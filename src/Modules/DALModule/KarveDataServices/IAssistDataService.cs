using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices
{
    /// <summary>
    ///  Data service for the assist.
    /// </summary>
    public interface IAssistDataService
    {
        /// <summary>
        ///  This returns a data service
        /// </summary>
        /// <param name="assistName">Name of the assist</param>
        /// <param name="query">Name of the query</param>
        /// <returns>Data object to be served.</returns>
        Task<IValueObject> Serve(string assistName, string query);
    }
}
