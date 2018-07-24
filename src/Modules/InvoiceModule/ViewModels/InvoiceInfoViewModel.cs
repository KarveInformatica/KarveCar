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
using System.Windows.Input;
using InvoiceModule.Common;
using KarveCommon;
using KarveControls;
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
    /// <inheritdoc />
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
                                    IInteractionRequestController controller) : base(dataServices,
                                                                                    controller,
                                                                                    dialogServices,
                                                                                    manager)
        {
            _dataServices = dataServices;
            _regionManager = regionManager;
            _invoiceDataService = _dataServices.GetInvoiceDataServices();

            SourceView = new ObservableCollection<InvoiceSummaryDto>();
            AssistMapper = _dataServices.GetAssistDataServices().Mapper;
            ItemChangedCommand = new Prism.Commands.DelegateCommand<IDictionary<string, object>>(OnChangedCommand);
            NavigateCommand = new DelegateCommand<object>(OnNavigate);
            AssistCommand = new DelegateCommand<object>(OnAssistCommand);
            AddNewClientCommand = new DelegateCommand<object>(OnAddNewClientCommand);
            OpenContractCommand = new DelegateCommand<object>(OnOpenContract);
            OpenVehiclesCommand = new DelegateCommand<object>(OnOpenVehicles);
            AssistExecuted += OnAssistExecuted;
            CompanyName = String.Empty;
            AddressName = String.Empty;
            List<string> colList;
            var genericInovice = new InvoiceSummaryDto();
            colList = genericInovice.GetType().GetProperties().Select(value => value.Name).ToList();

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
            CellGridPresentation = presenter;
            EventManager.RegisterObserverSubsystem(InvoiceModule.InvoiceSubSystem, this);
            var gid = Guid.NewGuid();
            GridIdentifier = GridIdentifiers.InvoiceLineGrids;
            ViewModelUri = new Uri("karve://invoice/viewmodel?id=" + gid.ToString());
            MailBoxHandler += IncomingMailBox;
            SubSystem = DataSubSystem.InvoiceSubsystem;
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
            var value = await dataServices.GetDoAsync(payLoad.PrimaryKeyValue);
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
                DataObject = clientDataServices.GetDoAsync(code),
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
            interpeter.CleanUp = CleanUp;
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


        private void CleanUp(DataPayLoad payLoad, DataSubSystem subsystem, string subsystemName)
        {
            var pKey = payLoad.PrimaryKeyValue;
            DeleteEventCleanup(pKey, PrimaryKeyValue, DataSubSystem.InvoiceSubsystem, EventSubsystem.InvoiceSubsystemVm);
            DeleteRegion();

        }
       
        /*
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
        */
        /// <summary>
        /// This answer the query
        /// </summary>
        /// <param name="assistTableName">Name of the query to answer</param>
        /// <param name="assistQuery">Query from the component to answer, it might be empty</param>
        /// <returns></returns>
        private async Task<bool> AssistQueryRequestHandler(string assistTableName, string assistQuery)
        {

            var value = await AssistMapper.ExecuteAssistGeneric(assistTableName, assistQuery);

            if (value == null)
            {
                return false;
            }

            switch (assistTableName)
            {
                case ClientAssist:
                    {

                        this.ClientDto = value as IncrementalList<ClientSummaryExtended>;
                        break;
                    }
                case InvoiceAssist:
                    {
                        this._invoiceSummary = (IEnumerable<InvoiceSummaryValueDto>)value;
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
                var dataObject = _invoiceData.Value;
                dataObject.InvoiceItems = _invoiceData.InvoiceItems;
                if (!dataObject.DTOPP.HasValue)
                {
                    dataObject.DTOPP = new decimal(0.03);
                }
                DataObject = ComputeTotals(dataObject);
                ClientDto = new IncrementalList<ClientSummaryExtended>(LoadMoreClients)
                { MaxItemCount = _invoiceData.NumberOfClients };
                ClientDto.LoadItems(_invoiceData.ClientSummary);

                SourceView = _invoiceData.InvoiceItems;
                _invoiceSummary = _invoiceData.InvoiceSummary;
                InvoiceDtos = new IncrementalList<InvoiceSummaryValueDto>(LoadMoreItems) { MaxItemCount = _invoiceSummary.Count() };

                ActiveSubSystem();
            }
        }

        private async void LoadMoreClients(uint arg1, int arg2)
        {
            var clientDs = _dataServices.GetClientDataServices();
            var pagedClient = await clientDs.GetPagedSummaryDoAsync(arg2, DefaultPageSize);
            ClientDto.LoadItems(pagedClient);

        }
        /// <summary>
        ///  Check the data context helper if has been clicked a agreement.
        /// </summary>
        /// <param name="helper">Data context helper</param>
        /// <returns>True if it is an agreement, false otherwise</returns>
        private bool IsAgreement(DataContextHelper helper)
        {
            var box = helper.Record as InvoiceSummaryDto;
            var helperCode = helper.Value as string;
            return ((helperCode != null) && (box != null) && (helperCode == box.AgreementCode));            
        }
        /// <summary>
        ///  Check the data context helper if has been clicked a agreement.
        /// </summary>
        /// <param name="helper">Data context helper</param>
        /// <returns>True if it is a vehicle, false otherwise</returns>

        private bool IsVehicle(DataContextHelper helper)
        {
            var box = helper.Record as InvoiceSummaryDto;
            var helperCode = helper.Value as string;
            return ((helperCode != null) && (box != null) && (helperCode == box.VehicleCode));
        }
        /// <summary>
        ///  This 
        /// </summary>
        /// <param name="obj"></param>
        private async void OnNavigate(object obj)
        {
            if (!(obj is DataContextHelper)) return;

            var helper = obj as DataContextHelper;
            var box = helper.Record as InvoiceSummaryDto;

       
            if (IsVehicle(helper))
            {
                const string query = "Code,Matricula,Brand,Model,VehicleGroup,Office,Places,Activity," +
                                     "Color,CubeMeters,Owner,AssuranceCompany,LeasingCompany,LeavingDate,StartingData," +
                                     "ClientNumber,Client,Policy,Kilometers,PurchaseInvoice,Frame,MotorNumber," +
                                     "ModelYear,Referencia,KeyCode,StorageKey";

                await OnVehicleSummaryAsync("Vehiculos", query, async delegate (VehicleSummaryDto vsdto)
                {
                    var dto = vsdto as VehicleSummaryDto;
                    await Task.Delay(1);
                    box.VehicleCode = vsdto.Code;

                }).ConfigureAwait(false);
            }
            else if (IsAgreement(helper))
            {


                const string contractValues = "Code,StartingFrom,ReturnDate,DeliveringPlace,Name," +
                                                "ClientCode,ClientName,DriverCode,DriverName,VehicleCode,RegistrationNumber,VehicleBrand,VehicleModel";
                await OnContractSummaryAsync("Contractos", contractValues, async delegate (ContractSummaryDto cdto)
                {
                    var dto = cdto as ContractSummaryDto;
                    box.AgreementCode = dto.Code;

                }).ConfigureAwait(false);


            }
           
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
        public IncrementalList<ClientSummaryExtended> ClientDto
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
         ///  Change the value on input
         /// </summary>
         /// <param name="eventDictionary">Event dictionary to be changed.</param>
        private void OnChangedCommand(IDictionary<string, object> eventDictionary)
        {

            var evDictionary = eventDictionary as IDictionary<string, object>;
            var changedDataObject = evDictionary["DataObject"];
            var payLoad = BuildDataPayload(eventDictionary);
            payLoad.Subsystem = DataSubSystem.InvoiceSubsystem;
            payLoad.SubsystemName = InvoiceModule.InvoiceSubsystemName;

            if (changedDataObject is IEnumerable<InvoiceSummaryDto> ev)
            {
                var invoiceSummaryDtos = ev as InvoiceSummaryDto[] ?? ev.ToArray();
                var aggregateRows = UpdateObject(evDictionary, invoiceSummaryDtos);

                var data = ComputeTotals(aggregateRows);
             //   data.InvoiceItems = invoiceSummaryDtos;
                DataObject = data;
                payLoad.DataObject = data;
                payLoad.Subsystem = DataSubSystem.InvoiceSubsystem;
                payLoad.Sender = ViewModelUri.ToString();
                payLoad.ObjectPath = ViewModelUri;
            }
            else
            {
               
                payLoad.PayloadType = DataPayLoad.Type.Update;
                payLoad.PrimaryKeyValue = PrimaryKeyValue;
                payLoad.HasDataObject = true;
                var dto = DataObject;
                dto.InvoiceItems = SourceView as IEnumerable<InvoiceSummaryDto>;
                payLoad.DataObject = DataObject;
                var uid = "invoice://" + Guid.ToString();
                payLoad.ObjectPath = new Uri(uid);
            }
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

        InvoiceDto UpdateObject(IDictionary<string, object> ev, IEnumerable<InvoiceSummaryDto> invoiceSummaryDtos)
        {
            var op = (ControlExt.GridOp) ev["Operation"];
            var dataObject = DataObject;

            if (ev.ContainsKey("ChangedValue"))
            {
                IEnumerable<InvoiceSummaryDto> summaryDtos = new List<InvoiceSummaryDto>();
                if (ev["ChangedValue"] is IEnumerable<object> changedValue)
                {
                    var localDtos = new List<InvoiceSummaryDto>();
                    foreach (var v in changedValue)
                    {
                        InvoiceSummaryDto dto = v as InvoiceSummaryDto;
                        localDtos.Add(dto);
                    }

                    switch (op)
                    {
                        case ControlExt.GridOp.Insert:
                            var currentValue = invoiceSummaryDtos.ToList();
                            summaryDtos = localDtos.Union(currentValue);
                            break;
                        case ControlExt.GridOp.Delete:
                            summaryDtos = invoiceSummaryDtos.Except(localDtos);
                            break;
                        case ControlExt.GridOp.Update:
                            var localIds = from x in localDtos select x.KeyId;
                            var enumerable = invoiceSummaryDtos as InvoiceSummaryDto[] ?? invoiceSummaryDtos.ToArray();
                            var toReplace = enumerable.Where(x => localIds.Contains(x.KeyId));
                            var invoiceDto = enumerable.Except(toReplace);
                            summaryDtos = invoiceDto.Union(localDtos);
                            break;
                    }
                }

                if (summaryDtos.Any())
                {
                    dataObject.InvoiceItems = summaryDtos;
                }

             
            }
            return dataObject;
        }

        InvoiceDto ComputeTotals(InvoiceDto aggregated)
        {
            // Fetch the data object and compute the totals.
            if (aggregated == null)
                return null;

            var dataObject = aggregated;
          
            var discount = new decimal(3);
            var ivaValue = new decimal(0.21);
         
            if (dataObject.DTOPP.HasValue)
            {
                discount = dataObject.DTOPP.Value;
            }
            if (dataObject.IVAPOR_FAC.HasValue)
            {
                ivaValue = dataObject.IVAPOR_FAC.Value;
            }

            if (dataObject.InvoiceItems != null)
            {
                var grossTotal = InvoiceHelpers.ComputeGrossTotal(dataObject.InvoiceItems);
                var baseValue = InvoiceHelpers.ComputeBase(dataObject.InvoiceItems, discount);
                dataObject.BRUTO_FAC = grossTotal;
                dataObject.BASE_FAC = baseValue;
                var computeIva = InvoiceHelpers.ComputeIva(baseValue, ivaValue);
                dataObject.TODO_FAC = baseValue + computeIva;
            }
            return dataObject;
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
        public List<string> GridColumns
        {
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
        private IncrementalList<ClientSummaryExtended> _clientValue;
        private IEnumerable<InvoiceSummaryValueDto> _invoiceSummary;
        private IncrementalList<InvoiceSummaryValueDto> _invoiceSummaryView;

        #endregion
        public const string InvoiceAssist = "INVOICE_ASSIST";
        public const string ClientAssist = "CLIENT_ASSIST";


    }
}
