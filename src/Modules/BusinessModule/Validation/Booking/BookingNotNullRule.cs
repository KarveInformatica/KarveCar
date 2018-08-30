using KarveCommonInterfaces;
using KarveDataServices.ViewObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Crud.Validation
{
    class BookingNotNullRule : ValidationChain<BookingViewObject>
    {
        public override bool Validate(BookingViewObject request)
        {
            var ret = true;
           if (string.IsNullOrEmpty(request.OFICINA_RES1))
           {
                ErrorMessage = "Oficina creacion no valida";
                return false;
            }
           if (string.IsNullOrEmpty(request.OFIRETORNO_RES1))
           {
               ErrorMessage = "Oficina retorno no valida. Value = " + request.OFIRETORNO_RES1;
                return false;
           }
           if (string.IsNullOrEmpty(request.OFISALIDA_RES1))
           {
                ErrorMessage = "Oficina salida no valida";
                return false;
            }
           if (string.IsNullOrEmpty(request.SUBLICEN_RES1))
           {
               ErrorMessage = "Empresa no valida";
                return false;
            }
           if (string.IsNullOrEmpty(request.CLIENTE_RES1))
           {
               ErrorMessage = "Cliente no valido";
                return false;
            }
            if (string.IsNullOrEmpty(request.CONDUCTOR_RES1))
            {
                ErrorMessage = "Conductor no valido";
                return false;
            }
            return ret;
        }
    }
}
