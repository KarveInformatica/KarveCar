using System.ComponentModel;

namespace KarveDataServices.DataTransferObject
{
    public class ClientEvaluationDto: BaseDto
    {
        private int _code;
        [DisplayName("Codigo")]
        public new int Code { get { return _code; } set { _code = value; base.Code = _code.ToString();  } }
       
    }
}