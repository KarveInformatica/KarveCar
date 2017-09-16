using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using Xceed.Wpf.DataGrid;
using DataRow = System.Data.DataRow;
using ThicknessConverter = Xceed.Wpf.DataGrid.Converters.ThicknessConverter;

namespace KarveControls
{
    /// <summary>
    /// Interaction logic for DualFieldSearchBox.xaml
    /// </summary>
    public partial class DualFieldSearchBox : UserControl
    {
        
        public static readonly DependencyProperty AssistNameDependencyProperty =
            DependencyProperty.Register(
                "AssistName",
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

        public static readonly RoutedEvent MagnificerPressEvent =
            EventManager.RegisterRoutedEvent(
                "MagnificerPress",
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

        
        public class MagnificerPressEventArgs : RoutedEventArgs
        {

            public MagnificerPressEventArgs() : base()
            {
            }
            public MagnificerPressEventArgs(RoutedEvent routedEvent) : base(routedEvent)
            {
            }
        }

        public event RoutedEventHandler MagnificerPress
        {
            add { AddHandler(MagnificerPressEvent, value); }
            remove { RemoveHandler(MagnificerPressEvent, value); }
        }
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
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
        public Boolean Lookup
        {
            get { return (Boolean)GetValue(LookupDependencyProperty); }
            set { SetValue(LookupDependencyProperty, value); }
        }

        public string AssistName
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

        public static readonly DependencyProperty LabelTextDependencyProperty =
            DependencyProperty.Register(
                "LabelText",
                typeof(string),
                typeof(SearchTextBox),
                new PropertyMetadata(string.Empty));
        
        public static readonly DependencyProperty LabelWidthDependencyProperty =
            DependencyProperty.Register(
                "LabelWidth",
                typeof(string),
                typeof(SearchTextBox), new PropertyMetadata(string.Empty, OnLabelWidthChange));
        // data field first text box
        private string _dataFieldFirst = String.Empty;
        // data field second text box
        private string _dataFieldSecond = String.Empty;
        // magnifier needed (the control is allowed to be search)
        private bool _lookup;
        private IList<string> _dataFields = new List<string>();
        
        private DataRow _currentRow = null;
        // auxiliar data table
        private DataTable _sourceView = new DataTable();
        // data table for the data text
        private DataTable _dataTable = new DataTable();
        private DataGridVirtualizingCollectionViewSource _viewData;
        private int _buttonManifierState;

        public event PropertyChangedEventHandler PropertyChanged;

        public DualFieldSearchBox()
        {
            InitializeComponent();
            _lookup = false;
            LayoutRoot.DataContext = this;
             _viewData = new DataGridVirtualizingCollectionViewSource();
            _viewData.PageSize = 50;
            _viewData.Source = this.SourceView.DefaultView;
            MagnificerGrid.ItemsSource = _viewData.View;
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
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
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
            if (!value)
            {
                this.PopUpButton.Visibility = Visibility.Hidden;
            }
            else
            {
                this.PopUpButton.Visibility = Visibility.Visible;
            }
        }

        private void OnSourceViewPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            DataTable currentTable = e.NewValue as DataTable;
            _viewData.PageSize = 1000;
            _viewData.Source = currentTable.DefaultView;
            // _viewData.QueryItems += new EventHandler<QueryItemsEventArgs>(Fetch_QueryItems);
            this.MagnificerGrid.ItemsSource = _viewData.View;
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
        private void RaiseMagnificerPressEvent()
        {
            MagnificerPressEventArgs args = new MagnificerPressEventArgs(MagnificerPressEvent);
            _buttonManifierState = 1;
            RaiseEvent(args);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Popup.IsOpen = false;
        }

        private void PopUpButton_OnClick(object sender, RoutedEventArgs e)
        {
            Binding bind = new Binding();
            bind.Source = this.SourceView;
            MagnificerGrid.SetBinding(Xceed.Wpf.DataGrid.DataGridControl.ItemsSourceProperty, bind);
            this.Popup.IsOpen = true;
            RaiseMagnificerPressEvent();
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
        public void SetDynamicBinding(ref DataTable dta, IList<ValidationRule> rules)
        {
            string fieldFirst = _dataFieldFirst.ToUpper();
            string fieldSecond = _dataFieldSecond.ToUpper();
            if (!string.IsNullOrEmpty(fieldFirst) || !string.IsNullOrEmpty(fieldSecond))
            {
                Binding oBind = new Binding("Text");
                oBind.Source = dta.Columns[fieldFirst];
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
                SearchTextFirst.Width = dta.Columns[fieldFirst].MaxLength;
                SearchTextFirst.SetBinding(TextBox.TextProperty, oBind);
                Binding oBind1 = new Binding("Text1");
                oBind1.Source = dta.Columns[fieldSecond];
                oBind1.Mode = BindingMode.TwoWay;
                oBind1.ValidatesOnDataErrors = true;
                oBind1.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                if (rules != null)
                {
                    foreach (ValidationRule rule in rules)
                    {
                        oBind.ValidationRules.Add(rule);
                    }
                }
                SearchTextSecond.Width = dta.Columns[fieldSecond].MaxLength;
                SearchTextSecond.SetBinding(TextBox.TextProperty, oBind1);
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
            this.SearchTextFirst.Width = Convert.ToDouble(e.NewValue);
        }
        private void OnTextContentFirstPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            this.SearchTextFirst.Text = e.NewValue as string;
        }
        private void OnTextContentSecondPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
           this.SearchTextSecond.Text= e.NewValue as string;
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
        }
        private void MagnificerGrid_OnSelectionChanged(object sender, DataGridSelectionChangedEventArgs e)
        {
            DataGridControl gridControl = sender as DataGridControl;
            DataRowView currentRowView = gridControl.SelectedItem as DataRowView;
            DataRow row = currentRowView.Row;
            DataColumnCollection cols = row.Table.Columns;
            string columnName = "";
            IList<string> columnNames = new List<string>();
            foreach (DataColumn col in cols)
            {
                if (col.ColumnName == this.DataFieldFirst ) 
                {
                      columnNames.Add(DataFieldFirst);
                    
                }
                if (col.ColumnName == this.DataFieldSecond)
                {
                    columnNames.Add(DataFieldSecond);
                }
            }
            if (!string.IsNullOrEmpty(columnNames[0]))
            {
                this.SearchTextFirst.Text = row[columnNames[0]] as string;
            }
            if (!string.IsNullOrEmpty(columnNames[1]))
            {
                this.SearchTextSecond.Text = row[columnNames[1]] as string;
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
        }
        private void OnDataFieldSecondPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            string value = e.NewValue as string;
            this.DataFieldFirst = value;
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
            this.SearchTextSecond.Width = Convert.ToDouble(e.NewValue);
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
