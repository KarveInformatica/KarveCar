using KarveCar.ViewModel.GenericViewModel;
using System;
using System.Windows.Input;

namespace KarveCar.Commands.ToolBarCommand
{
    public class AnteriorToolBarCommand : AbstractCommand
    {
        private ToolBarViewModel toolbarvm;

        public AnteriorToolBarCommand(ToolBarViewModel vm)
        {
            this.toolbarvm = vm;
        }
        public override void Execute(object parameter)
        {
            toolbarvm.AnteriorToolBar(parameter);
        }
    }
}