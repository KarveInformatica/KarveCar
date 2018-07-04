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
    class ReservationRequestDataAccessLayer : AbstractDataAccessLayer, IReservationRequestDataService
    {
        private IDataLoader<ReservationRequestDto> _dataLoader;
        private IDataSaver<ReservationRequestDto> _dataSaver;
        private IDataDeleter<ReservationRequestDto> _dataDeleter;
        private IMapper _mapper;

        public ReservationRequestDataAccessLayer(ISqlExecutor sqlExecutor): base(sqlExecutor)
        {
            _dataLoader = new DataLoader<PETICION, ReservationRequestDto>(sqlExecutor);
            _dataSaver = new DataSaver<PETICION, ReservationRequestDto>(sqlExecutor);
            _dataDeleter = new DataDeleter<PETICION, ReservationRequestDto>(sqlExecutor);
            TableName = "PETICION";
            _mapper = MapperField.GetMapper();
        }
        public async Task<bool> DeleteAsync(IReservationRequest booking)
        {
            if (!booking.Valid)
            {
                return false;
            }
            var dto = booking.Value;
            var result = await _dataDeleter.DeleteAsync(dto).ConfigureAwait(false);
            return result;
        }

        public async Task<IReservationRequest> GetDoAsync(string code)
        {
            IReservationRequest result = new NullReservationRequest();
            try
            {
                var dto  = await _dataLoader.LoadValueAsync(code).ConfigureAwait(false);
                result = new ReservationRequest(dto);
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
                auxQueryStore.AddParamCount(QueryType.QueryReservationRequestReason, result.Value.MOPETI);
                auxQueryStore.AddParamCount(QueryType.QueryOffice, result.Value.OFICINA);
                auxQueryStore.AddParamCount(QueryType.QueryClientSummaryExtById, result.Value.CLIENTE);
                auxQueryStore.AddParamCount(QueryType.QueryReseller, result.Value.VENDEDOR);
                auxQueryStore.AddParamCount(QueryType.QueryFares, result.Value.TARIFA);
                auxQueryStore.AddParamCount(QueryType.QueryCompany, result.Value.SUBLICEN);
                auxQueryStore.AddParamCount(QueryType.QueryVehicleGroup, result.Value.CATEGO);
                auxQueryStore.AddParamCount(QueryType.QueryOrigin, SelectionHelpers.ValueString(result.Value.ORIGEN));
                auxQueryStore.AddParamCount(QueryType.QueryVehicleSummaryById, result.Value.OTRO_VEHI);
               

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
        private bool ParseResult(IReservationRequest request, SqlMapper.GridReader reader)
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
                request.ResquestReasonDto = SelectionHelpers.WrappedSelectedDto<MOPETI, RequestReasonDto>(request.Value.MOPETI, _mapper, reader);
                request.OfficeDto = SelectionHelpers.WrappedSelectedDto<OFICINAS, OfficeDtos>(request.Value.OFICINA, _mapper, reader);
                request.ClientDto = SelectionHelpers.WrappedSelectedDto<ClientSummaryExtended, ClientSummaryExtended>(request.Value.CLIENTE, _mapper, reader);
                request.ResellerDto = SelectionHelpers.WrappedSelectedDto<VENDEDOR, ResellerDto>(request.Value.VENDEDOR, _mapper, reader);
                request.FareDto = SelectionHelpers.WrappedSelectedDto<NTARI, FareDto>(request.Value.TARIFA, _mapper, reader);
                request.CompanyDto = SelectionHelpers.WrappedSelectedDto<SUBLICEN, CompanyDto>(request.Value.SUBLICEN, _mapper, reader);
                request.GroupDto = SelectionHelpers.WrappedSelectedDto<GRUPOS, VehicleGroupDto>(request.Value.CATEGO, _mapper, reader);
                request.OriginDto = SelectionHelpers.WrappedSelectedDto<ORIGEN, OrigenDto>(request.Value.ORIGEN, _mapper, reader);
                request.VehicleDto = SelectionHelpers.WrappedSelectedDto<VehicleSummaryDto, VehicleSummaryDto>(request.Value.OTRO_VEHI, _mapper, reader);
               
               
#pragma warning disable CS0168 // Variable is declared but never used
            }
            catch (System.Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                return false;
            }
            return true;
        }

        public IReservationRequest GetNewDo(string value)
        {
            var newDto = new ReservationRequestDto();
            newDto.Code = value;
            newDto.IsNew = true;
            newDto.NUMERO = value;
            var reservationRequest = new ReservationRequest(newDto);
            return reservationRequest;
        }
        public async Task<IEnumerable<ReservationRequestSummary>> GetPagedSummaryDoAsync(int index, int pageSize)
        {
            if (pageSize <= 0)
            {
                throw new ArgumentException();
            }
            var pager = new DataPager<ReservationRequestSummary>(SqlExecutor);
            var pageStart = index;
            if (pageStart <= 0)
                pageStart = 1;
            NumberPage = await GetPageCount(pageSize).ConfigureAwait(false);
            var datas = await pager.GetPagedSummaryDoAsync(QueryType.QueryReservationRequestSummaryPaged, pageStart, pageSize).ConfigureAwait(false);
            return datas;
        }

        public async Task<IEnumerable<ReservationRequestSummary>> GetSortedCollectionPagedAsync(Dictionary<string, ListSortDirection> sortChain, long index, int pageSize)
        {
            if (pageSize <=0)
            {
                throw new ArgumentException();
            }
            var dataPager = new DataPager<ReservationRequestSummary>(SqlExecutor);
            var pageStart = index;
            if (pageStart <= 0)
                pageStart = 1;
            NumberPage = await GetPageCount(pageSize).ConfigureAwait(false);
            var datas = await dataPager.GetPagedSummaryDoSortedAsync(QueryType.QueryReservationRequestSummaryPaged, sortChain, index, pageSize).ConfigureAwait(false);
            return datas;
        }
        public async Task<IEnumerable<ReservationRequestSummary>> GetSummaryAllAsync()
        {
            var queryStore = QueryStoreFactory.GetQueryStore();
            queryStore.AddParam(QueryType.QueryReservationRequestSummary);
            var query = queryStore.BuildQuery();
            IEnumerable<ReservationRequestSummary> outResult = new List<ReservationRequestSummary>();
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
              if (dbConnection == null)
                {
                    throw new DataAccessLayerException("GetSummaryAllAsync cannot connect");
                }
              outResult = await dbConnection.QueryAsync<ReservationRequestSummary>(query).ConfigureAwait(false);
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
                    var pet = new PETICION();
                    uniqueId = connection.UniqueId(pet);
                    return uniqueId;
                }
            }
            return uniqueId;
        }
        public async Task<bool> SaveAsync(IReservationRequest bookingData)
        {
           if (!bookingData.Valid)
           {
                return false;
           }
            var savedReservation = await _dataSaver.SaveAsync(bookingData.Value).ConfigureAwait(false);
            return savedReservation;
        }
    }
}
