
using System;
using System.IO;
using Apache.Ibatis.Common.Resources;
using NUnit.Framework;

using Apache.Ibatis.Common.Exceptions;

namespace Apache.Ibatis.Common.Test.Fixtures.Resources
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

        private readonly IResourceLoader loader = new AssemblyResourceLoader();
        private readonly string assemblyName = "Apache.Ibatis.Common.Test";
        private readonly string resPath = "Fixtures.Utilities";

        [Test]
        public void Test_good_and_bad_assembly_uri_format()
        {
            Assert.IsTrue(loader.Accept(new Uri("assembly://something/")));
            Assert.IsFalse(loader.Accept(new Uri("file://something")));
            Assert.IsFalse(loader.Accept(new Uri("http://ibatis.apache.org/")));
        }

        [Test]
        public void Valid_loading_of_assembly_resource()
        {
            using (IResource resource = loader.Create(new Uri("assembly://" + assemblyName + "/" + resPath + "/sample.txt")))
            {
                Assert.IsNotNull(resource);

                using (TextReader reader = new StreamReader(resource.Stream))
                {
                    string line = reader.ReadLine();
                    Assert.That(line, Is.EqualTo("hello"));
                }
            }
        }

        /// <summary>
        /// Use incorrect format for an assembly resource.  Using
        /// comma delimited instead of '/'.
        /// </summary>
        [Test]
        [ExpectedException(typeof(UriFormatException))]
        public void Mal_formed_resource_name_should_raise_UriFormatException()
        {
            string uri = "assembly://" + assemblyName + "," + resPath + "/sample.txt";

            using (IResource resource = loader.Create(new Uri(uri)))
            {
                Assert.IsNotNull(resource);

            }
        }


        /// <summary>
        /// Use the correct format but with an invalid assembly name.
        /// </summary>
        [Test]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Invalid_assembly_name_should_raise_FileNotFoundException()
        {
            string uri = "assembly://Xyz.Invalid.Assembly/" + resPath + "/sample.txt";

            using (IResource resource = loader.Create(new Uri(uri)))
            {
                Assert.IsNotNull(resource);

            }
        }

        /// <summary>
        /// Use correct assembly name, but incorrect namespace and resource name.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ResourceException))]
        public void Invalid_resource_name_should_raise_ResourceException()
        {
             string uri = "assembly://" + assemblyName + "/Xyz/InvalidResource.txt";

             using (IResource resource = loader.Create(new Uri(uri)))
             {
                 Assert.IsNotNull(resource);
                 Assert.IsNull(resource.Stream, "Stream should be null");
             }
        }
    }
}
