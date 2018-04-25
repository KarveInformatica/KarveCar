using AutoMapper;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Logic;
using KarveCommonInterfaces;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using System.Transactions;
using System;
using Dapper;
using KarveDapper.Extensions;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using DataAccessLayer.SQL;
using System.Linq;
using DataAccessLayer.Crud;
using Z.BulkOperations;
using Z.Dapper.Plus;

namespace DataAccessLayer.Crud.Office
{
    /// <summary>
    ///  This is an office data saver. It saves the data for the office table.
    /// </summary>
    class OfficeDataSaver : IDataSaver<OfficeDtos>
    {
        private ISqlExecutor _executor;
        private IMapper _mapper;
        private QueryStoreFactory _queryStoreFactory;
        private IValidationChain<ClientDto> _validationChain;
        /// <summary>
        /// Client data saver
        /// </summary>
        /// <param name="executor">Sql command executor</param>
        public OfficeDataSaver(ISqlExecutor executor)
        {
            _executor = executor;
            /// FIXME: violate the law of demter.
            _mapper = MapperField.GetMapper();
            _queryStoreFactory = new QueryStoreFactory();
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
        ///  This saves the holiday in the office.
        /// </summary>
        /// <param name="currentOffice">Current office to be saved.</param>
        /// <param name="holidayDto">List of vacation for the current office.</param>
        /// <returns>return a task for saving the holidays</returns>
        private async Task SaveHolidayOfficeAsync(IDbConnection connection, OFICINAS currentOffice, IEnumerable<HolidayDto> holidayDto)
        {
            Contract.Requires(connection != null, "Connection is not null");
            Contract.Requires(currentOffice != null, "Current office is not null");
            Contract.Requires(holidayDto != null, "HolidayDto is not null");

            IEnumerable<FESTIVOS_OFICINA> holidayOffice = _mapper.Map<IEnumerable<HolidayDto>, IEnumerable<FESTIVOS_OFICINA>>(holidayDto);
            IQueryStore store = _queryStoreFactory.GetQueryStore();
            store.AddParam(QueryType.HolidaysByOffice, currentOffice.CODIGO);
            var query = store.BuildQuery();
            bool saved = false;
            // First i want fetch the current festivo oficina.
            // we shall insert or merge.
            try
            {
                IEnumerable<FESTIVOS_OFICINA> currentHolidays = await connection.QueryAsync<FESTIVOS_OFICINA>(query);
                if (currentHolidays.Count<FESTIVOS_OFICINA>() == 0)
                {
                    connection.BulkInsert(holidayOffice);
                }
                else
                {
                    // FIXME : check for concurrent optimistic lock.               
                    var holidaysToBeInserted = holidayOffice.Except(currentHolidays);
                    connection.BulkInsert<FESTIVOS_OFICINA>(holidaysToBeInserted);
                    var holidaysToBeUpdated = holidayOffice.Intersect(currentHolidays);
                    connection.BulkUpdate<FESTIVOS_OFICINA>(holidaysToBeUpdated);
                }
                saved = true;
            }
            catch (System.Exception e)
            {
                connection.Close();
                connection.Dispose();
                throw new DataLayerException(e.Message, e);
            }
            Contract.Ensures(saved);
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
                        try
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
                            await SaveHolidayOfficeAsync(connection, currentPoco, office.HolidayDates);
                            scope.Complete();
                        } catch (System.Exception e )
                        {
                            throw new DataLayerException(e.Message, e);
                        }
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

    }
}
