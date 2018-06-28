using System;
using System.Runtime.Serialization;

namespace DataAccessLayer
{
    [Serializable]
    internal class AssistDataException : System.Exception
    {
        public AssistDataException()
        {
        }

        public AssistDataException(string message) : base(message)
        {
        }

        public AssistDataException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected AssistDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}