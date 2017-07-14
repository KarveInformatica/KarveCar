using KarveCar.ViewModel.GenericViewModel;
using System;
using System.Windows.Input;

namespace KarveCar.Commands.ToolBarCommand
{
    public class SalirToolBarCommand : ICommand
    {
        private ToolBarViewModel toolbarvm;

        public SalirToolBarCommand(ToolBarViewModel vm)
        {
            this.toolbarvm = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            toolbarvm.SalirToolBar(parameter);
        }
    }
}