using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Logic;
using KarveDapper.Extensions;
using KarveDataServices;

namespace DataAccessLayer
{
    
        /// <summary>
        /// DataDeleter
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
                IDbConnection conn = null;
                T entity = _mapper.Map<Dto, T>(data);
                bool value = false;
                if (this._executor.Connection.State == ConnectionState.Open)
                {
                    conn = this._executor.Connection;
                }
                else
                {
                    conn = this._executor.OpenNewDbConnection();
                }
                try
                {
                    if (conn != null)
                    {
                        value = await conn.DeleteAsync<T>(entity);
                    }

                }
                finally
                {
                    conn?.Close();
                    conn?.Dispose();
                }
                return value;
            }
        }
    
}
