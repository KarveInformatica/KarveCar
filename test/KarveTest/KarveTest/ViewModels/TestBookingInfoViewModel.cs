using BookingModule.ViewModels;
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
        [SetUp]
        public void SetUp()
        {

            _viewModel = new BookingInfoViewModel(
                _mockDataServices.Object,
                _mockDialogService.Object,
                _mockEventManager.Object,
                _mockUnityContainer.Object,
                _mockRegionManager.Object,
                _mockRequestController.Object);
          
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
