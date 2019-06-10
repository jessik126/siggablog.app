using SiggaBlog.UI.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SiggaBlog.UI.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlbumPage : ContentPage
    {
        public AlbumPage()
        {
            InitializeComponent();

            BindingContext = new AlbumViewModel();
        }
    }
}