using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using KarveCommon.Services;
using InvoiceModule.ViewModels;
using KarveDataServices.DataTransferObject;

namespace KarveTest.ViewModels
{
    [TestFixture]
    class TestInvoiceControlViewModel: TestViewModelBase
    {
       
        private readonly InvoiceControlViewModel _invoiceControlViewModel;
        private readonly DataPayLoad _currentPayload = new DataPayLoad();

     

        [SetUp]
        public void SetUp()
        {
           
            // This code simulate the return from the data base of a list of vehicles.
            _mockDataServices.Setup(x => x.GetInvoiceDataServices().GetInvoiceSummaryAsync()).ReturnsAsync(
                (() => new List<InvoiceSummaryValueDto>()
                {
                            new InvoiceSummaryValueDto(){ InvoiceCode="12239", InvoiceDate = DateTime.Now, ClientName = "Karve1" },
                            new InvoiceSummaryValueDto(){ InvoiceCode="12240", InvoiceDate = DateTime.Now, ClientName = "Karve2" },
                            new InvoiceSummaryValueDto(){ InvoiceCode="12241", InvoiceDate = DateTime.Now, ClientName = "Karve3" },
                            new InvoiceSummaryValueDto(){ InvoiceCode="12242", InvoiceDate = DateTime.Now, ClientName = "Karve4" }
                }));
            
          
            _mockEventManager.Setup(x => x.NotifyObserverSubsystem(InvoiceModule.InvoiceModule.InvoiceSubSystem, _currentPayload));
            _mockRegionManager.Setup(x => x.RequestNavigate("TabRegion", ""));
     
        }

        /// <summary>
        ///  This test if the view model correctly load the values.
        /// </summary>
        [Test]
        public void Should_Start_InvoiceControlView()
        {

            List<InvoiceSummaryValueDto> summaryValue = new List<InvoiceSummaryValueDto>()
                {
                            new InvoiceSummaryValueDto(){ InvoiceCode="12239", InvoiceDate = DateTime.Now, ClientName = "Karve1" },
                            new InvoiceSummaryValueDto(){ InvoiceCode="12240", InvoiceDate = DateTime.Now, ClientName = "Karve2" },
                            new InvoiceSummaryValueDto(){ InvoiceCode="12241", InvoiceDate = DateTime.Now, ClientName = "Karve3" },
                            new InvoiceSummaryValueDto(){ InvoiceCode="12242", InvoiceDate = DateTime.Now, ClientName = "Karve4" }
            };
            // arrange and execute the load
             var invoiceControlViewModel = new InvoiceControlViewModel(_mockDataServices.Object,
                                                                   _mockUnityContainer.Object,
                                                                   _mockDialogService.Object,
                                                                   _mockRegionManager.Object,
                                                                   _mockRequestController.Object,
                                                                   _mockEventManager.Object);
            // here we sall have a summary view.
            var summaryView = invoiceControlViewModel.SummaryView;
            var summaryView2 = summaryView.Intersect<InvoiceSummaryValueDto>(summaryValue);
            Assert.AreEqual(summaryView.Count(), summaryView2.Count());
        }
       
    }
}
