using System;
using System.Runtime.Serialization;

namespace KarveDataAccessLayer
{
    [Serializable]
    internal class DataUpdateException : Exception
    {
        private Exception e;

        public DataUpdateException()
        {
        }

        public DataUpdateException(Exception e)
        {
            this.e = e;
        }

        public DataUpdateException(string message) : base(message)
        {
        }

        public DataUpdateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DataUpdateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}