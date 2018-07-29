using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Logic;
using DataAccessLayer.SQL;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using System.Linq;
using System.Text;
using NLog;

namespace DataAccessLayer.Crud.Booking
{
    /// <summary>
    ///  BookingDataLoader. This loads the boooking.
    /// </summary>
    internal class BookingDataLoader : IDataLoader<BookingDto>
    {

        private readonly ISqlExecutor _sqlExecutor;
        private readonly IMapper _mapper;
        private readonly QueryStoreFactory _queryStoreFactory;
        private int _currentPos;
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///  Constructor for the booking data loader.
        /// </summary>
        /// <param name="sqlExecutor">Sql executor interface</param>
        /// <param name="mapper">Maps the mapper</param>
        public BookingDataLoader(ISqlExecutor sqlExecutor, IMapper mapper)
        {
            _sqlExecutor = sqlExecutor;
            _mapper = MapperField.GetMapper();
            _queryStoreFactory = new QueryStoreFactory();

        }
        /// <summary>
        ///  Load the asynchronous async load.
        /// </summary>
        /// <returns>A list of booking</returns>
        public async Task<IEnumerable<BookingDto>> LoadAsyncAll()
        {
            var store = _queryStoreFactory.GetQueryStore();
            store.AddParam(QueryType.QueryBookingSummary);
            var query = store.BuildQuery();
            using (var dbConnection = _sqlExecutor.OpenNewDbConnection())
            {
                if (dbConnection != null)
                {
                    _logger.Log(LogLevel.Debug, query);
                    var reservation = await dbConnection.QueryAsync<BookingDto>(query);
                    return reservation;
                }
            }
            return new List<BookingDto>();
        }

        /*
           if (result.Valid)
            {
                var auxQueryStore = QueryStoreFactory.GetQueryStore();
                // foreach querytype and entity
                
                auxQueryStore.AddParamCount(QueryType.QueryOffice, dto.OFICINA_RES1);
                
                auxQueryStore.AddParamCount(QueryType.QueryOffice, dto.OFISALIDA_RES1);
                
                auxQueryStore.AddParamCount(QueryType.QueryOffice, dto.OFIRETORNO_RES1);
                
                auxQueryStore.AddParamCount(QueryType.QueryBudget, dto.PRESUPUESTO_RES1);
                
                auxQueryStore.AddParamCount(QueryType.QueryFares, dto.TARIFA_RES1);
                
                auxQueryStore.AddParamCount(QueryType.QueryGroup, dto.GRUPO_RES1);
                
                auxQueryStore.AddParamCount(QueryType.QueryBroker, dto.COMISIO_RES2);
                
                auxQueryStore.AddParamCount(QueryType.QueryVehicleSummary, dto.VCACT_RES1);
                
                auxQueryStore.AddParamCount(QueryType.ClientSummaryExtended, dto.OTROCOND_RES2);
                
                auxQueryStore.AddParamCount(QueryType.ClientSummaryExtended, dto.OTRO2COND_RES2);
                
                auxQueryStore.AddParamCount(QueryType.ClientSummaryExtended, dto.OTRO3COND_RES2);
                
                auxQueryStore.AddParamCount(QueryType.ClientSummaryExtended, dto.CONDUCTOR_CON1);
                
                auxQueryStore.AddParamCount(QueryType.QueryCity, dto.POCOND_RES2);
                
                auxQueryStore.AddParamCount(QueryType.QueryCountry, dto.PAISNIFCOND_RES2);
                
                auxQueryStore.AddParamCount(QueryType.QueryCounty, dto.PAISCOND_RES2);
                
                auxQueryStore.AddParamCount(QueryType.QueryProvince, dto.PROVCOND_RES2);
                
                var query = auxQueryStore.BuildQuery();
                using (var connection = SqlExecutor.OpenNewDbConnection())
                {
                    if (connection != null)
                    {
                        var multipleResult = await connection.QueryMultipleAsync(query).ConfigureAwait(false);
                        result.Valid = ParseResult(result, multipleResult);
                    }
                }
            }
            return result;
        }
        private bool ParseResult(IBookingData request, SqlMapper.GridReader reader)
        {

         if ((request == null) || (reader==null))
         {
                return false;
         }
         if (request.Value == null)
            {
                return false;
            }
            try
            {
              
                request.OfficeDto = SelectionHelpers.WrappedSelectedDto<CODIGO, OfficeDto>(request.Value.OFICINA_RES1, _mapper, reader);
              
                request.ReservationOfficeDeparture = SelectionHelpers.WrappedSelectedDto<CODIGO, OfficeDto>(request.Value.OFISALIDA_RES1, _mapper, reader);
              
                request.ReservationOfficeArrival = SelectionHelpers.WrappedSelectedDto<CODIGO, OfficeDto>(request.Value.OFIRETORNO_RES1, _mapper, reader);
              
                request.BudgetDto = SelectionHelpers.WrappedSelectedDto<NUMERO_PRE, BudgetDto>(request.Value.PRESUPUESTO_RES1, _mapper, reader);
              
                request.FareDto = SelectionHelpers.WrappedSelectedDto<NTARI, FareDto>(request.Value.TARIFA_RES1, _mapper, reader);
              
                request.VehicleGroupDto = SelectionHelpers.WrappedSelectedDto<CODIGO, VehicleGroupDto>(request.Value.GRUPO_RES1, _mapper, reader);
              
                request.BrokerDto = SelectionHelpers.WrappedSelectedDto<NUM_COMI, CommissionAgentSummaryDto>(request.Value.COMISIO_RES2, _mapper, reader);
              
                request.VehicleDto = SelectionHelpers.WrappedSelectedDto<CODIINT, VehicleSummaryDto>(request.Value.VCACT_RES1, _mapper, reader);
              
                request.DriverDto3 = SelectionHelpers.WrappedSelectedDto<NUMERO_CLI, ClientSummaryExtended>(request.Value.OTROCOND_RES2, _mapper, reader);
              
                request.DriverDto4 = SelectionHelpers.WrappedSelectedDto<NUMERO_CLI, ClientSummaryExtended>(request.Value.OTRO2COND_RES2, _mapper, reader);
              
                request.DriverDto5 = SelectionHelpers.WrappedSelectedDto<NUMERO_CLI, ClientSummaryExtended>(request.Value.OTRO3COND_RES2, _mapper, reader);
              
                request.DriverDto2 = SelectionHelpers.WrappedSelectedDto<NUMERO_CLI, ClientSummaryExtended>(request.Value.CONDUCTOR_CON1, _mapper, reader);
              
                request.CityDto3 = SelectionHelpers.WrappedSelectedDto<CP, CityDto>(request.Value.POCOND_RES2, _mapper, reader);
              
                request.DriverCountryList = SelectionHelpers.WrappedSelectedDto<SIGLAS, CountryDto>(request.Value.PAISNIFCOND_RES2, _mapper, reader);
              
                request.CountryDto3 = SelectionHelpers.WrappedSelectedDto<Value.CODIGO, CountryDto>(request.Value.PAISCOND_RES2, _mapper, reader);
              
                request.ProvinceDto3 = SelectionHelpers.WrappedSelectedDto<Value.CODIGO, ProvinciaDto>(request.Value.PROVCOND_RES2, _mapper, reader);
              

#pragma warning disable CS0168 // Variable is declared but never used
            }
            catch (System.Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                return false;
            }
            return true;
        }

             */
        /// <summary>
        ///  Load a single value.
        /// </summary>
        /// <param name="code">Reservation code.</param>
        /// <returns>An empty booking dto in case of fault, </returns>
        public async Task<BookingDto> LoadValueAsync(string code)
        {
            var reservationDto = new BookingDto();
            reservationDto.IsValid = false;
            if (string.IsNullOrEmpty(code))
            {
                return reservationDto;
            }
            using (var dbConnection = _sqlExecutor.OpenNewDbConnection())
            {

                var queryStore = _queryStoreFactory.GetQueryStore();

                var query = queryStore.AddParam(QueryType.QueryBooking, code).BuildQuery();
                _logger.Log(LogLevel.Debug, query);
                var multi = await dbConnection.QueryMultipleAsync(query).ConfigureAwait(false);
                var reservation = multi.Read<BookingPoco>().FirstOrDefault();
                var reservationItems = multi.Read<LIRESER>();
                if (reservation != null)
                {
                    reservationDto = _mapper.Map<BookingPoco, BookingDto>(reservation);
                }
                else
                {
                    return reservationDto;
                }

                if (reservationItems != null)
                {
                    
                    reservationDto.Items = _mapper.Map<IEnumerable<LIRESER>, IEnumerable<BookingItemsDto>>(reservationItems);
                   
                }
                 reservationDto.IsValid = true;
                
            }
            return reservationDto;
        }
        /// <summary>
        ///  Parse the data from the auxiliar 
        /// </summary>
        /// <param name="data">Booking object to be used.</param>
        /// <param name="reader">Reader to be used.</param>
        private void ParseAuxData(ref BookingDto data, SqlMapper.GridReader reader)
        {
            data.Drivers = SelectionHelpers.WrappedSelectedDto<ClientSummaryExtended, ClientSummaryExtended>(data.CONDUCTOR_RES1, _mapper, reader);
            data.Clients = SelectionHelpers.WrappedSelectedDto<ClientSummaryExtended, ClientSummaryExtended>(data.CLIENTE_RES1, _mapper, reader);
        }

