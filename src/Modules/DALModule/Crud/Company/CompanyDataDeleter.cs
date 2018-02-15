using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using AutoMapper;
using DataAccessLayer.DataObjects;
using System.Data;
using System.Transactions;
using KarveDapper.Extensions;
using System.Collections.Generic;

namespace DataAccessLayer.Crud.Company
{
    /// <summary>
    ///  Company class to be deleted.
    /// </summary>
    internal sealed class CompanyDataDeleter : IDataDeleter<CompanyDto>
    {
        private ISqlExecutor _sqlExecutor;
        private IMapper _mapper;
        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="executor"></param>
        public CompanyDataDeleter(ISqlExecutor executor)
        {
            _sqlExecutor = executor;
        }
        /// <summary>
        ///  Delete offices asynchronously.
        /// </summary>
        /// <param name="dto">Fata transfer object to delete the offices.</param>
        /// <returns>True if the action has been completed successfully</returns>
        private async Task<bool> DeleteOfficesAsync(IEnumerable<OfficeDtos> listOfOffices)
        {
            IEnumerable<OFICINAS> offices = _mapper.Map<IEnumerable<OfficeDtos>, IEnumerable<OFICINAS>>(listOfOffices);
            bool retValue = false;

            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {

                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    retValue = await connection.DeleteCollectionAsync<OFICINAS>(offices);
                    scope.Complete();
                }
            }
            return retValue;
        }
        /// <summary>
        ///  Delete asynchronous data.
        /// </summary>
        /// <param name="data">Company data to be deleted.</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(CompanyDto data)
        {
            bool retValue = false;
            SUBLICEN value = _mapper.Map<CompanyDto, SUBLICEN>(data);
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    retValue = await connection.DeleteAsync<SUBLICEN>(value);
                    retValue = retValue && await DeleteOfficesAsync(data.Offices);
                    scope.Complete();
                }

            }
            return retValue;
        }
    }
}
