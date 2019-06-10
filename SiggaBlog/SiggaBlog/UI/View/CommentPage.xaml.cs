using SiggaBlog.UI.Model;
using SiggaBlog.UI.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SiggaBlog.UI.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommentPage : ContentPage
    {
        public CommentPage(PostModel post)
        {
            InitializeComponent();

            BindingContext = new CommentViewModel(post);
        }
    }
}