using System;
using System.Runtime.Serialization;

namespace ToolBarModule.Command
{
    [Serializable]
    internal class SaveDataException : Exception
    {
        public SaveDataException()
        {
        }

        public SaveDataException(string message) : base(message)
        {
        }

        public SaveDataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SaveDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}