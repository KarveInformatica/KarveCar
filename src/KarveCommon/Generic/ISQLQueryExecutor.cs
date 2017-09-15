using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KarveCommon.Generic
{
    public interface ISqlQueryExecutor
    {
        /// <summary>
        /// This method show the exact line number for the exception
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="lineNumber">Position where it happens in the code</param>
        /// <param name="caller">Stack caller</param>
        /// <returns></returns>
        /// <summary>
        /// Public method that begin a transaction
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Method for commit a transaction
        /// </summary>
        void Commit();

        /// <summary>
        ///  Method for rolling back a transaction
        /// </summary>
        void Rollback();

        /// <summary>
        /// Method for open a connection
        /// </summary>
        /// <returns>True if the open is ok.</returns>
        bool Open();

        /// <summary>
        /// Method for clsoing a connection
        /// </summary>
        /// <returns></returns>
        bool Close();

        /// <summary>
        /// Method for loading a dataset.
        /// </summary>
        /// <param name="sqlQuery">Query for loading a data set</param>
        /// <returns></returns>
        DataSet LoadDataSet(string sqlQuery);

        /// <summary>
        /// Method for loading a dataset and setting the table names.
        /// </summary>
        /// <param name="sqlQuery">Query for loading the dataset</param>
        /// <param name="tableAlias">Query for loading the tables</param>
        /// <returns></returns>
        DataSet LoadDataSetByTables(string sqlQuery, IList<string> tableAlias);

        /// <summary>
        /// Asynchronous load for loading multiple select in a data set. Each query 
        /// is supposed to be separated by a ;
        /// </summary>
        /// <param name="sqlQuery">Composed query in the data set</param>
        /// <returns>A dataset with the loaded datatable</returns>
        Task<DataSet> AsyncDataSetLoad(string sqlQuery);

        /// <summary>
        /// Update synchronosly a data set. Each update is separated by a ;
        /// </summary>
        /// <param name="sqlQuery">Query updated</param>
        /// <param name="dts">Data Set to be updated</param>
        void UpdateDataSet(string sqlQuery, ref DataSet dts);
        /// <summary>
        /// Call a stored procedure with a given name.
        /// </summary>
        /// <param name="statementProcedureName"></param>
        /// <param name="statementProcList"></param>
        void CallStoredProcedure(string statementProcedureName, IList<string> statementProcList);

        /// <summary>
        /// Execute a single select command
        /// </summary>
        /// <param name="CommandName">Text of the command.</param>
        /// <param name="cmdType">SqlCommand type: it can be a stored procedure, a text</param>
        /// <returns></returns>

        DataTable ExecuteSelectCommand(string CommandName, CommandType cmdType);

        /// <summary>
        /// Execute a sql command type and return a data table with OdbcParameters
        /// </summary>
        /// <param name="CommandName">Name of the command</param>
        /// <param name="cmdType">Type of the command</param>
        /// <param name="param">List of parameters</param>
        /// <returns></returns>
        DataTable ExecuteParamerizedSelectCommand(string CommandName, CommandType cmdType,
           IDBParameter param);

        /// <summary>
        /// Execute a query and check the row name
        /// </summary>
        /// <param name="sqlQuery">Query to execute</param>
        /// <returns></returns>
        string ExecuteQueryDataTable(string sqlQuery);

        /// <summary>
        /// Check if in a table we have two columns.
        /// </summary>
        /// <param name="tableName">Name of the table</param>
        /// <param name="columnName">Column of the table</param>
        /// <param name="whereClause">Where condition</param>
        /// <returns></returns>
        bool SameColumn(string tableName, string columnName, string whereClause);

        /// <summary>
        /// Execute an insert, update, delete with OdbcParameters. It returns with 
        /// </summary>
        /// <param name="CommandName">Parameters</param>
        /// <param name="cmdType">type of the command</param>
        /// <param name="pars">Parametes</param>
        /// <returns></returns>
        bool ExecuteNonQuery(string CommandName, CommandType cmdType, IDBParameter param);
        
    }
}
