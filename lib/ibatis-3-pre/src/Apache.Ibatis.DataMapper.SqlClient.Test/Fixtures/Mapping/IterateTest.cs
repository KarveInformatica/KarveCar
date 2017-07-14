using System.Collections;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;
using NUnit.Framework;
using System.Collections.Generic;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping
{
    /// <summary>
    /// Summary description for DynamicTest.
    /// </summary>
    [TestFixture]
    public class IterateTest : BaseTest
    {
        #region SetUp & TearDown

        /// <summary>
        /// SetUp
        /// </summary>
        [SetUp]
        public void Init()
        {
            InitScript(sessionFactory.DataSource, scriptDirectory + "account-init.sql");
        }

        /// <summary>
        /// TearDown
        /// </summary>
        [TearDown]
        public void Dispose()
        { /* ... */ }

        #endregion

        [Test]
        public void Iterate()
        {
            IList parameters = new ArrayList();
            parameters.Add(1);
            parameters.Add(2);
            parameters.Add(3);

            IList list = dataMapper.QueryForList("DynamicIterate", parameters);
            AssertAccount1((Account)list[0]);
            Assert.AreEqual(3, list.Count);
        }

        [Test]
        public void Iterate2()
        {
            Account account = new Account();
            account.Ids = new int[3] { 1, 2, 3 };

            IList list = dataMapper.QueryForList("DynamicIterate2", account);
            AssertAccount1((Account)list[0]);
            Assert.AreEqual(3, list.Count);
        }

        [Test]
        public void IterateNestedListProperty() 
        {
            Account accountParam = new Account();

            Account account = new Account();
            account.Id = 1;
            accountParam.Accounts.Add(account);
            account = new Account();
            account.Id = 2;
            accountParam.Accounts.Add(account);
            account = new Account();
            account.Id = 3;
            accountParam.Accounts.Add(account);

            IList<Account> accounts = dataMapper.QueryForList<Account>("IterateNestedListProperty", accountParam);
            AssertAccount1((Account)accounts[0]);
            Assert.AreEqual(3, accounts.Count);
        }

        [Test]
        public void IterateNestedListPropertyB() 
        {
            Account accountParam = new Account();
            accountParam.Id = 99;

            Account account = new Account();
            account.Id = 1;
            accountParam.Accounts.Add(account);
            account = new Account();
            account.Id = 2;
            accountParam.Accounts.Add(account);
            account = new Account();
            account.Id = 3;
            accountParam.Accounts.Add(account);

            IList<Account> accounts = dataMapper.QueryForList<Account>("IterateNestedListPropertyB", accountParam);
            AssertAccount1((Account)accounts[0]);
            Assert.AreEqual(3, accounts.Count);
        }

        [Test]
        public void IterateNestedMapListProperty()
        {
            IDictionary map = new Hashtable();
            IList<Account> accountList = new List<Account>();
            map["Accounts"] = accountList;

            Account account = new Account();
            account.Id = 1;
            accountList.Add(account);
            account = new Account();
            account.Id = 2;
            accountList.Add(account);
            account = new Account();
            account.Id = 3;
            accountList.Add(account);

            IList<Account> accounts = dataMapper.QueryForList<Account>("IterateNestedMapListProperty", map);
            AssertAccount1((Account)accounts[0]);
            Assert.AreEqual(3, accounts.Count);
        }

        [Test]
        public void IterateLiteral()
        {
            IList<int> parameters = new List<int>();
            parameters.Add(1);
            parameters.Add(2);
            parameters.Add(3);

            IList list = dataMapper.QueryForList("DynamicIterateLiteral", parameters);
            AssertAccount1((Account)list[0]);
            Assert.AreEqual(3, list.Count);
        }

        [Ignore]
        public void IterateInConditional()
        {
            IList<int> parameters = new List<int>();
            parameters.Add(1);
            parameters.Add(2);
            parameters.Add(3);

            IList list = dataMapper.QueryForList("DynamicIterateInConditional", parameters);
            Assert.AreEqual(2, list.Count);
            AssertAccount1((Account)list[0]);
            Assert.AreEqual(3, ((Account)list[0]).Id);

        }
    }
}
