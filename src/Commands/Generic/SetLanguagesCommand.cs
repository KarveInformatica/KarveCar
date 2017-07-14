using KarveCar.ViewModel.GenericViewModel;
using System;
using System.Windows.Input;

namespace KarveCar.Commands.Generic
{
    public class SetLanguagesCommand : AbstractCommand
    {
        private SetLanguagesViewModel setlanguagesvm;

        public SetLanguagesCommand() { }

        public SetLanguagesCommand(SetLanguagesViewModel vm)
        {
            this.setlanguagesvm = vm;
        }
        
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            setlanguagesvm.SetLanguages(parameter);
        }
    }
}
