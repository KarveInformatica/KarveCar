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

namespace DataAccessLayer
{
    internal class CompanyDataServices: ICompanyDataServices
    {
        private ISqlExecutor sqlExecutor;
        private CompanyDataLoader _loader;
        private CompanyDataSaver _saver;
        private CompanyDataDeleter _deleter;
        private QueryStoreFactory _queryStoreFactory = new QueryStoreFactory();
        /// <summary>
        ///  This is a service for loading company data
        /// </summary>
        /// <param name="sqlExecutor">Interface to the sql executor</param>
        public CompanyDataServices(ISqlExecutor sqlExecutor)
        {
            this.sqlExecutor = sqlExecutor;
            _loader = new CompanyDataLoader(sqlExecutor);
            _saver = new CompanyDataSaver(sqlExecutor);
            _deleter = new CompanyDataDeleter(sqlExecutor);
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
            IQueryStore store = _queryStoreFactory.GetQueryStore();
            store.AddParam(QueryType.QueryCompanySummary);
            var query = store.BuildQuery();
            IEnumerable<CompanySummaryDto> companySummaryDto = new ObservableCollection<CompanySummaryDto>();
            using (IDbConnection conn = sqlExecutor.OpenNewDbConnection())
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
            //data.CountryDto = new ObservableCollection<>
            return data;
        }
        /// <summary>
        ///  Return new company objects.
        /// </summary>
        /// <param name="code">Code of the company.</param>
        /// <returns>Create a new company.</returns>
        public ICompanyData GetNewCompanyDo(string code)
        {
            CompanyDto dto = new CompanyDto
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
        ///  Return a company identifier
        /// </summary>
        /// <returns>Get a new identifier unique for the company</returns>
        public string GetNewId()
        {
            string id = string.Empty;
            using (IDbConnection conn = sqlExecutor.OpenNewDbConnection())
            {
                var sublicen = new SUBLICEN();
                id =  conn.UniqueId<SUBLICEN>(sublicen);
            }
            return id;
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