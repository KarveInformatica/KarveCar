namespace ProvidersModule
{
    public interface IEventManager
    {
        void registerObserver(IEventObserver obs);
        void notifyObserver(ISupplierPayload payload);
    }
}