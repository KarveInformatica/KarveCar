using System.Diagnostics;
using DataAccessLayer;
using DataAccessLayer.SQL;
using KarveCar.Logic.Generic;
using KarveCommon.Services;
using KarveDataServices;
using Moq;

namespace KarveTest.DAL
{
    public class TestBase
    {
        protected ISqlExecutor SqlExecutor;
        protected IDataServices DataServices;
        protected IDataServices MockedDataService;
        protected Mock<ISqlExecutor> MockSqlExecutor;
        protected const string TestConnectionString = "EngineName=DBRENT_NET16;DataBaseName=DBRENT_NET16;Uid=cv;Pwd=1929;Host=172.26.0.45:5225";
        protected Stopwatch Stopwatch = new Stopwatch();

        public TestBase()
        {
            SqlExecutor = SetupSqlQueryExecutor();
            MockSqlExecutor = new Mock<ISqlExecutor>();
            MockedDataService = new DataServiceImplementation(MockSqlExecutor.Object);
            DataServices = new DataServiceImplementation(SqlExecutor);
            Executor = SqlExecutor;
            Services = DataServices;
        }
        public ISqlExecutor Executor { set; get; }
        public IDataServices Services { set; get; }
        /// <summary>
        ///  Setup the configuration service
        /// </summary>
        /// <returns>An instance of the configuration service</returns>
        public IConfigurationService SetupConfigurationService()
        {
            IConfigurationService configurationService = new ConfigurationService();
            return configurationService;
        }
        /// <summary>
        ///  Setup the query executor
        /// </summary>
        /// <returns>An instance of the query executor</returns>
        public ISqlExecutor SetupSqlQueryExecutor()
        {
            ISqlExecutor executor = new OleDbExecutor(TestConnectionString);
            return executor;
        }
        /// <summary>
        ///  Setup the sql odbc executor.
        /// </summary>
        /// <returns></returns>
        public ISqlExecutor SetupSqlOdbcQueryExecutor()
        {
            ISqlExecutor executor = new OdbcExecutor(TestConnectionString);
            return executor;
        }

    }
}