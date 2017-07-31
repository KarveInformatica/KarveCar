using System;
using System.Windows.Input;

namespace KarveCar.Commands.Generic
{
    class BanksUpdateCommand : ICommand
    {
        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        void ICommand.Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
