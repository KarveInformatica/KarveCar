using System;
using KarveCar.ViewModels;
using KarveCommon.Command;

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
            grupovehiculovm.GrupoVehiculo(parameter);
        }

        public override bool UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}

