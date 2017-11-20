using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MasterModule.Views
{
    /// <summary>
    /// Interaction logic for DirectionInfo.xaml
    /// </summary>

    
    public partial class DirectionInfo : UserControl
    {
        /// <summary>
        ///  Name of the assist table. The assist table is the table used to ref integrity with the previous table.
        /// </summary>

        public static readonly DependencyProperty DataObjectDependencyProperty =
            DependencyProperty.Register(
                "DataObject",
                typeof(object),
                typeof(DirectionInfo), new PropertyMetadata(null));

        public static readonly DependencyProperty PropertyListDependencyProperty =
            DependencyProperty.Register(
                "PropertyList",
                typeof(string),
                typeof(DirectionInfo), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty ItemChangedDependencyProperty =
            DependencyProperty.Register(
                "ItemChangedCommand",
                typeof(ICommand),
                typeof(DirectionInfo), new PropertyMetadata(null));

        public static readonly DependencyProperty AssistCommendDependencyProperty =
    DependencyProperty.Register(
        "AssistCommand",
        typeof(ICommand),
        typeof(DirectionInfo), new PropertyMetadata(null));

        private IDictionary<string, bool> ChangedMap = new Dictionary<string, bool>();
        /// <summary>
        ///  ItemChangedCommand.
        /// </summary>
        public ICommand ItemChangedCommand
        {
            set
            {
                SetValue(ItemChangedDependencyProperty, value);
            }
            get
            {
                return (ICommand)GetValue(ItemChangedDependencyProperty);
            }
        }
        /// <summary>
        ///  Comma separated property list
        /// </summary>
        public string PropertyList
        {
            set
            {
                SetValue(PropertyListDependencyProperty, value);
            }
            get
            {
                return (string)GetValue(PropertyListDependencyProperty);
            }
        }
        /// <summary>
        ///  AssistCommand
        /// </summary>
        public ICommand AssistCommand
        {
            set
            {
                SetValue(AssistCommendDependencyProperty, value);
            }
            get
            {
                return (ICommand)GetValue(AssistCommendDependencyProperty);
            }
        }
        /// <summary>
        ///  Source of data. Tipically is a DataTransferObject.
        /// </summary>
        public object DataObject
        {
            get
            {
                return GetValue(DataObjectDependencyProperty);
            }
            set
            {
                SetValue(DataObjectDependencyProperty, value);
            }
        }
        private bool textChanged = false;
        public DirectionInfo()
        {
            InitializeComponent();
            this.PhoneTextBox.TextChanged += PhoneTextBox_TextChanged;
            this.PhoneTextBox.LostFocus += PhoneTextBox_LostFocus;
            this.FaxTextBox.TextChanged += FaxTextBox_TextChanged;
            this.FaxTextBox.LostFocus += FaxTextBox_LostFocus;
            this.EmailTextBox.LostFocus += EmailTextBox_LostFocus;
            this.EmailTextBox.TextChanged += EmailTextBox_TextChanged;
            this.DirectionTextBox.LostFocus += DirectionTextBox_LostFocus;
            this.DirectionTextBox.TextChanged += DirectionTextBox_TextChanged;
            this.DirectionTextBox2.LostFocus += DirectionTextBox2_LostFocus;
            this.DirectionTextBox2.TextChanged += DirectionTextBox2_TextChanged;
            this.DefaultLayout.DataContext = this;
        }

        private void DirectionTextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            textChanged = true;
        }

        private void DirectionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            textChanged = true;
       }

        private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            textChanged = true;
            
        }

        private void FaxTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            textChanged = true;
        }

        private void DirectionTextBox2_LostFocus(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DirectionTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void EmailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PhoneTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textChanged)
            {
                IDictionary<string, object> valueDictionary = new Dictionary<string, object>
                {
                    [DATAOBJECT] = DataObject,
                    [CHANGED_VALUE] = this.PhoneTextBox.Text
                };
                if (ItemChangedCommand != null)
                {
                    if (ItemChangedCommand.CanExecute(valueDictionary))
                    {
                        ItemChangedCommand.Execute(valueDictionary);
                    }

                }
                textChanged = false;
            }
        }

        private void PhoneTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FaxTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Constant for the field data table
        /// </summary>
        public static string DATAOBJECT = "DataObject";
        public static string CHANGED_VALUE = "ChangedValue";

        
    }
}
