using KRibbon.ViewModel.GenericViewModel;
using System;
using System.Windows.Input;

namespace KRibbon.Commands.Generic
{
    public class SetLanguagesCommand : ICommand
    {
        private SetLanguagesViewModel setlanguagesvm;

        public SetLanguagesCommand() { }

        public SetLanguagesCommand(SetLanguagesViewModel vm)
        {
            this.setlanguagesvm = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            setlanguagesvm.SetLanguages(parameter);
        }
    }
}
