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

        Task<IEnumerable<T>> GetAsyncHelper<T>(string assistQuery);

        /// <summary>
        /// Execute an update asynchronous for the entities.
        /// </summary>
        /// <typeparam name="DtoTransfer"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> ExecuteAsyncUpdate<DtoTransfer, T>(DtoTransfer entity) where T : class;

        /// <summary>
        /// This execute an async insertion converting a data transfer object to a valued entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> ExecuteAsyncInsert<DtoTransfer, T>(DtoTransfer entity) where T : class;

        /// <summary>
        /// This execute an async deleting converting a data transfer object to a valued entity/
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> ExecuteAsyncDelete<DtoTransfer, T>(DtoTransfer entity) where T : class;
        /// <summary>
        ///  This execute or insert an update.
        /// </summary>
        /// <typeparam name="DtoTransfer"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> ExecuteInsertOrUpdate<DtoTransfer, T>(DtoTransfer entity) where T : class;

        // This generate a random well known long id that it is converted in a 8 bytes number.
        Task<string> GetUniqueId<T>(T entity) where T : class;
    }
}