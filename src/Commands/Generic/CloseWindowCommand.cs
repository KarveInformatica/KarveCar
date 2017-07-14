using KarveCar.ViewModel.GenericViewModel;
using System;
using System.Windows.Input;

namespace KarveCar.Commands.Generic
{
    class CloseWindowCommand : ICommand
    {
        private CloseWindowViewModel closewindowvm;

        public CloseWindowCommand() {}

        public CloseWindowCommand(CloseWindowViewModel vm)
        {
            this.closewindowvm = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            closewindowvm.CloseWindow(parameter);         
        }
    }
}
