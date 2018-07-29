using KarveDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataTransferObject;
using DataAccessLayer.Crud;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Model;
using DataAccessLayer.Exception;
using Dapper;
using DataAccessLayer.SQL;
using System.ComponentModel;
using DataAccessLayer.Logic;
using KarveDapper.Extensions;
using AutoMapper;

namespace DataAccessLayer
{
    class BookingDataAccessLayer : AbstractDataAccessLayer, IBookingDataService
    {
        private IDataLoader<BookingDto> _dataLoader;
        private IDataSaver<BookingDto> _dataSaver;
        private IDataDeleter<BookingDto> _dataDeleter;
        private IMapper _mapper;

        public BookingDataAccessLayer(ISqlExecutor sqlExecutor): base(sqlExecutor)
        {
            _dataLoader = new DataLoader<RESERVAS1, BookingDto>(sqlExecutor);
            _dataSaver = new DataSaver<RESERVAS1, BookingDto>(sqlExecutor);
            _dataDeleter = new DataDeleter<RESERVAS1, BookingDto>(sqlExecutor);
            TableName = "RESERVAS1";
            _mapper = MapperField.GetMapper();
        }
        public async Task<bool> DeleteAsync(IBookingData domainObject)
        {
            if (!domainObject.Valid)
            {
                return false;
            }
            var dto = domainObject.Value;
            var result = await _dataDeleter.DeleteAsync(dto).ConfigureAwait(false);
            return result;
        }

        public async Task<IBooking> GetDoAsync(string code)
        {
            IBooking result = new NullBooking();
            try
            {
                var dto  = await _dataLoader.LoadValueAsync(code).ConfigureAwait(false);
                result = new Booking(dto);
                result.Valid = true;
            }
            catch (System.Exception ex)
            {
                throw new DataAccessLayerException("Invalid request received with "+code, ex);
            }
            // now i shall use a query store again for setting and loading related stuff.
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
              
                request.OfficeDto = SelectionHelpers.WrappedSelectedDto<OFICINA, OfficeDto>(request.Value.OFICINA_RES1, _mapper, reader);
              
                request.ReservationOfficeDeparture = SelectionHelpers.WrappedSelectedDto<OFICINA, OfficeDto>(request.Value.OFISALIDA_RES1, _mapper, reader);
              
                request.ReservationOfficeArrival = SelectionHelpers.WrappedSelectedDto<OFICINA, OfficeDto>(request.Value.OFIRETORNO_RES1, _mapper, reader);
              
                request.BudgetDto = SelectionHelpers.WrappedSelectedDto<PRESUP1, BudgetDto>(request.Value.PRESUPUESTO_RES1, _mapper, reader);
              
                request.FareDto = SelectionHelpers.WrappedSelectedDto<NTARI, FareDto>(request.Value.TARIFA_RES1, _mapper, reader);
              
                request.VehicleGroupDto = SelectionHelpers.WrappedSelectedDto<GRUPOS, VehicleGroupDto>(request.Value.GRUPO_RES1, _mapper, reader);
              
                request.BrokerDto = SelectionHelpers.WrappedSelectedDto<COMISIO, CommissionAgentSummaryDto>(request.Value.COMISIO_RES2, _mapper, reader);
              
                request.VehicleDto = SelectionHelpers.WrappedSelectedDto<VEHICULOS1, VehicleSummaryDto>(request.Value.VCACT_RES1, _mapper, reader);
              
                request.DriverDto3 = SelectionHelpers.WrappedSelectedDto<CLIENTES1, ClientSummaryExtended>(request.Value.OTROCOND_RES2, _mapper, reader);
              
                request.DriverDto4 = SelectionHelpers.WrappedSelectedDto<CLIENTES1, ClientSummaryExtended>(request.Value.OTRO2COND_RES2, _mapper, reader);
              
                request.DriverDto5 = SelectionHelpers.WrappedSelectedDto<CLIENTES1, ClientSummaryExtended>(request.Value.OTRO3COND_RES2, _mapper, reader);
              
                request.DriverDto2 = SelectionHelpers.WrappedSelectedDto<CLIENTES1, ClientSummaryExtended>(request.Value.CONDUCTOR_CON1, _mapper, reader);
              
                request.CityDto3 = SelectionHelpers.WrappedSelectedDto<POBLACIONES, CityDto>(request.Value.POCOND_RES2, _mapper, reader);
              
                request.Country2Dto = SelectionHelpers.WrappedSelectedDto<PAIS, CountryDto>(request.Value.PAISNIFCOND_RES2, _mapper, reader);
              
                request.CountryDto3 = SelectionHelpers.WrappedSelectedDto<PAIS, CountryDto>(request.Value.PAISCOND_RES2, _mapper, reader);
              
                request.ProvinceDto3 = SelectionHelpers.WrappedSelectedDto<PROVINCIA, ProvinciaDto>(request.Value.PROVCOND_RES2, _mapper, reader);
              

#pragma warning disable CS0168 // Variable is declared but never used
            }
            catch (System.Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                return false;
            }
            return true;
        }

