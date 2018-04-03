using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  DeliveringForm. Pending Delivering.
    /// </summary>
   public class DeliveringFormDto: BaseDto
    {
      public  byte Codigo { set; get; }
      public  string Nombre { set; get; }
    }
}
