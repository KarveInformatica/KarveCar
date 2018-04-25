using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Threading.Tasks;
using iAnywhere.Data.SQLAnywhere;
using System;

namespace KarveDataServices
{
    /// <summary>
    /// This gives you the data parameters.
    /// </summary>
    public class DataParameter
    {
        /// <summary>
        ///  OdbcParamters
        /// </summary>
        public OdbcParameter[] OdbcParameters { set; get; }
        /// <summary>
        /// SAParameters
        /// </summary>
        public SAParameter[] OleDbParameters { set; get; }
    }
    /// <summary>
    /// This is the sql executor needed for the opening and interfacing the database.
    /// </summary>
    public interface ISqlExecutor: IDisposable
    {

        /// <summary>
        ///  Database connection string.
        /// </summary>
        string ConnectionString { set; get; }
        /// <summary>
        /// This value returns the current connection state.
        /// </summary>
        ConnectionState State { get; }
        /// <summary>
        /// Connection. 
        /// This is the connection of a value.
        /// </summary>
        IDbConnection Connection { set; get; }
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
        /// <returns>Return true if the close is ok.</returns>
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
        /// <param name="commandName">Text of the command.</param>
        /// <param name="cmdType">SqlCommand type: it can be a stored procedure, a text</param>
        /// <returns></returns>

        DataTable ExecuteSelectCommand(string commandName, CommandType cmdType);

        /// <summary>
        /// Execute a sql command type and return a data table with OdbcParameters
        /// </summary>
        /// <param name="commandName">Name of the command</param>
        /// <param name="cmdType">Type of the command</param>
        /// <param name="param">List of parameters</param>
        /// <returns></returns>
        DataTable ExecuteParamerizedSelectCommand(string commandName, CommandType cmdType,
           DataParameter param);

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
        /// <param name="commandName">Parameters</param>
        /// <param name="cmdType">Type of the command</param>
        /// <param name="param">Parameters</param>
        /// <returns></returns>
        bool ExecuteNonQuery(string commandName, CommandType cmdType, DataParameter param);
        /// <summary>
        ///  This method loads in a batch a set of queries
        /// </summary>
        /// <param name="queryList">A list of queries separated by a semicolon</param>
        /// <returns>Returns a  list of datasets.</returns>
        Task<DataSet> AsyncDataSetLoadBatch(IDictionary<string, string> queryList);

        /// <summary>
        /// This returns the datatable for asynchronous objects.
        /// </summary>
        /// <param name="sqlQuery">Query to be listed.</param>
        /// <returns></returns>
        Task<DataTable> QueryAsyncForDataTable(string sqlQuery);
        /// <summary>
        ///  Create a new connection with the current connection string.
        /// </summary>
        /// <returns>Returns a new connection</returns>
        IDbConnection OpenNewDbConnection();

    }
}
