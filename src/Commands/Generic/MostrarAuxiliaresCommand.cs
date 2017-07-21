using KarveCar.ViewModel.MaestrosViewModel;
using System;
using System.Windows.Input;

namespace KarveCar.Commands.Generic
{
    public class MostrarAuxiliaresCommand : AbstractCommand
    {
        private MostrarAuxiliaresViewModel mostrarauxiliaresvm;

        public MostrarAuxiliaresCommand() { }

        public MostrarAuxiliaresCommand(MostrarAuxiliaresViewModel vm)
        {
            this.mostrarauxiliaresvm = vm;
        }

        public override void Execute(object parameter)
        {
            mostrarauxiliaresvm.MostrarAuxiliares(parameter);        
        }

        public override bool UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
