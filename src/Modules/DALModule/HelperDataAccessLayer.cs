using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Dapper;
using DataAccessLayer.DataObjects.Wrapper;
using DataAccessLayer.Logic;
using DataAccessLayer.Exception;
using KarveDapper.Extensions;
using KarveDataServices;
using Syncfusion.UI.Xaml.Grid;
using System.Text;

namespace DataAccessLayer
{
    /// <summary>
    ///  This class has some helper methods that retrives values needed. The so called auxiliares.
    /// </summary>  
    internal class HelperDataAccessLayer : AbstractDataAccessLayer,IHelperDataServices
    {
        private IMapper _mapper;
        private const int pageSize = 500;
     
        /// <summary>
        /// It needs the data accessr
        /// </summary>
        /// <param name="executor">SQL executor</param>
        public HelperDataAccessLayer(ISqlExecutor executor): base(executor)
        {
            SqlExecutor = executor;
            this._mapper = MapperField.GetMapper();
        }

        /// <summary>
        ///  Delete asychronously mapping a value object to an entity
        /// </summary>
        /// <typeparam name="DtoTransfer">Type Value object to delete</typeparam>
        /// <typeparam name="T">Entity type to be deleted</typeparam>
        /// <param name="entity">entity</param>
        /// <returns></returns>
        public async Task<bool> ExecuteAsyncDelete<DtoTransfer, T>(DtoTransfer entity) where T : class
        {
           var recordDeleted = false;
            var entityValue = _mapper.Map<DtoTransfer, T>(entity);
            using (IDbConnection connection = SqlExecutor.OpenNewDbConnection())
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        // this is a new transaction scope enabled.
                        recordDeleted = await connection.DeleteAsync(entityValue);
                        scope.Complete();
                    }
                    catch (System.Exception ex)
                    {
                        scope.Dispose();
                        throw new DataAccessLayerException(ex.Message, ex);
                    }
                }
            }
            return recordDeleted;
        }
        /// <summary>
        /// Insert asynchronosly after remapping the data transfer object to the entity.
        /// </summary>
        /// <typeparam name="DtoTransfer">Data transfer object to be inserted</typeparam>
        /// <typeparam name="T">Entity to be mapped</typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> ExecuteAsyncInsert<DtoTransfer, T>(DtoTransfer entity) where T : class
        {
            var recordInserted = 0;

            var entityValue = _mapper.Map<DtoTransfer, T>(entity);
            using (IDbConnection connection = SqlExecutor.OpenNewDbConnection())
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    // this is a new transaction scope enabled.
                    recordInserted = await connection.InsertAsync(entityValue);
                    scope.Complete();
                }
            }
            return recordInserted;
        }
        /// <summary>
        ///  Generaated Scoped Unique ID.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        private async Task<string> GetScopedUniqueId<T>(IDbConnection connection, T entity) where T : class
        {
            var scopedId = String.Empty;

            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                scopedId = await connection.UniqueIdAsync<T>(entity);
                scope.Complete();
            }
            return scopedId;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<string> GetUniqueId<T>(T entity) where T : class
        {
            string uniqueId = string.Empty;

            if (SqlExecutor.Connection.State != ConnectionState.Open)
            {
                using (var connection = SqlExecutor.OpenNewDbConnection())
                {
                    if (connection != null)
                    {
                        uniqueId = await GetScopedUniqueId<T>(connection, entity);
                    }
                }
            }
            else
            {
                using (IDbConnection connection = SqlExecutor.OpenNewDbConnection())
                {
                    uniqueId = await GetScopedUniqueId<T>(connection, entity);
                }
            }

            if (uniqueId == string.Empty)
            {
                throw new DataAccessLayerException("Not possible to generate an unique identifer");
            }
            return uniqueId;
        }



        /// <summary>
        /// GetUniqueMappedId 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<string> GetMappedUniqueId<DtoTransfer, T>(DtoTransfer entity) where T : class
        {
            string uniqueId;
            if (entity == null)
            {
                return String.Empty;
            }
            var entityValue = _mapper.Map<DtoTransfer, T>(entity);
            if (SqlExecutor.Connection.State != ConnectionState.Open)
            {
                using (var connection = SqlExecutor.OpenNewDbConnection())
                {
                    uniqueId = await GetScopedUniqueId<T>(connection, entityValue);
                }
            }
            else
            {
                using (IDbConnection connection = SqlExecutor.OpenNewDbConnection())
                {
                    uniqueId = await GetScopedUniqueId<T>(connection, entityValue);
                }
            }
            return uniqueId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="DtoTransfer"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> ExecuteInsertOrUpdate<DtoTransfer, T>(DtoTransfer entity) where T : class
        {
            bool updateAsync = false;
            if (entity == null)
            {
                return false;
            }
            T entityValue = _mapper.Map<DtoTransfer, T>(entity);
            using (IDbConnection connection = SqlExecutor.OpenNewDbConnection())
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        bool present = connection.IsPresent<T>(entityValue);
                        if (!present)
                        {

                            updateAsync = await connection.InsertAsync(entityValue) > 0;
                        }
                        else
                        {
                            updateAsync = await connection.UpdateAsync(entityValue);
                        }
                        scope.Complete();
                    }
                    catch (System.Exception e)
                    {
                        scope.Dispose();
                        var msg = "HelperDataAccessLayer. Error: " + e.Message; 
                        throw new DataLayerExecutionException(msg, e);
                    }
                }
            }
            return updateAsync;
        }
        public async Task<bool> ExecuteAsyncUpdate<DtoTransfer, T>(DtoTransfer entity) where T : class
        {
            bool updateAsync = false;
            T entityValue = _mapper.Map<DtoTransfer, T>(entity);
            using (IDbConnection connection = SqlExecutor.OpenNewDbConnection())
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    // this is a new transaction scope enabled.
                    updateAsync = await connection.UpdateAsync(entityValue);
                    scope.Complete();
                }
            }
            return updateAsync;
        }
        /// <summary>
        /// Get the helper dataset for the async layer.
        /// </summary>
        /// <param name="assistQuery">Assist query.</param>
        /// <param name="assitTableName">Assist table</param>
        /// <returns></returns>
        public async Task<DataSet> GetAsyncHelper(string assistQuery, string assitTableName)
        {
            DataSet set = await SqlExecutor.AsyncDataSetLoad(assistQuery);
            set.Tables[0].TableName = assitTableName;
            return set;
        }
        /// <summary>
        /// This returns the way of data layer.
        /// </summary>
        /// <param name="assistQuery">Assist query</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAsyncHelper<T>(string assistQuery)
        {
            IDbConnection connection = SqlExecutor.Connection;
            IEnumerable<T> result = null;

            bool isOpen = false;
            if (connection == null)
            {
                isOpen = SqlExecutor.Open();
            }
            else
            {
                if (connection.State != ConnectionState.Open)
                {
                    isOpen = SqlExecutor.Open();
                }
            }
            if (isOpen)
            {
                connection = SqlExecutor.Connection;

                try
                {
                    result = await connection.QueryAsync<T>(assistQuery);
                }
                finally
                {
                    connection.Close();
                }
            }
            return result;
        }


        public async Task<IEnumerable<DtoTransfer>> GetPagedAsyncHelper<DtoTransfer, T>(string query, int startIndex, int pageSize) where DtoTransfer: class where T:class
        {
            IEnumerable<DtoTransfer> result = new List<DtoTransfer>();
            var splittedQuery = query.Trim().Split(' ');
            var outstring = "SELECT TOP {0} START AT {1} ";
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(outstring);
            for (int i = 1; i < splittedQuery.Length; ++i)
            {
                stringBuilder.Append(query[i]);
                stringBuilder.Append(" ");
            }
            outstring = string.Format(stringBuilder.ToString(), startIndex, pageSize);
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                try
                {
                    var values = await dbConnection.QueryAsync<T>(query).ConfigureAwait(false);
                    result = _mapper.Map<IEnumerable<DtoTransfer>>(values);
                }
                catch (System.Exception e)
                {
                    throw new DataLayerException("Error during mapping an entity", e);
                }
            }
            return result;
        }
        /// <summary>
        ///  Get the data transfer entity and checks for the 
        /// </summary>
        /// <typeparam name="DtoTransfer">Data transfer object.</typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<IEnumerable<DtoTransfer>> GetMappedAsyncHelper<DtoTransfer, T>(string query) where DtoTransfer : class
        {
            IDbConnection connection = SqlExecutor.Connection;
            IEnumerable<DtoTransfer> result = null;
            bool needToClose = false;
            if ((connection == null) || ((connection.State != ConnectionState.Open)))
            {
                connection = SqlExecutor.OpenNewDbConnection();
                needToClose = true;
            }

            try
            {
                var values = await connection.QueryAsync<T>(query).ConfigureAwait(false);
                result = _mapper.Map<IEnumerable<DtoTransfer>>(values);
            }
            catch (System.Exception e)
            {
                throw new DataLayerException("Error during mapping an entity", e);
            }
            finally
            {
                if (needToClose)
                {
                    connection.Close();
                }
            }
            return result;
        }
        /// <summary>
        ///  Get the summary of a given helper mapped directly to a given data transfer object
        /// </summary>
        /// <typeparam name="DtoTransfer">Data transfer object</typeparam>
        /// <typeparam name="T">Transfer</typeparam>
        /// <param name="pageIndex">Index page to be used.</param>
        /// <param name="pageSize">Page size to be used.</param>
        /// <returns>A chunk of a data relative to the helper</returns>
        public async Task<IEnumerable<DtoTransfer>> GetPagedSummaryDoAsync<DtoTransfer,T>(int pageIndex, int pageSize)    
            where DtoTransfer:class
            where T: class
        {
            IEnumerable<T> pagedData = new List<T>();
            using (var connection = SqlExecutor.OpenNewDbConnection())
            {
                if (connection != null)
                {
                    pagedData = await connection.GetPagedAsync<T>(pageIndex, pageSize).ConfigureAwait(false);
                }
            }
            var outputPagedData = _mapper.Map<IEnumerable<DtoTransfer>>(pagedData);
         
            return outputPagedData;
        }

        /// <summary>
        ///  GetPagedQueryDoAsync.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">Query to be executed.</param>
        /// <param name="pageIndex">Page Index</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetPagedQueryDoAsync<T>(string query, int pageIndex, int pageSize)
           where T : class
        {
            IEnumerable<T> pagedData = new List<T>();
            using (var connection = SqlExecutor.OpenNewDbConnection())
            {
                if (connection != null)
                {
                    pagedData = await connection.GetPagedAsync<T>(pageIndex, pageSize).ConfigureAwait(false);
                }
            }
            return pagedData;
        }
        /// <summary>
        /// GetMappedAllAsyncHelper.
        /// </summary>
        /// <typeparam name="DtoTransfer">Type of the data transfer</typeparam>
        /// <typeparam name="T">Type</typeparam>
        /// <returns>This retuns the mapped values</returns>
        public async Task<IEnumerable<DtoTransfer>> GetMappedAllAsyncHelper<DtoTransfer, T>() where DtoTransfer : class
                                                                                              where T : class
        {
            var connection = SqlExecutor.Connection;
            IncrementalList<T> list = null;
            IEnumerable<DtoTransfer> result = null;
            var needToClose = false;
            if ((connection == null) || ((connection.State != ConnectionState.Open)))
            {
                connection = SqlExecutor.OpenNewDbConnection();
                needToClose = true;
            }
            try
            {
                var values = await connection.GetPagedAsync<T>(1, pageSize);
                var numberOfPages = await connection.GetPageCount<T>(pageSize);
                list = new IncrementalList<T>( async (count, baseIndex)=> {
                    var size = pageSize;
                    var items = await connection.GetPagedAsync<T>(baseIndex, size);
                    list.LoadItems(items);
                });

                if (values != null)
                {
                    result = _mapper.Map<IEnumerable<DtoTransfer>>(values);
                }
                else
                {
                    return new List<DtoTransfer>();
                }
            }
            finally
            {
                if (needToClose)
                {
                    connection.Close();
                }
            }
            return result;
        }
        


        public async Task<IEnumerable<DtoTransfer>> GetMappedHelperPagedAsync<DtoTransfer, T>(long index, long pageSize) where DtoTransfer: class
                                                                                                where T: class
            
        {
            IEnumerable<DtoTransfer> result = new List<DtoTransfer>();
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                if (dbConnection == null)
                {
                    return result;
                }
                var values = await dbConnection.GetPagedAsync<T>(index,pageSize);
                if (values == null)
                {
                    return result;
                }
                result = _mapper.Map<IEnumerable<DtoTransfer>>(values);
                return result;
            }
        }
        /// <summary>
        /// Assist query using the data set
        /// </summary>
        /// <param name="assitQueryDictionary">Dictionary that contgins the assist query.</param>
        /// <returns></returns>
        public async Task<DataSet> GetAsyncHelper(IDictionary<string, string> assitQueryDictionary)
        {
            DataSet set = await SqlExecutor.AsyncDataSetLoadBatch(assitQueryDictionary);
            return set;
        }

        public async Task<DtoTransfer> GetSingleMappedAsyncHelper<DtoTransfer, T>(string code) where T : class
                                                                                        where DtoTransfer : class, new()
        {

            var result = new DtoTransfer();
            using (var connection = SqlExecutor.OpenNewDbConnection())
            {
                var value = await connection.GetAsync<T>(code);

                if (value != null)
                {
                    try
                    {
                        result = _mapper.Map<DtoTransfer>(value);
                    } catch (System.Exception ex)
                    {
                        result = new DtoTransfer();
                    }
                }
            }
            return result;
        }

        public Task<IDictionary<string, DtoTransfer>> GetAsyncBatchData<DtoTransfer>(IDictionary<string, string> value)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        ///  Execute a bulk delete of items.
        /// </summary>
        /// <typeparam name="DtoTransfer">Data Transfer object</typeparam>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="objectValues">Array of objects</param>
        /// <returns></returns>
        public async Task<bool>  ExecuteBulkDeleteAsync<DtoTransfer, T>(IEnumerable<DtoTransfer> objectValues) where T : class
        {
            bool executeValue = false;
            using (IDbConnection dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                try
                {
                    var transferred = _mapper.Map<IEnumerable<T>>(objectValues);

                    using (TransactionScope tran = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        executeValue = await dbConnection.DeleteCollectionAsync<T>(transferred);
                        if (executeValue)
                        {

                            tran.Complete();
                        }
                        else
                        {
                            tran.Dispose();
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw new DataLayerException(ex.Message, ex);
                }
                finally
                {
                    if (dbConnection.State == ConnectionState.Open)
                    {
                        dbConnection.Close();
                    }
                }
            }
            return executeValue;
        }
        /// <summary>
        ///  This function execute the mapping and the bulk insert or delete.
        /// </summary>
        /// <typeparam name="DtoTransfer">Type of the data transfer</typeparam>
        /// <typeparam name="T">Entity to be used</typeparam>
        /// <param name="dtoTransfers">List of data transfer object</param>

        public async Task<bool> ExecuteBulkUpdateAsync<DtoTransfer, T>(IEnumerable<DtoTransfer> dtoTransfers) where T : class
        {
            bool state = false;
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                try
                {
                    var transferred = _mapper.Map<IEnumerable<T>>(dtoTransfers);

                    using (var tran = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        state= await dbConnection.ExecuteUpdateCollectionAsync<T>(transferred);
                        tran.Complete();
                    }
                }
                catch (System.Exception ex)
                {
                    throw new DataLayerException(ex.Message, ex);
                }
                finally
                {
                    if (dbConnection.State == ConnectionState.Open)
                    {
                        dbConnection.Close();
                    }
                }
            }
            return state;
        }

        public async Task<bool> ExecuteBulkInsertAsync<DtoTransfer, T>(IEnumerable<DtoTransfer> dtoTransfers) where T : class
        {
            var state = false;
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                try
                {
                    var transferred = _mapper.Map<IEnumerable<T>>(dtoTransfers);
                    using (var tran = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        state = await dbConnection.InsertAsync(transferred).ConfigureAwait(false) > 0;
           
                        tran.Complete();
                    }
                }
                catch (System.Exception ex)
                {
                    throw new DataLayerException(ex.Message, ex);
                }
                finally
                {
                    if (dbConnection.State == ConnectionState.Open)
                    {
                        dbConnection.Close();
                    }
                }
            }
            return state;
        }
        /// <summary>
        ///  Get a list of data objects paged.
        /// </summary>
        /// <typeparam name="DtoTransfer">Data transfer object to get</typeparam>
        /// <typeparam name="T">Entity to get</typeparam>
        /// <param name="pageIndex">Offset in the set</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Return a list of mapped values</returns>
        public async Task<IEnumerable<DtoTransfer>> GetPagedSummaryDoAsync<DtoTransfer, T>(long pageIndex, int pageSize)
            where DtoTransfer : class
            where T : class
        {
            IEnumerable<DtoTransfer> transfer = new List<DtoTransfer>();
            long currentIndex = (pageIndex == 0) ? 1 : pageIndex;

            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {

                if (dbConnection != null)
                {
                        
                    var conn = await dbConnection.GetPagedAsync<T>(currentIndex, pageSize).ConfigureAwait(false);
                    transfer = _mapper.Map<IEnumerable<T>, IEnumerable<DtoTransfer>>(conn);
                    return transfer;
                }
            }
            return transfer;
        }

        public async Task<int> GetItemsCount<T>()
        {
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                if (dbConnection != null)
                {
                   Tuple<int,int> dbData = await dbConnection.GetPageCount<T>(1000);
                    return dbData.Item1;
                }
            }
            return 0;
        }

      
    }
    
}
