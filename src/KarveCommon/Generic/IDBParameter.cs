using System.Data.Odbc;
using System.Data.OleDb;
using iAnywhere.Data.SQLAnywhere;

namespace KarveCommon.Generic
{
    public class IDBParameter
    {
        public OdbcParameter[] odbcParameters { set; get; }
        public SAParameter[] oleDbParameters { set; get; }
    }
}