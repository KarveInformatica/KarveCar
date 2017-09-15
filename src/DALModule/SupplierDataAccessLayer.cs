?using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataObjects;
using DataAccessLayer.DataObjects;
using Apache.Ibatis.DataMapper;
using Apache.Ibatis.DataMapper.MappedStatements;
using System.Reflection;
using EnvConfig = KarveCommon.Generic.EnvironmentConfig;
using System.Collections.Generic;
using System.Security.Cryptography;
using Apache.Ibatis.DataMapper.Session;

namespace DataAccessLayer
{

    class SupplierDataAccessLayer : ISupplierDataServices
    {
        private IDataMapper _dataMapper;
        private IKarveDataMapper _mapper;
        private IConfigurationService _service;
        private ISession _session;
        public SupplierDataAccessLayer(IKarveDataMapper mapper, IConfigurationService service)
        {
            this._mapper = mapper;
            this._dataMapper = mapper.DataMapper;
            this._service = service;

        }
        #region ISupplierDataService Interface

        /// <summary>
        /// This method returns a table of the join between PROVEE1 and PROVEE2 
        /// </summary>
        /// <returns>It returns a dataset containing the complete summary.</returns>
        public async Task<DataSet> GetAsyncCompleteSummary()
        {
            DataSet dataSet = new DataSet("FullSupplierDataSet");
            DataTable supplierTable;
            supplierTable = await _dataMapper.QueryAsyncForDataTable("Suppliers.GetFullSuppliersSummary", null).ConfigureAwait(false);
            dataSet.Tables.Add(supplierTable);
            return dataSet;
        }
        /// <summary>
        /// Returns look for the Number, Nif, and brief summary of the supplier.
        /// </summary>
        /// <returns>A data set containing a Number, Nif, and summary</returns>
        public async Task<DataSet> GetAsyncAllSupplierSummary()
        {
            DataSet dataSet = new DataSet("SupplierDataSet");
            DataTable supplierTable;
            supplierTable = await _dataMapper.QueryAsyncForDataTable("Suppliers.GetAllSuppliersSummary", null).ConfigureAwait(false);
            dataSet.Tables.Add(supplierTable);
            return dataSet;
        }
        /// <summary>
        ///  This method returns all providers types 
        /// </summary>
        /// <returns></returns>
        public async Task<DataSet> GetAsyncAllProviderTypes()
        {
            DataSet dataSet = new DataSet("SuppliersTypesDataSet");
            DataTable supplierTable;
            supplierTable = await _dataMapper.QueryAsyncForDataTable("Suppliers.GetSupplierTypes", null).ConfigureAwait(false);
            dataSet.Tables.Add(supplierTable);
            return dataSet;
        }
        /// <summary>
        /// Get the type of the supplier (TIPOCOMP) given the code
        /// </summary>
        /// <param name="supplierCode">code of the supplier</param>
        /// <returns></returns>
        public async Task<DataSet> GetAsyncProviderType(string supplierCode)
        {
            DataSet dataSet = new DataSet("SupplierType");
            DataTable supplierTable = await _dataMapper.QueryAsyncForDataTable("Supplier.GetSupplierType", supplierCode);
            if (supplierTable != null)
            {
                dataSet.Tables.Add(supplierTable);
            }
           return dataSet;
        }
        /// <summary>
        /// Return the dataset of the delegations given a supplier.
        /// </summary>
        /// <param name="supplierCode">code of the supplier</param>
        /// <returns></returns>
        public async Task<DataSet> GetAsyncDelegations(string supplierCode)
        {
            DataSet set = new DataSet("SupplierDelegations");
            DataTable delegation = new DataTable();
            delegation = await _dataMapper.QueryAsyncForDataTableSession("Suppliers.GetSupplierDelegationByClient", supplierCode, _dataMapper.Session);
            if (delegation != null)
            {
                set.Tables.Add(delegation);
            }
            return set;
        }
        /// <summary>
        /// Get the visits from the supplier.
        /// </summary>
        /// <param name="clientCode">code of the supplier</param>
        /// <returns></returns>
        public async Task<DataSet> GetAsyncVisits(string clientCode)
        {
            DataSet set = new DataSet("SupplierVisit");
            DataTable visits = await _dataMapper.QueryAsyncForDataTableSession("Suppliers.GetSupplierVisits", clientCode, _dataMapper.Session);
            if (visits != null)
            {
                set.Tables.Add(visits);
            }
            return set;
        }
        ///  Get the evaluation note.
        /// </summary>
        /// <param name="evCode"> Get the evalutaion node foreach supplier</param>
        /// <returns></returns>
        public async Task<DataSet> GetAsyncEvaluationNote(string evCode)
        {
            DataSet set = new DataSet("EvaluationNote");
            DataTable note = await _dataMapper.QueryAsyncForDataTable("Suppliers.LoadEvaluationNote", evCode);
            if (note != null)
            {
                set.Tables.Add(note);
            }
            return set;

        }
        /// <summary>
        /// Retrieve the supplier data object info for the general summary.
        /// </summary>
        /// <param name="id">Identifier of the provider</param>
        /// <returns>A supplier data object info for the the UI, which contains all the info for the general</returns>
        public async Task<ISupplierDataInfo> GetAsyncSupplierDataObjectInfo(string id)
        {
            ISupplierDataInfo dataObject = new SupplierInfoDataObject();
            if (id != String.Empty)
            {

                IMapperCommand mapper1 = new QueryAsyncForObjectCommand<ISupplierDataInfo>("Suppliers.GetSupplierInfos", id);
                IMapperCommand mapper2 = new QueryAsyncForDataTableCommand("Suppliers.GetProvinceForEachSupplier", null);


                _dataMapper.AddBatch(mapper1);
                _dataMapper.AddBatch(mapper2);

                DataTable provinceDataCode = null;
                DataSet resultBatch = await _dataMapper.ExecuteAsyncBatch().ConfigureAwait(false);
                for (int i = 0; i < resultBatch.Tables.Count; ++i)
                {
                    string tableName = resultBatch.Tables[i].TableName;

                    if (tableName.Contains("SupplierInfo"))
                    {
                        SetDataObjectFields(resultBatch.Tables[i].Rows[0], ref dataObject);
                    }
                    if (tableName.Contains("Province"))
                    {
                        provinceDataCode = resultBatch.Tables[i];
                    }
                }
                if (provinceDataCode != null)
                {
                    EnumerableRowCollection<DataRow> dataRows = provinceDataCode.AsEnumerable().Where(r => r.Field<string>("ProvinceCode") == dataObject.ProvinceCode);
                    foreach (DataRow dr in dataRows)
                    {
                        string provinceValue = (string)dr["Province"];
                        if (provinceValue.Length > 0)
                            dataObject.Province = provinceValue;
                        break;
                    }
                    string code = dataObject.CountryCode;
                    if (code != null)
                    {
                        IMapperCommand mapper3 = new QueryAsyncForDataTableCommand("Suppliers.GetCountryForSingleSupplier", code);
                        _dataMapper.AddBatch(mapper3);
                        resultBatch = await _dataMapper.ExecuteAsyncBatch().ConfigureAwait(false);
                        if (resultBatch.Tables.Count > 0)
                        {
                            DataTable countryDataCode = resultBatch.Tables[0];
                            dataRows = countryDataCode.AsEnumerable().Where(r => r.Field<string>("CountryCode") == dataObject.CountryCode);
                            foreach (DataRow dr in dataRows)
                            {
                                string countryValue = dr["Name"] as string;
                                if (countryValue.Length > 0)
                                    dataObject.Country = countryValue;
                                break;
                            }
                        }
                    }
                }


            }
            return dataObject;
        }
        /// <summary>
        /// This return the types of supplier given its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ISupplierTypeData> GetAsyncSupplierTypesDataObject(string id)
        {
            IMapperCommand mapperSupplierTypes = new QueryAsyncForObjectCommand<ISupplierTypeData>("Suppliers.GetSupplierTypeById", id);
            _dataMapper.AddBatch(mapperSupplierTypes);
            DataSet supplierTypesDataSet = await _dataMapper.ExecuteAsyncBatch().ConfigureAwait(false);
            ISupplierTypeData dataObjectType = new SupplierTypeDataObject();
            // we need at least a result
            if (supplierTypesDataSet.Tables.Count == 1)
            {
                DataTable table = supplierTypesDataSet.Tables[0];
                SetDataObjectFields(table.Rows[0], ref dataObjectType);
            }
            return dataObjectType;
        }
        #endregion
        #region Private Methods
        private void SetDataObjectFields<T>(DataRow row, ref T dataObject)
        {

            Type t = dataObject.GetType();
            PropertyInfo[] props = t.GetProperties();
            foreach (PropertyInfo p in props)
            {
                string tmpValue = row.Table.Columns.Contains(p.Name) ? row[p.Name] as string : null;
                if ((tmpValue != null) && (p != null) && (dataObject != null))
                {


                    t.GetProperty(p.Name).SetValue(dataObject, Convert.ChangeType(tmpValue, p.PropertyType), null);
                }
            }

        }

