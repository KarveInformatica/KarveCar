using System;
using KarveCommon.Services;
using KarveDataServices;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Text;
using KarveControls.UIObjects;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using KarveCommon.Generic;
using KarveDataServices.DataObjects;
using MasterModule.Common;
using MasterModule.UIObjects.Suppliers;
using Prism.Commands;
using GridParams = KarveControls.KarveGrid.KarveGridView.ChangedGridViewEventArgs.EventParams;
using GridOperation = KarveControls.KarveGrid.KarveGridView.ChangedGridViewEventArgs.Operation;

namespace MasterModule.ViewModels
{
    /// <summary>
    ///  TODO This object violate SOLID. has too much responsabilities. We need to move all the data to a SupplierDataWrapper
    ///  which it will manage the dataset and dataobject indiependently.
    /// </summary>
    class ProviderInfoViewModel : MasterViewModuleBase, IEventObserver
    {

        private ObservableCollection<IUiObject> _headerObservableCollection = new ObservableCollection<IUiObject>();
        private ObservableCollection<IUiObject> _accountLeftCollection = new ObservableCollection<IUiObject>();
        private ObservableCollection<IUiObject> _accountRightCollection = new ObservableCollection<IUiObject>();
        private ObservableCollection<IUiObject> _accountLeftCheckBoxes = new ObservableCollection<IUiObject>();
        private ObservableCollection<IUiObject> _accountRightCheckBoxes = new ObservableCollection<IUiObject>();
        private ObservableCollection<IUiObject> _leasingCollection;
        private ObservableCollection<IUiObject> _topLeftDirection;
        private ObservableCollection<IUiObject> _topRightDirection;
        private ObservableCollection<IUiObject> _bottomLeftDirection;
        private ObservableCollection<IUiObject> _bottomRightDirection;
        private IList<ObservableCollection<IUiObject>> _componentsList = new List<ObservableCollection<IUiObject>>();
        private bool _delegationReadonly;
        private DataSet _delegationSet;
        private string _delegationQuery = "";
        private ISupplierData _supplierData;

        public ICommand ItemChangedCommand { set; get; }

        public DataTable DelegationTable
        {
            get
            {
                if (_delegationSet == null)
                {
                    return null;
                }
                if (_delegationSet.Tables.Count == 0)
                {
                    return null;
                }
                return _delegationSet.Tables[0];
            }
            set
            {
                if (_delegationSet == null)
                {
                    _delegationSet = new DataSet();
                    _delegationSet.Tables.Add(value);
                }
                else
                {
                    if (_delegationSet.Tables.Count == 0)
                    {
                        _delegationSet.Tables.Add(value);

                    }
                    else
                    {
                        _delegationSet.Tables[0].Merge(value);
                    }
                }
                RaisePropertyChanged("DelegationTable");
            }
        }
        #region Properties
        /// <summary>
        ///  To many observable collection.
        /// </summary>

