using KarveDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DataAccessLayer;
using DataAccessLayer.DataObjects;
using KarveDataServices.DataTransferObject;

namespace KarveTest.KarveDataServices
{
   
    /// <summary>
    ///  This text fixture enlist the set of tests needed for the karve data services. 
    ///  Trying to trigger any possibility of faults.
    /// </summary>
    class TestKarveDataServices: KarveTest.DAL.TestBase
    {
        private IDataServices _dataServices;
       
        [OneTimeSetUp]
        public void SetUp()
        {
            _dataServices = null;
            try
            {
                ISqlExecutor executor = SetupSqlQueryExecutor();
                _dataServices = new DataServiceImplementation(executor);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }
        /// <summary>
        ///  This test stress the reconfiguration.
        /// </summary>
        [Test]
        public async Task Should_DAL_Reconfigure_Correctly()
        {
            string connectionString = "EngineName = DBRENT_GZ; DataBaseName = DBRENT_GZ; Uid = cv; Pwd = 1929; Host = 127.0.0.1";
            _dataServices.Reconfigure(connectionString);
            // i need to verify if there is a connection and i can fetch datas after reconfiguration.
            IEnumerable<BanksDto> dtos = await _dataServices.GetHelperDataServices().GetMappedAllAsyncHelper<BanksDto, BANCO>();
            Assert.NotNull(dtos);
            Assert.GreaterOrEqual(dtos.Count<BanksDto>(), 0);
        }
        [Test]
        public void Should_DAL_Throw_With_BadFormedString()
        {
            string connectionString = "3902392093*12-2021-029182---111";
            Assert.Throws<DataLayerException>(() => _dataServices.Reconfigure(connectionString));            
        }
        [Test]
        public void Should_DAL_Throw_With_EmptyString()
        {
            string connectionString = "";
            Assert.Throws<DataLayerException>(() => _dataServices.Reconfigure(connectionString));
        }
    }
}
