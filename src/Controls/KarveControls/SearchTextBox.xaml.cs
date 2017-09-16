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
using ExtendedGrid.ExtendedGridControl;
using Xceed.Wpf.DataGrid;
using DataRow = System.Data.DataRow;

namespace KarveControls
{
    /// <summary>
    /// Interaction logic for SearchTextBox.xaml
    /// </summary>
    
    public partial class SearchTextBox : UserControl, INotifyPropertyChanged
    {

        public static readonly DependencyProperty AssistNameDependencyProperty =
            DependencyProperty.Register(
                "AssistName",
                typeof(string),
                typeof(SearchTextBox), new PropertyMetadata(string.Empty));


        public static readonly DependencyProperty TextContentDependencyProperty =
            DependencyProperty.Register(
                "TextContent",
                typeof(string),
                typeof(SearchTextBox), new PropertyMetadata(string.Empty, OnTextContentChange));

        public readonly static DependencyProperty TextContentWidthDependencyProperty =
            DependencyProperty.Register(
                "TextContentWidth",
                typeof(string),
                typeof(SearchTextBox), new PropertyMetadata(string.Empty, OnTextContentWidthChange));

        public static readonly DependencyProperty ButtonImageDependencyProperty =
            DependencyProperty.Register(
                "ButtonImage",
                typeof(string),
                typeof(SearchTextBox), new PropertyMetadata(string.Empty, OnButtonImageChange));


        public static readonly DependencyProperty LookupDependencyProperty =
            DependencyProperty.Register(
                "Lookup",
                typeof(Boolean),
                typeof(SearchTextBox), new PropertyMetadata(false, OnLookupChanged));

        public static readonly DependencyProperty SourceViewDependencyProperty =
            DependencyProperty.Register(
                "SourceView",
                typeof(DataTable),
                typeof(SearchTextBox),
                new PropertyMetadata(new DataTable(), OnSourceTableChanged));

        public static readonly RoutedEvent MagnificerPressEvent =
            EventManager.RegisterRoutedEvent(
                "MagnificerPress",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(SearchTextBox));


        public static DependencyProperty ItemSourceDependencyProperty =
            DependencyProperty.Register(
                "ItemSource",
                typeof(DataTable),
                typeof(SearchTextBox), new PropertyMetadata(new DataTable(), OnSearchTextBoxItemSourceChanged));

        public static DependencyProperty DataFieldDependencyProperty =
            DependencyProperty.Register(
                "DataField",
                typeof(string),
                typeof(SearchTextBox), new PropertyMetadata(string.Empty, OnSearchTextBoxDataFieldChanged));

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
        public ICommand SelectedIndexCommand { set; get; }

        public string ButtonImage
        {
            get { return (string)GetValue(ButtonImageDependencyProperty); }
            set { SetValue(ButtonImageDependencyProperty, value); }
        }
        public Boolean Lookup
        {
            get { return (Boolean)GetValue(LookupDependencyProperty); }
            set { SetValue(LookupDependencyProperty, value); }
        }
        public string AssistName
        {
            get { return (string)GetValue(AssistNameDependencyProperty); }
            set { SetValue(AssistNameDependencyProperty, value); }
        }


        public static readonly DependencyProperty LabelTextDependencyProperty =
            DependencyProperty.Register(
                "LabelText",
                typeof(string),
                typeof(SearchTextBox),
                new PropertyMetadata(string.Empty));
        public string LabelText
        {
            get { return (string)GetValue(LabelTextDependencyProperty); }
            set
            {
                SetValue(LabelTextDependencyProperty, value);
            }
        }
      
        public static readonly DependencyProperty LabelWidthDependencyProperty =
            DependencyProperty.Register(
                "LabelWidth",
                typeof(string),
                typeof(SearchTextBox), new PropertyMetadata(string.Empty, OnLabelWidthChange));

        private int _state = 0;
        private string _dataField = String.Empty;
        private DataRow _currentRow = null;
        private DataTable _sourceView = new DataTable();
        private DataTable _dataTable = new DataTable();
        private DataGridVirtualizingCollectionViewSource _viewData;
        private bool _lookup;
        public event PropertyChangedEventHandler PropertyChanged;

