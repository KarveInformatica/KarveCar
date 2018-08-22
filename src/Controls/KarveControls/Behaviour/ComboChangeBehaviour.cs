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

        // avoid the first 
        private bool first = true;
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
            this.AssociatedObject.PreviewKeyDown += AssociatedObject_PreviewKeyDown;
        }

        private void AssociatedObject_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var selectedIndex = this.AssociatedObject.SelectedIndex;
            if (e.Key == Key.Space)
            {


                if (selectedIndex == -1)
                {
                    selectedIndex = 0;
                }
                else
                {
                    selectedIndex = (selectedIndex + 1) % this.AssociatedObject.Items.Count; 
                }
            }
        }

        protected override void OnCleanup()
        {
            this.AssociatedObject.SelectionChanged -= AssociatedObject_SelectionChanged;
            this.AssociatedObject.PreviewKeyDown -= AssociatedObject_PreviewKeyDown;
        }

        private void AssociatedObject_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            IDictionary<string, object> ev = new Dictionary<string, object>();
            if (first)
            {
                first = false;
                return;
            }

            if (DataObject != null)
            {
                ev["DataObject"] = DataObject;
                ev["ChangedIndex"] = this.AssociatedObject.SelectedIndex;
                var cmd = Command;
                cmd?.Execute(ev);
            }
        }
    }
}
