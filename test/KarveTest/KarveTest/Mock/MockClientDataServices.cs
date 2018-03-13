using System;
using System.Runtime.Serialization;

namespace KarveTest.Mock
{
    [Serializable]
    internal class MockClientDataServices : Exception
    {
        public MockClientDataServices()
        {
        }

        public MockClientDataServices(string message) : base(message)
        {
        }

        public MockClientDataServices(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MockClientDataServices(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}