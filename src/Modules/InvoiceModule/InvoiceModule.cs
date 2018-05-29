using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using InvoiceModule.Views;
using InvoiceModule.ViewModels;

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
        private const string ModuleName = "InvoiceModule";
        internal const string InvoiceSubSystem = "InvoiceSubsystem";

        /// <summary>
        ///  Return the name of the module
        /// </summary>
        public string Name => ModuleName;

        public static string InvoiceSubsystemName { get; internal set; }

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
            _container.RegisterType<object, InvoiceControlView>("InvoiceSummary");
            _container.RegisterType<object, InvoiceControlViewModel>("InvoiceControlVM");
            _container.RegisterType<object, InvoiceSummaryFooter>("InvoiceSummaryFooter");
            _container.RegisterType<object, InvoiceInfoViewModel>("InvoiceInfoViewModel");

        }
    }

}
