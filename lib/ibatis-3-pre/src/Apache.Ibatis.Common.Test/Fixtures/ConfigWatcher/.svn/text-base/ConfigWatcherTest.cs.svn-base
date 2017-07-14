using System;
using System.Threading;
using Apache.Ibatis.Common.Resources;
using Apache.Ibatis.Common.Utilities;
using NUnit.Framework;

namespace Apache.Ibatis.Common.Test.Fixtures.ConfigWatcher
{
    /// <summary>
    /// Summary description for ConfigWatcherTest.
    /// </summary>
    [TestFixture] 
    public class ConfigWatcherTest
    {
        private bool _hasChanged = false;

        #region SetUp & TearDown

        /// <summary>
        /// SetUp
        /// </summary>
        [SetUp] 
        public void SetUp() 
        {
            _hasChanged = false;		
        }


        /// <summary>
        /// TearDown
        /// </summary>
        [TearDown] 
        public void Dispose()
        { 
        } 

        #endregion

        #region Test ConfigurationWatcher

        /// <summary>
        /// ConfigurationWatcher Test
        /// </summary>
        [Test] 
        public void ConfigurationWatcherTest() 
        {
            //Assembly a = Assembly.GetExecutingAssembly();
            //Uri uri = new System.Uri(a.CodeBase); 
            //string binDirectory = Path.GetDirectoryName(uri.LocalPath);
            string fileName = "test.config";

            // Configure a watcher
            ConfigureHandler configureDelegate = new ConfigureHandler( Configure );
            ConfigWatcherHandler.ClearFilesMonitored();

            CustomUriBuilder builder = new CustomUriBuilder(fileName, AppDomain.CurrentDomain.BaseDirectory);

            IResource resource = new FileResource(builder.Uri);
            ConfigWatcherHandler.AddFileToWatch(resource.FileInfo);

            TimerCallback callBakDelegate = new TimerCallback( ConfigWatcherTest.OnConfigFileChange );

            StateConfig state = new StateConfig();
            state.FileName = fileName;
            state.ConfigureHandler = configureDelegate;

            new ConfigWatcherHandler( callBakDelegate, state );

            resource.FileInfo.LastWriteTime = DateTime.Now;

            resource.FileInfo.Refresh();

            // Let's give a small bit of time for the change to propagate.
            // The ConfigWatcherHandler class has a timer which 
            // waits for 500 Millis before delivering
            // the event notification.
            System.Threading.Thread.Sleep(600); 

            Assert.IsTrue(_hasChanged);
        }

        protected void Configure(object obj)
        {
            _hasChanged = true;	
        }

        /// <summary>
        /// Called when the configuration has been updated. 
        /// </summary>
        /// <param name="obj">The state config.</param>
        public static void OnConfigFileChange(object obj)
        {
            StateConfig state = (StateConfig)obj;
            state.ConfigureHandler(null);
        }


        #endregion
    }
}