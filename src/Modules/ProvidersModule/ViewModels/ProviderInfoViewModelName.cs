using System;
using KarveCommon.Services;
using KarveDataServices;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using KarveControls.UIObjects;
using System.Threading.Tasks;
<<<<<<< HEAD
using System.Windows.Media;
using KarveControls;
using ProvidersModule.Common;
=======
using KarveControls;
>>>>>>> ff924997e4831d843f6c7f8514a59cb51345c3a3

namespace ProvidersModule.ViewModels
{
    class ProviderInfoViewModel : BindableBase, IEventObserver
    {
        private ObservableCollection<IUiObject> _upperPartObservableCollection = new ObservableCollection<IUiObject>();
        private ObservableCollection<IUiObject> _middlePartObservableCollection = new ObservableCollection<IUiObject>();
        private ObservableCollection<IUiObject> _headerObservableCollection = new ObservableCollection<IUiObject>();
        private ObservableCollection<IUiObject> _accountLeftCollection = new ObservableCollection<IUiObject>();
        private ObservableCollection<IUiObject> _accountRightCollection = new ObservableCollection<IUiObject>();
        private ObservableCollection<IUiObject> _accountLeftCheckBoxes = new ObservableCollection<IUiObject>();
        private ObservableCollection<IUiObject> _accountRightCheckBoxes = new ObservableCollection<IUiObject>();
        private ObservableCollection<IUiObject> _paymentDirectionCollection = new ObservableCollection<IUiObject>();

        private static string[] UpperPartLabel =
        {
            Properties.Resources.ProviderInfoViewModel_Numero,
            Properties.Resources.ProviderInfoViewModel_NombreCommercial,
            Properties.Resources.ProviderInfoViewModel_NIF,
            Properties.Resources.ProviderInfoViewModel_TipoProv
        };

        private static string[] LeftPartLabel =
        {
            Properties.Resources.ProviderInfoViewModel_Nombre,
            Properties.Resources.ProviderInfoViewModel_NIF,
            Properties.Resources.ProviderInfoViewModel_LoadLeftPart_Dirección,
            Properties.Resources.ProviderInfoViewModel_Dirección2,
            Properties.Resources.ProviderInfoViewModel_LoadLeftPart_CP,
            Properties.Resources.ProviderInfoViewModel_Población,
            Properties.Resources.ProviderInfoViewModel_LoadLeftPart_Provincia,
            Properties.Resources.ProviderInfoViewModel_LoadLeftPart_Pais,
            Properties.Resources.ProviderInfoViewModel_Teléfono,
            Properties.Resources.ProviderInfoViewModel_Fax,
            Properties.Resources.ProviderInfoViewModel_Móvil,
            Properties.Resources.ProviderInfoViewModel_Email,
            Properties.Resources.ProviderInfoViewModel_Web,
            Properties.Resources.ProviderInfoViewModel_Contacto,
            Properties.Resources.ProviderInfoViewModel_Empresa,
            Properties.Resources.ProviderInfoViewModel_Oficina,
            "Fecha de Baja",
            "Fecha de Alta",
            "Notas",
            "Observaciones"
        };

        private string[] UpperPartFields =
        {
            "NUM_PROVEE", "COMERCIAL", "TIPO"
        };

        private string[] LeftPartFields =
        {
            "NOMBRE", "NIF", "DIRECCION", "DIREC2" ,"CP", "POBLACION", "PROV", "NACIOPER", "TELEFONO", "FAX", "MOVIL", "EMAIL",
            "INTERNET", "PERSONA", "SUBLICEN", "OFICINA", "FBAJA", "FALTA", "NOTAS", "OBSERVA"
        };
        private string[] ContableUpperParts ={
            "NOMBRE", "NIF", "TIPO"
         };

        private string[] AccountLeftCheckBoxField =
        {
            "PALBARAN", "INTRACO", "GESTION_IVA_IMPORTA", "NOAUTOMARGEN"
        };

        private string[] TableLeftCheckBox =
        {
            "PROVEE2","PROVEE2","PROVEE1","PROVEE1"
        };
        private string[] AccountLeftCheckBoxNames =
        {
            "Gestión de albaranes", "Es Intracomunitario", "Gestionar IVA Importación", "Margen No Automatico"
        };

        private string[] AccountRightCheckBoxField =
        {
            "PROALB_COSTE_TRANSP", "EXENCIONES_INT", "AUTOFAC_MANTE"
        };

        private string[] TableRightCheckBox =
        {
            "PROVEE1", "PROVEE1", "PROVEE1"
        };
        private string[] AccountRightCheckBoxNames =
        {
          "Albaranes Coste Transporte", "Exenciones en Op.Interiores", "Generar Autofactura de Mantenimiento"
        };

<<<<<<< HEAD
        /// <summary>
        ///  This works in case of insert/update.
        /// </summary>
        private IDictionary<DataPayLoad.Type, IUiComponentChangeHandler> _changeHandlers =
            new Dictionary<DataPayLoad.Type, IUiComponentChangeHandler>
            {
                { DataPayLoad.Type.Insert, new InsertChangeHandler() },
                { DataPayLoad.Type.Update, new InsertChangeHandler() }
            };
   
            private const string ProviderInfoVm = "ProviderInfoViewModel";
=======
        private const string ProviderInfoVm = "ProviderInfoViewModel";
>>>>>>> ff924997e4831d843f6c7f8514a59cb51345c3a3
        private const string ImagePath = "/ProvidersModule;component/Images/search.png";
        private const string EmailImagePath = "/ProvidersModule;component/Images/email.png";

        private const string TipoProve = "TIPO_PROVE";
        private const string PaisKey = "NACIOPER";
        private const string TextboxHeight = "20";
        private const string LabelTextWidthDefault = "100";
        private const string TextBoxWidthSmall = "50";
        private const string TextBoxWidthDefault = "200";
        private const string TextBoxWidthLarge = "300";
        private const string TextBoxWidthWide = "400";
        private const string ProvinceKey = "PROV";
        private const string ProvinceComponentKey = "PROVINCE";
        private const string ZipKey = "SIGLAS";
        private const string PaisComponentKey = "PAIS";
<<<<<<< HEAD
        private bool insertOperation = false;
        
=======

>>>>>>> ff924997e4831d843f6c7f8514a59cb51345c3a3
        // This is the event manager for communicating with the toolbar and other view modules inside the provider Module.
        private readonly IEventManager _eventManager;

        private readonly IDataServices _dataServices;
<<<<<<< HEAD
        private MailBoxMessageHandler _messageHandler;
=======
        private readonly MailBoxMessageHandler _messageHandler;
>>>>>>> ff924997e4831d843f6c7f8514a59cb51345c3a3
        private readonly IDictionary<string, object> _componentsObjects = new Dictionary<string, object>();

        private IConfigurationService _configurationService;
        private DataSet _currentDataSet = new DataSet();
        private DataSet _assistantDataSet = new DataSet();
        private IDictionary<string, string> _viewModelQueries = new Dictionary<string, string>();
        private IDictionary<string, string> _viewModelAssitantQueries = new Dictionary<string, string>();

        private NotifyTaskCompletion<IList<DataSet>> _initializationTable;
        private DataSet _delegationSet;
        private DataTable _delegationDataTable;
<<<<<<< HEAD
        private DataPayLoad.Type _currentOperationalState;
        private string _primaryKeyValue = "";
=======

>>>>>>> ff924997e4831d843f6c7f8514a59cb51345c3a3
        public ProviderInfoViewModel(IEventManager eventManager, IConfigurationService configurationService,
            IDataServices dataServices)
        {
            _dataServices = dataServices;
            _configurationService = configurationService;
<<<<<<< HEAD
        
            _messageHandler += MessageHandler;

            _eventManager = eventManager;


            _eventManager.registerObserverSubsystem(ProviderModule.NAME, this);
           
        }

        private void MessageHandler(DataPayLoad load)
        {
            // here is coming the data from another view module
        }

        private void SetItemSourceTable(DataSet set, ref ObservableCollection<IUiObject> uiDfObjects)
        {
            IDictionary<string, DataTable> tablesByNameDictionary = BuildDictionaryFromDataSet(set);
            int count = 0;
            if (uiDfObjects.Count == 0)
                return;
            // now i have to check the uiDfObjects
            foreach (IUiObject uiObject in uiDfObjects)
            {

                DataTable table = null;
                if (tablesByNameDictionary.ContainsKey(uiObject.TableName))
                {
                    table = tablesByNameDictionary[uiObject.TableName];
                    uiObject.ItemSource = table;
                    if (uiObject is UiDoubleDfObject)
                    {
                        UiDoubleDfObject valDoubleDfObject = (UiDoubleDfObject)uiObject;
                        valDoubleDfObject.ItemSource = table;
                        valDoubleDfObject.ItemSourceRight = table;
                    }
                }
                if (uiObject is UiMultipleDfObject)
                {
                    UiMultipleDfObject box = (UiMultipleDfObject)uiObject;
                    IList<string> tableNames = box.Tables;
                    if (tableNames != null)
                    {
                        foreach (string tableName in tableNames)
                        {
                            box.SetItemSource(tablesByNameDictionary[tableName], tableName);
                        }
                    }
                }
                // this trigger a change
                

            }
            triggerRefresh(ref uiDfObjects);

        }

