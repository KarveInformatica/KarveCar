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
    public class ParameterMapModuleTest
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
                engine.RegisterModule(new AccountModule());
                engine.RegisterModule(new DocumentModule());

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
        /// Test null replacement in ParameterMap property
        /// </summary>
        [Test]
        public void NullValue_should_be_replaced()
        {
            Account account = NewAccount6();

            dataMapper.Insert("InsertAccountViaParameterMap", account);

            account = (Account)dataMapper.QueryForObject("GetAccountNullableEmail", 6);

            AssertAccount6(account);
        }

        /// <summary>
        /// Create a new account with id = 6
        /// </summary>
        /// <returns>An account</returns>
        private Account NewAccount6()
        {
            Account account = new Account();
            account.Id = 6;
            account.FirstName = "Calamity";
            account.LastName = "Jane";
            account.EmailAddress = "no_email@provided.com";
            return account;
        }

        /// <summary>
        /// Verify that the input account is equal to the account(id=6).
        /// </summary>
        /// <param name="account">An account object</param>
        private void AssertAccount6(Account account)
        {
            Assert.That(account.Id, Is.EqualTo(6), "account.Id");
            Assert.That(account.FirstName, Is.EqualTo("Calamity"), "account.FirstName");
            Assert.That(account.LastName, Is.EqualTo("Jane"), "account.LastName");
            Assert.That(account.EmailAddress, Is.Null, "account.EmailAddress");
        }
    }
}
