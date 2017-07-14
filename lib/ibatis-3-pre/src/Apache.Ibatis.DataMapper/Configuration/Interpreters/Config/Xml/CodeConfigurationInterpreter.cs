using System;
using System.Xml;
using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.Common.Contracts;
using Apache.Ibatis.Common.Data;
using Apache.Ibatis.Common.Resources;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config.Xml.Processor;

namespace Apache.Ibatis.DataMapper.Configuration.Interpreters.Config.Xml
{
    /// <summary>
    /// Allows most of the XML normally contained in SqlMapConfig.xml to be expressed in code. SqlMap items 
    /// continue to be processed as XML resources.
    /// </summary>
    /// <remarks>
    /// Custom properties should be added to an instance of ConfigurationSettings passed into the engine.
    /// </remarks>
    /// <example>
    /// <code>
    /// 
    /// &lt;sqlMapConfig xmlns="http://ibatis.apache.org/dataMapper" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" &gt;
    ///   &lt;providers uri="file://providers.config"/&gt;	
    ///   &lt;database&gt;
    ///    &lt;provider name="SQLite3"/&gt;
    ///    &lt;dataSource name="ibatisnet.sqlmap" connectionString="Data Source=ibatisnet.sqlite;Version=3;"/&gt;
    ///   &lt;/database&gt;  
    ///   &lt;alias&gt;
    ///    &lt;typeAlias alias="Account" type="Apache.Ibatis.DataMapper.Sqlite.Test.Domain.Account, Apache.Ibatis.DataMapper.Sqlite.Test"/&gt;
    ///   &lt;/alias&gt;  
    ///   &lt;sqlMaps&gt;
    ///    &lt;sqlMap uri="file://../../Maps/Account.xml"/&gt;
    ///   &lt;/sqlMaps&gt;
    /// &lt;/sqlMapConfig>
    ///
    /// var codeConfig = new CodeConfigurationInterpreter(engine.ConfigurationStore);
    /// codeConfig.AddDatabase(new SqliteDbProvider(), "Data Source=ibatisnet.sqlite;Version=3;");
    /// codeConfig.AddAlias(typeof(Account), "Account");
    /// codeConfig.AddSqlMap("file://../../Maps/Account.xml");
    /// </code>
    /// </example>
    public class CodeConfigurationInterpreter : IConfigurationInterpreter
    {
        private IConfigurationStore configurationStore;

        /// <summary>
        /// Allows adding items to the IConfigurationStore before ProcessResource is called.
        /// </summary>
        public CodeConfigurationInterpreter(IConfigurationStore store)
        {
            Contract.Require.That(store, Is.Not.Null).When("retrieve argument configurationStore in CodeConfigurationInterpreter constructor");

            configurationStore = store;
        }

        /// <summary>
        /// Should obtain the contents from the resource,
        /// interpret it and populate the <see cref="IConfigurationStore"/>
        /// accordingly.
        /// </summary>
        /// <param name="store">The store.</param>
        public void ProcessResource(IConfigurationStore store)
        {
            configurationStore = store;
        }

        /// <summary>
        /// Adds a Type alias to the store.
        /// </summary>
        /// <remarks>
        /// Uses ConfigConstants.ELEMENT_TYPEALIAS as the value for IConfiguration.Type.
        /// </remarks>
        /// <example>
        /// <code>
        /// &lt;alias&gt;
        ///	 &lt;typeAlias alias="Account" type="Apache.Ibatis.DataMapper.Sqlite.Test.Domain.Account, Apache.Ibatis.DataMapper.Sqlite.Test"/&gt;
	    /// &lt;/alias&gt;
        /// </code>
        /// </example>
        public void AddAlias(Type type, string name)
        {
            IConfiguration typeAlias = new MutableConfiguration(
                ConfigConstants.ELEMENT_TYPEALIAS,
                name,
                type.FullName + ", " + type.Assembly.GetName().Name);

            configurationStore.AddAliasConfiguration(typeAlias);
        }

        /// <summary>
        /// Adds a database configuration item to the store.
        /// </summary>
        /// <example>
        /// <code>
        /// &lt;database&gt;
        ///  &lt;provider name="SQLite3"/&gt;
        ///  &lt;dataSource name="ibatisnet.sqlmap" connectionString="Data Source=ibatisnet.sqlite;Version=3;"/&gt;
        /// &lt;/database&gt;  
        /// </code>
        /// </example>
        public void AddDatabase(IDbProvider dbProvider, string dataSourceConnectionString)
        {
            // hack: serialize the object to IConfiguration so it can eventually be converted back to IDbProvider
            configurationStore.AddProviderConfiguration(ProviderSerializer.Serialize(dbProvider));
            
            MutableConfiguration database = new MutableConfiguration(ConfigConstants.ELEMENT_DATABASE);
            
            MutableConfiguration provider = database.CreateChild("provider");
            provider.CreateAttribute(ConfigConstants.ATTRIBUTE_NAME, dbProvider.Id);

            MutableConfiguration dataSource = database.CreateChild("dataSource");
            dataSource.CreateAttribute(ConfigConstants.ATTRIBUTE_NAME, "defaultDataSource");
            dataSource.CreateAttribute("connectionString", dataSourceConnectionString);

            configurationStore.AddDatabaseConfiguration(database);
        }

        /// <summary>
        /// Adds an XML sql map configuration item.
        /// </summary>
        /// <param name="uri">A URI to XML data.</param>
        /// <param name="validate">Validate the XML sqlMap file using SqlMap.xsd</param>
        /// <example>
        /// <code>
        /// &lt;sqlMaps&gt;
        ///  &lt;sqlMap uri="file://../../Maps/Account.xml"/&gt;
        /// &lt;/sqlMaps&gt;
        /// </code>
        /// </example>
        public void AddSqlMap(string uri, bool validate)
        {
            IResource resource = ResourceLoaderRegistry.GetResource(uri);

            using (resource)
            {
                if (validate)
                {
                    XmlDocument document = new XmlDocument();
                    document.Load(resource.Stream);
                    SchemaValidator.Validate(document.ChildNodes[1], "SqlMap.xsd");
                }

                resource.Stream.Position = 0;
                using (XmlTextReader reader = new XmlTextReader(resource.Stream))
                {
                    using (XmlMappingProcessor processor = new XmlMappingProcessor())
                    {
                        processor.Process(reader, configurationStore);
                    }
                }
            }
        }

        // TODO: add support for type handlers

        /// <summary>
        /// Unused. Always returns null.
        /// </summary>
        public IResource Resource
        {
            get { return null; }
        }
    }
}