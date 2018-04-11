using NUnit.Framework;
using System;
using KarveCommon.Services;
using System.Xml.Serialization;
using System.IO;
using System.Collections;
using KarveCar.Logic.Generic;

namespace KarveTest.Base
{
    [TestFixture]
    class TestEnviromentVariables
    {
        private IConfigurationService _configuration = null;
        private IEnviromentVariables _environ = null;
        private static readonly string DefaultXmlFilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        private const string Name = "Environ.xml";
        private string _tmpFile = null;
        [OneTimeSetUp]
        public void Setup()
        {
            _configuration = new ConfigurationService();
            _tmpFile = Path.Combine(DefaultXmlFilePath, Name);

        }
        [Test]
        public void Should_Env_ContainerNotNull()
        {
            _environ = _configuration.EnviromentVariables;
            Assert.NotNull(_environ);
        }
        [Test]
        public void Should_Env_Company_Config_Set_Configuration_Not_Null()
        {
            _environ.SetKey(KarveCommon.Generic.EnvironmentConfig.CompanyConfiguration, "Test1", "0");
            string value = _environ.GetKey(KarveCommon.Generic.EnvironmentConfig.CompanyConfiguration, "Test1") as string;
            Assert.AreEqual(value, "0");
        }
        [Test]
        public void Should_Env_Company_Config_Set_Karve_Not_Null()
        {
            _environ.SetKey(KarveCommon.Generic.EnvironmentConfig.KarveConfiguration, "Test1", "0");
            string value = _environ.GetKey(KarveCommon.Generic.EnvironmentConfig.KarveConfiguration, "Test1") as string;
            Assert.AreEqual(value, "0");
        }
        [Test]
        public void Should_Env_Office_Config_Set_Karve_Not_Null()
        {
            _environ.SetKey(KarveCommon.Generic.EnvironmentConfig.OfficeConfiguration, "Test1", "0");
            string value = _environ.GetKey(KarveCommon.Generic.EnvironmentConfig.OfficeConfiguration, "Test1") as string;
            Assert.AreEqual(value, "0");
        }
        [Test]
        public void Should_Env_Config_Set_And_Unset_Not_Null()
        {
            _environ.SetKey(KarveCommon.Generic.EnvironmentConfig.OfficeConfiguration, "Test1", "0");
            string value = _environ.GetKey(KarveCommon.Generic.EnvironmentConfig.OfficeConfiguration, "Test1") as string;
            Assert.AreEqual(value, "0");
            _environ.EmptyKey(KarveCommon.Generic.EnvironmentConfig.OfficeConfiguration, "Test1");
            var newObject = _environ.GetKey(KarveCommon.Generic.EnvironmentConfig.OfficeConfiguration, "Test1");
            Assert.IsNull(newObject);
            var setAndUnset = _environ.IsSet(KarveCommon.Generic.EnvironmentConfig.OfficeConfiguration, "Test1");
            Assert.False(setAndUnset);
            _environ.SetKey(KarveCommon.Generic.EnvironmentConfig.OfficeConfiguration, "Test1", "0");
            setAndUnset = _environ.IsSet(KarveCommon.Generic.EnvironmentConfig.OfficeConfiguration, "Test1");
            Assert.True(setAndUnset);
            setAndUnset = _environ.IsSetNotZero(KarveCommon.Generic.EnvironmentConfig.OfficeConfiguration, "Test1");
            Assert.False(setAndUnset);
            _environ.SetKey(KarveCommon.Generic.EnvironmentConfig.OfficeConfiguration, "Test1", "1");
            setAndUnset = _environ.IsSetNotZero(KarveCommon.Generic.EnvironmentConfig.OfficeConfiguration, "Test1");
            Assert.True(setAndUnset);
        }
        /// <summary>
        ///  In this test i should deserialize and serialize the configuration file.
        ///  Basically this comes from app.config.
        /// </summary>
        [Test]
        public void Should_Env_Config_XML_Serializable()
        {
            IEnviromentVariables eVariables = null;
            IEnviromentVariables currentVariables = null;
            currentVariables = _configuration.EnviromentVariables;
            try
            {
                Serialize(_configuration.EnviromentVariables);
                Deserialize(out eVariables);
            } catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            if (eVariables != null)
            {
                IEnumerator it = eVariables.GetEnumerator();
                do
                {
                    EnviromentVariable ev = (EnviromentVariable)it.Current;
                    Assert.True(currentVariables.IsSet(ev.Config, ev.Key));
                } while (it.MoveNext());
            }
        }
        private void Serialize(IEnviromentVariables variables)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(KarveCommon.Generic.EnvironmentVariables));
            string tmpFile = Path.Combine(DefaultXmlFilePath, Name);
            using (TextWriter writer = new StreamWriter(tmpFile))
            {
                serializer.Serialize(writer, variables);
            }
        }
        private void Deserialize(out IEnviromentVariables variables)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(KarveCommon.Generic.EnvironmentVariables));
            _tmpFile = Path.Combine(DefaultXmlFilePath, Name);
            using (TextReader reader = new StreamReader(_tmpFile))
            {
                object obj = deserializer.Deserialize(reader);
                IEnviromentVariables env = (IEnviromentVariables)obj;
                variables = env;
            }
        }

    }
}
