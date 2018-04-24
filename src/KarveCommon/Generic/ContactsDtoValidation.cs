using KarveCommon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommonInterfaces;
using KarveDataServices.DataTransferObject;

namespace KarveCommon.Generic
{
    /// <summary>
    ///  RelatedDtoValidation
    /// </summary>
    public class RelatedDtoValidation : ValidationChain<DataPayLoad>
    {
        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="request">Request to be validated.</param>
        /// <returns></returns>
        public override bool Validate(DataPayLoad request)
        {
            if (request.HasRelatedObject)
            {
                var relatedObject = request.RelatedObject;
                switch (relatedObject)
                {
                    case BranchesDto valueBranchesDto:
                        return (!string.IsNullOrEmpty(valueBranchesDto.BranchKeyId)
                                && (!string.IsNullOrEmpty(valueBranchesDto.BranchId)));
                    case ContactsDto valueContactsDto:
                        return (!string.IsNullOrEmpty(valueContactsDto.ContactId)
                                && (!string.IsNullOrEmpty(valueContactsDto.ContactsKeyId)));
                }
            }
            return false;
        }
    }
}
