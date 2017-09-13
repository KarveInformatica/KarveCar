using System.Collections;
using KarveCommon.Generic;
using System.Collections.Generic;

namespace KarveCommon.Services
{
   
    // Enviroment variable.
    public class EnviromentVariable
    {
        private EnvironmentConfig _config;
        private string _key;
        private object _value;
        public EnvironmentConfig Config
        {
            set
            {
                _config = value;
            }
            get
            {
                return _config;
            }
        }
        public string Key
        {
            set
            {
                _key = value;
            }
            get
            {
                return _key;
            }
        }
        public object Value
        {
            set
            {
                _value = value;
            }
            get
            {
                return _value;
            }
        }
    };
    /// <summary>
    ///  This interface is for the global enviroment of the program.
    /// </summary>
    public interface IEnviromentVariables: IEnumerable<EnviromentVariable>
    {
        /// <summary>
        ///  This gives us if the variable is present.
        /// </summary>
        /// <param name="config">Enviroment config</param>
        /// <param name="key">Key name</param>
        /// <returns></returns>
        bool HasKey(EnvironmentConfig config, string key);
        /// <summary>
        /// This check if a value is set for a given key.
        /// </summary>
        /// <param name="config">Enviroment config</param>
        /// <param name="key">Key name</param>
        /// <returns></returns>
        bool IsSet(EnvironmentConfig config, string key);
        /// <summary>
        /// This method set the key to the value.
        /// </summary>
        /// <param name="config">Enviroment config</param>
       /// <param name="key">Key Name</param>
        /// <param name="value">Key Value</param>
        void SetKey(EnvironmentConfig config, string key, object value);
        /// <summary>
        /// This method remove the key form the enviroment.
        /// </summary>
        /// <param name="config">Config</param>
        /// <param name="key">Key Value</param>
        void EmptyKey(EnvironmentConfig config, string key);
        /// <summary>
        ///  This returns the key that it is available.
        /// </summary>
        /// <param name="config">Enviroment config</param>
        /// <param name="key">Key Name</param>
        /// <returns></returns>
        object GetKey(EnvironmentConfig config, string key);
        /// <summary>
        /// This unset a value in the configuration enviroment.
        /// </summary>
        /// <param name="config">Enviroment config</param>
        /// <param name="key">Key Name</param>
        void UnSet(EnvironmentConfig config, string key);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="karveConfiguration"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        bool IsSetNotEmpty(EnvironmentConfig karveConfiguration, string v);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="officeConfiguration"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        bool IsSetNotZero(EnvironmentConfig officeConfiguration, string v);

       
    }
}