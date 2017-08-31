using System;
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
using System.Collections.ObjectModel;
using EnvConfig = KarveCommon.Generic.EnvironmentConfig;
using System.Collections.Generic;

namespace DataAccessLayer
{
    class SupplierDataAccessLayer : ISupplierDataServices
    {
        private IDataMapper _dataMapper;
        private IConfigurationService _service;

        public SupplierDataAccessLayer(IDataMapper dataMapper, IConfigurationService service)
        {
            this._dataMapper = dataMapper;
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
        /// This method look for the Number, Nif, and brief summary of the supplier.
        /// </summary>
        /// <returns></returns>
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
                // nombre tabla.
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
        /// <summary>
        ///  Each supplier has an evaluation note. We retrieve the data object of the evaluation note.
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        public Task<ISupplierEvaluationNoteData> GetAsyncSupplierEvaluationNoteDataObject(string supplierId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        ///  This methods is useful for retriving monitoring informations from the database,
        ///  give the id of the supplier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<ISupplierMonitoringData> GetAsyncMonitoringSupplierById(string id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        ///  This returns the asynchronous supplier type given hisid.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ISupplierTypeData GetAsyncSupplierTypeById(string id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        ///  Return a paged dataset that it is the merge between the first dataset fetched and the new request.
        /// </summary>
        /// <returns></returns>
        public Task<DataSet> GetAsyncSuppliersSummaryPaged()
        {
            throw new NotImplementedException();
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


        /** see the datas from provee2 */
        public async void Update(ISupplierDataInfo dataInfo,
                           ISupplierTypeData dataType,
                           ISupplierAccountObjectInfo account,
                           ObservableCollection<ISupplierMonitoringData> monitoring,
                           bool dataContactsChanged,
                           ObservableCollection<ISupplierContactsData> dataContacts)
        {

            IEnviromentVariables environ = _service.GetEnviromentVariables();
            IUserAccessControlList accessControlList = _service.GetAccountManagement();

            if (environ.IsSet(EnvConfig.OfficeConfiguration, EnvironmentVariables.Mapfre))
            {
                dataInfo.Name = dataInfo.Name + " " + dataInfo.Surname1 + " " + dataInfo.Surname2;
            }
            dataInfo.Email.Replace("@", "#");
            string name = environ.GetKey(EnvConfig.KarveConfiguration, EnvironmentVariables.CurrentUser) as string;
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
            /* Understand this.
             * If OK And txtNacioPer.Text <> "" Then OK = dbUpdateTo("Provee1", "NACIODOMI", txtNacioPer.Text, cWHERE & "NUM_PROVEE = '" & Text1.Text & "'")
             */
            // Save the table proveee1  and provee2
            _dataMapper.AddBatch(new UpdateCommandObject(dataInfo, dataType, "Suppliers.UpdateSupplierInfoAndType"));
            // Save monitoring (seguimento)
            // we pass here the data table changed.
            /*// data table
             *   If OK Then OK = GuardarSeguimiento
  If OK Then OK = Guardar_Otros
  If OK Then OK = Guardar_EvaluaNota
  If OK Then OK = GuardarTrans
  If OK Then OK = GuardaTipo

             */
            _dataMapper.AddBatch(new DeleteCommandObject(dataInfo, "Suppliers.DeleteMonitoring"));
            foreach (ISupplierMonitoringData monitorData in monitoring)
            {
                _dataMapper.AddBatch(new InsertCommandObject(monitorData, "Suppliers.InsertMonitoring"));
            }

            // save other things
            await SaveOtherData(environ, _dataMapper, account).ConfigureAwait(false);
            /*
             * data table
              If OK Then OK = Guardar_EvaluaNota
            // DATA TABLE  
            If OK Then OK = GuardarTrans
 
             */
             /* GUARDAR TIPO 
              
             
             */
            dataInfo.ChangedByUser = name;
            account.ChangedByUser = name;
            account.LastChange = DateTime.Now.ToString();
            // review this as adaptable with the db.
            dataInfo.LastChange = DateTime.Now.ToString();
            _dataMapper.ExecuteUpdateAsyncBatch();



        }

        private async Task<bool> SaveOtherData(IEnviromentVariables environ, IDataMapper dataMapper,
                                         ISupplierAccountObjectInfo account, string connectedUser)
        {
            // in case there is no supplier account.
            if (environ.IsSet(EnvConfig.CompanyConfiguration, EnvironmentVariables.NoCtaContaProvee))
            {
                return true;
            }
            if (!environ.IsSet(EnvConfig.CompanyConfiguration, EnvironmentVariables.NoCrearCuentaProvee))
            {
                // no creare cuenta provee.
                CreateSupplierAccount(_dataMapper, account);
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
                        string value = await dataMapper.QueryAsyncForObject<string>("Suppliers.GetAccountCodeList", null);
                        string[] words = value.Split(',');
                        foreach (string code in words)
                        {
                            int rowsAffected = await dataMapper.QueryAsyncForObject<int>("ExistAccountByCode", code);
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
                                bool ret = await dataMapper.ExecuteInsertAsync<bool>("Supplier.InsertNewAccount", param);
                            }
                        }
                    }
                    else
                    {
                        IDictionary<string, object> param = new Dictionary<string, object>();
                        param.Add("codigo", accountName.Trim());
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
                            /*
                             * 
                             *    If OK Then OK = CreaCtaE mpsProv(Cols, Trim(Cuenta), sNomCta, 
                             *    Text2.Text, IIf(EmpresaPlanCta <> "", EmpresaPlanCta, EmpresaConectada), "P")
                             */
                            ret = await CreateAccountCompanySupplier(param, sublicen);
                        }
                    }

                }
            }
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
            IList<SupplierSublicenDataObject> supplierSublicenDataObject = await mapper.QueryAsyncForList<SupplierSublicenDataObject>("Suppliers.GetDifferentSublicen", companyName);
            foreach (SupplierSublicenDataObject da in supplierSublicenDataObject)
            {
                string companyCode = da.;
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
                Tuple<string, object> cuTuple = await mapper.QueryAsyncForObject<Tuple<string, object>>("Generic.CheckExistColumnInTable", param).ConfigureAwait(true);
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
                rowsAffected = await dataMapper.QueryAsyncForObject<int>("ExistAccountByCode", accountName);
            }
            else 
            {
                IList<string> param = new List<string>();
                param.Add(accountName);
                param.Add(sublicen);
                rowsAffected = await dataMapper.QueryAsyncForObject<int>("ExistAccountByCodeAndSublicen", param);
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
        private void CreateSupplierAccount(IDataMapper dataMapper, ISupplierAccountObjectInfo account)
        {
            throw new NotImplementedException();
        }

        private bool isAccountableAccountChanged(IDataMapper dataMapper, ISupplierAccountObjectInfo account)
        {
            throw new NotImplementedException();
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

        private bool isChangePresentExpenseAccount(ISupplierAccountObjectInfo account)
        {
            throw new NotImplementedException();
        }

        private async Task<int> NumberOfModification(IDataMapper mapper, IEnviromentVariables environ,
                                    ISupplierAccountObjectInfo accountInfo)
        {
            /*
             * SELECT NOMODIFICA_DESC FROM CU1 WHERE codigo = 'accountInfo.AccountableAccount' AND sublicen = 'sublicenValue' NOMODIFICA_DESC  
             */
            string companyPlanAccount = (string) environ.GetKey(EnvConfig.KarveConfiguration, EnvironmentVariables.EmpresaPlanCuenta);
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

        #endregion

    }
}
