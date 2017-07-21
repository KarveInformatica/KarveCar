using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using System.Windows.Markup;

namespace MultiEventCommandBinder
{
    /// <summary>
    /// This is a command that simply aggregates other commands into a group.
    /// This command's CanExecute logic delegates to the CanExecute logic of 
    /// all the child commands.  When executed, it calls the Execute method
    /// on each child command sequentially.
    /// </summary>
    //[ContentProperty("Commands")]
    public class CommandGroup : ICommand
    {
        #region Constructor

        #endregion // Constructor

        #region Commands

        private ObservableCollection<ICommand> _commands;

        /// <summary>
        /// Returns the collection of child commands.  They are executed
        /// in the order that they exist in this collection.
        /// </summary>
        public ObservableCollection<ICommand> Commands
        {
            get
            {
                if (_commands == null)
                {
                    _commands = new ObservableCollection<ICommand>();
                    _commands.CollectionChanged += OnCommandsCollectionChanged;
                }

                return _commands;
            }
        }

        private void OnCommandsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // We have a new child command so our ability to execute may have changed.
            OnCanExecuteChanged();

            if (e.NewItems != null && 0 < e.NewItems.Count)
            {
                foreach (ICommand cmd in e.NewItems)
                    cmd.CanExecuteChanged += OnChildCommandCanExecuteChanged;
            }

            if (e.OldItems != null && 0 < e.OldItems.Count)
            {
                foreach (ICommand cmd in e.OldItems)
                    cmd.CanExecuteChanged -= OnChildCommandCanExecuteChanged;
            }
        }

        private void OnChildCommandCanExecuteChanged(object sender, EventArgs e)
        {
            // Bubble up the child commands CanExecuteChanged event so that
            // it will be observed by WPF.
            OnCanExecuteChanged();
        }

        #endregion // Commands

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return Commands.All(cmd => cmd.CanExecute(parameter));
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            foreach (ICommand cmd in Commands)
                cmd.Execute(parameter);
        }

        #endregion

        protected virtual void OnCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
