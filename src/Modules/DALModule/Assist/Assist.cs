using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.Assist;
namespace DataAccessLayer.Assist
{
    /// <summary>
    ///  This class is useful for adding a new assist.
    ///  An assist a call coming from the magnifier component.
    /// </summary>
    public class Assist: IAssist
    {
        /// <summary>
        ///  Name of the assist.
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        ///  Query of the assist.
        /// </summary>
        public string Query { set; get; }
    }
}
