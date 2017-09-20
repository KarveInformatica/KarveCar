using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using ThicknessConverter = Xceed.Wpf.DataGrid.Converters.ThicknessConverter;

namespace KarveControls
{
    /// <summary>
    /// Interaction logic for DataField.xaml
    /// </summary>
    public partial class DataField : CommonControl
    {


        public static readonly RoutedEvent DataFieldChangedEvent =
            EventManager.RegisterRoutedEvent(
                "DataFieldChanged",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(DataField));

        private bool textContentChanged = false;

        public class DataFieldEventArgs : RoutedEventArgs
        {
            private string _fieldData = "";

            public string FieldData
            {
                get { return _fieldData; }
                set { _fieldData= value; }
            }
            public DataFieldEventArgs() : base()
            {

            }
            public  DataFieldEventArgs(RoutedEvent routedEvent) : base(routedEvent)
            {

            }
        }

        public event RoutedEventHandler DataFieldChanged
        {
            add { AddHandler(DataFieldChangedEvent, value); }
            remove { RemoveHandler(DataFieldChangedEvent, value); }
        }


               #region TextContent Property
        public static readonly DependencyProperty TextContentDependencyProperty =
            DependencyProperty.Register(
                "TextContent",
                typeof(string),
                typeof(DataField),
                new PropertyMetadata(string.Empty, OnTextContentChange));
       
        public string TextContent
        {
            get { return (string)GetValue(TextContentDependencyProperty); }
            set { SetValue(TextContentDependencyProperty, value); }
        }


        private static void OnTextContentChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataField control = d as DataField;
            if (control != null)
            {
                control.OnPropertyChanged("TextContent");
                control.OnTextContentPropertyChanged(e);
            }
        }

        private void OnTextContentPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            string value = e.NewValue as string;
            this.TextField.Text = value;
        }
        #endregion
        #region LabelVisible

        public static readonly DependencyProperty LabelVisibleDependencyProperty =
            DependencyProperty.Register("LabelVisible",
                typeof(bool),
                typeof(DataField),
                new PropertyMetadata(false, OnLabelVisibleChange));

        public bool LabelVisible
        {
            get { return (bool)GetValue(LabelVisibleDependencyProperty); }
            set { SetValue(LabelVisibleDependencyProperty, value); }
        }

        private static void OnLabelVisibleChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataField control = d as DataField;
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
                typeof(DataField),
                new PropertyMetadata(string.Empty, OnLabelTextChange));

        public string LabelText
        {
            get { return (string)GetValue(LabelTextDependencyProperty); }
            set { SetValue(LabelTextDependencyProperty, value); }
        }
        private static void OnLabelTextChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataField control = d as DataField;
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
                typeof(DataField),
                new PropertyMetadata(string.Empty, OnLabelTextWidthChange));

        public string LabelTextWidth
        {
            get { return (string)GetValue(LabelTextWidthDependencyProperty); }
            set { SetValue(LabelTextWidthDependencyProperty, value); }
        }
        private static void OnLabelTextWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataField control = d as DataField;
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

        public string TextContentWidth
        {
            get { return (string)GetValue(TextContentWidthDependencyProperty); }
            set {  SetValue(TextContentWidthDependencyProperty, value); }
        }

        public readonly static DependencyProperty TextContentWidthDependencyProperty =
            DependencyProperty.Register(
                "TextContentWidth",
                typeof(string),
                typeof(DataField), new PropertyMetadata(string.Empty, OnTextContentWidthChange));

        private static void OnTextContentWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataField control = d as DataField;
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
            TextField.Width = valueName;
        }
        #endregion

        
        
        public static DependencyProperty ReloadDependencyProperty =
            DependencyProperty.Register(
                "Reload",
                typeof(bool),
                typeof(DataField),
                new PropertyMetadata(false, OnReloadChanged));

        private static void OnReloadChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataField controlDataField = d as DataField;
            if (controlDataField != null)
            {
                controlDataField.OnPropertyChanged("Reload");
                controlDataField.OnReloadPropertyChanged(e);
            }
        }

        private void OnReloadPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            string field = _dataField.ToUpper();
            if (!string.IsNullOrEmpty(field))
            {
                DataTable dta = ItemSource;
                Binding oBind = new Binding("Text");
                oBind.Source = dta.Columns[field];
                oBind.Mode = BindingMode.TwoWay;
                oBind.ValidatesOnDataErrors = false;
                oBind.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                TextField.Width = dta.Columns[field].MaxLength;
                TextField.SetBinding(TextBox.TextProperty, oBind);
            }
        }
        public bool Reload
        {
            get { return (bool)GetValue(ReloadDependencyProperty); }
            set { SetValue(ReloadDependencyProperty, value); }
        }
        public override void SetDynamicBinding(ref DataTable dta, IList<ValidationRule> rules)
        {
            string field = _dataField.ToUpper();
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
                TextField.Width = dta.Columns[field].MaxLength;
                TextField.SetBinding(TextBox.TextProperty, oBind);
            }
           
        }
        
        public DataField()
        {
            InitializeComponent();
            LabelVisible = true;
            TextField.IsReadOnly = false;
            TextField.TextChanged += TextField_TextChanged;
            TextField.GotFocus += TextField_GotFocus;
            
            this.GotFocus += DataField_GotFocus;
            this.LostFocus += DataField_LostFocus;
            this.DataFieldContent.DataContext = this;
            /*
            Binding myBinding = BindingOperations.GetBinding(this.TextField, TextBox.TextProperty);
            if (this.Dat)
            myBinding.ValidationRules
            */
        }

        private void TextField_TextChanged(object sender, TextChangedEventArgs e)
        {
            textContentChanged = true;
            RaiseEvent(e);
        }

        private void DataField_LostFocus(object sender, RoutedEventArgs e)
        {
          //  RaiseEvent(e);
            if ((TextField.Text.Length > 0) && (textContentChanged))
            {
                DataFieldEventArgs ev = new DataFieldEventArgs(DataFieldChangedEvent);
                ev.FieldData = TextField.Text;
                RaiseEvent(ev);
            }
        }

        private void TextField_GotFocus(object sender, RoutedEventArgs e)
        {
            this.TextField.SelectAll();
            RaiseEvent(e);
        }

        private void DataField_GotFocus(object sender, RoutedEventArgs e)
        {
            TextField.Focus();
        }
    }
}
