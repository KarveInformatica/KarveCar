using System;
using System.Runtime.Serialization;

namespace KarveDataAccessLayer
{
    [Serializable]
    internal class VeichlesDataService : Exception
    {
        public VeichlesDataService()
        {
        }

        public VeichlesDataService(string message) : base(message)
        {
        }

        public VeichlesDataService(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected VeichlesDataService(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}