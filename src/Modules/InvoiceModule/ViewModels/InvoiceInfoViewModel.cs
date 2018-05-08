using System;
using System.Collections.Generic;
using KarveCommon.Generic;
using KarveDataServices;
using KarveCommonInterfaces;
using KarveCommon.Services;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using InvoiceModule.Views;
using KarveCommon;
using KarveDataServices.DataTransferObject;
using KarveControls.Behaviour.Grid;
using KarveControls.HeaderedWindow;
using KarveDataServices.DataObjects;
using Microsoft.Practices.Unity;
using NLog;
using Prism.Interactivity.InteractionRequest;
using Syncfusion.Windows.Shared;
using MasterModule.Views;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Cells;
namespace InvoiceModule.ViewModels
{
    /// <summary>
    ///  View model for the info view.
    /// </summary>
    public class InvoiceInfoViewModel : KarveRoutingBaseViewModel, IEventObserver, IDisposeEvents
    {
       

        /// <summary>
        /// InvoiceInfoViewModel.
        /// </summary>
        /// <param name="dataServices">DataServices</param>
        /// <param name="dialogServices"></param>
        /// <param name="manager"></param>
        /// <param name="container"></param>
        /// <param name="regionManager"></param>
        /// <param name="controller"></param>

        public InvoiceInfoViewModel(IDataServices dataServices,
                                    IDialogService dialogServices,
                                    IEventManager manager,
                                    
                                    IRegionManager regionManager, 
                                    IInteractionRequestController controller): base(dataServices,
                                                                                    controller, 
                                                                                    dialogServices,
                                                                                    manager)
        {
            _dataServices = dataServices;
            _regionManager = regionManager;
            _invoiceDataService = _dataServices.GetInvoiceDataServices();
            
            SourceView = new ObservableCollection<InvoiceSummaryDto>();
            AssistMapper=_dataServices.GetAssistDataServices().Mapper;
            ItemChangedCommand = new Prism.Commands.DelegateCommand<IDictionary<string,object>>(OnChangedCommand);
            NavigateCommand = new DelegateCommand<object>(OnNavigate);
            AssistCommand = new DelegateCommand<object>(OnAssistCommand);
            AddNewClientCommand = new DelegateCommand<object>(OnAddNewClientCommand);
            OpenContractCommand = new DelegateCommand<object>(OnOpenContract);
            OpenVehiclesCommand = new DelegateCommand<object>(OnOpenVehicles);
            AssistExecuted += OnAssistExecuted;
            CompanyName = String.Empty;
            AddressName = String.Empty;
            List<string> colList;
            colList = new List<string>();
            var genericInovice = new InvoiceSummaryDto();
            foreach (var value in genericInovice.GetType().GetProperties())
            {
                colList.Add(value.Name);
            }
         
            GridColumns = new List<string>()
            {
                "AgreementCode","VehicleCode", "Opciones", "Description", "Quantity", "Price", "Discount", "Subtotal",
                "Unity", "Iva"
            };
            /*
             * This is a cell grid presentation item 
             */
           var presenter = new ObservableCollection<CellPresenterItem>()
            {
                new NavigationAwareItem() { DataTemplateName="NavigateInvoiceItem", MappingName="AgreementCode", RegionName=RegionNames.LineRegion},
                new NavigationAwareItem() { DataTemplateName="NavigateVehicleItem", MappingName="VehicleCode", RegionName=RegionNames.LineRegion}
            };
            CellGridPresentation= presenter;
            EventManager.RegisterObserverSubsystem(InvoiceModule.InvoiceSubSystem, this);
            var gid = Guid.NewGuid();
            ViewModelUri = new Uri("karve://invoice/viewmodel?id=" + gid.ToString());
            MailBoxHandler += IncomingMailBox;
            RegisterMailBox(ViewModelUri.ToString());
        }
        private void IncomingMailBox(DataPayLoad payload)
        {
            var payLoadType = payload.PayloadType;
            var key = payload.PrimaryKeyValue;
            
                if ((payload.Sender != null) && (payload.Sender == ViewModelUri.ToString()))
                {
                    return;
                }

                if (payLoadType == DataPayLoad.Type.Delete && payload.PrimaryKeyValue == PrimaryKeyValue)
                {
                    base.HandleMessageBoxPayLoad(payload);
                    DeleteItem(payload);
                    PrimaryKeyValue = "";
                }

                // forward to the controller
                if (payload.PayloadType == DataPayLoad.Type.Insert)
                {
                    payload.Sender = ViewModelUri.ToString();
                    EventManager.NotifyObserverSubsystem(InvoiceModule.InvoiceSubSystem, payload);
                }
            

        }

