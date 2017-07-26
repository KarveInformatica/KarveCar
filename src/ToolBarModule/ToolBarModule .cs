using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBarModule
{

    public class ToolBarModule : IModule
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
