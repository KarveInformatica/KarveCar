using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using KarveControls.Generic;

namespace KarveControls
{
    /// <summary>
    /// Interaction logic for DataDetiPicker.xaml
    /// </summary>
    public partial class DataDatePicker : UserControl
    {
        /// <summary>
        /// DatePicker changed event
        /// </summary>
        public static readonly RoutedEvent DataDatePickerChangedEvent =
            EventManager.RegisterRoutedEvent(
                "DataDatePickerChanged",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(DataDatePicker));

        /// <summary>
        /// Event class of the event picker.
        /// </summary>
        public class DataDatePickerEventArgs : RoutedEventArgs
        {
            private DateTime _fieldData = new DateTime();
            private IDictionary<string, object> _changedValues = new Dictionary<string, object>();

            /// <summary>
            /// Value of the date
            /// </summary>
            public DateTime FieldData
            {
                get { return _fieldData; }
                set { _fieldData = value; }
            }

            public IDictionary<string, object> ChangedValuesObjects
            {
                get { return _changedValues; }
                set { _changedValues = value; }
            }

            /// <summary>
            ///  std. constructor.
            /// </summary>
            public DataDatePickerEventArgs() : base()
            {

            }

            /// <summary>
            ///  standard constructor
            /// </summary>
            /// <param name="routedEvent">Constructor</param>
            public DataDatePickerEventArgs(RoutedEvent routedEvent) : base(routedEvent)
            {

            }
        }

        /// <summary>
        ///  DataDatePicker changed.
        /// </summary>
        public event RoutedEventHandler DataDatePickerChanged
        {
            add { AddHandler(DataDatePickerChangedEvent, value); }
            remove { RemoveHandler(DataDatePickerChangedEvent, value); }
        }

        /// <summary>
        /// Data Object dependency property.
        /// </summary>
        public static DependencyProperty DataObjectDependencyProperty
            = DependencyProperty.Register(
                "DataObject",
                typeof(object),
                typeof(DataDatePicker),
                new PropertyMetadata(null, OnDataObjectChanged));

        /// <summary>
        ///  This is the data object to be saved.
        /// </summary>
        public object DataObject
        {
            get { return GetValue(DataObjectDependencyProperty); }
            set { SetValue(DataObjectDependencyProperty, value); }
        }

        private static void OnDataObjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataDatePicker control = d as DataDatePicker;
            if (control != null)
            {
                var value = ControlExt.GetDataSourcePath(control);
                if (!string.IsNullOrEmpty(value))
                {
                    var obj = ComponentUtils.GetPropValue(control, value);
                    control.DateContent = Convert.ToDateTime(obj);
                }
            }
        }


        #region TextContent Property

        public static readonly DependencyProperty DateContentDependencyProperty =
            DependencyProperty.Register(
                "DateContent",
                typeof(DateTime),
                typeof(DataDatePicker),
                new PropertyMetadata(DateTime.Now, OnDateContentChange));

        /// <summary>
        /// DateContent content of the date.
        /// </summary>
        public DateTime DateContent
        {
            get { return (DateTime) GetValue(DateContentDependencyProperty); }
            set { SetValue(DateContentDependencyProperty, value); }
        }

