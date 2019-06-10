using Acr.UserDialogs;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SiggaBlog.UI.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IUserDialogs Dialog { get; set; }

        public BaseViewModel()
        {
            Dialog = UserDialogs.Instance;
        }


        public async Task PushModalAsync(Page page)
        {
            if (App.Navigation != null)
                await App.Navigation.PushModalAsync(page);
        }

        public async Task PopModalAsync()
        {
            if (App.Navigation != null)
                await App.Navigation.PopModalAsync();
        }

        public async Task PushAsync(Page page)
        {
            if (App.Navigation != null)
                await App.Navigation.PushAsync(page);
        }

        public async Task PopAsync()
        {
            if (App.Navigation != null)
                await App.Navigation.PopAsync();
        }

        public void RemoveStackPages(Page exceptedPage = null)
        {
            var existingPages = App.Navigation.NavigationStack.ToList();
            foreach (var page in existingPages)
            {
                if (page != null && page == exceptedPage)
                    continue;

                App.Navigation.RemovePage(page);
            }
        }

        #region INotifyPropertyChanging implementation

        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;

        public void OnPropertyChanging(string propertyName)
        {
            if (PropertyChanging == null)
                return;

            PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