        public ObservableCollection<IUiObject> AccountRightCheckBoxes
        {
            get { return _accountRightCheckBoxes; }
            set { _accountRightCheckBoxes = value; RaisePropertyChanged(); }
        }
        public ObservableCollection<IUiObject> AccountLeftCheckBoxes
        {
            get { return _accountLeftCheckBoxes; }
            set { _accountLeftCheckBoxes = value; RaisePropertyChanged(); }
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
            get { return MiddlePartObservableCollection; }
            set
            {
                MiddlePartObservableCollection = value;
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
        public ObservableCollection<IUiObject> TopLeftDirection
        {
            get { return _topLeftDirection; }
            set { _topLeftDirection = value; RaisePropertyChanged(); }
        }
        public ObservableCollection<IUiObject> TopRightDirection
        {
            get { return _topRightDirection; }
            set { _topRightDirection = value; RaisePropertyChanged(); }
        }
        public ObservableCollection<IUiObject> BottomLeftDirection
        {
            get { return _bottomLeftDirection; }
            set { _bottomLeftDirection = value; RaisePropertyChanged(); }
        }
        public ObservableCollection<IUiObject> BottomRightDirection
        {
            get { return _bottomRightDirection; }
            set { _bottomRightDirection = value; RaisePropertyChanged(); }
        }
        #endregion


        private const string ProviderInfoVm = "ProviderInfoViewModel";


        // This is the event manager for communicating with the toolbar and other view modules inside the provider Module.
       
        // current dataset for this view module.

        private DataSet _currentDataSet = new DataSet();
        private DataSet _assistantDataSet = new DataSet();
        // current data queries and aux for the view module.

        private IDictionary<string, string> _viewModelQueries = new Dictionary<string, string>();
        private IDictionary<string, string> _viewModelAssitantQueries = new Dictionary<string, string>();

        private INotifyTaskCompletion<IList<DataSet>> _initializationTable;

        // payload received. State of the view.

     
        // Current valye of the primary key.

        private string _primaryKeyValue = "";
     
        private ObservableCollection<IUiObject> _intractoCollection;
        private Visibility _visibility;
        private bool _isInsertion;
        private DataTable _providerTableFirst;
        private DataTable _providerTableSecond;
        private DataSet _assistDS;
        public ICommand AssistCommand { set; get; }

        public ObservableCollection<IUiObject> IntracoCollection
        {
            set { _intractoCollection = value; RaisePropertyChanged("IntracoCollection"); }
            get { return _intractoCollection; }
        }
        public ObservableCollection<IUiObject> UpperValueCollection
        {
            set { UpperPartObservableCollection = value; RaisePropertyChanged("UpperValueCollection"); }
            get { return UpperPartObservableCollection; }
        }


        public ProviderInfoViewModel(IEventManager eventManager, IConfigurationService configurationService,
            IDataServices dataServices): base(configurationService, eventManager, dataServices)
        {
          // assign params.
            LoadUserInterfaceObjects();
            ConfigurationService = configurationService;  
            MailBoxHandler += MessageHandler;
            DelegationChangedRowsCommand = new DelegateCommand<object>(DelegationChangeRows);
            //ContactsChangedRowsCommand = new DelegateCommand<object>(ContactsChangedRows);
            DelegationStateBinding = false;
            IsVisible = Visibility.Visible;
            ItemChangedCommand = new DelegateCommand<object>(OnChangedField);
            AssistCommand = new DelegateCommand<object>(OnAssistCommand);
            EventManager.RegisterObserverSubsystem(MasterModule.ProviderSubsystemName, this);
        }

        private void OnAssistCommand(object param)
        {
            IDictionary<string, string> values = (Dictionary<string, string>)param;
            string assistTableName = values.ContainsKey("AssistTable") ? values["AssistTable"] as string : null;
            string assistQuery = values.ContainsKey("AssistQuery") ? values["AssistQuery"] as string : null;
            AssistQueryRequestHandler(assistTableName, assistQuery, _primaryKeyValue);
        }

        private void OnChangedField(object obj)
        {
            IDictionary<string, object> eventDictionary = (IDictionary<string, object>) obj;
            OnChangedField(eventDictionary);
        }



        /// <summary>
        ///  Handler for the delegation change rows
        ///  It handles the update, delete, insert
        /// </summary>
        /// <param name="parameter">Dictionary of parameters to be handled.</param>
        private void DelegationChangeRows(object parameter)
        {
            IDictionary<GridParams, object> eventParams = (IDictionary<GridParams, object>)parameter;
            DataTable table = (DataTable)eventParams[GridParams.DataSource];
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.HasDataSet = true;
            payLoad.Queries = new Dictionary<string, string>();
            // Before doing the merge it shall check the alias field.
            string aliasField = (string)eventParams[GridParams.AliasField];
            if (!table.Columns.Contains(aliasField))
            {
                table.Columns.Add(aliasField);
            }
            foreach (DataRow row in table.Rows)
            {
                row[aliasField] = _primaryKeyValue;
            }
            table.TableName = DelegationDataBaseTableName;
            DelegationTable = table;
            payLoad.Set = _delegationSet;

            payLoad.Queries.Add(DelegationDataBaseTableName, ContainsAndAdd(_delegationQuery, aliasField));
            payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
            payLoad.PrimaryKeyValue = ProviderConstants.DelegationesPrimaryKeyValue;
            if (eventParams.ContainsKey(GridParams.Operation))
            {
                GridOperation operation = (GridOperation)eventParams[GridParams.Operation];
                DataPayLoad.Type payLoadType = Convert(operation);
                payLoad.PayloadType = payLoadType;
                EventManager.NotifyToolBar(payLoad);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="delegationQuery"></param>
        /// <param name="aliasField"></param>
        /// <returns></returns>
        private string ContainsAndAdd(string delegationQuery, string aliasField)
        {
            string str = ":";
            string[] stringValues = delegationQuery.Split(',');
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (string value in stringValues)
            {
                if (i == 1)
                {
                    builder.Append(aliasField);
                    builder.Append(",");
                }
                builder.Append(stringValues[i++]);
                if (i < stringValues.Length)
                    builder.Append(",");
            }
            str = builder.ToString();
            return str;
        }
        private DataPayLoad.Type Convert(GridOperation operation)
        {
            DataPayLoad.Type type = DataPayLoad.Type.Any;
            switch (operation)
            {
                case GridOperation.Delete:
                    type = DataPayLoad.Type.Delete;
                    break;
                case GridOperation.Insert:
                    type = DataPayLoad.Type.Insert;
                    break;
                case GridOperation.Update:
                    type = DataPayLoad.Type.Update;
                    break;
            }
            return type;
        }

        /// <summary>
        ///  This is an changed rows command.
        /// </summary>
        public ICommand DelegationChangedRowsCommand { set; get; }
        public ICommand ContactsChangedRowsCommand { set; get; }
        
       
        private void InitializationTableOnPropertyChanged(object sender,
            PropertyChangedEventArgs propertyChangedEventArgs)
        {


            string propertyName = propertyChangedEventArgs.PropertyName;

            if (propertyName.Equals("Status"))
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


                    SetItemSourceTable(_currentDataSet, ref _headerObservableCollection);
                    SetItemSourceTable(_currentDataSet, ref MiddlePartObservableCollection);
                    SetItemSourceTable(_currentDataSet, ref _accountRightCollection);
                    SetItemSourceTable(_currentDataSet, ref _accountLeftCollection);
                    SetItemSourceTable(_currentDataSet, ref _accountLeftCheckBoxes);
                    SetItemSourceTable(_currentDataSet, ref _accountRightCheckBoxes);
                    SetItemSourceTable(_currentDataSet, ref _leasingCollection);
                    SetItemSourceTable(_currentDataSet, ref _topLeftDirection);
                    SetItemSourceTable(_currentDataSet, ref _topRightDirection);
                    SetItemSourceTable(_currentDataSet, ref _bottomLeftDirection);
                    SetItemSourceTable(_currentDataSet, ref _bottomRightDirection);
                    SetItemSourceTable(_currentDataSet, ref _intractoCollection);



                    if (_assistantDataSet.Tables.Count > 0)
                    {

                        SetSourceViewTable(_assistantDataSet, ref UpperPartObservableCollection);
                        SetSourceViewTable(_assistantDataSet, ref MiddlePartObservableCollection);
                        SetSourceViewTable(_assistantDataSet, ref _accountRightCollection);
                        SetSourceViewTable(_assistantDataSet, ref _accountLeftCollection);
                        SetSourceViewTable(_assistantDataSet, ref _leasingCollection);
                        SetSourceViewTable(_assistantDataSet, ref _headerObservableCollection);
                        SetSourceViewTable(_assistantDataSet, ref _topLeftDirection);
                        SetSourceViewTable(_assistantDataSet, ref _topRightDirection);
                        SetSourceViewTable(_assistantDataSet, ref _bottomLeftDirection);
                        SetSourceViewTable(_assistantDataSet, ref _bottomRightDirection);
                        SetSourceViewTable(_assistantDataSet, ref _accountLeftCheckBoxes);
                        SetSourceViewTable(_assistantDataSet, ref _accountRightCheckBoxes);
                        SetSourceViewTable(_assistantDataSet, ref _intractoCollection);

                    }
                }


                TopLeftDirection = _topLeftDirection;
                TopRightDirection = _topRightDirection;
                BottomLeftDirection = _bottomLeftDirection;
                BottomRightDirection = _bottomRightDirection;
                IntracoCollection = _intractoCollection;
                UpperValueCollection = UpperPartObservableCollection;
                HeaderValueCollection = _headerObservableCollection;
                MiddleValueCollection = MiddlePartObservableCollection;
                AccountRightCollection = _accountRightCollection;
                AccountLeftCollection = _accountLeftCollection;

                LeasingCollection = _leasingCollection;
                AccountRightCheckBoxes = _accountRightCheckBoxes;
                AccountLeftCheckBoxes = _accountLeftCheckBoxes;


                UpperValueCollection = UpperPartObservableCollection;
                MiddleValueCollection = MiddlePartObservableCollection;
                AccountRightCollection = _accountRightCollection;
                AccountLeftCollection = _accountLeftCollection;
                RightCheckBoxesCollection = _accountRightCheckBoxes;
                LeftCheckBoxesCollection = _accountLeftCheckBoxes;
               
            }
        }

        // this load all the ui objects that are needed to match the fields with data.
        private void LoadUserInterfaceObjects()
        {
            // here we create the builders.

            UiFirstPageBuilder firstPageBuilder = new UiFirstPageBuilder();
            UiSuppliersUpperPartPageBuilder headerPageBuilder = new UiSuppliersUpperPartPageBuilder();
            UiInvoicingBuilder invoicingBuilder = new UiInvoicingBuilder();
            UiDirectionPageBuilder directionPageBuilder = new UiDirectionPageBuilder(EmailLookupRequestHandler);

            firstPageBuilder.EmailCheckHandler = EmailLookupRequestHandler;
            IDictionary<string, ObservableCollection<IUiObject>> pageObjects = firstPageBuilder.BuildPageObjects(AssistQueryRequestHandler, OnChangedField);
            UpperPartObservableCollection = pageObjects[MasterModule.UiUpperPart];
            MiddlePartObservableCollection = pageObjects[MasterModule.UiMiddlePartPage];
            pageObjects = headerPageBuilder.BuildPageObjects(AssistQueryRequestHandler, OnChangedField);
            _headerObservableCollection = pageObjects[MasterModule.UiUpperPart];
            pageObjects = invoicingBuilder.BuildPageObjects(AssistQueryRequestHandler, OnChangedField);
            _accountRightCollection = pageObjects[ProviderConstants.UiInvocingAccounts];
            _intractoCollection = pageObjects[ProviderConstants.UiIntracoAccount];
            _leasingCollection = pageObjects[ProviderConstants.UiLeasing];
            _accountLeftCollection = pageObjects[ProviderConstants.UiInvocingData];
            _accountLeftCheckBoxes = pageObjects[ProviderConstants.UiInvoiceOptionPart1];
            _accountRightCheckBoxes = pageObjects[ProviderConstants.UiInvoiceOptionPart2];
            pageObjects = directionPageBuilder.BuildPageObjects(AssistQueryRequestHandler, OnChangedField);

            _bottomLeftDirection = pageObjects[ProviderConstants.UiOrderDirectionsCollection];
            _topLeftDirection = pageObjects[ProviderConstants.UiPaymentDirectionsCollection];
            _bottomRightDirection = pageObjects[ProviderConstants.UiDevolutionDirectionsCollection];
            _topRightDirection = pageObjects[ProviderConstants.UiReclaimDirectionsCollection];

            _componentsList.Add(UpperPartObservableCollection);
            _componentsList.Add(MiddlePartObservableCollection);
            _componentsList.Add(_accountRightCollection);
            _componentsList.Add(_accountLeftCollection);
            _componentsList.Add(_accountLeftCheckBoxes);
            _componentsList.Add(_accountRightCheckBoxes);
            _componentsList.Add(_leasingCollection);
            _componentsList.Add(_topLeftDirection);
            _componentsList.Add(_bottomRightDirection);
            _componentsList.Add(_topRightDirection);
            _componentsList.Add(_bottomLeftDirection);
            _componentsList.Add(_intractoCollection);

        }

       /// <summary>
       ///  TODO: remove the helper.
       /// </summary>
       /// <param name="primaryKeyValue"></param>
       /// <param name="isInsertion"></param>
       /// <param name="currentDataSet"></param>
       /// <param name="helper"></param>
        private void Init(string primaryKeyValue, bool isInsertion, DataSet currentDataSet = null, DataSet helper = null)
        {

            ObservableCollection<IUiObject> obsValue = MergeInOneCpCollection(_componentsList);
            
            _viewModelQueries = SqlBuilder.SqlBuildSelectFromUiObjects(obsValue, primaryKeyValue, isInsertion);
            _primaryKeyValue = primaryKeyValue;
            _isInsertion = isInsertion;
            StartAndNotify();
 			if (currentDataSet != null)
            {
                SetItemSourceTable(currentDataSet, ref UpperPartObservableCollection);
                SetItemSourceTable(currentDataSet, ref MiddlePartObservableCollection);
            //   MessageBox.Show("Name");
                 SetSourceViewTable(helper, ref UpperPartObservableCollection);
                    SetSourceViewTable(helper, ref MiddlePartObservableCollection);
            }
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

        public Visibility IsVisible
        {
            set {
                _visibility = value; RaisePropertyChanged();
            }
            get { return _visibility; }
        }

        public string MagnifierButtonImage
        {
            get { return MasterModule.ImagePath; }
        }

        // create an abstract method that loads everything is too loong.
        private async Task<IList<DataSet>> LoadDataValue(string primaryKeyValue, bool insert)
        {
            Stopwatch loadTime = new Stopwatch();
            loadTime.Start();

            // add all other assist table 
            ISupplierDataServices services = DataServices.GetSupplierDataServices();
            DataSet dataSet = null;
            if (insert)
            {
                dataSet = await services.GetNewSupplier(_viewModelQueries);
            }
            else
            {
                dataSet = await services.GetAsyncSupplierInfo(_viewModelQueries);
            }
            ProviderDataFirst = dataSet.Tables["PROVEE1"];
            ProviderDataSecond = dataSet.Tables["PROVEE2"];

            fillViewModelAssistantQueries(UpperPartObservableCollection, dataSet, ref _viewModelAssitantQueries);
            fillViewModelAssistantQueries(MiddlePartObservableCollection, dataSet, ref _viewModelAssitantQueries);
            // replace with for.
            fillViewModelAssistantQueries(_accountRightCollection, dataSet, ref _viewModelAssitantQueries);
            fillViewModelAssistantQueries(_accountLeftCollection, dataSet, ref _viewModelAssitantQueries);
            fillViewModelAssistantQueries(_leasingCollection, dataSet, ref _viewModelAssitantQueries);
            fillViewModelAssistantQueries(_bottomLeftDirection, dataSet, ref _viewModelAssitantQueries);
            fillViewModelAssistantQueries(_topLeftDirection, dataSet, ref _viewModelAssitantQueries);
            fillViewModelAssistantQueries(_topRightDirection, dataSet, ref _viewModelAssitantQueries);
            fillViewModelAssistantQueries(_bottomRightDirection, dataSet, ref _viewModelAssitantQueries);
            fillViewModelAssistantQueries(_bottomLeftDirection, dataSet, ref _viewModelAssitantQueries);
            fillViewModelAssistantQueries(_accountRightCheckBoxes, dataSet, ref _viewModelAssitantQueries);
            fillViewModelAssistantQueries(_accountLeftCheckBoxes, dataSet, ref _viewModelAssitantQueries);
            fillViewModelAssistantQueries(_intractoCollection, dataSet, ref _viewModelAssitantQueries);


            IHelperDataServices helperDataServices = DataServices.GetHelperDataServices();
            DataSet assistDataSet = await helperDataServices.GetAsyncHelper(_viewModelAssitantQueries);
            assistDataSet.DataSetName = "AssistSet";
            SetItemSourceTable(dataSet, ref UpperPartObservableCollection);
            SetItemSourceTable(dataSet, ref MiddlePartObservableCollection);
            SetSourceViewTable(assistDataSet, ref UpperPartObservableCollection);
            SetSourceViewTable(assistDataSet, ref MiddlePartObservableCollection);

            // load delegaciones
            Tuple<string, DataSet> values = await services.GetAsyncDelegations(primaryKeyValue);
            _delegationSet = values.Item2;
            _delegationQuery = values.Item1;
            // update the thinge
            RaisePropertyChanged("DelegationTable");
            IList<DataSet> sets = new List<DataSet>();
            sets.Add(dataSet);
            sets.Add(assistDataSet);
            AssistSet = assistDataSet;
            //loadTime.Stop();
            //MessageBox.Show(string.Format("{0}", loadTime.ElapsedMilliseconds));


            if (insert)
            {
                SetItemSourceTable(dataSet, ref UpperPartObservableCollection);
                SetItemSourceTable(dataSet, ref MiddlePartObservableCollection);
                SetItemSourceTable(dataSet, ref _accountRightCollection);
                SetItemSourceTable(dataSet, ref _accountLeftCollection);
                SetItemSourceTable(dataSet, ref _leasingCollection);
                UpdateObsCollection(primaryKeyValue, ref UpperPartObservableCollection);
                UpdateObsCollection(primaryKeyValue, ref MiddlePartObservableCollection);
            }
            //UpperValueCollection = UpperPartObservableCollection;
            loadTime.Stop();
            //   MessageBox.Show(string.Format("{0}", loadTime.ElapsedMilliseconds));

            //   MiddleValueCollection = _middlePartObservableCollection;
            return sets;
        }

        public DataSet AssistSet
        {
            set { _assistDS = value; RaisePropertyChanged(); }
            get { return _assistDS; }
        }
        public string DelegationDataBaseTableName
        {
            get
            {
                return ProviderConstants.DelegationDataBaseTable;
            }
        }

        public DataTable ProviderDataFirst
        {
            get { return _providerTableFirst; }
            set { _providerTableFirst = value; RaisePropertyChanged(); }
        }

        public DataTable ProviderDataSecond
        {
            get { return _providerTableSecond; }
            set { _providerTableSecond = value; RaisePropertyChanged(); }
        }

        public bool DelegationStateBinding
        {
            get
            {
                return false;
            }
            set
            {
                _delegationReadonly = value; RaisePropertyChanged();

            }
        }

        private void UpdateObsCollection(string primaryKey, ref ObservableCollection<IUiObject> obs)
        {
            for (int j = 0; j < obs.Count; ++j)
            {
                IUiObject obj = obs[j];
                if ((obj.DataField == primaryKey))
                {
                    DataTable table = obj.ItemSource as DataTable;
                    table.Rows[0][obj.DataField] = primaryKey;
                    obj.ItemSource = table;
                    MiddlePartObservableCollection[j] = obj;
                }
            }
        }
        private void EmailLookupRequestHandler(string email)
        {
            LaunchMailClient(email);
        }

        // TODO Fix excessive depth of code.
        /*
        private void
            UpdateSource(DataSet dataSetAssistant, string primaryKey,
            ref ObservableCollection<IUiObject> collection)
        {

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
                                dataSetAssistant.Tables[0].NewRow();

                                update.SourceView = dataSetAssistant.Tables[0];

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
                        }
                    }
                }



            }
        }
        */

        private async void AssistQueryRequestHandler(string assistTableName, string assistQuery, string primaryKey)
        {
            IHelperDataServices helperDataServices = DataServices.GetHelperDataServices();
            DataSet dataSetAssistant = await helperDataServices.GetAsyncHelper(assistQuery, assistTableName);
            if ((dataSetAssistant != null) && (dataSetAssistant.Tables.Count > 0))
            {
                AssistSet = dataSetAssistant;
                UpdateSource(dataSetAssistant, primaryKey, ref UpperPartObservableCollection);
                UpdateSource(dataSetAssistant, primaryKey, ref MiddlePartObservableCollection);
                UpdateSource(dataSetAssistant, primaryKey, ref _accountRightCollection);
                UpdateSource(dataSetAssistant, primaryKey, ref _accountLeftCollection);
                UpdateSource(dataSetAssistant, primaryKey, ref _leasingCollection);
                UpdateSource(dataSetAssistant, primaryKey, ref _headerObservableCollection);
                UpdateSource(dataSetAssistant, primaryKey, ref _bottomLeftDirection);
                UpdateSource(dataSetAssistant, primaryKey, ref _topLeftDirection);
                UpdateSource(dataSetAssistant, primaryKey, ref _bottomRightDirection);
                UpdateSource(dataSetAssistant, primaryKey, ref _topRightDirection);
                UpdateSource(dataSetAssistant, primaryKey, ref _accountLeftCheckBoxes);
                UpdateSource(dataSetAssistant, primaryKey, ref _accountRightCheckBoxes);
                UpdateSource(dataSetAssistant, primaryKey, ref _intractoCollection);
                
                IntracoCollection = _intractoCollection;
                BottomLeftDirection = _bottomLeftDirection;
                TopRightDirection = _topRightDirection;
                TopLeftDirection = _topLeftDirection;
                BottomRightDirection = _bottomRightDirection;
                LeasingCollection = _leasingCollection;
                AccountRightCollection = _accountRightCollection;
                AccountLeftCollection = _accountLeftCollection;
                UpperValueCollection = UpperPartObservableCollection;
                MiddleValueCollection = MiddlePartObservableCollection;
                HeaderValueCollection = _headerObservableCollection;
                AccountLeftCheckBoxes = _accountLeftCheckBoxes;
                AccountRightCheckBoxes = _accountRightCheckBoxes;

            }
        }

        // fix this method is too long against clean code.


       // TODO: this shall be moved to the upper class
        private void OnChangedField(IDictionary<string, object> eventDictionary)
        {
            DataPayLoad payLoad = new DataPayLoad();
            if (CurrentOperationalState == DataPayLoad.Type.Insert)
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
                SqlBuilder.StripTop(ref _viewModelQueries);
                payLoad.Queries = _viewModelQueries;
                List<DataSet> setList = new List<DataSet>();
                setList.Add(_currentDataSet);
                setList.Add(_assistantDataSet);
                // setList.Add(_delegationSet);
                payLoad.SetList = setList;
                EventManager.NotifyToolBar(payLoad);
            }
            else
            {
                payLoad.PayloadType = DataPayLoad.Type.Update;
                payLoad.HasDictionary = true;
                payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
                payLoad.DataDictionary = eventDictionary;
                DataTable table = (DataTable)eventDictionary["DataTable"];
                
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
                    EventManager.NotifyToolBar(payLoad);
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
                        EventManager.NotifyToolBar(payLoad);
                    }
                }
            }
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
                EventManager.RegisterMailBox(mailboxName, MailBoxHandler);
            }
            // here i can fix the primary key
            
