using KarveDataServices.DataObjects;
using System.Collections.Generic;
using System.Threading.Tasks;
using KarveDataServices.DataTransferObject;
namespace KarveDataServices
{
    /// <summary>
    ///  This interface specified all the service repository to handle the crud of a single office.
    /// </summary>
    public interface IOfficeDataServices
    {
        /// <summary>
        ///  This give us the summary query.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<OfficeSummaryDto>> GetAsyncAllOfficeSummary();
        /// <summary>
        /// This return a client with a new code.
        /// </summary>
        /// <param name="code">Code to return.</param>
        /// <returns></returns>
        IOfficeData GetNewOfficeDo(string code);
      /// <summary>
      ///  This function delete the office data.
      /// </summary>
      /// <param name="data">Data of the office.</param>
      /// <returns></returns>
        Task<bool> DeleteOfficeAsyncDo(IOfficeData data);
        /// <summary>
        ///  This save the office data.
        /// </summary>
        /// <param name="data">Office data to be saved</param>
        /// <returns>true or false in case of a client.</returns>
        Task<bool> SaveAsync(IOfficeData data);
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
        /// <returns>Returns the list of offices in a company</returns>
        Task<IEnumerable<OfficeSummaryDto>> GetCompanyOffices(string companyCode);
        /// <summary>
        ///  Returns just the holidays for a given office id.
        /// </summary>
        /// <param name="officeId">Office identifier</param>
        /// <returns>Holiday List</returns>
        Task<IEnumerable<HolidayDto>> GetHolidaysAsync(string officeId);
        /// <summary>
        /// This a time table.
        /// </summary>
        /// <param name="officeId">Identifier of the office</param>
        /// <param name="companyId">Identifier of the company</param>
        /// <returns></returns>
        Task<IEnumerable<DailyTime>> GetTimeTableAsync(string officeId, string companyId);
    }
}
