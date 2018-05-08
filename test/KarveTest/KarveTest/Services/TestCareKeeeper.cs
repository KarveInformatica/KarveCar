using KarveCommon.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KarveTest.Services
{
   
    class TestCareKeeeper
    {
        class MockDataObject
        {

        };
        class MockCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                throw new NotImplementedException();
            }

            public void Execute(object parameter)
            {
                throw new NotImplementedException();
            }
        };
        private ICareKeeperService _keeper;
        [OneTimeSetUp]
        public void Setup()
        {
            _keeper = new CareKeeper();
        }
        [Test]
        public void Should_CareKeeper_SchedulePayload ()
        {
            DataPayLoad dataPayLoad = new DataPayLoad();
            dataPayLoad.DataObject = new MockDataObject();
            dataPayLoad.HasDataObject = true;
            dataPayLoad.ObjectPath=new Uri("karve://suppliers/viewmodel/id/8393839");
            _keeper.Schedule(dataPayLoad);
            Assert.AreEqual(_keeper.GetScheduledPayload().Count, 1);
        }
    }

}
