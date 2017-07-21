using KarveCar.ViewModel.GenericViewModel;
using System;
using System.Windows.Input;

namespace KarveCar.Commands.ToolBarCommand
{
    public class DeleteToolBarCommand : AbstractCommand
    {
        private ToolBarViewModel toolbarvm;

        public DeleteToolBarCommand(ToolBarViewModel vm)
        {
            this.toolbarvm = vm;
        }
        public override void Execute(object parameter)
        {
            toolbarvm.EliminarToolBar(parameter);
        }

        public override bool UnExecute()
        {
            return false;
        }
    }
}