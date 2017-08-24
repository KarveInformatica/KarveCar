using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProvidersModule.Views;
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
            _container.RegisterType<IEventManager, ProvidersModule.EventManager>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IProvidersViewModel, ProvidersModule.ViewModels.ProvidersControlViewModel>();
            _container.RegisterType<IProvidersView, ProvidersModule.Views.ProvidersControl>();
            _container.RegisterType<object, SupplierView>("SupplierView");
            _container.RegisterType<object, GenericGridView>("GenericGridView");
            _container.RegisterType<object, BasicEditorView>("BasicEditorView");
            _container.RegisterType<IRegionNavigationContentLoader, ScopedRegionNavigationContentLoader>(new ContainerControlledLifetimeManager());
        }
        public void Initialize()
        {
            RegisterViewsAndServices();
        }
    }

}
