using System;
using System.Collections.Generic;
using System.Data;
using KarveCommon.Services;
using KarveDataServices;

namespace ToolBarModule.Command
{
    internal class SupplierDataPayload : IDataPayLoadHandler
    {
        private ISupplierDataServices _dataServices = null;
        private IEventManager _manager = null;

        public SupplierDataPayload()
        {
        }

        public event ErrorExecuting OnErrorExecuting;
        /// <summary>
        ///  This updates a data set.
        /// </summary>
        /// <param name="payLoad"></param>
        /// <param name="set"></param>
        /// <param name="queries"></param>
        private void HandleDataSetUpdate(DataPayLoad payLoad, DataSet set, IDictionary<string, string> queries)
        {
            try
            {
                _dataServices.UpdateDataSet(queries, set);
                payLoad.Queries = queries;
                payLoad.Sender = ToolBarModule.NAME;
                payLoad.PayloadType = DataPayLoad.Type.UpdateView;
                NotifyEventManager(_manager, payLoad);
            }
            catch (Exception e)
            {
                OnErrorExecuting?.Invoke(e.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="payLoad"></param>
        /// <param name="dataSetList"></param>
        /// <param name="queries"></param>
        private void HandleDataSetListUpdate(DataPayLoad payLoad, IList<DataSet> dataSetList, IDictionary<string, string> queries)
        {
            foreach (DataSet set in dataSetList)
            {
                try
                {
                    _dataServices.UpdateDataSet(queries, set);
                    DataPayLoad newSet = (DataPayLoad)payLoad.Clone();
                    newSet.HasDataSetList = false;
                    newSet.HasDataSet = true;
                    payLoad.Sender = ToolBarModule.NAME;
                    payLoad.PayloadType = DataPayLoad.Type.UpdateView;
                    NotifyEventManager(_manager, payLoad);
                }
                catch (Exception e)
                {
                    OnErrorExecuting?.Invoke(e.Message);
                }
            }


        }
        private void NotifyEventManager(IEventManager manager, DataPayLoad payLoad)
        {
            manager.SendMessage(EventSubsystem.SuppliersSummaryVm, payLoad);
        }

        /// <summary>
        /// This execute the payload and notify the event manager
        /// </summary>
        /// <param name="services">Services to be used</param>
        /// <param name="manager">Manager to be notified</param>
        /// <param name="payLoad">Payload to execute.</param>
        public void ExecutePayload(IDataServices services, IEventManager manager, DataPayLoad payLoad)
        {
            _dataServices = services.GetSupplierDataServices();
            _manager = manager;
            switch (payLoad.PayloadType)
            {
                case DataPayLoad.Type.Update:
                    {
                        if (payLoad.HasDataSetList)
                        {
                            HandleDataSetListUpdate(payLoad, payLoad.SetList, payLoad.Queries);
                        }
                        if (payLoad.HasDataSet)
                        {
                            HandleDataSetUpdate(payLoad, payLoad.Set, payLoad.Queries);
                        }
                        break;
                    }
            }
        }
    }
}
