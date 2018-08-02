using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using MasterModule.Common;
using Prism.Regions;
using System;
using AutoMapper;
using DataAccessLayer.Logic;
using System.Collections.Generic;
using System.Windows;

namespace KarveCar.Navigation
{

    /// <summary>
    ///  Implementation of the navigation between two view models. 
    ///  A view model A could use a KarveNavigator object for opening a new view first.
    /// </summary>
    public class KarveNavigator: IKarveNavigator
    {
        private readonly IDataServices _dataServices;
        private readonly IRegionManager _regionManager;
        private readonly IEventManager _eventManager;
        private readonly IDialogService _dialogService;
        private readonly IMapper _mapper;
        /// <summary>
        /// KarveNavigator constructor
        /// </summary>
        /// <param name="dataServices">DataServices to be used for navigation</param>
        /// <param name="regionManager">RegionManager to be used for instantiating a videw</param>
        /// <param name="eventManager">EventManager to be used for communicating between view models</param>
        /// <param name="dialogService">DialogServicing to be used for spotting errors.</param>
        public KarveNavigator(IDataServices dataServices, IRegionManager regionManager, IEventManager eventManager, IDialogService dialogService)
        {
            _dataServices = dataServices;
            _regionManager = regionManager;
            _eventManager = eventManager;
            _dialogService = dialogService;
            _mapper = MapperField.GetMapper();
        }

        public void NewView<Type>(Uri viewModelUri, Type t)
        {
            
        }
        /// <summary>
        /// Create a new client view for insertion.
        /// </summary>
        /// <param name="viewModelUri">Uri assigned to the new client view</param>
        public void NewClientView(Uri viewModelUri)
        { 
            var clientDataService = _dataServices.GetClientDataServices();
            var numberCode = clientDataService.GetNewId();
            var payload = clientDataService.GetNewDo(numberCode);
            var viewName = numberCode +"."+KarveLocale.Properties.Resources.ClientsControlViewModel_NewItem_NuevoCliente ;
            Navigate(_regionManager, numberCode, viewName, typeof(MasterModule.Views.ClientsInfoView).FullName);
            var factory = DataPayloadFactory.GetInstance();
            var dataPayload = factory.BuildInsertPayLoadDo<IClientData>(viewName, 
                payload, 
                DataSubSystem.ClientSubsystem, 
                viewModelUri.ToString(), 
                viewModelUri.ToString(), 
                viewModelUri);
            payload.Value.NUMERO_CLI = numberCode;
            _eventManager.NotifyObserverSubsystem(MasterModuleConstants.ClientSubSystemName, dataPayload);
        }
        /// <summary>
        /// Create a new broker view.
        /// </summary>
        /// <param name="viewModelUri">A new broker uri</param>
        public void NewBrokerView(Uri viewModelUri)
        {
            var broker = _dataServices.GetCommissionAgentDataServices();
            var numberCode = broker.NewId();
            var viewName = numberCode + "." + "Nuevo Commision Agent";
            var payload = broker.GetNewDo(numberCode);
            Navigate(_regionManager, numberCode, viewName, typeof(MasterModule.Views.CommissionAgentInfoView).FullName);
            var factory = DataPayloadFactory.GetInstance();
            var dataPayload = factory.BuildInsertPayLoadDo<ICommissionAgent>(viewName, payload, DataSubSystem.CommissionAgentSubystem, viewModelUri.ToString(), viewModelUri.ToString(), viewModelUri);
            _eventManager.NotifyObserverSubsystem(MasterModuleConstants.CommissionAgentSystemName, dataPayload);
        }
        /// <summary>
        /// Open a new tab for an existing item. You need to provide the DataPayload to be used in the tab.
        /// </summary>
        /// <typeparam name="ViewType">Type of the view (i.e. CommissionAgentInfoView) to be created.</typeparam>
        /// <param name="id">Identifier of the view.</param>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="payload">Kind of payload.</param>
        /// <param name="subsystem">Kind of subsystem.</param>
        public void Navigate<ViewType>(string id, string viewName,
            DataPayLoad payload, string subsystem)
        {
            Navigate(_regionManager, id, viewName, typeof(ViewType).FullName);
            _eventManager.NotifyObserverSubsystem(subsystem, payload);
        }
        /// <summary>
        ///  Create a new vehicle view for insertion
        /// </summary>
        /// <param name="viewModelUri">Uri to be assigned to the new vehicle view</param>
        public void NewVehicleView(Uri viewModelUri)
        {
            var dataServices = _dataServices.GetVehicleDataServices();
            var numberCode = dataServices.NewId();
            var payload = dataServices.GetNewDo(numberCode);
            var viewName = KarveCar.Navigation.Properties.Resources.KarveNavigator_NewVehicleView_NuevoVehiculo + "." + numberCode;
            Navigate(_regionManager, numberCode, viewName, typeof(MasterModule.Views.VehicleInfoView).FullName);
            var factory = DataPayloadFactory.GetInstance();
            var dataPayload = factory.BuildInsertPayLoadDo<IVehicleData>(viewName, payload, DataSubSystem.VehicleSubsystem, viewModelUri.ToString(), viewModelUri.ToString(), viewModelUri);            
            _eventManager.NotifyObserverSubsystem(MasterModuleConstants.VehiclesSystemName, dataPayload);

        }
        public void NewFareView(Uri viewModelUri)
        {
            _dialogService?.ShowErrorMessage("Fare not yet implemented");
        }
      
