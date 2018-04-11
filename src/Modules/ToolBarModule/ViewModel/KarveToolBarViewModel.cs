using System;
using KarveCommon.Services;
using KarveDataServices;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using ToolBarModule.Command;
using System.Windows.Input;
using KarveCommon.Command;
using KarveCommon.Generic;
using Prism.Interactivity.InteractionRequest;
using Prism.Regions;
using System.Linq;

namespace ToolBarModule
{
    /// <summary>
    /// View model that is able to manage the tool bar.
    /// </summary>
    public class KarveToolBarViewModel : BindableBase, IToolBarViewModel, IEventObserver
    {
        public enum ToolbarStates
        {
            Insert,
            Delete,
            Update,
            None
        };

        private Dictionary<DataSubSystem, string> _dictionary = new Dictionary<DataSubSystem, string>()
        {
            { DataSubSystem.CommissionAgentSubystem, EventSubsystem.CommissionAgentSummaryVm},
            { DataSubSystem.CompanySubsystem, EventSubsystem.CompanySummaryVm},
            { DataSubSystem.ClientSubsystem, EventSubsystem.ClientSummaryVm},
            { DataSubSystem.OfficeSubsystem, EventSubsystem.OfficeSummaryVm},
            { DataSubSystem.HelperSubsytsem, EventSubsystem.HelperSubsystem},
            { DataSubSystem.SupplierSubsystem, EventSubsystem.SuppliersSummaryVm},
            { DataSubSystem.VehicleSubsystem, EventSubsystem.VehichleSummaryVm }
          };
        private ToolbarStates _states;
        private ICareKeeperService _careKeeper;
        private IDataServices _dataServices;
        private bool _buttonEnabled = false;
        private bool _isNewEnabled = true;
        private IConfigurationService _configurationService;
        private Stack<DataPayLoad> _dataPayLoadLifo = new Stack<DataPayLoad>();
        private IEventManager _eventManager;
        private const string currentSaveImage = @"/KarveCar;component/Images/save_toolbar.png";
        private const string currentSaveImageModified = @"/KarveCar;component/Images/modified.png";
        private const string ObserverName = "KarveToolBarViewModel.";
        private string _currentSaveImage = null;
        private bool _buttonSaveEnabled = true;
        private ISqlValidationRule<DataPayLoad> _validationRules;
        private IDictionary<string, DataSubSystem> _subSystems = new Dictionary<string, DataSubSystem>();
        private DataSubSystem _activeSubSystem = DataSubSystem.None;
        private string confirmDelete = "Quieres borrar el registro?";
        private string confirmSave = "Quieres guardar el registro?";
        private string currentViewObjectId = string.Empty;
        private Stack<Uri> viewStack = new Stack<Uri>();

        private string _uniqueId;
        // this is useful for adding or removing item to the toolbar.
        public InteractionRequest<IConfirmation> ConfirmationRequest { get; set; }
        public ICommand ConfirmationCommand { get; set; }

        public ICommand SaveValueCommand { get; set; }
        private IRegionManager _regionManager;
        private bool _isDeleteEnabled;
        private string noActiveValue;


        /// <summary>
        /// KarveToolBarViewModel is a view model to modle the toolbar behaviour.
        /// </summary>
        /// <param name="dataServices"></param>
        /// <param name="eventManager"></param>
        /// <param name="careKeeper"></param>
        /// <param name="regionManager"></param>
        /// <param name="configurationService"></param>
        public KarveToolBarViewModel(IDataServices dataServices,
                                 IEventManager eventManager,
                                 ICareKeeperService careKeeper,
                                 IRegionManager regionManager,
                                 IConfigurationService configurationService)
        {
            this._dataServices = dataServices;
            this._configurationService = configurationService;
            this._eventManager = eventManager;
            this._eventManager.RegisterObserverToolBar(this);
            this._careKeeper = careKeeper;
            this.SaveCommand = new DelegateCommand(DoSaveCommand);
            this.NewCommand = new DelegateCommand(DoNewCommand);
            this.DeleteCommand = new DelegateCommand(DoDeleteCommand);
            this._dataServices = dataServices;
            this._configurationService = configurationService;
            this._eventManager = eventManager;
            this._eventManager.RegisterObserverToolBar(this);
            this.CurrentSaveImagePath = currentSaveImage;
            _regionManager = regionManager;
            _states = ToolbarStates.None;
            noActiveValue = string.Empty;
            this.IsSaveEnabled = false;
            this.IsDeleteEnabled = false;
            this.IsNewEnabled = false;
            ConfirmationRequest = new InteractionRequest<IConfirmation>();
            Confirmation request = new Confirmation
            {
                Title = "Confirmacion",
                Content = confirmDelete
            };
            
            ConfirmationCommand = new DelegateCommand(() =>
            {
                // string noActiveValue = configurationService.GetPrimaryKeyValue();
                request.Content = confirmDelete;
                ConfirmationRequest.Raise(request);
                if (request.Confirmed)
                {
                    DeleteCommand.Execute();
                }

            });
            SaveValueCommand = new DelegateCommand(() =>
            {
                request.Content = confirmSave;

                ConfirmationRequest.Raise(request);
                if (request.Confirmed)
                {
                    SaveCommand.Execute();
         
                }
                else
                {
                    this.CurrentSaveImagePath = KarveToolBarViewModel.currentSaveImage;
                }
            });

            SetInsertValidationChain();
            _uniqueId = ObserverName + Guid.NewGuid();
        }

