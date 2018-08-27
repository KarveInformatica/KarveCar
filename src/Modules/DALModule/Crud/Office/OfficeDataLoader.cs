using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using DataAccessLayer.SQL;
using KarveDataServices.ViewObjects;
using KarveDataServices;
using System.Data;
using KarveDapper.Extensions;
using AutoMapper;
using Dapper;

using System.Diagnostics.Contracts;
using System;

namespace DataAccessLayer.Crud.Office
{

    /// <summary>
    ///  Loader of the data 
    /// </summary>
    public class OfficeDataLoader: IDataLoader<OfficeViewObject> 
    {
        private readonly ISqlExecutor _executor;
        private readonly IMapper _mapper;
        private long _currentPos;
        private readonly QueryStoreFactory _queryStoreFactory;
        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="executor">Executor</param>
        public OfficeDataLoader(ISqlExecutor executor, IMapper mapper)
        {
            _executor = executor;
            _mapper = mapper;
            _queryStoreFactory = new QueryStoreFactory();
        }
        /// <summary>
        /// Load asynchronously a list of offices.
        /// </summary>
        /// <returns>A list of offcies</returns>
        public async Task<IEnumerable<OfficeViewObject>> LoadAsyncAll()
        {
            IEnumerable<OfficeViewObject> officeDtos = new List<OfficeViewObject>();
            using (IDbConnection connection = _executor.OpenNewDbConnection())
            {
                var value = await connection.GetAllAsync<OFICINAS>();
                officeDtos = _mapper.Map<IEnumerable<OFICINAS>, IEnumerable<OfficeViewObject>>(value);
               
           
            }
            return officeDtos;
        }


        /// <summary>
        ///  Parse the result of an office multiple query
        /// </summary>
        /// <param name="request"></param>
        /// <param name="reader"></param>
        /// <returns></returns>
       
        private bool ParseResult(OfficeViewObject request, OFICINAS  value, SqlMapper.GridReader reader)
        {

            if ((request == null) || (reader == null))
            {
                return false;
            }
            if (request.Value == null)
            {
                return false;
            }
            try
            {
                request.City = SelectionHelpers.WrappedSelectedDto<POBLACIONES, CityViewObject>(value.CP, _mapper, reader);
                request.Province = SelectionHelpers.WrappedSelectedDto<PROVINCIA, ProvinceViewObject>(value.PROVINCIA, _mapper, reader);
                request.Currencies = SelectionHelpers.WrappedSelectedDto<CURRENCIES, CurrenciesViewObject>(value.CURRENCY_OFI, _mapper, reader);
                request.HolidayDates= SelectionHelpers.WrappedSelectedDto<FESTIVOS_OFICINA, HolidayViewObject>(value.CODIGO, _mapper, reader);
                request.DelegaContable = SelectionHelpers.WrappedSelectedDto<DELEGA, DelegaContableViewObject>(value.DEPARTA, _mapper, reader);
                request.Country = SelectionHelpers.WrappedSelectedDto<Country, CountryViewObject>(value.PAIS, _mapper, reader);
                request.OfficeZone = SelectionHelpers.WrappedSelectedDto<ZONAOFI, ZonaOfiViewObject>(value.ZONAOFI, _mapper, reader);
#pragma warning disable CS0168 // Variable is declared but never used
            }
            catch (System.Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                return false;
            }
            return true;
        }

        private async Task<OfficeViewObject> LoadAuxAsync(IDbConnection connection,
                                                    OfficeViewObject officeViewObject, OFICINAS value)

        {

            if ((officeViewObject == null) || (value == null) || (connection == null))
            {
                throw new ArgumentNullException("Invalid input during load!");                 
            }
            var auxQueryStore = _queryStoreFactory.GetQueryStore();
            auxQueryStore.AddParamCount(QueryType.QueryCity, value.CP);
            auxQueryStore.AddParamCount(QueryType.QueryProvince, value.PROVINCIA);
            auxQueryStore.AddParamCount(QueryType.QueryCurrencyValue, value.CURRENCY_OFI);
            auxQueryStore.AddParamCount(QueryType.HolidaysByOffice, value.CODIGO);
            auxQueryStore.AddParamCount(QueryType.QueryDeptContable, value.DEPARTA);
            auxQueryStore.AddParamCount(QueryType.QueryCountry, value.PAIS);
            auxQueryStore.AddParamCount(QueryType.QueryOfficeZone, value.ZONAOFI);
            var query = auxQueryStore.BuildQuery();
            var multipleResult = await connection.QueryMultipleAsync(query).ConfigureAwait(false);
            officeViewObject.IsValid = ParseResult(officeViewObject,value, multipleResult);
            return officeViewObject;
        }

        // <summary>
        /// Load asynchronous values.
        /// </summary>
        /// <param name="code">Code to be used</param>
        /// <returns>An office data transfer object</returns>
        public async Task<OfficeViewObject> LoadValueAsync(string code)
        {

            Contract.Requires(condition: !string.IsNullOrEmpty(code));
            OfficeViewObject officeViewObject = new OfficeViewObject();
         
            using (var connection = _executor.OpenNewDbConnection())
            {
                var value = await connection.GetAsync<OFICINAS>(code).ConfigureAwait(false);
                if (value == null)
                {
                    officeViewObject.IsValid = false;
                    return officeViewObject;
                }
                officeViewObject = _mapper.Map<OFICINAS, OfficeViewObject>(value);
                officeViewObject = await LoadAuxAsync(connection, officeViewObject, value).ConfigureAwait(false);
                officeViewObject.IsValid = true;
            }
            return officeViewObject;
        }

        public async Task<IEnumerable<OfficeViewObject>> LoadValueAtMostAsync(int n, int back = 0)
        {
            IEnumerable<OfficeViewObject> officeDtos;
            IQueryStore store = _queryStoreFactory.GetQueryStore();
            if (_currentPos <= 0)
            {
                _currentPos = 1;
            }
            using (IDbConnection connection = _executor.OpenNewDbConnection())
            {
                store.AddParam<int, long>(QueryType.QueryOfficePaged,  n, _currentPos);
                _currentPos += n - back;
                var query = store.BuildQuery();
                var value = await connection.QueryAsync<OFICINAS>(query);
                officeDtos = _mapper.Map<IEnumerable<OFICINAS>, IEnumerable<OfficeViewObject>>(value);
            }
            return officeDtos;
            
        }
    }

}