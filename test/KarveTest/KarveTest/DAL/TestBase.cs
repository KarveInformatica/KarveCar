using KarveCommon.Generic;
using KarveCommon.Services;

namespace KarveTest.DAL
{
    public class TestBase
    {
        protected const string TestConnectionString =
            "EngineName=DBRENT_NET16;DataBaseName=DBRENT_NET16;Uid=cv;Pwd=1929;Host=172.26.0.45";
        
        protected IConfigurationService SetupConfigurationService()
        {
            IConfigurationService configurationService = new KarveCar.Logic.ConfigurationService();
            return configurationService;
        }

        protected ISqlQueryExecutor SetupSqlQueryExecutor()
        {
            ISqlQueryExecutor executor = new OleDbQueryExecutor(TestConnectionString);
            return executor;
        }

}
}