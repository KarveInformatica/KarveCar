using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using MasterModule.Common;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;
using KarveCommon.Generic;
using System.Windows;
using System.Diagnostics.Contracts;
using KarveDataServices.DataObjects;

namespace MasterModule.ViewModels
{

    public class OfficeInfoViewModel : MasterInfoViewModuleBase, IEventObserver, IDisposeEvents
    {
        #region Constructor 
        public OfficeInfoViewModel(IEventManager eventManager, IConfigurationService configurationService, IDataServices dataServices, IRegionManager manager) : base(eventManager, configurationService, dataServices, manager)
        {
            base.ConfigureAssist();
            AssistCommand = new DelegateCommand<object>(OnAssistCommand);
            ItemChangedCommand = new DelegateCommand<object>(OnChangedField);
            AssistExecuted += OfficeAssistResult;
            EventManager.RegisterObserverSubsystem(MasterModuleConstants.OfficeSubSytemName, this);
            DataObject = new OfficeDtos();
        }

        private void OfficeAssistResult(object sender, PropertyChangedEventArgs e)
        {
            

            
        }
        #endregion
        #region Properties
        /// <summary>
        ///  Data object
        /// </summary>
        public OfficeDtos DataObject
        {
            set
            {
                _currentOfficeDto = value;
                RaisePropertyChanged();
            }
            get
            {
                return _currentOfficeDto;
            }
        }
        /// <summary>
        ///  Helper data.
        /// </summary>
        public IHelperBase CompanyHelper
        {
            set
            {
                _companyHelper = value;
                RaisePropertyChanged();
            }
            get
            {
                return _companyHelper;
            }
        }
        /// <summary>
        ///  Show brokers data objects.
        /// </summary>
        public IEnumerable<CommissionAgentSummaryDto> BrokersDto
        {
            get
            {
                return _brokers;
            }
            set
            {
                _brokers = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Show client data transfer object.
        /// </summary>
        public IEnumerable<ClientSummaryDto> ClientDto
        {
            get
            {
                return _clientDto;
            }
            set
            {
                _clientDto = value;
                RaisePropertyChanged();
            }
        }
        #endregion


        #region Public Methods

        /// <summary>
        ///  Incoming Payload
        /// </summary>
        /// <param name="payload">Data payload</param>
        public void IncomingPayload(DataPayLoad payload)
        {


            if (payload != null)
            {

                RegisterPrimaryKey(payload);
                // here i can fix the primary key
                switch (payload.PayloadType)
                {
                    case DataPayLoad.Type.UpdateData:
                        {
                            if (payload.HasDataObject)
                            {
                                var clientData = payload.DataObject as OfficeDtos;
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
                                PrimaryKeyValue = DataServices.GetCompanyDataServices().GetNewId();

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
                                    MasterModuleConstants.CompanySubSystemName);
                                DeleteRegion(payload.PrimaryKeyValue);

                            }
                            break;
                        }
                }
            }
        }

        public void Init(string primaryKey, DataPayLoad payload, bool isInsert)
        {
            if (payload.HasDataObject)
            {
                Logger.Info("OfficeInfoViewModel has received payload type " + payload.PayloadType.ToString());
                var companyData = payload.DataObject as IOfficeData;
                if (companyData != null)
                {
                    _companyData = companyData;
                    DataObject = _companyData.Value;
                    CompanyHelper = companyData;
                    
                    Logger.Info("CompanyInfoViewModel has activated the client subsystem as current with directive " +
                                payload.PayloadType.ToString());
                    ActiveSubSystem();
                    RaisePropertyChanged("Helper");
                }
            }
        }
        #endregion

        #region Protected Methods
        /// <summary>
        ///  This method set the registration payload.
        /// </summary>
        /// <param name="payLoad"></param>
        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            payLoad.Subsystem = DataSubSystem.CompanySubsystem;
        }
        #endregion

        #region Private Methods

        private void OnAssistCommand(object param)
        {
            IDictionary<string, string> values = (Dictionary<string, string>)param;
            string assistTableName = values.ContainsKey("AssistTable") ? values["AssistTable"] as string : null;
            string assistQuery = values.ContainsKey("AssistQuery") ? values["AssistQuery"] as string : null;
            this.AssistNotifierInitialized = NotifyTaskCompletion.Create<bool>(AssistQueryRequestHandler(assistTableName, assistQuery), AssistExecuted);
        }

