using KarveCar.ViewModel.GenericViewModel;
using System;
using System.Windows.Input;

namespace KarveCar.Commands.ToolBarCommand
{

    public class NextToolBarCommand : AbstractCommand
    {
        private ToolBarViewModel toolbarvm;

        public NextToolBarCommand(ToolBarViewModel vm)
        {
            this.toolbarvm = vm;
        }

        
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            toolbarvm.SiguienteToolBar(parameter);
        }

        public override bool UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}