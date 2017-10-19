using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterModule.Interfaces;
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

        internal const string ProviderSubsystemName = "ProviderSystem";
        internal const string ImagePath = "/MasterModule;component/Images/search.png";
        internal const string EmailImagePath = "/MasterModule;component/Images/email.png";
        internal const string UiUpperPart = "UpperPartPageBuilder";
        internal const string UiMiddlePartPage = "UiMiddlePartPageBuilder";
        internal const string UiLeftPartPage = "UiLeftPartPageBuilder";
        internal const string UiRightPartPage = "UiRightPartPageBuilder";
        internal const string CommissionAgentSystemName = "CommissionAgentSystem";
        internal const string CommissionAgentInfoView = "CommissionAgentInfoView";
        internal const string VehiclesSystemName = "VehiclesSystemName";
        internal const string VehiclesSystemInfoView = "CommissionAgentInfoView";
        internal const string FareSystemName = "VehiclesSystemName";
        internal const string FareSystemInfoView = "CommissionAgentInfoView";


        public MasterModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

       
        protected void RegisterViewsAndServices()
        {
            _container.RegisterType<ISupplierInfoView, ProviderInfoView>();
            _container.RegisterType<ICommissionAgentView, CommissionAgentInfoView>();
            _container.RegisterType<object, CommissionAgentControlView>("CommissionAgent");
            _container.RegisterType<object, ClientsControlView>("Clients");
            _container.RegisterType<object, ProvidersControl>("Suppliers");
            _container.RegisterType<object, VehiclesControlView>("Vehicles");
            //_container.RegisterType<object, >("");


        }
        public void Initialize()
        {
            RegisterViewsAndServices();
        }

        
    }

}
