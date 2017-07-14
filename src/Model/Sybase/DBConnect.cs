using iAnywhere.Data.SQLAnywhere;
using KRibbon.Model.Classes.SQL;

namespace KRibbon.Model.Sybase
{
    public class DBConnect
    {
        #region Constructores
        public DBConnect() { }

        public DBConnect(string EngineName, string DatabaseName, string Uid, string Pwd, string Host)
        {
            this.enginename  = EngineName;
            this.databasename = DatabaseName;
            this.uid  = Uid;
            this.pwd  = Pwd;
            this.host = Host;
        }
        #endregion

        #region Propiedades
        private string enginename;// = "DBRENT_NET16";
        public string EngineName
        {
            get { return enginename; }
            set { enginename = value; }
        }

        private string databasename;// = "DBRENT_NET16";
        public string DatabaseName
        {
            get { return databasename; }
            set { databasename = value; }
        }

        private string uid;// = "cv";
        public string Uid
        {
            get { return uid; }
            set { uid = value; }
        }

        private string pwd;// = "1929";
        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }

        private string host;// = "172.26.0.45";
        public string Host
        {
            get { return host; }
            set { host = value; }
        }
        #endregion

        /// <summary>
        /// Devuelve una connectionString con los parámetros recibidos en el constructor 
        /// (EngineName, DatabaseName, Uid, Pwd, Host)
        /// </summary>
        /// <returns></returns>
        public string ConnexionString()
        {
            return "EngineName="   + this.EngineName +
                 "; DatabaseName=" + this.DatabaseName +
                 "; Uid="          + this.Uid +
                 "; Pwd="          + this.Pwd.ToString() +
                 "; Links=tcpip(host=" + this.Host + ")";
        }

        public SAConnection GetConnection(DBConnect dbconn)
        {
            return new SAConnection(string.Format(ScriptsSQL.CONNECTION_STRING, dbconn.enginename, dbconn.databasename, dbconn.uid, dbconn.pwd, dbconn.host));
        }

        public SAConnection GetConnection()
        {
            return new SAConnection(string.Format(ScriptsSQL.CONNECTION_STRING, enginename, this.databasename, this.uid, this.pwd, this.host));
        }
    }
}
