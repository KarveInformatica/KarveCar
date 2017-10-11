using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KarveControls.Generic;
using Telerik.Pivot.Core.Fields;
using static KarveControls.CommonControl;

namespace KarveControls
{
    /// <summary>
    /// Interaction logic for DataDetiPicker.xaml
    /// </summary>
    public partial class DataDatePicker : UserControl
    {
        public static readonly RoutedEvent DataDatePickerChangedEvent =
            EventManager.RegisterRoutedEvent(
                "DataDatePickerChanged",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(DataDatePicker));


        public class DataDatePickerEventArgs : RoutedEventArgs
        {
            private DateTime _fieldData =  new DateTime();
            private IDictionary<string, object> _changedValues = new Dictionary<string, object>();

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

            public DataDatePickerEventArgs() : base()
            {

            }

            public DataDatePickerEventArgs(RoutedEvent routedEvent) : base(routedEvent)
            {

            }
        }

        public event RoutedEventHandler DataDatePickerChanged
        {
            add { AddHandler(DataDatePickerChangedEvent, value); }
            remove { RemoveHandler(DataDatePickerChangedEvent, value); }
        }

        #region CommonPart

        public event PropertyChangedEventHandler PropertyChanged;

        private string _description;
        private bool _upperCase;
        private DataTable _itemSource;
        private string _DataDatePicker = string.Empty;
        private string _tableName = string.Empty;
        private bool _dataContextChanged = false;
        private bool _allowedEmpty = false;
        private DataType _dataAllowed;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region Description

        public static readonly DependencyProperty DescriptionDependencyProperty =
            DependencyProperty.Register(
                "Description",
                typeof(string),
                typeof(DataDatePicker),
                new PropertyMetadata(String.Empty));

        #endregion

        #region DataAllowed

        public static readonly DependencyProperty DataAllowedDependencyProperty =
            DependencyProperty.Register(
                "DataAllowed",
                typeof(DataType),
                typeof(DataDatePicker),
                new PropertyMetadata(DataType.DateTime, OnDataAllowedChange));

        public DataType DataAllowed
        {
            get { return (DataType) GetValue(DataAllowedDependencyProperty); }
            set { SetValue(DataAllowedDependencyProperty, value); }
        }

        private static void OnDataAllowedChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataDatePicker control = d as DataDatePicker;
            if (control != null)
            {
                control.OnPropertyChanged("DataAllowed");
                control.OnDataAllowedChange(e);
            }
        }

        protected virtual void OnDataAllowedChange(DependencyPropertyChangedEventArgs e)
        {
            DataType type = (DataType) Enum.Parse(typeof(DataType), e.NewValue.ToString());
            _dataAllowed = type;
        }

        #endregion

        #region ItemSource

        public static DependencyProperty ItemSourceDependencyProperty
            = DependencyProperty.Register(
                "ItemSource",
                typeof(DataTable),
                typeof(DataDatePicker),
                new PropertyMetadata(new DataTable(), OnItemSourceChanged));

        public DataTable ItemSource
        {
            get { return (DataTable) GetValue(ItemSourceDependencyProperty); }
            set { SetValue(ItemSourceDependencyProperty, value); }
        }

