using System;
using Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures;
using NUnit.Framework;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping.MSSQL.Generics
{
    /// <summary>
    /// Summary description for StatementTest.
    /// </summary>
    [TestFixture] 
    [Category("MSSQL")]
    public class StatementTest : BaseTest
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
            InitScript(sessionFactory.DataSource, scriptDirectory + "ps_SelectAccount.sql", false);

            InitScript(sessionFactory.DataSource, scriptDirectory + "category-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "order-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "line-item-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "ps_SelectLineItem.sql", false);
        }

        /// <summary>
        /// TearDown
        /// </summary>
        [TearDown] 
        public void Dispose()
        { /* ... */ } 

        #endregion

        #region Specific statement test for sql server

        /// <summary>
        /// Test Insert Account via store procedure
        /// </summary>
        [Test]
        public void GenericTestInsertAccountViaStoreProcedure() 
        {
            Account account = new Account();

            account.Id = 99;
            account.FirstName = "Achille";
            account.LastName = "Talon";
            account.EmailAddress = "Achille.Talon@somewhere.com";

            dataMapper.Insert("InsertAccountViaStoreProcedure", account);

            Account testAccount = dataMapper.QueryForObject<Account>("GetAccountViaColumnName", 99);

            Assert.IsNotNull(testAccount);
            Assert.AreEqual(99, testAccount.Id);
        }

        /// <summary>
        /// Test statement with properties subtitutions
        /// (Test for IBATISNET-21 : Property substitutions do not occur inside selectKey statement)
        /// </summary>
        [Test] 
        public void GenericTestInsertCategoryWithProperties()
        {
            Category category = new Category();
            category.Guid = Guid.NewGuid();

            int key = (int)dataMapper.Insert("InsertCategoryWithProperties", category);

            Category categoryTest = dataMapper.QueryForObject<Category>("GetCategory", key);
            Assert.AreEqual(key, categoryTest.Id);
            Assert.AreEqual("Film", categoryTest.Name);
            Assert.AreEqual(category.Guid, categoryTest.Guid);
        }

        /// <summary>
        /// Test guid column/field.
        /// </summary>
        [Test]
        public void GenericTestGuidColumn()
        {
            Category category = new Category();
            category.Name = "toto";
            category.Guid = Guid.NewGuid();

            int key = (int)dataMapper.Insert("InsertCategory", category);

            Category categoryTest = dataMapper.QueryForObject<Category>("GetCategory", key);
            Assert.AreEqual(key, categoryTest.Id);
            Assert.AreEqual(category.Name, categoryTest.Name);
            Assert.AreEqual(category.Guid, categoryTest.Guid);
        }

        /// <summary>
        /// Test guid column/field through parameterClass.
        /// </summary>
        [Test]
        public void GenericTestGuidColumnParameterClass()
        {
            Guid newGuid = Guid.NewGuid();
            int key = (int)dataMapper.Insert("InsertCategoryGuidParameterClass", newGuid);

            Category categoryTest = dataMapper.QueryForObject<Category>("GetCategory", key);
            Assert.AreEqual(key, categoryTest.Id);
            Assert.AreEqual("toto", categoryTest.Name);
            Assert.AreEqual(newGuid, categoryTest.Guid);
        }

        /// <summary>
        /// Test guid column/field through parameterClass without specifiyng dbType
        /// </summary>
        [Test]
        public void GenericTestGuidColumnParameterClassJIRA20() 
        {
            Guid newGuid = Guid.NewGuid();
            int key = (int)dataMapper.Insert("InsertCategoryGuidParameterClassJIRA20", newGuid);

            Category categoryTest = dataMapper.QueryForObject<Category>("GetCategory", key);
            Assert.AreEqual(key, categoryTest.Id);
            Assert.AreEqual("toto", categoryTest.Name);
            Assert.AreEqual(newGuid, categoryTest.Guid);
        }

        /// <summary>
        /// Test Update Category with Extended ParameterMap
        /// </summary>
        [Test]
        public void GenericTestUpdateCategoryWithExtendParameterMap()
        {
            Category category = new Category();
            category.Name = "Cat";
            category.Guid = Guid.NewGuid();

            int key = (int)dataMapper.Insert("InsertCategoryViaParameterMap", category);
            category.Id = key;

            category.Name = "Dog";
            category.Guid = Guid.NewGuid();

            dataMapper.Update("UpdateCategoryViaParameterMap", category);

            Category categoryRead = null;
            categoryRead = dataMapper.QueryForObject<Category>("GetCategory", key);

            Assert.AreEqual(category.Id, categoryRead.Id);
            Assert.AreEqual(category.Name, categoryRead.Name);
            Assert.AreEqual(category.Guid.ToString(), categoryRead.Guid.ToString());
        }

        /// <summary>
        /// Test select via store procedure
        /// </summary>
        [Test]
        public void GenericTestSelect()
        {
            Order order = dataMapper.QueryForObject<Order>("GetOrderWithAccountViaSP", 1);
            AssertOrder1(order);
            AssertAccount1(order.Account);
        }

        /// <summary>
        /// Test generic Collection via store procedure
        /// </summary>
        [Test]
        public void TestGenericCollectionMappingViaSP()
        {
            Order order = dataMapper.QueryForObject<Order>("GetOrderWithGenericViaSP", 1);

            AssertOrder1(order);

            // Check generic collection
            Assert.IsNotNull(order.LineItemsCollection);
            Assert.AreEqual(3, order.LineItemsCollection.Count);
        }
        #endregion


    }
}