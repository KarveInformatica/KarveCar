using KarveDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DataAccessLayer;
using DataAccessLayer.DataObjects;
using KarveDataServices.ViewObjects;

namespace KarveTest.KarveDataServices
{
   
    /// <summary>
    ///  This text fixture enlist the set of tests needed for the karve data services. 
    ///  Trying to trigger any possibility of faults.
    /// </summary>
    class TestKarveDataServices: KarveTest.DAL.TestBase
    {
        
        public void SetUp()
        {
            try
            {
                SqlExecutor = SetupSqlQueryExecutor();
                DataServices = new DataServiceImplementation(SqlExecutor);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }
        /*
        [Test]
        public async Task Should_DAL_Reconfigure_Correctly()
        {
            string connectionString = "EngineName = DBRENT_GZ; DataBaseName = DBRENT_GZ; Uid = cv; Pwd = 1929; Host = 127.0.0.1";
            DataServices.Reconfigure(connectionString);
            // i need to verify if there is a connection and i can fetch datas after reconfiguration.
            IEnumerable<BanksViewObject> dtos = await DataServices.GetHelperDataServices().GetMappedAllAsyncHelper<BanksViewObject, BANCO>();
            Assert.NotNull(dtos);
            Assert.GreaterOrEqual(dtos.Count<BanksViewObject>(), 0);
        }
        
        [Test]
        public void Should_DAL_Throw_With_BadFormedString()
        {
            var connectionString = "3902392093*12-2021-029182---111";
            var saveConnectionString = SqlExecutor.ConnectionString;
            Assert.Throws<ArgumentException>(() => DataServices.Reconfigure(connectionString));
            DataServices.Reconfigure(saveConnectionString);
        }
        [Test]
        public void Should_DAL_Throw_With_EmptyString()
        {
            var connectionString = "";
            var saveConnectionString = SqlExecutor.ConnectionString;
            Assert.Throws<ArgumentException>(() => DataServices.Reconfigure(connectionString));
            DataServices.Reconfigure(saveConnectionString);
        }
        */
    }
}
