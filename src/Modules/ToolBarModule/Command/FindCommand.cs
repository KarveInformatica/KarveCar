using System;
using KarveCommon.Command;

namespace ToolBarModule.Command
{
    public class FindCommand : AbstractCommand
    {
        private KarveToolBarViewModel toolbarvm;

        public FindCommand(KarveToolBarViewModel vm)
        {
            this.toolbarvm = vm;
        }
        public override void Execute(object parameter)
        {
         //   toolbarvm.BuscarToolBar(parameter);
        }

        public override bool UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
