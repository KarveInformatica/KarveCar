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
        private readonly ISqlExecutor _executor;
        private readonly IMapper _mapper;
        private readonly QueryStoreFactory _queryStoreFactory;
        private IValidationChain<ClientDto> _validationChain;
        /// <summary>
        /// Client data saver
        /// </summary>
        /// <param name="executor">Sql command executor</param>
        public OfficeDataSaver(ISqlExecutor executor, IMapper mapper)
        {
            _executor = executor;
            /// FIXME: violate the law of demter.
            _mapper = mapper;
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
                var currentHolidays = await connection.QueryAsync<FESTIVOS_OFICINA>(query);
                var festivosOficinas = currentHolidays as FESTIVOS_OFICINA[] ?? currentHolidays.ToArray();
                if (!festivosOficinas.Any())
                {
                    saved = await connection.InsertAsync(holidayOffice).ConfigureAwait(false) > 0;
                        
                }
                else
                {
                    // FIXME : check for concurrent optimistic lock.               
                    var enumerable = holidayOffice as FESTIVOS_OFICINA[] ?? holidayOffice.ToArray();
                    var holidaysToBeInserted = enumerable.Except(festivosOficinas);
                    saved =  await connection.InsertAsync(holidaysToBeInserted).ConfigureAwait(false)>0;
                    var holidaysToBeUpdated = enumerable.Intersect(festivosOficinas);
                    saved = saved && await connection.UpdateAsync(holidaysToBeUpdated).ConfigureAwait(false);
                }
                
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
            var currentPoco = _mapper.Map<OfficeDtos, OFICINAS>(office);
            Contract.Assert(currentPoco != null, "Invalid Poco");
            var retValue = false;
          
            
            using (connection = _executor.OpenNewDbConnection())
            {
                try
                {
                    using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
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

                            if (retValue)
                            {
                               await SaveHolidayOfficeAsync(connection, currentPoco, office.HolidayDates).ConfigureAwait(false);
                            }
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
