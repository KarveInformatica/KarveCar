using KarveCommon.Generic;
using KarveCommonInterfaces;
using Prism.Commands;
using System;
using System.Collections.Generic;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using Syncfusion.UI.Xaml.Grid;
using BookingModule.Views;
using Prism.Regions;

namespace BookingModule.ViewModels
{
    public class ReservationRequestControlViewModel : KarveControlViewModel, ICreateRegionManagerScope, INavigationAware
    {
        private IReservationRequestDataService _reservationRequestDataService;
        private IRegionManager _regionManager;
        private INotifyTaskCompletion<IEnumerable<ReservationRequestSummary>> _reservationCompletion;
        private PayloadInterpeter<ReservationRequestSummary> _payloadInterpeterReload;
        private PayloadInterpeter<KarveDataServices.IReservationRequest> _payloadInterpeter;
        public bool CreateRegionManagerScope => true;

        public ReservationRequestControlViewModel(IDataServices services,
            IInteractionRequestController requestController,
            IDialogService dialogService,
            IRegionManager manager,
            IEventManager eventManager) : base(services, requestController, dialogService, eventManager)
        {
            _reservationRequestDataService = services.GetReservationRequestDataService();
            _regionManager = manager;
            ItemName = "Peticiones de Reserva";
            DefaultPageSize = 50;

            DirectSubsystem = BookingModule.RequestGroup;
            ViewModelUri = new Uri("karve://booking/request/viewmodel?id=" + UniqueId);
            InitViewModel();

        }

        private void InitViewModel()
        {
            MailBoxHandler += OnMailBoxHandler;
            MailboxName = ViewModelUri.ToString();
            RegisterMailBox(MailboxName);
            base.GridIdentifier = GridIdentifiers.ReservationRequestGrid;
            SubSystem = DataSubSystem.BookingSubsystem;
            EventManager.RegisterObserverSubsystem(EventSubsystem.BookingSubsystemVm, this);
            EventManager.RegisterObserverSubsystem(BookingModule.RequestGroup, this);
            OpenCommand = new DelegateCommand<object>(OpenCurrentItem);
            SummaryView = new IncrementalList<ReservationRequestSummary>(LoadMoreItems);
            _payloadInterpeterReload = new PayloadInterpeter<ReservationRequestSummary>();
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
            _payloadInterpeter = new PayloadInterpeter<KarveDataServices.IReservationRequest>();
            InitPayLoadInterpeter(_payloadInterpeter);
            RegisterToolBar();
            StartAndNotify();
        }

        private void OnMailBoxHandler(DataPayLoad payLoad)
        {
         
        }

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public override void IncomingPayload(DataPayLoad dataPayLoad)
        {
            if (dataPayLoad == null) return;
            if ((dataPayLoad.Sender != null) && (dataPayLoad.Sender.Equals(ViewModelUri)))
            {
                return;
            }
          
            var currentId = _reservationRequestDataService.NewId();

            var interpeter = new PayloadInterpeter<KarveDataServices.IReservationRequest>();
            InitPayLoadInterpeter(interpeter);
            OperationalState = interpeter.CheckOperationalType(dataPayLoad);
            interpeter.ActionOnPayload(dataPayLoad, PrimaryKeyValue, currentId, SubSystem,
                EventSubsystem.BookingSubsystemVm);
        }
        
