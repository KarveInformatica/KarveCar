using System.Collections;
using System.Collections.Generic;
using Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures;
using NUnit.Framework;

using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;
using Apache.Ibatis.DataMapper.Session;


namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping
{
    /// <summary>
    /// Summary description for ResultMapTest.
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
            InitScript(sessionFactory.DataSource, scriptDirectory + "account-procedure.sql", false);
            InitScript(sessionFactory.DataSource, scriptDirectory + "order-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "line-item-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "enumeration-init.sql");
        }

        /// <summary>
        /// TearDown
        /// </summary>
        [TearDown]
        public void Dispose()
        { /* ... */ }

        #endregion

        #region Result Map test

        [Test]
        public void ResultMap_with_suffix_should_work()
        {
            List<Order> list = (List<Order>)dataMapper.QueryForList<Order>("GetOrderWithPrefix", null);
            Assert.That(list.Count, Is.EqualTo(11));
        }

        [Test]
        public void ResultMap_with_prefix_should_work()
        {
            List<Order> list = (List<Order>)dataMapper.QueryForList<Order>("GetOrderWithSuffix", null);
            Assert.That(list.Count, Is.EqualTo(11));
        }

        /// <summary>
        /// Test a composite Key Mapping.
        /// It must be: key1,key2,... (old syntax)
        /// </summary>
        [Test]
        [Category("JIRA")]
        [Description("JIRA251")]
        public void Composite_key_mapping_should_work()
        {
            Order order1 = (Order)dataMapper.QueryForObject("GetOrderWithFavouriteLineItem-JIRA-251", 1);
            Order order2 = (Order)dataMapper.QueryForObject("GetOrderWithFavouriteLineItem-JIRA-251", 2);

            Assert.IsNotNull(order1);
            Assert.IsNotNull(order1.FavouriteLineItem);
            Assert.AreEqual(1, order1.FavouriteLineItem.Id);

            Assert.IsNotNull(order2);
            Assert.IsNotNull(order2.FavouriteLineItem);
            Assert.AreEqual(17, order2.FavouriteLineItem.Id);
        }

        /// <summary>
        /// Test a Result Map property with map by column name
        /// </summary>
        [Test]
        public void TestColumnsByName()
        {
            Order order = (Order)dataMapper.QueryForObject("GetOrderLiteByColumnName", 1);
            AssertOrder1(order);
        }

        /// <summary>
        /// Test a Result Map property with map by column index
        /// </summary>
        [Test]
        public void TestColumnsByIndex()
        {
            Order order = (Order)dataMapper.QueryForObject("GetOrderLiteByColumnIndex", 1);
            AssertOrder1(order);
        }


        /// <summary>
        /// Test extends attribute in a Result Map
        /// </summary>
        [Test]
        public void TestExtendedResultMap()
        {
            Order order = (Order)dataMapper.QueryForObject("GetOrderWithLineItems", 1);

            AssertOrder1(order);
            Assert.IsNotNull(order.LineItemsIList);
            Assert.AreEqual(3, order.LineItemsIList.Count);
        }

        /// <summary>
        /// Test lazyLoad attribute in a Result Map property
        /// </summary>
        [Test]
        public void TestLazyLoad()
        {
            Order order = (Order)dataMapper.QueryForObject("GetOrderWithLineItems", 1);

            AssertOrder1(order);

            Assert.IsNotNull(order.LineItemsIList);
            Assert.IsTrue(typeof(IList).IsAssignableFrom(order.LineItemsIList.GetType()));

            Assert.AreEqual(3, order.LineItemsIList.Count);
            // After a call to a method from a proxy object,
            // the proxy object is replaced by his real object.
            Assert.IsTrue(order.LineItemsIList is ArrayList);
        }

        /// <summary>
        /// Test lazyLoad attribute With an Open Connection
        /// </summary>
        [Test]
        public void LazyLoad_with_OpenSession_should_work()
        {
            ISession session = sessionFactory.OpenSession();

            Order order = (Order)dataMapper.QueryForObject("GetOrderWithLineItems", 1);

            AssertOrder1(order);

            Assert.IsNotNull(order.LineItemsIList);
            Assert.IsTrue(typeof(IList).IsAssignableFrom(order.LineItemsIList.GetType()));

            Assert.AreEqual(3, order.LineItemsIList.Count);
            // After a call to a method from a proxy object,
            // the proxy object is replaced by his real object.
            Assert.IsTrue(order.LineItemsIList is ArrayList);

            session.Close();
        }

        /// <summary>
        /// Test collection mapping
        /// order.LineItems
        /// </summary>
        [Test]
        public void TestLazyWithStronglyTypedCollectionMapping()
        {
            Order order = (Order)dataMapper.QueryForObject("GetOrderWithLineItemCollection", 1);

            AssertOrder1(order);

            Assert.IsNotNull(order.LineItemsCollection);
            Assert.AreEqual(3, order.LineItemsCollection.Count);

            IEnumerator e = ((IEnumerable)order.LineItemsCollection).GetEnumerator();
            while (e.MoveNext())
            {
                LineItem item = (LineItem)e.Current;
                Assert.IsNotNull(item);
            }
        }

        /// <summary>
        /// Test null value replacement(on string) in a Result property.
        /// </summary>
        [Test]
        public void TestNullValueReplacementOnString()
        {
            Account account = (Account)dataMapper.QueryForObject("GetAccountViaColumnName", 3);
            Assert.AreEqual("no_email@provided.com", account.EmailAddress);
        }

        /// <summary>
        /// Test null value replacement(on enum class) in a Result property.
        /// </summary>
        [Test]
        public void TestNullValueReplacementOnEnum()
        {
            Enumeration enumClass = new Enumeration();
            enumClass.Id = 99;
            enumClass.Day = Days.Thu;
            enumClass.Color = Colors.Blue;
            enumClass.Month = Months.All;

            dataMapper.Insert("InsertEnumViaParameterMap", enumClass);

            enumClass = null;
            enumClass = dataMapper.QueryForObject("GetEnumerationNullValue", 99) as Enumeration;

            Assert.AreEqual(enumClass.Day, Days.Thu);
            Assert.AreEqual(enumClass.Color, Colors.Blue);
            Assert.AreEqual(enumClass.Month, Months.All);
        }

        /// <summary>
        /// Test usage of dbType in a result map property.
        /// 
        /// </summary>
        [Test]
        public void TestTypeSpecified()
        {
            Order order = (Order)dataMapper.QueryForObject("GetOrderWithTypes", 1);
            AssertOrder1(order);
        }


        /// <summary>
        /// Test a Complex Object Mapping. 
        /// Order + Account in Order.Account
        /// </summary>
        [Test]
        public void TestComplexObjectMapping()
        {
            Order order = (Order)dataMapper.QueryForObject("GetOrderWithAccount", 1);
            AssertOrder1(order);
            AssertAccount1(order.Account);
        }


        /// <summary>
        /// Test collection mapping with extends attribute
        /// </summary>
        [Test]
        public void TestCollectionMappingAndExtends()
        {
            Order order = (Order)dataMapper.QueryForObject("GetOrderWithLineItemsCollection", 1);

            AssertOrder1(order);

            // Check strongly typed collection
            Assert.IsNotNull(order.LineItemsCollection);
            Assert.AreEqual(3, order.LineItemsCollection.Count);
        }

        /// <summary>
        /// Test collection mapping: Ilist collection 
        /// order.LineItemsIList 
        /// </summary>
        [Test]
        public void TestListMapping()
        {
            Order order = (Order)dataMapper.QueryForObject("GetOrderWithLineItems", 1);

            AssertOrder1(order);

            // Check IList collection
            Assert.IsNotNull(order.LineItemsIList);
            Assert.AreEqual(3, order.LineItemsIList.Count);
        }

        /// <summary>
        /// Test Array Mapping
        /// </summary>
        [Test]
        public void TestArrayMapping()
        {
            Order order = (Order)dataMapper.QueryForObject("GetOrderWithLineItemArray", 1);

            AssertOrder1(order);
            Assert.IsNotNull(order.LineItemsArray);
            Assert.AreEqual(3, order.LineItemsArray.Length);
        }

        /// <summary>
        /// Test collection mapping
        /// order.LineItems
        /// </summary>
        [Test]
        public void TestStronglyTypedCollectionMapping()
        {
            Order order = (Order)dataMapper.QueryForObject("GetOrderWithLineItemCollection", 1);

            AssertOrder1(order);

            Assert.IsNotNull(order.LineItemsCollection);
            Assert.AreEqual(3, order.LineItemsCollection.Count);

            IEnumerator e = ((IEnumerable)order.LineItemsCollection).GetEnumerator();
            while (e.MoveNext())
            {
                LineItem item = (LineItem)e.Current;
                Assert.IsNotNull(item);
            }
        }

        /// <summary>
        /// Test a ResultMap mapping as an Hastable.
        /// </summary>
        [Test]
        public void TestHashtableMapping()
        {
            Hashtable order = (Hashtable)dataMapper.QueryForObject("GetOrderAsHastable", 1);

            AssertOrder1AsHashtable(order);
        }

        /// <summary>
        /// Test nested object.
        /// Order + FavouriteLineItem in order.FavouriteLineItem
        /// </summary>
        [Test]
        public void TestNestedObjects()
        {
            Order order = (Order)dataMapper.QueryForObject("GetOrderJoinedFavourite", 1);

            AssertOrder1(order);

            Assert.IsNotNull(order.FavouriteLineItem);
            Assert.AreEqual(1, order.FavouriteLineItem.Id, "order.FavouriteLineItem.Id");
            Assert.AreEqual("ESM-34", order.FavouriteLineItem.Code);

        }

        /// <summary>
        /// Test nested object.
        /// Order + FavouriteLineItem in order.FavouriteLineItem
        /// </summary>
        [Test]
        public void TestNestedObjects2()
        {
            Order order = (Order)dataMapper.QueryForObject("GetOrderJoinedFavourite2", 1);

            AssertOrder1(order);

            Assert.IsNotNull(order.FavouriteLineItem);
            Assert.AreEqual(1, order.FavouriteLineItem.Id, "order.FavouriteLineItem.Id");
            Assert.AreEqual("ESM-34", order.FavouriteLineItem.Code);
        }

        /// <summary>
        /// Test Implicit Result Maps
        /// </summary>
        [Test]
        public void TestImplicitResultMaps()
        {
            Order order = (Order)dataMapper.QueryForObject("GetOrderJoinedFavourite3", 1);

            AssertOrder1(order);

            Assert.IsNotNull(order.FavouriteLineItem);
            Assert.AreEqual(1, order.FavouriteLineItem.Id, "order.FavouriteLineItem.Id");
            Assert.AreEqual("ESM-34", order.FavouriteLineItem.Code);

        }

        /// <summary>
        /// Test a composite Key Mapping.
        /// It must be: property1=column1,property2=column2,...
        /// </summary>
        [Test]
        public void TestCompositeKeyMapping()
        {
            Order order1 = (Order)dataMapper.QueryForObject("GetOrderWithFavouriteLineItem", 1);
            Order order2 = (Order)dataMapper.QueryForObject("GetOrderWithFavouriteLineItem", 2);

            Assert.IsNotNull(order1);
            Assert.IsNotNull(order1.FavouriteLineItem);
            Assert.AreEqual(1, order1.FavouriteLineItem.Id);

            Assert.IsNotNull(order2);
            Assert.IsNotNull(order2.FavouriteLineItem);
            Assert.AreEqual(17, order2.FavouriteLineItem.Id);

        }

        /// <summary>
        /// Test Dynamique Composite Key Mapping
        /// </summary>
        [Test]
        public void TestDynamiqueCompositeKeyMapping()
        {

            Order order1 = (Order)dataMapper.QueryForObject("GetOrderWithDynFavouriteLineItem", 1);

            Assert.IsNotNull(order1);
            Assert.IsNotNull(order1.FavouriteLineItem);
            Assert.AreEqual(1, order1.FavouriteLineItem.Id);
        }

        /// <summary>
        /// Test a simple type mapping (string)
        /// </summary>
        [Test]
        public void TestSimpleTypeMapping()
        {
            IList list = dataMapper.QueryForList("GetAllCreditCardNumbersFromOrders", null);

            Assert.AreEqual(5, list.Count);
            Assert.AreEqual("555555555555", list[0]);
        }

        /// <summary>
        /// Test a simple type mapping (decimal)
        /// </summary>
        [Test]
        public void TestDecimalTypeMapping()
        {
            Hashtable param = new Hashtable();
            param.Add("LineItem_ID", 1);
            param.Add("Order_ID", 1);
            decimal price = (decimal)dataMapper.QueryForObject("GetLineItemPrice", param);
            Assert.AreEqual(45.43m, price);
        }

        /// <summary>
        /// Test Byte Array Mapping
        /// </summary>
        /// <remarks>Test for request support 1032436 ByteArrayTypeHandler misses the last byte</remarks>
        [Test]
        public void TestByteArrayMapping()
        {
            Account account = NewAccount6();

            dataMapper.Insert("InsertAccountViaParameterMap", account);

            Order order = new Order();
            order.Id = 99;
            order.CardExpiry = "09/11";
            order.Account = account;
            order.CardNumber = "154564656";
            order.CardType = "Visa";
            order.City = "Lyon";
            order.Date = System.DateTime.MinValue;
            order.PostalCode = "69004";
            order.Province = "Rhone";
            order.Street = "rue Durand";

            dataMapper.Insert("InsertOrderViaParameterMap", order);

            LineItem item = new LineItem();
            item.Id = 99;
            item.Code = "test";
            item.Price = -99.99m;
            item.Quantity = 99;
            item.Order = order;
            item.PictureData = new byte[] { 1, 2, 3 };

            // Check insert
            dataMapper.Insert("InsertLineItemWithPicture", item);

            // select
            LineItem loadItem = null;

            Hashtable param = new Hashtable();
            param.Add("LineItem_ID", 99);
            param.Add("Order_ID", 99);

            loadItem = dataMapper.QueryForObject("GetSpecificLineItemWithPicture", param) as LineItem;

            Assert.IsNotNull(loadItem.Id);
            Assert.IsNotNull(loadItem.PictureData);
            Assert.AreEqual(item.PictureData, loadItem.PictureData);
        }

        /// <summary>
        /// Test null replacement (on decimal) in ResultMap property
        /// </summary>
        [Test]
        public void TestNullValueReplacementOnDecimal()
        {
            Account account = NewAccount6();

            dataMapper.Insert("InsertAccountViaParameterMap", account);

            Order order = new Order();
            order.Id = 99;
            order.CardExpiry = "09/11";
            order.Account = account;
            order.CardNumber = "154564656";
            order.CardType = "Visa";
            order.City = "Lyon";
            order.Date = System.DateTime.MinValue; //<-- null replacement for parameterMAp 
            order.PostalCode = "69004";
            order.Province = "Rhone";
            order.Street = "rue Durand";

            dataMapper.Insert("InsertOrderViaParameterMap", order);

            LineItem item = new LineItem();
            item.Id = 99;
            item.Code = "test";
            item.Price = -99.99m;//<-- null replacement for parameterMAp 
            item.Quantity = 99;
            item.Order = order;

            dataMapper.Insert("InsertLineItem", item);

            // Retrieve LineItem & test null replacement for resultMap 

            LineItem testItem = (LineItem)dataMapper.QueryForObject("GetSpecificLineItemWithNullReplacement", 99);

            Assert.IsNotNull(testItem);
            Assert.AreEqual(-77.77m, testItem.Price);
            Assert.AreEqual("test", testItem.Code);
        }

        /// <summary>
        /// Test null replacement (on DateTime) in ResultMap property.
        /// </summary>
        [Test]
        public void TestNullValueReplacementOnDateTime()
        {
            Account account = NewAccount6();

            dataMapper.Insert("InsertAccountViaParameterMap", account);

            Order order = new Order();
            order.Id = 99;
            order.CardExpiry = "09/11";
            order.Account = account;
            order.CardNumber = "154564656";
            order.CardType = "Visa";
            order.City = "Lyon";
            order.Date = System.DateTime.MinValue; //<-- null replacement
            order.PostalCode = "69004";
            order.Province = "Rhone";
            order.Street = "rue Durand";

            dataMapper.Insert("InsertOrderViaParameterMap", order);

            Order orderTest = (Order)dataMapper.QueryForObject("GetOrderLiteByColumnName", 99);

            Assert.AreEqual(System.DateTime.MinValue, orderTest.Date);
        }
        //#if dotnet2



        //        /// <summary>
        //        /// Test lazy mapping
        //        /// </summary>
        //        [Test]
        //        public void TestLazyWithGenericStronglyTypedCollection()
        //        {
        //            Order order = (Order)sqlMap.QueryForObject("GetOrderWithLineItemCollection2", 1);

        //            AssertOrder1(order);

        //            Assert.IsNotNull(order.LineItemsCollection2);
        //            Assert.AreEqual(2, order.LineItemsCollection2.Count);

        //            IEnumerator<LineItem> e = ((IEnumerable<LineItem>)order.LineItemsCollection2).GetEnumerator();
        //            while (e.MoveNext())
        //            {
        //                LineItem item = e.Current;
        //                Assert.IsNotNull(item);
        //            }
        //        }
        //#endif
        #endregion

    }
}