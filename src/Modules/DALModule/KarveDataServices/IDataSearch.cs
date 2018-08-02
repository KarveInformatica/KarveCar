using System;
using System.Collections.Generic;
using KarveCommonInterfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices
{
    /// <summary>
    /// Interface for searching data following some well known criterias.
    /// </summary>
    /// <typeparam name="DomainType">Domain object to be used for searching</typeparam>
    /// <typeparam name="SummaryType">Summary type to be used for searching</typeparam>
    public interface IDataSearch<DomainType, SummaryType>
    {
        /// <summary>
        /// Retrieve a list of summaries in a date interval. Both dates cannot be null.
        /// </summary>
        /// <param name="from">Starting date. If it is null means all the past.</param>
        /// <param name="to">Ending date. It it is null means all the future.</param>
        /// <returns>List of summaries type</returns>
        Task<IEnumerable<SummaryType>> SearchByDate(DateTime? from, DateTime? to);
        /// <summary>
        /// Search using a query filter.
        /// </summary>
        /// <param name="filter">Filter to filter queries</param>
        /// <returns></returns>
       Task<IEnumerable<SummaryType>> SearchByFilter(IQueryFilter filter);
        /// <summary>
        /// Retrieve a list of summaries in a date interval. Both dates cannot be null.
        /// </summary>
        /// <param name="from">Starting date. If it is null means all the past.</param>
        /// <param name="to">Ending date. It it is null means all the future.</param>
        /// <returns>List of summaries type</returns>
        Task<IEnumerable<SummaryType>> SearchByDatePaged(DateTime? from, DateTime? to, int pageSize);
        /// <summary>
        /// Search in the dbms using a query filter using a page size.
        /// </summary>
        /// <param name="filter">Filter to filter queries</param>
        /// <returns></returns>
        Task<IEnumerable<SummaryType>> SearchByFilterPaged(IQueryFilter filter, int pageSize);
        /// <summary>
        ///  Search a single entity in a db using a query filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<DomainType> SearchSingleByFilter(IQueryFilter filter);
        /// <summary>
        ///  Search a single entity in a db using the propery name and the value of the property
        /// </summary>
        /// <param name="name">name of the pro</param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<DomainType> SearchSingleByProperty(string name, string value);

    }
}
