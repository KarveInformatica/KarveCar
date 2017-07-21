using KarveCar.ViewModel.GenericViewModel;
using System;
using System.Windows.Input;

namespace KarveCar.Commands.ToolBarCommand
{
    public class PrintToolBarCommand : AbstractCommand
    {
        private ToolBarViewModel toolbarvm;

        public PrintToolBarCommand(ToolBarViewModel vm)
        {
            this.toolbarvm = vm;
        }
        public override void Execute(object parameter)
        {
            toolbarvm.ImprimirToolBar(parameter);
        }

        public override bool UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}