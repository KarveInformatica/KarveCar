using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace KarveCommon.Generic
{
    /// <summary>
    ///  This perform the data validation in case of saving an office.
    /// </summary>
    public class OfficeDtoValidation : ValidationChain<DataPayLoad>
    {
        /// <summary>
        ///  Validate the DataPayload
        /// </summary>
        /// <param name="request">Request to be validated</param>
        /// <returns></returns>
        public override bool Validate(DataPayLoad req)
        {
          
            if (!req.HasDataObject)
            {
                return true;
            }
            var dtos = new OfficeDtos();
            switch (req.DataObject)
            {
                case IOfficeData dataObject:
                    dtos = dataObject.Value;
                    break;
                case OfficeDtos dto:
                    dtos = dto;
                    break;
            }
            return !string.IsNullOrEmpty(dtos.Codigo);
        }
    }
}
