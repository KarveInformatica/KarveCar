using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveDataServices;
using Dapper;
using KarveDapper.Extensions;
using KarveDapper;
using AutoMapper;
using System;
using System.Linq;
using DataAccessLayer.Exception;

namespace DataAccessLayer.SQL
{
    public abstract class AbstractSqlExecutor : ISqlExecutor
    {
        protected IList<ISqlCommand> CommandList;
        /// <summary>
        ///  Load a data set from a query.
        /// </summary>
        /// <param name="sqlQuery">Query for loading a data set</param>
        /// <returns></returns>
        public abstract Task<DataSet> AsyncDataSetLoad(string sqlQuery);
        /// <summary>
        ///  Returns the connection state
        /// </summary>
        public abstract ConnectionState State { get; }
        /// <summary>
        ///  Returns the connection.
        /// </summary>
        public abstract IDbConnection Connection { get; set; }
        /// <summary>
        ///  Returns a connection string.
        /// </summary>
        public string ConnectionString { get ; set ; }
        /// <summary>
        ///  Begin a transaction.
        /// </summary>
        public abstract void BeginTransaction();
        /// <summary>
        /// Call a stored procedure
        /// </summary>
        /// <param name="statementProcedureName">Name of the procedure</param>
        /// <param name="statementProcList">List of string</param>
        public abstract void CallStoredProcedure(string statementProcedureName, IList<string> statementProcList);
        /// <summary>
        ///  Close the connection. 
        /// </summary>
        /// <returns>true if close successfully.</returns>
        public abstract bool Close();
        /// <summary>
        ///  Commit a DML query.
        /// </summary>
        public abstract void Commit();
        /// <summary>
        /// ADO.NET select command paramerized.
        /// </summary>
        /// <param name="CommandName">Command name</param>
        /// <param name="cmdType">Typo of the command</param>
        /// <param name="param">Paramter it might be OleDB or ODBC.</param>
        /// <returns></returns>
        public abstract DataTable ExecuteParamerizedSelectCommand(string CommandName, CommandType cmdType, DataParameter param);
        public abstract string ExecuteQueryDataTable(string sqlQuery);
        public abstract DataTable ExecuteSelectCommand(string CommandName, CommandType cmdType);
        public abstract DataSet LoadDataSet(string sqlQuery);
        public abstract DataSet LoadDataSetByTables(string sqlQuery, IList<string> tableAlias);
        public abstract bool Open();
        /// <summary>
        ///  Open a new db connection. The rationale is to open/close a connection in a way that connection pool is able to 
        /// </summary>
        /// <returns></returns>
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


        public async Task<Tuple<Dto,IEnumerable<RelatedDto>>> ExecuteRelatedQuery<T, T1, Dto, RelatedDto>(string sql, IMapper mapper)
        {
            var currentItem = Activator.CreateInstance<T>();
            IEnumerable<T1> relatedItems = new List<T1>();
            using (var connection = OpenNewDbConnection())
            {
                if (connection == null)
                {
                    throw new DataAccessLayerException("Cannot open a valid connection");
                }
                var multi = await connection.QueryMultipleAsync(sql);
                currentItem = multi.Read<T>().FirstOrDefault();
                if (currentItem!=null)
                {
                   relatedItems = multi.Read<T1>().ToList();
                }

            }
            IEnumerable<RelatedDto> items = new List<RelatedDto>();
            var returnTuple = new Tuple<Dto, IEnumerable<RelatedDto>>(Activator.CreateInstance<Dto>(),items);
            if (currentItem!=null)
            {
                returnTuple = new Tuple<Dto, IEnumerable<RelatedDto>>(mapper.Map<T, Dto>(currentItem), mapper.Map<IEnumerable<T1>, IEnumerable<RelatedDto>>(relatedItems));
            }
            return returnTuple;
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
        public abstract void Dispose();
    }
}
