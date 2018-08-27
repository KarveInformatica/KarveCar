using KarveDataServices.ViewObjects;
using System.Collections.Generic;

namespace KarveDataServices.DataObjects
{
    public interface IHelperMasterCommon
    {
        /// <summary>
        ///  Branches
        /// </summary>
        IEnumerable<BranchesViewObject> BranchesDto { set; get; }

        /// <summary>
        ///  Contacts
        /// </summary>
        IEnumerable<ContactsViewObject> ContactsDto { set; get; }
        /// <summary>
        ///  visits data transfer.
        /// </summary>
        IEnumerable<VisitsViewObject> VisitsDto { get; set; }


    }
}