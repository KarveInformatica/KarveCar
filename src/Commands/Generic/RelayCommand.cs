using System;
using System.Diagnostics;
using System.Windows.Input;

namespace KRibbon.Commands.Generic
{
    public class RelayCommand : ICommand
    {
        #region Propiedades 
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;
        #endregion 

        #region Constructores
        public RelayCommand() { }
        public RelayCommand(Action<object> execute) : this(execute, null) { }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion

        #region ICommand Members 
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        #endregion
    }
}