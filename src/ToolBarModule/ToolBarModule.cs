using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace ToolBarModule
{
    public class ToolBarModule : IModule
    {
        private readonly IUnityContainer _container;
        private IRegionManager _regionManager;
        
        public ToolBarModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        protected void RegisterViewsAndServices()
        {
            _container.RegisterType<IToolBarViewModel, KarveToolBarViewModel>();
            _container.RegisterType<IToolBarView, KarveToolBarView>();
        }
        public void Initialize()
        {
            RegisterViewsAndServices();
            _regionManager.RegisterViewWithRegion("KarveToolBar", typeof(KarveToolBarView));

        }
    }
}
