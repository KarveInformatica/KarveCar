using KarveCommon.Generic;
using KarveCommonInterfaces;
using Prism.Commands;
using System;
using System.Collections.Generic;
using KarveCommon.Services;

using KarveDataServices;
using KarveDataServices.DataTransferObject;
using KarveDataServices.DataObjects;
using Syncfusion.UI.Xaml.Grid;
using BookingModule.Views;
using Prism.Regions;

namespace BookingModule.ViewModels
{
    internal class BookingIncidentControlViewModel : KarveControlViewModel, ICreateRegionManagerScope, INavigationAware
    {
		private IBookingIncidentDataService  _incidentService;
		private IRegionManager _regionManager;
		private INotifyTaskCompletion<IEnumerable<BookingIncidentSummaryDto>> _incidentCompletion;
	    private PayloadInterpeter<BookingIncidentSummaryDto> _payloadInterpeterReload;
        private PayloadInterpeter<IBookingIncidentData> _payloadInterpeter;
		public bool CreateRegionManagerScope => true;
		public BookingIncidentControlViewModel(IDataServices services,
           IInteractionRequestController requestController,
           IDialogService dialogService,
           IRegionManager manager,
           IEventManager eventManager) : base(services, requestController, dialogService, eventManager)
		   {
		     _incidentService = services.GetBookingIncidentDataService();
			 _regionManager = manager;
		     ItemName = "Incidencias";
		     DefaultPageSize = 50;
             ViewModelUri = new Uri("karve://booking/incident/viewmodel?id=" + UniqueId);
             InitViewModel();
		   }

        private void InitViewModel()
        {
            MailBoxHandler += OnMailBoxHandler;
            MailboxName = ViewModelUri.ToString();
            RegisterMailBox(MailboxName);
            base.GridIdentifier = GridIdentifiers.BookingIncidentGrid;
            SubSystem = DataSubSystem.BookingSubsystem;
            EventManager.RegisterObserverSubsystem(EventSubsystem.BookingSubsystemVm, this);
            EventManager.RegisterObserverSubsystem(BookingModule.GroupBookingIncident, this);
            OpenCommand = new DelegateCommand<object>(OpenCurrentItem);
            SummaryView = new IncrementalList<BookingIncidentSummaryDto>(LoadMoreItems);
            _payloadInterpeterReload = new PayloadInterpeter<BookingIncidentSummaryDto>();
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
               // do nothing.
            };
            _payloadInterpeter = new PayloadInterpeter<IBookingIncidentData>();
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
            var currentId = _incidentService.NewId();

