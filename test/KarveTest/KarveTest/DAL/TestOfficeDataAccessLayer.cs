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
using KarveDapper;
using KarveDapper.Extensions;

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
        public async Task Should_Load_An_Office_Correctly()
        {
            // arrange
           IOfficeDataServices officeDataServices = _dataServices.GetOfficeDataServices();
           IEnumerable<OfficeSummaryDto> officeSummary = await officeDataServices.GetPagedSummaryDoAsync(1,10);
           OfficeSummaryDto summaryDto=officeSummary.FirstOrDefault<OfficeSummaryDto>();
           
           Assert.NotNull(summaryDto);
            // act
           IOfficeData officeData = await officeDataServices.GetAsyncOfficeDo(summaryDto.Code).ConfigureAwait(false);
            // assert
            Assert.IsTrue(officeData.Valid);
            OfficeDtos dto = officeData.Value as OfficeDtos;
            Assert.NotNull(dto);
            Assert.AreEqual(summaryDto.Code, officeData.Value.Codigo);
            Assert.Greater(dto.Province.Count(), 0);
            Assert.Greater(dto.HolidayDates.Count(), 0);

        }
        [Test]
        public void Should_Throw_OfficeWhenBadCode()
        {
            IOfficeDataServices officeDataServices = _dataServices.GetOfficeDataServices();
            Assert.ThrowsAsync<DataLayerException>(async () => await officeDataServices.GetAsyncOfficeDo("-1"));
            
        }

    }

}