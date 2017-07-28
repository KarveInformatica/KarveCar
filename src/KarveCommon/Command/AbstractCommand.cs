using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;

namespace KarveCommon.Command
{
    /// <summary>
    ///  AbstractCommand is the generic view model command.
    /// </summary>
    public abstract class  AbstractCommand: ICommand

    {
        // this is relared to ICommand
        public event EventHandler CanExecuteChanged;
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }
        // Execute of the command
        public abstract void Execute(object parameter);

        // FIXME: This shall be refactored.
        public virtual bool UnExecute()
        {
            throw new NotImplementedException();
        }

    }
}
