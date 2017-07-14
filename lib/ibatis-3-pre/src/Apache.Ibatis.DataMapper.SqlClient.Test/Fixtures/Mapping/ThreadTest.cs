using System;
using System.Threading;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;
using NUnit.Framework;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping
{
    /// <summary>
    /// Summary description for TransactionTest.
    /// </summary>
    [TestFixture] 
    public class ThreadTest: BaseTest
    {
        private readonly ManualResetEvent startEvent = new ManualResetEvent(false);
        private readonly ManualResetEvent stopEvent = new ManualResetEvent(false);

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
        public void TestCommonUsageMultiThread()
        {
            // 10 threads for 5 seconds
            RunThreadsForDuration(10, 5, i =>
             {
                 string prefix = String.Format("[Thread #{0:00} HashCode: {1:00}]: ", i, Thread.CurrentThread.GetHashCode());

                 // ???
                 Assert.IsNull(sessionStore.CurrentSession);

                 Console.WriteLine(prefix + "Beginning");
                 int parameter = i % 2 == 0 ? 2 : 1; // check parity of current thread
                 Account account = (Account)dataMapper.QueryForObject("GetAccountViaColumnIndex", parameter);
                 Assert.IsNull(sessionStore.CurrentSession);
                 Console.WriteLine(prefix + "AssertAccount" + parameter);
                 if (parameter == 1)
                 {
                     AssertAccount1(account);
                 }
                 else
                 {
                     AssertAccount2(account);
                 }
                 Console.WriteLine(prefix + "Ending");
             });
        }

        public void RunThreadsForDuration(int numberOfThreads, int duration, Action<int> action)
        {
            Thread[] threads = new Thread[numberOfThreads];
            for (int i = 0; i < numberOfThreads; i++)
            {
                threads[i] = new Thread(ExecuteUntilSignal);
                threads[i].Start(new CurrentThreadActionInfo(i, action));
            }
            startEvent.Set();
            Thread.CurrentThread.Join(1000 * duration);
            stopEvent.Set();

            // give things time to stop ???
            Thread.Sleep(2000);
        }

        public void ExecuteUntilSignal(object state)
        {
            var actionInfo = (CurrentThreadActionInfo)state;

            Console.WriteLine("Queueing thread #{0} until all threads are ready to start...", actionInfo.CurrentThread);

            startEvent.WaitOne(int.MaxValue, false);
            while (!stopEvent.WaitOne(1, false))
            {
                actionInfo.Invoke();
            }
        }

        class CurrentThreadActionInfo
        {
            public int CurrentThread { get; private set; }
            public Action<int> Action { get; private set; }

            public CurrentThreadActionInfo(int currentThread, Action<int> action)
            {
                CurrentThread = currentThread;
                Action = action;
            }

            public void Invoke()
            {
                Action(CurrentThread);
            }
        }
    }
}