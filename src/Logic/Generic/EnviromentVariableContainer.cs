using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;

namespace KarveCar.Logic.Generic
{
    class EnviromentVariableContainer : IEnviromentVariables
    {

        IDictionary<string, object> _officeConfiguration = new Dictionary<string, object>();
        IDictionary<string, object> _companyConfiguration = new Dictionary<string, object>();
        IDictionary<string, object> _karveConfiguration = new Dictionary<string, object>();
        public enum EnvirommentConfig { OFFICE_CONFIGURATION, COMPANY_CONFIGURATION, KARVE_CONFIGURATION };
        public void EmptyKey(string key, object value)
        {
        //    _variables.Remove(key);
        }

        public object GetKey(string key)
        {
            return null;
        }

        public bool HasKey(string key)
        {
            return true;
        }

        public bool IsSet(string key)
        {
            bool variable = false;

            /*
            bool variable = false;
            if (_variables.ContainsKey(key))
            {
                if (_variables[key] != null)
                {
                    variable = true;
                }
            }*/
            return variable;
        }

        public bool isSetCompanyConfig(string v)
        {
            throw new NotImplementedException();
        }

        public void SetKey(string key, object value)
        {
            //_variables[key] = value;
        }

    }
}
