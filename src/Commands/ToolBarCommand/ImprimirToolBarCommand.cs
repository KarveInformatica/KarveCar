using KarveCar.ViewModel.GenericViewModel;
using System;
using System.Windows.Input;

namespace KarveCar.Commands.ToolBarCommand
{
    public class ImprimirToolBarCommand : AbstractCommand
    {
        private ToolBarViewModel toolbarvm;

        public ImprimirToolBarCommand(ToolBarViewModel vm)
        {
            this.toolbarvm = vm;
        }
        public override void Execute(object parameter)
        {
            toolbarvm.ImprimirToolBar(parameter);
        }
    }
}