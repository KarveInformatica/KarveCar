using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace BusinessModule
{
    public class BusinessModuleModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public BusinessModuleModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }
        public void Initialize()
        {
          
        }
    }
}