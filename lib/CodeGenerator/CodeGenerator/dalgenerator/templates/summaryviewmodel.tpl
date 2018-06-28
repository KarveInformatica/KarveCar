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

namespace {{data.modulename}}.ViewModels
{
    internal class {{data.name}}ControlViewModel : KarveControlViewModel, ICreateRegionManagerScope, INavigationAware
    {
		private I{{data.name}}DataService  _{{data.namelower}}Service;
		private IRegionManager _regionManager;
		private INotifyTaskCompletion<IEnumerable<{{data.name}}SummaryDto>> _{{data.namelower}}Completion;
	    private PayloadInterpeter<{{data.name}}SummaryDto> _payloadInterpeterReload;
        private PayloadInterpeter<KarveDataServices.I{{data.name}}> _payloadInterpeter;
		public bool CreateRegionManagerScope => true;
		public {{data.name}}ControlViewModel(IDataServices services,
           IInteractionRequestController requestController,
           IDialogService dialogService,
           IRegionManager manager,
           IEventManager eventManager) : base(services, requestController, dialogService, eventManager)
		   {
		     _{{data.namelower}}Service = services.Get{{data.name}}DataService();
			 _regionManager = manager;
		     ItemName = {{data.summarytitle}};
		     DefaultPageSize = 50;
             ViewModelUri = new Uri("{{data.baseuri}}/viewmodel?id=" + UniqueId);
             InitViewModel();
		   }

        private void InitViewModel()
        {
            MailBoxHandler += OnMailBoxHandler;
            MailboxName = ViewModelUri.ToString();
            RegisterMailBox(MailboxName);
            base.GridIdentifier = GridIdentifiers.{{data.name}}Grid;
            SubSystem = DataSubSystem.{{data.subsystem}};
            EventManager.RegisterObserverSubsystem(EventSubsystem.{{data.subsystem}}Vm, this);
            EventManager.RegisterObserverSubsystem(Karve.Constants.Group{{data.name}}, this);
            OpenCommand = new DelegateCommand<object>(OpenCurrentItem);
            SummaryView = new IncrementalList<{{data.name}}Summary>(LoadMoreItems);
            _payloadInterpeterReload = new PayloadInterpeter<{{data.name}}Summary>();
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
            _payloadInterpeter = new PayloadInterpeter<KarveDataServices.I{{data.name}}>();
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
            var currentId = _{{data.namelower}}.NewId();

            var interpeter = new PayloadInterpeter<KarveDataServices.I{{data.name}}>();
            InitPayLoadInterpeter(interpeter);
            OperationalState = interpeter.CheckOperationalType(dataPayLoad);
            interpeter.ActionOnPayload(dataPayLoad, PrimaryKeyValue, currentId, SubSystem,
                EventSubsystem.{data.subsystem}Vm);
        }
		private void InitPayLoadInterpeter(PayloadInterpeter<KarveDataServices.I{{data.name}}> payloadInterpeter)
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
            NotifyTaskCompletion.Create<IEnumerable<{{data.name}}SummaryDto>>(
                _reservationRequestDataService.GetPagedSummaryDoAsync(baseIndex, DefaultPageSize), (task, ev) =>
                {
                    if (task is INotifyTaskCompletion<IEnumerable<{{data.name}}SummaryDto>> data)
                    {
                        if (data.IsSuccessfullyCompleted)
                        {
                            if (SummaryView is IncrementalList<{{data.name}}SummaryDto> summary)
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

            _{{data.namelower}}Completion = NotifyTaskCompletion.Create<IEnumerable<{{data.name}}Summary>>(
               _{{data.namelower}}Service.GetPagedSummaryDoAsync(1, DefaultPageSize), (task, ev) =>
               {
                   if (task is INotifyTaskCompletion<IEnumerable<{{data.name}}Summary>> summaryCollection)
                   {
                       if (summaryCollection.IsSuccessfullyCompleted)
                       {
                           var collection = summaryCollection.Result;


                           if (SummaryView is IncrementalList<{{data.name}}Summary> summary)
                           {
                               var maxItems = _{{data.namelower}}Service.NumberItems;
                               PageCount = __{{data.namelower}}Service.NumberPage;
                               var summaryList = new IncrementalList<{{data.name}}Summary>(LoadMoreItems) { MaxItemCount = (int)maxItems };
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
            if (!(value is {{data.name}}Summary item)) return;
            var name = item.{{data.namenavigation}};
            var id = item.Code;
            CreateNewItem(name,id);
            var tabName = id + "." + name;
            var provider = await _{{data.namelower}}Service.GetDoAsync(id);
            var currentPayload = BuildShowPayLoadDo(tabName, provider);
            currentPayload.DataObject = provider;
            currentPayload.Subsystem = {{data.subsystem}};
            currentPayload.PrimaryKeyValue = id;
            ActiveSubSystem();
            currentPayload.Sender = ViewModelUri.ToString();
            EventManager.NotifyObserverSubsystem(Karve.Constants.Group{{data.name}}, currentPayload);
        }
        protected override void NewItem()
        {
            var id = _reservationRequestDataService.NewId();
            var data = _reservationRequestDataService.GetNewDo(id);
            var name = "{{data.newitemname}}";
            string viewNameValue = name + "." + id;
            // here shall be added to the region
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("id", id);
            navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, viewNameValue);
            var uri = new Uri(typeof({{data.infoviewmodelname}}).FullName + navigationParameters, UriKind.Relative);
            _regionManager.RequestNavigate("TabRegion", uri);
            var currentPayload = BuildShowPayLoadDo(viewNameValue, data);
            currentPayload.DataObject = data;
            currentPayload.Subsystem = DataSubSystem.{{data.subsystem}};
            currentPayload.PrimaryKeyValue = id;
            ActiveSubSystem();
            currentPayload.Sender = ViewModelUri.ToString();
            EventManager.NotifyObserverSubsystem(Karve.Constants.Group{{data.name}}, currentPayload);
        }
        private void CreateNewItem(string id, string name)
        {
            string viewNameValue = name + "." + id;
            // here shall be added to the region
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("id", id);
            navigationParameters.Add(ScopedRegionNavigationContentLoader.DefaultViewName, viewNameValue);
            var uri = new Uri(typeof({{data.infoviewmodelname}}).FullName + navigationParameters, UriKind.Relative);
            _regionManager.RequestNavigate("TabRegion", uri);
        }
        protected override string GetRouteName(string name)
        {
            var route = @"karve://{{data.baseuri}}/" + name;
            var routedName = new Uri(route).AbsoluteUri;
            return routedName;
        }
        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            if (payLoad == null)
            {
                payLoad = new DataPayLoad();
            }
            payLoad.Subsystem = {{data.subsystem}};
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.HasDataObject = false;
            payLoad.HasRelatedObject = false;
            payLoad.Sender = ViewModelUri.ToString();
        }
        public override void DisposeEvents()
        {
            MailBoxHandler -= OnMailBoxHandler;
            DeleteMailBox(ViewModelUri.ToString());
            EventManager.DeleteObserverSubSystem(EventSubsystem.{{data.subsystem}}Vm, this);
            EventManager.DeleteObserverSubSystem(Karve.Constants.Group{{data.name}}, this);
        }
	}
}
