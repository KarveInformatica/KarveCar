using System.Collections.Generic;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;
using NUnit.Framework;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping.Generics
{
    /// <summary>
    /// Tests generic list
    /// 
    /// Interface tests
    /// 1) IList&lgt;LineItem&glt (Order.LineItemsGenericList) <--- QueryForList&lgt;LineItem&glt
    /// 2) IList&lgt;LineItem&glt (Order.LineItemsGenericList) <--- QueryForList&lgt;LineItem&glt Lazy load
    /// 3) IList&lgt;LineItem&glt (Order.LineItemsGenericList) <--- QueryForList&lgt;LineItem&glt with listClass = LineItemCollection2
    /// 4) IList&lgt;LineItem&glt (Order.LineItemsGenericList) <--- QueryForList&lgt;LineItem&glt with listClass = LineItemCollection2 lazy

    /// Strongly typed collection tests
    /// 5) LineItemCollection2 (Order.LineItemCollection2) <--- QueryForList&lgt;LineItem&glt with listClass = LineItemCollection2
    /// 6) LineItemCollection2 (Order.LineItemCollection2) <--- QueryForList&lgt;LineItem&glt  with listClass = LineItemCollection2 Lazy load
    /// </summary>
    [TestFixture] 
    public class ResultMapTest : BaseTest
    {
        #region SetUp & TearDown

        /// <summary>
        /// SetUp
        /// </summary>
        [SetUp]
        public void Init()
        {
            InitScript(sessionFactory.DataSource, scriptDirectory + "account-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "order-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "line-item-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "enumeration-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "coupons-init.sql");

        }

        /// <summary>
        /// TearDown
        /// </summary>
        [TearDown]
        public void Dispose()
        { /* ... */ }

        #endregion

        #region Result Map test

        /// <summary>
        /// Coupons
        /// </summary>
        [Test]
        public void TestJIRA243WithGoupBy()
        {
            IList<Coupon> coupons = dataMapper.QueryForList<Coupon>("GetCouponBrand", null);

            Assert.That(coupons.Count, Is.EqualTo(5));
            Assert.That(coupons[0].BrandIds[0], Is.EqualTo(1));
            Assert.That(coupons[0].BrandIds[1], Is.EqualTo(2));
            Assert.That(coupons[0].BrandIds[2], Is.EqualTo(3));
            Assert.That(coupons[1].BrandIds[0], Is.EqualTo(4));
            Assert.That(coupons[1].BrandIds[1], Is.EqualTo(5));
            Assert.That(coupons[2].BrandIds.Count, Is.EqualTo(0));
            Assert.That(coupons[3].BrandIds.Count, Is.EqualTo(0));
            Assert.That(coupons[4].BrandIds[0], Is.EqualTo(6));
        }

        /// <summary>
        /// Coupons
        /// </summary>
        [Test]
        public void Test243WithoutGoupBy()
        {
            IList<Coupon> coupons = dataMapper.QueryForList<Coupon>("GetCoupons", null);

            Assert.That(coupons.Count, Is.EqualTo(5));
            Assert.That(coupons[0].BrandIds[0], Is.EqualTo(1));
            Assert.That(coupons[0].BrandIds[1], Is.EqualTo(2));
            Assert.That(coupons[0].BrandIds[2], Is.EqualTo(3));
            Assert.That(coupons[1].BrandIds[0], Is.EqualTo(4));
            Assert.That(coupons[1].BrandIds[1], Is.EqualTo(5));
            Assert.That(coupons[2].BrandIds.Count, Is.EqualTo(0));
            Assert.That(coupons[3].BrandIds.Count, Is.EqualTo(0));
            Assert.That(coupons[4].BrandIds[0], Is.EqualTo(6));
        }

        /// <summary>
        /// Test generic Ilist  : 
        /// 1) IList&lgt;LineItem&glt (Order.LineItemsGenericList) <--- QueryForList&lgt;LineItem&glt
        /// </summary>
        [Test]
        public void TestGenericList()
        {
            Order order = dataMapper.QueryForObject<Order>("GetOrderWithGenericListLineItem", 1);

            AssertOrder1(order);

            // Check generic IList collection
            Assert.IsNotNull(order.LineItemsGenericList);
            Assert.AreEqual(3, order.LineItemsGenericList.Count);
        }

        /// <summary>
        /// Test generic Ilist with lazy loading : 
        /// 2) IList&lgt;LineItem&glt (Order.LineItemsGenericList) <--- QueryForList&lgt;LineItem&glt Lazy load
        /// </summary>
        [Test]
        public void TestGenericListLazyLoad()
        {
            Order order = dataMapper.QueryForObject<Order>("GetOrderWithGenericLazyLoad", 1);

            AssertOrder1(order);

            // Check generic IList collection
            Assert.IsNotNull(order.LineItemsGenericList);
            Assert.IsNotNull(order.GenericListAccount);
            order.LineItemsGenericList.Add(new LineItem());
            Assert.AreEqual(4, order.LineItemsGenericList.Count);
            Assert.AreEqual(5, order.GenericListAccount.Count);

        }

        /// <summary>
        /// Test generic typed generic Collection on generic IList  
        /// 3) IList&lgt;LineItem&glt (Order.LineItemsGenericList) <--- QueryForList&lgt;LineItem&glt with listClass = LineItemCollection2
        /// </summary>
        [Test]
        public void TestGenericCollectionOnIList()
        {
            Order order = dataMapper.QueryForObject<Order>("GetOrderWithGenericLineItemCollection", 1);

            AssertOrder1(order);

            // Check generic collection
            Assert.IsNotNull(order.LineItemsGenericList);
            Assert.AreEqual(3, order.LineItemsGenericList.Count);
            LineItemCollection2 lines = (LineItemCollection2)order.LineItemsGenericList;
        }

        //order-and-generic-list-lineitem GetLineItemsForOrderWithGenericList
        [Test]
        public void TestTypedGenericList()
        {
            Order order = dataMapper.QueryForObject<Order>("GetOrderGenericListLineItem", 1);

            AssertOrder1(order);

            // Check generic collection
            Assert.IsNotNull(order.GenericListLineItem);
            Assert.AreEqual(3, order.GenericListLineItem.Count);
            ListeEntiteMetier<LineItem> list = new ListeEntiteMetier<LineItem>();
            Assert.That(order.GenericListLineItem, Is.TypeOf(list.GetType()));
        }


        [Test]
        public void TestLazyTypedGenericCollection()
        {
            Order order = dataMapper.QueryForObject<Order>("GetOrderGenericLineItemsLazy", 1);

            AssertOrder1(order);

            Assert.IsNotNull(order.GenericListLineItem);
            Assert.AreEqual(3, order.GenericListLineItem.Count);
            ListeEntiteMetier<LineItem> list = order.GenericListLineItem;
            Assert.That(order.GenericListLineItem, Is.TypeOf(list.GetType()));

        }

        /// <summary>
        /// Test generic IList with lazy typed collection 
        /// 4) IList&lgt;LineItem&glt (Order.LineItemsGenericList) <--- QueryForList&lgt;LineItem&glt with listClass = LineItemCollection2 lazy
        /// </summary>
        [Test]
        public void TestLazyListGenericMapping()
        {
            Order order = (Order)dataMapper.QueryForObject("GetOrderWithGenericLineItemsLazy", 1);

            AssertOrder1(order);

            Assert.IsNotNull(order.LineItemsGenericList);
            Assert.AreEqual(3, order.LineItemsGenericList.Count);
            LineItemCollection2 lines = (LineItemCollection2)order.LineItemsGenericList;
        }

        /// <summary>
        /// Test generic typed generic Collection on generic typed generic Collection
        /// 5) LineItemCollection2 (Order.LineItemCollection2) <--- QueryForList&lgt;LineItem&glt with listClass = LineItemCollection2
        /// </summary>
        [Test]
        public void TestTypedCollectionOnTypedCollection()
        {
            Order order = (Order)dataMapper.QueryForObject("GetOrderWithGenericTypedLineItemCollection", 1);

            AssertOrder1(order);

            Assert.IsNotNull(order.LineItemsCollection2);
            Assert.AreEqual(3, order.LineItemsCollection2.Count);

            IEnumerator<LineItem> e = ((IEnumerable<LineItem>)order.LineItemsCollection2).GetEnumerator();
            while (e.MoveNext())
            {
                LineItem item = e.Current;
                Assert.IsNotNull(item);
            }
        }

        /// <summary>
        /// Test generic typed generic Collection lazy
        /// 6) LineItemCollection2 (Order.LineItemCollection2) <--- QueryForList&lgt;LineItem&glt  with listClass = LineItemCollection2 Lazy load
        /// </summary>
        [Test]
        public void TestTypedCollectionLazy()
        {
            Order order = (Order)dataMapper.QueryForObject("GetOrderWithGenericTypedLineItemCollectionLazy", 1);

            AssertOrder1(order);

            Assert.IsNotNull(order.LineItemsCollection2);
            Assert.AreEqual(3, order.LineItemsCollection2.Count);

            IEnumerator<LineItem> e = ((IEnumerable<LineItem>)order.LineItemsCollection2).GetEnumerator();
            while (e.MoveNext())
            {
                LineItem item = e.Current;
                Assert.IsNotNull(item);
            }
        }

        #endregion
    }
}