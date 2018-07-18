using System.Data;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Logic;
using KarveDapper.Extensions;
using KarveDataServices;
using System.Transactions;

namespace DataAccessLayer.Crud
{
        /// <summary>
        /// Generic data deleter for entitities.
        /// </summary>
        /// <typeparam name="T">Type of the entity</typeparam>
        /// <typeparam name="Dto">Data Transfer object</typeparam>
        public class DataDeleter<T, Dto> : IDataDeleter<Dto> where T : class
            where Dto : class, new()
        {

            private readonly IMapper _mapper;
            /// <summary>
            /// Executor of sql.
            /// </summary>
            private readonly ISqlExecutor _executor;
            /// <summary>
            ///  Delete the entity
            /// </summary>
            /// <param name="executor">Sql command executor</param>
            public DataDeleter(ISqlExecutor executor)
            {
                this._executor = executor;
                this._mapper = MapperField.GetMapper();
            }
            /// <summary>
            ///  Delete asynchronously the entity after the mapping from dto to entity.
            /// </summary>
            /// <param name="data"></param>
            /// <returns></returns>
            public async Task<bool> DeleteAsync(Dto data)
            {
               
                T entity = _mapper.Map<Dto, T>(data);
                bool retValue = false;
                using (IDbConnection connection = _executor.OpenNewDbConnection())
                { 
                   try
                    {
                        using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                        {
                            retValue = await connection.DeleteAsync<T>(entity).ConfigureAwait(false);
                         scope.Complete();
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                return retValue;
            }
        }   
}
