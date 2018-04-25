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

namespace DataAccessLayer
{
    /// <summary>
    ///  This class has some helper methods that retrives values needed. The so called auxiliares.

    /// </summary>  
    internal class HelperDataAccessLayer : IHelperDataServices
    {
        private readonly ISqlExecutor _sqlExecutor;
        private IMapper _mapper;
        /// <summary>
        /// It needs the data accessr
        /// </summary>
        /// <param name="dataMapper">SQL executor</param>
        public HelperDataAccessLayer(ISqlExecutor dataMapper)
        {
            this._sqlExecutor = dataMapper;
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
            bool recordDeleted = false;
            T entityValue = _mapper.Map<DtoTransfer, T>(entity);
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
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
        /// Insert asynchronosly.
        /// </summary>
        /// <typeparam name="DtoTransfer"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> ExecuteAsyncInsert<DtoTransfer, T>(DtoTransfer entity) where T : class
        {
            int recordInserted = 0;

            T entityValue = _mapper.Map<DtoTransfer, T>(entity);
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
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
            string scopedId = String.Empty;

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
            string uniqueId;

            if (_sqlExecutor.Connection.State != ConnectionState.Open)
            {
                using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
                {
                    uniqueId = await GetScopedUniqueId<T>(connection, entity);
                }
            }
            else
            {
                using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
                {
                    uniqueId = await GetScopedUniqueId<T>(connection, entity);
                }
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
            T entityValue = _mapper.Map<DtoTransfer, T>(entity);
            if (_sqlExecutor.Connection.State != ConnectionState.Open)
            {
                using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
                {
                    uniqueId = await GetScopedUniqueId<T>(connection, entityValue);
                }
            }
            else
            {
                using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
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
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
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
                        throw new DataLayerExecutionException("Error during insert", e);
                    }
                }
            }
            return updateAsync;
        }
        public async Task<bool> ExecuteAsyncUpdate<DtoTransfer, T>(DtoTransfer entity) where T : class
        {
            bool updateAsync = false;
            T entityValue = _mapper.Map<DtoTransfer, T>(entity);
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
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
            DataSet set = await _sqlExecutor.AsyncDataSetLoad(assistQuery);
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
            IDbConnection connection = _sqlExecutor.Connection;
            IEnumerable<T> result = null;

            bool isOpen = false;
            if (connection == null)
            {
                isOpen = _sqlExecutor.Open();
            }
            else
            {
                if (connection.State != ConnectionState.Open)
                {
                    isOpen = _sqlExecutor.Open();
                }
            }
            if (isOpen)
            {
                connection = _sqlExecutor.Connection;

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
        /// <summary>
        ///  Get the data transfer entity and checks for the 
        /// </summary>
        /// <typeparam name="DtoTransfer"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<IEnumerable<DtoTransfer>> GetMappedAsyncHelper<DtoTransfer, T>(string query) where DtoTransfer : class
        {
            IDbConnection connection = _sqlExecutor.Connection;
            IEnumerable<DtoTransfer> result = null;
            bool needToClose = false;
            if ((connection == null) || ((connection.State != ConnectionState.Open)))
            {
                connection = _sqlExecutor.OpenNewDbConnection();
                needToClose = true;
            }

            try
            {
                var values = await connection.QueryAsync<T>(query);
                result = _mapper.Map<IEnumerable<DtoTransfer>>(values);
            }
            catch (System.Exception e)
            {
                var exception = "message";
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




        public async Task<IEnumerable<DtoTransfer>> GetMappedAllAsyncHelper<DtoTransfer, T>() where DtoTransfer : class
                                                                                              where T : class
        {
            IDbConnection connection = _sqlExecutor.Connection;
            IEnumerable<DtoTransfer> result = null;
            bool needToClose = false;
            if ((connection == null) || ((connection.State != ConnectionState.Open)))
            {
                connection = _sqlExecutor.OpenNewDbConnection();
                needToClose = true;
            }
            try
            {
                var values = await connection.GetAsyncAll<T>();
                result = _mapper.Map<IEnumerable<DtoTransfer>>(values);
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
        /// Assist query using the data set
        /// </summary>
        /// <param name="assitQueryDictionary">Dictionary that contgins the assist query.</param>
        /// <returns></returns>
        public async Task<DataSet> GetAsyncHelper(IDictionary<string, string> assitQueryDictionary)
        {
            DataSet set = await _sqlExecutor.AsyncDataSetLoadBatch(assitQueryDictionary);
            return set;
        }

        public async Task<DtoTransfer> GetSingleMappedAsyncHelper<DtoTransfer, T>(string code) where T : class
                                                                                        where DtoTransfer : class, new()
        {
            IDbConnection connection = _sqlExecutor.Connection;
            DtoTransfer result = new DtoTransfer();
            if ((connection == null) || ((connection.State != ConnectionState.Open)))
            {
                connection = _sqlExecutor.OpenNewDbConnection();
            }
            try
            {
                var value = await connection.GetAsync<T>(code);
                result = _mapper.Map<DtoTransfer>(value);
            }
            finally
            {
                connection.Close();
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
            using (IDbConnection dbConnection = _sqlExecutor.OpenNewDbConnection())
            {
                try
                {
                    var transferred = _mapper.Map<IEnumerable<T>>(objectValues);

                    using (TransactionScope tran = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        executeValue = await dbConnection.DeleteCollectionAsync<T>(transferred);
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
            using (IDbConnection dbConnection = _sqlExecutor.OpenNewDbConnection())
            {
                try
                {
                    var transferred = _mapper.Map<IEnumerable<T>>(dtoTransfers);

                    using (TransactionScope tran = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
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

        /*
          var dt = DateTime.Now;
                            value.ULTMODI = dt.ToString("yyyyMMddHH:mm");
             */

        public async Task<bool> ExecuteBulkInsertAsync<DtoTransfer, T>(IEnumerable<DtoTransfer> dtoTransfers) where T : class
        {
            bool state = false;
            using (IDbConnection dbConnection = _sqlExecutor.OpenNewDbConnection())
            {
                try
                {
                    var transferred = _mapper.Map<IEnumerable<T>>(dtoTransfers);
                    using (TransactionScope tran = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
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
    }
    
}
