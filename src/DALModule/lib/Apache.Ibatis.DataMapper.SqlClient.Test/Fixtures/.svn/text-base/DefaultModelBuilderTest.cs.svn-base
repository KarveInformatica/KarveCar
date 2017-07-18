using Apache.Ibatis.DataMapper.Configuration;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config.Xml;
using Apache.Ibatis.DataMapper.Model;

using NUnit.Framework;
using System;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures
{
    [TestFixture] 
    public class DefaultModelBuilderTest
    {

        /// <summary>
        /// Test DefaultModelBuilder
        /// </summary>
        [Test]
        public void Test_DefaultModelBuilder()
        {
            string uri = "SqlMap_Test_Configure.config";
            IConfigurationStore store = new DefaultConfigurationStore();

            IConfigurationInterpreter interpreter = new XmlConfigurationInterpreter(uri);

            interpreter.ProcessResource(store);
            //Console.WriteLine(store.ToString());

            IModelStore modelStore = new DefaultModelStore();
            IModelBuilder builder = new DefaultModelBuilder(modelStore);

            builder.BuildModel(null, store);

            CheckModelStore(modelStore);
        }

        private void CheckModelStore(IModelStore store)
        {
            Console.WriteLine(store.ToString());

            //Assert.That(store.Properties.Length, Is.EqualTo(14));
            //Assert.That(store.GetPropertyConfiguration("useStatementNamespaces").Value, Is.EqualTo("false"));

            //Assert.That(store.Settings.Length, Is.EqualTo(4));
            //Assert.That(store.GetSettingConfiguration("validateSqlMap").Value, Is.EqualTo("false"));

            //Assert.That(store.Providers.Length, Is.EqualTo(17));
            //IConfiguration informixProvider = store.GetProviderConfiguration("Informix");
            //Assert.That(informixProvider.Attributes["description"], Is.EqualTo("Informix NET Provider, 2.81.0.0"));
            //Assert.That(informixProvider.Attributes["commandBuilderClass"], Is.EqualTo("IBM.Data.Informix.IfxCommandBuilder"));

            //Assert.That(store.Databases.Length, Is.EqualTo(1));
            //Assert.That(store.Databases[0].Children.Count, Is.EqualTo(2));

            //IConfiguration provider = store.Databases[0].Children.Find(DataConstants.ELEMENT_PROVIDER)[0];
            //Assert.That(provider, Is.Not.Null);
            //Assert.That(provider.Attributes[DataConstants.ATTRIBUTE_NAME], Is.EqualTo("sqlServer1.1"));
            //Assert.That(provider.Id, Is.EqualTo("sqlServer1.1"));
            //Assert.That(provider.Value, Is.EqualTo("sqlServer1.1"));
            //Assert.That(provider.Type, Is.EqualTo(DataConstants.ELEMENT_PROVIDER));

            //IConfiguration datasource = store.Databases[0].Children.Find(DataConstants.ELEMENT_DATASOURCE)[0];
            //Assert.That(datasource, Is.Not.Null);
            //Assert.That(datasource.Value.StartsWith("data source="));
            //Assert.That(datasource.Type, Is.EqualTo(DataConstants.ELEMENT_DATASOURCE));

            //Assert.That(store.Alias.Length, Is.EqualTo(12));
            //Assert.That(store.GetAliasConfiguration("Account").Value, Is.EqualTo("Apache.Ibatis.DataMapper.SqlClient.Test.Domain.Account, Apache.Ibatis.DataMapper.SqlClient.Test"));

            //Assert.That(store.TypeHandlers.Length, Is.EqualTo(2));
            //Assert.That(store.GetTypeHandlerConfiguration("bool").Attributes.Count, Is.EqualTo(3));
            //Assert.That(store.GetTypeHandlerConfiguration("string").Attributes.Count, Is.EqualTo(2));

            //// Cache model
            //Assert.That(store.CacheModels.Length, Is.EqualTo(2));
            //IConfiguration cacheModel = store.CacheModels[0];
            //Assert.That(cacheModel.Children.Count, Is.EqualTo(4));
            //Assert.That(cacheModel.Attributes.ContainsKey(ConfigConstants.ATTRIBUTE_NAMESPACE), Is.True);

            //// Result map
            //Assert.That(store.ResultMaps.Length, Is.EqualTo(3 + 3 + 2));
            //IConfiguration resultMap = store.GetResultMapConfiguration("Account.account-result-constructor");
            //Assert.IsNotNull(resultMap);
            //Assert.That(resultMap.Children.Count, Is.EqualTo(4));

            //IConfiguration constructor = resultMap.Children.Find(ConfigConstants.ELEMENT_CONSTRUCTOR)[0];
            //Assert.IsNotNull(constructor);
            //Assert.That(constructor.Children.Count, Is.EqualTo(3));

            //ConfigurationCollection arguments = constructor.Children.Find(ConfigConstants.ELEMENT_ARGUMENT);

            //Assert.IsNotEmpty(arguments);
            //Assert.That(arguments.Count, Is.EqualTo(3));
            //Assert.That(arguments[0].Attributes[ConfigConstants.ATTRIBUTE_ARGUMENTNAME], Is.EqualTo("identifiant"));

            //ConfigurationCollection results = resultMap.Children.Find(ConfigConstants.ELEMENT_RESULT);
            //Assert.IsNotEmpty(results);
            //Assert.That(results.Count, Is.EqualTo(3));
            //Assert.That(results[0].Attributes[ConfigConstants.ATTRIBUTE_PROPERTY], Is.EqualTo("EmailAddress"));

            //// Parameter map
            //Assert.That(store.ParameterMaps.Length, Is.EqualTo(7));
            //IConfiguration parameterMap = store.GetParameterMapConfiguration("Account.insert-params");
            //Assert.IsNotNull(parameterMap);
            //Assert.That(parameterMap.Children.Count, Is.EqualTo(6));

            //ConfigurationCollection parameters = parameterMap.Children.Find(ConfigConstants.ELEMENT_PARAMETER);

            //Assert.IsNotEmpty(parameters);
            //Assert.That(parameters.Count, Is.EqualTo(6));
            //Assert.That(parameters[4].Attributes.Count, Is.EqualTo(4));
            //Assert.That(parameters[3].Attributes[ConfigConstants.ATTRIBUTE_PROPERTY], Is.EqualTo("EmailAddress"));

            //// sql statement in Mapping2.xml
            //Assert.That(store.Statements.Length, Is.EqualTo(97));
            //IConfiguration sqlStatement = store.GetStatementConfiguration("includeComplex");
            //Assert.IsNotNull(sqlStatement);
            //Assert.That(sqlStatement.Attributes.ContainsKey(ConfigConstants.ATTRIBUTE_NAMESPACE), Is.True);

            //Assert.That(sqlStatement.Children.Count, Is.EqualTo(1));
            //IConfiguration child = sqlStatement.Children[0];//dynamic
            //Assert.That(child.Children.Count, Is.EqualTo(1));
            //child = child.Children[0];//isParameterPresent
            //Assert.That(child.Children.Count, Is.EqualTo(3));
            //child = child.Children[1];//isNotEmpty
            //Assert.That(child.Attributes.Count, Is.EqualTo(2));
            //Assert.IsTrue(child.Attributes.ContainsKey("prepend"));
            //Assert.IsTrue(child.Attributes.ContainsKey("property"));
            //Assert.That(child.Attributes["prepend"], Is.EqualTo("and"));
            //Assert.That(child.Attributes["property"], Is.EqualTo("FirstName"));
        }
    }
}