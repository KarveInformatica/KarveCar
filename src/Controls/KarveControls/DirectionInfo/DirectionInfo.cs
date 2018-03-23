using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using KarveControls.Generic;
using KarveDataServices.DataTransferObject;
using Syncfusion.Windows.Shared;

namespace KarveControls
{
    [TemplatePart(Name = "PART_DirectionTextBox", Type = typeof(TextBox))]
    [TemplatePart(Name = "PART_DirectionTextBox2", Type = typeof(TextBox))]
    [TemplatePart(Name = "PART_CountrySearchBox", Type = typeof(DualFieldSearchBox))]
    [TemplatePart(Name = "PART_CitySearchBox", Type = typeof(DualFieldSearchBox))]
    [TemplatePart(Name = "PART_ProvinceSearchBox", Type = typeof(DualFieldSearchBox))]
    [TemplatePart(Name = "PART_PhoneTextBox", Type = typeof(TextBox))]
    [TemplatePart(Name = "PART_FaxTextBox", Type = typeof(TextBox))]
    [TemplatePart(Name = "PART_EmailTextBox", Type = typeof(TextBox))]
    [TemplatePart(Name = "PART_EmailButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_WebTextBox", Type = typeof(TextBox))]
    [TemplatePart(Name = "PART_WebButton", Type = typeof(Button))]

    public class DirectionInfo : Control
    {