        private static void OnDateContentChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataDatePicker control = d as DataDatePicker;
            if (control != null)
            {

                var value = ControlExt.GetDataSourcePath(control);
                var obj = ControlExt.GetDataSource(control);
                if (!string.IsNullOrEmpty(value))
                {
                    var date = e.NewValue;
                    if (date is DateTime)
                    {
                        ComponentUtils.SetPropValue(obj, value, date);
                    }
                }
            }
        }

        #endregion

        #region LabelVisible
        /// <summary>
        /// Label visible dependency property. Its default is true. 
        /// </summary>
        public static readonly DependencyProperty LabelVisibleDependencyProperty =
            DependencyProperty.Register("LabelVisible",
                typeof(bool),
                typeof(DataDatePicker),
                new PropertyMetadata(true, OnLabelVisibleChange));
        /// <summary>
        ///  Label visible
        /// </summary>
        public bool LabelVisible
        {
            get { return (bool) GetValue(LabelVisibleDependencyProperty); }
            set { SetValue(LabelVisibleDependencyProperty, value); }
        }

        private static void OnLabelVisibleChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataDatePicker control = d as DataDatePicker;
            if (control != null)
            {
                control.OnLabelVisibleChanged(e);
            }
        }

        private void OnLabelVisibleChanged(DependencyPropertyChangedEventArgs e)
        {
            bool value = Convert.ToBoolean(e.NewValue);
            if (value)
            {
                this.LabelField.Visibility = Visibility.Visible;
            }
            else
            {
                this.LabelField.Visibility = Visibility.Hidden;
            }
        }

        #endregion

        #region LabelText
        /// <summary>
        ///  Label text dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelTextDependencyProperty =
            DependencyProperty.Register(
                "LabelText",
                typeof(string),
                typeof(DataDatePicker),
                new PropertyMetadata(string.Empty, OnLabelTextChange));

        /// <summary>
        ///  Label associated to the data picker
        /// </summary>
        public string LabelText
        {
            get { return (string) GetValue(LabelTextDependencyProperty); }
            set { SetValue(LabelTextDependencyProperty, value); }
        }

        private static void OnLabelTextChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataDatePicker control = d as DataDatePicker;
            if (control != null)
            {
                control.OnLabelTextChanged(e);
            }
        }

        private void OnLabelTextChanged(DependencyPropertyChangedEventArgs e)
        {
            string label = e.NewValue as string;
            this.LabelField.Text = label;
        }

        #endregion

        #region LabelTextWidth 

        public readonly static DependencyProperty LabelTextWidthDependencyProperty =
            DependencyProperty.Register(
                "LabelTextWidth",
                typeof(string),
                typeof(DataDatePicker),
                new PropertyMetadata(string.Empty, OnLabelTextWidthChange));
        /// <summary>
        /// Width of the text
        /// </summary>
        public string LabelTextWidth
        {
            get { return (string) GetValue(LabelTextWidthDependencyProperty); }
            set { SetValue(LabelTextWidthDependencyProperty, value); }
        }

        private static void OnLabelTextWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataDatePicker control = d as DataDatePicker;
            if (control != null)
            {
                control.OnLabelTextWidthChanged(e);
            }
        }

        private void OnLabelTextWidthChanged(DependencyPropertyChangedEventArgs e)
        {
            double value = Convert.ToDouble(e.NewValue);
            LabelField.Width = value;
        }

        #endregion

        #region TextContentWidth
        /// <summary>
        /// Picker content width.
        /// </summary>
        public string PickerContentWidth
        {
            get { return (string) GetValue(PickerContentWidthDependencyProperty); }
            set { SetValue(PickerContentWidthDependencyProperty, value); }
        }
        /// <summary>
        /// Picker content width dependency properties.
        /// </summary>
        public readonly static DependencyProperty PickerContentWidthDependencyProperty =
            DependencyProperty.Register(
                "PickerContentWidth",
                typeof(string),
                typeof(DataDatePicker), new PropertyMetadata(string.Empty, OnPickerContentWidthChange));

        private static void OnPickerContentWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataDatePicker control = d as DataDatePicker;
            if (control != null)
            {
                control.OnPickerContentWidthPropertyChanged(e);
            }
        }

        private void OnPickerContentWidthPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            string tmpValue = e.NewValue as string;
            double valueName = Convert.ToDouble(tmpValue);
            this.DatePicker.Width = valueName;

        }

        #endregion

        /// <summary>
        ///  Height of the picker
        /// </summary>
        public readonly static DependencyProperty DataDatePickerHeightDependencyProperty =
            DependencyProperty.Register(
                "DataDatePickerHeight",
                typeof(string),
                typeof(DataDatePicker),
                new PropertyMetadata("40", OnDataDatePickerHeightChange));

        /// <summary>
        ///  Height of the picker
        /// </summary>
        public string DataDatePickerHeight
        {
            get { return (string) GetValue(DataDatePickerHeightDependencyProperty); }
            set { SetValue(DataDatePickerHeightDependencyProperty, value); }
        }

        private static void OnDataDatePickerHeightChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataDatePicker control = d as DataDatePicker;
            if (control != null)
            {
                control.OnDataDatePickerHeightChanged(e);
            }
        }

        private void OnDataDatePickerHeightChanged(DependencyPropertyChangedEventArgs e)
        {
            double value = Convert.ToDouble(e.NewValue);
            LabelField.Height = value;
            DatePicker.Height = value;
        }

        /// <summary>
        ///  Constructor for the picker.
        /// </summary>
        public DataDatePicker()
        {
            InitializeComponent();
            // right default
            LabelField.Visibility = Visibility.Visible;
            DataPickerContext.DataContext = this;
        }

        private void DatePicker_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            if (DatePicker.SelectedDate != null)
            {
                DataDatePickerEventArgs ev = new DataDatePickerEventArgs(DataDatePickerChangedEvent);
                ev.FieldData = DatePicker.SelectedDate.Value;
                IDictionary<string, object> valueDictionary = new Dictionary<string, object>();
                valueDictionary["DataObject"] = DataObject;
                valueDictionary["ChangedValue"] = DatePicker.SelectedDate.Value;
                ev.ChangedValuesObjects = valueDictionary;
                RaiseEvent(ev);
            }
        }
    }
}
