using KarveCar.ViewModel.GenericViewModel;
using System;
using System.Windows.Input;

namespace KarveCar.Commands.ToolBarCommand
{
    public class PreviousToolBarCommand : AbstractCommand
    {
        private ToolBarViewModel toolbarvm;

        public PreviousToolBarCommand(ToolBarViewModel vm)
        {
            this.toolbarvm = vm;
        }
        public override void Execute(object parameter)
        {
            toolbarvm.AnteriorToolBar(parameter);
        }

        public override bool UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}