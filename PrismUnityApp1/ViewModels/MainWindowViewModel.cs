using System.Diagnostics;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace PrismUnityApp1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private string _title = "Prism Unity Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            Debug.WriteLine($"{nameof(MainWindowViewModel)} created");
        }

        public void Initialize()
        {
            var journal = _regionManager.Regions["ContentRegion"].NavigationService.Journal;

            BackCommand = new DelegateCommand(journal.GoBack, () => journal.CanGoBack);
            OnPropertyChanged("BackCommand");

            ForwardCommand = new DelegateCommand(journal.GoForward, () => journal.CanGoForward);
            OnPropertyChanged("ForwardCommand");

            _regionManager.Regions["ContentRegion"].NavigationService.Navigated += (sender, args) =>
            {
                BackCommand.RaiseCanExecuteChanged();
                ForwardCommand.RaiseCanExecuteChanged();
            };
        }
        

        public DelegateCommand BackCommand { get; private set; }
        public DelegateCommand ForwardCommand { get; private set; }
    }
}
