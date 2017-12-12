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
    /// </summary>
    public class Assist: IAssist
    {
        public string Name { set; get; }
        public string Query { set; get; }
    }
}
