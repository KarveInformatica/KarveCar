using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Model;
using DataAccessLayer.SQL;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using NUnit.Framework;

namespace KarveTest.DAL
{
    /// <summary>
    /// This test test the basic operation of insert, delete, update a single entity.
    /// </summary>
    [TestFixture]
    class TestDataCrud: TestBase
    {
        private ISqlExecutor _sqlExecutor;
        private IDataLoader<SupplierDto> _dataLoader;
        private IDataSaver<SupplierDto> _dataSaver;
        private IDataDeleter<SupplierDto> _dataDeleter;
        /// <summary>
        /// The setup.
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

        [Test]
        public async void Should_Load_Modify_And_Save_Correctly()
        {
            SupplierDto value = new SupplierDto();
            value.NUM_PROVEE = "91892291";
            SupplierDto dtoValue = await  _dataLoader.LoadValueAsync(value.NUM_PROVEE);
            Assert.AreEqual(value.NUM_PROVEE, dtoValue.NUM_PROVEE);
            value.NOMBRE = "BasicSupplier";
            bool result = await _dataSaver.SaveAsync(value);
            Assert.AreEqual(result, true);
        }

        [Test]
        public async void Should_Detect_Error_Saving_A_Not_Correct_Data()
        {
            SupplierDto value = new SupplierDto();
            value.NUM_PROVEE = "";
            bool result = await _dataSaver.SaveAsync(value);
            Assert.AreEqual(result, false);
        }

        [Test]
        public async void Should_Insert_And_Delete_A_Correctly()
        {
            SupplierDto value = new SupplierDto();
            value.NUM_PROVEE = "891892";
            bool result = await _dataSaver.SaveAsync(value);
            Assert.IsTrue(result);
            bool dataDeleter = await _dataDeleter.DeleteAsync(value);
            Assert.IsTrue(dataDeleter);
        }
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
