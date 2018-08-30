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

namespace Users.ViewModels
{
    internal class UsersControlViewModel : KarveControlViewModel, ICreateRegionManagerScope, INavigationAware
    {
		private IUsersDataService  _incidentService;
		private IRegionManager _regionManager;
		private INotifyTaskCompletion<IEnumerable<UsersSummaryDto>> _incidentCompletion;
	    private PayloadInterpeter<UsersSummaryDto> _payloadInterpeterReload;
        private PayloadInterpeter<KarveDataServices.IUsers> _payloadInterpeter;
		public bool CreateRegionManagerScope => true;
		public UsersControlViewModel(IDataServices services,
           IInteractionRequestController requestController,
           IDialogService dialogService,
           IRegionManager manager,
           IEventManager eventManager) : base(services, requestController, dialogService, eventManager)
		   {
		     _incidentService = services.GetUsersDataService();
			 _regionManager = manager;
		     ItemName = Usuarios;
		     DefaultPageSize = 50;
             ViewModelUri = new Uri("user/viewmodel?id=" + UniqueId);
             InitViewModel();
		   }

        private void InitViewModel()
        {
            MailBoxHandler += OnMailBoxHandler;
            MailboxName = ViewModelUri.ToString();
            RegisterMailBox(MailboxName);
            base.GridIdentifier = GridIdentifiers.UsersGrid;
            SubSystem = DataSubSystem.UserSubsystem;
            EventManager.RegisterObserverSubsystem(EventSubsystem.UserSubsystemVm, this);
            EventManager.RegisterObserverSubsystem(Karve.Constants.GroupUsers, this);
            OpenCommand = new DelegateCommand<object>(OpenCurrentItem);
            SummaryView = new IncrementalList<UsersSummary>(LoadMoreItems);
            _payloadInterpeterReload = new PayloadInterpeter<UsersSummary>();
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
            _payloadInterpeter = new PayloadInterpeter<KarveDataServices.IUsers>();
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
            var currentId = _incident.NewId();

            var interpeter = new PayloadInterpeter<KarveDataServices.IUsers>();
            InitPayLoadInterpeter(interpeter);
            OperationalState = interpeter.CheckOperationalType(dataPayLoad);
            interpeter.ActionOnPayload(dataPayLoad, PrimaryKeyValue, currentId, SubSystem,
                EventSubsystem.{data.subsystem}Vm);
        }
		private void InitPayLoadInterpeter(PayloadInterpeter<KarveDataServices.IUsers> payloadInterpeter)
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
            NotifyTaskCompletion.Create<IEnumerable<UsersSummaryDto>>(
                _reservationRequestDataService.GetPagedSummaryDoAsync(baseIndex, DefaultPageSize), (task, ev) =>
                {
                    if (task is INotifyTaskCompletion<IEnumerable<UsersSummaryDto>> data)
                    {
                        if (data.IsSuccessfullyCompleted)
                        {
                            if (SummaryView is IncrementalList<UsersSummaryDto> summary)
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

            _incidentCompletion = NotifyTaskCompletion.Create<IEnumerable<UsersSummary>>(
               _incidentService.GetPagedSummaryDoAsync(1, DefaultPageSize), (task, ev) =>
               {
                   if (task is INotifyTaskCompletion<IEnumerable<UsersSummary>> summaryCollection)
                   {
                       if (summaryCollection.IsSuccessfullyCompleted)
                       {
                           var collection = summaryCollection.Result;


                           if (SummaryView is IncrementalList<UsersSummary> summary)
                           {
                               var maxItems = _incidentService.NumberItems;
                               PageCount = __incidentService.NumberPage;
                               var summaryList = new IncrementalList<UsersSummary>(LoadMoreItems) { MaxItemCount = (int)maxItems };
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
            if (!(value is UsersSummary item)) return;
            var name = item.;
            var id = item.Code;
            CreateNewItem(name,id);
            var tabName = id + "." + name;
            var provider = await _incidentService.GetDoAsync(id);
            var currentPayload = BuildShowPayLoadDo(tabName, provider);
            currentPayload.DataObject = provider;
            currentPayload.Subsystem = UserSubsystem;
            currentPayload.PrimaryKeyValue = id;
            ActiveSubSystem();
            currentPayload.Sender = ViewModelUri.ToString();
            EventManager.NotifyObserverSubsystem(Karve.Constants.GroupUsers, currentPayload);
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
            currentPayload.Subsystem = DataSubSystem.UserSubsystem;
            currentPayload.PrimaryKeyValue = id;
            ActiveSubSystem();
            currentPayload.Sender = ViewModelUri.ToString();
            EventManager.NotifyObserverSubsystem(Karve.Constants.GroupUsers, currentPayload);
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
            var route = @"karve://user/" + name;
            var routedName = new Uri(route).AbsoluteUri;
            return routedName;
        }
        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            if (payLoad == null)
            {
                payLoad = new DataPayLoad();
            }
            payLoad.Subsystem = UserSubsystem;
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.HasDataObject = false;
            payLoad.HasRelatedObject = false;
            payLoad.Sender = ViewModelUri.ToString();
        }
        public override void DisposeEvents()
        {
            MailBoxHandler -= OnMailBoxHandler;
            DeleteMailBox(ViewModelUri.ToString());
            EventManager.DeleteObserverSubSystem(EventSubsystem.UserSubsystemVm, this);
            EventManager.DeleteObserverSubSystem(Karve.Constants.GroupUsers, this);
        }
	}
}