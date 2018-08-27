using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using System.Data;
using System.Diagnostics.Contracts;
using DataAccessLayer.DataObjects;
using AutoMapper;
using System.Transactions;
using Dapper;
using KarveDapper.Extensions;
using DataAccessLayer.Logic;
using DataAccessLayer.SQL;

namespace DataAccessLayer.Crud.Office
{
    /// <summary>
    /// Office data deleter. This object has the single responsabilty to deletes an office.
    /// </summary>
    internal sealed class OfficeDataDeleter: IDataDeleter<OfficeViewObject>
    {
        private readonly ISqlExecutor _executor;
        private readonly IMapper _mapper;

        /// <summary>
        ///  constructor
        /// </summary>
        /// <param name="executor">Query executor for lower level</param>
        /// <param name="mapper">Automapper instance for mapping the entities to data transfer object</param>
        public OfficeDataDeleter(ISqlExecutor executor, IMapper mapper)
        {
            _executor = executor;
            _mapper = mapper;
        }
        /// <summary>
        ///  Delete an office 
        /// </summary>
        /// <param name="data">Data transfer object to be used for deleting an object</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(OfficeViewObject data)
        {
            Contract.Assert(data != null, "Invalid data transfer object");
            var currentPoco = _mapper.Map<OfficeViewObject, OFICINAS>(data);
            var retValue = false;
            using (var connection = _executor.OpenNewDbConnection())
            {
                try
                {
                    using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        retValue = await connection.DeleteAsync<OFICINAS>(currentPoco);
                        if ((retValue) && (data.HolidayDates.Any()))
                        {
                            QueryStore store = QueryStore.GetInstance();
                            store.AddParam(QueryType.HolidaysOfficeDelete, currentPoco.CODIGO);
                            var q = store.BuildQuery();
                            var execQuery = await connection.ExecuteAsync(q);
                            
                            //var connection = await connection.DeleteAsync();
                            // now we can delete the associated holidays.
                            //var holidays=_mapper.Map<IEnumerable<HolidayViewObject>, IEnumerable<FESTIVOS_OFICINA>>(data.HolidayDates);
                            // retValue = await connection.DeleteAsync(holidays);
                        }
                        scope.Complete();
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            return retValue;

            
        }
    }
}
