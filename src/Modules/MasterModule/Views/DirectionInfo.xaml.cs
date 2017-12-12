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
using KarveDataServices.DataTransferObject;
using Prism.Commands;

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
                typeof(DirectionInfo), new PropertyMetadata(new object()));

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
        public static readonly DependencyProperty ProvinceAssistNameDependencyProperty =
            DependencyProperty.Register(
                "ProvinceAssistName",
                typeof(string),
                typeof(DirectionInfo), new PropertyMetadata(string.Empty));

        public string ProvinceAssistName
        {
            set
            {
                SetValue(ProvinceAssistNameDependencyProperty, value);
            }
            get
            {
                return (string)GetValue(ProvinceAssistNameDependencyProperty);
            }
        }
        public static readonly DependencyProperty DirectionDependencyProperty =
            DependencyProperty.Register(
                "Direction",
                typeof(string),
                typeof(DirectionInfo), new PropertyMetadata(string.Empty));

        public string Direction
        {
            set
            {
                SetValue(DirectionDependencyProperty, value);
            }
            get
            {
                return (string)GetValue(DirectionDependencyProperty);
            }
        }
        public static readonly DependencyProperty Direction2DependencyProperty =
            DependencyProperty.Register(
                "Direction2",
                typeof(string),
                typeof(DirectionInfo), new PropertyMetadata(string.Empty));

        public string Direction2
        {
            set
            {
                SetValue(Direction2DependencyProperty, value);
            }
            get
            {
                return (string)GetValue(Direction2DependencyProperty);
            }
        }

        public static readonly DependencyProperty CityDependencyProperty =
            DependencyProperty.Register(
                "City",
                typeof(string),
                typeof(DirectionInfo), new PropertyMetadata(string.Empty));

        public string City
        {
            set
            {
                SetValue(CityDependencyProperty, value);
            }
            get
            {
                return (string)GetValue(CityDependencyProperty);
            }
        }
        public static readonly DependencyProperty ProvinceDependencyProperty =
            DependencyProperty.Register(
                "Province",
                typeof(string),
                typeof(DirectionInfo), new PropertyMetadata(string.Empty));

        public string Province
        {
            set
            {
                SetValue(ProvinceDependencyProperty, value);
            }
            get
            {
                return (string)GetValue(ProvinceDependencyProperty);
            }
        }


        public static readonly DependencyProperty CityAssistNameProperty =
            DependencyProperty.Register(
                "CityAssistName",
                typeof(string),
                typeof(DirectionInfo), new PropertyMetadata(string.Empty));
        public string CityAssistName
        {
            set
            {
                SetValue(CityAssistNameProperty, value);
            }
            get
            {
                return (string)GetValue(CityAssistNameProperty);
            }
        }

        public static readonly DependencyProperty CountryAssistNameProperty =
            DependencyProperty.Register(
                "CountryAssistName",
                typeof(string),
                typeof(DirectionInfo), new PropertyMetadata(string.Empty));

        public string CountryAssistName
        {
            set
            {
                SetValue(CountryAssistNameProperty, value);
            }
            get
            {
                return (string)GetValue(CountryAssistNameProperty);
            }
        }
  


        public static readonly DependencyProperty CountryDependencyProperty =
            DependencyProperty.Register(
                "Country",
                typeof(string),
                typeof(DirectionInfo), new PropertyMetadata(string.Empty));


        public static readonly DependencyProperty CountrySourceDependencyProperty =
            DependencyProperty.Register(
                "CountrySourceView",
                typeof(ObservableCollection<CountryDto>),
                typeof(DirectionInfo), new PropertyMetadata(new ObservableCollection<CountryDto>(), OnCountrySource));

        public string CountrySourceView
        {
            set
            {
                SetValue(CountrySourceDependencyProperty, value);
            }
            get
            {
                return (string)GetValue(CountrySourceDependencyProperty);
            }
        }
        private static void OnCountrySource(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DirectionInfo info = d as DirectionInfo;
            info?.UpdateCountry(e.NewValue);
        }

        private void UpdateCountry(object eNewValue)
        {
            this.CountrySearchBox.SourceView = eNewValue;
        }

        public static readonly DependencyProperty CitySourceDependencyProperty =
            DependencyProperty.Register(
                "CitySourceView",
                typeof(ObservableCollection<CityDto>),
                typeof(DirectionInfo), new PropertyMetadata(new ObservableCollection<CityDto>(), OnCitySource));

        public string CitySourceView
        {
            set
            {
                SetValue(CitySourceDependencyProperty, value);
            }
            get
            {
                return (string)GetValue(CitySourceDependencyProperty);
            }
        }


        private static void OnCitySource(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DirectionInfo info = d as DirectionInfo;
            info?.UpdateCity(e.NewValue);
        }

        private void UpdateCity(object newValue)
        {
            this.CitySearchBox.SourceView = newValue;
        }


        /// <summary>
        ///  province
        /// </summary>
        /// 

        public static readonly DependencyProperty ProvinceSourceDependencyProperty =
            DependencyProperty.Register(
                "ProvinceSourceView",
                typeof(ObservableCollection<ProvinciaDto>),
                typeof(DirectionInfo), new PropertyMetadata(new ObservableCollection<ProvinciaDto>(), OnProvinceSource));

        public ObservableCollection<ProvinciaDto> ProvinceSourceView
        {
            set
            {
                SetValue(ProvinceSourceDependencyProperty, value);
            }
            get
            {
                return (ObservableCollection<ProvinciaDto>)GetValue(ProvinceSourceDependencyProperty);
            }
        }
        private static void OnProvinceSource(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DirectionInfo dInfo = d as DirectionInfo;
            dInfo?.UpdateProvince(e.NewValue);
            
        }
        private void UpdateProvince(object newValue)
        {
            this.ProvinceSearchBox.SourceView = newValue;
        }

        public string Country
        {
            set
            {
                SetValue(CountryDependencyProperty, value);
            }
            get
            {
                return (string)GetValue(CountryDependencyProperty);
            }
        }
        public static readonly DependencyProperty PhoneDependencyProperty =
            DependencyProperty.Register(
                "Phone",
                typeof(string),
                typeof(DirectionInfo), new PropertyMetadata(string.Empty));

        public string Phone
        {
            set
            {
                SetValue(PhoneDependencyProperty, value);
            }
            get
            {
                return (string)GetValue(PhoneDependencyProperty);
            }
        }
        public static readonly DependencyProperty FaxDependencyProperty =
            DependencyProperty.Register(
                "Fax",
                typeof(string),
                typeof(DirectionInfo), new PropertyMetadata(string.Empty));

        public string Fax
        {
            set
            {
                SetValue(FaxDependencyProperty, value);
            }
            get
            {
                return (string)GetValue(FaxDependencyProperty);
            }
        }
        public static readonly DependencyProperty EmailDependencyProperty =
                DependencyProperty.Register(
                "Email",
                typeof(string),
                typeof(DirectionInfo), new PropertyMetadata(string.Empty));

        public ICommand AssistCommand { set; get; }
        public string Email
        {
            set
            {
                SetValue(EmailDependencyProperty, value);
            }
            get
            {
                return (string)GetValue(EmailDependencyProperty);
            }
        }
        public static readonly DependencyProperty ItemChangedDependencyProperty =
            DependencyProperty.Register(
                "ItemChangedCommand",
                typeof(ICommand),
                typeof(DirectionInfo), new PropertyMetadata(null));

        public static readonly DependencyProperty MagnifierDependencyProperty =
            DependencyProperty.Register(
                "MagnifierCommand",
                typeof(ICommand),
                typeof(DirectionInfo), new PropertyMetadata(null));
    
        private IDictionary<string, bool> ChangedMap = new Dictionary<string, bool>();
        private ProvinciaDto _provinciaDto;

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

        /// <summary>
        ///  AssistCommand
        /// </summary>
        public ICommand MagnifierCommand
        {
            set
            {
                SetValue(MagnifierDependencyProperty, value);
            }
            get
            {
                return (ICommand)GetValue(MagnifierDependencyProperty);
            }
        }

        public ProvinciaDto ProvinceDto
        {
            set
            {
                _provinciaDto = value;
                this.ProvinceSearchBox.SourceView = value;

            }
            get { return _provinciaDto; }
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
            this.AssistCommand = new DelegateCommand<object>(ExecuteMagnifier);
        }
        private void ExecuteMagnifier(object var)
        {
            if (MagnifierCommand != null)
            {
                IDictionary<string, string> valueDictionary = var as  Dictionary<string, string>;
                string citySearchBox = CitySearchBox.AssistTableName;
                var tmpValue = valueDictionary["AssistTable"];
                if (citySearchBox == tmpValue)
                {
                    valueDictionary["AssistTable"] = CityAssistName;
                }
                else if (CountrySearchBox.AssistTableName == tmpValue)
                {
                    valueDictionary["AssistTable"] = CountryAssistName;
                }
                else if (ProvinceSearchBox.AssistTableName == tmpValue)
                {
                    valueDictionary["AssistTable"] = ProvinceAssistName;
                }
                var = valueDictionary;
                MagnifierCommand.Execute(var);
            }
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
            ChangedValue(this.DirectionTextBox2.Text);
        }

        private void DirectionTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ChangedValue(this.DirectionTextBox.Text);

        }

        private void EmailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ChangedValue(this.EmailTextBox.Text);
        }

        private void ChangedValue(string value)
        {
            if (textChanged)
            {
                IDictionary<string, object> valueDictionary = new Dictionary<string, object>
                {
                    [DATAOBJECT] = DataObject,
                    [CHANGED_VALUE] = value
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
            textChanged = true;
        }

        private void FaxTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ChangedValue(this.FaxTextBox.Text);
        }

        /// <summary>
        ///  Constant for the field data table
        /// </summary>
        public static string DATAOBJECT = "DataObject";
        public static string CHANGED_VALUE = "ChangedValue";


    }
}
