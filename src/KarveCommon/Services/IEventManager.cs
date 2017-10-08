using System;

namespace KarveCommon.Services
{
    public delegate void MailBoxMessageHandler(DataPayLoad payLoad);

    public interface IEventManager
    {
        void registerObserverSubsystem(string id, IEventObserver obs);
        void notifyObserverSubsystem(string v, DataPayLoad dataPayload);
        void registerObserver(IEventObserver obs);
        void notifyObserver(DataPayLoad payload);
        void RegisterObserverToolBar(IEventObserver obs);
        void NotifyToolBar(DataPayLoad payload);
        void deleteObserverSubSystem(string v, IEventObserver obs);
        void disableNotify(string v, IEventObserver obs);
        void enableNotify(string id, IEventObserver obs);
        void RegisterMailBox(string id, MailBoxMessageHandler messageHandler);
        void SendMessage(string viewModuleId, DataPayLoad payLoad);
    }
}