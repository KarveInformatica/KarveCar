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
using static KarveControls.CommonControl;

namespace KarveControls.DataArea
{
    /// <summary>
    /// Interaction logic for DataArea.xaml
    /// </summary>
    public partial class DataArea : UserControl, INotifyPropertyChanged
    {
        private double _dataAreaWidth;
        private string _dataAreaLabel;
        private string _textValue;
        
        


        public event PropertyChangedEventHandler PropertyChanged;

        protected string _description;
        protected DataType _dataAllowed;
        protected bool _allowedEmpty;
        protected bool _upperCase;
        protected DataTable _itemSource;
        protected string _DataArea = string.Empty;
        protected string _tableName = string.Empty;

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
                typeof(DataArea),
                new PropertyMetadata(String.Empty));
        #endregion
        #region DataAllowed
        public static readonly DependencyProperty DataAllowedDependencyProperty =
            DependencyProperty.Register(
                "DataAllowed",
                typeof(DataType),
                typeof(DataArea),
                new PropertyMetadata(DataType.Any, OnDataAllowedChange));
        public DataType DataAllowed
        {
            get { return (DataType)GetValue(DataAllowedDependencyProperty); }
            set { SetValue(DataAllowedDependencyProperty, value); }
        }
        private static void OnDataAllowedChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataArea control = d as DataArea;
            if (control != null)
            {
                control.OnPropertyChanged("DataAllowed");
                control.OnDataAllowedChange(e);
            }
        }
        protected virtual void OnDataAllowedChange(DependencyPropertyChangedEventArgs e)
        {
            DataType type = (DataType)Enum.Parse(typeof(DataType), e.NewValue.ToString());
            DataAllowed = type;
            _dataAllowed = type;
        }
        #endregion
        #region ItemSource

        public static DependencyProperty ItemSourceDependencyProperty
            = DependencyProperty.Register(
                "ItemSourceDependencyProperty",
                typeof(DataTable),
                typeof(DataArea),
                new PropertyMetadata(new DataTable(), OnItemSourceChanged));

        public DataTable ItemSource
        {
            get { return (DataTable)GetValue(ItemSourceDependencyProperty); }
            set { SetValue(ItemSourceDependencyProperty, value); }
        }
        private static void OnItemSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataArea control = d as DataArea;
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
        }


        #endregion
        #region TableName
        public static readonly DependencyProperty DBTableNameDependencyProperty =
            DependencyProperty.Register(
                "TableName",
                typeof(string),
                typeof(DataArea),
                new PropertyMetadata(string.Empty, OnTableNameChange));
        private static void OnTableNameChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataArea control = d as DataArea;
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
        #region UpperCaseChange

        public static readonly DependencyProperty UpperCaseDependencyProperty =
            DependencyProperty.Register(
                "UpperCase",
                typeof(bool),
                typeof(DataArea),
                new PropertyMetadata(false, OnUpperCaseChange));

        private static void OnUpperCaseChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataArea control = d as DataArea;
            if (control != null)
            {
                control.OnPropertyChanged("UpperCase");
                control.OnUpperCaseChanged(e);
            }
        }
        private void OnUpperCaseChanged(DependencyPropertyChangedEventArgs e)
        {
            bool value = Convert.ToBoolean(e.NewValue);
            if (value)
            {
                EditorText.Text = EditorText.Text.ToUpper();
            }
        }
        public bool UpperCase
        {
            get { return (bool)GetValue(UpperCaseDependencyProperty); }
            set { SetValue(UpperCaseDependencyProperty, value); }
        }
        #endregion
        #region IsReadOnly

        public static readonly DependencyProperty IsReadOnlyDependencyProperty =
            DependencyProperty.Register(
                "IsReadOnly",
                typeof(bool),
                typeof(DataArea),
                new PropertyMetadata(false, IsReadOnlyDependencyPropertyChange));

        private static void IsReadOnlyDependencyPropertyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataArea control = d as DataArea;
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
                this.IsReadOnly=value;
            }
        }

        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyDependencyProperty); }
            set { SetValue(IsReadOnlyDependencyProperty, value); }
        }
        #endregion
        #region DataArea

        public static DependencyProperty DataAreaDependencyProperty =
            DependencyProperty.Register(
                "DataField",
                typeof(string),
                typeof(DataArea),
                new PropertyMetadata(string.Empty, OnDataAreaChanged));

        public string DataField
        {
            get { return (string)GetValue(DataAreaDependencyProperty); }
            set { SetValue(DataAreaDependencyProperty, value); }
        }
        private static void OnDataAreaChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataArea controlDataArea = d as DataArea;
            if (controlDataArea != null)
            {
                controlDataArea.OnPropertyChanged("DataField");
                controlDataArea.OnDataAreaPropertyChanged(e);
            }
        }
        private void OnDataAreaPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            _DataArea = e.NewValue as string;
        }
        #endregion
        #region LabelText
        public static readonly DependencyProperty LabelTextDependencyProperty =
            DependencyProperty.Register(
                "LabelText",
                typeof(string),
                typeof(DataArea),
                new PropertyMetadata(string.Empty, OnLabelTextChange));

        public string LabelText
        {
            get { return (string)GetValue(LabelTextDependencyProperty); }
            set { SetValue(LabelTextDependencyProperty, value); }
        }
        private static void OnLabelTextChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataArea control = d as DataArea;
            if (control != null)
            {
                control.OnPropertyChanged("LabelText");
                control.OnLabelTextChanged(e);
            }
        }

        private void OnLabelTextChanged(DependencyPropertyChangedEventArgs e)
        {
            string value = e.NewValue as string;
            LabelComponent.Content = value;
        }

        #endregion
        #region LabelTextWidth 
        public readonly static DependencyProperty LabelTextWidthDependencyProperty =
            DependencyProperty.Register(
                "LabelTextWidth",
                typeof(string),
                typeof(DataArea),
                new PropertyMetadata(string.Empty, OnLabelTextWidthChange));

        public string LabelTextWidth
        {
            get { return (string)GetValue(LabelTextWidthDependencyProperty); }
            set { SetValue(LabelTextWidthDependencyProperty, value); }
        }
        private static void OnLabelTextWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataArea control = d as DataArea;
            if (control != null)
            {
                control.OnPropertyChanged("LabelTextWidth");
                control.OnLabelTextWidthChanged(e);
            }
        }

        private void OnLabelTextWidthChanged(DependencyPropertyChangedEventArgs e)
        {
            string value = e.NewValue as string;
            DataAreaWidth = Convert.ToDouble(value);
        }
        #endregion
        #region LabelVisible

        public readonly static DependencyProperty LabelVisibleDependencyProperty =
            DependencyProperty.Register(
                "LabelVisible",
                typeof(bool),
                typeof(DataArea),
                new PropertyMetadata(true, OnLabelVisibleChange));

        public bool LabelVisible
        {
            get { return (bool)GetValue(LabelVisibleDependencyProperty); }
            set { SetValue(LabelVisibleDependencyProperty, value); }
        }

        private static void OnLabelVisibleChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataArea control = d as DataArea;
            if (control != null)
            {
                control.OnPropertyChanged("LabelVisible");
                control.OnLabelVisibleChanged(e);
            }
        }

        private void OnLabelVisibleChanged(DependencyPropertyChangedEventArgs e)
        {
            bool isVisible = Convert.ToBoolean(e.NewValue);
            if (isVisible)
            {
                this.LabelComponent.Visibility = Visibility.Visible;
            }
            else
            {
                LabelComponent.Visibility = Visibility.Collapsed;
            }
        }

        #endregion
        #region AllowedEmpty
        public static readonly DependencyProperty AllowedEmptyDependencyProperty =
            DependencyProperty.Register(
                "AllowedEmpty",
                typeof(bool),
                typeof(DataArea),
                new PropertyMetadata(false, OnAllowedEmptyChange));
        public bool AllowedEmpty
        {
            get { return (bool)GetValue(AllowedEmptyDependencyProperty); }
            set { SetValue(AllowedEmptyDependencyProperty, value); }
        }
        private static void OnAllowedEmptyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataArea control = d as DataArea;
            if (control != null)
            {
                control.OnPropertyChanged("AllowedEmpty");
                control.OnAllowedEmptyChange(e);
            }
        }
        #region TextContent Property
        public static readonly DependencyProperty TextContentDependencyProperty =
            DependencyProperty.Register(
                "TextContent",
                typeof(string),
                typeof(DataArea),
                new PropertyMetadata(string.Empty, OnTextContentChange));

        public string TextContent
        {
            get { return (string)GetValue(TextContentDependencyProperty); }
            set { SetValue(TextContentDependencyProperty, value); }
        }
        protected virtual void OnAllowedEmptyChange(DependencyPropertyChangedEventArgs e)
        {
            _allowedEmpty = Convert.ToBoolean(e.NewValue);

        }

        public void SetDynamicBinding(ref DataTable dta, IList<ValidationRule> rules)
        {
            string field = DataField;
            if (!string.IsNullOrEmpty(field))
            {
                Binding oBind = new Binding("Text");
                oBind.Source = dta.Columns[field];
                oBind.Mode = BindingMode.TwoWay;
                oBind.ValidatesOnDataErrors = true;
                oBind.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                if (rules != null)
                {
                    foreach (ValidationRule rule in rules)
                    {
                        oBind.ValidationRules.Add(rule);
                    }
                }
               EditorText.DropDownWidth = dta.Columns[field].MaxLength;
               EditorText.SetBinding(DataArea.TextContentDependencyProperty, oBind);
            }
        }

        private static void OnTextContentChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataArea control = d as DataArea;
            if (control != null)
            {
                control.OnPropertyChanged("TextContent");
                control.OnTextContentPropertyChanged(e);
            }
        }

        private void OnTextContentPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            string value = e.NewValue as string;
            this.EditorText.Text = value;
        }
        #endregion

        #endregion

        public DataArea()
        {
            InitializeComponent();
            this.DataAreaLayout.DataContext = this;
        }

        public double DataAreaWidth
        {
            get { return _dataAreaWidth; }
            set
            {
             _dataAreaWidth = value;
             EditorText.Width = _dataAreaWidth;
            }
        }

        public string DataAreaLabel
        {
            get
            {
                return _dataAreaLabel;
            }
            set
            {
                _dataAreaLabel = value;
                 LabelComponent.Content = value;
            }
        }

        public string TextValue
        {
            get
            {
                return _textValue;
                
            }
            set
            {
                _textValue = value;
                EditorText.Text = value;
            }
            
        }
       
    }
}
