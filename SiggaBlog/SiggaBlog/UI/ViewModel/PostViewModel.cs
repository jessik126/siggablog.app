using Autofac;
using Plugin.Connectivity;
using SiggaBlog.Domain.Entity;
using SiggaBlog.Mediator.Api;
using SiggaBlog.Mediator.DataBase;
using SiggaBlog.UI.Model;
using SiggaBlog.UI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SiggaBlog.UI.ViewModel
{
    public class PostViewModel : BaseViewModel
    {
        #region Properties - Private

        //data
        private readonly PostDatabase postDatabase;
        private readonly PostApi postApi;

        //view
        private IList<PostModel> postsModel;
        private PostModel postModel;

        private AlbumModel albumModel;

        private ICommand commentsCommand;
        private ICommand updateCommand;

        #endregion

        #region Properties - Public

        public IList<PostModel> PostsVM
        {
            get
            {
                return postsModel;
            }
            set
            {
                postsModel = value;

                if (postsModel == null || !postsModel.Any())
                {
                    return;
                }

                OnPropertyChanged("PostsVM");
            }
        }

        public PostModel PostVM
        {
            get
            {
                return postModel;
            }
            set
            {
                postModel = value;

                if (postModel == null)
                {
                    return;
                }

                DisplayCommentsCommand.Execute(postModel);

                OnPropertyChanged("PostVM");

                PostVM = null;
            }
        }

        public AlbumModel AlbumVM
        {
            get
            {
                return albumModel;
            }
            set
            {
                albumModel = value;

                if (albumModel == null)
                {
                    return;
                }

                OnPropertyChanged("AlbumVM");
            }
        }


        #endregion

        #region Constructor 

        public PostViewModel(AlbumModel albumSelected)
        {
            postDatabase = App.Container.Resolve<PostDatabase>();
            postApi = App.Container.Resolve<PostApi>();

            albumModel = albumSelected;

            GetDatabase();
        }

        #endregion

        #region Methods - Public

        public ICommand DisplayCommentsCommand
        {
            get
            {
                return commentsCommand ?? (commentsCommand = new Command(DisplayComments));
            }
        }

        public async void DisplayComments()
        {
            try
            {
                CommentPage page = new CommentPage(PostVM);
                await PushAsync(page);
            }
            catch (Exception ex)
            {
                await Dialog.AlertAsync(ex.Message, "Erro", "Ok");
            }
        }

        public ICommand UpdateCommand
        {
            get
            {
                return updateCommand ?? (updateCommand = new Command(() => GetDatabase(true)));
            }
        }

        #endregion

        #region Methods - Private

        private async void GetDatabase(bool updateAll = false)
        {
            await UpdateDatabase(updateAll);

            PostsVM = postDatabase.Get()
                .Where(i => i.AlbumId == albumModel.Id)
                .Select(i => new PostModel
                {
                    Id = i.Id,
                    Title = i.Title,
                    Body = i.Body,
                    AlbumId = i.AlbumId,
                    AlbumTitle = albumModel.Title
                }).ToList();

            if (PostsVM == null || !PostsVM.Any())
            {
                Dialog.Toast("No posts found.", new TimeSpan(5));
            }
        }

        private async Task<bool> UpdateDatabase(bool updateAll)
        {
            Dialog.ShowLoading("Updating all data");

            if (updateAll)
            {
                postDatabase.DeleteAll();
            }

            var result = await GetApiToDatabase();

            Dialog.HideLoading();

            return result;
        }

        private async Task<bool> GetApiToDatabase()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var posts = await postApi.Get("albumId", albumModel.Id.ToString());

                foreach (var post in posts)
                {
                    var postDb = postDatabase.Get(i => i.Id == post.Id);
                    if (postDb.Any())
                    {
                        continue;
                    }

                    var postToInsert = new PostEntity()
                    {
                        Id = post.Id,
                        Title = post.Title,
                        Body = post.Body,
                        AlbumId = post.AlbumId
                    };

                    postDatabase.Insert(postToInsert);
                }

                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }

        #endregion
    }
}
