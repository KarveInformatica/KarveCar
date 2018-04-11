using System.Collections.ObjectModel;
using System.Threading;
using KarveCommon.Services;
using NUnit.Framework;
using Moq;


namespace KarveTest.Services
{
    [TestFixture]
    class TestConfigurationService
    {
        /* create e factory for the configuration service */
        private Mock<IConfigurationService> _service = new Mock<IConfigurationService>();
        [OneTimeSetUp]
        public void Setup()
        {
            _service =  null;
        }
        
        /// <summary>
        ///  Test Communication of observable collection between two different two view models.
        /// It simulates two thread different of execution
        /// </summary>
        [Test]
        public void Should_SendReceive_EventData()
        {
            //_service.SubscribeDataChange(CheckData);
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                ObservableCollection<object> obs = new ObservableCollection<object>();
                var currentValue = 3;
                obs.Add(currentValue);
                DataPayLoad payLoad = new DataPayLoad();
                payLoad.PayloadType = DataPayLoad.Type.Insert;
               // payLoad.CollectionData = obs;
              //  _service.NotifyDataChange(payLoad);
            }).Start();


        }
       
       
        private void CheckData(DataPayLoad data)
        {
          //  var currentValue = data.CollectionData[3];
            var currentType = data.PayloadType;
            //Assert.AreEqual(currentValue, 3);
            Assert.AreEqual(currentType, DataPayLoad.Type.Insert);
            
        }
    }
}
