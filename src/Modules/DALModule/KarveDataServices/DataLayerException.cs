using System;
using System.Runtime.Serialization;

namespace KarveDataServices
{
    [Serializable]
    public class DataLayerException : Exception
    {
        /// <summary>
        ///  DataLayerExecption. Exception for triggering an exceptional event in data event.
        /// </summary>
        public DataLayerException()
        {
        }

        public DataLayerException(string message) : base(message)
        {
        }

        public DataLayerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DataLayerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}