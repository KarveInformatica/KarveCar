using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataObjects;
using DataAccessLayer.DataObjects;
using Apache.Ibatis.DataMapper;
using Apache.Ibatis.DataMapper.MappedStatements;
using System.Reflection;
using System.Collections.ObjectModel;

namespace DataAccessLayer
{
    class SupplierDataAccessLayer :  ISupplierDataServices
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
            DataTable supplierTable ;
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
        private void SetDataObjectFields<T>(DataRow row, ref  T dataObject)
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

        public void Update(ISupplierDataInfo dataInfo,
                           ISupplierTypeData dataType,
                           ISupplierAccountObjectInfo account,
                           ObservableCollection<ISupplierMonitoringData> monitoring,
                           bool dataContactsChanged,
                           ObservableCollection<ISupplierContactsData> dataContacts)
        {

            IEnviromentVariables environ = _service.GetEnviromentVariables();
            IUserAccessControlList accessControlList = _service.GetAccountManagement();


            if (environ.IsSet("MAPFRE"))
            {
                dataInfo.Name = dataInfo.Name + " " + dataInfo.Surname1 + " " + dataInfo.Surname2;
            }
            dataInfo.Email.Replace("@", "#");
            string name = environ.GetKey("CurrentUser") as string;
            dataInfo.ChangedByUser = name;
            // review this as adaptable with the db.
            dataInfo.LastChange = DateTime.Now.ToString();
            if (environ.IsSet("MRENT"))
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
            if (environ.IsSet("GESTREGDOCUS") && dataContactsChanged)
            {
                throw new SupplierDataServicesAccessModifiedException("Data modified in the contacts");
            }
            // cuenta contable in spanish.
            bool ExpenseAccountChanged = isChangePresentExpenseAccount(account);

            // ask what means icono formulario_id_201. It shall be a configuration enviroment parameter.
            if (environ.IsSet("HERRERO") && environ.IsSet("Icono_Formulario_ID_201"))
            {
                /* select incremento from provee1 where num_provee= 'INCREMENTO' */
            }

            if ((account.TransferAccount.Trim().Length != 0) && (account.IBAN.Trim().Length == 0))
            {
                // SELECT CREAR_IBAN(account.TransferAccount) AS IBAN IBAN.
                account.IBAN = ComputeIBAN(_dataMapper);
                account.SWIFT = ComputeSWIFT(account.IBAN);
                //txtIBAN.Text = getColValueSQL(cSELECT & "CREAR_IBAN(" & setApostrofar(txtCC.Text) & ") AS IBAN", separator, "IBAN")

            }
            if (environ.IsSet("EFECTOS_PROVEE"))
            {
                CreateSupplierAccount();

            }
            _dataMapper.AddBatch(new UpdateCommandObject(dataInfo, dataType, "Suppliers.GetSupplierInfoAndType"));
            _dataMapper.AddBatch(new DeleteCommandObject(dataInfo, "Suppliers.DeleteMonitoring"));
            foreach (ISupplierMonitoringData monitorData in monitoring)
            {
                _dataMapper.AddBatch(new InsertCommandObject(monitorData, "Suppliers.InsertMonitoring"));
            }
            // save other things
            SaveOtherData(environ, _dataMapper);


             
            // save evaluation note
            /*
             */
            // save trans
            /* 
             */
            _dataMapper.ExecuteUpdateAsyncBatch();
            /*

            If txtCC.Text <> "" And txtIBAN.Text = "" Then cmdCalcIban_Click
  On Error GoTo ROLL
  bdBeginTrans
  If GetIntNotNull(DatosConfig(Confi_Emp, "EFECTOS_PROVEE")) <> 0 Then CreaCta
  OK = dbFrmWrite("Provee1", Me, miWhere)
  If OK Then OK = dbFrmWrite("Provee2", Me, miWhere)
  If OK And txtNacioPer.Text <> "" Then OK = dbUpdateTo("Provee1", "NACIODOMI", txtNacioPer.Text, cWHERE & "NUM_PROVEE = '" & Text1.Text & "'")
  If OK Then OK = GuardarSeguimiento
  If OK Then OK = Guardar_Otros
  If OK Then OK = Guardar_EvaluaNota
  If OK Then OK = GuardarTrans
  If OK Then OK = GuardaTipo
  If cE("GEST_DOCVEHI") And OK Then OK = DOCUS.GuardarDocs
  If OK Then GuardaLin


  sNomCta = DameNombreCta


  If GetIntNotNull(DatosConfig(Confi_Emp, "NO_CTA_CONTA_PROVEE")) = 0 Then
    If GetIntNotNull(DatosConfig(Confi_Emp, "CONTAALBPROV")) <> 0 And GetIntNotNull(chk(0).Value) <> 0 Then
      Dim ctapendfac As String, Cols As String, Vals As String
      ctapendfac = "409" & FDer(Right(Text1.Text, NivelCta - 3), "0", NivelCta - 3)
      If Not Existe_en_CU1(ctapendfac, IIf(EmpresaPlanCta <> "", EmpresaPlanCta, EmpresaConectada)) Then
        Cols = "Codigo" & separator & "Descrip" & separator & _
                "ultmodi" & separator & "usuario" & separator & _
                "SUBLICEN" & separator & "Activo"
        Vals = ctapendfac & separator & sNomCta & " FAC.PENDIENTES" & separator & _
              txtUltmodi.Text & separator & TxtUsuario.Text & separator & _
              EmpresaConectada & separator & "P"
        OK = dbInsertTo("Cu1", Cols, Vals)
      Else
        If Not CK("RENTMULTIMEDIA") And TxtNom.Text<> getColValueSQL(cSELECT &"DESCRIP" & cFROM & "cu1" & _
                                cWHERE & "codigo='" & txtContable.Text & "'" & _
                                cAND & "SUBLICEN = '" & IIf(EmpresaPlanCta <> "", EmpresaPlanCta, EmpresaConectada) & "'", separator, "DESCRIP") Then
          OK = dbUpdateTo("CU1", "DESCRIP", sNomCta, cWHERE & "codigo='" & txtContable.Text & "'" & cAND & "SUBLICEN = '" & IIf(EmpresaPlanCta <> "", EmpresaPlanCta, EmpresaConectada) & "'")
        End If
      End If
    End If
    If GetIntNotNull(DatosConfig(Confi_Emp, "EFECTOS_PROVEE")) <> 0 And txtCtaEfecto.Text <> "" Then
      If Not Existe_en_CU1(txtCtaEfecto.Text, EmpresaConectada) Then
        Cols = "Codigo" & separator & "Descrip" & separator & _
                "ultmodi" & separator & "usuario" & separator & _
                "SUBLICEN" & separator & "Activo"
        Vals = txtCtaEfecto.Text & separator & sNomCta & " EFECTOS" & separator & _
              txtUltmodi.Text & separator & TxtUsuario.Text & separator & _
              EmpresaConectada & separator & "P"
        OK = dbInsertTo("Cu1", Cols, Vals)
      End If
     End If
     If OK And bCambioCta Then OK = BorraCtaVieja(CuentaA)
   End If
   If OK Then
      Guardar_Delega_NoTrac Me, Text1.Text, vDelega, "ProDelega"
      Guardar_Contacto_NoTrac Me, Text1.Text, vContacto, "ProContactos"
      Guardar_Visitas_PROV_NoTrac Me, Text1.Text, vVisitas
   End If
   If OK And ExisteProveeDest Then OK = dbUpdateTo("clientes1", "PROVEE_DEST", Text1.Text, cWHERE & "NUMERO_cli = '" & edKCli.Text & "'")
   If Not OK Then
      GoTo ROLL
   Else
      AutoCodigoEliminar
   End If
bdCommitTrans
   GestionaComi
   CargarTrans
   If(GetIntNotNull(DatosConfig(Docs, "HERRERO")) <> 0 And Icono_Formularios_ID = 201) Then
     If dIncr<> GetDoubleNotNull(txtIncr.Text) Then
      ValDivisa = getColValueSQL(cSELECT & "XCONVEURO" & cFROM & "TL_DIVISA" & cWHERE & "CODIGO = '" & edDivisa.Text & "'", separator, "XCONVEURO")
        If ValDivisa = 0 Then ValDivisa = 1
        dIncr = GetDoubleNotNull(txtIncr.Text) / 100
        ExecuteDirect cUPDATE &"TL_RECAMBIO set PRECIO = ((Coste - (Coste * Dto / 100)) * " & Double2StrPunto(ValDivisa, 2) & ") + (((Coste - (Coste * Dto / 100)) * " & Double2StrPunto(ValDivisa, 2) & " * " & Double2StrPunto(dIncr, 2) & "))" & vbNewLine & _
                      cFROM & "TL_PROVRECAMBIO as TPR" & vbNewLine & _
                      cINNER & "TL_RECAMBIO as TRE on TPR.RECAMBIO = TRE.CODIGO" & vbNewLine & _
                      cWHERE & "TPR.PROVEEDOR = '" & Text1.Text & "'"
      End If
   End If
   On Error GoTo 0
   sCtaGastoVieja = TxtCu.Text
   Mensa "DATOS_GUARDADOS"
   TxtModo.Text = edModos.Actualizar
   misCambios = False
   OjoContactos = False
   Exit Sub
ROLL:
            bdRollback
            ErrorsAdoDB
End Sub
*/

        }

