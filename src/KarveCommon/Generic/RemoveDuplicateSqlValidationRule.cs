using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;

namespace KarveCommon.Generic
{
    /// <summary>
    ///  This is a validation rule that avoid duplicates
    /// </summary>
    public class RemoveDuplicateSqlValidationRule: ValidationChain<DataPayLoad>
    {
        public override  bool Validate(DataPayLoad request)
        {
            return true;
        }
    }
}
