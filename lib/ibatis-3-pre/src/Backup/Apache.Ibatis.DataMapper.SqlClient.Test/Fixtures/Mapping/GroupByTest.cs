
using System.Collections;
using System.Collections.Generic;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;
using Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures;
using NUnit.Framework;

using Category=Apache.Ibatis.DataMapper.SqlClient.Test.Domain.Petshop.Category;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping
{
    /// <summary>
    /// Summary description for GroupByTest.
    /// </summary>
    [TestFixture]
    public class GroupByTest : BaseTest
    {
        #region SetUp & TearDown

        /// <summary>
        /// SetUp
        /// </summary>
        [TestFixtureSetUp]
        protected override void SetUpFixture()
        {
            base.SetUpFixture();

            InitScript(sessionFactory.DataSource, scriptDirectory + "petstore-drop.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "petstore-schema.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "petstore-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "child-parent-init.sql");
        }


        /// <summary>
        /// Dispose the SqlMap
        /// </summary>
        [TestFixtureTearDown]
        protected override void TearDownFixture()
        {
            InitScript(sessionFactory.DataSource, scriptDirectory + "petstore-drop.sql");
            base.TearDownFixture();
        }
        #endregion

        [Test]
        public void Can_groupBy_primitive_type()
        {
            IList<Category> list = dataMapper.QueryForList<Category>("GetCategories-SimpleResult", null);
            Assert.AreEqual(6, list.Count);
        }

        [Test]
        [Category("JIRA")]
        [Description("JIRA253")]
        public void Timestamp_Data_Type_should_be_load()
        {
            IList<Parent> parents = dataMapper.QueryForList<Parent>("GetAllParentsNPlus1", null);

            Assert.That(parents[0].Children.Count, Is.EqualTo(2));
            Assert.That(parents[1].Children.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestBobHanson ()
        {
            InitScript(sessionFactory.DataSource, scriptDirectory + "groupby-schema.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "groupby-init.sql");

            IList<Application> list = dataMapper.QueryForList<Application>("GroupByBobHanson", null);
            Assert.AreEqual(1, list.Count);
            Application application = list[0];

            Assert.AreEqual("Admin", application.DefaultRole.Name);
            Assert.AreEqual(2, application.Users.Count);
            Assert.AreEqual("user1", application.Users[0].UserName);
            Assert.IsNull(application.Users[0].Address);
            
            Assert.AreEqual(1, application.Users[0].Roles.Count);
            Assert.AreEqual("User", application.Users[0].Roles[0].Name);

            Assert.AreEqual(2, application.Users[1].Roles.Count);
            Assert.AreEqual("User", application.Users[1].Roles[1].Name);
            Assert.AreEqual("Admin", application.Users[1].Roles[0].Name);

        }


        [Test]
        public void TestGroupByWithNullSon() 
        {
            IList list = dataMapper.QueryForList("GetCategories", null);
            Assert.AreEqual(6, list.Count);
        }

        [Test]
        public void TestGroupBy()
        {
            IList list = dataMapper.QueryForList("GetAllCategories", null);
            Assert.AreEqual(5, list.Count);
        }
        
        [Test]
        public void TestGroupByExtended()  
        {
            IList list = dataMapper.QueryForList("GetAllCategoriesExtended", null);
            Assert.AreEqual(5, list.Count);
        }

        [Test]
        public void TestNestedProperties()
        {
            IList list = dataMapper.QueryForList("GetFish", null);
            Assert.AreEqual(1, list.Count);

            Domain.Petshop.Category cat = (Domain.Petshop.Category)list[0];
            Assert.AreEqual("FISH", cat.Id);
            Assert.AreEqual("Fish", cat.Name);
            Assert.IsNotNull(cat.Products, "Expected product list.");
            Assert.AreEqual(4, cat.Products.Count);

            Domain.Petshop.Product product = (Domain.Petshop.Product)cat.Products[0];
            Assert.AreEqual(2, product.Items.Count);
        }

        [Test]
        public void TestForQueryForObject()
        {
            Domain.Petshop.Category cat = (Domain.Petshop.Category)dataMapper.QueryForObject("GetFish", null);
            Assert.IsNotNull(cat);

            Assert.AreEqual("FISH", cat.Id);
            Assert.AreEqual("Fish", cat.Name);
            Assert.IsNotNull(cat.Products, "Expected product list.");
            Assert.AreEqual(4, cat.Products.Count);

            Domain.Petshop.Product product = (Domain.Petshop.Product)cat.Products[0];
            Assert.AreEqual(2, product.Items.Count);
        }

        [Test]
        public void TestGenericFish()
        {
            IList list = dataMapper.QueryForList("GetFishGeneric", null);
            Assert.AreEqual(1, list.Count);

            Domain.Petshop.Category cat = (Domain.Petshop.Category)list[0];
            Assert.AreEqual("FISH", cat.Id);
            Assert.AreEqual("Fish", cat.Name);
            Assert.IsNotNull(cat.GenericProducts, "Expected product list.");
            Assert.AreEqual(4, cat.GenericProducts.Count);

            Domain.Petshop.Product product = cat.GenericProducts[0];
            Assert.AreEqual(2, product.GenericItems.Count);
        }

        [Test]
        public void TestForQueryForObjectGeneric()
        {
            Domain.Petshop.Category cat = dataMapper.QueryForObject<Domain.Petshop.Category>("GetFishGeneric", null);
            Assert.IsNotNull(cat);

            Assert.AreEqual("FISH", cat.Id);
            Assert.AreEqual("Fish", cat.Name);
            Assert.IsNotNull(cat.GenericProducts, "Expected product list.");
            Assert.AreEqual(4, cat.GenericProducts.Count);

            Domain.Petshop.Product product = cat.GenericProducts[0];
            Assert.AreEqual(2, product.GenericItems.Count);
        }

        [Test]
        public void TestJira241()
        {
            Category myCategory = new Category();

            dataMapper.QueryForObject<Category>("GetFishGeneric", null, myCategory);
            Assert.IsNotNull(myCategory);

            Assert.AreEqual("FISH", myCategory.Id);
            Assert.AreEqual("Fish", myCategory.Name);
            Assert.IsNotNull(myCategory.GenericProducts, "Expected product list.");
            Assert.AreEqual(4, myCategory.GenericProducts.Count);

            Domain.Petshop.Product product = myCategory.GenericProducts[0];
            Assert.AreEqual(2, product.GenericItems.Count);
        }

        [Test]
        public void TestGenericList()
        {
            IList<Domain.Petshop.Category> list = dataMapper.QueryForList<Domain.Petshop.Category>("GetFishGeneric", null);
            Assert.AreEqual(1, list.Count);

            Domain.Petshop.Category cat = list[0];
            Assert.AreEqual("FISH", cat.Id);
            Assert.AreEqual("Fish", cat.Name);
            Assert.IsNotNull(cat.GenericProducts, "Expected product list.");
            Assert.AreEqual(4, cat.GenericProducts.Count);

            Domain.Petshop.Product product = cat.GenericProducts[0];
            Assert.AreEqual(2, product.GenericItems.Count);
        }
        
        [Test]
        public void TestGroupByNull()
        {
            IList list = dataMapper.QueryForList("GetAllProductCategoriesJIRA250", null);
            Domain.Petshop.Category cat = (Domain.Petshop.Category)list[0];
            Assert.AreEqual(0, cat.Products.Count);
        }
        
        /// <summary>
        /// Test Select N+1 on Order/LineItem
        /// </summary>
        [Test]
        public void TestOrderLineItemGroupBy()
        {
            InitScript(sessionFactory.DataSource, scriptDirectory + "petstore-drop.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "account-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "order-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "line-item-init.sql");

            Order order = new Order();
            order.Id = 11;
            LineItem item = new LineItem();
            item.Id = 10;
            item.Code = "blah";
            item.Price = 44.00m;
            item.Quantity = 1;
            item.Order = order;

            dataMapper.Insert("InsertLineItemPostKey", item);

            
            IList list = dataMapper.QueryForList("GetOrderLineItem", null);

            Assert.AreEqual(11, list.Count);
            
            order = (Order)list[0];
            Assert.AreEqual(3, order.LineItemsIList.Count);
            Assert.IsNotNull(order.Account);
            AssertAccount1(order.Account);

            order = (Order)list[10];
            Assert.AreEqual(1, order.LineItemsIList.Count);
            Assert.IsNull(order.Account);
        }

        /// <summary>
        /// Test GroupBy With use of Inheritance
        /// </summary>
        [Test]
        public void GroupByWithInheritance()
        {
            InitScript(sessionFactory.DataSource, scriptDirectory + "petstore-drop.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "account-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "documents-init.sql");

            IList<Account> list = dataMapper.QueryForList<Account>("JIRA206", null);
            
            Assert.AreEqual(5, list.Count);
            Assert.AreEqual(0, list[0].Documents.Count);
            Assert.AreEqual(2, list[1].Documents.Count);
            Assert.AreEqual(1, list[2].Documents.Count);
            Assert.AreEqual(0, list[3].Documents.Count);
            Assert.AreEqual(2, list[4].Documents.Count);

            InitScript(sessionFactory.DataSource, scriptDirectory + "petstore-drop.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "petstore-schema.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "petstore-init.sql");
        }
    }
}