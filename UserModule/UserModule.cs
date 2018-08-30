namespace UserModule
{
    using global::UserModule.Service;
    using Microsoft.Practices.Unity;
    using Prism.Modularity;
    using Prism.Regions;
    using Prism.Unity;

    public class UserModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public UserModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
           
        }
    }
}