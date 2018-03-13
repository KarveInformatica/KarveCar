using System;
using System.Runtime.Serialization;

namespace InvoiceModule.ViewModels
{
    [Serializable]
    internal class GridLoadException : Exception
    {
        public GridLoadException()
        {
        }

        public GridLoadException(string message) : base(message)
        {
        }

        public GridLoadException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GridLoadException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}