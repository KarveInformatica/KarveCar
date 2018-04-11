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
                _mockRegionManager.Object, _mockRequestController.Object);
        }
        [Test]
        public void Should_Setup_Fare()
        {
         
        }
        [Test]
        public void Should_Arrive_A_NewItem_From_Control_ViewModel()
        {
        }

    }
}
