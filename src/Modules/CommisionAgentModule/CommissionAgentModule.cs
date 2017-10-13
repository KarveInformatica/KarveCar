using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommisionAgent.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace CommissionAgentModule
    {
        public class  CommissionAgentModule : IModule
        {
            private readonly IUnityContainer _container;
            private IRegionManager _regionManager;
            public const string NAME = "ProvideModule";

            public CommissionAgentModule(IUnityContainer container, IRegionManager regionManager)
            {
                _container = container;
                _regionManager = regionManager;
            }
            protected void RegisterViewsAndServices()
            {
               // _container.RegisterType<IProvidersViewModel, ProvidersModule.ViewModels.ProvidersControlViewModel>();
               // _container.RegisterType<IProvidersView, ProvidersModule.Views.ProvidersControl>();
               // _container.RegisterType<ISupplierInfoView, ProvidersModule.Views.ProviderInfoView>();
            }
            public void Initialize()
            {
                RegisterViewsAndServices();
            }
        }

    }
}
