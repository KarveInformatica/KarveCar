using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using DataAccessLayer.DataObjects;
using Prism.Regions;
using System;

namespace KarveCar.Navigation
{
    /// <summary>
    ///  Factory for creating new helper view. It creates a new tab with associated the data object.
    /// </summary>
    internal class HelperNavigatorFactory : IHelperViewFactory
    {

        private IDataServices _dataService;
        private IRegionManager _regionManager;
        private IDialogService _dialogService;

        /// <summary>
        ///  Constructor for the helper view.
        /// </summary>
        /// <param name="dataService">DataService for retrieving the helper dataservice.</param>
        /// <param name="regionManager">Region manager used by the factory for the navigation.</param>
        /// <param name="dialogService">DialogService used by the factory for pointing out the errors.</param>
        public HelperNavigatorFactory(IDataServices dataService, IRegionManager regionManager, IDialogService dialogService)
        {
            _dataService = dataService;
            _regionManager = regionManager;
            _dialogService = dialogService;
        }

        /// <summary>
        ///  Generic method used for navigating. Retrieve an unique id for the new view and generate a view payload to be sent. 
        /// </summary>
        /// <typeparam name="Entity">Entity Type of the view (same name as db column) </typeparam>
        /// <typeparam name="Dto">Data transfer object to be used.</typeparam>
        /// <param name="e">Entity</param>
        /// <param name="viewName">Name of the view</param>
        private void NewHelperView<Entity, Dto>(Entity e, string viewName, Uri viewModelUri) where Dto : BaseDto where Entity : class
        {
            var helperDataService = _dataService.GetHelperDataServices();
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
            var currentUri = new Uri(viewModelUri.ToString() + id);
            var factory = DataPayloadFactory.GetInstance();
            var helperDto = Activator.CreateInstance<Dto>();
            helperDto.Code = id;
            var dataPayload = factory.BuildInsertPayLoadDo<Dto>(viewName, helperDto, DataSubSystem.HelperSubsytsem, currentUri.ToString(), currentUri.ToString(), currentUri);
            NavigateView.Navigate(_regionManager, viewName);
        }

      
        public void NewBookingMediaView(Uri uri)
        {
            var e = new MEDIO_RES();
            NewHelperView<MEDIO_RES, BookingMediaDto>(e, "Nuevo Medio", uri);
        }

        public void NewBookingTypeView(Uri uri)
        {
            var e = new TIPOS_RESERVAS();
            NewHelperView<TIPOS_RESERVAS, BookingTypeDto>(e, "Nueva Reservas", uri);
        }

        public void NewContactClientView(Uri uri)
        {
            var e = new CliContactos();
            NewHelperView<CliContactos, ContactsDto>(e, "Nuevo Contacto", uri);
        }

        public void NewEmployeeAgencyView(Uri uri)
        {
            var e = new EAGE();
            NewHelperView<EAGE, AgencyEmployeeDto>(e, "Nueva Agencia", uri);
        }
        public void NewOriginView(Uri uri)
        {
            var e = new ORIGEN();
            NewHelperView<ORIGEN, OrigenDto>(e, "Nuevo Origin", uri);
        }
        public void NewPaymentFormView(Uri uri)
        {
            var e = new FORMAS();
            NewHelperView<FORMAS, PaymentFormDto>(e, "Nueva Forma de Cobro", uri);
        }
        public void NewVehicleActivityView(Uri uri)
        {
            var e = new ACTIVEHI();
            NewHelperView<ACTIVEHI, VehicleActivitiesDto>(e, "Nueva Actividad Vehiculo", uri);
        }
        public void NewBookingPrintingType(Uri viewModelUri)
        {
            var e = new CONTRATIPIMPR();
            NewHelperView<CONTRATIPIMPR, PrintingTypeDto>(e, "Nueva Actividad Vehiculo", viewModelUri);
        }
        public void NewReseller(Uri uri)
        {
            var e = new VENDEDOR();
            NewHelperView<VENDEDOR, ResellerDto>(e, "Nuevo Vendedor", uri);
        }
        public void NewBookingRequestReason(Uri uri)
        {
            var e = new MOPETI();
            NewHelperView<MOPETI, RequestReasonDto>(e, "Nueva Motivo Peticion", uri);
        }
    }
}
