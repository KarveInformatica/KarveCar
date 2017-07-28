using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using KarveCommon.Services;
using Prism.Commands;
using Prism.Events;
using Prism.Modularity;


namespace KarveCommon.Services
{
    /// <summary>
    ///  Configuration services is a service configuration used around the application for 
    ///  providing communication between the view models.
    /// </summary>
    public class ConfigurationService: IConfigurationService
    {

        private Window mainWindow;
        private readonly IEventAggregator eventAggregator = new EventAggregator();
       
        /// <summary>
        ///  This is the constructor of the configuration service
        /// </summary>
        /// <param name="mainWindow">The main shell of the application will be injected to the ConfigurationService.</param>
        public ConfigurationService(Window mainWindow)
        {
            this.mainWindow = mainWindow;
        }
        
        public void NotifyDataChange(DataPayLoad changedData)
        {
            lock (this)
            {
                eventAggregator.GetEvent<DataChangeEvent>().Publish(changedData);
            }
        }
        public bool CloseApplication()
        {

            if (mainWindow == null)
            {
                return false;
            }
            try
            {
                mainWindow.Close();
            }  
            catch (Exception ex)
            {
                return false;
                //  ErrorsGeneric.MessageError(ex);
            }
            return true;
        }
        public void SubscribeDataChange(Action<DataPayLoad> action)
        {
            // thread safety.
            lock (this)
            {
                this.eventAggregator.GetEvent<DataChangeEvent>().Subscribe(action);
            }
        }
    }
}
