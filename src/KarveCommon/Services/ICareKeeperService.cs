using KarveCommon.Command;
using System.Collections.Generic;

namespace KarveCommon.Services
{
    /// <summary>
    ///  The ICareKeeperService is a service for saving command and doing the undo of the commands. 
    /// </summary>
    public interface ICareKeeperService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Return the dataPayLoad of executed command</returns>
        DataPayLoad Do(CommandWrapper command);
        /// <summary>
        /// 
        /// </summary>
        void Undo();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        void Schedule(DataPayLoad payload);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DataPayLoad.Type GetScheduledPayloadType();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // FixMe shall return an iterator.
        Queue<DataPayLoad> GetScheduledPayload();
        /// <summary>
        ///  Number of scheduled payloads.
        /// </summary>
        /// <returns></returns>
        int ScheduledPayloadCount();
       
    }
}
