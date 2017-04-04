using Prism.Modularity;
using Prism.Regions;
using System;

namespace PrismResourcesModule1
{
    public class PrismResourcesModule1Module : IModule
    {
        IRegionManager _regionManager;

        public PrismResourcesModule1Module(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }


        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}