using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using KarveCommon.Services;
using KarveControls.UIObjects;
using KarveDataServices;
using MasterModule.Common;
using MasterModule.UIObjects.CommissionAgents;
using Prism.Commands;

namespace MasterModule.ViewModels
{
    /// <summary>
    /// This view model is the commission agent view model
    /// </summary>
    /// 
    /// CommissionAgentInfoViewModel
    public class CommissionAgentInfoViewModel : MasterViewModuleBase,IEventObserver
    {
        private Visibility _visibility;
        private DataTable _commissionTable;
        private ObservableCollection<IUiObject> _leftObservableCollection;
        private ObservableCollection<IUiObject> _rightObservableCollection;
        private ObservableCollection<IUiObject> _upperObservableCollection;
        /// <summary>
        /// ViewModel for the commission agent. 
        /// </summary>
        /// <param name="configurationService">The configuration service will be used in this case</param>
        /// <param name="eventManager">Event manager</param>
        /// <param name="services">Services to be used</param>

        public CommissionAgentInfoViewModel(IConfigurationService configurationService, 
                                            IEventManager eventManager, IDataServices services) : base(configurationService, eventManager, services)
        {

           
            PrimaryKeyValue = CommissionAgentConstants.PrimaryKey;
            LoadUserInterfaceObjects();
            ConfigurationService = configurationService;
            MailBoxHandler += MessageHandler;
            _visibility = Visibility.Collapsed;
            AssistDataSet = new DataSet();
            MagnifierCommand = new DelegateCommand<object>(MagnifierCommandHandler);
            ItemChangedCommand= new DelegateCommand<object>(ItemChangedHandler);
            EventManager.registerObserverSubsystem(MasterModule.CommissionAgentSystemName, this);

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
        ///  This load the user interface object for the upper part.
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
            if (collection.ContainsKey(MasterModule.UiLeftPartPage))
            {
                LeftValueCollection = collection[MasterModule.UiLeftPartPage];
            }
           // IDictionary<string, string> query = SQLBuilder.SqlBuildSelectFromUiObjects(collection[MasterModule.UiUpperPart], PrimaryKeyValue, false);
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
        public ObservableCollection<IUiObject> LeftValueCollection
        {
            set { _leftObservableCollection = value; RaisePropertyChanged(); }
            get { return _rightObservableCollection; }
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
        public ICommand ItemChangedCommand { set; get; }
        /// <summary>
        ///  Set or Get the vehicle is visible.
        /// </summary>
        public Visibility IsVisible
        {
            get { return _visibility; }
            set { _visibility = value; }
        }

        /// <summary>
        ///  Return the commissionist table.
        /// </summary>
        public string TableName
        {
            get { return "COMISIO"; }
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
        // TODO: this code shall reduced. The function is too long.
        private void OnChangedField(IDictionary<string, object> eventDictionary)
        {
            DataPayLoad payLoad = new DataPayLoad();
            if (CurrentOperationalState == DataPayLoad.Type.Insert)
            {
                payLoad.PayloadType = DataPayLoad.Type.Insert;
                payLoad.HasDataSetList = true;
                payLoad.Subsystem = DataSubSystem.SupplierSubsystem;
                DataTable table = (DataTable)eventDictionary["DataTable"];
                MergeTableChanged(table, ref CurrentDataSet);
                MergeTableChanged(table, ref AssistDataSet);
                KarveControls.UIObjects.SQLBuilder.StripTop(ref ViewModelQueries);
                payLoad.Queries = ViewModelQueries;
                List<DataSet> setList = new List<DataSet>();
                setList.Add(CurrentDataSet);
                setList.Add(AssistDataSet);
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
                string colName = (string)eventDictionary["Field"];
                object changedValue = eventDictionary["ChangedValue"];

                string tableName = table.TableName;
                bool foundTable = false;
                foreach (DataTable currentTable in CurrentDataSet.Tables)
                {
                    if (currentTable.TableName == tableName)
                    {
                        foundTable = true;
                        break;
                    }
                }
                if (foundTable)
                {
                   CurrentDataSet.Tables[tableName].Merge(table);
                    DataRowState state = CurrentDataSet.Tables[tableName].Rows[0].RowState;
                    payLoad.HasDataSet = true;
                    payLoad.Set = CurrentDataSet;
                    EventManager.NotifyToolBar(payLoad);
                    payLoad.Queries = ViewModelQueries;
                }
                else
                {

                    foreach (DataTable currentTable in AssistDataSet.Tables)
                    {
                        if (currentTable.TableName == tableName)
                        {
                            foundTable = true;
                            break;
                        }
                    }
                    if (foundTable)
                    {
                        AssistDataSet.Tables[tableName].Merge(table);
                        payLoad.Set = AssistDataSet;
                        payLoad.Queries = ViewModelQueries;
                        EventManager.NotifyToolBar(payLoad);
                    }
                }
            }
        }
        /// <summary>
        ///  This method starts and notify the view model
        /// </summary>
        public override void StartAndNotify()
        {
          //  throw new NotImplementedException();
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

        protected override string GetRouteName(string name)
        {
            //throw new NotImplementedException();
            return "CommisionAgentNewInfo";
        }

        public void incomingPayload(DataPayLoad payload)
        {
        //    throw new NotImplementedException();
        }
    }
}
