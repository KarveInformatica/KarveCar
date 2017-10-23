using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using DataAccessLayer.DataObjects;
using DataAccessLayer.DataObjects.Wrapper;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveControls;
using KarveControls.UIObjects;
using KarveDataServices;
using KarveDataServices.DataObjects;
using MasterModule.Common;
using MasterModule.UIObjects.CommissionAgents;
using Prism.Commands;

namespace MasterModule.ViewModels
{
    /// <summary>
    /// This view model is the commission agent view model
    /// </summary>
    /// CommissionAgentInfoViewModel
    public partial class CommissionAgentInfoViewModel : MasterViewModuleBase,IEventObserver
    {
        private const string TableNameComisio = "COMISIO";
        private Visibility _visibility;
        private DataTable _commissionTable;
        private IDictionary<string, string> _queries;
        private string _primaryKeyValue = "";
        private bool _isInsertion = false;
        private ObservableCollection<UiDfSearch> _leftObservableCollection;
        private ObservableCollection<IUiObject> _rightObservableCollection;
        private ObservableCollection<IUiObject> _upperObservableCollection;
        private ICommissionAgentDataServices _commissionAgentDataServices;
        private INotifyTaskCompletion<ICommissionAgent> _initializationTable;
        /// <summary>
        ///  This is a a commission agent data object.
        /// </summary>
        private ICommissionAgent _commissionAgentDo;
        
        //
        // A part of the ui is made up different objects inserted in a observable collection.
        //
        /// <summary>
        /// ViewModel for the commission agent. 
        /// </summary>
        /// <param name="configurationService">The configuration service will be used in this case</param>
        /// <param name="eventManager">Event manager</param>
        /// <param name="services">Services to be used</param>

        public CommissionAgentInfoViewModel(IConfigurationService configurationService, 
                                            IEventManager eventManager, IDataServices services) : base(configurationService, eventManager, services)
        {
            IsVisible = Visibility.Collapsed;
            AssistQueryDictionary = new Dictionary<string, string>();
            _queries = new Dictionary<string, string>();
            PrimaryKeyValue = CommissionAgentConstants.PrimaryKey;
            LoadUserInterfaceObjects();
            ConfigurationService = configurationService;
            MailBoxHandler += MessageHandler;
            _visibility = Visibility.Collapsed;
            AssistDataSet = new DataSet();
            MagnifierCommand = new DelegateCommand<object>(MagnifierCommandHandler);
            ItemChangedCommand= new DelegateCommand<object>(ItemChangedHandler);
            EventManager.registerObserverSubsystem(MasterModule.CommissionAgentSystemName, this);
            _commissionAgentDataServices = DataServices.GetCommissionAgentDataServices();
        }
        /// <summary>
        /// This is enabled to the change the handler
        /// The command deliver some parmetes.
        /// </summary>
        /// <param name="obj">The object conveyed from the command.</param>
        private void ItemChangedHandler(object obj)
        {
            IDictionary<string, object> values = (Dictionary<string, object>) obj;
            OnChangedField(values);
        }
        /// <summary>
        /// This item is enabled to the magnifier command. When the user press the magnifier.
        /// </summary>
        /// <param name="param">Parameter of the command</param>
        private void MagnifierCommandHandler(object param)
        {
            IDictionary<string, object> values = (Dictionary<string, object>)param;
            string assistTableName = values.ContainsKey("AssitTableName") ? values["AssitTableName"] as string : null;
            string primaryKey = values.ContainsKey("AssitFieldFirst") ? values["AssitFieldFirst"] as string : null;
            string assistQuery = values.ContainsKey("AssitQuery") ? values["AssitQuery"] as string : null;
            AssistQueryRequestHandler(assistTableName, assistQuery, primaryKey);
        }
        /// <summary>
        ///  This load the user interface object for the upper part and the right page is it is present.
        /// </summary>
        private void LoadUserInterfaceObjects()
        {
            UiCommissionAgentUpperPartBuilder builderUpperPart = new UiCommissionAgentUpperPartBuilder();
            IDictionary<string, ObservableCollection<IUiObject>> collection = builderUpperPart.BuildPageObjects(AssistQueryRequestHandler, OnChangedField);
            if (collection.ContainsKey(MasterModule.UiUpperPart))
            {
                UpperValueCollection = collection[MasterModule.UiUpperPart];
            }
            if (collection.ContainsKey(MasterModule.UiRightPartPage))
            {
                RightValueCollection = collection[MasterModule.UiRightPartPage];
            }
            _leftObservableCollection = _leftSideDualDfSearchBoxes;
        }
        /// <summary>
        /// UpperValueCollection. 
        /// </summary>
        public ObservableCollection<IUiObject> UpperValueCollection
        {
            get { return _upperObservableCollection; }
            set { _upperObservableCollection = value; }
        }
        /// <summary>
        ///  LeftValueCollection. This returns the left value collection
        /// </summary>
        public ObservableCollection<UiDfSearch> LeftValueCollection
        {
            set { _leftObservableCollection = value; RaisePropertyChanged(); }
            get { return _leftObservableCollection; }
        }
        /// <summary>
        ///  This return the right value collection.
        /// </summary>
        public ObservableCollection<IUiObject> RightValueCollection
        {
            set
            {
                _rightObservableCollection = value; RaisePropertyChanged(); 
                
            }
            get
            {
                return _rightObservableCollection;
            }
        }

