using System.Collections.Generic;
using System.Diagnostics.Contracts;
using KarveCommon.Services;

namespace KarveCommon
{
    /// <summary>
    /// This handles the change field data object
    /// </summary>
    public class ChangeFieldHandlerDo<T> : IChangeHandler where T: class
    {
        private DataSubSystem _currentSubsystem;
        private T _dataObject;
        private IDictionary<string, string> _viewModelQueries;
        private IEventManager _eventManager;

        /// <summary>
        /// DataObject to be merged in case of an update
        /// </summary>
        public T DataObject
        {
            get => _dataObject;
            set => _dataObject = value;
        }
        /// <summary>
        /// The current subsystem.
        /// </summary>
        public DataSubSystem Subsystem
        {
            get => _currentSubsystem;
            set => _currentSubsystem = value;
        }
        /// <summary>
        /// View model queries.
        /// </summary>
        public IDictionary<string, string> ViewModelQueries
        {
            get => _viewModelQueries;
            set => _viewModelQueries = value;
        }

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
            _currentSubsystem = subSystem;

        }
        /// <summary>
        /// Change field handler do.
        /// </summary>
        /// <param name="ev">Events.</param>
        /// <param name="vmQueries">Queries.</param>
        /// <param name="subSystem">Kind of subsystem.</param>
        public ChangeFieldHandlerDo(IEventManager ev,  DataSubSystem subSystem)
        {
            _eventManager = ev;
            _viewModelQueries = null;
            _currentSubsystem = subSystem;

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
            //SqlBuilder.StripTop(ref _viewModelQueries);
            payLoad.Queries = _viewModelQueries;
            // this now contains an object.
            if (evDictionary.ContainsKey("DataObject"))
            {
                
                payLoad.HasDataObject = true;
                _eventManager.NotifyToolBar(payLoad);
            }
        }
        /// <summary>
        ///  This enforce the change of a view model field.
        /// </summary>
        /// <param name="evDictionary">Dictionary of fields coming from the lower level.</param>
        /// <param name="dataObject">Data fields to be enforced.</param>
        private void EnforceChange(IDictionary<string, object> evDictionary, ref T dataObject)
        {
            string path = "";
            if (evDictionary.ContainsKey("Field"))
            {
                path = evDictionary["Field"] as string;
                if (evDictionary.ContainsKey("ChangedValue"))
                {
                    var changedValue = evDictionary["ChangedValue"];
                    ComponentUtils.SetPropValue(dataObject, path, changedValue);

                }
            }

        }
        /// <summary>
        /// The action to handle a payload.
        /// </summary>
        /// <param name="payLoad">DataPayload to be saved.</param>
        /// <param name="evDictionary">Dictionary of the events.</param>
        public void OnUpdate(DataPayLoad payLoad, IDictionary<string, object> evDictionary)
        {
            Contract.Requires(payLoad != null, "Cannot update the payload");
            Contract.Requires(_eventManager != null, "Data object is not null");
            payLoad.Subsystem = Subsystem;
            payLoad.PayloadType = DataPayLoad.Type.Update;
            _dataObject = payLoad.DataObject as T;
            _eventManager.NotifyToolBar(payLoad);
            
        }
    }
}
