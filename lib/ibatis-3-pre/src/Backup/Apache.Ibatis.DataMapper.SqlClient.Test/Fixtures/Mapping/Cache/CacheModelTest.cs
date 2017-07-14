using System;
using Apache.Ibatis.Common.Utilities;
using Apache.Ibatis.DataMapper.Model.Cache;
using Apache.Ibatis.DataMapper.Model.Cache.Implementation;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;
using NUnit.Framework;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping.Cache
{
    /// <summary>
    /// Summary description for CacheKeyTest.
    /// </summary>
    [TestFixture]
    public class CacheModelTest
    {
        [Test]
        /// <summary>
        /// Returns reference to same instance of cached object
        /// </summary>
        public void TestReturnInstanceOfCachedOject()
        {
            CacheModel cacheModel = new CacheModel("test", typeof(LruCache).FullName, 60, 1, false);

            //cacheModel.FlushInterval = interval;
            //cacheModel.IsReadOnly = true;
            //cacheModel.IsSerializable = false;

            Order order = new Order(); 
            order.CardNumber = "CardNumber";
            order.Date = DateTime.Now;
            order.LineItemsCollection = new LineItemCollection();
            LineItem item = new LineItem();
            item.Code = "Code1";
            order.LineItemsCollection.Add(item);
            item = new LineItem();
            item.Code = "Code2";
            order.LineItemsCollection.Add(item);

            CacheKey key = new CacheKey();
            key.Update(order);

            int firstId = HashCodeProvider.GetIdentityHashCode(order);
            cacheModel[ key ] = order;

            Order order2 = cacheModel[ key ] as Order;
            int secondId = HashCodeProvider.GetIdentityHashCode(order2);
            Assert.AreEqual(firstId, secondId, "hasCode different");
        }

        [Test]
        /// <summary>
        /// Returns copy of cached object
        /// </summary>
        public void TestReturnCopyOfCachedOject()
        {
            CacheModel cacheModel = new CacheModel("test", typeof(LruCache).FullName, 60, 1, true);

            Order order = new Order(); 
            order.CardNumber = "CardNumber";
            order.Date = DateTime.Now;
            order.LineItemsCollection = new LineItemCollection();

            LineItem item = new LineItem();
            item.Code = "Code1";
            order.LineItemsCollection.Add(item);

            item = new LineItem();
            item.Code = "Code2";
            order.LineItemsCollection.Add(item);

            CacheKey key = new CacheKey();
            key.Update(order);

            int firstId = HashCodeProvider.GetIdentityHashCode(order);
            cacheModel[ key ] = order;

            Order order2 = cacheModel[ key ] as Order;
            int secondId = HashCodeProvider.GetIdentityHashCode(order2);
            Assert.AreNotEqual(firstId, secondId, "hasCode equal");

        }
    }
}