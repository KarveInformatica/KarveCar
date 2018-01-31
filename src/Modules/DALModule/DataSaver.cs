using KarveDataServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Logic;
using KarveDapper.Extensions;

namespace DataAccessLayer
{
    /// <summary>
    /// DataSaver
    /// </summary>
    /// <typeparam name="T">Type of the entity</typeparam>
    /// <typeparam name="Dto">Data Transfer object</typeparam>
    public class DataSaver<T, Dto> : IDataSaver<Dto> where T : class
        where Dto : class, new()
    {
        /// <summary>
        /// Executor of sql.
        /// </summary>
        private readonly ISqlExecutor _executor;
        /// <summary>
        ///  This save the mapper
        /// </summary>
        private readonly  IMapper _mapper;
        /// <summary>
        ///  This save the data.
        /// </summary>
        /// <param name="executor"></param>
        public DataSaver(ISqlExecutor executor)
        {
            this._executor = executor;
            this._mapper = MapperField.GetMapper();
        }
        /// <summary>
        ///  This save the data asynchronously
        /// </summary>
        /// <param name="data">data to be saved.</param>
        /// <returns></returns>
        public async Task<bool> SaveAsync(Dto data)
        {
            IDbConnection conn = null;
            bool value = false;
            T entity = _mapper.Map<Dto, T>(data);
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
                    if (!conn.IsPresent<T>(entity))
                    {
                        value = await conn.InsertAsync<T>(entity) > 0;
                    }
                    else
                    {
                        value = await conn.UpdateAsync<T>(entity);
                    }
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
