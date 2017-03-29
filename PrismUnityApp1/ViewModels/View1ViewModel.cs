using System.Diagnostics;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Regions;

namespace PrismUnityApp1.ViewModels
{
    public class View1ViewModel : BindableBase, INavigationAware, ITabItemViewModel, IRegionMemberLifetime
    {
        private readonly IRegionManager _regionManager;

        public View1ViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            Debug.WriteLine($"{nameof(View1ViewModel)} created");
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Debug.WriteLine($"{nameof(View1ViewModel)} OnNavigatedTo");

            _regionManager.Regions["ContentRegion"].NavigationService.Navigating += (sender, args) => Debug.WriteLine($"Navigating to {args.Uri}");
            _regionManager.Regions["ContentRegion"].NavigationService.Navigated += (sender, args) => Debug.WriteLine($"Navigated to {args.Uri}");
            _regionManager.Regions["ContentRegion"].NavigationService.NavigationFailed += (sender, args) => Debug.WriteLine($"Navigation failed to {args.Uri}");

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

        public string Title => "View 1";
        public string ViewName => "View1";
        public bool KeepAlive => true;

        private string text;
        public string Text { get { return text; } private set { text = value; RaisePropertyChanged(); } }
    }
}
