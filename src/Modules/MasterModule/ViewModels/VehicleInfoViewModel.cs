using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using KarveCommon.Services;
using KarveDataServices;
using MasterModule.Common;
using KarveDataServices.DataObjects;
using KarveCommon.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;

namespace MasterModule.ViewModels
{
    /// <summary>
    ///  This represent the detailed class for the view model in case of each car.
    /// </summary>
    partial class VehicleInfoViewModel: MasterViewModuleBase, IEventObserver, IDataErrorInfo
    {
        /// <summary>
        ///  This the private basic data template selector.
        /// </summary>
        private DataTemplateSelector _dataTemplateSelector;
        /// <summary>
        ///  Vehicle Data Services.
        /// </summary>
        private IVehicleDataServices _vehicleDataServices;
        private IVehicleData _vehicleDo;
        private object _dataObject;
        private object _deleteNotifyTaskCompletion;
        private readonly PropertyChangedEventHandler _deleteEventHandler;
        private INotifyTaskCompletion<IVehicleData> _initializationTable;
        private DelegateCommand<object> _changedCommand;
        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="configurationService">This is the configurartion service</param>
        /// <param name="eventManager"> The event manager for sending/recieving messages from the view model</param>
        /// <param name="services">Data access layer interface</param>
        public VehicleInfoViewModel(IConfigurationService configurationService, IEventManager eventManager, IDataServices services) : 
            base(configurationService, eventManager, services)
        {
            _vehicleDataServices = services.GetVehicleDataServices();
            ItemChangedCommand = new DelegateCommand<object>(ChangeUnpack);
            EventManager.RegisterObserverSubsystem(MasterModuleConstants.VehiclesSystemName, this);
            
        }
        /// <summary>
        ///  This return a basic template selector for each item colletion.
        /// </summary>
        public DataTemplateSelector BasicTemplateSelector
        {
            
            get { return _dataTemplateSelector; }
            set { _dataTemplateSelector = value; RaisePropertyChanged(); }
        }

        public object DataObject
        {
            get { return _dataObject; }
            set { _dataObject = value;
                RaisePropertyChanged();
            }
        }


        private void ActiveSubSystem()
        {
            // change the active subsystem in the toolbar state.
            RegisterToolBar();
        }
        public string Error => throw new NotImplementedException();

        public string this[string columnName] => throw new NotImplementedException();

        /// <summary>
        /// This is the start notify.
        /// </summary>
        public override void StartAndNotify()
        {
            _initializationTable =
                NotifyTaskCompletion.Create<IVehicleData>(LoadDataValue(PrimaryKeyValue, IsInsertion), InitializationDataObjectOnPropertyChanged);
            throw new NotImplementedException();
        }

