using KarveCar.ViewModel.GenericViewModel;
using System;
using System.Windows.Input;

namespace KarveCar.Commands.Generic
{
    public class CloseTabItemCommand : AbstractCommand
    {
        private CloseTabItemViewModel closetabitemvm;

        public CloseTabItemCommand() {}

        public CloseTabItemCommand(CloseTabItemViewModel vm)
        {
            this.closetabitemvm = vm;
        }

        public override void Execute(object parameter)
        {
            closetabitemvm.CloseTabItem(parameter);         
        }
    }
}
