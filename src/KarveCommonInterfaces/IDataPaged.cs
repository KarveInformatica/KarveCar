using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCommonInterfaces
{
    /// <summary>
    ///   This get the data paged in asynchronous way.
    /// </summary>
    public interface IDataPaged<T> where T: class
    {
        Task<IEnumerable<T>> GetPagedSummaryDoAsync(long pageIndex, long pageSize);
    }
}
