using Autofac;
using Refit;
using SiggaBlog.Data.Repository;
using SiggaBlog.Domain.Constant;
using SiggaBlog.Domain.Interface.Api;
using SiggaBlog.Domain.Interface.Repository;
using SiggaBlog.Mediator.Api;
using SiggaBlog.Mediator.DataBase;
using SiggaBlog.UI.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SiggaBlog
{
    public partial class App : Application
    {
        public static IContainer Container { get; private set; }

        public static INavigation Navigation { get; private set; }

        public App()
        {
            InitializeComponent();

#if DEBUG
            HotReloader.Current.Start(this);
#endif
            IoC();

            MainPage = new NavigationPage(new AlbumPage());
            Navigation = MainPage.Navigation;
        }

        private void IoC()
        {
            var builder = new ContainerBuilder();

            //api register
            builder.RegisterInstance(new AlbumApi(RestService.For<IAlbumApi>(Url.url)));
            builder.RegisterInstance(new CommentApi(RestService.For<ICommentApi>(Url.url)));
            builder.RegisterInstance(new PhotoApi(RestService.For<IPhotoApi>(Url.url)));
            builder.RegisterInstance(new PostApi(RestService.For<IPostApi>(Url.url)));
            builder.RegisterInstance(new UserApi(RestService.For<IUserApi>(Url.url)));

            //repository register
            builder.RegisterType<AlbumRepository>().As<IAlbumRepository>();
            builder.RegisterType<AlbumDatabase>();
            builder.RegisterType<CommentRepository>().As<ICommentRepository>();
            builder.RegisterType<CommentDatabase>();
            builder.RegisterType<PostRepository>().As<IPostRepository>();
            builder.RegisterType<PostDatabase>();

            Container = builder.Build();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
