using System;
using System.Xml;
using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.Common.Data;
using Apache.Ibatis.Common.Resources;
using Apache.Ibatis.DataMapper.Configuration;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config.Xml;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config.Xml.Processor;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;
using NUnit.Framework;


namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures
{
    /// <summary>
    /// Description résumée de ConfigureTest.
    /// </summary>
    [TestFixture] 
    public class ConfigureTest  
    {
        #region SetUp

        /// <summary>
        /// SetUp
        /// </summary>
        [SetUp] 
        public void Init() 
        {

        }
        #endregion 
	    
        [Test]
        public void JsonInterpreter_test()
        {
            IConfigurationStore store = new DefaultConfigurationStore();
            string uri = "SqlMap.config.Json";
            IResource resource = ResourceLoaderRegistry.GetResource(uri);

            IConfigurationInterpreter interpreter = new JsonInterpreter(resource);

            interpreter.ProcessResource(store);
        }


        /// <summary>
        /// Test XmlProcessorTest
        /// </summary>
        [Test]
        public void XmlProcessorTest()
        {
            using (XmlTextReader reader = new XmlTextReader("SqlMap_Test_Configure.config"))
            {
                IConfigurationStore store = new DefaultConfigurationStore();

                using (XmlConfigProcessor processor = new XmlConfigProcessor())
                {
                    processor.Process(reader, store);

                    CheckResource(store);
                }
            }
        }

        /// <summary>
        /// Test XmlConfigurationInterpreter via FilePath
        /// </summary>
        [Test]
        public void Test_XmlConfigurationInterpreter_via_FilePath()
        {
            string uri = "SqlMap_Test_Configure.config";
            IConfigurationStore store = new DefaultConfigurationStore();

            IConfigurationInterpreter interpreter = new XmlConfigurationInterpreter(uri);

            interpreter.ProcessResource(store);

            CheckResource(store);
        }

        /// <summary>
        /// Test XmlConfigurationInterpreter Via FilePath WithoutProtocol
        /// </summary>
        [Test]
        public void Test_XmlConfigurationInterpreter_via_FilePath_WithoutProtocol()
        {
            string uri ="SqlMap_Test_Configure.config";
            IConfigurationStore store = new DefaultConfigurationStore();

            IConfigurationInterpreter interpreter = new XmlConfigurationInterpreter(
                ResourceLoaderRegistry.GetResource(uri));

            interpreter.ProcessResource(store);

            CheckResource(store);
        }

        /// <summary>
        /// Test XmlConfigurationInterpreter Via FilePath WithProtocol
        /// </summary>
        [Test]
        public void Test_XmlConfigurationInterpreter_via_FilePath_WithProtocol()
        {
            string uri = "file://SqlMap_Test_Configure.config";
            IConfigurationStore store = new DefaultConfigurationStore();

            IConfigurationInterpreter interpreter = new XmlConfigurationInterpreter(
                ResourceLoaderRegistry.GetResource(uri));

            interpreter.ProcessResource(store);

            CheckResource(store);
        }

        /// <summary>
        /// Test XmlConfigurationInterpreter Via AssemblyUri
        /// </summary>
        [Test]
        public void Test_XmlConfigurationInterpreter_via_AssemblyUri()
        {
            string uri = "assembly://Apache.Ibatis.DataMapper.SqlClient.Test/bin.Debug/SqlMap_Test_Configure.config";

            IConfigurationStore store = new DefaultConfigurationStore();

            IConfigurationInterpreter interpreter = new XmlConfigurationInterpreter(
                ResourceLoaderRegistry.GetResource(uri));

            interpreter.ProcessResource(store);

            CheckResource(store);
        }

        /// <summary>
        /// Test DefaultConfigurationEngine via Assembly Resource
        /// </summary>
        [Test]
        public void Test_DefaultConfigurationEngine_via_Assembly_Resource()
        {
            string uri = "assembly://Apache.Ibatis.DataMapper.SqlClient.Test/bin.Debug/SqlMap_Test_Configure.config";
            IResource resource = ResourceLoaderRegistry.GetResource(uri);

            IConfigurationEngine engine = new DefaultConfigurationEngine();
            engine.RegisterInterpreter(new XmlConfigurationInterpreter(resource));

            engine.BuildMapperFactory();

            CheckResource(engine.ConfigurationStore);
        }

        /// <summary>
        /// Test DefaultConfigurationEngine via File Resource
        /// </summary>
        [Test]
        public void Test_DefaultConfigurationEngine_via_File_Resource()
        {
            string uri = "file://~/SqlMap_Test_Configure.config";
            IResource resource = ResourceLoaderRegistry.GetResource(uri);

            IConfigurationEngine engine = new DefaultConfigurationEngine();
            engine.RegisterInterpreter(new XmlConfigurationInterpreter(resource));

            engine.BuildMapperFactory();

            CheckResource(engine.ConfigurationStore);
        }

        private void CheckResource(IConfigurationStore store)
        {
            Console.WriteLine(store.ToString());

            Assert.That(store.Properties.Length, Is.EqualTo(14));
            Assert.That(store.GetPropertyConfiguration("useStatementNamespaces").Value, Is.EqualTo("false"));

            Assert.That(store.Settings.Count, Is.EqualTo(4));
            Assert.That(store.GetSettingConfiguration("validateSqlMap").Value, Is.EqualTo("false"));

            Assert.That(store.Providers.Length, Is.EqualTo(17));
            IConfiguration informixProvider = store.GetProviderConfiguration("Informix");
            Assert.That(informixProvider.Attributes["description"], Is.EqualTo("Informix NET Provider, 2.81.0.0"));
            Assert.That(informixProvider.Attributes["commandBuilderClass"], Is.EqualTo("IBM.Data.Informix.IfxCommandBuilder"));

            Assert.That(store.Databases.Length, Is.EqualTo(1));
            Assert.That(store.Databases[0].Children.Count, Is.EqualTo(2));

            IConfiguration provider = store.Databases[0].Children.Find(DataConstants.ELEMENT_PROVIDER)[0];
            Assert.That(provider, Is.Not.Null);
            Assert.That(provider.Attributes[DataConstants.ATTRIBUTE_NAME], Is.EqualTo("sqlServer2.0"));
            Assert.That(provider.Id, Is.EqualTo("sqlServer2.0"));
            Assert.That(provider.Value, Is.EqualTo("sqlServer2.0"));
            Assert.That(provider.Type, Is.EqualTo(DataConstants.ELEMENT_PROVIDER));

            IConfiguration datasource = store.Databases[0].Children.Find(DataConstants.ELEMENT_DATASOURCE)[0];
            Assert.That(datasource, Is.Not.Null);
            Assert.That(datasource.Value.StartsWith("data source="));
            Assert.That(datasource.Type, Is.EqualTo(DataConstants.ELEMENT_DATASOURCE));

            Assert.That(store.Alias.Length, Is.EqualTo(12));
            Assert.That(store.GetAliasConfiguration("Account").Value, Is.EqualTo("Apache.Ibatis.DataMapper.SqlClient.Test.Domain.Account, Apache.Ibatis.DataMapper.SqlClient.Test"));

            Assert.That(store.TypeHandlers.Length, Is.EqualTo(2));
            Assert.That(store.GetTypeHandlerConfiguration("bool").Attributes.Count, Is.EqualTo(3));
            Assert.That(store.GetTypeHandlerConfiguration("string").Attributes.Count, Is.EqualTo(2));

            // Cache model
            Assert.That(store.CacheModels.Length, Is.EqualTo(2));
            IConfiguration cacheModel = store.CacheModels[0];
            Assert.That(cacheModel.Children.Count, Is.EqualTo(2));
            Assert.That(cacheModel.Attributes.ContainsKey(ConfigConstants.ATTRIBUTE_NAMESPACE), Is.True);

            // Result map
            Assert.That(store.ResultMaps.Length, Is.EqualTo(16));
            IConfiguration resultMap = store.GetResultMapConfiguration("Account.account-result-constructor");
            Assert.IsNotNull(resultMap);
            Assert.That(resultMap.Children.Count, Is.EqualTo(4));

            IConfiguration constructor = resultMap.Children.Find(ConfigConstants.ELEMENT_CONSTRUCTOR)[0];
            Assert.IsNotNull(constructor);
            Assert.That(constructor.Children.Count, Is.EqualTo(3));

            ConfigurationCollection arguments = constructor.Children.Find(ConfigConstants.ELEMENT_ARGUMENT);

            Assert.IsNotEmpty(arguments);
            Assert.That(arguments.Count, Is.EqualTo(3));
            Assert.That(arguments[0].Attributes[ConfigConstants.ATTRIBUTE_ARGUMENTNAME], Is.EqualTo("identifiant"));

            ConfigurationCollection results = resultMap.Children.Find(ConfigConstants.ELEMENT_RESULT);
            Assert.IsNotEmpty(results);
            Assert.That(results.Count, Is.EqualTo(3));
            Assert.That(results[0].Attributes[ConfigConstants.ATTRIBUTE_PROPERTY], Is.EqualTo("EmailAddress"));

            // Parameter map
            Assert.That(store.ParameterMaps.Length, Is.EqualTo(11));
            IConfiguration parameterMap = store.GetParameterMapConfiguration("Account.insert-params");
            Assert.IsNotNull(parameterMap);
            Assert.That(parameterMap.Children.Count, Is.EqualTo(6));

            ConfigurationCollection parameters = parameterMap.Children.Find(ConfigConstants.ELEMENT_PARAMETER);

            Assert.IsNotEmpty(parameters);
            Assert.That(parameters.Count, Is.EqualTo(6));
            Assert.That(parameters[4].Attributes.Count, Is.EqualTo(4));
            Assert.That(parameters[3].Attributes[ConfigConstants.ATTRIBUTE_PROPERTY], Is.EqualTo("EmailAddress"));

            // sql statement in Mapping2.xml
            Assert.That(store.Statements.Length, Is.EqualTo(97));
            IConfiguration sqlStatement = store.GetStatementConfiguration("includeComplex");
            Assert.IsNotNull(sqlStatement);
            Assert.That(sqlStatement.Attributes.ContainsKey(ConfigConstants.ATTRIBUTE_NAMESPACE), Is.True);

            Assert.That(sqlStatement.Children.Count, Is.EqualTo(1));
            IConfiguration child = sqlStatement.Children[0];//dynamic
            Assert.That(child.Children.Count, Is.EqualTo(1));
            child = child.Children[0];//isParameterPresent
            Assert.That(child.Children.Count, Is.EqualTo(3));
            child = child.Children[1];//isNotEmpty
            Assert.That(child.Attributes.Count, Is.EqualTo(2));
            Assert.IsTrue(child.Attributes.ContainsKey("prepend"));
            Assert.IsTrue(child.Attributes.ContainsKey("property"));
            Assert.That(child.Attributes["prepend"], Is.EqualTo("and"));
            Assert.That(child.Attributes["property"], Is.EqualTo("FirstName"));
        }
    

        //#region Relatives Path tests



        ///// <summary>
        ///// Test ConfigureAndWatch via relative path
        ///// </summary>
        //[Test] 
        //public void TestConfigureAndWatchRelativePathViaBuilder()
        //{
        //    ConfigureHandler handler = new ConfigureHandler(Configure);

        //    DomSqlMapBuilder builder = new DomSqlMapBuilder();

        //    NameValueCollection properties = new NameValueCollection();
        //    properties.Add("collection2Namespace", "Apache.Ibatis.DataMapper.SqlClient.Test.Domain.LineItemCollection, Apache.Ibatis.DataMapper.SqlClient.Test");
        //    properties.Add("nullableInt", "int");

        //    builder.Properties = properties;

        //    ISqlMapper mapper = builder.ConfigureAndWatch(_fileName, handler);

        //    Assert.IsNotNull(mapper);
        //}

        ///// <summary>
        ///// Test Configure via absolute path 
        ///// </summary>
        //[Test] 
        //public void TestConfigureAndWatchAbsolutePathWithFileSuffix()
        //{
        //    _fileName = "file://" + Resources.DefaultBasePath + Path.DirectorySeparatorChar + _fileName;
        //    ConfigureHandler handler = new ConfigureHandler(Configure);

        //    DomSqlMapBuilder builder = new DomSqlMapBuilder();

        //    NameValueCollection properties = new NameValueCollection();
        //    properties.Add("collection2Namespace", "Apache.Ibatis.DataMapper.SqlClient.Test.Domain.LineItemCollection, Apache.Ibatis.DataMapper.SqlClient.Test");
        //    properties.Add("nullableInt", "int");

        //    builder.Properties = properties;

        //    ISqlMapper mapper = builder.ConfigureAndWatch(_fileName, handler);

        //    Assert.IsNotNull(mapper);
        //}

        ///// <summary>
        ///// Test Configure via absolute path 
        ///// </summary>
        //[Test] 
        //public void TestConfigureAndWatchAbsolutePathWithFileSuffixViaBuilder()
        //{
        //    _fileName = "file://" + Resources.DefaultBasePath + Path.DirectorySeparatorChar + _fileName;
        //    ConfigureHandler handler = new ConfigureHandler(Configure);

        //    DomSqlMapBuilder builder = new DomSqlMapBuilder();

        //    NameValueCollection properties = new NameValueCollection();
        //    properties.Add("collection2Namespace", "Apache.Ibatis.DataMapper.SqlClient.Test.Domain.LineItemCollection, Apache.Ibatis.DataMapper.SqlClient.Test");
        //    properties.Add("nullableInt", "int");

        //    builder.Properties = properties;

        //    ISqlMapper mapper = builder.ConfigureAndWatch(_fileName, handler);

        //    Assert.IsNotNull(mapper);
        //}

        ///// <summary>
        ///// Test Configure via absolute path via FileInfo
        ///// </summary>
        //[Test] 
        //public void TestConfigureAndWatchAbsolutePathViaFileInfo()
        //{
        //    _fileName = Resources.DefaultBasePath + Path.DirectorySeparatorChar + _fileName;
        //    FileInfo fileInfo = new FileInfo(_fileName);

        //    ConfigureHandler handler = new ConfigureHandler(Configure);

        //    DomSqlMapBuilder builder = new DomSqlMapBuilder();

        //    NameValueCollection properties = new NameValueCollection();
        //    properties.Add("collection2Namespace", "Apache.Ibatis.DataMapper.SqlClient.Test.Domain.LineItemCollection, Apache.Ibatis.DataMapper.SqlClient.Test");
        //    properties.Add("nullableInt", "int");

        //    builder.Properties = properties;

        //    ISqlMapper mapper = builder.ConfigureAndWatch(fileInfo.FullName, handler);

        //    Assert.IsNotNull(mapper);
        //}
        //#endregion 




        //private bool _hasChanged = false;

        ///// <summary>
        ///// ConfigurationWatcher Test
        ///// </summary>
        //[Test]
        //public void ConfigurationWatcherTestOnSqlMapConfig()
        //{
        //    //string fileName = @"..\..\Maps\MSSQL\SqlClient\Account.xml";

        //    ConfigureHandler handler = new ConfigureHandler(MyHandler);

        //    DomSqlMapBuilder builder = new DomSqlMapBuilder();

        //    NameValueCollection properties = new NameValueCollection();
        //    properties.Add("collection2Namespace", "Apache.Ibatis.DataMapper.SqlClient.Test.Domain.LineItemCollection, Apache.Ibatis.DataMapper.SqlClient.Test");
        //    properties.Add("nullableInt", "int");

        //    builder.Properties = properties;

        //    ISqlMapper mapper = builder.ConfigureAndWatch(_fileName, handler);

        //    // test that the mapper was correct build
        //    Assert.IsNotNull(mapper);

        //    CustomUriBuilder uriBuilder = new CustomUriBuilder(_fileName, AppDomain.CurrentDomain.BaseDirectory);

        //    using (IResource resource = new FileResource(uriBuilder.Uri))
        //    {
        //        resource.FileInfo.LastWriteTime = DateTime.Now;

        //        resource.FileInfo.Refresh();
        //    }

        //    // Let's give a small bit of time for the change to propagate.
        //    // The ConfigWatcherHandler class has a timer which 
        //    // waits for 500 Millis before delivering
        //    // the event notification.
        //    System.Threading.Thread.Sleep(600);

        //    Assert.IsTrue(_hasChanged);
            
        //    _hasChanged = false;
            
        //}

        ///// <summary>
        ///// ConfigurationWatcher Test
        ///// </summary>
        //[Test]
        //public void ConfigurationWatcherTestOnMappingFile()
        //{
        //    string fileName = @"..\..\Maps\MSSQL\SqlClient\Account.xml";

        //    ConfigureHandler handler = new ConfigureHandler(MyHandler);

        //    DomSqlMapBuilder builder = new DomSqlMapBuilder();

        //    NameValueCollection properties = new NameValueCollection();
        //    properties.Add("collection2Namespace", "Apache.Ibatis.DataMapper.SqlClient.Test.Domain.LineItemCollection, Apache.Ibatis.DataMapper.SqlClient.Test");
        //    properties.Add("nullableInt", "int");

        //    builder.Properties = properties;

        //    ISqlMapper mapper = builder.ConfigureAndWatch(_fileName, handler);

        //    // test that the mapper was correct build
        //    Assert.IsNotNull(mapper);

        //    CustomUriBuilder uriBuilder = new CustomUriBuilder(fileName, AppDomain.CurrentDomain.BaseDirectory);

        //    using (IResource resource = new FileResource(uriBuilder.Uri))
        //    {
        //        resource.FileInfo.LastWriteTime = DateTime.Now;

        //        resource.FileInfo.Refresh();
        //    }

        //    // Let's give a small bit of time for the change to propagate.
        //    // The ConfigWatcherHandler class has a timer which 
        //    // waits for 500 Millis before delivering
        //    // the event notification.
        //    System.Threading.Thread.Sleep(600);

        //    Assert.IsTrue(_hasChanged);

        //    _hasChanged = false;

        //}

        //protected void MyHandler(object obj)
        //{
        //    _hasChanged = true;
        //}

    }
}