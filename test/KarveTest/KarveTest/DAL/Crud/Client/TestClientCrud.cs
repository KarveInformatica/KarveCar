using System;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using NUnit.Framework;
using KarveTest.DAL;
using DataAccessLayer.Crud;
using System.Data;
using KarveDapper.Extensions;


namespace KarveDataAccessLayer.DAL.Crud
{
    [TestFixture]
    class TestClientCrud: TestBase
    {
        private IDataServices _dataServices;
        private ISqlExecutor _sqlExecutor;
        private IDataLoader<ClientDto> _clientDataLoader;
        private IDataSaver<ClientDto> _clientDataSaver;
        private IDataDeleter<ClientDto> _clientDataDeleter;
        private CrudFactory _crudFactory;
        [OneTimeSetUp]
        public void SetUp()
        {
            _dataServices = null;
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
        public async Task Should_Load_A_Client_Entity()
        {
            string currentCode = string.Empty;
            using (IDbConnection db = _sqlExecutor.OpenNewDbConnection())
            {
                var cli = await db.GetAsyncAll<DataAccessLayer.DataObjects.CLIENTES1>();
                var value = cli.OrderByDescending(p => p.NUMERO_CLI).FirstOrDefault();
                currentCode = value.NUMERO_CLI;
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
                currentCode = value.NUMERO_CLI;
            }
            ClientDto dto = await _clientDataLoader.LoadValueAsync(currentCode);
            Assert.AreEqual(dto.NUMERO_CLI, currentCode); 
            Assert.NotNull(dto);
        }
    }
}