        /// <summary>
        ///  Update the supplier tables.
        /// </summary>
        /// <param name="dataInfo"></param>
        /// <param name="dataType"></param>
        /// <param name="account"></param>
        /// <param name="monitoringData"></param>
        /// <param name="evaluationData"></param>
        /// <param name="transportProviderData"></param>
        /// <param name="segurProviderData"></param>
        /// <param name="delegationDataTable"></param>
        /// <param name="contactsDataTable"></param>
        /// <param name="visitsDataTable"></param>
        /// <param name="dataContactsChanged"></param>
        /// <returns></returns>
        /// 
        private async Task<bool> Update(ISupplierDataInfo dataInfo,
                           ISupplierTypeData dataType,
                           ISupplierAccountObjectInfo account,
                           DataTable monitoringData,
                           DataTable evaluationData,
                           DataTable transportProviderData,
                           DataTable segurProviderData,
                           DataTable delegationDataTable,
                           DataTable contactsDataTable,
                           DataTable visitsDataTable,
                           bool dataContactsChanged)
        {
            IEnviromentVariables environ = _service.GetEnviromentVariables();
            IUserAccessControlList accessControlList = _service.GetAccountManagement();
            bool returnValue = true;
            if (environ.IsSet(EnvConfig.OfficeConfiguration, EnvironmentVariables.Mapfre))
            {
                dataInfo.Name = dataInfo.Name + " " + dataInfo.Surname1 + " " + dataInfo.Surname2;
            }
            dataInfo.Email.Replace("@", "#");
            string name = environ.GetKey(EnvConfig.KarveConfiguration, EnvironmentVariables.CurrentUser) as string;
            // maybe this can be done at upper level.
            dataInfo.ChangedByUser = name;
            account.ChangedByUser = name;
            account.LastChange = DateTime.Now.ToString();

            if (environ.IsSet(EnvConfig.OfficeConfiguration, EnvironmentVariables.MRent))
            {
                if (!accessControlList.hasDeletePermission(name, "ProviderModule"))
                {
                    throw new SupplierDataServiceAccessDeniedException("Permission Invalid for the user " + name + "in module ProviderModule");
                }
            }
            else
            {
                if (!accessControlList.hasAllPermission(name, "ProviderModule"))
                {
                    throw new SupplierDataServiceAccessDeniedException("Permission Invalid for the user " + name + "in module ProviderModule");
                }
            }
            // permission control done.
            if (environ.IsSet(EnvConfig.OfficeConfiguration, EnvironmentVariables.GuestRegDocus) && dataContactsChanged)
            {
                throw new SupplierDataServicesAccessModifiedException("Data modified in the contacts");
            }
            // cuenta contable in spanish.
            bool IsAccountableAccountChanged = isAccountableAccountChanged(_dataMapper, account);
            // FIXME: ask what means icono formulario_id_201. It shall be a configuration enviroment parameter.
            // valor of incremento.
            double increaseValue = 0.0;
            if (environ.IsSet(EnvConfig.OfficeConfiguration, EnvironmentVariables.Herrero) && environ.IsSet(EnvConfig.OfficeConfiguration, EnvironmentVariables.IconoFormularioID201))
            {
                IMapperCommand mapperIncreaseValue = new QueryAsyncForObjectCommandRetValue<double>("Suppliers.GetIncreasedValue", Convert.ToString(increaseValue));
                /* increaseValue = select incremento from provee1 where num_provee= 'INCREMENTO' */
                increaseValue = await _dataMapper.QueryAsyncForObject<double>("Suppliers.GetIncreasedValue", Convert.ToString(increaseValue)).ConfigureAwait(false);

            }
            // if there no iban in the object set data object.
            if ((account.TransferAccount.Trim().Length != 0) && (account.IBAN.Trim().Length == 0))
            {
                account.IBAN = await ComputeIBAN(_dataMapper, account);
                account.SWIFT = await ComputeSWIFT(_dataMapper, account.IBAN);
            }
            if (environ.IsSet(EnvConfig.CompanyConfiguration, EnvironmentVariables.EfectosProvee))
            {
                // create a supplier account
                _dataMapper.AddBatch(new CreateSupplierAccountCommandObject(account));
            }
            // Save the table proveee1  and provee2
            _dataMapper.AddBatch(new UpdateCommandObject(dataInfo, dataType, "Suppliers.UpdateSupplierInfo"));
            // update monitoring data.
            _dataMapper.AddBatch(new UpdateCommandTable(monitoringData, "Suppliers.UpdateMonitoringTable"));
            // save evaluation note.
            _dataMapper.AddBatch(new UpdateCommandTable(evaluationData, "Suppliers.UpdateEvaluationTable"));
            // transport provider table.
            _dataMapper.AddBatch(new UpdateCommandTable(transportProviderData, "Suppliers.UpdateTransportProviderTable"));
            // add supplier type.
            _dataMapper.AddBatch(new UpdateCommandObject(dataType, "Suppliers.UpdateSupplierType"));
            // add assurance data
            _dataMapper.AddBatch(new UpdateCommandTable(segurProviderData, "Suppliers.UpdateAssuranceData"));

            try
            {
                // we execute a first batch
                returnValue = returnValue && await _dataMapper.ExecuteUpdateAsyncBatch();

            }
            catch (Exception e)
            {
                throw new DataUpdateException(e.Message);
            }
            if (!returnValue)
            {
                return returnValue;
            }
            // save other things
            await SaveOtherData(environ, _dataMapper, account, name).ConfigureAwait(false);
            if (!environ.IsSetNotEmpty(EnvConfig.KarveConfiguration, EnvironmentVariables.NoCtaContaProvee))
            {

                // if contalbprov (invoice account suppliers) and Isinvoice management enabled. albanares = invoice  
                if (environ.IsSetNotEmpty(EnvConfig.CompanyConfiguration, EnvironmentVariables.ContaAlbProve) && (account.IsInvoiceManagementEnabled))
                {
                    int accountLevel = 3;
                    if (environ.IsSet(EnvConfig.KarveConfiguration, EnvironmentVariables.NivelCta))
                    {
                        accountLevel = Convert.ToInt32(account.CustomerAccount);
                    }
                    // FIXME: from visual basic shall be  ctapendfac = "409" & FDer(Right(Text1.Text, NivelCta - 3), "0", NivelCta - 3)
                    string pendingBillingAccount = "409" + CommonString.FDer(CommonString.Right(dataInfo.Code, accountLevel - 3), '0', accountLevel - 3);
                    bool existInTable = await ExistsInAccountTable(_dataMapper, pendingBillingAccount, environ).ConfigureAwait(false);
                    if (!existInTable)
                    {
                        IDictionary<string, object> param = new Dictionary<string, object>();

                        param.Add("codigo", pendingBillingAccount);
                        param.Add("descrip", account.AccountDescription + " FAC.PENDIENTES");
                        param.Add("ultmodi", account.LastChange);
                        param.Add("usuario", account.ChangedByUser);
                        param.Add("activo", account.Active);
                        param.Add("descrip2", account.AccountDescription2);
                        param.Add("sublicen", account.Sublicen);
                        bool ret = await _dataMapper.ExecuteInsertAsyncDictionary<bool>("Supplier.InsertNewAccount", param).ConfigureAwait(false);
                    }
                    else
                    {
                        IDictionary<string, object> param = new Dictionary<string, object>();
                        param.Add("codigo", account.AccountableAccount);
                        param.Add("sublicen", account.Sublicen);
                        /* select descrip from cu1 where codigo = account.AccountableAccount and sublicen = sublicen descrip
                         */
                        string accountDescription = await _dataMapper.QueryAsyncForObjectByDictionary<string>("Supplier.SelectDescription", param);

                        if ((!environ.IsSet(EnvConfig.KarveConfiguration, EnvironmentVariables.RentMultiMedia)) && (!accountDescription.Equals(account.AccountableAccount)))
                        {
                            // here defer the update
                            _dataMapper.AddBatch(new UpdateSupplierAccountCommandObject(account, "Supplier.AccountObject"));
                        }

                    }

                }
                // if the efectos provee is not null and the "cuenta efectos" is not empty
                if (!environ.IsSetNotEmpty(EnvConfig.CompanyConfiguration, EnvironmentVariables.EfectosProvee)
                     && (account.CustomerAccount == string.Empty))

                {
                    IDictionary<string, object> param = new Dictionary<string, object>();
                    param.Add("codigo", account.CustomerAccount);
                    param.Add("descrip", account.AccountDescription + " EFECTOS");
                    param.Add("ultmodi", account.LastChange);
                    param.Add("usuario", account.ChangedByUser);
                    param.Add("activo", account.Active);
                    param.Add("sublicen", account.Sublicen);
                    bool ret = await _dataMapper.ExecuteInsertAsyncDictionary<bool>("Supplier.InsertNewAccount", param).ConfigureAwait(false);
                }
                /* FIXME: At this point i want todelete the old account if is required
                 *       If OK And bCambioCta Then OK = BorraCtaVieja(CuentaA)               
                 */
                if (environ.IsSetNotEmpty(EnvConfig.KarveConfiguration, EnvironmentVariables.ExisteProveeDest))
                {
                    IDictionary<string, object> param = new Dictionary<string, object>();
                    param.Add("codigo", account.AccountableAccount);
                    param.Add("NUMERO_cli", account.edKCli);
                    // update clientes1 set provee_dest = account.AccountableAccount and NUMERO_Cli = edKCli.Text
                    _dataMapper.AddBatch(new UpdateCommandDictionary("Clientes.UpdateClients1", param));
                }

            }
            _dataMapper.AddBatch(new UpdateCommandTable(delegationDataTable, "Suppliers.UpdateSupplierDelegations"));
            _dataMapper.AddBatch(new UpdateCommandTable(contactsDataTable, "Suppliers.UpdateSupplierContacts"));
            _dataMapper.AddBatch(new UpdateCommandTable(visitsDataTable, "Supplier.UpdateSupplierVisits"));


            dataInfo.ChangedByUser = name;
            account.ChangedByUser = name;
            account.LastChange = DateTime.Now.ToString();
            // review this as adaptable with the db.
            dataInfo.LastChange = DateTime.Now.ToString();
            bool retValue = await _dataMapper.ExecuteUpdateAsyncBatch().ConfigureAwait(false);

            #region FixMeAutoCodigo
            /**
			 * FIXME: AutoCodigoEliminar. ask why we need an autocodigo. 
			 */
            #endregion
            returnValue = returnValue & await ManageComi(environ, _dataMapper, dataInfo.Type, account, dataInfo);
            return returnValue;
        }

