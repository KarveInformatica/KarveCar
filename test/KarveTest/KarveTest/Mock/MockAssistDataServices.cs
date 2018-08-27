using KarveDataServices;
using System;
using System.Runtime.Serialization;
using KarveDataServices.ViewObjects;

namespace KarveTest.Mock
{
    [Serializable]
    internal class MockAssistDataServices : IAssistDataService
    {
        public MockAssistDataServices()
        {
        }
   
        public IAssistMapper<BaseViewObject> Mapper { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}