using System;

namespace KarveCommon.Services
{
    /// <summary>
    ///  This service is a global service for messagging and closing the application
    /// </summary>
    public interface IConfigurationService
    {
        void NotifyDataChange(DataPayLoad changedData);
        void SubscribeDataChange(Action<DataPayLoad> dataChanged);
        bool CloseApplication();
    }
}