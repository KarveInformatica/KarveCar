using System;
using System.Runtime.Serialization;

namespace DataAccessLayer.XmlDB
{
    [Serializable]
    internal class XmlCompanyDataService : System.Exception
    {
        public XmlCompanyDataService()
        {
        }

        public XmlCompanyDataService(string message) : base(message)
        {
        }

        public XmlCompanyDataService(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected XmlCompanyDataService(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}