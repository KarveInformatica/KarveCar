using System;

namespace ToolBarModule.Command
{
    public class NextCommand : ToolBarCommand
    {
        public NextCommand(KarveToolBarViewModel vm) : base(vm)
        {
        }

        public override void Execute(object parameter)
        {
            //toolbarvm.SiguienteToolBar(parameter);
        }

        public override bool UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}