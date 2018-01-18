using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using KarveCommon.Services;
using KarveDataServices;
using Prism.Regions;
using Prism.Commands;
using System;
using System.Reflection;

namespace HelperModule.ViewModels
{
    /// <summary>
    ///  Generic class for doing CRUD with the helpers. 
    ///  We can use this crud because most of the aux forms contains just an entity and not related entity.
    ///  It allows as well.
    /// </summary>
    /// <typeparam name="Dto">Data Transfer Object</typeparam>
    /// <typeparam name="Entity">Entity to be mapped.</typeparam>
    public abstract class GenericHelperViewModel<Dto, Entity> : BaseHelperViewModel where Entity : class, new()
        where Dto : class, new()
    {
        private ObservableCollection<Dto> _listOfValues = new ObservableCollection<Dto>();
        protected Dto CurrentValue = new Dto();
        protected Dto PreviousValue;
        private HelperLoader<Dto, Entity> _loader;
        private HelperSaver<Dto, Entity> _saver;
        protected string QueryLoad;
        private ObservableCollection<Dto> _helperView;

        /// <summary>
        /// GenericHelperViewModel
        /// </summary>
        /// <param name="query">Loading query for the helper</param>
        /// <param name="dataServices">DataService abstraction layer</param>
        /// <param name="region">Region to navigate</param>
        /// <param name="manager">EventManager for communicate with other components</param>
        public GenericHelperViewModel(string query, IDataServices dataServices, IRegionManager region,
            IEventManager manager) : base(dataServices, region, manager)
        {
            SelectionChangedCommand = new DelegateCommand<object>(OnSelectionChangedCommand);
            ItemChangedCommand = new DelegateCommand<object>(OnItemChangedCommand);
            SaveState = false;
            QueryLoad = query;
            InitLoader(dataServices, query);
            _saver = new HelperSaver<Dto, Entity>(dataServices);
            var id = Address.ToString();
            MailBoxMessageHandler += IncomingMailbox;
            EventManager.RegisterMailBox(id, MailBoxMessageHandler);
        }
        private void InitLoader(IDataServices dataServices, string query)
        {
            _loader = new HelperLoader<Dto, Entity>(dataServices);
            if (query == string.Empty)
            {
                _loader.LoadAll();
                if (_loader.HelperView != null)
                {
                    HelperView = _loader.HelperView;
                    HelperDto = _loader.HelperView.FirstOrDefault();
                }
            }
            else
            {
                _loader.Load(query);
                if (_loader.HelperView != null)
                {
                    HelperView = _loader.HelperView;
                    HelperDto = _loader.HelperView.FirstOrDefault();
                }
            }
        }
    
        /// <summary>
        /// Selection changed within the grid.
        /// </summary>
        /// <param name="obj"></param>
        private void OnSelectionChangedCommand(object obj)
        {
            var value = obj as Dto;
            if (value != null)
            {
                HelperDto = value;
            }
        }
        /// <summary>
        ///  Reverted current value.
        /// </summary>
        /// <param name="payLoad">This is the payload.</param>
        public override void Revert(DataPayLoad payLoad)
        {
            var tmp = CurrentValue;
            CurrentValue = payLoad.DataObject as Dto;
            PreviousValue = tmp;      
        }
        /// <summary>
        ///  Element to delete the entity
        /// </summary>
        /// <param name="payLoad">Payload to be deleted</param>
        /// <returns></returns>
        public override async Task<bool> DeleteEntity(DataPayLoad payLoad)
        {
            var cv = CurrentValue;
            bool entityDeleted = false;
            if (cv != null)
            {
                entityDeleted = await DataServices.GetHelperDataServices()
                    .ExecuteAsyncDelete<Dto, Entity>(cv);
                if (entityDeleted)
                {
                    Update();
                   
                }
                else
                {
                    MessageBox.Show("Error deleting item");
                }
            }
            return entityDeleted;
        }
        /// <summary>
        ///  Update the value.
        /// </summary>
        protected void Update()
        {
            _loader.Load(QueryLoad);
            HelperView = _loader.HelperView;
            PreviousValue = CurrentValue;
            CurrentValue = HelperView.FirstOrDefault();
        }
        /// <summary>
        ///  Helper dto.
        /// </summary>
        public Dto HelperDto
        {
            get { return CurrentValue; }
            set { CurrentValue = value; RaisePropertyChanged(); }
        }
        /// <summary>
        ///  Helper collection
        /// </summary>
        public ObservableCollection<Dto> HelperView
        {
            get { return _helperView; }
            set { _helperView = value; }
        }
        /// <summary>
        ///  This dispose the helper when we close the tab.
        /// </summary>
        public void DisposeEvents()
        {
            var id = Address.ToString();
            EventManager.DeleteMailBoxSubscription(id);
        }
        /// <summary>
        ///  Notify the toolbar after a change.
        /// </summary>
        /// <param name="changedValue">The object changed in the textbox.</param>
        private void OnItemChangedCommand(object changedValue)
        {
            DataPayLoad payload = new DataPayLoad();
            payload.ObjectPath = Address;
            payload.PayloadType = DataPayLoad.Type.Update;
            payload.Subsystem = DataSubSystem.HelperSubsytsem;
            payload.DataObject = CurrentValue;
            payload.HasDataObject = true;
            payload.HasOldValue = true;
            payload.OldValue = PreviousValue;
            EventManager.NotifyToolBar(payload);
        }
        /// <summary>
        ///  SetUnique code. Unique code in the karve.
        /// </summary>
        /// <param name="payLoad">Data payload to be analized.</param>
        /// <param name="dataServices">Data Services to be analized/</param>
        public abstract Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices);

