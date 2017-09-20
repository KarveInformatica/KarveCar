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
            DoubleField, IntegerField, NifField, Iban, Any
        }

        public enum Encoding
        {
            Latin, Utf8
        }       
        public static readonly DependencyProperty DescriptionDependencyProperty =
            DependencyProperty.Register(
                "Description",
                typeof(string),
                typeof(CommonControl),
                new PropertyMetadata(String.Empty, OnDescriptionChange));

        #region DataAllowed Property

        public static readonly DependencyProperty DataAllowedDependencyProperty =
            DependencyProperty.Register(
                "DataAllowed",
                typeof(DataType),
                typeof(CommonControl),
                new PropertyMetadata(DataType.Any, OnDataAllowedChange));
        public DataType DataAllowed
        {
            get { return (DataType)GetValue(DataAllowedDependencyProperty); }
            set { SetValue(DescriptionDependencyProperty, value); }
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
        #region AllowedEmpty
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

        protected object GetPropertyValue(DependencyProperty property)
        {
            return GetValue(property);
        }
        protected virtual void OnAllowedEmptyChange(DependencyPropertyChangedEventArgs e)
        {
            _allowedEmpty = Convert.ToBoolean(e.NewValue);

        }
        #endregion
        public static readonly DependencyProperty AllowedEmptyDependencyProperty =
            DependencyProperty.Register(
                "AllowedEmpty",
                typeof(bool),
                typeof(CommonControl),
                new PropertyMetadata(false, OnAllowedEmptyChange));

        
        public static readonly DependencyProperty UpperCaseDependencyProperty =
            DependencyProperty.Register(
                "UpperCase",
                typeof(bool),
                typeof(CommonControl),
                new PropertyMetadata(false, OnUpperCaseChange));



        public static DependencyProperty ItemSourceDependencyProperty
            = DependencyProperty.Register(
                "ItemSourceDependencyProperty",
                typeof(CommonControl),
                typeof(DataTable),
                new PropertyMetadata(false, OnItemSourceChanged));


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


        #region TableName

        public static readonly DependencyProperty DBTableNameDependencyProperty =
            DependencyProperty.Register(
                "TableName",
                typeof(string),
                typeof(DataRadio),
                new PropertyMetadata(string.Empty, OnTableNameChange));
        private static void OnTableNameChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataRadio control = d as DataRadio;
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
        public event PropertyChangedEventHandler PropertyChanged;

        protected string _description;
        protected DataType _dataAllowed;
        protected bool _allowedEmpty;
        protected bool _upperCase;
        protected DataTable _itemSource;
        protected string _dataField = string.Empty;
        protected string _tableName = string.Empty;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #region Description Property
        public string Description
        {
            get { return (string)GetValue(DescriptionDependencyProperty); }
            set { SetValue(DescriptionDependencyProperty, value); }
        }

        private static void OnDescriptionChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CommonControl control = d as CommonControl;
            if (control != null)
            {
                control.OnPropertyChanged("Description");
                control.OnDescriptionPropertyChanged(e);
            }
        }

        private void OnDescriptionPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            string value = e.NewValue as string;
            this.Description = value;
            _description = value;
        }
        #endregion
        #region AllowedEmptyChanged Property

        #endregion
        #region UpperCase
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
        private void OnUpperCaseChanged(DependencyPropertyChangedEventArgs e)
        {
            this._upperCase = Convert.ToBoolean(e.NewValue);
        }
        #endregion

        #region DynamicBinding
        public abstract void SetDynamicBinding(ref DataTable dta, IList<ValidationRule> rules);
        #endregion
        #region DataField
        public static DependencyProperty DataFieldDependencyProperty =
            DependencyProperty.Register(
                "DataField",
                typeof(string),
                typeof(DataRadio),
                new PropertyMetadata(string.Empty, OnDataFieldChanged));

        public string DataField
        {
            get { return (string)GetValue(DataFieldDependencyProperty); }
            set { SetValue(DataFieldDependencyProperty, value); }
        }
        private static void OnDataFieldChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataRadio controlDataRadio = d as DataRadio;
            if (controlDataRadio != null)
            {
                controlDataRadio.OnPropertyChanged("DataField");
                controlDataRadio.OnDataFieldPropertyChanged(e);
            }
        }

        private void OnDataFieldPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            _dataField = e.NewValue as string;
        }
        #endregion


        public CommonControl(): base()
        {
        }
    }
}
