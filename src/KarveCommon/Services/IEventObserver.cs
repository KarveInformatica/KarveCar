namespace KarveCommon.Services
{
    public interface IEventObserver
    {
        void IncomingPayload(DataPayLoad payload);
  
    }
}