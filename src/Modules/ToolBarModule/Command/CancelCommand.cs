using System;
using KarveCommon.Command;

namespace ToolBarModule.Command 
{
    public class CancelCommand : AbstractCommand
    {
        private KarveToolBarViewModel toolbarvm;

        public CancelCommand(KarveToolBarViewModel vm)
        {
            this.toolbarvm = vm;
        }
        public override void Execute(object parameter)
        {
            //toolbarvm.CancelarToolBar(parameter);          
        }
        public override bool UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}