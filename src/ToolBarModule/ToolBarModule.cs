using Microsoft.Practices.Unity;
using Prism.Modularity;

namespace KarveCar.ToolBarModule
{

    public class ToolBarModule : IModule
    {
        private readonly IUnityContainer _container;

        public ToolBarModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
        //    _container.RegisterType<object, ViewA>("ViewA");
        //   _container.RegisterType<object, ViewB>("ViewB");
        }
    }

}
