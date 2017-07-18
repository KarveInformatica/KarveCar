using System;
using System.Reflection;
using NUnit.Framework;
using DataAccessLayer;



namespace KarveCarUnitTest.DAL.Maestro
{

    /// <summary>
    /// Summary description for BaseTest.
    /// </summary>
    [TestFixture]
    public abstract class BaseTest
    {
       
        protected static IDalLocator dataMapper = null;
   
        /// <summary>
        /// Initialize an sqlMap
        /// </summary>
        [TestFixtureSetUp]
        protected virtual void SetUpFixture()
        {
            //			string loadTime = DateTime.Now.Subtract(start).ToString();
            //			Console.WriteLine("Loading configuration time :"+loadTime);
        }

        /// <summary>
        /// Dispose the SqlMap
        /// </summary>
        [TestFixtureTearDown]
        protected virtual void TearDownFixture()
        {
        }
    }
}