using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using NUnit.Framework;
using KarveDataServices;
using DataAccessLayer;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Model;
using KarveDapper.Extensions;
using KarveDataServices.DataTransferObject;

namespace KarveTest.DAL
{
    /// <summary>
    ///  This test the invoice fetching.
    /// </summary>
    [TestFixture]
    class TestInvoiceDataLayer : TestBase
    {
        /// <summary>
        ///  executor 
        /// </summary>
        private ISqlExecutor _sqlExecutor;

        /// <summary>
        ///  invoice data service.
        /// </summary>
        private IInvoiceDataServices _invoiceDataService;

        private IDataServices _dataServices;

        /// <summary>
        /// The setup.
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {

            try
            {
                _sqlExecutor = SetupSqlQueryExecutor();
                _dataServices = new DataServiceImplementation(_sqlExecutor);
                _invoiceDataService = _dataServices.GetInvoiceDataServices();
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
        public async Task Should_Load_InvoiceSummaryCorrectly()
        {
            // arrange
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    var invoiceSummary = await _invoiceDataService.GetPagedSummaryDoAsync(1,100);
                    Assert.GreaterOrEqual(invoiceSummary.Count(), 0);
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        /// <summary>
        ///  This test load an item correctly.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Should_Load_InvoiceCorrectly()
        {
            // arrange
            try
            {
                // load every invoice
                var invoiceSummary = await _invoiceDataService.GetPagedSummaryDoAsync(1,10);
                var invoice = invoiceSummary.FirstOrDefault();
                Assert.NotNull(invoice);
                var invoiceCode = await _invoiceDataService.GetDoAsync(invoice.InvoiceName);
                Assert.NotNull(invoiceCode);
                Assert.IsNotInstanceOf<NullInvoice>(invoiceCode);
                Assert.AreEqual(invoice.InvoiceName, invoiceCode.Value.NUMERO_FAC);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public async Task Should_Load_InvoiceClientCorrectly()
        {
            try
            {



                var facturas = new FACTURAS();

                using (var connection = _sqlExecutor.OpenNewDbConnection())
                {
                    var clientes = await connection.GetPagedAsync<FACTURAS>(10, 10);
                    var singleClient = clientes.FirstOrDefault();
                    string query  = string.Format("SELECT * FROM FACTURAS WHERE CLIENTE_FAC='{0}'", singleClient.CLIENTE_FAC);
                    // 0000253
                    facturas =  await connection.QueryFirstAsync<FACTURAS>(query);
                }

                var singleInvoiceData = await _invoiceDataService.GetDoAsync(facturas.NUMERO_FAC);
                Assert.NotNull(singleInvoiceData);
                Assert.IsNotInstanceOf<NullInvoice>(singleInvoiceData);
                Assert.AreEqual(facturas.NUMERO_FAC, singleInvoiceData.Value.NUMERO_FAC);
                Assert.Greater(singleInvoiceData.ClientSummary.Count(),0);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        /// <summary>
        /// Should fail to load using an invalid code.
        /// </summary>
        [Test]
        public void Should_Fail_LoadingInvalidInvoice()
        {
            const string code = "-19292";
            Assert.ThrowsAsync<DataLayerException>(async () => await _invoiceDataService.GetDoAsync(code));
        }

        [Test]
        public void Should_Generate_InvoiceUniqueId()
        {
            // arrange
            var strDictionary = new HashSet<string>();
            var isValueDuplicated = false;
            // act
            foreach (var v in Enumerable.Range(1,10))
            {
                var currentId = _invoiceDataService.NewId();
                var isPresent = strDictionary.Contains(currentId);
                if (!isPresent)
                {
                    strDictionary.Add(currentId);
                }
                else
                {
                    isValueDuplicated = true;
                }

                break;
            }

            // assert.
            Assert.IsFalse(isValueDuplicated);
        }

        /// <summary>
        ///  Should invoice with lines.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Should_Save_AnInvoiceWithLines()
        {
            var factory = AbstractDomainWrapperFactory.GetFactory(_dataServices);
            var invoice = factory.CreateInvoice("28982");
            var invoiceDto = invoice.Value;
            var firstKey1 = string.Empty;
            var secondKey1 = string.Empty;
            int numberLiFact = 0;

            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                var pageAndCount = await dbConnection.GetPageCount<LIFAC>().ConfigureAwait(false);
                numberLiFact = pageAndCount.Item1;

            }
            numberLiFact++;
            firstKey1 = numberLiFact.ToString();
            numberLiFact++;
            secondKey1 = numberLiFact.ToString();
            invoiceDto.CLIENTE_FAC = "129231";
            invoiceDto.BRUTO_FAC = 1000;
            invoiceDto.BASE_FAC = 1000;
            invoiceDto.CONTRATO_FAC = "128283";


            var item0 = new InvoiceSummaryDto()
            {

                Description = "Lamps",
                Subtotal = 0,
                FileNumber = "1",
                VehicleCode = "9202920",
                Iva = 19,
                Price = 170,
                User = "CV",
                Unity = "M",
                Number = "0",
                Quantity = 1,
                IsNew = true,
                IsValid = true,
                KeyId = firstKey1

            };
            var item1 = new InvoiceSummaryDto()
            {
                Discount = 0,
                Description = "Lamps",
                Subtotal = 270,
                FileNumber = "1",
                Number = "1",
                VehicleCode = "9202920",
                Iva = 19,
                Price = 100,
                User = "CV",
                Unity = "M",
                Quantity = 1,
                IsNew = true,
                KeyId = secondKey1
            };

            var invoiceList = new List<InvoiceSummaryDto> {item0, item1};
            invoice.Value.InvoiceItems = invoiceList;
            var dataFactory = _dataServices.GetInvoiceDataServices();
            await dataFactory.DeleteAsync(invoice);
            // act 
            var retValue = await dataFactory.SaveAsync(invoice);
            // assert
            var invoiceValue = await dataFactory.GetDoAsync(invoice.Value.NUMERO_FAC);
            Assert.NotNull(invoiceValue);
            Assert.AreEqual(retValue, true);
            Assert.IsTrue(invoiceValue.Valid);
            var value = invoiceValue.Value;
            Assert.AreEqual(invoiceDto.CLIENTE_FAC, value.CLIENTE_FAC);
            Assert.AreEqual(invoiceDto.BRUTO_FAC, value.BRUTO_FAC);
            Assert.AreEqual(invoiceDto.BASE_FAC, value.BASE_FAC);
            Assert.AreEqual(invoiceDto.CONTRATO_FAC, value.CONTRATO_FAC);
            var invoiceLines = value.InvoiceItems.Except(invoiceList);
            Assert.AreEqual(0, invoiceLines.Count());

        }

        [Test]
        public async Task Should_Delete_InvoiceCorrectly()
        {
            var dataFactory = _dataServices.GetInvoiceDataServices();
            var summary = await dataFactory.GetPagedSummaryDoAsync(1,20);
            var invoice = summary.FirstOrDefault();
            var value = false;
            if (invoice != null)
            {
                var invoiceDo = await dataFactory.GetDoAsync(invoice.InvoiceName);
                Assert.IsNotInstanceOf(typeof(NullInvoice), invoiceDo);
                value = await dataFactory.DeleteAsync(invoiceDo);
            }

            if (invoice != null)
            {
                var invoiceValue = await dataFactory.GetDoAsync(invoice.InvoiceName);
                Assert.IsInstanceOf(typeof(NullInvoice), invoiceValue);
            }

            Assert.AreEqual(value, true);
        }
        [Test]
        public void Should_Discard_NullInvoice()
        {
            var factory = AbstractDomainWrapperFactory.GetFactory(_dataServices);
            var invoice = factory.CreateInvoice("28982");
            invoice.Value = null;
            var dataFactory = _dataServices.GetInvoiceDataServices();
            // act 
            Assert.ThrowsAsync<DataLayerException>(async() => await dataFactory.SaveAsync(invoice));

            
        }

        [Test]
        public async Task Should_Fail_SavingInvalidInvoiceNumber()
        {
            const string code = "-19292";
            var factory = AbstractDomainWrapperFactory.GetFactory(_dataServices);
            var invoice = factory.CreateInvoice(code);
            var dataFactory = _dataServices.GetInvoiceDataServices();
            // act 
            Assert.IsNotInstanceOf(typeof(NullInvoice), invoice);
            var invoiceSaved = false;
            invoiceSaved = await dataFactory.SaveAsync(invoice);
            Assert.AreEqual(invoiceSaved, false);
        }

        [Test]
        public void Should_Discard_AnInvalidInvoice()
        {
            var factory = AbstractDomainWrapperFactory.GetFactory(_dataServices);
            var invoice = factory.CreateInvoice("28982");
            var dataFactory = _dataServices.GetInvoiceDataServices();
            invoice.Value = null;
            Assert.ThrowsAsync<DataLayerException>(async () => await dataFactory.SaveAsync(invoice));
        }

    }
}
