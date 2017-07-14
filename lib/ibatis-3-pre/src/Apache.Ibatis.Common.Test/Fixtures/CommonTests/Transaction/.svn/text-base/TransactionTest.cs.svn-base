
using System;

using Apache.Ibatis.Common.Transaction;

using Apache.Ibatis.Common.Test.Domain;

using NUnit.Framework;

namespace Apache.Ibatis.Common.Test.NUnit.CommonTests.Transaction
{
	/// <summary>
	/// Summary description for TransactionTest.
	/// </summary>
	[TestFixture] 
	[Category("MTS")]
	public class TransactionTest : BaseTest
	{
		#region SetUp & TearDown
		/// <summary>
		/// SetUp
		/// </summary>
		[SetUp] 
		public void SetUp() 
		{
			InitSqlMap();
			InitScript( sqlMap.DataSource, ScriptDirectory + "account-init.sql" );
		}

		/// <summary>
		/// TearDown
		/// </summary>
		[TearDown] 
		public void Dispose()
		{ 
		} 
		#endregion

		#region Transaction Tests
		/// <summary>
		/// Test Simple call to TransactionScope with a commit
		/// </summary>
		[Test] 
		public void SimpleTransaction() 
		{
			Account account = null;

			using (TransactionScope tx = new TransactionScope())
			{
				account = sqlMap.QueryForObject("GetAccountViaColumnName", 1) as Account;
				AssertAccount1(account);
				
				account.FirstName ="transaction changed";
				sqlMap.Update("UpdateAccountViaParameterMap", account);

				tx.Complete(); // Commit
			}

			account = null;
			account = sqlMap.QueryForObject("GetAccountViaColumnName", 1) as Account;

			Assert.AreEqual("transaction changed", account.FirstName);
		}

		/// <summary>
		/// Test Simple call to TransactionScope with a roolback
		/// </summary>
		[Test] 
		public void SimpleRollback() 
		{
			Account account = null;

			using (TransactionScope tx = new TransactionScope())
			{
				account = sqlMap.QueryForObject("GetAccountViaColumnName", 1) as Account;
				AssertAccount1(account);
				
				account.FirstName ="transaction changed";
				sqlMap.Update("UpdateAccountViaParameterMap", account);

				//tx.Complete(); // RollBack
			}

			account = null;
			account = sqlMap.QueryForObject("GetAccountViaColumnName", 1) as Account;

			Assert.AreEqual("Joe", account.FirstName);
		}

		/// <summary>
		/// Test Nested TransactionScope
		/// </summary>
		[Test] 
		public void NestedTransactionScope()
		{
			Account account = null;

			using (TransactionScope tx1 = new TransactionScope())
			{
				account = sqlMap.QueryForObject("GetAccountViaColumnName", 1) as Account;
				AssertAccount1(account);
				
				account.FirstName ="transaction1 changed";
				sqlMap.Update("UpdateAccountViaParameterMap", account);

				account = null;

				using (TransactionScope tx2 = new TransactionScope())
				{
					account = sqlMap.QueryForObject("GetAccountViaColumnName", 1) as Account;
					Assert.AreEqual("transaction1 changed", account.FirstName);
				
					account.FirstName ="transaction2 changed";
					sqlMap.Update("UpdateAccountViaParameterMap", account);

					tx2.Complete(); // Commit
				}

				tx1.Complete(); // Commit
			}
			account = null;
			account = sqlMap.QueryForObject("GetAccountViaColumnName", 1) as Account;

			Assert.AreEqual("transaction2 changed", account.FirstName);

		}

		/// <summary>
		/// Test Nested TransactionScope
		/// </summary>
		[Test] 
		public void NestedCommitWithRollBack()
		{
			Account account = null;

			using (TransactionScope tx1 = new TransactionScope())
			{
				account = sqlMap.QueryForObject("GetAccountViaColumnName", 1) as Account;
				AssertAccount1(account);
				
				account.FirstName = "transaction1 changed";
				sqlMap.Update("UpdateAccountViaParameterMap", account);

				account = null;

				using (TransactionScope tx2 = new TransactionScope())
				{
					account = sqlMap.QueryForObject("GetAccountViaColumnName", 1) as Account;
					Assert.AreEqual("transaction1 changed", account.FirstName);
				
					account.FirstName = "transaction2 changed";
					sqlMap.Update("UpdateAccountViaParameterMap", account);

					//tx2.Complete(); // RollBack
				}

				tx1.Complete(); // Commit

				Assert.AreEqual(false, tx1.IsVoteCommit);
			}
			account = null;
			account = sqlMap.QueryForObject("GetAccountViaColumnName", 1) as Account;

			Assert.AreEqual("Joe", account.FirstName);
		}

