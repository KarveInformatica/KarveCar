using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KarveControls
{
    public class ControlState : DependencyObject
    {
        public const string PreviousState = "PreviousState";
        public const string CurrentState = "CurrentState";
        public const string ComponentName = "ComponentName";

        public static readonly DependencyProperty DescriptionDependencyProperty =
DependencyProperty.RegisterAttached(
    "Description",
    typeof(string),
    typeof(ControlState),
    new FrameworkPropertyMetadata(String.Empty));

        public static readonly DependencyProperty TextCurrentDependencyProperty =
    DependencyProperty.RegisterAttached(
        "TextCurrent",
        typeof(string),
        typeof(ControlState),
        new FrameworkPropertyMetadata(String.Empty));

        public string TextCurrent
        {
            get { return (string)GetValue(TextCurrentDependencyProperty); }
            set { SetValue(TextCurrentDependencyProperty, value); }
        }

        /// <summary>
        ///  Get the item changed command
        /// </summary>
        /// <param name="ds">Dependency object</param>
        /// <returns></returns>
        public static string GetTextCurrent(FrameworkElement ds)
        {
            return (string)ds.GetValue(TextCurrentDependencyProperty);
        }
        /// <summary>
        /// Set the item changed command
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="item"></param>
        public static void SetTextCurrent(FrameworkElement ds, object item)
        {
            ds.SetValue(TextCurrentDependencyProperty, item);
        }

        public static readonly DependencyProperty TextPreviousDependencyProperty =
    DependencyProperty.RegisterAttached(
        "TextPrevious",
        typeof(string),
        typeof(ControlState),
        new FrameworkPropertyMetadata(string.Empty));


        public string TextPrevious
        {
            get { return (string)GetValue(TextPreviousDependencyProperty); }
            set { SetValue(TextPreviousDependencyProperty, value); }
        }

        public static readonly DependencyProperty PrevComboSelectedIndexDependencyProperty =
         DependencyProperty.RegisterAttached(
        "PrevComboSelectedIndex",
        typeof(int),
        typeof(ControlState),
        new FrameworkPropertyMetadata(0));

        public string PrevComboSelectedIndex
        {
            get { return (string)GetValue(PrevComboSelectedIndexDependencyProperty); }
            set { SetValue(PrevComboSelectedIndexDependencyProperty, value); }
        }
        public static readonly DependencyProperty CurrentComboSelectedIndexDependencyProperty =
         DependencyProperty.RegisterAttached(
        "PrevComboSelectedIndex",
        typeof(int),
        typeof(ControlState),
        new FrameworkPropertyMetadata(0));


        
        /// <summary>
        ///  Get the item changed command
        /// </summary>
        /// <param name="ds">Dependency object</param>
        /// <returns></returns>
        public static string GetTextPrevious(FrameworkElement ds)
        {
            return (string)ds.GetValue(IsChangedDependencyProperty);
        }
        /// <summary>
        /// Set the item changed command
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="item"></param>
        public static void SetTextPrevious(FrameworkElement ds, object item)
        {
            ds.SetValue(IsChangedDependencyProperty, item);
        }


        public static readonly DependencyProperty IsChangedDependencyProperty =
    DependencyProperty.RegisterAttached(
        "IsChanged",
        typeof(bool),
        typeof(ControlState),
        new FrameworkPropertyMetadata(true));


        /// <summary>
        ///  Get the item changed command
        /// </summary>
        /// <param name="ds">Dependency object</param>
        /// <returns></returns>
        public static bool GetIsChanged(FrameworkElement ds)
        {
            return (bool)ds.GetValue(IsChangedDependencyProperty);
        }
        /// <summary>
        /// Set the item changed command
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="item"></param>
        public static void SetIsChanged(FrameworkElement ds, object item)
        {
            ds.SetValue(IsChangedDependencyProperty, item);
        }


        public static readonly DependencyProperty ItemChangedCommandDependencyProperty =
       DependencyProperty.RegisterAttached(
           "ItemChangedCommand",
           typeof(ICommand),
           typeof(ControlState),
           new FrameworkPropertyMetadata(null, PropertyChangedCb));


        public static readonly DependencyProperty DateCurrentDependencyProperty =
 DependencyProperty.RegisterAttached(
     "DateCurrent",
     typeof(DateTime),
     typeof(ControlState),
     new FrameworkPropertyMetadata(DateTime.Now));


        /// <summary>
        ///  Get the item changed command
        /// </summary>
        /// <param name="ds">Dependency object</param>
        /// <returns></returns>
        public static DateTime GetDateCurrent(DependencyObject ds)
        {
            return (DateTime)ds.GetValue(DateCurrentDependencyProperty);
        }
        /// <summary>
        /// Set the item changed command
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="item"></param>
        public static void SetDateCurrent(DependencyObject ds, object item)
        {
            ds.SetValue(DateCurrentDependencyProperty, item);
        }

        /// <summary>
        ///  Depedency property.
        /// </summary>
        public static readonly DependencyProperty DatePrevDependencyProperty =
 DependencyProperty.RegisterAttached(
     "DatePrev",
     typeof(DateTime),
     typeof(ControlState),
     new FrameworkPropertyMetadata(DateTime.Now));

        /// <summary>
        /// Get the previous value of type datetime
        /// </summary>
        /// <param name="ds">Dependency Object/ User control to take</param>
        /// <returns></returns>
        public static DateTime GetDatePrev(DependencyObject ds)
        {
            return (DateTime)ds.GetValue(DatePrevDependencyProperty);
        }
        /// <summary>
        /// Set the item changed command
        /// </summary>
        /// <param name="ds">Dependency Object, user control to take</param>
        /// <param name="item">Item value to be set</param>
        public static void SetDatePrev(DependencyObject ds, object item)
        {
            ds.SetValue(DatePrevDependencyProperty, item);
        }

        /// <summary>
        ///  Get the item changed command
        /// </summary>
        /// <param name="ds">Dependency object</param>
        /// <returns></returns>
        public static object GetItemChangedCommand(DependencyObject ds)
        {
            return ds.GetValue(ItemChangedCommandDependencyProperty);
        }
        /// <summary>
        /// Set the item changed command
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="item"></param>
        public static void SetItemChangedCommand(DependencyObject ds, object item)
        {
            ds.SetValue(ItemChangedCommandDependencyProperty, item);
        }

        private static void PropertyChangedCb(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBox component = d as TextBox;
            if (component != null)
            {
                component.TextChanged += Component_TextChanged;
                component.LostFocus += Component_LostFocus;
                d.SetValue(DescriptionDependencyProperty, component.Name);
            }
           
            if (component == null)
            {
                var combo = d as ComboBox;
                if (combo != null)
                {
                    combo.SelectionChanged += Combo_SelectionChanged;
                    d.SetValue(DescriptionDependencyProperty, combo.Name);
                }
                DatePicker dateComponent = d as DatePicker;
                if (dateComponent != null)
                {
                    dateComponent.SelectedDateChanged += DateComponent_SelectedDateChanged;
                    d.SetValue(DescriptionDependencyProperty, dateComponent.Name);
                }
            }
        }

        private static void Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FrameworkElement box = sender as FrameworkElement;
            ICommand command = (ICommand)box.GetValue(ItemChangedCommandDependencyProperty);
            if (command != null)
            {
              
                IDictionary<string, object> ev = new Dictionary<string, object>();
                ev["PreviousState"] = box.GetValue(PrevComboSelectedIndexDependencyProperty);
                ev["CurrentState"] = box.GetValue(CurrentComboSelectedIndexDependencyProperty);
                ev["ComponentName"] = box.GetValue(DescriptionDependencyProperty);
                command.Execute(ev);
            }
        }

        private static void DateComponent_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            FrameworkElement box = sender as FrameworkElement;
            ICommand command = (ICommand)box.GetValue(ItemChangedCommandDependencyProperty);
            if (command != null)
            {
                IDictionary<string, object> ev = new Dictionary<string, object>();
                ev["PreviousState"] = box.GetValue(DatePrevDependencyProperty);
                ev["CurrentState"] = box.GetValue(DateCurrentDependencyProperty);
                ev["ComponentName"] = box.GetValue(DescriptionDependencyProperty);
                command.Execute(ev);
            }
        }

        private static void Component_LostFocus(object sender, RoutedEventArgs e)
        {
            FrameworkElement box = sender as FrameworkElement;
            bool valueChanged = (bool)box.GetValue(IsChangedDependencyProperty);
            if (valueChanged)
            {
                ICommand command = (ICommand)box.GetValue(ItemChangedCommandDependencyProperty);
                if (command != null)
                {
                    IDictionary<string, object> ev = new Dictionary<string, object>();
                    ev["PreviousState"] = box.GetValue(TextPreviousDependencyProperty);
                    ev["CurrentState"] = box.GetValue(TextCurrentDependencyProperty);
                    ev["ComponentName"] = box.GetValue(DescriptionDependencyProperty);
                    command.Execute(ev);
                }

            }

        }
        private static void Component_TextChanged(object sender, TextChangedEventArgs e)
        {
            DependencyObject component = sender as DependencyObject;
            if (component != null)
            {
                component.SetValue(IsChangedDependencyProperty, true);
            }
        }
    }
}
