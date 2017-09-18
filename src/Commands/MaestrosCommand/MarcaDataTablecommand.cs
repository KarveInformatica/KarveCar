using KarveCar.ViewModel.MaestrosViewModel;
using KarveCommon.Command;
using System;

namespace KarveCar.Commands.MaestrosCommand
{
    public class MarcaDataTableCommand : AbstractCommand
    {
        private MarcaDataTableViewModel marcavm;

        public MarcaDataTableCommand() { }
        public MarcaDataTableCommand(MarcaDataTableViewModel vm)
        {
            this.marcavm = vm;
        }

        public override void Execute(object parameter)
        {
            marcavm.Marca(parameter);
        }

        public override bool UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
