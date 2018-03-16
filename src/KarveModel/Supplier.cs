using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveModel
{
    /// <summary>
    ///  This model a supplier.
    /// </summary>
    public class Supplier : DomainObject
    {
        public override void AcceptChanges()
        {

        }
        public override IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }

        public override void RejectChanges()
        {
            throw new NotImplementedException();
        }
    }
}
