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
        private const string currentSaveImage = @"/KarveCar;component/Images/save1.png";
        private const string currentSaveImageModified = @"/KarveCar;component/Images/save.png";
        private string _currentSaveImage = null;
        private object _image = null;
        public KarveToolBarViewModel(ICareKeeperService careKeeperService,
                                 IDataServices dataServices,
                                 IEventManager eventManager,
                                 IConfigurationService configurationService)
        {
            this._careKeeper = careKeeperService;
            this.UndoCommand = new DelegateCommand(DoUndoCommand, CanExecute);
            this.SaveCommand = new DelegateCommand(DoSaveCommand);
            this.RedoCommand = new DelegateCommand(DoRedoCommand);
            this.ExitCommand = new DelegateCommand(DoExitCommand, CanExecute);
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

        private void NewData(DataPayLoad dataCollection)
        {
            // ok in this case we can 
            // new data has been arrived.
            //_dataPayLoadLifo.Push(dataCollection);
        }
        private void DoSaveCommand()
        {


            //SaveDataLayerCommand command = new SaveDataLayerCommand(_locator, _careKeeper);
            //foreach (var item in _dataPayLoadLifo)
            // {
            //   command.Do(item);
            // }

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

        private void DoSave()
        {

        }


        public void incomingPayload(DataPayLoad payload)
        {
            // ok in this case we can 
            this.CurrentSaveImagePath = currentSaveImageModified;

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
