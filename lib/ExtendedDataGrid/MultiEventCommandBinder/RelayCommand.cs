using System;
using System.Windows.Input;

namespace MultiEventCommandBinder
{
    public class RelayCommand : ICommand
    {
        #region Fields

        public Action<CommandArgs> ExecuteDelegate;
        public Action<object> ExecuteDelegateObject;
        public Predicate<object> CanExecuteDelegate;
        public string EventName { get; set; }

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Creates a new command that can always ExecuteDelegate.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action<CommandArgs> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Creates a new command that can always ExecuteDelegate.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            ExecuteDelegateObject = execute;
            CanExecuteDelegate = canExecute;

        }
        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<CommandArgs> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            ExecuteDelegate = execute;
            CanExecuteDelegate = canExecute;
           
        }

        #endregion // Constructors

        #region ICommand Members

       
        public bool CanExecute(object parameter)
        {
            return CanExecuteDelegate == null || CanExecuteDelegate(parameter);
        }
       
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
           
                if (parameter is CommandArgs)
                {
                    if (ExecuteDelegate != null)
                    {
                        ExecuteDelegate(parameter as CommandArgs);
                    }
                }
                else
                {
                    if (ExecuteDelegateObject != null)
                    {
                        ExecuteDelegateObject(parameter);
                    }
                }
            
        }

        #endregion // ICommand Members
    }
}
