
using Apache.Ibatis.DataMapper.Model.Cache;
using Apache.Ibatis.DataMapper.Model.Cache.Implementation;
using NUnit.Framework;


namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping.Cache
{
    [TestFixture]
    public class LruCacheTest
    {
        [Test]
        public void Least_recently_used_item_should_be_removed()
        {
            LruCache cache = new LruCache();
            cache.Size = 5;

            for (int i = 0; i < 5; i++)
            {
                cache[i] = i;
            }

            Assert.That(cache[0], Is.EqualTo(0));
            cache[5] = 5;
            Assert.That(cache[1], Is.Null);
            Assert.That(cache.Size, Is.EqualTo(5));
        }

        [Test]
        public void Item_should_be_removed_on_demand()
        {
            ICache cache = new LruCache();

            cache[0] = 0;
            Assert.That(cache[0], Is.Not.Null);

            cache.Remove(0);
            Assert.That(cache[0], Is.Null);
        }

        [Test]
        public void Cache_should_be_clear_on_demand()
        {
            ICache cache = new LruCache();

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

        protected virtual ICache GetCache()
        {
            return new LruCache();
        }

        [Test]
        public void Cache_with_size_one_should_be_clear()
        {
            ICache cache = GetCache();
            cache.Size = 1;

            string testKey = "testKey";
            string testVal = "testVal";
            cache[testKey] = testVal;
            Assert.AreEqual(testVal, cache[testKey]);

            string testKey2 = "testKey2";
            string testVal2 = "testVal2";
            cache[testKey2] = testVal2;
            Assert.AreEqual(testVal2, cache[testKey2]);

            Assert.IsNull(cache[testKey]);
        }

        [Test]
        public void Get_and_put_object_should_work()
        {
            ICache cache = GetCache();
            string testKey = "testKey";
            string testVal = "testVal";

            Assert.AreEqual(cache[testKey], null);

            cache[testKey] = testVal;
            Assert.AreEqual(cache[testKey], testVal);

            cache[testKey] = null;
            Assert.AreEqual(cache[testKey], null);
        }

        [Test]
        public void Remove_from_cache_object_should_work()
        {
            ICache cache = GetCache();
            string testKey = "testKey";
            string testVal = "testVal";

            Assert.AreEqual(cache[testKey], null);

            cache[testKey] = testVal;
            Assert.AreEqual(cache[testKey], testVal);

            cache.Remove(testKey);
            Assert.AreEqual(cache[testKey], null);
        }

        [Test]
        public void Clear_cache_should_work()
        {
            ICache cache = GetCache();
            string testKey = "testKey";
            string testVal = "testVal";

            Assert.AreEqual(cache[testKey], null);

            cache[testKey] = testVal;
            Assert.AreEqual(cache[testKey], testVal);

            cache.Clear();
            Assert.AreEqual(cache[testKey], null);
        }
    }
}
