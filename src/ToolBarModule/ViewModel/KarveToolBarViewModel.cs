using DataAccessLayer;
using KarveCommon.Services;
using KarveDataServices;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Windows;
using ToolBarModule.Command;
using System;
using System.Windows.Media.Imaging;
using System.Net.Cache;
using KarveCommon.Command;

namespace ToolBarModule
{
    /// <summary>
    /// View model that is able to manage the tool bar.
    /// </summary>
    public class KarveToolBarViewModel : BindableBase, IToolBarViewModel, IEventObserver
    {
        private ICareKeeperService _careKeeper;
        private IDataServices _dataServices;
        private bool _buttonEnabled = false;
        private IConfigurationService _configurationService;
        private Stack<DataPayLoad> _dataPayLoadLifo = new Stack<DataPayLoad>();
        private IEventManager _eventManager;
        private const string currentSaveImage = @"/KarveCar;component/Images/save_toolbar.png";
        private const string currentSaveImageModified = @"/KarveCar;component/Images/modified.png";
        private string _currentSaveImage = null;
        private bool _buttonSaveEnabled = false;
        
        public KarveToolBarViewModel(IDataServices dataServices,
                                 IEventManager eventManager,
                                 ICareKeeperService careKeeper,
                                 IConfigurationService configurationService)
        {
            this._dataServices = dataServices;
            this._configurationService = configurationService;
            this._eventManager = eventManager;
            this._eventManager.registerObserverToolBar(this);
            this._careKeeper = careKeeper;
            this.SaveCommand = new DelegateCommand(DoSaveCommand);
            this._dataServices = dataServices;
            this._configurationService = configurationService;
            this._eventManager = eventManager;
            this._eventManager.registerObserverToolBar(this);
            _currentSaveImage = currentSaveImage;
           
            
        }
        private object GetImage(string imageUri)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.None;
            image.UriCachePolicy = new RequestCachePolicy(RequestCacheLevel.BypassCache);
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            image.UriSource = new Uri(imageUri, UriKind.RelativeOrAbsolute);
            image.EndInit();
            return image;
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

        
        

        private void DoExitCommand()
        {
            _configurationService.CloseApplication();
        }

        private void DoUndoCommand()
        {

        }

        private void DoRedoCommand()
        {

        }

        private bool CanExecute()
        {
            return true;
        }

        private void DoSaveCommand()
        {
            this.CurrentSaveImagePath = KarveToolBarViewModel.currentSaveImage;
            this.IsSaveEnabled = false;
            SaveDataCommand dataCommand = new SaveDataCommand(this._dataServices, this._careKeeper);
            _careKeeper.Do(new CommandWrapper(dataCommand));
            
        }
        /*
         * 
         */
        public void incomingPayload(DataPayLoad payload)
        {
            // ok in this case we can 
            this.CurrentSaveImagePath = currentSaveImageModified;
            this.IsSaveEnabled = true;
            _careKeeper.Schedule(payload);
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
