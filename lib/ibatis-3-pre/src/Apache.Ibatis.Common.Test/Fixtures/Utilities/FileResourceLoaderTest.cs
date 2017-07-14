
using System;
using System.IO;
using Apache.Ibatis.Common.Resources;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Apache.Ibatis.Common.Test.NUnit.CommonTests.Utilities.Resources
{
    [TestFixture]
    public class FileResourceLoaderTest
    {
        private IResourceLoader loader = new FileResourceLoader();

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
        public void Accept()
        {
            Assert.IsTrue(loader.Accept(new Uri("file://something")));
            Assert.IsFalse(loader.Accept(new Uri("http://ibatis.apache.org/")));
        }

        [Test]
        public void CreateWithAbsolutePath()
        {
            string file = "file://"+Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\NUnit\CommonTests\Utilities\sample.txt");

            CustomUriBuilder builder = new CustomUriBuilder(file, AppDomain.CurrentDomain.BaseDirectory);

            IResource resource = loader.Create(builder.Uri);

            Assert.IsNotNull(resource);

            TextReader reader = new StreamReader(resource.Stream);
            string line = reader.ReadLine();
            Assert.That(line, Is.EqualTo("hello"));
        }

        [Test(Description = "Create With Relative Path")]
        public void CreateWithRelativePath()
        {
            string file = @"../NUnit/CommonTests/Utilities/sample.txt";

            CustomUriBuilder builder = new CustomUriBuilder(file, AppDomain.CurrentDomain.BaseDirectory);

            IResource resource = loader.Create(builder.Uri);

            Assert.IsNotNull(resource);

            TextReader reader = new StreamReader(resource.Stream);
            string line = reader.ReadLine();
            Assert.That(line, Is.EqualTo("hello"));
        }
    }
}
