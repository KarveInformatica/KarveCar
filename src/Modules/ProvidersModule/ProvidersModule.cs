using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterModule.ViewModels;
using MasterModule.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace MasterModule
{
    public class MasterModule : IModule
    {
        private readonly IUnityContainer _container;
        private IRegionManager _regionManager;
        public const string NAME = "MasterModule";

        public MasterModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }
        protected void RegisterViewsAndServices()
        {
            _container.RegisterType<IProvidersViewModel, ProvidersControlViewModel>();
            _container.RegisterType<IProvidersView, ProvidersControl>();
            _container.RegisterType<ISupplierInfoView, ProviderInfoView>();
        }
        public void Initialize()
        {
            RegisterViewsAndServices();
        }
    }

}
