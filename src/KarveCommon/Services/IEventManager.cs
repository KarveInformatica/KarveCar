namespace KarveCommon.Services
{
    public interface IEventManager
    {
        void registerObserverSubsystem(string id, IEventObserver obs);
        void notifyObserverSubsystem(string v, DataPayLoad dataPayload);
        void registerObserver(IEventObserver obs);
        void notifyObserver(DataPayLoad payload);
        void registerObserverToolBar(IEventObserver obs);
        void notifyObserverToolBar(DataPayLoad payload);
    }
}