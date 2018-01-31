using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using KarveCommon.Command;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataObjects;
using ToolBarModule.Command;

namespace ToolBarModule
{
    class InsertDataCommand : AbstractCommand
    {
        private IDataServices _dataServices;
        private ICareKeeperService _careKeeper;
        private IEventManager _eventManager;
        private IConfigurationService _configurationService;
        // FIXME: move the payload handlers in an upper class.
        private ISqlValidationRule<DataPayLoad> _sqlValidationRule;
        // FIXME: move the payload handlers in an upper class.
        private IDictionary<DataSubSystem, IDataPayLoadHandler> payLoadHandlers =
            new Dictionary<DataSubSystem, IDataPayLoadHandler>()
            {
                {DataSubSystem.SupplierSubsystem, new SupplierDataPayload()},
                {DataSubSystem.CommissionAgentSubystem, new CommissionAgentPayload()},
                {DataSubSystem.HelperSubsytsem, new HelperDataPayLoad()},
                { DataSubSystem.ClientSubsystem,  new ClientDataPayload() }
            };
        /// <summary>
        /// This is the configuratin of an insert command.
        /// </summary>
        /// <param name="dataServices"></param>
        /// <param name="careKeeper"></param>
        /// <param name="eventManager"></param>
        /// <param name="configurationService"></param>
        public InsertDataCommand(IDataServices dataServices, ICareKeeperService careKeeper, IEventManager eventManager, IConfigurationService configurationService)
        {
            _dataServices = dataServices;
            _careKeeper = careKeeper;
            _eventManager = eventManager;
            _configurationService = configurationService;
            InitHandlers();
        }
        /// <summary>
        ///  Validation rules to be enforced  before the insert.
        /// </summary>
        public ISqlValidationRule<DataPayLoad> ValidationRules
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
        /// <summary>
        /// Check the validation chains 
        /// </summary>
        /// <param name="parameter">It is a parameter as data payload</param>
        /// <returns></returns>
        public override bool CanExecute(object parameter)
        {
            DataPayLoad param = (DataPayLoad) parameter;
            // chain of resposability design pattern.
            bool validate = _sqlValidationRule.Validate(param);
            return validate;
        }
        private void Handler_OnErrorExecuting(string errorType)
        {
            // change this for a better solution with a separation.
            MessageBox.Show(errorType, "Error during insert", MessageBoxButtons.OK);
        }

        void InitHandlers()
        {
            foreach (var value in payLoadHandlers.Values)
            {
                value.OnErrorExecuting+= Handler_OnErrorExecuting;
            }
        }
        public override void Execute(object parameter)
        {
           
            DataPayLoad payLoad = (DataPayLoad)parameter;
            if (payLoad == null)
                return;

                if (payLoadHandlers.ContainsKey(payLoad.Subsystem))
                {
                    IDataPayLoadHandler handler = payLoadHandlers[payLoad.Subsystem];
                    handler.ExecutePayload(_dataServices, _eventManager, ref payLoad);
                }
                else
                {
                    MessageBox.Show("Error selecting the insert action handler. Subsystem not known");
                }
            
        }
    }
}