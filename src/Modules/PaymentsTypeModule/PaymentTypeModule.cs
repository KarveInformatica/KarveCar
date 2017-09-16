using Microsoft.Practices.Unity;
using PaymentTypeModule.ChargeClients.View;
using PaymentTypeModule.ChargeClients.ViewModel;
using Prism.Modularity;
using Prism.Regions;

namespace PaymentTypeModule
{

        public class PaymentTypeModule : IModule
        {
            private readonly IUnityContainer _container;
            private IRegionManager _regionManager;
          
            public PaymentTypeModule(IUnityContainer container, IRegionManager regionManager)
            {
                _container = container;
                _regionManager = regionManager;
            }

            protected void RegisterViewsAndServices()
            {
                _container.RegisterType<IPaymentViewModule, ClientChargeViewModel>();
                _container.RegisterType<IPaymentView, ClientChargeView>();
            }
            public void Initialize()
            {
                RegisterViewsAndServices();
            }
        }
}
