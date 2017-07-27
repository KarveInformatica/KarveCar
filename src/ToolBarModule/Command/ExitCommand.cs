using System;

namespace ToolBarModule.Command
{
    public class ExitCommand : ToolBarCommand
    {
        public ExitCommand(KarveToolBarViewModel vm) : base(vm)
        {
        }
        public override void Execute(object parameter)
        {
        //    toolbarvm.SalirToolBar(parameter);
        }

        public override bool UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}