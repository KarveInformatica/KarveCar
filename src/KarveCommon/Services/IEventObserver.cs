namespace KarveCommon.Services
{
    public interface IEventObserver
    {
        string UniqueId { get; set; }
        void IncomingPayload(DataPayLoad payload);
    }
}