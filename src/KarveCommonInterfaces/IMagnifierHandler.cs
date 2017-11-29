using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCommonInterfaces
{
    /// <summary>
    ///  IMagnifier handler.
    /// Handler for 
    /// </summary>
    public interface IMagnifierHandler
    {
        /// <summary>
        /// handle assist name
        /// </summary>
        /// <param name="assistQuery">Query to do an assist</param>
        /// <param name="tableName">Code of the assist.</param>
        void HandleAssist(string assistQuery, string tableName);
    }
}