        /// <summary>
        ///  Create a single query.
        /// </summary>
        /// <param name="data">Data to be used in a reservation.</param>
        /// <returns>Returns a query.</returns>
        private string CreateAuxQuery(BookingDto data)
        {
            var queryStore = _queryStoreFactory.GetQueryStore();
            queryStore.AddParamCount(QueryType.QueryClientSummaryExtById, data.CONDUCTOR_RES1);
            var builder = new StringBuilder();
            var queryStore2 = _queryStoreFactory.GetQueryStore();
            queryStore2.AddParamCount(QueryType.QueryClientSummaryExtById, data.CLIENTE_RES1);
            builder.Append(queryStore.BuildQuery());
            builder.Append(queryStore2.BuildQuery());
            var executableQuery = builder.ToString();
            builder.Clear();
            return executableQuery;
        }

        /// <summary>
        ///  Load at most m reservation.
        /// </summary>
        /// <param name="n">Number of element</param>
        /// <param name="back">If you can go head or back.</param>
        /// <returns>A list of booking dto.</returns>
        public async Task<IEnumerable<BookingDto>> LoadValueAtMostAsync(int n, int back = 0)
        {
            var reservationDto = new List<BookingDto>();
            using (var dbConnection = _sqlExecutor.OpenNewDbConnection())
            {
                _currentPos += back;
                if (_currentPos < 1)
                {
                    _currentPos = 1;
                }
                var queryStore = _queryStoreFactory.GetQueryStore();
                var query = queryStore.AddParamRange(QueryType.QueryBookedPaged, _currentPos, n).BuildQuery();
                var result = await dbConnection.QueryAsync<BookingPoco>(query);
                var dtoList = _mapper.Map<IEnumerable<BookingPoco>, IEnumerable<BookingDto>>(result);
                reservationDto = dtoList.ToList<BookingDto>();
            }
            return reservationDto;
        }
    }
}