        private async Task<bool> ManageComi(IEnviromentVariables environ,
            IDataMapper mapper,
            string type,
            ISupplierAccountObjectInfo account,
            ISupplierDataInfo info)
        {
            bool retValue = false;
            int value = (int)environ.GetKey(EnvConfig.CompanyConfiguration, EnvironmentVariables.Tipproconce);
            if (environ.IsSetNotEmpty(EnvConfig.CompanyConfiguration, EnvironmentVariables.Mercedes) && (type == value.ToString()))
            {
                /*
                    SELECT NOMBRE, PERSONA, NIF, DIRECTION, POBLACION, PROV, CP, NACIOPER, NACIODOMI, TELEFONO, FAX,
                    OBSERVA,sublicen , FALTA, fbaja, eMail, INTERNET, Movil, COORDGPS, Oficina
                    FROM PROVEE1 where NUM_PROVEE=info.Codigo*/
                DataTable tmpSupplier = await mapper.QueryAsyncForDataTableSession("Supplier.GetSupplier", info.Code, mapper.Session).ConfigureAwait(false);
                /* from the select we need to fetch the values 
                  "NOMBRE", "PERSONA", "NIF", "DIRECCION", "POBLACION", "PROV", "CP", "NACIOPER", "NACIODOMI", "TELEFONO", "FAX", 
                 "OBSERVA", "sublicen", "FALTA", "fbaja", "eMail", "INTERNET", "Movil", "COORDGPS", "Oficina"
                */
                /* SELECT NUM_COMI from comisio where NIF = account.Nif */
                DataTable comi = null;
                if (string.IsNullOrEmpty(account.CommissionNumber))
                {
                    comi = await mapper.QueryAsyncForDataTableSession("Supplier.GetCommissionByNif", account.Nif, mapper.Session).ConfigureAwait(false);
                    if ((comi != null) && (comi.Rows.Count > 0) && (comi.Columns.Contains("NUM_COMI")))
                    {
                        DataRowCollection rows = comi.Rows;
                        account.CommissionNumber = rows[0]["NUM_COMI"] as string;
                    }
                }
                if (string.IsNullOrEmpty(account.CommissionNumber))
                {
                    /** in vb6 we use a function for generating the comissionist numner
                     * places in JaBAutoCodigoTrans("COMISIO", "NUM_COMI")
                     * I would prefer generate a true random value with a fixed prefix.
                     */
                    short tmpComisioNumber = 0;
                    short commisionNumber = 0;
                    // i repeat the generation until there is a unique commision number
                    do
                    {
                        byte[] data = new byte[1];
                        using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
                        {
                            rngCsp.GetBytes(data);
                        }
                        tmpComisioNumber = BitConverter.ToInt16(data, 0);
                        account.CommissionNumber = tmpComisioNumber.ToString();
                        commisionNumber = await mapper.QueryAsyncForObjectSession<short>("Commission.GetNumberOfCommission", tmpComisioNumber, mapper.Session).ConfigureAwait(false);
                    } while (commisionNumber == tmpComisioNumber);
                    mapper.AddBatch(new InsertCommissionNumberCommand(account.CommissionNumber, tmpSupplier, "Commission.InsertCommission"));
                    IDictionary<string, object> commissionParam = new Dictionary<string, object>();
                    commissionParam["NUMCOMI_PR"] = account.CommissionNumber;
                    commissionParam["NUM_PROVEE"] = info.Code;
                    mapper.AddBatch(new UpdateCommandDictionary("Supplier.UpdateSupplierCommission", commissionParam));
                    retValue = retValue & await mapper.ExecuteUpdateAsyncBatch().ConfigureAwait(false);
                }
                else
                {
                    mapper.AddBatch(new UpdateCommandTable(tmpSupplier, account.CommissionNumber, "Commission.UpdateCommission"));
                    retValue = retValue & await mapper.ExecuteUpdateAsyncBatch().ConfigureAwait(false);
                }

            }
            return retValue;
        }
        private async Task<bool> SaveOtherData(IEnviromentVariables environ, IDataMapper dataMapper,
                                             ISupplierAccountObjectInfo account, string connectedUser)
        {
            // in case there is no supplier account.
            if (environ.IsSet(EnvConfig.CompanyConfiguration, EnvironmentVariables.NoCtaContaProvee))
            {
                return true;
            }
            // cuenta contable 
            string accountName = account.AccountableAccount;
            account.AccountDescription = await GetAccountName(dataMapper, environ, account).ConfigureAwait(false);
            account.AccountDescription2 = await GetAccountName(dataMapper, environ, account, false).ConfigureAwait(false);
            int numberOfModification = await NumberOfModification(dataMapper, environ, account).ConfigureAwait(false);
            if (!String.IsNullOrEmpty(accountName))
            {
                bool existInTable = await ExistsInAccountTable(dataMapper, accountName, environ).ConfigureAwait(false);
                if (!existInTable)
                {
                    if (environ.IsSetNotEmpty(EnvConfig.CompanyConfiguration, EnvironmentVariables.ProveComun))
                    {
                        /* SELECT list(codigo) from sublicen sublicen  */
                        string value = await dataMapper.QueryAsyncForObjectSession<string>("Suppliers.GetAccountCodeList", null, _dataMapper.Session).ConfigureAwait(false);
                        string[] words = value.Split(',');
                        foreach (string code in words)
                        {
                            int rowsAffected = await dataMapper.QueryAsyncForObjectSession<int>("Suppliers.ExistAccountByCode", code, _dataMapper.Session).ConfigureAwait(false);
                            if (rowsAffected > 0)
                            {
                                IList<object> param = new List<object>();
                                param.Add(account.AccountableAccount);
                                param.Add(account.AccountDescription);
                                param.Add(account.LastChange);
                                param.Add(account.ChangedByUser);
                                param.Add(account.Active);
                                param.Add(account.AccountDescription2);
                                param.Add(code);
                                bool ret = await dataMapper.ExecuteInsertAsync<bool>("Supplier.InsertNewAccount", param, _dataMapper.Session).ConfigureAwait(false);
                                return ret;
                            }
                        }
                    }
                    else
                    {
                        IDictionary<string, object> param = new Dictionary<string, object>();
                        param.Add("codigo", account.AccountName);
                        param.Add("descrip", account.AccountDescription);
                        param.Add("ultmodi", account.LastChange);
                        param.Add("usuario", account.ChangedByUser);
                        param.Add("activo", account.Active);
                        param.Add("descrip2", account.AccountDescription2);
                        param.Add("sublicen", account.Sublicen);
                        bool ret = await dataMapper.ExecuteInsertAsyncDictionary<bool>("Supplier.InsertNewAccount", param);
                        if (ret)
                        {
                            string sublicen = GetSublicen(environ);
                            ret = await CreateAccountCompanySupplier(dataMapper, environ, account, param, sublicen);
                        }
                        return ret;
                    }
                }
            }
            return true;

        }

