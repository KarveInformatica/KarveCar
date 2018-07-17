using BookingModule.ViewModels;
using KarveDataServices;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveTest.ViewModels
{
    class TestBookingInfoViewModel: TestViewModelBase
    {
        private BookingInfoViewModel _viewModel;
        private Mock<IBookingDataService> _bookingDataService = new Mock<IBookingDataService>();
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
                _mockRequestController.Object);

            
           // _mockDataServices.Setup(
                
           //     _navigator.Setup(x => x.NewClientView(It.IsAny<Uri>()))
        // .Callback(() => { isClientNavigated = true; });)
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
