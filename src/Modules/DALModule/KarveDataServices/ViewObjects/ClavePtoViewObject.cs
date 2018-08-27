using System.Runtime.Serialization;

namespace KarveDataServices.ViewObjects
{
    [DataContract]
    public class ClavePtoViewObject: BaseViewObject
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