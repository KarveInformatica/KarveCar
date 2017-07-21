using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;

namespace MultiEventCommandBinder
{
    /// <summary>
    /// Defines the interface for a strategy of execution for the CommandBehaviorBinding
    /// </summary>
    public interface IExecutionStrategy
    {
        /// <summary>
        /// Gets or sets the Behavior that we ExecuteDelegate this strategy
        /// </summary>
        CommandBehaviorBinding Behavior { get; set; }


        void Execute(object parameter, string eventName, object eventArgs);
    }

    /// <summary>
    /// Executes a command 
    /// </summary>
    public class CommandExecutionStrategy : IExecutionStrategy
    {
       
        #region IExecutionStrategy Members

        /// <summary>
        /// Gets or sets the Behavior that we ExecuteDelegate this strategy
        /// </summary>
        public CommandBehaviorBinding Behavior { get; set; }


        public void Execute(object parameter, string eventName, object eventArgs)
        {
            if (Behavior == null)
                throw new InvalidOperationException("Behavior property cannot be null when executing a strategy");

           
                if (Behavior.Command is CommandGroup)
                {
                    var commandGroup = Behavior.Command as CommandGroup;


                    ICommand currentCommand = commandGroup.Commands.FirstOrDefault(command => ((RelayCommand) command).EventName == eventName);

                    if (currentCommand != null)
                    {
                        var args = new CommandArgs
                        {
                            CommandParameters = Behavior.CommandParameter,
                            OriginalArgs = ((object[])eventArgs)[2],
                            OriginalSource = ((object[])eventArgs)[1]
                        };
                        if (currentCommand.CanExecute(Behavior.CommandParameter))
                          currentCommand.Execute(args);
                    }
                    else
                    {
                        Debug.WriteLine("Event name is not passed.");
                    }
                }
                else
                {
                    Behavior.Command.Execute(Behavior.CommandParameter);
                }
            
        }

        #endregion
    }

    /// <summary>
    /// executes a delegate
    /// </summary>
    public class ActionExecutionStrategy : IExecutionStrategy
    {
        #region IExecutionStrategy Members

        /// <summary>
        /// Gets or sets the Behavior that we ExecuteDelegate this strategy
        /// </summary>
        public CommandBehaviorBinding Behavior { get; set; }

        /// <summary>
        /// Executes an Action delegate
        /// </summary>

        public void Execute(object parameter, string eventName, object eventArgs)
        {
            Behavior.Action(parameter);
        }

        #endregion
    }
}
