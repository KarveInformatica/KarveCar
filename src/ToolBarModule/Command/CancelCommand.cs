using System;
using KarveCommon;
using KarveCommon.Command;
using ToolBarModule.ViewModel;

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