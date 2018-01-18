using System;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static KarveControls.ControlExt;

namespace KarveControls
{
    /// <summary>
    /// Interaction logic for DualDataField.xaml
    /// </summary>
    public partial class DualDataField : UserControl
    {

        private string _description;
        private string _tableName;
        private DataType _dataAllowed;
        private DataType _dataAllowedFirst;
        private DataType _dataAllowedSecond;
        private bool _allowedEmpty;
        private bool _upperCase;
        private DataTable _itemSource;

        public static readonly DependencyProperty DescriptionDependencyProperty =
            DependencyProperty.Register(
                "Description",
                typeof(string),
                typeof(DualDataField),
                new PropertyMetadata(String.Empty, OnDescriptionChange));

        public static readonly DependencyProperty DataAllowedDependencyProperty =
            DependencyProperty.Register(
                "DataAllowed",
                typeof(DataType),
                typeof(DualDataField),
                new PropertyMetadata(DataType.Any, OnDataAllowedChange));

        public static readonly DependencyProperty AllowedEmptyDependencyProperty =
            DependencyProperty.Register(
                "AllowedEmpty",
                typeof(bool),
                typeof(DualDataField),
                new PropertyMetadata(false, OnAllowedEmptyChange));

        public static readonly DependencyProperty ItemSourceDependencyProperty =
            DependencyProperty.Register(
                "ItemSource",
                typeof(DataTable),
                typeof(DualDataField),
                new PropertyMetadata(new DataTable(), OnItemSourceChanged));

        public static readonly DependencyProperty UpperCaseDependencyProperty =
            DependencyProperty.Register(
                "UpperCase",
                typeof(bool),
                typeof(DualDataField),
                new PropertyMetadata(false, OnUpperCaseChange));


        public static readonly DependencyProperty TableNameDependencyProperty =
            DependencyProperty.Register(
                "TableName",
                typeof(string),
                typeof(DualDataField),
                new PropertyMetadata(string.Empty, OnTableNameChange));

        public static readonly DependencyProperty DataFieldFirstDependencyProperty =
            DependencyProperty.Register(
                "DataFieldFirst",
                typeof(string),
                typeof(DualDataField),
                new PropertyMetadata(string.Empty, OnDataFieldFirstChange));


        public static readonly DependencyProperty TextContentFirstWidthDependencyProperty =
            DependencyProperty.Register(
                "TextContentFirstWidth",
                typeof(string),
                typeof(DualDataField),
                new PropertyMetadata(string.Empty, OnDataFieldWidthFirstChange));

        public static readonly DependencyProperty TextContentSecondWidthDependencyProperty =
            DependencyProperty.Register(
                "TextContentSecondWidth",
                typeof(string),
                typeof(DualDataField),
                new PropertyMetadata(string.Empty, OnDataFieldWidthSecondChange));

      
        
        public static readonly DependencyProperty IsReadOnlyFirstDependencyProperty =
            DependencyProperty.Register(
                "IsReadOnlyFirst",
                typeof(bool),
                typeof(DualDataField),
                new PropertyMetadata(false, OnIsReadOnlyFirstProperty));
      
        private static void OnIsReadOnlyFirstProperty(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualDataField dualFieldSearchBox = d as DualDataField;
            if (dualFieldSearchBox != null)
            {
                dualFieldSearchBox.OnPropertyChanged("IsReadOnlyFirst");
                dualFieldSearchBox.OnReadOnlySet(e, true);
            }
        }
        private static void OnIsReadOnlySecondProperty(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualDataField dualFieldSearchBox = d as DualDataField;
            if (dualFieldSearchBox != null)
            {
                dualFieldSearchBox.OnPropertyChanged("IsReadOnlySecond");
                dualFieldSearchBox.OnReadOnlySet(e, false);
            }
        }
        private void OnReadOnlySet(DependencyPropertyChangedEventArgs e, bool eventReadOnly)
        {
            bool value = Convert.ToBoolean(e.NewValue);
            if (eventReadOnly)
            { 
                TextFieldFirst.IsReadOnly = value;
            }
            else
            {
                TextFieldFirst.IsReadOnly = value;
            }
        }
        private static void OnDataFieldWidthFirstChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualDataField dualDataField = d as DualDataField;
            dualDataField.OnPropertyChanged("TextContentFirstWidth");
            dualDataField.OnChangeDataFieldWidth(true, e);
        }

