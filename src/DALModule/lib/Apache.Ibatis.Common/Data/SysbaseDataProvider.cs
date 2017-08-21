namespace Apache.Ibatis.Common.Data
{
    public class SysbaseDataProvider: DbProvider
    {
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
        public void Initialize()
        {
            // empty
        }
        

}
}
