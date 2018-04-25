using System;
using System.Runtime.Serialization;

namespace DataAccessLayer.DataObjects.Wrapper
{
    [Serializable]
    internal class DataLayerExecutionException : System.Exception
    {
        public DataLayerExecutionException()
        {
        }

        public DataLayerExecutionException(string message) : base(message)
        {
        }

        public DataLayerExecutionException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected DataLayerExecutionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}