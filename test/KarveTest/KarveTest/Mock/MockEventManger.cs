using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;

namespace KarveTest.Mock
{

    /// <summary>
    ///  This is a mock event manager class. It enables us to register a mock object.
    /// </summary>
    class MockEventManger: IEventManager
    {
        public bool IsNotified => throw new NotImplementedException();

        /// <summary>
        ///  Register an observer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="obs"></param>
        public void RegisterObserverSubsystem(string id, IEventObserver obs)
        {
         
        }
        /// <summary>
        ///  Notify an observer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dataPayload"></param>
        public void NotifyObserverSubsystem(string id, DataPayLoad dataPayload)
        {
         
        }

        public void RegisterObserver(IEventObserver obs)
        {
         
        }

        public void NotifyObserver(DataPayLoad payload)
        {
         
        }

        public void RegisterObserverToolBar(IEventObserver obs)
        {
         
        }

        public void NotifyToolBar(DataPayLoad payload)
        {
         
        }

        public void DeleteObserverSubSystem(string id, IEventObserver obs)
        {
         
        }

        public void DisableNotify(string id, IEventObserver obs)
        {
         
        }

        public void EnableNotify(string id, IEventObserver obs)
        {
         
        }

        public void RegisterMailBox(string id, MailBoxMessageHandler messageHandler)
        {
        }

        public bool IsRegistered(string id)
        {
            return true;
        }

        public void DeleteMailBoxSubscription(string id)
        {
         
        }

        public void SendMessage(string viewModuleId, DataPayLoad payLoad)
        {
        }

        public void DeleteObserver(IEventObserver observer)
        {
        }

        public bool IsRegisteredMailbox(string id, DataPayLoad payLoad)
        {
           return true;
        }
    }
}
