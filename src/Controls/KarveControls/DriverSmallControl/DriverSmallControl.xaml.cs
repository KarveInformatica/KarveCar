using System;
using System.Collections.Generic;
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

namespace KarveControls
{
    /// <summary>
    /// Interaction logic for DriverSmallControl.xaml
    /// </summary>
    public partial class DriverSmallControl : UserControl
    {
        /// <summary>
        ///  Property for the columns to be shown in the dual searchbox
        /// </summary>
        public static readonly DependencyProperty PropertiesProperty =
         DependencyProperty.Register(
             "Properties",
             typeof(string),
             typeof(DriverSmallControl),
             new PropertyMetadata(string.Empty));
        /// <summary>
        ///  Path of the date member property
        /// </summary>
        public static readonly DependencyProperty DatePathProperty =
         DependencyProperty.Register(
             "DatePath",
             typeof(string),
             typeof(DriverSmallControl),
             new PropertyMetadata(string.Empty));

        /// <summary>
        ///  Command to trigger the dual searchbox
        /// </summary>
        public static readonly DependencyProperty AssistCommandProperty =
         DependencyProperty.Register(
             "AssistCommand",
             typeof(ICommand),
             typeof(DriverSmallControl),
             new PropertyMetadata(null));
       /// <summary>
       ///  Command to detect changed.
       /// </summary>
        public static readonly DependencyProperty ItemChangedCommandProperty =
        DependencyProperty.Register(
        "ItemChangedCommand",
        typeof(ICommand),
        typeof(DriverSmallControl),
         new PropertyMetadata(null));

        /// <summary>
        ///  The object is a list of drivers. Usually it shall be an incremental list.
        /// </summary>
        public static readonly DependencyProperty DriversProperty = 
            DependencyProperty.Register("Drivers",typeof(object),typeof(DriverSmallControl),new PropertyMetadata(null));
        
        /// <summary>
        ///  License Number member property
        /// </summary>
        public static readonly DependencyProperty LicenseNumberProperty =
         DependencyProperty.Register(
             "LicenseNumber",
             typeof(string),
             typeof(DriverSmallControl),
             new PropertyMetadata(string.Empty));

        /// <summary>
        ///  Driving License expire date property.
        /// </summary>
        public static readonly DependencyProperty ExpireDateProperty =
           DependencyProperty.Register("ExpireDate", typeof(DateTime), typeof(DriverSmallControl), new PropertyMetadata(null));
        
        /// <summary>
        ///  Data object property.
        /// </summary>
        public static readonly DependencyProperty DataObjectProperty =
          DependencyProperty.Register("DataObject", typeof(object), typeof(DriverSmallControl), new PropertyMetadata(null));

        /// <summary>
        ///  Set or Get the properties/coma separated columns for the driver grid. 
        /// </summary>
        public string Properties
        {
            set
            {
                SetValue(PropertiesProperty, value);
            }
            get
            {
                return (string)GetValue(PropertiesProperty);
            }
        }
        /// <summary>
        ///  Set or Get the member path for the datafield grid. 
        /// </summary>
        public string DatePath
        {
            set
            {
                SetValue(DatePathProperty, value);
            }
            get
            {
                return (string)GetValue(PropertiesProperty);
            }
        }

      
        /// <summary>
        ///  Set or Get the command for the driver popup. 
        /// </summary>
        public ICommand AssistCommand
        {
            set
            {
                SetValue(AssistCommandProperty, value);
            }
            get
            {
                return (ICommand)GetValue(AssistCommandProperty);
            }
        }
        /// <summary>
        ///  Set or Get the command for the changed. 
        /// </summary>
        public ICommand ItemChangedCommand
        {
            set
            {
                SetValue(ItemChangedCommandProperty, value);
            }
            get
            {
                return (ICommand)GetValue(ItemChangedCommandProperty);
            }
        }
        /// <summary>
        ///  Set or Get the source of the list. 
        /// </summary>
        public object Drivers
        {
            set
            {
                SetValue(DriversProperty, value);
            }
            get
            {
                return (object)GetValue(DriversProperty);
            }
        }
        /// <summary>
        ///  Set or Get the license number. 
        /// </summary>
        public string LicenseNumber
        {
            set
            {
                SetValue(LicenseNumberProperty, value);
            }
            get
            {
                return (string)GetValue(LicenseNumberProperty);
            }
        }

        /// <summary>
        ///  Set or Get the dataobject. 
        /// </summary>
        public object DataObject
        {
            set
            {
                SetValue(DataObjectProperty, value);
            }
            get
            {
                return (object)GetValue(DataObjectProperty);
            }
        }

        /// <summary>
        ///  Set or Get the expiredate. 
        /// </summary>
        public DateTime ExpireDate
        {
            set
            {
                SetValue(ExpireDateProperty, value);
            }
            get
            {
                return (DateTime)GetValue(ExpireDateProperty);
            }
        }

        public DriverSmallControl()
        {
            InitializeComponent();
        }
    }
}
