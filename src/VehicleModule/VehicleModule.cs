using Microsoft.Practices.Unity;
using VehicleModule.VehicleGroup.View.
using Prism.Modularity;
using Prism.Regions;

namespace VehicleModule
{

        public class VehicleModuleModule : IModule
        {
            private readonly IUnityContainer _container;
            private IRegionManager _regionManager;
          
            public VehicleModule(IUnityContainer container, IRegionManager regionManager)
            {
                _container = container;
                _regionManager = regionManager;
            }

            protected void RegisterViewsAndServices()
            {
                _container.RegisterType<IVehicleViewModel, ClientChargeViewModel>();
                _container.RegisterType<IVehicleView, ClientChargeView>();
            }
            public void Initialize()
            {
                RegisterViewsAndServices();
            }
        }
}
