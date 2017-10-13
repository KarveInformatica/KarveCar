using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using KarveControls.Generic;
using KarveControls.UIObjects;
using Xceed.Wpf.DataGrid;
using DataRow = System.Data.DataRow;

namespace KarveControls
{
    /// <summary>
    /// Interaction logic for DualFieldSearchBox.xaml
    /// </summary>
    public partial class DualFieldSearchBox : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Property string to refresh
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

       // most of the shared ones shall be moved as attached properties 
     

        public static readonly DependencyProperty AssistNameDependencyProperty =
            DependencyProperty.Register(
                "AssistTableName",
                typeof(string),
                typeof(DualFieldSearchBox), new PropertyMetadata(string.Empty));


        public static readonly DependencyProperty AssistDataFieldFirstDependencyProperty =
            DependencyProperty.Register(
                "AssistDataFieldFirst",
                typeof(string),
                typeof(DualFieldSearchBox), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty AssistDataFieldSecondDependencyProperty =
            DependencyProperty.Register(
                "AssistDataFieldSecond",
                typeof(string),
                typeof(DualFieldSearchBox), new PropertyMetadata(string.Empty));


        public static readonly DependencyProperty TextContentFirstDependencyProperty =
            DependencyProperty.Register(
                "TextContentFirst",
                typeof(string),
                typeof(DualFieldSearchBox), new PropertyMetadata(string.Empty, OnTextContentFirstChange));

        public static readonly DependencyProperty TextContentSecondDependencyProperty =
            DependencyProperty.Register(
                "TextContentSecond",
                typeof(string),
                typeof(DualFieldSearchBox), new PropertyMetadata(string.Empty, OnTextContentSecondChange));

        public readonly static DependencyProperty TextContentFirstWidthDependencyProperty =
            DependencyProperty.Register(
                "TextContentFirstWidth",
                typeof(string),
                typeof(DualFieldSearchBox), new PropertyMetadata(string.Empty, OnTextContentFirstWidthChange));

        public readonly static DependencyProperty TextContentSecondWidthDependencyProperty =
            DependencyProperty.Register(
                "TextContentSecondWidth",
                typeof(string),
                typeof(DualFieldSearchBox), new PropertyMetadata(string.Empty, OnTextContentSecondWidthChange));

        public static readonly DependencyProperty ButtonImageDependencyProperty =
            DependencyProperty.Register(
                "ButtonImage",
                typeof(string),
                typeof(DualFieldSearchBox), new PropertyMetadata(string.Empty, OnButtonImageChange));


        public static readonly DependencyProperty LookupDependencyProperty =
            DependencyProperty.Register(
                "Lookup",
                typeof(Boolean),
                typeof(DualFieldSearchBox), new PropertyMetadata(false, OnLookupChanged));

        public static readonly DependencyProperty SourceViewDependencyProperty =
            DependencyProperty.Register(
                "SourceView",
                typeof(DataTable),
                typeof(DualFieldSearchBox),
                new PropertyMetadata(new DataTable(), OnSourceTableChanged));

        public static readonly RoutedEvent MagnifierPressEvent =
            EventManager.RegisterRoutedEvent(
                "MagnifierPress",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(DualFieldSearchBox));

        public static DependencyProperty ItemSourceDependencyProperty =
            DependencyProperty.Register(
                "ItemSource",
                typeof(DataTable),
                typeof(DualFieldSearchBox), new PropertyMetadata(new DataTable(), OnSearchTextBoxItemSourceChanged));

         public static DependencyProperty DataFieldFirstDependencyProperty =
            DependencyProperty.Register(
                "DataFieldFirst",
                typeof(string),
                typeof(DualFieldSearchBox), new PropertyMetadata(string.Empty, OnSearchTextBoxDataFieldFirstChanged));

        public static DependencyProperty DataFieldSecondDependencyProperty =
            DependencyProperty.Register(
                "DataFieldSecond",
                typeof(string),
                typeof(DualFieldSearchBox), new PropertyMetadata(string.Empty, OnSearchTextBoxDataFieldSecondChanged));

        public static DependencyProperty DataAllowedFirstDependencyProperty =
            DependencyProperty.Register(
                "DataAllowedFirst",
                typeof(CommonControl.DataType),
                typeof(DualFieldSearchBox), new PropertyMetadata(CommonControl.DataType.Any, OnChangedDataAllowedFirst));

        private static void OnChangedDataAllowedFirst(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox dualFieldSearchBox = d as DualFieldSearchBox;
            dualFieldSearchBox.OnPropertyChanged("DataAllowedFirst");
            dualFieldSearchBox.OnDataAllowedChanged(e, true);
        }

        private void OnDataAllowedChanged(DependencyPropertyChangedEventArgs e, bool firstValue)
        {
            CommonControl.DataType dataType;
            dataType = (CommonControl.DataType)Enum.Parse(typeof(CommonControl.DataType), e.NewValue.ToString());
            if (firstValue)
            {
                _dataAllowedFirst = dataType;
            }
            else
            {
                _dataAllowedSecond = dataType;
            }
        }
        public static DependencyProperty DataAllowedSecondDependencyProperty =
            DependencyProperty.Register(
                "DataAllowedSecond",
                typeof(CommonControl.DataType),
                typeof(DualFieldSearchBox), new PropertyMetadata(CommonControl.DataType.Any, OnChangedDataAllowedSecond));

        private static void OnChangedDataAllowedSecond(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox dualFieldSearchBox = d as DualFieldSearchBox;
            dualFieldSearchBox.OnPropertyChanged("DataAllowedSecond");
            dualFieldSearchBox.OnDataAllowedChanged(e, false);
        }

        public static DependencyProperty DataFieldsDependencyProperty =
            DependencyProperty.Register(
                "DataFields",
                typeof(IList<string>),
                typeof(DualFieldSearchBox), new PropertyMetadata(new List<string>(), OnSearchTextBoxDataFields));

        public static DependencyProperty IsReadOnlyProperty = DependencyProperty.Register(
            "IsReadOnly",
            typeof(bool),
            typeof(DualFieldSearchBox),
            new PropertyMetadata(false, OnIsReadOnlyProperty));


        public static DependencyProperty IsReadOnlyFirstProperty = DependencyProperty.Register(
            "IsReadOnlyFirst",
            typeof(bool),
            typeof(DualFieldSearchBox),
            new PropertyMetadata(false, OnIsReadOnlyFirstProperty));

        public static DependencyProperty IsReadOnlySecondProperty = DependencyProperty.Register(
            "IsReadOnlySecond",
            typeof(bool),
            typeof(DualFieldSearchBox),
            new PropertyMetadata(false, OnIsReadOnlySecondProperty));

        public static readonly DependencyProperty TableNameDependencyProperty =
            DependencyProperty.Register(
                "TableName",
                typeof(string),
                typeof(DualFieldSearchBox),
                new PropertyMetadata(string.Empty, OnTableNameChange));

        public static readonly DependencyProperty LabelVisibleDependencyProperty =
            DependencyProperty.Register("LabelVisible",
                typeof(bool),
                typeof(DualFieldSearchBox),
                new PropertyMetadata(false, OnLabelVisibleChange));
               
        #region LabelVisible

        public bool LabelVisible
        {
            get { return (bool)GetValue(LabelVisibleDependencyProperty); }
            set { SetValue(LabelVisibleDependencyProperty, value); }
        }

        private static void OnLabelVisibleChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnPropertyChanged("LabelVisible");
                control.OnLabelVisiblePropertyChanged(e);
            }
        }
        private void OnLabelVisiblePropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            bool value = Convert.ToBoolean(e.NewValue);
            if (value)
            {
                SearchLabel.Visibility = Visibility.Visible;
            }
            else
            {
                SearchLabel.Visibility = Visibility.Collapsed;
            }
        }
        #endregion

        
        #region TableName

        private string _tableName;
        private static void OnTableNameChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnPropertyChanged("TableName");
                control.OnTableNameChanged(e);
            }
        }

        public string TableName
        {
            get { return (string)GetValue(TableNameDependencyProperty); }
            set { SetValue(TableNameDependencyProperty, value); }
        }

        private void OnTableNameChanged(DependencyPropertyChangedEventArgs e)
        {
            _tableName = e.NewValue as string;
        }


        #endregion

        #region assist Query

        #endregion
        #region Event Magnifier Lupa
        public static readonly RoutedEvent AssistQueryChangedEvent =
            EventManager.RegisterRoutedEvent(
                "AssistQueryChangedEvent",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(DualFieldSearchBox));


        public static readonly RoutedEvent DataSearchTextBoxChangedEvent =
            EventManager.RegisterRoutedEvent(
                "DataSearchTextBoxChanged",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(DualFieldSearchBox));



        public class AssitQueryPressEventArgs : RoutedEventArgs
        {
            public const string ASSISTTABLE = "AssistTable";
            public const string ASSISTQUERY = "AssistQuery";

            public AssitQueryPressEventArgs() : base()
            {
            }
            public AssitQueryPressEventArgs(RoutedEvent routedEvent) : base(routedEvent)
            {
            }

            public IDictionary<string, string> AssistParameters
            {
                get
                {
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    dictionary.Add(ASSISTTABLE, TableName);
                    dictionary.Add(ASSISTQUERY, AssistQuery);
                    return dictionary;
                }
            }

            public string AssistQuery { get; set; }
            public string TableName { get; set; }
        }
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

        public CommonControl.DataType DataAllowedFirst
        {
            get { return (CommonControl.DataType)GetValue(DataAllowedFirstDependencyProperty); }
            set { SetValue(DataAllowedFirstDependencyProperty, value); }
        }


        public CommonControl.DataType DataAllowedSecond
        {
            get { return (CommonControl.DataType)GetValue(DataAllowedSecondDependencyProperty); }
            set { SetValue(DataAllowedSecondDependencyProperty, value); }
        }

        public Boolean Lookup
        {
            get { return (Boolean)GetValue(LookupDependencyProperty); }
            set { SetValue(LookupDependencyProperty, value); }
        }

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
        public string LabelText
        {
            get { return (string)GetValue(LabelTextDependencyProperty); }
            set
            {
                SetValue(LabelTextDependencyProperty, value);
            }
        }


        public static readonly DependencyProperty AssistQueryDependencyProperty =
            DependencyProperty.Register(
                "AssistQuery",
                typeof(string),
                typeof(DualFieldSearchBox),
                new PropertyMetadata(string.Empty));

        public string AssistQuery
        {
            get { return (string)GetValue(AssistQueryDependencyProperty); }
            set
            {
                SetValue(AssistQueryDependencyProperty, value);
            }
        }

        public static readonly DependencyProperty LabelTextDependencyProperty =
            DependencyProperty.Register(
                "LabelText",
                typeof(string),
                typeof(DualFieldSearchBox),
                new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty LabelWidthDependencyProperty =
            DependencyProperty.Register(
                "LabelWidth",
                typeof(string),
                typeof(DualFieldSearchBox), new PropertyMetadata(string.Empty, OnLabelWidthChange));
        // data field first text box
        private string _dataFieldFirst = String.Empty;
        // data field second text box
        private string _dataFieldSecond = String.Empty;
        // magnifier needed (the control is allowed to be search)
        private IList<string> _dataFields = new List<string>();

        // auxiliar data table
        private DataTable _sourceView = new DataTable();
        // data table for the data text
        private DataTable _dataTable = new DataTable();
        private DataGridVirtualizingCollectionViewSource _viewData;
        private ComponentFiller _filler;
        private static int _buttonManifierState;
        
        public const int DEFAULT_PAGE_SIZE = 100;
        private CommonControl.DataType _dataAllowedFirst;
        private CommonControl.DataType _dataAllowedSecond;
        private ComponentFiller _componentFiller;
        /// <summary>
        /// This is a component with a grid table associated.
        /// </summary>
        public DualFieldSearchBox()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
            _filler = new ComponentFiller();
            //_lookup = false;
            _viewData = new DataGridVirtualizingCollectionViewSource();
            _viewData.PageSize = DEFAULT_PAGE_SIZE;
            _viewData.Source = this.SourceView.DefaultView;
            _componentFiller = new ComponentFiller();
            SearchTextFirst.KeyUp += SearchTextOnKeyDown;
            MagnifierGrid.SourceView = this.SourceView;
           
        //    MagnifierGrid.ItemsSource = _viewData.View;
         //   MagnifierGrid.AllowDrag = true;
            RaiseMagnifierPressEvent();
        }
        private void SearchTextOnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            bool IsNotANumber = false;
            if (keyEventArgs.Key < Key.D0 || keyEventArgs.Key > Key.D9)
            {
                // determine if the key is a number from the top of the keyboard.
                if ((keyEventArgs.Key < Key.NumPad0) || (keyEventArgs.Key > Key.NumPad9))
                {
                    // here we a no number 
                    IsNotANumber = true;
                }
            }

            if ((keyEventArgs.Key == Key.LeftShift) || (keyEventArgs.Key == Key.RightShift))
            {
                IsNotANumber = true;
            }
            if (!IsNotANumber)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("SELECT ");
                builder.Append(AssistDataFieldFirst);
                builder.Append(","); 
                builder.Append(AssistDataFieldSecond);
                builder.Append(" FROM ");
                builder.Append(AssistTableName);
                builder.Append(" WHERE ");
                if (SearchTextFirst.Text.Trim() != "")
                {
                    string clause = ComputeFieldFormat(this.ItemSource, DataFieldFirst, SearchTextFirst.Text,
                        AssistDataFieldFirst);
                    builder.Append(clause);
                    string query = builder.ToString();
                    AssitQueryPressEventArgs assistParam = new AssitQueryPressEventArgs(AssistQueryChangedEvent);
                    assistParam.AssistQuery = query;
                    assistParam.TableName = AssistTableName;
                    RaiseEvent(assistParam);
                }
            }
        }
        public string LabelWidth
        {
            get { return (string)GetValue(LabelWidthDependencyProperty); }
            set { SetValue(LabelWidthDependencyProperty, value); }
        }
        public string TextContentFirst
        {
            get { return (string)GetValue(TextContentFirstDependencyProperty); }
            set { SetValue(TextContentFirstDependencyProperty, value); }
        }

        public string TextContentSecond
        {
            get { return (string)GetValue(TextContentSecondDependencyProperty); }
            set { SetValue(TextContentSecondDependencyProperty, value); }
        }

        public string TextContentFirstWidth
        {
            get { return (string)GetValue(TextContentFirstWidthDependencyProperty); }
            set { SetValue(TextContentFirstWidthDependencyProperty, value); }
        }
        public string TextContentSecondWidth
        {
            get { return (string)GetValue(TextContentSecondWidthDependencyProperty); }
            set { SetValue(TextContentSecondWidthDependencyProperty, value); }
        }

        public DataTable ItemSource
        {
            get { return (DataTable)GetValue(ItemSourceDependencyProperty); }
            set { SetValue(ItemSourceDependencyProperty, value); }
        }
        public DataTable SourceView
        {
            get { return (DataTable)GetValue(SourceViewDependencyProperty); }
            set
            {
                SetValue(SourceViewDependencyProperty, value);
                if (_buttonManifierState == 0)
                {
                    Popup.IsOpen = true;
                }
            }
        }
        #region LabelTextWidth 
        public readonly static DependencyProperty LabelTextWidthDependencyProperty =
            DependencyProperty.Register(
                "LabelTextWidth",
                typeof(string),
                typeof(DualFieldSearchBox),
                new PropertyMetadata(string.Empty, OnLabelTextWidthChange));

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
                control.OnPropertyChanged("LabelTextWidth");
                control.OnLabelTextWidthChanged(e);
            }
        }

        private void OnLabelTextWidthChanged(DependencyPropertyChangedEventArgs e)
        {
            double value = Convert.ToDouble(e.NewValue);
            SearchLabel.Width = value;
        }
        #endregion
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        public bool IsReadOnlyFirst
        {
            get { return (bool)GetValue(IsReadOnlyFirstProperty); }
            set { SetValue(IsReadOnlyFirstProperty, value); }
        }
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
                 dualFieldSearchBox.OnPropertyChanged("IsReadOnlyFirst");
                 dualFieldSearchBox.OnReadOnlySet(e, true);                
            }
        }
        private static void OnIsReadOnlySecondProperty(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox dualFieldSearchBox = d as DualFieldSearchBox;
            if (dualFieldSearchBox != null)
            {
                dualFieldSearchBox.OnPropertyChanged("IsReadOnlySecond");
                dualFieldSearchBox.OnReadOnlySet(e, false);
            }
        }
        private void OnReadOnlySet(DependencyPropertyChangedEventArgs e, bool eventReadOnly)
        {
            bool value = Convert.ToBoolean(e.NewValue);
            if (eventReadOnly)
            {
                SearchTextFirst.IsReadOnly = value;
                if (value)
                {
                    SearchTextFirst.Background = Brushes.CadetBlue;
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
                    SearchTextFirst.Background = Brushes.CadetBlue;
                }
                else
                {
                    SearchTextFirst.Background = Brushes.White;
                }
            }
        }
        private static void OnSourceTableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnPropertyChanged("SourceView");
                control.OnSourceViewPropertyChanged(e);
            }
        }
        private static void OnLookupChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnPropertyChanged("Lookup");
                control.OnLookupPropertyChanged(e);
            }
        }
        private void OnLookupPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            bool value = Convert.ToBoolean(e.NewValue);
           
           // _lookup = false;
            if (!value)
            {
                this.PopUpButton.Visibility = Visibility.Hidden;
            }
            else
            {
             //   this.Popup.IsOpen = true;
                this.PopUpButton.Visibility = Visibility.Visible;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="dataFieldFirst"></param>
        /// <returns></returns>
        private string ComputeFieldFormat(DataTable itemSource, string dataFieldFirst, string valueToFind, string assistDataField)
        {
            string fieldFormat = "";
            DataColumnCollection primaryKeyCollection = itemSource.Columns;
            if (primaryKeyCollection.Contains(dataFieldFirst))
            {
                DataRow primaryItemSourceRow = itemSource.Rows[0];
               // var valueToFind = primaryItemSourceRow[dataFieldFirst];
                Type dataType = primaryItemSourceRow.Table.Columns[dataFieldFirst].DataType;
                if ((dataType.Name == "Int16") || (dataType.Name == "Int32"))
                {
                    fieldFormat = string.Format("{0} = {1}", assistDataField, valueToFind);
                }
                else if (dataType.Name == "String")
                {
                    fieldFormat = string.Format("{0} = '{1}'", assistDataField, valueToFind);
                }
            }
            return fieldFormat;
        }

        private void UpdateValues(DataTable sourceView, DataTable itemSource)
        {
            if ((sourceView != null) && (sourceView.Rows.Count > 0))
            {

                DataColumnCollection collection = sourceView.Columns;
                DataColumnCollection primaryKeyCollection = itemSource.Columns;
                if (itemSource.Rows.Count > 0)
                {
                    DataRow primaryItemSourceRow = itemSource.Rows[0];
                    DataRow[] filteredRows = null;
                    if (collection.Contains(AssistDataFieldFirst))
                    {
                        if (primaryKeyCollection.Contains(DataFieldFirst))
                        {

                            var valueToFind = primaryItemSourceRow[DataFieldFirst];
                            if (!System.DBNull.Value.Equals(valueToFind))
                            {
                                Type dataType = primaryItemSourceRow.Table.Columns[DataFieldFirst].DataType;
                                string fieldFormat = "";
                                if ((dataType.Name == "Int16") || (dataType.Name == "Int32"))
                                {
                                    fieldFormat = string.Format("{0} = {1}", AssistDataFieldFirst, valueToFind);
                                }
                                else if (dataType.Name == "String")
                                {
                                    fieldFormat = string.Format("{0} = '{1}'", AssistDataFieldFirst, valueToFind);
                                }
                                filteredRows = sourceView.Select(fieldFormat);
                            }
                        }
                        if ((filteredRows != null) && (filteredRows.Length == 1))
                        {
                            TextContentFirst = String.Format("{0}", filteredRows[0][AssistDataFieldFirst]);
                            TextContentSecond = String.Format("{0}", filteredRows[0][AssistDataFieldSecond]);
                        }

                    }

                }
                else
                {
                    TextContentFirst = "";
                    TextContentSecond = "";
                }
            }
        }

        private void OnSourceViewPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            DataTable currentTable = e.NewValue as DataTable;
            if (currentTable != null)
            {
               

              //  DataGridCollectionViewSource viewData = new DataGridCollectionViewSource();
              // viewData.Source = currentTable;
                this.MagnifierGrid.SourceView = currentTable;
                //   ItemsSource = viewData.View;
                if (_buttonManifierState == 1)
                {
                    
                        this.Popup.IsOpen = true;
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
                control.OnPropertyChanged("ButtonImage");
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
            AssitQueryPressEventArgs args = new AssitQueryPressEventArgs(MagnifierPressEvent);
            if (!string.IsNullOrEmpty(this.AssistQuery))
            {
                args.AssistQuery = this.AssistQuery;
                args.TableName = AssistTableName;
                _buttonManifierState = 1;
                RaiseEvent(args);

            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Popup.IsOpen = false;
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
                control.OnPropertyChanged("LabelText");
                control.OnLabelTextPropertyChanged(e);
            }
        }
        private static void OnLabelWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnPropertyChanged("LabelWidth");
                control.OnLabelTextPropertyChanged(e);
            }
        }
        private static void OnTextContentFirstChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnPropertyChanged("TextContentFirst");
                control.OnTextContentFirstPropertyChanged(e);
            }
        }
        private static void OnTextContentSecondChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnPropertyChanged("TextContentSecond");
                control.OnTextContentSecondPropertyChanged(e);
            }
        }
        private static void OnTextContentFirstWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnPropertyChanged("TextContentFirstWidth");
                control.OnTextContentFirstWidthPropertyChanged(e);
            }

        }
        private static void OnIsReadOnlyProperty(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnPropertyChanged("IsReadOnly");
                control.OnIsReadOnlyPropertyChanged(e);
            }
        }
        private void OnTextContentFirstWidthPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                this.SearchTextFirst.Width = Convert.ToDouble(e.NewValue);
            }
            else
            {
                this.SearchTextFirst.Width = 100;
            }
        }

        private void OnTextContentFirstPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            this.SearchTextFirst.Text = Convert.ToString(e.NewValue);

            if (!IsReadOnlyFirst)
            {
                if (!string.IsNullOrEmpty(DataFieldFirst))
                {
                    _componentFiller.FillTable(SearchTextFirst, DataFieldFirst, ref _dataTable);
                }
                else
                {
                    _componentFiller.FillTable(SearchTextFirst, AssistDataFieldFirst, ref _sourceView);

                }
            }

        }
        private void OnTextContentSecondPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            this.SearchTextSecond.Text = Convert.ToString(e.NewValue);

            
            if (!string.IsNullOrEmpty(DataFieldSecond))
            {
                _componentFiller.FillTable(SearchTextSecond, DataFieldSecond, ref _dataTable);
            }
            else
            {
                _componentFiller.FillTable(SearchTextSecond, AssistDataFieldSecond, ref _sourceView);

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
                control.OnPropertyChanged("ItemSource");
                control.OnItemSourcePropertyChanged(e);
            }
        }
        private void OnItemSourcePropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            DataTable dt = e.NewValue as DataTable;
            _dataTable = dt;
            UpdateValues(_sourceView, _dataTable);
             

        }
        private void MagnifierGrid_OnSelectionChanged(object sender, DataGridSelectionChangedEventArgs e)
        {
            DataGridControl gridControl = sender as DataGridControl;
            DataRowView currentRowView = gridControl.SelectedItem as DataRowView;
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
                }
            }
        }
        private static void OnSearchTextBoxDataFieldFirstChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnPropertyChanged("DataFieldFirst");
                control.OnDataFieldFirstPropertyChanged(e);
            }
        }
        private static void OnSearchTextBoxDataFieldSecondChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnPropertyChanged("DataFieldSecond");
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
            this.DataFieldSecond= value;
        }
        private static void OnSearchTextBoxDataFields(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnPropertyChanged("DataFields");
                control.OnDataFieldsPropertyChanged(e);
            }
        }
        private static void OnTextContentSecondWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DualFieldSearchBox control = d as DualFieldSearchBox;
            if (control != null)
            {
                control.OnPropertyChanged("DataFieldWidthSecond");
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
