using KarveCar.ViewModel.GenericViewModel;
using System;
using System.Windows.Input;

namespace KarveCar.Commands.Generic
{
    class CloseWindowCommand : AbstractCommand
    {
        private CloseWindowViewModel closewindowvm;

        public CloseWindowCommand() {}

        public CloseWindowCommand(CloseWindowViewModel vm)
        {
            this.closewindowvm = vm;
        }
        public override  void Execute(object parameter)
        {
            closewindowvm.CloseWindow(parameter);         
        }
    }
}
