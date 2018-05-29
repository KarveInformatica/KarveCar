using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataTransferObject;

namespace KarveDataServices
{
    /// <summary>
    ///  Interface to allow pagination.
    /// </summary>
    
    public interface IDataPageLoader
    {
        /// <summary>
        ///  DataPage Loader
        /// </summary>
        /// <param name="startIndex">Index to start</param>
        /// <param name="pageSize">Dimension of the page</param>
        /// <returns></returns>
       Task<IEnumerable> LoadPageAsync(int startIndex, int pageSize);
        Task<int> PageCountAsync();
    }
}
