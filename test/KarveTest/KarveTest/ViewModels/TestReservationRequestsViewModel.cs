using BookingModule.ViewModels;
using KarveCar.Navigation;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using Moq;
using NUnit.Framework;
using DataAccessLayer.DataObjects;
using KarveDataServices.ViewObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalBase = KarveTest.DAL.TestBase;
using DataAccessLayer.DtoWrapper;
using KarveDapper;
using KarveDapper.Extensions;
using Dapper;
using Microsoft.Practices.Unity;

namespace KarveTest.ViewModels
{
    /// <summary>
    ///  Testing the view models in isolation to verify the input triggered from different events.
    /// </summary>
    [TestFixture]
    class TestReservationRequestsViewModels
    {
        private Mock<IEventManager> _eventManager;
        private Mock<IDataServices> _dataServices;
        private Mock<IKarveNavigator> _navigator;
        private Mock<IInteractionRequestController> _interacionController;
        private Mock<IDialogService> _dialogService;
        private Mock<IAssistDataService> _assistService;
        private Mock<IUnityContainer> _unityContainer;
        private ISqlExecutor _sqlExecutor;
        private IDataServices _services;
        private DalBase testbase = new DalBase();
        private ReservationRequestsViewModel _reservationRequestsView;
        [SetUp]
        public void Setup()
        {
         _eventManager = new Mock<IEventManager>();
         _dataServices = new Mock<IDataServices>();
            _unityContainer = new Mock<IUnityContainer>();
         _navigator = new Mock<IKarveNavigator>();
         _interacionController = new Mock<IInteractionRequestController>();
         _dialogService = new Mock<IDialogService>();
         _assistService = new Mock<IAssistDataService>();
         _sqlExecutor = testbase.SetupSqlQueryExecutor();
         _services = testbase.Services;
        }
        [Test]
        public void Should_Add_ANewClient()
        {
            bool isClientNavigated = false;
            // prepare the navigator call back
            _navigator.Setup(x => x.NewClientView(It.IsAny<Uri>()))
        .Callback(()=> { isClientNavigated = true; });
        var reservationRequestsView = new ReservationRequestsViewModel(_dataServices.Object, _interacionController.Object, _dialogService.Object, _eventManager.Object, _navigator.Object, null, null, _unityContainer.Object);
            _reservationRequestsView.CreateNewClient.Execute();
            Assert.IsTrue(isClientNavigated);
        }
        [Test]
        public void Should_Add_ANewReason()
        {
            /*
            bool isClientNavigated = false;
           _navigator.Setup(x => x.NewHelperView<MOPETI,RequestReasonViewObject>(It.IsAny<MOPETI>(), It.IsAny<string>())).Callback(() => { isClientNavigated = true; });
            var reservationRequestsView = new ReservationRequestsViewModel(_dataServices.Object, _interacionController.Object, _dialogService.Object, _eventManager.Object, _navigator.Object, null, null);
            _reservationRequestsView.CreateNewRequestReason.Execute();
            Assert.IsTrue(isClientNavigated);
            */
        }
        [Test]
        public void Should_Insert_ANewItem()
        {
            ReservationRequestViewObject viewObject = new ReservationRequestViewObject()
            {
                NUMERO = "12190"
            };
            IReservationRequest reservationRequest = new ReservationRequest(viewObject);

            bool isRegistered = false;
            DataPayLoad currentDataPayLoad = null;
            var requestService = new Mock<IReservationRequestDataService>();
            requestService.Setup(x => x.GetNewDo(It.IsAny<string>())).Returns(reservationRequest);

            _eventManager.Setup(x => x.NotifyToolBar(It.IsAny<DataPayLoad>())).Callback<DataPayLoad>(x =>
            {
                isRegistered = x.PayloadType == DataPayLoad.Type.RegistrationPayload;
                currentDataPayLoad = x;
            });
            _dataServices.Setup(x=>x.GetReservationRequestDataService()).Returns(requestService.Object);
            var reservationRequestsView = new ReservationRequestsViewModel(_dataServices.Object, _interacionController.Object, _dialogService.Object, _eventManager.Object, _navigator.Object, null, null, _unityContainer.Object);

            // now i should arrange a new id and send to the reservation request view model.
            DataPayLoad payload = new DataPayLoad();
            payload.PayloadType = DataPayLoad.Type.Insert;
            payload.DataObject = reservationRequest;
            payload.HasDataObject = true;
            reservationRequestsView.IncomingPayload(payload);
            Assert.AreEqual(reservationRequestsView.DataObject.NUMERO, viewObject.NUMERO);
        }
        [Test]
        public async Task Should_Show_AnItem()
        {
            var dto = new ReservationRequestViewObject();
            // i prepare data with real data from the database.

            using (var conn = _sqlExecutor.OpenNewDbConnection())
            {
                var entity = await conn.GetRandomEntityAsync<PETICION>().ConfigureAwait(false);
                dto.NUMERO = entity.NUMERO;
                dto.MOPETI = entity.MOPETI;
                dto.OBS1 = entity.OBS1;
                dto.NOMCLI = entity.NOMCLI;
                dto.OFICINA = entity.OFICINA;
                dto.ORIGEN = 10; // internet
                dto.OTRO_VEHI = entity.OTRO_VEHI;
                dto.CATEGO = entity.CATEGO;
               
            }
            var clientService = _services.GetClientDataServices();
            var helperService = _services.GetHelperDataServices();
            var vehicleService = _services.GetVehicleDataServices();

            var clientDto = await clientService.GetPagedSummaryDoAsync(1,1);
            var grupos = await helperService.GetSingleMappedAsyncHelper<VehicleGroupViewObject, GRUPOS>(dto.CATEGO);
            var origen = await helperService.GetSingleMappedAsyncHelper<OrigenViewObject, ORIGEN>(dto.ORIGEN.Value.ToString());
            var reservation = new ReservationRequest(dto);
            reservation.ClientDto = reservation.ClientDto.Union(new List<ClientSummaryExtended>() { clientDto.FirstOrDefault()});
            reservation.GroupDto = reservation.GroupDto.Union(new List<VehicleGroupViewObject>() { grupos });
            DataPayLoad payload = new DataPayLoad();
            payload.PayloadType = DataPayLoad.Type.Show;
            payload.DataObject = reservation;
            var reservationRequestsView = new ReservationRequestsViewModel(_dataServices.Object, _interacionController.Object, _dialogService.Object, _eventManager.Object, _navigator.Object, null, null, _unityContainer.Object);
            reservationRequestsView.IncomingPayload(payload);
            Assert.GreaterOrEqual(1, reservationRequestsView.ClientDto.Count());
            Assert.GreaterOrEqual(1, reservationRequestsView.GroupDto.Count());
            Assert.AreEqual(dto.NUMERO, reservationRequestsView.DataObject.NUMERO);
            Assert.AreEqual(dto.MOPETI, reservationRequestsView.DataObject.MOPETI);
        }


    }
}