        protected override void DeleteItem(DataPayLoad payLoad)
        {   
            NotifyTaskCompletion.Create<bool>(this.DeleteAsync(payLoad),
                ev: (sender, args) =>
                {
                    if (!(sender is INotifyTaskCompletion<bool> taskCompletion))
                    {
                        return;
                    }
                    if (taskCompletion.IsFaulted)
                    {
                        DialogService?.ShowErrorMessage("Error during deleting the invoice");
                    }

                    if (!taskCompletion.IsSuccessfullyCompleted)
                    {
                        return;
                    }
                    var dataPayLoad = new DataPayLoad()
                    {
                        Sender = ViewModelUri.ToString(),
                        PayloadType = DataPayLoad.Type.UpdateView
                    };
                    EventManager.NotifyObserverSubsystem(InvoiceModule.InvoiceSubSystem, dataPayLoad);
                    UnregisterToolBar(payLoad.PrimaryKey);

                    DeleteRegion();
                });
               
        }

        protected async Task<bool> DeleteAsync(DataPayLoad payLoad)
        {
            var dataServices = _dataServices.GetInvoiceDataServices();
            var value = await dataServices.GetInvoiceDoAsync(payLoad.PrimaryKeyValue);
            if (!value.Valid)
            {
                return false;
            }

            var retValue = await dataServices.DeleteAsync(value);
            return retValue;
        }

        private void OnOpenVehicles(object obj)
        {
            MessageBox.Show("OpenVehicle");

        }

        private void OnOpenContract(object obj)
        {
            MessageBox.Show("OpenContract");
        }

        private ICommand OpenContractCommand { set; get; }
        private ICommand OpenVehiclesCommand { set; get; }
        /// <summary>
        /// Navigate to the view
        /// </summary>
        /// <param name="code">Code of the view to navigate</param>
        /// <param name="viewName">Viewname to view</param>
        private void Navigate(string code, string viewName)
        {
            var navigationParameters = new NavigationParameters
            {
                { "id", code },
                { ScopedRegionNavigationContentLoader.DefaultViewName, viewName }
            };
            var uri = new Uri(typeof(ClientsInfoView).FullName + navigationParameters, UriKind.Relative);
            _regionManager.RequestNavigate("TabRegion", uri);
        }

        /// <summary>
        ///  This effectively add a new client.
        /// </summary>
        /// <param name="obj"></param>
        private void OnAddNewClientCommand(object obj)
        {
            var clientDataServices = _dataServices.GetClientDataServices(); 
            var code = clientDataServices.GetNewId();
            Navigate(code, "NuevoCliente");
            var currentPayload = new DataPayLoad
            {
                Subsystem = DataSubSystem.ClientSubsystem,
                PayloadType = DataPayLoad.Type.Insert,
                PrimaryKeyValue = code,
                HasDataObject = true,
                DataObject = clientDataServices.GetNewClientAgentDo(code),
                Sender = EventSubsystem.ClientSummaryVm
            };
            EventManager.NotifyObserverSubsystem(EventSubsystem.ClientSummaryVm, currentPayload);
        }

        public override void DisposeEvents()
        {
            base.DisposeEvents();
            DeleteMailBox(ViewModelUri.ToString());
            EventManager.DeleteObserverSubSystem(InvoiceModule.InvoiceSubSystem, this);
            AssistExecuted -= OnAssistExecuted;
        }

