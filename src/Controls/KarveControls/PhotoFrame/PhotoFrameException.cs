using System;
using System.Runtime.Serialization;

namespace KarveControls.PhotoFrame
{
    [Serializable]
    internal class PhotoFrameException : Exception
    {
        public PhotoFrameException()
        {
        }

        public PhotoFrameException(string message) : base(message)
        {
        }
        public PhotoFrameException(string message, Exception innerException) : base(message, innerException)
        {
        }
        protected PhotoFrameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}