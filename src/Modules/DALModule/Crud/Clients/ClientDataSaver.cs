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
using KarveDataServices.DataTransferObject;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Crud.Clients
{
    /// <summary>
    /// Client data save. This class has the single responsability to save the data.
    /// </summary>
    internal sealed class ClientDataSaver : IDataSaver<ClientDto>
    {
        private ISqlExecutor _executor;
        private IMapper _mapper;
        private IValidationChain<ClientDto> _validationChain;
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
        public IValidationChain<ClientDto> ValidationChain
        {
            set { _validationChain = value; }
            get { return _validationChain; }
        }


        /// <summary>
        ///  Save the asynchronous client
        /// </summary>
        /// <param name="save">Data transfer to be saved</param>
        /// <returns>It returns the boolean value.</returns>
        public async Task<bool> SaveAsync(ClientDto save)
        {
            IDbConnection connection = null;
            ///ClientPoco currentPoco;
            if (ValidationChain != null)
            {
                if (!ValidationChain.Validate(save))
                {
                    throw new DataLayerInvalidClientException(ValidationChain.Errors);
                }
            }
        
            CLIENTES1 client1 = _mapper.Map<ClientDto, CLIENTES1>(save);
            CLIENTES2 client2 = _mapper.Map<ClientDto, CLIENTES2>(save);
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
                            retValue = await connection.InsertAsync<CLIENTES1>(client1) > 0;
                            if (retValue)
                            {
                                retValue = await connection.InsertAsync<CLIENTES2>(client2) > 0;
                            }
                        }
                        else
                        {
                            retValue = await connection.UpdateAsync<CLIENTES1>(client1);
                            if (retValue)
                            {
                                retValue = await connection.UpdateAsync<CLIENTES2>(client2);

                                /* there is a case of lack of cohoerence, due to the split between databases,
                                 * in case of a bad importation*/
                                if (!retValue)
                                {
                                    retValue = await connection.InsertAsync<CLIENTES2>(client2) > 0;
                                }
                            }
                        }
                        retValue = retValue && await SaveBranchesAsync(connection, save.BranchesDto);
                        retValue = retValue && await SaveContactsAsync(connection, save.ContactsDto);
                        retValue = retValue && await SaveVisitsAsync(connection, save.VisitsDto);
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
        private async Task<bool> SaveVisitsAsync(IDbConnection connection, IEnumerable<VisitsDto> saveVisitsDto)
        {
            Contract.Assert(saveVisitsDto != null, "Save contacts shall be not null");

            bool retValue = false;
            if (saveVisitsDto.Count<VisitsDto>() == 0)
            {
                return true;
            }
            // SELECT * from Visitas;
            IEnumerable<Visitas> visitas = _mapper.Map<IEnumerable<VisitsDto>, IEnumerable<Visitas>>(saveVisitsDto);
            int value = await connection.InsertAsync(saveVisitsDto);
            retValue = value > 0;
            return retValue;

        }
        /// <summary>
        ///  Save the contacs
        /// </summary>
        /// <param name="saveContactsDto">Contacts to be saved</param>
        /// <returns></returns>
        private async Task<bool> SaveContactsAsync(IDbConnection connection, IEnumerable<ContactsDto> saveContactsDto)
        {
            Contract.Assert(saveContactsDto != null, "Save contacts shall be not null");
            var retValue = false;
            IEnumerable<CliContactos> contacts = _mapper.Map<IEnumerable<ContactsDto>, IEnumerable<CliContactos>>(saveContactsDto);
            var entityToInsert = contacts.ToList();
            if (!entityToInsert.Any())
            {
                return true;
            }
            var value = await connection.InsertAsync(entityToInsert);
            retValue = value > 0;
            return retValue;
        }
        /// <summary>
        /// Save the branches.
        /// </summary>
        /// <param name="branchesDto">List of branches</param>
        /// <returns>Return a true or a false.</returns>
        private async Task<bool> SaveBranchesAsync(IDbConnection connection, IEnumerable<BranchesDto> branchesDto)
        {
            Contract.Assert(connection != null, "Connection shall be not null");
            var retValue = false;
            IEnumerable<cliDelega> branches = _mapper.Map<IEnumerable<BranchesDto>, IEnumerable<cliDelega>>(branchesDto);
            var entityToInsert = branches.ToList();
            if (!entityToInsert.Any())
            {
                return true;
            }
           
            var value = await connection.InsertAsync(entityToInsert);
            retValue = value > 0;
            return retValue;
        }
    }
}