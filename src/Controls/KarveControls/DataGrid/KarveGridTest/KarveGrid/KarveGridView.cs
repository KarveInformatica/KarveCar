using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Binding = System.Windows.Data.Binding;
using PropertyChangedCallback = System.Windows.PropertyChangedCallback;
using GridColView = Telerik.WinControls.UI.GridViewColumn;
using KarveGrid.Column;
using KarveGrid.Column.Types;
using KarveGrid.Events;
using KarveGrid.GridDefinition;
using KarveGrid.GridFilters;
using KarveGrid.GridOrder;
using KarveGrid.GridTable;
using KarveGrid.KarveEditor.BrowerGridEditorKarve;
using Telerik.WinControls.Data;
using DataGridColumn = KarveGrid.Column.DataGridColumn;
using DataGridTextBoxColumn = KarveGrid.Column.Types.DataGridTextBoxColumn;
using MessageBox = System.Windows.MessageBox;

namespace KarveGrid
{
    public class KarveGridView : Grid, INotifyPropertyChanged
    {
        #region Private Variables
        private RadGridView _currentView = new RadGridView();
        private Grid _baseContainer;
        private int _columnWidth = 100;
        private int _pageSize;
        private DataGridTemplate _dataGridDefinition = new DataGridTemplate();
        private DataGridRules _dataGridRules = new DataGridRules();
        private DataGridTables _dataGridTables = new DataGridTables();
        private DataGridColumns _dataGridColumns = new DataGridColumns();
        private DataGridOrderedColumns _dataGridOrderedColumns = new DataGridOrderedColumns();
        private DataGridColumnGroups _dataGridColumnGroups = new DataGridColumnGroups();
        private DataGridTextBoxColumn _relationalColumn = new DataGridTextBoxColumn();
        private bool _loading;
        private bool _reQuery;
        /// <summary>
        ///  This delegate trigger an internal query that it will raise an event to the view model.
        /// </summary>
        /// <param name="Clausulas"></param>
        private delegate void TriggerQueryEventHandler(DataGridRules Clausulas);
        private TriggerQueryEventHandler TriggerQuery;
        private bool _bChangeOperator;
        private MasterGridViewTemplate _masterTemplate;
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
        public enum GridType
        {
            Edit,
            Search
        }
        #endregion
        #region DependencyProperty

        public static DependencyProperty SourceViewProperty =
            DependencyProperty.Register(
                "SourceView",
                typeof(DataTable),
                typeof(KarveGridView),
                new PropertyMetadata(new DataTable(), OnSourceViewChange));

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

