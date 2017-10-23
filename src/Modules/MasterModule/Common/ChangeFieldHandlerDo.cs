using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveControls.UIObjects;

namespace MasterModule.Common
{
    /// <summary>
    /// This handles the change field data object
    /// </summary>
    internal class ChangeFieldHandlerDo<T>:IChangeHandler
    {
        private DataSet _assistantDataSet;
        private DataSubSystem _currentSubsystem;
        private T _dataObject;
        private IDictionary<string,string> _viewModelQueries;
        private IEventManager _eventManager;

        /// <summary>
        /// DataObject to be merged in case of an update
        /// </summary>
        public T DataObject { get => _dataObject; set => _dataObject = value; }
        /// <summary>
        /// AssistantDataSet to be used.
        /// </summary>
        public DataSet AssistantDataSet { get => _assistantDataSet; set => _assistantDataSet = value; }
        /// <summary>
        /// The current subsystem.
        /// </summary>
        public DataSubSystem Subsystem { get => _currentSubsystem; set => _currentSubsystem = value; }
        /// <summary>
        /// View model queries.
        /// </summary>
        public IDictionary<string,string> ViewModelQueries { get => _viewModelQueries; set => _viewModelQueries = value; }

        /// <summary>
        /// Change field handler do.
        /// </summary>
        /// <param name="ev">Events.</param>
        /// <param name="vmQueries">Queries.</param>
        /// <param name="subSystem">Kind of subsystem.</param>
        public ChangeFieldHandlerDo(IEventManager ev, IDictionary<string, string> vmQueries, DataSubSystem subSystem)
        {
            _eventManager = ev;
            _viewModelQueries = vmQueries;

        }
        /// <summary>
        /// The action to handle a changed payload on insert
        /// </summary>
        /// <param name="payLoad">DataPayLoad to be saved.</param>
        /// <param name="evDictionary">Dictionary of events.</param>
        public void OnInsert(DataPayLoad payLoad, IDictionary<string, object> evDictionary)
        {
            payLoad.PayloadType = DataPayLoad.Type.Insert;
            payLoad.HasDataObject = true;
            payLoad.Subsystem = Subsystem;
            payLoad.HasDictionary = true;
            payLoad.DataDictionary = evDictionary;
            

            SqlBuilder.StripTop(ref _viewModelQueries);
            payLoad.Queries = _viewModelQueries;
            // this now contains an object.
            if (evDictionary.ContainsKey("DataObject"))
            {
                _dataObject = (T) evDictionary["DataObject"];
                DataSetUtilities.MergeObjectChanged<T>(_dataObject, AssistantDataSet);
                payLoad.Set = AssistantDataSet;
                payLoad.HasDataSet = true;
                _eventManager.NotifyToolBar(payLoad);
            }
        }

        /// <summary>
        /// The action to handle a payload.
        /// </summary>
        /// <param name="payLoad">DataPayload to be saved.</param>
        /// <param name="evDictionary">Dictionary of the events.</param>
        public void OnUpdate(DataPayLoad payLoad, IDictionary<string, object> evDictionary)
        {
            payLoad.HasDataObject = true;
            payLoad.Subsystem = Subsystem;
            payLoad.HasDictionary = true;
            payLoad.DataDictionary = evDictionary;
            if (evDictionary.ContainsKey("DataObject"))
            {
                _dataObject = (T)evDictionary["DataObject"];
               //   DataSetHelper.MergeObjectChanged<T>(_dataObject, AssistantDataSet);
               //  payLoad.Set = AssistantDataSet;
               // payLoad.HasDataSet = true;
                _eventManager.NotifyToolBar(payLoad);
            }
        }
    }
}
