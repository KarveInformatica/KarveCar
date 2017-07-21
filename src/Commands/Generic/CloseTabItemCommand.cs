using KarveCar.ViewModel.GenericViewModel;
using System;
using System.Windows.Input;
using KarveCommon.Command;

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

        public override bool UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
