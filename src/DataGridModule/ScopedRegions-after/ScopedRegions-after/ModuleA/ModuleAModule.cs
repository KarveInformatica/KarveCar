using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using ModuleA.Views;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        private readonly IUnityContainer _container;

        public ModuleAModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<object, ViewA>("ViewA");
            _container.RegisterType<object, ViewB>("ViewB");
        }
    }
}
