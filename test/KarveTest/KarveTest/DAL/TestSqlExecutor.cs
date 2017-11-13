using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
