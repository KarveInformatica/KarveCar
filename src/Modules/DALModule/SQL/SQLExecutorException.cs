using System;
using System.Runtime.Serialization;

namespace DataAccessLayer.SQL
{
    /// <summary>
    /// This allow the bubbling of the exception. 
    /// </summary>
    [Serializable]
    internal class SQLExecutorException : System.Exception
    {
        public SQLExecutorException()
        {
        }

        public SQLExecutorException(string message) : base(message)
        {
        }

        public SQLExecutorException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected SQLExecutorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}