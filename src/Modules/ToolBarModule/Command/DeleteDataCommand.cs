using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Command;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;

namespace ToolBarModule.Command
{
    /// <summary>
    /// Delete data command.
    /// </summary>
    class DeleteDataCommand: AbstractCommand
    {
        private IDataServices _dataServices;
        private ICareKeeperService _careKeeper;
        private IEventManager _eventManager;
        private IConfigurationService _configurationService;
        private SqlValidationRule _sqlValidationRule;

        public DeleteDataCommand(IDataServices dataServices, ICareKeeperService careKeeper, IEventManager eventManager, IConfigurationService configurationService)
        {
            _dataServices = dataServices;
            _careKeeper = careKeeper;
            _eventManager = eventManager;
            _configurationService = configurationService;
        }
        public SqlValidationRule ValidationRules
        {
            get
            {
                return _sqlValidationRule;

            }
            set
            {
                _sqlValidationRule = value;
            }
        }
        public override bool CanExecute(object parameter)
        {
            if (_sqlValidationRule==null)
                return false;
            DataPayLoad param = (DataPayLoad)parameter;
            // chain of resposability design pattern.
            bool validate = false;
            validate = _sqlValidationRule.Validate(param);
            return validate;
        }

        public override void Execute(object parameter)
        {
            DataPayLoad payLoad = (DataPayLoad)parameter;
            if (payLoad == null)
                return;
            if (payLoad.PayloadType == DataPayLoad.Type.Delete)
            {
                if (payLoad.Subsystem == DataSubSystem.SupplierSubsystem)
                {
                    ISupplierDataServices dataServices = _dataServices.GetSupplierDataServices();
                    DataSet set;
                    // dataServices.DeleteSupplier()
                }
            }
        }
    }
}