        public IBooking GetNewDo(string value)
        {
            var newDto = new BookingDto();
            newDto.CodeId = value;
            newDto.IsNew = true;
            var domainObject = new BookingData(newDto);
            return domainObject;
        }
        public async Task<IEnumerable<BookingSummary>> GetPagedSummaryDoAsync(int index, int pageSize)
        {
            if (pageSize <= 0)
            {
                throw new ArgumentException();
            }
            var pager = new DataPager<BookingSummary>(SqlExecutor);
            var pageStart = index;
            if (pageStart <= 0)
                pageStart = 1;
            NumberPage = await GetPageCount(pageSize).ConfigureAwait(false);
            var datas = await pager.GetPagedSummaryDoAsync(QueryStore.BookingSummaryPaged, pageStart, pageSize).ConfigureAwait(false);
            return datas;
        }

        public async Task<IEnumerable<BookingSummary>> GetSortedCollectionPagedAsync(Dictionary<string, ListSortDirection> sortChain, long index, int pageSize)
        {
            if (pageSize <=0)
            {
                throw new ArgumentException();
            }
            var dataPager = new DataPager<BookingSummary>(SqlExecutor);
            var pageStart = index;
            if (pageStart <= 0)
                pageStart = 1;
            NumberPage = await GetPageCount(pageSize).ConfigureAwait(false);
            var datas = await dataPager.GetPagedSummaryDoSortedAsync(QueryStore.BookingSummaryPaged, sortChain, index, pageSize).ConfigureAwait(false);
            return datas;
        }
        public async Task<IEnumerable<BookingSummary>> GetSummaryAllAsync()
        {
            var queryStore = QueryStoreFactory.GetQueryStore();
            queryStore.AddParam(QueryType.QueryBookingSummaryPagedSummary);
            var query = queryStore.BuildQuery();
            IEnumerable<BookingSummary> outResult = new List<BookingSummary>();
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
              if (dbConnection == null)
                {
                    throw new DataAccessLayerException("GetSummaryAllAsync cannot connect");
                }
              outResult = await dbConnection.QueryAsync<BookingSummary>(query).ConfigureAwait(false);
            }
            return outResult;
        }
        public string NewId()
        {
            string uniqueId = string.Empty;
            using (var connection = SqlExecutor.OpenNewDbConnection())
            {
                if (connection != null)
                {
                    var pet = new RESERVAS1();
                    uniqueId = connection.UniqueId(pet);
                    return uniqueId;
                }
            }
            return uniqueId;
        }
        public async Task<bool> SaveAsync(IBookingData domainObject)
        {
           if (!domainObject.Valid)
           {
                return false;
           }
            var savedReservation = await _dataSaver.SaveAsync(domainObject.Value).ConfigureAwait(false);
            return savedReservation;
        }
    }
}