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
	  /// <summary>
      ///  Data Access Layer Repository generated automagically by Karve CodeGenerator Project.
      /// </summary>
    class IncidentDataAccessLayer : AbstractDataAccessLayer, IIncidentDataService
    {
        private IDataLoader<IncidentDto> _dataLoader;
        private IDataSaver<IncidentDto> _dataSaver;
        private IDataDeleter<IncidentDto> _dataDeleter;
        private IMapper _mapper;

        public IncidentDataAccessLayer(ISqlExecutor sqlExecutor): base(sqlExecutor)
        {
            _dataLoader = new DataLoader<INCIDENCIAS, IncidentDto>(sqlExecutor);
            _dataSaver = new DataSaver<INCIDENCIAS, IncidentDto>(sqlExecutor);
            _dataDeleter = new DataDeleter<INCIDENCIAS, IncidentDto>(sqlExecutor);
            TableName = "INCIDENCIAS";
            _mapper = MapperField.GetMapper();
        }
        public async Task<bool> DeleteAsync(IIncidentData domainObject)
        {
            if (!domainObject.Valid)
            {
                return false;
            }
            var dto = domainObject.Value;
            var result = await _dataDeleter.DeleteAsync(dto).ConfigureAwait(false);
            return result;
        }

        public async Task<IIncident> GetDoAsync(string code)
        {
            IIncident result = new NullIncident();
            try
            {
                var dto  = await _dataLoader.LoadValueAsync(code).ConfigureAwait(false);
                result = new Incident(dto);
                result.Valid = true;
            }
            catch (System.Exception ex)
            {
                throw new DataAccessLayerException("Invalid request received with "+code, ex);
            }
            // now i shall use a query store again for setting and loading related stuff.
            if (result.Valid)
            {
				result = await BuildAux(result).ConfigureAwait(false);
            }
            return result;
        }
		 public async Task<IIncidentData> BuildAux(IIncidentData result)
		 {
			 var auxQueryStore = QueryStoreFactory.GetQueryStore();
                #region KarveCode Generator for query multiple
				// Code Generated that concatains multiple queries to be executed by QueryMultipleAsync.
                
                auxQueryStore.AddParamCount(QueryType.QueryOffice, dto.OFICINA);
                
                auxQueryStore.AddParamCount(QueryType.QuerySupplierSummary, dto.PROVEE);
                
                auxQueryStore.AddParamCount(QueryType.QueryVehicleSummary, dto.VEHI);
                
                auxQueryStore.AddParamCount(QueryType.ClientSummaryExtended, dto.CLIENTE);
                
                auxQueryStore.AddParamCount(QueryType.IncidentType, dto.COINRE);
                
				#endregion
                var query = auxQueryStore.BuildQuery();
                using (var connection = SqlExecutor.OpenNewDbConnection())
                {
                    if (connection != null)
                    {
                        var multipleResult = await connection.QueryMultipleAsync(query).ConfigureAwait(false);
                        result.Valid = ParseResult(result, multipleResult);
                    }
                }
				return result;
		 }
        private bool ParseResult(IIncidentData request, SqlMapper.GridReader reader)
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
              
                request.IncidentOfficeDto = SelectionHelpers.WrappedSelectedDto<OFICINA, OfficeDto>(request.Value.OFICINA, _mapper, reader);
              
                request.IncidentSupplierDto = SelectionHelpers.WrappedSelectedDto<PROVEE1, SupplierSummaryDto>(request.Value.PROVEE, _mapper, reader);
              
                request.IncidentVehicleDto = SelectionHelpers.WrappedSelectedDto<VehicleSummaryDto, VehicleSummaryDto>(request.Value.VEHI, _mapper, reader);
              
                request.IncidentClientDto = SelectionHelpers.WrappedSelectedDto<ClientSummaryExtended, ClientSummaryExtended>(request.Value.CLIENTE, _mapper, reader);
              
                request.IncidentTypeDto = SelectionHelpers.WrappedSelectedDto<COINRE, IncidentTypeDto>(request.Value.TIPO, _mapper, reader);
              

#pragma warning disable CS0168 // Variable is declared but never used
            }
            catch (System.Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                return false;
            }
            return true;
        }

        public IIncident GetNewDo(string value)
        {
            var newDto = new IncidentDto();
            newDto.CodeId = value;
            newDto.IsNew = true;
            var domainObject = new IncidentData(newDto);
            return domainObject;
        }
        public async Task<IEnumerable<IncidentSummary>> GetPagedSummaryDoAsync(int index, int pageSize)
        {
            if (pageSize <= 0)
            {
                throw new ArgumentException();
            }
            var pager = new DataPager<IncidentSummary>(SqlExecutor);
            var pageStart = index;
            if (pageStart <= 0)
                pageStart = 1;
            NumberPage = await GetPageCount(pageSize).ConfigureAwait(false);
            var datas = await pager.GetPagedSummaryDoAsync(QueryStore.IncidentSummaryPaged, pageStart, pageSize).ConfigureAwait(false);
            return datas;
        }

        public async Task<IEnumerable<IncidentSummary>> GetSortedCollectionPagedAsync(Dictionary<string, ListSortDirection> sortChain, long index, int pageSize)
        {
            if (pageSize <=0)
            {
                throw new ArgumentException();
            }
            var dataPager = new DataPager<IncidentSummary>(SqlExecutor);
            var pageStart = index;
            if (pageStart <= 0)
                pageStart = 1;
            NumberPage = await GetPageCount(pageSize).ConfigureAwait(false);
            var datas = await dataPager.GetPagedSummaryDoSortedAsync(QueryStore.IncidentSummaryPaged, sortChain, index, pageSize).ConfigureAwait(false);
            return datas;
        }
        public async Task<IEnumerable<IncidentSummary>> GetSummaryAllAsync()
        {
            var queryStore = QueryStoreFactory.GetQueryStore();
            queryStore.AddParam(QueryType.QueryIncidentSummaryPagedSummary);
            var query = queryStore.BuildQuery();
            IEnumerable<IncidentSummary> outResult = new List<IncidentSummary>();
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
              if (dbConnection == null)
                {
                    throw new DataAccessLayerException("GetSummaryAllAsync cannot connect");
                }
              outResult = await dbConnection.QueryAsync<IncidentSummary>(query).ConfigureAwait(false);
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
                    var pet = new INCIDENCIAS();
                    uniqueId = connection.UniqueId(pet);
                    return uniqueId;
                }
            }
            return uniqueId;
        }
        public async Task<bool> SaveAsync(IIncidentData domainObject)
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