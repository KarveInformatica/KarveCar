using System.Collections;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;
using NUnit.Framework;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping
{
    /// <summary>
    /// Summary description for DynamicTest.
    /// </summary>
    [TestFixture]
    public class DynamicTest : BaseTest
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
        }

        /// <summary>
        /// TearDown
        /// </summary>
        [TearDown]
        public void Dispose()
        { /* ... */ }

        #endregion

        #region Dynamic tests

        /// <summary>
        /// Test Dynamic Sql On Column Selection
        /// JIRA IBATISNET-114
        /// </summary>
        [Test]
        public void TestDynamicSqlOnColumnSelection()
        {
            Account paramAccount = new Account();
            Account resultAccount = new Account();
            IList list = null;

            paramAccount.LastName = "Dalton";
            list = dataMapper.QueryForList("DynamicSqlOnColumnSelection", paramAccount);
            resultAccount = (Account)list[0];
            AssertAccount1(resultAccount);
            Assert.AreEqual(5, list.Count);

            paramAccount.LastName = "Bayon";
            list = dataMapper.QueryForList("DynamicSqlOnColumnSelection", paramAccount);
            resultAccount = (Account)list[0];
            Assert.IsNull(resultAccount.FirstName);
            Assert.IsNull(resultAccount.LastName);
            Assert.AreEqual(5, list.Count);
        }

        /// <summary>
        /// Test IsNotEmpty True
        /// </summary>
        [Test]
        public void TestIsNotEmptyTrue()
        {
            IList list = dataMapper.QueryForList("DynamicIsNotEmpty", "Joe");
            AssertAccount1((Account)list[0]);
            Assert.AreEqual(1, list.Count);
        }

        /// <summary>
        /// Test IsNotEmpty False
        /// </summary>
        [Test]
        public void TestIsNotEmptyFalse()
        {
            IList list = dataMapper.QueryForList("DynamicIsNotEmpty", "");
            Assert.AreEqual(5, list.Count);
        }

        /// <summary>
        /// Test IsEqual true
        /// </summary>
        [Test]
        public void TestIsEqualTrue()
        {
            IList list = dataMapper.QueryForList("DynamicIsEqual", "Joe");
            AssertAccount1((Account)list[0]);
            Assert.AreEqual(1, list.Count);
        }

        /// <summary>
        /// Test IsEqual False
        /// </summary>
        [Test]
        public void TestIsEqualFalse()
        {
            IList list = dataMapper.QueryForList("DynamicIsEqual", "BLAH!");
            Assert.AreEqual(5, list.Count);
        }

        /// <summary>
        /// Test IsGreater true
        /// </summary>
        [Test]
        public void TestIsGreaterTrue()
        {
            IList list = dataMapper.QueryForList("DynamicIsGreater", 5);
            AssertAccount1((Account)list[0]);
            Assert.AreEqual(1, list.Count);
        }

        /// <summary>
        /// Test IsGreater false
        /// </summary>
        [Test]
        public void TestIsGreaterFalse()
        {
            IList list = dataMapper.QueryForList("DynamicIsGreater", 1);
            Assert.AreEqual(5, list.Count);
        }

        /// <summary>
        /// Test IsGreaterEqual true
        /// </summary>
        [Test]
        public void TestIsGreaterEqualTrue()
        {
            IList list = dataMapper.QueryForList("DynamicIsGreaterEqual", 3);
            AssertAccount1((Account)list[0]);
            Assert.AreEqual(1, list.Count);
        }

        /// <summary>
        /// Test IsGreaterEqual false
        /// </summary>
        [Test]
        public void TestIsGreaterEqualFalse()
        {
            IList list = dataMapper.QueryForList("DynamicIsGreaterEqual", 1);
            Assert.AreEqual(5, list.Count);
        }

        /// <summary>
        /// Test IsLess true
        /// </summary>
        [Test]
        public void TestIsLessTrue()
        {
            IList list = dataMapper.QueryForList("DynamicIsLess", 1);
            AssertAccount1((Account)list[0]);
            Assert.AreEqual(1, list.Count);
        }

        /// <summary>
        /// Test IsLess false
        /// </summary>
        [Test]
        public void TestIsLessFalse()
        {
            IList list = dataMapper.QueryForList("DynamicIsLess", 5);
            Assert.AreEqual(5, list.Count);
        }

        /// <summary>
        /// Test IsLessEqual true
        /// </summary>
        [Test]
        public void TestIsLessEqualTrue()
        {
            IList list = dataMapper.QueryForList("DynamicIsLessEqual", 3);
            AssertAccount1((Account)list[0]);
            Assert.AreEqual(1, list.Count);
        }

        /// <summary>
        /// Test IsLessEqual false
        /// </summary>
        [Test]
        public void TestIsLessEqualFalse()
        {
            IList list = dataMapper.QueryForList("DynamicIsLessEqual", 5);
            Assert.AreEqual(5, list.Count);
        }

        /// <summary>
        /// Test IsNotNull true
        /// </summary>
        [Test]
        public void TestIsNotNullTrue()
        {
            IList list = dataMapper.QueryForList("DynamicIsNotNull", "");
            AssertAccount1((Account)list[0]);
            Assert.AreEqual(1, list.Count);
        }

        /// <summary>
        /// Test IsNotNull false
        /// </summary>
        [Test]
        public void TestIsNotNullFalse()
        {
            IList list = dataMapper.QueryForList("DynamicIsNotNull", null);
            Assert.AreEqual(5, list.Count);
        }

        /// <summary>
        /// Test IsPropertyAvailable true
        /// </summary>
        [Test]
        public void TestIsPropertyAvailableTrue()
        {
            Account account = new Account();
            account.Id = 1;

            IList list = dataMapper.QueryForList("DynamicIsPropertyAvailable", account);
            AssertAccount1((Account)list[0]);
            Assert.AreEqual(1, list.Count);
        }

        /// <summary>
        /// Test IsPropertyAvailable false
        /// </summary>
        [Test]
        public void TestIsPropertyAvailableFalse()
        {
            string parameter = "1";

            IList list = dataMapper.QueryForList("DynamicIsPropertyAvailable", parameter);
            Assert.AreEqual(5, list.Count);
        }

        /// <summary>
        /// Test IsParameterPresent true
        /// </summary>
        [Test]
        public void TestIsParameterPresentTrue()
        {
            IList list = dataMapper.QueryForList("DynamicIsParameterPresent", 1);
            AssertAccount1((Account)list[0]);
            Assert.AreEqual(1, list.Count);
        }

        /// <summary>
        /// Test IsParameterPresent false
        /// </summary>
        [Test]
        public void TestIsParameterPresentFalse()
        {
            IList list = dataMapper.QueryForList("DynamicIsParameterPresent", null);
            Assert.AreEqual(5, list.Count);
        }

        /// <summary>
        /// Test Empty Parameter Object
        /// </summary>
        [Test]
        public void TestEmptyParameterObject()
        {
            Account account = new Account();
            account.Id = -1;

            IList list = dataMapper.QueryForList("DynamicQueryByExample", account);

            AssertAccount1((Account)list[0]);
            Assert.AreEqual(5, list.Count);
        }

        /// <summary>
        /// Test Dynamic With Extend
        /// </summary>
        [Test]
        public void TestDynamicWithExtend()
        {
            Account account = new Account();
            account.Id = -1;

            IList list = dataMapper.QueryForList("DynamicWithExtend", account);

            AssertAccount1((Account)list[0]);
            Assert.AreEqual(5, list.Count);
        }

        /// <summary>
        /// Test Multiple Iterate
        /// </summary>
        [Test]
        public void TestMultiIterate()
        {
            IList parameters = new ArrayList();
            parameters.Add(1);
            parameters.Add(2);
            parameters.Add(3);

            IList list = dataMapper.QueryForList("MultiDynamicIterate", parameters);

            AssertAccount1((Account)list[0]);
            Assert.AreEqual(3, list.Count);
        }

        /// <summary>
        /// Test Array Property Iterate
        /// </summary>
        [Test]
        public void TestArrayPropertyIterate()
        {
            Account account = new Account();
            account.Ids = new int[3] { 1, 2, 3 };

            IList list = dataMapper.QueryForList("DynamicQueryByExample", account);

            AssertAccount1((Account)list[0]);
            Assert.AreEqual(3, list.Count);
        }

        /// <summary>
        /// Test Complete Statement Substitution
        /// </summary>
        [Test]
        [Ignore("No longer supported.")]
        public void TestCompleteStatementSubst()
        {
            string statement = "select" +
                               "    Account_ID			as Id," +
                               "    Account_FirstName	as FirstName," +
                               "    Account_LastName	as LastName," +
                               "    Account_Email		as EmailAddress" +
                               "  from Accounts" +
                               "  where Account_ID = #id#";
            int id = 1;

            Hashtable parameters = new Hashtable();
            parameters.Add("id", id);
            parameters.Add("statement", statement);

            IList list = dataMapper.QueryForList("DynamicSubst", parameters);
            AssertAccount1((Account)list[0]);
            Assert.AreEqual(1, list.Count);
        }

        /// <summary>
        /// Test Query By Example
        /// </summary>
        [Test]
        public void TestQueryByExample()
        {
            Account account;

            account = new Account();

            account.Id = 5;
            account = dataMapper.QueryForObject("DynamicQueryByExample", account) as Account;
            AssertGilles(account);

            account = new Account();
            account.FirstName = "Gilles";
            account = dataMapper.QueryForObject("DynamicQueryByExample", account) as Account;
            AssertGilles(account);

            account = new Account();
            account.LastName = "Bayon";
            account = dataMapper.QueryForObject("DynamicQueryByExample", account) as Account;
            AssertGilles(account);

            account = new Account();
            account.EmailAddress = "gilles";
            account = (Account)dataMapper.QueryForObject("DynamicQueryByExample", account) as Account;
            AssertGilles(account);

            account = new Account();
            account.Id = 5;
            account.FirstName = "Gilles";
            account.LastName = "Bayon";
            account.EmailAddress = "gilles.bayon@nospam.org";
            account = dataMapper.QueryForObject("DynamicQueryByExample", account) as Account;
            AssertGilles(account);
        }

        /// <summary>
        /// Test Query By Example via private field
        /// </summary>
        [Test]
        public void TestQueryByExampleViaField()
        {
            Account account;

            account = new Account();

            account.Id = 5;
            account = dataMapper.QueryForObject("DynamicQueryByExampleViaPrivateField", account) as Account;
            AssertGilles(account);

            account = new Account();
            account.FirstName = "Gilles";
            account = dataMapper.QueryForObject("DynamicQueryByExampleViaPrivateField", account) as Account;
            AssertGilles(account);

            account = new Account();
            account.LastName = "Bayon";
            account = dataMapper.QueryForObject("DynamicQueryByExampleViaPrivateField", account) as Account;
            AssertGilles(account);

            account = new Account();
            account.EmailAddress = "gilles";
            account = (Account)dataMapper.QueryForObject("DynamicQueryByExampleViaPrivateField", account) as Account;
            AssertGilles(account);

            account = new Account();
            account.Id = 5;
            account.FirstName = "Gilles";
            account.LastName = "Bayon";
            account.EmailAddress = "gilles.bayon@nospam.org";
            account = dataMapper.QueryForObject("DynamicQueryByExampleViaPrivateField", account) as Account;
            AssertGilles(account);
        }
        #endregion
    }
}