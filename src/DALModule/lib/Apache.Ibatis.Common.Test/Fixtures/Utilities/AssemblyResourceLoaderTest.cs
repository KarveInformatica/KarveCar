
using System;
using System.IO;
using Apache.Ibatis.Common.Resources;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Apache.Ibatis.Common.Test.NUnit.CommonTests.Utilities.Resources
{
    [TestFixture] 
    public class AssemblyResourceLoaderTest
    {
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

        private IResourceLoader loader = new AssemblyResourceLoader();
        private string assemblyName = "Apache.Ibatis.Common.Test";
        private string resPath = "NUnit.CommonTests.Utilities";

        [Test]
        public void Accept()
        {
            Assert.IsTrue(loader.Accept(new Uri("assembly://something/")));
            Assert.IsFalse(loader.Accept(new Uri("file://something")));
            Assert.IsFalse(loader.Accept(new Uri("http://ibatis.apache.org/")));
        }

        [Test]
        public void CreateWithAbsolutePath()
        {
            using (IResource resource = loader.Create(new Uri("assembly://" + assemblyName + "/" + resPath + "/sample.txt")))
            {
                Assert.IsNotNull(resource);

                TextReader reader = new StreamReader(resource.Stream);
                string line = reader.ReadLine();
                Assert.That(line, Is.EqualTo("hello"));
            }
        }
    }
}
