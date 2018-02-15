using KarveDataServices.DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices
{
    public interface IOfficeDataServices
    {
        /// <summary>
        ///  This give us the summary query.
        /// </summary>
        /// <returns></returns>
        Task<DataSet> GetAsyncAllOfficeSummary();
        /// <summary>
        /// This return a client with a new code.
        /// </summary>
        /// <param name="code">Code to return.</param>
        /// <returns></returns>
        IOfficeData GetNewOfficeDo(string code);
        /// <summary>
        ///  This is a delete client.
        /// </summary>
        Task<bool> DeleteOfficeAsyncDo(IOfficeData commissionAgent);
        /// <summary>
        ///  This save the office data.
        /// </summary>
        /// <param name="clientData"></param>
        /// <returns>true or false in case of a client.</returns>
        Task<bool> SaveAsync(IOfficeData clientData);
        /// <summary>
        ///  Client data object
        /// </summary>
        /// <param name="clientIndentifier">Identifier a client</param>
        /// <returns>Client data to receive</returns>
        Task<IOfficeData> GetAsyncOfficeDo(string clientIndentifier);
        /// <summary>
        ///  This generate an unique id following the entity.
        /// </summary>
        /// <returns></returns>
        string GetNewId();
        /// <summary>
        ///  Get the list of the company offices.
        /// </summary>
        /// <param name="companyCode">Code of the company</param>
        /// <returns></returns>
        Task<IEnumerable<OfficeSummaryDto>> GetCompanyOffices(string companyCode);
    }
}
