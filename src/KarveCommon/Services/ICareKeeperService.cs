using KarveCommon.Command;

namespace KarveCommon.Services
{
    /// <summary>
    ///  The ICareKeeperService is a service for saving command and doing the undo of the commands. 
    /// </summary>
    public interface ICareKeeperService
    {
        void Do(CommandWrapper w);
        void Undo();
        void Schedule(DataPayLoad payload);
    }
}
