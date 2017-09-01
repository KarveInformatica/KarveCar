using DataAccessLayer;
using KarveCommon.Command;
using KarveCommon.Services;
using KarveDataServices;
using System;
using System.Collections.Generic;

namespace ToolBarModule.Command
{
    /// <summary>
    ///  This command save the data to the database
    /// </summary>
    public class SaveDataCommand : AbstractCommand
    {
        private IDataServices _dataServices;
        private ICareKeeperService _careKeeperService;
        private DataPayLoad _dataPayLoad;
        private IDictionary<string, DataPayLoad> dictionary = new Dictionary<string, DataPayLoad>();
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
        private void SaveSupplierDataLayer(DataPayLoad payload)
        {

        }
        private void SaveVehicleGroupDataLayer(DataPayLoad payload)
        {

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
                    // the host is the subsystem
                    Uri uri = payload.ObjectPath;

                //    uri.Host == Envit

                    if (payload.PayloadType == DataPayLoad.Type.Update)
                    {
                        try
                        {
                            if (payload.Subsystem == (int)KarveDataServices.DataSubSystem.SupplierSubsystem)
                            {
                                ISupplierDataServices supplierDataServices = _dataServices.GetSupplierDataServices();
                                
                                
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
                            if (payload.Subsystem == (int)KarveDataServices.DataSubSystem.SupplierSubsystem)
                            {
                                ISupplierDataServices supplierDataServices = _dataServices.GetSupplierDataServices();
                            //    supplierDataServices.InsertDataObject(payload.DataObject);
                            //    supplierDataServices.InsertDataSet(payload.Set);
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
        /// Unexecute the save command
        /// </summary>
        /// <returns>true if the execution has been correct</returns>
        public override bool UnExecute()
        {
            return true;
        }
    }
}