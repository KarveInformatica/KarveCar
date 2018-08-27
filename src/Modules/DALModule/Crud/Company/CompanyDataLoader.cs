using KarveDataServices;
using KarveDataServices.ViewObjects;
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
using System;
using System.Collections.ObjectModel;

namespace DataAccessLayer.Crud.Company
{
    /// <summary>
    ///  Company loader
    /// </summary>
    internal sealed class CompanyDataLoader : IDataLoader<CompanyViewObject>
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
        public async Task<IEnumerable<CompanyViewObject>> LoadAsyncAll()
        {
            IEnumerable<CompanyViewObject> companyDto = new List<CompanyViewObject>();
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                var value =  await connection.GetAllAsync<SUBLICEN>();
                companyDto = _mapper.Map<IEnumerable<SUBLICEN>, IEnumerable<CompanyViewObject>>(value);
            }
            return companyDto;
        }

        /// <summary>
        ///  Load just a company with a code primary key value
        /// </summary>
        /// <param name="code">Identifier of the company</param>
        /// <returns>The company data transfer object.</returns>
        public async Task<CompanyViewObject> LoadValueAsync(string code)
        {
            var companyDto = new CompanyViewObject();
            using (var connection = _sqlExecutor.OpenNewDbConnection())
            {
                var value = await connection.GetAsync<SUBLICEN>(code);
                if (value == null)
                {
                    companyDto.IsValid = false;
                    return companyDto;
                }
                companyDto = _mapper.Map<SUBLICEN, CompanyViewObject>(value);
                
                var store = CreateQueryStore(companyDto);
                var multipleQuery = store.BuildQuery();
                var reader = await connection.QueryMultipleAsync(multipleQuery);

                var city = SelectionHelpers.WrappedSelectedDto<POBLACIONES, CityViewObject>(value.POBLACION, _mapper, reader);

                var province = SelectionHelpers.WrappedSelectedDto<PROVINCIA, ProvinceViewObject>(value.PROVINCIA, _mapper, reader);
                companyDto.Offices = SelectionHelpers.WrappedSelectedDto<OFICINAS, OfficeViewObject>(value.CODIGO, _mapper, reader);
                companyDto.City = city.FirstOrDefault();
                companyDto.Province = province.FirstOrDefault();

            }
            return companyDto;
        }
  
        /// <summary>
        /// Load at most N async values.
        /// </summary>
        /// <param name="n">Number of values from the current position to be loaded</param>
        /// <param name="back">offset, it can be positive or negative</param>
        /// <returns></returns>
        public async Task<IEnumerable<CompanyViewObject>> LoadValueAtMostAsync(int n, int back = 0)
        {

            IEnumerable<CompanyViewObject> companyDto = new List<CompanyViewObject>();
            IQueryStore store = _queryStoreFactory.GetQueryStore();
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                store.AddParamRange(QueryType.QueryCompanyPaged, _currentPos, n);
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
        private void SetDataTransferObject(SqlMapper.GridReader reader, SUBLICEN company, ref CompanyViewObject viewObject)
        {
            // think about the GridReader.

            if (reader == null)
                return;
            if (!string.IsNullOrEmpty(company.CP))
            {
                if (reader.IsConsumed)
                    return;
                Helper.CityDto = MapperUtils.GetMappedValue<POBLACIONES, CityViewObject>(reader.Read<POBLACIONES>().FirstOrDefault(), _mapper);
            }

            if (!string.IsNullOrEmpty(company.NACIO))
            {
                if (reader.IsConsumed)
                    return;

                Helper.CountryDto = MapperUtils.GetMappedValue<Country, CountryViewObject>(reader.Read<Country>().FirstOrDefault(), _mapper);
            }
            
            if (!string.IsNullOrEmpty(company.PROVINCIA))
            {
                if (reader.IsConsumed)
                    return;
                Helper.ProvinciaDto = MapperUtils.GetMappedValue<PROVINCIA, ProvinceViewObject>(reader.Read<PROVINCIA>().FirstOrDefault(), _mapper);
            }
            var listOfOffices = reader.Read<OFICINAS>().ToList();
            viewObject.Offices =  _mapper.Map<IEnumerable<OFICINAS>, IEnumerable<OfficeViewObject>>(listOfOffices);

        }
        /// <summary>
        ///  Create a local query store.
        /// </summary>
        /// <param name="company">Company data transfer object used to be inserted in the query store.</param>
        /// <returns>Return an interface of the query store.</returns>
        private IQueryStore CreateQueryStore(CompanyViewObject company)
        {
            IQueryStore store = _queryStoreFactory.GetQueryStore();
            store.Clear();
            store.AddParamCount(QueryType.QueryCity, company.CP);
            store.AddParamCount(QueryType.QueryProvince, company.PROVINCIA);
            store.AddParamCount(QueryType.QueryCompanyOffices, company.Code);
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
