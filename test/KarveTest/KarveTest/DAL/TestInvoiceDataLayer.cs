using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using KarveDataServices;
using KarveCommon.Services;
using DataAccessLayer;

namespace KarveTest.DAL
{ 
    /// <summary>
    ///  This test the invoice fetching.
    /// </summary>
    [TestFixture]
    class TestInvoiceDataLayer: TestBase
    {
        /// <summary>
        ///  executor 
        /// </summary>
        private ISqlExecutor _sqlExecutor;
        /// <summary>
        ///  service
        /// </summary>
        private IConfigurationService _serviceConf;
        /// <summary>
        ///  invoice data service.
        /// </summary>
        private IInvoiceDataServices _invoiceDataService;
        /// <summary>
        /// The setup.
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {

            _serviceConf = base.SetupConfigurationService();
            try
            {
                _sqlExecutor = SetupSqlQueryExecutor();
                var dataServices = new DataServiceImplementation(_sqlExecutor);
                _invoiceDataService = dataServices.GetInvoiceDataServices();              
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        /// <summary>
        ///  This test load a summary correctly
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Shall_LoadSummary_Correctly()
        {
            // arrange
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    var invoiceSummary = await _invoiceDataService.GetInvoiceSummaryAsync();
                    Assert.GreaterOrEqual(invoiceSummary.Count(), 0);
                }
            } catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        ///  This test load an item correctly.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Should_LoadItem_Correctly()
        {
            // arrange
            try
            {
                // load every invoice
                var invoiceSummary = await _invoiceDataService.GetInvoiceSummaryAsync();
                var invoice = invoiceSummary.FirstOrDefault();
                Assert.NotNull(invoice);
                var invoiceCode = await _invoiceDataService.GetInvoiceDoAsync(invoice.InvoiceCode);
                Assert.NotNull(invoiceCode);
                Assert.AreEqual(invoice.InvoiceCode, invoiceCode.Value.NUMERO_FAC);
            
            } catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Should fail to load using an invalid code.
        /// </summary>
        [Test]
        public async Task Should_FailLoading_UsingAnInvalid_Code()
        {
            bool failed = false;
            try
            {
                // arrange
                var code = "-19292";
                // act
                var invoiceCode = await _invoiceDataService.GetInvoiceDoAsync(code);
                // assert
                Assert.NotNull(invoiceCode);
            } catch(Exception e)
            {
                failed = true;
            }
            Assert.Equals(failed, true);
        }
    }
}
