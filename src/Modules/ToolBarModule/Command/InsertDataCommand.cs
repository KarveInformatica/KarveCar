using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using KarveCommon.Command;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;

namespace ToolBarModule
{
    class InsertDataCommand : AbstractCommand
    {
        private IDataServices _dataServices;
        private ICareKeeperService _careKeeper;
        private IEventManager _eventManager;
        private IConfigurationService _configurationService;
        private SqlValidationRule _sqlValidationRule;

        public InsertDataCommand(IDataServices dataServices, ICareKeeperService careKeeper, IEventManager eventManager, IConfigurationService configurationService)
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

        private void ManageSupplierInsertion(DataPayLoad payLoad)
        { 
            ISupplierDataServices supplierDataServices = _dataServices.GetSupplierDataServices();
            if (supplierDataServices != null)
            {
                IDictionary<string, string> queries = payLoad.Queries;
                if (payLoad.HasDataSetList)
                {
                    IList<DataSet> dataSetList = payLoad.SetList;

                        try
                        {
                            string name = dataSetList[0].DataSetName;
                            supplierDataServices.UpdateDataSet(queries, dataSetList[0]);
                          

                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                        DataPayLoad newSet = (DataPayLoad)payLoad.Clone();
                        newSet.HasDataSetList = true;
                        newSet.HasDataSet = false;
                        newSet.SetList = payLoad.SetList;
                        newSet.Queries = payLoad.Queries;
                        newSet.Sender = ToolBarModule.NAME;
                        newSet.PayloadType = DataPayLoad.Type.UpdateView;
                        if (_eventManager != null)
                        {
                           _eventManager.SendMessage("ProvidersControlViewModel", newSet);
                        }
                    
                }
            }
        }

        public override void Execute(object parameter)
        {
           
            DataPayLoad payLoad = (DataPayLoad)parameter;
            if (payLoad == null)
                return;
            if (payLoad.PayloadType == DataPayLoad.Type.Insert)
            {
                    if (payLoad.Subsystem == DataSubSystem.SupplierSubsystem)
                    {
                        ManageSupplierInsertion(payLoad);
                    }
            }
        }
    }
}