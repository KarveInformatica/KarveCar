using System;
using System.Windows.Interactivity;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;

namespace KarveControls
{
    public class AttachedClick : Behavior<TextBlock>
    {

        public static readonly DependencyProperty IsDayClickedProperty =
    DependencyProperty.Register(
    "DaySelected", typeof(Boolean),
    typeof(AttachedClick), new FrameworkPropertyMetadata(false));

        public static readonly DependencyProperty DayIndexDependencyProperty =
DependencyProperty.Register(
"DayIndex", typeof(int),
typeof(AttachedClick), new FrameworkPropertyMetadata(0));
        public static readonly DependencyProperty CommandDependencyProperty =
DependencyProperty.Register(
"Command", typeof(ICommand),
typeof(AttachedClick), new FrameworkPropertyMetadata(null));

        /// <summary>
        ///  Day selected.
        /// </summary>
        public bool DaySelected
        {
            get
            {
                return (bool)GetValue(IsDayClickedProperty);
            }
            set
            {
                SetValue(IsDayClickedProperty, value);
            }
        }
        /// <summary>
        ///  Day index selected.
        /// </summary>
        public int DayIndex
        {
            get
            {
                return (int)GetValue(DayIndexDependencyProperty);
            }
            set
            {
                SetValue(DayIndexDependencyProperty, value);
            }
        }
        /// <summary>
        ///  Day index selected.
        /// </summary>
        public ICommand Command
        {
            get
            {
                return (ICommand)GetValue(CommandDependencyProperty);
            }
            set
            {
                SetValue(CommandDependencyProperty, value);
            }
        }
        public AttachedClick()
        {
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseLeftButtonDown;
        }
        /// <summary>
        ///  On a click on the textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AssociatedObject_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            if (!DaySelected)
            {
                this.AssociatedObject.Background = Brushes.Yellow;
                DaySelected = true;
                var value = this.AssociatedObject.Text;
                Tuple<bool, int> par = new Tuple<bool, int>(true, Convert.ToInt16(value));
                DayIndex = Convert.ToInt16(value);
                Command?.Execute(par);

            }
            else
            {
                this.AssociatedObject.Background = Brushes.White;
                DaySelected = false;
                var value = this.AssociatedObject.Text;
                DayIndex = Convert.ToInt16(value);
                Command?.Execute(this);

            }
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
        }

    }
}