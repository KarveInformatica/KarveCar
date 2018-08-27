using KarveDataServices.ViewObjects;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace KarveDataServices
{
    /// <summary>
    /// HelperDataServices is an interface to retrieve the helper entities from the database.
    /// </summary>
    public interface IHelperDataServices
    {
        /// <summary>
        ///  Get helper for countries and provinces. 
        /// </summary>
        /// <returns></returns>
        Task<DataSet> GetAsyncHelper(string assistQuery, string assistTableName);
        /// <summary>
        /// This method execute a dictionary of queries and returns a data set.
        /// The key of the dictionary is the name of the table.
        /// The table of the dictionary is the value of the query.
        /// </summary>
        /// <param name="viewModelAssitantQueries">Queries for the assistant</param>
        /// <returns></returns>
        Task<DataSet> GetAsyncHelper(IDictionary<string, string> viewModelAssitantQueries);
         /// <summary>
         /// This method has executed an async helper following the entity.
         /// </summary>
         /// <typeparam name="T"></typeparam>
         /// <param name="assistQuery"></param>
         /// <returns></returns>
        Task<IEnumerable<T>> GetAsyncHelper<T>(string assistQuery);


        /// <summary>
        ///  Nimbger of the items in the helpers
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<int> GetItemsCount<T>();

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
        /// <typeparam name="T">Type of the entity to be inserted</typeparam>
        /// <param name="entity">Value of the entity</param>
        /// <returns></returns>
        Task<int> ExecuteAsyncInsert<DtoTransfer, T>(DtoTransfer entity) where T : class;
        /// <summary>
        /// This execute an async deleting converting a data transfer object to a valued entity/
        /// </summary>
        /// <typeparam name="T">Type of the entity</typeparam>
        /// <param name="entity">Value of the entity</param>
        /// <returns></returns>
        Task<bool> ExecuteAsyncDelete<DtoTransfer, T>(DtoTransfer entity) where T : class;

        /// <summary>
        ///  This execute a bulk delete of a set of items.
        /// </summary>
        /// <typeparam name="DtoTransfer">Data transfer object to delete</typeparam>
        /// <typeparam name="T">Entity to delete.</typeparam>
        /// <param name="objectValues">Array of items to be deleted.</param>
        /// <returns>Trur if the value has been deleted successfully</returns>
       
        Task<bool> ExecuteBulkDeleteAsync<DtoTransfer, T>(IEnumerable<DtoTransfer> objectValues) where T : class;

        /// <summary>
        ///  This execute or insert an update. Detect if the entity is already present and insert or update it.
        /// </summary>
        /// <typeparam name="DtoTransfer">Type of the data transfer object to be used</typeparam>
        /// <typeparam name="T">Type of the entity to be used.</typeparam>
        /// <param name="entity">Array to be used to update</param>
        /// <returns>Returns true if the entity is correctly updated</returns>
        Task<bool> ExecuteInsertOrUpdate<DtoTransfer, T>(DtoTransfer entity) where T : class;

        /// <summary>
        ///  This asynchronously does an update or an insert of an entity.
        /// </summary>
        /// <typeparam name="DtoTransfer">Type of the data transfer object to be used
        /// </typeparam>
        /// <typeparam name="T">Entity to be used</typeparam>
        /// <param name="entity">Array to be used to update</param>
        /// <returns>Returns true if the entity is correctly updated</returns>
        Task<bool> ExecuteBulkUpdateAsync<DtoTransfer, T>(IEnumerable<DtoTransfer> entity) where T : class;
    
        /// <summary>
        /// This asynchrnously does a bulk insert of items.
        /// </summary>
        /// <typeparam name="DtoTransfer">Data transfer of objects</typeparam>
        /// <typeparam name="T">Entities to delete</typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> ExecuteBulkInsertAsync<DtoTransfer, T>(IEnumerable<DtoTransfer> entity) where T : class;
      
        /// <summary>
        /// This generates a random number that it is the field of the entity
        /// </summary>
        /// <typeparam name="T">Type of the entity</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        Task<string> GetUniqueId<T>(T entity) where T : class;
        /// <summary>
        ///  This execute a query mapping directly to the Data Transfer Object, in this way the asking module 
        /// is not dependent in any case on the data implementation.
        /// </summary>
        /// <typeparam name="DtoTransfer"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<IEnumerable<DtoTransfer>> GetMappedAsyncHelper<DtoTransfer, T>(string query)
            where DtoTransfer : class;
        /// <summary>
        ///  GetUniqueMappedId
        /// </summary>
        /// <typeparam name="T1">Data Transfer</typeparam>
        /// <typeparam name="T">Type of the entity</typeparam>
        /// <param name="entity">Entity from which we generate the id.</param>
        /// <returns></returns>
        Task<string> GetMappedUniqueId<DtoTransfer, T>(DtoTransfer entity) where T : class;

        /// <summary>
        /// Return a single value from the code and map to the data transfer object. 
        /// </summary>
        /// <typeparam name="DtoTransfer">Data Transfer Object to be mapped</typeparam>
        /// <typeparam name="T">Entity to be mapped</typeparam>
        /// <param name="code">Code to select the single entity</param>
        /// <returns></returns>

        Task<DtoTransfer> GetSingleMappedAsyncHelper<DtoTransfer, T>(string code) where T : class
            where DtoTransfer : class, new();
        /// <summary>
        /// Given a set of code and names, it generates the queries and get the value. 
        /// </summary>
        /// <param name="value">Dictionary of code to lookup and list.</param>
        /// <returns></returns>
        Task<IDictionary<string, DtoTransfer>> GetAsyncBatchData<DtoTransfer>(IDictionary<string, string> value);
        /// <summary>
        ///  This returns all the entities that are presnet in a table mapped as data transfer object.
        /// </summary>
        /// <typeparam name="DtoTransfer">Type of the data transfer object.</typeparam>
        /// <typeparam name="T"> Type of the entity to be mapped.</typeparam>
        /// <returns></returns>
        /// 
        Task<IEnumerable<DtoTransfer>> GetMappedAllAsyncHelper<DtoTransfer, T>() where DtoTransfer : class 
                                                                                 where T : class;

        /// <summary>
        ///  Fetch the pageSize pages asynchronously and it maps directly to the helper.
        /// </summary>
        /// <typeparam name="DtoTransfer">Data transfer object to be used</typeparam>
        /// <typeparam name="T">Entity type to be used</typeparam>
        /// <param name="pageIndex">Index of the page to be used.</param>
        /// <param name="pageSize">Dimension of the page to be used.</param>
        /// <returns></returns>
        Task<IEnumerable<DtoTransfer>> GetPagedSummaryDoAsync<DtoTransfer, T>(long pageIndex, int pageSize)
        where DtoTransfer : class where T : class;

        /// <summary>
        ///  Fetch the paged queries.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetPagedQueryDoAsync<T>(string query, int pageIndex, int pageSize) where T : class;
        Task<IEnumerable<Dto>> GetPagedAsyncHelper<Dto, Entity>(string query, int pageIndex, int pageSize)
            where Dto : class
            where Entity : class;
    }
}