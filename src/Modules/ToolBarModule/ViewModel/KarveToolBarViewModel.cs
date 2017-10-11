using KarveCommon.Services;
using KarveDataServices;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using ToolBarModule.Command;
using System;
using System.Windows.Media.Imaging;
using System.Net.Cache;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using KarveCommon.Command;
using KarveCommon.Generic;
using MessageBox = System.Windows.MessageBox;

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
        private string _currentSaveImage = null;
        private bool _buttonSaveEnabled = true;
        private SqlValidationRule _validationRules;
        private IDictionary<string, DataSubSystem> _subSystems = new Dictionary<string, DataSubSystem>();
        private DataSubSystem _activeSubSystem = DataSubSystem.None;

        public KarveToolBarViewModel(IDataServices dataServices,
                                 IEventManager eventManager,
                                 ICareKeeperService careKeeper,
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
            _states = ToolbarStates.None;
            SetInsertValidationChain();
        }

        private void DoDeleteCommand()
        {
            string value = _configurationService.GetPrimaryKeyValue();
            if (value.Length > 0)
            {
                if (_activeSubSystem == DataSubSystem.SupplierSubsystem)
                {
                    // i have to delete the ficha.
                    _states = ToolbarStates.Delete;
                    DataPayLoad payLoad = new DataPayLoad();
                    payLoad.PayloadType = DataPayLoad.Type.Delete;
                    payLoad.PrimaryKeyValue = value;
                    _eventManager.SendMessage("ProvidersControlViewModel", payLoad);
                }
            }
        }

        private void SetInsertValidationChain()
        {
            SqlValidationRule crossDomain = new CrossReferenceValidationRule();
            _validationRules = new RemoveDuplicateSqlValidationRule();
            _validationRules.SetSuccessor(crossDomain);
        }
        private void DoNewCommand()
        {
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.PayloadType = DataPayLoad.Type.Insert;
            _states = ToolbarStates.Insert;
            if (_activeSubSystem == DataSubSystem.SupplierSubsystem)
            {
                _eventManager.SendMessage("ProvidersControlViewModel", payLoad);
            }
        }
        public bool IsNewEnabled
        {
            get { return _isNewEnabled; }
            set { _isNewEnabled = value; RaisePropertyChanged("IsNewEnabled"); }
        }
        public bool IsSaveEnabled
        {
            get { return _buttonSaveEnabled; }
            set
            {
                _buttonSaveEnabled = value;
                RaisePropertyChanged();
            }
        }
        public bool ButtonEnabled
        {
            get { return _buttonEnabled; }
            set
            {
                _buttonEnabled = value;
                RaisePropertyChanged();
            }
        }
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

        private void DoSaveCommand()
        {
            if (this.IsSaveEnabled)
            {
                this.CurrentSaveImagePath = KarveToolBarViewModel.currentSaveImage;
                this.IsSaveEnabled = false;
                if (_states == ToolbarStates.Insert)
                {
                    InsertDataCommand dataCommand = new InsertDataCommand(this._dataServices,
                        this._careKeeper,
                        this._eventManager,
                        this._configurationService);
                    dataCommand.ValidationRules = this._validationRules;
                    _careKeeper.Do(new CommandWrapper(dataCommand));
                    _states = ToolbarStates.None;
                }
                else
                {
                    SaveDataCommand dataCommand = new SaveDataCommand(this._dataServices, this._careKeeper,
                        this._eventManager, this._configurationService);
                    _careKeeper.Do(new CommandWrapper(dataCommand));
                }
            }
        }
        /// <summary>
        ///  Each different subsytem call this method to notify a change in the system to the toolbar.
        /// </summary>
        /// <param name="payload"></param>
        public void incomingPayload(DataPayLoad payload)
        {
            IsNewEnabled = true;
            switch (payload.PayloadType)
            {
                // a subsystem has opened a new window with data.
                case DataPayLoad.Type.RegistrationPayload:
                {
                    _activeSubSystem = payload.Subsystem;
                    IsNewEnabled = true;
                    break;
                }
                case DataPayLoad.Type.Delete:
                {
                    string primaryKeyValue = payload.PrimaryKeyValue;
                    _configurationService.CloseTab(primaryKeyValue);
                    _states = ToolbarStates.None;
                    DataPayLoad payLoad = new DataPayLoad(); 
                    payLoad.PayloadType = DataPayLoad.Type.UpdateView;
                    if (_activeSubSystem == DataSubSystem.SupplierSubsystem)
                    {
                        _eventManager.SendMessage("ProvidersControlViewModel", payLoad);
                    }
                    break;
                }
                case DataPayLoad.Type.UpdateView:
                {
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

        public DelegateCommand EnableSaveCommand { set; get; }
        public DelegateCommand DisableSaveCommand { set; get; }
        public DelegateCommand DisableDeleteCommand { set; get; }
        public DelegateCommand EnableDeleteCommand { set; get; }
        public DelegateCommand UndoCommand { get; set; }
        public DelegateCommand RedoCommand { get; set; }
        public DelegateCommand SaveCommand { set; get; }
        public DelegateCommand EditCommand { set; get; }
        public DelegateCommand ExitCommand { set; get; }
        public DelegateCommand NewCommand { set; get; }
        public DelegateCommand DeleteCommand { set; get; }
        public DelegateCommand CancelCommand { set; get; }
        public DelegateCommand PrintCommand { set; get; }
        public DelegateCommand SearchCommand { set; get; }


    }

}
