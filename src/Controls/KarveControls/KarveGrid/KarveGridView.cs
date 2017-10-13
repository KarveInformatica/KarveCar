using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using KarveControls.KarveGrid.Column;
using KarveControls.KarveGrid.Events;
using KarveControls.KarveGrid.GridDefinition;
using KarveControls.KarveGrid.GridOrder;
using KarveControls.KarveGrid.KarveEditor.BrowerGridEditorKarve;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;
using Binding = System.Windows.Data.Binding;
using PropertyChangedCallback = System.Windows.PropertyChangedCallback;
using GridColView = Telerik.WinControls.UI.GridViewColumn;
using Panel = System.Windows.Controls.Panel;

namespace KarveControls.KarveGrid
{
    /// <summary>
    ///  This component wraps a Telerick DataGrid enables the reuse of the grid in the WPF context.
    ///  It can generate automagically the query from the columns names. 
    /// </summary>
    public class KarveGridView : Grid, INotifyPropertyChanged
    {
        public enum GridType
        {
            Edit,
            Search
        }

        private const int CurrentViewPageSize = 20;
        private int _columnWidth = 100;
        private GridType _gridType = GridType.Search;
        private IList<string> _columnsList = new List<string>();
        #region Private Variables

        private readonly RadGridView _currentView = new RadGridView();
        private Grid _baseContainer;
        private long _pageIndex = 0;
        #endregion
        #region Public Variables

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        #endregion

        #region DependencyProperty
        /// <summary>
        /// This depedency property exposes the grid type.
        /// </summary>
        public static DependencyProperty GridTypeDependencyProperty = DependencyProperty.Register("GridType", typeof(GridType), 
            typeof(KarveGridView), new PropertyMetadata(GridType.Edit));
        /// <summary>
        ///  This dependency property exposes the field.
        /// </summary>
        public static DependencyProperty AliasFieldProperty = DependencyProperty.Register("AliasField", typeof(string), 
            typeof(KarveGridView), new PropertyMetadata(string.Empty));

        /// <summary>
        /// This depedency property exposes the source of the GridView. It is the table associated to the source.
        /// </summary>

        public static DependencyProperty SourceViewProperty =
            DependencyProperty.Register(
                "SourceView",
                typeof(DataTable),
                typeof(KarveGridView),
                new PropertyMetadata(new DataTable(), OnSourceViewChange));

        private static void OnSourceViewChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            KarveGridView karveGrid = d as KarveGridView;
            if (karveGrid != null)
            {
                karveGrid.OnPropertyChanged("SourceView");
                karveGrid.OnSourceViewChanged(e);
            }
        }

        private void OnSourceViewChanged(DependencyPropertyChangedEventArgs e)
        {
            DataTable table = e.NewValue as DataTable;
            _currentView.DataSource = table;
            if (table != null)
            {
                _currentView.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

                if (table.Rows.Count != 0)
                {
                    _currentView.MasterTemplate.BestFitColumns(BestFitColumnMode.DisplayedCells);
                    _currentView.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                
                }
                _currentView.MasterTemplate.Refresh();
            }
        }

