using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using DataAccessLayer;
using KarveDataServices;
using KarveDataServices.DataObjects;
using NUnit.Framework;
using KarveCommon.Services;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using KarveCommon.Generic;
using KarveDataServices.DataTransferObject;
using MasterModule.ViewModels;
using Microsoft.Practices.Unity;
using Moq;
using Prism.Regions;

namespace KarveTest.DAL
{
    [TestFixture]
    public class TestSupplierDataServicesLayer: TestBase
    {
        private IDataServices _dataServices;
        private ISupplierDataServices _supplierDataServices;
        private const string ConnectionString = "EngineName=DBRENT_NET16;DataBaseName=DBRENT_NET16;Uid=cv;Pwd=1929;Host=172.26.0.45";

        [OneTimeSetUp]
        public void SetUp()
        {
            _dataServices = null;
            try
            {
                ISqlExecutor executor = SetupSqlQueryExecutor();
               _dataServices = new DataServiceImplementation(executor);
                _supplierDataServices = _dataServices.GetSupplierDataServices();
            }
           catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void Should_Return_To_ViewModel_SummaryCollection()
        {
            var eventManager = new Mock<IEventManager>();
            var configurationService = new Mock<IConfigurationService>();
            var unity = new Mock<IUnityContainer>();
            var regionManager = new Mock<IRegionManager>();
            ProvidersControlViewModel providersControlViewModel = new ProvidersControlViewModel(configurationService.Object,
                unity.Object,
                _dataServices,
                regionManager.Object,
                eventManager.Object);
            providersControlViewModel.StartAndNotify();
            IEnumerable<SupplierSummaryDto> collection = providersControlViewModel.SummaryCollection;
            Assert.GreaterOrEqual(collection.Distinct().Count(), 1);
        }
        [Test]
        public async Task Should_Give_Me_A_SupplierCollection()
        {
            // Setup already arranged all.
            // Act
            IEnumerable<ISupplierData> supplierCollection =  await _supplierDataServices.GetAsyncSupplierCollection();
            // Assert
            Assert.NotNull(supplierCollection);
            ISupplierData data = supplierCollection.FirstOrDefault();
            Assert.NotNull(data);
            var invalidData = from supplier in supplierCollection
                where supplier.Valid == false
                select supplier;
            var invalidDataShallBeNull = invalidData.FirstOrDefault();
            Assert.Null(invalidDataShallBeNull);

        }

        [Test]
        public async Task Should_Give_Dtos_Supplier()
        {
            IEnumerable<ISupplierData> supplierCollection = await _supplierDataServices.GetAsyncSupplierCollection();
            // Assert
            Assert.NotNull(supplierCollection);
            ISupplierData data = supplierCollection.FirstOrDefault();
            var accountDtos = data.AccountDtos;
            Assert.GreaterOrEqual(accountDtos.Distinct().Count(),1); 
            var banksDto = data.BanksDtos;
            Assert.GreaterOrEqual(banksDto.Distinct().Count(), 1);
            var vias = data.ViasDtos;
            Assert.GreaterOrEqual(vias.Distinct().Count(), 1);
            var province = data.ProvinciaDtos;
            Assert.GreaterOrEqual(province.Distinct().Count(), 1);
            var country = data.CountryDtos;
            Assert.GreaterOrEqual(country.Distinct().Count(), 1);
            var paymentForm = data.PaymentDtos;
            Assert.GreaterOrEqual(paymentForm.Distinct().Count(), 1);
        }

        [Test]
        public async Task Should_Give_Me_A_SupplierCollectionIds_Unique()
        {
            IEnumerable<ISupplierData> supplierCollection = await _supplierDataServices.GetAsyncSupplierCollection();
            var grouping = supplierCollection.GroupBy(item => (item.Value.NUM_PROVEE)).GroupBy(t => t).Where(t => t.Count() != 1);
            Assert.Null(grouping.FirstOrDefault());
        }
        [Test]
        public async Task Should_Give_Me_SupplierSummaryDts()
        {
            IEnumerable<SupplierSummaryDto> supplierCollection = await _supplierDataServices.GetSupplierAsyncSummaryDo();
            Assert.GreaterOrEqual(supplierCollection.Distinct().Count(),1);
        }

        [Test]
        public async Task Should_Delete_A_SupplieDo()
        {
            // arrange
            IEnumerable<ISupplierData> supplierCollection = await _supplierDataServices.GetAsyncSupplierCollection();
            ISupplierData supplierData = supplierCollection.FirstOrDefault();
            Assert.NotNull(supplierData);
            bool value = await _supplierDataServices.DeleteAsyncSupplierDo(supplierData);
            Assert.True(value);
        }
        [Test]
        public async Task Should_Insert_And_Save_A_Supplier()
        {
            string id = _supplierDataServices.GetNewId();
            ISupplierData data = _supplierDataServices.GetNewSupplierDo(id);
            SupplierDto dto = data.Value;
            bool value = await _supplierDataServices.Save(data);
            Assert.True(value);
        }
        /// <summary>
        ///  Should udpate and save a vehicle.
        /// </summary>
        /// <returns></returns>
        public async Task Should_Update_Save_A_Vehicle()
        {
            IEnumerable<ISupplierData> supplierCollection = await _supplierDataServices.GetAsyncSupplierCollection();
            ISupplierData supplierData = supplierCollection.FirstOrDefault();
            Assert.NotNull(supplierData);
            bool value = await _supplierDataServices.SaveChanges(supplierData);

        }
        [Test]
        public async Task Should_Give_Me_A_Valid_Supplier()
        {
            // arrange
            IEnumerable<ISupplierData> supplierCollection = await _supplierDataServices.GetAsyncSupplierCollection();
            ISupplierData validSupplier = supplierCollection.FirstOrDefault();
            Assert.NotNull(validSupplier);
            ISupplierData supplier = await _supplierDataServices.GetAsyncSupplierDo(validSupplier.Value.NUM_PROVEE);
            Assert.True(supplier.Valid);
            Assert.AreEqual(validSupplier, supplier);
        }

        // <summary>
        // This is an asynchronous test where for each supplier we get the information for its supplierId.
        // </summary>
        // <returns></returns>
        [Test]
        public async Task Should_Give_SupplierSummary()
        {
            DataSet set = null;
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    set = await _supplierDataServices.GetAsyncAllSupplierSummary();
                    Assert.NotNull(set);
                    Assert.Greater(set.Tables.Count, 0);
                    Assert.NotNull(set.Tables[0]);
                    int rowCounts = set.Tables[0].Rows.Count;
                    Assert.Greater(set.Tables[0].Rows.Count, 0);
                    Assert.NotNull(set.Tables[0].Rows[0][0]);
                    for (int k = 0; k < rowCounts; ++k)
                    {
                        string value = set.Tables[0].Rows[k][0] as string;
                        Assert.NotNull(value);
                        Assert.LessOrEqual(value.Length, 7);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // <summary>
        // This is an asynchronous test where for each supplier we get the information for its supplierId.
        // </summary>
        // <returns></returns>
        [Test]
        public async Task Should_Give_SupplierCompleteSummary()
        {
            DataSet set = null;
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    set = await _supplierDataServices.GetAsyncSuppliers();
                    Assert.NotNull(set);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// Should have a new provider id.
        /// </summary>
        [Test]
        public void Should_Have_NewProviderId()
        {
            // the item shall be unique.
            List<string> idList = new List<string>();
            string item = "";
            for (int i = 0; i < 10; ++i)
            {
                item = _supplierDataServices.GetNewId();
                Assert.IsTrue(!idList.Contains(item));
                idList.Add(item);
            }
            Assert.AreEqual(idList.Count, 10);
        }


    }
}
