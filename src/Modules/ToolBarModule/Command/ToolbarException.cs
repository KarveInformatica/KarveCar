using System;
using System.Runtime.Serialization;

namespace ToolBarModule.Command
{
    [Serializable]
    internal class ToolbarException : Exception
    {
        public ToolbarException()
        {
        }

        public ToolbarException(string message) : base(message)
        {
        }

        public ToolbarException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ToolbarException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}