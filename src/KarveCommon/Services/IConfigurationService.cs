using System;
using System.Collections.ObjectModel;
using Prism.Commands;

namespace KarveCommon.Services
{
    /// <summary>
    ///  This service is a global service for messagging and closing the application
    /// </summary>
    public interface IConfigurationService
    {
        void NotifyDataChange(ObservableCollection<object> changedData);
        void SubscribeDataChange(Action<ObservableCollection<object>> dataChanged);
        bool CloseApplication();
    }
}