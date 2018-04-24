using KarveDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices.DataObjects;

namespace KarveCommon.Generic
{
    /// <summary>
    ///  This rule is validation rule before saving a vehicle.
    /// </summary>
    public class VehicleValidationRule : ValidationChain<DataPayLoad>
    {
      /// <inheritdoc />
      /// <summary>
      ///  Validate is a vehicle validation rule
      /// </summary>
      /// <param name="request">Request to be validated</param>
      /// <returns>True of the validation is correct.</returns>
        public override bool Validate(DataPayLoad request)
        {
            var value = request.DataObject as IVehicleData;
            if (value?.Value == null)
            {
                return false;
            }
            var currentDto = value.Value;
            return !string.IsNullOrEmpty(currentDto.CODIINT);
        }
    }
}
