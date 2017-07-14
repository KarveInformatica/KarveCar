using System;
using System.Collections.Generic;
using Apache.Ibatis.DataMapper.Model.Cache;
using Apache.Ibatis.DataMapper.Model.Cache.Decorators;
using Apache.Ibatis.DataMapper.Model.Cache.Implementation;
using NUnit.Framework;


namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping.Cache
{
    [TestFixture]
    public class WeakCacheTest
    {

        [Test]
        public void Least_recently_used_item_should_be_removed()
        {
            WeakCache cache = new WeakCache();
            for (int i = 0; i < 1000000; i++)
            {
                cache[i] = i;
            }
            GC.Collect();
            object o = cache[0];

            Assert.That(cache.Size, Is.EqualTo(999999));
        }

        [Test]
        public void Demonstrate_that_copies_are_equals()
        {
            ICache cache = new WeakCache();
            cache = new SharedCache(cache);

            for (int i = 0; i < 100000; i++)
            {
                cache[i] = i;
                object value = cache[i];
                Assert.That(value, Is.Null | Is.EqualTo(i));
            }
        }

        [Test]
        public void Item_should_be_removed_on_demand()
        {
            ICache cache = new WeakCache();

            cache[0] = 0;
            Assert.That(cache[0], Is.Not.Null);

            cache.Remove(0);
            Assert.That(cache[0], Is.Null);
        }

        [Test]
        public void Cache_should_be_clear_on_demand()
        {
            ICache cache = new WeakCache();

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
