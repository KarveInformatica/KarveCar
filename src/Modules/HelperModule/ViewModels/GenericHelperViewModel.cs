using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using KarveCommon.Services;
using KarveDataServices;
using Prism.Regions;
using Prism.Commands;
using System;
using System.ComponentModel;
using System.Reflection;
using KarveCommon.Generic;

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
        
        protected Dto CurrentValue = new Dto();
        protected Dto PreviousValue;
        /// <summary>
        /// In this case is useful apply the interface segregation and divide the responsabilities between an entity loader
        /// and en entity saver. The interface-segregation principle (ISP) states that no client 
        /// should be forced to depend on methods it does not use.
        /// ISP splits interfaces that are very large into smaller and more specific ones so that clients 
        /// will only have to know about the methods that are of interest to them. 
        /// Such shrunken interfaces are also called role interfaces
        /// ISP is intended to keep a system decoupled and thus easier to refactor, change, and redeploy. I
        /// </summary>
        private HelperLoader<Dto, Entity> _loader;
        private HelperSaver<Dto, Entity> _saver;
        protected string QueryLoad;

        /// <summary>
        /// The main reason for this is the following link: https://msdn.microsoft.com/en-us/magazine/jj991977.aspx
        /// 1. Async void methods have different composing semantics. 
        /// 2. Async methods returning Task or Task<T> can be easily composed using await, Task.WhenAny, Task.WhenAll and so on. 
        /// 3. Async methods returning void don’t provide an easy way to notify the calling code that they’ve completed. 
        /// It’s easy to start several async void methods, but it’s not easy to determine when they’ve finished. 
        /// Async void methods will notify their SynchronizationContext when they start and finish, 
        /// but a custom SynchronizationContext is a complex solution for regular application code.
        /// Async void methods are difficult to test. 
        /// Because of the differences in error handling and composing, it’s difficult to write unit tests that call async void methods.
        /// Some other part of the program are using void async will be refactored to use an assistcompletion and  an assist completion handler.
        /// Each search box send and assist that has result an async method call for this we need a notify task completion.
        protected INotifyTaskCompletion<bool> AssistCompletion;
        /// <summary>
        ///  When the task is successfully completed we invoke an handler.
        /// </summary>
        protected PropertyChangedEventHandler AssistCompletionEventHandler;
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

        protected ObservableCollection<Dto> LoadView()
        {
            _loader.Load(QueryLoad);
            return _loader.HelperView;
        }

    /// <summary>
        ///  Update the value.
        /// </summary>
        protected virtual void Update()
        {
            
            HelperView = LoadView();
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
        public ObservableCollection<Dto> HelperView { get; set; } = new ObservableCollection<Dto>();

        /// <summary>
        ///  This dispose the helper when we close the tab.
        /// </summary>
        public override void DisposeEvents()
        {
            base.DisposeEvents();
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
        ///  FIXME: here there is a problem, we dont check the return value.
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
