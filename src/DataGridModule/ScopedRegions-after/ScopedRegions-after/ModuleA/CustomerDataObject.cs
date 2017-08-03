using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Mvvm;

namespace ModuleA
{
    
    /// <summary>
    /// A simple data object
    /// </summary>
    public class CustomerDataObject
    {
        public string Id { get; set; }

        public string CompanyName { get; set; }

        public string ContactName { get; set; }
    }
    
}
