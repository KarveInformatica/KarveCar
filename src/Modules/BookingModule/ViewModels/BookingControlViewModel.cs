using System.Collections.Generic;
using System.ComponentModel;
using BookingModule.Views;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Syncfusion.UI.Xaml.Grid;
using Prism.Regions;
using System;
using KarveControls.HeaderedWindow;
using Microsoft.Practices.Unity;
using Syncfusion.Windows.Shared;
using KarveDataServices.DataObjects;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookingModule.ViewModels
{
    /// <summary>
    ///  View model to control the flow of a booking.
    /// </summary>
    public class BookingControlViewModel : KarveControlViewModel, ICreateRegionManagerScope
    {
        private INotifyTaskCompletion<IEnumerable<BookingSummaryDto>> _bookingSummaryCompletion;
        private readonly IBookingDataService _bookingDataService;
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        public DelegateCommand<object> OpenItemCommand { get; }

        private IRegionManager _detailsRegionManager;

        private PropertyChangedEventHandler _bookingLoadEventHandler;

        public DelegateCommand<object> NavigateClient { get; set; }

        private PayloadInterpeter<BookingSummaryDto> _payloadInterpeterReload;
        private PayloadInterpeter<IBookingData> _payloadInterpeter;
        private string _itemsCounts;
        private int _counterInterval;

        public ICommand CancelBook { get; set; }

        //  public DataPayLoad.Type OperationalState { get; private set; }

        /// <summary>
        ///  The region shall be scoped.
        /// </summary>
        public bool CreateRegionManagerScope =>  true;

        public BookingControlViewModel(IRegionManager regionManager, IDataServices services, IUnityContainer container, IInteractionRequestController requestController, IDialogService dialogService, IEventManager eventManager) : base(services, requestController, dialogService, eventManager)
        {

            _bookingDataService = DataServices.GetBookingDataService();
            _regionManager = regionManager;
            _container = container;
            // set the name to the listing grid.
            ItemName = "Reservas";
            DefaultPageSize = 50;
            _counterInterval = 0;
            CancelBook = new DelegateCommand<object>(OnCancelBook);
            ViewModelUri = new Uri("karve://booking/viewmodel?id=" + UniqueId);
            InitViewModel();
        }

        private void OnCancelBook(object obj)
        {
            DialogService?.ShowErrorMessage("Cannot cancel this booking");
        }

        private void InitViewModel()
        {
            MailBoxHandler += OnMailBoxHandler;
            MailboxName = ViewModelUri.ToString();
            RegisterMailBox(MailboxName);
            EventManager.RegisterObserverSubsystem(EventSubsystem.BookingSubsystemVm, this);
            EventManager.RegisterMailBox(ViewModelUri.ToString(), MailBoxHandler);
            _bookingLoadEventHandler += OnNotifyIncrementalList<BookingSummaryDto>;
            SummaryView = new IncrementalList<BookingSummaryDto>(LoadMoreItems);
            OpenCommand = new DelegateCommand<object>(OpenCurrentItem);
            NavigateClient = new DelegateCommand<object>(OnNavigateClient);

            _payloadInterpeterReload = new PayloadInterpeter<BookingSummaryDto>();
            _payloadInterpeterReload.Init = (value, packet, insertion) =>
              {
                  switch (packet.PayloadType)
                  {
                      case DataPayLoad.Type.UpdateView:
                          StartAndNotify();
                          break;
                  };
              };
            _payloadInterpeterReload.CleanUp = (key, system, name) =>
             {
               //  up to now.
             };
            _payloadInterpeter = new PayloadInterpeter<IBookingData>();
            InitPayLoadInterpeter(_payloadInterpeter);
             RegisterToolBar();
             StartAndNotify();
        }

        private void OnNavigateClient(object obj)
        {
            throw new NotImplementedException();
        }

        private PayloadInterpeter<IBookingData> InitPayLoadInterpeter(PayloadInterpeter<IBookingData> payloadInterpeter)
        {
            payloadInterpeter.Init = (value, packet, insertion) =>
            {
                // ok i shall do a new
                if (insertion)
                {
                    NewItem();

                }
                else
                {
                    if (packet.Sender == ViewModelUri.ToString())
                    {
                        return;
                    }
                    switch (packet.PayloadType)
                    {
                        case DataPayLoad.Type.UpdateView:
                            {

                                StartRefresh();
                                

                            }
                            break;
                        case DataPayLoad.Type.Insert:
                            NewItem();
                            break;
                    }

                }
            };
            payloadInterpeter.CleanUp = (key, system, name) =>
            {

                DisposeEvents();

            };
            return payloadInterpeter;
        }
        private void MailboxHandlerName(DataPayLoad payload)
        {
            OperationalState = _payloadInterpeter.CheckOperationalType(payload);
            _payloadInterpeter.ActionOnPayload(payload, payload.PrimaryKeyValue, string.Empty, DataSubSystem.BookingSubsystem, BookingModule.BookingSubSystem);
       
        }


        /// <summary>
        ///     This true if it is a navigation target.
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        ///     This is if it is navigated from.
        /// </summary>
        /// <param name="navigationContext">Navigation context</param>
        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }


        public void StartRefresh()
        {
            Task<IEnumerable<BookingSummaryDto>> t = _bookingDataService.GetPagedSummaryDoAsync(1, 50);
            
            NotifyTaskCompletion.Create<IEnumerable<BookingSummaryDto>>(t, (sender, ev) =>
            {
                if (SummaryView is IncrementalList<BookingSummaryDto> summary)
                {
                    summary.Clear();
                }
               
                OnPagedEvent(sender, ev);
            }
           );

        }

        /// <summary>
        ///  StartAndNotify.
        /// </summary>
        public void StartAndNotify()
        {
            
            _bookingSummaryCompletion = NotifyTaskCompletion.Create<IEnumerable<BookingSummaryDto>>(
                _bookingDataService.GetPagedSummaryDoAsync(1, DefaultPageSize), (sender, ev)=> 
                {
                    if (sender is INotifyTaskCompletion<IEnumerable<BookingSummaryDto>> bookingSummary)
                    {
                        if (bookingSummary.IsFaulted)
                        {
                            DialogService?.ShowErrorMessage("Cannot load booking summary");
                            return;
                        }
                        var booking = bookingSummary.Result;
                        var maxItems = _bookingDataService.NumberItems;
                        PageCount = _bookingDataService.NumberPage;
                        ItemCounts = maxItems.ToString();
                        var bookingList = new IncrementalList<BookingSummaryDto>(LoadMoreItems) { MaxItemCount = (int)maxItems };
                        bookingList.LoadItems(booking);
                        SummaryView = bookingList;
                    }
                });
        }
       
        /// <summary>
        ///     This open a current item value.
        ///     Asyc void shall be considered bad always
        ///     except when used through command.s
        /// </summary>
        /// <param name="value">value recevied</param>
        private async void OpenCurrentItem(object value)
        {
            if (!(value is BookingSummaryDto reservation)) return;
            if (string.IsNullOrEmpty(reservation.ClientCode))
            {
                return;
            }
            var name = reservation.ClientCode;
            var id = reservation.BookingNumber;
            var tabName =  "Reserva."+id;           
            CreateNewItem(tabName);
            var provider = await _bookingDataService.GetDoAsync(id).ConfigureAwait(false);         
            var currentPayload = BuildShowPayLoadDo(tabName, provider);
            currentPayload.DataObject = provider;
            currentPayload.Subsystem = DataSubSystem.BookingSubsystem;
            currentPayload.PrimaryKeyValue = id;
            //ActiveSubSystem();
            currentPayload.Sender = ViewModelUri.ToString();
            EventManager.NotifyObserverSubsystem(BookingModule.BookingSubSystem, currentPayload);
        }

        private void CreateNewItem(string name)
        {
            // The composite.
            var detailsRegion = _regionManager.Regions[RegionNames.TabRegion];
            var headeredWindow = _container.Resolve<HeaderedWindow>();
            headeredWindow.Header = name;
            var infoView = _container.Resolve<BookingInfoView>();
            var lineview = _container.Resolve<LineGridView>();
            var footerView = _container.Resolve<BookingFooterView>();
            /* 
             * Resolve the view model. Kind of view model first approach. We can use a LineGridView 
             * for every kind of subject and for the specific.
             *  This allows the reuse better than view.
             */
            var vm = _container.Resolve<BookingInfoViewModel>();
            infoView.DataContext = vm;
            lineview.DataContext = vm;
            footerView.DataContext = vm;
            headeredWindow.DataContext = vm;
            _detailsRegionManager = detailsRegion.Add(headeredWindow, null, true);
            var headerRegion = _detailsRegionManager.Regions[RegionNames.HeaderRegion];
            var lineRegion = _detailsRegionManager.Regions[RegionNames.LineRegion];
            var footerRegion = _detailsRegionManager.Regions[RegionNames.FooterRegion];
            lineRegion.Add(lineview, null, true);
            headerRegion.Add(infoView, null, true);
            footerRegion.Add(footerView, null, true);
            headeredWindow.Focus();
        }

        private void Navigate(string code, string viewName)
        {
            Navigate<BookingInfoView>(_regionManager, code, viewName);
        }

        /// <summary>
        ///     Create a new invoice.
        /// </summary>
        protected override void NewItem()
        {
            var id = _bookingDataService.NewId();
            var newDo = _bookingDataService.GetNewDo(id);
            newDo.Value.NUMERO_RES = id;
            var viewName = "Nueva " + "." + id;
            CreateNewItem(id);
            var currentPayload = BuildShowPayLoadDo(viewName, newDo);
            currentPayload.Subsystem = DataSubSystem.BookingSubsystem;
            currentPayload.PayloadType = DataPayLoad.Type.Insert;
            currentPayload.PrimaryKeyValue = id;
            currentPayload.Sender = ViewModelUri.ToString();
            EventManager.NotifyObserverSubsystem(BookingModule.BookingSubSystem, currentPayload);
       
        }
        protected override string GetRouteName(string name)
        {
            var route = @"booking://" + BookingModule.BookingSubSystem + "//" + name;
            var routedName = new Uri(route).AbsoluteUri;
            return routedName;
        }
        protected void LoadMoreItems(uint count, int baseIndex)
        {
            NotifyTaskCompletion.Create<IEnumerable<BookingSummaryDto>>(
                _bookingDataService.GetPagedSummaryDoAsync(baseIndex, DefaultPageSize), PagingEvent);

        }
        protected override void OnPagedEvent(object sender, PropertyChangedEventArgs eventArgs)
        {
            if (sender is INotifyTaskCompletion<IEnumerable<BookingSummaryDto>> completion)
            {
                if (completion.IsSuccessfullyCompleted)
                {
                    if (SummaryView is IncrementalList<BookingSummaryDto> summary)
                    {
                       
                        summary.LoadItems(completion.Result);
                        SummaryView = summary;
                    }
                }
                else
                {
                    DialogService.ShowErrorMessage("Not completed");
                }
            }
        }
        protected override void SetResult<T>(IEnumerable<T> result)
        {
            switch (result)
            {
                case IEnumerable<BookingSummaryDto> booking:
                    var maxItems = _bookingDataService.NumberItems;
                    PageCount = _bookingDataService.NumberPage;
                    ItemCounts = maxItems.ToString();
                    var bookingList = new IncrementalList<BookingSummaryDto>(LoadMoreItems) { MaxItemCount = (int)maxItems };
                    bookingList.LoadItems(booking);
                    
                    SummaryView = bookingList;
                    break;
            }
        }

        public override void DisposeEvents()
        {
            base.DisposeEvents();
            _bookingLoadEventHandler -= OnNotifyIncrementalList<BookingSummaryDto>;
            MailBoxHandler -= OnMailBoxHandler;
            DeleteMailBox(ViewModelUri.ToString());
            EventManager.DeleteObserverSubSystem(BookingModule.BookingSubSystem, this);

        }

        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            if (payLoad == null)
            {
                payLoad = new DataPayLoad();
            }
            payLoad.Subsystem = DataSubSystem.BookingSubsystem;
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.HasDataObject = false;
            payLoad.HasRelatedObject = false;
            payLoad.Sender = ViewModelUri.ToString();
        }
      
        public override void IncomingPayload(DataPayLoad payload)
        {
            var newId = _bookingDataService.NewId();
            if ((payload.Sender!=null) && (payload.Sender.Equals(ViewModelUri)))
            {
                return;
            }
           OperationalState = _payloadInterpeter.CheckOperationalType(payload);
            _payloadInterpeter.ActionOnPayload(payload, payload.PrimaryKeyValue, newId, DataSubSystem.BookingSubsystem, BookingModule.BookingSubSystem);
        }
        private void OnMailBoxHandler(DataPayLoad payload)
        {
            var newId = string.Empty;
            OperationalState = _payloadInterpeter.CheckOperationalType(payload);
            _payloadInterpeterReload.ActionOnPayload(payload, payload.PrimaryKeyValue, newId, DataSubSystem.BookingSubsystem, BookingModule.BookingSubSystem);
        }
        public string ItemCounts
        {
            set
            {
                _itemsCounts = value;
                RaisePropertyChanged();
            }
            get
            {
                return _itemsCounts;
            }
                
        }

        /// <summary>
        ///  Delete Async a new item.
        /// </summary>
        /// <param name="clientIndentifier">PrimaryKey of the view model.</param>
        /// <param name="payLoad">Payload that comes from the event manager to get a value.</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(string clientIndentifier, DataPayLoad payLoad)
        {
            var returnValue = true;
            try
            {
                var bookingData = await _bookingDataService.GetDoAsync(clientIndentifier);
                if (bookingData == null)
                {
                    return false;
                }
                returnValue = await _bookingDataService.DeleteAsync(bookingData);
                if (returnValue)
                {
                    
                  DialogService?.ShowDialogMessage("Reserva", "Reserva borrada con exito");
                }
            } catch (Exception e)
            {
               DialogService?.ShowErrorMessage("Error en el borrar la reserva: "+ e.Message);
            }
            return returnValue;
        }
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {

        }
        
    }
}