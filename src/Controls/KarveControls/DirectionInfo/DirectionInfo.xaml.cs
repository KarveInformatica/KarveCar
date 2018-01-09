using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using KarveControls.Generic;
using KarveDataServices.DataTransferObject;
using NLog;
using Syncfusion.Windows.Shared;

namespace KarveControls
{
    /// <summary>
    /// Interaction logic for DirectionInfo.xaml
    /// </summary>


    public partial class DirectionInfo : UserControl
    {

        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        ///  Name of the assist table. The assist table is the table used to ref integrity with the previous table.
        /// </summary>
        public static readonly DependencyProperty DataObjectDependencyProperty =
            DependencyProperty.Register(
                "DataObject",
                typeof(object),
                typeof(DirectionInfo), new PropertyMetadata(new object(), OnDataObjectChanged));

        private static void OnDataObjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DirectionInfo info = d as DirectionInfo;
            if (info != null)
            {
                info.UpdateValues(e);
            }
        }

        private void GetAndSetDependency(object dataObject, DependencyProperty dependencyProperty, ref TextBox box, ControlExt.DataType type)
        {


            var value = GetValue(dependencyProperty) as string;
            if (!string.IsNullOrEmpty(value))
            {
                var tmpValue = value.Split('.');
                if (tmpValue.Length == 2)
                {
                    box.Text = ComponentUtils.GetTextDo(dataObject, tmpValue[1], type);
                }
            }
        }
        private void UpdateValues(DependencyPropertyChangedEventArgs ev)
        {
            object dataObject = ev.NewValue;
            if (dataObject != null)
            {
                ControlExt.DataType type = ControlExt.DataType.Any;
                GetAndSetDependency(dataObject, DirectionDependencyProperty, ref this.DirectionTextBox, type);
                GetAndSetDependency(dataObject, Direction2DependencyProperty, ref this.DirectionTextBox2, type);
                GetAndSetDependency(dataObject, EmailDependencyProperty, ref this.EmailTextBox, ControlExt.DataType.Email);
                GetAndSetDependency(dataObject, FaxDependencyProperty, ref this.FaxTextBox, type);
                GetAndSetDependency(dataObject, PhoneDependencyProperty, ref this.PhoneTextBox, type);
                //CitySearchBox.DataSource = dataObject;
                //CountrySearchBox.DataSource = dataObject;
                //ProvinceSearchBox.DataSource = dataObject;
            }
        }
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
                typeof(DirectionInfo), new PropertyMetadata(new ObservableCollection<CountryDto>()));

        public ObservableCollection<CountryDto> CountrySourceView
        {
            set
            {
                SetValue(CountrySourceDependencyProperty, (object) value);
            }
            get
            {
                return (ObservableCollection<CountryDto>)GetValue(CountrySourceDependencyProperty);
            }
        }
        public static readonly DependencyProperty CitySourceDependencyProperty =
            DependencyProperty.Register(
                "CitySourceView",
                typeof(ObservableCollection<CityDto>),
                typeof(DirectionInfo), new PropertyMetadata(null));

        public ObservableCollection<CityDto> CitySourceView
        {
            set
            { 

                SetValue(CitySourceDependencyProperty, (object) value);
            }
            get
            {
                return (ObservableCollection<CityDto>)GetValue(CitySourceDependencyProperty);
            }
        }


    

        /// <summary>
        ///  province
        /// </summary>
        /// 

        public static readonly DependencyProperty ProvinceSourceDependencyProperty =
            DependencyProperty.Register(
                "ProvinceSourceView",
                typeof(ObservableCollection<ProvinciaDto>),
                typeof(DirectionInfo), new PropertyMetadata(new ObservableCollection<ProvinciaDto>()));

        public ObservableCollection<ProvinciaDto> ProvinceSourceView
        {
            set
            {
                this.ProvinceSearchBox.SourceView = value;
                SetValue(ProvinceSourceDependencyProperty, (object) value);
            }
            get
            {
                return (ObservableCollection<ProvinciaDto>)GetValue(ProvinceSourceDependencyProperty);
            }
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
            this.PhoneTextBox.IsReadOnly = false;
            this.PhoneTextBox.LostFocus += PhoneTextBox_LostFocus;
            this.FaxTextBox.TextChanged += FaxTextBox_TextChanged;
            this.FaxTextBox.LostFocus += FaxTextBox_LostFocus;
            this.EmailTextBox.LostFocus += EmailTextBox_LostFocus;
            this.EmailTextBox.TextChanged += EmailTextBox_TextChanged;
            this.DirectionTextBox.LostFocus += DirectionTextBox_LostFocus;
            this.DirectionTextBox.TextChanged += DirectionTextBox_TextChanged;
            this.DirectionTextBox2.LostFocus += DirectionTextBox2_LostFocus;
            this.DirectionTextBox2.TextChanged += DirectionTextBox2_TextChanged;
            this.CountrySearchBox.ItemChangedCommand = new DelegateCommand<object>(OnSearchChanged);
            this.ProvinceSearchBox.ItemChangedCommand = new DelegateCommand<object>(OnSearchChanged);
            this.CitySearchBox.ItemChangedCommand = new DelegateCommand<object>(OnSearchChanged);
            this.ProvinceSearchBox.ItemChangedCommand = new DelegateCommand<object>(OnSearchChanged);
            this.DefaultLayout.DataContext = this;
            this.AssistCommand = new Prism.Commands.DelegateCommand<object>(ExecuteMagnifier);

            // AssistCommand.Execute();
        }

        private void OnSearchChanged(object obj)
        {
            ICommand cmd = GetValue(ItemChangedDependencyProperty) as ICommand;
            if (cmd != null)
            {
                cmd.Execute(obj);
            }
        }

        private void ExecuteMagnifier(object var)
        {

            if (MagnifierCommand != null)
            {
                IDictionary<string, string> valueDictionary = var as Dictionary<string, string>;
                string citySearchBox = CitySearchBox.AssistTableName;
                var tmpValue = valueDictionary["AssistTable"];

                if (citySearchBox == tmpValue)
                {
                    // DataObject = CitySearchBox.DataSource;
                    valueDictionary["AssistTable"] = CityAssistName;
                }
                else if (CountrySearchBox.AssistTableName == tmpValue)
                {
                    // DataObject = CountrySearchBox.DataSource;
                    valueDictionary["AssistTable"] = CountryAssistName;
                }
                else if (ProvinceSearchBox.AssistTableName == tmpValue)
                {
                    //valueDictionary["DataObject"] = ProvinceSearchBox.DataSource;
                    valueDictionary["AssistTable"] = ProvinceAssistName;
                }
                var = valueDictionary;
                MagnifierCommand.Execute(var);
            }

        }
        private void DirectionTextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            textChanged = true;
            RaiseEvent(e);
        }

        private void DirectionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            textChanged = true;
            RaiseEvent(e);
        }

        private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            textChanged = true;
            RaiseEvent(e);
        }

        private void FaxTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            textChanged = true;
            RaiseEvent(e);
        }

        private void DirectionTextBox2_LostFocus(object sender, RoutedEventArgs e)
        {
            ChangedValue(Direction2, this.DirectionTextBox2.Text);
        }

        private void DirectionTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ChangedValue(Direction, this.DirectionTextBox.Text);

        }

        private void EmailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            this.EmailTextBox.Text.Replace("@", "#");
            ChangedValue(Email, this.EmailTextBox.Text);
        }

        private void ChangedValue(string path, string value)
        {
            if (textChanged)
            {
                ComponentUtils.SetPropValue(DataObject, path, value);
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
                ComponentUtils.SetPropValue(DataObject, Phone, PhoneTextBox.Text);
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
            RaiseEvent(e);

        }

        private void FaxTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ChangedValue(Fax, this.FaxTextBox.Text);
        }

        /// <summary>
        ///  Constant for the field data table
        /// </summary>
        public static string DATAOBJECT = "DataObject";
        public static string CHANGED_VALUE = "ChangedValue";


    }
}
