using KarveCommon.Services;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using DataAccessLayer;
using Prism.Regions;

namespace ToolBarModule
{

    public class ToolBarModule : IModule
    {
        private readonly IUnityContainer _container;
        private ICareKeeperService _undoService;
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
            _container.RegisterType<IToolBarViewModel, KarveToolBarViewModel>();
            _container.RegisterType<IToolBarView, KarveToolBarView>();
            _undoService = _container.Resolve<ICareKeeperService>();
            _dalLocator = _container.Resolve<IDalLocator>();
            _configurationService = _container.Resolve<IConfigurationService>();
        }
        public void Initialize()
        {
            RegisterViewsAndServices();
            _regionManager.RegisterViewWithRegion("KarveDataGrid", typeof(KarveToolBarView));
           
        }
    }

}
