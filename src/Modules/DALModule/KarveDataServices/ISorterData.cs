using KarveDataServices.DataTransferObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices
{
    public interface ISorterData<DtoType> where DtoType: BaseDto
    {
        /// <summary>
        ///  This is a  sorted collection paged asynchronously.
        /// </summary>
        /// <typeparam name="DtoType">Type of the data to be paged</typeparam>
        /// <param name="sortChain">List of the chain to be sorted</param>
        /// <param name="index">Starting index</param>
        /// <param name="pageSize">Starting size</param>
        /// <returns></returns>
        Task<IEnumerable<DtoType>> GetSortedCollectionPagedAsync(Dictionary<string, ListSortDirection> sortChain, long index, int pageSize);
    }
}
