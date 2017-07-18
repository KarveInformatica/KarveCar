
using Apache.Ibatis.DataMapper.Model.Cache.Decorators;
using Apache.Ibatis.DataMapper.Model.Cache.Implementation;
using NUnit.Framework;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping.Cache
{
    [TestFixture]
    public class BaseCacheTest
    {
        [Test]
        public void Equals_and_hashCode_on_decorated_cache_should_be_equal()
        {
            PerpetualCache cache = new PerpetualCache();
            cache.Id = "test_cache";

            Assert.That(cache, Is.EqualTo(cache));
            Assert.That(cache.Equals( new SynchronizedCache(cache) ), Is.True );
            Assert.That(cache.Equals( new SharedCache(cache) ), Is.True );
            Assert.That(cache.Equals( new LoggingCache(cache) ), Is.True );
            Assert.That(cache.Equals( new ScheduledCache(cache, long.MinValue) ), Is.True );
        }
    }
}