        private object ComputeSWIFT(string iBAN)
        {
            throw new NotImplementedException();
        }

        private string ComputeIBAN(IDataMapper mapper)
        {
            throw new NotImplementedException();
        }
        private void SaveTranspProveedores(IEnviromentVariables variableMapping, IDataMapper dataMapper)
        {
/*            Private Function GuardarTrans() As Boolean
  Dim pTr As Integer, Linea As Integer
  Dim OK As Boolean
  Dim codigo As String, Cols As String, Vals As String
  '*==================================================
  If Not(UCase(App.EXEName) = UCase("CarreWin_XP") Or UCase(App.EXEName) = UCase("Rentamaq")) And _
     Not esTaller Then GuardarTrans = True: Exit Function
  quitarLapiz DBTrans
  ExecuteDirect cDELETE &cFROM & "TRANSP_PROVEE" & vbNewLine & _
                cWHERE & "PROVEE = '" & Text1.Text & "'"
  OK = True
  Cols = getColsNamesExclude(vIn(0), separator, "NOMTIPOPEDI", "LINEA")
  For pTr = 1 To lIn
    If Not Columna_Igual_ConWhere("TRANSP_PROVEE", "PROVEE", "PROVEE = '" & Text1.Text & "'" & vbNewLine & _
                                                          cAND & "TIPOPEDI = '" & getColsArrayValue(vIn(0), vIn(pTr), "TIPOPEDI") & "'") Then
      vIn(pTr) = setColsArrayValue(vIn(0), vIn(pTr), "PROVEE", Text1.Text)
      Vals = getColsValuesExclude(vIn(0), vIn(pTr), separator, "NOMTIPOPEDI", "LINEA")
      OK = dbInsertTo("TRANSP_PROVEE", Cols, Vals)
      If Not OK Then Exit For
    End If
  Next pTr
  GuardarTrans = OK
End Function
*/
        }
        private void SaveEvaluationNote(IEnviromentVariables variableMapping, IDataMapper dataMapper)
        {
 /*           Dim iReg  As Integer
 Dim OK As Boolean


  quitarLapiz Me.dbgForma
  ExecuteDirect cDELETE & cFROM & "PROVEE_EVALUANOTA" & vbNewLine & _
                cWHERE & "PROVEE = '" & Text1.Text & "'"
  OK = True
  For iReg = 1 To uboundNotNull(vNota)
    If getColsArrayValue(vNota(0), vNota(iReg), "PROVEE") = "" Then
      vNota(iReg) = setColsArrayValue(vNota(0), vNota(iReg), "PROVEE", Text1.Text)
    End If
    vNota(iReg) = setColsArrayValue(vNota(0), vNota(iReg), "LIN", iReg)
    OK = dbInsertTo("PROVEE_EVALUANOTA", _
              getColsNamesExclude(vNota(0), separator, "ROWS"), _
              getColsValuesExclude(vNota(0), vNota(iReg), separator, "ROWS"))
    If Not OK Then Exit For
  Next iReg
  Guardar_EvaluaNota = OK
*/
        }
        private void SaveOtherData(IEnviromentVariables variableMapping, IDataMapper dataMapper)
        {
            if (variableMapping.isSetCompanyConfig("NO_CTA_CONTA_PROVEE"))
            {
            }

            if (variableMapping.IsSet("NO_CTA_CONTA_PROVEE"))
            {

            }
        }

