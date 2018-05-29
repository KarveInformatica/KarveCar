using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SQL
{
    /// <summary>
    ///  Generate an integeral query identifer.
    /// </summary>
    public static class QueryIdentifier
    {
        private static long _maxId;
        /// <summary>
        ///  Returns the long value of the new identifier.
        /// </summary>
        /// <returns></returns>
        public static long NewId()
        {
           if (_maxId > long.MaxValue)
            {
                _maxId = 0;

            }
            else
            {
                _maxId++;
            }
            return _maxId;
        }
    }
}