        public void NewHelperView<Entity, Dto>(Entity e, string viewName) where Dto: BaseDto where Entity:class
        {
            var helperDataService = _dataServices.GetHelperDataServices();
            var id = string.Empty;
            NotifyTaskCompletion.Create<string>(helperDataService.GetUniqueId(e), (task, ev) =>
            {
                if (task is INotifyTaskCompletion<string> result)
                {
                    if (result.IsSuccessfullyCompleted)
                    {
                        id = result.Task.Result;
                    }
                    else
                    {
                        _dialogService?.ShowErrorMessage("Error in identifier generation");
                    }
                }
            });
            var factory = DataPayloadFactory.GetInstance();
               Navigate(_regionManager, string.Empty, string.Empty, viewName);
        }
       
        /// <summary>
        ///  Create new vehicle group view
        /// </summary>
        /// <param name="viewModelUri">Sender identifier</param>
        public void NewGroupView(Uri viewModelUri)

        {
            _dialogService?.ShowErrorMessage("Group navigation not yet implemented");
            return;
            /*
            var helperDataService = _dataServices.GetHelperDataServices();
            var group = new GRUPOS();
            string id = string.Empty;
            NotifyTaskCompletion.Create<string>(helperDataService.GetUniqueId<GRUPOS>(group), (task, ev) =>
            {
                if (task is INotifyTaskCompletion<string> result)
                {
                    if (result.IsSuccessfullyCompleted)
                    {
                        id = result.Task.Result;
                    }
                    else
                    {
                        _dialogService?.ShowErrorMessage("Error in identifier generation");
                    }
                }
            });
            var payload = new VehicleGroupDto();
            payload.Codigo = id;
            payload.Code = id;
            var viewName = "Nuevo Grupo" + "." + id;
            var factory = DataPayloadFactory.GetInstance();
            var dataPayload = factory.BuildInsertPayLoadDo<VehicleGroupDto>(viewName, payload, DataSubSystem.HelperSubsytsem, viewModelUri.ToString(), viewModelUri.ToString(), viewModelUri);
            Navigate(_regionManager, id, viewName, "VehicleGroupViewModel");
            _eventManager.NotifyObserverSubsystem(EventSubsystem.HelperSubsystem, dataPayload);
            */
        }
        /// <summary>
        /// Navigate to the requested view in a view first approach.
        /// </summary>
        /// <param name="manager">Region Manager used to navigate</param>
        /// <param name="code">New domain item code</param>
        /// <param name="tabName">Name of the tab</param>
        /// <param name="viewName">Name of the view to be used</param>
        public void Navigate(IRegionManager manager, string code, string tabName, string viewName)
        {
            var navigationParameters = new NavigationParameters
            {
                {"id", code},
                {ScopedRegionNavigationContentLoader.DefaultViewName, tabName}
            };
            string navigationUri = string.Empty;
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(tabName))
            {
                navigationUri = viewName;
            }
            else
            {
                navigationUri = viewName + navigationParameters;
            }
            var uri = new Uri(navigationUri, UriKind.Relative);  
            manager.RequestNavigate(RegionNames.TabRegion, uri);

        }

        public void NewBookingView(Uri viewModelUri)
        {
            throw new NotImplementedException();
        }

        public IHelperViewFactory GetHelperViewFactory()
        {
            return new HelperNavigatorFactory(_dataServices, _regionManager, _dialogService);
        }

        public void NewSummaryView<DomainType,T>(IEnumerable<T> summary, string title, string fullName)
        {
            var navigationUri = title;
            var uri = new Uri(navigationUri, UriKind.Relative);
            Navigate(_regionManager,string.Empty, title, fullName);
              
        }

        public void NewIncidentView(BookingDto currentBooking)
        {
            MessageBox.Show("New incident");
        }
    }
    
}
