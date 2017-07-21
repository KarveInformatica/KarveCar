using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace MultiEventCommandBinder
{
    public class CommandBehaviorBinding : IDisposable
    {
   
        public CommandBehaviorBinding()
        {
            EventHandler = new List<Delegate>();
            Event = new List<EventInfo>();
            EventName = new List<string>();
        }

        #region Properties

        /// <summary>
        /// Get the owner of the CommandBinding ex: a Button
        /// This property can only be set from the BindEvent Method
        /// </summary>
        public DependencyObject Owner { get; private set; }

        /// <summary>
        /// The event name to hook up to
        /// This property can only be set from the BindEvent Method
        /// </summary>
        public List<string> EventName { get; private set; }

        /// <summary>
        /// The event info of the event
        /// </summary>
        public List<EventInfo> Event { get; private set; }

        /// <summary>
        /// Gets the EventHandler for the binding with the event
        /// </summary>
        public List<Delegate> EventHandler { get; private set; }

        #region Execution

        //stores the strategy of how to ExecuteDelegate the event handler
        private IExecutionStrategy _strategy;

        /// <summary>
        /// Gets or sets a CommandParameter
        /// </summary>
        public object CommandParameter { get; set; }

        private ICommand _command;

        /// <summary>
        /// The command to ExecuteDelegate when the specified event is raised
        /// </summary>
        public ICommand Command
        {
            get { return _command; }
            set
            {
                _command = value;
                //set the execution strategy to ExecuteDelegate the command
                if (_command is CommandGroup)
                {
                    _strategy = new CommandExecutionStrategy { Behavior = this };
                }
                else
                {
                    _strategy = new CommandExecutionStrategy { Behavior = this };
                }
            }
        }

        private Action<object> _action;

        /// <summary>
        /// Gets or sets the Action
        /// </summary>
        public Action<object> Action
        {
            get { return _action; }
            set
            {
                _action = value;
                // set the execution strategy to ExecuteDelegate the action
                _strategy = new ActionExecutionStrategy { Behavior = this };
            }
        }

        #endregion

        #endregion

        //Creates an EventHandler on runtime and registers that handler to the Event specified
        public void BindEvent(DependencyObject owner, string eventName)
        {
            EventName.Add(eventName);
            Owner = owner;
            Event.Add(Owner.GetType().GetEvent(eventName, BindingFlags.Public | BindingFlags.Instance));
            if (Event == null)
                return;
            EventHandler.Add(EventHandlerGenerator.CreateDelegate(
                                 Event[Event.Count - 1].EventHandlerType,
                                 typeof(CommandBehaviorBinding).GetMethod("Execute",
                                                                           BindingFlags.Public | BindingFlags.Instance),
                                 this, eventName));
            Event[Event.Count - 1].AddEventHandler(Owner, EventHandler[EventHandler.Count - 1]);
        }

        /// <summary>
        /// Executes the strategy
        /// </summary>
        public void Execute(string eventName, object eventArgs)
        {
            try
            {
                if (_strategy == null)
                    return;

                _strategy.Execute(CommandParameter, eventName, eventArgs);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        #region IDisposable Members

        private bool _disposed;

        /// <summary>
        /// Unregisters the EventHandler from the Event
        /// </summary>
        public void Dispose()
        {
            if (!_disposed)
            {
                foreach (var eventInfo in Event)
                {
                    var info = eventInfo;
                    var matchingDelgate = EventHandler.Find(ei => ei.Method.Name == info.Name);
                    if (matchingDelgate != null)
                    {
                        eventInfo.RemoveEventHandler(Owner, matchingDelgate);
                    }
                }
                _disposed = true;
            }
        }

        #endregion
    }
}
