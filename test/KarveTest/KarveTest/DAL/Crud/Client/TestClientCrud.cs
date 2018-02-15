using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using NUnit.Framework;
using KarveTest.DAL;
using DataAccessLayer.Crud;

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
        public 
    }
}
