using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using AutoMapper;
using DataAccessLayer.DataObjects;
using System.Data;
using System.Transactions;
using KarveDapper.Extensions;
using System.Collections.Generic;
using DataAccessLayer.Logic;
using Z.Dapper.Plus;
using System.Linq;

namespace DataAccessLayer.Crud.Company
{
    /// <summary>
    ///  Company class to be deleted.
    /// </summary>
    internal sealed class CompanyDataDeleter : IDataDeleter<CompanyViewObject>
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
            _mapper = MapperField.GetMapper();
        }
        /// <summary>
        ///  Delete offices asynchronously.
        /// </summary>
        /// <param name="dto">Fata transfer object to delete the offices.</param>
        /// <returns>True if the action has been completed successfully</returns>
        private async Task<bool> DeleteOfficesAsync(IDbConnection connection, IEnumerable<OfficeViewObject> listOfOffices)
        {
            bool retValue = true;
            if (listOfOffices.Count() > 0)
            {
                IEnumerable<OFICINAS> offices = _mapper.Map<IEnumerable<OfficeViewObject>, IEnumerable<OFICINAS>>(listOfOffices);
                retValue = false;

                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    retValue = await connection.DeleteCollectionAsync<OFICINAS>(offices).ConfigureAwait(false);
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
        public async Task<bool> DeleteAsync(CompanyViewObject data)
        {
            bool retValue = false;

            SUBLICEN value = _mapper.Map<CompanyViewObject, SUBLICEN>(data);
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    retValue = await connection.DeleteAsync<SUBLICEN>(value);
                    retValue = retValue && await DeleteOfficesAsync(connection, data.Offices).ConfigureAwait(false);
                    scope.Complete();
                }

            }

            return retValue;
        }
    }
}
