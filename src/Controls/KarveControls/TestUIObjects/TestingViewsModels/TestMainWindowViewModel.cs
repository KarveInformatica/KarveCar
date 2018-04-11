using KarveControls.Interactivity;
using Microsoft.Practices.Unity;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUIComponents.TestingViewsModels
{
    class TestMainWindowViewModel: BindableBase
    {
        private IUnityContainer _unityContainer;
        private RequestController _controller = null;
       
        public TestMainWindowViewModel(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
            Controller = _unityContainer.Resolve<RequestController>();
            var l = new List<string>() { "name1", "name2", "name3" };
            SourceView = l;

        }

        public IUnityContainer UnityContainer
        {
            set
            {
                _unityContainer = value;
                Controller = _unityContainer.Resolve<RequestController>();

            }
            get
            {
                return _unityContainer;
            }
        }
        /// <summary>
        /// Set or Get the source view.
        /// </summary>
        public object SourceView { set; get; }
        public object SelectedItem { set; get; }
        /// <summary>
        ///  Set or Get The controller.
        /// </summary>
        public RequestController Controller {
            set
            {
                _controller = value;
                RaisePropertyChanged();
            }
            get
            {
                return _controller;
            }
        }
    }
}
