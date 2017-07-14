using System;
using System.IO;
using Apache.Ibatis.Common.Resources;
using NUnit.Framework;

namespace Apache.Ibatis.Common.Test.Fixtures.Resources
{
    [TestFixture]
    public class UrlResourceLoaderTest
    {
        private IResourceLoader loader = new UrlResourceLoader();

        #region SetUp & TearDown

        /// <summary>
        /// SetUp
        /// </summary>
        [SetUp]
        public void SetUp()
        {
        }


        /// <summary>
        /// TearDown
        /// </summary>
        [TearDown]
        public void Dispose()
        {
        }

        #endregion

        [Test]
        public void Test_good_and_bad_url_uri_format()
        {
            Assert.IsFalse(loader.Accept(new Uri("file://something")));
            Assert.IsTrue(loader.Accept(new Uri("http://ibatis.apache.org/")));
            Assert.IsTrue(loader.Accept(new Uri("https://ibatis.apache.org/")));
            Assert.IsTrue(loader.Accept(new Uri("ftp://ibatis.apache.org/")));
        }

        [Test]
        [ExpectedException(typeof(Apache.Ibatis.Common.Exceptions.ResourceException))]
        public void Url_should_raise_exception_FileNotFoundException_on_FileInfo_property()
        {
            string uri = "http://www.apache.org/";

            CustomUriBuilder builder = new CustomUriBuilder(uri, AppDomain.CurrentDomain.BaseDirectory);

            using (IResource resource = loader.Create(builder.Uri))
            {
                Assert.IsNotNull(resource);

                FileInfo file = resource.FileInfo;
                file.GetType();
            }
        }
    }
}
