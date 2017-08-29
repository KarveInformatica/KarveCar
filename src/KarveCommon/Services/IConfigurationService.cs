using System;
using System.Collections.ObjectModel;
using Prism.Commands;
using System.Windows.Controls;
using static KarveCommon.Generic.RecopilatorioEnumerations;

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
        void AddMainTab(object view, string tabName);
    }
}