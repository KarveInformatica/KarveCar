using System;
using System.Collections;
using Apache.Ibatis.DataMapper.Exceptions;
using Apache.Ibatis.DataMapper.Session;
using Apache.Ibatis.DataMapper.Session.Transaction;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;
using NUnit.Framework;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping
{
    /// <summary>
    /// Summary description for TransactionTest.
    /// </summary>
    [TestFixture] 
    public class TransactionTest: BaseTest
    {

        #region SetUp & TearDown

        /// <summary>
        /// SetUp 
        /// </summary>
        [SetUp]
        public void SetUp() 
        {
            InitScript(sessionFactory.DataSource, scriptDirectory + "category-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "category-procedure.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "account-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "account-procedure.sql", false);

        }

        /// <summary>
        /// TearDown
        /// </summary>
        [TearDown] 
        public void Dispose()
        { /* ... */ } 

        #endregion

        [Test]
        public void Second_transaction_should_not_be_committed()
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    transaction.Complete();
                }

                using (ITransaction transaction = session.BeginTransaction())
                {
                    Assert.IsFalse(transaction.WasCommit);
                    Assert.IsFalse(transaction.WasRollback);
                }
            }
        }

        [Test]
        [ExpectedException(typeof(DataMapperException))]
        public void Commit_after_dispose_throws_exception()
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                ITransaction transaction = session.BeginTransaction();
                transaction.Dispose();
                transaction.Commit();
            }
        }

        [Test]
        [ExpectedException(typeof(DataMapperException))]
        public void Rollback_after_dispose_throws_exception()
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                ITransaction transaction = session.BeginTransaction();
                transaction.Dispose();
                transaction.Rollback();
            }
        }

        [Test]
        public void Command_aftertransaction_should_work()
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                }

                using (ITransaction transaction = session.BeginTransaction())
                {
                    transaction.Commit();
                }


                using (ITransaction transaction = session.BeginTransaction())
                {
                    transaction.Rollback();
                }
                Account account = (Account)dataMapper.QueryForObject("GetAccountNullableEmail", 1);
                Assert.IsNotNull(account);
            }
        }

        /// <summary>
        /// Test IsTransactionStart
        /// </summary>
        [Test]
        public void Transaction_should_Start()
        {
            Account account = NewAccount6();

            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    dataMapper.Insert("InsertAccountViaParameterMap", account);

                    account = NewAccount6();
                    account.Id = 7;
                    dataMapper.Insert("InsertAccountViaParameterMap", account);

                    transaction.Complete(); // Commit
                }
            }
        }

        [Test]
        public void WasCommittedOrRolledBack()
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Assert.AreSame(transaction, session.Transaction);
                    Assert.IsFalse(transaction.WasCommit);
                    Assert.IsFalse(transaction.WasRollback);
                    transaction.Commit();

                    Assert.IsNotNull(session.Transaction);
                    Assert.IsTrue(transaction == session.Transaction);

                    Assert.IsTrue(transaction.WasCommit);
                    Assert.IsFalse(transaction.WasRollback);

                    Assert.IsTrue(session.Transaction.WasCommit);
                    Assert.IsFalse(session.Transaction.WasRollback);

                    Assert.IsFalse(session.Transaction.IsStarted);

                }

                using (ITransaction transaction = session.BeginTransaction())
                {
                    transaction.Rollback();

                    Assert.IsNotNull(session.Transaction);
                    Assert.IsTrue(transaction == session.Transaction);

                    Assert.IsTrue(transaction.WasRollback);
                    Assert.IsFalse(transaction.WasCommit);

                    Assert.IsTrue(session.Transaction.WasRollback);
                    Assert.IsFalse(session.Transaction.WasCommit);

                    Assert.IsFalse(session.Transaction.IsStarted);
                }
            }
        }

        /// <summary>
        /// Test BeginTransaction, CommitTransaction
        /// </summary>
        [Test]
        public void Begin_commit_transaction_should_work() 
        {
            Account account = NewAccount6();

            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    dataMapper.Insert("InsertAccountViaParameterMap", account);
                    transaction.Complete(); // Commit
                }
            }

            // This will use autocommit...
            account = (Account) dataMapper.QueryForObject("GetAccountNullableEmail", 6);

            AssertAccount6(account);
        }

        /// <summary>
        /// Test that nested BeginTransaction throw an exception
        /// </summary>
        [Test]
        public void Begin_transaction_on_transaction_already_started_should_throw_exception() 
        {
            Account account = NewAccount6();
            bool exceptionThrownAsExpected = false;

            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    dataMapper.Insert("InsertAccountViaParameterMap", account);

                    try 
                    {
                        session.BeginTransaction(); // transaction already started
                    }
                    catch (DataMapperException e)
                    {
                        exceptionThrownAsExpected = true;
                        //Console.WriteLine("Test TransactionAlreadyStarted " + e.Message);
                    }
                    transaction.Complete(); // Commit
                }
            }

            // This will use autocommit...
            account = (Account) dataMapper.QueryForObject("GetAccountNullableEmail", 6);
            AssertAccount6(account);
            Assert.IsTrue(exceptionThrownAsExpected);
        }

        /// <summary>
        /// Test that CommitTransaction without BeginTransaction trow an exception
        /// </summary>
        [Test]
        public void Commit_transaction_without_Begin_transaction_should_throw_an_exception() 
        {
            Account account = NewAccount6();
            bool exceptionThrownAsExpected = false;

            dataMapper.Insert("InsertAccountViaParameterMap", account);

            using (ISession session = sessionFactory.OpenSession())
            {
                try
                {
                    session.Transaction.Commit(); // No transaction started
                }
                catch (Exception e)
                {
                    exceptionThrownAsExpected = true;
                    //Console.WriteLine("Test NoTransactionStarted " + e.Message);
                }
            }

            // This will use autocommit...
            Assert.IsTrue(exceptionThrownAsExpected);
            account = (Account) dataMapper.QueryForObject("GetAccountNullableEmail", 6);
            AssertAccount6(account);
        }

        /// <summary>
        /// Test a RollBack Transaction.
        /// </summary>
        [Test]
        public void Rollback_transaction_should_work() 
        {
            Account account = NewAccount6();

            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    dataMapper.Insert("InsertAccountViaParameterMap", account);
                }
            }// will rollback

            // This will use autocommit...
            account = (Account) dataMapper.QueryForObject("GetAccountNullableEmail", 6);
            Assert.IsNull(account);
        }

        /// <summary>
        /// Test Using syntax on Transaction
        /// </summary>
        [Test]
        public void Using_syntax_should_commit_transaction()
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Account account = (Account)dataMapper.QueryForObject("GetAccountViaColumnName", 1);

                    account.EmailAddress = "new@somewhere.com";
                    dataMapper.Update("UpdateAccountViaParameterMap", account);

                    account = dataMapper.QueryForObject("GetAccountViaColumnName", 1) as Account;

                    Assert.AreEqual("new@somewhere.com", account.EmailAddress);

                    transaction.Complete(); // Commit
                } // compiler will call Dispose on ITransaction
            }// compiler will call Dispose on ISession
        }

        /// <summary>
        /// Test 
        /// </summary>
        [Test]
        public void Session_Transaction_should_be_commit()
        {
            ISession session = sessionFactory.OpenSession();
            ITransaction transaction = session.BeginTransaction();

            Account account = (Account)dataMapper.QueryForObject("GetAccountViaColumnName", 1);

            account.EmailAddress = "new@somewhere.com";
            dataMapper.Update("UpdateAccountViaParameterMap", account);

            account = dataMapper.QueryForObject("GetAccountViaColumnName", 1) as Account;

            Assert.AreEqual("new@somewhere.com", account.EmailAddress);

            transaction.Commit();
            session.Close();
        }

        /// <summary>
        /// Test DBHelperParameterCache in transaction
        /// </summary>
        [Test]
        public void DBHelperParameterCache_should_work_in_transaction()
        {
            Account account = new Account();

            account.Id = 99;
            account.FirstName = "Achille";
            account.LastName = "Talon";
            account.EmailAddress = "Achille.Talon@somewhere.com";

            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {

                    dataMapper.Insert("InsertAccountViaStoreProcedure", account);

                    Hashtable map = new Hashtable();
                    map.Add("Id", 0);
                    map.Add("Name", "Toto");
                    map.Add("Guid", Guid.NewGuid());

                    dataMapper.Insert("InsertCategoryViaStoreProcedureWithMap", map);
                    Assert.AreEqual(1, map["Id"]);

                    transaction.Complete();
                }
            }
        }
    }
}