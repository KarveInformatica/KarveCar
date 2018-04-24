using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataObjects;

namespace KarveCommon.Generic
{
    /// <summary>
    ///  SupplierValidationRule is a validation rule.
    /// </summary>
    public class SuppliersValidationRule: ValidationChain<DataPayLoad>
    {
        public override bool Validate(DataPayLoad request)
        {
            var value = request.DataObject as ISupplierData;
            if (value?.Value == null)
            {
                return false;
            }
            return !string.IsNullOrEmpty(value.Value.NUM_PROVEE);
        }        
    }
}