        public static DependencyProperty SelectedRowProperty =
            DependencyProperty.Register(
                "SelectedRow",
                typeof(DataRowView),
                typeof(KarveGridView),
                new PropertyMetadata(null, OnRowViewChange));
        private static void OnRowViewChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            KarveGridView karveGrid = d as KarveGridView;
            if (karveGrid != null)
            {
                karveGrid.OnPropertyChanged("SelectedRow");
                karveGrid.OnSelectedRow(e);
            }
        }

        internal void EndEdit()
        {
            throw new NotImplementedException();
        }

        private void OnSelectedRow(DependencyPropertyChangedEventArgs e)
        {
            DataRowView rowInfo = e.NewValue as DataRowView;
            if (rowInfo != null)
            {
                _currentRow = rowInfo;
            }
        }

        public static DependencyProperty ReadOnlyProperty =
            DependencyProperty.Register(
                "ReadOnly",
                typeof(bool),
                typeof(KarveGridView),
                new PropertyMetadata(false, OnReadOnlyChange));


        private static void OnReadOnlyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            KarveGridView karveGrid = d as KarveGridView;
            if (karveGrid != null)
            {
                karveGrid.OnPropertyChanged("ReadOnly");
                karveGrid.OnIsReadOnlyChanged(e);
            }
        }

        private void OnIsReadOnlyChanged(DependencyPropertyChangedEventArgs e)
        {
            bool value = Convert.ToBoolean(e.NewValue);
            
            if (value == false)
            {
                _currentView.ReadOnly = false;
                _currentView.EnableFiltering = true;
                _currentView.AllowEditRow = true;
                _currentView.AllowAddNewRow = true;
                _currentView.AllowDeleteRow = true;
                _currentView.AllowColumnChooser =true;
                _currentView.EnableGrouping = true;
                _currentView.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;
                _currentView.MultiSelect = true;
                _currentView.MasterTemplate.Refresh();

            }
            else
            {
                _currentView.ReadOnly = true;
                _currentView.EnableFiltering = true;
                _currentView.AllowEditRow = false;
                _currentView.AllowAddNewRow = false;
                _currentView.AllowDeleteRow =false;
                _currentView.MultiSelect = false;
                _currentView.AllowDragToGroup = true;
                _currentView.AllowColumnReorder = true;
                _currentView.EnableGrouping = true;
                _currentView.AllowColumnChooser = true;
                _currentView.MasterTemplate.Refresh();
                _currentView.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.FullRowSelect;
            }
            
           
        }

        public bool ReadOnly
        {
            get { return (bool)GetValue(ReadOnlyProperty); }
            set { SetValue(ReadOnlyProperty, value); }
        }

        public static DependencyProperty TableNameProperty =
            DependencyProperty.Register(
                "TableName",
                typeof(string),
                typeof(KarveGridView),
                new PropertyMetadata(string.Empty));
        
        public string TableName
        {
            get { return (string) GetValue(TableNameProperty); }
            set { SetValue(TableNameProperty, value);}
        }
       
        public static DependencyProperty ColumnsNamesProperty =
            DependencyProperty.Register(
                "ColumnNames",
                typeof(string),
                typeof(KarveGridView),
                new PropertyMetadata(string.Empty));

        public string ColumnNames
        {
            get { return (string)GetValue(ColumnsNamesProperty); }
            set { SetValue(ColumnsNamesProperty, value); }
        }
        
        public static DependencyProperty AutoGenerateColumnsDependencyProperty =
            DependencyProperty.Register(
                "AutoGenerateColumns",
                typeof(bool),
                typeof(KarveGridView),
                new PropertyMetadata(false));

        public static DependencyProperty TableAliasProperty =
            DependencyProperty.Register(
                "TableAlias",
                typeof(string),
                typeof(KarveGridView),
                new PropertyMetadata(string.Empty));

        public string TableAlias
        {
            get { return (string)GetValue(TableAliasProperty); }
            set { SetValue(TableAliasProperty, value); }
        }

        public string PrimaryKey
        {
            get { return (string)GetValue(PrimaryKeyProperty); }
            set { SetValue(PrimaryKeyProperty, value); }
        }
        public string AliasField
        {
            get { return (string)GetValue(AliasFieldProperty); }
            set { SetValue(AliasFieldProperty, value); }
        }

        public string AssistQuery
        {
            get { return (string)GetValue(AssitQueryProperty); }
            set { SetValue(AssitQueryProperty, value); }
        }
        public static DependencyProperty PageSizeProperty =
            DependencyProperty.Register(
                "PageSize",
                typeof(int),
                typeof(KarveGridView),
                new FrameworkPropertyMetadata(
                    CurrentViewPageSize,
                    FrameworkPropertyMetadataOptions.AffectsMeasure,
                    new PropertyChangedCallback(OnPageSizeChange)),
                new System.Windows.ValidateValueCallback(OnPageSizeValidateValue));

        public static DependencyProperty ColumnMinWidthProperty =
            DependencyProperty.Register(
                "ColumnWidth",
                typeof(int),
                typeof(KarveGridView),
                new FrameworkPropertyMetadata(
                    100,
                    FrameworkPropertyMetadataOptions.AffectsMeasure,
                    new PropertyChangedCallback(OnColumnWidthChange)),
                new System.Windows.ValidateValueCallback(OnColumnMinWidthValue));
        private static bool OnColumnMinWidthValue(object value)
        {
            int number = Convert.ToInt32(value);
            return GreaterThanZero(number);
        }

        private static void OnColumnWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            KarveGridView karveGrid = d as KarveGridView;
            if (karveGrid != null)
            {
                karveGrid.OnPropertyChanged("ColumnWidth");
                karveGrid.OnColumnWidthChanged(e);
            }
        }
        private void OnColumnWidthChanged(DependencyPropertyChangedEventArgs e)
        {
            Telerik.WinControls.UI.GridViewColumnCollection cols = this._currentView.Columns;
            _columnWidth = Convert.ToInt32(e.NewValue);

            foreach (GridColView column in _currentView.Columns)
            {
                if (column is GridViewDataColumn)
                {
                    GridViewDataColumn col = column as GridViewDataColumn;
                    if (col != null)
                    {
                        col.Width = _columnWidth;
                    }
                }
            }

        }
        #endregion
        #region Custom Events

        public static readonly System.Windows.RoutedEvent FilterChangeEvent =
            EventManager.RegisterRoutedEvent(
                "FilterChangeEvent",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(KarveGridView));


        public static readonly System.Windows.RoutedEvent PageChangeEvent =
            EventManager.RegisterRoutedEvent(
                "PageChangeEvent",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(KarveGridView));

      

        // RowDoubleClickEvent
        public static readonly System.Windows.RoutedEvent RowDoubleClickEvent =
            EventManager.RegisterRoutedEvent(
                "RowDoubleClickEvent",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(KarveGridView));

        public static readonly System.Windows.RoutedEvent ColumnQueryEvent =
            EventManager.RegisterRoutedEvent(
                "ColumnQueryEvent",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(KarveGridView));

        public static readonly System.Windows.RoutedEvent UpdateQueryEvent =
            EventManager.RegisterRoutedEvent(
                "UpdateQueryEvent",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(KarveGridView));


        public static readonly System.Windows.RoutedEvent QueryDataTableEvent =
            EventManager.RegisterRoutedEvent(
                "QueryDataTableEvent",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(KarveGridView));

        public static readonly System.Windows.RoutedEvent SelectedRowGridViewEvent =
            EventManager.RegisterRoutedEvent(
                "SelectedRowGridViewEvent",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(KarveGridView));

        public static readonly System.Windows.RoutedEvent ChangedRowsGridViewEvent =
            EventManager.RegisterRoutedEvent("ChangedRows",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(KarveGridView));

        /// <summary>
        ///  This event is the event of delete rows. It gets triggered when the user deletes a row.
        /// </summary>
        public class ChangedGridViewEventArgs : System.Windows.RoutedEventArgs
        {

            private string _tableName;
            private object _dataSource;
            

            /// <summary>
            /// This lists the parameters that the event can convey.
            /// </summary>
            public enum EventParams {
                /// <summary>
                /// Source of the data. It is a data source 
                /// </summary>
                DataSource,                         
               /// <summary>
               /// Name of the table
               /// </summary>
               TableName,   
               /// <summary>
               /// Rows deleted.
               /// </summary>
                RowsDeleted,     
                /// <summary>
                /// Operation done in the grid.
                /// </summary>
                Operation,
                /// <summary>
                /// Alias field.
                /// </summary>
                AliasField
            }

            /// <summary>
            ///  Operation that changes the parameters.
            /// </summary>
            /// TODO This enum is duplicated in the DataPayLoad and it shall match.
            public enum Operation
            {
                /// <summary>
                /// Insert an item
                /// </summary>
                Insert = 0,
                /// <summary>
                /// Delete an item.
                /// </summary>
                Delete = 1,
                /// <summary>
                /// Update an item
                /// </summary>
                Update = 2
            }
            /// <summary>
            ///  Rows changed
            /// </summary>
            private object _currentArrayList;
            /// <summary>
            /// Kind of operation
            /// </summary>
            private Operation _operation;

            /// <summary>
            ///  Base constructor
            /// </summary>
            public ChangedGridViewEventArgs() : base()
            {

            }
            /// <summary>
            ///  Constructor with an event.
            /// </summary>
            /// <param name="routedEvent"> This gives you the routedEvent</param>
            public ChangedGridViewEventArgs(System.Windows.RoutedEvent routedEvent) : base(routedEvent)
            {

            }
            /// <summary>
            ///  This returns the current arraylist for the deleted collection in the grid.
            /// </summary>
            public object Rows
            {
                get { return _currentArrayList; }
                set { _currentArrayList = value; }
            }

            /// <summary>
            ///  This returns the current data table.
            /// </summary>
            public object DataSource
            {
                get { return _dataSource; }
                set { _dataSource = value; }
            }
            /// <summary>
            ///  Name of the table.
            /// </summary>
            public string TableName
            {
                get { return _tableName; }
                set { _tableName = value; }
            }
            /// <summary>
            ///  Current operation that the event conveys.
            /// </summary>
            public Operation CurrentOperation
            {
                get { return _operation; }
                set { _operation = value; }
            }

            /// <summary>
            ///  Dictionary of the parameters present in the event.
            /// </summary>
            public IDictionary<EventParams, object> RowParameters
            {
                get
                {
                    Dictionary<EventParams, object> dictionary = new Dictionary<EventParams, object>();
                    if (DataSource != null)
                    {
                        dictionary.Add(EventParams.DataSource, DataSource);
                    }
                    if (string.IsNullOrEmpty(TableName))
                    {
                        dictionary.Add(EventParams.TableName, TableName);
                    }
                    if (Rows != null)
                    {
                        dictionary.Add(EventParams.RowsDeleted, Rows);
                    }
                    if (AliasField != null)
                    {
                        dictionary.Add(EventParams.AliasField, AliasField);
                    }
                    dictionary.Add(EventParams.Operation, CurrentOperation);
                    return dictionary;
                }
            }
            /// <summary>
            ///  Relational Id value.
            /// </summary>
            public string AliasField { get; set; }
        }


        private object _relationalId;
        private bool _dataSetFiltering;
        private bool _bScrolling;
         /// <summary>
         /// Master template for the grid.
         /// </summary>
        private MasterGridViewTemplate _masterTemplate;
        private int _currentPageIndex;
        private bool _isItemChanged;
        private DependencyProperty PrimaryKeyProperty;
        private int _pageSize;
        private DataRowView _currentRow;

        public event RoutedEventHandler QueryDataTableRequest
        {
            add { AddHandler(QueryDataTableEvent, value); }
            remove { RemoveHandler(QueryDataTableEvent, value); }
        }
        public event RoutedEventHandler PageChanging
        {
            add { AddHandler(PageChangeEvent, value); }
            remove { RemoveHandler(PageChangeEvent, value); }
        }
        public event RoutedEventHandler RowMouseDoubleClick
        {
            add { AddHandler(RowDoubleClickEvent, value); }
            remove { RemoveHandler(RowDoubleClickEvent, value); }
        }
        public event RoutedEventHandler ColumnQueryRequest
        {
            add => AddHandler(ColumnQueryEvent, value);
            remove => RemoveHandler(ColumnQueryEvent, value);
        }
        public event RoutedEventHandler SelectionRowChanged
        {
            add => AddHandler(SelectedRowGridViewEvent, value);
            remove => RemoveHandler(SelectedRowGridViewEvent, value);
        }
        /// <summary>
        ///  This event is to detect any modification to the grid. It can be a delete, insert, add of a row.
        /// </summary>
        public event RoutedEventHandler ChangedRows
        {
            add { AddHandler(ChangedRowsGridViewEvent, value); }
            remove { RemoveHandler(ChangedRowsGridViewEvent, value); }
        }
        private void QueryDataTable(string table, string alias, bool isMergeNeeded)
        {
            Events.Events.QueryDataTableEventArgs args = new Events.Events.QueryDataTableEventArgs(QueryDataTableEvent);
            args.Table = table;
            args.Alias = alias;
            args.Merge = isMergeNeeded;
            RaiseEvent(args);
        }
        private void UpdateData(DataSet dataSet, string sqlQuery)
        {
            Events.UpdateQueryEventArgs args = new Events.UpdateQueryEventArgs();
            args.DataSet = dataSet;
            args.SqlQuery = sqlQuery;
            RaiseEvent(args);
        }

        private void PageChangingData()
        {
            
            Events.PageChangingEventArgs args = new Events.PageChangingEventArgs(PageChangeEvent);
            args.PageIndex = _currentView.MasterTemplate.PageIndex;
            _currentPageIndex = args.PageIndex;
            //
            //RaiseEvent(args);
        }

        private void QueryColumnsName(string sql, string table, string alias)
        {
            global::KarveControls.KarveGrid.Events.QueryColumnsName args = new global::KarveControls.KarveGrid.Events.QueryColumnsName();
            args.SqlQuery = sql;
            args.AliasName = alias;
            args.TableName = table;
            RaiseEvent(args);
        }

        private void ChangeFilterEvents(IList<string> expressionList)
        {
            global::KarveControls.KarveGrid.Events.ChangeFilterEvent args = new global::KarveControls.KarveGrid.Events.ChangeFilterEvent(FilterChangeEvent);
            args.ExpressionList = expressionList;
            args.TableName = this.TableName;
            RaiseEvent(args);
        }
        #endregion


        static KarveGridView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(KarveGridView),
                new FrameworkPropertyMetadata(typeof(KarveGridView)));
        }
        /// <summary>
        ///  This class is a wrapper to the Telerick Grid for allowing WPF Grid.
        /// </summary>
        public KarveGridView() : base()
        {
            
            _currentView.EnablePaging = true;
            _currentView.PageSize = CurrentViewPageSize;
            _currentView.Width = (int)this.Width;
            _currentView.Height = (int) this.Height;
            _currentView.EnableFiltering = true;
            _currentView.MasterTemplate.BestFitColumns(BestFitColumnMode.DisplayedCells);
            _currentView.MasterTemplate.Refresh();
            System.Windows.Forms.Integration.WindowsFormsHost host = new System.Windows.Forms.Integration.WindowsFormsHost();
            host.Child = _currentView;
            this.Children.Add(host);
            SetColumnWidth(this.ColumnWidth);
        
            InitContainers();
            InitEvents();
     }
        /// <summary>
        ///  This method handle the changes from the grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentViewOnRowsChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            ChangedGridViewEventArgs changedEventArgs = new ChangedGridViewEventArgs(ChangedRowsGridViewEvent);
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                changedEventArgs.TableName = TableName;
                changedEventArgs.DataSource = _currentView.DataSource;
                changedEventArgs.Rows = e.NewItems;
                changedEventArgs.AliasField = AliasField;
                changedEventArgs.CurrentOperation = ChangedGridViewEventArgs.Operation.Delete;
                RaiseEvent(changedEventArgs);
            }
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                changedEventArgs.TableName = TableName;
                changedEventArgs.DataSource = _currentView.DataSource;
                changedEventArgs.Rows = e.NewItems;
                changedEventArgs.AliasField = AliasField;
                changedEventArgs.CurrentOperation = ChangedGridViewEventArgs.Operation.Insert;
                RaiseEvent(changedEventArgs);
            }
            if (e.Action == NotifyCollectionChangedAction.ItemChanged)
            {
                _isItemChanged = true;
            }
            
        }
       
        // the cell has been edited and validated.
       
        private void CurrentViewOnCellEndEdit(object sender, GridViewCellEventArgs eventArgs)
        {
            ChangedGridViewEventArgs changedEventArgs = new ChangedGridViewEventArgs(ChangedRowsGridViewEvent);
            if (_isItemChanged)
            {
                changedEventArgs.TableName = TableName;
                changedEventArgs.DataSource = _currentView.DataSource;
                changedEventArgs.Rows = eventArgs.Row;
                changedEventArgs.AliasField = AliasField;
                changedEventArgs.CurrentOperation = ChangedGridViewEventArgs.Operation.Update;
                RaiseEvent(changedEventArgs);
            }
        }


        private void InitContainers()
        {
            foreach (var column in _currentView.Columns)
            {
                if (column is GridViewDataColumn)
                {
                    GridViewDataColumn col = column as GridViewDataColumn;
                    if (col != null)
                    {
                        col.Width = this.ColumnWidth;

                    }
                }
            }
          
        }
 

        private static bool OnPageSizeValidateValue(object value)
        {
            int number = Convert.ToInt32(value);
            return GreaterThanZero(number);
        }

        private static bool GreaterThanZero(int value)
        {
            int tmp = Convert.ToInt32(value);
            return (tmp > 0);
        }
        private static void OnPageSizeChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            KarveGridView karveGrid = d as KarveGridView;
            if (karveGrid != null)
            {
                karveGrid.OnPropertyChanged("PageSize");
                karveGrid.OnPageSizeChanged(e);
            }
        }

        private void OnPageSizeChanged(DependencyPropertyChangedEventArgs e)
        {
            int value = Convert.ToInt32(e.NewValue);
            _currentView.PageSize = value;
        }

        

        private void SetColumnWidth(int columnWidth)
        {
            foreach (var column in _currentView.Columns)
            {
                if (column is GridViewDataColumn)
                {
                    GridViewDataColumn col = column as GridViewDataColumn;
                    if (col != null)
                    {
                        col.Width = columnWidth;

                    }
                }
            }
        }
        /// <summary>
        ///  This return the selected row in the DataGrid.
        /// </summary>
        public DataRowView SelectedRow
        {
            get
            {
                return (DataRowView)GetValue(SelectedRowProperty);
            }
            set { SetValue(SelectedRowProperty, value); }
            
        }

        private void KarveGridView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            System.Windows.Forms.Integration.WindowsFormsHost host = (System.Windows.Forms.Integration.WindowsFormsHost)Children[0];
            host.Height = Convert.ToInt32(e.NewSize.Height);
            host.Width = Convert.ToInt32(e.NewSize.Width);
            _currentView.Width = Convert.ToInt32(e.NewSize.Width);
            _currentView.Height = Convert.ToInt32(e.NewSize.Height);
        }
        /// <summary>
        ///  This set the DataSource in a form of a data table
        /// </summary>
        public DataTable SourceView
        {
            get { return (DataTable)GetValue(SourceViewProperty); }
            set
            {
                SetValue(SourceViewProperty, value);
                _currentView.MasterTemplate.BestFitColumns(BestFitColumnMode.DisplayedCells);
                _currentView.MasterTemplate.Refresh();

            }
        }
        /// <summary>
        ///  This returns the PageSize
        /// </summary>
        public int PageSize
        {
            get { return (int)GetValue(PageSizeProperty); }
            set
            {
                SetValue(PageSizeProperty, value);
                _pageSize = value;
            }
        }
        /// <summary>
        ///  This sets the 
        /// </summary>
        public int ColumnWidth
        {
            get { return (int)GetValue(ColumnMinWidthProperty); }
            set
            {
                SetValue(ColumnMinWidthProperty, value);

            }
        }

        public bool AutoGenerateColumns
        {
            get { return (bool)GetValue(AutoGenerateColumnsDependencyProperty); }
            set
            {
                bool tmpValue = Convert.ToBoolean(value);
                SetValue(AutoGenerateColumnsDependencyProperty, tmpValue);

            }
        }

        public bool RowsMark { get; internal set; }

        public Telerik.WinControls.UI.GridViewColumnCollection Columns
        {
            get
            {
                return this._currentView.Columns;
            }
        }
        private void DataGrid_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {
            RadTextBoxEditor tbEditor = _currentView.ActiveEditor as RadTextBoxEditor;
            if ((tbEditor != null))
            {
                RadTextBoxEditorElement tbElement = (RadTextBoxEditorElement)tbEditor.EditorElement;
                tbElement.KeyDown -= tbElement_KeyDown;
                tbElement.KeyDown += tbElement_KeyDown;
            }
        }
        private void DataGrid_EditorRequired(object sender, EditorRequiredEventArgs e)
        {
            if (object.ReferenceEquals(e.EditorType, typeof(GridBrowseEditor)))
            {
                e.EditorType = typeof(BrowerGridEditorKarve);
            }
        }

        private void tbElement_KeyDown(object sender, KeyEventArgs e)
        {
            if (DataGridType == GridType.Search)
            {
                if (_currentView.MasterView.TableFilteringRow.IsCurrent)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                      //  LoadQuery();
                    }
                    else if (e.KeyCode == Keys.F4)
                    {

                    }
                }
            }
        }

        
        
        private FilterDescriptor LoadDateFilter(DataGridRule dataGridRule)
        {
            DateFilterDescriptor dateFilterDescriptor = new DateFilterDescriptor();
            dateFilterDescriptor.Value = Convert.ToDateTime(dataGridRule.Value);
            dateFilterDescriptor.Operator = DataGridRule.TranslateFilter(dataGridRule.Criterio);
            dateFilterDescriptor.IsFilterEditor = true;
            dateFilterDescriptor.PropertyName = dataGridRule.Name;
            return dateFilterDescriptor;
        }

        private FilterDescriptor LoadTextFilter(DataGridRule dataGridRule)
        {
            FilterDescriptor textFilterDescriptor = new FilterDescriptor();
            textFilterDescriptor.Value = dataGridRule.Value;
            textFilterDescriptor.Operator = DataGridRule.TranslateFilter(dataGridRule.Criterio);
            textFilterDescriptor.IsFilterEditor = true;
            textFilterDescriptor.PropertyName = dataGridRule.Name;
            return textFilterDescriptor;
        }

        private void DataGrid_FilterChanging(object sender, GridViewCollectionChangingEventArgs e)
        {
           
            /*
            IDictionary<Type, IKarveGridFilter> filterTypes = new Dictionary<Type, IKarveGridFilter>();
            object value = e.NewValue;
            
            FilterDescriptor filterDescriptor = null;
            CompositeFilterDescriptor compositeFilter = null;
            if (e.NewValue is FilterDescriptor)
            {
                filterDescriptor = (FilterDescriptor) e.NewValue;
            }
            else
            {
                compositeFilter = (CompositeFilterDescriptor) e.NewValue;
            }
            // check if this exists
            filterTypes.Add(typeof(FilterDescriptor), new TextFilter(filterDescriptor));
            filterTypes.Add(typeof(DateFilterDescriptor), new DateFilter(filterDescriptor));
            filterTypes.Add(typeof(CompositeFilterDescriptor), new KarveCompositeFilter(compositeFilter));

            if (!_dataSetFiltering)
            {
                if (_loading == false)
                {
                    _bChangeOperator = false;
                    switch (e.Action)
                    {
                        case NotifyCollectionChangedAction.Remove:
                            _dataGridRules.Remove(e.PropertyName);
                            _bChangeOperator = true;
                            _reQuery = false;
                            break;
                        default:
                            Type type = e.NewItems[0].GetType();
                            filterTypes[type].Apply(_dataGridColumns, ref _dataGridRules);
                            break;
                    }
                    _dataGridDefinition.Clausulas = _dataGridRules;
                    e.Cancel = !_bChangeOperator;
                }
            }
            */
        }
        public void LoadOrdered()
        {
            /*
            this._loading = true;
            _currentView.MasterTemplate.SortDescriptors.Clear();
            foreach (DataGridOrderedColumn column in _dataGridOrderedColumns.Ordered())
            {
                if (ExistColumn(column.Name))
                {
                    ListSortDirection direction = ListSortDirection.Ascending;
                    if (column.Criteria == DataGridOrderedColumn.OrderCriteria.Desc)
                    {
                        direction = ListSortDirection.Descending;
                    }
                    _currentView.MasterTemplate.SortDescriptors.Add(column.Name, direction);
                }
            }
            */
        }
        
        public object DataSource
        {
            get { return this._currentView.DataSource; }
            set { this._currentView.DataSource = value; }
        }

        public DataGridColumnGroups ViewDefinition
        {
            get { return this.ViewDefinition; }
            set { this.ViewDefinition = value; }
        }

        public bool AllowAddNewRow { get; internal set; }
        public bool AllowEditRow { get; internal set; }
        public bool AllowDeleteRow { get; internal set; }
        public GridType DataGridType { get; internal set; }
        public DependencyProperty AssitQueryProperty { get; set; }

        private void Init()
        {
            this._masterTemplate = _currentView.MasterTemplate;
        }

        private void InitEvents()
        {
            if (_currentView != null)
            {
                SizeChanged += KarveGridView_SizeChanged;
                _currentView.CellEndEdit += CurrentViewOnCellEndEdit;
                _currentView.RowsChanged += CurrentViewOnRowsChanged;
                _currentView.FilterChanged += DataGrid_FilterChanged;
                _currentView.EnableGrouping = true;
                _currentView.EnableSorting = true;
                _currentView.EnableFiltering = true;
                _currentView.EnablePaging = true;
                _currentView.SelectionMode = GridViewSelectionMode.FullRowSelect;
                _currentView.CurrentRowChanged+=CurrentViewOnSelectionChanged;
                _currentView.PageChanging += DataGrid_PageChanging;                
                _currentView.CellEndEdit+=CurrentViewOnCellEndEdit;
                _currentView.CellDoubleClick+=CurrentViewOnCellDoubleClick;
                
            }
        }

        private void CurrentViewOnCellDoubleClick(object sender, GridViewCellEventArgs gridViewCellEventArgs)
        {
            GridViewRowInfo info = _currentView.CurrentRow;
            GridViewSelectedCellsChangedEventArgs args = new GridViewSelectedCellsChangedEventArgs(RowDoubleClickEvent); 
            this.SelectedRow = info.DataBoundItem as DataRowView;
            args.CurrentRow = info;
            RaiseEvent(args);
        }
        
        private void CurrentViewOnSelectionChanged(object sender, EventArgs eventArgs)
        {
            GridViewRowInfo info = _currentView.CurrentRow;
            GridViewSelectedCellsChangedEventArgs args = new GridViewSelectedCellsChangedEventArgs(SelectedRowGridViewEvent);
            args.CurrentRow = info;
            this.SelectedRow = info.DataBoundItem as DataRowView;

            RaiseEvent(args);
        }

        
        
        private void DataGrid_FilterChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            
            IList<string> filterCurrent = new List<string>();
            foreach (var item in e.NewItems)
            {
                FilterDescriptor filterDescriptor = item as FilterDescriptor;
                if (filterDescriptor != null)
                {

                    string set = filterDescriptor.Expression;
                    filterCurrent.Add(set);
                }
            }
            ChangeFilterEvents(filterCurrent);
        }
        
        private void DataGrid_PageChanging(object sender, Telerik.WinControls.PageChangingEventArgs e)
        {
            /*Change data and raise an event*/ 
           PageChangingData();   
        }

        private void VScrollBar_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            RadScrollBarElement scrollBar = _currentView.TableElement.VScrollBar;
            int deltaScrollBar = scrollBar.Maximum - scrollBar.Value;
            _bScrolling = true;
            if (deltaScrollBar <= (scrollBar.LargeChange - 1))
            {
                LoadMergeQuery();
            }
            _bScrolling = false;
        }

        private void LoadMergeQuery()
        {
            throw new NotImplementedException();
        }

        private void DataGrid_MouseWheel(object sender, MouseEventArgs e)
        {
            RadScrollBarElement scrollBar = _currentView.TableElement.VScrollBar;
            int deltaScrollBar = scrollBar.Maximum - scrollBar.Value;

            if (DataGridType == GridType.Search)
            {
                if (deltaScrollBar <= (scrollBar.LargeChange - 1))
                {
                    LoadMergeQuery();
                }
            }
        }
        
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            object tmpContainer = GetTemplateChild("PART_GridContainer");
            _baseContainer = tmpContainer as Grid;
            if (_baseContainer != null)
            {
                _baseContainer.Loaded += KarveGrid2_Loaded;
            }
        }
        private void KarveGrid2_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Windows.Forms.Integration.WindowsFormsHost host = new System.Windows.Forms.Integration.WindowsFormsHost();
            host.Child = _currentView;
            _baseContainer.Children.Add(host);
        }
    }
}
