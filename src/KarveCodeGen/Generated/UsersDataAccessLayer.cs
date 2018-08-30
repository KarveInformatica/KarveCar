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
    class UsersDataAccessLayer : AbstractDataAccessLayer, IUsersDataService
    {
        private IDataLoader<UsersDto> _dataLoader;
        private IDataSaver<UsersDto> _dataSaver;
        private IDataDeleter<UsersDto> _dataDeleter;
        private IMapper _mapper;

        public UsersDataAccessLayer(ISqlExecutor sqlExecutor): base(sqlExecutor)
        {
            _dataLoader = new DataLoader<USURE, UsersDto>(sqlExecutor);
            _dataSaver = new DataSaver<USURE, UsersDto>(sqlExecutor);
            _dataDeleter = new DataDeleter<USURE, UsersDto>(sqlExecutor);
            TableName = "USURE";
            _mapper = MapperField.GetMapper();
        }
        public async Task<bool> DeleteAsync(IUsersData domainObject)
        {
            if (!domainObject.Valid)
            {
                return false;
            }
            var dto = domainObject.Value;
            var result = await _dataDeleter.DeleteAsync(dto).ConfigureAwait(false);
            return result;
        }

        public async Task<IUsers> GetDoAsync(string code)
        {
            IUsers result = new NullUsers();
            try
            {
                var dto  = await _dataLoader.LoadValueAsync(code).ConfigureAwait(false);
                result = new Users(dto);
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
		 public async Task<IUsersData> BuildAux(IUsersData result)
		 {
			 var auxQueryStore = QueryStoreFactory.GetQueryStore();
                #region KarveCode Generator for query multiple
				// Code Generated that concatains multiple queries to be executed by QueryMultipleAsync.
                
                auxQueryStore.AddParamCount(QueryType.QueryOffice, dto.OFI_COD);
                
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
        private bool ParseResult(IUsersData request, SqlMapper.GridReader reader)
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
              
                request.UserOfficeDto = SelectionHelpers.WrappedSelectedDto<OFICINA, OfficeViewObject>(request.Value.OFI_COD, _mapper, reader);
              

#pragma warning disable CS0168 // Variable is declared but never used
            }
            catch (System.Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                return false;
            }
            return true;
        }

        public IUsers GetNewDo(string value)
        {
            var newDto = new UsersDto();
            newDto.CodeId = value;
            newDto.IsNew = true;
            var domainObject = new UsersData(newDto);
            return domainObject;
        }
        public async Task<IEnumerable<UsersSummary>> GetPagedSummaryDoAsync(int index, int pageSize)
        {
            if (pageSize <= 0)
            {
                throw new ArgumentException();
            }
            var pager = new DataPager<UsersSummary>(SqlExecutor);
            var pageStart = index;
            if (pageStart <= 0)
                pageStart = 1;
            NumberPage = await GetPageCount(pageSize).ConfigureAwait(false);
            var datas = await pager.GetPagedSummaryDoAsync(QueryStore.UserSummaryPaged, pageStart, pageSize).ConfigureAwait(false);
            return datas;
        }

        public async Task<IEnumerable<UsersSummary>> GetSortedCollectionPagedAsync(Dictionary<string, ListSortDirection> sortChain, long index, int pageSize)
        {
            if (pageSize <=0)
            {
                throw new ArgumentException();
            }
            var dataPager = new DataPager<UsersSummary>(SqlExecutor);
            var pageStart = index;
            if (pageStart <= 0)
                pageStart = 1;
            NumberPage = await GetPageCount(pageSize).ConfigureAwait(false);
            var datas = await dataPager.GetPagedSummaryDoSortedAsync(QueryStore.UserSummaryPaged, sortChain, index, pageSize).ConfigureAwait(false);
            return datas;
        }
        public async Task<IEnumerable<UsersSummary>> GetSummaryAllAsync()
        {
            var queryStore = QueryStoreFactory.GetQueryStore();
            queryStore.AddParam(QueryType.QueryUserSummaryPagedSummary);
            var query = queryStore.BuildQuery();
            IEnumerable<UsersSummary> outResult = new List<UsersSummary>();
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
              if (dbConnection == null)
                {
                    throw new DataAccessLayerException("GetSummaryAllAsync cannot connect");
                }
              outResult = await dbConnection.QueryAsync<UsersSummary>(query).ConfigureAwait(false);
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
                    var pet = new USURE();
                    uniqueId = connection.UniqueId(pet);
                    return uniqueId;
                }
            }
            return uniqueId;
        }
        public async Task<bool> SaveAsync(IUsersData domainObject)
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