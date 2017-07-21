using KarveCar.ViewModel.GenericViewModel;
using System;
using System.Windows.Input;

namespace KarveCar.Commands.ToolBarCommand
{
    public class ExitToolBarCommand : AbstractCommand
    {
        private ToolBarViewModel toolbarvm;

        public ExitToolBarCommand(ToolBarViewModel vm)
        {
            this.toolbarvm = vm;
        }
        public override void Execute(object parameter)
        {
            toolbarvm.SalirToolBar(parameter);
        }

        public override bool UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}