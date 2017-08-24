using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataObjects
{
    public interface ISupplierEvaluationNote
    {
        string Codigo { set; get; }
        decimal Precio { set; get; }
        decimal CumplePrevision { set; get; }
        decimal RespondePedido { set; get; }
        decimal SuministraInfo { set; get; }
        DateTime Fecha { set; get; }
        decimal Trato { set; get; }
        decimal AttReciboda { set; get; }
        decimal Presentacion { set; get; }
        decimal Suma { get; set; }
        decimal Media { get; set; }
    }
}
