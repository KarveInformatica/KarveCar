using DataAccessLayer;
using KarveDataServices;
using KarveDataServices.ViewObjects;
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
           IEnumerable<OfficeSummaryViewObject> officeSummary = await officeDataServices.GetPagedSummaryDoAsync(1,10);
           OfficeSummaryViewObject summaryViewObject=officeSummary.FirstOrDefault<OfficeSummaryViewObject>();
           
           Assert.NotNull(summaryViewObject);
            // act
           IOfficeData officeData = await officeDataServices.GetAsyncOfficeDo(summaryViewObject.Code).ConfigureAwait(false);
            // assert
            Assert.IsTrue(officeData.Valid);
            OfficeViewObject viewObject = officeData.Value as OfficeViewObject;
            Assert.NotNull(viewObject);
            Assert.AreEqual(summaryViewObject.Code, officeData.Value.Codigo);
            Assert.Greater(viewObject.Province.Count(), 0);
            Assert.Greater(viewObject.HolidayDates.Count(), 0);

        }
        [Test]
        public void Should_Throw_OfficeWhenBadCode()
        {
            IOfficeDataServices officeDataServices = _dataServices.GetOfficeDataServices();
            Assert.ThrowsAsync<DataLayerException>(async () => await officeDataServices.GetAsyncOfficeDo("-1"));
            
        }

    }

}