using Apache.Ibatis.DataMapper.Model.Cache;
using Apache.Ibatis.DataMapper.Model.Cache.Decorators;
using Apache.Ibatis.DataMapper.Model.Cache.Implementation;
using NUnit.Framework;


namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping.Cache
{
    [TestFixture]
    public class PerpetualCacheTest
    {
        [Test]
        [Category("Perpetual cache")]
        public void Demonstrate_how_all_objects_are_kept()
        {
            ICache cache = new PerpetualCache();
            cache = new SynchronizedCache(cache);

            for (int i = 0; i < 100000; i++)
            {
                cache[i] = i;
                Assert.That(cache[i], Is.EqualTo(i));
            }

            Assert.That(cache.Size, Is.EqualTo(100000));
        }

        [Test]
        [Category("Perpetual cache")]
        public void Demonstrate_that_copies_are_equals()
        {
            ICache cache = new PerpetualCache();
            cache = new SharedCache(cache);

            for (int i = 0; i < 100000; i++)
            {
                cache[i] = i;
                Assert.That(cache[i], Is.EqualTo(i));
            }
        }

        [Test]
        public void Item_should_be_removed_on_demand()
        {
            ICache cache = new PerpetualCache();
            cache = new SynchronizedCache(cache);

            cache[0] = 0;
            Assert.That(cache[0], Is.Not.Null);

            cache.Remove(0);
            Assert.That(cache[0], Is.Null);
        }

        [Test]
        public void Cache_should_be_clear_on_demand()
        {
            ICache cache = new PerpetualCache();
            cache = new SynchronizedCache(cache);

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