        /// <summary>
        ///  This returns an assist table.
        /// </summary>
        public object AssistTable
        {
            get { return AssistDataSet; }
            set { AssistDataSet = (DataSet) value; RaisePropertyChanged(); }
        }
        /// <summary>
        ///  This returns a data table for binding the objects.
        /// </summary>
        public DataTable CommissionTable
        {
            get
            {
                return _commissionTable;
            }
            set { _commissionTable = value; }
            
        }

        /// <summary>
        ///  This return the magnifier button
        /// </summary>
        public string MagnifierButtonImage
        {
            get { return MasterModule.ImagePath; }
        }
        /// <summary>
        ///  Command to be associated to on change.
        /// </summary>
        public ICommand MagnifierCommand { set; get; }
        /// <summary>
        /// This item changed command.
        /// </summary>
        public ICommand ItemChangedCommand { set; get; }
        /// <summary>
        ///  Set or Get the vehicle is visible.
        /// </summary>
        public Visibility IsVisible
        {
            get { return _visibility; }
            set { _visibility = value; RaisePropertyChanged(); }
        }

        /// <summary>
        ///  Return the commissionist table.
        /// </summary>
        public string TableName
        {
            get { return TableNameComisio; }
        }
        /// <summary>
        ///  Assistant queries. Set of the queries related to the magnifier.
        /// </summary>
        public  IDictionary<string, string> AssistQueryDictionary { get; set; }

        /// <summary>
        ///  This is a query dictionary of all queries.
        ///  At this point we can start the notification load.
        ///  In the view model we have everything that we need for loading stuff.
        /// </summary>
        public IDictionary<string, string> QueryDictionary
        {
            get
            {
                return _queries;
            }
            set
            {
                _queries = value;
                // here we have the loader.
                if (_queries.Keys.Count > 0)
                     StartAndNotify();
            }
        }

        /// <summary>
        ///  This is the email button image that it is needed.
        /// </summary>
        public string EmailButtonImage
        {
            get { return MasterModule.EmailImagePath; }
        }
        /// <summary>
        /// This is the start and notify.
        /// </summary>
        public override void StartAndNotify()
        {

             
            IsVisible = Visibility.Visible;
            _initializationTable =
                NotifyTaskCompletion.Create<ICommissionAgent>(LoadDataValue(_primaryKeyValue, _isInsertion), InitializationDataObjectOnPropertyChanged);
          // _initializationTable.PropertyChanged += InitializationDataObjectOnPropertyChanged;
        }

        


        /// <summary>
        ///  Initialization on property changed.
        /// </summary>
        /// <param name="sender">This is the sender.</param>
        /// <param name="e">Parameters</param>
        private void InitializationDataObjectOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            IsVisible = Visibility.Visible;
            if (sender is ICommissionAgent)
            {
                ICommissionAgent agent = (ICommissionAgent)sender;
                DataObject = agent.Commission;
            }
           
        }
        /// <summary>
        /// This program loads the data from the data values.
        /// </summary>
        /// <param name="primaryKeyValue">Primary Key.</param>
        /// <param name="isInsertion">Inserted key.</param>
        /// <returns></returns>
        private async Task<ICommissionAgent> LoadDataValue(string primaryKeyValue, bool isInsertion)
        {

            ICommissionAgent agent = null;
            if (isInsertion)
            {
                agent = _commissionAgentDataServices.GetNewCommissionAgentDo();
            }
            else
            {
                agent = await _commissionAgentDataServices.GetCommissionAgentDo(primaryKeyValue);
            }
            return agent;
        }

        /// <summary>
        /// Returns a data object.
        /// </summary>
        public object DataObject
        {
            set
            {
                _commissionAgentDo.Commission = value;
                RaisePropertyChanged();
            }
            // Data object to get
            get { return _commissionAgentDo.Commission; }
        }

