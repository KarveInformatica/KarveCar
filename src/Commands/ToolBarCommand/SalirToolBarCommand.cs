using KarveCar.ViewModel.GenericViewModel;
using System;
using System.Windows.Input;

namespace KarveCar.Commands.ToolBarCommand
{
    public class SalirToolBarCommand : AbstractCommand
    {
        private ToolBarViewModel toolbarvm;

        public SalirToolBarCommand(ToolBarViewModel vm)
        {
            this.toolbarvm = vm;
        }
        public override void Execute(object parameter)
        {
            toolbarvm.SalirToolBar(parameter);
        }
    }
}