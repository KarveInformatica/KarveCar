using Microsoft.Practices.Unity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace InvoiceModule
{
    public class InvoiceModule
    {
        private readonly IUnityContainer _container;
        private IRegionManager _regionManager;
        private  const string _name = "InvoiceModule";
        /// <summary>
        ///  Return the name of the module
        /// </summary>
        public string Name => _name;
        public InvoiceModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }
    }
}
