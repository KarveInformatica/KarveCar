using System;
using System.Collections;
using System.Configuration;
using System.IO;
using Apache.Ibatis.Common.Resources;
using Apache.Ibatis.DataMapper.Configuration;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config.Xml;
using Apache.Ibatis.DataMapper.Session;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;
using NUnit.Framework;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Modules
{
    [TestFixture]
    public class ResultMapModuleTest
    {
        protected IDataMapper dataMapper = null;

        /// <summary>
        /// Initialize an sqlMap
        /// </summary>
        [TestFixtureSetUp]
        protected virtual void SetUpFixture()
        {
            string resource = "SqlMap_StatementOnly.config";
            string scriptDirectory = Path.Combine(Path.Combine(Path.Combine(Resources.ApplicationBase, ".."), ".."), "Scripts") + Path.DirectorySeparatorChar;

            try
            {
                IConfigurationEngine engine = new DefaultConfigurationEngine();
                engine.RegisterInterpreter(new XmlConfigurationInterpreter(resource));
                engine.RegisterModule(new DocumentModule());
                engine.RegisterModule(new AccountModule());

                IMapperFactory mapperFactory = engine.BuildMapperFactory();

                Console.WriteLine(engine.ConfigurationStore.ToString());

                dataMapper = ((IDataMapperAccessor)mapperFactory).DataMapper;
                ISessionFactory sessionFactory = engine.ModelStore.SessionFactory;
                BaseTest.InitScript(sessionFactory.DataSource, scriptDirectory + "account-init.sql");

            }
            catch (Exception ex)
            {
                Exception e = ex;
                while (e != null)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    e = e.InnerException;

                }
                throw;
            }

        }

        /// <summary>
        /// Test Inheritance On Result Property
        /// </summary>
        [Test]
        public void Inheritance_on_result_property_should_work()
        {
            Account account = dataMapper.QueryForObject<Account>("select-account-joined-document", 3);
            Assert.AreEqual(3, account.Id, "account.Id");
            Assert.AreEqual("William", account.FirstName, "account.FirstName");

            Book book = account.Document as Book;
            Assert.IsNotNull(book);
            AssertBook(book, 3, "Lord of the Rings", 3587);
        }

        /// <summary>
        /// Test account constructor mapping
        /// </summary>
        [Test]
        public void Constructor_mapping_should_work()
        {
            Account account = dataMapper.QueryForObject <Account>("SelectAccountConstructor", 1);
            AssertAccount1(account);
        }

        /// <summary>
        /// Test All document with no formula
        /// </summary>
        [Test]
        public void GetAllDocument()
        {
            IList list = dataMapper.QueryForList("GetAllDocument", null);

            Assert.AreEqual(6, list.Count);
            Book book = (Book)list[0];
            AssertBook(book, 1, "The World of Null-A", 55);

            book = (Book)list[1];
            AssertBook(book, 3, "Lord of the Rings", 3587);

            Document document = (Document)list[2];
            AssertDocument(document, 5, "Le Monde");

            document = (Document)list[3];
            AssertDocument(document, 6, "Foundation");

            Newspaper news = (Newspaper)list[4];
            AssertNewspaper(news, 2, "Le Progres de Lyon", "Lyon");

            document = (Document)list[5];
            AssertDocument(document, 4, "Le Canard enchaine");
        }

        /// <summary>
        /// Test All document in a typed collection
        /// </summary>
        [Test]
        public void GetTypedCollection()
        {
            DocumentCollection list = (DocumentCollection) dataMapper.QueryForList("GetTypedCollection", null); 
            Assert.AreEqual(6, list.Count);

            Book book = (Book)list[0];
            AssertBook(book, 1, "The World of Null-A", 55);

            book = (Book)list[1];
            AssertBook(book, 3, "Lord of the Rings", 3587);

            Document document = list[2];
            AssertDocument(document, 5, "Le Monde");

            document = list[3];
            AssertDocument(document, 6, "Foundation");

            Newspaper news = (Newspaper)list[4];
            AssertNewspaper(news, 2, "Le Progres de Lyon", "Lyon");

            document = list[5];
            AssertDocument(document, 4, "Le Canard enchaine");
        }

        /// <summary>
        /// Test All document with Custom Type Handler
        /// </summary>
        [Test]
        public void GetAllDocumentWithCustomTypeHandler()
        {
            IList list = dataMapper.QueryForList("GetAllDocumentWithCustomTypeHandler", null);

            Assert.AreEqual(6, list.Count);
            Book book = (Book)list[0];
            AssertBook(book, 1, "The World of Null-A", 55);

            book = (Book)list[1];
            AssertBook(book, 3, "Lord of the Rings", 3587);

            Newspaper news = (Newspaper)list[2];
            AssertNewspaper(news, 5, "Le Monde", "Paris");

            book = (Book)list[3];
            AssertBook(book, 6, "Foundation", 557);

            news = (Newspaper)list[4];
            AssertNewspaper(news, 2, "Le Progres de Lyon", "Lyon");

            news = (Newspaper)list[5];
            AssertNewspaper(news, 4, "Le Canard enchaine", "Paris");
        }

        private void AssertDocument(Document document, int id, string title)
        {
            Assert.AreEqual(id, document.Id);
            Assert.AreEqual(title, document.Title);
        }

        private void AssertBook(Book book, int id, string title, int pageNumber)
        {
            Assert.AreEqual(id, book.Id);
            Assert.AreEqual(title, book.Title);
            Assert.AreEqual(pageNumber, book.PageNumber);
        }

        private void AssertNewspaper(Newspaper news, int id, string title, string city)
        {
            Assert.AreEqual(id, news.Id);
            Assert.AreEqual(title, news.Title);
            Assert.AreEqual(city, news.City);
        }

        /// <summary>
        /// Verify that the input account is equal to the account(id=1).
        /// </summary>
        /// <param name="account">An account object</param>
        protected void AssertAccount1(Account account)
        {
            Assert.AreEqual(1, account.Id, "account.Id");
            Assert.AreEqual("Joe", account.FirstName, "account.FirstName");
            Assert.AreEqual("Dalton", account.LastName, "account.LastName");
            Assert.AreEqual("Joe.Dalton@somewhere.com", account.EmailAddress, "account.EmailAddress");
        }
    }
}