            var interpeter = new PayloadInterpeter<IBookingIncidentData>();
            InitPayLoadInterpeter(interpeter);
            OperationalState = interpeter.CheckOperationalType(dataPayLoad);
            interpeter.ActionOnPayload(dataPayLoad, PrimaryKeyValue, currentId, SubSystem,
                EventSubsystem.BookingSubsystemVm);
        }
		private void InitPayLoadInterpeter(PayloadInterpeter<IBookingIncidentData> payloadInterpeter)
        {
            payloadInterpeter.Init = (value, packet, insertion) =>
            {

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

                                 StartAndNotify();


                            }
                            break;
                        case DataPayLoad.Type.Insert:
                            NewItem();
                            break;
                    }

                }
            };
            payloadInterpeter.CleanUp = CleanUp;
        }
        protected void CleanUp(DataPayLoad payLoad, DataSubSystem subsystem, string eventSubsystem)
        {
                DisposeEvents();
        }
        protected void LoadMoreItems(uint count, int baseIndex)
        {
            NotifyTaskCompletion.Create<IEnumerable<BookingIncidentSummaryDto>>(
             _incidentService.GetPagedSummaryDoAsync(baseIndex, DefaultPageSize), (task, ev) =>
                {
                    if (task is INotifyTaskCompletion<IEnumerable<BookingIncidentSummaryDto>> data)
                    {
                        if (data.IsSuccessfullyCompleted)
                        {
                            if (SummaryView is IncrementalList<BookingIncidentSummaryDto> summary)
                            {
                                summary.LoadItems(data.Result);
                            }
                        }
                        else
                        {
                            DialogService?.ShowErrorMessage("No puedo cargar datos de incidencias");
                        }
                    }
                });
        }
        
		public void StartAndNotify()
        {

            _incidentCompletion = NotifyTaskCompletion.Create<IEnumerable<BookingIncidentSummaryDto>>(
               _incidentService.GetPagedSummaryDoAsync(1, DefaultPageSize), (task, ev) =>
               {
                   if (task is INotifyTaskCompletion<IEnumerable<BookingIncidentSummaryDto>> summaryCollection)
                   {
                       if (summaryCollection.IsSuccessfullyCompleted)
                       {
                           var collection = summaryCollection.Result;


                           if (SummaryView is IncrementalList<BookingIncidentSummaryDto> summary)
                           {
                               var maxItems = _incidentService.NumberItems;
                               PageCount = _incidentService.NumberPage;
                               var summaryList = new IncrementalList<BookingIncidentSummaryDto>(LoadMoreItems) { MaxItemCount = (int)maxItems };
                               summaryList.LoadItems(collection);
                               SummaryView = summaryList;
                           }
                       }
                       else
                       {
                           DialogService?.ShowErrorMessage("Cannot load more pages");
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
            if (!(value is BookingIncidentSummaryDto item)) return;
            var name = item.Name;
            var id = item.Code;
            CreateNewItem(name,id);
            var tabName = id + "." + name;
            var provider = await _incidentService.GetDoAsync(id);
            var currentPayload = BuildShowPayLoadDo(tabName, provider);
            currentPayload.DataObject = provider;
            currentPayload.Subsystem = DataSubSystem.BookingSubsystem; 
            currentPayload.PrimaryKeyValue = id;
            ActiveSubSystem();
            currentPayload.Sender = ViewModelUri.ToString();
            EventManager.NotifyObserverSubsystem(BookingModule.GroupBookingIncident, currentPayload);
        }
        protected override void NewItem()
        {
            var id = _incidentService.NewId();
            var data = _incidentService.GetNewDo(id);
            var name = "";
            string viewNameValue = name + "." + id;
            // here shall be added to the region
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("id", id);
            navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, viewNameValue);
            var uri = new Uri(typeof(BookingIncidentInfoViewModel).FullName + navigationParameters, UriKind.Relative);
            _regionManager.RequestNavigate("TabRegion", uri);
            var currentPayload = BuildShowPayLoadDo(viewNameValue, data);
            currentPayload.DataObject = data;
            currentPayload.Subsystem = DataSubSystem.BookingSubsystem;
            currentPayload.PrimaryKeyValue = id;
            ActiveSubSystem();
            currentPayload.Sender = ViewModelUri.ToString();
            EventManager.NotifyObserverSubsystem(BookingModule.GroupBookingIncident, currentPayload);
        }
        private void CreateNewItem(string id, string name)
        {
            string viewNameValue = name + "." + id;
            // here shall be added to the region
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("id", id);
            navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, viewNameValue);
            var uri = new Uri(typeof(BookingIncidentInfoViewModel).FullName + navigationParameters, UriKind.Relative);
            _regionManager.RequestNavigate("TabRegion", uri);
        }
        protected override string GetRouteName(string name)
        {
            var route = @"karve://booking/incident/" + name;
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
            MailBoxHandler -= OnMailBoxHandler;
            DeleteMailBox(ViewModelUri.ToString());
            ClearSummary<BookingIncidentSummaryDto>();
            EventManager.DeleteObserverSubSystem(EventSubsystem.BookingSubsystemVm, this);
            EventManager.DeleteObserverSubSystem(BookingModule.GroupBookingIncident, this);
        }

        public override void Dispose()
        {
           
        }
    }
}