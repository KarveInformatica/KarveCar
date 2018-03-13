using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Moq;
using KarveTest.Mock;
using Prism.Regions;
using MasterModule.ViewModels;
using NUnit.Framework;

namespace KarveTest.ViewModels
{
    class TestFareInfoViewModel: TestViewModelBase
    {
        private FaresInfoViewModel _fareInfoViewModel = null;

        public TestFareInfoViewModel()
        {
            _fareInfoViewModel = new FaresInfoViewModel(_mockEventManager.Object,
                _mockConfigurationService.Object,
                _mockDataServices.Object,
                _mockDialogService.Object,
                _mockRegionManager.Object);
        }
        [Test]
        public void Setup()
        {
            //  _eventManager.Setup(x=> x.)
            //  mock.Setup(foo => foo.DoSomething("ping")).Returns(true);
        }
        [Test]
        public void Should_Arrive_A_NewItem_From_Control_ViewModel()
        {
            /*
             arrange
            DataPayLoad payload = new DataPayLoad();
            string routedName =  "FareModule: 89839";
            payload.PayloadType = DataPayLoad.Type.Show;
            payload.Registration = routedName;
            payload.HasDataObject = false;
            payload.Subsystem = DataSubSystem.FareSubsystem;
            payload.DataObject = new FareDto();
            payload.PrimaryKey = "3000";
            _fareInfoViewModel.IncomingPayload(null);that we have the same dto
            */
        }

    }
}
