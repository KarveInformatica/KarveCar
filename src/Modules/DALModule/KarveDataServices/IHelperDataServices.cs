using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace KarveDataServices
{
    public interface IHelperDataServices
    {
     
        /// <summary>
        ///  Get helper for countries and provinces. 
        /// </summary>
        /// <returns></returns>
        Task<DataSet> GetAsyncHelper(string assistQuery, string assistTableName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModelAssitantQueries">Queries for the assistant</param>
        /// <returns></returns>
        Task<DataSet> GetAsyncHelper(IDictionary<string, string> viewModelAssitantQueries);
        
    }
}