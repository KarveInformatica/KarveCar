namespace Apache.Ibatis.Common.Data
{
    /// <summary>
    /// System.Data.SQLite, Version=1.0.61.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139
    /// </summary>
    public class SqliteDbProvider : DbProvider
    {
        /// <summary>
        /// Sets default values for connecting to Sqlite.
        /// </summary>
        public SqliteDbProvider()
        {
            Id = "SQLite3";
            AssemblyName = "System.Data.SQLite, Version=1.0.61.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139";
            CommandBuilderClass = "System.Data.SQLite.SQLiteCommandBuilder";
            DbCommandClass = "System.Data.SQLite.SQLiteCommand";
            DbConnectionClass = "System.Data.SQLite.SQLiteConnection";
            Description = "System.Data.SQLite, Version=1.0.61.0";
            IsDefault = true;
            IsEnabled = true;
            ParameterDbTypeClass = "System.Data.SQLite.SQLiteType";
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
            // parameterClass="System.Data.SQLite.SQLiteParameter"
        }
    }
}
