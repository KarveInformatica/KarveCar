using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karve.Interactivity
{
    /// <summary>
    ///  This is the interactivity module.
    /// </summary>
    class InteractivityModule: IModule
    {
        private readonly IUnityContainer _container;
        public InteractivityModule(IUnityContainer container)
        {
            _container = container;
        }
        public void Initialize()
        {
            _container.RegisterType<IModalViewModel, InteractionRequestViewModel>();
            _container.RegisterType<IModalView, InteractionRequestView>();
            _container.RegisterType<object, InteractionRequestContoller
        }
    }
}
