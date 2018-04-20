using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using System.Data;
using System.Diagnostics.Contracts;
using DataAccessLayer.DataObjects;
using AutoMapper;
using System.Transactions;
using KarveDapper.Extensions;
using DataAccessLayer.Logic;

namespace DataAccessLayer.Crud.Office
{
    /// <summary>
    /// Office data deleter. This object has the single responsabilty to deletes an office.
    /// </summary>
    internal sealed class OfficeDataDeleter: IDataDeleter<OfficeDtos>
    {
        private ISqlExecutor _executor;
        private IMapper _mapper;

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
        public async Task<bool> DeleteAsync(OfficeDtos data)
        {
            Contract.Assert(data != null, "Invalid data transfer object");
            var currentPoco = _mapper.Map<OfficeDtos, OFICINAS>(data);
            bool retValue = false;
            using (IDbConnection connection = _executor.OpenNewDbConnection())
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        retValue = await connection.DeleteAsync<OFICINAS>(currentPoco);
                        if ((retValue) && (data.HolidayDates.Count<HolidayDto>()>0))
                        {
                            // now we can delete the associated holidays.
                            var holidays=_mapper.Map<IEnumerable<HolidayDto>, IEnumerable<FESTIVOS_OFICINA>>(data.HolidayDates);
                            retValue = await connection.DeleteAsync(holidays);
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
