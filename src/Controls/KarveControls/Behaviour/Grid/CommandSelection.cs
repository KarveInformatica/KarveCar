using System.Windows.Interactivity;
using Syncfusion.UI.Xaml.Grid;
using System.Windows.Input;
using System.Windows;

namespace KarveControls.Behaviour.Grid
{
    public class CommandSelection : Behavior<SfDataGrid>
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(CommandSelection));
        public static readonly DependencyProperty CommandParamProperty = DependencyProperty.RegisterAttached("CommandParam", typeof(object), typeof(CommandSelection));
        /// <summary>
        ///  Command to be executed
        /// </summary>
        public ICommand Command
        {
                set { SetValue(CommandProperty, value); }
                get { return (ICommand)GetValue(CommandProperty); }
        }
        public ICommand CommandParam
        {
            set { SetValue(CommandParamProperty, value); }
            get { return (ICommand)GetValue(CommandParamProperty); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.MouseDoubleClick += AssociatedObject_MouseDoubleClick;
            this.AssociatedObject.Unloaded += AssociatedObject_Unloaded;
        }
        // we use unloaded to be sure to unsubscribe early events since deteched might not be called.
        private void AssociatedObject_Unloaded(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.MouseDoubleClick -= AssociatedObject_MouseDoubleClick;

        }
        private void AssociatedObject_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
           ICommand command =  GetValue(CommandProperty) as ICommand;
           object commandParm = GetValue(CommandParamProperty);
            if (command != null)
            {
                command.Execute(commandParm);
            }
        }
        protected override void OnDetaching()
        {
            base.OnAttached();
            this.AssociatedObject.Unloaded -= AssociatedObject_Unloaded;   
        }
    }
}
