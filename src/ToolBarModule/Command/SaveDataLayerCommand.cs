using System;
using System.Collections.ObjectModel;
using DataAccessLayer;
using KarveCommon.Command;
using KarveCommon.Services;

namespace ToolBarModule.Command
{
    public class SaveDataLayerCommand : AbstractCommand
    {
        private IDalLocator _dalLocator;
        private ICareKeeperService _careKeeperService;
        private DataPayLoad _dataPayLoad;

        public SaveDataLayerCommand(IDalLocator dalLocator, ICareKeeperService  careKeeperService)
        {
            this._dalLocator = dalLocator;
            this._careKeeperService = careKeeperService;
        }

        public void Do(object parameter)
        {
            CommandWrapper cw = new CommandWrapper(this, parameter);
            this._careKeeperService.Do(cw);
        }

        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                _dataPayLoad = parameter as DataPayLoad;
                if ((_dataPayLoad == null) || (_dataPayLoad.DataObjectName == null))
                    throw new DataLayerExecutionException();

                IDalObject dalObject = _dalLocator.FindDalObject(_dataPayLoad.DataObjectName);
                dalObject.StoreCollection(_dataPayLoad.CollectionData);
            }
        }
        public override bool UnExecute()
        {
            IDalObject dalObject = _dalLocator.FindDalObject(_dataPayLoad.DataObjectName);
            bool removeField = false;
            try
            {
                removeField = dalObject.RemoveCollection(_dataPayLoad.CollectionData);
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