        /// <summary>
        /// Payload to be part of the modification.
        /// </summary>
        /// <param name="payLoad">Data payload to set the modification date.</param>
        public virtual void SetModification(ref DataPayLoad payLoad)
        {
            var lastModification = DateTime.Now;
            var dto = payLoad.DataObject;
            Type t = dto.GetType();
            PropertyInfo info = t.GetProperty("LastModification");
            if (info != null)
            {
                info.SetValue(dto, lastModification.ToString("yyyMMddHHmmss"));
            }
            payLoad.DataObject = dto;
        }
        /// <summary>
        ///  Insert entity. This insert an entity for the owner.
        /// </summary>
        /// <param name="payLoad">Payload that contains the entity to be inserted.</param>
        /// <returns></returns>
        public override async Task<bool> InsertEntity(DataPayLoad payLoad)
        {
            bool entityInserted = true;
            // here we shall use navigation for creating a new view.
            Dto dto = new Dto();
            await SetCode(payLoad, DataServices);
            SetModification(ref payLoad);
            CurrentValue = dto;
            PreviousValue = dto;
            State = BaseHelperViewModel.InsertState;
            return entityInserted;
        }
        /// <summary>
        ///  Update summary.
        /// </summary>
        /// <param name="payLoad">Payload to be updated.</param>
        /// <returns></returns>
        public override bool UpdateEntity(DataPayLoad payLoad)
        {
            State = BaseHelperViewModel.UpdateState;
            SaveState = false;
            SaveItem(payLoad);
            Update();
            return SaveState;
        }
        /// <summary>
        ///  This is to save or update the data contained in the payload.
        /// </summary>
        /// <param name="payLoad"></param>
        /// <returns></returns>
        protected override async Task<DataPayLoad> HandleSaveOrUpdate(DataPayLoad payLoad)
        {
            DataPayLoad currentPayLoad = payLoad;
            if (currentPayLoad.HasDataObject)
            {
                SetModification(ref currentPayLoad);
                Dto currentDto = currentPayLoad.DataObject as Dto ;
                if (currentDto == null)
                {
                    currentDto = CurrentValue;
                }
                bool value = await _saver.SaveDto(currentDto);
                if (!value)
                {
                    State = "Error in insertion/update";
                }
               SaveState = value;
               State = "";
            }
            return currentPayLoad;
        }

      
    }
}
