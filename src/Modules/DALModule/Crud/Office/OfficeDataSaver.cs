using AutoMapper;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Logic;
using KarveCommonInterfaces;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using System.Transactions;
using Dapper;
using KarveDapper.Extensions;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using DataAccessLayer.SQL;
using System.Linq;
using DataAccessLayer.Crud;

namespace DataAccessLayer.Crud.Office
{
    class OfficeDataSaver : IDataSaver<OfficeDtos>
    {
        private ISqlExecutor _executor;
        private IMapper _mapper;
        private IValidationChain<ClientDto> _validationChain;
        /// <summary>
        /// Client data saver
        /// </summary>
        /// <param name="executor"></param>
        public OfficeDataSaver(ISqlExecutor executor)
        {
            _executor = executor;
            _mapper = MapperField.GetMapper();
        }
        /// <summary>
        ///  Returns the validation chain
        /// </summary>
        public IValidationChain<ClientDto> ValidationChain
        {
            set { _validationChain = value; }
            get { return _validationChain; }
        }
        /// <summary>
        ///  Save the asynchronous client
        /// </summary>
        /// <param name="office">Data transfer to be saved.</param>
        /// <returns>It returns the boolean value.</returns>
        public async Task<bool> SaveAsync(OfficeDtos office)
        {
            Contract.Assert(office != null, "Invalid Poco");
            IDbConnection connection = null;
            OFICINAS currentPoco;
            currentPoco = _mapper.Map<OfficeDtos, OFICINAS>(office);
            Contract.Assert(currentPoco != null, "Invalid Poco");
            bool retValue = false;
           
            using (connection = _executor.OpenNewDbConnection())
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        var present = connection.IsPresent<OFICINAS>(currentPoco);
                        if (!present)
                        {
                            retValue = await connection.InsertAsync<OFICINAS>(currentPoco) > 0;
                        }
                        else
                        {
                            retValue = await connection.UpdateAsync<OFICINAS>(currentPoco);
                            
                        }
                       
                        scope.Complete();
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            Contract.Ensures(connection.State == ConnectionState.Closed);
            return retValue;

        }
        /// <summary>
        ///  Save Holidays.
        /// </summary>
        /// <param name="holidayDates">Dates of the holidays</param>
        /// <returns></returns>
        private async Task<bool> SaveHolidays(IEnumerable<HolidayDto> holidayDates)
        {
            bool retValue = false;
            var value = _mapper.Map<IEnumerable<HolidayDto>,IEnumerable<FESTIVOS_OFICINA>>(holidayDates);
            var office = holidayDates.FirstOrDefault();
            if (office == null)
            {
                return retValue;
            }
           
            using (IDbConnection connection = _executor.OpenNewDbConnection())
            {
                retValue = await connection.UpdateCollectionAsync<FESTIVOS_OFICINA>(value);
            }
            return retValue;
        }
    }
}