        private void CompanyAssistResult(object sender, PropertyChangedEventArgs e)
        {
            string propertyName = e.PropertyName;
            if (propertyName.Equals("Status"))
            {
                if (AssistNotifierInitialized.IsSuccessfullyCompleted)
                {
                    bool value = AssistNotifierInitialized.Task.Result;
                    if (!value)
                    {
                        Logger.Error("Executed Assist invalid");
                    }

                }
            }

        }
        private async Task<bool> AssistQueryRequestHandler(string assistTableName, string assistQuery)
        {
            var value = await AssistMapper.ExecuteAssist(assistTableName, assistQuery);
            bool retValue = false;
            if (value != null)
            {
                switch (assistTableName)
                {
                    case "CITY_ASSIST":
                        {
                            CompanyHelper.CityDto = (IEnumerable<CityDto>)value;
                            retValue = true;
                            break;
                        }
                    case "PROVINCE_ASSIST":
                        {
                            CompanyHelper.ProvinciaDto = (IEnumerable<ProvinciaDto>)value;
                            retValue = true;
                            break;
                        }
                    case "COUNTRY_ASSIST":
                        {
                            CompanyHelper.CountryDto = (IEnumerable<CountryDto>)value;
                            retValue = true;
                            break;
                        }

                    case "BROKER_ASSIST":
                        {
                            BrokersDto = (IEnumerable<CommissionAgentSummaryDto>)value;
                            retValue = true;
                            break;
                        }
                    case "CLIENT_ASSIST":
                        {
                            ClientDto = (IEnumerable<ClientSummaryDto>)value;
                            retValue = true;
                            break;
                        }
                }
                RaisePropertyChanged("OfficeHelper");
            }
            return retValue;
        }

        /// <summary>
        /// Change field.
        /// </summary>
        /// <param name="objectChanged"></param>
        private void OnChangedField(object objectChanged)
        {
            IDictionary<string, object> eventDictionary = (IDictionary<string, object>)objectChanged;
            OnChangedField(eventDictionary);
        }

        private void OnChangedField(IDictionary<string, object> eventDictionary)
        {
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.Subsystem = DataSubSystem.OfficeSubsystem;
            payLoad.SubsystemName = MasterModuleConstants.OfficeSubSytemName;
            payLoad.PayloadType = DataPayLoad.Type.Update;
            if (string.IsNullOrEmpty(payLoad.PrimaryKeyValue))
            {
                payLoad.PrimaryKeyValue = PrimaryKeyValue;

            }
            if (eventDictionary.ContainsKey("DataObject"))
            {
                if (eventDictionary["DataObject"] == null)
                {
                    MessageBox.Show("DataObject is null.");
                }
                var data = eventDictionary["DataObject"];
                var name = eventDictionary["Field"] as string;
                GenericObjectHelper.PropertySetValue(data, name, eventDictionary["ChangedValue"]);
                payLoad.DataObject = data;
            }
            // remove ViewModelQueries.
            ChangeFieldHandlerDo<OfficeDtos> handlerDo = new ChangeFieldHandlerDo<OfficeDtos>(EventManager, DataSubSystem.CompanySubsystem);

            if (CurrentOperationalState == DataPayLoad.Type.Insert)
            {
                handlerDo.OnInsert(payLoad, eventDictionary);
            }
            else
            {
                payLoad.PayloadType = DataPayLoad.Type.Update;
                handlerDo.OnUpdate(payLoad, eventDictionary);
            }
        }

 
        // <summary>
        ///  This register the primary key
        /// </summary>
        /// <param name="payLoad">Payload to be registered</param>
        private void RegisterPrimaryKey(DataPayLoad payLoad)
        {
            Contract.Assert(PrimaryKeyValue != null, "RegisterPrimaryKey error");
            Contract.Assert(payLoad != null, "RegisterPrimaryKey error");
            if (PrimaryKeyValue.Length == 0)
            {
                PrimaryKeyValue = payLoad.PrimaryKeyValue;
                _mailBoxName = "Office." + PrimaryKeyValue + "." + UniqueId;
                if (!string.IsNullOrEmpty(PrimaryKeyValue))
                {
                    if (MailBoxHandler != null)
                    {
                        EventManager.RegisterMailBox(_mailBoxName, MailBoxHandler);
                    }
                }
            }

        }
        public override void DisposeEvents()
        {
            EventManager.DeleteMailBoxSubscription(_mailBoxName);
            EventManager.DeleteObserverSubSystem(MasterModuleConstants.CompanySubSystemName, this);
        }
        #endregion

        #region Private Fields
        private IOfficeData _companyData;
        private string _mailBoxName;
        private IHelperBase _companyHelper;
        private IEnumerable<CommissionAgentSummaryDto> _brokers;
        private IEnumerable<ClientSummaryDto> _clientDto;
        private OfficeDtos _currentOfficeDto;
        #endregion


    }

}
