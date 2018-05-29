using System.Collections.Generic;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using DataAccessLayer.Crud.Company;
using DataAccessLayer.SQL;
using System.Data;
using KarveDapper;
using KarveDapper.Extensions;
using Dapper;
using System.Collections.ObjectModel;
using DataAccessLayer.Model;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Exception;
using System.ComponentModel;

namespace DataAccessLayer
{
    /// <summary>
    ///  CompanyDataServices class has the resposability to load/store company data.
    /// </summary>
    internal class CompanyDataServices: AbstractDataAccessLayer, ICompanyDataServices
    {
        /// <summary>
        ///  We tried to have a separate resposability to each so we split the class 
        ///  in loader, saver, deleter.
        /// </summary>
        private CompanyDataLoader _loader;
        private CompanyDataSaver _saver;
        private CompanyDataDeleter _deleter;
       
        /// <summary>
        ///  This is a service for loading company data
        /// </summary>
        /// <param name="sqlExecutor">Interface to the sql executor</param>
        public CompanyDataServices(ISqlExecutor sqlExecutor): base(sqlExecutor)
        {
           
            _loader = new CompanyDataLoader(sqlExecutor);
            _saver = new CompanyDataSaver(sqlExecutor);
            _deleter = new CompanyDataDeleter(sqlExecutor);
            // it is important to set for paging.
            TableName = "SUBLICEN";
        }
        
        /// <summary>
        /// This delete the company asynchronously
        /// </summary>
        /// <param name="companyData">Data of the company</param>
        /// <returns>Return true of delete successfully</returns>
        public async Task<bool> DeleteCompanyAsyncDo(ICompanyData companyData)
        {
            if (companyData.Value == null)
            {
                return false;
            }
            return await _deleter.DeleteAsync(companyData.Value).ConfigureAwait(false);
        }
        /// <summary>
        ///Get the list of company summary.
        /// </summary>
        /// <returns>Return the list of company summary</returns>
        public async Task<IEnumerable<CompanySummaryDto>> GetAsyncAllCompanySummary()
        {
            var store = QueryStoreFactory.GetQueryStore();
            store.AddParam(QueryType.QueryCompanySummary);
            var query = store.BuildQuery();
            IEnumerable<CompanySummaryDto> companySummaryDto = new ObservableCollection<CompanySummaryDto>();
            using (var conn = SqlExecutor.OpenNewDbConnection())
            {
                try
                {
                    companySummaryDto = await conn.QueryAsync<CompanySummaryDto>(query);

                } catch (System.Exception ex)
                {
                    throw new DataAccessLayerException("GetAsyncAllCompanySummary exception", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
            return companySummaryDto;
        }
        /// <summary>
        ///  Retrieve the company data object given the company identifier.
        /// </summary>
        /// <param name="id">Identifier of the company</param>
        /// <returns>Data of the company</returns>
        public async Task<ICompanyData> GetAsyncCompanyDo(string id)
        {
            CompanyDto dto =  await _loader.LoadValueAsync(id).ConfigureAwait(true);
            ICompanyData data = new Company();
            data.Value = dto;
            // initialize the dto for the province and the city.
            var prov = new ObservableCollection<ProvinciaDto>();
            var city = new ObservableCollection<CityDto>();
            prov.Add(dto.Province);
            city.Add(dto.City);
            data.ProvinciaDto = new ObservableCollection<ProvinciaDto>();
            data.CityDto = city;
            data.ProvinciaDto = prov;
            return data;
        }
        /// <summary>
        ///  Create a new company object
        /// </summary>
        /// <param name="code">Code of the company.</param>
        /// <returns>Create a new company.</returns>
        public ICompanyData GetNewCompanyDo(string code)
        {
            var dto = new CompanyDto
            {
                Code = code,
                CODIGO = code
            };
            ICompanyData data = new Company
            {
                Value = dto
            };
            return data;
        }
        /// <summary>
        ///  Returns a company identifier
        /// </summary>
        /// <returns>Get a new identifier unique for the company</returns>
        public string GetNewId()
        {
            string id = string.Empty;
            using (var conn = SqlExecutor.OpenNewDbConnection())
            {
                
                var sublicen = new SUBLICEN();
                id =  conn?.UniqueId<SUBLICEN>(sublicen);
            }
            return id;
        }
        /// <summary>
        ///  Get the list of tha paged company. Compute as side effect the number of pages.
        /// </summary>
        /// <param name="baseIndex">Index of the company</param>
        /// <param name="defaultPageSize">default page size</param>
        /// <returns></returns>
        public async Task<IEnumerable<CompanySummaryDto>> GetPagedSummaryDoAsync(int baseIndex, int defaultPageSize)
        {
            var pager = new DataPager<CompanySummaryDto>(SqlExecutor);
            var pageStart = baseIndex;
            if (pageStart == 0)
                pageStart = 1;
            NumberPage = await GetPageCount(defaultPageSize);
            var datas = await pager.GetPagedSummaryDoAsync(QueryType.QueryCompanyPaged, pageStart,defaultPageSize);
            return datas;
        }
        /// <summary>
        ///  This returns a sorted summary sorted and extended collection.
        /// </summary>
        /// <param name="sortChain">Sort direction</param>
        /// <param name="pageIndex">Index of the page</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>A list of sorted company</returns>
        public async Task<IEnumerable<CompanySummaryDto>> GetSortedCollectionPagedAsync(
            Dictionary<string, ListSortDirection> sortChain, long pageIndex, int pageSize)
        {
            var dataPager = new DataPager<CompanySummaryDto>(SqlExecutor);
            var pageStart = pageIndex;
            if (pageStart == 0)
                pageStart = 1;
            NumberPage = await GetPageCount(pageSize).ConfigureAwait(false);
            var datas = await dataPager.GetPagedSummaryDoSortedAsync(QueryType.QueryCompanyPaged, sortChain, pageIndex, pageSize);
            return datas;
        }

        /// <summary>
        ///  Save the data of the company asynchronously.
        /// </summary>
        /// <param name="companyData">Company data</param>
        /// <returns>Boolean company</returns>
        public async Task<bool> SaveAsync(ICompanyData companyData)
        {
            if (companyData.Value == null)
            {
                return false;
            }
            return await _saver.SaveAsync(companyData.Value).ConfigureAwait(false);
        }
    }
}