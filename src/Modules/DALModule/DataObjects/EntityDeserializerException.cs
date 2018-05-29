using System;
using System.Runtime.Serialization;

namespace DataAccessLayer.DataObjects
{
    [Serializable]
    internal class EntityDeserializerException : System.Exception
    {
        public EntityDeserializerException()
        {
        }

        public EntityDeserializerException(string message) : base(message)
        {
        }

        public EntityDeserializerException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected EntityDeserializerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}