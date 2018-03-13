using System;
using System.Runtime.Serialization;

namespace KarveDataServices
{
    [Serializable]
    public class DataLayerException : Exception
    {
        /// <summary>
        ///  DataLayerExecption. Exception for triggering an exceptional event in data access event.
        /// </summary>
        public DataLayerException()
        {
        }
        /// <summary>
        /// DataLayerException. Exception for triggering an exceptional event in data access event.
        /// </summary>
        /// <param name="message">Message to be shown</param>
        public DataLayerException(string message) : base(message)
        {
        }
        /// <summary>
        /// DataLayerExecption. Exception for triggering an exceptional event in data access event.
        /// </summary>
        /// <param name="message">Message to be showbn</param>
        /// <param name="innerException"></param>
        public DataLayerException(string message, Exception innerException) : base(message, innerException)
        {
        }
        /// <summary>
        ///  SerializationInfo
        /// </summary>
        /// <param name="info">Info de serialization</param>
        /// <param name="context">Contexto</param>
        protected DataLayerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}