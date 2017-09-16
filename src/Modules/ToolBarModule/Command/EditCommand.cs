namespace ToolBarModule.Command
{
    public class EditCommand : ToolBarCommand
    {
        public EditCommand(KarveToolBarViewModel vm): base(vm)
        {
        }
        public override void Execute(object parameter)
        {
     //       toolbarvm.EditarToolBar(parameter);
        }

        public override bool UnExecute()
        {
            return true;
        }
    }
}