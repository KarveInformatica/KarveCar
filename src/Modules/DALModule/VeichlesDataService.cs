using System;
using System.Runtime.Serialization;

namespace DataAccessLayer
{
    [Serializable]
    internal class VeichlesDataService : System.Exception
    {
        public VeichlesDataService()
        {
        }

        public VeichlesDataService(string message) : base(message)
        {
        }

        public VeichlesDataService(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected VeichlesDataService(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}