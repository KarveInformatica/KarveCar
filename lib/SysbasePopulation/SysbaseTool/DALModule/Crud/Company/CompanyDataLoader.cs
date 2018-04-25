using KarveDataServices;
using KarveDataServices.DataTransferObject;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer.SQL;
using KarveDapper.Extensions;
using DataAccessLayer.DataObjects;
using AutoMapper;
using DataAccessLayer.Logic;
using Dapper;
using System.Linq;

namespace DataAccessLayer.Crud.Company
{
    /// <summary>
    ///  Company loader
    /// </summary>
    internal sealed class CompanyDataLoader : IDataLoader<CompanyDto>
    {
        private ISqlExecutor _sqlExecutor;
        private IMapper _mapper;
        private IHelperData _helperBase;
        private long _currentPos;
        private QueryStoreFactory _queryStoreFactory;
        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="sqlExecutor">This load the sql executor</param>
        public CompanyDataLoader(ISqlExecutor sqlExecutor)
        {
            _sqlExecutor = sqlExecutor;
            _mapper = MapperField.GetMapper();
            _currentPos = 0;
            _helperBase = new HelperBase();
            _queryStoreFactory = new QueryStoreFactory();
        }
        /// <summary>
        ///  Load all the companies present in the system
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CompanyDto>> LoadAsyncAll()
        {
            IEnumerable<CompanyDto> companyDto = new List<CompanyDto>();
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                var value =  await connection.GetAllAsync<SUBLICEN>();
                companyDto = _mapper.Map<IEnumerable<SUBLICEN>, IEnumerable<CompanyDto>>(value);
            }
            return companyDto;
        }
        /// <summary>
        ///  Load just a company with a code primary key value
        /// </summary>
        /// <param name="code">Identifier of the company</param>
        /// <returns>The company data transfer object.</returns>
        public async Task<CompanyDto> LoadValueAsync(string code)
        {
            CompanyDto companyDto = new CompanyDto();
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                var value = await connection.GetAsync<SUBLICEN>(code);
                companyDto = _mapper.Map<SUBLICEN, CompanyDto>(value);
                if (value != null)
                {
                    SqlMapper.GridReader reader = null;
                    IQueryStore store = CreateQueryStore(companyDto);
                    string multipleQuery = store.BuildQuery();
                    reader = await connection.QueryMultipleAsync(multipleQuery);
                    // set the helpers and maps the offices that belong to a company.
                    SetDataTransferObject(reader, value, ref companyDto);

                }
            }
            return companyDto;
        }
        /// <summary>
        /// Load at most N async values.
        /// </summary>
        /// <param name="n">Number of values from the current position to be loaded</param>
        /// <param name="back">offset, it can be positive or negative</param>
        /// <returns></returns>
        public async Task<IEnumerable<CompanyDto>> LoadValueAtMostAsync(int n, int back = 0)
        {

            IEnumerable<CompanyDto> companyDto = new List<CompanyDto>();
            IQueryStore store = _queryStoreFactory.GetQueryStore();
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                store.AddParamRange(QueryType.QueryPagedCompany, _currentPos, n);
                _currentPos += n + back;
                var query = store.BuildQuery();
                var value = await connection.QueryAsync<SUBLICEN>(query);

            }
            return companyDto;
        }


        /// <summary>
        ///  Set the transfer objects. We create the transfer object from the entity.
        /// </summary>
        /// <param name="reader">GridReader reader of dapper results</param>
        /// <param name="office">Poco to check if there is a null parameter.</param>
        private void SetDataTransferObject(SqlMapper.GridReader reader, SUBLICEN company, ref CompanyDto dto)
        {
            // think about the GridReader.

            if (reader == null)
                return;
            if (!string.IsNullOrEmpty(company.CP))
            {
                if (reader.IsConsumed)
                    return;
                Helper.CityDto = MapperUtils.GetMappedValue<POBLACIONES, CityDto>(reader.Read<POBLACIONES>().FirstOrDefault(), _mapper);
            }

            if (!string.IsNullOrEmpty(company.NACIO))
            {
                if (reader.IsConsumed)
                    return;

                Helper.CountryDto = MapperUtils.GetMappedValue<Country, CountryDto>(reader.Read<Country>().FirstOrDefault(), _mapper);
            }
            
            if (!string.IsNullOrEmpty(company.PROVINCIA))
            {
                if (reader.IsConsumed)
                    return;
                Helper.ProvinciaDto = MapperUtils.GetMappedValue<PROVINCIA, ProvinciaDto>(reader.Read<PROVINCIA>().FirstOrDefault(), _mapper);
            }
            var listOfOffices = reader.Read<OFICINAS>().ToList();
            dto.Offices =  _mapper.Map<IEnumerable<OFICINAS>, IEnumerable<OfficeDtos>>(listOfOffices);

        }
        /// <summary>
        ///  Create a local query store.
        /// </summary>
        /// <param name="company">Company data transfer object used to be inserted in the query store.</param>
        /// <returns>Return an interface of the query store.</returns>
        private IQueryStore CreateQueryStore(CompanyDto company)
        {
            IQueryStore store = _queryStoreFactory.GetQueryStore();
            store.AddParam(QueryType.QueryCity, company.City.Code);
            store.AddParam(QueryType.QueryCountry, company.Country.Code);
            store.AddParam(QueryType.QueryProvince, company.Province.Code);
            store.AddParam(QueryType.QueryOffice, company.Code);
            return store;
        }
        /// <summary>
        ///  Return the helper. The helper is used to bind auxiliar datas for the dualsearchbox.
        /// </summary>
        public IHelperData Helper
        {
            get { return _helperBase; }
            set { _helperBase = value; }
        }
    }
}