            if (payload.PayloadType != DataPayLoad.Type.Delete)
            {
                if (!string.IsNullOrEmpty(_primaryKeyValue))
                {
                    Init(_primaryKeyValue, false);
                    CurrentOperationalState = DataPayLoad.Type.Show;
                }
                else
                {
                    CurrentOperationalState = DataPayLoad.Type.Insert;
                    _primaryKeyValue = DataServices.GetSupplierDataServices().GetNewId();
                    Init(_primaryKeyValue, true);
                }
            }
            else if (payload.PayloadType == DataPayLoad.Type.Delete)
            {
                    DeleteItem(payload.PrimaryKeyValue);
                
            }
            
            
            //_eventManager.disableNotify(ProviderModule.NAME, this);
        }

        private void DeleteItem(string primaryKeyValue)
        {
            string primaryKey = primaryKeyValue;
            if (primaryKey == _primaryKeyValue)
            {
                ISupplierDataServices supplierDataServices = DataServices.GetSupplierDataServices();
                IDictionary<string, string> namedDictionary = _viewModelQueries;
                supplierDataServices.DeleteSupplier(_viewModelQueries, _currentDataSet);
                DataPayLoad payLoad = new DataPayLoad();
                payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
                payLoad.PrimaryKeyValue = primaryKey;
                payLoad.Queries = _viewModelQueries;
                payLoad.PayloadType = DataPayLoad.Type.Delete;
                EventManager.NotifyToolBar(payLoad);
                _primaryKeyValue = "";
            }
        }

        public override void StartAndNotify()
        {
            IsVisible = Visibility.Visible;
            _initializationTable = NotifyTaskCompletion.Create<IList<DataSet>>(LoadDataValue(_primaryKeyValue, _isInsertion), InitializationTableOnPropertyChanged);
          //  _initializationTable.PropertyChanged += InitializationTableOnPropertyChanged;
        }
        public override void NewItem()
        {
         //   throw new NotImplementedException();
        }


        protected override void SetTable(DataTable table)
        {
           // throw new NotImplementedException();
        }

        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            //throw new NotImplementedException();
        }

        protected override string GetRouteName(string name)
        {
             return "ProviderModule:" + name;
        }

        protected override void SetDataObject(object result)
        {
            _supplierData = (ISupplierData) result;
        }
    }
}

