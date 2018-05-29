using KarveDataServices;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon;
using KarveCommonInterfaces;
using Syncfusion.Data;
using KarveCommon.Generic;
using KarveDataServices.DataTransferObject;
using DataAccessLayer.FilterService;
using Moq;
using Syncfusion.UI.Xaml.Grid;
using DataAccessLayer.SQL;

namespace KarveTest.DAL
{
    /// <summary>
    ///   This filters the data in the grid.
    /// </summary>
    [TestFixture]
    public class TestFilterData: TestBase
    {
        // SqlExecutor
        private ISqlExecutor _executor;
        /// <summary>
        ///  Query store doing any day.
        /// </summary>
        private QueryStore _queryStore;
        // Mock 
        private Mock<IDialogService> _dialogMock;
        // askedtoShow.
        private bool _askedToShow;
        /// <summary>
        ///  TestFilterData
        /// </summary>
        public TestFilterData()
        {
            _askedToShow = false;
        }
        [OneTimeSetUp]
        public void Setup()
        {
            _queryStore = new QueryStore();
            _executor = SetupSqlQueryExecutor();
            _dialogMock = new Mock<IDialogService>();
            _dialogMock.Setup(x => x.ShowErrorMessage(It.IsAny<string>())).Callback(() => _askedToShow = true);
        }
        [Test]
        public void Should_Trigger_ANewSummaryFilter()
        {
            IQueryFilter queryFilter = new QueryFilter("NOMBRE", "CLA*", PredicateType.And);
            IDataFilterService dataFilter = new DataFilterSummaryService<ClientSummaryExtended>(_dialogMock.Object, _executor);
            _queryStore.Clear();
            var query = queryFilter.Resolve();
            dataFilter.FilterEventResult += DataFilter_FilterEventResult;
            dataFilter.FilterDataAsync(query);
        }

        private void DataFilter_FilterEventResult(object data)
        {
            var dataValue = data as IncrementalList<ClientSummaryExtended>;
            Assert.NotNull(dataValue);
        }
    }
}
