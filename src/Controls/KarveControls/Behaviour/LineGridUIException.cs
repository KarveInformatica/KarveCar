using System;
using System.Runtime.Serialization;

namespace KarveControls.Behaviour
{
    [Serializable]
    internal class LineGridUIException : Exception
    {
        /*
         *  This GridUIException comes true when a bad mapping in the UI happens.
         */
        public LineGridUIException()
        {
        }

        public LineGridUIException(string message) : base(message)
        {
        }

        public LineGridUIException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LineGridUIException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}