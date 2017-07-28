using System;
using System.Windows;
using Prism.Events;


namespace KarveCommon.Services
{
    /// <summary>
    ///  Configuration services is a service configuration used around the application for 
    ///  providing a communication mechanism between the view models.
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
        /// <summary>
        /// This method notify the change of the DataPayLoad the receiver.
        /// </summary>
        /// <param name="changedData">Payload changed. In case of DataPayload it has inside the data.</param>
        public void NotifyDataChange(DataPayLoad changedData)
        {
            lock (this)
            {
                eventAggregator.GetEvent<DataChangeEvent>().Publish(changedData);
            }
        }
        /// <summary>
        ///  This close the application.
        /// </summary>
        /// <returns>true if the close has been successfully.</returns>
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
                throw new ConfigurationServiceException("ConfigurationService Error during CloseApplication. Reason:" + ex.Message);
            }
            return true;
        }
        /// <summary>
        /// This method subscribe waiting for the change of the data. It shall be an asynchronous subscribtion.
        /// </summary>
        /// <param name="action"></param>
        public void SubscribeDataChange(Action<DataPayLoad> action)
        {
            // thread safety.
            lock (this)
            {
                this.eventAggregator.GetEvent<DataChangeEvent>().Subscribe(action);
            }
        }
    }
    /// <summary>
    ///  Customization of the service.
    /// </summary>
    public class ConfigurationServiceException : Exception
    {
        public ConfigurationServiceException(string exMessage): base(exMessage)
        {
        }
    }
}
