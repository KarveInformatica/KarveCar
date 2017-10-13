using System;
using System.Collections;
using KarveCommon.Services;
using KarveDataServices;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using KarveControls.UIObjects;
using System.Threading.Tasks;
using System.Windows.Media;
using KarveCommon.Generic;
using KarveControls;
using ProvidersModule.Common;

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
        private bool insertOperation = false;

        // This is the event manager for communicating with the toolbar and other view modules inside the provider Module.
        private readonly IEventManager _eventManager;
        private readonly IDataServices _dataServices;
        private MailBoxMessageHandler _messageHandler;
        private IConfigurationService _configurationService;

        // current dataset for this view module.

        private DataSet _currentDataSet = new DataSet();
        private DataSet _assistantDataSet = new DataSet();
        // current data queries and aux for the view module.

        private IDictionary<string, string> _viewModelQueries = new Dictionary<string, string>();
        private IDictionary<string, string> _viewModelAssitantQueries = new Dictionary<string, string>();

        private NotifyTaskCompletion<IList<DataSet>> _initializationTable;

        // payload received. State of the view.

        private DataPayLoad.Type _currentOperationalState;

        // Current valye of the primary key.

        private string _primaryKeyValue = "";
        private DataTable _delegationDataTable;
        private ObservableCollection<IUiObject> _leasingCollection;

        public ProviderInfoViewModel(IEventManager eventManager, IConfigurationService configurationService,
            IDataServices dataServices)
        {
            _dataServices = dataServices;
            _configurationService = configurationService;

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


            }
            for (int i = 0; i < uiDfObjects.Count; ++i)
            {
                IUiObject tmp = uiDfObjects[i];
                uiDfObjects.RemoveAt(i);
                uiDfObjects.Insert(i, tmp);
            }
        }

        private void SetSourceViewTable(DataSet sourceView, ref ObservableCollection<IUiObject> uiDfObjects)
        {
            IDictionary<string, DataTable> tablesByNameDictionary = BuildDictionaryFromDataSet(sourceView);
            if (uiDfObjects.Count == 0)
                return;
            int count = 0;
            foreach (IUiObject uiObject in uiDfObjects)
            {

                if (uiObject is UiMultipleDfObject)
                {
                    UiMultipleDfObject box = (UiMultipleDfObject)uiObject;
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
                    UiDualDfSearchTextObject box = (UiDualDfSearchTextObject)uiObject;
                    if (tablesByNameDictionary.ContainsKey(box.AssistTableName))
                    {
                        box.SourceView = tablesByNameDictionary[box.AssistTableName];
                    }
                }

            }
           // triggerRefresh(ref uiDfObjects);
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
            if (_initializationTable.IsSuccessfullyCompleted)
            {


                SetItemSourceTable(_currentDataSet, ref _upperPartObservableCollection);
                SetItemSourceTable(_currentDataSet, ref _headerObservableCollection);
                SetItemSourceTable(_currentDataSet, ref _middlePartObservableCollection);
                SetItemSourceTable(_currentDataSet, ref _accountRightCollection);
                SetItemSourceTable(_currentDataSet, ref _accountLeftCollection);
                SetItemSourceTable(_currentDataSet, ref _accountLeftCheckBoxes);
                SetItemSourceTable(_currentDataSet, ref _accountRightCheckBoxes);
                SetItemSourceTable(_currentDataSet, ref _leasingCollection);


                if (_assistantDataSet.Tables.Count > 0)
                {
                    SetSourceViewTable(_assistantDataSet, ref _upperPartObservableCollection);
                    SetSourceViewTable(_assistantDataSet, ref _middlePartObservableCollection);
                    SetSourceViewTable(_assistantDataSet, ref _accountRightCollection);
                    SetSourceViewTable(_assistantDataSet, ref _accountLeftCollection);
                    SetItemSourceTable(_assistantDataSet, ref _leasingCollection);
                    SetItemSourceTable(_assistantDataSet, ref _headerObservableCollection);
                }
            }



            UpperValueCollection = _upperPartObservableCollection;
            MiddleValueCollection = _middlePartObservableCollection;
            AccountRightCollection = _accountRightCollection;
            AccountLeftCollection = _accountLeftCollection;
            RightCheckBoxesCollection = _accountRightCheckBoxes;
            LeftCheckBoxesCollection = _accountLeftCheckBoxes;
        }


        public DataTable DelegationTable
        {
            get { return _delegationDataTable; }
            set { _delegationDataTable = value; RaisePropertyChanged("DelegationTable"); }
        }

        public ObservableCollection<IUiObject> HeaderValueCollection
        {
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
            set { _accountRightCheckBoxes = value; RaisePropertyChanged(); }
        }
        public ObservableCollection<IUiObject> LeasingCollection
        {
            get { return _leasingCollection; }
            set { _leasingCollection = value; RaisePropertyChanged(); }
        }
        public ObservableCollection<IUiObject> LeftCheckBoxesCollection
        {
            get { return _accountLeftCheckBoxes; }
            set { _accountRightCheckBoxes = value; RaisePropertyChanged(); }
        }
        // this load all the ui objects that are needed to match the fields with data.
        private void LoadUIObjects()
        {
            // here we create the builders.

            UiGeneralPageBuilder generalPageBuilder = new UiGeneralPageBuilder();
            generalPageBuilder.EmailCheckHandler = EmailLookupRequestHandler;
            IDictionary <string, ObservableCollection<IUiObject>> dictionary =  generalPageBuilder.BuildPageObjects(AssistQueryRequestHandler, OnChangedField);
           _upperPartObservableCollection = dictionary[ProviderConstants.UiUpperPart];
           _middlePartObservableCollection = dictionary[ProviderConstants.UiMiddlePartPage];
            UiUpperPartPageBuilder headerPageBuilder= new UiUpperPartPageBuilder();
            dictionary = headerPageBuilder.BuildPageObjects(AssistQueryRequestHandler, OnChangedField);
            _headerObservableCollection = dictionary[ProviderConstants.UiUpperPart]; 
            UiInvoicingBuilder invoicingBuilder = new UiInvoicingBuilder();
            dictionary = invoicingBuilder.BuildPageObjects(AssistQueryRequestHandler, OnChangedField);
            _accountRightCollection = dictionary[ProviderConstants.UiInvocingAccounts];
            _leasingCollection = dictionary[ProviderConstants.UiLeasing];
            _accountLeftCollection = dictionary[ProviderConstants.UiInvocingData];
            _accountLeftCheckBoxes = dictionary[ProviderConstants.UiInvoiceOptionPart1];
            _accountRightCheckBoxes = dictionary[ProviderConstants.UiInvoiceOptionPart2];
            UpperValueCollection = _upperPartObservableCollection;
            HeaderValueCollection = _headerObservableCollection;
            MiddleValueCollection = _middlePartObservableCollection;
            AccountRightCollection = _accountRightCollection;
            LeasingCollection = _leasingCollection;
            AccountRightCheckBoxes = _accountRightCheckBoxes;
            AccountLeftCheckBoxes = _accountLeftCheckBoxes;




            /* LoadLeftPart();
             LoadAccountHeader();
             LoadAccountLeft();
             LoadAccountRight(AssistQueryRequestHandler, OnChangedField);
             LoadAccountCheckBoxes();
             LoadPaymentDirections(AssistQueryRequestHandler, OnChangedField);
             */
        }

       
        private void Init(string primaryKeyValue, bool insert)
        {
            LoadUIObjects();
            _initializationTable = new NotifyTaskCompletion<IList<DataSet>>(LoadDataValue(primaryKeyValue, insert));
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
            cuentaContable.ButtonImage = ProviderConstants.ImagePath;
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
            cuentaGasto.ButtonImage = ProviderConstants.ImagePath;
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
            retentionAccount.ButtonImage = ProviderConstants.ImagePath;
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
            cuentaPago.ButtonImage = ProviderConstants.ImagePath;
            cuentaPago.DataField = "CTAPAGO";
            cuentaPago.OnAssistQuery += AssistQueryRequestHandler;
            _accountLeftCollection.Add(cuentaPago);

            // cuenta cp / cuenta lp

            UiGroupBoxMultipleObject leasingBoxMultipleObject = new UiGroupBoxMultipleObject();
            leasingBoxMultipleObject.GroupBoxTitle = "Leasing";

            UiDualDfSearchTextObject cuentaCp = new UiDualDfSearchTextObject(ProvidersModule.Properties.Resources.ProviderInfoViewModel_LoadAccountLeft_CuentaCP, LabelTextWidthDefault);
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
            cuentaCp.ButtonImage = ProviderConstants.ImagePath;
            cuentaCp.DataField = "CTACP";
            cuentaCp.OnAssistQuery += AssistQueryRequestHandler;
            //leasingBoxMultipleObject.AddDataField(cuentaCp);
            _accountLeftCollection.Add(cuentaCp);

            UiDualDfSearchTextObject cuentaLp = new UiDualDfSearchTextObject("Cuenta L/P", LabelTextWidthDefault);
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
            cuentaLp.ButtonImage = ProviderConstants.ImagePath;
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
            cuentaSoportado.ButtonImage = ProviderConstants.ImagePath;
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
            cuentaRepercutido.ButtonImage = ProviderConstants.ImagePath;
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
            paymentSearchBox.ButtonImage = ProviderConstants.ImagePath;
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
            vacationMonth1.ButtonImage = ProviderConstants.ImagePath;
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
            vacationMonth2.ButtonImage = ProviderConstants.ImagePath;
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
            uiDualDfSearch.ButtonImage = ProviderConstants.ImagePath;
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

            UiDualDfSearchTextObject uiIdioma = new UiDualDfSearchTextObject("Idioma", LabelTextWidthDefault);
            uiIdioma.ButtonImage = ProviderConstants.ImagePath;
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
            uiDivisa.ButtonImage = ProviderConstants.ImagePath;
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
                        UiDualDfSearchTextObject dualDfSearch = (UiDualDfSearchTextObject)nameObject;
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
                        UiMultipleDfObject multipleDfObject = (UiMultipleDfObject)nameObject;
                        IList<IUiObject> listOfSearchTextObjects =
                            multipleDfObject.FindObjects(UiMultipleDfObject.DfKind.UiDualDfSearch);
                        foreach (var currentUiObject in listOfSearchTextObjects)
                        {
                            UiDualDfSearchTextObject dualDfSearch = (UiDualDfSearchTextObject)currentUiObject;
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
            collection.Add(_leasingCollection);
            ObservableCollection<IUiObject> obsValue = MergeInOneCpCollection(collection);
            _viewModelQueries = SQLBuilder.SqlBuildSelectFromUiObjects(obsValue, primaryKeyValue, insert);
            // add all other assist table 
            ISupplierDataServices services = _dataServices.GetSupplierDataServices();
            DataSet dataSet = null;
            if (insert)
            {
                dataSet = await services.GetNewSupplier(_viewModelQueries);
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
            fillViewModelAssistantQueries(_leasingCollection, dataSet, ref _viewModelAssitantQueries);
           
            IHelperDataServices helperDataServices = _dataServices.GetHelperDataServices();
            DataSet assistDataSet = await helperDataServices.GetAsyncHelper(_viewModelAssitantQueries);
            assistDataSet.DataSetName = "AssistSet";
            // load delegaciones
            DataSet delegationSet = await services.GetAsyncDelegations(primaryKeyValue);
            DataTable table = delegationSet.Tables[0];
            DelegationTable = table;
            sets.Add(dataSet);
            sets.Add(assistDataSet);
            if (insert)
            {
                SetItemSourceTable(dataSet, ref _upperPartObservableCollection);
                SetItemSourceTable(dataSet, ref _middlePartObservableCollection);
                SetItemSourceTable(dataSet, ref _accountRightCollection);
                SetItemSourceTable(dataSet, ref _accountLeftCollection);
                SetItemSourceTable(dataSet, ref _leasingCollection);
                UpdateObsCollection(primaryKeyValue, ref _upperPartObservableCollection);
                UpdateObsCollection(primaryKeyValue, ref _middlePartObservableCollection);
            }

            return sets;
        }

        public bool DelegationStateBinding
        {
            get { return true; }
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
            }
        }
        private void EmailLookupRequestHandler(string email)
        {
            LaunchMailClient(email);
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
                            UiMultipleDfObject tmp = (UiMultipleDfObject)obj;
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
                UpdateSource(dataSetAssistant, primaryKey,ref _leasingCollection);
                UpdateSource(dataSetAssistant, primaryKey, ref _headerObservableCollection);

                LeasingCollection = _leasingCollection;
                AccountRightCollection = _accountRightCollection;
                AccountLeftCollection = _accountLeftCollection;
                UpperValueCollection = _upperPartObservableCollection;
                MiddleValueCollection = _middlePartObservableCollection;
                HeaderValueCollection = _headerObservableCollection;
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
             //   MergeTableChanged(table, ref _delegationSet);
                //                _viewModelQueries = SQLBuilder.SqlBuildSelectFromUiObjects(obsValue, primaryKeyValue, insert);
                // now with the table merged we go on.
                SQLBuilder.StripTop(ref _viewModelQueries);
                payLoad.Queries = _viewModelQueries;
                List<DataSet> setList = new List<DataSet>();
                setList.Add(_currentDataSet);
                setList.Add(_assistantDataSet);
               // setList.Add(_delegationSet);
                payLoad.SetList = setList;
                _eventManager.NotifyToolBar(payLoad);
            }
            else
            {
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
        public ObservableCollection<IUiObject> AccountRightCheckBoxes { get { return _accountRightCheckBoxes; }
                                                                        set { _accountRightCheckBoxes = value; } }
        public ObservableCollection<IUiObject> AccountLeftCheckBoxes { get { return _accountLeftCheckBoxes; }
                                                                       set { _accountLeftCheckBoxes = value; } }

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
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
            payLoad.PrimaryKeyValue = primaryKey;
            payLoad.PayloadType = DataPayLoad.Type.Delete;
            _eventManager.NotifyToolBar(payLoad);
        }
    }
}

