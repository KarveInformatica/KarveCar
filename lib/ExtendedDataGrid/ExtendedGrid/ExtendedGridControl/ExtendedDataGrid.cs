using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;
using ExtendedGrid.Base;
using ExtendedGrid.Classes;
using ExtendedGrid.Interface;
using Expression = System.Linq.Expressions.Expression;
using Path = System.Windows.Shapes.Path;

namespace ExtendedGrid.ExtendedGridControl
{
    public sealed class ExtendedDataGrid : CopyDg, INotifyPropertyChanged
    {
        #region Members

        private static readonly Uri DataGridUri = new Uri("/ExtendedGrid;component/Styles/DataGrid.Generic.xaml",
                                                          UriKind.Relative);

        private readonly ResourceDictionary _dataGridUriStyle = new ResourceDictionary {Source = DataGridUri};

        private static readonly Uri DefaultThemeUri = new Uri("/ExtendedGrid;component/DataGridThemes/Default.xaml",
                                                              UriKind.Relative);

        private const string GenericThemeUri = "/ExtendedGrid;component/DataGridThemes/{0}.xaml";
        private readonly ResourceDictionary _defaultGridTheme = new ResourceDictionary {Source = DefaultThemeUri};
        private DataTable _rowSummariesTable = new DataTable();
        private ObservableCollection<GroupByData> _groupByCollection = new ObservableCollection<GroupByData>();
        
        public const int Sum = 0;
        public const int Average = 1;
        public const int Count = 2;
        public const int Min = 3;
        public const int Max = 4;
        public const int Smallest = 5;
        public const int Largest = 6;
        private ResourceDictionary _lastTheme;
        internal List<DataGridColumn> ColumnsInGroupBy = new List<DataGridColumn>();

        public enum Themes
        {
            Default,
            Office2007Silver,
            Office2007Black,
            Office2007Blue,
            Windows7,
            OrangeDarkExplorer,
            System,
            ElectronicMedia
        }

        private bool _inWidthChange;
        private bool _updatingColumnInfo;

        public static readonly DependencyProperty ColumnInfoProperty = DependencyProperty.Register("ColumnInfo",
                                                                                                   typeof (
                                                                                                       ObservableCollection
                                                                                                       <
                                                                                                       ColumnInformation
                                                                                                       >),
                                                                                                   typeof (
                                                                                                       ExtendedDataGrid),
                                                                                                   new FrameworkPropertyMetadata
                                                                                                       (null,
                                                                                                        FrameworkPropertyMetadataOptions
                                                                                                            .
                                                                                                            BindsTwoWayByDefault,
                                                                                                        ColumnInfoChangedCallback)
            );

        private int? _lastFrozenRowCount;

        private readonly List<string> _computaions = new List<string>
                                                         {
                                                             "Sum",
                                                             "Average",
                                                             "Count",
                                                             "Min",
                                                             "Max",
                                                             "Smallest",
                                                             "Largest"
                                                         };

        private readonly List<string> _summableComputaions = new List<string> {"Sum", "Average", "Count", "Min", "Max"};
        private readonly List<string> _nonSummableComputaions = new List<string> {"Smallest", "Largest", "Count"};
        private DataRow _draggedItem;
        /// <summary>
        /// Format of count on row summary 
        /// </summary>
        public string RowSummaryCountFormat { get; set; }
        /// <summary>
        /// Format of sum on row summary 
        /// </summary>
        public string RowSummarySumFormat { get; set; }
        /// <summary>
        /// Format of average on row summary 
        /// </summary>
        public string RowSummaryAverageFormat { get; set; }
        /// <summary>
        /// Format of minimum on row summary 
        /// </summary>
        public string RowSummaryMinFormat { get; set; }
        /// <summary>
        /// Format of maximum on row summary 
        /// </summary>
        public string RowSummaryMaxFormat { get; set; }
        /// <summary>
        /// Format of smallest on row summary 
        /// </summary>
        public string RowSummarySmallestFormat { get; set; }
        /// <summary>
        /// Format of largest on row summary 
        /// </summary>
        public string RowSummaryLargestFormat { get; set; }
        /// <summary>
        /// If set to true will remove 3 state sorting
        /// And it will revert to normal two state sorting
        /// If set to true it will perform 3 state sorting
        /// </summary>
        public bool OnlyTwoWaySorting { get; set; }

        #endregion

        #region Constructors

        public ExtendedDataGrid()
        {
            AddResources();
            AutoFilterHelper = new AutoFilterHelper(this);
            (Items.SortDescriptions as INotifyCollectionChanged).CollectionChanged += SortDescriptionsCollectionChanged;
            Sorting += DataGridStandardSorting;
            Loaded += ExtendedDataGridLoaded;
            LoadingRow += ExtendedDataGridLoadingRow;
            Columns.CollectionChanged += ColumnsCollectionChanged;
            GroupByCollection.CollectionChanged += GroupByCollectionCollectionChanged;
            GroupByColumnAdded += ExtendedDataGridGroupByColumnAdded;
            GroupByColumnRemoved += ExtendedDataGridGroupByColumnRemoved;
            PreviewKeyDown += ExtendedDataGridPreviewKeyDown;
            RowHeaderChanged += ExtendedDataGridRowHeaderChanged;
            FrozenColumnCountChanged += ExtendedDataGridFrozenColumnCountChanged;
            MouseDown += ExtendedDataGridMouseDown;
            for (int i = 0; i < 8; i++)
            {
                var row = RowSummariesTable.NewRow();
                RowSummariesTable.Rows.Add(row);
            }
            NotifyPropertyChanged("RowSummariesTable");
            //Group Style Start
            var groupStyle = FindResource("CustomGroupStyle");
            GroupStyle.Add((GroupStyle) groupStyle);
            //Group Style End
        }

        #endregion

        #region Events
        /// <summary>
        /// Event is fired when the Row header is changed
        /// </summary>
        public event EventHandler RowHeaderChanged;
        /// <summary>
        /// Frozen column count changed event
        /// </summary>
        public event EventHandler FrozenColumnCountChanged;
        /// <summary>
        /// Event is fired when any any column is added in group by
        /// </summary>
        public event EventHandler GroupByColumnAdded;
        /// <summary>
        /// Event is fired when any column is removed from group by
        /// </summary>
        public event EventHandler GroupByColumnRemoved;
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Override

