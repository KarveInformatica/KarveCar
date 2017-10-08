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
using System.Windows.Input;

namespace KarveControls
{
    public abstract class CommonControl: UserControl, INotifyPropertyChanged
    {
        public enum DataType
        {
            DoubleField, IntegerField, NifField, IbanField, Any,
            Email,
            BankAccount,
            Swift,
            DateTime
        }

        public enum Encoding
        {
            Latin, Utf8
        }       
      
      
        protected object GetPropertyValue(DependencyProperty property)
        {
            return GetValue(property);
        }
        protected virtual void OnAllowedEmptyChange(DependencyPropertyChangedEventArgs e)
        {
            _allowedEmpty = Convert.ToBoolean(e.NewValue);

        }

       
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected string _description;
        protected DataType _dataAllowed;
        protected bool _allowedEmpty;
        protected bool _upperCase;
        protected DataTable _itemSource;
        protected string _CommonControl = string.Empty;
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
                typeof(CommonControl),
                new PropertyMetadata(String.Empty));
        #endregion
        #region DataAllowed
        public static readonly DependencyProperty DataAllowedDependencyProperty =
            DependencyProperty.Register(
                "DataAllowed",
                typeof(DataType),
                typeof(CommonControl),
                new PropertyMetadata(DataType.Any, OnDataAllowedChange));
        public DataType DataAllowed
        {
            get { return (DataType)GetValue(DataAllowedDependencyProperty); }
            set { SetValue(DataAllowedDependencyProperty, value); }
        }
        private static void OnDataAllowedChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CommonControl control = d as CommonControl;
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
                typeof(CommonControl),
                new PropertyMetadata(new DataTable(), OnItemSourceChanged));

        public DataTable ItemSource
        {
            get { return (DataTable)GetValue(ItemSourceDependencyProperty); }
            set { SetValue(ItemSourceDependencyProperty, value); }
        }
        private static void OnItemSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CommonControl control = d as CommonControl;
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
                typeof(CommonControl),
                new PropertyMetadata(string.Empty, OnTableNameChange));
        private static void OnTableNameChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CommonControl control = d as CommonControl;
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
                typeof(CommonControl),
                new PropertyMetadata(false, OnUpperCaseChange));

        private static void OnUpperCaseChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CommonControl control = d as CommonControl;
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
        #endregion
        #region IsReadOnly

        public static readonly DependencyProperty IsReadOnlyDependencyProperty =
            DependencyProperty.Register(
                "IsReadOnly",
                typeof(bool),
                typeof(CommonControl),
                new PropertyMetadata(false, IsReadOnlyDependencyPropertyChange));

        private static void IsReadOnlyDependencyPropertyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CommonControl control = d as CommonControl;
            if (control != null)
            {
                control.OnPropertyChanged("IsReadOnly");
                control.OnIsReadOnlyChanged(e);
            }
        }

        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyDependencyProperty); }
            set { SetValue(IsReadOnlyDependencyProperty, value); }
        }
        #endregion
        #region CommonControl

        public static DependencyProperty CommonControlDependencyProperty =
            DependencyProperty.Register(
                "DataField",
                typeof(string),
                typeof(CommonControl),
                new PropertyMetadata(string.Empty, OnCommonControlChanged));

        public string DataField
        {
            get { return (string)GetValue(CommonControlDependencyProperty); }
            set { SetValue(CommonControlDependencyProperty, value); }
        }
        private static void OnCommonControlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CommonControl controlDataRadio = d as CommonControl;
            if (controlDataRadio != null)
            {
                controlDataRadio.OnPropertyChanged("DataField");
                controlDataRadio.OnCommonControlPropertyChanged(e);
            }
        }
        private void OnCommonControlPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            _CommonControl = e.NewValue as string;
        }
    #endregion
        #region LabelText
        public static readonly DependencyProperty LabelTextDependencyProperty =
            DependencyProperty.Register(
                "LabelText",
                typeof(string),
                typeof(CommonControl),
                new PropertyMetadata(string.Empty, OnLabelTextChange));

        public string LabelText
        {
            get { return (string)GetValue(LabelTextDependencyProperty); }
            set { SetValue(LabelTextDependencyProperty, value); }
        }
        private static void OnLabelTextChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CommonControl control = d as CommonControl;
            if (control != null)
            {
                control.OnPropertyChanged("LabelText");
                control.OnLabelTextChanged(e);
            }
        }
        #endregion
        #region LabelTextWidth 
        public readonly static DependencyProperty LabelTextWidthDependencyProperty =
            DependencyProperty.Register(
                "LabelTextWidth",
                typeof(string),
                typeof(CommonControl),
                new PropertyMetadata(string.Empty, OnLabelTextWidthChange));

        public string LabelTextWidth
        {
            get { return (string)GetValue(LabelTextWidthDependencyProperty); }
            set { SetValue(LabelTextWidthDependencyProperty, value); }
        }
        private static void OnLabelTextWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CommonControl control = d as CommonControl;
            if (control != null)
            {
                control.OnPropertyChanged("LabelTextWidth");
                control.OnLabelTextWidthChanged(e);
            }
        }
        #endregion
        #region LabelVisible

        public readonly static DependencyProperty LabelVisibleDependencyProperty =
            DependencyProperty.Register(
                "LabelVisible",
                typeof(bool),
                typeof(CommonControl),
                new PropertyMetadata(true, OnLabelVisibleChange));

        public bool LabelVisible
        {
            get { return (bool)GetValue(LabelVisibleDependencyProperty); }
            set { SetValue(LabelVisibleDependencyProperty, value); }
        }

        private static void OnLabelVisibleChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CommonControl control = d as CommonControl;
            if (control != null)
            {
                control.OnPropertyChanged("LabelVisible");
                control.OnLabelVisibleChanged(e);
            }
        }

        #endregion
        #region AllowedEmpty
        public static readonly DependencyProperty AllowedEmptyDependencyProperty =
            DependencyProperty.Register(
                "AllowedEmpty",
                typeof(bool),
                typeof(CommonControl),
                new PropertyMetadata(false, OnAllowedEmptyChange));
        public bool AllowedEmpty
        {
            get { return (bool)GetValue(AllowedEmptyDependencyProperty); }
            set { SetValue(AllowedEmptyDependencyProperty, value); }
        }
        private static void OnAllowedEmptyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CommonControl control = d as CommonControl;
            if (control != null)
            {
                control.OnPropertyChanged("AllowedEmpty");
                control.OnAllowedEmptyChange(e);
            }
        }
        #endregion


        protected abstract void OnLabelTextChanged(DependencyPropertyChangedEventArgs e);
        protected abstract void OnLabelTextWidthChanged(DependencyPropertyChangedEventArgs e);        
        protected abstract void OnUpperCaseChanged(DependencyPropertyChangedEventArgs e);
        protected abstract void OnLabelVisibleChanged(DependencyPropertyChangedEventArgs e);
        protected abstract void OnIsReadOnlyChanged(DependencyPropertyChangedEventArgs e);
        public abstract void SetDynamicBinding(ref DataTable dta, IList<ValidationRule> rules);
        #region BindTextField
        protected void BindTextField(string fieldName, ref DataTable dta, TextBox textField, 
                                     IList<ValidationRule> rules)
        {
            Binding oBind = new Binding("Text");
            oBind.Source = dta.Columns[fieldName];
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
            textField.Width = dta.Columns[fieldName].MaxLength;
            textField.SetBinding(TextBox.TextProperty, oBind);
        }
        #endregion

        public CommonControl(): base()
        {
        }
    }
}
