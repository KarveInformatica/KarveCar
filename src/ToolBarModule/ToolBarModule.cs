using System.ComponentModel;
using KarveCommon;
using KarveCommon.Services;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using ToolBarModule.View;
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

        public ToolBarModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {

            _regionManager.RegisterViewWithRegion("KarveToolBar", typeof(KarveToolBar));
            _undoService = _container.Resolve<ICareKeeperService>();
            _dalLocator = _container.Resolve<IDalLocator>();

        }
    }

}
