using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    [DataContract]
    public class AccountDto: BaseDto
    {
        /// <summary>
        ///  Set or get the CODIGO property.
        /// </summary>
        [PrimaryKey]
        [DataMember]
        public string Codigo { get; set; }
        /// <summary>
        ///  Set or get the DESCRIP property.
        /// </summary>
        [DataMember]
        public string Description { get; set; }
        /// <summary>
        ///  Set or get the CC property.
        /// </summary>
        [DataMember]
        public string Cuenta { get; set; }
    }
}
