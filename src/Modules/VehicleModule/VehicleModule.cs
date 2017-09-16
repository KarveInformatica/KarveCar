using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace VehicleModule
{

        public class VehicleModule : IModule
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
              //  _container.RegisterType<IVehicleViewModel, ClientChargeViewModel>();
              //  _container.RegisterType<IVehicleView, ClientChargeView>();
            }
            public void Initialize()
            {
                RegisterViewsAndServices();
            }
        }
}
