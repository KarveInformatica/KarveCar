using System;

namespace ToolBarModule.Command
{
    public class PreviousCommand : ToolBarCommand
    {
        public PreviousCommand(KarveToolBarViewModel vm) : base(vm)
        {
        }
        public override void Execute(object parameter)
        {
            // toolbarvm.AnteriorToolBar(parameter);
        }

        public override bool UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}