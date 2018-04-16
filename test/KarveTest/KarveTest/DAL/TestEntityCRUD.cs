using System;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.Crud;
using DataAccessLayer.Model;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using NUnit.Framework;
using System.Threading.Tasks;

namespace KarveTest.DAL
{
    /// <summary>
    /// This fixture tests the CRUD on single entities.
    /// </summary>
    [TestFixture]
    class TestEntityCrud: TestBase
    {
        private ISqlExecutor _sqlExecutor;
        private IDataLoader<SupplierDto> _dataLoader;
        private IDataSaver<SupplierDto> _dataSaver;
        private IDataDeleter<SupplierDto> _dataDeleter;
        /// <summary>
        /// This setup the test for entity modification.
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {
            try
            {
                _sqlExecutor = SetupSqlQueryExecutor();
                _dataLoader = new DataLoader<SupplierPoco, SupplierDto>(_sqlExecutor);
                _dataSaver = new DataSaver<SupplierPoco, SupplierDto>(_sqlExecutor);
                _dataDeleter = new DataDeleter<SupplierPoco,SupplierDto>(_sqlExecutor);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        ///  This test for a entity that load correctly.
        /// </summary>
        [Test]
        public async Task Should_Load_Entities_Modify_And_Save_Correctly()
        {
            SupplierDto value = new SupplierDto();
            value.NUM_PROVEE = "91892291";
            SupplierDto dtoValue = await  _dataLoader.LoadValueAsync(value.NUM_PROVEE);
            Assert.AreEqual(value.NUM_PROVEE, dtoValue.NUM_PROVEE);
            value.NOMBRE = "BasicSupplier";
            bool result = await _dataSaver.SaveAsync(value);
            Assert.AreEqual(result, true);
        }
        /// <summary>
        ///  This test detect and error and save entities in not a correct way.
        /// </summary>
        [Test]
        public async void Should_Detect_Error_Saving_Entities_A_Not_Correct_Data()
        {
            SupplierDto value = new SupplierDto();
            value.NUM_PROVEE = "";
            bool result = await _dataSaver.SaveAsync(value);
            Assert.AreEqual(result, false);
        }
        /// <summary>
        ///  This test insert and delete an entity correctly.
        /// </summary>
        [Test]
        public async void Should_Entity_Insert_And_Delete_A_Correctly()
        {
            SupplierDto value = new SupplierDto();
            value.NUM_PROVEE = "891892";
            bool result = await _dataSaver.SaveAsync(value);
            Assert.IsTrue(result);
            bool dataDeleter = await _dataDeleter.DeleteAsync(value);
            Assert.IsTrue(dataDeleter);
        }
        /// <summary>
        ///  This test should delete and insert data correctly.
        /// </summary>
        [Test]
        public async  void Should_Delete_And_Insert_Data_Correnctly()
        {
            var allValues = await _dataLoader.LoadAsyncAll();
            var valueToDelete = allValues.FirstOrDefault();
            if (valueToDelete != null)
            {
                bool retValue = await _dataDeleter.DeleteAsync(valueToDelete);
                Assert.IsTrue(retValue);                
                retValue= await _dataSaver.SaveAsync(valueToDelete);
                Assert.IsTrue(retValue);
            }
        }

    }
}
