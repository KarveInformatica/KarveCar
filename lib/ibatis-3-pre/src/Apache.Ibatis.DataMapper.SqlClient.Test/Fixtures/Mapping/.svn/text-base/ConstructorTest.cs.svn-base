using System;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;
using NUnit.Framework;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping
{
    /// <summary>
    /// Summary description for ConstructorTest.
    /// </summary>
    [TestFixture]
    public class ConstructorTest : BaseTest
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
            InitScript(sessionFactory.DataSource, scriptDirectory + "other-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "Nullable-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "category-init.sql");
        }

        /// <summary>
        /// TearDown
        /// </summary>
        [TearDown]
        public void Dispose()
        { /* ... */
        }

        #endregion

        #region Tests

        [Test]
        [Category("JIRA")]
        [Description("JIRA-260")]
        public void Extend_ResultMap_with_Constructor_should_be_used()
        {
            Account account = dataMapper.QueryForObject<Account>("JIRA260", 1);
            AssertAccount1(account);
            Assert.IsTrue(account.BannerOption);
            Assert.IsFalse(account.CartOption);
        }

        /// <summary>
        /// Test account constructor mapping
        /// </summary>
        [Test]
        public void TestPrimitiveArgument()
        {
            Account account = dataMapper.QueryForObject("SelectAccountConstructor", 1) as Account;
            AssertAccount1(account);
        }

        /// <summary>
        /// Test argument nullable constructor mapping
        /// </summary>
        [Test]
        public void TestNullableArgument()
        {
            NullableClass clazz = new NullableClass();
            clazz.TestBool = true;
            clazz.TestByte = 155;
            clazz.TestChar = 'a';
            DateTime? date = new DateTime?(DateTime.Now);
            clazz.TestDateTime = date;
            clazz.TestDecimal = 99.53M;
            clazz.TestDouble = 99.5125;
            Guid? guid = new Guid?(Guid.NewGuid());
            clazz.TestGuid = guid;
            clazz.TestInt16 = 45;
            clazz.TestInt32 = null;
            clazz.TestInt64 = 1234567890123456789;
            clazz.TestSingle = 4578.46445454112f;

            dataMapper.Insert("InsertNullable", clazz);

            clazz = null;
            clazz = dataMapper.QueryForObject<NullableClass>("GetNullableConstructor", 1);

            Assert.IsNotNull(clazz);
            Assert.AreEqual(1, clazz.Id);
            Assert.IsTrue(clazz.TestBool.Value);
            Assert.AreEqual(155, clazz.TestByte);
            Assert.AreEqual('a', clazz.TestChar);
            Assert.AreEqual(date.Value.ToString(), clazz.TestDateTime.Value.ToString());
            Assert.AreEqual(99.53M, clazz.TestDecimal);
            Assert.AreEqual(99.5125, clazz.TestDouble);
            Assert.AreEqual(guid, clazz.TestGuid);
            Assert.AreEqual(45, clazz.TestInt16);
            Assert.IsNull(clazz.TestInt32);
            Assert.AreEqual(1234567890123456789, clazz.TestInt64);
            Assert.AreEqual(4578.46445454112f, clazz.TestSingle);
        }


        /// <summary>
        /// Test constructor injection using a resultMapping where
        /// - the resultmapping object performs *only* constructor injection.
        /// </remarks>
        [Test]
        public void TestJIRA176()
        {
            Category category = new Category();
            category.Name = "toto";
            category.Guid = Guid.Empty;

            int key = (int)dataMapper.Insert("InsertCategory", category);

            ImmutableCategoryPropertyContainer categoryContainerFromDB = (ImmutableCategoryPropertyContainer)dataMapper.QueryForObject("GetImmutableCategoryInContainer", key);
            Assert.IsNotNull(categoryContainerFromDB);
            Assert.IsNotNull(categoryContainerFromDB.ImmutableCategory);
            Assert.AreEqual(category.Name, categoryContainerFromDB.ImmutableCategory.Name);
            Assert.AreEqual(key, categoryContainerFromDB.ImmutableCategory.Id);
            Assert.AreEqual(category.Guid, categoryContainerFromDB.ImmutableCategory.Guid);
        }
	    
        /// <summary>
        /// Test constructor with resultMapping attribute on argument
        /// </remarks>
        [Test]
        public void Use_constructor_with_resultMapping_attribute_on_argument()
        {
            //Console.WriteLine(((IModelStoreAccessor)dataMapper).ModelStore);

            Order order = dataMapper.QueryForObject("GetOrderConstructor1",10) as Order;

            Assert.IsNotNull(order.Account);
            AssertAccount1(order.Account);

            order = dataMapper.QueryForObject("GetOrderConstructor1",11) as Order;

            Assert.IsNull(order.Account);
        }

        /// <summary>
        /// Test constructor with an argument using a resultMapping where
        /// - the resulMap argument use another constructor
        /// - all second constructor arguments are null.
        /// </remarks>
        [Test]
        public void TestJIRA173()
        {
            Order order = dataMapper.QueryForObject("GetOrderConstructor8",11) as Order;

            Assert.IsTrue(order.Id == 11);
            Assert.IsNull(order.Account);
        }

        /// <summary>
        /// Test resultMap with a result property using another resultMap and where
        /// - the result property resultMap use a constructor
        /// - all the constructor arguments are null.
        /// </remarks>
        [Test]
        public void TestJIRA174()
        {
            Order order = dataMapper.QueryForObject("GetOrderConstructor9",11) as Order;

            Assert.IsTrue(order.Id == 11);
            Assert.IsNull(order.Account);
        }

        /// <summary>
        /// Test a constructor argument with select tag.
        /// </remarks>
        [Test]
        public void TestJIRA186()
        {
            Order order = dataMapper.QueryForObject("GetOrderConstructor10", 5) as Order;

            Assert.IsTrue(order.Id == 5);
            Assert.IsNotNull(order.Account);
            Assert.IsNotNull(order.Account.Document);
        }
	    
        /// <summary>
        /// Test constructor with select attribute on argument
        /// </remarks>
        [Test]
        public void TestArgumentSelectObject()
        {
            Order order = (Order) dataMapper.QueryForObject("GetOrderConstructor2", 1);
            AssertOrder1(order);
            AssertAccount1(order.Account);
        }

        /// <summary>
        /// Test constructor with select attribute on IList argument
        /// </remarks>
        [Test]
        public void TestArgumentSelectIList()
        {
            Order order = (Order) dataMapper.QueryForObject("GetOrderConstructor3", 1);
            AssertOrder1(order);
            AssertAccount1(order.Account);
			
            Assert.IsNotNull(order.LineItemsIList);
            Assert.AreEqual(3, order.LineItemsIList.Count);
        }

        /// <summary>
        /// Test constructor with select attribute on array argument
        /// </remarks>
        [Test]
        public void TestArgumentSelectArray()
        {
            Order order = (Order) dataMapper.QueryForObject("GetOrderConstructor4", 1);
            AssertOrder1(order);
            AssertAccount1(order.Account);
			
            Assert.IsNotNull( order.LineItemsArray );
            Assert.AreEqual(3, order.LineItemsArray.Length);
        }

        /// <summary>
        /// Test constructor with select attribute on stronly typed collection argument
        /// </remarks>
        [Test]
        public void TestArgumentSelectCollection()
        {
            Order order = (Order) dataMapper.QueryForObject("GetOrderConstructor5", 1);
            AssertOrder1(order);
            AssertAccount1(order.Account);
			
            Assert.IsNotNull( order.LineItemsCollection );
            Assert.AreEqual(3, order.LineItemsCollection.Count);
        }

        /// <summary>
        /// Test constructor with select attribute on generic list argument
        /// </remarks>
        [Test]
        public void TestArgumentSelectGenericIList()
        {
            Order order = (Order)dataMapper.QueryForObject("GetOrderConstructor6", 1);
            AssertOrder1(order);

            Assert.IsNotNull(order.LineItemsGenericList);
            Assert.AreEqual(3, order.LineItemsGenericList.Count);
        }

        /// <summary>
        /// Test constructor with select attribute on stronly typed generic collection argument
        /// </remarks>
        [Test]
        public void TestArgumentSelectGenericCollection()
        {
            Order order = (Order)dataMapper.QueryForObject("GetOrderConstructor7", 1);
            AssertOrder1(order);

            Assert.IsNotNull(order.LineItemsCollection2);
            Assert.AreEqual(3, order.LineItemsCollection2.Count);
        }

        #endregion
    }
}