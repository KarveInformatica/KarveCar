using DataAccessLayer.SQL;
using NUnit.Framework;
namespace KarveTest.DAL
{
    class TestBuildQuery
    {
        private QueryStore _store = new QueryStore();
        [OneTimeSetUp]
        public void Setup()
        {
            _store = new QueryStore();
        }
        [Test]
        public void TestMultipleQuery()
        {
            _store.AddParam(QueryStore.QueryType.QueryCity, "0001");
            _store.AddParam(QueryStore.QueryType.QueryLanguage, "0001");
            var value = _store.BuildQuery();
        }
    }
}
