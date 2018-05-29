using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.SQL;
using KarveTest.DAL;
using KarveDataAccessLayer;
using KarveCommonInterfaces;
using KarveDataServices;
using NUnit.Framework;

namespace DataAccessLayer.Crud.Clients.Test
{
    /// <summary>
    ///  TestClientDataLoader.
    /// </summary>
    class TestClientDataLoader : TestBase
    {
        private ISqlExecutor _executor;
        [OneTimeSetUp]
        public void Setup()
        {
            _executor = SetupSqlQueryExecutor();
        }

        [Test]
        public void Should_Load_ClientDataCorrectly()
        {
            using (var dbConnection = _executor.OpenNewDbConnection())
            {
                QueryStoreFactory queryStoreFactory = new QueryStoreFactory();


            }
          
        }

       
    }
}