        private async Task<bool> CreateAccountCompanySupplier(IDataMapper mapper,
                                                      IEnviromentVariables environ,
                                                      ISupplierAccountObjectInfo account,
                                                      IDictionary<string, object> param,
                                                      string company)
        {

            string companyName = company;
            bool returnValue = true;
            /*SELECT CODIGO FROM SUBLICen WHERE CODIGO<>companyName*/
            IList<SupplierSublicenDataObject> supplierSublicenDataObject = await mapper.QueryAsyncForList<SupplierSublicenDataObject>("Suppliers.GetCodeInSublicen", companyName);
            /*SELECT CODIGO FROM SUBLICen WHERE CODIGO<>companyName*/
            supplierSublicenDataObject = await mapper.QueryAsyncForList<SupplierSublicenDataObject>("Suppliers.GetCodeInSublicen", companyName);
            foreach (SupplierSublicenDataObject da in supplierSublicenDataObject)
            {
                string companyCode = da.code;
                /*
                 *  SELECT TOP 1 CODIGO FROM CU1 WHERE SUBLICEN='00' AND CODIGO=companyCode;
                 */
                IDictionary<string, object> p = new Dictionary<string, object>();
                p.Add("table", "cu1");
                p.Add("codigo", account.AccountableAccount);
                p.Add("sublicen", companyCode);
                /*
                *  SELECT (TOP 1 FROM CU WHERE codigo=account.AccountableAccount and sublicen = companyCode
                * Check if Exist columns in code
                 */
                Tuple<string, object> cuTuple = await mapper.QueryAsyncForObject<Tuple<string, object>>("Suppliers.CheckExistColumnInTable", param).ConfigureAwait(true);
                if (cuTuple.Item2 != null)
                {
                    IDictionary<string, object> updateParam = new Dictionary<string, object>();
                    updateParam.Add("account", account.AccountableAccount);
                    updateParam.Add("accountdescription", account.AccountDescription);
                    updateParam.Add("accountlastmodification", account.LastChange);
                    updateParam.Add("accountlastuser", account.ChangedByUser);
                    updateParam.Add("systemtype", EnvironmentVariables.SupplierModuleType);
                    updateParam.Add("accountdescription2", account.AccountDescription2);
                    updateParam.Add("sublicen", companyName);
                    bool ret = await mapper.ExecuteInsertAsyncDictionary<bool>("Supplier.InsertNewAccountCompanySupplier", updateParam);
                    returnValue = ret && returnValue;
                }
            }
            return returnValue;

        }
        private string GetAccountPrefix(IEnviromentVariables environ)
        {
            string text = "400";
            if (environ.IsSetNotEmpty(EnvConfig.KarveConfiguration, EnvironmentVariables.PrefijoProve))
            {
                text = (string)environ.GetKey(EnvConfig.KarveConfiguration, EnvironmentVariables.PrefijoProve);
            }
            return text;
        }
        /// <summary>
        ///  Get the "sublicen" value following the enviroment configuration variables.
        /// </summary>
        /// <param name="environ">Enviroment variables.</param>
        /// <returns></returns>
        private string GetSublicen(IEnviromentVariables environ)
        {
            string sublicen = "";
            if (environ.IsSetNotEmpty(EnvConfig.KarveConfiguration, EnvironmentVariables.EmpresaPlanCuenta))
            {
                sublicen = (string)environ.GetKey(EnvConfig.KarveConfiguration, EnvironmentVariables.EmpresaPlanCuenta);
            }
            else
            {
                sublicen = (string)environ.GetKey(EnvConfig.KarveConfiguration, EnvironmentVariables.EmpresaConectada);
            }
            if (String.IsNullOrEmpty(sublicen))
            {
                sublicen = "00";
            }
            return sublicen;
        }
        private async Task<bool> ExistsInAccountTable(IDataMapper dataMapper, string accountName, IEnviromentVariables environ)
        {
            int rowsAffected = 0;
            /*
             SELECT TOP 1 codigo FROM CU1 where codigo=accountName;
             SELECT TOP 1 codigo FROM CU1 where codigo=accountName and SUBLICEN=sublicen;
             */
            string sublicen = "";
            if (environ.IsSetNotEmpty(EnvConfig.KarveConfiguration, EnvironmentVariables.EmpresaPlanCuenta))
            {
                sublicen = (string)environ.GetKey(EnvConfig.KarveConfiguration, EnvironmentVariables.EmpresaPlanCuenta);
            }
            else
            {
                sublicen = (string)environ.GetKey(EnvConfig.KarveConfiguration, EnvironmentVariables.EmpresaConectada);
            }
            if (String.IsNullOrEmpty(sublicen))
            {
                rowsAffected = await dataMapper.QueryAsyncForObject<int>("Suppliers.ExistAccountByCode", accountName);
            }
            else
            {
                IList<string> param = new List<string>();
                param.Add(accountName);
                param.Add(sublicen);
                rowsAffected = await dataMapper.QueryAsyncForObject<int>("Suppliers.ExistAccountByCodeAndSublicen", param);
            }
            return (rowsAffected > 0);
        }




