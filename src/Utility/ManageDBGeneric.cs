using iAnywhere.Data.SQLAnywhere;
using KarveCar.Model.Generic;
using KarveCar.Model.Sybase;
using KarveCommon.Generic;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static KarveCommon.Generic.Enumerations;

namespace KarveCar.Utility
{
    public class ManageDBGeneric
    {
        #region Selects
        /// <summary>
        /// Devuelve una GenericObservableCollection con los valores recuperados de la DB 
        /// según el EOpcion y el script sql (sql) pasados por params
        /// </summary>
        /// <param name="opcion"></param>
        /// <returns></returns>
        public static GenericObservableCollection GetValuesFromDBObsCollection(EOpcion opcion, string sql)
        {
            //Se recupera el List<TemplateInfoDB> (templateinfodb) y el object (obj) según el EOpcion pasado por params
            List<TemplateInfoDB> templateinfodb = RecopilatorioCollections.ribbonbuttondictionary.FirstOrDefault(z => z.Key == opcion).Value.templateinfodb;
            object obj = RecopilatorioCollections.ribbonbuttondictionary.FirstOrDefault(z => z.Key == opcion).Value.obj;

            GenericObservableCollection auxobscollection = new GenericObservableCollection();
         
            try
            {
                using (SAConnection conn = new DBConnect().GetConnection(new DBConnect("DBRENT_NET16", "DBRENT_NET16", "cv", "1929", "172.26.0.45")))
                {
                    conn.Open();
                    SACommand cmd = new SACommand(sql, conn);
                    SADataReader dr = cmd.ExecuteReader();

                    auxobscollection = ManageGenericObject.GetObservableCollectionFromSADataReader(dr, templateinfodb, obj);
                }
            }
            catch (SAException e)
            {
                ErrorsDB.MessageError(e);
            }

            return auxobscollection; //Se devuelve la ObservableCollection del tipo recibido por params
        }

        /// <summary>
        /// Devuelve un DataTable con los valores recuperados de la DB según el script sql (sql) pasado por param
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetValuesFromDbDataTable(string sql)
        {
            DataTable datatable = new DataTable();

            try
            {
                using (SAConnection conn = new DBConnect().GetConnection(new DBConnect("DBRENT_NET16", "DBRENT_NET16", "cv", "1929", "172.26.0.45")))
                {
                    conn.Open();
                    SACommand cmd = new SACommand(sql, conn);
                    SADataReader dr = cmd.ExecuteReader();
                    
                    datatable.Load(dr);
                }
            }
            catch (SAException e)
            {
                ErrorsDB.MessageError(e);
            }

            return datatable;
        }
        #endregion

        #region Updates
        /// <summary>
        /// Modifica varios registros de la DB según la lista de scripts sql (sqlList) pasados por param.
        /// Devuelve la cantidad de registro que se han modificado correctamente.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int UpdateRegisterList(List<string> sqlList)
        {
            int result = 0;
            try
            {
                using (SAConnection conn = new DBConnect().GetConnection(new DBConnect("DBRENT_NET16", "DBRENT_NET16", "cv", "1929", "172.26.0.45")))
                {
                    SATransaction trans = null;
                    try
                    {
                        conn.Open();
                        trans = conn.BeginTransaction();

                        foreach (var sql in sqlList)
                        {
                            SACommand command = new SACommand(sql, conn, trans);
                            result += command.ExecuteNonQuery();
                        }
                        trans.Commit();
                    }
                    catch (SAException e)
                    {
                        trans.Rollback();
                        ErrorsDB.MessageError(e);
                    }
                }
            }
            catch (SAException e)
            {
                ErrorsDB.MessageError(e);
            }
            return result;
        }

        /// <summary>
        /// Modifica un registro de la DB según el script sql (sql) pasado por param.
        /// Devuelve 1 si el registro se ha modificado correctamente, y 0 en caso contrario.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int CRUDRegister(string sql)
        {
            int result = 0;
            try
            {
                using (SAConnection conn = new DBConnect().GetConnection(new DBConnect("DBRENT_NET16", "DBRENT_NET16", "cv", "1929", "172.26.0.45")))
                {
                    SATransaction trans = null;
                    try
                    {
                        conn.Open();
                        trans = conn.BeginTransaction();
                        SACommand command = new SACommand(sql, conn, trans);
                        result = command.ExecuteNonQuery();
                        trans.Commit();
                    }
                    catch (SAException e)
                    {
                        trans.Rollback();
                        ErrorsDB.MessageError(e);
                    }
                }
            }
            catch (SAException e)
            {
                ErrorsDB.MessageError(e);
            }
            return result;
        }
        #endregion
    }
}

