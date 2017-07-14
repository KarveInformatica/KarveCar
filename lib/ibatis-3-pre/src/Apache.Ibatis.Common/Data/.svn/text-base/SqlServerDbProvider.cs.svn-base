using System;
using System.Data;
using System.Data.SqlClient;

namespace Apache.Ibatis.Common.Data
{
    /// <summary>
    /// System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
    /// </summary>
    public class SqlServerDbProvider : DbProvider
    {
        /// <summary>
        /// Sets default values for connecting to SQL Server.
        /// </summary>
        public SqlServerDbProvider()
        {
            Id = "sqlServer";
            AssemblyName = "System.Data, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
            CommandBuilderClass = "System.Data.SqlClient.SqlCommandBuilder";
            DbCommandClass = "System.Data.SqlClient.SqlCommand";
            DbConnectionClass = "System.Data.SqlClient.SqlConnection";
            Description = "Microsoft SQL Server, provider V2.0.0.0 in framework .NET V2.0";
            IsDefault = true;
            IsEnabled = true;
            ParameterDbTypeClass = "System.Data.SqlDbType";
            ParameterDbTypeProperty = "SqlDbType";
            ParameterPrefix = "@";
            SetDbParameterPrecision = false;
            SetDbParameterScale = false;
            SetDbParameterSize = false; // ???
            UseDeriveParameters = false; // ???
            UseParameterPrefixInParameter = true;
            UseParameterPrefixInSql = true;
            UsePositionalParameters = false;
            AllowMARS = false;
            // parameterClass="System.Data.SqlClient.SqlParameter"
            // dataAdapterClass="System.Data.SqlClient.SqlDataAdapter"
        }

        public void Initialize()
        {
            // empty
        }

        public override IDbConnection CreateConnection()
        {
            return new SqlConnection();
        }

        public override IDbCommand CreateCommand()
        {
            return new SqlCommand();
        }

        public override IDbDataParameter CreateDataParameter()
        {
            return new SqlParameter();
        }

        public Type CommandBuilderType
		{
			get { return typeof (SqlCommandBuilder); }
		}

        public Type ParameterDbType
        {
            get { return typeof (SqlDbType); }
        }
    }
}