        private async Task<string> GetAccountName(IDataMapper dataMapper, IEnviromentVariables environ, ISupplierAccountObjectInfo accountInfo, bool firstAccount = true)
        {
            string accountName = "";
            int number = await NumberOfModification(dataMapper, environ, accountInfo).ConfigureAwait(false);
            if (number == 0)
            {
                accountName = accountInfo.AccountName;
            }
            string companyPlanAccount = (string)environ.GetKey(EnvConfig.KarveConfiguration, EnvironmentVariables.EmpresaPlanCuenta);
            string sublicenValue;
            if (!String.IsNullOrEmpty(companyPlanAccount))
            {
                sublicenValue = companyPlanAccount;
            }
            else
            {
                sublicenValue = accountInfo.Sublicen;
            }
            string queryName = firstAccount ? "Supplier.AccountableAccountDescription" : "Supplier.AccountableAccountDescription2";
            /***********************
             * select descrip from cu1 where codigo = accountInfo.AccountableAccount and sublicenValue = sublicen DESCRIP
             ************************/
            /***********************
             * select descrip2 from cu1 where codigo = accountInfo.AccountableAccount and sublicenValue = sublicen DESCRIP2
             ************************/
            IList<string> param = new List<string>();
            param.Add(accountInfo.AccountableAccount);
            param.Add(sublicenValue);
            accountName = await dataMapper.QueryAsyncForObject<string>(queryName, param).ConfigureAwait(false);
            return accountName;
        }

