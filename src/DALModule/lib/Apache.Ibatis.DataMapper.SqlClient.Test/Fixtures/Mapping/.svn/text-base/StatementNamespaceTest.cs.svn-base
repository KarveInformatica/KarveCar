using System;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;
using NUnit.Framework;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping
{
    /// <summary>
    /// To test statement namespaces,
    /// set your SqlMap config settings attribute 
    /// useStatementNamespaces="true" 
    /// before running Namespace Tests.
    /// </summary>
    [TestFixture] 
    [Category("StatementNamespaces")]
    public class StatementNamespaceTest : BaseTest
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
            InitScript(sessionFactory.DataSource, scriptDirectory + "category-init.sql");
        }

        /// <summary>
        /// TearDown
        /// </summary>
        [TearDown] 
        public void Dispose()
        { /* ... */ } 

        #endregion

        #region Test statement namespaces

        /// <summary>
        /// Test QueryForObject
        /// </summary>
        [Test] 
        public void TestQueryForObject() {

            if (configurationSetting.UseStatementNamespaces)
            {
                Account account = dataMapper.QueryForObject("Account.GetAccountViaResultClass", 1) as Account;
                AssertAccount1(account);
            }
            else
            {
                Assert.Ignore("UseStatementNamespaces is false, skipping");
            }
        }

        /// <summary>
        /// Test collection mapping: Ilist collection 
        /// order.LineItemsIList 
        /// with statement namespaces enabled
        /// </summary>
        [Test]
        public void TestListMapping() {

            if (configurationSetting.UseStatementNamespaces)
            {
                Order order =
                    (Order) dataMapper.QueryForObject("Order.GetOrderWithLineItemsUsingStatementNamespaces", 1);

                AssertOrder1(order);

                // Check IList collection
                Assert.IsNotNull(order.LineItemsIList);
                Assert.AreEqual(3, order.LineItemsIList.Count);
            }
            else
            {
                Assert.Ignore("UseStatementNamespaces is false, skipping");
            }
        }

        /// <summary>
        /// Test Insert Via Insert Statement
        /// for support request 1050704:
        /// Unable to use selectKey with 
        /// useStatementNamespaces=true
        /// </summary>
        [Test] 
        public void TestInsertSelectKey() {

            if (configurationSetting.UseStatementNamespaces)
            {
                Category category = new Category();
                category.Name = "toto";
                category.Guid = Guid.NewGuid();

                int key = (int) dataMapper.Insert("Category.InsertCategoryViaInsertStatement", category);
                Assert.AreEqual(1, key);
            }
            else
            {
                Assert.Ignore("UseStatementNamespaces is false, skipping");
            }
        }

        #endregion
    }
}