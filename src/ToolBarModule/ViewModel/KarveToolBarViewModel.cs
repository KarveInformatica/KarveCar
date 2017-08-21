using KarveCommon.Services;
using KarveDataServices;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;

namespace ToolBarModule
{
    /// <summary>
    /// View model that is able to manage the tool bar.
    /// </summary>
    public class KarveToolBarViewModel : BindableBase, IToolBarViewModel
    {
        private ICareKeeperService _careKeeper;
        private IDataServices _dataServices;
        private bool _buttonEnabled = false;
        private IConfigurationService _configurationService;
        private Stack<DataPayLoad> _dataPayLoadLifo = new Stack<DataPayLoad>();

        public KarveToolBarViewModel(ICareKeeperService careKeeperService,
                                     IDataServices dataServices,
                                     IConfigurationService configurationService)
        {
            this._careKeeper = careKeeperService;
            this.UndoCommand = new DelegateCommand(DoUndoCommand, CanExecute);
            this.SaveCommand = new DelegateCommand(DoSaveCommand);
            this.RedoCommand = new DelegateCommand(DoRedoCommand);
            this.ExitCommand = new DelegateCommand(DoExitCommand, CanExecute);
            this._dataServices = dataServices;
            this._configurationService = configurationService;
            this._configurationService.SubscribeDataChange(NewData);
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

        private void NewData(DataPayLoad dataCollection)
        {
            // ok in this case we can 
            ButtonEnabled = true;
            // new data has been arrived.
            _dataPayLoadLifo.Push(dataCollection);
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