        private static void OnItemSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataDatePicker control = d as DataDatePicker;
            if (control != null)
            {
                control.OnPropertyChanged("ItemSource");
                control.OnItemSourceChanged(e);
            }
        }


        protected virtual void OnItemSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            DataTable table = e.NewValue as DataTable;
          
            _itemSource = table;
            if (!string.IsNullOrEmpty(DataField))
            {
                if (table != null)
                {
                    DataColumnCollection collection = table.Columns;
                    if (collection.Contains(DataField))
                    {
                        DataRow dataRow = table.Rows[0];
                        object currentValue = dataRow[DataField];
                        if (!DBNull.Value.Equals(currentValue))
                        {

                            DateTime dt = DateTime.Parse(currentValue.ToString());
                            DatePicker.SelectedDate = dt;

                        }
                    }
                }
            }
        }

        #endregion

        #region TableName

        public static readonly DependencyProperty DBTableNameDependencyProperty =
            DependencyProperty.Register(
                "TableName",
                typeof(string),
                typeof(DataDatePicker),
                new PropertyMetadata(string.Empty, OnTableNameChange));

        private static void OnTableNameChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataDatePicker control = d as DataDatePicker;
            if (control != null)
            {
                control.OnPropertyChanged("TableName");
                control.OnTableNameChanged(e);
            }
        }

        public string TableName
        {
            get { return (string) GetValue(DBTableNameDependencyProperty); }
            set { SetValue(DBTableNameDependencyProperty, value); }
        }

        protected virtual void OnTableNameChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is string)
            {
                _tableName = e.NewValue as string;
            }
        }

        #endregion

        #region DataDatePicker

        public static DependencyProperty DataDatePickerDependencyProperty =
            DependencyProperty.Register(
                "DataField",
                typeof(string),
                typeof(DataDatePicker),
                new PropertyMetadata(string.Empty, OnDataFieldChanged));

        public string DataField
        {
            get { return (string) GetValue(DataDatePickerDependencyProperty); }
            set { SetValue(DataDatePickerDependencyProperty, value); }
        }

        private static void OnDataFieldChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataDatePicker controlDataRadio = d as DataDatePicker;
            if (controlDataRadio != null)
            {
                controlDataRadio.OnPropertyChanged("DataField");
                controlDataRadio.OnDataFieldPropertyChanged(e);
            }
        }

        private void OnDataFieldPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            _DataDatePicker = e.NewValue as string;
            if (this._itemSource != null)
            {
                if (!string.IsNullOrEmpty(_DataDatePicker))
                {
                    DataColumnCollection collection = _itemSource.Columns;
                    if (collection.Contains(_DataDatePicker))
                    {

                        DataRow dataRow = _itemSource.Rows[0];
                        object currentValue = dataRow[DataField];
                        if (!DBNull.Value.Equals(currentValue))
                        {

                            DateTime dt = DateTime.Parse(currentValue.ToString());
                            DatePicker.SelectedDate = dt.Date;

                        }
                    }

                }


            }
        }

        #endregion

        #endregion

        #region AllowedEmpty

        public static readonly DependencyProperty AllowedEmptyDependencyProperty =
            DependencyProperty.Register(
                "AllowedEmpty",
                typeof(bool),
                typeof(DataDatePicker),
                new PropertyMetadata(false, OnAllowedEmptyChange));

        public bool AllowedEmpty
        {
            get { return (bool) GetValue(AllowedEmptyDependencyProperty); }
            set { SetValue(AllowedEmptyDependencyProperty, value); }
        }

        private static void OnAllowedEmptyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataDatePicker control = d as DataDatePicker;
            if (control != null)
            {
                control.OnPropertyChanged("AllowedEmpty");
                control.OnAllowedEmptyChange(e);
            }
        }

        private void OnAllowedEmptyChange(DependencyPropertyChangedEventArgs e)
        {
            bool value = Convert.ToBoolean(e.NewValue);
            _allowedEmpty = value;
        }

        #endregion

        #region TextContent Property

        public static readonly DependencyProperty DateContentDependencyProperty =
            DependencyProperty.Register(
                "DateContent",
                typeof(DateTime),
                typeof(DataDatePicker),
                new PropertyMetadata(DateTime.Now, OnDateContentChange));

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
                control.OnPropertyChanged("DateContent");
                control.OnDateContentPropertyChanged(e);
            }
        }

        

    private void OnDateContentPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
        object tmpValue = e.NewValue;
        DateTime currentDateTime;
        bool isDateTime = false;
   
        if ((e.NewValue!=null) && (tmpValue.GetType() == typeof(DateTime)))
        {
            isDateTime = true;
        }
         
        if ((_itemSource != null) && (!String.IsNullOrEmpty(this._DataDatePicker)))
        {
            if (isDateTime)
            {
                currentDateTime = (DateTime)e.NewValue;
                if (_itemSource.Rows.Count > 0)
                {
                    _itemSource.Rows[0][_DataDatePicker] = currentDateTime.ToString("yyyy-MM-dd");
                }
                
                        
            }
        }
    }
    #endregion
    #region LabelVisible

    public static readonly DependencyProperty LabelVisibleDependencyProperty =
        DependencyProperty.Register("LabelVisible",
            typeof(bool),
            typeof(DataDatePicker),
            new PropertyMetadata(false, OnLabelVisibleChange));

    public bool LabelVisible
    {
        get { return (bool)GetValue(LabelVisibleDependencyProperty); }
        set { SetValue(LabelVisibleDependencyProperty, value); }
    }

    private static void OnLabelVisibleChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        DataDatePicker control = d as DataDatePicker;
        if (control != null)
        {
            control.OnPropertyChanged("LabelVisible");
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
    public static readonly DependencyProperty LabelTextDependencyProperty =
        DependencyProperty.Register(
            "LabelText",
            typeof(string),
            typeof(DataDatePicker),
            new PropertyMetadata(string.Empty, OnLabelTextChange));

    public string LabelText
    {
        get { return (string)GetValue(LabelTextDependencyProperty); }
        set { SetValue(LabelTextDependencyProperty, value); }
    }
    private static void OnLabelTextChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        DataDatePicker control = d as DataDatePicker;
        if (control != null)
        {
            control.OnPropertyChanged("LabelText");
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

    public string LabelTextWidth
    {
        get { return (string)GetValue(LabelTextWidthDependencyProperty); }
        set { SetValue(LabelTextWidthDependencyProperty, value); }
    }
    private static void OnLabelTextWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        DataDatePicker control = d as DataDatePicker;
        if (control != null)
        {
            control.OnPropertyChanged("LabelTextWidth");
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

    public string PickerContentWidth
    {
        get { return (string)GetValue(PickerContentWidthDependencyProperty); }
        set { SetValue(PickerContentWidthDependencyProperty, value); }
    }

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
            control.OnPropertyChanged("TextContentWidth");
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


    #region DataDatePickerHeight 
    public readonly static DependencyProperty DataDatePickerHeightDependencyProperty =
        DependencyProperty.Register(
            "DataDatePickerHeight",
            typeof(string),
            typeof(DataDatePicker),
            new PropertyMetadata("40", OnDataDatePickerHeightChange));

    public string DataDatePickerHeight
    {
        get { return (string)GetValue(DataDatePickerHeightDependencyProperty); }
        set { SetValue(DataDatePickerHeightDependencyProperty, value); }
    }
    private static void OnDataDatePickerHeightChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        DataDatePicker control = d as DataDatePicker;
        if (control != null)
        {
            control.OnPropertyChanged("DataDatePickerHeight");
            control.OnDataDatePickerHeightChanged(e);
        }
    }

    private void OnDataDatePickerHeightChanged(DependencyPropertyChangedEventArgs e)
    {
        double value = Convert.ToDouble(e.NewValue);
        LabelField.Height = value;
        DatePicker.Height = value;
    }

    #endregion

    public DataDatePicker()
    {
         InitializeComponent();
         DataPickerContext.DataContext = this;
    }
    private void DatePicker_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
    {

        if (DatePicker.SelectedDate != null)
        {
            DataDatePickerEventArgs ev = new DataDatePickerEventArgs(DataDatePickerChangedEvent);
            ev.FieldData = DatePicker.SelectedDate.Value;
            IDictionary<string, object> valueDictionary = new Dictionary<string, object>();
            valueDictionary["TableName"] = TableName;
            valueDictionary["Field"] = DataField;
            valueDictionary["DataTable"] = ItemSource;
            valueDictionary["ChangedValue"] = DatePicker.SelectedDate.Value;
            ev.ChangedValuesObjects = valueDictionary;
            RaiseEvent(ev);
        }
    }
}
}
