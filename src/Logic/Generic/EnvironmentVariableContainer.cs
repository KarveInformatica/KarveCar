
using System.Collections.Generic;
using KarveCommon.Services;
using KarveCommon.Generic;
using System;
using System.Xml.Serialization;
using System.Collections;

namespace KarveCar.Logic.Generic
{
    [XmlRoot("EnvironmentConfiguration")]
    public class EnvironmentVariableContainer : IEnviromentVariables, IEnumerable<EnviromentVariable>
    {
        [XmlAttribute("OfficeConfiguration")]
        private IDictionary<string, object> _officeConfiguration = new Dictionary<string, object>();
        [XmlAttribute("CompanyConfiguration")]
        private IDictionary<string, object> _companyConfiguration = new Dictionary<string, object>();
        [XmlAttribute("KarveConfiguration")]
        private IDictionary<string, object> _karveConfiguration = new Dictionary<string, object>();
        [XmlIgnore]
        private readonly IDictionary<EnvironmentConfig, IDictionary<string, object>> enviromentMap = new Dictionary<EnvironmentConfig, IDictionary<string, object>>();
        public EnvironmentVariableContainer()
        {
            enviromentMap.Add(EnvironmentConfig.OfficeConfiguration, _officeConfiguration);
            enviromentMap.Add(EnvironmentConfig.CompanyConfiguration, _companyConfiguration);
            enviromentMap.Add(EnvironmentConfig.KarveConfiguration, _karveConfiguration);
            SetDefaultConfig();
        }
        private void SetDefaultConfig()
        {
            
            SetKey(EnvironmentConfig.KarveConfiguration, EnvironmentKey.ConnectedCompany, "KarveSL");
            SetKey(EnvironmentConfig.KarveConfiguration, EnvironmentKey.CurrentOffice, "C1");
            SetKey(EnvironmentConfig.KarveConfiguration, EnvironmentKey.CurrentUser, "CV");
            SetKey(EnvironmentConfig.KarveConfiguration, EnvironmentKey.DataBaseType, "Sybase Anywhere 16");
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
            if (enviromentMap.TryGetValue(config, out var map))
            {
                return map.ContainsKey(key);

            }
            return false;
        }

        public void UnSet(EnvironmentConfig config, string key)
        {
            object value = null;
            if (enviromentMap.TryGetValue(config, out var map))
            {
                map.TryGetValue(key, out value);
            }
            value = null;
        }
        public bool IsSet(EnvironmentConfig config, string key)
        {
            object value = null;
            if (enviromentMap.TryGetValue(config, out var map))
            {
                map.TryGetValue(key, out value);
            }
            if (value != null)
                return true;

            return false;
        }

        public void SetKey(EnvironmentConfig config, string key, object value)
        {
            value = null;
            if (enviromentMap.TryGetValue(config, out var map))
            {
                map.TryGetValue(key, out value);
            }

        }

        public bool IsSetNotEmpty(EnvironmentConfig config, string key)
        {
            object value = null;
            if (enviromentMap.TryGetValue(config, out var map))
            {
                map.TryGetValue(key, out value);
            }
            return (value != null);
        }

        public bool IsSetNotZero(EnvironmentConfig config, string key)
        {
            object value = null;
            int res;
            if (enviromentMap.TryGetValue(config, out var map))
            {
                map.TryGetValue(key, out value);
            }
            Int32.TryParse(value as string, out res);
            return (res != 0);
        }
       
        public IEnumerator GetEnumerator()
        {
            MergeDictionaries(out var mergedDictionaries);
            foreach (EnviromentVariable currentVariable in mergedDictionaries)
            {
                // Return the current element and then on next function call 
                // resume from next element rather than starting all over again;
                yield return currentVariable;
            }
        }
        private void MergeDictionaries(out IList<EnviromentVariable> mergedDictionaries)
        {
            mergedDictionaries = new List<EnviromentVariable>();
            foreach (KeyValuePair<string, object> envVariables in _officeConfiguration)
            {
                EnviromentVariable var = new EnviromentVariable
                {
                    Config = EnvironmentConfig.OfficeConfiguration,
                    Key = envVariables.Key,
                    Value = envVariables.Value
                };
                mergedDictionaries.Add(var);
            }
            
        }
        IEnumerator<EnviromentVariable> IEnumerable<EnviromentVariable>.GetEnumerator()
        {
            return (IEnumerator<EnviromentVariable>)this.GetEnumerator();
        }
    }
}
