namespace KarveCommon.Services
{
    public interface IEnviromentVariables
    {
        /// <summary>
        ///  This gives us if the variable is present.
        /// </summary>
        /// <param name="key">Key name</param>
        /// <returns></returns>
        bool HasKey(string key);
        /// <summary>
        /// This check if a value is set for a given key.
        /// </summary>
        /// <param name="key">Key name</param>
        /// <returns></returns>
        bool IsSet(string key);
        /// <summary>
        /// This method set the key to the value.
        /// </summary>
        /// <param name="key">Key Name</param>
        /// <param name="value">Key Value</param>
        void SetKey(string key, object value);
        /// <summary>
        /// This method remove the key form the enviroment.
        /// </summary>
        /// <param name="key">Key Name</param>
        /// <param name="value">Key Value</param>
        void EmptyKey(string key, object value);
        /// <summary>
        ///  This returns the key that it is available.
        /// </summary>
        /// <param name="key">Key Name</param>
        /// <returns></returns>
        object GetKey(string key);
        bool isSetCompanyConfig(string v);
    }
}