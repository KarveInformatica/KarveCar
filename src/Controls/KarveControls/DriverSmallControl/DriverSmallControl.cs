using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KarveControls
{
    /// <summary>
    /// Interaction logic for DriverSmallControl.xaml
    /// </summary>
    public class DriverSmallControl : Control
    {


        static DriverSmallControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DriverSmallControl), new FrameworkPropertyMetadata(typeof(DriverSmallControl)));

        }
        public DriverSmallControl()
        { 
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
        /// <summary>
        ///  ComboBoxItem to be binded.
        /// </summary>
        public static readonly DependencyProperty SalutationItemProperty =
         DependencyProperty.Register(
             "SalutationItem",
             typeof(object),
             typeof(DriverSmallControl),
             new PropertyMetadata(string.Empty));
        /// <summary>
        ///  Set or Get the Salutation Item, ComboBoxItem
        /// </summary>
        public object SalutationItem
        {
            set
            {
                SetValue(SalutationItemProperty, value);
            }
            get
            {
                return GetValue(SalutationItemProperty);
            }
        }
        /// <summary>
        /// Dependency Property Index of the selected salutation
        /// </summary>
        public static readonly DependencyProperty SalutationIndexProperty = DependencyProperty.Register("SalutationIndex", typeof(int), typeof(DriverSmallControl),
     new PropertyMetadata(0));

        /// <summary>
        ///  Set or Get the Salutation Index
        /// </summary>
        public int SalutationIndex
        {
            set
            {
                SetValue(SalutationIndexProperty, value);
            }
            get
            {
                return (int) GetValue(SalutationIndexProperty);
            }
        }
        /// <summary>
        /// Dependency Property for DriverFirstName
        /// </summary>
        public static readonly DependencyProperty DriverFirstNameProperty =
DependencyProperty.Register(
    "DriverFirstName",
    typeof(string),
    typeof(DriverSmallControl),
    new PropertyMetadata(string.Empty));

     
        /// <summary>
        ///  Set or Get the driver first name.
        /// </summary>
        public string DriverFirstName
        {
            set
            {
                SetValue(DriverFirstNameProperty, value);
            }
            get
            {
                return (string)GetValue(DriverFirstNameProperty);
            }
        }


        /// <summary>
        /// Dependency Property for DriverSecondName
        /// </summary>

        public static readonly DependencyProperty DriverSecondNameProperty = DependencyProperty.Register(
                "DriverSecondName",
                typeof(string),
                typeof(DriverSmallControl));

        /// <summary>
        /// Set or Get the driver second name.
        /// </summary>
        public string DriverSecondName
        {
            set
            {
                SetValue(DriverFirstNameProperty, value);
            }
            get
            {
                return (string)GetValue(DriverFirstNameProperty);
            }
        }

        /// <summary>
        ///  Set or Get the driver license number.
        /// </summary>
        public static readonly DependencyProperty DrivingLicenseNumberProperty =
            DependencyProperty.Register(
            "DrivingLicenseNumber",
            typeof(string),
            typeof(DriverSmallControl),
            new PropertyMetadata(string.Empty));

        /// <summary>
        /// Set or Get the driver license number
        /// </summary>

        public string DrivingLicenseNumber
        {
            set
            {
                SetValue(DrivingLicenseNumberProperty, value);
            }
            get
            {
                return (string)GetValue(DrivingLicenseNumberProperty);
            }
        }
        public static readonly DependencyProperty DrivingLicenseExpireDateProperty =
         DependencyProperty.Register(
            "DrivingLicenseExpireDate",
            typeof(DateTime),
            typeof(DriverSmallControl));

        /// <summary>
        /// Set or Get the driver license expire date
        /// </summary>

        public DateTime DrivingLicenseExpireDate
        {
            set
            {
                SetValue(DrivingLicenseExpireDateProperty, value);
            }
            get
            {
                return (DateTime)GetValue(DrivingLicenseExpireDateProperty);
            }
        }
        /// <summary>
        /// Direction dependency property.
        /// </summary>

        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.Register(
            "Direction",
            typeof(string),
            typeof(DriverSmallControl),
            new PropertyMetadata(string.Empty));
        /// <summary>
        ///  Set or Get the direction.
        /// </summary>
        public string Direction
        {
            set
            {
                SetValue(DirectionProperty, value);
            }
            get
            {
                return (string)GetValue(DirectionProperty);
            }
        }

        /// <summary>
        /// Set or Get the direction
        /// </summary>
        public static readonly DependencyProperty CityProperty =
            DependencyProperty.Register(
            "CityPath",
            typeof(string),
            typeof(DriverSmallControl),
            new PropertyMetadata(string.Empty));

        /// <summary>
        ///  Set or Get the city path.
        /// </summary>
        public string CityPath
        {
            set
            {
                SetValue(CityProperty, value);
            }
            get
            {
                return (string)GetValue(CityProperty);
            }
        }
        /// <summary>
        ///  AssistNameCity. The assist name city is the name of the assist tag to be triggered for a city.
        /// </summary>
        public static readonly DependencyProperty AssistNameCityProperty =
            DependencyProperty.Register(
            "AssistNameCity",
            typeof(string),
            typeof(DriverSmallControl),
            new PropertyMetadata(string.Empty));
        
        /// <summary>
        ///  Set or Get AssistNameCity. The tag to be used in the view model to answer to an assist.
        /// </summary>
        public string  AssistNameCity
        {
            set
            {
                SetValue(AssistNameCityProperty, value);
            }
            get
            {
                return (string)GetValue(AssistNameCityProperty);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty ItemChangedCommandProperty =
       DependencyProperty.Register(
       "ItemChangedCommand",
       typeof(ICommand),
       typeof(DriverSmallControl),
        new PropertyMetadata(null));

        /// <summary>
        ///  Set or Get the item changed command. This command is used to when a change happens.
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
        ///  Command to trigger the dual searchbox
        /// </summary>
        public static readonly DependencyProperty AssistCommandProperty =
         DependencyProperty.Register(
             "AssistCommand",
             typeof(ICommand),
             typeof(DriverSmallControl),
             new PropertyMetadata(null));


        /// <summary>
        ///  Set or Get the assist command.
        /// </summary>
        public ICommand AssistCommand
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
        ///  The object is a list of drivers. Usually it shall be an incremental list.
        /// </summary>
        public static readonly DependencyProperty CitySourceViewProperty =
            DependencyProperty.Register("CitySourceView", typeof(object), typeof(DriverSmallControl), new PropertyMetadata(null));


        /// <summary>
        ///  Set or Get the city source view.
        /// </summary>
        public object CitySourceView
        {
            set
            {
                SetValue(CitySourceViewProperty, value);
            }
            get
            {
                return GetValue(CitySourceViewProperty);
            }
        }

        /// <summary>
        ///  Data object property.
        /// </summary>
        public static readonly DependencyProperty DataObjectDependencyProperty =
            DependencyProperty.Register("DataObject", typeof(object), typeof(DriverSmallControl), new PropertyMetadata(null));

        /// <summary>
        ///  Set or Get the city data object
        /// </summary>
        public object DataObject
        {
            set
            {
                SetValue(DataObjectDependencyProperty, value);
            }
            get
            {
                return GetValue(DataObjectDependencyProperty);
            }
        }

        public static readonly DependencyProperty ProvinceProperty =
            DependencyProperty.Register(
            "ProvincePath",
            typeof(string),
            typeof(DriverSmallControl),
            new PropertyMetadata(string.Empty));

        /// <summary>
        ///  Set or Get the city source view.
        /// </summary>
        public string ProvincePath
        {
            set
            {
                SetValue(ProvinceProperty, value);
            }
            get
            {
                return (string)GetValue(ProvinceProperty);
            }
        }


        public static readonly DependencyProperty AssistNameProvinceProperty =
          DependencyProperty.Register(
          "AssistNameProvince",
          typeof(string),
          typeof(DriverSmallControl),
          new PropertyMetadata(string.Empty));

        /// <summary>
        ///  Set or Get the city source view.
        /// </summary>
        public string AssistNameProvince
        {
            set
            {
                SetValue(AssistNameProvinceProperty, value);
            }
            get
            {
                return (string)GetValue(AssistNameProvinceProperty);
            }
        }

        /// <summary>
        ///  The object is a list of drivers. Usually it shall be an incremental list.
        /// </summary>
        public static readonly DependencyProperty ProvinceSourceViewProperty =
            DependencyProperty.Register("ProvinceSourceView", typeof(object), typeof(DriverSmallControl), new PropertyMetadata(null));

        /// <summary>
        ///  Set or Get the city data object
        /// </summary>
        public object ProvinceSourceView
        {
            set
            {
                SetValue(ProvinceSourceViewProperty, value);
            }
            get
            {
                return GetValue(ProvinceSourceViewProperty);
            }
        }

        /// <summary>
        //
        /// </summary>
        public static readonly DependencyProperty CountryProperty =
            DependencyProperty.Register(
            "CountryPath",
            typeof(string),
            typeof(DriverSmallControl),
            new PropertyMetadata(string.Empty));

        public string CountryPath
        {
            set
            {
                SetValue(CountryProperty, value);
            }
            get
            {
                return (string)GetValue(CountryProperty);
            }
        }
        public static readonly DependencyProperty AssistNameCountryProperty =
          DependencyProperty.Register(
          "AssistNameCountry",
          typeof(string),
          typeof(DriverSmallControl),
          new PropertyMetadata(string.Empty));

        public string AssistNameCountry
        {
            set
            {
                SetValue(AssistNameCountryProperty, value);
            }
            get
            {
                return (string)GetValue(AssistNameCountryProperty);
            }
        }
        /// <summary>
        ///  The object is a list of drivers. Usually it shall be an incremental list.
        /// </summary>
        public static readonly DependencyProperty CountrySourceViewProperty =
            DependencyProperty.Register("CountrySourceView", typeof(object), typeof(DriverSmallControl), new PropertyMetadata(null));

        public object CountrySourceView
        {
            set
            {
                SetValue(ProvinceSourceViewProperty, value);
            }
            get
            {
                return GetValue(ProvinceSourceViewProperty);
            }
        }

        public static readonly DependencyProperty PhoneProperty =
         DependencyProperty.Register(
         "Phone",
         typeof(string),
         typeof(DriverSmallControl),
         new PropertyMetadata(string.Empty));


        /// <summary>
        ///  Set or Get the phone.
        /// </summary>
        public string Phone
        {
            set
            {
                SetValue(PhoneProperty, value);
            }
            get
            {
                return (string) GetValue(PhoneProperty);
            }
        }


        public static readonly DependencyProperty EmailProperty =
    DependencyProperty.Register(
    "Email",
    typeof(string),
    typeof(DriverSmallControl),
    new PropertyMetadata(string.Empty));

        /// <summary>
        ///  Set or Get the email.
        /// </summary>
        public string Email
        {
            set
            {
                SetValue(EmailProperty, value);
            }
            get
            {
                return (string)GetValue(PhoneProperty);
            }
        }
       
       
    }
}
