using System.Collections.Generic;
using System.ComponentModel;
using BookingModule.Views;
using Prism.Mvvm;
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

namespace BookingModule.ViewModels
{
    public class BookingControlViewModel : KarveControlViewModel
    {
        private INotifyTaskCompletion<IEnumerable<BookingSummaryDto>> _bookingSummaryCompletion;
        private readonly IBookingDataService _bookingDataService;
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;
        private IRegionManager _detailsRegionManager;

        private PropertyChangedEventHandler _bookingLoadEventHandler;
        
        private PayloadInterpeter<IBookingData> _payloadInterpeter;

        public DataPayLoad.Type OperationalState { get; private set; }

        public BookingControlViewModel(IRegionManager regionManager, IDataServices services, IUnityContainer container, IInteractionRequestController requestController, IDialogService dialogService, IEventManager eventManager) : base(services, requestController, dialogService, eventManager)
        {

            _bookingDataService = DataServices.GetBookingDataService();
            _regionManager = regionManager;
            _container = container;
            // set the name to the listing grid.
            ItemName = "Reservas";
            DefaultPageSize = 50;
            ViewModelUri = new Uri("karve://booking/viewmodel?id=" + UniqueId);
            InitViewModel();
        }

        private void InitViewModel()
        {
            MailBoxHandler += OnMailBoxHandler;
            MailboxName = ViewModelUri.ToString();
            RegisterMailBox(MailboxName);
            EventManager.RegisterMailBox(MailboxName, MailBoxHandler);
            _bookingLoadEventHandler += OnNotifyIncrementalList<BookingSummaryDto>;
            SummaryView = new IncrementalList<BookingSummaryDto>(LoadMoreItems);
            OpenCommand = new DelegateCommand<object>(OpenCurrentItem);
            _payloadInterpeter = new PayloadInterpeter<IBookingData>();
            _payloadInterpeter.Init = (value, packet, insertion) =>
            {
                // ok i shall do a new
                if (insertion)
                {
                    NewItem();

                }
                else
                {
                    switch (packet.PayloadType)
                    {
                        case DataPayLoad.Type.UpdateView:
                            StartAndNotify();
                            break;
                        case DataPayLoad.Type.Insert:
                            NewItem();

                            break;
                    }

                }
            };
            _payloadInterpeter.CleanUp = (key, system, name) =>
            {
                DisposeEvents();

            };
            StartAndNotify();

        }
      

        private void MailboxHandlerName(DataPayLoad payLoad)
        {
           
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
        /// <param name="navigationContext"></param>
        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public override void StartAndNotify()
        {
            _bookingSummaryCompletion = NotifyTaskCompletion.Create<IEnumerable<BookingSummaryDto>>(
                _bookingDataService.GetPagedSummaryDoAsync(1, DefaultPageSize), _bookingLoadEventHandler);

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
            var name = reservation.ClientCode;
            var id = reservation.BookingNumber;
            var tabName = id + "." + name;
            CreateNewItem(tabName);
            var provider = await _bookingDataService.GetDoAsync(id);
            var currentPayload = BuildShowPayLoadDo(tabName, provider);
            currentPayload.DataObject = provider;
            currentPayload.Subsystem = DataSubSystem.BookingSubsystem;
            currentPayload.PrimaryKeyValue = id;
            ActiveSubSystem();
            currentPayload.Sender = base.MailboxName;
            Navigate(id, tabName);
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
            var viewName = "Nuova " + "." + id;
            CreateNewItem(id);
            var currentPayload = BuildShowPayLoadDo(viewName, newDo);
            currentPayload.Subsystem = DataSubSystem.InvoiceSubsystem;
            currentPayload.PayloadType = DataPayLoad.Type.Insert;
            currentPayload.PrimaryKeyValue = id;
            currentPayload.Sender = ViewModelUri.ToString();
            EventManager.NotifyObserverSubsystem(BookingModule.BookingSubSystem, currentPayload);
            Navigate(id, viewName);
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
        }
      
        public override void IncomingPayload(DataPayLoad payload)
        {
            var newId = _bookingDataService.NewId();
           OperationalState = _payloadInterpeter.CheckOperationalType(payload);
            _payloadInterpeter.ActionOnPayload(payload, PrimaryKeyValue, newId, DataSubSystem.BookingSubsystem, BookingModule.BookingSubSystem);
        }
        private void OnMailBoxHandler(DataPayLoad payload)
        {
        }

        /// <summary>
        ///  Delete Async a new item.
        /// </summary>
        /// <param name="clientIndentifier">PrimaryKey of the view model.</param>
        /// <param name="payLoad">Payload that comes from the event manager to get a value.</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(string clientIndentifier, DataPayLoad payLoad)
        {
            var bookingData = await _bookingDataService.GetDoAsync(clientIndentifier);
            if (bookingData == null)
            {
                return false;
            }
            return await _bookingDataService.DeleteAsync(bookingData);
        }
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
        }
        
    }
}