using System;
using KarveCar.ViewModels;
using KarveCommon.Command;

namespace KarveCar.Commands.Generic
{
    // TODO: code duplication. The real one shall be the KarveCommon.

    public class SetLanguagesCommand : AbstractCommand
    {
        private MainWindowViewModel setlanguagesvm;

        public SetLanguagesCommand() { }

        public SetLanguagesCommand(MainWindowViewModel vm)
        {
            this.setlanguagesvm = vm;
        }
        
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            setlanguagesvm.SetLanguages(parameter);
        }
    }
}
