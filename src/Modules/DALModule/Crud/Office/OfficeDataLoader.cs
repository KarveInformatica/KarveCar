using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using DataAccessLayer.SQL;
using KarveDataServices.DataTransferObject;
using KarveDataServices;
using System.Data;
using KarveDapper.Extensions;
using AutoMapper;
using Dapper;
using System.Diagnostics.Contracts;

namespace DataAccessLayer.Crud.Office
{

    /// <summary>
    ///  Loader of the data 
    /// </summary>
    public class OfficeDataLoader: IDataLoader<OfficeDtos> 
    {
        private readonly ISqlExecutor _executor;
        private readonly IMapper _mapper;
        private long _currentPos;
        private readonly QueryStoreFactory _queryStoreFactory;
        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="executor">Executor</param>
        public OfficeDataLoader(ISqlExecutor executor, IMapper mapper)
        {
            _executor = executor;
            _mapper = mapper;
            _queryStoreFactory = new QueryStoreFactory();
        }
        /// <summary>
        /// Load asynchronously a list of offices.
        /// </summary>
        /// <returns>A list of offcies</returns>
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

        private async Task<OfficeDtos> LoadAuxAsync(IDbConnection connection, 
                                                    EntityDeserializer deserializer, 
                                                    OfficeDtos officeDtos, OFICINAS value)
        {
            var output = new List<EntityDecorator>();
            if (value != null)
            {
                IQueryStore queryStore = _queryStoreFactory.GetQueryStore();
                queryStore.AddParam(QueryType.QueryCity, officeDtos.POBLACION);
                queryStore.AddParam(QueryType.QueryProvince, officeDtos.PROVINCIA);
                queryStore.AddParam(QueryType.QueryCurrency);
                queryStore.AddParam(QueryType.HolidaysByOffice, value.CODIGO);
                var queryHolidays = queryStore.BuildQuery();
                var reader = await connection.QueryMultipleAsync(queryHolidays);
                while (!reader.IsConsumed)
                {
                    var row = reader.Read();

                    foreach (var singleValue in row)
                    {
                        var deserialized = deserializer.Deserialize(singleValue);
                        if (deserialized != null)
                        {
                            output.Add(deserialized);
                        }
                    }
                }

                officeDtos.City = deserializer.SelectDto<POBLACIONES, CityDto>(_mapper, output);
                officeDtos.Province = deserializer.SelectDto<PROVINCIA, ProvinciaDto>(_mapper, output);
                officeDtos.Currencies = deserializer.SelectDto<CURRENCIES, CurrenciesDto>(_mapper, output);
                officeDtos.HolidayDates = deserializer.SelectDto<FESTIVOS_OFICINA, HolidayDto>(_mapper, output);
            }

            return officeDtos;
        }

        // <summary>
        /// Load asynchronous values.
        /// </summary>
        /// <param name="code">Code to be used</param>
        /// <returns>An office data transfer object</returns>
        public async Task<OfficeDtos> LoadValueAsync(string code)
        {

            Contract.Requires(condition: !string.IsNullOrEmpty(code));
            OfficeDtos officeDtos;
            IList<object> entities = new List<object>()
           {
               new POBLACIONES(),
               new PROVINCIA(),
               new CURRENCIES(),
               new FESTIVOS_OFICINA()
           };
            IList<object> dto = new List<object>()
            {
                new CityDto(),
                new ProvinciaDto(),
                new CurrenciesDto(),
                new HolidayDto()
            };
            EntityDeserializer deserializer = new EntityDeserializer(entities, dto);
            var output = new List<EntityDecorator>();
            using (var connection = _executor.OpenNewDbConnection())
            {
                var value = await connection.GetAsync<OFICINAS>(code);
                officeDtos = _mapper.Map<OFICINAS, OfficeDtos>(value);
                officeDtos = await LoadAuxAsync(connection, deserializer, officeDtos, value).ConfigureAwait(false);
            }
            return officeDtos;
        }

        public async Task<IEnumerable<OfficeDtos>> LoadValueAtMostAsync(int n, int back = 0)
        {
            IEnumerable<OfficeDtos> officeDtos;
            IQueryStore store = _queryStoreFactory.GetQueryStore();
            using (IDbConnection connection = _executor.OpenNewDbConnection())
            {
                store.AddParamRange(QueryType.QueryCompanyPaged, _currentPos, n);
                _currentPos += n + back;
                var query = store.BuildQuery();
                var value = await connection.QueryAsync<OFICINAS>(query);
                officeDtos = _mapper.Map<IEnumerable<OFICINAS>, IEnumerable<OfficeDtos>>(value);
            }
            return officeDtos;
            
        }
    }

}