        private void LoadMoreItems(uint count, int baseIndex)
        {
            var list = _invoiceSummary.Skip(baseIndex).Take(50).ToList();
            InvoiceDtos.LoadItems(list);
        }
        private void OnAssistExecuted(object sender, PropertyChangedEventArgs e)
        {
            var notificationCompletion = sender as INotifyTaskCompletion<bool>;
            if (notificationCompletion == null)
            {
                return;
            }
            if (!notificationCompletion.Task.IsFaulted)
            {
                return;
            }
            var errorAssist = "Error during assist: " + notificationCompletion.ErrorMessage;
            DialogService?.ShowErrorMessage(errorAssist);
        }

        public DataPayLoad.Type OperationalState { get; set; }


        private void OnAssistCommand(object param)
        {
            IDictionary<string, string> values = (Dictionary<string, string>)param;
            string assistTableName = values.ContainsKey("AssistTable") ? values["AssistTable"] as string : null;
            string assistQuery = values.ContainsKey("AssistQuery") ? values["AssistQuery"] as string : null;
            this.AssistNotifierInitialized = NotifyTaskCompletion.Create<bool>(AssistQueryRequestHandler(assistTableName, assistQuery), AssistExecuted);
        }

        /// <summary>
        ///  Incoming Payload
        /// </summary>
        /// <param name="dataPayLoad">This is the incoming payload that it is working on.</param>
        public void IncomingPayload(DataPayLoad dataPayLoad)
        {
            if (dataPayLoad == null)
            {
                return;
            }
            var interpeter = new PayloadInterpeter<IInvoiceData>();
            var currentId = _invoiceDataService.NewId();
            interpeter.Init = Init;
            interpeter.CleanUp= CleanUp;
            if (string.IsNullOrEmpty(PrimaryKeyValue))
            {
                PrimaryKeyValue = dataPayLoad.PrimaryKeyValue;
            }

            if (string.IsNullOrEmpty(PrimaryKeyValue))
                return;

            // check if this message is for me.
            if (PrimaryKeyValue.Length > 0)
            {
                if (!(dataPayLoad.DataObject is InvoiceDto dto))
                {
                    if (dataPayLoad.DataObject is IInvoiceData domainObject)
                    {
                        if (domainObject.Value.NUMERO_FAC != PrimaryKeyValue)
                        {
                            return;
                            
                        }
                    }
                }
                else
                {
                    if (dto.NUMERO_FAC != PrimaryKeyValue)
                    {
                        return;

                    }

                }
            }
            OperationalState = interpeter.CheckOperationalType(dataPayLoad);
          //  PrimaryKeyValue = dataPayLoad.PrimaryKeyValue;
            interpeter.ActionOnPayload(dataPayLoad, PrimaryKeyValue, currentId, DataSubSystem.InvoiceSubsystem, EventSubsystem.InvoiceSubsystemVm);
        }

        
        private void CleanUp(string primarykey, DataSubSystem subsystem, string subsystemName)
        {
            DeleteEventCleanup(primarykey, PrimaryKeyValue, DataSubSystem.InvoiceSubsystem, EventSubsystem.InvoiceSubsystemVm);
            DeleteRegion();

        }
        /// <summary>
        ///  This delete the region when there is a delete.
        /// </summary>
        private void DeleteRegion()
        {
            var activeRegion = _regionManager.Regions[RegionName].ActiveViews.FirstOrDefault();
            switch (activeRegion)
            {
                case null:
                    return;
                case HeaderedWindow _:
                    if (activeRegion is HeaderedWindow invoiceInfo)
                    {
                    _regionManager.Regions[RegionName].Remove(invoiceInfo);
                    }
                    break;
                case FrameworkElement _:
                    var framework = activeRegion as FrameworkElement;
                    framework?.ClearValue(RegionManager.RegionManagerProperty);
                    break;
            }
        }
        /// <summary>
        /// This answer the query
        /// </summary>
        /// <param name="assistTableName">Name of the query to answer</param>
        /// <param name="assistQuery">Query from the component to answer, it might be empty</param>
        /// <returns></returns>
        private async Task<bool> AssistQueryRequestHandler(string assistTableName, string assistQuery)
        {

            var value = await AssistMapper.ExecuteAssist(assistTableName, assistQuery);

            if (value == null)
            {
                return false;
            }

            switch (assistTableName)
            {
                case ClientAssist:
                {
                    this.ClientDto = (IEnumerable<ClientSummaryDto>) value;
                    break;
                }
                case InvoiceAssist:
                {
                    this._invoiceSummary = (IEnumerable<InvoiceSummaryValueDto>) value;
                    InvoiceDtos = new IncrementalList<InvoiceSummaryValueDto>(LoadMoreItems) { MaxItemCount = _invoiceSummary.Count() };
                    break;
                }
                default:
                {
                    throw new ArgumentException("In the assist you neeed simply a valid tag");
                }

            }

            return true;

        }
        /// <summary>
        ///  Initialize the invoice
        /// </summary>
        /// <param name="value"></param>
        /// <param name="payload">Invoice payload to be used</param>
        /// <param name="insertion">To be or not inserted</param>
        private void Init(string value, DataPayLoad payload, bool insertion)
        {
            if (!payload.HasDataObject)
            {
                return;
            }
            if (payload.DataObject is IInvoiceData invoiceData)
            {
                _invoiceData = invoiceData;
                DataObject = _invoiceData.Value;
                ClientDto= _invoiceData.ClientSummary;
                SourceView = _invoiceData.InvoiceItems;
                _invoiceSummary = _invoiceData.InvoiceSummary;
                InvoiceDtos  = new IncrementalList<InvoiceSummaryValueDto>(LoadMoreItems) { MaxItemCount = _invoiceSummary.Count() };

                ActiveSubSystem();
            }
        }
        /// <summary>
        ///  This 
        /// </summary>
        /// <param name="obj"></param>
        private async void OnNavigate(object obj)
        {
            if (!(obj is TextBox box)) return;
            var boxName = box.Name;
            var value = box.Text;
            if (boxName.Contains("VehicleItemBox"))
            {
                const string query = "Code,Matricula,Brand,Model,VehicleGroup,Office,Places,Activity," +
                                     "Color,CubeMeters,Owner,AssuranceCompany,LeasingCompany,LeavingDate,StartingData," +
                                     "ClientNumber,Client,Policy,Kilometers,PurchaseInvoice,Frame,MotorNumber," +
                                     "ModelYear,Referencia,KeyCode,StorageKey";

                await OnVehicleSummaryAsync("Vehiculos", query ,async delegate (VehicleSummaryDto vsdto)
                {
                    var dto = vsdto as VehicleSummaryDto;
                      
                    await SetVehicleSummary(vsdto);

                }).ConfigureAwait(false);
            }
            else
            {

     
                const string contractValues = "Code,StartingFrom,ReturnDate,DeliveringPlace,Name," +
                                                "ClientCode,ClientName,DriverCode,DriverName,VehicleCode,RegistrationNumber,VehicleBrand,VehicleModel";
                await OnContractSummaryAsync("Contractos", contractValues, async delegate(ContractSummaryDto cdto)
                {
                    var dto = cdto as ContractSummaryDto;
                    await SetContractSummary(cdto);
                }).ConfigureAwait(false);

                
            }
        }

