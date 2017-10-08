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

namespace KarveControls
{
    /// <summary>
    /// Interaction logic for DataCheckBox.xaml
    /// </summary>
    public partial class DataFieldCheckBox : UserControl
    {
        public static readonly RoutedEvent DataFieldCheckBoxChangedEvent =
            EventManager.RegisterRoutedEvent(
                "DataFieldCheckBoxChanged",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(DataFieldCheckBox));

        
        public class DataFieldCheckBoxEventArgs : RoutedEventArgs
        {
            private bool _isSelected = false;
            private bool _fieldData = false;
            private IDictionary<string, object> _changedValues = new Dictionary<string, object>();

            public bool FieldData
            {
                get { return _fieldData; }
                set { _fieldData = value; }
            }

            public bool IsSelected
            {
                get { return _isSelected; }
                set { _isSelected = value; }
            }
            public IDictionary<string, object> ChangedValuesObjects
            {
                get { return _changedValues; }
                set { _changedValues = value; }
            }

            public DataFieldCheckBoxEventArgs() : base()
            {

            }

            public DataFieldCheckBoxEventArgs(RoutedEvent routedEvent) : base(routedEvent)
            {

            }
        }

        public event RoutedEventHandler DataFieldCheckBoxChanged
        {
            add { AddHandler(DataFieldCheckBoxChangedEvent, value); }
            remove { RemoveHandler(DataFieldCheckBoxChangedEvent, value); }
        }

        #region CommonPart

        public event PropertyChangedEventHandler PropertyChanged;

        protected string _description;
        protected CommonControl.DataType _dataAllowed;
        protected bool _allowedEmpty;
        protected bool _upperCase;
        protected DataTable _itemSource;
        protected string _dataField = string.Empty;
        protected string _tableName = string.Empty;
        private ComponentFiller _filler = new ComponentFiller();

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
                typeof(DataFieldCheckBox),
                new PropertyMetadata(String.Empty));

        #endregion

        #region DataAllowed

        public static readonly DependencyProperty DataAllowedDependencyProperty =
            DependencyProperty.Register(
                "DataAllowed",
                typeof(CommonControl.DataType),
                typeof(DataFieldCheckBox),
                new PropertyMetadata(CommonControl.DataType.Any, OnDataAllowedChange));

        public CommonControl.DataType DataAllowed
        {
            get { return (CommonControl.DataType)GetValue(DataAllowedDependencyProperty); }
            set { SetValue(DataAllowedDependencyProperty, value); }
        }

