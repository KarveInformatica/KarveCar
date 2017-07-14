
using System;
using System.Collections;
using System.Collections.Generic;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;
using Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures;
using NUnit.Framework;


namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping
{
    /// <summary>
    /// Summary description for ParameterMapTest.
    /// </summary>
    [TestFixture]
    public class MultipleResultTest : BaseTest
    {
        #region SetUp & TearDown

        /// <summary>
        /// SetUp
        /// </summary>
        [SetUp]
        public void Init()
        {
            InitScript(sessionFactory.DataSource, scriptDirectory + "account-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "category-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "documents-init.sql");
        }

        /// <summary>
        /// TearDown
        /// </summary>
        [TearDown]
        public void Dispose()
        { /* ... */
        }

        #endregion


        /// <summary>
        /// Test Multiple ResultMaps
        /// </summary>
        [Test]
        public void TestMultipleResultMapsWithInList()
        {
            IList accounts = new ArrayList();
            dataMapper.QueryForList("GetMultipleResultMapAccount", null, accounts);
            Assert.AreEqual(2, accounts.Count);
        }

        /// <summary>
        /// Test Multiple ResultMaps
        /// </summary>
        [Test]
        public void TestMultipleAccountResultMap()
        {
            Assert.AreEqual(2, dataMapper.QueryForList("GetMultipleResultMapAccount", null).Count);
        }

        /// <summary>
        /// Test Multiple ResultMaps
        /// </summary>
        [Test]
        public void TestMultipleResultClassWithInList()
        {
            IList accounts = new ArrayList();
            dataMapper.QueryForList("GetMultipleResultClassAccount", null, accounts);
            Assert.AreEqual(2, accounts.Count);
        }

        /// <summary>
        /// Test Multiple Result class
        /// </summary>
        [Test]
        public void TestMultipleAccountResultClass()
        {
            IList list = dataMapper.QueryForList("GetMultipleResultClassAccount", null);
            Assert.AreEqual(2, list.Count);

            Assert.That(list[0], Is.InstanceOfType(typeof(List<Account>)));
            Assert.That(list[1], Is.InstanceOfType(typeof(List<Account>)));
        }

        /// <summary>
        /// Test Multiple ResultMaps
        /// </summary>
        [Test]
        public void TestMultipleResultMap()
        {
            Category category = new Category();
            category.Name = "toto";
            category.Guid = Guid.NewGuid();

            int key = (int)dataMapper.Insert("InsertCategory", category);
            IList list = dataMapper.QueryForList("GetMultipleResultMap", null);
            
            Assert.AreEqual(2, list.Count);
            
            List<Account> accounts = (List<Account>)list[0];
            List<Category> categorys = (List<Category>)list[1];
            AssertAccount1(accounts[0]);
            Assert.AreEqual(key, categorys[0].Id);
            Assert.AreEqual(category.Name, categorys[0].Name);
            Assert.AreEqual(category.Guid, categorys[0].Guid);
        }

        /// <summary>
        /// Test Multiple Result class
        /// </summary>
        [Test]
        public void TestMultipleResultClass()
        {
            Category category = new Category();
            category.Name = "toto";
            category.Guid = Guid.NewGuid();

            int key = (int)dataMapper.Insert("InsertCategory", category);

            IList list = dataMapper.QueryForList("GetMultipleResultClass", null);
            Assert.AreEqual(2, list.Count);

            Assert.That(list[0], Is.InstanceOfType(typeof(List<Account>)));
            Assert.That(list[1], Is.InstanceOfType(typeof(List<Category>)));

        }
        
        /// <summary>
        /// Test Multiple Document
        /// </summary>
        [Test]
        public void TestMultipleDocument()
        {
            IList<Document> list = dataMapper.QueryForList<Document>("GetMultipleDocument", null);

            Assert.AreEqual(3, list.Count);
        }
    }
}