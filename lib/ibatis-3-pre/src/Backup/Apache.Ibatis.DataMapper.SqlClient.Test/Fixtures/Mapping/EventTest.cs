using System;
using Apache.Ibatis.Common.Resources;
using Apache.Ibatis.DataMapper.Configuration;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config.Xml;
using Apache.Ibatis.DataMapper.MappedStatements;
using Apache.Ibatis.DataMapper.Model.Events;
using Apache.Ibatis.DataMapper.Model.ResultMapping;
using Apache.Ibatis.DataMapper.Session;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;
using Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Modules;
using NUnit.Framework;


namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping
{
    [TestFixture]
    public class EventTest :ScriptBase 
    {
        private IDataMapper dataMapper = null;
        private ISessionFactory sessionFactory = null;

        [TestFixtureSetUp]
        public void SetUpFixture()
        {
            string uri = "file://~/SqlMap.event.config";
            IResource resource = ResourceLoaderRegistry.GetResource(uri);

            ConfigurationSetting setting = new ConfigurationSetting();
            IConfigurationEngine engine = new DefaultConfigurationEngine(setting);
            engine.RegisterInterpreter(new XmlConfigurationInterpreter(resource));
            engine.RegisterModule(new EventModule());

            IMapperFactory mapperFactory = engine.BuildMapperFactory();
            sessionFactory = engine.ModelStore.SessionFactory;
            dataMapper = ((IDataMapperAccessor)mapperFactory).DataMapper;
        }

        /// <summary>
        /// SetUp
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            InitScript(sessionFactory.DataSource, scriptDirectory + "account-init.sql");
            InitScript(sessionFactory.DataSource, scriptDirectory + "documents-init.sql");
        }


        [Test]
        public void PreSelectEvent_must_be_fired()
        {
            IMappedStatement statement = ((IModelStoreAccessor)dataMapper).ModelStore.GetMappedStatement("SelectAccount");
            Assert.That(statement, Is.Not.Null);
            statement.PreSelect+= PreSelectEventHandler;

            Account account = dataMapper.QueryForObject<Account>("SelectAccount", 1);
            Assert.That(account, Is.Not.Null);
            Assert.That(account.Id, Is.EqualTo(2));

            statement.PreSelect -= PreSelectEventHandler;
        }

        private static void PreSelectEventHandler(object src, PreStatementEventArgs evnt)
        {
            Assert.That(((IMappedStatement)src).Id, Is.EqualTo("SelectAccount"));
            evnt.ParameterObject = ((int)evnt.ParameterObject) +1;
        }


        [Test]
        public void PostSelectEventListener_must_be_fired()
        {
            IMappedStatement statement = ((IModelStoreAccessor)dataMapper).ModelStore.GetMappedStatement("SelectAccount");
            Assert.That(statement, Is.Not.Null);
            statement.PostSelect += PostSelectEventHandler;

            Account account = dataMapper.QueryForObject<Account>("SelectAccount", 1);
            Assert.That(account, Is.Not.Null);
            Assert.That(account.Id, Is.EqualTo(99));

            statement.PostSelect -= PostSelectEventHandler;
        }

        private static void PostSelectEventHandler(object src, PostStatementEventArgs evnt)
        {
            Assert.That(((IMappedStatement)src).Id, Is.EqualTo("SelectAccount"));
            Account account = (Account)evnt.ResultObject;
            account.Id = 99;
        }

        
        [Test]
        public void PreInsertEventListener_must_be_fired()
        {
            IMappedStatement statement = statement = ((IModelStoreAccessor)dataMapper).ModelStore.GetMappedStatement("InsertAccount");
            Assert.That(statement, Is.Not.Null);
            statement.PreInsert += PreInsertEventHandler;
            
            Account account = new Account();
            account.Id = 6;
            account.FirstName = "Calamity";
            account.LastName = "Jane";
            account.EmailAddress = "no_email@provided.com";

            dataMapper.Insert("InsertAccount", account);

            account = dataMapper.QueryForObject<Account>("SelectAccount", 6);

            Assert.That(account, Is.Not.Null);
            Assert.That(account.Id, Is.EqualTo(6));
            Assert.That(account.FirstName, Is.EqualTo("Calamity"));
            Assert.That(account.LastName, Is.EqualTo("Jane"));
            Assert.That(account.EmailAddress, Is.EqualTo("pre.insert.email@noname.org"));

            statement.PreInsert -= PreInsertEventHandler;
        }

        private static void PreInsertEventHandler(object src, PreStatementEventArgs evnt)
        {
            Assert.That(((IMappedStatement)src).Id, Is.EqualTo("InsertAccount"));
            Account account = (Account)evnt.ParameterObject;
            account.EmailAddress = "pre.insert.email@noname.org";
        }

        
        [Test]
        public void PostInsertEventListener_must_be_fired()
        {
            IMappedStatement statement = ((IModelStoreAccessor)dataMapper).ModelStore.GetMappedStatement("InsertAccount");
            Assert.That(statement, Is.Not.Null);
            statement.PostInsert += PostInsertEventHandler;

            Account account = new Account();
            account.Id = 6;
            account.FirstName = "Calamity";
            account.LastName = "Jane";
            account.EmailAddress = "no_email@provided.com";

            int id = (int)dataMapper.Insert("InsertAccount", account);

            Assert.That(id, Is.EqualTo(999));
            Assert.That(account.Id, Is.EqualTo(99));

            statement.PostInsert -= PostInsertEventHandler;

        }

        private static void PostInsertEventHandler(object src, PostStatementEventArgs evnt)
        {
            Assert.That(((IMappedStatement)src).Id, Is.EqualTo("InsertAccount"));
            Account account = (Account)evnt.ParameterObject;
            account.Id = 99;
            evnt.ResultObject = 999;
        }
      

        [Test]
        public void PreUpdateOrDeleteEventListener_must_be_fired()
        {
            IMappedStatement statement =  ((IModelStoreAccessor)dataMapper).ModelStore.GetMappedStatement("UpdateAccount");
            statement.PreUpdateOrDelete += PreUpdateOrDeleteEventHandler;
            
            Account account = dataMapper.QueryForObject<Account>("SelectAccount", 1);
            account.EmailAddress = "To.Be.Replace@noname.org";

            dataMapper.Update("UpdateAccount", account);

            account = dataMapper.QueryForObject<Account>("SelectAccount", 1);

            Assert.That(account, Is.Not.Null);
            Assert.That(account.Id, Is.EqualTo(1));
            Assert.That(account.EmailAddress, Is.EqualTo("Pre.Update.Or.Delete.Event@noname.org"));

            statement.PreUpdateOrDelete -= PreUpdateOrDeleteEventHandler;
        }

        private static void PreUpdateOrDeleteEventHandler(object src, PreStatementEventArgs evnt)
        {
            Assert.That(((IMappedStatement)src).Id, Is.EqualTo("UpdateAccount"));
            Account account = (Account)evnt.ParameterObject;
            account.EmailAddress = "Pre.Update.Or.Delete.Event@noname.org";
        }

        [Test]
        public void PostUpdateOrDeleteEventListener_must_be_fired()
        {
            IMappedStatement statement = ((IModelStoreAccessor)dataMapper).ModelStore.GetMappedStatement("UpdateAccount");
            statement.PostUpdateOrDelete += PostUpdateOrDeleteEventHandler;

            Account account = dataMapper.QueryForObject<Account>("SelectAccount", 1);

            int id = dataMapper.Update("UpdateAccount", account);

            Assert.That(id, Is.EqualTo(999));
            Assert.That(account.Id, Is.EqualTo(99));

            statement.PostUpdateOrDelete -= PostUpdateOrDeleteEventHandler;

        }

        private static void PostUpdateOrDeleteEventHandler(object src, PostStatementEventArgs evnt)
        {
            Assert.That(((IMappedStatement)src).Id, Is.EqualTo("UpdateAccount"));
            Account account = (Account)evnt.ParameterObject;
            account.Id = 99;
            evnt.ResultObject = 999;
        }

    
        [Test]
        public void PreCreateEventListener_must_be_fired()
        {
            IResultMap resultMap = ((IModelStoreAccessor)dataMapper).ModelStore.GetResultMap("Account.account-result-constructor");
            resultMap.PreCreate += PreCreateEventHandler;

            Account account = dataMapper.QueryForObject<Account>("SelectAccountViaConstructor", 1);

            Assert.That(account.Id, Is.EqualTo(1));
            Assert.That(account.LastName, Is.EqualTo("new lastName"));

            resultMap.PreCreate -= PreCreateEventHandler;
        }

        private static void PreCreateEventHandler(object src, PreCreateEventArgs evnt)
        {
            Assert.That(((IResultMap)src).Id, Is.EqualTo("Account.account-result-constructor"));
            evnt.Parameters[evnt.Parameters.Length - 1] = "new lastName";
        }

        [Test]
        public void PostCreateEventListener_must_be_fired()
        {
            IResultMap resultMap = ((IModelStoreAccessor)dataMapper).ModelStore.GetResultMap("Account.account-result-constructor");
            resultMap.PostCreate += PostCreateEventHandler;

            Account account = dataMapper.QueryForObject<Account>("SelectAccountViaConstructor", 1);

            Assert.That(account.Id, Is.EqualTo(1234));
            Assert.That(account.LastName, Is.EqualTo("New LastName"));
            Assert.That(account.FirstName, Is.EqualTo("New FirstName"));

            resultMap.PostCreate -= PostCreateEventHandler;
        }

        private static void PostCreateEventHandler(object src, PostCreateEventArgs evnt)
        {
            Assert.That(((IResultMap)src).Id, Is.EqualTo("Account.account-result-constructor"));
            Account account = (Account)evnt.Instance;
            account.Id = 1234;
            account.FirstName = "New FirstName";
            account.LastName = "New LastName";
        }
  
        [Test]
        public void PrePropertyEventListener_must_be_fired()
        {
            IResultMap resultMap = ((IModelStoreAccessor)dataMapper).ModelStore.GetResultMap("Account.account-result");
            ResultProperty resultProperty = resultMap.Properties.FindByPropertyName("FirstName");

            resultProperty.PreProperty += PreCreateEventHandler;

            Account account = dataMapper.QueryForObject<Account>("SelectAccount", 1);

            Assert.That(account.Id, Is.EqualTo(1));
            Assert.That(account.FirstName, Is.EqualTo("No Name"));
            Assert.That(account.LastName, Is.EqualTo("Dalton"));

            resultProperty.PreProperty -= PreCreateEventHandler;
        }

        private static void PreCreateEventHandler(object src, PrePropertyEventArgs evnt)
        {
            Assert.That(((ResultProperty)src).PropertyName, Is.EqualTo("FirstName"));
            evnt.DataBaseValue = "No Name";
        }

  
        [Test]
        public void PostPropertyEventListener_must_be_fired()
        {
            IResultMap resultMap = ((IModelStoreAccessor)dataMapper).ModelStore.GetResultMap("Account.account-result-with-document");
            ResultProperty resultProperty = resultMap.Properties.FindByPropertyName("Document");

            resultProperty.PostProperty += PostCreateEventHandler;

            Account account = dataMapper.QueryForObject<Account>("SelectAccountWithDocument", 1);
            Assert.That(account.Id, Is.EqualTo(1));
            Assert.That(account.Document, Is.Not.Null);
            Assert.That(account.Document.Id, Is.EqualTo(55));

            resultProperty.PostProperty -= PostCreateEventHandler;
        }

        private static void PostCreateEventHandler(object src, PostPropertyEventArgs evnt)
        {
            Assert.That(((ResultProperty)src).PropertyName, Is.EqualTo("Document"));
            Account account = (Account)evnt.Target;

            Assert.That(account.Document, Is.Null);

            account.Document = new Document();
            account.Document.Id = 55;
        }
    }
}
