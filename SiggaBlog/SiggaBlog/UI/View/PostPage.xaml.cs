using SiggaBlog.UI.Model;
using SiggaBlog.UI.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SiggaBlog.UI.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostPage : ContentPage
    {
        public PostPage(AlbumModel album)
        {
            InitializeComponent();

            BindingContext = new PostViewModel(album);
        }
    }
}