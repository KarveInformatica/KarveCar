using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;
using KarveCommon;
using KarveControls.Generic;

namespace KarveControls.Behaviour
{ 
    /// <summary>
    ///  PlusMinusBehaviour. This is  behaviour that modify the behaviour of a toogle button for allowing + or minus. 
    /// </summary>
    /// 
    class PlusMinusBehaviour: Behavior<ToggleButton>
    {

        private StackPanel _panel = new StackPanel();
        private TextBlock _block = new TextBlock();
        private Image _image = new Image();

        /// <summary>
        ///  This is the list of the allowed columns. If a column is not in this list.
        /// </summary>
        public static readonly DependencyProperty plusPathProperty = DependencyProperty.Register("PlusPath",
            typeof(string), typeof(PlusMinusBehaviour));

        /// <summary>
        ///  Set or Get PlusPath property.
        /// </summary>
        public string PlusPath
        {
            set
            {
                SetValue(plusPathProperty, value);
            }
            get
            {
                return (string)GetValue(plusPathProperty);
            }
        }
        public static readonly DependencyProperty minusPathProperty = DependencyProperty.Register("MinusPath",
            typeof(string), typeof(PlusMinusBehaviour));
        /// <summary>
        /// Set or Get MinusPath property.
        /// </summary>
        public string MinusPath
        {
            set
            {
                SetValue(minusPathProperty, value);
            }
            get
            {
                return (string)GetValue(minusPathProperty);
            }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            _block.Text = KarveLocale.Properties.Resources.PlusMinusBehaviour_OnAttached_MoreItems;
            _image = new Image();
            _image.Source = ComponentUtils.CreateImageSource(PlusPath, true);
            _panel.Children.Add(_image);
            _panel.Children.Add(_block);
            this.AssociatedObject.Content = _panel;
            this.AssociatedObject.Checked += AssociatedObject_Checked;
            this.AssociatedObject.Unchecked += AssociatedObject_Unchecked;
        }

        private void AssociatedObject_Unchecked(object sender, RoutedEventArgs e)
        {
            _block.Text = KarveLocale.Properties.Resources.PlusMinusBehaviour_OnAttached_MoreItems; 
        }

        private void AssociatedObject_Checked(object sender, RoutedEventArgs e)
        {
            _image.Source = ComponentUtils.CreateImageSource(MinusPath, true);
            _block.Text = KarveLocale.Properties.Resources.PlusMinusBehaviour_OnAttached_LessItems;
        }

        /// <summary>
        ///  Detach the attached values.
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
        }
    }
}