        private void DoDeleteCommand()
        {

            var value = "";
            var singleView = _regionManager.Regions[RegionNames.TabRegion].ActiveViews.FirstOrDefault();
            var headerProp = singleView.GetType().GetProperty("Header");
            var header = headerProp.GetValue(singleView) as string;
            if (header != null)
            {
                value = header.Split('.')[0];
            }
            _states = ToolbarStates.Delete;
            DataPayLoad payLoad = new DataPayLoad
            {
                PayloadType = DataPayLoad.Type.Delete,
                PrimaryKeyValue = value,
                Subsystem = _activeSubSystem
            };
            payLoad.PrimaryKey = value;
            payLoad.PrimaryKeyValue = value;

            if (!string.IsNullOrEmpty(currentViewObjectId))
            {
                payLoad.ObjectPath = viewStack.Peek();
                _eventManager.SendMessage(currentViewObjectId, payLoad);
            }

            DeliverIncomingNotify(_activeSubSystem, payLoad);

        }

        private void SetInsertValidationChain()
        {
            // SqlValidationRule crossDomain = new CrossReferenceValidationRule();
            _validationRules = new RemoveDuplicateSqlValidationRule();
            // _validationRules.SetSuccessor(crossDomain);
        }

        private void DoNewCommand()
        {
            DataPayLoad payLoad = new DataPayLoad
            {
                PayloadType = DataPayLoad.Type.Insert
            };
            _states = ToolbarStates.Insert;
            if (!string.IsNullOrEmpty(currentViewObjectId))
            {
                payLoad.ObjectPath = viewStack.Peek();
                _eventManager.SendMessage(currentViewObjectId, payLoad);
            }
            else
            {

                // this send a message to the current control view model.
                DeliverIncomingNotify(_activeSubSystem, payLoad);
            }

        }
        /// <summary>
        /// Return true when is a new enabled.
        /// </summary>
        public bool IsNewEnabled
        {
            get { return _isNewEnabled; }
            set { _isNewEnabled = value; RaisePropertyChanged("IsNewEnabled"); }
        }