        public static DependencyProperty PageSizeProperty =
            DependencyProperty.Register(
                "PageSize",
                typeof(int),
                typeof(KarveGridView),
                new FrameworkPropertyMetadata(
                    20,
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

        #endregion
        #region Custom Events

        public static readonly System.Windows.RoutedEvent FilterChangeEvent =
            EventManager.RegisterRoutedEvent(
                "FilterChangeEvent",
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

        public static readonly System.Windows.RoutedEvent ModifiedCellRoutedEvent =
            EventManager.RegisterRoutedEvent(
                "ModifiedCellRoutedEvent",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(KarveGridView));

        private object _relationalId;
        private bool _dataSetFiltering;
        private bool _bScrolling;

        public event RoutedEventHandler QueryDataTableRequest
        {
            add { AddHandler(QueryDataTableEvent, value); }
            remove { RemoveHandler(QueryDataTableEvent, value); }
        }
        public event RoutedEventHandler UpdateDataTableChanged
        {
            add { AddHandler(UpdateQueryEvent, value); }
            remove { RemoveHandler(UpdateQueryEvent, value); }
        }
        public event RoutedEventHandler ColumnQueryRequest
        {
            add { AddHandler(ColumnQueryEvent, value); }
            remove { RemoveHandler(ColumnQueryEvent, value); }
        }
        public event RoutedEventHandler SelectionRowChanged
        {
            add { AddHandler(SelectedRowGridViewEvent, value); }
            remove { RemoveHandler(SelectedRowGridViewEvent, value); }
        }
        private void QueryDataTable(string table, string alias, bool isMergeNeeded)
        {
            Events.QueryDataTableEventArgs args = new Events.QueryDataTableEventArgs(QueryDataTableEvent);
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

        private void QueryColumnsName(string sql, string table, string alias)
        {
            Events.QueryColumnsName args = new Events.QueryColumnsName();
            args.SqlQuery = sql;
            args.AliasName = alias;
            args.TableName = table;
            RaiseEvent(args);
        }

        private void ChangeFilterEvents(IList<string> expressionList)
        {
            Events.ChangeFilterEvent args = new Events.ChangeFilterEvent(FilterChangeEvent);
            args.ExpressionList = expressionList;
            args.TableName = this.TableName;
            //       RaiseEvent();
        }
        #endregion


        static KarveGridView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(KarveGridView),
                new FrameworkPropertyMetadata(typeof(KarveGridView)));
        }
        public KarveGridView() : base()
        {

            _currentView.EnablePaging = true;
            _currentView.PageSize = 20;
            _currentView.Width = (int)this.Width;
            _currentView.EnableFiltering = true;
            System.Windows.Forms.Integration.WindowsFormsHost host = new System.Windows.Forms.Integration.WindowsFormsHost();
            host.Child = _currentView;
            this.Children.Add(host);
            SetColumnWidth(this.ColumnWidth);
            this.SizeChanged += KarveGridView_SizeChanged;
            InitContainers();
            InitEvents();
            InitDelegates();
        }

        private void InitContainers()
        {
           
        }

        public void InitDelegates()
        {
            _dataGridDefinition = new DataGridTemplate();
            _dataGridDefinition.QueryColumnsName += QueryColumnsName;
            _dataGridDefinition.UpdateData += UpdateData;
            _dataGridDefinition.QueryDataTable += QueryDataTable;
            TriggerQuery+=TriggerQueryUpdate;
        }

        private void TriggerQueryUpdate(DataGridRules clausulas)
        {
            MessageBox.Show("Name");
        } 

        private static bool OnColumnMinWidthValue(object value)
        {
            int number = Convert.ToInt32(value);
            return GreaterThanZero(number);
        }

        private static void OnColumnWidthChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            KarveGridView karveGrid = d as KarveGridView;
            karveGrid.OnPropertyChanged("ColumnWidth");
            karveGrid.OnColumnWidthChanged(e);
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
            karveGrid.OnPropertyChanged("PageSize");
            karveGrid.OnPageSizeChanged(e);
        }

        private void OnPageSizeChanged(DependencyPropertyChangedEventArgs e)
        {
            int value = Convert.ToInt32(e.NewValue);
            _currentView.PageSize = value;
        }

        private static void OnSourceViewChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            KarveGridView karveGrid = d as KarveGridView;
            karveGrid.OnPropertyChanged("SourceView");
            karveGrid.OnSourceViewChanged(e);

        }

        private void OnSourceViewChanged(DependencyPropertyChangedEventArgs e)
        {
            DataTable table = e.NewValue as DataTable;
            _currentView.DataSource = table;
            foreach (var column in _currentView.Columns)
            {
                if (column is GridViewDataColumn)
                {
                    GridViewDataColumn col = column as GridViewDataColumn;
                    if (col != null)
                    {
                        col.Width = 100;

                    }
                }
            }
            _masterTemplate = _currentView.MasterTemplate;
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


        private void KarveGridView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            System.Windows.Forms.Integration.WindowsFormsHost host = (System.Windows.Forms.Integration.WindowsFormsHost)Children[0];
            host.Height = Convert.ToInt32(e.NewSize.Height);
            host.Width = Convert.ToInt32(e.NewSize.Width);
            _currentView.Width = Convert.ToInt32(e.NewSize.Width);
            _currentView.Height = Convert.ToInt32(e.NewSize.Height);
        }

