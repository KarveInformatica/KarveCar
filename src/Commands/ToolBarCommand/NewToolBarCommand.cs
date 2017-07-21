using KarveCar.ViewModel.GenericViewModel;
using System;
using System.Windows.Input;

namespace KarveCar.Commands.ToolBarCommand
{
    public class NewToolBarCommand : AbstractCommand
    {
        private ToolBarViewModel toolbarvm;

        public NewToolBarCommand(ToolBarViewModel vm)
        {
            this.toolbarvm = vm;
        }
        public override void Execute(object parameter)
        {
            toolbarvm.NuevoToolBar(parameter);
        }

        public override bool UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
