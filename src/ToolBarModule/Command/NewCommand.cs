using System;
using KarveCommon.Command;
using ToolBarModule.ViewModel;

namespace ToolBarModule.Command
{
    public class NewCommand : AbstractCommand
    {
        private KarveToolBarViewModel toolbarvm;

        public NewCommand(KarveToolBarViewModel vm)
        {
            this.toolbarvm = vm;
        }
        public override void Execute(object parameter)
        {
           // toolbarvm.NuevoToolBar(parameter);
        }

        public override bool UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
