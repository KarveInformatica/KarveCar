using System;
using KarveCar.ViewModels;
using KarveCommon.Command;

namespace KarveCar.Commands.MaestrosCommand
{
    public class MarcaCommand : AbstractCommand
    {
        private MarcaViewModel marcavm;

        public MarcaCommand() { }
        public MarcaCommand(MarcaViewModel vm)
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
