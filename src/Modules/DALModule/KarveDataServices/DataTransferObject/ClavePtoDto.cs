using System.Runtime.Serialization;

namespace KarveDataServices.DataTransferObject
{
    [DataContract]
    public class ClavePtoDto: BaseDto
    {
       
        [DataMember]
        public string Numero { get;  set; }
        [DataMember]
        public string Nombre { get; set; }


        public override bool HasErrors
        {
            get
            {
                if ((Nombre != null) && (Nombre.Length > NameSize))
                {
                    ErrorList.Add(ConstantDataError.NameTooLong);
                    return true;
                }
                return false;
            }
        }

    }
}