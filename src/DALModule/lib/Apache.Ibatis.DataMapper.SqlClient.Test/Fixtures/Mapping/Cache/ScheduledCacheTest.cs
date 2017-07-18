using System;
using System.Threading;
using Apache.Ibatis.DataMapper.Model.Cache;
using Apache.Ibatis.DataMapper.Model.Cache.Decorators;
using Apache.Ibatis.DataMapper.Model.Cache.Implementation;
using NUnit.Framework;


namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping.Cache
{
    [TestFixture]
    public class ScheduledCacheTest
    {
        [Test]
        [Category("Scheduled cache")]
        public void All_objects_should_be_flush_after_a_certain_time()
        {
            ICache cache = new PerpetualCache();
            cache = new ScheduledCache(cache, 1);
            cache = new LoggingCache(cache);
            for (int i = 0; i < 100; i++)
            {
                cache[i] = i;
                Assert.That(cache[i], Is.EqualTo(i));
            }
            Thread.Sleep(new TimeSpan(0,0,1,5));
            Assert.That(cache.Size, Is.EqualTo(0));
        }

        [Test]
        public void Item_should_be_removed_on_demand()
        {
            ICache cache = new PerpetualCache();
            cache = new ScheduledCache(cache, 60000);
            cache = new LoggingCache(cache);

            cache[0] = 0;
            Assert.That(cache[0], Is.Not.Null);

            cache.Remove(0);
            Assert.That(cache[0], Is.Null);
        }

        [Test]
        public void Cache_should_be_clear_on_demand()
        {
            ICache cache = new PerpetualCache();
            cache = new ScheduledCache(cache, 60000);
            cache = new LoggingCache(cache);

            for (int i = 0; i < 5; i++)
            {
                cache[i] = i;
            }

            Assert.That(cache[0], Is.Not.Null);
            Assert.That(cache[4], Is.Not.Null);
            cache.Clear();
            Assert.That(cache[0], Is.Null);
            Assert.That(cache[4], Is.Null);
        }
    }
}