        private bool isAccountableAccountChanged(IDataMapper dataMapper, ISupplierAccountObjectInfo account)
        {
            return true;
        }

        private async Task<string> ComputeSWIFT(IDataMapper dataMapper, string Iban)
        {
            string bankCode = Iban.Substring(5, 4);
            /* SELECT SWIFT FROM BANCO WHERE CODBAN = banco*/
            string swift = await dataMapper.QueryAsyncForObject<string>("Suppliers.ComputeSwift", bankCode);
            return swift;
        }

        private async Task<string> ComputeIBAN(IDataMapper dataMapper, ISupplierAccountObjectInfo account)
        {
            /* SELECT CREAR_IBAN account.Transfer as IBAN IBAN*/
            string iban = await dataMapper.QueryAsyncForObject<string>("Suppliers.ComputeIban", account.TransferAccount).ConfigureAwait(false);
            return iban;
        }
        private async Task<int> NumberOfModification(IDataMapper mapper, IEnviromentVariables environ,
                                    ISupplierAccountObjectInfo accountInfo)
        {
            /*
             * SELECT NOMODIFICA_DESC FROM CU1 WHERE codigo = 'accountInfo.AccountableAccount' AND sublicen = 'sublicenValue' NOMODIFICA_DESC  
             */
            string companyPlanAccount = (string)environ.GetKey(EnvConfig.KarveConfiguration, EnvironmentVariables.EmpresaPlanCuenta);
            string sublicenValue;
            if (!String.IsNullOrEmpty(companyPlanAccount))
            {
                sublicenValue = companyPlanAccount;
            }
            else
            {
                sublicenValue = accountInfo.Sublicen;
            }
            IList<string> param = new List<string>();
            param.Add(accountInfo.AccountableAccount);
            param.Add(sublicenValue);
            int numberOfModification = await mapper.QueryAsyncForObject<int>("Suppliers.NoModifica", param);
            return numberOfModification;
        }

