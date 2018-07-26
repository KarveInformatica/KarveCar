using System;
using KarveCommon.Services;
using KarveDataServices;
using Prism.Commands;
using System.Collections.Generic;
using ToolBarModule.Command;
using System.Windows.Input;
using KarveCommon.Command;
using KarveCommon.Generic;
using Prism.Interactivity.InteractionRequest;
using Prism.Regions;
using System.Linq;
using KarveCommonInterfaces;
using ToolBarModule.ViewModel;
using System.Windows.Controls;
using KarveDataServices.DataTransferObject;

namespace ToolBarModule
{
    /// <summary>
    /// View model that is able to manage the tool bar.
    /// </summary>
    public class KarveToolBarViewModel : KarveViewModelBase, IToolBarViewModel, IEventObserver
    {
        public enum ToolbarStates
        {
            Insert,
            Delete,
            Update,
            None
        };

        private readonly Dictionary<DataSubSystem, string> _dictionary;

        private ToolbarStates _states;
        private readonly ICareKeeperService _careKeeper;
        private readonly IDataServices _dataServices;
        private readonly IConfigurationService _configurationService;
        private readonly IEventManager _eventManager;

        private bool _buttonEnabled = false;
        private bool _isNewEnabled = true;
        private Stack<DataPayLoad> _dataPayLoadLifo = new Stack<DataPayLoad>();
        private const string currentSaveImage = @"/KarveCar;component/Images/save_toolbar.png";
        private const string currentSaveImageModified = @"/KarveCar;component/Images/modified.png";
        private const string ObserverName = "KarveToolBarViewModel.";
        private string _currentSaveImage = null;
        private bool _buttonSaveEnabled = true;
        private ISqlValidationRule<DataPayLoad> _validationRules;
        private IDictionary<string, DataSubSystem> _subSystems = new Dictionary<string, DataSubSystem>();
        private DataSubSystem _activeSubSystem = DataSubSystem.None;
        private readonly string confirmDelete = "Quieres Borrar El Registro?";
        private string confirmSave = "Quieres Salvar El Registro?";
        private string currentViewObjectId = string.Empty;
        private Stack<Uri> viewStack = new Stack<Uri>();
        private CompositeCommand _compositeSaveCommand = new CompositeCommand();
        private CompositeCommand _compositeDeleteCommand = new CompositeCommand();
        private CompositeCommand _compositeNewCommand = new CompositeCommand();


        private string _uniqueId;
        // this is useful for adding or removing item to the toolbar.
        public InteractionRequest<IConfirmation> ConfirmationRequest { get; set; }
        public ICommand ConfirmationCommand { get; set; }

        public ICommand SaveValueCommand { get; set; }
        private IRegionManager _regionManager;
        private bool _isDeleteEnabled;
        private string _noActiveValue;
        private IDialogService _dialogService;


