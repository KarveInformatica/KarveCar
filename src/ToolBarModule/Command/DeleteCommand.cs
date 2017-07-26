using KarveCommon.Command;
using ToolBarModule.ViewModel;

namespace ToolBarModule.Command
{
    public class DeleteCommand : AbstractCommand
    {
        private KarveToolBarViewModel _viewModel;

        public DeleteCommand(KarveToolBarViewModel vm)
        {
            this._viewModel = vm;
        }
        public override void Execute(object parameter)
        {
            CommandWrapper wrapper = new CommandWrapper(this, parameter);
       //     ViewModel.DeleteItem(wrapper);
        }
        public override bool UnExecute()
        {
         //   return ViewModel.Undo();
            return true;
        }
    }
}