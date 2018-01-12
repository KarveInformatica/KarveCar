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
           _container.RegisterType<object, VehicleTypes>("VehiclesType");
            _container.RegisterType<object, VehicleRepostajeReason>("VehicleRepostajeReason");

        }
        public void Initialize()
        {
            RegisterViewsAndServices();
        }
    }
}
