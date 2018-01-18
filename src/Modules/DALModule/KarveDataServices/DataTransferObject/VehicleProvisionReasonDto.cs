using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    public class VehicleProvisionReasonDto
    {
        public byte Code { get; set; }

        public  string Name { get; set; }

        public string LastModification { get; set; }
    }
}
