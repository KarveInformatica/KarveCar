using System.Collections.Generic;
using System.Threading.Tasks;
using KarveDataServices;
using System.Data;
using KarveDapper.Extensions;
using System.Transactions;
using AutoMapper;
using Dapper;
using DataAccessLayer.Logic;
namespace DataAccessLayer
{
    /// <summary>
    ///  DataLoader. This load asynchronsoly all the data.
    /// </summary>
    public class DataLoader<T, Dto> : IDataLoader<Dto> where T : class
                                                         where Dto: class, new()
    {
        private readonly ISqlExecutor _sqlExecutor;
        private readonly IMapper _mapper;


        public async Task<IEnumerable<Dto>> LoadAsyncAll(string query)
        {
            IDbConnection conn = null;
            IList<Dto> emptyList = new List<Dto>();

            if (_sqlExecutor.Connection.State == ConnectionState.Open)
            {
                conn = _sqlExecutor.Connection;
            }
            else
            {
                conn = _sqlExecutor.OpenNewDbConnection();
            }

            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    if (conn != null)
                    {
                        var values = await conn.QueryAsync<T>(query);
                        var outValues = _mapper.Map<IEnumerable<T>, IEnumerable<Dto>>(values);
                        return outValues;
                    }
                }
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return emptyList;
        }
        /// <summary>
        ///  This load asynchonosly and map the dto to a given entity. In case we have an exception we dont log or capture but let them bubble up.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Dto>> LoadAsyncAll() 
        {
            IDbConnection conn = null;
            IList<Dto> emptyList = new List<Dto>();
            if (_sqlExecutor.Connection.State == ConnectionState.Open)
            {
                conn = _sqlExecutor.Connection;
            }
            else
            {
                conn = _sqlExecutor.OpenNewDbConnection();
            }

            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    if (conn != null)
                    {
                        var values = await conn.GetAllAsync<T>();
                        var outValues = _mapper.Map<IEnumerable<T>, IEnumerable<Dto>>(values);
                        return outValues;
                    }
                }
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return emptyList;
        }

        public async Task<Dto> LoadValueAsync(string code)
        {
            IDbConnection conn = null;
            Dto dto = new Dto();
            if (_sqlExecutor.Connection.State == ConnectionState.Open)
            {
                conn = _sqlExecutor.Connection;
            }
            else
            {
                conn = _sqlExecutor.OpenNewDbConnection();
            }

            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    if (conn != null)
                    {
                        var value = await conn.GetAsync<T>(code);
                        var outValues = _mapper.Map<T, Dto>(value);
                        return outValues;
                    }
                }
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return dto;
        }

        public DataLoader(ISqlExecutor executor)
        {
            _sqlExecutor = executor;
            this._mapper = MapperField.GetMapper();
        }
       
    }
}
