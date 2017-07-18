
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Apache.Ibatis.Common.Utilities;

using Apache.Ibatis.DataMapper.MappedStatements;
using Apache.Ibatis.DataMapper.Model.Cache.Implementation;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;
using NUnit.Framework;
using Apache.Ibatis.DataMapper.Model.Cache;
using Apache.Ibatis.DataMapper.Session;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping
{
    /// <summary>
    /// Summary description for ParameterMapTest.
    /// </summary>
    [TestFixture] 
    public class CacheTest : BaseTest
    {
        #region SetUp & TearDown

        /// <summary>
        /// SetUp
        /// </summary>
        [SetUp] 
        public void SetUp() 
        {
            InitScript(sessionFactory.DataSource, scriptDirectory + "account-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "account-procedure.sql", false);
        }

        /// <summary>
        /// TearDown
        /// </summary>
        [TearDown] 
        public void TearDown()
        { /* ... */ } 

        #endregion

        #region Test cache

        /// <summary>
        /// Test for JIRA 29
        /// </summary>
        [Test] 
        public void TestJIRA28()
        {
            Account account = dataMapper.QueryForObject("GetNoAccountWithCache",-99) as Account;

            Assert.IsNull(account);
        }

        /// <summary>
        /// Cache error with QueryForObject<T>
        /// </summary>
        [Test]
        public void TestJIRA242WithNoCache()
        {
            Account account = dataMapper.QueryForObject<Account>("GetNoAccountWithCache", -99);
            account = dataMapper.QueryForObject<Account>("GetNoAccountWithCache", -99);

            Assert.IsNull(account);
        }

        /// <summary>
        /// Cache error with QueryForObject<T> with object in cache
        /// </summary>
        [Test]
        public void TestJIRA242WithCache()
        {
            Account account1 = dataMapper.QueryForObject<Account>("GetNoAccountWithCache", 1);
            AssertAccount1(account1);
            int firstId = HashCodeProvider.GetIdentityHashCode(account1);

            Account account2 = dataMapper.QueryForObject<Account>("GetNoAccountWithCache", 1);
            AssertAccount1(account2);

            int secondId = HashCodeProvider.GetIdentityHashCode(account2);

            Assert.AreEqual(firstId, secondId);
        }

        /// <summary>
        /// Cache error with QueryForObject<T> PostStatementEventArgs with object in cache
        /// </summary>
        [Test]
        public void TestJIRA242WithCacheAndPostStatementEventArgs()
        {
            List<bool> postSelectedWithCacheHitCalled = new List<bool>();

            IMappedStatement statement = ((IModelStoreAccessor)dataMapper).ModelStore.GetMappedStatement("GetNoAccountWithCache");
            statement.Statement.CacheModel.Cache.Clear();
            statement.PostSelect += (sender, e) => postSelectedWithCacheHitCalled.Add(e.CacheHit);

            Account first = dataMapper.QueryForObject<Account>("GetNoAccountWithCache", 1);
            Account second = dataMapper.QueryForObject<Account>("GetNoAccountWithCache", 1);
            Assert.AreEqual(first.Id, second.Id);

            // ensure the PostSelect event was called twice
            Assert.IsTrue(postSelectedWithCacheHitCalled.Count == 2);

            // the first time through we should get CacheHit==false because the cache is empty
            Assert.IsFalse(postSelectedWithCacheHitCalled[0]);

            // the second time through we should get CacheHit==true
            Assert.IsTrue(postSelectedWithCacheHitCalled[1]);
        }

        /// <summary>
        /// Cache error with QueryForObjectwith object in cache
        /// </summary>
        [Test]
        public void TestJIRA242_WithoutGeneric_WithCache()
        {
            Account account1 = dataMapper.QueryForObject("GetNoAccountWithCache", 1) as Account;
            AssertAccount1(account1);
            int firstId = HashCodeProvider.GetIdentityHashCode(account1);

            Account account2 = dataMapper.QueryForObject("GetNoAccountWithCache", 1) as Account;
            AssertAccount1(account2);

            int secondId = HashCodeProvider.GetIdentityHashCode(account2);

            Assert.AreEqual(firstId, secondId);
        }

        [Test]
        public void LRU_cache_should_work()
        {
            IList list = dataMapper.QueryForList("GetLruCachedAccountsViaResultMap", null);

            int firstId = HashCodeProvider.GetIdentityHashCode(list);

            list = dataMapper.QueryForList("GetLruCachedAccountsViaResultMap", null);

            int secondId = HashCodeProvider.GetIdentityHashCode(list);

            Assert.AreEqual(firstId, secondId);

            list = dataMapper.QueryForList("GetLruCachedAccountsViaResultMap", null);

            int thirdId = HashCodeProvider.GetIdentityHashCode(list);

            Assert.AreEqual(firstId, thirdId);
        }

        /// <summary>
        /// Test Cache query
        /// </summary>
        /// <remarks>
        /// Used trace to see that the second query don't open an new connection
        /// </remarks>
        [Test]
        public void TestJIRA104()
        {
            IList list = dataMapper.QueryForList("GetCachedAccountsViaResultMap", null);

            int firstId = HashCodeProvider.GetIdentityHashCode(list);

            list = dataMapper.QueryForList("GetCachedAccountsViaResultMap", null);

            int secondId = HashCodeProvider.GetIdentityHashCode(list);

            Assert.AreEqual(firstId, secondId);
        }
	    
        /// <summary>
        /// Test Cache query
        /// </summary>
        [Test] 
        public void TestQueryWithCache() 
        {
            IList list = dataMapper.QueryForList("GetCachedAccountsViaResultMap", null);

            int firstId = HashCodeProvider.GetIdentityHashCode(list);

            list = dataMapper.QueryForList("GetCachedAccountsViaResultMap", null);

            //Console.WriteLine(sqlMap.GetDataCacheStats());

            int secondId = HashCodeProvider.GetIdentityHashCode(list);

            Assert.AreEqual(firstId, secondId);

            Account account = (Account) list[1];
            account.EmailAddress  = "somebody@cache.com";
            dataMapper.Update("UpdateAccountViaInlineParameters", account);

            list = dataMapper.QueryForList("GetCachedAccountsViaResultMap", null);

            int thirdId = HashCodeProvider.GetIdentityHashCode(list);

            Assert.IsTrue(firstId != thirdId);

            //Console.WriteLine(sqlMap.GetDataCacheStats());
        }


        /// <summary>
        /// Test flush Cache
        /// </summary>
        [Test] 
        public void TestFlushDataCache() 
        {
            IList list = dataMapper.QueryForList("GetCachedAccountsViaResultMap", null);

            int firstId = HashCodeProvider.GetIdentityHashCode(list);

            list = dataMapper.QueryForList("GetCachedAccountsViaResultMap", null);

            int secondId = HashCodeProvider.GetIdentityHashCode(list);

            Assert.AreEqual(firstId, secondId);

            ((IModelStoreAccessor)dataMapper).ModelStore.FlushCaches();

            list = dataMapper.QueryForList("GetCachedAccountsViaResultMap", null);

            int thirdId = HashCodeProvider.GetIdentityHashCode(list);

            Assert.AreNotEqual(firstId, thirdId);
        }

        [Test]
        public void TestFlushDataCacheOnExecute()
        {
            IList list = dataMapper.QueryForList("GetCachedAccountsViaResultMap", null);
            int firstId = HashCodeProvider.GetIdentityHashCode(list);
			
            list = dataMapper.QueryForList("GetCachedAccountsViaResultMap", null);
            int secondId = HashCodeProvider.GetIdentityHashCode(list);
            Assert.AreEqual(firstId, secondId);
		    
            dataMapper.Update("UpdateAccountViaInlineParameters", list[0]);
            list = dataMapper.QueryForList("GetCachedAccountsViaResultMap", null);
            int thirdId = HashCodeProvider.GetIdentityHashCode(list);
            Assert.AreNotEqual(firstId ,thirdId);
        }

        /// <summary>
        /// Test MappedStatement Query With Threaded Cache
        /// </summary>
        [Test]
        public void TestMappedStatementQueryWithThreadedCache() 
        {
            Hashtable results = new Hashtable();

            TestCacheThread.StartThread(dataMapper, results, "GetCachedAccountsViaResultMap");
            int firstId = (int) results["id"];

            TestCacheThread.StartThread(dataMapper, results, "GetCachedAccountsViaResultMap");
            int secondId = (int) results["id"];

            Assert.AreEqual(firstId, secondId);

            IList list = (IList) results["list"];

            Account account = (Account) list[1];
            account.EmailAddress = "new.toto@somewhere.com";
            dataMapper.Update("UpdateAccountViaInlineParameters", account);

            list = dataMapper.QueryForList("GetCachedAccountsViaResultMap", null);

            int thirdId = HashCodeProvider.GetIdentityHashCode(list);

            Assert.AreNotEqual(firstId , thirdId);
        }

        /// <summary>
        /// Test MappedStatement Query With Threaded Read Write Cache
        /// </summary>
        [Test]
        public void TestMappedStatementQueryWithThreadedReadWriteCache()
        {
            Hashtable results = new Hashtable();

            TestCacheThread.StartThread(dataMapper, results, "GetRWCachedAccountsViaResultMap");
            int firstId = (int) results["id"];

            TestCacheThread.StartThread(dataMapper, results, "GetRWCachedAccountsViaResultMap");
            int secondId = (int) results["id"];

            Assert.AreNotEqual(firstId, secondId);

            IList list = (IList) results["list"];

            Account account = (Account) list[1];
            account.EmailAddress = "new.toto@somewhere.com";
            dataMapper.Update("UpdateAccountViaInlineParameters", account);

            list = dataMapper.QueryForList("GetCachedAccountsViaResultMap", null);

            int thirdId = HashCodeProvider.GetIdentityHashCode(list);

            Assert.AreNotEqual(firstId, thirdId);
        }

        /// <summary>
        /// Test Cache Null Object
        /// </summary>
        [Test]
        public void TestCacheNullObject()
        {
            CacheModel cache = GetCacheModel();
            CacheKey key = new CacheKey();
            key.Update("testKey");

            cache[key] = null;

            object returnedObject = cache[key];
            Assert.AreEqual(CacheModel.NULL_OBJECT, returnedObject);
            Assert.AreEqual(HashCodeProvider.GetIdentityHashCode(CacheModel.NULL_OBJECT), HashCodeProvider.GetIdentityHashCode(returnedObject));
        }


        /// <summary>
        /// Test CacheHit
        /// </summary>
        [Test]
        public void TestCacheHit() 
        {
            CacheModel cache = GetCacheModel();

            CacheKey key = new CacheKey();
            key.Update("testKey");

            string value = "testValue";
            cache[key] = value;

            object returnedObject = cache[key];
            Assert.AreEqual(value, returnedObject);
            Assert.AreEqual(HashCodeProvider.GetIdentityHashCode(value), HashCodeProvider.GetIdentityHashCode(returnedObject));
        }

        /// <summary>
        /// Test CacheMiss
        /// </summary>
        [Test]
        public void TestCacheMiss() 
        {
            CacheModel cache = GetCacheModel();

            CacheKey key = new CacheKey();
            key.Update("testKey");

            string value = "testValue";
            cache[key] = value;

            CacheKey wrongKey = new CacheKey();
            wrongKey.Update("wrongKey");

            object returnedObject = cache[wrongKey];
            Assert.IsTrue(!value.Equals(returnedObject));
            Assert.IsNull(returnedObject) ;
            //Assert.AreEqual(0, cache.HitRatio);
        }
		
        /// <summary>
        /// Test CacheHitMiss
        /// </summary>
        [Test]
        public void TestCacheHitMiss() 
        {
            CacheModel cache = GetCacheModel();

            CacheKey key = new CacheKey();
            key.Update("testKey");

            string value = "testValue";
            cache[key] = value;

            object returnedObject = cache[key];
            Assert.AreEqual(value, returnedObject);
            Assert.AreEqual(HashCodeProvider.GetIdentityHashCode(value), HashCodeProvider.GetIdentityHashCode(returnedObject));

            CacheKey wrongKey = new CacheKey();
            wrongKey.Update("wrongKey");

            returnedObject = cache[wrongKey];
            Assert.IsTrue(!value.Equals(returnedObject));
            Assert.IsNull(returnedObject) ;
            //Assert.AreEqual(0.5, cache.HitRatio);
        }


        /// <summary>
        /// Test Duplicate Add to Cache
        /// </summary>
        /// <remarks>IBATISNET-134</remarks>
        [Test]
        public void TestDuplicateAddCache() 
        {
            CacheModel cache = GetCacheModel();

            CacheKey key = new CacheKey();
            key.Update("testKey");
            string value = "testValue";

            object obj = null;
            obj = cache[key];
            Assert.IsNull(obj);
            obj = cache[key];
            Assert.IsNull(obj);

            cache[key] = value;
            cache[key] = value;

            object returnedObject = cache[key];
            Assert.AreEqual(value, returnedObject);
            Assert.AreEqual(HashCodeProvider.GetIdentityHashCode(value), HashCodeProvider.GetIdentityHashCode(returnedObject));
        }

        private CacheModel GetCacheModel() 
        {
            CacheModel cache = new CacheModel("test", typeof(PerpetualCache).FullName, long.MinValue, 0, false);
            //cache.FlushInterval = new FlushInterval(0, 5, 0, 0);
			
            return cache;
        }

        #endregion


        private class TestCacheThread
        {
            private IDataMapper dataMapper = null;
            private Hashtable results = null;
            private string statementName = string.Empty;

            public TestCacheThread(IDataMapper dataMapper, Hashtable results, string statementName) 
            {
                this.dataMapper = dataMapper;
                this.results = results;
                this.statementName = statementName;
            }

            public void Run() 
            {
                try 
                {
                    IMappedStatement statement = ((IModelStoreAccessor)dataMapper).ModelStore.GetMappedStatement(statementName);
                    ISession session = sessionFactory.OpenSession();
                    session.OpenConnection();

                    IList list = statement.ExecuteQueryForList(session, null);

                    int firstId = HashCodeProvider.GetIdentityHashCode(list);

                    list = statement.ExecuteQueryForList(session, null);
                    int secondId = HashCodeProvider.GetIdentityHashCode(list);

                    results["id"] = secondId;
                    results["list"] = list;
                    session.Close();
                } 
                catch (Exception e) 
                {
                    throw e;
                }
            }

            public static void StartThread(IDataMapper dataMapper, Hashtable results, string statementName) 
            {
                TestCacheThread tct = new TestCacheThread(dataMapper, results, statementName);
                Thread thread = new Thread( new ThreadStart(tct.Run) );
                thread.Start();
                try 
                {
                    thread.Join();
                } 
                catch (Exception e) 
                {
                    throw e;
                }
            }
        }
    }
}