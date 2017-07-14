using KRibbon.ViewModel.MaestrosViewModel;
using System;
using System.Windows.Input;

namespace KRibbon.Commands.Generic
{
    public class MostrarAuxiliaresCommand : ICommand
    {
        private MostrarAuxiliaresViewModel mostrarauxiliaresvm;

        public MostrarAuxiliaresCommand() { }

        public MostrarAuxiliaresCommand(MostrarAuxiliaresViewModel vm)
        {
            this.mostrarauxiliaresvm = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mostrarauxiliaresvm.MostrarAuxiliares(parameter);        
        }
    }
}