        protected override void OnColumnReordered(DataGridColumnEventArgs e)
        {
            UpdateColumnInfo();
            base.OnColumnReordered(e);
            if (RowSummariesGrid != null)
            {
                //If columns are reordred its important to resorder row summaries if it exisi.
                var rowSummariesColumn =
                    RowSummariesGrid.Columns.FirstOrDefault(column => column.SortMemberPath == e.Column.SortMemberPath);
                if (rowSummariesColumn != null)
                {
                    rowSummariesColumn.DisplayIndex = e.Column.DisplayIndex;
                }
            }
        }

        protected override void OnInitialized(EventArgs e)
        {
            EventHandler sortDirectionChangedHandler = (sender, x) => UpdateColumnInfo();
            EventHandler widthPropertyChangedHandler = (sender, x) => _inWidthChange = true;
            var sortDirectionPropertyDescriptor =
                DependencyPropertyDescriptor.FromProperty(DataGridColumn.SortDirectionProperty, typeof (DataGridColumn));
            var widthPropertyDescriptor = DependencyPropertyDescriptor.FromProperty(DataGridColumn.WidthProperty,
                                                                                    typeof (DataGridColumn));

            Loaded += (sender, x) =>
                          {
                              foreach (var column in Columns)
                              {
                                  sortDirectionPropertyDescriptor.AddValueChanged(column, sortDirectionChangedHandler);
                                  widthPropertyDescriptor.AddValueChanged(column, widthPropertyChangedHandler);
                              }
                          };
            Unloaded += (sender, x) =>
                            {
                                foreach (var column in Columns)
                                {
                                    sortDirectionPropertyDescriptor.RemoveValueChanged(column,
                                                                                       sortDirectionChangedHandler);
                                    widthPropertyDescriptor.RemoveValueChanged(column, widthPropertyChangedHandler);
                                }
                            };

            base.OnInitialized(e);
        }

        protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
            base.OnItemsSourceChanged(oldValue, newValue);
            CommitEdit();
            CommitEdit();

            foreach (var column in Columns)
            {
                var extendedColumn = column as IExtendedColumn;
                if (extendedColumn != null)
                {
                    GetSummaryValue(extendedColumn);
                }
            }
            var cvs = CollectionViewSource.GetDefaultView(ItemsSource);
            if (cvs != null)
                cvs.GroupDescriptions.CollectionChanged +=
                    GroupDescriptionsCollectionChanged;

            var scrollViewer = FindControls.FindChild<ScrollViewer>(this, "DG_ScrollViewer");
            if (scrollViewer != null)
            {
                scrollViewer.ScrollToLeftEnd();
            }
            InvalidateArrange();
        }

        protected override void OnExecutedCommitEdit(ExecutedRoutedEventArgs e)
        {
            base.OnExecutedCommitEdit(e);
            if (e.OriginalSource == null) return;
            var extendedColumn = ((DataGridCell) e.OriginalSource).Column as IExtendedColumn;
            if (extendedColumn != null)
                GetSummaryValue(extendedColumn);
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            switch (e.Property.Name)
            {
                case "RowHeaderWidth":
                    if (RowHeaderChanged != null)
                        RowHeaderChanged(this, new EventArgs());
                    break;
                case "FrozenColumnCount":
                    if (FrozenColumnCountChanged != null)
                        FrozenColumnCountChanged(this, new EventArgs());
                    break;
            }
        }

        #endregion

        #region Methods
        /// <summary>
        /// THis helps to recompute the row summaries if the data is committed to the data grid
        /// </summary>
        public void FireNotifyForRowSummaries()
        {
            NotifyPropertyChanged("RowSummariesTable");
        }
        
