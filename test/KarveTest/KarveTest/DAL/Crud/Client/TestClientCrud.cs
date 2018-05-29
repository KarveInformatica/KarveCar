using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Crud;
using DataAccessLayer.DataObjects;
using KarveDapper.Extensions;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using NUnit.Framework;

namespace KarveTest.DAL.Crud.Client
{
    [TestFixture]
    class TestClientCrud: TestBase
    {
      
        private ISqlExecutor _sqlExecutor;
        private IDataLoader<ClientDto> _clientDataLoader;
        private IDataSaver<ClientDto> _clientDataSaver;
        private IDataDeleter<ClientDto> _clientDataDeleter;
        private CrudFactory _crudFactory;
        [OneTimeSetUp]
        public void SetUp()
        {
            try
            {
                _sqlExecutor = SetupSqlQueryExecutor();
                _crudFactory = CrudFactory.GetFactory(_sqlExecutor);
                _clientDataLoader = _crudFactory.ClientLoader;
                _clientDataSaver = _crudFactory.ClientSaver;
                _clientDataDeleter = _crudFactory.ClientDeleter;

                Assert.NotNull(_sqlExecutor);
                
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public async Task Should_Load_AClientEntity()
        {
            string currentCode = string.Empty;
            using (IDbConnection db = _sqlExecutor.OpenNewDbConnection())
            {
                var cli = await db.GetAsyncAll<DataAccessLayer.DataObjects.CLIENTES1>();
                var value = cli.OrderByDescending(p => p.NUMERO_CLI).FirstOrDefault();
                if (value != null)
                {
                    currentCode = value.NUMERO_CLI;
                }
            }
            Assert.AreNotEqual(currentCode, string.Empty);
        }
        [Test]
        public async Task Should_Load_Client_Correctly()
        {
            // arrange
            string currentCode = string.Empty;
            using (IDbConnection db = _sqlExecutor.OpenNewDbConnection())
            {
                var cli = await db.GetAsyncAll<DataAccessLayer.DataObjects.CLIENTES1>();
                var value = cli.OrderByDescending(p=>p.NUMERO_CLI).FirstOrDefault();
                if (value != null) currentCode = value.NUMERO_CLI;
            }
            ClientDto dto = await _clientDataLoader.LoadValueAsync(currentCode);
            Assert.AreEqual(dto.NUMERO_CLI, currentCode); 
            Assert.NotNull(dto);
            Assert.NotNull(dto.Helper);
        }

        [Test]
        public async Task Should_Save_AClientCorrectly()
        {
            var currentCode = string.Empty;
            POBLACIONES singleCity;

            using (var db = _sqlExecutor.OpenNewDbConnection())
            {
               
                var cli = await db.GetAsyncAll<DataAccessLayer.DataObjects.CLIENTES1>();
                var allCities = await db.GetAsyncAll<DataAccessLayer.DataObjects.POBLACIONES>();
                singleCity = allCities.FirstOrDefault();
                var value = cli.OrderByDescending(p => p.NUMERO_CLI).FirstOrDefault();
                if (value != null)
                {
                    currentCode = value.NUMERO_CLI;
                }
            }

            var dto = await _clientDataLoader.LoadValueAsync(currentCode);
            dto.EMAIL = "giorgio@gmail.com";
            if (singleCity != null)
            {
                dto.POBLACION = singleCity.CP;
            }
            var result = await _clientDataSaver.SaveAsync(dto);
            var changed = await _clientDataLoader.LoadValueAsync(currentCode);

            Assert.AreEqual(result, true);
            if (singleCity != null)
            {
                Assert.AreEqual(changed.POBLACION, singleCity.CP);
                Assert.AreEqual(dto.EMAIL, "giorgio@gmail.com");
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public async Task Should_Delete_AClientCorrectly()
        {
            string currentCode = string.Empty;
            // arrange
            using (var db = _sqlExecutor.OpenNewDbConnection())
            {

                var cli = await db.GetAsyncAll<DataAccessLayer.DataObjects.CLIENTES1>();
                var value = cli.OrderByDescending(p => p.NUMERO_CLI).FirstOrDefault();
                if (value != null)
                {
                    currentCode = value.NUMERO_CLI;
                }
            }
            var candidateDto = await _clientDataLoader.LoadValueAsync(currentCode);
            var resultValue = await _clientDataDeleter.DeleteAsync(candidateDto);
            using (var db = _sqlExecutor.OpenNewDbConnection())
            {
                var cli = await db.GetAsyncAll<DataAccessLayer.DataObjects.CLIENTES1>();
                var cli2 = await db.GetAsyncAll<DataAccessLayer.DataObjects.CLIENTES2>();
                var clientes1 = cli.FirstOrDefault(x => x.NUMERO_CLI == currentCode);
                var clientes2 = cli2.FirstOrDefault(x => x.NUMERO_CLI == currentCode);
                // i shall be sure that there has been deleted.
                Assert.Null(clientes1);
                Assert.Null(clientes2);
            }
            var candidateDeleted = await _clientDataLoader.LoadValueAsync(currentCode);
            Assert.AreEqual(candidateDeleted.IsValid, false);
            Assert.IsTrue(resultValue);
        }
    }
}
