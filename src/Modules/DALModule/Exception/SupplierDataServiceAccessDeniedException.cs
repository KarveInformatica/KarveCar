using System;
using System.Runtime.Serialization;

namespace DataAccessLayer.Exception
{
    [Serializable]
    internal class SupplierDataServiceAccessDeniedException : System.Exception
    {
        public SupplierDataServiceAccessDeniedException()
        {
        }

        public SupplierDataServiceAccessDeniedException(string message) : base(message)
        {
        }

        public SupplierDataServiceAccessDeniedException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected SupplierDataServiceAccessDeniedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}