                        /*
             * Private Function Guardar_Otros() As Boolean
 Dim OK As Boolean
 Dim Cols As String, Vals As String, Cuenta As String
 Dim sNomCta As String
 Dim sNomCta2 As String
 Dim iNoMod As Integer
  '*-------------------------------------------------
   If GetIntNotNull(DatosConfig(Confi_Emp, "NO_CTA_CONTA_PROVEE")) <> 0 Then Guardar_Otros = True: Exit Function
  '*-------------------------------------------------
   OK = True
   If txtContable.Text = "" Then
      If GetIntNotNull(DatosConfig(Confi_Emp, "NOCREAR_CTAPROVEE")) = 0 Then
        CreaCta
      End If
   End If
   Cuenta = Trim(txtContable.Text)
   sNomCta = DameNombreCta
   sNomCta2 = DameNombreCta2
   iNoMod = DameNoMod
   If Cuenta <> "" Then
      If Not Existe_en_CU1(Cuenta, IIf(EmpresaPlanCta <> "", EmpresaPlanCta, EmpresaConectada)) Then
         txtUltmodi.Text = UltimaModi()
         TxtUsuario.Text = UsuarioConectado
         'Guardar en taricli COMPROBAR PARAMETROS
         Cols = "Codigo" & separator & "Descrip" & separator & _
                "ultmodi" & separator & "usuario" & separator & _
                "Activo" & separator & "DESCRIP2" & separator & "SUBLICEN"
         Vals = Trim(Cuenta) & separator & sNomCta & separator & _
                txtUltmodi.Text & separator & TxtUsuario.Text & separator & _
                "P" & separator & sNomCta2 & separator
'         If Text2.Text <> "" Then
'
'         End If
         
         Dim RET As String
         Dim i As Integer
         If GetIntNotNull(DatosConfig(Docs, "PROVE_COMUN")) = 1 Then
            RET = getColValueSQL(cSELECT & "list(codigo) codigo" & cFROM & "sublicen", ",", "codigo")
            For i = 1 To getCols(RET, ",")
              If Not Existe_en_CU1(Cuenta, Piece(RET, ",", i)) Then
                OK = dbInsertTo("Cu1", Cols, Vals & Piece(RET, ",", i))
              End If
            Next i
         Else
            OK = dbInsertTo("Cu1", Cols, Vals & IIf(EmpresaPlanCta <> "", EmpresaPlanCta, EmpresaConectada))
            If OK Then OK = CreaCtaEmpsProv(Cols, Trim(Cuenta), sNomCta, Text2.Text, IIf(EmpresaPlanCta <> "", EmpresaPlanCta, EmpresaConectada), "P")
         End If
      Else
        If iNoMod = 0 Then
          If Not CK("RENTMULTIMEDIA") And sNomCta <> getColValueSQL(cSELECT & "DESCRIP" & cFROM & "cu1" & _
                                  cWHERE & "codigo='" & Trim(Cuenta) & "'" & _
                                  cAND & "SUBLICEN = '" & IIf(EmpresaPlanCta <> "", EmpresaPlanCta, EmpresaConectada) & "'", separator, "DESCRIP") Then
            OK = dbUpdateTo("CU1", "DESCRIP", sNomCta, cWHERE & "codigo='" & Trim(Cuenta) & "'" & cAND & "SUBLICEN = '" & IIf(EmpresaPlanCta <> "", EmpresaPlanCta, EmpresaConectada) & "'")
          End If
          If sNomCta2 <> "" And Text2.Text <> getColValueSQL(cSELECT & "DESCRIP2" & cFROM & "cu1" & _
                                  cWHERE & "codigo='" & Trim(Cuenta) & "'" & _
                                cAND & "SUBLICEN = '" & IIf(EmpresaPlanCta <> "", EmpresaPlanCta, EmpresaConectada) & "'", separator, "DESCRIP2") Then
            OK = dbUpdateTo("CU1", "DESCRIP2", sNomCta2, cWHERE & "codigo='" & Trim(Cuenta) & "'" & cAND & "SUBLICEN = '" & IIf(EmpresaPlanCta <> "", EmpresaPlanCta, EmpresaConectada) & "'")
          End If
        End If
      End If
    End If
    Guardar_Otros = OK
End Function
*/
       

        private void CreateSupplierAccount()
        {
            throw new NotImplementedException();
        }

        

        private string ComputeIBAN()
        {
            throw new NotImplementedException();
        }

        private bool isChangePresentExpenseAccount(ISupplierAccountObjectInfo account)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsycResult(ISupplierDataInfo supplierDataInfo,
                                           ISupplierEvaluationNoteData evaluationNodeData,
                                           ISupplierBranchesData supplierDataBranches
                                           )
        {
            return null;
        }
        public void UpdateDataObject(object dataObject)
        {
            if (dataObject != null)
            {
                
            }
        }

        public void UpdateDataSet(DataSet set)
        {
            throw new NotImplementedException();
        }

        public void InsertDataObject(object dataObject)
        {
            throw new NotImplementedException();
        }

        public void InsertDataSet(DataSet set)
        {
            throw new NotImplementedException();
        }




        #endregion

    }
}
