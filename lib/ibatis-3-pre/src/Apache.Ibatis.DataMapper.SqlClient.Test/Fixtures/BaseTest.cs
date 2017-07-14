using System;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Reflection;
using Apache.Ibatis.Common.Data;
using Apache.Ibatis.Common.Logging;
using Apache.Ibatis.Common.Resources;
using Apache.Ibatis.Common.Utilities;
using Apache.Ibatis.DataMapper.Configuration;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config.Xml;
using Apache.Ibatis.DataMapper.Session;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;
using Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Modules;
using NUnit.Framework;
// DataSource definition
    // ScriptRunner definition

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures
{
    public delegate string KeyConvert(string key);

    /// <summary>
    /// Summary description for BaseTest.
    /// </summary>
    [TestFixture]
    public abstract class BaseTest : ScriptBase
    {
        /// <summary>
        /// The sqlMap
        /// </summary>
        protected static IDataMapper dataMapper = null;
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected static KeyConvert ConvertKey = null;
        protected static ISessionFactory sessionFactory = null;
        protected ISessionStore sessionStore = null;
        protected ConfigurationSetting configurationSetting;

        /// <summary>
        /// Initialize an sqlMap
        /// </summary>
        [TestFixtureSetUp]
        protected virtual void SetUpFixture()
        {
            //DateTime start = DateTime.Now;

            configurationSetting = new ConfigurationSetting();
            configurationSetting.Properties.Add("collection2Namespace", "Apache.Ibatis.DataMapper.SqlClient.Test.Domain.LineItemCollection2, Apache.Ibatis.DataMapper.SqlClient.Test");
            configurationSetting.Properties.Add("nullableInt", "int?");

            string resource = "sqlmap.config";

            try
            {
                IConfigurationEngine engine = new DefaultConfigurationEngine(configurationSetting);
                engine.RegisterInterpreter(new XmlConfigurationInterpreter(resource));
                engine.RegisterModule(new AliasModule());

                IMapperFactory mapperFactory = engine.BuildMapperFactory();
                sessionFactory = engine.ModelStore.SessionFactory;
                dataMapper = ((IDataMapperAccessor)mapperFactory).DataMapper;
                sessionStore = ((IModelStoreAccessor) dataMapper).ModelStore.SessionStore;
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

            if (sessionFactory.DataSource.DbProvider.Id.IndexOf("PostgreSql") >= 0)
            {
                ConvertKey = new KeyConvert(Lower);
            }
            else if (sessionFactory.DataSource.DbProvider.Id.IndexOf("oracle") >= 0)
            {
                ConvertKey = new KeyConvert(Upper);
            }
            else
            {
                ConvertKey = new KeyConvert(Normal);
            }

            //			string loadTime = DateTime.Now.Subtract(start).ToString();
            //			Console.WriteLine("Loading configuration time :"+loadTime);
        }

        /// <summary>
        /// Dispose the SqlMap
        /// </summary>
        [TestFixtureTearDown]
        protected virtual void TearDownFixture()
        {
            dataMapper = null;
        }

        protected static string Normal(string key)
        {
            return key;
        }

        protected static string Upper(string key)
        {
            return key.ToUpper();
        }

        protected static string Lower(string key)
        {
            return key.ToLower();
        }

        /// <summary>
        /// Configure the SqlMap
        /// </summary>
        /// <remarks>
        /// Must verify ConfigureHandler signature.
        /// </remarks>
        /// <param name="obj">
        /// The reconfigured sqlMap.
        /// </param>
        protected static void Configure(object obj)
        {
            dataMapper = null;//(SqlMapper) obj;
        }

        /// <summary>
        /// Run a sql batch for the datasource.
        /// </summary>
        /// <param name="datasource">The datasource.</param>
        /// <param name="script">The sql batch</param>
        public static void InitScript(IDataSource datasource, string script)
        {
            InitScript(datasource, script, true);
        }

        /// <summary>
        /// Run a sql batch for the datasource.
        /// </summary>
        /// <param name="datasource">The datasource.</param>
        /// <param name="script">The sql batch</param>
        /// <param name="doParse">parse out the statements in the sql script file.</param>
        protected static void InitScript(IDataSource datasource, string script, bool doParse)
        {
            ScriptRunner runner = new ScriptRunner();

            runner.RunScript(datasource, script, doParse);
        }

        /// <summary>
        /// Create a new account with id = 6
        /// </summary>
        /// <returns>An account</returns>
        protected Account NewAccount6()
        {
            Account account = new Account();
            account.Id = 6;
            account.FirstName = "Calamity";
            account.LastName = "Jane";
            account.EmailAddress = "no_email@provided.com";
            return account;
        }

        /// <summary>
        /// Verify that the input account is equal to the account(id=1).
        /// </summary>
        /// <param name="account">An account object</param>
        protected void AssertGilles(Account account)
        {
            Assert.AreEqual(5, account.Id, "account.Id");
            Assert.AreEqual("Gilles", account.FirstName, "account.FirstName");
            Assert.AreEqual("Bayon", account.LastName, "account.LastName");
            Assert.AreEqual("gilles.bayon@nospam.org", account.EmailAddress, "account.EmailAddress");
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

        protected void AssertAccount2(Account account)
        {
            Assert.AreEqual(2, account.Id, "account.Id");
            Assert.AreEqual("Averel", account.FirstName, "account.FirstName");
            Assert.AreEqual("Dalton", account.LastName, "account.LastName");
            Assert.AreEqual("Averel.Dalton@somewhere.com", account.EmailAddress, "account.EmailAddress");
        }

        /// <summary>
        /// Verify that the input account is equal to the account(id=1).
        /// </summary>
        /// <param name="account">An account as hashtable</param>
        protected void AssertAccount1AsHashtable(Hashtable account)
        {
            Assert.AreEqual(1, (int)account["Id"], "account.Id");
            Assert.AreEqual("Joe", (string)account["FirstName"], "account.FirstName");
            Assert.AreEqual("Dalton", (string)account["LastName"], "account.LastName");
            Assert.AreEqual("Joe.Dalton@somewhere.com", (string)account["EmailAddress"], "account.EmailAddress");
        }

        /// <summary>
        /// Verify that the input account is equal to the account(id=1).
        /// </summary>
        /// <param name="account">An account as hashtable</param>
        protected void AssertAccount1AsHashtableForResultClass(Hashtable account)
        {
            Assert.AreEqual(1, (int)account[ConvertKey("Id")], "account.Id");
            Assert.AreEqual("Joe", (string)account[ConvertKey("FirstName")], "account.FirstName");
            Assert.AreEqual("Dalton", (string)account[ConvertKey("LastName")], "account.LastName");
            Assert.AreEqual("Joe.Dalton@somewhere.com", (string)account[ConvertKey("EmailAddress")], "account.EmailAddress");
        }

        /// <summary>
        /// Verify that the input account is equal to the account(id=6).
        /// </summary>
        /// <param name="account">An account object</param>
        protected void AssertAccount6(Account account)
        {
            Assert.AreEqual(6, account.Id, "account.Id");
            Assert.AreEqual("Calamity", account.FirstName, "account.FirstName");
            Assert.AreEqual("Jane", account.LastName, "account.LastName");
            Assert.IsNull(account.EmailAddress, "account.EmailAddress");
        }

        /// <summary>
        /// Verify that the input order is equal to the order(id=1).
        /// </summary>
        /// <param name="order">An order object.</param>
        protected void AssertOrder1(Order order)
        {
            DateTime date = new DateTime(2003, 2, 15, 8, 15, 00);

            Assert.AreEqual(1, order.Id, "order.Id");
            Assert.AreEqual(date.ToString(), order.Date.ToString(), "order.Date");
            Assert.AreEqual("VISA", order.CardType, "order.CardType");
            Assert.AreEqual("999999999999", order.CardNumber, "order.CardNumber");
            Assert.AreEqual("05/03", order.CardExpiry, "order.CardExpiry");
            Assert.AreEqual("11 This Street", order.Street, "order.Street");
            Assert.AreEqual("Victoria", order.City, "order.City");
            Assert.AreEqual("BC", order.Province, "order.Id");
            Assert.AreEqual("C4B 4F4", order.PostalCode, "order.PostalCode");
        }

        /// <summary>
        /// Verify that the input order is equal to the order(id=1).
        /// </summary>
        /// <param name="order">An order as hashtable.</param>
        protected void AssertOrder1AsHashtable(Hashtable order)
        {
            DateTime date = new DateTime(2003, 2, 15, 8, 15, 00);

            Assert.AreEqual(1, (int)order["Id"], "order.Id");
            Assert.AreEqual(date.ToString(), ((DateTime)order["Date"]).ToString(), "order.Date");
            Assert.AreEqual("VISA", (string)order["CardType"], "order.CardType");
            Assert.AreEqual("999999999999", (string)order["CardNumber"], "order.CardNumber");
            Assert.AreEqual("05/03", (string)order["CardExpiry"], "order.CardExpiry");
            Assert.AreEqual("11 This Street", (string)order["Street"], "order.Street");
            Assert.AreEqual("Victoria", (string)order["City"], "order.City");
            Assert.AreEqual("BC", (string)order["Province"], "order.Id");
            Assert.AreEqual("C4B 4F4", (string)order["PostalCode"], "order.PostalCode");
        }
    }
}