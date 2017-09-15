namespace Apache.Ibatis.Common.Data
{
    
    /// <summary>
    /// This is the sysbase data provider for the mapper. Currently is supported sysbase 16. 
    /// </summary>
    public class SysbaseDataProvider: DbProvider
    {
        /// constructor
        public SysbaseDataProvider()
        {
            Id = "SysBase";
            AssemblyName = "iAnywhere.Data.SQLAnywhere.v4.5, Version = 16.0.0.13244, Culture = neutral, PublicKeyToken = f222fc4333e0d400";
            CommandBuilderClass = "iAnywhere.Data.SQLAnywhere.SACommandBuilder";
            DbCommandClass = "iAnywhere.Data.SQLAnywhere.SACommand";
            DbConnectionClass = " iAnywhere.Data.SQLAnywhere.SAConnection";
            Description = "SysBase provider";
            IsDefault = true;
            IsEnabled = true;
            ParameterDbTypeClass = "iAnywhere.Data.SQLAnywhere.SADbType";
            ParameterDbTypeProperty = "DbType";
            ParameterPrefix = "@";
            SetDbParameterPrecision = false;
            SetDbParameterScale = false;
            SetDbParameterSize = false; // ???
            UseDeriveParameters = false; // ???
            UseParameterPrefixInParameter = true;
            UseParameterPrefixInSql = true;
            UsePositionalParameters = false;
            AllowMARS = false;
       }
        /// <summary>
        ///  Currently no special initialization is needed.
        /// </summary>
        public void Initialize()
        {
            // empty
        }
        

}
}