        /// <summary>
        /// Return true when is a delete enabled.
        /// </summary>
        public bool IsDeleteEnabled
        {
            get { return _isDeleteEnabled; }
            set { _isDeleteEnabled = value; RaisePropertyChanged("IsDeleteEnabled"); }
        }
        /// <summary>
        /// Return true when save is enabled
        /// </summary>
        public bool IsSaveEnabled
        {
            get { return _buttonSaveEnabled; }
            set
            {
                _buttonSaveEnabled = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Return true when a new is enabeled.
        /// </summary>
        public bool ButtonEnabled
        {
            get { return _buttonEnabled; }
            set
            {
                _buttonEnabled = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Return curren 
        /// </summary>
        public string CurrentSaveImagePath
        {
            get
            {
                return _currentSaveImage;
            }
            set
            {
                _currentSaveImage = value;
                RaisePropertyChanged("CurrentSaveImagePath");
            }

        }

        private void ExecuteCommand(DataPayLoad payLoad)
        {
            if (payLoad != null)
            {
                if ((payLoad.PayloadType == DataPayLoad.Type.Insert) || (_states == ToolbarStates.Insert))
                {
                    InsertDataCommand dataCommand = new InsertDataCommand(this._dataServices,
                        this._careKeeper,
                        this._eventManager,
                        this._configurationService)
                    {
                        ValidationRules = this._validationRules
                    };
                    _careKeeper.Do(new CommandWrapper(dataCommand));
                    _states = ToolbarStates.None;
                }
                else
                {

                    SaveDataCommand dataCommand = new SaveDataCommand(this._dataServices, this._careKeeper,
                         this._eventManager, this._configurationService);
                    _careKeeper.Do(new CommandWrapper(dataCommand));

                }
                // in case of the helper subsystem it is the same view model to handle the stuff,
                if (payLoad.Subsystem != DataSubSystem.HelperSubsytsem)
                {
                    payLoad.PayloadType = DataPayLoad.Type.UpdateView;
                }

                if (payLoad.ObjectPath != null)
                {
                    // we deliver the answer to theobject itself.
                    _eventManager.SendMessage(payLoad.ObjectPath.ToString(), payLoad);
                }
                else
                {
                    // we deliver directly to the controller of the subsystem
                    DeliverIncomingNotify(payLoad.Subsystem, payLoad);
                }
            }
        }
        private void DoSaveCommand()
        {
            if (this.IsSaveEnabled)
            {
                this.CurrentSaveImagePath = KarveToolBarViewModel.currentSaveImage;
                // this.IsSaveEnabled = false;
                Queue<DataPayLoad> payLoad = _careKeeper.GetScheduledPayload();
                if (payLoad != null)
                {
                    while (payLoad.Count > 0)
                    {
                        DataPayLoad currentItem = payLoad.Peek();
                        ExecuteCommand(currentItem);
                    }
                }
                this.CurrentSaveImagePath = KarveToolBarViewModel.currentSaveImage;
                this.IsSaveEnabled = false;
            }

        }


        /// FIXME: dont repeat yourself see toolbar datapayload.
        /// <summary>
        /// Delvier incoming notify.
        /// TODO: try to unify data subsystem and event subsystem.
        /// </summary>
        /// <param name="subSystem">Current subsystem</param>
        /// <param name="payLoad">Current datapayload</param>
        private void DeliverIncomingNotify(DataSubSystem subSystem, DataPayLoad payLoad)
        {


            payLoad.Subsystem = subSystem;
            string destinationSubsystem = "";
            _dictionary.TryGetValue(payLoad.Subsystem, out destinationSubsystem);
            if (!string.IsNullOrEmpty(destinationSubsystem))
            {
                _eventManager.SendMessage(destinationSubsystem, payLoad);
            }
        }

        /// <summary>
        /// Return the subscription uniqueId.
        /// </summary>
        public string UniqueId
        {

            get { return _uniqueId; }
            set { _uniqueId = value; }
        }

        /// <summary>
        ///  Each different subsytem call this method to notify a change in the system to the toolbar.
        /// </summary>
        /// <param name="payload"></param>
        public void IncomingPayload(DataPayLoad payload)
        {

            IsNewEnabled = true;
            CurrentPayLoad = payload;
            switch (payload.PayloadType)
            {
                // a subsystem has opened a new window with data.
                case DataPayLoad.Type.RegistrationPayload:
                    {
                        _activeSubSystem = payload.Subsystem;
                        var objectPath = payload.ObjectPath;
                        if (objectPath != null)
                        {
                            currentViewObjectId = objectPath.ToString();
                            if (!viewStack.Contains(objectPath))
                            {
                                viewStack.Push(objectPath);
                            }
                        }
                        IsNewEnabled = true;
                        IsDeleteEnabled = true;
                        break;
                    }
                case DataPayLoad.Type.UnregisterPayload:
                    {
                        var objectPath = payload.ObjectPath;
                        if (objectPath != null)
                        {
                            viewStack.Pop();
                            currentViewObjectId = viewStack.Peek().ToString();
                        }
                        break;
                    }
                case DataPayLoad.Type.Delete:
                    {
                        string primaryKeyValue = payload.PrimaryKeyValue;
                        _activeSubSystem = payload.Subsystem;
                        _states = ToolbarStates.None;
                        DataPayLoad payLoad = new DataPayLoad
                        {
                            PayloadType = DataPayLoad.Type.UpdateView
                        };
                        DeliverIncomingNotify(_activeSubSystem, payLoad);
                        break;
                    }
                case DataPayLoad.Type.UpdateView:
                    {
                        break;
                    }
                case DataPayLoad.Type.UpdateInsertGrid:
                    {
                        this.CurrentSaveImagePath = currentSaveImageModified;
                        this.IsSaveEnabled = true;
                        _careKeeper.Schedule(payload);
                        break;
                    }
                case DataPayLoad.Type.DeleteGrid:
                    {
                        this.CurrentSaveImagePath = currentSaveImageModified;
                        this.IsSaveEnabled = true;
                        // in this case we if the previous payload was good
                        _careKeeper.Schedule(payload);
                        break;

                    }
                // a subsystem has updated a new window with data.
                case DataPayLoad.Type.Insert:
                case DataPayLoad.Type.Update:
                    {

                        this.CurrentSaveImagePath = currentSaveImageModified;
                        this.IsSaveEnabled = true;
                        // this keeps the value for saving.
                        _careKeeper.Schedule(payload);

                        break;
                    }
            }
        }
        /// <summary>
        /// Save command current tab.
        /// </summary>
        public DelegateCommand SaveCommand { set; get; }
        /// <summary>
        ///  New command tab
        /// </summary>
        public DelegateCommand NewCommand { set; get; }

        /// <summary>
        ///  Delete command view module.
        /// </summary>
        public DelegateCommand DeleteCommand { set; get; }
        /// <summary>
        ///  Returns the currenct active payload in the toolbar if any
        /// </summary>
        public DataPayLoad CurrentPayLoad { get; set; }
    }

}
