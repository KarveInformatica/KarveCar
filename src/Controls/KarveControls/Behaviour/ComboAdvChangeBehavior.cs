using Syncfusion.Windows.Tools.Controls;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Collections;
using System.Windows.Media;
using Syncfusion.UI.Xaml.Grid;

namespace KarveControls.Behaviour
{
    /// <summary>
    ///  ComboAdvChangeBehvior. Select a combo box.
    /// </summary>
    public class ComboAdvChangeBehavior : KarveBehaviorBase<ComboBoxAdv>
    {
        /// <summary>
        ///  Command dependency property
        /// </summary>
        public static DependencyProperty CommandDependencyProperty
            = DependencyProperty.Register(
                "Command",
                typeof(ICommand),
                typeof(ComboAdvChangeBehavior));

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
                typeof(ComboAdvChangeBehavior) , new UIPropertyMetadata(null, OnDataObjectChanged));

        private static void OnDataObjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ComboAdvChangeBehavior cmd = d as ComboAdvChangeBehavior;
            if (cmd!=null)
            {
                cmd.OnDataObjectChanged(e);
            }
        }
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

            if (this.AssociatedObject == null)
                return;

            this.AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;
        }
        protected override void OnCleanup()
        {
            if (this.AssociatedObject == null)
                return;

            this.AssociatedObject.SelectionChanged -= AssociatedObject_SelectionChanged;
        }
        protected override void OnAttached()
        {
            if (this.AssociatedObject!=null)
            {
                this.AssociatedObject.DefaultText = KarveLocale.Properties.Resources.ComboAdvChangeBehavior_OnDetaching_EligeCampo;

            }
            base.OnAttached();           
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
        }
        private void AssociatedObject_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            /*
            if (this.AssociatedObject != null)
            {
                IDictionary<string, object> ev = new Dictionary<string, object>();
                ev["ChangedIndex"] = this.AssociatedObject.SelectedIndex;
                ev["ChangedValues"] = this.AssociatedObject.SelectedItems;
                ev["DataObject"] = null;
                ICommand cmd = Command;
                if (cmd != null)
                {
                    cmd.Execute(ev);
                }
            }*/
        }
        private void OnDataObjectChanged(DependencyPropertyChangedEventArgs e)
        {
            var value = e.NewValue as IEnumerable;
            if ((value != null) && (this.AssociatedObject!=null))
            {
                this.AssociatedObject.ItemsSource = value;
            }
        }
    }
}
