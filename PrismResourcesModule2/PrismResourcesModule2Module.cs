using Prism.Modularity;
using Prism.Regions;
using System;

namespace PrismResourcesModule2
{
    public class PrismResourcesModule2Module : IModule
    {
        IRegionManager _regionManager;

        public PrismResourcesModule2Module(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}