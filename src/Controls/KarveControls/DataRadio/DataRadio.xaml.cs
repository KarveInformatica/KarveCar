using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;
using Telerik.WinControls.UI;
using static KarveControls.ControlExt;
using Binding = System.Windows.Data.Binding;
using TextBox = System.Windows.Controls.TextBox;
using UserControl = System.Windows.Controls.UserControl;


namespace KarveControls
{

/// <summary>
/// Interaction logic for DataRadio.xaml
/// </summary>
public partial class DataRadio : UserControl, INotifyPropertyChanged
    {
        #region Private Variables

        private ICommand _currentCommand;
        private object _commandParameters;
        private bool _isChecked;

        private readonly RadRadioButton _radioView = new RadRadioButton();
        public enum RadioState { Unchecked,Checked, Undeterminate };

        #endregion

        #region DataRadioCommand

        public class DataRadioCommand: ICommand
        {
  
            public DataRadioCommand()
            {
          
            }
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public virtual void Execute(object parameter)
            {
            }

            public event EventHandler CanExecuteChanged;
        }
        #endregion

        #region CommonPart
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
        protected string _DataRadio = string.Empty;
        protected string _tableName = string.Empty;
        protected string _dataField = String.Empty;

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
                typeof(DataRadio),
                new PropertyMetadata(String.Empty));
        #endregion
        #region DataAllowed
        public static readonly DependencyProperty DataAllowedDependencyProperty =
            DependencyProperty.Register(
                "DataAllowed",
                typeof(DataType),
                typeof(DataRadio),
                new PropertyMetadata(DataType.Any, OnDataAllowedChange));
        public DataType DataAllowed
        {
            get { return (DataType)GetValue(DataAllowedDependencyProperty); }
            set { SetValue(DataAllowedDependencyProperty, value); }
        }
        private static void OnDataAllowedChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataRadio control = d as DataRadio;
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
                typeof(DataRadio),
                new PropertyMetadata(new DataTable(), OnItemSourceChanged));

        public DataTable ItemSource
        {
            get { return (DataTable)GetValue(ItemSourceDependencyProperty); }
            set { SetValue(ItemSourceDependencyProperty, value); }
        }
        private static void OnItemSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataRadio control = d as DataRadio;
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
        #region UpperCaseChange

        public static readonly DependencyProperty UpperCaseDependencyProperty =
            DependencyProperty.Register(
                "UpperCase",
                typeof(bool),
                typeof(DataRadio),
                new PropertyMetadata(false, OnUpperCaseChange));

        private static void OnUpperCaseChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataRadio control = d as DataRadio;
            if (control != null)
            {
                control.OnPropertyChanged("UpperCase");
                control.OnUpperCaseChanged(e);
            }
        }

        private void OnUpperCaseChanged(DependencyPropertyChangedEventArgs e)
        {
        
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
                typeof(DataRadio),
                new PropertyMetadata(false, IsReadOnlyDependencyPropertyChange));

        private static void IsReadOnlyDependencyPropertyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataRadio control = d as DataRadio;
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
        #region DataRadio

        public static DependencyProperty DataRadioDependencyProperty =
            DependencyProperty.Register(
                "DataField",
                typeof(string),
                typeof(DataRadio),
                new PropertyMetadata(string.Empty, OnDataRadioChanged));

        public string DataField
        {
            get { return (string)GetValue(DataRadioDependencyProperty); }
            set { SetValue(DataRadioDependencyProperty, value); }
        }
        private static void OnDataRadioChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataRadio controlDataRadio = d as DataRadio;
            if (controlDataRadio != null)
            {
                controlDataRadio.OnPropertyChanged("DataField");
                controlDataRadio.OnDataRadioPropertyChanged(e);
            }
        }
        private void OnDataRadioPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            _DataRadio = e.NewValue as string;
        }
        #endregion
        #region AllowedEmpty
        public static readonly DependencyProperty AllowedEmptyDependencyProperty =
            DependencyProperty.Register(
                "AllowedEmpty",
                typeof(bool),
                typeof(DataRadio),
                new PropertyMetadata(false, OnAllowedEmptyChange));
        public bool AllowedEmpty
        {
            get { return (bool)GetValue(AllowedEmptyDependencyProperty); }
            set { SetValue(AllowedEmptyDependencyProperty, value); }
        }
        private static void OnAllowedEmptyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataRadio control = d as DataRadio;
            if (control != null)
            {
                control.OnPropertyChanged("AllowedEmpty");
                control.OnAllowedEmptyChange(e);
            }
        }
        #endregion



        #endregion
        
        #region DataRadioChanged RoutedEvent  
        public event RoutedEventHandler DataRadioChanged
        {
            add { AddHandler(DataRadioChangedEvent, value); }
            remove { RemoveHandler(DataRadioChangedEvent, value); }
        }

        public static readonly RoutedEvent DataRadioChangedEvent =
            EventManager.RegisterRoutedEvent(
                "DataRadioChanged",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(DataRadio));

        #endregion

        public class DataRadioEventArgs : RoutedEventArgs
        {
            private string _fieldData = "";
            private bool _state = false;

            public string FieldData
            {
                get { return _fieldData; }
                set { _fieldData = value; }
            }

            public bool IsChecked
            {
                get { return _state; }
                set { _state = value; }
            }
            public DataRadioEventArgs() : base()
            {
            }
            public DataRadioEventArgs(RoutedEvent routedEvent) : base(routedEvent)
            {
            }
        }
   
        #region IsChecked

        public static DependencyProperty IsCheckedCommandDependencyProperty
            = DependencyProperty.Register(
                "IsChecked",
                typeof(bool),
                typeof(DataRadio),
                new PropertyMetadata(false, OnIsCheckedChange));

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedCommandDependencyProperty); }
            set { SetValue(IsCheckedCommandDependencyProperty, value); }
        }

        private static void OnIsCheckedChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataRadio control = d as DataRadio;
            if (control != null)
            {
                control.OnPropertyChanged("IsChecked");
                control.OnIsCheckedChange(e);
            }
        }

        private void OnIsCheckedChange(DependencyPropertyChangedEventArgs e)
        {
            bool value = Convert.ToBoolean(e.NewValue);
            _isChecked = value;
            if (_radioView != null)
            {
                if (_isChecked)
                {
                    _radioView.CheckState = CheckState.Checked;
                }
                else
                {
                    _radioView.CheckState = CheckState.Unchecked;
                }
            }
        }

    #endregion

        #region CheckedCommand
        public static DependencyProperty CheckedCommandDependencyProperty
            = DependencyProperty.Register(
                "CheckedCommand",
                typeof(ICommand),
                typeof(DataRadio), 
                new PropertyMetadata(new DataRadioCommand(), OnCheckedCommand));

        public ICommand CheckedCommand
        {
            get { return (ICommand) GetValue(CheckedCommandDependencyProperty); }
            set { SetValue(CheckedCommandDependencyProperty, value); }
        }

        private static void OnCheckedCommand(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataRadio control = d as DataRadio;
            if (control != null)
            {
                control.OnPropertyChanged("CheckedCommand");
                control.OnCheckedCommand(e);
            }
        }
        private void OnCheckedCommand(DependencyPropertyChangedEventArgs e)
        {

            ICommand command = e.NewValue as ICommand;
            this._currentCommand = command;
        }
        #endregion

        #region Command Parameter Dependency Property

        public static DependencyProperty CommandParametersDependencyProperty
            = DependencyProperty.Register(
                "CommandParametersDependencyProperty",
                typeof(object),
                typeof(DataRadio),
                new PropertyMetadata(null, OnCommandParametersChanged));

        public object CommandParameters
        {
            get { return (object)GetValue(CommandParametersDependencyProperty); }
            set { SetValue(CommandParametersDependencyProperty, value); }
        }
        private static void OnCommandParametersChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataRadio control = d as DataRadio;
            if (control != null)
            {
                control.OnPropertyChanged("CommandParameters");
                control.OnCommandParametersChanged(e);
            }
        }
        private void OnCommandParametersChanged(DependencyPropertyChangedEventArgs e)
        {
            this._commandParameters = e.NewValue;
        }
        #endregion
  
        
       

        #region Content
        public static DependencyProperty ContentDependencyProperty =
            DependencyProperty.Register(
                "Content",
                typeof(object),
                typeof(DataRadio),
                new PropertyMetadata(false, OnContentChanged));
       
        private static void OnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataRadio controlDataRadio = d as DataRadio;
            if (controlDataRadio != null)
            {
                controlDataRadio.OnPropertyChanged("Content");
                controlDataRadio.OnContentPropertyChanged(e);
            }
        }
        private void OnContentPropertyChanged(DependencyPropertyChangedEventArgs e)
        {

            
            object content = e.NewValue;
            if (_radioView != null)
            {
                if (content is System.Drawing.Image)
                {
                    this._radioView.Image = content as System.Drawing.Image;
                }
                if (content is string)
                {
                    this._radioView.Text = content as string;
                }
            }

        }
        public new object Content
        {
            get { return GetValue(ContentDependencyProperty); }
            set { SetValue(ContentDependencyProperty, value); }
        }
        #endregion

        public DataRadio()
        {
            InitializeComponent();
            /*if (_radioView != null)
            {
                this._radioView.CheckStateChanged += RadioViewOnCheckStateChanged;
            }
            */
            this.RadioContext.DataContext = this;
        }

        private void RadioViewOnCheckStateChanged(object sender, EventArgs eventArgs)
        {
            DataRadioEventArgs args = new DataRadioEventArgs();
            if (_radioView != null)
            {
                bool checkedState = _radioView.CheckState == CheckState.Checked;

                args.FieldData = this._dataField;
                args.IsChecked = checkedState;
                if (this._currentCommand != null)
                {
                    if (_currentCommand.CanExecute(this._commandParameters))
                    {
                        _currentCommand.Execute(this._commandParameters);
                    }
                }
                RaiseEvent(args);
            }
        }

        private void RadioContext_OnLoaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Integration.WindowsFormsHost host = new System.Windows.Forms.Integration.WindowsFormsHost();
            host.Child = _radioView;
            RadioContext.Children.Add(host);
        }


        protected void OnIsReadOnlyChanged(DependencyPropertyChangedEventArgs e)
        {
            bool value = Convert.ToBoolean(e.NewValue);
            if (_radioView != null)
            {
                _radioView.IsAccessible = value;
            }
        }

        public void SetDynamicBinding(ref DataTable dta, IList<ValidationRule> rules)
        {
            string field = _dataField.ToUpper();
            if (!string.IsNullOrEmpty(field))
            {
                Binding oBind = new Binding("IsChecked");
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
                SetBinding(IsCheckedCommandDependencyProperty, oBind);
            }
        }
    }
}
