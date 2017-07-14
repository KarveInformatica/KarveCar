using System;
using System.Collections;
using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.Common.Resources;
using Apache.Ibatis.DataMapper.Configuration;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config.Xml;
using Apache.Ibatis.DataMapper.Configuration.Module;
using Apache.Ibatis.DataMapper.Session.Stores;
using NUnit.Framework;

using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;
using System.Collections.Generic;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures
{
    [TestFixture] 
    public class DefaultConfigurationEngineTest
    {
        private List<string> fileNames = new List<string>();

        private class AccountModule : Module
        {
            public override void Load()
            {
                RegisterResultMap<Category>("Category-result")
                    .MappingMember("Id").ToColumnName("Category_ID");
            }
        }

        [Test]
        public void Event_FileReourceLoad_should_be_launch()
        {
            string resource = "SqlMap_Test_Configure.config";

            IConfigurationEngine engine = new DefaultConfigurationEngine();
            engine.FileResourceLoad += FileResourceEventHandler;

            engine.RegisterInterpreter(new XmlConfigurationInterpreter(resource));
            engine.BuildMapperFactory();

            Assert.That(fileNames.Count, Is.EqualTo(6));
            Assert.Contains(resource, fileNames);
            Assert.Contains("database.config", fileNames);
            Assert.Contains("providers.config", fileNames);
            Assert.Contains("Mapping1.xml", fileNames);
            Assert.Contains("Mapping3.xml", fileNames);
            Assert.Contains("Mapping4.xml", fileNames);
        }

        private void FileResourceEventHandler(object sender, FileResourceLoadEventArgs evnt)
        {
            fileNames.Add(evnt.FileInfo.Name);
        }

        [Test]
        public void ResultMap_configuration_via_code_should_override_file_configuration()
        {
            string uri = "assembly://Apache.Ibatis.DataMapper.SqlClient.Test/bin.Debug/SqlMap_Test_Configure.config";
            IResource resource = ResourceLoaderRegistry.GetResource(uri);

            // Before have 4 properties
            IConfigurationEngine engine = new DefaultConfigurationEngine();
            engine.RegisterInterpreter(new XmlConfigurationInterpreter(resource));

            engine.BuildMapperFactory();
            IConfiguration resultMap = engine.ConfigurationStore.GetResultMapConfiguration("Account.Category-result");
            Assert.That(resultMap.Children.Count, Is.EqualTo(3));

            // With code configuration override have only 1 properties
            engine = new DefaultConfigurationEngine();
            engine.RegisterInterpreter(new XmlConfigurationInterpreter(resource));
            engine.RegisterModule(new AccountModule());

            engine.BuildMapperFactory();

            resultMap = engine.ConfigurationStore.GetResultMapConfiguration("Account.Category-result");
            Assert.That(resultMap.Children.Count, Is.EqualTo(1));
        }

        /// <summary>
        /// Test Extended ResultMap
        /// </summary>
        [Test]
        public void Should_contains_ResultMap_DocumentBook_with_5_properties()
        {
            string uri = "assembly://Apache.Ibatis.DataMapper.SqlClient.Test/bin.Debug/SqlMap_Test_Configure.config";
            IResource resource = ResourceLoaderRegistry.GetResource(uri);

            IConfigurationEngine engine = new DefaultConfigurationEngine();
            engine.RegisterInterpreter(new XmlConfigurationInterpreter(resource));

            engine.BuildMapperFactory();

            IConfiguration resultMap = engine.ConfigurationStore.GetResultMapConfiguration("Document.book");
            Assert.That(resultMap.Children.Count, Is.EqualTo(4));

            //Console.WriteLine(engine.ModelStore.ToString());
        }

        /// <summary>
        /// Test  Extended ParameterMap
        /// </summary>
        [Test]
        public void Should_contains_ParameterMap_OrderInsertExtend_with_10_properties()
        {
            string uri = "assembly://Apache.Ibatis.DataMapper.SqlClient.Test/bin.Debug/SqlMap_Test_Configure.config";
            IResource resource = ResourceLoaderRegistry.GetResource(uri);

            IConfigurationEngine engine = new DefaultConfigurationEngine();
            engine.RegisterInterpreter(new XmlConfigurationInterpreter(resource));

            engine.BuildMapperFactory();

            IConfiguration parameterMap = engine.ConfigurationStore.GetParameterMapConfiguration("Order.insert-extend");
            Assert.That(parameterMap.Children.Count, Is.EqualTo(10));

            int index = parameterMap.Children.FindIndex(
                delegate(IConfiguration paramater)
                    { return paramater.Id == "CardNumber"; }
                );
            Assert.That(index, Is.EqualTo(5));

            //Console.WriteLine(engine.ConfigurationStore);
        }

        /// <summary>
        /// Test  Extended Statement
        /// </summary>
        [Test]
        public void Should_contains_statement_GetAllAccountsOrderByName_with_2_child()
        {
            string uri = "assembly://Apache.Ibatis.DataMapper.SqlClient.Test/bin.Debug/SqlMap_Test_Configure.config";
            IResource resource = ResourceLoaderRegistry.GetResource(uri);

            IConfigurationEngine engine = new DefaultConfigurationEngine();
            engine.RegisterInterpreter(new XmlConfigurationInterpreter(resource));

            engine.BuildMapperFactory();

            IConfiguration statement = engine.ConfigurationStore.GetStatementConfiguration("GetAllAccountsOrderByName");
            Assert.That(statement.Children.Count, Is.EqualTo(2));

            //Console.WriteLine(engine.ConfigurationStore);
        }

        /// <summary>
        /// Test HybridWebThreadSessionStore
        /// </summary>
        [Test]
        public void Can_plug_HybridWebThreadSessionStore()
        {
            string uri = "assembly://Apache.Ibatis.DataMapper.SqlClient.Test/bin.Debug/SqlMap_Test_Configure.config";
            IResource resource = ResourceLoaderRegistry.GetResource(uri);

            ConfigurationSetting setting = new ConfigurationSetting();
            setting.SessionStore = new HybridWebThreadSessionStore("test");
            setting.ValidateMapperConfigFile = true;

            IConfigurationEngine engine = new DefaultConfigurationEngine(setting);
            engine.RegisterInterpreter(new XmlConfigurationInterpreter(resource));

            IMapperFactory mapperFactory = engine.BuildMapperFactory();
            IDataMapper dataMapper = ((IDataMapperAccessor)mapperFactory).DataMapper;

            Account account = dataMapper.QueryForObject<Account>("GetAccountViaResultClass", 1);

            Assert.AreEqual(1, account.Id, "account.Id");
            Assert.AreEqual("Joe", account.FirstName, "account.FirstName");
            Assert.AreEqual("Dalton", account.LastName, "account.LastName");
            Assert.AreEqual("Joe.Dalton@somewhere.com", account.EmailAddress, "account.EmailAddress");
        }
	    
    }
}