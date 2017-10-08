using System;
using System.Runtime.Serialization;

namespace DataAccessLayer.Exception
{
    [Serializable]
    internal class SupplierDataServicesAccessModifiedException : System.Exception
    {
        public SupplierDataServicesAccessModifiedException()
        {
        }

        public SupplierDataServicesAccessModifiedException(string message) : base(message)
        {
        }

        public SupplierDataServicesAccessModifiedException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected SupplierDataServicesAccessModifiedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}