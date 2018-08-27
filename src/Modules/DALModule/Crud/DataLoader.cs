using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Dapper;
using DataAccessLayer.Logic;
using KarveDapper.Extensions;
using KarveDataServices;

namespace DataAccessLayer.Crud
{
    /// <summary>
    ///  DataLoader. This load asynchronsoly all the data.
    /// </summary>
    public class DataLoader<T, Dto> : IDataLoader<Dto> where T : class
                                                         where Dto: class, new()
    {
        private readonly ISqlExecutor _sqlExecutor;
        private readonly IMapper _mapper;
        /// <summary>
        ///  Load all entities from a query and maps directly to a viewObject.
        /// </summary>
        /// <param name="query">Query.</param>
        /// <returns></returns>

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
        ///  This load asynchonosly and map the viewObject to a given entity. In case we have an exception we dont log or capture but let them bubble up.
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
                    if (conn != null)
                    {
                        var values = await conn.GetAllAsync<T>();
                        var outValues = _mapper.Map<IEnumerable<T>, IEnumerable<Dto>>(values);
                        return outValues;
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
                    if (conn != null)
                    {
                        var value = await conn.GetAsync<T>(code);
                        switch (value)
                        {
                            case null when conn.State != ConnectionState.Open:
                                return dto;
                            case null:
                                conn.Close();
                                conn.Dispose();
                                return dto;
                        }
                        var outValues = _mapper.Map<T, Dto>(value);
                        return outValues;
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

        public Task<IEnumerable<Dto>> LoadValueAtMostAsync(int n, int back = 0)
        {
            throw new System.NotImplementedException();
        }

        public DataLoader(ISqlExecutor executor)
        {
            _sqlExecutor = executor;
            this._mapper = MapperField.GetMapper();
        }

       
    }
}
