using KarveDataServices;
using System;
using System.Runtime.Serialization;
using KarveDataServices.DataTransferObject;

namespace KarveTest.Mock
{
    [Serializable]
    internal class MockAssistDataServices : IAssistDataService
    {
        public MockAssistDataServices()
        {
        }
   
        public IAssistMapper<BaseDto> Mapper { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}