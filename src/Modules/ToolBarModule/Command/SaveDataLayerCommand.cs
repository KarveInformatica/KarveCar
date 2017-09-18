﻿using KarveDataAccessLayer;
using KarveCommon.Command;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataObjects;
using System;
using System.Collections.Generic;
using System.Data;

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

        /// <summary>
        /// Save the data objects to the database table and it uses the carekeeper service to 
        /// allows the do undo of the saving.
        /// </summary>
        /// <param name="dalLocator">Database AccessLayer Inteface API</param>
        /// <param name="careKeeperService">Carekeeper Do/Undo mechanism</param>
        public SaveDataCommand(IDataServices dataServices, ICareKeeperService careKeeperService)
        {
            this._dataServices = dataServices;
            this._careKeeperService = careKeeperService;
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
        ///  This method save the supplier data layer
        /// </summary>
        /// <param name="payload"></param>
        private async void InsertOrUpdateSupplierDataLayer(DataPayLoad payload, bool insert)
        {
            ISupplierDataServices services = _dataServices.GetSupplierDataServices();
            ISupplierDataInfo info = (ISupplierDataInfo)payload.DataMap[SupplierPayLoad.SupplierDOName];
            ISupplierTypeData td = (ISupplierTypeData)payload.DataMap[SupplierPayLoad.SupplierDOType];
            ISupplierAccountObjectInfo ao = (ISupplierAccountObjectInfo)payload.DataMap[SupplierPayLoad.SupplierAccountingDO];
            DataSet monitoringData = (DataSet)payload.DataMap[SupplierPayLoad.SupplierMonitoringDS];
            DataSet evaluationData = (DataSet)payload.DataMap[SupplierPayLoad.SupplierEvaluationDS];
            DataSet transportData = (DataSet)payload.DataMap[SupplierPayLoad.SupplierTransportDS];
            DataSet contactsData = (DataSet)payload.DataMap[SupplierPayLoad.SupplierContactsDS];
            DataSet visitsData = (DataSet)payload.DataMap[SupplierPayLoad.SupplierVisitsDS];
            DataSet assuranceProviderData = (DataSet)payload.DataMap[SupplierPayLoad.SupplierAssuranceDS];
            bool contactsChanged = (bool)payload.DataMap[SupplierPayLoad.SupplierContactsChangedField];
            bool result = false;
            if (!insert)
            {
                result = await services.Update(info, 
                                               td, 
                                               ao, 
                                               monitoringData,
                                               evaluationData, 
                                               transportData,
                                               assuranceProviderData,
                                               contactsData, 
                                               visitsData, 
                                               contactsChanged);
            }
            else
            {
                result = await services.Insert(info, td, ao, monitoringData, evaluationData,
                                               transportData, assuranceProviderData, contactsChanged, visitsData);

            }
            
        }
        
        /// <summary>
        ///  Execute the save command.
        /// </summary>
        /// <param name="parameter">Data Payload that is composed of the table name and a observable collection</param>
        public override void Execute(object parameter)
        {

            if (parameter != null)
            {
                // here we have the save or update parameters.
                IDictionary<string, DataPayLoad> param = FilterParameters(parameter);
                foreach (DataPayLoad payload in param.Values)
                {
                   
                   

                    if (payload.PayloadType == DataPayLoad.Type.Update)
                    {
                        try
                        {
                            if (payload.Subsystem == DataSubSystem.SupplierSubsystem)
                            {
                                InsertOrUpdateSupplierDataLayer(payload, false);
                            }
                        }
                        catch (Exception e)
                        {
                            throw new SaveDataException(e.Message);
                        }
                    }
                    if (payload.PayloadType == DataPayLoad.Type.Insert)
                    {
                        try
                        {
                            if (payload.Subsystem == DataSubSystem.SupplierSubsystem)
                            {
                                InsertOrUpdateSupplierDataLayer(payload, true);
                            }
                        }
                        catch (Exception e)
                        {
                            throw new SaveDataException(e.Message);
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