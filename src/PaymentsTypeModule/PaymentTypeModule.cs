using DataAccessLayer;
using KarveCommon.Services;
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
            private ICareKeeperService _undoService;
            private IDalLocator _dalLocator;
            private IRegionManager _regionManager;
            private IConfigurationService _configurationService;

            public PaymentTypeModule(IUnityContainer container, IRegionManager regionManager)
            {
                _container = container;
                _regionManager = regionManager;
            }

            protected void RegisterViewsAndServices()
            {
                _container.RegisterType<IPaymentViewModule, ClientChargeViewModel>();
                _container.RegisterType<IPaymentView, ClientChargeView>();
                _undoService = _container.Resolve<ICareKeeperService>();
                _dalLocator = _container.Resolve<IDalLocator>();
                _configurationService = _container.Resolve<IConfigurationService>();
            }
            public void Initialize()
            {
                RegisterViewsAndServices();
            }
        }
}
