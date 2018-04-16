using KarveDataServices.DataTransferObject;
using System.Collections.Generic;

namespace KarveDataServices.DataObjects
{
    public interface IHelperMasterCommon
    {
        /// <summary>
        ///  Branches
        /// </summary>
        IEnumerable<BranchesDto> BranchesDto { set; get; }

        /// <summary>
        ///  Contacts
        /// </summary>
        IEnumerable<ContactsDto> ContactsDto { set; get; }
        /// <summary>
        ///  visits data transfer.
        /// </summary>
        IEnumerable<VisitsDto> VisitsDto { get; set; }


    }
}