        /// <summary>
        /// KarveToolBarViewModel is a view model to modle the toolbar behaviour.
        /// </summary>
        /// <param name="dataServices">Service for fetching datas</param>
        /// <param name="eventManager">Service for communicate with other view models</param>
        /// <param name="careKeeper">Service for caring command and storing/undoing command</param>
        /// <param name="regionManager">Service for region handling</param>
        /// <param name="dialogService">Service for spotting the dialog</param>
        /// <param name="configurationService">Service for the configuraration parameters</param>
        public KarveToolBarViewModel(IDataServices dataServices,
                                 IEventManager eventManager,
                                 ICareKeeperService careKeeper,
                                 IRegionManager regionManager,
                                 IDialogService dialogService,
                                 IConfigurationService configurationService) : base(dataServices, null, dialogService)
        {
            this._dictionary = SubsystemFactory.GetSubsytem();
            this._dataServices = dataServices;
            this._dialogService = dialogService;
            this._configurationService = configurationService;
            this._eventManager = eventManager;
            this._eventManager.RegisterObserverToolBar(this);
            this._careKeeper = careKeeper;
            this.SaveCommand = new DelegateCommand(DoSaveCommand);
            this.NewCommand = new DelegateCommand(DoNewCommand);
            this.DeleteCommand = new DelegateCommand<object>(DoDeleteCommand);
            this._dataServices = dataServices;
            this._configurationService = configurationService;
            this._eventManager = eventManager;
            this._eventManager.RegisterObserverToolBar(this);
            this.CurrentSaveImagePath = currentSaveImage;
            _regionManager = regionManager;
            _states = ToolbarStates.None;
            _noActiveValue = string.Empty;
            this.IsSaveEnabled = false;
            this.IsDeleteEnabled = false;
            this.IsNewEnabled = false;
            ConfirmationRequest = new InteractionRequest<IConfirmation>();
            Confirmation request = new Confirmation
            {
                Title = "Confirmacion",
                Content = confirmDelete
            };
            ViewModelUri = new Uri("karve://toolbar/viewmodel?id=" + UniqueId);
            ConfirmationCommand = new DelegateCommand(() =>
            {
                // string noActiveValue = configurationService.GetPrimaryKeyValue();
                request.Content = confirmDelete;
                ConfirmationRequest.Raise(request);
                if (request.Confirmed)
                {
                    string value = string.Empty;
                    var singleView = _regionManager.Regions[RegionNames.TabRegion].ActiveViews.FirstOrDefault();
                    if (singleView != null)
                    {
                        var headerProp = singleView.GetType().GetProperty("Header");
                        if (headerProp != null)
                        {
                            if (headerProp.GetValue(singleView) is string header)
                            {
                                value = header.Split('.')[0];
                            }
                        }
                    }

                    DeleteCommand.Execute(value);
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

            AddValidationChain();
            _uniqueId = ObserverName + Guid.NewGuid();
        }

        private bool IsCommandBaseOnly(ref Uri viewModelUri)
        {
            var activeView = _regionManager.Regions[RegionNames.TabRegion].ActiveViews.FirstOrDefault();
            if (activeView is UserControl control)
            {
                if (control.DataContext is KarveViewModelBase baseViewModel)
                {
                    viewModelUri = baseViewModel.ViewModelUri;
                    return baseViewModel.CompositeCommandOnly;
                }

            }
            return false;
        }

        private void DoDeleteCommand(object key)
        {
            var value = key as string;

            _states = ToolbarStates.Delete;
            DataPayLoad payLoad = new DataPayLoad
            {
                PayloadType = DataPayLoad.Type.Delete,
                PrimaryKeyValue = value,
                Subsystem = _activeSubSystem,
                PrimaryKey = value,
                Sender = ViewModelUri.ToString()
            };
            payLoad.PrimaryKeyValue = value;

            // 1. first of all we try to see if the active tab is a deleter view.

            var activeView = _regionManager.Regions[RegionNames.TabRegion].ActiveViews.FirstOrDefault();
            if (activeView is UserControl control)
            {
                if (control.DataContext is KarveViewModelBase baseViewModel)
                {
                    // The current view model has declarated that he is able to destroy himself.
                    // Looking forward for Hiroshima.

                    var isDeleter = baseViewModel.IsDeleter;
                    if (isDeleter)
                    {
                        baseViewModel.DeleteView(value);
                        // he destroy himself and communicate the stuff.
                        // no more work is needed.
                        return;
                    }


                }
            }
            /* 
             * let's see if i am command base and i can still suicide me:
             * 1. If it is me.
             * 2. If my primary key is ok.
             */
            Uri uri = null;
            if (IsCommandBaseOnly(ref uri))
            {
                DoDeleteHimSelf(value, uri);
                return;
            }
            /* I am not lucky. Nobody destroys himself.
            *  On the top of the tsack it should be the last ctrated let's try to send a delete message to him.
            *  He will help to murder the right tab if he will be have a mailbox to receive my destruction message.
            *  
            */
            if (!string.IsNullOrEmpty(currentViewObjectId))
            {
                payLoad.ObjectPath = viewStack.Peek();

                _eventManager.SendMessage(currentViewObjectId, payLoad);
            }
            // I dont trust anyone like Al Pacino in carlitos way..let's send the bomb to the active subsystem.
            // The baby to kill is the active window for sure we have a controller or himself.
            DeliverIncomingNotify(_activeSubSystem, payLoad);

        }

        private bool DoDeleteHimSelf(string value, Uri uri)
        {
            Tuple<string, Uri> deleteInfo = new Tuple<string, Uri>( value, uri );
            if (_compositeDeleteCommand.RegisteredCommands.Count() > 0)
            {
                if (_compositeDeleteCommand.CanExecute(deleteInfo))
                {
                    _compositeDeleteCommand.Execute(deleteInfo);
                    return true;
                }
            }
            return false;
        }

        private void AddValidationChain()
        {
            var chainBuilder = new ValidationChainBuilder<DataPayLoad>();
            chainBuilder.AddItem(new VehicleValidationRule());
            chainBuilder.AddItem(new SuppliersValidationRule());
            chainBuilder.AddItem(new OfficeDtoValidation());
            chainBuilder.AddItem(new RelatedDtoValidation());
            _validationRules = chainBuilder.First;

        }

        private void DoNewCommand()
        {
            var payLoad = new DataPayLoad
            {
                PayloadType = DataPayLoad.Type.Insert,
                Sender = ViewModelUri.ToString()
            };

            var activeView = _regionManager.Regions[RegionNames.TabRegion].ActiveViews.FirstOrDefault();

            string directSubsystem = string.Empty;
            if (activeView != null)
            {
                if (activeView is UserControl control)
                {
                    if (control.DataContext is KarveViewModelBase baseViewModel)
                    {
                        var subsystem = baseViewModel.SubSystem;

                        if (subsystem != DataSubSystem.None)
                        {
                            _activeSubSystem = subsystem;
                        }
                    }

                }
            }
            // one user that uses the command registration shall not use any new notification. 
            Uri uri = null;
            if (IsCommandBaseOnly(ref uri))
            {
                DoNewAll(uri);
            }
            else
            {
                DeliverIncomingNotify(_activeSubSystem, payLoad);
            }
            _states = ToolbarStates.Insert;

        }
        /// <summary>
        /// Return true when is a new enabled.
        /// </summary>
        public bool IsNewEnabled
        {
            get => _isNewEnabled;
            set { _isNewEnabled = value; RaisePropertyChanged("IsNewEnabled"); }
        }

        /// <summary>
        /// Return true when is a delete enabled.
        /// </summary>
        public bool IsDeleteEnabled
        {
            get => _isDeleteEnabled;
            set { _isDeleteEnabled = value; RaisePropertyChanged("IsDeleteEnabled"); }
        }
        /// <summary>
        /// Return true when save is enabled
        /// </summary>
        public bool IsSaveEnabled
        {
            get => _buttonSaveEnabled;
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
            get => _buttonEnabled;
            set
            {
                _buttonEnabled = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Return the current saved image.
        /// </summary>
        public string CurrentSaveImagePath
        {
            get => _currentSaveImage;
            set
            {
                _currentSaveImage = value;
                RaisePropertyChanged("CurrentSaveImagePath");
            }

        }

        private bool CheckValidation(AbstractCommand command, DataPayLoad payLoad)
        {

            var dto = payLoad.DataObject;
            BaseDto payloadDto;
            // it might be happen to have two cases. 
            // The data transfer object is the Value parameter or not.
            if (payLoad.DataObject is BaseDto baseDto)
            {
                payloadDto = baseDto;

            }
            else
            {
                payloadDto = KarveCommon.ComponentUtils.GetPropValue(dto, "Value") as BaseDto;

            }
            if (!command.CanExecute(payloadDto))
            {
               
                var error = payloadDto.GetErrors(string.Empty) as  List<string>;
                if (error != null)
                {
                    var errorName = error.FirstOrDefault();
                    DialogService?.ShowErrorMessage(errorName);
                }
                return false;
            }
            _careKeeper.Do(new CommandWrapper(command));
            _states = ToolbarStates.None;
            return true;

        }
        private bool ExecuteCommand(DataPayLoad payLoad)
        {
            if (payLoad == null)
            {
                return false;
            }

            var insertDataCommand = new InsertDataCommand(this._dataServices,
                this._eventManager)
            {
                ValidationRules = this._validationRules
            };
            var saveCommand = new SaveDataCommand(this._dataServices, this._careKeeper,
                this._eventManager, this._configurationService)
            {
                ValidationRules = this._validationRules
            };


            if ((payLoad.PayloadType == DataPayLoad.Type.Insert) || (_states == ToolbarStates.Insert))
            {
                var validated = CheckValidation(insertDataCommand, payLoad);
                if (!validated)
                {
                    this.CurrentSaveImagePath = currentSaveImageModified;
                    _careKeeper.DeleteItems(payLoad.ObjectPath);
                    return false;

                }
            }
            else
            {
                _careKeeper.Do(new CommandWrapper(saveCommand));

            }
            // in case of the helper subsystem it is the same view model to handle the stuff,
            if (payLoad.Subsystem != DataSubSystem.HelperSubsytsem)
            {
                payLoad.PayloadType = DataPayLoad.Type.UpdateView;
            }
            payLoad.Sender = ViewModelUri.ToString();
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
            return true;
        }
        /// <summary>
        ///  i create if it is my me
        /// </summary>
        /// <param name="uri">Active view uri</param>
        private void DoNewAll(Uri uri)
        {
            if (_compositeNewCommand.RegisteredCommands.Count() > 0)
            {
                if (_compositeNewCommand.CanExecute(null))
                {
                    _compositeNewCommand.Execute(uri);
                }
            }
        }
        private bool DoSaveHimself(DataPayLoad payload = null)
        {
            // ok then 
            if (_compositeSaveCommand.RegisteredCommands.Count() > 0)
            {
                if (_compositeSaveCommand.CanExecute(payload))
                {
                    _compositeSaveCommand.Execute(payload);
                }
                return true;
            }
            return false;
        }
        private bool SaveAll(Func<DataPayLoad, bool> saveFunc)
        {
            var payLoad = _careKeeper.GetScheduledPayload();
            var retValue = true;
            if (payLoad != null)
            {
                while (payLoad.Count > 0)
                {
                    var currentItem = payLoad.Peek();
                    retValue &= saveFunc(currentItem);
                }
            }
            return retValue;
        }
     
        private void DoSaveCommand()
        {
            bool retValue = false;

            if (!this.IsSaveEnabled)
            {
                return;
            }
            Uri uri = null;
            if (IsCommandBaseOnly(ref uri))
            {
                //i know which is my state.
                retValue = DoSaveHimself();
            }
            else
            {
                retValue = SaveAll(ExecuteCommand);
            }
            if (retValue)
            {
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
            payLoad.Sender = ViewModelUri.ToString();
            _dictionary.TryGetValue(payLoad.Subsystem, out var destinationSubsystem);
            if (!string.IsNullOrEmpty(destinationSubsystem))
            {
                _eventManager.SendMessage(destinationSubsystem, payLoad);
            }
        }
        private void DeliverDirect(DataSubSystem subSystem, string direct, DataPayLoad payLoad)
        {
            payLoad.Subsystem = subSystem;
            payLoad.Sender = ViewModelUri.ToString();
            if (!string.IsNullOrEmpty(direct))
            {
                _eventManager.SendMessage(direct, payLoad);
            }
        }


        /// <summary>
        ///  Each different subsytem call this method to notify a change in the system to the toolbar.
        /// </summary>
        /// <param name="payload"></param>
        public void IncomingPayload(DataPayLoad payload)
        {

            IsNewEnabled = true;
            CurrentPayLoad = payload;
            _activeSubSystem = payload.Subsystem;
            switch (payload.PayloadType)
            {
                // a subsystem has opened a new window with data.
                case DataPayLoad.Type.RegistrationPayload:
                    {

                        var objectPath = payload.ObjectPath;
                        if (objectPath != null)
                        {
                            currentViewObjectId = objectPath.ToString();
                            if (!viewStack.Contains(objectPath))
                            {
                                viewStack.Push(objectPath);
                            }

                            if (payload.HasDeleteCommand)
                            {
                                if (!_compositeDeleteCommand.RegisteredCommands.Contains(payload.DeleteCommand))
                                {
                                    _compositeDeleteCommand.RegisterCommand(payload.DeleteCommand);
                                }
                            }
                            if (payload.HasSaveCommand)
                            {
                                if (!_compositeSaveCommand.RegisteredCommands.Contains(payload.SaveCommand))
                                {
                                    _compositeSaveCommand.RegisterCommand(payload.SaveCommand);
                                }
                            }
                            if (payload.HasNewCommand)
                            {
                                if (!_compositeNewCommand.RegisteredCommands.Contains(payload.NewCommand))
                                {
                                    _compositeNewCommand.RegisterCommand(payload.NewCommand);
                                }

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
                            if (viewStack.Any())
                            {
                                viewStack.Pop();
                            }
                            if (viewStack.Any())
                            {
                                currentViewObjectId = viewStack.Peek().ToString();
                            }
                        }
                        // some crazy people has invented a composite command to delete/save
                        // so in this case we can degister the command.
                        if (payload.HasDeleteCommand)
                        {
                            if (payload.DeleteCommand != null)
                                _compositeDeleteCommand.UnregisterCommand(payload.DeleteCommand);
                        }
                        if (payload.HasSaveCommand)
                        {
                            if (payload.SaveCommand != null)
                                _compositeSaveCommand.UnregisterCommand(payload.SaveCommand);
                        }
                        if (payload.HasNewCommand)
                        {
                            if (payload.NewCommand != null)
                                _compositeNewCommand.UnregisterCommand(payload.NewCommand);
                        }
                        break;
                    }
                case DataPayLoad.Type.Dispose:
                    {
                        var objectPath = payload.ObjectPath;
                        CleanCareKeeper(objectPath);
                        // delete any composite command

                        if (objectPath != null)
                        {
                            var list = viewStack.ToList();
                            list.RemoveAll(x => x == objectPath);
                            viewStack.Clear();
                            foreach (var x in list)
                            {
                                viewStack.Push(x);
                            }
                        }
                        bool empty = this._careKeeper.ScheduledPayloadCount() == 0;
                        if (empty)
                        {
                            CurrentSaveImagePath = KarveToolBarViewModel.currentSaveImage;
                        }
                        break;
                    }
                case DataPayLoad.Type.Delete:
                    {
                        _activeSubSystem = payload.Subsystem;
                        _states = ToolbarStates.None;
                        var payLoad = new DataPayLoad
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
        ///  Clean the carekeeper.
        /// </summary>
        /// <param name="objectPath">Path of the object</param>
        private void CleanCareKeeper(Uri objectPath)
        {
            this._careKeeper.DeleteItems(objectPath);

        }

        /// <summary>
        /// Save command current tab.
        /// </summary>
        public DelegateCommand SaveCommand { set; get; }
        /// <summary>
        ///  New command tab
        /// </summary>
        public ICommand NewCommand { set; get; }

        /// <summary>
        ///  Delete command view module.
        /// </summary>
        public DelegateCommand<object> DeleteCommand { set; get; }
        /// <summary>
        ///  Returns the currenct active payload in the toolbar if any
        /// </summary>
        public DataPayLoad CurrentPayLoad { get; set; }
    }

}
