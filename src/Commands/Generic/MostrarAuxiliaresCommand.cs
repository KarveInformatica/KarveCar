using KarveCommon.Command;
using System;
using System.Threading.Tasks;
using KarveCar.ViewModels;

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

        /// <inheritdoc/>
        public override async void Execute(object parameter)
        {
            if (mostrarauxiliaresvm != null)
                await mostrarauxiliaresvm.MostrarAuxiliares(parameter);
        }

        public override bool UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