        private void OnChangeDataFieldWidth(bool currentValue, DependencyPropertyChangedEventArgs e)
        {
            string value = e.NewValue as string;
            double dataValue = Convert.ToDouble(value);
            if (currentValue)
            {
                TextFieldFirst.Width = dataValue;
            }
            else
            {
                TextFieldSecond.Width = dataValue;
            }
        }

        private static void OnDataFieldWidthSecondChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualDataField dualDataField = d as DualDataField;
            dualDataField.OnPropertyChanged("TextContentSecondWidth");
            dualDataField.OnChangeDataFieldWidth(false, e);
        }

        public static readonly DependencyProperty DataFieldSecondDependencyProperty =
            DependencyProperty.Register(
                "DataFieldSecond",
                typeof(string),
                typeof(DualDataField),
                new PropertyMetadata(string.Empty, OnDataFieldSecondChange));





        public static readonly DependencyProperty DataAllowedFirstDependencyProperty =
            DependencyProperty.Register(
                "DataAllowedFirst",
                typeof(DataType),
                typeof(DualDataField),
                new PropertyMetadata(DataType.Any, OnDataAllowedFirstChange));

      
        public static readonly DependencyProperty DataAllowedSecondDependencyProperty =
            DependencyProperty.Register(
                "DataAllowedSecond",
                typeof(DataType),
                typeof(DualDataField),
                new PropertyMetadata(DataType.Any, OnDataAllowedSecondChange));


   

        public static readonly DependencyProperty IsReadOnlySecondDependencyProperty =
            DependencyProperty.Register(
                "IsReadOnlySeocnd",
                typeof(bool),
                typeof(DualDataField),
                new PropertyMetadata(false, OnIsReadOnlySecondProperty));

       
        public static readonly DependencyProperty LabelVisibleDependencyProperty =
            DependencyProperty.Register("LabelVisible",
                typeof(bool),
                typeof(DualDataField),
                new PropertyMetadata(false, OnLabelVisibleChange));

        public static readonly DependencyProperty LabelTextDependencyProperty =
            DependencyProperty.Register(
                "LabelText",
                typeof(string),
                typeof(DualDataField),
                new PropertyMetadata(string.Empty, OnLabelTextChange));

        public readonly static DependencyProperty LabelTextWidthDependencyProperty =
            DependencyProperty.Register(
                "LabelTextWidth",
                typeof(string),
                typeof(DualDataField),
                new PropertyMetadata(string.Empty, OnLabelTextWidthChange));


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }



        #region DataAllowedFirstChange
        private static void OnDataAllowedFirstChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualDataField control = d as DualDataField;
            control.OnPropertyChanged("DataAllowedFirst");
            control.DataAllowedChange(true, e);
        }
        #endregion

        #region DataAllowedSecondChange
        private static void OnDataAllowedSecondChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualDataField control = d as DualDataField;
            control.OnPropertyChanged("DataAllowedSecond");
            control.DataAllowedChange(false, e);
        }
        #endregion

        private void DataAllowedChange(bool name, DependencyPropertyChangedEventArgs e)
        {
            DataType dataType = (DataType)Enum.Parse(typeof(DataType), e.NewValue.ToString());

            if (name)
            {
                _dataAllowedFirst = dataType;
            }
            else
            {
                _dataAllowedSecond = dataType;
            }
        }
        public DataType DataAllowedFirst
        {
            get { return (DataType)GetValue(DataAllowedFirstDependencyProperty); }
            set { SetValue(DataAllowedFirstDependencyProperty, value); }
        }

        public DataType DataAllowedSecond
        {
            get { return (DataType)GetValue(DataAllowedSecondDependencyProperty); }
            set { SetValue(DataAllowedSecondDependencyProperty, value); }
        }

        public DataType IsReadOnlyFirst
        {
            get { return (DataType)GetValue(IsReadOnlyFirstDependencyProperty); }
            set { SetValue(IsReadOnlyFirstDependencyProperty, value); }
        }

        public DataType IsReadOnlySecond
        {
            get { return (DataType)GetValue(IsReadOnlySecondDependencyProperty); }
            set { SetValue(IsReadOnlySecondDependencyProperty, value); }
        }



        public string TextContentFirstWidth
        {
            get { return (string)GetValue(TextContentFirstWidthDependencyProperty); }
            set { SetValue(TextContentFirstWidthDependencyProperty, value); }
        }

        public string TextContentSecondWidth
        {
            get { return (string)GetValue(TextContentSecondWidthDependencyProperty); }
            set { SetValue(TextContentSecondWidthDependencyProperty, value); }
        }
        #region Description Property

        public string Description
        {
            get { return (string)GetValue(DescriptionDependencyProperty); }
            set { SetValue(DescriptionDependencyProperty, value); }
        }

        private static void OnDescriptionChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualDataField control = d as DualDataField;
            if (control != null)
            {
                control.OnPropertyChanged("Description");
                control.OnDescriptionPropertyChanged(e);
            }
        }

        private void OnDescriptionPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            string value = e.NewValue as string;

            _description = value;
        }

        #endregion

        #region DataAllowed Property

        public DataType DataAllowed
        {
            get { return (DataType)GetValue(DataAllowedDependencyProperty); }
            set { SetValue(DescriptionDependencyProperty, value); }
        }

        private static void OnDataAllowedChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualDataField control = d as DualDataField;
            if (control != null)
            {
                control.OnPropertyChanged("DataAllowed");
                control.OnDataAllowedChange(e);
            }
        }

        private void OnDataAllowedChange(DependencyPropertyChangedEventArgs e)
        {
            DataType type = (DataType)Enum.Parse(typeof(DataType), e.NewValue.ToString());
            _dataAllowed = type;
        }

        #endregion

        #region AllowedEmptyChanged Property

        public bool AllowedEmpty
        {
            get { return (bool)GetValue(AllowedEmptyDependencyProperty); }
            set { SetValue(AllowedEmptyDependencyProperty, value); }
        }

        private static void OnAllowedEmptyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualDataField control = d as DualDataField;
            if (control != null)
            {
                control.OnPropertyChanged("AllowedEmpty");
                control.OnAllowedEmptyChange(e);
            }

        }

        private void OnAllowedEmptyChange(DependencyPropertyChangedEventArgs e)
        {
            _allowedEmpty = Convert.ToBoolean(e.NewValue);

        }

        #endregion

        #region ItemSource

        public DataTable ItemSource
        {
            get { return (DataTable)GetValue(ItemSourceDependencyProperty); }
            set { SetValue(ItemSourceDependencyProperty, value); }
        }

        private static void OnItemSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualDataField control = d as DualDataField;
            if (control != null)
            {
                control.OnPropertyChanged("ItemSource");
                control.OnItemSourceChanged(e);
            }
        }

        private void OnItemSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            DataTable table = e.NewValue as DataTable;
            this._itemSource = table;
        }

        #endregion

        #region TableName

        private static void OnTableNameChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualDataField control = d as DualDataField;
            if (control != null)
            {
                control.OnPropertyChanged("TableName");
                control.OnTableNameChanged(e);
            }
        }

        public string TableName
        {
            get { return (string)GetValue(TableNameDependencyProperty); }
            set { SetValue(TableNameDependencyProperty, value); }
        }

        private void OnTableNameChanged(DependencyPropertyChangedEventArgs e)
        {
            _tableName = e.NewValue as string;
        }

        #endregion

        #region UpperCase

        private static void OnUpperCaseChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualDataField control = d as DualDataField;
            if (control != null)
            {
                control.OnPropertyChanged("UpperCase");
                control.OnUpperCaseChanged(e);
            }
        }

        public bool UpperCase
        {
            get { return (bool)GetValue(UpperCaseDependencyProperty); }
            set { SetValue(UpperCaseDependencyProperty, value); }
        }

        private void OnUpperCaseChanged(DependencyPropertyChangedEventArgs e)
        {
            this._upperCase = Convert.ToBoolean(e.NewValue);
            if (_upperCase)
            {
                TextFieldFirst.Text = TextFieldFirst.Text.ToUpper();
                TextFieldSecond.Text = TextFieldFirst.Text.ToUpper();
            }
        }

        #endregion

        #region DataFieldFirst Property
        public string DataFieldFirst
        {
            get { return (string)GetValue(DataFieldFirstDependencyProperty); }
            set { SetValue(DataFieldFirstDependencyProperty, value); }
        }

        private static void OnDataFieldFirstChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualDataField control = d as DualDataField;
            if (control != null)
            {
                control.OnPropertyChanged("DataFieldFirst");
                control.OnDataFieldFirstPropertyChanged(e);
            }
        }

        private void OnDataFieldFirstPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            string value = e.NewValue as string;
            TextFieldFirst.Text = value;

        }
        #endregion

        #region LabelVisible
        public bool LabelVisible
        {
            get { return (bool)GetValue(LabelVisibleDependencyProperty); }
            set { SetValue(LabelVisibleDependencyProperty, value); }
        }

        private static void OnLabelVisibleChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualDataField control = d as DualDataField;
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

        public string LabelText
        {
            get { return (string)GetValue(LabelTextDependencyProperty); }
            set { SetValue(LabelTextDependencyProperty, value); }
        }

        private static void OnLabelTextChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualDataField control = d as DualDataField;
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


        public string LabelTextWidth
        {
            get { return (string)GetValue(LabelTextWidthDependencyProperty); }
            set { SetValue(LabelTextWidthDependencyProperty, value); }
        }

        private static void OnLabelTextWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualDataField control = d as DualDataField;
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


        #region DataFieldSecond Property


        public string DataFieldSecond
        {
            get { return (string)GetValue(DataFieldSecondDependencyProperty); }
            set { SetValue(DataFieldSecondDependencyProperty, value); }
        }

        private static void OnDataFieldSecondChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualDataField control = d as DualDataField;
            if (control != null)
            {
                control.OnPropertyChanged("DataFieldSecond");
                control.OnDataFieldSecondPropertyChanged(e);
            }
        }

        private void OnDataFieldSecondPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            string value = e.NewValue as string;
            TextFieldSecond.Text = value;
        }
        #endregion
        private static void OnDataFieldIsReadonlyFirst(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualDataField control = d as DualDataField;
            if (control != null)
            {
                control.OnPropertyChanged("IsReadonlyFirst");
                control.OnDataFieldSecondPropertyChanged(e);
            }
            
        }
        private static void OnDataFieldIsReadonlySecond(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualDataField control = d as DualDataField;
            if (control != null)
            {
                control.OnPropertyChanged("IsReadonlySecond");
                control.OnDataFieldSecondPropertyChanged(e);
            }
        }

        #region Events

        public static readonly RoutedEvent DataFieldsChangedEvent =
            EventManager.RegisterRoutedEvent(
                "DataFieldsChanged",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(DualDataField));
        private bool textContentFirstChanged = false;
        private bool textContentSecondChanged = false;

        public class DataFieldsEventArgs : RoutedEventArgs
        {
            private string _fieldData1 = "";
            private string _fieldData2 = "";

            public string FirstFieldData
            {
                get { return _fieldData1; }
                set { _fieldData1 = value; }
            }

            public string SecondFieldData
            {
                get { return _fieldData2; }
                set { _fieldData2 = value; }
            }

            public DataFieldsEventArgs() : base()
            {

            }

            public DataFieldsEventArgs(RoutedEvent routedEvent) : base(routedEvent)
            {

            }
        }


        public event RoutedEventHandler DataFieldsChanged
        {
            add { AddHandler(DataFieldsChangedEvent, value); }
            remove { RemoveHandler(DataFieldsChangedEvent, value); }
        }
        #endregion

        public DualDataField()
        {
            InitializeComponent();
            LostFocus += DualDataField_LostFocus;
            TextFieldFirst.TextChanged += TextFieldFirstOnTextChanged;
            TextFieldSecond.TextChanged += TextFieldSecondOnTextChanged;
        }

        private void TextFieldFirstOnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            textContentFirstChanged = true;
            RaiseEvent(textChangedEventArgs);
        }
        private void TextFieldSecondOnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            textContentSecondChanged = true;
            RaiseEvent(textChangedEventArgs);
        }
        private void DualDataField_LostFocus(object sender, RoutedEventArgs e)
        {
            DataFieldsEventArgs args = new DataFieldsEventArgs(DataFieldsChangedEvent);
            if (textContentFirstChanged || textContentSecondChanged)
            {
                args.FirstFieldData = DataFieldFirst;
                args.SecondFieldData = DataFieldSecond;
                RaiseEvent(args);
            }

        }
    }
}