        public DataSet GetSuppliersSummaryPaged(long pos)
        {
            PageParameterObject paged = new PageParameterObject();
            paged.startPos = pos;
            DataTable setSummary = _dataMapper.QueryForDataTable("Suppliers.GetFullSuppliersSummaryPaged", pos);
            DataSet setName = new DataSet("PagedSupplierSummary");
            setName.Tables.Add(setSummary);
            return setName;
        }
        public async Task<ISupplierTypeData> GetAsyncSupplierTypeById(string supplierId)
        {
            ISupplierTypeData data = await _dataMapper.QueryAsyncForObjectSession<ISupplierTypeData>("Suppliers.GetSupplierTypeById", supplierId, _dataMapper.Session).ConfigureAwait(false);
            return data;
        }
        public async Task<ISupplierAccountObjectInfo> GetAsyncSupplierAccountInfo(string supplierId, object environ)

        {
            IEnviromentVariables env = environ as IEnviromentVariables;
            string sublicen = GetSublicen(env);
            string accountPrefix = GetAccountPrefix(env);

            IDictionary<string, object> param = new Dictionary<string, object>();
            ISupplierAccountObjectInfo account = new SupplierAccountObjectInfo();
            AccountDataObject accountDataObject = await GetAsyncSupplierAccountableAccount("Suppliers.GetAccountableAccount", supplierId, sublicen).ConfigureAwait(false);
            account.AccountableAccount = accountDataObject.AccountNumber;
            account.Sublicen = accountDataObject.Sublicen;
            param["cuenta"] = accountDataObject.AccountNumber;
            param["sublicen"] = sublicen;
            account.AccountName = accountDataObject.AccountDescription2;
            string value = await _dataMapper.QueryAsyncForObjectSession<string>("Suppliers.GetBalance", param, _dataMapper.Session).ConfigureAwait(false);
            account.PrefixAccount = accountPrefix;
            account.AccountBalance = String.IsNullOrEmpty(value) ? 0 : Convert.ToDouble(value);
            //account.AccountName =
            account.AccountDescription = accountDataObject.AccountDescription;
            account.AccountDescription2 = accountDataObject.AccountDescription2;

            accountDataObject = await GetAsyncSupplierAccountableAccount("Suppliers.GetExpensesAccount", supplierId, sublicen).ConfigureAwait(false);
            if (accountDataObject != null)
            {
                account.ExpensesAccountCode = accountPrefix;
                account.ExpensesAccount = accountDataObject.AccountNumber;
            }
            accountDataObject = await GetAsyncSupplierAccountableAccount("Suppliers.GetDeductionAccount", supplierId, sublicen).ConfigureAwait(false);
            if (accountDataObject != null)
            {
                account.ExpensesAccountCode = accountPrefix;
                account.ExpensesAccount = accountDataObject.AccountNumber;
            }
            accountDataObject = await GetAsyncSupplierAccountableAccount("Suppliers.GetPaymentAccount", supplierId, sublicen).ConfigureAwait(false);
            if (accountDataObject != null)
            {
                account.PaymentAccountCode = accountPrefix;
                account.PaymentAccount = accountDataObject.AccountNumber;
            }
            accountDataObject = await GetAsyncSupplierAccountableAccount("Suppliers.GetIntracopAccount", supplierId, sublicen).ConfigureAwait(false);
            if (accountDataObject != null)
            {
                account.IntraAccountSop = accountDataObject.AccountNumber;
            }
            accountDataObject = await GetAsyncSupplierAccountableAccount("Suppliers.GetCPAccount", supplierId, sublicen).ConfigureAwait(false);
            if (accountDataObject != null)
            {
                account.CPAccount = accountDataObject.AccountNumber;
            }
            accountDataObject = await GetAsyncSupplierAccountableAccount("Suppliers.GetLPAccount", supplierId, sublicen).ConfigureAwait(false);
            if (accountDataObject != null)
            {
                account.LPAccount = accountDataObject.AccountNumber;
            }
            accountDataObject = await GetAsyncSupplierAccountableAccount("Suppliers.GetTransferAccount", supplierId, sublicen).ConfigureAwait(false);
            if (accountDataObject != null)
            {
                account.TransferAccount = accountDataObject.AccountNumber;
            }
            if (!String.IsNullOrEmpty(account.TransferAccount))
            {
                account.IBAN = await ComputeIBAN(_dataMapper, account).ConfigureAwait(false);
                account.SWIFT = await ComputeSWIFT(_dataMapper, account.IBAN).ConfigureAwait(false);
            }
            return account;
        }
        // "Suppliers.GetAccountableAccount"
       /* private async Task<AccountDataObject> GetAsyncSupplierAccountableAccount(string statementId, string supplierId, string sublicen)
        {
            AccountDataObject accountDataObject;
            IDictionary<string, object> param = new Dictionary<string, object>();
            string code = sublicen;
            if (String.IsNullOrEmpty(sublicen))
            {
                code = "00";
            }
            param["supplierId"] = supplierId;
            param["sublicen"] = sublicen;
            accountDataObject = await _dataMapper.QueryAsyncForObjectSession<AccountDataObject>(statementId, param, _dataMapper.Session);

            return accountDataObject;
        }
        */
        public async Task<IDictionary<string, string>> GetAsyncSupplierDescription(string supplierId, string sublicen)
        {
            IList<string> list = new List<string>();
            list.Add(supplierId);
            list.Add(sublicen);
            string description = await _dataMapper.QueryAsyncForObject<string>("Suppliers.AccountableAccountDescription", list);
            string description2 = await _dataMapper.QueryAsyncForObject<string>("Suppliers.AccountableAccountDescription2", list);
            IDictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary["Description"] = description;
            dictionary["Description2"] = description2;
            return dictionary;
        }
        public async Task<double> GetAsyncBalance(string supplierId, string sublicen)
        {
            string data = "";
            IDictionary<string, object> param = new Dictionary<string, object>();
            param["cuenta"] = supplierId;
            param["sublicen"] = sublicen;
            data = await _dataMapper.QueryAsyncForObject<string>("Suppliers.GetBalance", param);
            if (!String.IsNullOrEmpty(data))
            {
                return Convert.ToDouble(data);
            }
            return 0;
        }
        public async Task<DataSet> GetEvaluationNote(string supplierId)
        {
            DataTable table = await _dataMapper.QueryAsyncForDataTableSession("Suppliers.LoadEvaluationNote", supplierId, _dataMapper.Session).ConfigureAwait(false);
            DataSet set = new DataSet("SupplierEvaluationNote");
            set.Tables.Add(table);
            return set;
        }
        public async Task<DataSet> GetAsyncTransportProviderData(string supplierId)
        {
            DataTable table = await _dataMapper.QueryAsyncForDataTableSession("Suppliers.GetSupplierTransportInfo", supplierId, _dataMapper.Session).ConfigureAwait(false);
            DataSet set = new DataSet("SupplierEvaluationNote");
            set.Tables.Add(table);
            return set;
        }