        private void InitPayLoadInterpeter(PayloadInterpeter<KarveDataServices.IReservationRequest> payloadInterpeter)
        {
            payloadInterpeter.Init = (value, packet, insertion) =>
            {
              
                    switch (packet.PayloadType)
                    {
                        case DataPayLoad.Type.Insert:
                            NewItem();
                            break;
                         case DataPayLoad.Type.UpdateView:
                            StartAndNotify();
                            break;
                    }           
            };
            payloadInterpeter.CleanUp = CleanUp;
        }
        // when i shall delete.
        protected void CleanUp(DataPayLoad payLoad, DataSubSystem subsystem, string eventSubsystem)
        {
            EventManager.NotifyObserverSubsystem(BookingModule.RequestGroup, payLoad);
        }
        protected void LoadMoreItems(uint count, int baseIndex)
        {
            NotifyTaskCompletion.Create<IEnumerable<ReservationRequestSummary>>(
                _reservationRequestDataService.GetPagedSummaryDoAsync(baseIndex, DefaultPageSize), (task, ev) =>
                {
                    if (task is INotifyTaskCompletion<IEnumerable<ReservationRequestSummary>> reservations)
                    {
                        if (reservations.IsSuccessfullyCompleted)
                        {
                            if (SummaryView is IncrementalList<ReservationRequestSummary> summary)
                            {
                                summary.LoadItems(reservations.Result);
                            }
                        }
                        else
                        {
                            DialogService?.ShowErrorMessage("No puedo cargar datos de peticiones");
                        }
                    }
                });
        }
        public  void StartAndNotify()
        {

            _reservationCompletion = NotifyTaskCompletion.Create<IEnumerable<ReservationRequestSummary>>(
               _reservationRequestDataService.GetPagedSummaryDoAsync(1, DefaultPageSize), (task, ev) =>
               {
                   if (task is INotifyTaskCompletion<IEnumerable<ReservationRequestSummary>> reservations)
                   {
                       if (reservations.IsSuccessfullyCompleted)
                       {
                           var collection = reservations.Result;


                           if (SummaryView is IncrementalList<ReservationRequestSummary> summary)
                           {
                               var maxItems = _reservationRequestDataService.NumberItems;
                               PageCount = _reservationRequestDataService.NumberPage;
                               var summaryList = new IncrementalList<ReservationRequestSummary>(LoadMoreItems) { MaxItemCount = (int)maxItems };
                               summaryList.LoadItems(collection);
                               SummaryView = summaryList;                               
                           }
                       }
                       else
                       {
                           DialogService?.ShowErrorMessage("No puedo cargar datos de peticiones : " + reservations.ErrorMessage);
                       }
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
            if (!(value is ReservationRequestSummary reservation)) return;
            var name = reservation.CompanyName;
            var id = reservation.Code;
            if (string.IsNullOrEmpty(id))
            {
                DialogService?.ShowErrorMessage("Cannot open an invalid id");
            }
            if (string.IsNullOrEmpty(name))
            {
                name = "Unknown company";
            }
            CreateNewItem(name,id);
            var tabName = id + "." + name;
            var provider = await _reservationRequestDataService.GetDoAsync(id);
            var currentPayload = BuildShowPayLoadDo(tabName, provider);
            currentPayload.DataObject = provider;
            currentPayload.Subsystem = DataSubSystem.BookingSubsystem;
            currentPayload.PrimaryKeyValue = id;
            ActiveSubSystem();
            currentPayload.Sender = ViewModelUri.ToString();
            EventManager.NotifyObserverSubsystem(BookingModule.RequestGroup, currentPayload);
        }
        protected override void NewItem()
        {
            var id = _reservationRequestDataService.NewId();
            var data = _reservationRequestDataService.GetNewDo(id);
            var name = "Peticion ";
            string viewNameValue = name + "." + id;
            // here shall be added to the region
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("id", id);
            navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, viewNameValue);

            var uri = new Uri(typeof(ReservationRequests).FullName + navigationParameters, UriKind.Relative);
            _regionManager.RequestNavigate("TabRegion", uri);
            var currentPayload = BuildShowPayLoadDo(viewNameValue, data);
            currentPayload.DataObject = data;
            currentPayload.Subsystem = DataSubSystem.BookingSubsystem;
            currentPayload.PrimaryKeyValue = id;
            ActiveSubSystem();
            currentPayload.Sender = ViewModelUri.ToString();
            EventManager.NotifyObserverSubsystem(BookingModule.RequestGroup, currentPayload);
        }
        private void CreateNewItem(string id, string name)
        {

            string viewNameValue = name + "." + id;
            // here shall be added to the region
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("id", id);
            navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, viewNameValue);

            var uri = new Uri(typeof(ReservationRequests).FullName + navigationParameters, UriKind.Relative);

            _regionManager.RequestNavigate("TabRegion", uri);

        }
        protected override string GetRouteName(string name)
        {
            var route = @"booking://" + BookingModule.BookingSubSystem + "//" + name;
            var routedName = new Uri(route).AbsoluteUri;
            return routedName;
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
        public override void DisposeEvents()
        {
            ClearSummary<ReservationRequestSummary>();
            MailBoxHandler -= OnMailBoxHandler;
            DeleteMailBox(ViewModelUri.ToString());
            EventManager.DeleteObserverSubSystem(EventSubsystem.BookingSubsystemVm, this);
            EventManager.DeleteObserverSubSystem(BookingModule.RequestGroup, this);
        }

        public override void Dispose()
        {
            
        }
    }
}
