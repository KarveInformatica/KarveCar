using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using InvoiceModule.Views;

namespace InvoiceModule
{ 
    /// <summary>
    ///  InvoiceModule. 
    ///  This is a module for initializing.
    /// </summary>
    public class InvoiceModule : IModule
    {
        private readonly IUnityContainer _container;
        private IRegionManager _regionManager;
        private const string _name = "InvoiceModule";
        /// <summary>
        ///  Return the name of the module
        /// </summary>
        public string Name => _name;
        /// <summary>
        /// Module to handle an invoice.
        /// </summary>
        /// <param name="container">Container to be used in an invoice</param>
        /// <param name="regionManager">Region Manager</param>
        public InvoiceModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }
        /// <summary>
        ///  This initialize the values.
        /// </summary>
        public void Initialize()
        {
            _container.RegisterType<object, InvoiceControlView>("Invoices");
            _container.RegisterType<object, InvoiceInfoView>(typeof(InvoiceInfoView).FullName);
          //  _container.RegisterTypeForNavigation<InvoiceInfoView>(typeof(InvoiceInfoViewModel).FullName)
            _container.RegisterTypeForNavigation<LineGridView>();
            _container.RegisterTypeForNavigation<GenericGridView>();
           // var navigationParameters = new NavigationParameters();
            //_regionManager.RequestNavigate("LineRegion", "LineGridView");
            //_regionManager.RegisterViewWithRegion("HeaderRegion", typeof(Views.HeaderDataView));
        }
    }

}
