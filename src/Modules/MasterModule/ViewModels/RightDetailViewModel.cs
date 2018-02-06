using System;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using MasterModule.Views;
using Prism.Regions;

namespace MasterModule.ViewModels
{
    /// <summary>
    ///  RightDetailClientInfoView
    /// </summary>
    class RightDetailViewModel : KarveViewModelBase
    {
        private string _name = string.Empty;
        private IEventManager _eventManager;
        private IDataServices _dataServices;
        private IRegionManager _regionManager;
        private ClientesDto _dataObject;

        /// <summary>
        ///  This returns a name.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        ///  View model for the right part of the client info view
        /// </summary>
        /// <param name="eventManager">Communication manager</param>
        /// <param name="services">Services</param>
        /// <param name="regionManager">Region manager</param>
        public RightDetailViewModel(IEventManager eventManager, IDataServices services, IRegionManager regionManager): base(services)
        {
            _eventManager = eventManager;
            _dataServices = services;
            _regionManager = regionManager;
            Name = "master://"+typeof(RightDetailViewModel).FullName;
            RegisterMailBox();
        }

        private void RegisterMailBox()
        {
            MailBoxHandler += MailBoxHandlerMethod;
            _eventManager.RegisterMailBox(Name, MailBoxHandler);
        }

        private void MailBoxHandlerMethod(DataPayLoad payLoad)
        {
            if (payLoad.HasDataObject)
            {
                DataObject = payLoad.DataObject as ClientesDto;
                _eventManager.DeleteMailBoxSubscription(Name);
                // Each view model shall have a unique uri to locate it.
                Uri uri = new Uri(Name);
                string guid = Guid.ToString();
                Uri value = new Uri(uri, guid);
                Name = value.ToString();
                _eventManager.RegisterMailBox(Name, MailBoxHandlerMethod);
            }
        }


       

        /// <summary>
        ///  Data object to be refreshed.
        /// </summary>
        public ClientesDto DataObject
        {
            get { return _dataObject; }
            set { _dataObject = (ClientesDto)value; RaisePropertyChanged(); }
        }

        public override void DisposeEvents()
        {
            _eventManager.DeleteMailBoxSubscription(Name);
        }

    }
}
