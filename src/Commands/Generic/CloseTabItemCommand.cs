using KarveCar.ViewModel.GenericViewModel;
using System;
using System.Windows.Input;

namespace KarveCar.Commands.Generic
{
    public class CloseTabItemCommand : ICommand
    {
        private CloseTabItemViewModel closetabitemvm;

        public CloseTabItemCommand() {}

        public CloseTabItemCommand(CloseTabItemViewModel vm)
        {
            this.closetabitemvm = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            closetabitemvm.CloseTabItem(parameter);         
        }
    }
}
