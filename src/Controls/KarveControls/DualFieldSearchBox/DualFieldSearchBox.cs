using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using KarveControls.Generic;
using Syncfusion.UI.Xaml.Grid;
using NLog;
using System.Windows.Controls.Primitives;
using static KarveControls.DataField;
using Prism.Commands;

namespace KarveControls
{
    /// <summary>
    /// User control for a search box. 
    /// It allows us to have a single field or a doble field search box with a valid magnifier.
    /// </summary>
    ///
    [TemplatePart(Name = "PART_SearchLabel", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_SearchTextFirst", Type = typeof(TextBox))]
    [TemplatePart(Name = "PART_SearchTextSecond", Type = typeof(TextBox))]
    [TemplatePart(Name = "PART_MagnifierGrid", Type = typeof(SfDataGrid))]
    [TemplatePart(Name = "PART_PopUp", Type = typeof(Popup))]
   [TemplatePart(Name = "PART_PopUpButtonImage", Type = typeof(Image))]
     
      
    public partial class DualFieldSearchBox : TextBox
    {

        // private SfDataGrid MagnifierGrid = new SfDataGrid();
        // most of the shared ones shall be moved as attached properties 
        private Logger logger = LogManager.GetCurrentClassLogger();
        private bool triggerLoad = false;
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
        /// AssistName is a label to be identified from the view model to look for a query and set the resoult.
        /// </summary>
        public static readonly DependencyProperty AssistNameDependencyProperty =
            DependencyProperty.Register(
                "AssistTableName",
                typeof(string),
                typeof(DualFieldSearchBox), new PropertyMetadata(string.Empty));

        /// <summary>
        ///  Field of cross reference with the assist table. Primary Key. 
        ///  AssistDataFields are used when we have not set the assist query.
        /// </summary>
        public static readonly DependencyProperty AssistDataFieldFirstDependencyProperty =
            DependencyProperty.Register(
                "AssistDataFieldFirst",
                typeof(string),
                typeof(DualFieldSearchBox), new PropertyMetadata(string.Empty));
        /// <summary>
        /// Second field that it can be used in the assist table.
        ///  AssistDataFields are used when we have not set the assist query 
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
                typeof(DualFieldSearchBox), new PropertyMetadata("100", OnTextContentFirstWidthChange));
        /// <summary>
        ///  Width content of the second textbox
        /// </summary>
        public static readonly DependencyProperty TextContentSecondWidthDependencyProperty =
            DependencyProperty.Register(
                "TextContentSecondWidth",
                typeof(string),
                typeof(DualFieldSearchBox), new PropertyMetadata("200", OnTextContentSecondWidthChange));
        /// <summary>
        ///  Kind of image to be associated to the button in the searchbox.
        /// </summary>
        public static readonly DependencyProperty ButtonImageDependencyProperty =
            DependencyProperty.Register(
                "ButtonImage",
                typeof(string),
                typeof(DualFieldSearchBox), new PropertyMetadata("/KarveControls;component/Images/search.png", OnButtonImageChange));
        /// <summary>
        /// Data Object dependency properties.
        /// </summary>
        public static readonly DependencyProperty DataObjectDependencyProperty = DependencyProperty.Register("DataObject",
                                                    typeof(object),
                                                    typeof(DualFieldSearchBox));
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
        ///  When the magnifier got pressed we send this routed event bubbling to the view model and can be detected with blend interactivity.
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

            var dataType = (ControlExt.DataType)Enum.Parse(typeof(ControlExt.DataType), e.NewValue.ToString());
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
        public new static DependencyProperty IsReadOnlyProperty = DependencyProperty.Register(
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
            var control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnLabelVisiblePropertyChanged(e);
            }
        }

        private void OnLabelVisiblePropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null)
                return;
            bool value = Convert.ToBoolean(e.NewValue);
            if (SearchLabel != null)
            {
                if (value)
                {
                    SearchLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    SearchLabel.Visibility = Visibility.Collapsed;
                }
            }
        }
        #endregion

        public ICommand PopUpOpenCommand { get; set; }
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
            add => AddHandler(MagnifierPressEvent, value);
            remove => RemoveHandler(MagnifierPressEvent, value);
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
        public static readonly DependencyProperty ColumnsDependencyProperty =
            DependencyProperty.Register(
                "Columns",
                typeof(string),
                typeof(DualFieldSearchBox),
                new PropertyMetadata(string.Empty));

        /// <summary>
        /// AssistProperties. 
        /// </summary>
        public string ColumnsProperties
        {
            get { return (string)GetValue(ColumnsDependencyProperty); }
            set { SetValue(ColumnsDependencyProperty, value); }
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

        private string CheckTheValueInSourceView(string value)
        {
            var source = SourceView as IEnumerable;
            if (source != null)
            {


                foreach (var assistValue in source)
                {
                    var firstValue = ComponentUtils.GetPropValue(assistValue, _codeFirst);
                    var secondValue = ComponentUtils.GetPropValue(assistValue, _codeSecond);
                    if ((firstValue != null) && (secondValue != null))
                    {
                        if ((!string.IsNullOrEmpty(firstValue.ToString()))
                            && (!string.IsNullOrEmpty(secondValue.ToString())))
                        {

                            if (firstValue.ToString() == value)
                            {
                                return secondValue.ToString();
                            }
                        }
                    }
                }
            }
            return string.Empty;
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
            _codeFirst = AssistDataFieldFirst;
            _codeSecond = AssistDataFieldSecond;
            if (!string.IsNullOrEmpty(AssistProperties))
            {
                string[] fields = AssistProperties.Split(',');
                if (fields.Length >= 2)
                {
                    _codeFirst = fields[0];
                    _codeSecond = fields[1];
                }
            }
            var textDo = ComponentUtils.GetTextDo(value, DataFieldFirst, DataAllowedFirst);
            var source = SourceView as IEnumerable;
            if (source != null)
            {
                // find the code in _sourceView
                foreach (var assistValue in source)
                {
                    var firstValue = ComponentUtils.GetPropValue(assistValue, _codeFirst);
                    var secondValue = ComponentUtils.GetPropValue(assistValue, _codeSecond);
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
        private const string ValueStr = "Value";
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
        private ControlExt.DataType _dataAllowedFirst;
        private ControlExt.DataType _dataAllowedSecond;
        private readonly ComponentFiller _componentFiller;
        private bool _firstSelection = true;

        private bool _textMode = false;
        private TextBox SearchTextFirst;
        private TextBox SearchTextSecond;
        private Popup Popup;
        private SfDataGrid MagnifierGrid;
        private Image PopUpButtonImage;
        private TextBlock SearchLabel;

        static DualFieldSearchBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DualFieldSearchBox), new FrameworkPropertyMetadata(typeof(DualFieldSearchBox)));
        }
        /// <summary>
        /// This is a component with a grid table associated.
        /// </summary>
        public DualFieldSearchBox() : base()
        {
            _componentFiller = new ComponentFiller();
            PopUpCloseCommand = new DelegateCommand(ButtonBase_OnClick);
            PopUpOpenCommand = new DelegateCommand(PopUpButton_OnClick);

        }


        public DelegateCommand PopUpCloseCommand { get; set; }


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            SearchTextFirst = GetTemplateChild("PART_SearchTextFirst") as TextBox;
            SearchTextSecond = GetTemplateChild("PART_SearchTextSecond") as TextBox;
            if (SearchTextFirst != null)
            {
                SearchTextFirst.TextChanged += SearchText_TextChanged;
            }
            if (SearchTextSecond != null)
            {
                SearchTextSecond.TextChanged += SearchText_TextChanged;
            }
            Popup = GetTemplateChild("PART_PopUp") as Popup;
           
            PopUpButtonImage = GetTemplateChild("PART_PopUpButtonImage") as Image;
            SearchLabel = GetTemplateChild("PART_SearchLabel") as TextBlock;
            MagnifierGrid = GetTemplateChild("PART_MagnifierGrid") as SfDataGrid;
            if (MagnifierGrid != null)
            {
                MagnifierGrid.SelectionChanged += MagnifierGrid_OnSelectionRowChanged;
                MagnifierGrid.MouseDoubleClick += MagnifierGrid_MouseDoubleClick;

            }
            triggerLoad = true;
            RaiseMagnifierPressEvent();
            triggerLoad = false;
        }

        private void MagnifierGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Popup != null)
            {
                if (Popup.IsOpen)
                {
                    var value = MagnifierGrid.SelectedItem;
                    if (value == null)
                    {
                        return;
                    }
                    HandleObjectValue(value);
                    Popup.IsOpen = false;
                }
            }
        }

       
        
       private void SearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchTxtFirst = SearchTextFirst.Text;
            string currentValueSecond = CheckTheValueInSourceView(searchTxtFirst);
            if (string.IsNullOrEmpty(currentValueSecond))
            {
                _textMode = true;
                RaiseKeyAssist();
                TextContentSecond = "";
            }
            else
            {
                TextContentSecond = currentValueSecond;
            }

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

                if ((_buttonManifierState == 1))
                {
                    Popup.IsOpen = true;
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
        private string _codeFirst;
        private string _codeSecond;

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
            if (!string.IsNullOrEmpty(e.NewValue as string))
            {
                double value = Convert.ToDouble(e.NewValue);
                if (SearchLabel != null)
                {
                    SearchLabel.Width = value;
                }
            }
        }
        #endregion
        /// <summary>
        ///  Read only both fields
        /// </summary>
        public new bool IsReadOnly
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
            // Precondition.
            if ((SearchTextFirst == null) || (SearchTextSecond == null))
                return;
            if (eventReadOnly)
            {
                SearchTextFirst.IsReadOnly = value;
                if (value)
                {
                    SearchTextFirst.Background = Brushes.LightCyan;
                }
                else
                {
                    SearchTextFirst.Background = Brushes.White;
                }
            }
            else
            {
                SearchTextSecond.IsReadOnly = value;
                if (value)
                {
                    SearchTextSecond.Background = Brushes.LightCyan;
                }
                else
                {
                    SearchTextSecond.Background = Brushes.White;
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
            // in case a text changed from the keyboard.
            if (_textMode)
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

                    var tmpValue = ComponentUtils.GetPropValue(currentDto, fieldList[0]);
                    if (tmpValue != null)
                    {
                        if (tmpValue is string)
                        {
                            textContentFirst = tmpValue as string;
                        }
                        else
                        {
                            textContentFirst = tmpValue.ToString();
                        }
                    }

                    if (textContentFirst == itemToFind)
                    {
                        textContentSecond = ComponentUtils.GetPropValue(currentDto, fieldList[1]) as string;
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

            if (_textMode)
            {
                _textMode = false;
                return;
            }
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
                if (DataSource != null)
                {
                    HandleSourceViewAsEnumerable(enumerableValue, DataSource);
                }

                if (MagnifierGrid != null)
                {
                    MagnifierGrid.ItemsSource = new GridVirtualizingCollectionView(enumerableValue);
                    
                   
                    if (_buttonManifierState == 1)
                    {
                        _firstSelection = true;
                        if (Popup != null)
                        {
                           
                            this.Popup.IsOpen = true;

                            this.Popup.Width = MagnifierGrid.ActualWidth + 30;
                            _buttonManifierState = 0;
                        }

                        return;
                    }

                }


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
                //  SearchTextFirst = GetTemplateChild("PART_SearchTextFirst") as Image;
                if (PopUpButtonImage != null)
                {
                    this.PopUpButtonImage.Source = new BitmapImage(uriSource);
                }
            }
        }

        private void RaiseKeyAssist()
        {
       
            if (string.IsNullOrEmpty(this.AssistQuery))
            {
                AssistQuery = ComputeAssistQuery(AssistDataFieldFirst, AssistDataFieldSecond, AssistTableName);
            }
            IDictionary<string, string> valueDictionary = new Dictionary<string, string>();
            valueDictionary["AssistTable"] = AssistTableName;
            valueDictionary["DataFieldFirst"] = DataFieldFirst;
            valueDictionary["Field"] = DataFieldFirst;
            valueDictionary["DataFieldSecond"] = DataFieldSecond;
            valueDictionary["AssitFieldFirst"] = AssistDataFieldFirst;
            valueDictionary["AssitFieldSecond"] = AssistDataFieldSecond;
            valueDictionary["AssistQuery"] = AssistQuery;
            if (MagnifierCommand != null)
            {
                MagnifierCommand.Execute(valueDictionary);
            }
            else
            {
                MagnifierPressEventArgs args = new MagnifierPressEventArgs(MagnifierPressEvent);
                args.AssistQuery = AssistQuery;
                args.TableName = AssistTableName;
                args.AssistParameters.Add("AssistFieldFirst", AssistDataFieldFirst);
                RaiseEvent(args);

            }
        }
        private void RaiseMagnifierPressEvent()
        {
            Popup = GetTemplateChild("PART_PopUp") as Popup;

            if (Popup == null)
                return;
            if (Popup.IsOpen)
            {
                return;
            }

            MagnifierPressEventArgs args = new MagnifierPressEventArgs(MagnifierPressEvent);

            if (string.IsNullOrEmpty(this.AssistQuery))
            {
                AssistQuery = ComputeAssistQuery(AssistDataFieldFirst, AssistDataFieldSecond, AssistTableName);
            }
            if (!string.IsNullOrEmpty(AssistQuery))
            {
                args.AssistQuery = this.AssistQuery;
            }

            args.TableName = AssistTableName;
            args.AssistParameters.Add("AssistFieldFirst", AssistDataFieldFirst);
            if (!triggerLoad)
            {
                _buttonManifierState = 1;
            }
            IDictionary<string, string> valueDictionary = new Dictionary<string, string>();
            valueDictionary["AssistTable"] = AssistTableName;
            valueDictionary["DataFieldFirst"] = DataFieldFirst;
            valueDictionary["DataFieldSecond"] = DataFieldSecond;
            valueDictionary["AssitFieldFirst"] = AssistDataFieldFirst;
            valueDictionary["AssitFieldSecond"] = AssistDataFieldSecond;
            valueDictionary["AssistQuery"] = AssistQuery;

            if (MagnifierCommand != null)
            {

                MagnifierCommand.Execute(valueDictionary);
            }
            else
            {
                RaiseEvent(args);
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

        private void ButtonBase_OnClick()
        {
            this.Popup.IsOpen = false;
        }

        private void PopUpButton_OnClick()
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
            SearchTextFirst = GetTemplateChild("PART_SearchTextFirst") as TextBox;
            if (e.NewValue != null)
            {
                if (SearchTextFirst != null)
                    SearchTextFirst.Width = Convert.ToDouble(e.NewValue);
            }
            else
            {
                if (SearchTextFirst != null)
                {
                    this.SearchTextFirst.Width = 100;
                }
            }
        }

        private void OnTextContentFirstPropertyChanged(DependencyPropertyChangedEventArgs e)
        {

            if (SearchTextFirst != null)
            {
                SearchTextFirst.Text = Convert.ToString(e.NewValue);
            }

        }
        private void OnTextContentSecondPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (SearchTextSecond != null)
            {
                var value = Convert.ToString(e.NewValue);
                if (!string.IsNullOrEmpty(value))
                {
                    SearchTextSecond.Text = value;
                }
            }


        }
        private void OnLabelTextPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            SearchLabel = GetTemplateChild("PART_SearchLabel") as TextBlock;

            if (SearchLabel != null)
            {
                SearchLabel.Text = e.NewValue as string;
            }
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


        private void HandleObjectValue(object value)
        {
            object currentDto = value;

            if (string.IsNullOrEmpty(AssistProperties))
                return;

            if (MagnifierGrid == null)
            {
                return;
            }
            object textContentFirst = null;
            object textContentSecond = null;

            string[] fieldList = AssistProperties.Split(',');
            // if we have multiple fiels

            if (fieldList.Length >= 2)
            {
                textContentFirst = ComponentUtils.GetPropValue(currentDto, fieldList[0]);
                textContentSecond = ComponentUtils.GetPropValue(currentDto, fieldList[1]);
            }

            if ((textContentFirst == null) || (textContentSecond == null))
            {
                return;
            }
            _componentFiller.FillDataObject(textContentFirst.ToString(), DataFieldFirst, ref _dataSource);

            TextContentFirst = Convert.ToString(textContentFirst);
            if (textContentSecond is string)
            {
                TextContentSecond = textContentSecond as string;
            }
            else
            {
                TextContentSecond = Convert.ToString(textContentSecond);

            }

            if (Popup.IsOpen)
            {
                DataFieldEventArgs ev = new DataFieldEventArgs(DataSearchTextBoxChangedEvent);
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
                valueDictionary["Field"] = DataFieldFirst;
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
        private void MagnifierGrid_OnSelectionRowChanged(object sender, GridSelectionChangedEventArgs e)
        {

            var value = MagnifierGrid.SelectedItem;
            if (value == null)
            {
                return;
            }
            HandleObjectValue(value);
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
            if (DataFieldFirst != null)
            {
                this.DataFieldFirst = value;

                UpdateValues(_sourceView, _dataTable);
            }
        }
        private void OnDataFieldSecondPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            string value = e.NewValue as string;
            if (DataFieldSecond != null)
            {
                this.DataFieldSecond = value;
            }
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
            SearchTextSecond = GetTemplateChild("PART_SearchTextSecond") as TextBox;
            if (e.NewValue != null)
            {
                if (SearchTextSecond != null)
                {
                    this.SearchTextSecond.Width = Convert.ToDouble(e.NewValue);
                }
            }
            else
            {
                if (SearchTextSecond != null)
                {
                    this.SearchTextSecond.Width = 100;
                }
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
