using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.ViewObjects
{
    [DataContract]
    public class AccountViewObject: BaseViewObject
    {
       
        /// <summary>
        ///  Set or get the CODIGO property.
        /// </summary>
        [PrimaryKey]
        [DataMember]
        [Required]
        [Display(GroupName = "Codigo Cuenta")]
        public string Codigo { get; set; }
        /// <summary>
        ///  Set or get the DESCRIP property.
        /// </summary>
        [Display(GroupName = "Description Cuenta")]
        [DataMember]
        public string Description { get; set; }
        /// <summary>
        ///  Set or get the CC property.
        /// </summary>
        [Display(GroupName = "Numero Cuenta")]
        [DataMember]
        public string Cuenta { get; set; }
        public override bool HasErrors
        {
            get
            {
                if (Cuenta.Length <= 20)
                {
                    return false;
                }
                AddMessage("Cuenta",ConstantDataError.AccountValueTooLong);
                return true;

            }
        }
    }
}
