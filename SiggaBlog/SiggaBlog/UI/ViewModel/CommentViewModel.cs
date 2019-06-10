using Autofac;
using Plugin.Connectivity;
using SiggaBlog.Domain.Entity;
using SiggaBlog.Mediator.Api;
using SiggaBlog.Mediator.DataBase;
using SiggaBlog.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SiggaBlog.UI.ViewModel
{
    public class CommentViewModel : BaseViewModel
    {
        #region Properties - Private

        //data
        private readonly CommentDatabase commentDatabase;
        private readonly CommentApi commentApi;

        //view
        private IList<CommentModel> commentsModel;
        private CommentModel commentModel;

        private PostModel postModel;

        private ICommand updateCommand;

        #endregion

        #region Properties - Public

        public IList<CommentModel> CommentsVM
        {
            get
            {
                return commentsModel;
            }
            set
            {
                commentsModel = value;

                if (commentsModel == null || !commentsModel.Any())
                {
                    return;
                }

                OnPropertyChanged("CommentsVM");
            }
        }

        public CommentModel CommentVM
        {
            get
            {
                return commentModel;
            }
            set
            {
                commentModel = value;

                if (commentModel == null)
                {
                    return;
                }

                OnPropertyChanged("CommentVM");
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

                OnPropertyChanged("PostVM");
            }
        }


        #endregion

        #region Constructor

        public CommentViewModel(PostModel postSelected)
        {
            commentDatabase = App.Container.Resolve<CommentDatabase>();
            commentApi = App.Container.Resolve<CommentApi>();

            PostVM = postSelected;

            GetDatabase();
        }

        #endregion

        #region Methods - Public

        public ICommand UpdateCommand
        {
            get
            {
                return updateCommand ?? (updateCommand = new Command(() => GetDatabase(true)));
            }
        }

        #endregion

        #region Methods - Private

        public async void GetDatabase(bool updateAll = false)
        {
            await UpdateDatabase(updateAll);

            CommentsVM = commentDatabase.Get()
                .Where(i => i.PostId == PostVM.Id)
                .Select(i => new CommentModel
                {
                    Id = i.Id,
                    Comment = i.Comment,
                    Name = i.Name,
                    Email = i.Email,
                    PostId = i.PostId
                }).ToList();

            if (CommentsVM == null || !CommentsVM.Any())
            {
                Dialog.Toast("No comments found.", new TimeSpan(5));
            }
        }

        private async Task<bool> UpdateDatabase(bool updateAll)
        {
            Dialog.ShowLoading("Updating all data");

            if (updateAll)
            {
                commentDatabase.DeleteAll();
            }

            var result = await GetApiToDatabase();

            Dialog.HideLoading();

            return result;
        }

        private async Task<bool> GetApiToDatabase()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var comments = await commentApi.Get("postId", PostVM.Id.ToString());

                foreach (var comment in comments)
                {
                    var commentDb = commentDatabase.Get(i => i.Id == comment.Id);
                    if (commentDb.Any())
                    {
                        continue;
                    }

                    var commentToInsert = new CommentEntity()
                    {
                        Id = comment.Id,
                        Comment = comment.Body,
                        Name = comment.Name,
                        Email = comment.Email,
                        PostId = comment.PostId
                    };

                    commentDatabase.Insert(commentToInsert);
                }

                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);

        }

        #endregion

    }
}
