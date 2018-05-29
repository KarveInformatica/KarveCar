using System;
using System.Runtime.Serialization;

namespace DataAccessLayer
{
    [Serializable]
    internal class DataPagerException : System.Exception
    {
        public DataPagerException()
        {
        }

        public DataPagerException(string message) : base(message)
        {
        }

        public DataPagerException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected DataPagerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}