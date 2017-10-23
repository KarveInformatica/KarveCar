using System.Data.Odbc;

namespace KarveDataServices
{
    public class IDBParameter
    {
        public OdbcParameter[] odbcParameters { set; get; }
        public SAParameter[] oleDbParameters { set; get; }
    }
}