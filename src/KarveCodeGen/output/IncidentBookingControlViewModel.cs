using KarveCommon.Generic;
using KarveCommonInterfaces;
using Prism.Commands;
using System;
using System.Collections.Generic;
using KarveCommon.Services;
using KarveCommon.Generic;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Syncfusion.UI.Xaml.Grid;
using BookingModule.Views;
using Prism.Regions;

namespace Booking.ViewModels
{
    internal class IncidentBookingControlViewModel : KarveControlViewModel, ICreateRegionManagerScope, INavigationAware
    {
		private IIncidentBookingDataService  _incidenciasService;
		private IRegionManager _regionManager;
		private INotifyTaskCompletion<IEnumerable<IncidentBookingSummaryDto>> _incidenciasCompletion;
	    private PayloadInterpeter<IncidentBookingSummaryDto> _payloadInterpeterReload;
        private PayloadInterpeter<KarveDataServices.IIncidentBooking> _payloadInterpeter;
		public bool CreateRegionManagerScope => true;
		public IncidentBookingControlViewModel(IDataServices services,
           IInteractionRequestController requestController,
           IDialogService dialogService,
           IRegionManager manager,
           IEventManager eventManager) : base(services, requestController, dialogService, eventManager)
		   {
		     _incidenciasService = services.GetIncidentBookingDataService();
			 _regionManager = manager;
		     ItemName = Incidencias Reserva;
		     DefaultPageSize = 50;
             ViewModelUri = new Uri("booking/incidents/viewmodel?id=" + UniqueId);
             InitViewModel();
		   }

        private void InitViewModel()
        {
            MailBoxHandler += OnMailBoxHandler;
            MailboxName = ViewModelUri.ToString();
            RegisterMailBox(MailboxName);
            base.GridIdentifier = GridIdentifiers.IncidentBookingGrid;
            SubSystem = DataSubSystem.Booking;
            EventManager.RegisterObserverSubsystem(EventSubsystem.BookingVm, this);
            EventManager.RegisterObserverSubsystem(Karve.Constants.GroupIncidentBooking, this);
            OpenCommand = new DelegateCommand<object>(OpenCurrentItem);
            SummaryView = new IncrementalList<IncidentBookingSummary>(LoadMoreItems);
            _payloadInterpeterReload = new PayloadInterpeter<IncidentBookingSummary>();
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
            _payloadInterpeter = new PayloadInterpeter<KarveDataServices.IIncidentBooking>();
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
            var currentId = _incidencias.NewId();

            var interpeter = new PayloadInterpeter<KarveDataServices.IIncidentBooking>();
            InitPayLoadInterpeter(interpeter);
            OperationalState = interpeter.CheckOperationalType(dataPayLoad);
            interpeter.ActionOnPayload(dataPayLoad, PrimaryKeyValue, currentId, SubSystem,
                EventSubsystem.{data.subsystem}Vm);
        }
		private void InitPayLoadInterpeter(PayloadInterpeter<KarveDataServices.IIncidentBooking> payloadInterpeter)
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
		protected void LoadMoreItems(uint count, int baseIndex)
        {
            NotifyTaskCompletion.Create<IEnumerable<IncidentBookingSummaryDto>>(
                _reservationRequestDataService.GetPagedSummaryDoAsync(baseIndex, DefaultPageSize), (task, ev) =>
                {
                    if (task is INotifyTaskCompletion<IEnumerable<IncidentBookingSummaryDto>> data)
                    {
                        if (data.IsSuccessfullyCompleted)
                        {
                            if (SummaryView is IncrementalList<IncidentBookingSummaryDto> summary)
                            {
                                summary.LoadItems(data.Result);
                            }
                        }
                        else
                        {
                            DialogService?.ShowErrorMessage(ErrorConstants.DataLoadError);
                        }
                    }
                });
        }
		public override void StartAndNotify()
        {

            _incidenciasCompletion = NotifyTaskCompletion.Create<IEnumerable<IncidentBookingSummary>>(
               _incidenciasService.GetPagedSummaryDoAsync(1, DefaultPageSize), (task, ev) =>
               {
                   if (task is INotifyTaskCompletion<IEnumerable<IncidentBookingSummary>> summaryCollection)
                   {
                       if (summaryCollection.IsSuccessfullyCompleted)
                       {
                           var collection = summaryCollection.Result;


                           if (SummaryView is IncrementalList<IncidentBookingSummary> summary)
                           {
                               var maxItems = _incidenciasService.NumberItems;
                               PageCount = __incidenciasService.NumberPage;
                               var summaryList = new IncrementalList<IncidentBookingSummary>(LoadMoreItems) { MaxItemCount = (int)maxItems };
                               summaryList.LoadItems(collection);
                               SummaryView = summaryList;
                           }
                       }
                       else
                       {
                           DialogService?.ShowErrorMessage(ErrorConstants.DataLoadError+" : " + reservations.ErrorMessage);
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
            if (!(value is IncidentBookingSummary item)) return;
            var name = item.;
            var id = item.Code;
            CreateNewItem(name,id);
            var tabName = id + "." + name;
            var provider = await _incidenciasService.GetDoAsync(id);
            var currentPayload = BuildShowPayLoadDo(tabName, provider);
            currentPayload.DataObject = provider;
            currentPayload.Subsystem = Booking;
            currentPayload.PrimaryKeyValue = id;
            ActiveSubSystem();
            currentPayload.Sender = ViewModelUri.ToString();
            EventManager.NotifyObserverSubsystem(Karve.Constants.GroupIncidentBooking, currentPayload);
        }
        protected override void NewItem()
        {
            var id = _reservationRequestDataService.NewId();
            var data = _reservationRequestDataService.GetNewDo(id);
            var name = "";
            string viewNameValue = name + "." + id;
            // here shall be added to the region
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("id", id);
            navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, viewNameValue);
            var uri = new Uri(typeof().FullName + navigationParameters, UriKind.Relative);
            _regionManager.RequestNavigate("TabRegion", uri);
            var currentPayload = BuildShowPayLoadDo(viewNameValue, data);
            currentPayload.DataObject = data;
            currentPayload.Subsystem = DataSubSystem.Booking;
            currentPayload.PrimaryKeyValue = id;
            ActiveSubSystem();
            currentPayload.Sender = ViewModelUri.ToString();
            EventManager.NotifyObserverSubsystem(Karve.Constants.GroupIncidentBooking, currentPayload);
        }
        private void CreateNewItem(string id, string name)
        {
            string viewNameValue = name + "." + id;
            // here shall be added to the region
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("id", id);
            navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, viewNameValue);
            var uri = new Uri(typeof().FullName + navigationParameters, UriKind.Relative);
            _regionManager.RequestNavigate("TabRegion", uri);
        }
        protected override string GetRouteName(string name)
        {
            var route = @"karve://booking/incidents/" + name;
            var routedName = new Uri(route).AbsoluteUri;
            return routedName;
        }
        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            if (payLoad == null)
            {
                payLoad = new DataPayLoad();
            }
            payLoad.Subsystem = Booking;
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.HasDataObject = false;
            payLoad.HasRelatedObject = false;
            payLoad.Sender = ViewModelUri.ToString();
        }
        public override void DisposeEvents()
        {
            MailBoxHandler -= OnMailBoxHandler;
            DeleteMailBox(ViewModelUri.ToString());
            EventManager.DeleteObserverSubSystem(EventSubsystem.BookingVm, this);
            EventManager.DeleteObserverSubSystem(Karve.Constants.GroupIncidentBooking, this);
        }
	}
}