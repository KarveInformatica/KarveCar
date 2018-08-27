using System.Data;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Logic;
using KarveCommonInterfaces;
using KarveDapper.Extensions;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Crud.Clients
{
    /// <summary>
    /// Client data save. This class has the single responsability to save the data.
    /// </summary>
    internal sealed class ClientDataSaver : IDataSaver<ClientViewObject>
    {
        private ISqlExecutor _executor;
        private IMapper _mapper;
        private IValidationChain<ClientViewObject> _validationChain;
        /// <summary>
        /// Client data saver
        /// </summary>
        /// <param name="executor">Sql executor to be saved.</param>
        public ClientDataSaver(ISqlExecutor executor)
        {
            _executor = executor;
            _mapper = MapperField.GetMapper();
        }
        /// <summary>
        ///  Returns the validation chain
        /// </summary>
        public IValidationChain<ClientViewObject> ValidationChain
        {
            set { _validationChain = value; }
            get { return _validationChain; }
        }


        /// <summary>
        ///  Save the asynchronous client
        /// </summary>
        /// <param name="save">Data transfer to be saved</param>
        /// <returns>It returns the boolean value.</returns>
        public async Task<bool> SaveAsync(ClientViewObject save)
        {
            IDbConnection connection = null;
            ///ClientPoco currentPoco;
            if (ValidationChain != null)
            {
                if (!ValidationChain.Validate(save))
                {
                    throw new DataLayerValidationException(ValidationChain.Errors);
                }
            }

            CLIENTES1 client1 = _mapper.Map<ClientViewObject, CLIENTES1>(save);
            if (!string.IsNullOrEmpty(save.CreditCardExpiryMonth) && !string.IsNullOrEmpty(save.CreditCardExpiryYear))
            {
                client1.TARCADU = string.Format("{0}/{1}", save.CreditCardExpiryMonth, save.CreditCardExpiryYear);
            }
            CLIENTES2 client2 = _mapper.Map<ClientViewObject, CLIENTES2>(save);
            var retValue = false;
            if ((client1 == null) || (client2 == null))
            {
                return false;
            }

            using (connection = _executor.OpenNewDbConnection())
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        var present = connection.IsPresent<CLIENTES1>(client1);
                      
                        if (!present)
                        {
                            retValue = await connection.InsertAsync<CLIENTES1>(client1).ConfigureAwait(false) > 0;
                            if (retValue)
                            {
                                retValue = await connection.InsertAsync<CLIENTES2>(client2).ConfigureAwait(false) > 0;
                            }
                        }
                        else
                        {
                            retValue = await connection.UpdateAsync<CLIENTES1>(client1).ConfigureAwait(false);
                            if (retValue)
                            {
                                retValue = await connection.UpdateAsync<CLIENTES2>(client2).ConfigureAwait(false);

                                /* there is a case of lack of cohoerence, due to the split between databases,
                                 * in case of a bad importation*/
                                if (!retValue)
                                {
                                    retValue = await connection.InsertAsync<CLIENTES2>(client2).ConfigureAwait(false) > 0;
                                }
                            }
                        }
                        retValue = retValue && await SaveBranchesAsync(connection, save.BranchesDto).ConfigureAwait(false);
                        retValue = retValue && await SaveContactsAsync(connection, save.ContactsDto).ConfigureAwait(false);
                        retValue = retValue && await SaveVisitsAsync(connection, save.VisitsDto).ConfigureAwait(false);
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
        ///  Save the visit.
        /// </summary>
        /// <param name="saveVisitsDto">Visit to save</param>
        /// <returns></returns>
        private async Task<bool> SaveVisitsAsync(IDbConnection connection, IEnumerable<VisitsViewObject> saveVisitsDto)
        {
            Contract.Assert(saveVisitsDto != null, "Save contacts shall be not null");

           var retValue = false;
            if (saveVisitsDto.Count<VisitsViewObject>() == 0)
            {
                return true;
            }
            // SELECT * from Visitas;
            IEnumerable<Visitas> visitas = _mapper.Map<IEnumerable<VisitsViewObject>, IEnumerable<Visitas>>(saveVisitsDto);
            int value = await connection.InsertAsync(saveVisitsDto).ConfigureAwait(false);
            retValue = value > 0;
            return retValue;

        }
        /// <summary>
        ///  Save the contacs
        /// </summary>
        /// <param name="saveContactsDto">Contacts to be saved</param>
        /// <returns></returns>
        private async Task<bool> SaveContactsAsync(IDbConnection connection, IEnumerable<ContactsViewObject> saveContactsDto)
        {
            Contract.Assert(saveContactsDto != null, "Save contacts shall be not null");
            var retValue = false;
            IEnumerable<CliContactos> contacts = _mapper.Map<IEnumerable<ContactsViewObject>, IEnumerable<CliContactos>>(saveContactsDto);
            var entityToInsert = contacts.ToList();
            if (!entityToInsert.Any())
            {
                return true;
            }
            var value = await connection.InsertAsync(entityToInsert).ConfigureAwait(false);
            retValue = value > 0;
            return retValue;
        }
        /// <summary>
        /// Save the branches.
        /// </summary>
        /// <param name="branchesDto">List of branches</param>
        /// <returns>Return a true or a false.</returns>
        private async Task<bool> SaveBranchesAsync(IDbConnection connection, IEnumerable<BranchesViewObject> branchesDto)
        {
            Contract.Assert(connection != null, "Connection shall be not null");
            var retValue = false;
            IEnumerable<cliDelega> branches = _mapper.Map<IEnumerable<BranchesViewObject>, IEnumerable<cliDelega>>(branchesDto);
            var entityToInsert = branches.ToList();
            if (!entityToInsert.Any())
            {
                return true;
            }
            var value = await connection.InsertAsync(entityToInsert).ConfigureAwait(false);
            retValue = value > 0;
            return retValue;
        }
    }
}