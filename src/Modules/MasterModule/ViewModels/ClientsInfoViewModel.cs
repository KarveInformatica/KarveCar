using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using AutoMapper;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using MasterModule.Common;
using Prism.Regions;
using DataAccessLayer.Logic;
using Prism.Commands;

namespace MasterModule.ViewModels
{
    /// <summary>
    /// This class is responsible for adding/modifying and viewing a view model.
    /// </summary>
    class ClientsInfoViewModel: MasterInfoViewModuleBase, IEventObserver, IDisposeEvents
    {
        private IClientData _clientData;
        private IClientDataServices _clientDataServices;
        private object _province;
        private object _country;
        private object _company;
        private object _clientZone;
        private object _origenDto;
        private object _office;

        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="eventManager">Event manager</param>
        /// <param name="configurationService">Configuration service</param>
        /// <param name="dataServices">Data Service</param>
        /// <param name="manager">Region Manager</param>
        public ClientsInfoViewModel(IEventManager eventManager, IConfigurationService configurationService, IDataServices dataServices, IRegionManager manager) : base(eventManager, configurationService, dataServices, manager)
        {
            base.ConfigureAssist();

            ConfigurationService = configurationService;
            MailBoxHandler += MessageHandler;
            EventManager.RegisterObserverSubsystem(MasterModuleConstants.ClientSubSystemName, this);
            _clientDataServices = dataServices.GetClientDataServices();
            InitVmCommands();
        }
        /// <summary>
        ///  Initialize view model.
        /// </summary>
        private void InitVmCommands()
        {
            ItemChangedCommand = new Prism.Commands.DelegateCommand<object>(OnChangedField);
            AssistCommand = new Prism.Commands.DelegateCommand<object>(OnAssistCommand);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void OnChangedField(object obj)
        {
           
        }
        // move to the master,
        private async void OnAssistCommand(object param)
        {
            IDictionary<string, string> values = (Dictionary<string, string>)param;
            string assistTableName = values.ContainsKey("AssistTable") ? values["AssistTable"] as string : null;
            string assistQuery = values.ContainsKey("AssistQuery") ? values["AssistQuery"] as string : null;
            bool value = await AssistQueryRequestHandler(assistTableName, assistQuery);
        }

        private async Task<bool> AssistQueryRequestHandler(string assistTableName, string assistQuery)
        {
            IEnumerable<BaseDto> value = await AssistMapper.ExecuteAssist(assistTableName, assistQuery);
            /*
             * TODO: Think a way to avoid this .. suppose a view model has 400 searchbox different, doenst make sense.
             */
            if (value != null)
            {
                switch (assistTableName)
                {
                    case "CITY_ASSIST":
                    {
                        CityDto = value ;
                        break;
                    }
                    case "COUNTRY_ASSIST":
                    {
                        CountryDto = value;
                        break;
                    }
                    case "PROVINCE_ASSIST":
                    {
                        ProvinceDto = value;
                        break;
                    }
                    case "COMPANY_ASSIST":
                    {
                        CompanyDto = value;
                        break;
                    }
                    case "OFFICE_ASSIST":
                    {
                        OfficeDto = value;
                        break;
                    }
                }
                return true;
            }
            return false;
        }
        /// <summary>
        ///  This returns the client data.
        /// </summary>
        public IClientData DataObject
        {
            get { return _clientData; }
            set { _clientData = value; RaisePropertyChanged(); }
        }
        /// <summary>
        ///  This register the primary key
        /// </summary>
        /// <param name="payLoad">Payload to be registered</param>
        private void RegisterPrimaryKey(DataPayLoad payLoad)
        {
            Contract.Assert(PrimaryKeyValue!=null, "RegisterPrimaryKey error");
            Contract.Assert(payLoad!=null, "RegisterPrimaryKey error");
            if (PrimaryKeyValue.Length == 0)
            {
                PrimaryKeyValue = payLoad.PrimaryKeyValue;
                string mailboxName = "Clients." + PrimaryKeyValue;
                if (!string.IsNullOrEmpty(PrimaryKeyValue))
                {
                    if (MailBoxHandler != null)
                    {
                        EventManager.RegisterMailBox(mailboxName, MailBoxHandler);
                    }
                }
            }

        }
        /// <summary>
        ///  Handle the payload from the event manager
        /// </summary>
        /// <param name="dataPayLoad"></param>
        public void IncomingPayload(DataPayLoad dataPayLoad)
        {

            DataPayLoad payload = dataPayLoad;

            if (payload != null)
            {
                
                RegisterPrimaryKey(dataPayLoad);
                // here i can fix the primary key
                switch (payload.PayloadType)
                {
                    case DataPayLoad.Type.UpdateData:
                    {
                        if (payload.HasDataObject)
                        {
                            var clientData = payload.DataObject as IClientData;
                            DataObject = clientData;
                        }
                        break;
                    }
                    case DataPayLoad.Type.UpdateView:
                    case DataPayLoad.Type.Show:
                    {
                        Init(PrimaryKeyValue, payload, false);
                        CurrentOperationalState = DataPayLoad.Type.Show;
                        break;
                    }
                    case DataPayLoad.Type.Insert:
                    {
                        CurrentOperationalState = DataPayLoad.Type.Insert;
                        if (string.IsNullOrEmpty(PrimaryKeyValue))
                        {
                            PrimaryKeyValue =
                                DataServices.GetClientDataServices().GetNewId();

                            CurrentOperationalState = DataPayLoad.Type.Insert;
                        }
                        Init(PrimaryKeyValue, payload, true);
                        break;
                    }
                    case DataPayLoad.Type.Delete:
                    {

                        if (PrimaryKey == payload.PrimaryKey)
                        {
                            DeleteEventCleanup(payload.PrimaryKeyValue, PrimaryKeyValue, DataSubSystem.ClientSubsystem,
                                MasterModuleConstants.ClientSubSystemName);
                            DeleteRegion(payload.PrimaryKeyValue);

                        }
                        break;
                    }
                }
            }

        }
        // All helpers values.
        public object ProvinceDto
        {
            set { _province = value; RaisePropertyChanged(); }
            get { return _province; }
        }

        public object OfficeDto
        {
            set { _office = value; RaisePropertyChanged(); }
            get
            {
                return _office;
            }
        }

        public object CountryDto
        {
            set { _country = value; RaisePropertyChanged(); }
            get { return _country; }
           
        }

        public object CityDto
        {
            set { _country = value; RaisePropertyChanged(); }
            get { return _country; }
           
        }

        public object CompanyDto
        {
            set { _company = value; RaisePropertyChanged(); }
            get { return _company; }

        }

        public object ClientZoneDto
        {
            set { _clientZone = value; RaisePropertyChanged(); }
            get { return _clientZone; }
        }

        private object OrigenDto
        {
            set { _origenDto = value; RaisePropertyChanged(); }
            get { return _origenDto; }
        }
        private object BrokerDto { set; get; }
        private object ClientMarketDto { set; get; }
        private object ResellerDto { set; get; }
        private object ClientTypeDto { set; get; }
        public DelegateCommand<object> ItemChangedCommand { get; set; }

        public void Init(string primaryKey, DataPayLoad payload, bool isInsert)
        {
            if (payload.HasDataObject)
            {
                Logger.Info("ClientInfoViewModel has received payload type " + payload.PayloadType.ToString());
                var clientData = payload.DataObject as IClientData;
                DataObject = clientData;
                EventManager.SendMessage(UpperBarClientViewModel.Name, payload);
                Logger.Info("ClientInfoViewModel has activated the client subsystem as current with directive " +
                            payload.PayloadType.ToString());
                ActiveSubSystem();

            }
        }
    }
}
