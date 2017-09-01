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
using EnvConfig = KarveCommon.Generic.EnvironmentConfig;
using System.Collections.Generic;
// this is needed for the random commissinist.
using System.Security.Cryptography;

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
        public async Task<DataSet> GetAsyncProviderType()
        {
            /* 
             * SELECT TIPOCOMP_P1 FROM PROVEE1 WHERE NUM_PROVEE="";
             */ 
            DataSet dataSet = new DataSet("ProviderType");
           
            return dataSet;
        }
        public async Task<DataSet> GetAsyncDelegations()
        {
            /* SELECT *, NULL ENVIAR
            vArray = getColsArraySQL_EXEC(cSELECT & "*, NULL ENVIAR" & sCrearMandato & cFROM & Taula & cWHERE & "cldIdCliente = " & setApostrofar(codi) & sOrden, EMAIL_SEPARA) */
            DataSet set = new DataSet("AsyncDelegations");
            return set;
        }

        /*
          Dim OK As Boolean
 Dim miWhere As String
 Dim sCod As String
  PasandoDatos = True
  Screen.MousePointer = 11
  sCod = Text1.Text
  Limpiar
  Text1.Text = sCod
  miWhere = cWHERE & "NUM_PROVEE = '" & Trim(Text1.Text) & "'"
  PasandoDatos = True
  OK = dbFrmSet("PROVEE1", Me, miWhere)
  If OK Then OK = dbFrmSet("PROVEE2", Me, miWhere)
  If OK Then
     textObserva.Text = Replace(textObserva_.Text, "#", "@")
     Carga_Tipo
     If txtDistri.Text = "" Then txtDistri.Text = getColValueRet("PROVEE1", "CODIEDI_PR1", edDistribuidor.Text, "NUM_PROVEE")
     '*------------------------------------------------------------------------
     Cargar_Delega Me, Text1.Text, vDelega, vDelegaCont, "ProDelega"
     Cargar_Contacto Me, Text1.Text, vContacto, vContactoCont, "ProContactos", "ProDelega"
     Cargar_Visitas_PROV Me, Text1.Text, vVisitas, vVisitasCont
     CargarLiPe
     CalcularEstadoHomologacion
     Cargar_EvaluaNota
     CargarTrans
     CargarArray
     '*------------------------------------------------------------------------
     TxtModo.Text = CStr(edModos.Actualizar)
     If Not (Icono_Formularios_ID = 201 And Img_Splash = 308) Then
        txtSaldo.Text = getSaldo
     End If
     misCambios = False
    
    If (getColValueSQL(cSELECT & "FBAJA" & cFROM & "PROVEE1" & miWhere, _
                      separator, "FBAJA")) <> "" Then
      jMsgBox getIdiomaMensa("Proveedor Dado de Baja", , "PROVEE_BAJA"), vbInformation
    End If
  Else
   jMsgBox getIdiomaMensa("Error al Pasar Datos", , "ERROR_DATOS")
  End If
  If GetIntNotNull(DatosConfig(Docs, "MAPFRE")) <> 0 Then
    If txtNomSolo.Text = "" And TxtNom.Text <> "" Then
      txtNomSolo.Text = TxtNom.Text
    End If
  End If
  edContacto.BtnVisible = GetIntNotNull(nContactos(Text1.Text)) > 0
  optPendPago(0).Value = True
  PasandoDatos = False
  OjoContactos = False
  If TxtIvaI(0).Text <> "" Then TxtIvaI(0).Description = Nom_Cu1(TxtIvaI(0).Text, txtSublicen.Text)
  txtGasAbono.Description = Nom_Cu1(txtGasAbono.Text, txtSublicen.Text)
  If txtCtaPago.Text <> "" Then txtCtaPago.Description = Nom_Cu1(txtCtaPago.Text, txtSublicen.Text)
  If CK("GESTION_DIVISAS") And edDivisa.Text <> "" Then
    cmdExtract(1).Visible = True
    cmdExtract(1).Caption = "Extracto " & edDivisa.Description
  Else
    cmdExtract(1).Visible = False
  End If
  If CK("MBF") Then
    If edBPS.Text <> "" And txtContable.Text = "" Then txtContable.Text = edBPS.Text
  End If
  sCtaGastoVieja = TxtCu.Text
  Screen.MousePointer = 0
  PasandoDatos = False
End Sub

             */
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

                IMapperCommand mapper1 = new Apache.Ibatis.DataMapper.MappedStatements.QueryAsyncForObjectCommand<ISupplierDataInfo>("Suppliers.GetSupplierInfos", id);
               // IMapperCommand mapper2 = new QueryAsyncForDataTableCommand("Suppliers.GetProvinceForEachSupplier", null);

                 _dataMapper.AddBatch(mapper1);
               // _dataMapper.AddBatch(mapper2);

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
        public async Task<bool> Update(ISupplierDataInfo dataInfo,
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
                        bool ret = await _dataMapper.ExecuteInsertAsyncDictionary<bool>("Supplier.InsertNewAccount", param);
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
                    bool ret = await _dataMapper.ExecuteInsertAsyncDictionary<bool>("Supplier.InsertNewAccount", param);
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
            bool retValue = await _dataMapper.ExecuteUpdateAsyncBatch();

            #region FixMeAutoCodigo
            /**
			 * FIXME: AutoCodigoEliminar. ask why we need an autocodigo. 
			 * <summary>
			 *   Private Sub AutoCodigoEliminar()
			 *    Dim pTr As Long
			 *   Dim codigo As String
			 *   If TxtModo.Text = CStr(edModos.Agregar) And AutoCodigo <> "" Then
			 *			  finTransacCodis "PROVEE1", AutoCodigo
	         *			AutoCodigo = ""
	         *		End If
             *         For pTr = 1 To vDelegaCont
	         *       codigo = getColsArrayValue(vDelega(0), vDelega(pTr), "cldIdDelega", EMAIL_SEPARA)
	         *     If codigo <> "" Then finTransacCodis "ProDelega", codigo
             *    Next pTr
             *    For pTr = 1 To vContactoCont
	         *   codigo = getColsArrayValue(vContacto(0), vContacto(pTr), "ccoIdContacto", EMAIL_SEPARA)
	         *  If codigo <> "" Then finTransacCodis "ProContactos", codigo
             *   Next pTr
             *  End Sub
			 * </summary>
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
                DataTable tmpSupplier = await mapper.QueryAsyncForDataTableSession("Supplier.SelectProveedor", info.Code, mapper.Session);
                /* from the select we need to fetch the values 
                  "NOMBRE", "PERSONA", "NIF", "DIRECCION", "POBLACION", "PROV", "CP", "NACIOPER", "NACIODOMI", "TELEFONO", "FAX", 
                 "OBSERVA", "sublicen", "FALTA", "fbaja", "eMail", "INTERNET", "Movil", "COORDGPS", "Oficina"
                */
                /* SELECT NUM_COMI from comisio where NIF = account.Nif */
                DataTable comi = null;
                if (string.IsNullOrEmpty(account.CommissionNumber))
                {
                    comi = await mapper.QueryAsyncForDataTableSession("Supplier.SelectCommisionByNif", account.Nif, mapper.Session);
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
                    retValue = retValue & await mapper.ExecuteUpdateAsyncBatch();
                }
                else
                {
                    mapper.AddBatch(new UpdateCommandTable(tmpSupplier, account.CommissionNumber, "Commission.UpdateCommission"));
                    retValue = retValue & await mapper.ExecuteUpdateAsyncBatch();
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
            if (!environ.IsSet(EnvConfig.CompanyConfiguration, EnvironmentVariables.NoCrearCuentaProvee))
            {
                // ref . CtaCuenta.
                /*
                GetSupplierAccount(_dataMapper, out account);
                */
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
                    IList<SupplierSublicenDataObject> supplierSublicenDataObject = await mapper.QueryAsyncForList<SupplierSublicenDataObject>("Suppliers.GetDifferentSublicen", companyName);
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
                private void GetSupplierAccount(IDataMapper dataMapper, ISupplierAccountObjectInfo account)
                {

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

                #endregion

            }
}
