
using Apache.Ibatis.DataMapper.Model.Cache;
using Apache.Ibatis.DataMapper.Model.Cache.Implementation;
using NUnit.Framework;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping.Cache
{
    [TestFixture]
    public class FifoCacheTest
    {
        [Test]
        public void First_item_should_be_removed()
        {
            FifoCache cache = new FifoCache();
            cache.Size = 5;

            for (int i = 0; i < 5; i++)
            {
                cache[i]= i;
            }

            Assert.That(cache[0], Is.EqualTo(0));
            cache[5] = 5;
            Assert.That(cache[0], Is.Null);
            Assert.That(cache.Size, Is.EqualTo(5));
        }

        [Test]
        public void Item_should_be_removed_on_demand()
        {
            ICache cache = new FifoCache();

            cache[0] = 0;
            Assert.That(cache[0], Is.Not.Null);

            cache.Remove(0);
            Assert.That(cache[0], Is.Null);
        }

        [Test]
        public void Cache_should_be_clear_on_demand()
        {
            ICache cache = new FifoCache();

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
