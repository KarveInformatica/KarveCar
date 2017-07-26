using System;
using System.Collections.Generic;
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
using ToolBarModule.View;

namespace ToolBarModule.ViewModel
{
    /// <summary>
    /// View model that is able to manage the tool bar.
    /// </summary>
    public class KarveToolBarViewModel: BindableBase
    {
        private ICareKeeperService _careKeeper;
        private IDalLocator _locator;
        private bool saveEnabled;

        public KarveToolBarViewModel(ICareKeeperService careKeeperService, IDalLocator locator)
        {
            this._careKeeper = careKeeperService;
            this.EnableSaveCommand = new DelegateCommand(DoEnableSave, CanExecute);
            this.DisableSaveCommand = new DelegateCommand(DoDisableSave, CanExecute);
            this.DisableDeleteCommand = new DelegateCommand(DoDisableCommand, CanExecute);
            this.EnableDeleteCommand = new DelegateCommand(DoEnableDeleteCommand, CanExecute);
            this.UndoCommand = new DelegateCommand(DoUndoCommand, CanExecute);
            this.SaveCommand = new DelegateCommand(DoSaveCommand);
            this.RedoCommand = new DelegateCommand(DoRedoCommand);
            this.ExitCommand = new DelegateCommand(DoExitCommand, CanExecute);
            this._locator = locator;
        }

        private void DoSaveCommand()
        {
            if (saveEnabled)
            {
            }
        }

        private void DoExitCommand()
        {

            MessageBox.Show("Noma");
            /*   try
               {
                   if (MessageBox.Show(Resources.msgSalir, Resources.lrapmnitSalir, MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                   {
                       ((MainWindow)Application.Current.MainWindow).Close();
                   }
               }
               catch (Exception ex)
               {
                   ErrorsGeneric.MessageError(ex);
               }
               */
        }

        private void DoUndoCommand()
        {
            
        }

        private void DoRedoCommand()
        {

        }

        private void DoEnableDeleteCommand()
        {
        }

        private void DoDisableCommand()
        {
        }

        private void DoEnableSave()
        {
            saveEnabled = true;
        }


        private void DoDisableSave()
        {
            saveEnabled = false;
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
     
    }

}
