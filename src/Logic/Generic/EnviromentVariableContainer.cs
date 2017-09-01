
using System.Collections.Generic;
using KarveCommon.Services;
using KarveCommon.Generic;
using System;
using System.Xml.Serialization;

namespace KarveCar.Logic.Generic
{
    [XmlRoot("EnviromentConfiguration")]
    public class EnviromentVariableContainer : IEnviromentVariables
    {
        [XmlAttribute("OfficeConfiguration")]
        private IDictionary<string, object> _officeConfiguration = new Dictionary<string, object>();
        [XmlAttribute("CompanyConfiguration")]
        private IDictionary<string, object> _companyConfiguration = new Dictionary<string, object>();
        [XmlAttribute("KarveConfiguration")]
        private IDictionary<string, object> _karveConfiguration = new Dictionary<string, object>();
        [XmlIgnore]
        private IDictionary<EnvironmentConfig, IDictionary<string, object>> enviromentMap;
        public EnviromentVariableContainer()
        {
            enviromentMap = new Dictionary<EnvironmentConfig, IDictionary<string, object>>();
            enviromentMap.Add(EnvironmentConfig.OfficeConfiguration, _officeConfiguration);
            enviromentMap.Add(EnvironmentConfig.CompanyConfiguration, _companyConfiguration);
            enviromentMap.Add(EnvironmentConfig.KarveConfiguration, _karveConfiguration);
        }
        public void EmptyKey(EnvironmentConfig config, string key)
        {
            IDictionary<string, object> map;
            if (enviromentMap.TryGetValue(config, out map))
            {
                map.Remove(key);
            }
        }

        public object GetKey(EnvironmentConfig config, string key)
        {
            IDictionary<string, object> map;
            object value = null;
            if (enviromentMap.TryGetValue(config, out map))
            {
                map.TryGetValue(key, out value);
            }
            return value;
        }

        public bool HasKey(EnvironmentConfig config, string key)
        {
            IDictionary<string, object> map;
            if (enviromentMap.TryGetValue(config, out map))
            {
                return map.ContainsKey(key);

            }
            return false;
        }

        public void UnSet(EnvironmentConfig config, string key)
        {
            IDictionary<string, object> map;
            object value = null;
            if (enviromentMap.TryGetValue(config, out map))
            {
                map.TryGetValue(key, out value);
            }
            value = null;
        }
        public bool IsSet(EnvironmentConfig config, string key)
        {
            IDictionary<string, object> map;
            object value = null;
            if (enviromentMap.TryGetValue(config, out map))
            {
                map.TryGetValue(key, out value);
            }
            if (value != null)
                return true;

            return false;
        }

        public void SetKey(EnvironmentConfig config, string key, object value)
        {
            IDictionary<string, object> map;
            value = null;
            if (enviromentMap.TryGetValue(config, out map))
            {
                map.TryGetValue(key, out value);
            }

        }

        public bool IsSetNotEmpty(EnvironmentConfig config, string key)
        {
           return false;
        }
    }
}
