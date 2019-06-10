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
    public class AlbumViewModel : BaseViewModel
    {
        #region Properties - Private

        //data
        private readonly AlbumDatabase albumDatabase;
        private readonly AlbumApi albumApi;
        private readonly PhotoApi photoApi;
        private readonly UserApi userApi;

        //view
        private IList<AlbumModel> albumsModel;
        private AlbumModel albumModel;

        private ICommand postsCommand;
        private ICommand updateCommand;

        #endregion

        #region Properties - Public

        public IList<AlbumModel> AlbumsVM
        {
            get
            {
                return albumsModel;
            }
            set
            {
                albumsModel = value;

                if (albumsModel == null || !albumsModel.Any())
                {
                    return;
                }

                OnPropertyChanged("AlbumsVM");
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

                DisplayPostsCommand.Execute(albumModel);

                OnPropertyChanged("AlbumVM");

                AlbumVM = null;
            }
        }

        #endregion

        #region Constructor

        public AlbumViewModel()
        {
            albumDatabase = App.Container.Resolve<AlbumDatabase>();
            albumApi = App.Container.Resolve<AlbumApi>();
            photoApi = App.Container.Resolve<PhotoApi>();
            userApi = App.Container.Resolve<UserApi>();

            GetDatabase();
        }

        #endregion

        #region Methods - Public

        public ICommand DisplayPostsCommand
        {
            get
            {
                return postsCommand ?? (postsCommand = new Command(DisplayPosts));
            }
        }

        public async void DisplayPosts()
        {
            try
            {
                PostPage page = new PostPage(AlbumVM);
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

        #region Methods - Public

        private async void GetDatabase(bool updateAll = false)
        {
            await UpdateDatabase(updateAll);

            AlbumsVM = albumDatabase.Get().Select(i => new AlbumModel
            {
                Id = i.Id,
                Title = i?.Title,
                Photo = i?.Photo,
                User = i?.User
            }).ToList();

            if (AlbumsVM == null)
            {
                Dialog.Alert("Album empty. Try again later", "Erro", "Ok");
            }
        }

        private async Task<bool> UpdateDatabase(bool updateAll)
        {
            Dialog.ShowLoading("Updating all data");

            if (updateAll)
            {
                albumDatabase.DeleteAll();
            }

            var result = await GetApiToDatabase();

            Dialog.HideLoading();

            return result;
        }

        private async Task<bool> GetApiToDatabase()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var albums = await albumApi.Get();

                foreach (var album in albums)
                {
                    var albumDb = albumDatabase.Get(i => i.Id == album.Id);
                    if (albumDb.Any())
                    {
                        continue;
                    }

                    var photo = (await photoApi.Get("albumId", album.Id.ToString())).FirstOrDefault();
                    var user = await userApi.Get(album.UserId);

                    var albumToInsert = new AlbumEntity()
                    {
                        Id = album.Id,
                        Title = album?.Title,
                        Photo = photo?.ThumbnailUrl,
                        User = user?.Name
                    };

                    albumDatabase.Insert(albumToInsert);
                }

                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }

        #endregion
    }
}
