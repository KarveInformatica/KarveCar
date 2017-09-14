using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Odbc;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;


namespace KarveCommon.Generic
{
    /// <summary>
    /// Summary description for DataAccess
    /// </summary>
    public class SQLQueryExecutor
    {
        private OdbcConnection _connection = null;
        private ConnectionState _currentState;
        private OdbcTransaction _sqlTransaction = null;
        private string _connectionString;
        /// <summary>
        /// This method is a sql command wrapper for sending command to the database.
        /// </summary>
        /// <param name="connectionString">OBDC connection string</param>
        public SQLQueryExecutor(string connectionString)
        {
            _connectionString = connectionString;
            _connection = InitConnection(_connectionString);
        }
        /// <summary>
        /// This method show the exact line number for the exception
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="lineNumber">Position where it happens in the code</param>
        /// <param name="caller">Stack caller</param>
        /// <returns></returns>
        private string ShowMessage(string message,
            [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string caller = null)
        {
            string outMessage = message + " at line " + lineNumber + " (" + caller + ")";
            return outMessage;
        }
        /// <summary>
        /// Public method that begin a transaction
        /// </summary>
        public void BeginTransaction()
        {
            _sqlTransaction = _connection.BeginTransaction();
        }
        /// <summary>
        /// Method for commit a transaction
        /// </summary>
        public void Commit()
        {
            if (_sqlTransaction != null)
            {
                _sqlTransaction.Commit();
            }
        }
        /// <summary>
        ///  Method for rolling back a transaction
        /// </summary>
        public void Rollback()
        {
            if (_sqlTransaction != null)
            {
                _sqlTransaction.Rollback();
            }
        }
        
        /// <summary>
        /// Method for open a connection
        /// </summary>
        /// <returns>True if the open is ok.</returns>
        public bool Open()
        {
            try
            {
                if (_currentState != ConnectionState.Open)
                {
                    _connection.Open();
                    _currentState = _connection.State;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Method for clsoing a connection
        /// </summary>
        /// <returns></returns>
        public bool Close()
        {
            try
            {
                if (_currentState != ConnectionState.Closed)
                {
                    _connection.Close();
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Method for loading a dataset.
        /// </summary>
        /// <param name="sqlQuery">Query for loading a data set</param>
        /// <returns></returns>
        public DataSet LoadDataSet(string sqlQuery)
        {
            DataSet dts = new DataSet();
            bool dataValue = false;
            if (_sqlTransaction == null)
            {
                dataValue = Open();
            }
            try
            {
                if (dataValue)
                {
                    OdbcDataAdapter dataAdapter = new OdbcDataAdapter(sqlQuery, _connection);
                    dataAdapter.FillSchema(dts, SchemaType.Source);
                    dataAdapter.Fill(dts);
                }
            }
            catch (Exception e)
            {

                Rollback();

            }
            finally
            {
                if (_sqlTransaction != null)
                {
                    Close();
                }
            }
            return dts;
        }
        /// <summary>
        /// Method for loading a dataset and setting the table names.
        /// </summary>
        /// <param name="sqlQuery">Query for loading the dataset</param>
        /// <param name="tableAlias">Query for loading the tables</param>
        /// <returns></returns>
        public DataSet LoadDataSetByTables(string sqlQuery, IList<string> tableAlias)
        {
            DataSet ds = LoadDataSet(sqlQuery);


            if (_sqlTransaction == null)
            {
                int i = 0;
                foreach (DataTable t in ds.Tables)
                {
                    if (i < tableAlias.Count)
                    {
                        t.TableName = tableAlias[i++];
                    }
                }
            }
            return ds;
        }
        /// <summary>
        /// Asynchronous load for loading multiple select in a data set. Each query 
        /// is supposed to be separated by a ;
        /// </summary>
        /// <param name="sqlQuery">Composed query in the data set</param>
        /// <returns>A dataset with the loaded datatable</returns>
        public async Task<DataSet> AsyncDataSetLoad(string sqlQuery)

        {
            DataSet set = new DataSet();
            DataTable table = null;
            OdbcDataAdapter da = null;
            OdbcCommand cmd = null;

            try
            {
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.ConnectionString = _connectionString;

                    await _connection.OpenAsync();
                }

                OdbcTransaction dbTransaction = _connection.BeginTransaction();
                IList<string> queryPart = Regex.Split(sqlQuery, ";");
                object region = new object();
                int i = 0;
               
                foreach (string query in queryPart)
                {
                    lock (region)
                    {
                        cmd = new OdbcCommand(queryPart[i++], _connection, dbTransaction);
                        table = new DataTable();
                        da = new OdbcDataAdapter(cmd);
                    }
                    await Task.Run(() =>
                    {
                        da.Fill(table);
                    }).ConfigureAwait(false);
                    set.Tables.Add(table);
                }
            }
            catch (Exception e)
            {
                Close();
                set = null;
            }
            finally
            {
                set.Dispose();
                if (cmd != null)
                {
                    cmd.Dispose();
                }
                if (da != null)
                {
                    da.Dispose();
                }
            }
            return set;
        }
        /// <summary>
        /// Update synchronosly a data set. Each update is separated by a ;
        /// </summary>
        /// <param name="sqlQuery">Query updated</param>
        /// <param name="dts">Data Set to be updated</param>
        public void UpdateDataSet(string sqlQuery, ref DataSet dts)
        {
            OdbcCommand cmd = null;

            try
            {
                if (_sqlTransaction != null)
                {
                    Open();
                }
                if (dts.HasChanges())
                {
                    int i = 0;
                    IList<string> queryPart = Regex.Split(sqlQuery, ";");
                    foreach (DataTable table in dts.Tables)
                    {
                        if (_sqlTransaction != null)
                        {
                            cmd = new OdbcCommand(queryPart[i++], _connection);
                        }
                        else
                        {
                            cmd = new OdbcCommand(queryPart[i++], _connection, _sqlTransaction);
                        }
                        OdbcDataAdapter dta = new OdbcDataAdapter(cmd);
                        OdbcCommandBuilder commandBuilder = new OdbcCommandBuilder(dta);
                        dta.Update(table);
                    }
                }
                if (_sqlTransaction != null)
                {
                    Close();
                }
            }
            catch (Exception e)
            {
                if (_sqlTransaction != null)
                {
                    Rollback();
                }
                string msg = "DataAccessLayer Error: " + ShowMessage(e.Message);
                throw new Exception(msg);
            }
            finally
            {
                Close();
                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }
        }
        /// <summary>
        /// Create a OdbcCommand from a transaction 
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns>An OdbcCommand</returns>
        private OdbcCommand CommandTransaction(string sqlString)
        {
            OdbcCommand cmd = null;
            if (_sqlTransaction == null)
            {
                Open();
                cmd = new OdbcCommand(sqlString, _connection);
            }
            else
            {
                cmd = new OdbcCommand(sqlString, _connection, _sqlTransaction);
            }
            return cmd;
        }
        /// <summary>
        /// Close a connection if a transaction is not active.
        /// </summary>
        private void CloseInTransaction()
        {
            if (_sqlTransaction != null)
            {
                Close();
            }
        }
        /// <summary>
        /// Calls a stored procedure if needed.
        /// </summary>
        /// <param name="statementProcedureName">Stored procedure name</param>
        /// <param name="statementProcList">List of parameters for a stored procedure</param>
        public void CallStoredProcedure(string statementProcedureName, IList<string> statementProcList)
        {
            string sqlString = "";
            string sqlParams = "";

            foreach (string param in statementProcList)
            {
                if (!string.IsNullOrEmpty(sqlString))
                {
                    sqlString = sqlString + ",";
                }
                sqlParams = sqlParams + "'" + param + "'";
            }
            sqlString = "call " + statementProcedureName + " (" + sqlParams + ")";
            try
            {
                OdbcCommand command = CommandTransaction(sqlString);

                if (command != null)
                {
                    command.ExecuteScalar();
                }

            }
            catch (Exception e)
            {
                Rollback();
                string msg = "DataAccessLayer Error: " + ShowMessage(e.Message);
                throw new Exception(msg);
            }
            finally
            {
                CloseInTransaction();
            }

        }
        /// <summary>
        /// Execute a single select command
        /// </summary>
        /// <param name="CommandName">Text of the command.</param>
        /// <param name="cmdType">SqlCommand type: it can be a stored procedure, a text</param>
        /// <returns></returns>
        
        public DataTable ExecuteSelectCommand(string CommandName, CommandType cmdType)
        {
            
            OdbcCommand cmd = null;
            DataTable table = new DataTable();

            cmd = _connection.CreateCommand();

            cmd.CommandType = cmdType;
            cmd.CommandText = CommandName;

            try
            {
                _connection.Open();

                OdbcDataAdapter da = null;
                using (da = new OdbcDataAdapter(cmd))
                {
                    da.Fill(table);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
                _connection.Close();
            }

            return table;
        }
        /// <summary>
        /// Execute a sql command type and return a data table with OdbcParameters
        /// </summary>
        /// <param name="CommandName">Name of the command</param>
        /// <param name="cmdType">Type of the command</param>
        /// <param name="param">List of parameters</param>
        /// <returns></returns>
        public DataTable ExecuteParamerizedSelectCommand(string CommandName, CommandType cmdType, OdbcParameter[] param)
        {
            OdbcCommand cmd = null;
            DataTable table = new DataTable();

            cmd = _connection.CreateCommand();

            cmd.CommandType = cmdType;
            cmd.CommandText = CommandName;
            cmd.Parameters.AddRange(param);

            try
            {
                _connection.Open();

                OdbcDataAdapter da = null;
                using (da = new OdbcDataAdapter(cmd))
                {
                    da.Fill(table);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
                _connection.Close();
            }

            return table;
        }
        /// <summary>
        /// Execute a query and check the row name
        /// </summary>
        /// <param name="sqlQuery">Query to execute</param>
        /// <returns></returns>
        public string ExecuteQueryDataTable(string sqlQuery)
        {
            DataSet dts = LoadDataSet(sqlQuery);
            string executeQueryString = "";
            bool hasRow = (dts.Tables.Count > 0) && (dts.Tables[0].Rows.Count > 0);
            if (hasRow)
            {
                DataRow row = dts.Tables[0].Rows[0];
                executeQueryString = row.ItemArray[0] as string;
            }
            return executeQueryString;
        }
        /// <summary>
        /// Check if in a table we have two columns.
        /// </summary>
        /// <param name="tableName">Name of the table</param>
        /// <param name="columnName">Column of the table</param>
        /// <param name="whereClause">Where condition</param>
        /// <returns></returns>
        public bool SameColumn(string tableName, string columnName, string whereClause)
        {
            string sqlString = string.Format(" SELECT {0} FROM {1} {2}", columnName, tableName, whereClause);
            string value = ExecuteQueryDataTable(sqlString);
            return (!string.IsNullOrEmpty(value));
        }
        /// <summary>
        /// Execute an insert, update, delete with OdbcParameters. It returns with 
        /// </summary>
        /// <param name="CommandName">Parameters</param>
        /// <param name="cmdType">type of the command</param>
        /// <param name="pars">Parametes</param>
        /// <returns></returns>
        public bool ExecuteNonQuery(string CommandName, CommandType cmdType, OdbcParameter[] pars)
        {
            OdbcCommand cmd = null;
            int res = 0;
            cmd = _connection.CreateCommand();
            cmd.CommandType = cmdType;
            cmd.CommandText = CommandName;
            cmd.Parameters.AddRange(pars);

            try
            {
                _connection.Open();

                res = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
                _connection.Close();
            }

            if (res >= 1)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Method for opening a connection
        /// </summary>
        /// <param name="connectionString">Connection</param>
        /// <returns></returns>
        private OdbcConnection InitConnection(string connectionString)
        {
            try
            {
                _connection = new OdbcConnection(connectionString);

            }
            catch (Exception e)
            {
                string msg = "DataAccessLayer Error: " + ShowMessage(e.Message);
                throw new Exception(msg);
            }
            return _connection;
        }

    }
}
