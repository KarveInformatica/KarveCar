using System;
using System.Runtime.Serialization;

namespace DataAccessLayer.Exception
{
    [Serializable]
    internal class DataUpdateException : System.Exception
    {
        private System.Exception e;

        public DataUpdateException()
        {
        }

        public DataUpdateException(System.Exception e)
        {
            this.e = e;
        }

        public DataUpdateException(string message) : base(message)
        {
        }

        public DataUpdateException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected DataUpdateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}