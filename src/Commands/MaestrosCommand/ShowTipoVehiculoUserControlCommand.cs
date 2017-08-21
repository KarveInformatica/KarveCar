using KarveCar.ViewModel.MaestrosViewModel;
using KarveCommon.Command;
using System;

namespace KarveCar.Commands.MaestrosCommand
{
    public class ShowTipoVehiculoUserControlCommand : AbstractCommand
    {
        private GrupoVehiculoViewModel grupovehiculovm;

        public ShowTipoVehiculoUserControlCommand() { }
        public ShowTipoVehiculoUserControlCommand(GrupoVehiculoViewModel vm)
        {
            this.grupovehiculovm = vm;
        }

        public override void Execute(object parameter)
        {
            grupovehiculovm.ShowTipoVehiculoUserControl(parameter);
        }

        public override bool UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}