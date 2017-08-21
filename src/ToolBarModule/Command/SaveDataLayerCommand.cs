using DataAccessLayer;
using KarveCommon.Command;
using KarveCommon.Services;
using KarveDataServices;

namespace ToolBarModule.Command
{
    /// <summary>
    ///  This command save the data to the database
    /// </summary>
    public class SaveDataLayerCommand : AbstractCommand
    {
        private IDataServices _dataServices;
        private ICareKeeperService _careKeeperService;
        private DataPayLoad _dataPayLoad;
        /// <summary>
        /// Save the data objects to the database table and it uses the carekeeper service to 
        /// allows the do undo of the saving.
        /// </summary>
        /// <param name="dalLocator">Database AccessLayer Inteface API</param>
        /// <param name="careKeeperService">Carekeeper Do/Undo mechanism</param>
        public SaveDataLayerCommand(IDataServices dataServices, ICareKeeperService careKeeperService)
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
        /// <summary>
        ///  Execute the save command.
        /// </summary>
        /// <param name="parameter">Data Payload that is composed of the table name and a observable collection</param>
        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
            
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