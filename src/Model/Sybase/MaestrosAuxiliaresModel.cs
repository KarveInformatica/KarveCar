using iAnywhere.Data.SQLAnywhere;
using KarveCar.Utility;
using KarveCar.Model.Classes.SQL;
using KarveCar.Model.Generic;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using KarveCar.Common;
using  KarveCommon.Generic;

namespace KarveCar.Model.Sybase
{
    public class MaestrosAuxiliaresModel
    {
        

        public MaestrosAuxiliaresModel()
        {
        }
        /// <summary>
        /// Devuelve una colección con los valores recuperados de la tabla de auxiliares(tablaauxiliares) de la DB mediante el SADataReader, 
        /// del tipo del objeto(obj) pasado por params
        /// </summary>
        /// <param name="tablaauxiliares">Nombre de la tabla de auxiliares de la DB</param>
        /// <param name="dbcriterioslist">Criterios de ayuda (nombre de las columnas de la tabla de la DB, nombre de las propiedades del objeto, 
        /// tipos de los datos de las columnas de la tabla de la DB) para la obtención de los valores según el tipo del objeto(obj)</param>
        /// <param name="obj">Objeto del cual obtendremos su tipo, propiedades</param>
        /// <returns>Colección con los valores recuperados de la tabla de auxiliares(tablaauxiliares) de la DB</returns>
        public static GenericObservableCollection GetMaestrosAuxiliares(string nombretabladb, List<TemplateInfoDB> templateinfodb, object obj)
        {   //Se crea una conexión a la DB
            //string enginename = "DBRENT_NET16";
            //string databasename = "DBRENT_NET16";
            //string uid = "cv";
            //string pwd = "1929";
            //string host = "172.26.0.45";            
            //SAConnection conn = new SAConnection(string.Format(ScriptsSQL.CONNECTION_STRING, enginename, databasename, uid, pwd, host));
            SAConnection conn = new DBConnect().GetConnection(new DBConnect("DBRENT_NET16", "DBRENT_NET16", "cv", "1929" , "172.26.0.45"));
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

