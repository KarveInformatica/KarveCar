
using System.Collections.Generic;
using KarveCommon.Services;
using KarveCommon.Generic;
using System;
using System.Xml.Serialization;
using System.Collections;

namespace KarveCar.Logic.Generic
{
    [XmlRoot("EnviromentConfiguration")]
    public class EnviromentVariableContainer : IEnviromentVariables, IEnumerable<EnviromentVariable>
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
        private void setDefaultConfig()
        {
            /* EnvConfig.OfficeConfiguration, EnvironmentVariables.MRent 
               EnvConfig.OfficeConfiguration, EnvironmentVariables.Herrero
               EnvConfig.CompanyConfiguration, EnvironmentVariables.EfectosProvee
               EnvConfig.KarveConfiguration, EnvironmentVariables.NoCtaContaProvee
               EnvConfig.KarveConfiguration, EnvironmentVariables.ExisteProveeDest
               EnvConfig.CompanyConfiguration, EnvironmentVariables.Mercedes
               EnvConfig.CompanyConfiguration, EnvironmentVariables.NoCtaContaProvee
               EnvConfig.CompanyConfiguration, EnvironmentVariables.NoCrearCuentaProvee
               EnvConfig.CompanyConfiguration, EnvironmentVariables.ProveComun
               EnvConfig.KarveConfiguration, EnvironmentVariables.EmpresaPlanCuenta
             */
            SetKey(EnvironmentConfig.KarveConfiguration, EnvironmentVariables.EmpresaConectada, "KarveSL");


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
            IDictionary<string, object> map;
            object value = null;
            if (enviromentMap.TryGetValue(config, out map))
            {
                map.TryGetValue(key, out value);
            }
            return (value != null);
        }

        public bool IsSetNotZero(EnvironmentConfig config, string key)
        {
            IDictionary<string, object> map;
            object value = null;
            int res;
            if (enviromentMap.TryGetValue(config, out map))
            {
                map.TryGetValue(key, out value);
            }
            Int32.TryParse(value as string, out res);
            return (res != 0);
        }
       
        public IEnumerator GetEnumerator()
        {
            IList<EnviromentVariable> mergedDictionaries;
            MergeDictionaries(out mergedDictionaries);
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
                EnviromentVariable var = new EnviromentVariable();
                var.Config = EnvironmentConfig.OfficeConfiguration;
                var.Key = envVariables.Key;
                var.Value = envVariables.Value;
                mergedDictionaries.Add(var);
            }
            
        }
        IEnumerator<EnviromentVariable> IEnumerable<EnviromentVariable>.GetEnumerator()
        {
            return (IEnumerator<EnviromentVariable>)this.GetEnumerator();
        }
    }
}
