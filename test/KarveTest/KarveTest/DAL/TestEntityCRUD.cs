using System;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.Crud;
using DataAccessLayer.DtoWrapper;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using NUnit.Framework;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveDapper.Extensions;

namespace KarveTest.DAL
{
    /// <summary>
    /// This fixture tests the CRUD on single entities.
    /// </summary>
    [TestFixture]
    class TestEntityCrud: TestBase
    {
        private ISqlExecutor _sqlExecutor;
        private IDataLoader<ComisioViewObject> _dataLoader;
        private IDataSaver<ComisioViewObject> _dataSaver;
        private IDataDeleter<ComisioViewObject> _dataDeleter;
        /// <summary>
        /// This setup the test for entity modification.
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {
            try
            {
                _sqlExecutor = SetupSqlQueryExecutor();
                _dataLoader = new DataLoader<COMISIO, ComisioViewObject>(_sqlExecutor);
                _dataSaver = new DataSaver<COMISIO,ComisioViewObject>(_sqlExecutor);
                _dataDeleter = new DataDeleter<COMISIO,ComisioViewObject>(_sqlExecutor);
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
           var expectedCode = String.Empty;
            using (var dbConnection = _sqlExecutor.OpenNewDbConnection())
            {
                if (dbConnection != null)
                {
                    var resultData = await dbConnection.GetPagedAsync<COMISIO>(1, 2);
                    var resultItem = resultData.FirstOrDefault();
                    expectedCode = resultItem?.NUM_COMI;
                }
            }
           var value = new ComisioViewObject
           {
                 NUM_COMI = expectedCode
            };
            var dtoValue = await  _dataLoader.LoadValueAsync(value.NUM_COMI);
            Assert.AreEqual(value.NUM_COMI, dtoValue.NUM_COMI);
            value.NOMBRE = "BasicSupplier";
            var result = await _dataSaver.SaveAsync(value);
            Assert.AreEqual(result, true);
        }
        /// <summary>
        ///  This test detect and error and save entities in not a correct way.
        /// </summary>
        [Test]
        public void Should_Throw_Entities_NotCorrectSavedData()
        {
            ComisioViewObject value = new ComisioViewObject {NUM_COMI = ""};
            Assert.ThrowsAsync<DataLayerException>(async () => await _dataSaver.SaveAsync(value));
            
          
        }
        /// <summary>
        ///  This test insert and delete an entity correctly.
        /// </summary>
        [Test]
        public async Task Should_Entity_Insert_And_Delete_A_Correctly()
        {
            var value = new ComisioViewObject {NUM_COMI = "891892", NOMBRE = "Lucia"};
            bool result = await _dataSaver.SaveAsync(value);
            Assert.IsTrue(result);
            bool dataDeleter = await _dataDeleter.DeleteAsync(value);
            Assert.IsTrue(dataDeleter);
        }
        /// <summary>
        ///  This test should delete and insert data correctly.
        /// </summary>
        [Test]
        public async Task  Should_Delete_And_Insert_Data_Correnctly()
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
