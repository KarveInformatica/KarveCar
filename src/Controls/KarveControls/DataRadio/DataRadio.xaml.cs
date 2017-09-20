using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.WinControls.UI;
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

        private DataTable _itemSource;
        private ICommand _currentCommand;
        private object _commandParameters;
        private bool _isChecked;

        private RadRadioButton _radioView;
        private string _dataField;
        public enum RadioState { Unchecked,Checked, Undeterminate };

        #endregion

        #region PropertyChanged definition

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
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
        #region
        public static readonly DependencyProperty DescriptionDependencyProperty =
            DependencyProperty.Register(
                "Description",
                typeof(string),
                typeof(DataRadio));
    
        #endregion
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
            if (_isChecked)
            {
                _radioView.CheckState = CheckState.Checked;
            }
            else
            {
                _radioView.CheckState = CheckState.Unchecked;
            }
        }

    #endregion





        #region CheckedCommand
        public static DependencyProperty CheckedCommandDependencyProperty
            = DependencyProperty.Register(
                "CheckedCommand",
                typeof(ICommand),
                typeof(DataRadio), 
                new PropertyMetadata(false, OnCheckedCommand));

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
        #region ItemSource Dependency Property

        public static DependencyProperty ItemSourceDependencyProperty
            = DependencyProperty.Register(
                "ItemSourceDependencyProperty",
                typeof(DataTable),
                typeof(DataRadio),
                new PropertyMetadata(false, OnItemSourceChanged));

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
        private void OnItemSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            DataTable table = e.NewValue as DataTable;
            this._itemSource = table;
        }
        #endregion

        #region TableName
        private string _tableName = string.Empty;

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
        private void OnTableNameChanged(DependencyPropertyChangedEventArgs e)
        {
            _tableName = e.NewValue as string;
        }
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
            if (content is System.Drawing.Image)
            {
                this._radioView.Image = content as System.Drawing.Image;
            }
            if (content is string)
            {
                this._radioView.Text = content as string;
            }

        }
        public new object Content
        {
            get { return GetValue(ContentDependencyProperty); }
            set { SetValue(ContentDependencyProperty, value); }
        }
        #endregion

        #region DynamicBinding
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
               SetBinding(DataRadio.IsCheckedCommandDependencyProperty, oBind);
            }
        }
#endregion
        public DataRadio()
        {
            InitializeComponent();
            this._radioView.CheckStateChanged+=RadioViewOnCheckStateChanged;
          
            this.RadioContext.DataContext = this;
        }

        private void RadioViewOnCheckStateChanged(object sender, EventArgs eventArgs)
        {
            DataRadioEventArgs args = new DataRadioEventArgs();
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

        private void RadioContext_OnLoaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Integration.WindowsFormsHost host = new System.Windows.Forms.Integration.WindowsFormsHost();
            _radioView = new RadRadioButton();
            host.Child = _radioView;
            RadioContext.Children.Add(host);

        }
    }
}
