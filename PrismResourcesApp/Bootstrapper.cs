using Microsoft.Practices.Unity;
using Prism.Unity;
using PrismResourcesApp.Views;
using System.Windows;
using Prism.Regions;
using PrismResourcesModule1.Views;
using PrismResourcesModule2.Views;

namespace PrismResourcesApp
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<object, View1>("View1");
            Container.RegisterType<object, View11>("View11");
            Container.RegisterType<object, View2>("View2");
        }

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            var regionManager = this.Container.Resolve<IRegionManager>();

            regionManager.AddToRegion("ContentRegion1", Container.Resolve<object>("View1"));
            regionManager.AddToRegion("ContentRegion11", Container.Resolve<object>("View11"));
            regionManager.AddToRegion("ContentRegion2", Container.Resolve<object>("View2"));

            Application.Current.MainWindow.Show();
        }
    }
}
