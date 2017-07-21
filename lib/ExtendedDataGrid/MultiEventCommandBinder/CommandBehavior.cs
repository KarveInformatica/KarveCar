using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MultiEventCommandBinder
{
    /// <summary>
    /// Defines the attached properties to create a CommandBehaviorBinding
    /// </summary>
    public class CommandBehavior
    {
        #region Behavior

        /// <summary>
        /// Behavior Attached Dependency Property
        /// </summary>
        private static readonly DependencyProperty BehaviorProperty =
            DependencyProperty.RegisterAttached("Behavior", typeof(CommandBehaviorBinding), typeof(CommandBehavior),
                                                new FrameworkPropertyMetadata((CommandBehaviorBinding)null));

        /// <summary>
        /// Gets the Behavior property. 
        /// </summary>
        private static CommandBehaviorBinding GetBehavior(DependencyObject d)
        {
            return (CommandBehaviorBinding)d.GetValue(BehaviorProperty);
        }

        /// <summary>
        /// Sets the Behavior property.  
        /// </summary>
        private static void SetBehavior(DependencyObject d, CommandBehaviorBinding value)
        {
            d.SetValue(BehaviorProperty, value);
        }

        #endregion

        #region Command

        /// <summary>
        /// Command Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command", typeof(object), typeof(CommandBehavior),
                                                new FrameworkPropertyMetadata(null,
                                                                              OnCommandChanged));

        /// <summary>
        /// Gets the Command property.  
        /// </summary>
        public static ICommand GetCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(CommandProperty);
        }

        /// <summary>
        /// Sets the Command property. 
        /// </summary>
        public static void SetCommand(DependencyObject d, ICommand value)
        {
            d.SetValue(CommandProperty, value);
        }

        /// <summary>
        /// Handles changes to the Command property.
        /// </summary>
        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null)
                return;
            CommandBehaviorBinding binding = FetchOrCreateBinding(d);
            if ((e.NewValue as ObservableCollection<RelayCommand>) != null)
            {
                binding.Command = null;
                var collectionOfCommands = e.NewValue as ObservableCollection<RelayCommand>;
                var commandGroup = new CommandGroup();
                foreach (var commands in collectionOfCommands)
                {
                    commandGroup.Commands.Add(commands);

                }

                binding.Command = commandGroup;
            }
            else
            {
                binding.Command = (ICommand)e.NewValue;
            }
        }

        #endregion

        #region Action

        /// <summary>
        /// Action Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty ActionProperty =
            DependencyProperty.RegisterAttached("Action", typeof(Action<object>), typeof(CommandBehavior),
                                                new FrameworkPropertyMetadata(null,
                                                                              OnActionChanged));

        /// <summary>
        /// Gets the Action property.  
        /// </summary>
        public static Action<object> GetAction(DependencyObject d)
        {
            return (Action<object>)d.GetValue(ActionProperty);
        }

        /// <summary>
        /// Sets the Action property. 
        /// </summary>
        public static void SetAction(DependencyObject d, Action<object> value)
        {
            d.SetValue(ActionProperty, value);
        }

        /// <summary>
        /// Handles changes to the Action property.
        /// </summary>
        private static void OnActionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CommandBehaviorBinding binding = FetchOrCreateBinding(d);
            binding.Action = (Action<object>)e.NewValue;
        }

        #endregion

        #region CommandParameter

        /// <summary>
        /// CommandParameter Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.RegisterAttached("CommandParameter", typeof(object), typeof(CommandBehavior),
                                                new FrameworkPropertyMetadata(null,
                                                                              OnCommandParameterChanged));

        /// <summary>
        /// Gets the CommandParameter property.  
        /// </summary>
        public static object GetCommandParameter(DependencyObject d)
        {
            return d.GetValue(CommandParameterProperty);
        }

        /// <summary>
        /// Sets the CommandParameter property. 
        /// </summary>
        public static void SetCommandParameter(DependencyObject d, object value)
        {
            d.SetValue(CommandParameterProperty, value);
        }

        /// <summary>
        /// Handles changes to the CommandParameter property.
        /// </summary>
        private static void OnCommandParameterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CommandBehaviorBinding binding = FetchOrCreateBinding(d);
           
            binding.CommandParameter = e.NewValue;
           
        }

        #endregion

        #region Event

        /// <summary>
        /// Event Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty EventProperty =
            DependencyProperty.RegisterAttached("Event", typeof(string), typeof(CommandBehavior),
                                                new FrameworkPropertyMetadata(String.Empty,
                                                                              OnEventChanged));

        /// <summary>
        /// Gets the Event property.  This dependency property 
        /// indicates ....
        /// </summary>
        public static string GetEvent(DependencyObject d)
        {
            return (string)d.GetValue(EventProperty);
        }

        /// <summary>
        /// Sets the Event property.  This dependency property 
        /// indicates ....
        /// </summary>
        public static void SetEvent(DependencyObject d, string value)
        {
            d.SetValue(EventProperty, value);
        }

        /// <summary>
        /// Handles changes to the Event property.
        /// </summary>
        private static void OnEventChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CommandBehaviorBinding binding = FetchOrCreateBinding(d);
            //check if the Event is set. If yes we need to rebind the Command to the new event and unregister the old one
            if (binding.Event != null && binding.Owner != null)
                binding.Dispose();
            if (string.IsNullOrEmpty(e.NewValue.ToString())) return;
            //bind the new event to the command
            if (!e.NewValue.ToString().Contains(","))
            {
                binding.BindEvent(d, e.NewValue.ToString());
            }
            else
            {
                string[] events = e.NewValue.ToString().Split(',');
                foreach (string eventStr in events)
                {
                    binding.BindEvent(d, eventStr);
                }

            }
        }

        #endregion

        #region Helpers

        //tries to get a CommandBehaviorBinding from the element. Creates a new instance if there is not one attached
        private static CommandBehaviorBinding FetchOrCreateBinding(DependencyObject d)
        {
            CommandBehaviorBinding binding = GetBehavior(d);
            if (binding == null)
            {
                binding = new CommandBehaviorBinding();
                SetBehavior(d, binding);
            }
            return binding;
        }

        #endregion
    }
}
