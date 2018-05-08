using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using KarveCommon.Services;
using KarveDataServices;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace KarveTest.DAL
{
    [TestFixture]
    class TestContractDataAccessLayer : TestBase
    {

        private ISqlExecutor _sqlExecutor;
        private IConfigurationService _serviceConf;
        private IContractDataServices _contractDataServices;
        private IDataServices _dataServices;
        /// <summary>
        /// The setup.
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {

            _serviceConf = base.SetupConfigurationService();
            try
            {
                _sqlExecutor = SetupSqlQueryExecutor();
                _dataServices = new DataServiceImplementation(_sqlExecutor);
                _contractDataServices = _dataServices.GetContractDataServices();
               
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public async Task Should_Load_ContractBasicSummary()
        {
            var contract = await  _contractDataServices.GetContractSummaryAsync();
            Assert.Greater(contract.Count(),0);
        }
    }
}