        private  async Task SetContractSummary(ContractSummaryDto cdto)
        {
            await Task.Delay(1);
        }


        internal async Task SetVehicleSummary(VehicleSummaryDto vsdto)
        {
            await Task.Delay(1);
        }
        /// <summary>
        ///  Data object for the invoice.
        /// </summary>
        public InvoiceDto DataObject
        {
            set { _invoiceDataValue = value; RaisePropertyChanged(); }
            get => _invoiceDataValue;
        }

        /// <summary>
        /// Summary of the client.
        /// </summary>
        public IEnumerable<ClientSummaryDto> ClientDto
        {
            get => _clientValue;
            set
            {
                _clientValue = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Summary of the invoice.
        /// </summary>
        public IncrementalList<InvoiceSummaryValueDto> InvoiceDtos
        {
            get => _invoiceSummaryView;
            set { _invoiceSummaryView = value; RaisePropertyChanged(); }
        }
        /// <summary>
        ///  Notification Request.
        /// </summary>
        public InteractionRequest<INotification> NotificationRequest
        {
            get => _notificationRequest;
            set
            {
                _notificationRequest = value;
                RaisePropertyChanged("NotificationRequest");
            }
        }

        /// <summary>
        /// OnChangedCommand. It is a command to be changed.
        /// </summary>
        /// <param name="dict">Dictionary</param>
        private void OnChangedCommand(IDictionary<string, object> eventDictionary)
        {
            DataPayLoad payLoad = BuildDataPayload(eventDictionary);
            payLoad.Subsystem = DataSubSystem.InvoiceSubsystem;
            payLoad.SubsystemName = InvoiceModule.InvoiceSubsystemName;
            payLoad.PayloadType = DataPayLoad.Type.Update;
            payLoad.PrimaryKeyValue = PrimaryKeyValue;
            payLoad.HasDataObject = true;
            var dto = DataObject;
            dto.InvoiceItems = SourceView as IEnumerable<InvoiceSummaryDto>;
            payLoad.DataObject = DataObject;
            var uid = "invoice://" + Guid.ToString();
            payLoad.ObjectPath = new Uri(uid);
            var handlerDo = new ChangeFieldHandlerDo<InvoiceDto>(EventManager, DataSubSystem.InvoiceSubsystem);

            if (OperationalState == DataPayLoad.Type.Insert)
            {
                handlerDo.OnInsert(payLoad, eventDictionary);
            }
            else
            {
                payLoad.PayloadType = DataPayLoad.Type.Update;
                
                handlerDo.OnUpdate(payLoad, eventDictionary);
            }

        }
        /// <summary>
        ///  Items to be shown in the lower grid.
        /// </summary>
        public object SourceView
        {
            set
            {
                _sourceView = value;
                RaisePropertyChanged("SourceView");
            }
            get => _sourceView;
        }

        public string CompanyName
        {
            get; set;
        }

        public string AddressName
        {
            get; set;
        }
        /// <summary>
        ///  Columns of the grid.
        /// </summary>
        public List<string> GridColumns {
            set
            {
                _gridView = value;
                RaisePropertyChanged("GridColumns");
            }
            get => _gridView;
        }

        public ICommand NavigateCommand { set; get; }
        /// <summary>
        ///  This function will add a new client.
        /// </summary>
        public ICommand AddNewClientCommand { set; get; }

        public DelegateCommand<object> AssistCommand { get; }

        /// <summary>
        ///  Opciones to be loaded in the grid.
        /// </summary>
        public ObservableCollection<CellPresenterItem> CellGridPresentation
        {
            get => _cellNavigationAware;
            set
            {
                _cellNavigationAware = value;
                RaisePropertyChanged("CellGridPresentation");
            }
        }

        protected override string GetRouteName(string name)
        {
            string routedName = "InvoiceInfoModule" + name;
            return routedName;
        }

        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.Subsystem = DataSubSystem.InvoiceSubsystem;
            payLoad.ObjectPath = ViewModelUri;
        }

        #region Private fields.
        private IDataServices _dataServices;
        private IRegionManager _regionManager;
        private IInvoiceDataServices _invoiceDataService;
        private IUnityContainer _unityContainer;
      
        private object _sourceView;
        private List<string> _gridView;
        private InteractionRequest<INotification> _notificationRequest;
        private ObservableCollection<CellPresenterItem> _cellNavigationAware;
        private IInvoiceData _invoiceData;
        private InvoiceDto _invoiceDataValue;
        private IEnumerable<ClientSummaryDto> _clientValue;
        private IEnumerable<InvoiceSummaryValueDto> _invoiceSummary;
        private IncrementalList<InvoiceSummaryValueDto> _invoiceSummaryView;

        #endregion
        public const string InvoiceAssist = "INVOICE_ASSIST";
        public const string ClientAssist = "CLIENT_ASSIST";


    }
}
