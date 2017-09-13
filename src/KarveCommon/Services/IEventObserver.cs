namespace KarveCommon.Services
{
    public interface IEventObserver
    {
        void incomingPayload(DataPayLoad payload);
    }
}