using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;
using Dapper;
using DataAccessLayer.DataObjects.Wrapper;
using DataAccessLayer.Model;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using DataAccessLayer.DataObjects;
using KarveDapper.Extensions;
using KarveDapper;
using KarveDataServices;
using SqlMapperExtensions = KarveDapper.Extensions.SqlMapperExtensions;

namespace DataAccessLayer
{

    /// <summary>
    ///  This class is responsabile for the handling of the application settings. 
    /// For allowing multiple clients 
    /// </summary>
    public class SettingsDataService : ISettingsDataService
    {
        private readonly ISqlExecutor _executorSql;


        private string _selectColumns =
                "SELECT USER_LUPAS_COLUMNAS.ID_COL as ID_COL, USER_LUPAS_COLUMNAS.ID_LUPA as ID_LUPA, USER_LUPAS_COLUMNAS.COLUMNA_NOMBRE as COLUMNA_NOMBRE," +
                "USER_LUPAS_COLUMNAS.VISIBLE as VISIBLE, USER_LUPAS_COLUMNAS.POSICION as POSICION, USER_LUPAS_COLUMNAS.ANCHO as ANCHO " +
                "FROM  USER_LUPAS INNER JOIN USER_LUPAS_COLUMNAS ON USER_LUPAS_COLUMNAS.ID_LUPA = USER_LUPAS.ID WHERE USER_LUPAS.ID= '{0}';"
            ;


        private string _sqlQuery = @"SELECT USER_LUPAS.ID as ID, 
                                     USER_LUPAS.USUARIO as USUARIO,
                                     USER_LUPAS.LUPA as LUPA, 
                                     USER_LUPAS.NOMBRE as NOMBRE,
                                     USER_LUPAS.DEFECTO as DEFECTO,
                                     USER_LUPAS.PUBLICA as PUBLICA,
                                     USER_LUPAS.ULTMODI as ULTMODI
                                     FROM  USER_LUPAS WHERE USER_LUPAS.ID='{0}';";

        private string _sqlDelete = @"DELETE FROM USER_LUPAS WHERE USER_LUPAS.ID='{0}'";
        private string _sqlDeleteColumns = @"DELETE FROM  USER_LUPAS_COLUMNAS WHERE  USER_LUPAS_COLUMNAS.ID_LUPA='{0}'";

        private string _sqlQueryAll = @"SELECT USER_LUPAS.ID as Identifier, 
                                     USER_LUPAS.USUARIO as UserName,
                                     USER_LUPAS.LUPA as Magnifier, 
                                     USER_LUPAS.NOMBRE as Name,
                                     USER_LUPAS.DEFECTO as Defect,
                                     USER_LUPAS.PUBLICA as Public,
                                     USER_LUPAS.ULTMODI as LastModification,
                                     USER_LUPAS_COLUMNAS.ID_LUPA as ID_LUPA,
                                     USER_LUPAS_COLUMNAS.COLUMNA_NOMBRE as COLUMNA_NOMBRE,
                                     USER_LUPAS_COLUMNAS.VISIBLE as VISIBLE,
                                     USER_LUPAS_COLUMNAS.POSICION as POSICION,
                                     USER_LUPAS_COLUMNAS.ANCHO as ANCHO
                                     FROM  USER_LUPAS INNER JOIN USER_LUPAS_COLUMNAS ON USER_LUPAS_COLUMNAS.ID_LUPA;";

        /// <summary>
        ///  Settings data service.
        /// </summary>
        /// <param name="executor">Setting data service</param>
        public SettingsDataService(ISqlExecutor executor)
        {
            _executorSql = executor;
        }

        /// <summary>
        ///  This returns the settings foreach columns and summary view.
        /// </summary>
        /// <returns></returns>
        public async Task<IList<IMagnifierSettings>> GetAllMagnifiersSettings()
        {
            var magnifierList = await GetSettings(_sqlQueryAll, _selectColumns);
            return magnifierList;
        }

        /// <summary>
        ///  This returns the columns settings for each columns and for each summary view.
        /// </summary>
        /// <param name="idValue">Identifier of the magnifier</param>
        /// <returns></returns>
        public async Task<IMagnifierSettings> GetMagnifierSettings(long idValue)
        {

            var simpleQuery = string.Format(_sqlQuery, idValue);
            var magnifierSetting = await GetSettings(simpleQuery, _selectColumns);
            return magnifierSetting.FirstOrDefault();
        }

