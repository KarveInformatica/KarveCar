using KarveCommon.Command;
using System;
using KarveCar.ViewModels;

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
