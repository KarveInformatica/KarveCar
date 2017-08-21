using KarveCar.ViewModel.MaestrosViewModel;
using KarveCommon.Command;
using System;

namespace KarveCar.Commands.MaestrosCommand
{
    public class ShowGrupoVehiculoUserControlCommand : AbstractCommand
    {
        private GrupoVehiculoViewModel grupovehiculovm;

        public ShowGrupoVehiculoUserControlCommand() { }
        public ShowGrupoVehiculoUserControlCommand(GrupoVehiculoViewModel vm)
        {
            this.grupovehiculovm = vm;
        }

        public override void Execute(object parameter)
        {
            grupovehiculovm.ShowGrupoVehiculoUserControl(parameter);
        }

        public override bool UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}