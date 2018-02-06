using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveDataServices;

namespace DataAccessLayer.SQL
{
    public abstract class AbstractSqlExecutor : ISqlExecutor
    {
        protected IList<ISqlCommand> CommandList;
        /// <summary>
        ///  Load a data set from a query.
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <returns></returns>
        public abstract Task<DataSet> AsyncDataSetLoad(string sqlQuery);
        public abstract ConnectionState State { get; }
        public abstract IDbConnection Connection { get; set; }
        public abstract void BeginTransaction();
        public abstract void CallStoredProcedure(string statementProcedureName, IList<string> statementProcList);
        public abstract bool Close();
        public abstract void Commit();
        public abstract DataTable ExecuteParamerizedSelectCommand(string CommandName, CommandType cmdType, DataParameter param);
        public abstract string ExecuteQueryDataTable(string sqlQuery);
        public abstract DataTable ExecuteSelectCommand(string CommandName, CommandType cmdType);
        public abstract DataSet LoadDataSet(string sqlQuery);
        public abstract DataSet LoadDataSetByTables(string sqlQuery, IList<string> tableAlias);
        public abstract bool Open();
        public abstract IDbConnection OpenNewDbConnection();
        public abstract void Rollback();
        public abstract void UpdateDataSet(string sqlQuery, ref DataSet dts);
        public abstract bool ExecuteNonQuery(string commandName, CommandType cmdType, DataParameter param);

        public abstract Task<DataSet> AsyncDataSetLoadBatch(IDictionary<string, string> queryList);
        //  public abstract IList<T> ExecuteQueryFields(string sqlQuery);
       
        public void AddBatch(ISqlCommand command)
        {
            this.CommandList.Add(command);
        }
        public bool SameColumn(string tableName, string columnName, string whereClause)
        {
            string sqlString = string.Format(" SELECT {0} FROM {1} {2}", columnName, tableName, whereClause);
            string value = ExecuteQueryDataTable(sqlString);
            return (!string.IsNullOrEmpty(value));
        }

        /// <summary>
        /// This method show the exact line number for the exception
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="lineNumber">Position where it happens in the code</param>
        /// <param name="caller">Stack caller</param>
        /// <returns></returns>
        protected string ShowMessage(string message,
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string caller = null)
        {
            string outMessage = message + " at line " + lineNumber + " (" + caller + ")";
            return outMessage;
        }

        public abstract Task<DataTable> QueryAsyncForDataTable(string sqlQuery);
    }
}
