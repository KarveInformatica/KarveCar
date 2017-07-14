using System;
using NUnit.Framework;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping.MSSQL
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
        public void TestInsertAccountViaStoreProcedure() 
        {
            Account account = new Account();

            account.Id = 99;
            account.FirstName = "Achille";
            account.LastName = "Talon";
            account.EmailAddress = "Achille.Talon@somewhere.com";

            dataMapper.Insert("InsertAccountViaStoreProcedure", account);

            Account testAccount = dataMapper.QueryForObject("GetAccountViaColumnName", 99) as Account;

            Assert.IsNotNull(testAccount);
            Assert.AreEqual(99, testAccount.Id);
        }

        /// <summary>
        /// Test an insert with identity key.
        /// </summary>
        [Test] 
        public void TestInsertIdentityViaInsertQuery()
        {
            Category category = new Category();
            category.Name = "toto";
            category.Guid = Guid.NewGuid();

            int key = (int)dataMapper.Insert("InsertCategory", category);
            Assert.AreEqual(1, key);
        }

        /// <summary>
        /// Test an insert using SCOPE_IDENTITY.
        /// </summary>
        [Test]
        public void TestInsertCategoryScope()
        {
            Category category = new Category();
            category.Name = "toto";
            category.Guid = Guid.NewGuid();

            dataMapper.QueryForObject("InsertCategoryScope", category, category);
            Assert.That(category.Id, Is.EqualTo(1));
        }

        /// <summary>
        /// Test Insert Via Insert Statement.
        /// (Test for IBATISNET-21 : Property substitutions do not occur inside selectKey statement)
        /// </summary>
        [Test] 
        public void TestInsertViaInsertStatement()
        {
            Category category = new Category();
            category.Name = "toto";
            category.Guid = Guid.NewGuid();

            int key = (int)dataMapper.Insert("InsertCategoryViaInsertStatement", category);
            Assert.AreEqual(1, key);
        }

        /// <summary>
        /// Test statement with properties subtitutions
        /// (Test for IBATISNET-21 : Property substitutions do not occur inside selectKey statement)
        /// </summary>
        [Test] 
        public void TestInsertCategoryWithProperties()
        {
            Category category = new Category();
            category.Guid = Guid.NewGuid();

            int key = (int)dataMapper.Insert("InsertCategoryWithProperties", category);

            Category categoryTest = dataMapper.QueryForObject("GetCategory", key) as Category;
            Assert.AreEqual(key, categoryTest.Id);
            Assert.AreEqual("Film", categoryTest.Name);
            Assert.AreEqual(category.Guid, categoryTest.Guid);
        }

        /// <summary>
        /// Test guid column/field.
        /// </summary>
        [Test] 
        public void TestGuidColumn()
        {
            Category category = new Category();
            category.Name = "toto";
            category.Guid = Guid.NewGuid();

            int key = (int)dataMapper.Insert("InsertCategory", category);

            Category categoryTest = (Category)dataMapper.QueryForObject("GetCategory", key);
            Assert.AreEqual(key, categoryTest.Id);
            Assert.AreEqual(category.Name, categoryTest.Name);
            Assert.AreEqual(category.Guid, categoryTest.Guid);
        }

        /// <summary>
        /// Test guid column/field through parameterClass.
        /// </summary>
        [Test] 
        public void TestGuidColumnParameterClass() {
            Guid newGuid = Guid.NewGuid();
            int key = (int)dataMapper.Insert("InsertCategoryGuidParameterClass", newGuid);

            Category categoryTest = (Category)dataMapper.QueryForObject("GetCategory", key);
            Assert.AreEqual(key, categoryTest.Id);
            Assert.AreEqual("toto", categoryTest.Name);
            Assert.AreEqual(newGuid, categoryTest.Guid);
        }

        /// <summary>
        /// Test guid column/field through parameterClass without specifiyng dbType
        /// </summary>
        [Test] 
        public void TestGuidColumnParameterClassJIRA20() 
        {
            Guid newGuid = Guid.NewGuid();
            int key = (int)dataMapper.Insert("InsertCategoryGuidParameterClassJIRA20", newGuid);

            Category categoryTest = (Category)dataMapper.QueryForObject("GetCategory", key);
            Assert.AreEqual(key, categoryTest.Id);
            Assert.AreEqual("toto", categoryTest.Name);
            Assert.AreEqual(newGuid, categoryTest.Guid);
        }

        /// <summary>
        /// Test Insert Category Via ParameterMap.
        /// </summary>
        [Test] 
        public void TestInsertCategoryViaParameterMap()
        {
            Category category = new Category();
            category.Name = "Cat";
            category.Guid = Guid.NewGuid();

            int key = (int)dataMapper.Insert("InsertCategoryViaParameterMap", category);
            Assert.AreEqual(1, key);
        }

        /// <summary>
        /// Test Update Category with Extended ParameterMap
        /// </summary>
        [Test] 
        public void TestUpdateCategoryWithExtendParameterMap()
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
            categoryRead = (Category) dataMapper.QueryForObject("GetCategory", key);

            Assert.AreEqual(category.Id, categoryRead.Id);
            Assert.AreEqual(category.Name, categoryRead.Name);
            Assert.AreEqual(category.Guid.ToString(), categoryRead.Guid.ToString());
        }

        /// <summary>
        /// Test select via store procedure
        /// </summary>
        [Test] 
        public void TestSelect()
        {
            Order order = (Order) dataMapper.QueryForObject("GetOrderWithAccountViaSP", 1);
            AssertOrder1(order);
            AssertAccount1(order.Account);
        }
        #endregion


    }
}