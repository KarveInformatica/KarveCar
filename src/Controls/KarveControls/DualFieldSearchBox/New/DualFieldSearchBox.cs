using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using KarveControls.Generic;
using KarveControls.KarveGrid.Events;
using Syncfusion.UI.Xaml.Grid;
using Telerik.WinControls.UI;
using DataColumn = Syncfusion.UI.Xaml.Grid.DataColumn;
using DataRow = Syncfusion.UI.Xaml.Grid.DataRow;

namespace KarveControls
{
    /// <summary>
    /// DualFieldSearchBox. SearchBox for karve win.
    /// </summary>
    [TemplatePart(Name = "PART_LabelField", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_TextField_Code", Type = typeof(TextBox))]
    [TemplatePart(Name = "PART_TextField_Value", Type = typeof(TextBox))]
    [TemplatePart(Name = "PART_Button", Type = typeof(Button))]
    [TemplatePart(Name = "PART_Image", Type = typeof(Image))]

   
    public partial class DualFieldSearchBox : Control
    {

        /// <summary>
        ///  Magnifier command dependency property.
        /// </summary>
        public static readonly DependencyProperty MagnifierCommandProperty = DependencyProperty.Register("MagnifierCommand",
            typeof(ICommand), typeof(DualFieldSearchBox));
        /// <summary>
        /// Command dependency property.
        /// </summary>  
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command",
              typeof(ICommand), typeof(DualFieldSearchBox));

        /// <summary>
        ///  Name of the assist table. The assist table is the table used to ref integrity with the previous table.
        /// </summary>
        public static readonly DependencyProperty AssistNameDependencyProperty =
            DependencyProperty.Register(
                "AssistTableName",
                typeof(string),
                typeof(DualFieldSearchBox), new PropertyMetadata(string.Empty));

        /// <summary>
        ///  Field of cross reference with the assist table. Primary Key.
        /// </summary>
        public static readonly DependencyProperty AssistDataFieldFirstDependencyProperty =
            DependencyProperty.Register(
                "AssistDataFieldFirst",
                typeof(string),
                typeof(DualFieldSearchBox), new PropertyMetadata(string.Empty));
        /// <summary>
        /// Second field that it can be used in the assist table.
        /// </summary>
        public static readonly DependencyProperty AssistDataFieldSecondDependencyProperty =
            DependencyProperty.Register(
                "AssistDataFieldSecond",
                typeof(string),
                typeof(DualFieldSearchBox), new PropertyMetadata(string.Empty));

        /// <summary>
        /// Content of the first textbox.
        /// </summary>
        public static readonly DependencyProperty TextContentFirstDependencyProperty =
            DependencyProperty.Register(
                "TextContentFirst",
                typeof(string),
                typeof(DualFieldSearchBox), new PropertyMetadata(string.Empty, OnTextContentFirstChange));
        /// <summary>
        ///  Content of the second textbox.
        /// </summary>
        public static readonly DependencyProperty TextContentSecondDependencyProperty =
            DependencyProperty.Register(
                "TextContentSecond",
                typeof(string),
                typeof(DualFieldSearchBox), new PropertyMetadata(string.Empty, OnTextContentSecondChange));
        /// <summary>
        ///  Width content of the first textbox.
        /// </summary>
        public static readonly DependencyProperty TextContentFirstWidthDependencyProperty =
            DependencyProperty.Register(
                "TextContentFirstWidth",
                typeof(string),
                typeof(DualFieldSearchBox), new PropertyMetadata(string.Empty, OnTextContentFirstWidthChange));
        /// <summary>
        ///  Width content of the second textbox
        /// </summary>
        public static readonly DependencyProperty TextContentSecondWidthDependencyProperty =
            DependencyProperty.Register(
                "TextContentSecondWidth",
                typeof(string),
                typeof(DualFieldSearchBox), new PropertyMetadata(string.Empty, OnTextContentSecondWidthChange));
        /// <summary>
        ///  Kind of image to be associated to the button in the searchbox.
        /// </summary>
        public static readonly DependencyProperty ButtonImageDependencyProperty =
            DependencyProperty.Register(
                "ButtonImage",
                typeof(string),
                typeof(DualFieldSearchBox), new PropertyMetadata("/KarveControls;component/Images/searchImage.png", OnButtonImageChange));

        /// <summary>
        /// Data Object dependency properties.
        /// </summary>
        public static readonly DependencyProperty DataObjectDependencyProperty =
            DependencyProperty.Register("DataObject",
                typeof(object),
                typeof(DualFieldSearchBox), null);

        /// <summary>
        ///  DataTable or data object to be associated with the search. Cross reference table.
        /// </summary>
        public static readonly DependencyProperty SourceViewDependencyProperty =
            DependencyProperty.Register(
                "SourceView",
                typeof(object),
                typeof(DualFieldSearchBox),
                new PropertyMetadata(null, OnSourceViewChanged));
        /// <summary>
        ///  Event associated with the magnifier press.
        /// </summary>
        public static readonly RoutedEvent MagnifierPressEvent =
            EventManager.RegisterRoutedEvent(
                "MagnifierPress",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(DualFieldSearchBox));
        /// <summary>
        ///  DataTable or data object associated with the item source.
        /// </summary>
        public static DependencyProperty ItemSourceDependencyProperty =
            DependencyProperty.Register(
                "ItemSource",
                typeof(DataTable),
                typeof(DualFieldSearchBox), new PropertyMetadata(new DataTable(), OnSearchTextBoxItemSourceChanged));

        /// <summary>
        /// Primary Key or first field to be associated with the table. It is a data table or a name of property.
        /// </summary>
        public static DependencyProperty DataFieldFirstDependencyProperty =
           DependencyProperty.Register(
               "DataFieldFirst",
               typeof(string),
               typeof(DualFieldSearchBox), new PropertyMetadata(string.Empty, OnSearchTextBoxDataFieldFirstChanged));
        /// <summary>
        /// Command associated to the changed of a property. It gets triggered when a change happens.
        /// </summary>
        public static DependencyProperty ItemChangedCommandDependencyProperty =
            DependencyProperty.Register(
                "ItemChangedCommand",
                typeof(ICommand),
                typeof(DualFieldSearchBox), new PropertyMetadata(null));

        /// ItemChangeCommand
        /// <summary>
        /// Other field to be associated optionally if there is no cross reference with the second textbox.
        /// </summary>
        public static DependencyProperty DataFieldSecondDependencyProperty =
            DependencyProperty.Register(
                "DataFieldSecond",
                typeof(string),
                typeof(DualFieldSearchBox), new PropertyMetadata(string.Empty, OnSearchTextBoxDataFieldSecondChanged));
        /// <summary>
        /// The kind of data allowed with this control: Email,Iban,Nif,etc. can be valuable values.
        /// </summary>
        public static DependencyProperty DataAllowedFirstDependencyProperty =
            DependencyProperty.Register(
                "DataAllowedFirst",
                typeof(ControlExt.DataType),
                typeof(DualFieldSearchBox), new PropertyMetadata(ControlExt.DataType.Any, OnChangedDataAllowedFirst));




        private static void OnChangedDataAllowedFirst(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox dualFieldSearchBox = d as DualFieldSearchBox;
            if (dualFieldSearchBox != null)
            {
                dualFieldSearchBox.OnDataAllowedChanged(e, true);
            }
        }

        private void OnDataAllowedChanged(DependencyPropertyChangedEventArgs e, bool firstValue)
        {
            ControlExt.DataType dataType;
            dataType = (ControlExt.DataType)Enum.Parse(typeof(ControlExt.DataType), e.NewValue.ToString());
            if (firstValue)
            {
                _dataAllowedFirst = dataType;
            }
            else
            {
                _dataAllowedSecond = dataType;
            }
        }
        /// <summary>
        /// The kind of data allowed with this control: Email,Iban,Nif,etc. can be valuable values.
        /// </summary>
        public static DependencyProperty DataAllowedSecondDependencyProperty =
            DependencyProperty.Register(
                "DataAllowedSecond",
                typeof(ControlExt.DataType),
                typeof(DualFieldSearchBox), new PropertyMetadata(ControlExt.DataType.Any, OnChangedDataAllowedSecond));

        private static void OnChangedDataAllowedSecond(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox dualFieldSearchBox = d as DualFieldSearchBox;
            if (dualFieldSearchBox != null)
            {
                dualFieldSearchBox.OnDataAllowedChanged(e, false);
            }
        }

        /// <summary>
        ///  This control can accept its data fields as list of string.
        /// </summary>
        public static DependencyProperty DataFieldsDependencyProperty =
            DependencyProperty.Register(
                "DataFields",
                typeof(IList<string>),
                typeof(DualFieldSearchBox), new PropertyMetadata(new List<string>(), OnSearchTextBoxDataFields));
        /// <summary>
        ///  Set or Get if the control is made readonly. Both first or second field.
        /// </summary>
        public static DependencyProperty IsReadOnlyProperty = DependencyProperty.Register(
            "IsReadOnly",
            typeof(bool),
            typeof(DualFieldSearchBox),
            new PropertyMetadata(false, OnIsReadOnlyProperty));
        /// <summary>
        ///  Set or Get if the control first field is readonly.
        /// </summary>
        public static DependencyProperty IsReadOnlyFirstProperty = DependencyProperty.Register(
            "IsReadOnlyFirst",
            typeof(bool),
            typeof(DualFieldSearchBox),
            new PropertyMetadata(false, OnIsReadOnlyFirstProperty));
        /// <summary>
        ///  Set or Get if the control second field is readonly.
        /// </summary>
        public static DependencyProperty IsReadOnlySecondProperty = DependencyProperty.Register(
            "IsReadOnlySecond",
            typeof(bool),
            typeof(DualFieldSearchBox),
            new PropertyMetadata(false, OnIsReadOnlySecondProperty));
        /// <summary>
        ///  Set or Get the first table name.
        /// </summary>
        public static readonly DependencyProperty TableNameDependencyProperty =
            DependencyProperty.Register(
                "TableName",
                typeof(string),
                typeof(DualFieldSearchBox),
                new PropertyMetadata(string.Empty, OnTableNameChange));
        /// <summary>
        ///  Enable/Disable Visibility of the Label.
        /// </summary>
        public static readonly DependencyProperty LabelVisibleDependencyProperty =
            DependencyProperty.Register("LabelVisible",
                typeof(bool),
                typeof(DualFieldSearchBox),
                new PropertyMetadata(false, OnLabelVisibleChange));

        static DualFieldSearchBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DualFieldSearchBox), new FrameworkPropertyMetadata(typeof(DualFieldSearchBox)));
           
        }

        #region LabelVisible
        /// <summary>
        ///  Set or Get the Label Visible: Hidden or Collasped.
        /// </summary>
        public bool LabelVisible
        {
            get { return (bool)GetValue(LabelVisibleDependencyProperty); }
            set { SetValue(LabelVisibleDependencyProperty, value); }
        }

        private static void OnLabelVisibleChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DualFieldSearchBox control)
            {
                control.OnLabelVisiblePropertyChanged(e);
            }
        }
        private void OnLabelVisiblePropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            bool value = Convert.ToBoolean(e.NewValue);
            TextBlock searchLabel = GetTemplateChild("PART_LabelField") as TextBlock;
            if (searchLabel == null)
            {
                return;
            }
            if (value)
            {
                searchLabel.Visibility = Visibility.Visible;
            }
            else
            {
                searchLabel.Visibility = Visibility.Collapsed;
            }
        }
        #endregion


        /// <summary>
        ///  Set or Get The TableName
        /// </summary>
        public ICommand ItemChangedCommand
        {
            get { return (ICommand)GetValue(ItemChangedCommandDependencyProperty); }
            set { SetValue(ItemChangedCommandDependencyProperty, value); }
        }


        #region TableName

        private string _tableName;
        private static void OnTableNameChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnTableNameChanged(e);
            }
        }
        /// <summary>
        ///  Set or Get The TableName
        /// </summary>
        public string TableName
        {
            get { return (string)GetValue(TableNameDependencyProperty); }
            set { SetValue(TableNameDependencyProperty, value); }
        }

        private void OnTableNameChanged(DependencyPropertyChangedEventArgs e)
        {
            _tableName = e.NewValue as string;
        }
        /// <summary>
        /// This is a data source.
        /// </summary>
        private object _dataSource;
        #endregion

        #region assist Query

        #endregion
        #region Event Magnifier Lupa
        /// <summary>
        ///  Event raised when the magnifier is pressed.
        /// </summary>
        public static readonly RoutedEvent AssistQueryChangedEvent =
            EventManager.RegisterRoutedEvent(
                "AssistQueryChangedEvent",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(DualFieldSearchBox));

        /// <summary>
        ///  Event raise when one of the two textbox is pressed.
        /// </summary>
        public static readonly RoutedEvent DataSearchTextBoxChangedEvent =
            EventManager.RegisterRoutedEvent(
                "DataSearchTextBoxChanged",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(DualFieldSearchBox));
        /// <summary>
        ///  Every time is changed a text box this event get raised.
        /// </summary>
        public event RoutedEventHandler DataSearchTextBoxChanged
        {
            add { AddHandler(DataSearchTextBoxChangedEvent, value); }
            remove { RemoveHandler(DataSearchTextBoxChangedEvent, value); }
        }
        // This is needed fro InvokeCommand Prism 
        /// <summary>
        ///  Get the event handler from the magnifier.
        /// </summary>
        public event RoutedEventHandler MagnifierPress
        {
            add { AddHandler(MagnifierPressEvent, value); }
            remove { RemoveHandler(MagnifierPressEvent, value); }
        }
        /// <summary>
        ///  Button image to be associated to the magnifier
        /// </summary>
        public string ButtonImage
        {
            get
            {
                return (string)GetValue(ButtonImageDependencyProperty);
            }
            set
            {
                SetValue(ButtonImageDependencyProperty, value);
            }
        }
        #endregion
        /// <summary>
        /// First data allowed.
        /// </summary>
        public ControlExt.DataType DataAllowedFirst
        {
            get { return (ControlExt.DataType)GetValue(DataAllowedFirstDependencyProperty); }
            set { SetValue(DataAllowedFirstDependencyProperty, value); }
        }
        /// <summary>
        ///  Second data allowed.
        /// </summary>
        public ControlExt.DataType DataAllowedSecond
        {
            get { return (ControlExt.DataType)GetValue(DataAllowedSecondDependencyProperty); }
            set { SetValue(DataAllowedSecondDependencyProperty, value); }
        }

        /// <summary>
        ///  AssitTableName. Name of the table.
        /// </summary>
        public string AssistTableName
        {
            get
            {
                return (string)GetValue(AssistNameDependencyProperty);
            }
            set
            {
                SetValue(AssistNameDependencyProperty, value);
            }
        }

        /// <summary>
        ///  Get or Set the assist data field. This is the first field to be crossreferenced.
        /// </summary>
        public string AssistDataFieldFirst
        {
            get
            {
                return (string)GetValue(AssistDataFieldFirstDependencyProperty);
            }
            set
            {
                SetValue(AssistDataFieldFirstDependencyProperty, value);
            }
        }
        /// <summary>
        ///  Get or Set the assist data field second for the assist query. This is the second name, generally readonly to be used.
        /// </summary>
        public string AssistDataFieldSecond
        {
            get
            {
                return (string)GetValue(AssistDataFieldSecondDependencyProperty);
            }
            set
            {
                SetValue(AssistDataFieldSecondDependencyProperty, value);
            }
        }
        /// <summary>
        /// Get or Set the data field first for the assist query.
        /// </summary>
        public string DataFieldFirst
        {
            get
            {
                return (string)GetValue(DataFieldFirstDependencyProperty);
            }
            set
            {
                SetValue(DataFieldFirstDependencyProperty, value);
            }
        }
        /// <summary>
        /// Get or Set the data field second for the assist query.
        /// </summary>
        public string DataFieldSecond
        {
            get
            {
                return (string)GetValue(DataFieldSecondDependencyProperty);
            }
            set
            {
                SetValue(DataFieldSecondDependencyProperty, value);
            }
        }
        /// <summary>
        /// Get or Set the data fields in the searchbox.
        /// </summary>
        public IList<string> DataFields
        {
            get
            {
                return (IList<string>)GetValue(DataFieldsDependencyProperty);
            }
            set
            {
                SetValue(DataFieldSecondDependencyProperty, value);
            }
        }
        /// <summary>
        /// LabelText.
        /// </summary>
        public string LabelText
        {
            get { return (string)GetValue(LabelTextDependencyProperty); }
            set
            {
                SetValue(LabelTextDependencyProperty, value);
            }
        }

        /// <summary>
        /// Assist Query to be used.
        /// </summary>
        public static readonly DependencyProperty AssistQueryDependencyProperty =
            DependencyProperty.Register(
                "AssistQuery",
                typeof(string),
                typeof(DualFieldSearchBox),
                new PropertyMetadata(string.Empty));

        /// <summary>
        ///  Set/Get the assist query.
        /// </summary>
        public string AssistQuery
        {
            get { return (string)GetValue(AssistQueryDependencyProperty); }
            set
            {
                SetValue(AssistQueryDependencyProperty, value);
            }
        }

        /// <summary>
        /// Assist Query to be used.
        /// </summary>
        public static readonly DependencyProperty AssistPropertiesDependencyProperty =
            DependencyProperty.Register(
                "AssistProperties",
                typeof(string),
                typeof(DualFieldSearchBox),
                new PropertyMetadata(string.Empty));

        /// <summary>
        /// AssistProperties. 
        /// </summary>
        public string AssistProperties
        {
            get { return (string)GetValue(AssistPropertiesDependencyProperty); }
            set { SetValue(AssistPropertiesDependencyProperty, value); }
        }

        /// <summary>
        ///  Dependency property for the data object.
        /// </summary>
        public static readonly DependencyProperty DataSourceDependencyProperty =
            DependencyProperty.Register(
                "DataSource",
                typeof(object),
                typeof(DualFieldSearchBox), new PropertyMetadata(null, OnDataSourceChanged));
        /// <summary>
        ///  DataSource dependency property.
        /// </summary>
        public object DataSource
        {
            get { return GetValue(DataSourceDependencyProperty); }
            set
            {
                SetValue(DataSourceDependencyProperty, value);
            }
        }
        /// <summary>
        ///  This gives us a data source changed.
        /// </summary>
        /// <param name="d">Dependency object to be used.</param>
        /// <param name="e">Depenendncy propperties to be used.</param>
        private static void OnDataSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox dualFieldSearchBox = d as DualFieldSearchBox;
            if (dualFieldSearchBox != null)
            {
                dualFieldSearchBox.OnDataSourceChanged(e);
            }
        }


        /// <summary>
        /// This handle the object data change.
        /// </summary>
        /// <param name="e"></param>
        private void OnDataSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null)
            {
                return;
            }
            object value = e.NewValue;
            _dataSource = value;

            DataRow[] filteredRows = null;
            Type type = value.GetType();
            object tableSource = SourceView;


            string codeFirst = AssistDataFieldFirst;
            string codeSecond = "";
            if (!string.IsNullOrEmpty(codeFirst))
            {
                string[] fields = AssistProperties.Split(',');
                if (fields.Length >= 2)
                {
                    codeFirst = fields[0];
                    codeSecond = fields[1];
                }
            }
            var textDo = ComponentUtils.GetTextDo(value, DataFieldFirst, DataAllowedFirst);
            var source = SourceView as IEnumerable;

            if (source != null)
            {
                // find the code in _sourceView
                foreach (var assistValue in source)
                {
                    var firstValue = ComponentUtils.GetPropValue(assistValue, codeFirst);
                    var secondValue = ComponentUtils.GetPropValue(assistValue, codeSecond);
                    if ((firstValue != null) && (secondValue != null))
                    {
                        string textFirstValue = firstValue.ToString();

                        if (textFirstValue == textDo)
                        {
                            TextContentFirst = textDo;
                            TextContentSecond = secondValue.ToString();
                        }
                    }
                }
            }


        }

        /// <summary>
        /// Label Text to be used.
        /// </summary>
        public static readonly DependencyProperty LabelTextDependencyProperty =
            DependencyProperty.Register(
                "LabelText",
                typeof(string),
                typeof(DualFieldSearchBox),
                new PropertyMetadata(string.Empty));
        /// <summary>
        ///  Width of the label to be used.
        /// </summary>
        public static readonly DependencyProperty LabelWidthDependencyProperty =
            DependencyProperty.Register(
                "LabelWidth",
                typeof(string),
                typeof(DualFieldSearchBox), new PropertyMetadata(string.Empty, OnLabelWidthChange));

        /// <summary>
        ///  PageSize to be used.
        /// </summary>
        public const int DefaultPageSize = 100;

        // data field first text box
        private string _dataFieldFirst = String.Empty;
        // data field second text box
        private string _dataFieldSecond = String.Empty;
        // magnifier needed (the control is allowed to be search)
        private IList<string> _dataFields = new List<string>();

        // auxiliar data table
        private object _sourceView = new DataTable();
        // data table for the data text
        private DataTable _dataTable = new DataTable();
        private static int _buttonManifierState = 0;
        private SfDataGrid _magnifierGrid = new SfDataGrid();
        private Popup _popUp = new Popup();
        private ControlExt.DataType _dataAllowedFirst;
        private ControlExt.DataType _dataAllowedSecond;
        private readonly ComponentFiller _componentFiller;
        private bool _firstSelection = true;
        private TextBox _searchTextFirst;
        private TextBox _searchTextSecond;
        private Button _buttonImage;
        /// <summary>
        /// This is a component with a grid table associated.
        /// </summary>
        public DualFieldSearchBox() : base()
        {
            _componentFiller = new ComponentFiller();
            _searchTextFirst = GetTemplateChild("PART_TextField_Code") as TextBox;
            if (_searchTextFirst!=null)
            {
                _searchTextFirst.TextChanged += SearchText_TextChanged;
            }
            _searchTextSecond = GetTemplateChild("PART_TextField_Value") as TextBox;
            if (_searchTextSecond != null)
            {
                _searchTextSecond.TextChanged += SearchText_TextChanged;
            }
            _buttonImage = GetTemplateChild("PART_ButtonImage") as Button;
            if (_buttonImage != null)
            {
                _buttonImage.Click += ButtonImageOnClick;
            }
            RaiseMagnifierPressEvent();
        }

        private void ButtonImageOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            MessageBox.Show("Clicked Button");
        }

        private void SearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            

        }

        private void SearchTextOnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
           
        }

        /// <summary>
        /// This method compute the filed format needed for selecting in the data table of the dual field search box.
        /// </summary>
        /// <param name="itemSource">DataTable needed to look for</param>
        /// <param name="dataFieldFirst">Primary key to search for in the item source</param>
        /// <param name="valueToFind">Value to find in the data table</param>
        /// <param name="assistDataField">Cross reference field to look for.</param>
        /// <returns></returns>
        private string ComputeFieldFormat(DataTable itemSource, string dataFieldFirst, string valueToFind, string assistDataField)
        {
            string fieldFormat = "";
           
            return fieldFormat;
        }
        /// <summary>
        ///  Label Width
        /// </summary>
        public string LabelWidth
        {
            get { return (string)GetValue(LabelWidthDependencyProperty); }
            set { SetValue(LabelWidthDependencyProperty, value); }
        }
        /// <summary>
        ///  TextContent of the first box.
        /// </summary>
        public string TextContentFirst
        {
            get { return (string)GetValue(TextContentFirstDependencyProperty); }
            set { SetValue(TextContentFirstDependencyProperty, value); }
        }
        /// <summary>
        ///  TextContent of the second box.
        /// </summary>
        public string TextContentSecond
        {
            get { return (string)GetValue(TextContentSecondDependencyProperty); }
            set { SetValue(TextContentSecondDependencyProperty, value); }
        }
        /// <summary>
        ///  Width of the content width
        /// </summary>
        public string TextContentFirstWidth
        {
            get { return (string)GetValue(TextContentFirstWidthDependencyProperty); }
            set { SetValue(TextContentFirstWidthDependencyProperty, value); }
        }
        /// <summary>
        /// width of the second content.
        /// </summary>
        public string TextContentSecondWidth
        {
            get { return (string)GetValue(TextContentSecondWidthDependencyProperty); }
            set { SetValue(TextContentSecondWidthDependencyProperty, value); }
        }
        /// <summary>
        ///  Set/Get the command for the magnifier.
        /// </summary>
        public ICommand MagnifierCommand
        {
            get { return (ICommand)GetValue(MagnifierCommandProperty); }
            set { SetValue(MagnifierCommandProperty, value); }
        }
        /// <summary>
        /// Set or Get the command for the source.
        /// </summary>
        public DataTable ItemSource
        {
            get { return (DataTable)GetValue(ItemSourceDependencyProperty); }
            set { SetValue(ItemSourceDependencyProperty, value); }
        }
        /// <summary>
        ///  Assist data table to be referenced.
        /// </summary>
        public object SourceView
        {
            get { return GetValue(SourceViewDependencyProperty); }
            set
            {
                SetValue(SourceViewDependencyProperty, value);
                if (_buttonManifierState == 1)
                {
                    _popUp.IsOpen = true;
                }
            }
        }
        /// <summary>
        /// Dependency Properties width of the label to be used.
        /// </summary>
        #region LabelTextWidth 
        public readonly static DependencyProperty LabelTextWidthDependencyProperty =
            DependencyProperty.Register(
                "LabelTextWidth",
                typeof(string),
                typeof(DualFieldSearchBox),
                new PropertyMetadata(string.Empty, OnLabelTextWidthChange));
        private TextBlock _searchLabel;

        /// <summary>
        ///  Label text width
        /// </summary>
        public string LabelTextWidth
        {
            get { return (string)GetValue(LabelTextWidthDependencyProperty); }
            set { SetValue(LabelTextWidthDependencyProperty, value); }
        }
        private static void OnLabelTextWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnLabelTextWidthChanged(e);
            }
        }

        private void OnLabelTextWidthChanged(DependencyPropertyChangedEventArgs e)
        {
            double value = Convert.ToDouble(e.NewValue);
            _searchLabel = GetTemplateChild("PART_LabelField") as TextBlock;
            if (_searchLabel != null)
            {
                _searchLabel.Width = value;
            }
        }
        #endregion
        /// <summary>
        ///  Read only both fields
        /// </summary>
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }
        /// <summary>
        ///  Set read only the first field of the search box
        /// </summary>
        public bool IsReadOnlyFirst
        {
            get { return (bool)GetValue(IsReadOnlyFirstProperty); }
            set { SetValue(IsReadOnlyFirstProperty, value); }
        }
        /// <summary>
        ///  Set readonly the second field of the search box.
        /// </summary>
        public bool IsReadOnlySecond
        {
            get { return (bool)GetValue(IsReadOnlySecondProperty); }
            set { SetValue(IsReadOnlySecondProperty, value); }
        }

        private static void OnIsReadOnlyFirstProperty(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox dualFieldSearchBox = d as DualFieldSearchBox;
            if (dualFieldSearchBox != null)
            {
                dualFieldSearchBox.OnReadOnlySet(e, true);
            }
        }
        private static void OnIsReadOnlySecondProperty(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox dualFieldSearchBox = d as DualFieldSearchBox;
            if (dualFieldSearchBox != null)
            {
                dualFieldSearchBox.OnReadOnlySet(e, false);
            }
        }
        private void OnReadOnlySet(DependencyPropertyChangedEventArgs e, bool eventReadOnly)
        {
            bool value = Convert.ToBoolean(e.NewValue);
           
            if (eventReadOnly)
            {
                _searchTextFirst.IsReadOnly = value;
                if (value)
                {
                    _searchTextFirst.Background = Brushes.LightCyan;
                }
                else
                {
                    _searchTextFirst.Background = Brushes.White;
                }
            }
            else
            {
                _searchTextSecond.IsReadOnly = value;
                if (value)
                {
                    _searchTextSecond.Background = Brushes.LightCyan;
                }
                else
                {
                    _searchTextSecond.Background = Brushes.White;
                }
            }
        }
        private static void OnSourceViewChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnSourceViewPropertyChanged(e);
            }
        }

        private void UpdateValues<Assist, Current>(Assist currentView, Current itemSource)
        {
            if (currentView is IEnumerable)
            {
                HandleSourceViewAsEnumerable(currentView, itemSource);
            }
        }
        /// <summary>
        ///  HandleSourceViewAsEnumerable.
        /// </summary>
        /// <param name="currentView"></param>
        /// <param name="itemSource"></param>
        private void HandleSourceViewAsEnumerable(object currentView, object itemSource)
        {
            IEnumerable currentEnumerable = (IEnumerable)currentView;
            Type dataType = itemSource.GetType();
            // Get the string Value of the object.
            if (currentEnumerable == null)
                return;

            var itemToFind = ComponentUtils.GetTextDo(itemSource, DataFieldFirst, DataAllowedFirst);
            bool objectFound = false;
            string textContentFirst = "";
            string textContentSecond = "";

            foreach (var currentDto in currentEnumerable)
            {

                if (!string.IsNullOrEmpty(AssistProperties))
                {
                    string[] fieldList = AssistProperties.Split(',');
                    textContentFirst = ComponentUtils.GetPropValue(currentDto, fieldList[0]) as string;
                    textContentSecond = ComponentUtils.GetPropValue(currentDto, fieldList[1]) as string;
                    if (textContentFirst == itemToFind)
                    {
                        // bingo.
                        objectFound = true;
                        break;
                    }
                }
                else
                {
                    // we shall use the assist fields.
                    textContentFirst = ComponentUtils.GetPropValue(currentDto, AssistDataFieldFirst) as string;
                    textContentSecond = ComponentUtils.GetPropValue(currentDto, AssistDataFieldSecond) as string;
                    if (textContentFirst == itemToFind)
                    {
                        // bingo.
                        objectFound = true;
                        break;
                    }
                }

            }
            if (objectFound)
            {
                TextContentFirst = textContentFirst;
                TextContentSecond = textContentSecond;
            }

        }
        private void OnSourceViewPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            DataTable currentTable = null;
            var data = DataSource;
            if (e.NewValue is DataTable)
            {
                currentTable = e.NewValue as DataTable;
            }
            else if (e.NewValue is DataSet)
            {
                string tableName = AssistTableName;
                var currentDataSet = e.NewValue as DataSet;
                currentTable = currentDataSet.Tables[tableName];
            }
            IEnumerable enumerableValue = e.NewValue as IEnumerable;
            if (enumerableValue != null)
            {
                _magnifierGrid.ItemsSource = enumerableValue;
                if (_buttonManifierState == 1)
                {
                    _firstSelection = true;
                    _popUp.IsOpen = true;
                    _buttonManifierState = 0;
                    return;
                }
                if (DataSource != null)
                {
                    HandleSourceViewAsEnumerable(enumerableValue, DataSource);
                }
                
            }
            if (currentTable != null)
            {
               _magnifierGrid.ItemsSource = currentTable;
                if (_buttonManifierState == 1)
                {
                    _firstSelection = true;
                    _popUp.IsOpen = true;
                    _buttonManifierState = 0;

                }
                UpdateValues(currentTable, ItemSource);
                _sourceView = currentTable;
            }
        }

        private static void OnButtonImageChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnButtonImageChange(e);
            }
        }
        private void OnButtonImageChange(DependencyPropertyChangedEventArgs e)
        {
            string value = e.NewValue as string;
            if (value != null)
            {
                Uri uriSource = new Uri(value, UriKind.Relative);
                this.PopUpButtonImage.Source = new BitmapImage(uriSource);
            }
        }
        private void RaiseMagnifierPressEvent()
        {
            MagnifierPressEventArgs args = new MagnifierPressEventArgs(MagnifierPressEvent);
            if (string.IsNullOrEmpty(this.AssistQuery))
            {
                AssistQuery = ComputeAssistQuery(AssistDataFieldFirst, AssistDataFieldSecond, AssistTableName);
            }
            if (!string.IsNullOrEmpty(AssistQuery))
            {
                args.AssistQuery = this.AssistQuery;
                args.TableName = AssistTableName;
                args.AssistParameters.Add("AssistFieldFirst", AssistDataFieldFirst);
                _buttonManifierState = 1;
                IDictionary<string, string> valueDictionary = new Dictionary<string, string>();
                valueDictionary["AssistTable"] = AssistTableName;
                valueDictionary["DataFieldFirst"] = DataFieldFirst;
                valueDictionary["DataFieldSecond"] = DataFieldSecond;
                valueDictionary["AssitFieldFirst"] = AssistDataFieldFirst;
                valueDictionary["AssitFieldSecond"] = AssistDataFieldSecond;
                valueDictionary["AssistQuery"] = AssistQuery;
                // args.ChangedValuesObjects = valueDictionary;
                if (MagnifierCommand != null)
                {

                    MagnifierCommand.Execute(valueDictionary);
                }
                else
                {
                    RaiseEvent(args);
                }
            }
        }

        private string ComputeAssistQuery(string assistDataFieldFirst, string assistDataFieldSecond, string tableName)
        {
            StringBuilder builder = new StringBuilder();
            if ((string.IsNullOrEmpty(assistDataFieldFirst)) ||
                (string.IsNullOrEmpty(assistDataFieldSecond)) ||
                (string.IsNullOrEmpty(tableName)))
            {
                return "";
            }

            builder.Append("SELECT ");
            builder.Append(assistDataFieldFirst);
            builder.Append(",");
            builder.Append(assistDataFieldSecond);
            builder.Append(" FROM ");
            builder.Append(tableName);
            return builder.ToString();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this._popUp.IsOpen = false;
            //_popup.IsOpen = false;
        }

        private void PopUpButton_OnClick(object sender, RoutedEventArgs e)
        {
            RaiseMagnifierPressEvent();
        }
        private static void OnLabelTextChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnLabelTextPropertyChanged(e);
            }
        }
        private static void OnLabelWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnLabelTextPropertyChanged(e);
            }
        }

        private static void OnTextContentFirstChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnTextContentFirstPropertyChanged(e);
            }
        }
        private static void OnTextContentSecondChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnTextContentSecondPropertyChanged(e);
            }
        }
        private static void OnTextContentFirstWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnTextContentFirstWidthPropertyChanged(e);
            }

        }
        private static void OnIsReadOnlyProperty(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnIsReadOnlyPropertyChanged(e);
            }
        }
        private void OnTextContentFirstWidthPropertyChanged(DependencyPropertyChangedEventArgs e)
        {

            _searchTextFirst = GetTemplateChild("PART_TextField_Code") as TextBox;
            if (e.NewValue != null)
            {
                this._searchTextFirst.Width = Convert.ToDouble(e.NewValue);
            }
            else
            {
                this._searchTextFirst.Width = 100;
            }
        }

        private void OnTextContentFirstPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            this.SearchTextFirst.Text = Convert.ToString(e.NewValue);
            if (!IsReadOnlyFirst)
            {
                if (!string.IsNullOrEmpty(DataFieldFirst))
                {
                    _componentFiller.FillTable(_searchTextFirst, DataFieldFirst, ref _dataTable);
                }
            }
        }
        private void OnTextContentSecondPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
   
            _searchTextSecond = GetTemplateChild("PART_TextField_Value") as TextBox;
            if (_searchTextSecond!=null)
            {
                _searchTextSecond.Text = Convert.ToString(e.NewValue);


                if (!string.IsNullOrEmpty(DataFieldSecond))
                {
                    _componentFiller.FillTable(_searchTextSecond, DataFieldSecond, ref _dataTable);
                }
            }


        }
        private void OnLabelTextPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            SearchLabel.Text = e.NewValue as string;
        }

        private static void OnSearchTextBoxItemSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnItemSourcePropertyChanged(e);
            }
        }
        private void OnItemSourcePropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            DataTable dt = e.NewValue as DataTable;
            _dataTable = dt;
            UpdateValues(_sourceView, _dataTable);


        }

        private bool IsInvalidMagnifierValue(GridViewRowInfo row)
        {
            bool retValue = (row == null) || (row.DataBoundItem == null);
            return retValue;
        }

        private void HandleObjectValue(object value)
        {
            object currentDto = value;
            if (string.IsNullOrEmpty(AssistProperties))
                return;
            string[] fieldList = AssistProperties.Split(',');

            object textContentFirst = ComponentUtils.GetPropValue(currentDto, fieldList[0].Trim());
            object textContentSecond = ComponentUtils.GetPropValue(currentDto, fieldList[1].Trim());

            if ((textContentFirst == null) || (textContentSecond == null))
            {
                return;
            }
            _componentFiller.FillDataObject(textContentFirst.ToString(), DataFieldFirst, ref _dataSource);

            TextContentFirst = textContentFirst.ToString();
            TextContentSecond = textContentSecond.ToString();

            if (_popup)
            {
                DataField.DataFieldEventArgs ev = new DataField.DataFieldEventArgs(DataSearchTextBoxChangedEvent);
                IDictionary<string, object> valueDictionary = new Dictionary<string, object>();
                valueDictionary["TableName"] = TableName;
                valueDictionary["AssitTableName"] = AssistTableName;
                valueDictionary["DataFieldFirst"] = DataFieldFirst;
                valueDictionary["DataFieldSecond"] = DataFieldSecond;
                valueDictionary["AssitFieldFirst"] = AssistDataFieldFirst;
                valueDictionary["AssitFieldSecond"] = AssistDataFieldSecond;
                valueDictionary["DataTable"] = ItemSource;
                valueDictionary["DataObject"] = this.DataSource;
                valueDictionary["AssistDataTable"] = SourceView;
                valueDictionary["ChangedCode"] = TextContentFirst;
                valueDictionary["ChangedValue"] = TextContentSecond;
                if (ItemChangedCommand != null)
                {
                    if (ItemChangedCommand.CanExecute(valueDictionary))
                    {
                        ItemChangedCommand.Execute(valueDictionary);
                    }
                }
                ev.ChangedValuesObjects = valueDictionary;
                RaiseEvent(ev);
            }
        }
        private void MagnifierGrid_OnSelectionRowChanged(object sender, RoutedEventArgs e)
        {

            /*
            GridViewSelectedCellsChangedEventArgs eventArgs = e as GridViewSelectedCellsChangedEventArgs;
            GridViewRowInfo currentRow = eventArgs?.CurrentRow;

            if (IsInvalidMagnifierValue(currentRow))
            {
                return;
            }

            if (_firstSelection)
            {
                _firstSelection = false;
                return;
            }

            DataRowView currentRowView = currentRow.DataBoundItem as DataRowView;
            if (currentRowView == null)
            {
                HandleObjectValue(currentRow.DataBoundItem);
                return;
            }
            DataRow row = currentRowView.Row;
            DataColumnCollection cols = row.Table.Columns;
            IList<string> columnNames = new List<string>();
            foreach (DataColumn col in cols)
            {
                if (col.ColumnName == AssistDataFieldFirst)
                {
                    columnNames.Add(AssistDataFieldFirst);

                }
                if (col.ColumnName == AssistDataFieldSecond)
                {
                    columnNames.Add(AssistDataFieldSecond);
                }
            }
            if (Popup.IsOpen)
            {
                if (columnNames.Count > 1)
                {
                    if (!string.IsNullOrEmpty(columnNames[0]))
                    {
                        string columnValue = Convert.ToString(row[columnNames[0]]);
                        TextContentFirst = columnValue;
                    }
                    if (!string.IsNullOrEmpty(columnNames[1]))
                    {

                        string columnValue = Convert.ToString(row[columnNames[1]]);
                        TextContentSecond = columnValue;
                    }
                    DataField.DataFieldEventArgs ev = new DataField.DataFieldEventArgs(DataSearchTextBoxChangedEvent);
                    IDictionary<string, object> valueDictionary = new Dictionary<string, object>();
                    valueDictionary["TableName"] = TableName;
                    valueDictionary["AssitTableName"] = AssistTableName;
                    valueDictionary["DataFieldFirst"] = DataFieldFirst;
                    valueDictionary["DataFieldSecond"] = DataFieldSecond;
                    valueDictionary["AssitFieldFirst"] = AssistDataFieldFirst;
                    valueDictionary["AssitFieldSecond"] = AssistDataFieldSecond;
                    valueDictionary["DataTable"] = ItemSource;
                    valueDictionary["DataObject"] = DataSource;
                    valueDictionary["AssistDataTable"] = SourceView;
                    valueDictionary["ChangedCode"] = TextContentFirst;
                    valueDictionary["ChangedValue"] = TextContentSecond;
                    if (ItemChangedCommand != null)
                    {
                        if (ItemChangedCommand.CanExecute(valueDictionary))
                        {
                            ItemChangedCommand.Execute(valueDictionary);
                        }
                    }
                    ev.ChangedValuesObjects = valueDictionary;
                    RaiseEvent(ev);
                }
                */
            }

        }
        private static void OnSearchTextBoxDataFieldFirstChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnDataFieldFirstPropertyChanged(e);
            }
        }
        private static void OnSearchTextBoxDataFieldSecondChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnDataFieldSecondPropertyChanged(e);
            }
        }
        private void OnDataFieldFirstPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            string value = e.NewValue as string;
            this.DataFieldFirst = value;
            UpdateValues(_sourceView, _dataTable);
        }
        private void OnDataFieldSecondPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            string value = e.NewValue as string;
            this.DataFieldSecond = value;
        }
        private static void OnSearchTextBoxDataFields(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnDataFieldsPropertyChanged(e);
            }
        }
        private static void OnTextContentSecondWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnTextContentSecondWidthPropertyChanged(e);
            }
        }
        private void OnTextContentSecondWidthPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                
                this.SearchTextSecond.Width = Convert.ToDouble(e.NewValue);
            }
            else
            {
                this.SearchTextSecond.Width = 100;
            }
        }
        private void OnDataFieldsPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            this.DataFields = e.NewValue as IList<string>;
        }
        private void OnIsReadOnlyPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            IsReadOnly = Convert.ToBoolean(e.NewValue);
        }
    }
}

}
