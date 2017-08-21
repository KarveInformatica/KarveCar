namespace ProvidersModule
{
    public interface IEventObserver
    {
        void incomingPayload(ISupplierPayload payload);
    }
}