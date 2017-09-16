using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Generic;

namespace KarveCommon.Generic
{
    public abstract class AbstractSqlQueryExecutor : ISqlQueryExecutor
    {
        protected IList<ISqlCommand> CommandList;
        public abstract Task<DataSet> AsyncDataSetLoad(string sqlQuery);
        public abstract void BeginTransaction();
        public abstract void CallStoredProcedure(string statementProcedureName, IList<string> statementProcList);
        public abstract bool Close();
        public abstract void Commit();
        public abstract bool ExecuteNonQuery(string CommandName, CommandType cmdType, IDBParameter param);
        public abstract DataTable ExecuteParamerizedSelectCommand(string CommandName, CommandType cmdType, IDBParameter param);
        public abstract string ExecuteQueryDataTable(string sqlQuery);
        public abstract DataTable ExecuteSelectCommand(string CommandName, CommandType cmdType);
        public abstract DataSet LoadDataSet(string sqlQuery);
        public abstract DataSet LoadDataSetByTables(string sqlQuery, IList<string> tableAlias);
        public abstract bool Open();
        public abstract void Rollback();
        public abstract void UpdateDataSet(string sqlQuery, ref DataSet dts);
        public abstract Task<DataTable> QueryAsyncForDataTable(string sqlQuery, string code);
        public abstract Task<T> QueryAsyncForObject<T>(string v, T parameter);
        public abstract Task<bool> ExecuteUpdateAsyncBatch();
        public abstract DataTable QueryForDataTable(string v, long pos);
        public abstract Task<T> QueryAsyncForObjectSession<T>(string v, string supplierId, ISqlSession session);
        public abstract ISqlSession OpenSession();
        public abstract void CloseSession(ISqlSession sqlSession);
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
    }
}
