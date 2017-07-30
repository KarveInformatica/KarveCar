using System;
using System.Collections.ObjectModel;
using DataAccessLayer;
using KarveCommon.Command;
using KarveCommon.Services;

namespace ToolBarModule.Command
{
    /// <summary>
    ///  This command save the data to the database
    /// </summary>
    public class SaveDataLayerCommand : AbstractCommand
    {
        private IDalLocator dalLocator;
        private ICareKeeperService careKeeperService;
        private DataPayLoad dataPayLoad;
        /// <summary>
        /// Save the data objects to the database table and it uses the carekeeper service to 
        /// allows the do undo of the saving.
        /// </summary>
        /// <param name="dalLocator">Database AccessLayer Inteface API</param>
        /// <param name="careKeeperService">Carekeeper Do/Undo mechanism</param>
        public SaveDataLayerCommand(IDalLocator dalLocator, ICareKeeperService  careKeeperService)
        {
            this.dalLocator = dalLocator;
            this.careKeeperService = careKeeperService;
        }
        /// <summary>
        /// Execute the command and save to the careKeeper.
        /// </summary>
        /// <param name="parameter">Data Payload that is composed of the table name and a observable collection</param>
        public void Do(object parameter)
        {
            CommandWrapper cw = new CommandWrapper(this, parameter);
            this.careKeeperService.Do(cw);
        }
        /// <summary>
        ///  Execute the save command.
        /// </summary>
        /// <param name="parameter">Data Payload that is composed of the table name and a observable collection</param>
        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                dataPayLoad = parameter as DataPayLoad;
                if ((dataPayLoad == null) || (dataPayLoad.DataObjectName == null))
                    throw new DataLayerExecutionException();
                
                IDalObject dalObject = dalLocator.FindDalObject(dataPayLoad.DataObjectName);
                if (dalObject != null)
                {
                    dalObject.StoreCollection(dataPayLoad.CollectionData);
                }
            }
        }
        /// <summary>
        /// Unexecute the save command
        /// </summary>
        /// <returns>true if the execution has been correct</returns>
        public override bool UnExecute()
        {
            IDalObject dalObject = dalLocator.FindDalObject(dataPayLoad.DataObjectName);
            try
            {
               dalObject.RemoveCollection(dataPayLoad.CollectionData);
            }
            catch (DataLayerExecutionException e)
            {
                // just for now we change the exception path
                // an exception is something special
                return false;
            }
            return true;
        }
    }
}