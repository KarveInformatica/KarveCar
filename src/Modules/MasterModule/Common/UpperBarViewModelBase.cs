using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using KarveControls.Generic;

namespace MasterModule.Common
{
    /// <summary>
    ///  Base class for the upper bar view model.
    /// </summary>
    public abstract class UpperBarViewModelBase: KarveViewModelBase
    {
        protected IEnumerable _sourceView= new List<object>();
        private object _dataObject = new object();
        protected IEventManager EventManager;
      
        protected DataSubSystem _subsystem;
        //protected const string AssistQuery = "AssistQuery";
       
       
        protected string PrimaryKeyValue = "";

        protected enum UpperBarViewModelState
        {
            Init, Loaded
        };

        protected UpperBarViewModelState _status;
        private ICommand _assistCommand;
        private ICommand _itemChangedHandler;
       
        /// <summary>
        ///  This is an upperbar view model base.
        /// </summary>
        protected UpperBarViewModelBase()
        {
            
        }
        /// <summary>
        ///  Constructor view model for the upper bar in the tabs of the master registry.
        /// </summary>
        /// <param name="eventManager"></param>
        /// <param name="dataServices"></param>
        public UpperBarViewModelBase(IEventManager eventManager, IDataServices dataServices): base(dataServices)
        {

            EventManager = eventManager;
            DataServices = dataServices;
        }

        protected void OnChangedItem(object data)
        {
            object currentObject = data;
            if (data is IDictionary<string, object>)
            {


                IDictionary<string, object> eventDictionary = data as IDictionary<string, object>;

                var fieldName = string.Empty;
                object valueName = null;

                if (eventDictionary.ContainsKey("DataObject"))
                {
                    var dataObjectValue = eventDictionary["DataObject"];
                    if (eventDictionary.ContainsKey("Field"))
                    {
                        fieldName = eventDictionary["Field"] as string;

                    }
                    if (eventDictionary.ContainsKey("ChangedValue"))
                    {
                        valueName = eventDictionary["ChangedValue"];
                    }

                    if (valueName != null)
                    {
                        currentObject = dataObjectValue;
                        ComponentUtils.SetPropValue(currentObject, "Value." + fieldName, valueName, true);
                        //payLoad.DataObject = currentObject;
                    }
                }
            }
            object dataObject = data;
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.DataObject = currentObject;

            UpdateDataObject(currentObject);
            payLoad.PayloadType = DataPayLoad.Type.Update;
            payLoad.HasDataObject = true;
            // it is important for following updates.
            payLoad.PrimaryKeyValue = PrimaryKeyValue;
            // both are very important for the event manager.
            payLoad.Subsystem = _subsystem;
            payLoad.SubsystemName = MasterModuleConstants.ProviderSubsystemName;
            // send message to the main view model to any item.
            EventManager.NotifyToolBar(payLoad);
        }

        protected abstract void UpdateDataObject(object currentObject);
        


       
    
        /// <summary>
        ///  Changed item
        /// </summary>
        public ICommand ItemChangedHandler {
             set {
            _itemChangedHandler = value;
            RaisePropertyChanged();
            }
        get { return _itemChangedHandler; }
    }

    /// <summary>
        ///  Assist Command
        /// </summary>
        public ICommand AssistCommand
        {
            set { _assistCommand = value; RaisePropertyChanged(); }
            get { return _assistCommand; }
        }

        /// <summary>
        ///  ChangedItem
        /// </summary>
        public ICommand ChangedItem { set; get; }

        /// <summary>
        ///  SourceView
        /// </summary>
        public abstract IEnumerable SourceView { set; get; }
        
    }

}