using KarveCommon.Services;
using KarveDataServices.ViewObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveTest.Common
{
    [TestFixture]
    class TestCareKeeper
    {
        private ICareKeeperService _careKeeper;
        [OneTimeSetUp]
        public void Setup()
        {
            _careKeeper = new CareKeeper();
        }
        [Test]
        public void Should_Delete_CareKeeperMultiplePayloadFromSameViewModel()
        {
            Guid guid = Guid.NewGuid();
            Uri uri = new Uri("karve://suppliers/viewmodel?id=" + guid.ToString());
            // schedule items.
            for (int i = 0; i < 10; ++i)
            {
                DataPayLoad payload = new DataPayLoad();
                payload.DataObject = new SupplierViewObject();
                payload.ObjectPath = uri;
                _careKeeper.Schedule(payload);

            }
            Assert.AreEqual(1, _careKeeper.ScheduledPayloadCount());
            _careKeeper.DeleteItems(uri);
            Assert.AreEqual(0, _careKeeper.ScheduledPayloadCount());
        }
        [Test]
        public void ShouldCareKeeper_Schedule_Item()
        {
            Guid guid = Guid.NewGuid();
            Uri uri = new Uri("karve://suppliers/viewmodel?id=" + guid.ToString());
            DataPayLoad payload = new DataPayLoad();
            payload.ObjectPath = uri;
            payload.DataObject = new SupplierViewObject();
            _careKeeper.Schedule(payload);
            var schedulerQueue = _careKeeper.GetScheduledPayload();
            var scheduledPayload = schedulerQueue.Dequeue();
            Assert.AreEqual(scheduledPayload.ObjectPath, uri);
        }
    }
}
