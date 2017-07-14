using KRibbon.ViewModel.ConfiguracionViewModel;
using System;
using System.Windows.Input;

namespace KRibbon.Commands.ConfiguracionCommand
{
    public class CintaOpcionesCommand : ICommand
    {
        private CintaOpcionesViewModel cintaopcionesvm;

        public CintaOpcionesCommand() { }
        public CintaOpcionesCommand(CintaOpcionesViewModel vm)
        {
            this.cintaopcionesvm = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            cintaopcionesvm.CintaOpciones(parameter);
        }
    }
}
