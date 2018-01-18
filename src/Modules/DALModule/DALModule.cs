using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace DataAccessLayer
{

        public class DALModule : IModule
        {
            private readonly IUnityContainer _container;
            private IRegionManager _regionManager;
          
            public DALModule(IUnityContainer container, IRegionManager regionManager)
            {
                _container = container;
                _regionManager = regionManager;
            }
            
        }
}
