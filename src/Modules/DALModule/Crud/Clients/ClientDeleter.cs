using System.Data;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using System.Linq;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Logic;
using DataAccessLayer.SQL;
using KarveDataServices;
using KarveDapper.Extensions;
using KarveDataServices.DataTransferObject;
using Z.Dapper.Plus;
using System.Collections.Generic;

namespace DataAccessLayer.Crud.Clients
{
    /// <summary>
    ///  This class has the single resposability to delete a client
    /// </summary>
    internal sealed class ClientDeleter : IDataDeleter<ClientDto>
    {
        private IMapper _mapper;
        private ISqlExecutor _executor;

        /// <summary>
        ///  Constructor for the sql deleter.
        /// </summary>
        /// <param name="executor">SqlExecutor to delete</param>
        public ClientDeleter(ISqlExecutor executor)
        {
            _mapper = MapperField.GetMapper();
            _executor = executor;
        }

        private async Task DeleteReferredTables(IDbConnection connection, ClientDto data)
        {

            var branches = _mapper.Map<IEnumerable<BranchesDto>, IEnumerable<cliDelega>>(data.BranchesDto);
            var contacts = _mapper.Map<IEnumerable<ContactsDto>, IEnumerable<CliContactos>>(data.ContactsDto);
            var visitas = _mapper.Map<IEnumerable<VisitsDto>, IEnumerable<Visitas>>(data.VisitsDto);
            await connection.BulkActionAsync(x => {
                if (branches.Count() > 0)
                {
                    x.BulkDelete(branches);
                }
                if (contacts.Count() > 0)
                {
                    x.BulkDelete(contacts);
                }
                if (visitas.Count() > 0)
                {
                    x.BulkDelete(visitas);
                }
            });
        }
        /// <summary>
        ///  This delete asynchronous data
        /// </summary>
        /// <param name="data">Client data object</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(ClientDto data)
        {
            Contract.Assert(data != null, "Invalid data transfer object");
            //var currentPoco = _mapper.Map<ClientDto, ClientPoco>(data);
            //  var code = currentPoco;
            CLIENTES1 client1 = new CLIENTES1();
            CLIENTES2 client2 = new CLIENTES2();
            client1.NUMERO_CLI = data.NUMERO_CLI;
            client2.NUMERO_CLI = data.NUMERO_CLI;
            
//            CLIENTES1 client1 = _mapper.Map<ClientPoco, CLIENTES1>(currentPoco);
 //           CLIENTES2 client2 = _mapper.Map<ClientPoco, CLIENTES2>(currentPoco);
            bool retValue = false;
            if ((client1 == null) || (client2 == null))
            {
                return false;
            }
            using (IDbConnection connection = _executor.OpenNewDbConnection())
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        retValue = await connection.DeleteAsync<CLIENTES1>(client1).ConfigureAwait(false);
                        if (retValue)
                        {
                            retValue = await connection.DeleteAsync<CLIENTES2>(client2).ConfigureAwait(false);
                        }
                        await DeleteReferredTables(connection, data);
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
