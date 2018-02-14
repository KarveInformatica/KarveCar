using KarveControls.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace KarveControls.HolidayCalendar
{
    class DateSelectionBehaviour: Behavior<KarveCalendar>
    {

        public enum SelectionState {  Selected, Unselected };

        public static DependencyProperty CommandDependencyProperty
            = DependencyProperty.Register(
                "Command",
                typeof(ICommand),
                typeof(DateSelectionBehaviour));
        /// <summary>
        ///  CountryCode
        /// </summary>
        public ICommand Command
        {
            set
            {
                SetValue(CommandDependencyProperty, value);
            }
            get
            {
                return (ICommand)GetValue(CommandDependencyProperty);
            }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.SelectedDatesChanged += AssociatedObject_SelectedDatesChanged;
            
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.SelectedDatesChanged -= AssociatedObject_SelectedDatesChanged;
        }

        private void AssociatedObject_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            IDictionary<SelectionState, System.Collections.IList> ev = new Dictionary<SelectionState, System.Collections.IList>();
            ev[SelectionState.Selected] = e.AddedItems;
            ev[SelectionState.Unselected] = e.RemovedItems;
            ICommand cmd = Command;
            if (cmd!=null)
            {
                cmd.Execute(ev);
            }
        }
    }
}
