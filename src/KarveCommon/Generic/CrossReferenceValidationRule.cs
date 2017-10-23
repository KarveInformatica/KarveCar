using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;

namespace KarveCommon.Generic
{
    public class CrossReferenceValidationRule: SqlValidationRule
    {
        public override bool Validate(DataPayLoad request)
        {
            return false;
        }
    }
}
