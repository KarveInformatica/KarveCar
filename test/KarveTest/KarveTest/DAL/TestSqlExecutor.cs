using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Dapper;
using DataAccessLayer;
using KarveCommon.Services;
using KarveDataServices;
using NUnit.Framework;

namespace KarveTest.DAL
{
    [TestFixture]
    public class TestSqlExecutor: TestBase
    {
        private IConfigurationService _serviceConf;
        // sample query.
        private const string QueryExecution = "select * from provee1"; 
        private ISqlExecutor _sqlExecutor;
        private const string ConnectionString =
            "EngineName=DBRENT_NET16;DataBaseName=DBRENT_NET16;Uid=cv;Pwd=1929;Host=172.26.0.45";
        [OneTimeSetUp]
        public void SetUp()
        {
            _serviceConf = base.SetupConfigurationService();
            try
            {
                _sqlExecutor = SetupSqlQueryExecutor();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        public void Should_Open_NewDatabaseConnection()
        {
            // arrange
            Assert.NotNull(_sqlExecutor);
            // act
            try
            {
                IDbConnection connection = null;
                using (connection = _sqlExecutor.OpenNewDbConnection())
                {

                    Assert.NotNull(connection);
                    Assert.AreEqual(ConnectionState.Open,connection.State);
                }
                Assert.AreEqual(connection.State, ConnectionState.Closed);
            } catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

                
        }


      

    }
}
