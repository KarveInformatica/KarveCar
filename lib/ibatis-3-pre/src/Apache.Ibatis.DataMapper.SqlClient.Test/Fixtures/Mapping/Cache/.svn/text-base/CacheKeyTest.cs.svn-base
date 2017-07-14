
using System;
using System.Collections.Generic;
using Apache.Ibatis.DataMapper.Model.Cache;
using Apache.Ibatis.DataMapper.Model.Cache.Implementation;
using NUnit.Framework;


namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping.Cache
{
    [TestFixture]
    public class CacheKeyTest
    {
        [Test]
        public void CacheKeys_should_be_equal()
        {
            DateTime date = DateTime.Now;
            CacheKey key1 = new CacheKey(new Object[] { 1, "hello", null, new DateTime(date.Ticks) });
            CacheKey key2 = new CacheKey(new Object[] { 1, "hello", null, new DateTime(date.Ticks) });

            Assert.That(key1, Is.EqualTo(key2));
            Assert.That(key2, Is.EqualTo(key1));
            Assert.That(key2.GetHashCode(), Is.EqualTo(key1.GetHashCode()));
            Assert.That(key1.GetHashCode(), Is.EqualTo(key2.GetHashCode()));
            Assert.That(key1.ToString(), Is.EqualTo(key2.ToString()));
        }

        [Test]
        public void CacheKeys_should_not_be_equal()
        {
            DateTime date = DateTime.Now;
            CacheKey key1 = new CacheKey(new Object[] { 1, "hello", null, new DateTime(date.Ticks) });
            CacheKey key2 = new CacheKey(new Object[] { 1, "hello", null, new DateTime(date.Ticks+5) });

            Assert.That(key1, Is.Not.EqualTo(key2));
            Assert.That(key2, Is.Not.EqualTo(key1));
            Assert.That(key1.GetHashCode(), Is.Not.EqualTo(key2.GetHashCode()));
            Assert.That(key1.ToString(), Is.Not.EqualTo(key2.ToString()));
        }

        [Test]
        public void CacheKeys_should_not_be_equal_due_to_order()
        {
            CacheKey key1 = new CacheKey(new Object[] { 1, "hello", null });
            CacheKey key2 = new CacheKey(new Object[] { 1, null, "hello" });

            Assert.That(key1, Is.Not.EqualTo(key2));
            Assert.That(key2, Is.Not.EqualTo(key1));
            Assert.That(key1.GetHashCode(), Is.Not.EqualTo(key2.GetHashCode()));
            Assert.That(key1.ToString(), Is.Not.EqualTo(key2.ToString()));
        }

        [Test]
        public void CacheKeys_empty_and_null_should_be_equal()
        {
            CacheKey key1 = new CacheKey();
            CacheKey key2 = new CacheKey();

            Assert.That(key1, Is.EqualTo(key2));
            Assert.That(key2, Is.EqualTo(key1));

            key1.Update(null);
            key2.Update(null);

            Assert.That(key1, Is.EqualTo(key2));
            Assert.That(key2, Is.EqualTo(key1));

            key1.Update(null);
            key2.Update(null);

            Assert.That(key1, Is.EqualTo(key2));
            Assert.That(key2, Is.EqualTo(key1));
        }

        [Test]
        public void ShouldNotConsider1LAndNegative9223372034707292159LToBeEqual()
        {
            // old version of ObjectProbe gave TestClass based on these longs the same HashCode
            DoTestClassEquals(1L, -9223372034707292159L);
        }

        [Test]
        public void Should_not_consider_1L_and_negative_9223372036524971138L_to_be_equal()
        {
            // current version of ObjectProbe gives TestClass based on these longs the same HashCode
            DoTestClassEquals(1L, -9223372036524971138L);
        }

        private static void DoTestClassEquals(long firstLong, long secondLong)
        {
            // Two cache keys are equal except for the parameter.
            CacheKey key = new CacheKey();

            key.Update(firstLong);

            CacheKey aDifferentKey = new CacheKey();

            key.Update(secondLong);

            Assert.IsFalse(aDifferentKey.Equals(key)); // should not be equal.
        }

        [Test]
        public void CacheKey_with_same_hashcode_shoul_be_equal()
        {
            CacheKey key1 = new CacheKey();
            CacheKey key2 = new CacheKey();

            key1.Update("HS1CS001");
            key2.Update("HS1D4001");
            /*
         The string hash algorithm is not an industry standard and is not guaranteed to produce the same behaviour between versions. 
         And in fact it does not. The .NET 2.0 CLR uses a different algorithm for string hashing than the .NET 1.1 CLR. 
        */

            Assert.Ignore("The .NET 2.0 CLR uses a different algorithm for string hashing than the .NET 1.1 CLR.");

        }

        [Test]
        public void CacheKey_with_2_params_having_same_hashcode_shoul_not_be_equal()
        {
            CacheKey key1 = new CacheKey();
            CacheKey key2 = new CacheKey();

            key1.Update("HS1CS001");
            key1.Update("HS1D4001");

            key2.Update("HS1D4001");
            key2.Update("HS1CS001");

            Assert.Ignore("The .NET 2.0 CLR uses a different algorithm for string hashing than the .NET 1.1 CLR.");
        }
    }
}
