using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DataAccessLayer;
using KarveCommon;
using KarveCommon.Command;
using KarveCommon.Generic;
using KarveCommon.Services;
using Prism.Commands;
using Prism.Mvvm;
using ToolBarModule.Command;
using ToolBarModule.Properties;

namespace ToolBarModule
{
    /// <summary>
    /// View model that is able to manage the tool bar.
    /// </summary>
    public class KarveToolBarViewModel: BindableBase, IToolBarViewModel
    {
        private ICareKeeperService _careKeeper;
        private IDalLocator _locator;
        private bool _buttonEnabled = false;
        private IConfigurationService _configurationService;
       private Stack<DataPayLoad> _dataPayLoadLifo = new Stack<DataPayLoad>();

        public KarveToolBarViewModel(ICareKeeperService careKeeperService, 
                                     IDalLocator locator,
                                     IConfigurationService configurationService)
        {
            this._careKeeper = careKeeperService;
            this.UndoCommand = new DelegateCommand(DoUndoCommand, CanExecute);
            this.SaveCommand = new DelegateCommand(DoSaveCommand);
            this.RedoCommand = new DelegateCommand(DoRedoCommand);
            this.ExitCommand = new DelegateCommand(DoExitCommand, CanExecute);
            this._locator = locator;
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
            SaveDataLayerCommand command = new SaveDataLayerCommand(_locator, _careKeeper);
            foreach (var item in _dataPayLoadLifo)
            {
                command.Do(item);
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

        /*
         
         System.Windows.Data Error: 40 : BindingExpression path error: 'DeleteCommand' property not found on 'object' ''String' (HashCode=2065684750)'. BindingExpression:Path=DeleteCommand; DataItem='String' (HashCode=2065684750); target element is 'KeyBinding' (HashCode=62726408); target property is 'Command' (type 'ICommand')
System.Windows.Data Error: 40 : BindingExpression path error: 'DeleteCommand' property not found on 'object' ''String' (HashCode=2065684750)'. BindingExpression:Path=DeleteCommand; DataItem='String' (HashCode=2065684750); target element is 'KeyBinding' (HashCode=17753217); target property is 'Command' (type 'ICommand')
System.Windows.Data Error: 40 : BindingExpression path error: 'DeleteCommand' property not found on 'object' ''String' (HashCode=2065684750)'. BindingExpression:Path=DeleteCommand; DataItem='String' (HashCode=2065684750); target element is 'MouseBinding' (HashCode=19714419); target property is 'Command' (type 'ICommand')
System.Windows.Data Error: 40 : BindingExpression path error: 'CancelCommand' property not found on 'object' ''KarveToolBarViewModel' (HashCode=1114082)'. BindingExpression:Path=CancelCommand; DataItem='KarveToolBarViewModel' (HashCode=1114082); target element is 'KeyBinding' (HashCode=18291919); target property is 'Command' (type 'ICommand')
System.Windows.Data Error: 40 : BindingExpression path error: 'CancelCommand' property not found on 'object' ''KarveToolBarViewModel' (HashCode=1114082)'. BindingExpression:Path=CancelCommand; DataItem='KarveToolBarViewModel' (HashCode=1114082); target element is 'KeyBinding' (HashCode=21522228); target property is 'Command' (type 'ICommand')
System.Windows.Data Error: 40 : BindingExpression path error: 'CancelCommand' property not found on 'object' ''KarveToolBarViewModel' (HashCode=1114082)'. BindingExpression:Path=CancelCommand; DataItem='KarveToolBarViewModel' (HashCode=1114082); target element is 'MouseBinding' (HashCode=28433766); target property is 'Command' (type 'ICommand')
System.Windows.Data Error: 40 : BindingExpression path error: 'PrintCommand' property not found on 'object' ''KarveToolBarViewModel' (HashCode=1114082)'. BindingExpression:Path=PrintCommand; DataItem='KarveToolBarViewModel' (HashCode=1114082); target element is 'KeyBinding' (HashCode=65099051); target property is 'Command' (type 'ICommand')
System.Windows.Data Error: 40 : BindingExpression path error: 'PrintCommand' property not found on 'object' ''KarveToolBarViewModel' (HashCode=1114082)'. BindingExpression:Path=PrintCommand; DataItem='KarveToolBarViewModel' (HashCode=1114082); target element is 'KeyBinding' (HashCode=8065117); target property is 'Command' (type 'ICommand')
System.Windows.Data Error: 40 : BindingExpression path error: 'PrintCommand' property not found on 'object' ''KarveToolBarViewModel' (HashCode=1114082)'. BindingExpression:Path=PrintCommand; DataItem='KarveToolBarViewModel' (HashCode=1114082); target element is 'MouseBinding' (HashCode=25051543); target property is 'Command' (type 'ICommand')
System.Windows.Data Error: 40 : BindingExpression path error: 'PreviousCommand' property not found on 'object' ''KarveToolBarViewModel' (HashCode=1114082)'. BindingExpression:Path=PreviousCommand; DataItem='KarveToolBarViewModel' (HashCode=1114082); target element is 'KeyBinding' (HashCode=20649961); target property is 'Command' (type 'ICommand')
System.Windows.Data Error: 40 : BindingExpression path error: 'PreviousCommand' property not found on 'object' ''KarveToolBarViewModel' (HashCode=1114082)'. BindingExpression:Path=PreviousCommand; DataItem='KarveToolBarViewModel' (HashCode=1114082); target element is 'KeyBinding' (HashCode=57687380); target property is 'Command' (type 'ICommand')
System.Windows.Data Error: 40 : BindingExpression path error: 'PreviousCommand' property not found on 'object' ''KarveToolBarViewModel' (HashCode=1114082)'. BindingExpression:Path=PreviousCommand; DataItem='KarveToolBarViewModel' (HashCode=1114082); target element is 'MouseBinding' (HashCode=29922341); target property is 'Command' (type 'ICommand')
System.Windows.Data Error: 40 : BindingExpression path error: 'SiguienteToolBarCommand' property not found on 'object' ''KarveToolBarViewModel' (HashCode=1114082)'. BindingExpression:Path=SiguienteToolBarCommand; DataItem='KarveToolBarViewModel' (HashCode=1114082); target element is 'KeyBinding' (HashCode=20292006); target property is 'Command' (type 'ICommand')
System.Windows.Data Error: 40 : BindingExpression path error: 'SiguienteToolBarCommand' property not found on 'object' ''KarveToolBarViewModel' (HashCode=1114082)'. BindingExpression:Path=SiguienteToolBarCommand; DataItem='KarveToolBarViewModel' (HashCode=1114082); target element is 'KeyBinding' (HashCode=12502218); target property is 'Command' (type 'ICommand')
System.Windows.Data Error: 40 : BindingExpression path error: 'SiguienteToolBarCommand' property not found on 'object' ''KarveToolBarViewModel' (HashCode=1114082)'. BindingExpression:Path=SiguienteToolBarCommand; DataItem='KarveToolBarViewModel' (HashCode=1114082); target element is 'MouseBinding' (HashCode=11363535); target property is 'Command' (type 'ICommand')
System.Windows.Data Error: 40 : BindingExpression path error: 'BuscarToolBarCommand' property not found on 'object' ''KarveToolBarViewModel' (HashCode=1114082)'. BindingExpression:Path=BuscarToolBarCommand; DataItem='KarveToolBarViewModel' (HashCode=1114082); target element is 'KeyBinding' (HashCode=8031928); target property is 'Command' (type 'ICommand')
System.Windows.Data Error: 40 : BindingExpression path error: 'BuscarToolBarCommand' property not found on 'object' ''KarveToolBarViewModel' (HashCode=1114082)'. BindingExpression:Path=BuscarToolBarCommand; DataItem='KarveToolBarViewModel' (HashCode=1114082); target element is 'KeyBinding' (HashCode=36554565); target property is 'Command' (type 'ICommand')
System.Windows.Data Error: 40 : BindingExpression path error: 'BuscarToolBarCommand' property not found on 'object' ''KarveToolBarViewModel' (HashCode=1114082)'. BindingExpression:Path=BuscarToolBarCommand; DataItem='KarveToolBarViewModel' (HashCode=1114082); target element is 'MouseBinding' (HashCode=55361044); target property is 'Command' (type 'ICommand')

         */

    }

}