        public async Task<DataSet> GetAsyncSupplierAssuranceData(string supplierId)
        {
            DataSet set = new DataSet("SupplierAssurance");
            DataTable table = await _dataMapper.QueryAsyncForDataTableSession("Suppliers.GetSupplierAssuranceInfo", supplierId, _dataMapper.Session);
            set.Tables.Add(table);
            return set;
        }
        public async Task<DataSet> GetAsyncSupplierContacts(string supplierId)
        {
            DataSet set = new DataSet("SupplierContacts");
            DataTable table = await _dataMapper.QueryAsyncForDataTableSession("Suppliers.GetSupplierContacts", supplierId, _dataMapper.Session);
            set.Tables.Add(table);
            return set;
        }

        public async Task<DataSet> GetAsyncMonitoring(string supplierId)
        {
            DataSet set = new DataSet("MonitoringSupplier");
            DataTable table = await _dataMapper.QueryAsyncForDataTableSession("Suppliers.MonitoringSuppliersById", supplierId, _dataMapper.Session);
            set.Tables.Add(table);
            return set;
        }

        public async Task<bool> Update(ISupplierDataInfo dataInfo,
            ISupplierTypeData dataType,
            ISupplierAccountObjectInfo ao,
            DataSet monitoringData,
            DataSet evaluationData,
            DataSet transportProviderData,
            DataSet assuranceProviderData,
            DataSet contactsProviderData,
            DataSet visitsProviderData,
            bool contactsChanged)
        {
            DataTable monitoringDataTable = monitoringData.Tables[0].GetChanges();
            DataTable evaluationDataTable = evaluationData.Tables[0].GetChanges();
            DataTable transportProviderDataTables = transportProviderData.Tables[0].GetChanges();
            DataTable contactsProviderDataTables = contactsProviderData.Tables[0].GetChanges();
            DataTable visitsProviderDataTables = visitsProviderData.Tables[0].GetChanges();
            bool updateResult = await Update(dataInfo, dataType, ao,
                         monitoringData, evaluationData,
                         transportProviderData, assuranceProviderData,
                         contactsProviderData, visitsProviderData, contactsChanged);
            return updateResult;
        }


        public void OpenDataSession()
        {
            _session = _mapper.SessionFactory.OpenSession();
            if (this._dataMapper.Session != null)
            {
                this._dataMapper.Session.Dispose();
            }
            this._dataMapper.Session = new ScopedSession(_session);
        }

        public void CloseDataSession()
        {
            this._dataMapper.Session.Session.Dispose();
        }



        public Task<ISupplierAccountObjectInfo> GetAsyncSupplierAccountInfo(string baseSupplierId)
        {
            throw new NotImplementedException();
        }

        public Task<DataSet> GetAsyncSuppliersSummaryPaged()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(ISupplierDataInfo info, ISupplierTypeData td, ISupplierAccountObjectInfo ao, DataSet monitoringData, DataSet evaluationData, DataSet transportData, DataSet assuranceProviderData, bool contactsChanged, DataSet visitsData)
        {
            throw new NotImplementedException();
        }
    }
}
#endregion

