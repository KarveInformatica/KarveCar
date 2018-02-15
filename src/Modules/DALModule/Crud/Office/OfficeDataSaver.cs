using AutoMapper;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Crud.Office
{
    class OfficeDataSaver: IDataSaver<OfficeDtos>
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
    /// <param name="save">Data transfer to be saved</param>
    /// <returns>It returns the boolean value.</returns>
    public async Task<bool> SaveAsync(ClientDto save)
    {
        IDbConnection connection = null;
        ClientPoco currentPoco;
        if (!ValidationChain.Validate(save))
        {
            throw new DataLayerInvalidClientException(ValidationChain.Errors);
        }
        currentPoco = _mapper.Map<ClientDto, ClientPoco>(save);
        Contract.Assert(currentPoco != null, "Invalid Poco");
        CLIENTES1 client1 = _mapper.Map<ClientPoco, CLIENTES1>(currentPoco);
        CLIENTES2 client2 = _mapper.Map<ClientPoco, CLIENTES2>(currentPoco);
        bool retValue = false;
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
                        }
                    }
                    retValue = retValue && await SaveBranchesAsync(save.BranchesDto);
                    retValue = retValue && await SaveContactsAsync(save.ContactsDto);
                    retValue = retValue && await SaveVisitsAsync(save.VisitsDto);
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
    /// <param name="saveVisitsDto"></param>
    /// <returns></returns>
    private async Task<bool> SaveVisitsAsync(IEnumerable<VisitsDto> saveVisitsDto)
    {
        bool retValue = false;
        // SELECT * from Visitas;
        IEnumerable<Visitas> visitas = _mapper.Map<IEnumerable<VisitsDto>, IEnumerable<Visitas>>(saveVisitsDto);
        using (IDbConnection connection = _executor.OpenNewDbConnection())
        {
            int value = await connection.InsertAsync(saveVisitsDto);
            retValue = value > 0;
        }
        return retValue;

    }
    /// <summary>
    ///  Save the contacs
    /// </summary>
    /// <param name="saveContactsDto"></param>
    /// <returns></returns>
    private async Task<bool> SaveContactsAsync(IEnumerable<ContactsDto> saveContactsDto)
    {
        bool retValue = false;
        IEnumerable<CliContactos> contacts = _mapper.Map<IEnumerable<ContactsDto>, IEnumerable<CliContactos>>(saveContactsDto);
        using (IDbConnection connection = _executor.OpenNewDbConnection())
        {
            int value = await connection.InsertAsync(saveContactsDto);
            retValue = value > 0;
        }
        return retValue;

    }
    /// <summary>
    /// Save the branches.
    /// </summary>
    /// <param name="branchesDto"></param>
    /// <returns></returns>
    private async Task<bool> SaveBranchesAsync(IEnumerable<BranchesDto> branchesDto)
    {
        bool retValue = false;
        IEnumerable<cliDelega> branches = _mapper.Map<IEnumerable<BranchesDto>, IEnumerable<cliDelega>>(branchesDto);
        using (IDbConnection connection = _executor.OpenNewDbConnection())
        {
            int value = await connection.InsertAsync(branches);
            retValue = value > 0;
        }
        return retValue;
    }

        public Task<bool> SaveAsync(OfficeDtos save)
        {
            throw new NotImplementedException();
        }
    }
