using System;
using System.Runtime.Serialization;

namespace DataAccessLayer
{
    [Serializable]
    internal class SupplierDataServiceAccessDeniedException : Exception
    {
        public SupplierDataServiceAccessDeniedException()
        {
        }

        public SupplierDataServiceAccessDeniedException(string message) : base(message)
        {
        }

        public SupplierDataServiceAccessDeniedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SupplierDataServiceAccessDeniedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}