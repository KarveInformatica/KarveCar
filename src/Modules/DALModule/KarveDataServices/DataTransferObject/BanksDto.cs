using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sinkien.IBAN4Net;

namespace KarveDataServices.DataTransferObject
{
    public class BanksDto : BaseDto
    {

        [Display(Name="Codigo")]
        public override string Code { get => base.Code; set => base.Code = value; }
        [Display(Name = "Nombre")]
        public override string Name { get => base.Name; set => base.Name = value; }
        /// <summary>
        ///  Set or get the USUARIO property.
        /// </summary>

        public string Usuario { get; set; }

           
            /// <summary>
            ///  Set or get the GESTIONAR property.
            /// </summary>

            public byte? GESTIONAR { get; set; }

            /// <summary>
            ///  Set or get the SWIFT property.
            /// </summary>

            public string Swift { get; set; }

            /// <summary>
            ///  Set or get the CTAPAGO_ASOCIA property.
            /// </summary>

            public string CTAPAGO_ASOCIA { get; set; }
            public override void ClearErrors()
            {
                Name = "default";
                Swift = string.Empty;
                base.ClearErrors();
            }
        public override bool HasErrors
            {
            get
            {
                if (string.IsNullOrEmpty(Name))
                {
                    return true;
                }
                if (base.Name.Length > 40)
                {
                    ErrorList.Add(ConstantDataError.NameTooLong);
                    return true;
                }
                if (!string.IsNullOrEmpty(Swift))
                {
                    try
                    {
                       
                        var bic = Bic.CreateInstance(Swift);
                    } catch (BicFormatException ex)
                    {
                        ErrorList.Add(ex.Message);
                        return true;
                    }
                }
                return false;
            }
            }

            

        

    }
}
