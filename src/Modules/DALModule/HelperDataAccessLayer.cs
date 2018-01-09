using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Dapper;
using DataAccessLayer.DataObjects.Wrapper;
using DataAccessLayer.Logic;
using KarveDapper.Extensions;
using KarveDataServices;

namespace DataAccessLayer
{
    /// <summary>
    ///  This class has some helper methods that retrives values needed. The so called auxiliares.
    /// </summary>
    class HelperDataAccessLayer :  IHelperDataServices
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

       
        public async Task<bool> ExecuteAsyncDelete<DtoTransfer, T>(DtoTransfer entity) where T : class
        {
            bool recordDeleted = false;
            T entityValue = _mapper.Map<DtoTransfer, T>(entity);
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    // this is a new transaction scope enabled.
                   recordDeleted = await connection.DeleteAsync(entityValue);
                   scope.Complete();
                }
            }
            return recordDeleted;
        }
        /// <summary>
        /// 
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
        private async Task<string> GetScopedUniqueId<T>(IDbConnection connection,T entity) where T : class
        {
            string scopedId = String.Empty;

            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                scopedId = await connection.UniqueId<T>(entity);
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

        public async Task<bool> ExecuteInsertOrUpdate<DtoTransfer, T>(DtoTransfer entity) where T : class
        {
            bool updateAsync = false;
            T entityValue = _mapper.Map<DtoTransfer, T>(entity);
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        try
                        {
                            bool present =  connection.IsPresent<T>(entityValue);
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
        /// <param name="assistQuery"></param>
        /// <param name="assitTableName"></param>
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
        /// <param name="assistQuery"></param>
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
                   isOpen =  _sqlExecutor.Open();
                }
            }
            if (isOpen)
            {
                connection = _sqlExecutor.Connection;
                // TODO: exception handling.
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
        /// Assist query using the data set
        /// </summary>
        /// <param name="assitQueryDictionary">Dictionary that contgins the assist query.</param>
        /// <returns></returns>
        public async Task<DataSet> GetAsyncHelper(IDictionary<string, string> assitQueryDictionary)
        {
            DataSet set = await _sqlExecutor.AsyncDataSetLoadBatch(assitQueryDictionary);
            return set;
        }

        
    }
}