        private static void OnDataAllowedChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataFieldCheckBox control = d as DataFieldCheckBox;
            if (control != null)
            {
                control.OnPropertyChanged("DataAllowed");
                control.OnDataAllowedChange(e);
            }
        }

        protected virtual void OnDataAllowedChange(DependencyPropertyChangedEventArgs e)
        {
            CommonControl.DataType type = (CommonControl.DataType)Enum.Parse(typeof(CommonControl.DataType), e.NewValue.ToString());
            DataAllowed = type;
            _dataAllowed = type;
        }

        #endregion

        #region ItemSource

        public static DependencyProperty ItemSourceDependencyProperty
            = DependencyProperty.Register(
                "ItemSource",
                typeof(DataTable),
                typeof(DataFieldCheckBox),
                new PropertyMetadata(new DataTable(), OnItemSourceChanged));

        public DataTable ItemSource
        {
            get { return (DataTable)GetValue(ItemSourceDependencyProperty); }
            set { SetValue(ItemSourceDependencyProperty, value); }
        }

        private static void OnItemSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataFieldCheckBox control = d as DataFieldCheckBox;
            if (control != null)
            {
                control.OnPropertyChanged("ItemSource");
                control.OnItemSourceChanged(e);
            }
        }


        protected virtual void OnItemSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            DataTable table = e.NewValue as DataTable;
            this._itemSource = table;
            if (!string.IsNullOrEmpty(DataField))
            {
                if (table != null)
                {
                    DataColumnCollection collection = table.Columns;
                    if (collection.Contains(DataField))
                    {
                        _filler.FetchFillerCheckBox(_itemSource, DataField, ref CheckBoxField);
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
                typeof(DataFieldCheckBox),
                new PropertyMetadata(string.Empty, OnTableNameChange));
        private static void OnTableNameChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataFieldCheckBox control = d as DataFieldCheckBox;
            if (control != null)
            {
                control.OnPropertyChanged("TableName");
                control.OnTableNameChanged(e);
            }
        }
        public string TableName
        {
            get { return (string)GetValue(DBTableNameDependencyProperty); }
            set { SetValue(DBTableNameDependencyProperty, value); }
        }
        protected virtual void OnTableNameChanged(DependencyPropertyChangedEventArgs e)
        {
            _tableName = e.NewValue as string;
        }
        #endregion
        #region IsChecked
        public static readonly DependencyProperty IsCheckedDependencyProperty =
            DependencyProperty.Register(
                "IsChecked",
                typeof(bool),
                typeof(DataFieldCheckBox),
                new PropertyMetadata(false, IsCheckedDependencyPropertyChange));

        private static void IsCheckedDependencyPropertyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataFieldCheckBox control = d as DataFieldCheckBox;
            if (control != null)
            {
                control.OnPropertyChanged("IsReadOnly");
                control.OnIsCheckedChanged(e);
            }
        }

        private void OnIsCheckedChanged(DependencyPropertyChangedEventArgs e)
        {
            bool value = Convert.ToBoolean(e.NewValue);
            if (value)
            {
                this.CheckBoxField.IsChecked = value;
            }
        }

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedDependencyProperty); }
            set { SetValue(IsCheckedDependencyProperty, value); }
        }
        #endregion
        #region IsReadOnly

        public static readonly DependencyProperty IsReadOnlyDependencyProperty =
            DependencyProperty.Register(
                "IsReadOnly",
                typeof(bool),
                typeof(DataFieldCheckBox),
                new PropertyMetadata(false, IsReadOnlyDependencyPropertyChange));

        private static void IsReadOnlyDependencyPropertyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataFieldCheckBox control = d as DataFieldCheckBox;
            if (control != null)
            {
                control.OnPropertyChanged("IsReadOnly");
                control.OnIsReadOnlyChanged(e);
            }
        }

        private void OnIsReadOnlyChanged(DependencyPropertyChangedEventArgs e)
        {
            bool value = Convert.ToBoolean(e.NewValue);
            if (value)
            {
                this.CheckBoxField.IsEnabled = value;
            }
        }

        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyDependencyProperty); }
            set { SetValue(IsReadOnlyDependencyProperty, value); }
        }
        #endregion
        #region DataField

        public static DependencyProperty DataFieldDependencyProperty =
            DependencyProperty.Register(
                "DataField",
                typeof(string),
                typeof(DataFieldCheckBox),
                new PropertyMetadata(string.Empty, OnDataFieldChanged));

        public string DataField
        {
            get { return (string)GetValue(DataFieldDependencyProperty); }
            set { SetValue(DataFieldDependencyProperty, value); }
        }
        private static void OnDataFieldChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataFieldCheckBox controlDataRadio = d as DataFieldCheckBox;
            if (controlDataRadio != null)
            {
                controlDataRadio.OnPropertyChanged("DataField");
                controlDataRadio.OnDataFieldPropertyChanged(e);
            }
        }
        private void OnDataFieldPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            _dataField = e.NewValue as string;
            if (this._itemSource != null)
            {
                if (!string.IsNullOrEmpty(_dataField))
                {
                    DataColumnCollection collection = _itemSource.Columns;
                    if (collection.Contains(_dataField))
                    {
                        bool value = _filler.FetchFillerCheckBox(_itemSource, _dataField, ref CheckBoxField);
                        CheckBoxField.IsEnabled = value;
                    }
                }
            }
        }
        #endregion
        #endregion     
        #region TextContent Property
        public static readonly DependencyProperty TextContentDependencyProperty =
            DependencyProperty.Register(
                "Content",
                typeof(string),
                typeof(DataFieldCheckBox),
                new PropertyMetadata(string.Empty, OnContentChange));

        public new string Content
        {
            get { return (string)GetValue(TextContentDependencyProperty); }
            set { SetValue(TextContentDependencyProperty, value); }
        }


        private static void OnContentChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataFieldCheckBox control = d as DataFieldCheckBox;
            if (control != null)
            {
                control.OnPropertyChanged("Content");
                control.OnContentPropertyChanged(e);
            }
        }

        private void OnContentPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            object value = e.NewValue;
            if (_itemSource != null)
            {
                if (!string.IsNullOrEmpty(_dataField))
                {
                    this.CheckBoxField.Content = value;
                    this.CheckBoxField.IsEnabled = true;
                }
            }
        }
        #endregion
       
        #region TextContentWidth

        public string TextContentWidth
        {
            get { return (string)GetValue(TextContentWidthDependencyProperty); }
            set { SetValue(TextContentWidthDependencyProperty, value); }
        }

        public readonly static DependencyProperty TextContentWidthDependencyProperty =
            DependencyProperty.Register(
                "TextContentWidth",
                typeof(string),
                typeof(DataFieldCheckBox), new PropertyMetadata(string.Empty, OnTextContentWidthChange));

        private static void OnTextContentWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataFieldCheckBox control = d as DataFieldCheckBox;
            if (control != null)
            {
                control.OnPropertyChanged("TextContentWidth");
                control.OnTextContentWidthPropertyChanged(e);
            }
        }
        private void OnTextContentWidthPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            string tmpValue = e.NewValue as string;
            double valueName = Convert.ToDouble(tmpValue);
            CheckBoxField.Width = valueName;
        }
        #endregion


        #region DataFieldHeight 
        public readonly static DependencyProperty DataFieldHeightDependencyProperty =
            DependencyProperty.Register(
                "DataFieldHeight",
                typeof(string),
                typeof(DataFieldCheckBox),
                new PropertyMetadata("40", OnDataFieldHeightChange));

        public string DataFieldHeight
        {
            get { return (string)GetValue(DataFieldHeightDependencyProperty); }
            set { SetValue(DataFieldHeightDependencyProperty, value); }
        }
        private static void OnDataFieldHeightChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataFieldCheckBox control = d as DataFieldCheckBox;
            if (control != null)
            {
                control.OnPropertyChanged("DataFieldHeight");
                control.OnDataFieldHeightChanged(e);
            }
        }

        private void OnDataFieldHeightChanged(DependencyPropertyChangedEventArgs e)
        {
            double value = Convert.ToDouble(e.NewValue);
            CheckBoxField.Height = value;
        }

        #endregion

        
        public static string CHANGED_VALUE = "ChangedValue";
        public static string FIELD = "Field";
        public static string DATATABLE = "DataTable";
        public static string TABLENAME = "TableName";
        private bool checkBoxIsChecked;
        private bool checkBoxIsChanged;

        public DataFieldCheckBox()
        {
            InitializeComponent();
            CheckBoxField.Checked+=CheckBoxFieldOnChecked;
            CheckBoxField.Unchecked+=CheckBoxFieldOnUnchecked;
            CheckBoxField.GotFocus+=CheckBoxFieldOnGotFocus;
            CheckBoxField.LostFocus+=CheckBoxFieldOnLostFocus;
            this.CheckBoxContent.DataContext = this;
        }

        private void CheckBoxFieldOnLostFocus(object sender, RoutedEventArgs routedEventArgs)
        {
            if (checkBoxIsChanged)
            {
                DataFieldCheckBoxEventArgs ev = new DataFieldCheckBoxEventArgs(DataFieldCheckBoxChangedEvent);
                ev.FieldData = checkBoxIsChecked;
                IDictionary<string, object> valueDictionary = new Dictionary<string, object>();
                valueDictionary["TableName"] = TableName;
                valueDictionary["Field"] = DataField;
                valueDictionary["DataTable"] = ItemSource;
                valueDictionary["ChangedValue"] = checkBoxIsChecked;
                ev.ChangedValuesObjects = valueDictionary;
                RaiseEvent(ev);
            }
        }

        private void CheckBoxFieldOnGotFocus(object sender, RoutedEventArgs routedEventArgs)
        {
            CheckBoxField.Focus();
        }

        private void CheckBoxFieldOnUnchecked(object sender, RoutedEventArgs routedEventArgs)
        {
            checkBoxIsChecked = false;
            checkBoxIsChanged = true;
            RaiseEvent(routedEventArgs);
        }

        private void CheckBoxFieldOnChecked(object sender, RoutedEventArgs routedEventArgs)
        {
            checkBoxIsChecked = true;
            checkBoxIsChanged = true;
            RaiseEvent(routedEventArgs);
        }
    }
}
