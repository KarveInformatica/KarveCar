using System;
using KarveCommon.Command;
using ToolBarModule.ViewModel;

namespace ToolBarModule.Command
{
    public class SaveCommand : AbstractCommand
    {
        private KarveToolBarViewModel ViewModel;

        public SaveCommand(KarveToolBarViewModel vm)
        {
            this.ViewModel = vm;
        }
        public override void Execute(object parameter)
        {
            CommandWrapper cw = new CommandWrapper(this, parameter);
            ViewModel.SaveCommand(cw);

            //toolbarvm.GuardarToolBar(parameter);
        }
        public override bool UnExecute()
        {
            return ViewModel.Undo();

          
        }
    }
}