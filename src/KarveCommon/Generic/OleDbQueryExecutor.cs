using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using KarveCommon.Generic;
using iAnywhere.Data.SQLAnywhere;

namespace KarveCommon.Generic
{
    
    public class OleDbQueryExecutor: AbstractSqlQueryExecutor
    {
        private SAConnection _connection;
        private SADataAdapter _adapter;
        private SACommandBuilder  _builder;
        private SACommand _command;
        private SATransaction _transaction;
        private string _connectionString;
        private ConnectionState _currentState;
        private object asyncLoadLock = new object();
        private string _defaultConnectionString = "EngineName=DBRENT_NET16;DataBaseName=DBRENT_NET16;Uid=cv;Pwd=1929;Host=172.26.0.45";
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; _connection = new SAConnection(_connectionString); }
        }
        public OleDbQueryExecutor()
        {
            _connectionString = _defaultConnectionString;
        }
        public OleDbQueryExecutor(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new SAConnection(_connectionString);
        }
        public override void BeginTransaction()
        {
            if (_currentState != ConnectionState.Open) Open();
            _transaction = _connection.BeginTransaction();
        }

        public override void Commit()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
            }
            if (_currentState == ConnectionState.Open) Close();

        }

        public override void Rollback()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
            }
            if (_currentState == ConnectionState.Open) Close();
        }

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
            catch (Exception e)
            {
                return false;
            }
            return true;
            
        }

        public override bool Close()
        {
            try
            {
                if (_currentState != ConnectionState.Closed)
                {
                    _connection.Close();
                    _currentState = _connection.State;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public override DataSet LoadDataSet(string sqlQuery)
        {

            DataSet dts = new DataSet();
            try
            {
                if (_transaction == null)
                {
                    Open();
                    _command = new SACommand(sqlQuery, _connection);
                }
                else
                {
                    _command = new SACommand(sqlQuery, _connection, _transaction);
                }
                SADataAdapter dta = new SADataAdapter(_command);
               
                dta.FillSchema(dts, SchemaType.Source);
                dta.Fill(dts);
                if (_transaction == null)
                {
                    Close();
                }
            }
            catch (Exception e)
            {
                if (_transaction != null)
                {
                    _transaction.Rollback();
                }
                string msg = "Loading dataset error :" + e.Message;
                throw new Exception(msg);
            }
            finally
            {
                Close();
            }
            return dts;

        }

        public override DataSet LoadDataSetByTables(string sqlQuery, IList<string> tableAlias)
        {
            DataSet ds = LoadDataSet(sqlQuery);


            if (_transaction == null)
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

        public override void UpdateDataSet(string sqlQuery, ref DataSet dts)
        {

          
            SACommand cmd = null;
            try
            {
                if (_transaction!= null && _currentState != ConnectionState.Open)
                {
                    Open();
                }
                if (dts.HasChanges())
                {
                    int i = 0;
                    IList<string> queryPart = Regex.Split(sqlQuery, ";");
                    foreach (DataTable table in dts.Tables)
                    {
                        if (_transaction == null)
                        {
                            cmd = new SACommand(queryPart[i++], _connection);
                        }
                        else
                        {
                            cmd = new SACommand(queryPart[i++], _connection, _transaction);
                        }
                        SADataAdapter dta = new SADataAdapter(cmd);
                        SACommandBuilder commandBuilder = new SACommandBuilder(dta);
                        dta.Update(table );                        
                    }
                }                
            }
            catch (Exception e)
            {
                if (_transaction != null && _currentState != ConnectionState.Open)
                {
                    Rollback();
                }
                string msg = "DataAccessLayer Error: " + ShowMessage(e.Message);
                throw new Exception(msg);
            }
            finally
            {
                if (_transaction == null && _currentState == ConnectionState.Open) Close();
                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }
        }

        public override Task<DataTable> QueryAsyncForDataTable(string sqlQuery, string code)
        {
            throw new NotImplementedException();
        }

        public override Task<T> QueryAsyncForObject<T>(string v, T parameter)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> ExecuteUpdateAsyncBatch()
        {
            throw new NotImplementedException();
        }

        public override DataTable QueryForDataTable(string v, long pos)
        {
            throw new NotImplementedException();
        }

        public override Task<T> QueryAsyncForObjectSession<T>(string v, string supplierId, ISqlSession session)
        {
            throw new NotImplementedException();
        }

        public override ISqlSession OpenSession()
        {
            throw new NotImplementedException();
        }

        public override void CloseSession(ISqlSession sqlSession)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Create a OdbcCommand from a transaction 
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns>An OdbcCommand</returns>
        private SACommand CommandTransaction(string sqlString)
        {
            SACommand cmd = null;
            if (_transaction == null)
            {
                Open();
                cmd = new SACommand(sqlString, _connection);
            }
            else
            {
                cmd = new SACommand(sqlString, _connection, _transaction);
            }
            return cmd;
        }
        /// <summary>
        /// Close a connection if a transaction is not active.
        /// </summary>
        private void CloseInTransaction()
        {
            if (_transaction != null)
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
                SACommand command = CommandTransaction(sqlString);

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
        public override DataTable ExecuteSelectCommand(string CommandName, CommandType cmdType)
        {
            SACommand cmd = null;
            DataTable table = new DataTable();

            cmd = _connection.CreateCommand();

            cmd.CommandType = cmdType;
            cmd.CommandText = CommandName;

            try
            {
                _connection.Open();

               SADataAdapter da = null;
                using (da = new SADataAdapter(cmd))
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

        public override DataTable ExecuteParamerizedSelectCommand(string CommandName, CommandType cmdType, IDBParameter param)
        {
            return ExecuteParamerizedSelectCommand(CommandName, cmdType, param.oleDbParameters);
        }

        public DataTable ExecuteParamerizedSelectCommand(string CommandName, CommandType cmdType, SAParameter[] param)
        {
            SACommand cmd = null;
            DataTable table = new DataTable();
            cmd = _connection.CreateCommand();
            cmd.CommandType = cmdType;
            cmd.CommandText = CommandName;
            cmd.Parameters.AddRange(param);

            try
            {
                _connection.Open();

                SADataAdapter da = null;
                using (da = new SADataAdapter(cmd))
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
        /// Execute an insert, update, delete with OdbcParameters. It returns with 
        /// </summary>
        /// <param name="CommandName">Parameters</param>
        /// <param name="cmdType">type of the command</param>
        /// <param name="pars">Parametes</param>
        /// <returns></returns>
        public  bool ExecuteNonQuery(string CommandName, CommandType cmdType, SAParameter[] pars)
        {
            SACommand cmd = null;
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

        public override bool ExecuteNonQuery(string CommandName, CommandType cmdType, IDBParameter pars)
        {
            return ExecuteNonQuery(CommandName, cmdType, pars.oleDbParameters);
        }

        public override async Task<DataSet> AsyncDataSetLoad(string sqlQuery)
        {
            DataSet dts = new DataSet();
            SADataAdapter dta = null;
            lock (asyncLoadLock)
            {
                try
                {
                    if (_transaction == null)
                    {
                        Open();
                        _command = new SACommand(sqlQuery, _connection);
                    }
                    else
                    {
                        _command = new SACommand(sqlQuery, _connection, _transaction);
                    }
                    dta = new SADataAdapter(_command);

                }
                catch (Exception e)
                {
                    if (_transaction != null)
                    {
                        _transaction.Rollback();
                    }
                    string msg = "Loading dataset error :" + e.Message;
                    throw new Exception(msg);
                }
            }
            if (dta != null)
            {
                try
                {
                    await Task.Run(() =>
                    {
                        dta.FillSchema(dts, SchemaType.Source);
                        dta.Fill(dts);
                    });
                }
                catch (Exception e)
                {
                    if (_transaction != null)
                    {
                        _transaction.Rollback();
                    }
                    string msg = "Loading dataset error :" + e.Message;
                    throw new Exception(msg);
                }
                finally
                {
                    Close();
                }
            }
            return dts;
        }
    }
}