        public DataTable SourceView
        {
            get { return (DataTable)GetValue(SourceViewProperty); }
            set
            {
                SetValue(SourceViewProperty, value);
                _currentView.DataSource = value;
                _currentView.MasterTemplate.BestFitColumns(BestFitColumnMode.DisplayedCells);
                _currentView.MasterTemplate.Refresh();

            }
        }
        private bool ExistColumn(string Value)
        {
            GridViewCellInfoCollection cellInfo = _currentView.MasterView.TableFilteringRow.Cells;
            foreach (GridViewCellInfo cell in cellInfo)
            {
                if (cell.ColumnInfo.Name == Value)
                    return true;
            }
            return false;
        }
        public int PageSize
        {
            get { return (int)GetValue(PageSizeProperty); }
            set
            {
                SetValue(PageSizeProperty, value);
                _pageSize = value;
                PageSize = _pageSize;
            }
        }
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
                        LoadQuery();
                    }
                    else if (e.KeyCode == Keys.F4)
                    {

                    }
                }
            }
        }
        public void LoadQuery(bool bMerge = false)
        {

            _loading = true;
            _reQuery = false;
            KarveGridView view = this;
            _dataGridDefinition.LoadQueries(ref view, bMerge);
            LoadFilters();
            LoadOrdered();
            TriggerQuery?.Invoke(_dataGridRules);
            _loading = false;
        }
        public void LoadFilters()
        {
            _currentView.FilterDescriptors.BeginUpdate();
            _currentView.FilterDescriptors.Clear();
            foreach (DataGridRule dataGridRule in _dataGridRules.Order())
            {
                FilterDescriptor filterDescriptor = null;
                switch (dataGridRule.CurrentFilterType)
                {
                    case DataGridRule.FilterType.Text:
                        filterDescriptor = LoadTextFilter(dataGridRule);
                        break;
                    case DataGridRule.FilterType.Data:
                        filterDescriptor = LoadDateFilter(dataGridRule);
                        break;
                    case DataGridRule.FilterType.Composed:
                        filterDescriptor = LoadCompositeFilter(dataGridRule);
                        break;
                }
                _currentView.FilterDescriptors.Add(filterDescriptor);
            }
            _currentView.FilterDescriptors.EndUpdate();
        }

        private FilterDescriptor LoadCompositeFilter(DataGridRule dataGridRule)
        {
            CompositeFilterDescriptor compositeFilter = new CompositeFilterDescriptor();
            FilterDescriptor filterDescriptor = null;
            foreach (var partGridRule in dataGridRule.Rules.Order())
            {
                DataGridRule.FilterType filterType = partGridRule.CurrentFilterType;
                switch (filterType)
                {
                    case DataGridRule.FilterType.Text:
                        filterDescriptor = LoadTextFilter(partGridRule);
                        break;
                    case DataGridRule.FilterType.Data:
                        filterDescriptor = LoadDateFilter(partGridRule);
                        break;
                }
                if (filterDescriptor != null)
                {
                    filterDescriptor.PropertyName = dataGridRule.Name;
                    compositeFilter.FilterDescriptors.Add(filterDescriptor);
                }
            }
            compositeFilter.Value = dataGridRule.Value;
            compositeFilter.Operator = FilterOperator.Contains;
            compositeFilter.IsFilterEditor = true;
            compositeFilter.PropertyName = dataGridRule.Name;
            compositeFilter.LogicalOperator = (dataGridRule.Operador == DataGridRule.OperatorRule.And)
                ? FilterLogicalOperator.And
                : FilterLogicalOperator.Or;
            compositeFilter.NotOperator = dataGridRule.Expresion.Substring(1, 3) == "NOT" ? true : false;
            return compositeFilter;
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
        }
        public void LoadOrdered()
        {
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
        }
        public void SetRelationalIdentifier()
        {
            foreach (var row in _currentView.Rows)
            {
                row.Cells[_relationalColumn.Name].Value = _relationalId;
            }
            if (DataGridType == GridType.Edit)
            {
                DataGridRules dataGridRules = new DataGridRules();
                DataGridRule dataGridRule = new DataGridRule();
                dataGridRule.Criterio = DataGridRule.SortingCriteria.IsEqualTo;
                dataGridRule.Table = _relationalColumn.Table;
                dataGridRule.ExtendedFieldName = (!string.IsNullOrEmpty(_relationalColumn.ExtendedFieldName)
                    ? _relationalColumn.ExtendedFieldName
                    : _relationalColumn.AliasField);

                dataGridRule.Name = _relationalColumn.Name;
                dataGridRules.Add(dataGridRule);
                _dataGridDefinition.Clausulas.Clear();
                _dataGridDefinition.Clausulas = dataGridRules;
            }
        }

        private void GridDelegacion_UserAddingRow(object sender, Telerik.WinControls.UI.GridViewRowCancelEventArgs e)
        {
            if (e.Rows.Length > 0)
            {
                e.Rows[0].Cells[RelationalColumn.Name].Value = _relationalId;
            }
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

        public DataGridTextBoxColumn RelationalColumn
        {
            get { return _relationalColumn; }
            set { _relationalColumn = value; }
        }

       

        private void Init()
        {
            this._masterTemplate = _currentView.MasterTemplate;
        }

        private void InitEvents()
        {
            if (_currentView != null)
            {
                _currentView.FilterChanged += DataGrid_FilterChanged;
                _currentView.RowFormatting += DataGrid_RowFormatting;
                _currentView.EnableGrouping = true;
                _currentView.EnableSorting = true;
                _currentView.SelectionMode = GridViewSelectionMode.FullRowSelect;
                _currentView.EnablePaging = true;
                _currentView.CurrentRowChanged+=CurrentViewOnSelectionChanged;
                _currentView.PageChanging += DataGrid_PageChanging;
                _currentView.CellEndEdit+=CurrentViewOnCellEndEdit;
                
            }
        }

        private void CurrentViewOnCellEndEdit(object sender, GridViewCellEventArgs gridViewCellEventArgs)
        {
            GridViewRowInfo info = _currentView.CurrentRow;
            GridRowModifiedCellEventArgs args = new GridRowModifiedCellEventArgs(ModifiedCellRoutedEvent);
            args.CurrentRow = info;
            RaiseEvent(args);

        }

        private void CurrentViewOnSelectionChanged(object sender, EventArgs eventArgs)
        {
            GridViewRowInfo info = _currentView.CurrentRow;
            GridViewSelectedCellsChangedEventArgs args = new GridViewSelectedCellsChangedEventArgs(SelectedRowGridViewEvent);
            args.CurrentRow = info;
            RaiseEvent(args);
        }

        private void DataGrid_SortChanging(object sender, GridViewCollectionChangingEventArgs e)
        {
            DataGridOrderedColumn orderedColumn = new DataGridOrderedColumn();
            if (DataGridType == GridType.Search)
            {
                if (_loading == false)
                {
                    e.Cancel = true;
                    if (e.NewItems.Count != 0)
                    {
                        DataGridColumn name = e.NewItems[0] as DataGridColumn;
         //               dynamic col = _dataGridDefinition.Columns[name.Pro]
                    }
                }
                
            }
        }

        
        private void DataGrid_FilterChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            
            IList<string> filterCurrent = new List<string>();
            foreach (var item in e.NewItems)
            {
                FilterDescriptor filterDescriptor = item as FilterDescriptor;
                string  set = filterDescriptor.Expression;
                filterCurrent.Add(set);
            }
            ChangeFilterEvents(filterCurrent);
        }
        private void DataGrid_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            GridRowElement row = e.RowElement;
            if (RowsMark)
            {
                if (e.RowElement.IsSelected)
                {
                    e.RowElement.BackColor = DefaultColors.DefaultSelectedColor;
                }
                else
                {
                    GridViewCellInfoCollection infoCollection = row.RowInfo.Cells;
                    var valueInfo = infoCollection[_dataGridDefinition.ColMarkName];
                    if (Convert.ToBoolean(valueInfo) == false)
                    {
                        e.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                        e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
                        e.RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                    }
                }
            }
        }

        public void GenerateGrid()
        {

            foreach (var col in _dataGridColumns.Ordered())
            {
                _dataGridDefinition.Columns.AddColumns(col);

            }
            foreach (var table in _dataGridTables.Ordered())
            {
                _dataGridDefinition.QueryTables.AddDataGridTable(table);
            }
            foreach (var col in _dataGridOrderedColumns.Ordered())
            {
                _dataGridDefinition.Ordenes.AddColumns(col);
            }
            foreach (var col in _dataGridRules.Order())
            {
                _dataGridDefinition.Clausulas.Add(col);
            }
            if ((_dataGridColumnGroups != null))
            {
                foreach (var column in _dataGridColumnGroups.ColumnGroups)
                {
                    _dataGridDefinition.GruposColumnas.AddColumns(column);

                }
            }
        }

        private void DataGrid_PageChanging(object sender, PageChangingEventArgs e)
        {

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
        public void SetDynamicBinding(ref DataTable dta, IList<ValidationRule> rules)
        {
            Binding oBind = new Binding("SourceView");
            oBind.Source = dta;
            oBind.Mode = BindingMode.TwoWay;
            oBind.ValidatesOnDataErrors = true;
            oBind.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            SetBinding(SourceViewProperty, oBind);
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


        public void BeginEdit()
        {
            _currentView.BeginEdit();
        }
        public void EndEdit()
        {
            _currentView.EndEdit();
        }
    }
}
