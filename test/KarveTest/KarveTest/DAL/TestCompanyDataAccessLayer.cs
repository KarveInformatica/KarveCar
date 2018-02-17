using DataAccessLayer;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveTest.DAL
{
    [TestFixture]
    class TestCompanyDataAccessLayer: TestBase
    {
        private ISqlExecutor _sqlExecutor;
        private IConfigurationService _serviceConf;
        private ICompanyDataService _companyDataService;
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
                var dataServices = new DataServiceImplementation(_sqlExecutor);
                _companyDataService = dataServices.GetCompanyDataServices();
                //  _commissionAgentDataServices = _dataServices.GetCommissionAgentDataServices();
              //  Assert.NotNull(_commissionAgentDataServices);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public async Task Should_Load_Correctly_Summary()
        {
            var listOfCompanies = await _companyDataService.GetAsyncAllCompanySummary();
            Assert.Greater(listOfCompanies.Count<CompanySummaryDto>(), 0);
        }

    }
}