        static DirectionInfo()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DirectionInfo), new FrameworkPropertyMetadata(typeof(DirectionInfo)));
         
        }
        public DirectionInfo()
        {
            this.AssistCommand = new Prism.Commands.DelegateCommand<object>(ExecuteMagnifier);
            this.WebCommand = new Prism.Commands.DelegateCommand<object>(LaunchWebBrowser);
            this.EmailCommand = new Prism.Commands.DelegateCommand<object>(LaunchMailClient);
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _firstDirection = GetTemplateChild("PART_DirectionTextBox") as TextBox;
            if (_firstDirection != null)
            {
                _firstDirection.TextChanged += DirectionTextBox_TextChanged;
                _firstDirection.IsReadOnly = false;
                _firstDirection.LostFocus += DirectionTextBox_LostFocus;
            }
            _secondDirection = GetTemplateChild("PART_DirectionTextBox2") as TextBox;
            if (_secondDirection != null)
            {
                _secondDirection.TextChanged += DirectionTextBox2_TextChanged;
                _secondDirection.LostFocus += DirectionTextBox2_LostFocus;
                _secondDirection.IsReadOnly = false;
            }
            _countrySearchBox = GetTemplateChild("PART_CountrySearchBox") as DualFieldSearchBox;
            if (_countrySearchBox != null)
            {
                _countrySearchBox.ItemChangedCommand = new DelegateCommand<object>(OnSearchChanged);
            }
                _citySearchBox = GetTemplateChild("PART_CitySearchBox") as DualFieldSearchBox;
            if (_citySearchBox != null)
            {
                _citySearchBox.ItemChangedCommand = new DelegateCommand<object>(OnSearchChanged);
            }
                _provinceSearchBox = GetTemplateChild("PART_ProvinceSearchBox") as DualFieldSearchBox;
            if (_provinceSearchBox != null)
            {
                _provinceSearchBox.ItemChangedCommand = new DelegateCommand<object>(OnSearchChanged);
            }
            _phoneTextBox = GetTemplateChild("PART_PhoneTextBox") as TextBox;
            if (_phoneTextBox != null)
            {
                _phoneTextBox.TextChanged += PhoneTextBox_TextChanged;
                _phoneTextBox.LostFocus += PhoneTextBox_LostFocus;
                _phoneTextBox.IsReadOnly = false;

            }
            _faxTextBox = GetTemplateChild("PART_FaxTextBox") as TextBox;
            if (_faxTextBox != null)
            {
                _faxTextBox.TextChanged += FaxTextBox_TextChanged;
                _faxTextBox.LostFocus += FaxTextBox_LostFocus;
                _faxTextBox.IsReadOnly = false;

            }
            _emailTextBox = GetTemplateChild("PART_EmailTextBox") as TextBox;
            if (_emailTextBox != null)
            {
                _emailTextBox.TextChanged += EmailTextBox_TextChanged;
                _emailTextBox.LostFocus += EmailTextBox_LostFocus;
                _emailTextBox.IsReadOnly = false;
            }
            _webTextBox = GetTemplateChild("PART_WebTextBox") as TextBox;
            if (_webTextBox != null)
            {
                _webTextBox.TextChanged += WebTextBox_TextChanged;
                _webTextBox.LostFocus += WebTextBox_LostFocus;
                _webTextBox.IsReadOnly = false;
            }
            UpdateControls(DataObject);
        }

     

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

        private string GetPropertyValue(object dataObject, string name, ControlExt.DataType type)
        {
            if (dataObject != null)
            {
                var tmp = ComponentUtils.GetTextDo(dataObject, name, type);
                if (type == ControlExt.DataType.Email)
                {
                    tmp = tmp.Replace("#", "@"); ;
                }
                return tmp;
            }
            return string.Empty;
        }

        private string GetDependencyValue(object dataObject, DependencyProperty dependencyProperty, ControlExt.DataType type)
        {
            string tmp = string.Empty;
            if ((dataObject == null))
            {
                return string.Empty;
            }
            var value = GetValue(dependencyProperty) as string;
            if (!string.IsNullOrEmpty(value))
            {
                var tmpValue = value.Split('.');
                if (tmpValue.Length == 2)
                {
                    tmp = GetPropertyValue(dataObject, tmpValue[1], type);
                }
                else if (tmpValue.Length == 1)
                {
                     tmp = GetPropertyValue(dataObject, tmpValue[0], type);
                }
            }
            return tmp;
        }
        private void GetAndSetDependency(object dataObject, DependencyProperty dependencyProperty, ref TextBox box, ControlExt.DataType type)
        {
            if ((dataObject == null) || (box == null))
            {
                return;
            }
            var value = GetValue(dependencyProperty) as string;
            if (!string.IsNullOrEmpty(value))
            {
                box.Text = GetDependencyValue(dataObject,dependencyProperty,type);
            }
        }

        private void UpdateValues(DependencyPropertyChangedEventArgs ev)
        {
            object dataObject = ev.NewValue;
            UpdateControls(dataObject);
        }

        private void UpdateControls(object dataObject)
        {
            if (dataObject != null)
            {
                ControlExt.DataType type = ControlExt.DataType.Any;
                GetAndSetDependency(dataObject, DirectionDependencyProperty, ref _firstDirection, type);
                GetAndSetDependency(dataObject, Direction2DependencyProperty, ref _secondDirection, type);
                GetAndSetDependency(dataObject, EmailDependencyProperty, ref _emailTextBox, ControlExt.DataType.Email);
                GetAndSetDependency(dataObject, FaxDependencyProperty, ref _faxTextBox, type);
                GetAndSetDependency(dataObject, PhoneDependencyProperty, ref _phoneTextBox, type);
                GetAndSetDependency(dataObject, WebDependencyProperty, ref _webTextBox, type);
            }
        }
        /// <summary>
        ///  Data object used for the direction.
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
  
        /// <summary>
        ///  This enable or disable the second direction information.
        /// </summary>
        public Visibility IsSecondEnabled
        {
            set
            {
                _isSecondEnabled = value;
            }
            get
            {
                return _isSecondEnabled;
            }
        }
        public static readonly DependencyProperty HideDirectionDependencyProperty =
               DependencyProperty.Register(
               "HideSecondDirection",
               typeof(bool),
               typeof(DirectionInfo), new PropertyMetadata(false, HideDirectionChangedCallback));
       
        /// <summary>
        ///  Hide second direction dependency property.
        /// </summary>
        public bool HideSecondDirection
        {
            set
            {
                SetValue(HideDirectionDependencyProperty, value);
            }
            get
            {
                return (bool)GetValue(HideDirectionDependencyProperty);
            }
        }
        private static void HideDirectionChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DirectionInfo directionInfo = d as DirectionInfo;
            if (directionInfo != null)
            {
                directionInfo.HideOrShowSecondDirection(e.NewValue);
            }
        }
        private void HideOrShowSecondDirection(object newValue)
        {
            bool secondDirection = Convert.ToBoolean(newValue);
            if (secondDirection)
            {
               IsSecondEnabled = Visibility.Collapsed;          
            }
            else
            {
                IsSecondEnabled = Visibility.Visible;
            }
        }
        /// <summary>
        ///  Assist depenency propepty name for looking up the province.
        /// </summary>
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
                typeof(IEnumerable<CountryDto>),
                typeof(DirectionInfo), new PropertyMetadata(null));

        public IEnumerable<CountryDto> CountrySourceView
        {
            set
            {
                SetValue(CountrySourceDependencyProperty, (object) value);
            }
            get
            {
                return (IEnumerable<CountryDto>)GetValue(CountrySourceDependencyProperty);
            }
        }
        public static readonly DependencyProperty CitySourceDependencyProperty =
            DependencyProperty.Register(
                "CitySourceView",
                typeof(IEnumerable<CityDto>),
                typeof(DirectionInfo));
        
        public IEnumerable<CityDto> CitySourceView
        {
            set
            { 

                SetValue(CitySourceDependencyProperty, (object) value);
            }
            get
            {
                return (IEnumerable<CityDto>)GetValue(CitySourceDependencyProperty);
            }
        }


    

        /// <summary>
        ///  province
        /// </summary>
        /// 
        
        public static readonly DependencyProperty ProvinceSourceDependencyProperty =
            DependencyProperty.Register(
                "ProvinceSourceView",
                typeof(IEnumerable<ProvinciaDto>),
                typeof(DirectionInfo), new PropertyMetadata(null));

        public ObservableCollection<ProvinciaDto> ProvinceSourceView
        {
            set
            {
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


        public static readonly DependencyProperty WebDependencyProperty =
            DependencyProperty.Register(
                "Web",
                typeof(string),
                typeof(DirectionInfo), new PropertyMetadata(string.Empty));

        /// <summary>
        ///  Web dependency property.
        /// </summary>
        public string Web
        {
            set
            {
                SetValue(WebDependencyProperty, value);
            }
            get
            {
                return (string)GetValue(WebDependencyProperty);
            }
        }
        public ICommand AssistCommand { set; get; }
        public ICommand EmailCommand { set; get; }
        public ICommand WebCommand { set; get; }

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

        private void LaunchMailClient(object value)
        {
            var tmp = GetDependencyValue(DataObject, EmailDependencyProperty, ControlExt.DataType.Email);
            if (tmp?.Length>0)
            {
                string emailUrl = "mailto:" + tmp + "?subject=KarveCar";
                System.Diagnostics.Process.Start(emailUrl);
            }
        }
        private void LaunchWebBrowser(object value)
        {
            var tmp = Web;
            if (tmp?.Length > 0)
            {
                System.Diagnostics.Process.Start(tmp);
            }
        }
        public ProvinciaDto ProvinceDto
        {
            set
            {
                _provinciaDto = value;
                if (_provinceSearchBox != null)
                {
                    _provinceSearchBox.SourceView = value;
                }
            }
            get { return _provinciaDto; }
        }

        private bool textChanged = false;
     

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
                string citySearchBox = _citySearchBox.AssistTableName;
                var tmpValue = valueDictionary["AssistTable"];

                if (citySearchBox == tmpValue)
                {
                    valueDictionary["AssistTable"] = CityAssistName;
                }
                else if (_countrySearchBox.AssistTableName == tmpValue)
                {
                    valueDictionary["AssistTable"] = CountryAssistName;
                }
                else if (_provinceSearchBox.AssistTableName == tmpValue)
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
            ChangedValue(Direction2, _secondDirection.Text);
        }

        private void DirectionTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ChangedValue(Direction, _firstDirection.Text);

        }

        private void EmailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            _emailTextBox.Text.Replace("@", "#");
            ChangedValue(Email, _emailTextBox.Text);
        }
        private void WebTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
           ChangedValue(Web, _webTextBox.Text);
            Web = _webTextBox.Text;
        }

        private void WebTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            textChanged = true;
            Web = _webTextBox.Text;
            RaiseEvent(e);
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
                ComponentUtils.SetPropValue(DataObject, Phone, _phoneTextBox.Text);
                IDictionary<string, object> valueDictionary = new Dictionary<string, object>
                {
                    [DATAOBJECT] = DataObject,
                    [CHANGED_VALUE] = _phoneTextBox.Text
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
            ChangedValue(Fax, _faxTextBox.Text);
        }
        /// <summary>
        ///  Constant for the field data table
        /// </summary>
        public static string DATAOBJECT = "DataObject";
        public static string CHANGED_VALUE = "ChangedValue";
        private TextBox _firstDirection;
        private TextBox _secondDirection;
        private DualFieldSearchBox _countrySearchBox;
        private DualFieldSearchBox _citySearchBox;
        private DualFieldSearchBox _provinceSearchBox;
        private TextBox _phoneTextBox;
        private TextBox _faxTextBox;
        private TextBox _emailTextBox;
        private TextBox _webTextBox;
        private Visibility _isSecondEnabled;
    }
}
