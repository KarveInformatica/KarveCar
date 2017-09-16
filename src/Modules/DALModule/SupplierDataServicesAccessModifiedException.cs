using System;
using System.Runtime.Serialization;

namespace KarveDataAccessLayer
{
    [Serializable]
    internal class SupplierDataServicesAccessModifiedException : Exception
    {
        public SupplierDataServicesAccessModifiedException()
        {
        }

        public SupplierDataServicesAccessModifiedException(string message) : base(message)
        {
        }

        public SupplierDataServicesAccessModifiedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SupplierDataServicesAccessModifiedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}