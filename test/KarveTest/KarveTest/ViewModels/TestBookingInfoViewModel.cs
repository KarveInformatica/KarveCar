using BookingModule.ViewModels;
using KarveDataServices;
using Moq;
using NUnit.Framework;

namespace KarveTest.ViewModels
{
    using BookingModule.Service;

    class TestBookingInfoViewModel: TestViewModelBase
    {
        private BookingInfoViewModel _viewModel;
        private Mock<IBookingDataService> _bookingDataService = new Mock<IBookingDataService>();

        private Mock<IBookingService> _bookingLogicService = new Mock<IBookingService>();
        [SetUp]
        public void SetUp()
        {
            _viewModel = new BookingInfoViewModel(
                _mockDataServices.Object,
                _mockDialogService.Object,
                _mockEventManager.Object,
                _mockUnityContainer.Object,
                _mockRegionManager.Object,
                _mockKarveNavigator.Object,
                _mockConfigurationService.Object,
                _mockRequestController.Object,
                this._bookingLogicService.Object);            
        }

        Mock<IBookingDataService> Setup()
        {
            var bookingDataService = new Mock<IBookingDataService>();
           // bookingDataService.Setup(x => x.GetBookingItemsCount(It.IsAny<string>())).ReturnsAsync(;
            return bookingDataService;
        }
        // i shall detect a change correctly.

        [Test]
        public void Should_DetectAChange_Correctly()
        {

        }
        [Test]
        public void Should_Raise_AnAssist_Correctly()
        {
        }
       
    }
}
