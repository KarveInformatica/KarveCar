using System;
using System.Runtime.Serialization;

namespace KarveTest.Mock
{
    [Serializable]
    internal class MockAssistDataServices : Exception
    {
        public MockAssistDataServices()
        {
        }

        public MockAssistDataServices(string message) : base(message)
        {
        }

        public MockAssistDataServices(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MockAssistDataServices(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}