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
    public class CommonControl: UserControl, INotifyPropertyChanged
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


        public static readonly DependencyProperty DataAllowedDependencyProperty =
            DependencyProperty.Register(
                "DataAllowed",
                typeof(DataType),
                typeof(CommonControl),
                new PropertyMetadata(DataType.Any, DataField.OnDataAllowedChange));




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



        public event PropertyChangedEventHandler PropertyChanged;
        protected string _description;
        protected DataType _dataAllowed;
        protected bool _allowedEmpty;
        protected bool _upperCase;
        protected DataTable _itemSource;

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
        #region DataAllowed Property
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
        private void OnDataAllowedChange(DependencyPropertyChangedEventArgs e)
        {
            DataType type = (DataType) Enum.Parse(typeof(DataType), e.NewValue.ToString());
            DataAllowed = type;
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
            CommonControl control = d as CommonControl;
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
        public CommonControl(): base()
        {
        }
    }
}