        private void triggerRefresh(ref ObservableCollection<IUiObject> uiDfObjects)
        {
            int count = 0;
            for (int i = 0; i < uiDfObjects.Count; ++i)
            {
                IUiObject tmp = uiDfObjects[count];
                uiDfObjects.RemoveAt(count);
                uiDfObjects.Insert(count, tmp);
                count++;
=======
            _messageHandler += MessageHandler;
            _eventManager = eventManager;
            _eventManager.registerObserverSubsystem(ProviderModule.NAME, this);
            _eventManager.RegisterMailBox(ProviderInfoViewModel.ProviderInfoVm, _messageHandler);
        }

        private void MessageHandler(DataPayLoad load)
        {
            // here is coming the data from another view module
        }

        private void SetItemSourceTable(DataSet set, ref ObservableCollection<IUiObject> uiDfObjects)
        {
            IDictionary<string, DataTable> tablesByNameDictionary = BuildDictionaryFromDataSet(set);

            // now i have to check the uiDfObjects
            foreach (IUiObject uiObject in uiDfObjects)
            {
                DataTable table = null;
                if (tablesByNameDictionary.ContainsKey(uiObject.TableName))
                {
                    table = tablesByNameDictionary[uiObject.TableName];
                    uiObject.ItemSource = table;
                    if (uiObject is UiDoubleDfObject)
                    {
                        UiDoubleDfObject valDoubleDfObject = (UiDoubleDfObject)uiObject;
                        valDoubleDfObject.ItemSource = table;
                        valDoubleDfObject.ItemSourceRight = table;
                    }
                }
                if (uiObject is UiMultipleDfObject)
                {
                    UiMultipleDfObject box = (UiMultipleDfObject)uiObject;
                    IList<string> tableNames = box.Tables;
                    if (tableNames != null)
                    {
                        foreach (string tableName in tableNames)
                        {
                            box.SetItemSource(tablesByNameDictionary[tableName], tableName);
                        }
                    }
                }
                

>>>>>>> ff924997e4831d843f6c7f8514a59cb51345c3a3
            }
        }
        private void SetSourceViewTable(DataSet sourceView, ref ObservableCollection<IUiObject> uiDfObjects)
        {
            IDictionary<string, DataTable> tablesByNameDictionary = BuildDictionaryFromDataSet(sourceView);
<<<<<<< HEAD
            if (uiDfObjects.Count == 0)
                return;
            int count = 0;
            foreach (IUiObject uiObject in uiDfObjects)
            {

                if (uiObject is UiMultipleDfObject)
                {
                    UiMultipleDfObject box = (UiMultipleDfObject) uiObject;
=======
            foreach (IUiObject uiObject in uiDfObjects)
            {
                if (uiObject is UiMultipleDfObject)
                {
                    UiMultipleDfObject box = (UiMultipleDfObject)uiObject;
>>>>>>> ff924997e4831d843f6c7f8514a59cb51345c3a3
                    IList<string> assistTables = box.AssistTables;
                    if (assistTables != null)
                    {
                        foreach (string tableName in assistTables)
                        {
                            if (tablesByNameDictionary.ContainsKey(tableName))
                            {
                                box.SetSourceView(tablesByNameDictionary[tableName], tableName);
                            }
                        }
                    }
                }
                if (uiObject is UiDualDfSearchTextObject)
                {
<<<<<<< HEAD
                    UiDualDfSearchTextObject box = (UiDualDfSearchTextObject) uiObject;
=======
                    UiDualDfSearchTextObject box = (UiDualDfSearchTextObject)uiObject;
>>>>>>> ff924997e4831d843f6c7f8514a59cb51345c3a3
                    if (tablesByNameDictionary.ContainsKey(box.AssistTableName))
                    {
                        box.SourceView = tablesByNameDictionary[box.AssistTableName];
                    }
                }
<<<<<<< HEAD

=======
>>>>>>> ff924997e4831d843f6c7f8514a59cb51345c3a3
            }
           triggerRefresh(ref uiDfObjects);
        }
        private IDictionary<string, DataTable> BuildDictionaryFromDataSet(DataSet set)
        {
            IDictionary<string, DataTable> tablesByNameDictionary = new Dictionary<string, DataTable>();
            foreach (DataTable t in set.Tables)
            {
                tablesByNameDictionary.Add(t.TableName, t);
            }
            return tablesByNameDictionary;

        }

        private void InitializationTableOnPropertyChanged(object sender,
            PropertyChangedEventArgs propertyChangedEventArgs)
        {
            IList<DataSet> setResult = _initializationTable.Result;

            if (setResult.Count < 2)
            {
                _currentDataSet = setResult[0];
            }
            else
            {
                _currentDataSet = setResult[0];
                _assistantDataSet = setResult[1];
            }
<<<<<<< HEAD
=======
            IDictionary<string, DataTable> currentDataTables = new Dictionary<string, DataTable>();
>>>>>>> ff924997e4831d843f6c7f8514a59cb51345c3a3
            if (_initializationTable.IsSuccessfullyCompleted)
            {


               SetItemSourceTable(_currentDataSet, ref _upperPartObservableCollection);
               SetItemSourceTable(_currentDataSet, ref _middlePartObservableCollection);
               SetItemSourceTable(_currentDataSet, ref _accountRightCollection);
               SetItemSourceTable(_currentDataSet, ref _accountLeftCollection);
               SetItemSourceTable(_currentDataSet, ref _accountLeftCheckBoxes);
               SetItemSourceTable(_currentDataSet, ref _accountRightCheckBoxes);

                if (_assistantDataSet.Tables.Count > 0)
                {
                    SetSourceViewTable(_assistantDataSet, ref _upperPartObservableCollection);
                    SetSourceViewTable(_assistantDataSet, ref _middlePartObservableCollection);
                    SetSourceViewTable(_assistantDataSet, ref _accountRightCollection);
                    SetSourceViewTable(_assistantDataSet, ref _accountLeftCollection);

                }
            }
<<<<<<< HEAD

           

=======
>>>>>>> ff924997e4831d843f6c7f8514a59cb51345c3a3
            UpperValueCollection = _upperPartObservableCollection;
            MiddleValueCollection = _middlePartObservableCollection;
            AccountRightCollection = _accountRightCollection;
            AccountLeftCollection = _accountLeftCollection;
            RightCheckBoxesCollection = _accountRightCheckBoxes;
            LeftCheckBoxesCollection = _accountLeftCheckBoxes;
<<<<<<< HEAD
        }

      
        public DataTable DelegationTable
        {
            get { return _delegationDataTable; }
            set { _delegationDataTable = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<IUiObject> HeaderValueCollection
        {
=======
        }

      
        public DataTable DelegationTable
        {
            get { return _delegationDataTable; }
            set { _delegationDataTable = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<IUiObject> HeaderValueCollection
        {
>>>>>>> ff924997e4831d843f6c7f8514a59cb51345c3a3
            get { return _headerObservableCollection; }
            set
            {
                _headerObservableCollection = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<IUiObject> MiddleValueCollection
        {
            get { return _middlePartObservableCollection; }
            set
            {
                _middlePartObservableCollection = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<IUiObject> AccountLeftCollection
        {
            get { return _accountLeftCollection; }
            set
            {
                _accountLeftCollection = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<IUiObject> AccountRightCollection
        {
            get { return _accountRightCollection; }
            set
            {
                _accountRightCollection = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<IUiObject> RightCheckBoxesCollection
        {
            get { return _accountRightCheckBoxes; }
            set { _accountRightCheckBoxes = value; RaisePropertyChanged();}
        }
        public ObservableCollection<IUiObject> LeftCheckBoxesCollection
        {
            get { return _accountLeftCheckBoxes; }
            set { _accountRightCheckBoxes = value; RaisePropertyChanged();}
        }
        // this load all the ui objects that are needed to match the fields with data.
        private void LoadUIObjects()
        {
            LoadUpperPart();
            LoadLeftPart();
            LoadAccountHeader();
            LoadAccountLeft();
            LoadAccountRight(AssistQueryRequestHandler, OnChangedField);
            LoadAccountCheckBoxes();
            LoadPaymentDirections(AssistQueryRequestHandler, OnChangedField);
        }

        private void LoadPaymentDirections(UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery,
            UiDfObject.ChangedField changedField)
        {
            UiDfObject direccionDePago = new UiDfObject("Direccion", LabelTextWidthDefault);
            direccionDePago.DataField = "DIR_PAGO";
            direccionDePago.TableName = "PROVEE1";
            direccionDePago.LabelTextWidth = LabelTextWidthDefault;
            direccionDePago.LabelVisible = true;
            direccionDePago.Height = TextboxHeight;
            direccionDePago.TextContentWidth = "50";
            direccionDePago.OnChangedField += changedField;
            direccionDePago.ItemSource = new DataTable();
            direccionDePago.PrimaryKey = "NUM_PROVEE";
            direccionDePago.AllowedEmpty = true;
            _paymentDirectionCollection.Add(direccionDePago);
            UiDfObject direccionDePago1 = new UiDfObject("Direccion 2", LabelTextWidthDefault);
            direccionDePago1.DataField = "DIR_PAGO";
            direccionDePago1.TableName = "PROVEE1";
            direccionDePago1.LabelTextWidth = LabelTextWidthDefault;
            direccionDePago1.LabelVisible = true;
            direccionDePago1.Height = TextboxHeight;
            direccionDePago1.TextContentWidth = "50";
            direccionDePago1.OnChangedField += changedField;
            direccionDePago1.ItemSource = new DataTable();
            direccionDePago1.PrimaryKey = "NUM_PROVEE";
            direccionDePago1.AllowedEmpty = true;
            _paymentDirectionCollection.Add(direccionDePago);
            UiDualDfSearchTextObject dualDfSearch = new UiDualDfSearchTextObject("CP",LabelTextWidthDefault);
            dualDfSearch.DataFieldFirst = "CP";
            dualDfSearch.ButtonImage = ImagePath;
            dualDfSearch.TableName = "PROVEE1";
            dualDfSearch.AssistDataFieldFirst = "CP";
            dualDfSearch.AssistDataFieldSecond = "POBLACION";
            dualDfSearch.AssistTableName = "PROVEE1";
            dualDfSearch.Height = TextboxHeight;
            dualDfSearch.TextContentFirstWidth = TextBoxWidthSmall;
            dualDfSearch.TextContentSecondWidth = TextBoxWidthLarge;
            dualDfSearch.SourceView = new DataTable();
            dualDfSearch.ItemSource = new DataTable();
            dualDfSearch.PrimaryKey = "NUM_PROVEE";
            dualDfSearch.OnChangedField += OnChangedField;
            dualDfSearch.OnAssistQuery += AssistQueryRequestHandler;
            UiDualDfSearchTextObject provDfSearchTextObject = new UiDualDfSearchTextObject("Provincia", LabelTextWidthDefault);
            provDfSearchTextObject.DataFieldFirst = "PROV";
            provDfSearchTextObject.ButtonImage = ImagePath;
            provDfSearchTextObject.TableName = "PROVEE1";
            provDfSearchTextObject.AssistDataFieldFirst = "CP";
           
        }
        private void LoadReclamationsDirections(UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery,
            UiDfObject.ChangedField changedField)
        {

        }
<<<<<<< HEAD
        private void Init(string primaryKeyValue, bool insert)
        {
            LoadUIObjects();
            _initializationTable = new NotifyTaskCompletion<IList<DataSet>>(LoadDataValue(primaryKeyValue, insert));
=======
        private void Init(string primaryKeyValue)
        {
            LoadUIObjects();
            _initializationTable = new NotifyTaskCompletion<IList<DataSet>>(LoadDataValue(primaryKeyValue));
>>>>>>> ff924997e4831d843f6c7f8514a59cb51345c3a3
            _initializationTable.PropertyChanged += InitializationTableOnPropertyChanged;
        }

        private void LoadAccountCheckBoxes()
        {
            for (int i = 0; i < AccountLeftCheckBoxField.Length; ++i)
            {
                UiDataFieldCheckBox uiDataFieldCheck = new UiDataFieldCheckBox();
                uiDataFieldCheck.DataField = AccountLeftCheckBoxField[i];
                uiDataFieldCheck.ItemSource = new DataTable();
                uiDataFieldCheck.OnChangedField += OnChangedField;
                uiDataFieldCheck.TableName = TableLeftCheckBox[i];
                uiDataFieldCheck.TextContentWidth = TextBoxWidthDefault;
                uiDataFieldCheck.LabelVisible = true;
                uiDataFieldCheck.Height = TextboxHeight;
                uiDataFieldCheck.PrimaryKey = "NUM_PROVEE";
                uiDataFieldCheck.Content = AccountLeftCheckBoxNames[i];
                uiDataFieldCheck.AllowedEmpty = true;
                uiDataFieldCheck.IsReadOnly = false;
                _accountLeftCheckBoxes.Add(uiDataFieldCheck);
            }
            for (int i = 0; i < AccountRightCheckBoxField.Length; ++i)
            {
                UiDataFieldCheckBox uiDataFieldCheck = new UiDataFieldCheckBox();
                uiDataFieldCheck.DataField = AccountRightCheckBoxField[i];
                uiDataFieldCheck.ItemSource = new DataTable();
                uiDataFieldCheck.OnChangedField += OnChangedField;
                uiDataFieldCheck.TableName = TableRightCheckBox[i];
                uiDataFieldCheck.Content = AccountRightCheckBoxNames[i];
                uiDataFieldCheck.LabelVisible = true;
                uiDataFieldCheck.Height = TextboxHeight;
                uiDataFieldCheck.TextContentWidth = TextBoxWidthDefault;
                uiDataFieldCheck.PrimaryKey = "NUM_PROVEE";
                uiDataFieldCheck.AllowedEmpty = true;
                uiDataFieldCheck.IsReadOnly = false;
                _accountRightCheckBoxes.Add(uiDataFieldCheck);
            }
        }


        private void LoadAccountLeft()
        {
            UiGroupBoxMultipleObject cuentasBoxMultipleObject = new UiGroupBoxMultipleObject();
            cuentasBoxMultipleObject.GroupBoxTitle = "Cuentas";
            
            UiMultipleDfObject accountDfObject1 = new UiMultipleDfObject();
            UiDfObject prefixDfObject = new UiDfObject("Prefijo", LabelTextWidthDefault);
            prefixDfObject.DataField = "PREFIJO";
            prefixDfObject.TableName = "PROVEE2";
            prefixDfObject.LabelVisible = true;
            prefixDfObject.Height = TextboxHeight;
            prefixDfObject.TextContentWidth = TextBoxWidthSmall;
            prefixDfObject.OnChangedField += OnChangedField;
            prefixDfObject.PrimaryKey = "NUM_PROVEE";
            prefixDfObject.AllowedEmpty = true;
            prefixDfObject.ItemSource = new DataTable();
            accountDfObject1.AddDataField(prefixDfObject);
            
            
          /*
            UiDfObject balance = new UiDfObject("Saldo", LabelTextWidthDefault);
            balance.DataField = "";
            balance.TableName = "";
            prefixDfObject.LabelVisible = true;
            prefixDfObject.Height = TextboxHeight;
            prefixDfObject.TextContentWidth = TextBoxWidthSmall;
            prefixDfObject.OnChangedField += OnChangedField;
            prefixDfObject.PrimaryKey = "NUM_PROVEE";
            prefixDfObject.AllowedEmpty = true;
            prefixDfObject.ItemSource = new DataTable();
            accountDfObject1.AddDataField(balance);
          */
            UiDualDfSearchTextObject cuentaContable = new UiDualDfSearchTextObject("Cuenta Contable", LabelTextWidthDefault);
            cuentaContable.DataFieldFirst = "CONTABLE";
            cuentaContable.TableName = "PROVEE2";
            cuentaContable.AssistTableName = "CU1";
            cuentaContable.AssistDataFieldFirst = "CODIGO";
            cuentaContable.AssistDataFieldSecond = "DESCRIP";
            cuentaContable.Height = TextboxHeight;
            cuentaContable.TextContentFirstWidth = TextBoxWidthSmall;
            cuentaContable.TextContentSecondWidth = TextBoxWidthLarge;
            cuentaContable.SourceView = new DataTable();
            cuentaContable.ItemSource = new DataTable();
            cuentaContable.PrimaryKey = "NUM_PROVEE";
            cuentaContable.OnChangedField += OnChangedField;
            cuentaContable.ButtonImage = ImagePath;
            cuentaContable.DataField = "CONTABLE";
            cuentaContable.OnAssistQuery += AssistQueryRequestHandler;
            accountDfObject1.AddDataField(cuentaContable);
            _accountLeftCollection.Add(accountDfObject1);

            UiDualDfSearchTextObject cuentaGasto = new UiDualDfSearchTextObject("Cuenta Gasto", LabelTextWidthDefault);
            cuentaGasto.DataFieldFirst = "CUGASTO";
            cuentaGasto.TableName = "PROVEE2";
            cuentaGasto.AssistTableName = "CU1";
            cuentaGasto.AssistDataFieldFirst = "CODIGO";
            cuentaGasto.AssistDataFieldSecond = "DESCRIP";
            cuentaGasto.Height = TextboxHeight;
            cuentaGasto.TextContentFirstWidth = TextBoxWidthSmall;
            cuentaGasto.TextContentSecondWidth = TextBoxWidthLarge;
            cuentaGasto.SourceView = new DataTable();
            cuentaGasto.ItemSource = new DataTable();
            cuentaGasto.PrimaryKey = "NUM_PROVEE";
            cuentaGasto.OnChangedField += OnChangedField;
            cuentaGasto.ButtonImage = ImagePath;
            cuentaGasto.DataField = "CONTABLE";
            cuentaGasto.OnAssistQuery += AssistQueryRequestHandler;
            
            _accountLeftCollection.Add(cuentaGasto);
            // cuenta retencion
            UiDualDfSearchTextObject retentionAccount = new UiDualDfSearchTextObject("Cuenta Retencion", LabelTextWidthDefault);
            retentionAccount.DataFieldFirst = "RETENCION";
            retentionAccount.TableName = "PROVEE2";
            retentionAccount.AssistTableName = "CU1";
            retentionAccount.AssistDataFieldFirst = "CODIGO";
            retentionAccount.AssistDataFieldSecond = "DESCRIP";
            retentionAccount.Height = TextboxHeight;
            retentionAccount.TextContentFirstWidth = TextBoxWidthSmall;
            retentionAccount.TextContentSecondWidth = TextBoxWidthLarge;
            retentionAccount.SourceView = new DataTable();
            retentionAccount.ItemSource = new DataTable();
            retentionAccount.PrimaryKey = "NUM_PROVEE";
            retentionAccount.OnChangedField += OnChangedField;
            retentionAccount.ButtonImage = ImagePath;
            retentionAccount.DataField = "CONTABLE";
            retentionAccount.OnAssistQuery += AssistQueryRequestHandler;
            
            _accountLeftCollection.Add(retentionAccount);
            // cuenta pago
            UiDualDfSearchTextObject cuentaPago = new UiDualDfSearchTextObject("Cuenta Pago", LabelTextWidthDefault);
            cuentaPago.DataFieldFirst = "CTAPAGO";
            cuentaPago.TableName = "PROVEE1";
            cuentaPago.AssistTableName = "CU1";
            cuentaPago.AssistDataFieldFirst = "CODIGO";
            cuentaPago.AssistDataFieldSecond = "DESCRIP";
            cuentaPago.Height = TextboxHeight;
            cuentaPago.TextContentFirstWidth = TextBoxWidthSmall;
            cuentaPago.TextContentSecondWidth = TextBoxWidthLarge;
            cuentaPago.SourceView = new DataTable();
            cuentaPago.ItemSource = new DataTable();
            cuentaPago.PrimaryKey = "NUM_PROVEE";
            cuentaPago.OnChangedField += OnChangedField;
            cuentaPago.ButtonImage = ImagePath;
            cuentaPago.DataField = "CTAPAGO";
            cuentaPago.OnAssistQuery += AssistQueryRequestHandler;
            _accountLeftCollection.Add(cuentaPago);

            // cuenta cp / cuenta lp
            
            UiGroupBoxMultipleObject leasingBoxMultipleObject = new UiGroupBoxMultipleObject();
            leasingBoxMultipleObject.GroupBoxTitle = "Leasing";

            UiDualDfSearchTextObject cuentaCp = new UiDualDfSearchTextObject("Cuenta C/P", LabelTextWidthDefault);
            cuentaCp.DataFieldFirst = "CTACP";
            cuentaCp.TableName = "PROVEE1";
            cuentaCp.AssistTableName = "CU1";
            cuentaCp.AssistDataFieldFirst = "CODIGO";
            cuentaCp.AssistDataFieldSecond = "DESCRIP";
            cuentaCp.Height = TextboxHeight;
            cuentaCp.TextContentFirstWidth = TextBoxWidthSmall;
            cuentaCp.TextContentSecondWidth = TextBoxWidthLarge;
            cuentaCp.SourceView = new DataTable();
            cuentaCp.ItemSource = new DataTable();
            cuentaCp.PrimaryKey = "NUM_PROVEE";
            cuentaCp.OnChangedField += OnChangedField;
            cuentaCp.ButtonImage = ImagePath;
            cuentaCp.DataField = "CTACP";
            cuentaCp.OnAssistQuery += AssistQueryRequestHandler;
            //leasingBoxMultipleObject.AddDataField(cuentaCp);
            _accountLeftCollection.Add(cuentaCp);

            UiDualDfSearchTextObject cuentaLp = new UiDualDfSearchTextObject("Cuenta C/P", LabelTextWidthDefault);
            cuentaLp.DataFieldFirst = "CTALP";
            cuentaLp.TableName = "PROVEE1";
            cuentaLp.AssistTableName = "CU1";
            cuentaLp.AssistDataFieldFirst = "CODIGO";
            cuentaLp.AssistDataFieldSecond = "DESCRIP";
            cuentaLp.Height = TextboxHeight;
            cuentaLp.TextContentFirstWidth = TextBoxWidthSmall;
            cuentaLp.TextContentSecondWidth = TextBoxWidthLarge;
            cuentaLp.SourceView = new DataTable();
            cuentaLp.ItemSource = new DataTable();
            cuentaLp.PrimaryKey = "NUM_PROVEE";
            cuentaLp.OnChangedField += OnChangedField;
            cuentaLp.ButtonImage = ImagePath;
            cuentaLp.DataField = "CTALP";
            cuentaLp.OnAssistQuery += AssistQueryRequestHandler;
            leasingBoxMultipleObject.AddDataField(cuentaLp);
            _accountLeftCollection.Add(cuentaLp);


            // checkbox
            UiDataFieldCheckBox uiDataFieldCheck = new UiDataFieldCheckBox();
            uiDataFieldCheck.TableName = "PROVEE1";
            uiDataFieldCheck.DataField = "PROVEELEAS";
            uiDataFieldCheck.ItemSource = new DataTable();
            uiDataFieldCheck.OnChangedField += OnChangedField;
            uiDataFieldCheck.TextContentWidth = TextBoxWidthDefault;
            uiDataFieldCheck.LabelVisible = true;
            uiDataFieldCheck.Height = TextboxHeight;
            uiDataFieldCheck.PrimaryKey = "NUM_PROVEE";
            uiDataFieldCheck.Content = "";
            uiDataFieldCheck.AllowedEmpty = true;
            uiDataFieldCheck.IsReadOnly = false;
            // checkbox1
            UiDataFieldCheckBox uiDataFieldCheck1 = new UiDataFieldCheckBox();
            uiDataFieldCheck.TableName = "PROVEE1";
            uiDataFieldCheck.DataField = "PROVEELEAS";
            uiDataFieldCheck.ItemSource = new DataTable();
            uiDataFieldCheck.OnChangedField += OnChangedField;
            uiDataFieldCheck.TextContentWidth = TextBoxWidthDefault;
            uiDataFieldCheck.LabelVisible = true;
            uiDataFieldCheck.Height = TextboxHeight;
            uiDataFieldCheck.PrimaryKey = "NUM_PROVEE";
            uiDataFieldCheck.Content = "Es proveedor de leasing";
            uiDataFieldCheck.AllowedEmpty = true;
            uiDataFieldCheck.IsReadOnly = false;
            _accountLeftCollection.Add(uiDataFieldCheck);

            UiGroupBoxMultipleObject intacoBoxMultipleObject = new UiGroupBoxMultipleObject();
            intacoBoxMultipleObject.GroupBoxTitle = "Intracomunitario";
            UiDualDfSearchTextObject cuentaSoportado = new UiDualDfSearchTextObject("Cta.Soportado", LabelTextWidthDefault);
            cuentaSoportado.DataFieldFirst = "CTAINTRACOP";
            cuentaSoportado.TableName = "PROVEE1";
            cuentaSoportado.AssistTableName = "CU1";
            cuentaSoportado.AssistDataFieldFirst = "CODIGO";
            cuentaSoportado.AssistDataFieldSecond = "DESCRIP";
            cuentaSoportado.Height = TextboxHeight;
            cuentaSoportado.TextContentFirstWidth = TextBoxWidthSmall;
            cuentaSoportado.TextContentSecondWidth = TextBoxWidthLarge;
            cuentaSoportado.SourceView = new DataTable();
            cuentaSoportado.ItemSource = new DataTable();
            cuentaSoportado.PrimaryKey = "NUM_PROVEE";
            cuentaSoportado.OnChangedField += OnChangedField;
            cuentaSoportado.ButtonImage = ImagePath;
            cuentaSoportado.DataField = "CTAINTRACOP";
            cuentaSoportado.OnAssistQuery += AssistQueryRequestHandler;
            _accountLeftCollection.Add(cuentaSoportado);

            //intacoBoxMultipleObject.AddDataField(cuentaSoportado);
            UiDualDfSearchTextObject cuentaRepercutido = new UiDualDfSearchTextObject("Cta.Repercutido", LabelTextWidthDefault);
            cuentaRepercutido.DataFieldFirst = "CTAINTRACOPREP";
            cuentaRepercutido.TableName = "PROVEE1";
            cuentaRepercutido.AssistTableName = "CU1";
            cuentaRepercutido.AssistDataFieldFirst = "CODIGO";
            cuentaRepercutido.AssistDataFieldSecond = "DESCRIP";
            cuentaRepercutido.Height = TextboxHeight;
            cuentaRepercutido.TextContentFirstWidth = TextBoxWidthSmall;
            cuentaRepercutido.TextContentSecondWidth = TextBoxWidthLarge;
            cuentaRepercutido.SourceView = new DataTable();
            cuentaRepercutido.ItemSource = new DataTable();
            cuentaRepercutido.PrimaryKey = "NUM_PROVEE";
            cuentaRepercutido.OnChangedField += OnChangedField;
            cuentaRepercutido.ButtonImage = ImagePath;
            cuentaRepercutido.DataField = "CTAINTRACOPREP";
            cuentaRepercutido.OnAssistQuery += AssistQueryRequestHandler;
            _accountLeftCollection.Add(cuentaRepercutido);

        }

        private void LoadAccountRight(UiDualDfSearchTextObject.OnAssistQueryRequestHandler assistQuery, 
                                        UiDfObject.ChangedField changedField)
        {

           
            UiDualDfSearchTextObject paymentSearchBox = new UiDualDfSearchTextObject("Forma de Pago", LabelTextWidthDefault);
            paymentSearchBox.DataFieldFirst = "FORPA";
            paymentSearchBox.TableName = "PROVEE2";
            paymentSearchBox.AssistTableName = "FORMAS";
            paymentSearchBox.AssistDataFieldFirst = "CODIGO";
            paymentSearchBox.AssistDataFieldSecond = "NOMBRE";
            paymentSearchBox.Height = TextboxHeight;
            paymentSearchBox.SourceView = new DataTable();
            paymentSearchBox.ItemSource = new DataTable();
            paymentSearchBox.PrimaryKey = "NUM_PROVEE";
            paymentSearchBox.OnChangedField += changedField;
            paymentSearchBox.ButtonImage = ImagePath;
            paymentSearchBox.DataField = "FORPA";
            paymentSearchBox.OnAssistQuery += assistQuery;
            _accountRightCollection.Add(paymentSearchBox);

            UiMultipleDfObject payementPlaces = new UiMultipleDfObject();
            UiDfObject dataDfObject = new UiDfObject();
            dataDfObject.LabelText = ProvidersModule.Properties.Resources.ProviderInfoViewModel_LoadAccountLeft_PlazoDePago;
            dataDfObject.DataField = "PLAZO";
            dataDfObject.TableName = "PROVEE2";
            dataDfObject.LabelTextWidth = LabelTextWidthDefault;
            dataDfObject.LabelVisible = true;
            dataDfObject.Height = TextboxHeight;
            dataDfObject.TextContentWidth = "50";
            dataDfObject.OnChangedField += OnChangedField;
            dataDfObject.ItemSource = new DataTable();
            dataDfObject.PrimaryKey = "NUM_PROVEE";
            dataDfObject.AllowedEmpty = true;
            payementPlaces.AddDataField(dataDfObject);
            // plazo de pago 2.

            UiDfObject dataDfObject2 = new UiDfObject();
            dataDfObject2.DataField = "PLAZO2";
            dataDfObject2.TableName = "PROVEE2";
            dataDfObject2.LabelVisible = false;
            dataDfObject2.Height = TextboxHeight;
            dataDfObject2.TextContentWidth = "50";
            dataDfObject2.OnChangedField += OnChangedField;
            dataDfObject2.PrimaryKey = "NUM_PROVEE";
            dataDfObject2.AllowedEmpty = true;
            dataDfObject2.ItemSource = new DataTable();
            payementPlaces.AddDataField(dataDfObject2);
            // plazo de pago 3.
            UiDfObject dataDfObject3 = new UiDfObject();
            dataDfObject3.DataField = "PLAZO3";
            dataDfObject3.TableName = "PROVEE2";
            dataDfObject2.LabelVisible = false;
            dataDfObject3.Height = TextboxHeight;
            dataDfObject3.TextContentWidth = "50";
            dataDfObject3.OnChangedField += OnChangedField;
            dataDfObject3.PrimaryKey = "NUM_PROVEE";
            dataDfObject3.AllowedEmpty = true;
            dataDfObject3.ItemSource = new DataTable();

            payementPlaces.AddDataField(dataDfObject3);
            // dias de pago
            UiDfObject payDfObject = new UiDfObject("Dias de pago", LabelTextWidthDefault);
            payDfObject.DataField = "DIA";
            payDfObject.TableName = "PROVEE2";
            payDfObject.LabelTextWidth = LabelTextWidthDefault;
            payDfObject.LabelVisible = true;
            payDfObject.Height = TextboxHeight;
            payDfObject.TextContentWidth = "50";
            payDfObject.IsVisible = true;
            payDfObject.OnChangedField += OnChangedField;
            payDfObject.PrimaryKey = "NUM_PROVEE";
            payDfObject.AllowedEmpty = true;
            payementPlaces.AddDataField(payDfObject);
            UiDfObject payDfObject1 = new UiDfObject();
            payDfObject1.DataField = "DIA2";
            payDfObject1.TableName = "PROVEE2";
            payDfObject1.ItemSource = new DataTable();
            payDfObject.IsVisible = true;
            payDfObject1.LabelVisible = false;
            payDfObject1.Height = TextboxHeight;
            payDfObject1.TextContentWidth = "50";
            payDfObject1.OnChangedField += OnChangedField;
            payDfObject1.PrimaryKey = "NUM_PROVEE";
            payDfObject1.AllowedEmpty = true;
            payementPlaces.AddDataField(payDfObject1);
            UiDfObject payDfObject2 = new UiDfObject();
            payDfObject2.DataField = "DIA3";
            payDfObject2.TableName = "PROVEE2";
            payDfObject2.LabelVisible = false;
            payDfObject.IsVisible = true;
            payDfObject2.Height = TextboxHeight;
            payDfObject2.TextContentWidth = "50";
            payDfObject2.OnChangedField += OnChangedField;
            payDfObject2.PrimaryKey = "NUM_PROVEE";
            payDfObject2.AllowedEmpty = true;
            payementPlaces.AddDataField(payDfObject2);
            _accountRightCollection.Add(payementPlaces);


            // mese vacaciones 1
            
            UiMultipleDfObject vacaciones = new UiMultipleDfObject();
            

            UiDualDfSearchTextObject vacationMonth1 = new UiDualDfSearchTextObject("Mes vacaciones", LabelTextWidthDefault);
            vacationMonth1.DataFieldFirst = "MESVACA";
            vacationMonth1.TableName = "PROVEE1";
            vacationMonth1.AssistTableName = "MESES";
            vacationMonth1.AssistDataFieldFirst = "NUMERO_MES";
            vacationMonth1.AssistDataFieldSecond = "MES";
            vacationMonth1.Height = TextboxHeight;
            vacationMonth1.SourceView = new DataTable();
            vacationMonth1.ItemSource = new DataTable();
            vacationMonth1.PrimaryKey = "NUM_PROVEE";
            vacationMonth1.OnChangedField += OnChangedField;
            vacationMonth1.ButtonImage = ImagePath;
            vacationMonth1.DataField = "MESVACA";
            vacationMonth1.OnAssistQuery += AssistQueryRequestHandler;
            vacationMonth1.TextContentFirstWidth = TextBoxWidthSmall;
            vacationMonth1.TextContentSecondWidth = TextBoxWidthSmall;

            //_accountRightCollection.Add(vacationMonth1);

            vacaciones.AddDataField(vacationMonth1);

            UiDualDfSearchTextObject vacationMonth2 = new UiDualDfSearchTextObject("Segundo Mes", LabelTextWidthDefault);
            vacationMonth2.DataFieldFirst = "MESVACA2";
            vacationMonth2.TableName = "PROVEE1";
            vacationMonth2.AssistTableName = "MESES";
            vacationMonth2.AssistDataFieldFirst = "NUMERO_MES";
            vacationMonth2.AssistDataFieldSecond = "MES";
            vacationMonth2.Height = TextboxHeight;
            vacationMonth2.SourceView = new DataTable();
            vacationMonth2.ItemSource = new DataTable();
            vacationMonth2.PrimaryKey = "NUM_PROVEE";
            vacationMonth2.OnChangedField += OnChangedField;
            vacationMonth2.ButtonImage = ImagePath;
            vacationMonth2.DataField = "MESVACA2";
            vacationMonth2.OnAssistQuery += AssistQueryRequestHandler;
            vacaciones.AddDataField(vacationMonth2);
            _accountRightCollection.Add(vacaciones);
           
            UiMultipleDfObject saleRowMultipleDfObject = new UiMultipleDfObject();
            saleRowMultipleDfObject.TableName = "PROVEE2";
            UiDfObject saleDfObject = new UiDfObject("Descuento", LabelTextWidthDefault);
            saleDfObject.DataField = "DTO";
            saleDfObject.TableName = "PROVEE2";
            saleDfObject.Height = TextboxHeight;
            saleDfObject.ItemSource = new DataTable();
            saleDfObject.PrimaryKey = "NUM_PROVEE";
            saleDfObject.OnChangedField += OnChangedField;
            saleDfObject.LabelTextWidth = LabelTextWidthDefault;
            saleDfObject.LabelVisible = true;
            saleDfObject.Height = TextboxHeight;
            saleDfObject.TextContentWidth = TextBoxWidthDefault;
            saleRowMultipleDfObject.AddDataField(saleDfObject);

            UiDfObject readyPayment = new UiDfObject("Pronto Pago", LabelTextWidthDefault);
            readyPayment.DataField = "PP";
            readyPayment.TableName = "PROVEE2";
            readyPayment.ItemSource = new DataTable();
            readyPayment.PrimaryKey = "NUM_PROVEE";
            readyPayment.OnChangedField += OnChangedField;
            readyPayment.ItemSource = new DataTable();
            readyPayment.LabelTextWidth = LabelTextWidthDefault;
            readyPayment.LabelVisible = true;
            readyPayment.Height = TextboxHeight;
            readyPayment.TextContentWidth = TextBoxWidthDefault;
            saleRowMultipleDfObject.AddDataField(readyPayment);
           
             UiDfObject readyPayment1 = new UiDfObject("Partida Iva", LabelTextWidthDefault);
             readyPayment1.DataField = "TIPOIVA";
             readyPayment1.TableName = "PROVEE1";
             readyPayment1.ItemSource = new DataTable();
             readyPayment1.PrimaryKey = "NUM_PROVEE";
             readyPayment1.OnChangedField += OnChangedField;
             readyPayment1.ItemSource = new DataTable();
             readyPayment1.LabelTextWidth = LabelTextWidthDefault;
             readyPayment1.LabelVisible = true;
             readyPayment1.Height = TextboxHeight;
             readyPayment1.TextContentWidth = TextBoxWidthDefault;
             saleRowMultipleDfObject.AddDataField(readyPayment1);
             
            _accountRightCollection.Add(saleRowMultipleDfObject);

            UiDfObject cuenta = new UiDfObject("Cuenta Bancaria", LabelTextWidthDefault);
            cuenta.DataAllowed = CommonControl.DataType.BankAccount;
            cuenta.DataField = "CC";
            cuenta.TableName = "PROVEE1";
            cuenta.ItemSource = new DataTable();
            cuenta.LabelVisible = true;
            cuenta.Height = TextboxHeight;
            cuenta.TextContentWidth = TextBoxWidthWide;
            cuenta.OnChangedField += OnChangedField;
            _accountRightCollection.Add(cuenta);

            UiDfObject cuenta1 = new UiDfObject("IBAN", LabelTextWidthDefault);
            cuenta1.DataAllowed = CommonControl.DataType.BankAccount;
            cuenta1.DataField = "IBAN";
            cuenta1.TableName = "PROVEE1";
            cuenta1.DataAllowed = CommonControl.DataType.IbanField;
            cuenta1.ItemSource = new DataTable();
            cuenta1.LabelVisible = true;
            cuenta1.Height = TextboxHeight;
            cuenta1.TextContentWidth = TextBoxWidthWide;
            cuenta1.OnChangedField += OnChangedField;
            _accountRightCollection.Add(cuenta1);

            UiMultipleDfObject uiBancosDfObject = new UiMultipleDfObject();

            UiDualDfSearchTextObject uiDualDfSearch = new UiDualDfSearchTextObject("Banco", LabelTextWidthDefault);
            uiDualDfSearch.ButtonImage = ImagePath;
            uiDualDfSearch.AssistDataFieldFirst = "CODBAN";
            uiDualDfSearch.AssistDataFieldSecond = "NOMBRE";
            uiDualDfSearch.AssistTableName = "BANCO";
            uiDualDfSearch.Height = TextboxHeight;
            uiDualDfSearch.IsVisible = true;
            uiDualDfSearch.PrimaryKey = "NUM_PROVEE";
            uiDualDfSearch.TableName = "PROVEE1";
            uiDualDfSearch.OnChangedField += OnChangedField;
            uiDualDfSearch.IsReadOnlySecond = true;
            uiDualDfSearch.IsReadOnlyFirst = false;
            uiDualDfSearch.LabelVisible = true;
            uiDualDfSearch.LabelTextWidth = LabelTextWidthDefault;
            uiDualDfSearch.DataFieldFirst = "BANCO";
            uiDualDfSearch.DataField = "BANCO";
            uiDualDfSearch.ItemSource = new DataTable();
            uiDualDfSearch.SourceView = new DataTable();
            uiDualDfSearch.OnAssistQuery += AssistQueryRequestHandler;
            uiBancosDfObject.AddDataField(uiDualDfSearch);
            UiDfObject swifDfObject = new UiDfObject("SWIFT", LabelTextWidthDefault);
            swifDfObject.DataAllowed = CommonControl.DataType.Swift;
            swifDfObject.DataField = "SWIFT";
            swifDfObject.TableName = "PROVEE1";
            swifDfObject.ItemSource = new DataTable();
            swifDfObject.LabelVisible = true;
            swifDfObject.Height = TextboxHeight;
            swifDfObject.TextContentWidth = TextBoxWidthDefault;
            swifDfObject.OnChangedField += OnChangedField;
            uiBancosDfObject.AddDataField(swifDfObject);
            UiMultipleDfObject uiIdiomaDivisDfObject = new UiMultipleDfObject();

            UiDualDfSearchTextObject  uiIdioma = new UiDualDfSearchTextObject("Idioma", LabelTextWidthDefault);
            uiIdioma.ButtonImage = ImagePath;
            uiIdioma.AssistDataFieldFirst = "CODIGO";
            uiIdioma.AssistDataFieldSecond = "NOMBRE";
            uiIdioma.AssistTableName = "IDIOMAS";
            uiIdioma.Height = TextboxHeight;
            uiIdioma.IsVisible = true;
            uiIdioma.PrimaryKey = "NUM_PROVEE";
            uiIdioma.TableName = "PROVEE1";
            uiIdioma.OnChangedField += OnChangedField;
            uiIdioma.IsReadOnlySecond = true;
            uiIdioma.IsReadOnlyFirst = false;
            uiIdioma.LabelVisible = true;
            uiIdioma.LabelTextWidth = LabelTextWidthDefault;
            uiIdioma.DataFieldFirst = "IDIOMA_PR1";
            uiIdioma.DataField = "IDIOMA_PR1";
            uiIdioma.ItemSource = new DataTable();
            uiIdioma.SourceView = new DataTable();
            uiIdioma.OnAssistQuery += AssistQueryRequestHandler;
            uiIdiomaDivisDfObject.AddDataField(uiIdioma);
            UiDualDfSearchTextObject uiDivisa = new UiDualDfSearchTextObject("Divisa", LabelTextWidthDefault);
            uiDivisa.ButtonImage = ImagePath;
            uiDivisa.AssistDataFieldFirst = "CODIGO";
            uiDivisa.AssistDataFieldSecond = "NOMBRE";
            uiDivisa.AssistTableName = "DIVISAS";
            uiDivisa.Height = TextboxHeight;
            uiDivisa.IsVisible = true;
            uiDivisa.PrimaryKey = "NUM_PROVEE";
            uiDivisa.TableName = "PROVEE2";
            uiDivisa.OnChangedField += OnChangedField;
            uiDivisa.IsReadOnlySecond = true;
            uiDivisa.IsReadOnlyFirst = false;
            uiDivisa.LabelVisible = true;
            uiDivisa.LabelTextWidth = LabelTextWidthDefault;
            uiDivisa.DataFieldFirst = "DIVISA";
            uiDivisa.DataField = "DIVISA";
            uiDivisa.ItemSource = new DataTable();
            uiDivisa.SourceView = new DataTable();
            uiDivisa.OnAssistQuery += AssistQueryRequestHandler;
            uiIdiomaDivisDfObject.AddDataField(uiDivisa);
            _accountRightCollection.Add(uiIdiomaDivisDfObject);
            //UiObjectsLoader loader = new UiObjectsLoader();
           // _accountRightCollection = loader.LoadCollection("UIAccountsRight.xml");
               // SaveCollection(_accountRightCollection, "UIAccountsRight.xml");

            //AccountRightCollection = _accountRightCollection;
        }
       

        // FIXME move to common
        private ObservableCollection<IUiObject> MergeInOneCpCollection(IList<ObservableCollection<IUiObject>> values)
        {
            ObservableCollection<IUiObject> obs = new ObservableCollection<IUiObject>();

            foreach (ObservableCollection<IUiObject> current in values)
            {
                if (current != null)
                {
                    foreach (IUiObject o in current)
                    {
                        if (o != null)
                        {
                            if (!string.IsNullOrEmpty(o.TableName))
                            {
                                obs.Add(o);
                            }
                        }
                    }
                }
            }
            return obs;
        }

        // FIXME move to commona view model
        private void fillViewModelAssistantQueries(ObservableCollection<IUiObject> collection,
                                                    DataSet itemSource,
                                                    ref IDictionary<string, string> assistantQueries)
        {
            foreach (IUiObject nameObject in collection)
            {
                if (!string.IsNullOrEmpty(nameObject.TableName))
                {
                    if (nameObject is UiDualDfSearchTextObject)
                    {
                        UiDualDfSearchTextObject dualDfSearch = (UiDualDfSearchTextObject) nameObject;
                        dualDfSearch.ComputeAssistantRefQuery(itemSource);
                        if (!string.IsNullOrEmpty(dualDfSearch.AssistRefQuery))
                        {
                            if (!assistantQueries.ContainsKey(dualDfSearch.AssistTableName))
                            {
                                assistantQueries.Add(dualDfSearch.AssistTableName, dualDfSearch.AssistRefQuery);
                            }
                        }
                    }
                    if (nameObject is UiMultipleDfObject)
                    {
                        UiMultipleDfObject multipleDfObject = (UiMultipleDfObject) nameObject;
                        IList<IUiObject> listOfSearchTextObjects =
                            multipleDfObject.FindObjects(UiMultipleDfObject.DfKind.UiDualDfSearch);
                        foreach (var currentUiObject in listOfSearchTextObjects)
                        {
                            UiDualDfSearchTextObject dualDfSearch = (UiDualDfSearchTextObject) currentUiObject;
                            dualDfSearch.ComputeAssistantRefQuery(itemSource);
                            if (!string.IsNullOrEmpty(dualDfSearch.AssistRefQuery))
                            {
                                if (!assistantQueries.ContainsKey(dualDfSearch.AssistTableName))
                                {
                                    assistantQueries.Add(dualDfSearch.AssistTableName, dualDfSearch.AssistRefQuery);
                                }
                            }
                        }
                    }
                }
            }
           
<<<<<<< HEAD
        }
        // create an abstract method that loads everything is too loong.
        private async Task<IList<DataSet>> LoadDataValue(string primaryKeyValue, bool insert)
        {
            IList<DataSet> sets = new List<DataSet>();
            IList<ObservableCollection<IUiObject>> collection = new List<ObservableCollection<IUiObject>>();
            collection.Add(_upperPartObservableCollection);
            collection.Add(_middlePartObservableCollection);
            collection.Add(_accountRightCollection);
            collection.Add(_accountLeftCollection);
            collection.Add(_accountLeftCheckBoxes);
            collection.Add(_accountRightCheckBoxes);

            ObservableCollection<IUiObject> obsValue = MergeInOneCpCollection(collection);
            _viewModelQueries = SQLBuilder.SqlBuildSelectFromUiObjects(obsValue, primaryKeyValue, insert);
            // add all other assist table 
            ISupplierDataServices services = _dataServices.GetSupplierDataServices();
            DataSet dataSet = null;
            if (insert)
            {
                dataSet = await services.GetNewSupplier(_viewModelQueries);
            //    SQLBuilder.StripTop("NUM_PROVEE", primaryKeyValue, ref _viewModelQueries);
            }
            else
            {
                dataSet = await services.GetAsyncSupplierInfo(_viewModelQueries);
            }
            // replace with for.
            fillViewModelAssistantQueries(_upperPartObservableCollection, dataSet, ref _viewModelAssitantQueries);
            fillViewModelAssistantQueries(_middlePartObservableCollection, dataSet, ref _viewModelAssitantQueries);
            fillViewModelAssistantQueries(_accountRightCollection, dataSet, ref _viewModelAssitantQueries);
            fillViewModelAssistantQueries(_accountLeftCollection, dataSet, ref _viewModelAssitantQueries);
            IHelperDataServices helperDataServices = _dataServices.GetHelperDataServices();
            DataSet assistDataSet = await helperDataServices.GetAsyncHelper(_viewModelAssitantQueries);
            assistDataSet.DataSetName = "AssistSet";
            // load delegaciones
            DataSet delegationSet = await services.GetAsyncDelegations(primaryKeyValue);
            DelegationTable = delegationSet.Tables[0];
            sets.Add(dataSet);
            sets.Add(assistDataSet);
            if (insert)
            {
                SetItemSourceTable(dataSet, ref _upperPartObservableCollection);
                SetItemSourceTable(dataSet, ref _middlePartObservableCollection);
                UpdateObsCollection(primaryKeyValue, ref _upperPartObservableCollection);
                UpdateObsCollection(primaryKeyValue, ref _middlePartObservableCollection);
            }

            return sets;
        }

        private void UpdateObsCollection(string primaryKey, ref ObservableCollection<IUiObject> obs)
        {
            for (int j = 0; j < obs.Count; ++j)
            {
                IUiObject obj = obs[j];
                if ((obj.DataField == primaryKey))
                {
                    DataTable table = obj.ItemSource;
                    table.Rows[0][obj.DataField] = primaryKey;
                    obj.ItemSource = table;
                    _middlePartObservableCollection[j] = obj;
                }
=======
        }
        // create an abstract method that loads everything is too loong.
        private async Task<IList<DataSet>> LoadDataValue(string primaryKeyValue)
        {
            IList<DataSet> sets = new List<DataSet>();
            IList<ObservableCollection<IUiObject>> collection = new List<ObservableCollection<IUiObject>>();
            collection.Add(_upperPartObservableCollection);
            collection.Add(_middlePartObservableCollection);
            collection.Add(_accountRightCollection);
            collection.Add(_accountLeftCollection);
            collection.Add(_accountLeftCheckBoxes);
            collection.Add(_accountRightCheckBoxes);

            ObservableCollection<IUiObject> obsValue = MergeInOneCpCollection(collection);
            _viewModelQueries = SQLBuilder.SqlBuildSelectFromUiObjects(obsValue, primaryKeyValue);
            // add all other assist table 
            ISupplierDataServices services = _dataServices.GetSupplierDataServices();
            DataSet dataSet = await services.GetAsyncSupplierInfo(_viewModelQueries);
            // replace with for.
            fillViewModelAssistantQueries(_upperPartObservableCollection, dataSet, ref _viewModelAssitantQueries);
            fillViewModelAssistantQueries(_middlePartObservableCollection, dataSet, ref _viewModelAssitantQueries);
            fillViewModelAssistantQueries(_accountRightCollection, dataSet, ref _viewModelAssitantQueries);
            fillViewModelAssistantQueries(_accountLeftCollection, dataSet, ref _viewModelAssitantQueries);
            IHelperDataServices helperDataServices = _dataServices.GetHelperDataServices();
            DataSet assistDataSet = await helperDataServices.GetAsyncHelper(_viewModelAssitantQueries);
            assistDataSet.DataSetName = "AssistSet";
            // load delegaciones
            DataSet delegationSet = await services.GetAsyncDelegations(primaryKeyValue);
            DelegationTable = delegationSet.Tables[0];
            sets.Add(dataSet);
            sets.Add(assistDataSet);
            return sets;
        }
        // move to ui builder.

        private UiDoubleDfObject BuildDoubleDfObjectProviders(string dbField, string dbLabel, string dbField2,
            string labelText2)
        {
            UiDoubleDfObject doubleDfObject = new UiDoubleDfObject();
            doubleDfObject.DataField = dbField;
            doubleDfObject.LabelText = dbLabel;
            doubleDfObject.LabelVisible = true;
            doubleDfObject.TextContentWidth = TextBoxWidthLarge;
            doubleDfObject.Height = TextboxHeight;
            doubleDfObject.TableName = "PROVEE1";
            doubleDfObject.LabelTextWidth = LabelTextWidthDefault;
            doubleDfObject.IsReadOnly = false;
            doubleDfObject.IsReadOnlyRight = false;
            doubleDfObject.PrimaryKey = "NUM_PROVEE";
            doubleDfObject.OnChangedField += OnChangedField;
            doubleDfObject.AllowedEmpty = true;
            doubleDfObject.DataFieldRight = dbField2;
            doubleDfObject.LabelTextRight = labelText2;
            doubleDfObject.LabelTextWidthRight = LabelTextWidthDefault;
            doubleDfObject.LabelVisibleRight = true;
            doubleDfObject.TextContentWidthRight = TextBoxWidthDefault;
            doubleDfObject.HeightRight = TextboxHeight;
            DataTable table = new DataTable();
            doubleDfObject.ItemSource = table;
            doubleDfObject.ItemSourceRight = table;

            return doubleDfObject;
        }
        // move to ui builder
        private void LoadAccountHeader()
        {
            foreach (IUiObject obs in _middlePartObservableCollection)
            {
                if (obs.DataField == "NOMBRE")
                {
                    _headerObservableCollection.Add(obs);
                }
            }
            foreach (IUiObject obs in _upperPartObservableCollection)
            {
                if (obs.DataField == "COMERCIAL")
                {
                    _headerObservableCollection.Add(obs);
                }
                if (obs.DataField == "TIPO")
                {
                    _headerObservableCollection.Add(obs);
                }
            }
            HeaderValueCollection = _headerObservableCollection;
        }
        private UiDualDfSearchTextObject BuildProvinceSearchTextObject(string provinceLabel, string provinceDataField)
        {
            UiDualDfSearchTextObject dualSearchTextObject1 =
                new UiDualDfSearchTextObject(Properties.Resources.ProviderInfoViewModel_LoadLeftPart_Provincia,
                    LabelTextWidthDefault);
            dualSearchTextObject1.ButtonImage = ImagePath;
            dualSearchTextObject1.AssistDataFieldFirst = ZipKey;
            dualSearchTextObject1.AssistDataFieldSecond = ProvinceKey;
            dualSearchTextObject1.AssistTableName = "PROVINCIA";
            dualSearchTextObject1.Height = TextboxHeight;
            dualSearchTextObject1.LabelText = provinceLabel;
            dualSearchTextObject1.IsVisible = true;
            dualSearchTextObject1.PrimaryKey = "NUM_PROVEE";
            dualSearchTextObject1.TableName = "PROVEE1";
            dualSearchTextObject1.OnChangedField += OnChangedField;
            dualSearchTextObject1.IsReadOnlySecond = true;
            dualSearchTextObject1.IsReadOnlyFirst = false;
            dualSearchTextObject1.LabelTextWidth = LabelTextWidthDefault;
            dualSearchTextObject1.DataFieldFirst = provinceDataField;
            dualSearchTextObject1.DataField = provinceDataField;
            dualSearchTextObject1.OnAssistQuery += AssistQueryRequestHandler;

            return dualSearchTextObject1;
        }

        private UiDualDfSearchTextObject BuildPaisSearchTextObject(string paisLabel, string paisDataField)
        {
            UiDualDfSearchTextObject tipoProve = new UiDualDfSearchTextObject("Pais", LabelTextWidthDefault);
            tipoProve.ButtonImage = ImagePath;
            tipoProve.TableName = "PROVEE1";
            tipoProve.PrimaryKey = "NUM_PROVEE";
            tipoProve.AssistTableName = "PAIS";
            tipoProve.AssistDataFieldFirst = "SIGLAS";
            tipoProve.AssistDataFieldSecond = "PAIS";
            tipoProve.DataField = paisDataField;
            tipoProve.DataFieldFirst = paisDataField;
            tipoProve.LabelText = paisLabel;
            tipoProve.Height = TextboxHeight;
            tipoProve.LabelTextWidth = LabelTextWidthDefault;
            tipoProve.TextContentFirstWidth = TextBoxWidthDefault;
            tipoProve.TextContentSecondWidth = "150";
            tipoProve.IsReadOnlyFirst = false;
            tipoProve.IsReadOnlySecond = false;
            tipoProve.SourceView = new DataTable();
            tipoProve.OnChangedField += OnChangedField;
            tipoProve.OnAssistQuery += AssistQueryRequestHandler;
            return tipoProve;
        }
        private void LoadLeftPart()
        {

            _middlePartObservableCollection = new ObservableCollection<IUiObject>();

            for (int i = 0; i < LeftPartFields.Length; ++i)
            {
                // Nombre and Nif
                if (i == 0)
                {
                    int j = 1;
                    _middlePartObservableCollection.Add(BuildDoubleDfObjectProviders(LeftPartFields[i],
                        LeftPartLabel[i], LeftPartFields[j], LeftPartFields[j]));
                    i = 1;
                }
                else if (LeftPartFields[i] == ProvinceKey)
                {

                    UiDualDfSearchTextObject dualSearchTextObject1 =
                        BuildProvinceSearchTextObject(LeftPartLabel[i], LeftPartFields[i]);

                    _middlePartObservableCollection.Add(dualSearchTextObject1);
                    _componentsObjects.Add(ProvinceComponentKey, dualSearchTextObject1);
                }
                else if (LeftPartFields[i] == PaisKey)
                {
                    UiDualDfSearchTextObject tipoProve = BuildPaisSearchTextObject(LeftPartLabel[i], LeftPartFields[i]);
                    _middlePartObservableCollection.Add(tipoProve);
                    _componentsObjects.Add(PaisComponentKey, tipoProve);
                }
                else if (LeftPartFields[i] == "SUBLICEN")
                {


                    UiMultipleDfObject multipleDfObject = new UiMultipleDfObject();

                    UiDualDfSearchTextObject dualSearchTextObject1 =
                        new UiDualDfSearchTextObject(Properties.Resources.ProviderInfoViewModel_Empresa,
                            LabelTextWidthDefault);
                    dualSearchTextObject1.ButtonImage = ImagePath;
                    dualSearchTextObject1.AssistDataFieldFirst = "CODIGO";
                    dualSearchTextObject1.AssistDataFieldSecond = "NOMBRE";
                    dualSearchTextObject1.AssistTableName = "SUBLICEN";
                    dualSearchTextObject1.Height = TextboxHeight;
                    dualSearchTextObject1.LabelText = LeftPartLabel[i];
                    dualSearchTextObject1.IsVisible = true;
                    dualSearchTextObject1.IsReadOnly = true;
                    dualSearchTextObject1.PrimaryKey = "NUM_PROVEE";
                    dualSearchTextObject1.TableName = "PROVEE1";
                    dualSearchTextObject1.OnChangedField += OnChangedField;
                    dualSearchTextObject1.IsReadOnlySecond = false;
                    dualSearchTextObject1.IsReadOnlyFirst = false;
                    dualSearchTextObject1.LabelTextWidth = LabelTextWidthDefault;
                    dualSearchTextObject1.DataFieldFirst = LeftPartFields[i];
                    dualSearchTextObject1.DataField = LeftPartFields[i];
                    dualSearchTextObject1.OnAssistQuery += AssistQueryRequestHandler;
                    _componentsObjects.Add("Sublicen", dualSearchTextObject1);
                    multipleDfObject.AddDataField(dualSearchTextObject1);
                    ++i;
                    UiDualDfSearchTextObject dualSearchTextObject2 =
                        new UiDualDfSearchTextObject(Properties.Resources.ProviderInfoViewModel_Empresa,
                            LabelTextWidthDefault);
                    dualSearchTextObject2.ButtonImage = ImagePath;
                    dualSearchTextObject2.AssistDataFieldFirst = "CODIGO";
                    dualSearchTextObject2.AssistDataFieldSecond = "NOMBRE";
                    dualSearchTextObject2.AssistTableName = "OFICINAS";
                    dualSearchTextObject2.Height = TextboxHeight;
                    dualSearchTextObject2.LabelText = LeftPartLabel[i];
                    dualSearchTextObject2.IsVisible = true;
                    dualSearchTextObject2.IsReadOnly = true;
                    dualSearchTextObject2.PrimaryKey = "NUM_PROVEE";
                    dualSearchTextObject2.TableName = "PROVEE1";
                    dualSearchTextObject2.OnChangedField += OnChangedField;
                    dualSearchTextObject2.IsReadOnlySecond = true;
                    dualSearchTextObject2.IsReadOnlyFirst = false;
                    dualSearchTextObject2.LabelTextWidth = LabelTextWidthDefault;
                    dualSearchTextObject2.DataFieldFirst = "OFICINA";
                    dualSearchTextObject2.DataField = "OFICINA";
                    dualSearchTextObject2.OnAssistQuery += AssistQueryRequestHandler;
                    _componentsObjects.Add("Oficinas", dualSearchTextObject2);
                    multipleDfObject.AddDataField(dualSearchTextObject2);
                   
                    _middlePartObservableCollection.Add(multipleDfObject);

                }
                else if (LeftPartFields[i] == "EMAIL")
                {
                    UiEmailDataField dataDfObject = new UiEmailDataField();
                    DataTable table = new DataTable();
                    dataDfObject.ItemSource = table;
                    dataDfObject.ButtonImage = EmailImagePath;
                    dataDfObject.DataField = LeftPartFields[i];
                    dataDfObject.LabelText = LeftPartLabel[i];
                    dataDfObject.DataAllowed = CommonControl.DataType.Email;
                    dataDfObject.LabelVisible = true;
                    dataDfObject.TextContentWidth = TextBoxWidthDefault;
                    dataDfObject.Height = TextboxHeight;
                    dataDfObject.TableName = "PROVEE1";
                    dataDfObject.LabelTextWidth = LabelTextWidthDefault;
                    dataDfObject.IsReadOnly = false;
                    dataDfObject.PrimaryKey = "NUM_PROVEE";
                    dataDfObject.OnChangedField += OnChangedField;
                    dataDfObject.AllowedEmpty = true;
                    dataDfObject.EmailEventHandler += EmailLookupRequestHandler;
                    _middlePartObservableCollection.Add(dataDfObject);
                }
                else if (LeftPartFields[i] == "CP")
                {
                    UiDoubleDfObject doubleDfObject = new UiDoubleDfObject();
                    doubleDfObject.DataField = LeftPartFields[i];
                    doubleDfObject.LabelText = LeftPartLabel[i];
                    doubleDfObject.IsReadOnly = true;
                    doubleDfObject.LabelVisible = true;
                    doubleDfObject.TextContentWidth = TextBoxWidthDefault;
                    doubleDfObject.Height = TextboxHeight;
                    doubleDfObject.TableName = "PROVEE1";
                    doubleDfObject.LabelTextWidth = LabelTextWidthDefault;
                    doubleDfObject.IsReadOnly = false;
                    doubleDfObject.IsReadOnlyRight = false;
                    doubleDfObject.PrimaryKey = "NUM_PROVEE";
                    doubleDfObject.OnChangedField += OnChangedField;
                    doubleDfObject.AllowedEmpty = true;
                    i++;
                    doubleDfObject.DataFieldRight = LeftPartFields[i];
                    doubleDfObject.LabelTextRight = LeftPartLabel[i];
                    doubleDfObject.LabelTextWidthRight = LabelTextWidthDefault;
                    doubleDfObject.LabelVisibleRight = true;
                    doubleDfObject.TextContentWidthRight = TextBoxWidthDefault;
                    doubleDfObject.HeightRight = TextboxHeight;
                    DataTable table = new DataTable();
                    doubleDfObject.ItemSource = table;
                    doubleDfObject.ItemSourceRight = table;
                    _middlePartObservableCollection.Add(doubleDfObject);
                }
                // FBAJA
                else if (LeftPartFields[i] == "FBAJA")
                {
                    //  UiMultipleDfObject dateMultipleDfObject = new UiMultipleDfObject();
                    UiDatePicker startDate = new UiDatePicker();
                    startDate.LabelText = LeftPartLabel[i];
                    startDate.LabelVisible = true;
                    startDate.DataField = LeftPartFields[i];
                    startDate.Height = TextboxHeight;
                    startDate.Width = "40";
                    startDate.OnChangedField += OnChangedField;
                    startDate.PrimaryKey = "NUM_PROVEE";
                    startDate.TableName = "PROVEE1";
                    startDate.ItemSource = new DataTable();
                    startDate.LabelTextWidth = LabelTextWidthDefault;
                    _middlePartObservableCollection.Add(startDate);
                    // dateMultipleDfObject.AddDataField(startDate);
                    i++;
                    UiDatePicker startDate1 = new UiDatePicker();
                    startDate1.LabelText = "Fecha de alta";
                    startDate1.LabelTextWidth = LabelTextWidthDefault;
                    startDate1.DataField = "FALTA";
                    startDate1.Height = TextboxHeight;
                    startDate1.Width = "40";
                    startDate1.LabelVisible = true;
                    startDate1.OnChangedField += OnChangedField;
                    startDate1.PrimaryKey = "NUM_PROVEE";
                    startDate1.TableName = "PROVEE1";
                    startDate1.ItemSource = new DataTable();
                    //dateMultipleDfObject.AddDataField(startDate1);
                    _middlePartObservableCollection.Add(startDate1);
                }
                else if (LeftPartFields[i] == "TELEFONO")
                {

                    UiMultipleDfObject multipleDfObject = new UiMultipleDfObject();

                    for (int k = 0; k < 3; ++k)
                    {
                        UiDfObject dataDfObject = new UiDfObject();
                        DataTable table = new DataTable();
                        dataDfObject.ItemSource = table;
                        dataDfObject.DataField = LeftPartFields[i];
                        dataDfObject.LabelText = LeftPartLabel[i];
                        dataDfObject.LabelVisible = true;
                        dataDfObject.TextContentWidth = TextBoxWidthDefault;
                        dataDfObject.Height = TextboxHeight;
                        dataDfObject.TableName = "PROVEE1";
                        dataDfObject.LabelTextWidth = LabelTextWidthDefault;
                        dataDfObject.IsReadOnly = false;
                        dataDfObject.PrimaryKey = "NUM_PROVEE";
                        dataDfObject.OnChangedField += OnChangedField;
                        dataDfObject.AllowedEmpty = true;
                        multipleDfObject.AddDataField(dataDfObject);

                        i++;
                    }
                    i--;

                    _middlePartObservableCollection.Add(multipleDfObject);
                }
                
                else if (LeftPartFields[i]=="NOTAS")
                {
                    UiDataArea dataArea  = new UiDataArea();
                    dataArea.DataField = LeftPartFields[i];
                    dataArea.LabelVisible = true;
                    dataArea.LabelText = "Notas";
                    dataArea.LabelTextWidth = LabelTextWidthDefault;
                    dataArea.TableName = "PROVEE1";
                    dataArea.PrimaryKey = "NUM_PROVEE";
                    dataArea.ItemSource = new DataTable();
                    _middlePartObservableCollection.Add(dataArea);
                }
                else if (LeftPartFields[i] == "OBSERVA")
                {
                    UiDataArea dataArea = new UiDataArea();
                    dataArea.DataField = LeftPartFields[i];
                    dataArea.LabelVisible = true;
                    dataArea.LabelText = "Observaciones";
                    dataArea.LabelTextWidth = LabelTextWidthDefault;
                    dataArea.TableName = "PROVEE1";
                    dataArea.PrimaryKey = "NUM_PROVEE";
                    dataArea.ItemSource = new DataTable();
                    _middlePartObservableCollection.Add(dataArea);
                }
                else
                {
                    // direccion.
                    UiDfObject dataDfObject = new UiDfObject();
                    dataDfObject.DataField = LeftPartFields[i];
                    dataDfObject.LabelText = LeftPartLabel[i];
                    dataDfObject.LabelVisible = true;
                    dataDfObject.TextContentWidth = TextBoxWidthLarge;
                    dataDfObject.Height = TextboxHeight;
                    dataDfObject.TableName = "PROVEE1";
                    dataDfObject.LabelTextWidth = LabelTextWidthDefault;
                    dataDfObject.IsReadOnly = false;
                    dataDfObject.ItemSource = new DataTable();
                    dataDfObject.IsVisible = true;
                    dataDfObject.PrimaryKey = "NUM_PROVEE";
                    dataDfObject.OnChangedField += OnChangedField;
                    dataDfObject.AllowedEmpty = true;
                    _middlePartObservableCollection.Add(dataDfObject);
                }

            }
           // MiddleValueCollection = _middlePartObservableCollection;

        }

        private void EmailLookupRequestHandler(string email)
        {
            LaunchMailClient(email);
        }

        private UiDualDfSearchTextObject CraftSupplierTypeObject()

        {
            UiDualDfSearchTextObject tipoProve = new UiDualDfSearchTextObject("Tipo.Prove", LabelTextWidthDefault);
            tipoProve.ButtonImage = ImagePath;
            tipoProve.TableName = "PROVEE1";
            tipoProve.PrimaryKey = "NUM_PROVEE";
            tipoProve.AssistTableName = "TIPOPROVE";
            tipoProve.AssistDataFieldFirst = "NUM_TIPROVE";
            tipoProve.AssistDataFieldSecond = "NOMBRE";
            tipoProve.DataField = "TIPO";
            tipoProve.DataFieldFirst = "TIPO";
            tipoProve.Height = TextboxHeight;
            tipoProve.LabelTextWidth = LabelTextWidthDefault;
            tipoProve.TextContentFirstWidth = LabelTextWidthDefault;
            tipoProve.TextContentSecondWidth = "150";
            tipoProve.IsReadOnlyFirst = true;
            tipoProve.IsReadOnlySecond = false;
            tipoProve.SourceView = new DataTable();
            tipoProve.OnChangedField += OnChangedField;
            tipoProve.OnAssistQuery += AssistQueryRequestHandler;
            return tipoProve;
        }
        private void LoadUpperPart()
        {
            _upperPartObservableCollection = new ObservableCollection<IUiObject>();
            for (int i = 0; i < UpperPartFields.Length - 1; ++i)
            {
                UiDfObject dataUiDfObject = new UiDfObject();
                dataUiDfObject.LabelText = UpperPartLabel[i];
                double value = Convert.ToDouble(UpperPartLabel[i].Length) + 50;
                dataUiDfObject.DataField = UpperPartFields[i];
                dataUiDfObject.LabelTextWidth = LabelTextWidthDefault;
                dataUiDfObject.TextContentWidth = "150";
                dataUiDfObject.Height = TextboxHeight;
                dataUiDfObject.TableName = "PROVEE1";
                dataUiDfObject.PrimaryKey = "NUM_PROVEE";
                dataUiDfObject.OnChangedField += OnChangedField;
                dataUiDfObject.AllowedEmpty = true;
                if (i == 0)
                {
                    dataUiDfObject.IsReadOnly = true;
                }
                else
                {
                    dataUiDfObject.IsReadOnly = false;
                }
                dataUiDfObject.IsVisible = true;
                if (dataUiDfObject.DataField == "COMERCIAL")
                {
                    dataUiDfObject.LabelTextWidth = "150";
                    dataUiDfObject.TableName = "PROVEE2";
                }
                else if (dataUiDfObject.DataField == "NIF")
                {
                    dataUiDfObject.LabelTextWidth = "50";
                }
                DataTable table = new DataTable();
                dataUiDfObject.ItemSource = table;
                _upperPartObservableCollection.Add(dataUiDfObject);
                _componentsObjects.Add(dataUiDfObject.DataField, dataUiDfObject);

>>>>>>> ff924997e4831d843f6c7f8514a59cb51345c3a3
            }
            UiDualDfSearchTextObject tipoProve = CraftSupplierTypeObject();
            _upperPartObservableCollection.Add(tipoProve);
            _componentsObjects.Add(TipoProve, tipoProve);

        }
<<<<<<< HEAD
        // move to ui builder.

        private UiDoubleDfObject BuildDoubleDfObjectProviders(string dbField, string dbLabel, string dbField2,
            string labelText2)
        {
            UiDoubleDfObject doubleDfObject = new UiDoubleDfObject();
            doubleDfObject.DataField = dbField;
            doubleDfObject.LabelText = dbLabel;
            doubleDfObject.LabelVisible = true;
            doubleDfObject.TextContentWidth = TextBoxWidthLarge;
            doubleDfObject.Height = TextboxHeight;
            doubleDfObject.TableName = "PROVEE1";
            doubleDfObject.LabelTextWidth = LabelTextWidthDefault;
            doubleDfObject.IsReadOnly = false;
            doubleDfObject.IsReadOnlyRight = false;
            doubleDfObject.PrimaryKey = "NUM_PROVEE";
            doubleDfObject.OnChangedField += OnChangedField;
            doubleDfObject.AllowedEmpty = true;
            doubleDfObject.DataFieldRight = dbField2;
            doubleDfObject.LabelTextRight = labelText2;
            doubleDfObject.LabelTextWidthRight = LabelTextWidthDefault;
            doubleDfObject.LabelVisibleRight = true;
            doubleDfObject.TextContentWidthRight = TextBoxWidthDefault;
            doubleDfObject.HeightRight = TextboxHeight;
          //  DataTable table = new DataTable();
          //  doubleDfObject.ItemSource = table;
          //  doubleDfObject.ItemSourceRight = table;

            return doubleDfObject;
        }
        // move to ui builder
        private void LoadAccountHeader()
        {
            foreach (IUiObject obs in _middlePartObservableCollection)
            {
                if (obs.DataField == "NOMBRE")
                {
                    _headerObservableCollection.Add(obs);
                }
            }
            foreach (IUiObject obs in _upperPartObservableCollection)
            {
                if (obs.DataField == "COMERCIAL")
                {
                    _headerObservableCollection.Add(obs);
                }
                if (obs.DataField == "TIPO")
                {
                    _headerObservableCollection.Add(obs);
                }
=======
        private void UpdateSource(DataSet dataSetAssistant, string primaryKey,
            ref ObservableCollection<IUiObject> collection)
        {

            IUiObject updateUiObject = null;
            bool found = false;
            int index = 0;
            if ((dataSetAssistant != null) && (dataSetAssistant.Tables.Count > 0))
            {

                UiDualDfSearchTextObject update = null;
                foreach (IUiObject obj in collection)
                {
                    if (obj is UiDualDfSearchTextObject)
                    {
                        update = (UiDualDfSearchTextObject)obj;
                        bool isValidKey = ((update.DataFieldFirst == primaryKey) ||
                                           (update.AssistDataFieldFirst == primaryKey));
                        if (isValidKey)
                        {
                            update.SourceView = dataSetAssistant.Tables[0];
                            updateUiObject = update;
                            found = true;
                            break;
                        }
                    }
                    
                   
                    if (obj is UiMultipleDfObject)
                    {
                            UiMultipleDfObject tmp = (UiMultipleDfObject) obj;
                            tmp.SetSourceView(dataSetAssistant.Tables[0], dataSetAssistant.Tables[0].TableName);
                            updateUiObject = tmp;
                    }
                    ++index;
                }
                if (found)
                {

                    collection.RemoveAt(index);
                    collection.Insert(index, updateUiObject);

                }
            }
        }

        private async void AssistQueryRequestHandler(string assistTableName, string assistQuery, string primaryKey)
        {
            IHelperDataServices helperDataServices = _dataServices.GetHelperDataServices();
            DataSet dataSetAssistant = await helperDataServices.GetAsyncHelper(assistQuery, assistTableName);
            if ((dataSetAssistant != null) && (dataSetAssistant.Tables.Count > 0))
            {
                UpdateSource(dataSetAssistant, primaryKey, ref _upperPartObservableCollection);
                UpdateSource(dataSetAssistant, primaryKey, ref _middlePartObservableCollection);
                UpdateSource(dataSetAssistant, primaryKey, ref _accountRightCollection);
                UpdateSource(dataSetAssistant, primaryKey, ref _accountLeftCollection);
                AccountRightCollection = _accountRightCollection;
                AccountLeftCollection = _accountLeftCollection;
                UpperValueCollection = _upperPartObservableCollection;
                MiddleValueCollection = _middlePartObservableCollection;
>>>>>>> ff924997e4831d843f6c7f8514a59cb51345c3a3
            }
            HeaderValueCollection = _headerObservableCollection;
        }
        private UiDualDfSearchTextObject BuildProvinceSearchTextObject(string provinceLabel, string provinceDataField)
        {
            UiDualDfSearchTextObject dualSearchTextObject1 =
                new UiDualDfSearchTextObject(Properties.Resources.ProviderInfoViewModel_LoadLeftPart_Provincia,
                    LabelTextWidthDefault);
            dualSearchTextObject1.ButtonImage = ImagePath;
            dualSearchTextObject1.AssistDataFieldFirst = ZipKey;
            dualSearchTextObject1.AssistDataFieldSecond = ProvinceKey;
            dualSearchTextObject1.AssistTableName = "PROVINCIA";
            dualSearchTextObject1.Height = TextboxHeight;
            dualSearchTextObject1.LabelText = provinceLabel;
            dualSearchTextObject1.IsVisible = true;
            dualSearchTextObject1.PrimaryKey = "NUM_PROVEE";
            dualSearchTextObject1.TableName = "PROVEE1";
            dualSearchTextObject1.OnChangedField += OnChangedField;
            dualSearchTextObject1.IsReadOnlySecond = true;
            dualSearchTextObject1.IsReadOnlyFirst = false;
            dualSearchTextObject1.LabelTextWidth = LabelTextWidthDefault;
            dualSearchTextObject1.DataFieldFirst = provinceDataField;
            dualSearchTextObject1.DataField = provinceDataField;
            dualSearchTextObject1.OnAssistQuery += AssistQueryRequestHandler;

<<<<<<< HEAD
            return dualSearchTextObject1;
        }

        private UiDualDfSearchTextObject BuildPaisSearchTextObject(string paisLabel, string paisDataField)
        {
            UiDualDfSearchTextObject tipoProve = new UiDualDfSearchTextObject("Pais", LabelTextWidthDefault);
            tipoProve.ButtonImage = ImagePath;
            tipoProve.TableName = "PROVEE1";
            tipoProve.PrimaryKey = "NUM_PROVEE";
            tipoProve.AssistTableName = "PAIS";
            tipoProve.AssistDataFieldFirst = "SIGLAS";
            tipoProve.AssistDataFieldSecond = "PAIS";
            tipoProve.DataField = paisDataField;
            tipoProve.DataFieldFirst = paisDataField;
            tipoProve.LabelText = paisLabel;
            tipoProve.Height = TextboxHeight;
            tipoProve.LabelTextWidth = LabelTextWidthDefault;
            tipoProve.TextContentFirstWidth = TextBoxWidthDefault;
            tipoProve.TextContentSecondWidth = "150";
            tipoProve.IsReadOnlyFirst = false;
            tipoProve.IsReadOnlySecond = false;
            tipoProve.SourceView = new DataTable();
            tipoProve.OnChangedField += OnChangedField;
            tipoProve.OnAssistQuery += AssistQueryRequestHandler;
            return tipoProve;
        }
        private void LoadLeftPart()
        {

            _middlePartObservableCollection = new ObservableCollection<IUiObject>();

            for (int i = 0; i < LeftPartFields.Length; ++i)
            {
                // Nombre and Nif
                if (i == 0)
                {
                    int j = 1;
                    _middlePartObservableCollection.Add(BuildDoubleDfObjectProviders(LeftPartFields[i],
                        LeftPartLabel[i], LeftPartFields[j], LeftPartFields[j]));
                    i = 1;
                }
                
                else if (LeftPartFields[i] == ProvinceKey)
                {

                    UiDualDfSearchTextObject dualSearchTextObject1 =
                        BuildProvinceSearchTextObject(LeftPartLabel[i], LeftPartFields[i]);

                    _middlePartObservableCollection.Add(dualSearchTextObject1);
                    //_componentsObjects.Add(ProvinceComponentKey, dualSearchTextObject1);
                }
                else if (LeftPartFields[i] == PaisKey)
                {
                    UiDualDfSearchTextObject tipoProve = BuildPaisSearchTextObject(LeftPartLabel[i], LeftPartFields[i]);
                    _middlePartObservableCollection.Add(tipoProve);
                    //_componentsObjects.Add(PaisComponentKey, tipoProve);
                }
                else if (LeftPartFields[i] == "SUBLICEN")
                {


                    UiMultipleDfObject multipleDfObject = new UiMultipleDfObject();

                    UiDualDfSearchTextObject dualSearchTextObject1 =
                        new UiDualDfSearchTextObject(Properties.Resources.ProviderInfoViewModel_Empresa,
                            LabelTextWidthDefault);
                    dualSearchTextObject1.ButtonImage = ImagePath;
                    dualSearchTextObject1.AssistDataFieldFirst = "CODIGO";
                    dualSearchTextObject1.AssistDataFieldSecond = "NOMBRE";
                    dualSearchTextObject1.AssistTableName = "SUBLICEN";
                    dualSearchTextObject1.Height = TextboxHeight;
                    dualSearchTextObject1.LabelText = LeftPartLabel[i];
                    dualSearchTextObject1.IsVisible = true;
                    dualSearchTextObject1.IsReadOnly = true;
                    dualSearchTextObject1.PrimaryKey = "NUM_PROVEE";
                    dualSearchTextObject1.TableName = "PROVEE1";
                    dualSearchTextObject1.OnChangedField += OnChangedField;
                    dualSearchTextObject1.IsReadOnlySecond = false;
                    dualSearchTextObject1.IsReadOnlyFirst = false;
                    dualSearchTextObject1.LabelTextWidth = LabelTextWidthDefault;
                    dualSearchTextObject1.DataFieldFirst = LeftPartFields[i];
                    dualSearchTextObject1.DataField = LeftPartFields[i];
                    dualSearchTextObject1.OnAssistQuery += AssistQueryRequestHandler;
                    _componentsObjects.Add("Sublicen", dualSearchTextObject1);
                    multipleDfObject.AddDataField(dualSearchTextObject1);
                    ++i;
                    UiDualDfSearchTextObject dualSearchTextObject2 =
                        new UiDualDfSearchTextObject(Properties.Resources.ProviderInfoViewModel_Empresa,
                            LabelTextWidthDefault);
                    dualSearchTextObject2.ButtonImage = ImagePath;
                    dualSearchTextObject2.AssistDataFieldFirst = "CODIGO";
                    dualSearchTextObject2.AssistDataFieldSecond = "NOMBRE";
                    dualSearchTextObject2.AssistTableName = "OFICINAS";
                    dualSearchTextObject2.Height = TextboxHeight;
                    dualSearchTextObject2.LabelText = LeftPartLabel[i];
                    dualSearchTextObject2.IsVisible = true;
                    dualSearchTextObject2.IsReadOnly = true;
                    dualSearchTextObject2.PrimaryKey = "NUM_PROVEE";
                    dualSearchTextObject2.TableName = "PROVEE1";
                    dualSearchTextObject2.OnChangedField += OnChangedField;
                    dualSearchTextObject2.IsReadOnlySecond = true;
                    dualSearchTextObject2.IsReadOnlyFirst = false;
                    dualSearchTextObject2.LabelTextWidth = LabelTextWidthDefault;
                    dualSearchTextObject2.DataFieldFirst = "OFICINA";
                    dualSearchTextObject2.DataField = "OFICINA";
                    dualSearchTextObject2.OnAssistQuery += AssistQueryRequestHandler;
                    //_componentsObjects.Add("Oficinas", dualSearchTextObject2);
                    multipleDfObject.AddDataField(dualSearchTextObject2);
                   
                    _middlePartObservableCollection.Add(multipleDfObject);

                }
                else if (LeftPartFields[i] == "EMAIL")
                {
                    UiEmailDataField dataDfObject = new UiEmailDataField();
                    DataTable table = new DataTable();
                    dataDfObject.ItemSource = table;
                    dataDfObject.ButtonImage = EmailImagePath;
                    dataDfObject.DataField = LeftPartFields[i];
                    dataDfObject.LabelText = LeftPartLabel[i];
                    dataDfObject.DataAllowed = CommonControl.DataType.Email;
                    dataDfObject.LabelVisible = true;
                    dataDfObject.TextContentWidth = TextBoxWidthDefault;
                    dataDfObject.Height = TextboxHeight;
                    dataDfObject.TableName = "PROVEE1";
                    dataDfObject.LabelTextWidth = LabelTextWidthDefault;
                    dataDfObject.IsReadOnly = false;
                    dataDfObject.PrimaryKey = "NUM_PROVEE";
                    dataDfObject.OnChangedField += OnChangedField;
                    dataDfObject.AllowedEmpty = true;
                    dataDfObject.EmailEventHandler += EmailLookupRequestHandler;
                    _middlePartObservableCollection.Add(dataDfObject);
                }
                else if (LeftPartFields[i] == "CP")
                {
                    UiDoubleDfObject doubleDfObject = new UiDoubleDfObject();
                    doubleDfObject.DataField = LeftPartFields[i];
                    doubleDfObject.LabelText = LeftPartLabel[i];
                    doubleDfObject.IsReadOnly = true;
                    doubleDfObject.LabelVisible = true;
                    doubleDfObject.TextContentWidth = TextBoxWidthDefault;
                    doubleDfObject.Height = TextboxHeight;
                    doubleDfObject.TableName = "PROVEE1";
                    doubleDfObject.LabelTextWidth = LabelTextWidthDefault;
                    doubleDfObject.IsReadOnly = false;
                    doubleDfObject.IsReadOnlyRight = false;
                    doubleDfObject.PrimaryKey = "NUM_PROVEE";
                    doubleDfObject.OnChangedField += OnChangedField;
                    doubleDfObject.AllowedEmpty = true;
                    i++;
                    doubleDfObject.DataFieldRight = LeftPartFields[i];
                    doubleDfObject.LabelTextRight = LeftPartLabel[i];
                    doubleDfObject.LabelTextWidthRight = LabelTextWidthDefault;
                    doubleDfObject.LabelVisibleRight = true;
                    doubleDfObject.TextContentWidthRight = TextBoxWidthDefault;
                    doubleDfObject.HeightRight = TextboxHeight;
                    DataTable table = new DataTable();
                    doubleDfObject.ItemSource = table;
                    doubleDfObject.ItemSourceRight = table;
                    _middlePartObservableCollection.Add(doubleDfObject);
                }
                // FBAJA
                else if (LeftPartFields[i] == "FBAJA")
                {
                    //  UiMultipleDfObject dateMultipleDfObject = new UiMultipleDfObject();
                    UiDatePicker startDate = new UiDatePicker();
                    startDate.LabelText = LeftPartLabel[i];
                    startDate.LabelVisible = true;
                    startDate.DataField = LeftPartFields[i];
                    startDate.Height = TextboxHeight;
                    startDate.Width = "40";
                    startDate.OnChangedField += OnChangedField;
                    startDate.PrimaryKey = "NUM_PROVEE";
                    startDate.TableName = "PROVEE1";
                    startDate.ItemSource = new DataTable();
                    startDate.LabelTextWidth = LabelTextWidthDefault;
                    _middlePartObservableCollection.Add(startDate);
                    // dateMultipleDfObject.AddDataField(startDate);
                    i++;
                    UiDatePicker startDate1 = new UiDatePicker();
                    startDate1.LabelText = "Fecha de alta";
                    startDate1.LabelTextWidth = LabelTextWidthDefault;
                    startDate1.DataField = "FALTA";
                    startDate1.Height = TextboxHeight;
                    startDate1.Width = "40";
                    startDate1.LabelVisible = true;
                    startDate1.OnChangedField += OnChangedField;
                    startDate1.PrimaryKey = "NUM_PROVEE";
                    startDate1.TableName = "PROVEE1";
                    startDate1.ItemSource = new DataTable();
                    //dateMultipleDfObject.AddDataField(startDate1);
                    _middlePartObservableCollection.Add(startDate1);
                }
                else if (LeftPartFields[i] == "TELEFONO")
                {

                    UiMultipleDfObject multipleDfObject = new UiMultipleDfObject();

                    for (int k = 0; k < 3; ++k)
                    {
                        UiDfObject dataDfObject = new UiDfObject();
                        DataTable table = new DataTable();
                        dataDfObject.ItemSource = table;
                        dataDfObject.DataField = LeftPartFields[i];
                        dataDfObject.LabelText = LeftPartLabel[i];
                        dataDfObject.LabelVisible = true;
                        dataDfObject.TextContentWidth = TextBoxWidthDefault;
                        dataDfObject.Height = TextboxHeight;
                        dataDfObject.TableName = "PROVEE1";
                        dataDfObject.LabelTextWidth = LabelTextWidthDefault;
                        dataDfObject.IsReadOnly = false;
                        dataDfObject.PrimaryKey = "NUM_PROVEE";
                        dataDfObject.OnChangedField += OnChangedField;
                        dataDfObject.AllowedEmpty = true;
                        multipleDfObject.AddDataField(dataDfObject);

                        i++;
                    }
                    i--;

                    _middlePartObservableCollection.Add(multipleDfObject);
                }
                
                else if (LeftPartFields[i]=="NOTAS")
                {
                    UiDataArea dataArea  = new UiDataArea();
                    dataArea.DataField = LeftPartFields[i];
                    dataArea.LabelVisible = true;
                    dataArea.LabelText = "Notas";
                    dataArea.LabelTextWidth = LabelTextWidthDefault;
                    dataArea.TableName = "PROVEE1";
                    dataArea.PrimaryKey = "NUM_PROVEE";
                    dataArea.ItemSource = new DataTable();
                    _middlePartObservableCollection.Add(dataArea);
                }
                else if (LeftPartFields[i] == "OBSERVA")
                {
                    UiDataArea dataArea = new UiDataArea();
                    dataArea.DataField = LeftPartFields[i];
                    dataArea.LabelVisible = true;
                    dataArea.LabelText = "Observaciones";
                    dataArea.LabelTextWidth = LabelTextWidthDefault;
                    dataArea.TableName = "PROVEE1";
                    dataArea.PrimaryKey = "NUM_PROVEE";
                    dataArea.ItemSource = new DataTable();
                    _middlePartObservableCollection.Add(dataArea);
                }
                else
                {
                    // direccion.
                    UiDfObject dataDfObject = new UiDfObject();
                    dataDfObject.DataField = LeftPartFields[i];
                    dataDfObject.LabelText = LeftPartLabel[i];
                    dataDfObject.LabelVisible = true;
                    dataDfObject.TextContentWidth = TextBoxWidthLarge;
                    dataDfObject.Height = TextboxHeight;
                    dataDfObject.TableName = "PROVEE1";
                    dataDfObject.LabelTextWidth = LabelTextWidthDefault;
                    dataDfObject.IsReadOnly = false;
                    dataDfObject.ItemSource = new DataTable();
                    dataDfObject.IsVisible = true;
                    dataDfObject.PrimaryKey = "NUM_PROVEE";
                    dataDfObject.OnChangedField += OnChangedField;
                    dataDfObject.AllowedEmpty = true;
                    _middlePartObservableCollection.Add(dataDfObject);
                } 

            }
          //MiddleValueCollection = _middlePartObservableCollection;

        }

        private void EmailLookupRequestHandler(string email)
        {
            LaunchMailClient(email);
        }

        private UiDualDfSearchTextObject CraftSupplierTypeObject()

        {
            UiDualDfSearchTextObject tipoProve = new UiDualDfSearchTextObject("Tipo.Prove", LabelTextWidthDefault);
            tipoProve.ButtonImage = ImagePath;
            tipoProve.TableName = "PROVEE1";
            tipoProve.PrimaryKey = "NUM_PROVEE";
            tipoProve.AssistTableName = "TIPOPROVE";
            tipoProve.AssistDataFieldFirst = "NUM_TIPROVE";
            tipoProve.AssistDataFieldSecond = "NOMBRE";
            tipoProve.DataField = "TIPO";
            tipoProve.DataFieldFirst = "TIPO";
            tipoProve.Height = TextboxHeight;
            tipoProve.LabelTextWidth = LabelTextWidthDefault;
            tipoProve.TextContentFirstWidth = LabelTextWidthDefault;
            tipoProve.TextContentSecondWidth = "150";
            tipoProve.IsReadOnlyFirst = true;
            tipoProve.IsReadOnlySecond = false;
            tipoProve.SourceView = new DataTable();
            tipoProve.OnChangedField += OnChangedField;
            tipoProve.OnAssistQuery += AssistQueryRequestHandler;
            return tipoProve;
        }
        private void LoadUpperPart()
        {
            _upperPartObservableCollection = new ObservableCollection<IUiObject>();
            for (int i = 0; i < UpperPartFields.Length - 1; ++i)
            {
                UiDfObject dataUiDfObject = new UiDfObject();
                dataUiDfObject.LabelText = UpperPartLabel[i];
                double value = Convert.ToDouble(UpperPartLabel[i].Length) + 50;
                dataUiDfObject.DataField = UpperPartFields[i];
                dataUiDfObject.LabelTextWidth = LabelTextWidthDefault;
                dataUiDfObject.TextContentWidth = "150";
                dataUiDfObject.Height = TextboxHeight;
                dataUiDfObject.TableName = "PROVEE1";
                dataUiDfObject.PrimaryKey = "NUM_PROVEE";
                dataUiDfObject.OnChangedField += OnChangedField;
                dataUiDfObject.AllowedEmpty = true;
                if (i == 0)
                {
                    dataUiDfObject.IsReadOnly = true;
                }
                else
                {
                    dataUiDfObject.IsReadOnly = false;
                }
                dataUiDfObject.IsVisible = true;
                if (dataUiDfObject.DataField == "COMERCIAL")
                {
                    dataUiDfObject.LabelTextWidth = "150";
                    dataUiDfObject.TableName = "PROVEE2";
                }
                else if (dataUiDfObject.DataField == "NIF")
                {
                    dataUiDfObject.LabelTextWidth = "50";
                }
                DataTable table = new DataTable();
                dataUiDfObject.ItemSource = table;
                _upperPartObservableCollection.Add(dataUiDfObject);
                //_componentsObjects.Add(dataUiDfObject.DataField, dataUiDfObject);

            }
            UiDualDfSearchTextObject tipoProve = CraftSupplierTypeObject();
            _upperPartObservableCollection.Add(tipoProve);
            //_componentsObjects.Add(TipoProve, tipoProve);

        }
        private void UpdateSource(DataSet dataSetAssistant, string primaryKey,
            ref ObservableCollection<IUiObject> collection)
        {

            IUiObject updateUiObject = null;
            bool found = false;
            int index = 0;
            if ((dataSetAssistant != null) && (dataSetAssistant.Tables.Count > 0))
            {

                UiDualDfSearchTextObject update = null;
                foreach (IUiObject obj in collection)
                {
                    if (obj is UiDualDfSearchTextObject)
                    {
                        update = (UiDualDfSearchTextObject)obj;
                        bool isValidKey = ((update.DataFieldFirst == primaryKey) ||
                                           (update.AssistDataFieldFirst == primaryKey));
                        if (isValidKey)
                        {
                            if (dataSetAssistant.Tables.Count > 0)
                            {
                                update.SourceView = dataSetAssistant.Tables[0];
                                updateUiObject = update;
                                found = true;
                            }
                            break;
                        }
                    }
                    
                   
                    if (obj is UiMultipleDfObject)
                    {
                        if (dataSetAssistant.Tables.Count > 0)
                        {
                            UiMultipleDfObject tmp = (UiMultipleDfObject) obj;
                            tmp.SetSourceView(dataSetAssistant.Tables[0], dataSetAssistant.Tables[0].TableName);
                            updateUiObject = tmp;
                        }
                    }
                    ++index;
                }
                if (found)
                {

                    collection.RemoveAt(index);
                    collection.Insert(index, updateUiObject);

                }
            }
        }

        private async void AssistQueryRequestHandler(string assistTableName, string assistQuery, string primaryKey)
        {
            IHelperDataServices helperDataServices = _dataServices.GetHelperDataServices();
            DataSet dataSetAssistant = await helperDataServices.GetAsyncHelper(assistQuery, assistTableName);
            if ((dataSetAssistant != null) && (dataSetAssistant.Tables.Count > 0))
            {
                UpdateSource(dataSetAssistant, primaryKey, ref _upperPartObservableCollection);
                UpdateSource(dataSetAssistant, primaryKey, ref _middlePartObservableCollection);
                UpdateSource(dataSetAssistant, primaryKey, ref _accountRightCollection);
                UpdateSource(dataSetAssistant, primaryKey, ref _accountLeftCollection);
                AccountRightCollection = _accountRightCollection;
                AccountLeftCollection = _accountLeftCollection;
                UpperValueCollection = _upperPartObservableCollection;
                MiddleValueCollection = _middlePartObservableCollection;
            }
        }

        // fix this method is too long against clean code.


        private void MergeTableChanged(DataTable table, ref DataSet currentDataSet)
        {
        
            string tableName = table.TableName;
            bool foundTable = false;
            if (currentDataSet != null)
            {
                foreach (DataTable currentTable in currentDataSet.Tables)
                {
                    if (currentTable.TableName == tableName)
                    {
                        foundTable = true;
                        break;
                    }
                }
                if (foundTable)
                {
                    currentDataSet.Tables[tableName].Merge(table);
                }
            }
        }

        private void OnChangedField(IDictionary<string, object> eventDictionary)
        {
            DataPayLoad payLoad = new DataPayLoad();
            if (_currentOperationalState == DataPayLoad.Type.Insert)
            {
                payLoad.PayloadType = DataPayLoad.Type.Insert;
                payLoad.HasDataSetList = true;
                payLoad.Subsystem = DataSubSystem.SupplierSubsystem;

                DataTable table = (DataTable)eventDictionary["DataTable"];
                MergeTableChanged(table, ref _currentDataSet);
                MergeTableChanged(table, ref _assistantDataSet);
                MergeTableChanged(table, ref _delegationSet);
//                _viewModelQueries = SQLBuilder.SqlBuildSelectFromUiObjects(obsValue, primaryKeyValue, insert);
                // now with the table merged we go on.
                SQLBuilder.StripTop(ref _viewModelQueries);
                payLoad.Queries = _viewModelQueries;
                List<DataSet> setList = new List<DataSet>();
                setList.Add(_currentDataSet);
                setList.Add(_assistantDataSet);
                setList.Add(_delegationSet);
                payLoad.SetList = setList;
                _eventManager.NotifyToolBar(payLoad);
            }
            else
            {
                payLoad.PayloadType = DataPayLoad.Type.Update;
                payLoad.HasDictionary = true;
                payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
                payLoad.DataDictionary = eventDictionary;
                DataTable table = (DataTable) eventDictionary["DataTable"];
                string colName = (string) eventDictionary["Field"];
                object changedValue = eventDictionary["ChangedValue"];

                string tableName = table.TableName;
                bool foundTable = false;
                foreach (DataTable currentTable in _currentDataSet.Tables)
                {
                    if (currentTable.TableName == tableName)
                    {
                        foundTable = true;
                        break;
                    }
                }
                if (foundTable)
                {
                    _currentDataSet.Tables[tableName].Merge(table);
                    DataRowState state = _currentDataSet.Tables[tableName].Rows[0].RowState;
                    payLoad.HasDataSet = true;
                    payLoad.Set = _currentDataSet;
                    _eventManager.NotifyToolBar(payLoad);
                    payLoad.Queries = _viewModelQueries;
                }
                else
                {

                    foreach (DataTable currentTable in _assistantDataSet.Tables)
                    {
                        if (currentTable.TableName == tableName)
                        {
                            foundTable = true;
                            break;
                        }
                    }
                    if (foundTable)
                    {
                        _assistantDataSet.Tables[tableName].Merge(table);
                        payLoad.Set = _assistantDataSet;
                        payLoad.Queries = _viewModelAssitantQueries;
                        _eventManager.NotifyToolBar(payLoad);
                    }
                }
            }
        }
        public ObservableCollection<IUiObject> UpperValueCollection
        {
            set { _upperPartObservableCollection = value; RaisePropertyChanged("UpperValueCollection"); }
            get { return _upperPartObservableCollection; }
        }


        private void LaunchMailClient(object value)
        {
            if (value != null)
            {
                string email = value as string;
                string emailUrl = "mailto:" + email + "?subject=KarveCar";

                System.Diagnostics.Process.Start(emailUrl);
            }
        }
        private void LaunchWebBrowser(object value)
        {
            if (value != null)
            {
                string webBrowser = value as string;
                if (webBrowser.Length > 0)
                {

                    System.Diagnostics.Process.Start(webBrowser);
                }
            }
        }
        public DataTable SupplierSummaryTable { get; private set; }

        public void incomingPayload(DataPayLoad dataPayLoad)
        {
            DataPayLoad payload = dataPayLoad;
            if (_primaryKeyValue.Length == 0)
            {
                _primaryKeyValue = payload.PrimaryKeyValue;
                string mailboxName = "Providers." + _primaryKeyValue;
                _eventManager.RegisterMailBox(mailboxName, _messageHandler);
            }
            // here i can fix the primary key.
            if (_primaryKeyValue == payload.PrimaryKeyValue)
            {
                if (payload.PayloadType == DataPayLoad.Type.Insert)
                {
                    _currentOperationalState = DataPayLoad.Type.Insert;
                    _primaryKeyValue = _dataServices.GetSupplierDataServices().GetNewId();
                    Init(_primaryKeyValue, true);
                }
                else if (payload.PayloadType == DataPayLoad.Type.Delete)
                {
                    DeleteItem();
                }
                else if (!string.IsNullOrEmpty(_primaryKeyValue))
                {
                    Init(_primaryKeyValue, false);
                    _currentOperationalState = DataPayLoad.Type.Show;
                }
            }
        //_eventManager.disableNotify(ProviderModule.NAME, this);
        }

        private void DeleteItem()
        {
            string primaryKey = _primaryKeyValue;
            ISupplierDataServices supplierDataServices = _dataServices.GetSupplierDataServices();
            supplierDataServices.DeleteSupplier(_viewModelQueries, _currentDataSet);
            DataPayLoad  payLoad = new DataPayLoad();
            payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
            payLoad.PrimaryKeyValue = primaryKey;
            payLoad.PayloadType = DataPayLoad.Type.Delete;
            _eventManager.NotifyToolBar(payLoad);
=======
        // fix this method is too long against clean code.

        private void OnChangedField(IDictionary<string, object> eventDictionary)
        {
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.PayloadType = DataPayLoad.Type.Update;
            payLoad.HasDictionary = true;
            payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
            payLoad.DataDictionary = eventDictionary;
            DataTable table = (DataTable)eventDictionary["DataTable"];
            string colName = (string)eventDictionary["Field"];
            object changedValue = eventDictionary["ChangedValue"];

            string tableName = table.TableName;
            bool foundTable = false;
            foreach (DataTable currentTable in _currentDataSet.Tables)
            {
                if (currentTable.TableName == tableName)
                {
                    foundTable = true;
                    break;
                }
            }
            if (foundTable)
            {
                _currentDataSet.Tables[tableName].Merge(table);
                DataRowState state = _currentDataSet.Tables[tableName].Rows[0].RowState;
                payLoad.HasDataSet = true;
                payLoad.Set = _currentDataSet;
                _eventManager.NotifyToolBar(payLoad);
                payLoad.Queries = _viewModelQueries;
            }
            else
            {

                foreach (DataTable currentTable in _assistantDataSet.Tables)
                {
                    if (currentTable.TableName == tableName)
                    {
                        foundTable = true;
                        break;
                    }
                }
                if (foundTable)
                {
                    _assistantDataSet.Tables[tableName].Merge(table);
                    payLoad.Set = _assistantDataSet;
                    payLoad.Queries = _viewModelAssitantQueries;
                    _eventManager.NotifyToolBar(payLoad);
                }
            }
        }
        public ObservableCollection<IUiObject> UpperValueCollection
        {
            set { _upperPartObservableCollection = value; RaisePropertyChanged("UpperValueCollection"); }
            get { return _upperPartObservableCollection; }
        }


        private void LaunchMailClient(object value)
        {
            if (value != null)
            {
                string email = value as string;
                string emailUrl = "mailto:" + email + "?subject=KarveCar";

                System.Diagnostics.Process.Start(emailUrl);
            }
        }
        private void LaunchWebBrowser(object value)
        {
            if (value != null)
            {
                string webBrowser = value as string;
                if (webBrowser.Length > 0)
                {

                    System.Diagnostics.Process.Start(webBrowser);
                }
            }
        }
        public DataTable SupplierSummaryTable { get; private set; }

        public void incomingPayload(DataPayLoad dataPayLoad)
        {
            DataPayLoad payload = dataPayLoad;
            string primaryKey = payload.PrimaryKeyValue;
            if (!string.IsNullOrEmpty(primaryKey))
            {
                Init(primaryKey);
                _eventManager.disableNotify(ProviderModule.NAME, this);
            }

>>>>>>> ff924997e4831d843f6c7f8514a59cb51345c3a3
        }

    }
}

