using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCar.Model
{
    public class Supplier
    {
        public string Name { set; get; }
        public string TaxIdentifier { set; get; }
        public Address Address { set; get; }
        public List<Visit> Visits { set; get; }
        public List<Branch> Branches { set; get; }
        public List<Contact> Contacts { set; get; }

    }
}