        /// <summary>
        /// Executor magnifier settings.
        /// </summary>
        /// <returns></returns>
        private async Task<IList<IMagnifierSettings>> GetSettings(string stringQuery, string colsQuery)
        {
            Contract.Assert(_executorSql != null);
            IList<IMagnifierSettings> currentMagnifierSetting = new List<IMagnifierSettings>();
            using (IDbConnection connection = _executorSql.OpenNewDbConnection())
            {
                try
                {
                    // TODO: find a better performance way. 
                    var magnifierList = await connection.QueryAsync<MagnifierSettings>(stringQuery);
                    foreach (var m in magnifierList)
                    {
                        string cols = string.Format(colsQuery, m.ID);
                        m.MagnifierColumns = await connection.QueryAsync<MagnifierColumns>(cols);
                        currentMagnifierSetting.Add(m);
                    }
                    connection.Close();
                }
                catch (System.Exception e)
                {
                    throw new DataLayerExecutionException(e.Message, e);
                }
                finally
                {
                    // not user if using dispose in case of exception.
                    connection.Dispose();
                }
            }
            return currentMagnifierSetting;
        }

        /// <summary>
        ///  Save magnifier settings
        /// </summary>
        /// <param name="value">Value of the settings</param>
        /// <returns></returns>
        public async Task<bool> SaveMagnifierSettings(IMagnifierSettings value)
        {
            MagnifierSettings settings = value as MagnifierSettings;
            bool ret = true;
            if (settings == null)
                return false;
            // shall check if the magnifier setting already exist
            USER_LUPAS magnifierDo = new USER_LUPAS();
            magnifierDo.DEFECTO = settings.DEFECTO;
            magnifierDo.ID = settings.ID;
            magnifierDo.LUPA = settings.LUPA;
            magnifierDo.NOMBRE = settings.NOMBRE;
            magnifierDo.PUBLICA = settings.PUBLICA;
            magnifierDo.ULTMODI = DateTime.Now.ToLongTimeString();
            magnifierDo.USUARIO = settings.USUARIO;
            IMagnifierSettings setting2 = await GetMagnifierSettings(magnifierDo.ID);
            if (setting2 != null)
            {
                // Update
                ret = await UpdateMagnifierSettings(value);
            }
            else
            {
                // insert
                ret = await InsertMagnifierSettings(value);
            }
            return ret;
        }

        private async Task<bool> InsertMagnifierSettings(IMagnifierSettings input)
        {
            MagnifierSettings settings = input as MagnifierSettings;
            bool retValue = true;
            if (settings == null)
                return false;
            using (IDbConnection connection = _executorSql.OpenNewDbConnection())
            {
                try
                {

                    using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        USER_LUPAS magnifierDo = new USER_LUPAS();
                        magnifierDo.DEFECTO = settings.DEFECTO;
                        magnifierDo.ID = settings.ID;
                        magnifierDo.LUPA = settings.LUPA;
                        magnifierDo.NOMBRE = settings.NOMBRE;
                        magnifierDo.PUBLICA = settings.PUBLICA;
                        magnifierDo.ULTMODI = DateTime.Now.ToLongTimeString();
                        magnifierDo.USUARIO = settings.USUARIO;
                        retValue = await connection.InsertAsync<USER_LUPAS>(magnifierDo) >=0;

                        scope.Complete();
                    }
                }
                finally 
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            if (settings.MagnifierColumns != null)
            {
                foreach (IMagnifierColumns col in settings.MagnifierColumns)
                {
                    retValue = retValue && await CreateMagnifierColumn(col) >= 0;
                }
            }
            return retValue;
        }


        /// <summary>
        ///  Update columns
        /// TODO: this is a workaround in this case columns doest work with entities we dont know why
        /// FIXME:
        /// </summary>
        /// <param name="mc"></param>
        /// <returns></returns>
        private async Task<bool> UpdateMagnifierColumns(IMagnifierColumns mc, IDbConnection connection)
        {
            bool value = false;
            USER_LUPAS_COLUMNAS cls = new USER_LUPAS_COLUMNAS();
            cls.ANCHO = mc.ANCHO;
            cls.COLUMNA_NOMBRE = mc.COLUMNA_NOMBRE;
            cls.ID_COL = mc.ID_COL;
            cls.ID_LUPA = mc.ID_LUPA;
            cls.POSICION = mc.POSICION;
            cls.VISIBLE = mc.VISIBLE;
            // FIME: rmemove this.
            string queryFormat =
                @"UPDATE USER_LUPAS_COLUMNAS SET ANCHO = '{0}', COLUMNA_NOMBRE = '{1}',ID_COL='{2}', ID_LUPA='{3}',POSICION='{4}', VISIBLE='{5}' WHERE USER_LUPAS_COLUMNAS.ID_COL='{2}'";
            var query = string.Format(queryFormat, cls.ANCHO, cls.COLUMNA_NOMBRE, cls.ID_COL, cls.ID_LUPA, cls.POSICION,
                cls.VISIBLE);
            await connection.ExecuteAsync(query);
            return value;
        }

