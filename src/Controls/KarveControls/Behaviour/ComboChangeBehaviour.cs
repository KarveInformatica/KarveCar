using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace KarveControls.Behaviour
{
    public class ComboChangeBehaviour: KarveBehaviorBase<ComboBox>
    {

        /// <summary>
        ///  Command dependency property
        /// </summary>
        public static DependencyProperty CommandDependencyProperty
            = DependencyProperty.Register(
                "Command",
                typeof(ICommand),
                typeof(ComboChangeBehaviour));

        /// <summary>
        ///  Command to be executed on change.
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


        /// <summary>
        ///  DataObject dependency property
        /// </summary>
        public static DependencyProperty DataObjectDependencyProperty
            = DependencyProperty.Register(
                "DataObject",
                typeof(object),
                typeof(ComboChangeBehaviour));

        /// <summary>
        ///  Command to be executed on change.
        /// </summary>
        public object DataObject
        {
            set
            {
                SetValue(DataObjectDependencyProperty, value);
            }
            get
            {
                return (object)GetValue(DataObjectDependencyProperty);
            }
        }

        protected override void OnSetup()
        {
            this.AssociatedObject.SelectionChanged+= AssociatedObject_SelectionChanged;
        }
        protected override void OnCleanup()
        {
            this.AssociatedObject.SelectionChanged -= AssociatedObject_SelectionChanged;
        }

        private void AssociatedObject_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            IDictionary<string, object> ev = new Dictionary<string, object>(); 
            ev["DataObject"] = DataObject;
            ev["ChangedIndex"] = this.AssociatedObject.SelectedIndex;
            ICommand cmd = Command;
            if (cmd != null)
            {
                cmd.Execute(ev);
            }
        }
    }
}
