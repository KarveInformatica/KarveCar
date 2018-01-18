using Prism.Mvvm;
using System.Windows.Input;
using System.ComponentModel;
using System.Threading.Tasks;
using KarveCommon.Services;
using Prism.Regions;
using KarveDataServices;
using System;
using System.Windows;
using KarveCommon.Generic;
using KarveCommonInterfaces;

namespace HelperModule.ViewModels
{
    /// <summary>
    ///  This base helper view model.
    /// </summary>
    public abstract class BaseHelperViewModel : BindableBase, INavigationAware, ICreateRegionManagerScope
    {
        private Guid _guid;
        protected Uri Address;
        protected string _state;
        protected bool SaveState;

        protected MailBoxMessageHandler MailBoxMessageHandler;

        /// <summary>
        ///  Load any helper window.
        /// </summary>
        protected PropertyChangedEventHandler ExecutedLoadHandler;
        protected IEventManager EventManager;

        /// <summary>
        ///  Unique Id for the helpers.
        /// </summary>
        public string UniqueId { get => _guid.ToString();
            set {
                _guid = Guid.Parse(value);
            } }  

       
        protected const string InsertState = "INSERT STATE";
        protected const string UpdateState = " UPDATE STATE";
        protected const string DefaultState = "";

        /// <summary>
        ///  BaseHelperViewModel. 
        /// </summary>
        protected IRegionManager RegionManager;
        protected IDataServices DataServices;
        protected abstract Task<DataPayLoad> HandleSaveOrUpdate(DataPayLoad payLoad);
        /// <summary>
        ///  SelectionChangedCommand
        /// </summary>
        public ICommand SelectionChangedCommand { set; get; }
        public ICommand ItemChangedCommand { set; get; }
        protected INotifyTaskCompletion<DataPayLoad> HelperUpdateNotifier;
        /// <summary>
        ///  This revert the previous operation
        /// </summary>
        /// <param name="payLoad">payload</param>
        public abstract void Revert(DataPayLoad payLoad);
        /// <summary>
        ///  This delete the entity
        /// </summary>
        /// <param name="payLoad">Payload to be deleted</param>
        /// <returns></returns>
        public abstract Task<bool> DeleteEntity(DataPayLoad payLoad);
        /// <summary>
        ///  Insert a new entity
        /// </summary>
        /// <param name="payLoad"></param>
        /// <returns></returns>
        public abstract Task<bool> InsertEntity(DataPayLoad payLoad);
        /// <summary>
        ///  Update an entity.
        /// </summary>
        /// <param name="payLoad"></param>
        /// <returns></returns>
        public abstract bool UpdateEntity(DataPayLoad payLoad);

        public bool CreateRegionManagerScope => true;

        

        public string State
        {
            get { return  _state; }
            set { _state = value; RaisePropertyChanged(); }
        }

     
        private void RegisterSubsystem()
        {
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.Subsystem = DataSubSystem.HelperSubsytsem;
            RegisterView(ref payLoad);
            EventManager.NotifyToolBar(payLoad);

        }
        /// <summary>
        ///  Constructor of the base class
        /// </summary>
        /// <param name="dataServices">Data service implementation.</param>
        /// <param name="region">Region manager.</param>
        /// <param name="eventManager">Event manager.</param>
        public BaseHelperViewModel(IDataServices dataServices, IRegionManager region, IEventManager eventManager)
        { 
            DataServices = dataServices;
            RegionManager = region;
            EventManager = eventManager;
            _guid = Guid.NewGuid();
            RegisterSubsystem();
        }
        protected  void IncomingMailbox(DataPayLoad payLoad)
        {
            HandlePayLoadMessage(payLoad);
        }
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
        protected  void RegisterView(ref DataPayLoad dataPayLoad)
        {
            Address = new Uri(new Uri("karve://helpers/"), UniqueId);
            dataPayLoad.ObjectPath = Address;
        }

        protected void SaveItem(DataPayLoad payLoad)
        {
            HelperUpdateNotifier =  NotifyTaskCompletion.Create(HandleSaveOrUpdate(payLoad), null);
        }
        protected async void HandlePayLoadMessage(DataPayLoad payLoad)
        {

            if (payLoad.ObjectPath == Address)
            {
                switch (payLoad.PayloadType)
                {
                    case DataPayLoad.Type.RevertChanges:
                    {
                        Revert(payLoad);
                        break;
                    }
                    case DataPayLoad.Type.Delete:
                    {
                        bool deleted = await DeleteEntity(payLoad);
                        if (!deleted)
                        {
                            MessageBox.Show("Cannot delete helper entity");
                        }
                        break;
                    }
                    case DataPayLoad.Type.Insert:
                    {
                        bool inserted = await InsertEntity(payLoad);
                        if (!inserted)
                        {
                            MessageBox.Show("Cannot insert helper entity");
                        }
                            break;
                    }
                    case DataPayLoad.Type.Update:
                    {
                        bool update = UpdateEntity(payLoad);
                        if (!update)
                        {
                            MessageBox.Show("Cannot update helper entity");
                        }
                        break;
                    }
                }
            }
        }
    }
}
