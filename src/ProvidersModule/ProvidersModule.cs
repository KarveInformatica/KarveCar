using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProvidersModule.View;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace ProvidersModule
{
    public class ProviderModule : IModule
    {
        private readonly IUnityContainer _container;
        private IRegionManager _regionManager;

        public ProviderModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        protected void RegisterViewsAndServices()
        {
            //_container.RegisterType<I, ProvidersModule.ProviderControl>();
            _container.RegisterType<IProvidersView, ProvidersModule.View.ProvidersControl>();
        }
        public void Initialize()
        {
            RegisterViewsAndServices();
        //    _regionManager.RegisterViewWithRegion("KarveToolBar", typeof(KarveToolBarView));

        }
    }
 
}
