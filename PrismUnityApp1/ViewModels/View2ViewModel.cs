using System.Diagnostics;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Regions;

namespace PrismUnityApp1.ViewModels
{
    public class View2ViewModel : BindableBase, INavigationAware, ITabItemViewModel, IRegionMemberLifetime
    {
        public View2ViewModel()
        {
            Debug.WriteLine($"{nameof(View2ViewModel)} created");
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Debug.WriteLine($"{nameof(View2ViewModel)} OnNavigatedTo");

            Text = "Loading...";

            Task.Delay(2000).ContinueWith((t) => Text = "Loaded Complete!");
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public string Title => "View 2";
        public string ViewName => "View2";
        public bool KeepAlive => true;

        private string text;
        public string Text { get { return text; } private set { text = value; RaisePropertyChanged(); } }
    }
}