using System;

namespace ToolBarModule.Command
{
    public class PrintCommand : ToolBarCommand
    {
        public PrintCommand(KarveToolBarViewModel vm) : base(vm)
        {
        }
        public override void Execute(object parameter)
        {
            //       toolbarvm.ImprimirToolBar(parameter);
        }
        public override bool UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}