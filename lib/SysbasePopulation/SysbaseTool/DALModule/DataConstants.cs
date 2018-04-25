using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataConstants
    {
        /// <summary>
        ///  Inner Join constant
        /// </summary>
        public const string cINNER = " INNER JOIN ";
        /// <summary>
        /// Outer join constant
        /// </summary>
        public const string cOUTER = " LEFT OUTER JOIN ";
        /// <summary>
        ///  Right outer join constant
        /// </summary>
        public const string cRIGHT = " RIGHT OUTER JOIN ";
        public const string cORDER = " ORDER BY ";
        public const string cUPDATE = " UPDATE ";
        public const string cINSERT = " INSERT INTO ";
        public const string cDELETE = " DELETE ";
        public const string cGROUP = " GROUP BY ";
        public const string cBETWEEN = " BETWEEN ";
        public const string cISNULL = " IS NULL ";
        public const string cSET = " SET ";
        public const string cUNION = " UNION ";
        public const string cUNION_ALL = " UNION ALL ";

    }
}