		/// <summary>
		/// Test Nested TransactionScope
		/// </summary>
		[Test] 
		public void NestedRollbackWithCommit()
		{
			Account account = null;

			using (TransactionScope tx1 = new TransactionScope())
			{
				account = sqlMap.QueryForObject("GetAccountViaColumnName", 1) as Account;
				AssertAccount1(account);
				
				account.FirstName = "transaction1 changed";
				sqlMap.Update("UpdateAccountViaParameterMap", account);

				account = null;

				using (TransactionScope tx2 = new TransactionScope())
				{
					account = sqlMap.QueryForObject("GetAccountViaColumnName", 1) as Account;
					Assert.AreEqual("transaction1 changed", account.FirstName);
				
					account.FirstName = "transaction2 changed";
					sqlMap.Update("UpdateAccountViaParameterMap", account);

					tx2.Complete(); // Commit

					Assert.AreEqual(true, tx2.IsVoteCommit);
				}

				//tx1.Complete(); // RollBack 
			}
			account = null;
			account = sqlMap.QueryForObject("GetAccountViaColumnName", 1) as Account;

			Assert.AreEqual("Joe", account.FirstName);
		}

		[Test]
		public void NestedRollbacks() 
		{
			Account account = null;

			using (TransactionScope tx1 = new TransactionScope())
			{
				account = sqlMap.QueryForObject("GetAccountViaColumnName", 1) as Account;
				AssertAccount1(account);
				
				account.FirstName = "transaction1 changed";
				sqlMap.Update("UpdateAccountViaParameterMap", account);

				account = null;

				using (TransactionScope tx2 = new TransactionScope())
				{
					account = sqlMap.QueryForObject("GetAccountViaColumnName", 1) as Account;
					Assert.AreEqual("transaction1 changed", account.FirstName);
				
					account.FirstName = "transaction2 changed";
					sqlMap.Update("UpdateAccountViaParameterMap", account);

					//tx2.Complete(); // RollBack
				}

				//tx1.Complete(); // RollBack 

				Assert.AreEqual(false, tx1.IsVoteCommit);
			}
			account = null;
			account = sqlMap.QueryForObject("GetAccountViaColumnName", 1) as Account;

			Assert.AreEqual("Joe", account.FirstName);
		}

		[Test]
		public void NestedTransactionScopeWithDifferentOption() 
		{
			Account account = null;

			using (TransactionScope tx1 = new TransactionScope(TransactionScopeOptions.Required))
			{
				account = sqlMap.QueryForObject("GetAccountViaColumnName", 1) as Account;
				AssertAccount1(account);
				
				account.FirstName = "transaction1 changed";
				sqlMap.Update("UpdateAccountViaParameterMap", account);

				account = null;

				using (TransactionScope tx2 = new TransactionScope(TransactionScopeOptions.RequiresNew))
				{
					account = sqlMap.QueryForObject("GetAccountViaColumnName", 1) as Account;
					Assert.AreEqual("transaction1 changed", account.FirstName);
				
					account.FirstName = "transaction2 changed";
					sqlMap.Update("UpdateAccountViaParameterMap", account);

					//tx2.Complete(); // RollBack, rem tx1 will be rollback
				}

				tx1.Complete(); 

				Assert.AreEqual(false, tx1.IsVoteCommit);
			}
			account = null;
			account = sqlMap.QueryForObject("GetAccountViaColumnName", 1) as Account;

			Assert.AreEqual("Joe", account.FirstName);
		}

//		[Test]
//		public void NestedTransactionScopeWithDifferentOption2() 
//		{
//			Account account = null;
//
//			using (TransactionScope tx1 = new TransactionScope(TransactionScopeOptions.Required))
//			{
//				account = sqlMap.QueryForObject("GetAccountViaColumnName", 1) as Account;
//				AssertAccount1(account);
//				
//				account.FirstName = "transaction1 changed";
//				sqlMap.Update("UpdateAccountViaParameterMap", account);
//
//				account = null;
//
//				using (TransactionScope tx2 = new TransactionScope(TransactionScopeOptions.RequiresNew))
//				{
//					account = sqlMap.QueryForObject("GetAccountViaColumnName", 1) as Account;
//					Assert.AreEqual("Joe", account.FirstName);
//				
//					account.FirstName = "transaction2 changed";
//					sqlMap.Update("UpdateAccountViaParameterMap", account);
//
//					tx2.Consistent = false; // RollBack
//
//					Assert.AreEqual(false, tx2.IsVoteCommit);
//				}
//
//				using (TransactionScope tx2 = new TransactionScope(TransactionScopeOptions.RequiresNew))
//				{
//					account = sqlMap.QueryForObject("GetAccountViaColumnName", 1) as Account;
//					Assert.AreEqual("Joe", account.FirstName);
//				
//					tx2.Consistent = false; // RollBack
//
//					Assert.AreEqual(false, tx2.IsVoteCommit);
//				}
//
//				tx1.Consistent = false; // RollBack 
//
//				Assert.AreEqual(false, tx1.IsVoteCommit);
//			}
//			account = null;
//			account = sqlMap.QueryForObject("GetAccountViaColumnName", 1) as Account;
//
//			Assert.AreEqual("Joe", account.FirstName);
//		}
		#endregion
	}
}
