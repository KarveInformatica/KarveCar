using KarveCar.ViewModel.GenericViewModel;
using System;
using System.Windows.Input;

namespace KarveCar.Commands.ToolBarCommand
{
    public class NuevoToolBarCommand : AbstractCommand
    {
        private ToolBarViewModel toolbarvm;

        public NuevoToolBarCommand(ToolBarViewModel vm)
        {
            this.toolbarvm = vm;
        }
        public override void Execute(object parameter)
        {
            toolbarvm.NuevoToolBar(parameter);
        }
    }
}
