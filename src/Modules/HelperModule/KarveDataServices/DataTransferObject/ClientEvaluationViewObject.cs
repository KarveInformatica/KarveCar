using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.ViewObjects
{
    public class ClientEvaluationViewObject: BaseViewObject
    {
        private int _code;
        [Display(Name = "Codigo")]
        public new int Code { get { return _code; } set { _code = value; base.Code = _code.ToString();  } }
       
    }
}