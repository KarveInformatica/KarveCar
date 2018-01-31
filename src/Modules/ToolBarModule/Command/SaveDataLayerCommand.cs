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
    public class SaveDataCommand : AbstractCommand
    {
        /// <summary>
        /// The data service will be used for storing the data
        /// </summary>
        private IDataServices _dataServices;
        /// <summary>
        ///  The care keeper service will be used for doing do/undo
        /// </summary>
        private ICareKeeperService _careKeeperService;
        private readonly IEventManager _eventManager;
        private IConfigurationService _configurationService;

        private IDictionary<DataSubSystem, IDataPayLoadHandler> payLoadHandlers =
            new Dictionary<DataSubSystem, IDataPayLoadHandler>()
            {
                { DataSubSystem.SupplierSubsystem, new SupplierDataPayload() },
                { DataSubSystem.CommissionAgentSubystem, new CommissionAgentPayload()},
                { DataSubSystem.VehicleSubsystem, new VehicleDataPayload() },
                {DataSubSystem.HelperSubsytsem, new HelperDataPayLoad() },
                { DataSubSystem.ClientSubsystem, new ClientDataPayload() }
            };

        /// <summary>
        /// Save the data objects to the database table and it uses the carekeeper service to 
        /// allows the do undo of the saving.
        /// </summary>
        /// <param name="dalLocator">Database AccessLayer Inteface API</param>
        /// <param name="careKeeperService">Carekeeper Do/Undo mechanism</param>
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
            foreach (var value in payLoadHandlers.Values)
            {
                value.OnErrorExecuting += HandlerOnOnErrorExecuting; 
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
                    if (payLoadHandlers.ContainsKey(payLoad.Subsystem))
                    {
                        IDataPayLoadHandler handler = payLoadHandlers[payLoad.Subsystem];
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
    }
}