        /// <summary>
        ///  Save magnifier settings
        /// </summary>
        /// <param name="value">Value of the settings</param>
        /// <returns></returns>
        private async Task<bool> UpdateMagnifierSettings(IMagnifierSettings value)
        {
            Contract.Assert(_executorSql != null, "Executor not instantiated correctly.");
            Contract.Assert(value != null, "Value of the magnifier invalid");
            bool retValue = true;
            string queryFormat = @"DELETE FROM USER_LUPAS_COLUMNAS WHERE POSICION='{0}' AND ID_LUPA='{1}';";
            MagnifierSettings settings = value as MagnifierSettings;
            if (settings == null)
                return false;
            

            USER_LUPAS magnifierDo = new USER_LUPAS();
            magnifierDo.DEFECTO = settings.DEFECTO;
            magnifierDo.ID = settings.ID;
            magnifierDo.LUPA = settings.LUPA;
            magnifierDo.NOMBRE = settings.NOMBRE;
            magnifierDo.PUBLICA = settings.PUBLICA;
            magnifierDo.ULTMODI = DateTime.Now.ToLongTimeString();
            magnifierDo.USUARIO = settings.USUARIO;
            using (IDbConnection connection = _executorSql.OpenNewDbConnection())
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {

                try
                {
                    // include optimistic check.
                    retValue = await connection.UpdateAsync<USER_LUPAS>(magnifierDo);
                    IEnumerable<IMagnifierColumns> cols = value.MagnifierColumns;
                    // this deletes the query.
                    foreach (var mc in cols)
                    {
                     //   var format = string.Format(queryFormat, mc.POSICION, mc.ID_LUPA);
                     //   await connection.ExecuteAsync(format);
                        retValue = await UpdateMagnifierColumns(mc, connection);
                    }
                    scope.Complete();
                }
                catch (System.Exception e)
                {
                    
                }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }
            return retValue;
        }

        public async Task<bool> SaveAllMagnifierSettings(IList<IMagnifierSettings> magnifier)
        {
            bool retValue = false;
            using (IDbConnection connection = _executorSql.OpenNewDbConnection())
            {
                using (TransactionScope scope = new TransactionScope())
                {

                    try
                    {
                        foreach (var m in magnifier)
                        {
                            MagnifierSettings settings = m as MagnifierSettings;
                            // TODO: include optimistic check.
                            retValue = await connection.UpdateAsync<MagnifierSettings>(settings);
                        }
                        scope.Complete();
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }
            return retValue;
        }

        public IMagnifierColumns NewMagnifierColumn()
        {
            MagnifierColumns cols = new MagnifierColumns();
            Random rnd = new Random();
            // TODO: check if exists
            int rndnumber = rnd.Next(0, int.MaxValue);
            // safe default.
            cols.ID_COL = rndnumber;
            cols.ANCHO = 0;
            cols.ID_COL = 1;
            cols.COLUMNA_NOMBRE = string.Empty;
            cols.POSICION = 1;
            cols.VISIBLE = 0;
  
            return cols;
        }

        public async Task<int> CreateMagnifierColumn(IMagnifierColumns col)
        {
            int retValue = -1;
            using (IDbConnection connection = _executorSql.OpenNewDbConnection())
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        USER_LUPAS_COLUMNAS cols = new USER_LUPAS_COLUMNAS();
                        cols.ANCHO = col.ANCHO;
                        cols.COLUMNA_NOMBRE = col.COLUMNA_NOMBRE;
                        cols.ID_COL = col.ID_COL;
                        cols.ID_LUPA = col.ID_LUPA;
                        cols.POSICION = col.POSICION;
                        cols.VISIBLE = col.VISIBLE;
                        retValue = await connection.InsertAsync<USER_LUPAS_COLUMNAS>(cols);
                        scope.Complete();
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }
            return retValue;
        }

        public async Task DeleteMagnifier(int i)
        {
            var queryMagnifier = string.Format(_sqlDelete, i);
            var queryMagnifierCols = string.Format(_sqlDeleteColumns, i);
            using (IDbConnection connection = _executorSql.OpenNewDbConnection())
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        await connection.ExecuteAsync(queryMagnifier);
                        await connection.ExecuteAsync(queryMagnifierCols);
                        scope.Complete();
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }
        }
        public IMagnifierSettings NewMagnifierSettings()
        {
            MagnifierSettings setting = new MagnifierSettings();
            return setting;
        }
    }
}