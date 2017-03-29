using System;
using Microsoft.Practices.Unity;
using Prism.Unity;
using PrismUnityApp1.Views;
using System.Windows;
using System.Windows.Controls;
using Prism.Regions;
using PrismUnityApp1.ViewModels;

namespace PrismUnityApp1
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<object, View1>("View1");
            Container.RegisterType<object, View2>("View2");
        }

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            var regionManager = this.Container.Resolve<IRegionManager>();

            //regionManager.RequestNavigate("ContentRegion", "View1");
            //regionManager.RequestNavigate("ContentRegion", "View2");

            ((Shell as FrameworkElement).DataContext as MainWindowViewModel).Initialize();

            regionManager.AddToRegion("ContentRegion", Container.Resolve<object>("View1"));
            regionManager.AddToRegion("ContentRegion", Container.Resolve<object>("View2"));

            Application.Current.MainWindow.Show();
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var mappings = base.ConfigureRegionAdapterMappings();

            mappings.RegisterMapping(typeof(TabControl), Container.Resolve<TabControlRegionAdapter>());

            return mappings;
        }
    }
}
