using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using MasterModule.Common;
using Prism.Regions;
using System;

namespace KarveCar.Navigation
{


    public class KarveNavigator: IKarveNavigator
    {
        private IDataServices _dataServices;
        private IRegionManager _regionManager;
        private IEventManager _eventManager;
        private IDialogService _dialogService;
        public KarveNavigator(IDataServices dataServices, IRegionManager regionManager, IEventManager eventManager, IDialogService dialogService)
        {
            _dataServices = dataServices;
            _regionManager = regionManager;
            _eventManager = eventManager;
            _dialogService = dialogService;
        }
        public void NewClientView(Uri viewModelUri)
        {

            var clientDataService = _dataServices.GetClientDataServices();
            var numberCode = clientDataService.GetNewId();
            var payload = clientDataService.GetNewDo(numberCode);
            var viewName = numberCode +"."+KarveLocale.Properties.Resources.ClientsControlViewModel_NewItem_NuevoCliente ;
            Navigate(_regionManager, numberCode, viewName, typeof(MasterModule.Views.ClientsInfoView).FullName);
            var factory = DataPayloadFactory.GetInstance();
            var dataPayload = factory.BuildInsertPayLoadDo<IClientData>(viewName, payload, DataSubSystem.ClientSubsystem, viewModelUri.ToString(), viewModelUri.ToString(), viewModelUri);
            _eventManager.NotifyObserverSubsystem(MasterModuleConstants.ClientSubSystemName, dataPayload);
        }
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
           // var payload = Activator.CreateInstance<Dto>();
          //  payload.Code = id;
            var factory = DataPayloadFactory.GetInstance();
//            var dataPayload = factory.BuildInsertPayLoadDo<Dto>(tabName, payload, DataSubSystem.HelperSubsytsem, viewModelUri.ToString(), viewModelUri.ToString(), viewModelUri);
               Navigate(_regionManager, string.Empty, string.Empty, viewName);
  //          _eventManager.NotifyObserverSubsystem(EventSubsystem.HelperSubsystem, dataPayload);
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
        private void Navigate(IRegionManager manager, string code, string tabName, string viewName)
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

    }
    
}
