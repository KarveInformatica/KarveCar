using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarveDataServices.DataObjects
{
    /// <summary>
    /// The commission interface
    /// </summary>
    public interface ICommissionAgent
    {
        /// <summary>
        ///  This is valid.
        /// </summary>
        bool Valid { set; get; }
        /// <summary>
        ///  This is the country of a commission agent
        /// </summary>
        ICountryData Country { set; get; }
        /// <summary>
        ///  This is the type of commission agent.
        /// </summary>
       ICommissionAgentTypeData Type { set;get;}
        /// <summary>
        ///  This is the province data of a commission agent.
        /// </summary>
        IProvinceData ProvinceData { set; get; }
        /// <summary>
        ///  This is the contact list
        /// </summary>
        IEnumerable<IContactsData> Contacts { set; get; }
        /// <summary>
        ///  This is the list of the branches.
        /// </summary>
        IEnumerable<IBranchesData> Delegation { set; get; }
        /// <summary>
        /// This return the underlying database object COMISIO.
        /// We use this for avoiding any extensive wrapping of the object COMISIO.
        /// The object COMISIO is generated directly from the table.
        /// </summary>
        object Commission { set; get; }
        /// <summary>
        ///  This load the value for the current commission agent.
        /// </summary>
        /// <param name="commissionDictionary">Fields to be loaded</param>
        /// <param name="commissionId">Identifier to be loaded. Primary Key</param>
        /// <returns>Returns the result of loading.</returns>
        Task<bool> LoadValue(IDictionary<string, string> commissionDictionary, string commissionId);
        /// <summary>
        ///  This save a new generated item.
        /// </summary>
        /// <returns>Return true if the new generated item a fresh one is saved.</returns>
        Task<bool> Save();
        /// <summary>
        /// This saves the changes of a commission item. Use this method if it is appropriate to do an update. 
        /// </summary>
        Task<bool> SaveChanges();
        /// <summary>
        ///  This method deletes all data asynchronous for the commission agent.
        /// </summary>
        /// <returns>Return delete or an exception if the data are deleted correctly</returns>
        Task<bool> DeleteAsyncData();
    }
}