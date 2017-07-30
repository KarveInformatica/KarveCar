using KarveCommon.Services;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using DataAccessLayer;
using Prism.Regions;

namespace DataGridModule
{

    public class DataGridModule : IModule
    {
        private readonly IUnityContainer _container;
        private IDalLocator _dalLocator;
        private IRegionManager  _regionManager;
        private IConfigurationService _configurationService;

        public ToolBarModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        protected void RegisterViewsAndServices()
        {
            _undoService = _container.Resolve<ICareKeeperService>();
            _dalLocator = _container.Resolve<IDalLocator>();
            _configurationService = _container.Resolve<IConfigurationService>();
        }
        public void Initialize()
        {
            RegisterViewsAndServices();
            _regionManager.RegisterViewWithRegion("KarveToolBar", typeof(KarveToolBarView));
           
        }
    }

}
