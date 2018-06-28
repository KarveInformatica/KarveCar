using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using KarveControls.Generic;
using SelectionChangedEventArgs = System.Windows.Controls.SelectionChangedEventArgs;
using System.Windows.Input;
using KarveCommon;
using Syncfusion.Windows.Controls.Input;
using Syncfusion.Windows.Shared;

namespace KarveControls
{

    /// <summary>
    /// Custom control for the date picker that support item changed command.
    /// </summary>
    [TemplatePart(Name = "PART_LabelText", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_DatePicker", Type = typeof(DateTimeEdit))]

    public class DataDatePicker : DatePicker
    {
        private DateTime? previousDate = DateTime.Now;
        private TextBlock _labelText = null;
        private DateTimeEdit _datePicker = null;

        /// <summary>
        /// ItemCommand changed event
        /// </summary>
        public static readonly RoutedEvent ItemCommandChangedEvent =
            EventManager.RegisterRoutedEvent(
                "ItemChangedCommand",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(DataDatePicker));


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
            add => AddHandler(DataDatePickerChangedEvent, value);
            remove => RemoveHandler(DataDatePickerChangedEvent, value);
        }

        /// <summary>
        /// Data Object dependency property.
        /// </summary>
        public static DependencyProperty ItemChangedCommandDependencyProperty
            = DependencyProperty.Register(
                "ItemChangedCommand",
                typeof(ICommand),
                typeof(DataDatePicker),
                new PropertyMetadata(null, OnDataObjectChanged));

        /// <summary>
        ///  This is the data object to be saved.
        /// </summary>
        public ICommand ItemChangedCommand
        {
            get => (ICommand)GetValue(ItemChangedCommandDependencyProperty);
            set => SetValue(ItemChangedCommandDependencyProperty, value);
        }

        /// <summary>
        ///  This is the data object to be saved.
        /// </summary>
        public object DataObject
        {
            get => GetValue(DataObjectDependencyProperty);
            set => SetValue(DataObjectDependencyProperty, value);
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

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _labelText = GetTemplateChild("PART_LabelText") as TextBlock;
            _datePicker = GetTemplateChild("PART_DatePicker") as DateTimeEdit;
            if (_labelText != null)
            {
                _labelText.Visibility = Visibility.Visible;
            }
            if (_datePicker != null)
            {
                _datePicker.DateTimeChanged += _datePicker_SelectedDateChanged;
            }

        }

        private void SetValueDo(object dataObject, string value)
        {
            ComponentUtils.SetPropValue(dataObject, value, _datePicker.DateTime);
        }

        private void _datePicker_SelectedDateChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            if (_datePicker == null)
                return;
            var value = ControlExt.GetDataSourcePath(this);
            var dataObject = ControlExt.GetDataSource(this);
            if (_datePicker.DateTime != null && previousDate == (DateTime)_datePicker.DateTime)
            {
                return;
            }

            if (_datePicker.DateTime != null)
            {
                // If we have a data source path we do the binding manually.
                if ((!string.IsNullOrEmpty(value) && (dataObject != null)))
                {
                    SetValueDo(dataObject, value);
                    DataObject = dataObject;
                }

                if (_datePicker.DateTime != null)
                {
                    DataDatePickerEventArgs ev = new DataDatePickerEventArgs(DataDatePickerChangedEvent)
                    {
                    
                        FieldData = _datePicker.DateTime.Value
                    };
                    IDictionary<string, object> valueDictionary = new Dictionary<string, object>
                    {
                        ["Field"] = value,
                        ["DataObject"] = DataObject,
                        ["ChangedValue"] = (DateTime) _datePicker.DateTime,
                        ["PreviousValue"] = previousDate
                    };
                    previousDate = (DateTime) _datePicker.DateTime;
                    ev.ChangedValuesObjects = valueDictionary;
                    RaiseEvent(ev);
                    HandleCommandItemChanged(valueDictionary);
                }
            }

        }

        private void HandleCommandItemChanged(IDictionary<string, object> valueDictionary)
        {
            ICommand command = ItemChangedCommand;
            if (command != null)
            {

                command.Execute(valueDictionary);

            }


        }

        private static void OnDataObjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataDatePicker control = d as DataDatePicker;
            if (control != null)
            {
                var value = ControlExt.GetDataSourcePath(control);
                var dataObject = ControlExt.GetDataSource(control);
                if (!string.IsNullOrEmpty(value))
                {
                    var obj = ComponentUtils.GetPropValue(dataObject, value);
                    if (obj != null)
                    {
                        control.DateContent = Convert.ToDateTime(obj);
                    }
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
            var currentValue = (DateTime) e.NewValue;
            if (currentValue == DateTime.MinValue)
            {
                return;
            }
            if (control != null)
            {

                var value = ControlExt.GetDataSourcePath(control);
                if (value != null)
                {
                    var obj = ControlExt.GetDataSource(control);
                    if (obj != null)
                    {
                        if (string.IsNullOrEmpty(value))
                        {
                            return;
                        }
                        var date = e.NewValue;
                        ComponentUtils.SetPropValue(obj, value, date);
                               
                        //  control.SetDate((DateTime)date);
                    }
                }
            }
        }



        #endregion
        #region PickerWidth
        public readonly static DependencyProperty PickerWidthDependencyProperty =
            DependencyProperty.Register(
                "PickerWidth",
                typeof(double),
                typeof(DataDatePicker),
                new PropertyMetadata(150d));

        /// <summary>
        /// PickerWidth 
        /// </summary>
        public double PickerWidth
        {
            get { return (double)GetValue(PickerWidthDependencyProperty); }
            set { SetValue(PickerWidthDependencyProperty, value); }
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
            if (_labelText == null)
                return;
            if (value)
            {

                _labelText.Visibility = Visibility.Visible;
            }
            else
            {
                _labelText.Visibility = Visibility.Collapsed;
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
            if (_labelText != null)
            {
                _labelText.Text = label;
            }
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
            try
            {
                var value = Convert.ToDouble(e.NewValue);
                if (_labelText != null)
                {
                    _labelText.Width = value;
                }
            }
            catch (Exception exception)
            {
                // in this case the parsing is not correct.
            }
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
            double value = Convert.ToDouble(tmpValue);
            if (_datePicker != null)
            {
                _datePicker.Width = value;
            }
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
                new PropertyMetadata("25", OnDataDatePickerHeightChange));

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
            if (_labelText != null)
            {
                _labelText.Height = value;
            }
            if (_datePicker != null)
            {
                _datePicker.Height = value;
            }
        }

        /// <summary>
        ///  Constructor for the picker.
        /// </summary>
        public DataDatePicker() : base()
        {
        }
        static DataDatePicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DataDatePicker), new FrameworkPropertyMetadata(typeof(DataDatePicker)));
        }
    }
}