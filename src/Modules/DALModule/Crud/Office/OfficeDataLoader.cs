using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using DataAccessLayer.SQL;
using KarveDataServices.DataTransferObject;
using KarveDataServices;
using System.Data;
using DataAccessLayer.Logic;
using KarveDapper.Extensions;
using KarveDapper;
using AutoMapper;
using Dapper;

namespace DataAccessLayer.Crud.Office
{

    /// <summary>
    ///  Loader of the data 
    /// </summary>
    public class OfficeDataLoader: IDataLoader<OfficeDtos> 
    {
        private ISqlExecutor _executor;
        private IMapper _mapper;
        private long _currentPos;
        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="executor">Executor</param>
        public OfficeDataLoader(ISqlExecutor executor)
        {
            _executor = executor;
            _mapper = MapperField.GetMapper();
        }

        public async Task<IEnumerable<OfficeDtos>> LoadAsyncAll()
        {
            IEnumerable<OfficeDtos> officeDtos = new List<OfficeDtos>();
            using (IDbConnection connection = _executor.OpenNewDbConnection())
            {
                var value = await connection.GetAllAsync<OFICINAS>();
                officeDtos = _mapper.Map<IEnumerable<OFICINAS>, IEnumerable<OfficeDtos>>(value);
               
           
            }
            return officeDtos;
        }

        public async Task<OfficeDtos> LoadValueAsync(string code)
        {
            OfficeDtos officeDtos = new OfficeDtos();
            using (IDbConnection connection = _executor.OpenNewDbConnection())
            {
                var value = await connection.GetAsync<OFICINAS>(code);
                officeDtos = _mapper.Map<OFICINAS, OfficeDtos>(value);
                
                if (value != null)
                {
                    QueryStore queryStore = new QueryStore();
                    queryStore.AddParam(QueryStore.QueryType.QueryCurrency);
                    queryStore.AddParam(QueryStore.QueryType.HolidaysByOffice, value.CODIGO);
                    var queryHolidays = queryStore.BuildQuery();
                    var reader = await connection.QueryMultipleAsync(queryHolidays);
                    var offices = reader.Read<CURRENCIES>();
                    if (!reader.IsConsumed)
                    {
                        var holidaysByOffice = reader.Read<FESTIVOS_OFICINA>();
                        officeDtos.HolidayDates = _mapper.Map<IEnumerable<FESTIVOS_OFICINA>, IEnumerable<HolidayDto>>(holidaysByOffice);
                    }
                    
                }
            }
            return officeDtos;
        }

        public async Task<IEnumerable<OfficeDtos>> LoadValueAtMostAsync(int n, int back = 0)
        {
            IEnumerable<OfficeDtos> officeDtos = new List<OfficeDtos>();
            QueryStore store = new QueryStore();
            using (IDbConnection connection = _executor.OpenNewDbConnection())
            {
                store.AddParamRange(QueryStore.QueryType.QueryPagedCompany, _currentPos, n);
                _currentPos += n + back;
                var query = store.BuildQuery();
                var value = await connection.QueryAsync<OFICINAS>(query);
                officeDtos = _mapper.Map<IEnumerable<OFICINAS>, IEnumerable<OfficeDtos>>(value);
            }
            return officeDtos;
            
        }

        private QueryStore CreateQueryStore(OFICINAS office)
        {
            QueryStore store = new QueryStore();
            store.AddParam(QueryStore.QueryType.QueryCity, office.CP);
            store.AddParam(QueryStore.QueryType.QueryOfficeZone, office.ZONAOFI);
            return store;
        }

    }

}