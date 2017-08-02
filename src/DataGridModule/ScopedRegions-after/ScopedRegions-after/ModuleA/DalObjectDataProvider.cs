using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA
{
    public class DalObjectDataProvider
    {
          public CustomerUIObjects GetCustomers()
          {
            CustomerUIObjects cu = new CustomerUIObjects();
            CustomerDataObject co = new CustomerDataObject();
            co.Id = "gz";
            co.CompanyName = "HP";
            co.ContactName = "giorgio.zoppi@hp.com";
            cu.Add(new CustomerUIObject(co));
            CustomerDataObject co1 = new CustomerDataObject();
            co1.Id = "gz";
            co1.CompanyName = "G&D";
            co1.ContactName = "giorgio.zoppi@gi-de.com";
            cu.Add(new CustomerUIObject(co1));
            return cu;
          }
    }
}
