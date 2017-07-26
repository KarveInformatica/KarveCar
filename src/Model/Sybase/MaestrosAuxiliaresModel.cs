using iAnywhere.Data.SQLAnywhere;
using KarveCar.Utility;
using KarveCar.Model.Generic;
using System.Collections.Generic;
using System.Linq;
using KarveCar.Model.SQL;
using KarveCommon.Generic;
using static KarveCar.Model.Generic.RecopilatorioCollections;
using static KarveCar.Model.Generic.RecopilatorioEnumerations;

namespace KarveCar.Model.Sybase
{
    public class MaestrosAuxiliaresModel
    {
        /// <summary>
        /// Devuelve una GenericObservableCollection con los valores recuperados de la DB según la EOpcion pasada por params
        /// </summary>
        /// <param name="opcion"></param>
        /// <returns></returns>
        public static GenericObservableCollection GetMaestrosAuxiliares(RecopilatorioEnumerations.EOpcion opcion)
        {



           
            //Se recupera el nombre de la tabla de la BBDD(nombretabladb), el List<TemplateInfoDB> (templateinfodb)
            //y el object (obj) según el EOpcion pasado por params
            string nombretabladb = ribbonbuttondictionary.Where(z => z.Key == opcion).FirstOrDefault().Value.nombretabladb;
            List<TemplateInfoDB> templateinfodb = ribbonbuttondictionary.Where(z => z.Key == opcion).FirstOrDefault().Value.templateinfodb;
            object obj = ribbonbuttondictionary.Where(z => z.Key == opcion).FirstOrDefault().Value.obj;

            //Se crea una conexión a la DB
            //string enginename = "DBRENT_NET16";
            //string databasename = "DBRENT_NET16";
            //string uid = "cv";
            //string pwd = "1929";
            //string host = "172.26.0.45";            
            //SAConnection conn = new SAConnection(string.Format(ScriptsSQL.CONNECTION_STRING, enginename, databasename, uid, pwd, host));
            SAConnection conn = new DBConnect().GetConnection(new DBConnect("DBRENT_NET16", "DBRENT_NET16", "cv", "1929", "172.26.0.45"));
            //SAConnection conn = new SAConnection(new DBConnect().ConnexionString());            
            string sql = string.Format(ScriptsSQL.SELECT_ALL_BASICA, nombretabladb);
            //Se crea una ObservableCollection del tipo de dato recibido por params
            GenericObservableCollection auxobscollection = new GenericObservableCollection();
                        
            try
            {
                conn.Open();
                SACommand cmd   = new SACommand(sql, conn);
                SADataReader dr = cmd.ExecuteReader();

                auxobscollection = ManageGenericObject.GetObservableCollectionFromSADataReader(dr, templateinfodb, obj);
                
                dr.Close();
            }
            catch (SAException e)
            {
                ErrorsDB.MessageError(e);
            }
            finally
            {
                conn.Close();
            }
            return auxobscollection; //Se devuelve la ObservableCollection del tipo recibido por params
        }
    }
}

