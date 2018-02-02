using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveDataServices;
using NLog;

namespace DataAccessLayer.SQL
{
    /// <summary>
    /// Summary description for DataAccess
    /// </summary>
    public class OdbcExecutor: AbstractSqlExecutor
    {
        private OdbcConnection _connection = null;
        private ConnectionState _currentState;
        private OdbcTransaction _sqlTransaction = null;
        private string _connectionString;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// This method is a sql command wrapper for sending command to the database.
        /// </summary>
        /// <param name="connectionString">OBDC connection string</param>
        public OdbcExecutor(string connectionString)
        {
            _connectionString = connectionString;
            _connection = InitConnection(_connectionString);
        }
        /// <summary>
        /// Public method that begin a transaction
        /// </summary>
        public override void BeginTransaction()
        {
            _sqlTransaction = _connection.BeginTransaction();
        }
        /// <summary>
        /// Method for commit a transaction
        /// </summary>
        public override void Commit()
        {
            if (_sqlTransaction != null)
            {
                _sqlTransaction.Commit();
            }
        }

        public override IDbConnection OpenNewDbConnection()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Method for rolling back a transaction
        /// </summary>
        public override void Rollback()
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
        public override bool Open()
        {
            try
            {
                if (_currentState != ConnectionState.Open)
                {
                    _connection.Open();
                    _currentState = _connection.State;
                }
            }
            catch (System.Exception e)
            {
                logger.Error(e, "Error opening the OdbcQuertExecutor");
                return false;
            }
            return true;
        }
        /// <summary>
        /// Method for closing a connection
        /// </summary>
        /// <returns></returns>
        public override bool Close()
        {
            try
            {
                if (_currentState != ConnectionState.Closed)
                {
                    _connection.Close();
                }
            }
            catch (System.Exception e)
            {
                logger.Error(e, "Error closing the OdbcQuertExecutor");
                return false;
            }
            return true;
        }
        /// <summary>
        /// Method for loading a dataset.
        /// </summary>
        /// <param name="sqlQuery">Query for loading a data set</param>
        /// <returns></returns>
        public override DataSet LoadDataSet(string sqlQuery)
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
            catch (System.Exception e)
            {

                Rollback();
                logger.Error(e, "Error loading the data set");

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
        public override DataSet LoadDataSetByTables(string sqlQuery, IList<string> tableAlias)
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

        private async Task<DataTable> AsyncLoadTable(string sqlQuery, OdbcTransaction dbTransaction)
        {

            object region = new object();
            OdbcCommand cmd = null;
            DataTable table = new DataTable();
            OdbcDataAdapter dataAdapter = null;
            if (_connection.State != ConnectionState.Open)
            {
                _connection.ConnectionString = _connectionString;

                await _connection.OpenAsync();
            }
            try
            {
                lock (region)
                {
                    cmd = new OdbcCommand(sqlQuery, _connection, dbTransaction);
                    table = new DataTable();
                    dataAdapter = new OdbcDataAdapter(cmd);
                }
                await Task.Run(() =>
                {
                    dataAdapter.Fill(table);
                }).ConfigureAwait(false);
            }
            finally
            {
                Close();
                dataAdapter?.Dispose();

                cmd?.Dispose();
            }
            return table;
        }
        /// <summary>
        /// Asynchronous load for loading multiple select in a data set. Each query 
        /// is supposed to be separated by a ;
        /// </summary>
        /// <param name="sqlQuery">Composed query in the data set</param>
        /// <returns>A dataset with the loaded datatable</returns>
        public override async Task<DataSet> AsyncDataSetLoad(string sqlQuery)

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
            catch (System.Exception e)
            {
                set = null;
            }
            finally
            {
                Close();
                set?.Dispose();
                cmd?.Dispose();
                da?.Dispose();
                
            }
            return set;
        }

        public override ConnectionState State { get; }
        public override IDbConnection Connection { get; set; }

        
        public override async Task<DataTable> QueryAsyncForDataTable(string sqlQuery)
        {

            if (_connection.State != ConnectionState.Open)
            {
                _connection.ConnectionString = _connectionString;

                await _connection.OpenAsync();
            }
            DataTable table = new DataTable();
            OdbcTransaction dbTransaction = _connection.BeginTransaction();
            try
            {
                table = await AsyncLoadTable(sqlQuery, dbTransaction).ConfigureAwait(false);
            }
            catch (System.Exception ex)
            {
                Close();
            }
            finally
            {
                table.Dispose();
            }
            return table;
        }
        /// <summary>
        /// Update synchronosly a data set. Each update is separated by a ;
        /// </summary>
        /// <param name="sqlQuery">Query updated</param>
        /// <param name="dts">Data Set to be updated</param>
        public override void UpdateDataSet(string sqlQuery, ref DataSet dts)
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
            catch (System.Exception e)
            {
                if (_sqlTransaction != null)
                {
                    Rollback();
                }
                string msg = "DataAccessLayer Error: " + ShowMessage(e.Message);
                throw new System.Exception(msg);
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

       

       
        public override IList<string> ExecuteQueryFields(string sqlQuery)
        {
            throw new NotImplementedException();
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
        public override void CallStoredProcedure(string statementProcedureName, IList<string> statementProcList)
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
            catch (System.Exception e)
            {
                Rollback();
                string msg = "DataAccessLayer Error: " + ShowMessage(e.Message);
                throw new System.Exception(msg);
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

        public override DataTable ExecuteSelectCommand(string CommandName, CommandType cmdType)
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
            catch (System.Exception ex)
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

        

        public override DataTable ExecuteParamerizedSelectCommand(string CommandName, CommandType cmdType, DataParameter param)
        {
            return ExecuteParamerizedSelectCommand(CommandName, cmdType, param.OdbcParameters);
        }

        /// <summary>
        /// Execute a sql command type and return a data table with OdbcParameters
        /// </summary>
        /// <param name="CommandName">Name of the command</param>
        /// <param name="cmdType">Type of the command</param>
        /// <param name="param">List of parameters</param>
        /// <returns></returns>
        public DataTable ExecuteParamerizedSelectCommand(string CommandName, CommandType cmdType, OdbcParameter[] p)
        {
            OdbcCommand cmd = null;
            OdbcParameter[] param = p;

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
            catch (System.Exception ex)
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
        public override string ExecuteQueryDataTable(string sqlQuery)
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
        /// Execute no query solution.
        /// </summary>
        /// <param name="CommandName">Name of the commnad</param>
        /// <param name="cmdType">Type of the commnad</param>
        /// <param name="params">Parameters</param>
        /// <returns></returns>
        public override bool ExecuteNonQuery(string CommandName, CommandType cmdType, DataParameter pars)
        {
            return ExecuteNonQuery(CommandName, cmdType, pars.OdbcParameters);
        }
        /// <summary>
        ///  Load a a batch of query from a dataset
        /// TODO: Implemenet this.
        /// </summary>
        /// <param name="queryList"></param>
        /// <returns></returns>
        public override Task<DataSet> AsyncDataSetLoadBatch(IDictionary<string, string> queryList)
        {
            throw new NotImplementedException();
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
            catch (System.Exception ex)
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
            catch (System.Exception e)
            {
                string msg = "DataAccessLayer Error: " + ShowMessage(e.Message);
                throw new System.Exception(msg);
            }
            return _connection;
        }

    }
}