        private void InitializationDataObjectOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is IVehicleData)
            {
                IVehicleData vehicle = (IVehicleData) sender;
                DataObject = vehicle;
            }
        }
        public ICommand ItemChangedCommand { set; get; }

        private void ChangeUnpack(object value)
        {
            IDictionary<string,object> changedItem = value as IDictionary<string,object>;
            if (changedItem != null)
            {
                OnChangedField(changedItem);
            }
        }
        /// <summary>
        ///  OnChangedField. This method shall be changed.
        /// </summary>
        /// <param name="eventDictionary">Dictionary of events.</param>
        private void OnChangedField(IDictionary<string, object> eventDictionary)
        {
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.Subsystem = DataSubSystem.VehicleSubsystem;
            if (string.IsNullOrEmpty(payLoad.PrimaryKeyValue))
            {
                payLoad.PrimaryKeyValue = PrimaryKeyValue;
                payLoad.PayloadType = DataPayLoad.Type.Update;
            }
            if (eventDictionary.ContainsKey("DataObject"))
            {
                if (eventDictionary["DataObject"] == null)
                {
                    MessageBox.Show("DataObject is null.");
                }
            }
            ChangeFieldHandlerDo<IVehicleData> handlerDo = new ChangeFieldHandlerDo<IVehicleData>(EventManager,
                ViewModelQueries,
                DataSubSystem.VehicleSubsystem);

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
        /// This program loads the data from the data values.
        /// </summary>
        /// <param name="primaryKeyValue">Primary Key.</param>
        /// <param name="isInsertion">Inserted key.</param>
        /// <returns></returns>
        private async Task<IVehicleData> LoadDataValue(string primaryKeyValue, bool isInsertion)
        {

            IVehicleData vehicle = null;
            if (isInsertion)
            {
                vehicle = _vehicleDataServices.GetNewVehicleDo(PrimaryKeyValue);
                if (vehicle != null)
                {
                    DataObject = vehicle;
                }
            }
            else
            {
                vehicle = await _vehicleDataServices.GetVehicleDo(primaryKeyValue);
                DataObject = vehicle;
                
            }
            return vehicle;
        }

        public override void NewItem()
        {
        }
        protected override void SetTable(DataTable table)
        {
           
        }

        /// <summary>
        ///  This method set the registration payload.
        /// </summary>
        /// <param name="payLoad"></param>
        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.Subsystem = DataSubSystem.VehicleSubsystem;
        }
        protected override void SetDataObject(object result)
        {
        }

        /// <summary>
        ///  This give usa the routing name of a vehicle module.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected override string GetRouteName(string name)
        {
            return "VehicleMasterModule." + name;
        }

        /// <summary>
        /// This adds a primary and a payload
        /// </summary>
        /// <param name="primaryKeyValue">PrimaryKey</param>
        /// <param name="payload">Data payload to be loaded</param>
        /// <param name="insertable">Is an insert operation</param>
        private void Init(string primaryKeyValue, DataPayLoad payload, bool insertable)
        {
            if (payload.HasDataObject)
            {
                _vehicleDo = (IVehicleData) payload.DataObject;
                DataObject = _vehicleDo;
                EventManager.SendMessage(UpperBarViewVehicleViewModel.Name, payload);
                RegisterToolBar();
            }
        }
        /// <summary>
        /// Primary key payload.
        /// </summary>
        /// <param name="primaryKeyValue">This deletes an item.</param>
        private void DeleteItem(string primaryKeyValue)
        {
            string primaryKey = primaryKeyValue;
            if (primaryKey == PrimaryKeyValue)
            {
                DataPayLoad dataPayload = new DataPayLoad();
                dataPayload.HasDataObject = true;
                dataPayload.PrimaryKeyValue = PrimaryKeyValue;
                _deleteNotifyTaskCompletion = NotifyTaskCompletion.Create<DataPayLoad>(HandleDeleteItem(dataPayload), _deleteEventHandler);
                PrimaryKeyValue = "";
            }
        }

        /// <summary>
        /// Delete a commission agent.
        /// </summary>
        /// <param name="inDataPayLoad"></param>
        /// <returns></returns>
        private async Task<DataPayLoad> HandleDeleteItem(DataPayLoad inDataPayLoad)
        {
            IVehicleData vehicle = await _vehicleDataServices.GetVehicleDo(inDataPayLoad.PrimaryKeyValue);
            DataPayLoad payload = new DataPayLoad();
            if (vehicle.Valid)
            {
                bool returnValue = await _vehicleDataServices.DeleteVehicleDo(vehicle);
                if (returnValue)
                {
                    payload.Subsystem = DataSubSystem.VehicleSubsystem;
                    payload.PrimaryKeyValue = inDataPayLoad.PrimaryKeyValue;
                    payload.PayloadType = DataPayLoad.Type.Delete;
                    EventManager.NotifyToolBar(payload);
                    PrimaryKeyValue = "";
                    _vehicleDo = null;
                }
            }
            return payload;
        }
        /// <summary>
        /// Incoming payload
        /// </summary>
        /// <param name="dataPayLoad">Payload to be used.</param>
        public void IncomingPayload(DataPayLoad dataPayLoad)
        {

            DataPayLoad payload = dataPayLoad;

            if (payload != null)
            {
                if (PrimaryKeyValue.Length == 0)
                {
                    PrimaryKeyValue = payload.PrimaryKeyValue;
                    string mailboxName = "Vehicles." + PrimaryKeyValue;
                    if (MailBoxHandler != null)
                    {
                        EventManager.RegisterMailBox(mailboxName, MailBoxHandler);
                    }
                }
                // here i can fix the primary key
                switch (payload.PayloadType)
                {
                    case DataPayLoad.Type.UpdateView:
                    case DataPayLoad.Type.Show:
                    {
                        Init(PrimaryKeyValue, payload, false);
                        CurrentOperationalState = DataPayLoad.Type.Show;
                        break;
                    }
                    case DataPayLoad.Type.Insert:
                    {
                        if (string.IsNullOrEmpty(PrimaryKeyValue))
                        {
                            CurrentOperationalState = DataPayLoad.Type.Insert;
                            PrimaryKeyValue =
                                _vehicleDataServices.GetNewId();
                            Init(PrimaryKeyValue, true);
                        }
                        break;
                    }

                    case DataPayLoad.Type.Delete:
                    {
                        DeleteItem(payload.PrimaryKeyValue);
                        break;
                    }
                }
            }

        }
    }
}