        public SearchTextBox()
        {
            InitializeComponent();
            _lookup = false;
            LayoutRoot.DataContext = this;
            _viewData = new DataGridVirtualizingCollectionViewSource();
            _viewData.PageSize = 50;
            _viewData.Source = this.SourceView.DefaultView;
           // _viewData.QueryItems += new EventHandler<QueryItemsEventArgs>(Fetch_QueryItems);
            this.MagnificerGrid.ItemsSource = _viewData.View;
        }
        
        

        public string LabelWidth
        {
            get { return (string)GetValue(LabelWidthDependencyProperty); }
            set { SetValue(LabelWidthDependencyProperty, value); }
        }
        public string TextContent
        {
            get { return (string)GetValue(TextContentWidthDependencyProperty); }
            set { SetValue(TextContentWidthDependencyProperty, value); }
        }
        public string TextContentWidth
        {
            get { return (string)GetValue(TextContentDependencyProperty); }
            set { SetValue(TextContentDependencyProperty, value); }
        }
        public string DataField
        {
            get { return (string)GetValue(DataFieldDependencyProperty); }
            set { SetValue(DataFieldDependencyProperty, value); }
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
           
                if (_state == 1)
                {
                    this.Popup.IsOpen = true;
                    _state = 0;
                }
            }
        }
        private static void OnSourceTableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SearchTextBox control = d as SearchTextBox;
            if (control != null)
            {
                control.OnPropertyChanged("SourceView");
                control.OnSourceViewPropertyChanged(e);
            }
        }

        private static void OnLookupChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SearchTextBox control = d as SearchTextBox;
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
            SearchTextBox control = d as SearchTextBox;
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
            this._state = 1;
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

            SearchTextBox control = d as SearchTextBox;
            if (control != null)
            {
                control.OnPropertyChanged("LabelText");
                control.OnLabelTextPropertyChanged(e);
            }
        }
        private static void OnLabelWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SearchTextBox control = d as SearchTextBox;
            if (control != null)
            {
                control.OnPropertyChanged("LabelWidth");
                control.OnLabelTextPropertyChanged(e);
            }
        }
       

        public void SetDynamicBinding(ref DataTable dta, IList<ValidationRule> rules)
        {
            string field = _dataField.ToUpper();
            if (!string.IsNullOrEmpty(field))
            {
                Binding oBind = new Binding("Text");
                oBind.Source = dta.Columns[field];
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
                this.SearchText.Width = dta.Columns[field].MaxLength;
                SearchText.SetBinding(TextBox.TextProperty, oBind);
            }
        }
        private static void OnTextContentChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SearchTextBox control = d as SearchTextBox;
            if (control != null)
            {
                control.OnPropertyChanged("TextContent");
                control.OnTextContentPropertyChanged(e);
            }

        }

        private static void OnTextContentWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SearchTextBox control = d as SearchTextBox;
            if (control != null)
            {
                control.OnPropertyChanged("TextContentWidth");
                control.OnTextContentWidthPropertyChanged(e);
            }

        }
        private void OnTextContentWidthPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            SearchText.Width = Convert.ToDouble(e.NewValue);  
        }
        private void OnTextContentPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            SearchText.Text = e.NewValue as string;
        }
        private void OnLabelTextPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            SearchLabel.Text = e.NewValue as string;
        }

        private static void OnSearchTextBoxItemSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SearchTextBox control = d as SearchTextBox;
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
        private static void OnSearchTextBoxDataFieldChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SearchTextBox control = d as SearchTextBox;
            if (control != null)
            {
                control.OnPropertyChanged("DataField");
                control.OnDataFieldPropertyChanged(e);
            }
        }

        private void OnDataFieldPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            this._dataField = e.NewValue as string;
        }

        private void MagnificerGrid_OnSelectionChanged(object sender, DataGridSelectionChangedEventArgs e)
        {
            Xceed.Wpf.DataGrid.DataGridControl gridControl = sender as Xceed.Wpf.DataGrid.DataGridControl;
            DataRowView currentRowView = gridControl.SelectedItem as DataRowView;
            DataRow row = currentRowView.Row;
            DataColumnCollection cols = row.Table.Columns;
            string columnName = "";
            foreach (DataColumn col in cols)
            {
                if (col.ColumnName == DataField)
                {
                    columnName = DataField;
                    break;
                }
            }
            if (!string.IsNullOrEmpty(columnName))
            {
                this.SearchText.Text = row[columnName] as string;
            }
           
        }
    }
}
