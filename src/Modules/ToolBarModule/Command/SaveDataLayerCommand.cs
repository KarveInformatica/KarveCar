using KarveCommon.Command;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

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
        private IEventManager _eventManager;
        private IConfigurationService _configurationService;
        
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
        }

        public SaveDataCommand(IDataServices dataServices, ICareKeeperService careKeeperService, IEventManager eventManager, IConfigurationService configurationService) : 
            this(dataServices, careKeeperService, configurationService)
        {
            _eventManager = eventManager;
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
            foreach (KeyValuePair<string, DataPayLoad> keypair in param)
            {
                if (keypair.Key.Contains(DataPayLoad.Type.Insert.ToString()) || keypair.Key.Contains(DataPayLoad.Type.Update.ToString()))
                {
                    filterPayload.Add(keypair.Key, keypair.Value);
                }
            }
            return filterPayload;
        }
        
        /// <summary>
        ///  Execute the save command.
        /// </summary>
        /// <param name="parameter">Data Payload that is composed of the table name and a observable collection</param>
        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                if (parameter is DataPayLoad)
                {
                    DataPayLoad payLoad = (DataPayLoad)parameter;
                    if (payLoad.PayloadType == DataPayLoad.Type.Update)
                    {
                        // here we check the subsystem
                        if (payLoad.Subsystem == DataSubSystem.SupplierSubsystem)
                        {
                            ISupplierDataServices supplierDataServices = _dataServices.GetSupplierDataServices();
                            if (supplierDataServices != null)
                            {
                                // here we can update
                                IDictionary<string, string> queries = payLoad.Queries;

                                if (payLoad.HasDataSet)
                                {
                                    DataSet set = payLoad.Set;
                                    if (set != null)
                                    {
                                        supplierDataServices.UpdateDataSet(queries, set);
                                        payLoad.Sender = ToolBarModule.NAME;
                                        payLoad.PayloadType = DataPayLoad.Type.UpdateView;
                                        if (_eventManager != null)
                                        {
                                            _eventManager.SendMessage("ProviderControlViewModel", payLoad);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("ToolBar showed null dataset");
                                    }
                                }
                                if (payLoad.HasDataSetList)
                                {
                                    IList<DataSet> dataSetList = payLoad.SetList;
                                    foreach (DataSet set in dataSetList)
                                    {
                                        try
                                        {
                                            supplierDataServices.UpdateDataSet(queries, set);
                                        }
                                        catch (Exception e)
                                        {
                                            MessageBox.Show(e.Message);
                                        }
                                        DataPayLoad newSet = (DataPayLoad)payLoad.Clone();
                                        newSet.HasDataSetList = false;
                                        newSet.HasDataSet = true;
                                        payLoad.Sender = ToolBarModule.NAME;
                                        payLoad.PayloadType = DataPayLoad.Type.UpdateView;
                                        if (_eventManager != null)
                                        {
                                            _eventManager.SendMessage("ProviderControlViewModel", newSet);
                                        }
                                    }

                                }
                            }
                        }
                    }
                        
                }
            }
        }
        /// <summary>
        /// Unexecute the save command. In this case we no rollback.
        /// </summary>
        /// <returns>true if the execution has been correct</returns>
        public override bool UnExecute()
        {
            return true;
        }
    }
}