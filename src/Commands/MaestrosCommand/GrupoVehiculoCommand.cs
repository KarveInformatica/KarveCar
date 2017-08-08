using KarveCar.ViewModel.MaestrosViewModel;
using KarveCommon.Command;
using System;

namespace KarveCar.Commands.MaestrosCommand
{
    public class GrupoVehiculoCommand : AbstractCommand
    {
        private GrupoVehiculoViewModel grupovehiculovm;

        public GrupoVehiculoCommand() { }
        public GrupoVehiculoCommand(GrupoVehiculoViewModel vm)
        {
            this.grupovehiculovm = vm;
        }

        public override void Execute(object parameter)
        {
            //grupovehiculovm.GrupoVehiculo(parameter);
        }

        public override bool UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}

