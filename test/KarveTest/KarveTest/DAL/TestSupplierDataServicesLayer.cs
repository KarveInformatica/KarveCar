using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DataAccessLayer;
using KarveDataServices;
using KarveDataServices.DataObjects;
using NUnit.Framework;
using System.Linq;
using KarveDataServices.DataTransferObject;

namespace KarveTest.DAL
{
    [TestFixture]
    public class TestSupplierDataServicesLayer: TestBase
    {
        private IDataServices _dataServices;
        private ISupplierDataServices _supplierDataServices;
        private ISqlExecutor _sqlExecutor;
        private const string ConnectionString = "EngineName=DBRENT_NET16;DataBaseName=DBRENT_NET16;Uid=cv;Pwd=1929;Host=172.26.0.45";

        [OneTimeSetUp]
        public void SetUp()
        {
            _dataServices = null;
            try
            {
                _sqlExecutor = SetupSqlQueryExecutor();
               _dataServices = new DataServiceImplementation(_sqlExecutor);
                _supplierDataServices = _dataServices.GetSupplierDataServices();
            }
           catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }



        [Test]
        public async Task Should_Load_AtMost25Items()
        {
            var pageIndex = 0;
            var pageSize = 25;
            var dataService = await _supplierDataServices.GetPagedSummaryDoAsync(pageIndex, pageSize);
            Assert.NotNull(dataService);
            Assert.AreEqual(dataService.Count(),25);
        }

        [Test]
        public async Task Should_Load_Multiple25Items()
        {
            var pageIndex = 0;
            var pageSize = 25;
            var supplierDatos1 = await _supplierDataServices.GetPagedSummaryDoAsync(pageIndex, pageSize);
            pageIndex = 25;
            var supplierDatos2 = await _supplierDataServices.GetPagedSummaryDoAsync(pageIndex, pageSize);
            pageIndex = 50;
            var supplierDatos3 = await _supplierDataServices.GetPagedSummaryDoAsync(pageIndex, pageSize);
            Assert.NotNull(supplierDatos1);
            Assert.NotNull(supplierDatos2);
            Assert.NotNull(supplierDatos3);
            Assert.AreEqual(supplierDatos1.Count(), 25);
            Assert.AreEqual(supplierDatos2.Count(), 25);
            Assert.AreEqual(supplierDatos3.Count(), 25 );
        }
        [Test]
        public async Task Should_GiveMe_SupplierSummaryDto()
        {
            IEnumerable<SupplierSummaryDto>
                supplierCollection = await _supplierDataServices.GetSupplierAsyncSummaryDo();
            Assert.GreaterOrEqual(supplierCollection.Distinct().Count(), 1);
        }

        [Test]
        public async Task Should_Insert_And_Save_A_Supplier()
        {
            string id = _supplierDataServices.GetNewId();
            ISupplierData data = _supplierDataServices.GetNewSupplierDo(id);
            SupplierDto dto = data.Value;
            dto.NOMBRE = "GenericSupplier";
            data.Value = dto;
            bool value = await _supplierDataServices.Save(data);

            Assert.True(value);
        }
        [Test]
        public async Task Should_Update_SupplierBranches()
        {
            // arrange
            var suppliers = await _supplierDataServices.GetSupplierAsyncSummaryDo();
            SupplierSummaryDto supplierSummaryDto =  suppliers.FirstOrDefault();
            if (supplierSummaryDto != null)
            {
                var id = supplierSummaryDto.Codigo;
                var province = new ProvinciaDto();
                province.Name = "Barcelona";
                province.Code = "08";
                province.Country = "Spain";
                Random rand = new Random();
                var branches = new List<BranchesDto>()
                {
                    new BranchesDto() { BranchKeyId = id,
                        BranchId = (rand.Next() % 5000).ToString(),
                        Branch="EAE",
                        ProvinceSource = province,
                        City = "Barcelona",
                        Address = "Calle Rocafort 137",
                        Address2 = "Calle Arago 65",
                        Email = "carlos.velasco@gmail.com",
                        Notes = "MyNotes",
                        Fax ="+33889381982"
                    },
                    new BranchesDto() { BranchKeyId = id,
                        BranchId = (rand.Next() % 5000).ToString(),
                        Branch="Scala",
                        ProvinceSource = province,
                        City = "Barcelona",
                        Address = "Calle Rocafort 189",
                        Address2 = "Calle Arago 123",
                        Email = "carlos.velasco@gmail.com",
                        Notes = "MyNotes",
                        Fax ="+33889381982"
                    },
                    new BranchesDto() { BranchKeyId = id,
                        BranchId = (rand.Next() % 5000).ToString(),
                        Branch="Scala",
                        ProvinceSource = province,
                        City = "Barcelona",
                        Address = "Calle Rocafort 189",
                        Address2 = "Calle Arago 123",
                        Email = "carlos.velasco@gmail.com",
                        Notes = "MyNotes",
                        Fax ="+33889381982"
                    }
                };
                var dataObject = await _supplierDataServices.GetAsyncSupplierDo(id);
                Assert.NotNull(dataObject);
                dataObject.BranchesDto = dataObject.BranchesDto.Union(branches);
                //act
                bool retValue = await _supplierDataServices.Save(dataObject);
                // assert.
                Assert.IsTrue(retValue);
                var savedObject = await _supplierDataServices.GetAsyncSupplierDo(id);
                var currentObject = savedObject.BranchesDto.Intersect(branches);
                Assert.AreEqual(currentObject.Count(), branches.Count());
            }
        }

        [Test]
        public async Task Should_Load_AValid_Supplier()
        {
            // arrange
            var supplierCollection = await _supplierDataServices.GetSupplierAsyncSummaryDo();
            var codeId = supplierCollection.FirstOrDefault()?.Codigo;
            // act
            var supplier = await _supplierDataServices.GetAsyncSupplierDo(codeId);
            // assert
            Assert.True(supplier.Valid);
            Assert.NotNull(supplier.Value);

        }
        [Test]
        public async Task Should_Insert_NewSupplierWithAllFields()
        {
            Dictionary<string, object> mapperProperties = new Dictionary<string, object>();
            // arrange
            var supplierCollection = await _supplierDataServices.GetSupplierAsyncSummaryDo();
            var codeId = supplierCollection.FirstOrDefault()?.Codigo;
            // act
            var supplier = await _supplierDataServices.GetAsyncSupplierDo(codeId);
            SupplierDto value = supplier.Value;
            value.NOMBRE = "GZopSoft";
            value.DIRECCION = "Calle Paris 39";
            value.POBLACION = "VITORIA-GASTEITZ";

            // assert
            //Assert.True(supplier.Valid);
            //Assert.NotNull(supplier.Value);
        }

        /*     [Test]
             public async Task Should_Insert_NewSupplierWithAllFields()
             {
                 private Dictionary<string, object> mapperProperties = new Dictionary<string, object>();
           await Task.Delay();
             }
             */

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
            for (int i = 0; i < 10; ++i)
            {
                var item = _supplierDataServices.GetNewId();
                Assert.IsTrue(!idList.Contains(item));
                idList.Add(item);
            }
            Assert.AreEqual(idList.Count, 10);
        }


    }
}
