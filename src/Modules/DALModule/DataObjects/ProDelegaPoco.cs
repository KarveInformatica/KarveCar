using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataObjects
{
    /// <summary>
    ///  This is a 
    /// </summary>
    class ProDelegaPoco: ProDelega
    {
        /// <summary>
        ///  ProDelegaPoco is a poco object 
        /// </summary>
        public ProDelegaPoco()
        {
        }
        /// <summary>
        ///  entity for fetching a province.
        /// </summary>
        public string NOM_PROV { set; get; }
        /// <summary>
        ///  entity for fetching a cp.
        /// </summary>
        public string CP { set; get; }
    }
}
