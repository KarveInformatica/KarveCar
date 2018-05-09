using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using KarveControls.Generic;
using System.Windows.Input;

namespace KarveControls
{
    /// <summary>
    ///  Represent a control that a user can select and clear.
    /// </summary>
    public class DataFieldCheckBox: CheckBox
    {
        private bool? _isChecked;
        private bool? _previous;
        private int times = 0;

        static DataFieldCheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DataFieldCheckBox), 
                                                          new FrameworkPropertyMetadata(typeof(DataFieldCheckBox)));
        }
        /// <summary>
        /// Data object properties.
        /// </summary>
        public static DependencyProperty DataObjectDependencyProperty =
            DependencyProperty.Register(
                "DataObject",
                typeof(object),
                typeof(DataFieldCheckBox));

        
       

        /// <summary>
        /// Data object dependency property. It get/set an object in the component.
        /// </summary>
        public object DataObject
        {
            set
            {
                SetValue(DataObjectDependencyProperty, value);
            }
            get { return (object) GetValue(DataObjectDependencyProperty); }
        }
        /// <summary>
        ///  default checkbox.
        /// </summary>
        public DataFieldCheckBox() : base()
        {
            
            this.Checked+=OnChecked;
            this.Unchecked+=OnUnchecked;
           // this.Click += DataFieldCheckBox_Click;
            _isChecked = IsChecked;
            _previous = IsChecked;
           
        }

        private void DataFieldCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (IsChecked.HasValue)
            {
                var value = IsChecked.Value;
                IsChecked = !value;
                 

            }
            else
            {
                IsChecked = false;
            }

        }

        private void OnUnchecked(object sender, RoutedEventArgs routedEventArgs)
        {
            DataFieldCheckBox checkBox = sender as DataFieldCheckBox;
            
            if (checkBox != null)
            {
                if (checkBox.IsChecked != null)
                {
                   
                    _isChecked = checkBox.IsChecked.Value;
                    
                }
                times = 1;
                if (times > 0)
                {
                    if (_previous.Value != _isChecked.Value)
                    {
                        SendEventOnChanged();
                    }
                }
               
                _previous = _isChecked;
            }
        }

        private void OnChecked(object sender, RoutedEventArgs routedEventArgs)
        {
            if (sender is DataFieldCheckBox checkBox)
            {


                if (checkBox.IsChecked != null)
                {

                    _isChecked = checkBox.IsChecked.Value;

                    if (_previous != null && ((_previous.Value == false) && (checkBox.IsChecked.Value == true)))
                    {
                        SendEventOnChanged();
                    }
                }
                if (times > 0)
                {
                    if (_isChecked != null && (_previous != null && _previous.Value != _isChecked.Value))
                    {
                        SendEventOnChanged();
                    }
                    times = 1;
                }
                _previous = _isChecked;

            }

        }

        private void SendEventOnChanged()
        {
            
                // ok we can raise the event.
                var path = ControlExt.GetDataSourcePath(this);
                var current = (IsChecked == true) ? 1 : 0;
                IDictionary<string, object> values = new Dictionary<string, object>();
                values.Add("DataObject", DataObject);
                values.Add("ChangedValue", IsChecked);
                values.Add("PreviousValue", _previous);
                values.Add("Field", path);
            if (Command != null)
            {
                Command.Execute(values);
            }
            else
            {
                DataFieldCheckBoxEventArgs args = new DataFieldCheckBoxEventArgs(DataFieldCheckBoxChangedEvent);
                args.ChangedValuesObjects = values;
                RaiseEvent(args);
            }
        }
        // in case it is changed.
        private void OnLostFocus(object sender, RoutedEventArgs routedEventArgs)
        {
         
            
        }

        
        /// <summary>
        ///  Apply template.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        /// <summary>
        ///  Event launched when the checkbox change.
        /// </summary>
        public static RoutedEvent DataFieldCheckBoxChangedEvent = EventManager.RegisterRoutedEvent("DataFieldCheckBoxChanged", 
            RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DataFieldCheckBox));
        /// <summary>
        /// This the event when it changes the checkbox.
        /// </summary>
        public event RoutedEventHandler
            DataFieldCheckBoxChanged
            {
                add
                {
                    AddHandler(DataFieldCheckBoxChangedEvent, value);
                }
                remove
                {
                    RemoveHandler(DataFieldCheckBoxChangedEvent, value);
                }
            }

    }
}
