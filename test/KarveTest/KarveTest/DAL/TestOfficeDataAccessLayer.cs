using DataAccessLayer;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using KarveDataServices.DataObjects;

namespace KarveTest.DAL
{
    
    public class TestOfficeDataAccessLayer : TestBase
    {

        private IDataServices _dataServices;
        private ISqlExecutor _sqlExecutor;
        private Mock<ISqlExecutor> _sqlExecutorMocked = new Mock<ISqlExecutor>();

        public TestOfficeDataAccessLayer() : base()
        {
        }
        /// <summary>
        /// Setup the client data
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {
            _dataServices = null;
            try
            {
                _sqlExecutor = SetupSqlQueryExecutor();
                _dataServices = new DataServiceImplementation(_sqlExecutor);
                Assert.NotNull(_dataServices);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        private async Task Should_Load_An_Office_Correctly()
        {
            // arrange
           IOfficeDataServices officeDataServices = _dataServices.GetOfficeDataServices();
           IEnumerable<OfficeSummaryDto> officeSummary = await officeDataServices.GetAsyncAllOfficeSummary();
           OfficeSummaryDto summaryDto=officeSummary.FirstOrDefault<OfficeSummaryDto>();
           Assert.NotNull(summaryDto);
            // act
           IOfficeData officeData = await officeDataServices.GetAsyncOfficeDo(summaryDto.Code);
            // assert
           Assert.AreEqual(summaryDto.Code, officeData.Value.Codigo);
        }
      
       


    }

}