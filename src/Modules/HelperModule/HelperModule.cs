using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using HelperModule.Views;
using KarveDataServices;

namespace HelperModule
{ 
    /// <summary>
    ///  Helper Module.
    /// </summary>
    public class HelperModule : IModule
    {
        private readonly IUnityContainer _container;
        private IRegionManager _regionManager;
        public const string NAME = "HelperModule";

        public HelperModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
            
        }
        protected void RegisterViewsAndServices()
        {
            _container.RegisterType<object, BudgetKey>("BudgetKey");
            _container.RegisterType<object, Business>("Business");
            _container.RegisterType<object, Cities>("Cities");
            _container.RegisterType<object, Channel>("Channel");
            _container.RegisterType<object, ClientBanks>("ClientBanks");
            _container.RegisterType<object, ClientInvoiceBlocks>("ClientInvoiceBlocks");
            _container.RegisterType<object, ClientOrigin> ("ClientLocation");
            _container.RegisterType<object, ClientType>("ClientType");
            _container.RegisterType<object, CreditCard>("CreditCard");
            _container.RegisterType<object, Country>("Country");
            _container.RegisterType<object, ContactType>("ContactType");
            _container.RegisterType<object, CompanyCard>("CompanyCard");
            _container.RegisterType<object, PeoplePosition>("PeoplePosition");
            _container.RegisterType<object, Market>("Market");
            _container.RegisterType<object, VisitType>("VisitType");
            _container.RegisterType<object, Province>("Province");
            _container.RegisterType<object, VehicleActivities>("VehicleActivities");
            _container.RegisterType<object, VehicleBrand>("VehicleBrand");
            _container.RegisterType<object, VehicleColors>("VehicleColors");
            _container.RegisterType<object, VehicleGroup>("VehicleGroup");
            _container.RegisterType<object, VehicleManteinanceCode>("VehicleMantienanceCode");
            _container.RegisterType<object, VehicleTypes>("VehiclesType");
            _container.RegisterType<object, VehicleRepostajeReason>("VehicleRepostajeReason");
            _container.RegisterType<object, RentingUse>("RentingUse");
            _container.RegisterType<object, Resellers>("Resellers");
            _container.RegisterType<object, ClientZone>("ClientZone");
            _container.RegisterType<object, VehicleExtra>("VehicleExtra");
            _container.RegisterType<object, VehicleTools>("VehicleTools");
        
        }
        public void Initialize()
        {
            RegisterViewsAndServices();
        }
    }
}
