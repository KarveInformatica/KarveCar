using KarveCar.ViewModel.GenericViewModel;
using System;
using System.Windows.Input;

namespace KarveCar.Commands.ToolBarCommand
{
    public class CancelToolBarCommand : AbstractCommand
    {
        private ToolBarViewModel toolbarvm;

        public CancelToolBarCommand(ToolBarViewModel vm)
        {
            this.toolbarvm = vm;
        }
        public override void Execute(object parameter)
        {
            toolbarvm.CancelarToolBar(parameter);          
        }
        public override bool UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}