        private void ExtendedDataGridMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Right)
            {
                if (Columns.Count(c => c.Visibility == Visibility.Visible) == 0)
                {
                    var cm = _dataGridUriStyle["DataGridHeaderColumnChooser"] as ContextMenu;
                    if (cm != null)
                    {
                        cm.Tag = this;
                        cm.IsOpen = true;
                    }
                }
            }
        }

        private void ExtendedDataGridFrozenColumnCountChanged(object sender, EventArgs e)
        {
            if (RowSummariesGrid != null)
            {
                RowSummariesGrid.FrozenColumnCount = FrozenColumnCount;
            }
        }

        private void ExtendedDataGridRowHeaderChanged(object sender, EventArgs e)
        {
            ArrangeColumnSplitter();
        }

        private void ArrangeColumnSplitter()
        {
            var grid = this;
            if ((!grid.ShowColumnSplitter || grid.FrozenColumnCount == 0))
                return;
            double tillNowWidth = 0;
            if (GridSplitterGrid == null)
                return;
            var listOfColumn = Columns.ToList().OrderBy(c => c.DisplayIndex);
            foreach (var column in listOfColumn)
            {
                if (column.Visibility == Visibility.Visible && column.DisplayIndex < FrozenColumnCount)
                {
                    tillNowWidth = tillNowWidth + column.ActualWidth - 0.5;
                }
            }
            GridSplitterGrid.ColumnDefinitions[0].Width = new GridLength(tillNowWidth + GetGridHeaderActualWidth(this));
        }

        private double GetGridHeaderActualWidth(DataGrid grid)
        {
            if (grid.HeadersVisibility == DataGridHeadersVisibility.None ||
                grid.HeadersVisibility == DataGridHeadersVisibility.Column)
                return 0;
            return grid.RowHeaderWidth;
        }

        private void GroupDescriptionsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var gc in e.NewItems)
                {
                    var columnName = ((PropertyGroupDescription) gc).PropertyName;
                    var count = GroupByCollection.Count(g => g.SortMemberPath == columnName);
                    if (count == 0)
                    {
                        var column = Columns.FirstOrDefault(c => c.SortMemberPath == columnName);
                        if (column != null)
                        {
                            AddGroupByColumn(column, false);
                            if (ColumnsInGroupBy.Count(g => g.SortMemberPath == columnName) == 0)
                            {
                                ColumnsInGroupBy.Add(column);
                            }
                        }
                    }
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var gc in e.OldItems)
                {
                    var columnName = ((PropertyGroupDescription) gc).PropertyName;
                    var count = GroupByCollection.Count(g => g.SortMemberPath == columnName);
                    if (count > 0)
                    {
                        var group = GroupByCollection.First(g => g.SortMemberPath == columnName);
                        GroupByCollection.Remove(group);
                        var column = ColumnsInGroupBy.First(c => c.SortMemberPath == columnName);
                        ColumnsInGroupBy.Remove(column);
                        var cvs = CollectionViewSource.GetDefaultView(ItemsSource);
                        if (cvs != null)
                            cvs.Refresh();

                    }
                }
            }
            NotifyPropertyChanged("GroupByCollection");
        }

        private void ExtendedDataGridPreviewKeyDown(object sender, KeyEventArgs e)
        {

            if (!AllowUserToCopy)
            {
                if (e.Key == Key.C)
                {
                    if (Keyboard.IsKeyDown(Key.LeftCtrl) || (Keyboard.IsKeyDown(Key.RightCtrl)))
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void ExtendedDataGridGroupByColumnRemoved(object sender, EventArgs e)
        {
            var args = (GroupByEventArgs) e;
            var columnName = args.Column.SortMemberPath;
            var count = GroupByCollection.Count(gc => gc.SortMemberPath == columnName);
            if (count <= 0) return;
            var itemToBeRemoved = GroupByCollection.First(gc => gc.SortMemberPath == columnName);
            GroupByCollection.Remove(itemToBeRemoved);
            var itemToBeRemoved1 = ColumnsInGroupBy.First(gc => gc.SortMemberPath == columnName);
            var index = ColumnsInGroupBy.IndexOf(itemToBeRemoved1);
            var lastCount = ColumnsInGroupBy.Count;
            ColumnsInGroupBy.Remove(itemToBeRemoved1);
            if (ColumnsInGroupBy.Count == 0)
            {
                if (_lastFrozenRowCount != null && _lastFrozenRowCount != 0)
                    FrozenRowCount = _lastFrozenRowCount;
            }

            var cvs = CollectionViewSource.GetDefaultView(ItemsSource);
            var propertyGroupDescription =
                cvs.GroupDescriptions.Where(gd => ((PropertyGroupDescription) (gd)).PropertyName == columnName).Cast
                    <PropertyGroupDescription>().FirstOrDefault();

            if (propertyGroupDescription == null) return;
            cvs.GroupDescriptions.Remove(propertyGroupDescription);
            cvs.Refresh();
            if (index != lastCount - 1)
                ArrangeGroupBy();
        }

        internal void ArrangeGroupBy()
        {

            var listOfDataGridColumn = (from item in GroupByCollection
                                        let count = Columns.Count(c => c.SortMemberPath == item.SortMemberPath)
                                        where count > 0
                                        select Columns[GetColumnIndex(Columns, item.SortMemberPath)]).ToList();
            GroupByCollection.Clear();

            foreach (var column in listOfDataGridColumn)
            {
                AddGroupByColumn(column, false);
                NotifyPropertyChanged("GroupByCollection");
            }
        }

        private void AddGroupByColumn(DataGridColumn column, bool shouldAdd)
        {
            // If there is no drop target for a dragged column, don't allow grouping
            if (GroupByControlVisibility == Visibility.Collapsed)
            {
                return;
            }
            IsGroupByOn = true;
            var columnName = column.Header;
            var count = GroupByCollection.Count(gc => Equals(gc.SortMemberPath, columnName));
            if (count == 0)
            {
                var newItem = new GroupByData
                                  {
                                      ColumnName = (string) columnName,
                                      Index = GroupByCollection.Count,
                                      SortDirection = Convert.ToString(column.SortDirection),
                                      SortMemberPath = column.SortMemberPath
                                  };

                var border = FindControls.FindChild<Border>(this, "");
                var headerPanel = FindControls.FindChild<DockPanel>(border, "headerPanel");
                var groupByContentControl = FindControls.FindChild<ContentControl>(headerPanel, "groupByContentControl");
                var group = FindControls.FindChild<ItemsControl>(groupByContentControl, "group");
                if (group != null) group.UpdateLayout();
                if (GroupByCollection.Count > 0 && group != null)
                {
                    newItem.GridWidth =
                        ((ContentPresenter)
                         (@group.ItemContainerGenerator.ContainerFromIndex(GroupByCollection.Count - 1))).ActualWidth +
                        10;
                    newItem.GridSecondColumnWidth = (newItem.GridWidth -
                                                     GroupByCollection[GroupByCollection.Count - 1].GridWidth)/2;
                }

                if (GroupByCollection.Count == 0)
                {

                    if (FrozenRowCount != null && FrozenRowCount != 0)
                    {
                        _lastFrozenRowCount = FrozenRowCount;
                        FrozenRowCount = 0;
                    }

                }
                GroupByCollection.Add(newItem);

                if (!shouldAdd) return;

                try
                {
                    var cvs = CollectionViewSource.GetDefaultView(ItemsSource);
                    cvs.GroupDescriptions.Add(new PropertyGroupDescription(column.SortMemberPath));

                    cvs.Refresh();
                }
                catch (Exception)
                {
                    GroupByCollection.Remove(newItem);
                    MessageBox.Show("Cannot group by when row is being edited.", "Error", MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                }
            }
        }

        public void RaiseGroupByColumnRemoved(DataGridColumn column)
        {
            GroupByColumnRemoved(this, new GroupByEventArgs {Column = column});
        }

        private void AddTheme(Themes value)
        {
            if (!UriParser.IsKnownScheme("pack"))
                UriParser.Register(new GenericUriParser(GenericUriParserOptions.GenericAuthority), "pack", -1);

            //Remove last loaded themes

            if (Resources.MergedDictionaries.Contains(_lastTheme))
                Resources.MergedDictionaries.Remove(_lastTheme);

            //Add new Theme
            var newTheme = new ResourceDictionary { Source = new Uri(String.Format(GenericThemeUri, value.ToString()), UriKind.Relative) };
            if (!Resources.MergedDictionaries.Contains(newTheme))
            {
                Resources.MergedDictionaries.Add(newTheme);
                _lastTheme = newTheme;
            }

        }
        private void GroupByCollectionCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var border = FindControls.FindChild<Border>(this, "");
            var headerPanel = FindControls.FindChild<DockPanel>(border, "headerPanel");
            var groupByContentControl = FindControls.FindChild<ContentControl>(headerPanel, "groupByContentControl");
            var txtDragName = FindControls.FindChild<TextBlock>(groupByContentControl, "txtDragName");
            var clearButton = FindControls.FindChild<Button>(groupByContentControl, "btnClearGroup");
            if (txtDragName != null)
                txtDragName.Visibility = GroupByCollection.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
            if (clearButton != null)
                clearButton.Visibility = GroupByCollection.Count != 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        private void ExtendedDataGridGroupByColumnAdded(object sender, EventArgs e)
        {
            var args = e as GroupByEventArgs;
            if (args != null)
                AddGroupByColumn(args.Column, true);
        }

        public void UpdateRowSummaries()
        {
            foreach (var column in Columns)
            {
                GetSummaryValue((IExtendedColumn) column);
            }
        }

        private void GetSummaryValue(IExtendedColumn column)
        {

            if (!ShowRowSummaries) return;
            if (Columns.Count == 0) return;
            var dataView = ItemsSource as DataView;
            if (dataView != null)
            {
                if (((DataView) ItemsSource).Count == 0) return;
                var type =
                    ((DataView) ItemsSource).Table.Columns[((DataGridColumn) column).SortMemberPath].DataType;
                var isSummable = IsSummable(type);
                var columnName = ((DataGridColumn) column).SortMemberPath;
                if (isSummable)
                {
                    foreach (var computation in _summableComputaions)
                    {
                        if (
                            (!String.IsNullOrEmpty(
                                Convert.ToString(
                                    RowSummariesTable.Rows[_computaions.IndexOf(computation)][
                                        ((DataGridColumn) column).SortMemberPath])) ||
                             (column.SummaryColumnSettings != null &&
                              column.SummaryColumnSettings.SummaryOperands.Count(so => so.Operation == computation) > 0)))
                            RowSummariesTable.Rows[_computaions.IndexOf(computation)][
                                columnName] =
                                GetRowSummariesValue(computation,
                                                     columnName);
                    }
                }
                else
                {
                    foreach (var computation in _nonSummableComputaions)
                        if (
                            column != null && (!String.IsNullOrEmpty(
                                Convert.ToString(
                                    RowSummariesTable.Rows[_computaions.IndexOf(computation)][
                                        columnName])) ||
                                               (column.SummaryColumnSettings != null &&
                                                column.SummaryColumnSettings.SummaryOperands.Count(
                                                    so => so.Operation == computation) > 0)))
                            RowSummariesTable.Rows[_computaions.IndexOf(computation)][
                                columnName] =
                                GetRowSummariesValue(computation,
                                                     columnName);
                }
            }
        }

        private bool IsSummable(Type type)
        {
            try
            {
                ParameterExpression paramA = Expression.Parameter(type, "a");
                ParameterExpression paramB = Expression.Parameter(type, "b");
                BinaryExpression addExpression = Expression.Add(paramA, paramB);
                var add = Expression.Lambda(addExpression, paramA, paramB).Compile();
                var v = Activator.CreateInstance(type);
                add.DynamicInvoke(v, v);
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal void DefaultViewListChanged(object sender, ListChangedEventArgs e)
        {
            LoadRowSummaries();
        }

        internal void LoadRowSummaries()
        {
            NotifyPropertyChanged("RowSummariesTable");
        }

        private object GetRowSummariesValue(string computation, string columnName)
        {

            object value = "";
            var dataView = ItemsSource as DataView;
            if (dataView != null)
            {
                var itemSourceDataTable = dataView.Table;
                var currentColumnName = columnName;
                object actualValue;
                switch (computation)
                {
                    case "Count":

                        value = itemSourceDataTable.Rows.Count;
                        break;
                    case "Sum":
                        actualValue = itemSourceDataTable.Compute("Sum(" + currentColumnName + ")", "");
                        if (actualValue != DBNull.Value)
                            value = Convert.ToDouble(itemSourceDataTable.Compute("Sum(" + currentColumnName + ")", ""));

                        break;
                    case "Average":
                        actualValue = itemSourceDataTable.Compute("Avg(" + currentColumnName + ")", "");
                        if (actualValue != DBNull.Value)
                            value = Convert.ToDouble(itemSourceDataTable.Compute("Avg(" + currentColumnName + ")", ""));
                        break;
                    case "Min":
                        actualValue = itemSourceDataTable.Compute("Min(" + currentColumnName + ")", "");
                        if (actualValue != DBNull.Value)
                            value = Convert.ToDouble(itemSourceDataTable.Compute("Min(" + currentColumnName + ")", ""));
                        break;
                    case "Max":
                        actualValue = itemSourceDataTable.Compute("Max(" + currentColumnName + ")", "");
                        if (actualValue != DBNull.Value)
                            value = Convert.ToDouble(itemSourceDataTable.Compute("Max(" + currentColumnName + ")", ""));
                        break;
                    case "Smallest":
                        var lengthOfCells =
                            (from DataRow row in itemSourceDataTable.Rows
                             select Convert.ToString(row[currentColumnName]).Length).ToList();
                        var minValue = "";
                        foreach (
                            var row in
                                itemSourceDataTable.Rows.Cast<DataRow>().Where(
                                    row => Convert.ToString(row[currentColumnName]).Length == lengthOfCells.Min()))
                        {
                            minValue = Convert.ToString(row[currentColumnName]);

                            break;
                        }

                        if (lengthOfCells.Count > 0)
                        {

                            value = minValue;
                        }

                        break;
                    case "Largest":

                        var lengthOfCells1 =
                            (from DataRow row in itemSourceDataTable.Rows
                             select Convert.ToString(row[currentColumnName]).Length).ToList();
                        var maxValue = "";
                        foreach (
                            var row in
                                itemSourceDataTable.Rows.Cast<DataRow>().Where(
                                    row => Convert.ToString(row[currentColumnName]).Length == lengthOfCells1.Max()))
                        {
                            maxValue = Convert.ToString(row[currentColumnName]);
                            break;
                        }

                        if (lengthOfCells1.Count > 0)
                        {

                            value = maxValue;
                        }

                        break;

                    default:
                        return "";
                }
            }
            if (String.IsNullOrEmpty(Convert.ToString(value)))
                value = " ";
            return value;
        }

        internal DataGridColumn GetRowSummariesGridColumnForSortMemberPath(string sortMemberPath)
        {
            if (RowSummariesGrid != null)
                return RowSummariesGrid.Columns.FirstOrDefault(column => column.SortMemberPath == sortMemberPath);
            return null;
        }

        private void ColumnsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems == null)
                return;
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var column in e.NewItems)
                    {
                        if (!RowSummariesTable.Columns.Contains(((DataGridColumn) column).SortMemberPath))
                        {
                            RowSummariesTable.Columns.Add(((DataGridColumn) column).SortMemberPath);
                            if (RowSummariesGrid != null)
                            {
                                var oldColumn =
                                    GetRowSummariesGridColumnForSortMemberPath(((DataGridColumn) column).SortMemberPath);
                                if (oldColumn == null)
                                    RowSummariesGrid.Columns.Add(new DataGridTextColumn
                                                                     {
                                                                         SortMemberPath =
                                                                             ((DataGridColumn) column).SortMemberPath,
                                                                         DisplayIndex =
                                                                             ((DataGridColumn) column).DisplayIndex,
                                                                         Visibility =
                                                                             ((DataGridColumn) column).Visibility,
                                                                         Width = ((DataGridColumn) column).Width
                                                                     });

                            }
                        }
                        var actualColumn =
                            column as IExtendedColumn;
                        if (actualColumn != null)
                            GetSummaryValue(actualColumn);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var column in e.NewItems)
                    {
                        if (RowSummariesTable.Columns.Contains(((DataGridColumn) column).SortMemberPath))
                        {
                            RowSummariesTable.Columns.Remove(((DataGridColumn) column).SortMemberPath);
                            if (RowSummariesGrid != null)
                            {
                                var rowSummariesColumn =
                                    GetRowSummariesGridColumnForSortMemberPath(((DataGridColumn) column).SortMemberPath);
                                if (rowSummariesColumn != null)
                                {
                                    var oldColumn =
                                        GetRowSummariesGridColumnForSortMemberPath(
                                            ((DataGridColumn) column).SortMemberPath);
                                    if (oldColumn != null)
                                        RowSummariesGrid.Columns.Remove(rowSummariesColumn);
                                }
                            }
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    {
                        var newColumns = e.NewItems;
                        foreach (var column in e.OldItems)
                        {
                            if (RowSummariesTable.Columns.Contains(((DataGridColumn) column).SortMemberPath))
                            {
                                var oldColumn = RowSummariesTable.Columns[((DataGridColumn) column).SortMemberPath];
                                if (oldColumn != null)
                                {
                                    oldColumn.ColumnName =
                                        (string) ((DataGridColumn) newColumns[e.OldItems.IndexOf(column)]).Header;
                                }
                            }
                        }
                    }
                    break;
            }
            NotifyPropertyChanged("RowSummariesTable");
            LoadRowSummaries();
        }

        private void ExtendedDataGridLoadingRow(object sender, DataGridRowEventArgs e)
        {

            if (IsGroupByOn)
                return;
            if (IsVerticalScrolling)
                return;
            if (ShowRowNumber)
            {
                var formattedText = new FormattedText((e.Row.GetIndex() + 1).ToString(CultureInfo.InvariantCulture),
                                                      CultureInfo.GetCultureInfo("en-us"),
                                                      FlowDirection.LeftToRight,
                                                      new Typeface("Arial"), FontSize = 9, Brushes.Black);
                double textWidth = formattedText.Width*72/96;
                if (textWidth > RowHeaderActualWidth && textWidth > 17)
                {
                    RowHeaderWidth = textWidth + 2;
                }
            }
            else
            {
                e.Row.Header = " ";
                if (Double.IsNaN(RowHeaderWidth))
                    RowHeaderWidth = 17;
            }
            NotifyPropertyChanged("RowSummariesTable");
        }

        private void ExtendedDataGridLoaded(object sender, RoutedEventArgs e)
        {
            var scrollViewer = FindControls.FindChild<ScrollViewer>(this, "DG_ScrollViewer");
            if (scrollViewer != null)
            {
                ScrollingPreviewService.OnVerticalScrollingPreviewTemplateChanged(scrollViewer,
                                                                                  ScrollToolTipDataTemplate);
            }
            NotifyPropertyChanged("RowSummariesTable");
            LoadRowSummaries();
            GroupByHeaderText = GroupByHeaderText;
            if (ShowRowNumber)
                DataGridBehavior.SetRowNumber(this, true);
            var grpContentCtrl = GetGroupByContentControl();
            if (grpContentCtrl != null)
            {
                grpContentCtrl.SizeChanged += GrpContentCtrlSizeChanged;
            }
        }

        private void GrpContentCtrlSizeChanged(object sender, SizeChangedEventArgs e)
        {
            IsGroupByOn = false;
        }

        private ContentControl GetGroupByContentControl()
        {
            try
            {
                var border = FindControls.FindChild<Border>(this, "");
                var headerPanel = FindControls.FindChild<DockPanel>(border, "headerPanel");
                var groupByContentControl = FindControls.FindChild<ContentControl>(headerPanel, "groupByContentControl");
                return groupByContentControl;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private void AddResources()
        {
            if (!UriParser.IsKnownScheme("pack"))
                UriParser.Register(new GenericUriParser(GenericUriParserOptions.GenericAuthority), "pack", -1);
            //Data grid
            if (!Resources.MergedDictionaries.Contains(_dataGridUriStyle))
                Resources.MergedDictionaries.Add(_dataGridUriStyle);
            //Themes Default
            if (!Resources.MergedDictionaries.Contains(_defaultGridTheme))
                Resources.MergedDictionaries.Add(_defaultGridTheme);
            _lastTheme = _defaultGridTheme;
        }
        /// <summary>
        /// Clears the filter was specified column
        /// </summary>
        /// <param name="columnName"></param>
        public void ClearFilter(string columnName)
        {
            AutoFilterHelper.RemoveAllFilter(this, columnName);
            DataGridColumnHeader header =
                FindControls.GetColumnHeaderFromColumn(Columns[GetColumnIndex(Columns, columnName)], this);
            if (header != null)
            {
                var popUp = FindControls.FindChild<Popup>(header, "popupDrag");
                if (popUp != null)
                {
                    popUp.Tag = "False";
                }
            }
        }

        private static int GetColumnIndex(IEnumerable<DataGridColumn> columns, string filedName)
        {
            int index = 0;
            foreach (DataGridColumn col in columns)
            {
                if (col.SortMemberPath == filedName)
                {
                    return index;
                }
                index++;
            }
            return index;
        }
        /// <summary>
        /// Export to excel
        /// </summary>
        /// <param name="workSheetName">Name you want in first sheet</param>
        /// <param name="fullFilePath">Path where you need to save the excel file</param>
        /// <param name="toOpen">Show open or not after creation</param>
        public void ExportToExcel(string workSheetName, string fullFilePath, bool toOpen)
        {
            try
            {
                //Select all rows 
                Focus();
                SelectAll();
                //Copy the entire grid
                ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, this);
                Clipboard.GetText();
                ExportToExcelService.CreateExcelFromClipboard(workSheetName, fullFilePath, toOpen);
                UnselectAll();
            }
            catch (Exception)
            {
                UnselectAll();
                throw;
            }

        }
        /// <summary>
        /// Export to PDF
        /// </summary>
        /// <param name="fullFilePath">Path where you need to save the pdf file</param>
        /// <param name="toOpen">Show open or not after creation</param>
        public void ExportToPdf(string fullFilePath, bool toOpen)
        {
            try
            {
                //Select all rows 
                Focus();
                SelectAll();
                //Copy the entire grid
                ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, this);
                Clipboard.GetText();
                ExportToExcelService.CreatePdfFromClipboard("PDF", fullFilePath, toOpen);
                UnselectAll();
            }
            catch (Exception)
            {
                UnselectAll();
                throw;
            }
        }
        /// <summary>
        /// Export to PDF
        /// </summary>
        /// <param name="fullFilePath">Path where you need to save the pdf file</param>
        /// <param name="tableStyle">It is excel style you want to export</param>
        /// <param name="toOpen">Show open or not after creation</param>
        public void ExportToPdf(string fullFilePath, ExcelTableStyle tableStyle, bool toOpen)
        {
            try
            {
                //Select all rows 
                Focus();
                SelectAll();
                //Copy the entire grid
                ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, this);
                Clipboard.GetText();
                ExportToExcelService.CreatePdfFromClipboard("PDF", fullFilePath, tableStyle, toOpen);
                UnselectAll();
            }
            catch (Exception)
            {
                UnselectAll();
                throw;
            }
        }
        /// <summary>
        /// Export to Csv
        /// </summary>
        /// <param name="workSheetName">Name of the first sheet</param>
        /// <param name="fullFilePath">Path where csv file is supposed to be saved</param>
        /// <param name="toOpen">To open or not after creation of csv file</param>
        public void ExportToCsv(string workSheetName, string fullFilePath, bool toOpen)
        {
            try
            {
                //Select all rows 
                Focus();
                SelectAll();
                //Copy the entire grid
                ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, this);
                Clipboard.GetText();
                ExportToExcelService.CreateCsvFromClipboard(workSheetName, fullFilePath, toOpen);
                UnselectAll();
            }
            catch (Exception)
            {
                UnselectAll();
                throw;
            }
        }
        /// <summary>
        /// Export to excel
        /// </summary>
        /// <param name="workSheetName">Sheet of the first sheet</param>
        /// <param name="fullFilePath">Path where is it is supposed to be saved</param>
        /// <param name="tableStyle">Style of excel you want to create</param>
        /// <param name="toOpen">To open or not after creation</param>
        public void ExportToExcel(string workSheetName, string fullFilePath, ExcelTableStyle tableStyle, bool toOpen)
        {
            try
            {
                //Select all rows 
                Focus();
                SelectAll();
                //Copy the entire grid
                ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, this);
                Clipboard.GetText();
                ExportToExcelService.CreateExcelFromClipboard(workSheetName, fullFilePath, tableStyle, toOpen);
                UnselectAll();
            }
            catch (Exception)
            {
                UnselectAll();
                throw;
            }
        }

        internal void RaiseGroupByColumnAdded(DataGridColumn column)
        {
            if (GroupByColumnAdded != null)
                GroupByColumnAdded(this, new GroupByEventArgs {Column = column});
        }

        private static void ColumnInfoChangedCallback(DependencyObject dependencyObject,
                                                      DependencyPropertyChangedEventArgs e)
        {
            var grid = (ExtendedDataGrid) dependencyObject;
            if (!grid._updatingColumnInfo)
            {
                grid.ColumnInfoChanged();
            }
        }

        private void SortDescriptionsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // clear all the headers of sort order
            foreach (DataGridColumn column in Columns)
            {
                string sortPath = SortHelpers.GetSortMemberPath(column);
                if (sortPath != null)
                {
                    var sortOrder1 = new Path();
                    DataGridColumnHeader header = FindControls.GetColumnHeaderFromColumn(column, this);
                    if (header != null)
                    {
                        var popUp = FindControls.FindChild<Popup>(header, "popupDrag");
                        if (popUp != null)
                        {
                            sortOrder1 = FindControls.FindChild<Path>(header, "SortArrow");
                        }
                        if (sortOrder1 != null)
                        {
                            sortOrder1.Tag = null;
                        }
                    }
                }
            }

            // add sort order 
            int sortIndex = 0;
            foreach (SortDescription sortDesc in Items.SortDescriptions)
            {
                sortIndex++;
                var sortOrder = new Path();
                var txtSortOrder = new TextBlock();

                DataGridColumnHeader header =
                    FindControls.GetColumnHeaderFromColumn(Columns[GetColumnIndex(Columns, sortDesc.PropertyName)], this);
                if (header != null)
                {
                    var popUp = FindControls.FindChild<Popup>(header, "popupDrag");
                    if (popUp != null)
                    {
                        sortOrder = FindControls.FindChild<Path>(header, "SortArrow");
                        txtSortOrder = FindControls.FindChild<TextBlock>(header, "txtSortOrder");
                    }
                }
                if (sortDesc.PropertyName ==
                    SortHelpers.GetSortMemberPath(Columns[GetColumnIndex(Columns, sortDesc.PropertyName)]))
                {


                    if (Items.SortDescriptions.Count > 1 && ShowSortOrder)
                    {

                        if (sortOrder != null)
                        {
                            sortOrder.Tag = "True";
                            if (txtSortOrder != null)
                            {
                                txtSortOrder.Text = sortIndex.ToString(CultureInfo.InvariantCulture);
                            }
                        }
                    }
                }
                else
                {
                    sortOrder.Tag = null;
                }
            }

            NotifyPropertyChanged("RowSummariesTable");
        }

        private void UpdateColumnInfo()
        {
            _updatingColumnInfo = true;
            ColumnInfo = new ObservableCollection<ColumnInformation>(Columns.Select(x => new ColumnInformation(x)));
            _updatingColumnInfo = false;
        }

        protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            if (_inWidthChange)
            {
                _inWidthChange = false;
                UpdateColumnInfo();
            }
            base.OnPreviewMouseLeftButtonUp(e);
        }

        private void ColumnInfoChanged()
        {
            Items.SortDescriptions.Clear();
            foreach (var column in ColumnInfo)
            {
                var realColumn = Columns.FirstOrDefault(x => column.SortMemberPath.Equals(x.SortMemberPath));
                if (realColumn == null)
                {
                    continue;
                }
                column.Apply(realColumn, Columns.Count, Items.SortDescriptions);
            }
        }

        private string SerializeObjectToXML<T>(T item)
        {
            var xs = new XmlSerializer(typeof (T));
            using (var stringWriter = new StringWriter())
            {
                xs.Serialize(stringWriter, item);
                return stringWriter.ToString();
            }
        }

        private T DeserializeFromXml<T>(string xml)
        {
            T result;
            var ser = new XmlSerializer(typeof (T));
            using (TextReader tr = new StringReader(xml))
            {
                result = (T) ser.Deserialize(tr);
            }
            return result;
        }
        /// <summary>
        /// Get the column information in xml (string) basically used to save data
        /// </summary>
        /// <returns>xml representation of column information in string</returns>
        public string GetColumnInformation()
        {
            UpdateColumnInfo();
            return SerializeObjectToXML(ColumnInfo);
        }
        /// <summary>
        /// This is used to apply the column information last saved
        /// </summary>
        /// <param name="xmlOfColumnInformation">xml representation of column information</param>
        /// <returns></returns>
        public bool SetColumnInformation(string xmlOfColumnInformation)
        {
            try
            {
                ColumnInfo = DeserializeFromXml<ObservableCollection<ColumnInformation>>(xmlOfColumnInformation);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private void DataGridStandardSorting(object sender, DataGridSortingEventArgs e)
        {
            if (OnlyTwoWaySorting)
                return;
            string sortPropertyName = SortHelpers.GetSortMemberPath(e.Column);
            if (!String.IsNullOrEmpty(sortPropertyName))
            {
                // sorting is cleared when the previous state is Descending
                if (e.Column.SortDirection.HasValue && e.Column.SortDirection.Value == ListSortDirection.Descending)
                {
                    int index = SortHelpers.FindSortDescription(Items.SortDescriptions, sortPropertyName);
                    if (index != -1)
                    {
                        e.Column.SortDirection = null;
                        // remove the sort description
                        Items.SortDescriptions.RemoveAt(index);
                        Items.Refresh();
                        if ((Keyboard.Modifiers & ModifierKeys.Shift) != ModifierKeys.Shift)
                        {
                            // clear any other sort descriptions for the multisorting case
                            Items.SortDescriptions.Clear();
                            Items.Refresh();
                        }
                        // stop the default sort
                        e.Handled = true;
                    }
                }
            }
        }

        #endregion

        #region Property

        internal bool IsGroupByColumnRemoved
        {
            get { return GroupByColumnRemoved != null; }
        }

        internal DataGrid RowSummariesGrid { get; set; }
        internal bool IsVerticalScrolling { get; set; }

        internal DataRow DraggedItem
        {
            get { return _draggedItem; }
            set
            {
                _draggedItem = value;
                NotifyPropertyChanged("DraggedItem");
            }
        }
        /// <summary>
        /// Group by collection
        /// </summary>
        public ObservableCollection<GroupByData> GroupByCollection
        {
            get { return _groupByCollection; }
            set
            {

                _groupByCollection = value;
                NotifyPropertyChanged("GroupByCollection");
            }
        }
        /// <summary>
        /// DataTable which keeps record of summary row
        /// </summary>
        public DataTable RowSummariesTable
        {
            get { return _rowSummariesTable; }
            set
            {

                _rowSummariesTable = value;
                NotifyPropertyChanged("RowSummariesTable");
            }
        }

        internal Grid GridSplitterGrid { get; set; }

        internal AutoFilterHelper AutoFilterHelper { get; private set; }

        internal bool IsGroupByOn { get; private set; }

        #endregion

        #region "Attached Properties"
        /// <summary>
        /// Auto Filter Font Size
        /// </summary>
        public double AutoFilterFontSize
        {
            get { return (double) GetValue(AutoFilterFontSizeProperty); }
            set { SetValue(AutoFilterFontSizeProperty, value); }
        }

        public static readonly DependencyProperty AutoFilterFontSizeProperty = DependencyProperty.Register(
            "AutoFilterFontSize", typeof (double), typeof (ExtendedDataGrid), new PropertyMetadata(9.0));
        /// <summary>
        /// Search Auto Filter Visibility
        /// </summary>
        public Visibility SearchAutoFilterVisibility
        {
            get { return (Visibility) GetValue(SearchAutoFilterVisibilityProperty); }
            set { SetValue(SearchAutoFilterVisibilityProperty, value); }
        }

        public static readonly DependencyProperty SearchAutoFilterVisibilityProperty = DependencyProperty.Register(
            "SearchAutoFilterVisibility", typeof (Visibility), typeof (ExtendedDataGrid),
            new PropertyMetadata(Visibility.Visible));
        /// <summary>
        /// Group By Control Visibility
        /// </summary>
        public Visibility GroupByControlVisibility
        {
            get { return (Visibility) GetValue(GroupByControlVisibilityProperty); }
            set { SetValue(GroupByControlVisibilityProperty, value); }
        }

        public static readonly DependencyProperty GroupByControlVisibilityProperty = DependencyProperty.Register(
            "GroupByControlVisibility", typeof (Visibility), typeof (ExtendedDataGrid),
            new PropertyMetadata(Visibility.Visible));
        /// <summary>
        /// Hide Column Chooser
        /// </summary>
        public Boolean HideColumnChooser
        {
            get { return (Boolean) GetValue(HideColumnChooseProperty); }
            set { SetValue(HideColumnChooseProperty, value); }
        }

        public static readonly DependencyProperty HideColumnChooseProperty = DependencyProperty.Register(
            "HideColumnChooser", typeof (Boolean), typeof (ExtendedDataGrid), new PropertyMetadata(false));
        /// <summary>
        /// Column Info
        /// </summary>
        public ObservableCollection<ColumnInformation> ColumnInfo
        {
            get { return (ObservableCollection<ColumnInformation>) GetValue(ColumnInfoProperty); }
            set { SetValue(ColumnInfoProperty, value); }
        }

        public static readonly DependencyProperty GroupByHeaderTextProperty = DependencyProperty.Register(
            "GroupByHeaderText", typeof (string), typeof (ExtendedDataGrid),
            new PropertyMetadata("Click a plus sign in column header to group by that column."));
        /// <summary>
        /// Group By Header Text
        /// </summary>
        public string GroupByHeaderText
        {
            get { return (string) GetValue(GroupByHeaderTextProperty); }
            set
            {
                SetValue(GroupByHeaderTextProperty, value);
                var textBox = FindControls.FindChild<TextBlock>(this, "txtDragName");
                if (textBox != null)
                {
                    textBox.Text = value;
                }
            }
        }
        /// <summary>
        /// Theme of the data grid
        /// </summary>
        public Themes Theme
        {
            get { return (Themes) GetValue(ThemeProperty); }
            set
            {
                AddTheme(value);
                SetValue(ThemeProperty, value);

            }
        }

        /// <summary>
        /// Allow to user to copy
        /// </summary>
        public Boolean AllowUserToCopy
        {
            get { return (Boolean) GetValue(AllowUserToCopyProperty); }
            set { SetValue(AllowUserToCopyProperty, value); }
        }

        public static readonly DependencyProperty AllowUserToCopyProperty = DependencyProperty.Register(
            "AllowUserToCopy", typeof (Boolean), typeof (ExtendedDataGrid), new PropertyMetadata(true));

        public static readonly DependencyProperty ThemeProperty = DependencyProperty.Register(
            "Theme", typeof (Themes), typeof (ExtendedDataGrid), new PropertyMetadata(Themes.Default));

        /// <summary>
        /// Can User Reorder Rows
        /// </summary>
        public Boolean CanUserReorderRows
        {
            get { return (Boolean) GetValue(CanUserReorderRowsProperty); }
            set { SetValue(CanUserReorderRowsProperty, value); }
        }

        public static readonly DependencyProperty CanUserReorderRowsProperty = DependencyProperty.Register(
            "CanUserReorderRows", typeof (Boolean), typeof (ExtendedDataGrid), new PropertyMetadata(false));

        /// <summary>
        /// Show Sort Order
        /// </summary>
        public Boolean ShowSortOrder
        {
            get { return (Boolean) GetValue(ShowSortOrderProperty); }
            set { SetValue(ShowSortOrderProperty, value); }
        }

        public static readonly DependencyProperty ShowSortOrderProperty = DependencyProperty.Register(
            "ShowSortOrder", typeof (Boolean), typeof (ExtendedDataGrid), new PropertyMetadata(false));

        /// <summary>
        /// Show Column Splitter
        /// </summary>
        public Boolean ShowColumnSplitter
        {
            get { return (Boolean) GetValue(ShowColumnSplitterProperty); }
            set { SetValue(ShowColumnSplitterProperty, value); }
        }

        public static readonly DependencyProperty ShowColumnSplitterProperty = DependencyProperty.Register(
            "ShowColumnSplitter", typeof (Boolean), typeof (ExtendedDataGrid), new PropertyMetadata(false));

        /// <summary>
        /// Footer Data Template
        /// </summary>
        public DataTemplate FooterDataTemplate
        {
            get { return (DataTemplate) GetValue(FooterDataTemplateProperty); }
            set
            {
                SetValue(FooterDataTemplateProperty, value);
                SetValue(ScrollingPreviewService.VerticalScrollingPreviewTemplateProperty,
                         GetValue(FooterDataTemplateProperty));
            }
        }

        public static readonly DependencyProperty FooterDataTemplateProperty = DependencyProperty.Register(
            "FooterDataTemplate", typeof (DataTemplate), typeof (ExtendedDataGrid));

        /// <summary>
        /// Scroll Tool Tip Data Template
        /// </summary>
        public DataTemplate ScrollToolTipDataTemplate
        {
            get { return (DataTemplate) GetValue(ScrollToolTipDataTemplateProperty); }
            set { SetValue(ScrollToolTipDataTemplateProperty, value); }
        }

        public static readonly DependencyProperty ScrollToolTipDataTemplateProperty = DependencyProperty.Register(
            "ScrollToolTipDataTemplate", typeof (DataTemplate), typeof (ExtendedDataGrid));

        /// <summary>
        /// Show Row Number
        /// </summary>
        public Boolean ShowRowNumber
        {
            get { return (Boolean) GetValue(ShowRowNumberProperty); }
            set { SetValue(ShowRowNumberProperty, value); }
        }

        public static readonly DependencyProperty ShowRowNumberProperty = DependencyProperty.Register(
            "ShowRowNumber", typeof (Boolean), typeof (ExtendedDataGrid), new PropertyMetadata(false));

        /// <summary>
        /// Show Row Summaries
        /// </summary>
        public Boolean ShowRowSummaries
        {
            get { return (Boolean) GetValue(ShowRowSummariesProperty); }
            set { SetValue(ShowRowSummariesProperty, value); }
        }

        public static readonly DependencyProperty ShowRowSummariesProperty = DependencyProperty.Register(
            "ShowRowSummaries", typeof (Boolean), typeof (ExtendedDataGrid), new PropertyMetadata(false));

        #endregion
    }
}
