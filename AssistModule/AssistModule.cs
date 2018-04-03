using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using AssistModule.ViewModels;
using AssistModule.Views;

namespace AssistModule
{
    /// <summary>
    ///  The assist module is a module for showing a grid with data coming from a data service.
    /// </summary>
    public class AssistModule : IModule
    {
        private readonly IUnityContainer _container;
        /// <summary>
        ///  This is an assist module.
        /// </summary>
        /// <param name="container">This is a container for the module</param>
        public AssistModule(IUnityContainer container)
        {
            _container = container;
        }
        /// <summary>
        ///  This initialize the container for an assist module.
        /// </summary>
        public void Initialize()
        {
            _container.RegisterType<AssistServiceView>();
            _container.RegisterType<AssistServiceViewModel>();
        }
    }
}
