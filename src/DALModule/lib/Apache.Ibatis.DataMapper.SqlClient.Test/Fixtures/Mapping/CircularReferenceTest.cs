using System;
using System.Collections;
using System.Collections.Generic;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;
using Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures;
using NUnit.Framework;


namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping
{
    /// <summary>
    /// Summary description for GroupByTest.
    /// </summary>
    [TestFixture]
    public class CircularReferenceTest : BaseTest
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
        }

        #endregion

        [Test]
        public void Order_account_reference_should_be_same()
        {
            List<Order> list = (List<Order>)dataMapper.QueryForList<Order>("GetOrderWithAcccount", null);
            Assert.That(list.Count, Is.EqualTo(10));
            Account account1 = list.Find(delegate(Order order) { return order.Id==1; }).Account;
            Account account2 = list.Find(delegate(Order order) { return order.Id == 10; }).Account;

            Assert.That(account1, Is.SameAs(account2));

            account1 = list.Find(delegate(Order order) { return order.Id == 2; }).Account;
            account2 = list.Find(delegate(Order order) { return order.Id == 7; }).Account;

            Assert.That(account1, Is.SameAs(account2));

            account1 = list.Find(delegate(Order order) { return order.Id == 5; }).Account;
            account2 = list.Find(delegate(Order order) { return order.Id == 6; }).Account;

            Assert.That(account1, Is.SameAs(account2));

        }
    }
}
