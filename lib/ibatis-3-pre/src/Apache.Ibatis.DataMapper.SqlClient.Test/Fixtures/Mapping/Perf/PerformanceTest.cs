using System;
using System.Data;
using System.Diagnostics;
using Apache.Ibatis.DataMapper.Session;
using Apache.Ibatis.DataMapper.Session.Transaction;
using Apache.Ibatis.DataMapper.SqlClient.Test.Domain;
using NUnit.Framework;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Fixtures.Mapping.Perf
{
    [TestFixture]
    [Category("Performance")]
    public class PerformanceTest : BaseTest
    {

        #region SetUp & TearDown

        /// <summary>
        /// SetUp
        /// </summary>
        [SetUp] 
        public void Init() 
        {
            InitScript(sessionFactory.DataSource, scriptDirectory + "simple-init.sql");
        }

        /// <summary>
        /// TearDown
        /// </summary>
        [TearDown] 
        public void Dispose()
        { /* ... */ } 

        #endregion

        #region DataMapper

        /// <summary>
        /// Ibatises the only.
        /// </summary>
        [Test]       
        public void IbatisOnly()
        {
            for (int n = 2; n < 4000; n *= 2)
            {
                Simple[] simples = new Simple[n];
                object[] ids = new object[n];
                for (int i = 0; i < n; i++)
                {
                    simples[i] = new Simple();
                    simples[i].Init();
                    simples[i].Count = i;
                    simples[i].Id = i;
                }

                //Now do timings
                Stopwatch stopWatch = new Stopwatch();
                GC.Collect();
                GC.WaitForPendingFinalizers();

                ISession session = sessionFactory.OpenSession();
                stopWatch.Start();
                Ibatis(session, simples, n, "h1");
                stopWatch.Stop();
                double ibatis = 1000000 * (stopWatch.ElapsedMilliseconds  / (double)n);
                session.Close();

                session = sessionFactory.OpenSession();
                stopWatch.Start();
                Ibatis(session, simples, n, "h2");
                stopWatch.Stop();
                ibatis += 1000000 * (stopWatch.ElapsedMilliseconds / (double)n);
                session.Close();

                session = sessionFactory.OpenSession();
                stopWatch.Start();
                Ibatis(session, simples, n, "h2");
                stopWatch.Stop();
                ibatis += 1000000 * (stopWatch.ElapsedMilliseconds / (double)n);
                session.Close();

                System.Console.WriteLine("Objects: " + n + " - iBATIS DataMapper: " + ibatis.ToString("F3"));
            }
            System.GC.Collect();
        }

        private void Ibatis(ISession session, Simple[] simples, int N, string runname)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                for (int i = 0; i < N; i++)
                {
                    dataMapper.Insert("InsertSimple", simples[i]);
                }

                for (int i = 0; i < N; i++)
                {
                    simples[i].Name = "NH - " + i + N + runname + " - " + System.DateTime.Now.Ticks;
                    dataMapper.Update("UpdateSimple", simples[i]);
                }

                for (int i = 0; i < N; i++)
                {
                    dataMapper.Delete("DeleteSimple", simples[i].Id);
                }
                transaction.Complete();
            }
        } 

        #endregion

        #region ADO.NET

        [Test]
        public void AdoNetOnly()
        {
            for (int n = 2; n < 4000; n *= 2)
            {
                Simple[] simples = new Simple[n];
                for (int i = 0; i < n; i++)
                {
                    simples[i] = new Simple();
                    simples[i].Init();
                    simples[i].Count = i;
                    simples[i].Id = i;
                }

                //Now do timings
                Stopwatch stopWatch = new Stopwatch();

                IDbConnection _connection = sessionFactory.DataSource.DbProvider.CreateConnection();
                _connection.ConnectionString = sessionFactory.DataSource.ConnectionString;

                _connection.Open();

                stopWatch.Start();
                DirectAdoNet(_connection, simples, n, "j1");
                stopWatch.Stop();
                double adonet = 1000000 * (stopWatch.ElapsedMilliseconds / (double)n);
                _connection.Close();

                _connection.Open();
                stopWatch.Start();
                DirectAdoNet(_connection, simples, n, "j2");
                stopWatch.Stop();
                adonet += 1000000 * (stopWatch.ElapsedMilliseconds / (double)n);
                _connection.Close();

                _connection.Open();
                stopWatch.Start();
                DirectAdoNet(_connection, simples, n, "j2");
                stopWatch.Stop();
                adonet += 1000000 * (stopWatch.ElapsedMilliseconds / (double)n);
                _connection.Close();

                System.Console.Out.WriteLine("Objects: " + n + " Direct ADO.NET: " + adonet.ToString("F3"));
            }
            System.GC.Collect();
        }

        private void DirectAdoNet(IDbConnection c, Simple[] simples, int N, string runname)
        {
            IDbCommand insert = InsertCommand();
            IDbCommand delete = DeleteCommand();
            IDbCommand select = SelectCommand();
            IDbCommand update = UpdateCommand();

            IDbTransaction t = c.BeginTransaction();

            insert.Connection = c;
            delete.Connection = c;
            select.Connection = c;
            update.Connection = c;

            insert.Transaction = t;
            delete.Transaction = t;
            select.Transaction = t;
            update.Transaction = t;

            insert.Prepare();
            delete.Prepare();
            select.Prepare();
            update.Prepare();

            for (int i = 0; i < N; i++)
            {
                ((IDbDataParameter)insert.Parameters[0]).Value = simples[i].Name;
                ((IDbDataParameter)insert.Parameters[1]).Value = simples[i].Address;
                ((IDbDataParameter)insert.Parameters[2]).Value = simples[i].Count;
                ((IDbDataParameter)insert.Parameters[3]).Value = simples[i].Date;
                ((IDbDataParameter)insert.Parameters[4]).Value = simples[i].Pay;
                ((IDbDataParameter)insert.Parameters[5]).Value = simples[i].Id;

                insert.ExecuteNonQuery();
            }

            for (int i = 0; i < N; i++)
            {
                ((IDbDataParameter)update.Parameters[0]).Value = "DR - " + i + N + runname + " - " + System.DateTime.Now.Ticks;
                ((IDbDataParameter)update.Parameters[1]).Value = simples[i].Address;
                ((IDbDataParameter)update.Parameters[2]).Value = simples[i].Count;
                ((IDbDataParameter)update.Parameters[3]).Value = simples[i].Date;
                ((IDbDataParameter)update.Parameters[4]).Value = simples[i].Pay;
                ((IDbDataParameter)update.Parameters[5]).Value = simples[i].Id;

                update.ExecuteNonQuery();
            }

            for (int i = 0; i < N; i++)
            {
                ((IDbDataParameter)delete.Parameters[0]).Value = simples[i].Id;
                delete.ExecuteNonQuery();
            }

            t.Commit();
        }

        private IDbCommand DeleteCommand()
        {
            string sql = "delete from Simples where id = ";
            sql += sessionFactory.DataSource.DbProvider.FormatNameForSql("id");

            IDbCommand cmd = sessionFactory.DataSource.DbProvider.CreateCommand();
            cmd.CommandText = sql;

            IDbDataParameter prm = cmd.CreateParameter();
            prm.ParameterName = sessionFactory.DataSource.DbProvider.FormatNameForParameter("id");
            prm.DbType = DbType.Int32;
            cmd.Parameters.Add(prm);

            return cmd;
        }

        private IDbCommand InsertCommand()
        {
            string sql = "insert into Simples ( name, address, count, date, pay, id ) values (";
            for (int i = 0; i < 6; i++)
            {
                if (i > 0) sql += ", ";
                sql += sessionFactory.DataSource.DbProvider.FormatNameForSql("param" + i.ToString());
            }

            sql += ")";

            IDbCommand cmd = sessionFactory.DataSource.DbProvider.CreateCommand();
            cmd.CommandText = sql;
            AppendInsertUpdateParams(cmd);

            return cmd;
        }

        private IDbCommand SelectCommand()
        {
            string sql = "SELECT s.id, s.name, s.address, s.count, s.date, s.pay FROM Simples s";

            IDbCommand cmd = sessionFactory.DataSource.DbProvider.CreateCommand();
            cmd.CommandText = sql;

            return cmd;
        }

        private IDbCommand UpdateCommand()
        {
            string sql = "update Simples set";
            sql += (" name = " + sessionFactory.DataSource.DbProvider.FormatNameForSql("param0"));
            sql += (", address = " + sessionFactory.DataSource.DbProvider.FormatNameForSql("param1"));
            sql += (", count = " + sessionFactory.DataSource.DbProvider.FormatNameForSql("param2"));
            sql += (", date = " + sessionFactory.DataSource.DbProvider.FormatNameForSql("param3"));
            sql += (", pay = " + sessionFactory.DataSource.DbProvider.FormatNameForSql("param4"));
            sql += " where id = " + sessionFactory.DataSource.DbProvider.FormatNameForSql("param5");

            IDbCommand cmd = sessionFactory.DataSource.DbProvider.CreateCommand();
            cmd.CommandText = sql;

            AppendInsertUpdateParams(cmd);

            return cmd;
        }

        private void AppendInsertUpdateParams(IDbCommand cmd)
        {
            IDbDataParameter[] prm = new IDbDataParameter[6];
            for (int j = 0; j < 6; j++)
            {
                prm[j] = cmd.CreateParameter();
                prm[j].ParameterName = sessionFactory.DataSource.DbProvider.FormatNameForParameter("param" + j.ToString());
                cmd.Parameters.Add(prm[j]);
            }

            int i = 0;
            prm[i].DbType = DbType.String;
            prm[i].Size = 255;
            i++;

            prm[i].DbType = DbType.String;
            prm[i].Size = 200;
            i++;

            prm[i].DbType = DbType.Int32;
            i++;

            prm[i].DbType = DbType.DateTime;
            i++;

            prm[i].DbType = DbType.Decimal;
            prm[i].Scale = 2;
            prm[i].Precision = 5;
            i++;

            prm[i].DbType = DbType.Int32;
            i++;

        } 
        #endregion

        [Test]       
        public void Many()
        {
            double ibatis = 0;
            double adonet = 0;

            for (int n = 0; n < 5; n++)
            {
                Simple[] simples = new Simple[n];
                for (int i = 0; i < n; i++)
                {
                    simples[i] = new Simple();
                    simples[i].Init();
                    simples[i].Count = i;
                    simples[i].Id = i;
                }

                ISession session = sessionFactory.OpenSession();
                Ibatis(session, simples, n, "h0");
                session.Close();

                IDbConnection connection = sessionFactory.DataSource.DbProvider.CreateConnection();
                connection.ConnectionString = sessionFactory.DataSource.ConnectionString;

                connection.Open();
                DirectAdoNet(connection, simples, n, "j0");
                connection.Close();

                session = sessionFactory.OpenSession();
                Ibatis(session, simples, n, "h0");
                session.Close();

                connection.Open();
                DirectAdoNet(connection, simples, n, "j0");
                connection.Close();

                // now do timings

                int loops = 30;
                Stopwatch stopWatch = new Stopwatch();

                for (int runIndex = 1; runIndex < 4; runIndex++)
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    stopWatch.Start();
                    for (int i = 0; i < loops; i++)
                    {
                        session = sessionFactory.OpenSession();
                        Ibatis(session, simples, n, "h" + runIndex.ToString());
                        session.Close();
                    }
                    stopWatch.Stop();
                    ibatis += 1000000 * (stopWatch.ElapsedMilliseconds / (double)loops);

                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    stopWatch.Start();
                    for (int i = 0; i < loops; i++)
                    {
                        connection.Open();
                        DirectAdoNet(connection, simples, n, "j" + runIndex.ToString());
                        connection.Close();
                    }
                    stopWatch.Stop();
                    adonet += 1000000 * (stopWatch.ElapsedMilliseconds / (double)loops);


                }
            }
            System.Console.Out.WriteLine("iBatis DataMapper : " + ibatis.ToString("F3") + " / Direct ADO.NET: " + adonet.ToString("F3") + " Ratio: " + ((ibatis / adonet)).ToString("F3"));

            System.GC.Collect();
        }

        [Test]       
        public void Simultaneous()
        {
            double ibatis = 0;
            double adonet = 0;

            IDbConnection connection = sessionFactory.DataSource.DbProvider.CreateConnection();
            connection.ConnectionString = sessionFactory.DataSource.ConnectionString;

            for (int n = 2; n < 4000; n *= 2)
            {
                Simple[] simples = new Simple[n];
                for (int i = 0; i < n; i++)
                {
                    simples[i] = new Simple();
                    simples[i].Init();
                    simples[i].Count = i;
                    simples[i].Id = i;
                }

                ISession session = sessionFactory.OpenSession();
                Ibatis(session, simples, n, "h0");
                session.Close();

                connection.Open();
                DirectAdoNet(connection, simples, n, "j0");
                connection.Close();

                session = sessionFactory.OpenSession();
                Ibatis(session, simples, n, "h0");
                session.Close();

                connection.Open();
                DirectAdoNet(connection, simples, n, "j0");
                connection.Close();

                //Now do timings
                Stopwatch stopWatch = new Stopwatch();

                GC.Collect();
                GC.WaitForPendingFinalizers();

                session = sessionFactory.OpenSession();
                stopWatch.Start();
                Ibatis(session, simples, n, "h1");
                stopWatch.Stop();
                ibatis = 1000000 * (stopWatch.ElapsedMilliseconds / (double)n);
                session.Close();

                connection.Open();
                stopWatch.Start();
                DirectAdoNet(connection, simples, n, "j1");
                stopWatch.Stop();
                adonet = 1000000 * (stopWatch.ElapsedMilliseconds / (double)n);
                connection.Close();

                session = sessionFactory.OpenSession();
                stopWatch.Start();
                Ibatis(session, simples, n, "h2");
                stopWatch.Stop();
                ibatis += 1000000 * (stopWatch.ElapsedMilliseconds / (double)n);
                session.Close();

                connection.Open();
                stopWatch.Start();
                DirectAdoNet(connection, simples, n, "j2");
                stopWatch.Stop();
                adonet += 1000000 * (stopWatch.ElapsedMilliseconds / (double)n);
                connection.Close();

                session = sessionFactory.OpenSession();
                stopWatch.Start();
                Ibatis(session, simples, n, "h2");
                stopWatch.Stop();
                ibatis += 1000000 * (stopWatch.ElapsedMilliseconds / (double)n);
                session.Close();

                connection.Open();
                stopWatch.Start();
                DirectAdoNet(connection, simples, n, "j2");
                stopWatch.Stop();
                adonet += 1000000 * (stopWatch.ElapsedMilliseconds / (double)n);
                connection.Close();
                System.Console.Out.WriteLine("Objects " + n + " iBATIS DataMapper : " + ibatis.ToString("F3") + " / Direct ADO.NET: " + adonet.ToString("F3") + " Ratio: " + ((ibatis / adonet)).ToString("F3"));
            }

            System.GC.Collect();
        }

    }
}