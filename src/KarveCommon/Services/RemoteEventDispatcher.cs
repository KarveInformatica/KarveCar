using System;
using DevExpress.Xpo;

namespace KarveCommon.Services
{
    /// <summary>
    ///  This class implement a remote event manager
    /// to be able to deliver remotely the payload that cames from the viewmodels,
    /// allowing different views communicate to a remote database.
    ///  TODO: this is just experimental.
    /// </summary>
    public class RemoteEventDispatcher : IEventManager
    {
   
        public void DeleteMailBoxSubscription(string id)
        {
            throw new NotImplementedException();
        }

        public void DeleteObserver(IEventObserver observer)
        {
            throw new NotImplementedException();
        }

        public void DeleteObserverSubSystem(string id, IEventObserver obs)
        {
            throw new NotImplementedException();
        }

        public void DisableNotify(string id, IEventObserver obs)
        {
            throw new NotImplementedException();
        }

        public void EnableNotify(string id, IEventObserver obs)
        {
            throw new NotImplementedException();
        }

        public bool IsRegisteredMailbox(string id, DataPayLoad payLoad)
        {
            throw new NotImplementedException();
        }

        public void NotifyObserver(DataPayLoad payload)
        {
            throw new NotImplementedException();
        }

        public void NotifyObserverSubsystem(string id, DataPayLoad dataPayload)
        {
            throw new NotImplementedException();
        }

        public void NotifyToolBar(DataPayLoad payload)
        {
            throw new NotImplementedException();
        }

        public void RegisterMailBox(string id, MailBoxMessageHandler messageHandler)
        {
            throw new NotImplementedException();
        }

        public void RegisterObserver(IEventObserver obs)
        {
            throw new NotImplementedException();
        }

        public void RegisterObserverSubsystem(string id, IEventObserver obs)
        {
            throw new NotImplementedException();
        }

        public void RegisterObserverToolBar(IEventObserver obs)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string viewModuleId, DataPayLoad payLoad)
        {
            throw new NotImplementedException();
        }
    }

}