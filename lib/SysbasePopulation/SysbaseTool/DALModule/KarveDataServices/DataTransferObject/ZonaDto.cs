using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  ZonaDts
    /// </summary>
    public class ZonasDto : BaseDto
    {
        public string Code { set; get; }
        public string Name { set; get; }
        public string TerminationZone { set; get; }
    }
}
