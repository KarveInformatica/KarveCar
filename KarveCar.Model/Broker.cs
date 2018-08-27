using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCar.Model
{
    class Broker
    {
        public string Name { set; get; }
        public Address Address { set; get; }
        public List<Visit> Visits { set; get; }
        public List<Branch> Branches { set; get; }
        public List<Contact> Contacts { set; get; }
    }
}
