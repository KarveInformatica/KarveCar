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
        public void Should_Open_Working_WithIn_Transaction_Scope_Working()
        {
            Assert.NotNull(_sqlExecutor);
            using (var scope = new TransactionScope())
            {
                try
                {
                    IDbConnection dbConnection = _sqlExecutor.OpenNewDbConnection();
                    Assert.NotNull(dbConnection);
                    Assert.AreEqual(ConnectionState.Open, dbConnection.State);
                    var value = dbConnection.Query(QueryExecution);
                    Assert.Greater(value.Distinct().Count(),0);
                }
                catch (Exception e)
                {
                    Assert.Fail(e.Message);                    
                }
            }
        }

    }
}
