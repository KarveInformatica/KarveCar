using KarveCommon.Command;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Windows;
using Prism.Commands;

namespace ToolBarModule.Command
{
    /// <summary>
    ///  This command save the data to the database
    /// </summary>
    internal class SaveDataCommand : BaseToolBarCommand
    {
        /// <summary>
        /// The data service will be used for storing the data
        /// </summary>
        private IDataServices _dataServices;
        /// <summary>
        ///  The care keeper service will be used for doing do/undo
        /// </summary>
        private ICareKeeperService _careKeeperService;
        /// <summary>
        ///  Event manager to be used.
        /// </summary>
        private readonly IEventManager _eventManager;
        /// <summary>
        ///  Configuration service.
        /// </summary>
        private IConfigurationService _configurationService;

        private bool _errorInit = false;
        /// <summary>
        /// Save the data objects to the database table and it uses the carekeeper service to 
        /// allows the do undo of the saving.
        /// </summary>

        public SaveDataCommand(IDataServices dataServices, ICareKeeperService careKeeperService, IConfigurationService configurationService)
        {
            _dataServices = dataServices;
            _careKeeperService = careKeeperService;
            _configurationService = configurationService;
            InitHandlers();
        }
        /// <summary>
        /// Save a data command for the configuration manager.
        /// </summary>
        /// <param name="dataServices"></param>
        /// <param name="careKeeperService"></param>
        /// <param name="eventManager"></param>
        /// <param name="configurationService"></param>
        public SaveDataCommand(IDataServices dataServices, ICareKeeperService careKeeperService, IEventManager eventManager, IConfigurationService configurationService) : 
            this(dataServices, careKeeperService, configurationService)
        {
            _eventManager = eventManager;
            InitHandlers();
        }
        void InitHandlers()
        {
            if (!_errorInit)
            {
                foreach (var value in PayLoadHandlers.Values)
                {
                    value.OnErrorExecuting += HandlerOnOnErrorExecuting;
                }
                _errorInit = true; 
            }
        }
        /// <summary>
        /// Execute the command and save to the careKeeper.
        /// </summary>
        /// <param name="parameter">Data Payload that is composed of the table name and a observable collection</param>
        public void Do(object parameter)
        {
            CommandWrapper cw = new CommandWrapper(this, parameter);
            this._careKeeperService.Do(cw);
        }

        private IDictionary<string, DataPayLoad> FilterParameters(object parameters)
        {
            IDictionary<string, DataPayLoad> filterPayload = new Dictionary<string, DataPayLoad>();
            IDictionary<string, DataPayLoad> param = parameters as IDictionary<string, DataPayLoad>;
            if (param != null)
            {
                foreach (KeyValuePair<string, DataPayLoad> keypair in param)
                {
                    if (keypair.Key.Contains(DataPayLoad.Type.Insert.ToString()) ||
                        keypair.Key.Contains(DataPayLoad.Type.Update.ToString()))
                    {
                        filterPayload.Add(keypair.Key, keypair.Value);
                    }
                }
            }
            return filterPayload;
        }
        
        /// <summary>
        ///  This executes a payload that it is coming from the toolbar.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                if (parameter is DataPayLoad)
                {
                    DataPayLoad payLoad = (DataPayLoad) parameter;
                    if (PayLoadHandlers.ContainsKey(payLoad.Subsystem))
                    {
                        IDataPayLoadHandler handler = PayLoadHandlers[payLoad.Subsystem];
                        handler.ExecutePayload(_dataServices, _eventManager, ref payLoad);
                    }
                    else
                    {
                        MessageBox.Show("Error unknwon subsystem");
                    }
                }
            }
        }
        /// <summary>
        ///  This handles the error. To see how to handle directly with xaml
        /// </summary>
        /// <param name="errorType"></param>
        private void HandlerOnOnErrorExecuting(string errorType)
        {
            // FIXME: use the configuration service messagebox service.
            MessageBox.Show(errorType, "Error while saving", MessageBoxButton.OK);
        }

        /// <summary>
        /// Unexecute the save command. In this case we have no undo.
        /// </summary>
        /// <returns>true if the execution has been correct</returns>
        public override bool UnExecute()
        {
            return true;
        }
        /// <summary>
        ///  Eliminate the payload handlers.
        /// </summary>
        public override void Dispose()
        {
            foreach (var value in PayLoadHandlers.Values)
            {
                value.OnErrorExecuting -= HandlerOnOnErrorExecuting;
            }
        }
    }
}