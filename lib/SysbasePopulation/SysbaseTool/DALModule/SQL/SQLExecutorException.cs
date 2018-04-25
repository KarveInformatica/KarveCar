using System;
using System.Runtime.Serialization;

namespace DataAccessLayer.SQL
{
    /// <summary>
    /// This allow the bubbling of the exception. 
    /// </summary>
    [Serializable]
    internal class SqlExecutorException : System.Exception
    {
        /// <summary>
        /// Exception in  the sql executor
        /// </summary>
        public SqlExecutorException()
        {
        }
        /// <summary>
        /// Exception in the sql executor
        /// </summary>
        /// <param name="message">Message of the exception</param>
        public SqlExecutorException(string message) : base(message)
        {
        }
        /// <summary>
        /// Exception in the sql executor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public SqlExecutorException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected SqlExecutorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}