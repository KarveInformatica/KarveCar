
using System;
using System.IO;
using Apache.Ibatis.Common.Exceptions;
using Apache.Ibatis.Common.Resources;
using NUnit.Framework;


namespace Apache.Ibatis.Common.Test.Fixtures.Resources
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
        public void Test_good_and_bad_file_uri_format()
        {
            Assert.IsTrue(loader.Accept(new Uri("file://something")));
            Assert.IsFalse(loader.Accept(new Uri("http://ibatis.apache.org/")));
        }

        [Test]
        public void Test_resource_creation_with_absolute_path()
        {
            string file = "file://"+Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\NUnit\CommonTests\Utilities\sample.txt");

            CustomUriBuilder builder = new CustomUriBuilder(file, AppDomain.CurrentDomain.BaseDirectory);

             using (IResource resource = loader.Create(builder.Uri))
             {
                Assert.IsNotNull(resource);

                using (TextReader reader = new StreamReader(resource.Stream))
                {
                    string line = reader.ReadLine();
                    Assert.That(line, Is.EqualTo("hello"));
                }
             }
        }

        [Test]
        public void Test_resource_creation_with_absolute_path_and_slash()
        {
            string file = "file:///" + Apache.Ibatis.Common.Resources.Resources.ApplicationBase + Path.DirectorySeparatorChar + "SqlMap_MSSQL_SqlClient.config";

            CustomUriBuilder builder = new CustomUriBuilder(file, AppDomain.CurrentDomain.BaseDirectory);

            using (IResource resource = loader.Create(builder.Uri))
            {
                Assert.IsNotNull(resource);

                using (TextReader reader = new StreamReader(resource.Stream))
                {
                    string line = reader.ReadLine();
                    Assert.That(line, Is.EqualTo(@"<?xml version=""1.0"" encoding=""utf-8""?>"));
                }
            }
        }

        [Test(Description = "Create With Relative Path")]
        public void Test_resource_creation_with_relative_path()
        {
            string file = @"../../NUnit/CommonTests/Utilities/sample.txt";

            CustomUriBuilder builder = new CustomUriBuilder(file, AppDomain.CurrentDomain.BaseDirectory);

            using (IResource resource = loader.Create(builder.Uri))
            {
                Assert.IsNotNull(resource);

                using (TextReader reader = new StreamReader(resource.Stream))
                {
                    string line = reader.ReadLine();
                    Assert.That(line, Is.EqualTo("hello"));
                }
            }
        }

        [Test]
        public void Test_resource_creation_in_same_base_directory_with_Relative()
        {
            string file = "SqlMap_MSSQL_SqlClient.config";

            CustomUriBuilder builder = new CustomUriBuilder(file, AppDomain.CurrentDomain.BaseDirectory);

            using (IResource resource = loader.Create(builder.Uri))
            {
                Assert.IsNotNull(resource);

                using (TextReader reader = new StreamReader(resource.Stream))
                {
                    string line = reader.ReadLine();
                    Assert.That(line, Is.EqualTo(@"<?xml version=""1.0"" encoding=""utf-8""?>"));
                }
            }
        }

        [Test]
        [ExpectedException(typeof(ResourceException))]
        public void Non_existing_resource_should_raise_ResourceException()
        {
            string file = "/Something/file1.txt";

            CustomUriBuilder builder = new CustomUriBuilder(file, AppDomain.CurrentDomain.BaseDirectory);
        }

        [Test]
        public void Test_resource_creation_with_space_in_path()
        {
            string path = Path.GetFullPath("spaced dir");
            Directory.CreateDirectory(path);
            string filePath = Path.Combine(path, "spaced file.txt");
            using (StreamWriter text = File.CreateText(filePath))
            {
                text.WriteLine("hello world");
            }

            CustomUriBuilder builder = new CustomUriBuilder("file://" + filePath, AppDomain.CurrentDomain.BaseDirectory);

            using (IResource resource = loader.Create(builder.Uri))
            {
                Assert.IsNotNull(resource);

                using (TextReader reader = new StreamReader(resource.Stream))
                {
                    Assert.That(reader.ReadLine(), Is.EqualTo("hello world"));
                }
            }
        }

        [Test]
        public void Test_resource_creation_with_special_uri_character()
        {
            string path = Path.GetFullPath("dir#");
            Directory.CreateDirectory(path);
            string filePath = Path.Combine(path, "file.txt");
            using (StreamWriter text = File.CreateText(filePath))
            {
                text.WriteLine("hello world");
            }

            CustomUriBuilder builder = new CustomUriBuilder(filePath, AppDomain.CurrentDomain.BaseDirectory);

            using (IResource resource = loader.Create(builder.Uri))
            {
                Assert.IsNotNull(resource);

                using (TextReader reader = new StreamReader(resource.Stream))
                {
                    Assert.That(reader.ReadLine(), Is.EqualTo("hello world"));
                }
            }
        }

    }
}
