using System;
using System.Runtime.Serialization;

namespace Apache.Ibatis.DataMapper.Configuration
{
    [Serializable]
    internal class TypeAliasDeserializeException : Exception
    {
        public TypeAliasDeserializeException()
        {
        }

        public TypeAliasDeserializeException(string message) : base(message)
        {
        }

        public TypeAliasDeserializeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TypeAliasDeserializeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}