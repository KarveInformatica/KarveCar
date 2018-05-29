using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices
{
    /// <summary>
    ///  Return the number of the pages in a select.
    /// </summary>
    public interface IPageCounter
    {
        /// <summary>
        ///  Fetch the number of pages in the current page.
        /// </summary>
        /// <param name="pageSize">Page size</param>
        /// <returns></returns>
        Task<int> GetPageCount(int pageSize);
        /// <summary>
        /// Set or Get the number of pages.
        /// </summary>
        int NumberPage { get; set; }
        /// <summary>
        /// Set or Get the number of pages.
        /// </summary>
        long NumberItems { get; set; }
    }
}
