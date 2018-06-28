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
    class {{data.name}}DataAccessLayer : AbstractDataAccessLayer, I{{data.name}}DataService
    {
        private IDataLoader<{{data.name}}Dto> _dataLoader;
        private IDataSaver<{{data.name}}Dto> _dataSaver;
        private IDataDeleter<{{data.name}}Dto> _dataDeleter;
        private IMapper _mapper;

        public {{data.name}}DataAccessLayer(ISqlExecutor sqlExecutor): base(sqlExecutor)
        {
            _dataLoader = new DataLoader<{{data.tablename}}, {{data.name}}Dto>(sqlExecutor);
            _dataSaver = new DataSaver<{{data.tablename}}, {{data.name}}Dto>(sqlExecutor);
            _dataDeleter = new DataDeleter<{{data.tablename}}, {{data.name}}Dto>(sqlExecutor);
            TableName = "{{data.tablename}}";
            _mapper = MapperField.GetMapper();
        }
        public async Task<bool> DeleteAsync(I{{data.name}}Data domainObject)
        {
            if (!domainObject.Valid)
            {
                return false;
            }
            var dto = domainObject.Value;
            var result = await _dataDeleter.DeleteAsync(dto).ConfigureAwait(false);
            return result;
        }

        public async Task<I{{data.name}}> GetDoAsync(string code)
        {
            I{Name} = new Null{{data.name}}();
            try
            {
                var dto  = await _dataLoader.LoadValueAsync(code).ConfigureAwait(false);
                result = new {{data.name}}(dto);
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
                {% for query in data.queries %}
                auxQueryStore.AddParamCount({{query.type}}, {{query.param}});
                {% endfor %}
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
        private bool ParseResult(I{{data.name}}Data request, SqlMapper.GridReader reader)
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
              {% for result in data.queryresult %}
                request.{{result.auxdto}} = SelectionHelpers.WrappedSelectedDto<{{result.entityaux}}, {{result.entityfieldtype}}>(request.{{result.entityfield}}, _mapper, reader);
              {% endfor %}

#pragma warning disable CS0168 // Variable is declared but never used
            }
            catch (System.Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                return false;
            }
            return true;
        }

        public I{{data.name}} GetNewDo(string value)
        {
            var newDto = new {{data.name}}Dto();
            newDto.CodeId = value;
            newDto.IsNew = true;
            var domainObject = new {{data.name}}Data(newDto);
            return domainObject;
        }
        public async Task<IEnumerable<{{data.name}}Summary>> GetPagedSummaryDoAsync(int index, int pageSize)
        {
            if (pageSize <= 0)
            {
                throw new ArgumentException();
            }
            var pager = new DataPager<{{data.name}}Summary>(SqlExecutor);
            var pageStart = index;
            if (pageStart <= 0)
                pageStart = 1;
            NumberPage = await GetPageCount(pageSize).ConfigureAwait(false);
            var datas = await pager.GetPagedSummaryDoAsync(QueryStore.{{data.pagedquery}}, pageStart, pageSize).ConfigureAwait(false);
            return datas;
        }

        public async Task<IEnumerable<{{data.name}}Summary>> GetSortedCollectionPagedAsync(Dictionary<string, ListSortDirection> sortChain, long index, int pageSize)
        {
            if (pageSize <=0)
            {
                throw new ArgumentException();
            }
            var dataPager = new DataPager<{{data.name}}Summary>(SqlExecutor);
            var pageStart = index;
            if (pageStart <= 0)
                pageStart = 1;
            NumberPage = await GetPageCount(pageSize).ConfigureAwait(false);
            var datas = await dataPager.GetPagedSummaryDoSortedAsync(QueryStore.{{data.pagedquery}}, sortChain, index, pageSize).ConfigureAwait(false);
            return datas;
        }
        public async Task<IEnumerable<{{data.name}}Summary>> GetSummaryAllAsync()
        {
            var queryStore = QueryStoreFactory.GetQueryStore();
            queryStore.AddParam(QueryType.Query{{data.pagedquery}}Summary);
            var query = queryStore.BuildQuery();
            IEnumerable<{{data.name}}Summary> outResult = new List<{{data.name}}Summary>();
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
              if (dbConnection == null)
                {
                    throw new DataAccessLayerException("GetSummaryAllAsync cannot connect");
                }
              outResult = await dbConnection.QueryAsync<{{data.name}}Summary>(query).ConfigureAwait(false);
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
                    var pet = new {{data.tablename}}();
                    uniqueId = connection.UniqueId(pet);
                    return uniqueId;
                }
            }
            return uniqueId;
        }
        public async Task<bool> SaveAsync(I{{data.name}}Data domainObject)
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