        /// <summary>
        ///  This method answer to the lookup of the assist query
        /// </summary>
        /// <param name="assistTableName">Assit TableName</param>
        /// <param name="assistQuery">Assist query</param>
        /// <param name="primaryKey">Primary Key of the table</param>
        private async void AssistQueryRequestHandler(string assistTableName, string assistQuery, string primaryKey)
        {
            IHelperDataServices helperDataServices = DataServices.GetHelperDataServices();
            DataSet dataSetAssistant = await helperDataServices.GetAsyncHelper(assistQuery, assistTableName);
            if ((dataSetAssistant != null) && (dataSetAssistant.Tables.Count > 0))
            {
                UpdateSource(dataSetAssistant, primaryKey, ref UpperPartObservableCollection);
                AssistDataSet = dataSetAssistant;
                AssistTable = dataSetAssistant;
            }
        }


       /// <summary>
       ///  OnChangedField. This method shall be changed.
       /// </summary>
       /// <param name="eventDictionary">Dictionary of events.</param>
        private void OnChangedField(IDictionary<string, object> eventDictionary)
        {
            DataPayLoad payLoad = new DataPayLoad();
            ChangeFieldHandlerDo<COMISIO> handlerDo = new ChangeFieldHandlerDo<COMISIO>(EventManager, 
                                                        ViewModelQueries, 
                                                        DataSubSystem.CommissionAgentSubystem);
           
            if (CurrentOperationalState == DataPayLoad.Type.Insert)
            {
                handlerDo.OnInsert(payLoad, eventDictionary);
               
            }
            else
            {
                handlerDo.OnUpdate(payLoad, eventDictionary);
            }
        }
       
        /// <summary>
        ///  This method start a new item when the user clicks over the toolbar
        /// </summary>
        public override void NewItem()
        {
           // throw new NotImplementedException();
        }
        /// <summary>
        ///  This method set the table to be saved.
        /// </summary>
        /// <param name="table"></param>
        protected override void SetTable(DataTable table)
        {
        //    throw new NotImplementedException();
        }
        /// <summary>
        ///  This method set the registration payload.
        /// </summary>
        /// <param name="payLoad"></param>
        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
          //  throw new NotImplementedException();
        }
        /// <summary>
        /// This is a data object to see the result.
        /// </summary>
        /// <param name="result"></param>
        protected override void SetDataObject(object result)
        {
          
        }

        protected override string GetRouteName(string name)
        {
            return "CommisionAgentNewInfo";
        }
        /// <summary>
        /// Init a primary key.
        /// </summary>
        /// <param name="primaryKey">Primary Key</param>
        /// <param name="value">Insert Value.</param>
        private void Init(string primaryKey, bool value)
        {
            // arriva el payload.
            _primaryKeyValue = primaryKey;
            _isInsertion = value;
            if (value)
            StartAndNotify();
        }
        /// <summary>
        /// Data Primary Key.
        /// </summary>
        /// <param name="dataPayLoad">Payload.</param>
        public void incomingPayload(DataPayLoad dataPayLoad)
        {
            DataPayLoad payload = dataPayLoad;
            if (payload != null)
            {
                if (_primaryKeyValue.Length == 0)
                {
                    _primaryKeyValue = payload.PrimaryKeyValue;
                    string mailboxName = "CommissionAgents." + _primaryKeyValue;
                    if (MailBoxHandler != null)
                    {
                        EventManager.RegisterMailBox(mailboxName, MailBoxHandler);
                    }
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
                        _primaryKeyValue = _commissionAgentDataServices.GetNewId();
                        Init(_primaryKeyValue, true);
                    }
                }
                else if (payload.PayloadType == DataPayLoad.Type.Delete)
                {
                    DeleteItem(payload.PrimaryKeyValue);

                }

            }
        }
        private void DeleteItem(string primaryKeyValue)
        {
            string primaryKey = primaryKeyValue;
            if (primaryKey == _primaryKeyValue)
            {
                ICommissionAgentDataServices commissionAgentDataServices =
                    DataServices.GetCommissionAgentDataServices();
                /*
                commissionAgentDataServices.DeleteCommissionAgent()
                ISupplierDataServices supplierDataServices = DataServices.GetSupplierDataServices();
                IDictionary<string, string> namedDictionary = _viewModelQueries;
                supplierDataServices.DeleteSupplier(_viewModelQueries, _currentDataSet);
                DataPayLoad payLoad = new DataPayLoad();
                payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
                payLoad.PrimaryKeyValue = primaryKey;
                payLoad.Queries = _viewModelQueries;
                payLoad.PayloadType = DataPayLoad.Type.Delete;
                EventManager.NotifyToolBar(payLoad);
                */
                _primaryKeyValue = "";
            }
        }

    }
}
