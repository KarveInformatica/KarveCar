using DataAccessLayer.SQL;
using NUnit.Framework;


namespace KarveTest.DAL
{
    class TestBuildQuery
    {
        private QueryStoreFactory _storeFactory = new QueryStoreFactory();
        private IQueryStore _store;
        [OneTimeSetUp]
        public void Setup()
        {
          _store = _storeFactory.GetQueryStore();
        }
        [Test]
        public void Should_Build_QueryWithParameters()
        {
            _store.AddParam(QueryType.QueryCity, "0001");
            _store.AddParam(QueryType.QueryLanguage, "0001");
            var value = _store.BuildQuery();
            Assert.NotNull(value);
        }
    }
}
