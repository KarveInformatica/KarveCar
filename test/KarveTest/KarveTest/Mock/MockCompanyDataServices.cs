using System;
using System.Runtime.Serialization;

namespace KarveTest.Mock
{
    [Serializable]
    internal class MockCompanyDataServices : Exception
    {
        public MockCompanyDataServices()
        {
        }

        public MockCompanyDataServices(string message) : base(message)
        {
        }

        public MockCompanyDataServices(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MockCompanyDataServices(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}