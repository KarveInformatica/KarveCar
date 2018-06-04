using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarveDataServices
{
    /// <summary>
    ///  Common interface for each data service.
    /// </summary>
    /// <typeparam name="DomainType"></typeparam>
    /// <typeparam name="SummaryType"></typeparam>
    public interface IDataProvider<DomainType, SummaryType>
    {
        /// <summary>
        ///  Returns the list of summaryType. A summary type in the system is used for lookup grid.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SummaryType>> GetSummaryAllAsync();
        /// <summary>
        ///  This gets the domain type asynchronously. 
        ///  A domain type is made of a translated entity to data transfer object 
        ///  and its auxiliares data. 
        /// </summary>
        /// <param name="code">Code for retrieving the data</param>
        /// <returns>The invoice data.</returns>
        Task<DomainType> GetDoAsync(string code);
        /// <summary>
        /// Save or update an invoice
        /// </summary>
        /// <param name="bookingData">Data to book</param>
        /// <returns></returns>
        Task<bool> SaveAsync(DomainType bookingData);
        /// <summary>
        /// Generate a new domain type given an unique identifier.
        /// </summary>
        /// <param name="value">Booking value</param>
        /// <returns>Returns true if the data has been saved</returns>
        DomainType GetNewDo(string value);
        /// <summary>
        /// Data to await for in the invoice.
        /// </summary>
        /// <param name="booking">Booking data</param>
        /// <returns>Delete the booking values</returns>
        Task<bool> DeleteAsync(DomainType booking);
        /// <summary>
        /// Load the paged summary asynchronously.
        /// </summary>
        /// <param name="index">Index inside the paged stuff.</param>
        /// <param name="pageSize">Size of the page</param>
        /// <returns></returns>
        Task<IEnumerable<SummaryType>> GetPagedSummaryDoAsync(int index, int pageSize);

    }
}