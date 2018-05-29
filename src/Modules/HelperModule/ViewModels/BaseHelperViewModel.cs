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
    ///  BaseHelperViewModel. All the view models in the helperModule:
    ///  1. will inherit this base class.
    ///  2. This class provide navigation tools
    /// </summary>
    public abstract class BaseHelperViewModel : KarveViewModelBase, INavigationAware, ICreateRegionManagerScope
    {
        protected Uri Address;
        private string _state;
        protected bool SaveState;

        protected MailBoxMessageHandler MailBoxMessageHandler;

        /// <summary>
        ///  Load any helper window.
        /// </summary>
        protected PropertyChangedEventHandler ExecutedLoadHandler;
        protected IEventManager EventManager;

        

       
       
        /// <summary>
        ///  BaseHelperViewModel. 
        /// </summary>
        protected IRegionManager RegionManager;
     
        protected abstract Task<DataPayLoad> HandleSaveOrUpdate(DataPayLoad payLoad);
        /// <summary>
        ///  SelectionChangedCommand
        /// </summary>
        public ICommand SelectionChangedCommand { set; get; }

        /// <summary>
        ///  Helper notifier.
        /// </summary>
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
        /// <param name="payLoad">Payload coming from the EventManager that contains the entity</param>
        /// <returns></returns>
        public abstract bool UpdateEntity(DataPayLoad payLoad);
        /// <summary>
        /// Create region scope.
        /// </summary>
        public bool CreateRegionManagerScope => true;


        // Event handler.
        protected PropertyChangedEventHandler SaveChangedEventHandler;

        /// <summary>
        ///  Current state of the view model to be showed to the user:
        ///     1. Insert. (in Spanish, Agregar) 
        ///     2. Show. (in Spanish, Consulatar)
        /// </summary>

        public string State
        {
            get { return  _state; }
            set { _state = value; RaisePropertyChanged(); }
        }
        
        /// <summary>
        ///  This method register a subsystem.
        /// </summary>
        private void RegisterSubsystem()
        {
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.Subsystem = DataSubSystem.HelperSubsytsem;
            RegisterView(ref payLoad);   
            EventManager.NotifyToolBar(payLoad);

        }
    

        /// <summary>
        /// Constructor of the base class
        /// </summary>
        /// <param name="dataServices">Data Services to be used.</param>
        /// <param name="region"> Region manager to be used.</param>
        /// <param name="eventManager">Event manager to be used.</param>
        
        public BaseHelperViewModel(IDataServices dataServices, IRegionManager region, 
            IEventManager eventManager): this(dataServices, region, eventManager, null)
        {

        }
        /// <summary>
        ///  Constructor of the base class
        /// </summary>
        /// <param name="dataServices">Data service implementation.</param>
        /// <param name="region">Region manager.</param>
        /// <param name="eventManager">Event manager.</param>
        public BaseHelperViewModel(IDataServices dataServices, IRegionManager region, IEventManager eventManager, IDialogService dialogService): base(dataServices)
        { 
            RegionManager = region;
            EventManager = eventManager;
          
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
            HelperUpdateNotifier =  NotifyTaskCompletion.Create(HandleSaveOrUpdate(payLoad), SaveChangedEventHandler);
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
