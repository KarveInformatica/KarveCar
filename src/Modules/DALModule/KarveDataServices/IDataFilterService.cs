using KarveCommonInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices
{
    /// <summary>
    ///  This is a data filter service for the grid. It returns a list of data.
    ///  We cannot avoid unboxing here.
    /// </summary>
    public delegate void OnFilteredResult(object data);
    public interface IDataFilterService
    {
        // set the data to be used.
        int PageSize { get; set; }
        /// <summary>
        ///  Set the event to be triggered when the new data has been received;
        /// </summary>
        event OnFilteredResult FilterEventResult;
        /// <summary>
        ///  Ask to filter data given already resolved where clause.
        /// </summary>
        /// <param name="whereClause">The string after where to be included in the where clause</param>
        /// <returns>The data filtered</returns>
        Task<object> FilterDataAsync(string query);

       
    }
}
