using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using ExtendedGrid.Classes;
using ExtendedGrid.Converter;
using ExtendedGrid.ExtendedGridControl;
using ExtendedGrid.Interface;
using System.Linq;
using Microsoft.Windows.Themes;
using Application = System.Windows.Application;
using Button = System.Windows.Controls.Button;
using CheckBox = System.Windows.Controls.CheckBox;
using Cursors = System.Windows.Input.Cursors;
using Expression = System.Windows.Expression;
using ListBox = System.Windows.Controls.ListBox;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;


namespace ExtendedGrid.Styles
{
    public partial class DataGridGeneric
    {
        private void AutoFilterMouseDown(object sender, MouseButtonEventArgs e)
        {
            
            TextBox textSearchBox=null;
            try
            {
                e.Handled = true;
                if (e.ChangedButton == MouseButton.Right)
                    return;
                var column = FindControls.FindParent<DataGridColumnHeader>((ContentControl)sender);
                if (string.IsNullOrEmpty(column.Column.SortMemberPath))
                {
                    return;
                }
                var extendedColumn = column.Column as IExtendedColumn;
                if (extendedColumn != null)
                {
                    if (!extendedColumn.AllowAutoFilter)
                        return;
                }
                var popup = FindControls.FindChild<Popup>(column, "popupDrag");
                if (popup == null) return;
                popup.IsOpen = true;
                //Change the position of popup with the mouse
                var popupSize = new Size(popup.ActualWidth, popup.ActualHeight);
                var position = new Point { X = column.ActualWidth - 19, Y = column.ActualHeight };
                popup.PlacementRectangle = new Rect(position, popupSize);
                var listbox = FindControls.FindChild<ListBox>(popup.Child, "autoFilterList");
                listbox.Focus();
                //listbox.LostFocus += PopLostFocus; Removed this becuase event was suscribing again and again on each mouse down
                var clearButton = FindControls.FindChild<Button>(popup.Child, "btnClear");
                //Get the text search textbox and empty it
                textSearchBox = FindControls.FindChild<TextBox>(popup.Child, "txtSearchAutoFilter");
                //Get the data from
                var mainGrid = FindControls.FindParent<ExtendedDataGrid>(popup);
                if (mainGrid != null)
                {
                    mainGrid.CommitEdit();
                    mainGrid.CommitEdit();
                    mainGrid.AutoFilterHelper.CurrentListBox = listbox;
                    CurrentColumn = column.Column.SortMemberPath;
                    CurrentGrid = mainGrid;

                    if (mainGrid.AutoFilterHelper.CurrentColumName == CurrentColumn)
                    {
                        var previousValues = mainGrid.AutoFilterHelper.CurrentDistictValues;
                        var currentValues = mainGrid.AutoFilterHelper.GetDistictValues(CurrentGrid, CurrentColumn);

                        foreach (var checkedListItem in currentValues)
                        {
                            var item = checkedListItem;
                            if (previousValues.Count(c => Convert.ToString(c.Name) == Convert.ToString(item.Name) && c.IsSelectAll != "(Select All)") == 0 && checkedListItem.IsSelectAll != "(Select All)")
                            {
                                previousValues.Add(new CheckedListItem { Name = checkedListItem.Name, IsChecked = previousValues[0].IsChecked });
                            }
                        }

                        if (clearButton != null && mainGrid.AutoFilterHelper.CurrentDistictValues!=null)
                        {
                            clearButton.IsEnabled = mainGrid.AutoFilterHelper.CurrentDistictValues.Count(c => c.IsChecked) > 0;
                            clearButton.UpdateLayout();
                        }
                        mainGrid.AutoFilterHelper.CurrentDistictValues = previousValues;
                        mainGrid.AutoFilterHelper.CurrentDistictValues[0].IsSelectAll = "(Select All)";
                        _isLoading = true;
                        listbox.ItemsSource = mainGrid.AutoFilterHelper.CurrentDistictValues;
                        listbox.UpdateLayout();
                        listbox.Items.Refresh();
                        return;
                    }
                    mainGrid.AutoFilterHelper.CurrentColumName = CurrentColumn;
                    var distict = mainGrid.AutoFilterHelper.GetDistictValues(CurrentGrid, CurrentColumn);

                    if (distict.Count(c => !c.IsChecked) == distict.Count)
                    {
                        if (Convert.ToString(popup.Tag) == "True")
                        {
                            _isLoading = true;
                            foreach (var checkedListItem in distict)
                            {
                                checkedListItem.IsChecked = true;
                            }
                        }
                    }

                    distict[0].IsSelectAll = "(Select All)";
                    listbox.ItemsSource = distict;
                    if (clearButton != null && mainGrid.AutoFilterHelper.CurrentDistictValues != null)
                    {
                        clearButton.IsEnabled = mainGrid.AutoFilterHelper.CurrentDistictValues.Count(c => c.IsChecked) > 0;
                      
                        clearButton.UpdateLayout();
                    }
                }
            }
            finally
            {
                if (textSearchBox != null)
                    textSearchBox.Text = string.Empty;
                _isLoading = false;
            }
        }
        void HeaderClickMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DataGridHeaderBorder dg = sender as DataGridHeaderBorder;
                var grid = FindControls.FindParent<ExtendedDataGrid>(dg);
                var popup = ((System.Windows.Controls.StackPanel)(((System.Windows.Controls.Control)(grid.AutoFilterHelper.CurrentListBox)).Parent)).Parent as Popup;
                if (popup == null) return;
                if (popup.IsMouseOver) return;
                var currentFocueedElement = FocusManager.GetFocusedElement(popup);
                if (currentFocueedElement == null)
                {
                    popup.IsOpen = false;
                }
            }
            catch
            {

            }
        }
        private void AutoFilterRightMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void PopLostFocus(object sender, RoutedEventArgs e)
        {
            var stackPanel = sender as StackPanel == null ? FindControls.FindParent<StackPanel>((FrameworkElement)sender) : (StackPanel)sender;
            if(stackPanel==null)return;
            var popup = (Popup)stackPanel.Parent;
            if(popup==null)return;
            if(popup.IsMouseOver)return;
            var currentFocueedElement = FocusManager.GetFocusedElement(popup);
            if(currentFocueedElement==null)
             popup.IsOpen = false;
        }

        private bool _isLoading;

        private void Checked(object sender, RoutedEventArgs e)
        {
            ExtendedDataGrid mainGrid = null;
            if (_isLoading) return;
            try
            {
                _isLoading = true;
                var checkbox = (CheckBox)sender;
                var value = checkbox.Content;
                var listBox = FindControls.FindParent<ListBox>(checkbox);
                var popup2 = (Popup)((StackPanel)(listBox.Parent)).Parent;
                mainGrid = FindControls.FindParent<ExtendedDataGrid>(popup2);
                if (Convert.ToString(checkbox.Tag) != "(Select All)")
                {
                    mainGrid.AutoFilterHelper.ApplyFilters(CurrentGrid, CurrentColumn, value);
                }
                else
                {
                    if (mainGrid.AutoFilterHelper.CurrentDistictValues == null)
                        return;
                    _isLoading = true;
                    var distictictValues = mainGrid.AutoFilterHelper.CurrentDistictValues;
                    foreach (var distictictValue in distictictValues)
                    {
                        if (Convert.ToString(distictictValue.Name) != "(Select All)" && distictictValue.IsSelectAll != "(Select All)")
                            distictictValue.IsChecked = true;
                    }
                    mainGrid.AutoFilterHelper.CurrentDistictValues = distictictValues;
                    mainGrid.AutoFilterHelper.RemoveAllFilter(CurrentGrid, CurrentColumn);
                    foreach (var c in distictictValues)
                    {
                        c.IsChecked = true;
                    }
                    var sp1 = FindControls.FindParent<StackPanel>(mainGrid.AutoFilterHelper.CurrentListBox);
                    var popup1 = sp1.Parent as Popup;
                    if (popup1 != null)
                    {
                        var clearButton = FindControls.FindChild<Button>(popup1.Child, "btnClear");
                        if (clearButton != null)
                        {
                            clearButton.IsEnabled = true;
                           
                        }
                          
                    }
                    mainGrid.AutoFilterHelper.CurrentListBox.UpdateLayout();
                    mainGrid.AutoFilterHelper.CurrentListBox.Items.Refresh();
                    return;
                }
                var sp = FindControls.FindParent<StackPanel>(mainGrid.AutoFilterHelper.CurrentListBox);
                var popup = sp.Parent as Popup;
                if (popup != null) popup.Tag = "True";
                mainGrid.AutoFilterHelper.CurrentListBox.UpdateLayout();
                mainGrid.AutoFilterHelper.CurrentListBox.Items.Refresh();
            }
            finally
            {
                ComputeAllColumnSummaries(mainGrid);
                if (mainGrid != null) 
                    mainGrid.FireNotifyForRowSummaries();
                _isLoading = false;
            }
        }

        private void UnChecked(object sender, RoutedEventArgs e)
        {
            if (_isLoading) return;
            ExtendedDataGrid grid=null;
            try
            {
                _isLoading = true;
                var checkbox = (CheckBox)sender;
                var listBox = FindControls.FindParent<ListBox>(checkbox);
                if(listBox == null)
                    return;
                var popup = (Popup)((StackPanel)(listBox.Parent)).Parent;
                grid  = FindControls.FindParent<ExtendedDataGrid>(popup);
                CurrentGrid = grid;
                grid.AutoFilterHelper.CurrentListBox = listBox;
                
                var value = checkbox.Content;
                if (Convert.ToString(checkbox.Tag) != "(Select All)")
                {

                    var distictValues = grid.AutoFilterHelper.CurrentListBox.ItemsSource as ObservableCollection<CheckedListItem>;
                    if (distictValues != null)
                    {
                        var countOfFiltersSelected = distictValues.Count(c => c.IsChecked && Convert.ToString(c.Name) != "(Select All)" && c.IsSelectAll != "(Select All)");
                        if (countOfFiltersSelected == distictValues.Count - 1)
                        {
                            _isLoading = true;
                            distictValues[0].IsChecked = false;
                            grid.AutoFilterHelper.CurrentListBox.UpdateLayout();
                            grid.AutoFilterHelper.CurrentListBox.Items.Refresh();
                        }
                        bool isFilterApplicable = false;
                        if(grid.ItemsSource is DataView)
                        {
                            isFilterApplicable = (!string.IsNullOrEmpty(((DataView)grid.ItemsSource).RowFilter) && ((DataView)grid.ItemsSource).RowFilter.Contains("[" + CurrentColumn + "]  IN"));
                        }
                        else if (CollectionViewSource.GetDefaultView(grid.ItemsSource) != null)
                        {
                            isFilterApplicable = (!string.IsNullOrEmpty(grid.AutoFilterHelper.FilterExpression) && (grid.AutoFilterHelper.FilterExpression.Contains("[" + CurrentColumn + "]  IN")));
                        }

                        if (!isFilterApplicable && !string.IsNullOrEmpty(Convert.ToString(value)))
                        {
                            string rowFilter;
                            if (grid.ItemsSource is DataView)
                            {
                                rowFilter = ((DataView)grid.ItemsSource).RowFilter;
                                if (string.IsNullOrEmpty(rowFilter))
                                {
                                    var actualValues = ((DataView)CurrentGrid.ItemsSource).Table.Rows.Cast<DataRow>().Select(row => Convert.ToString(row[CurrentColumn])).Where(val => val != Convert.ToString(value)).ToList();

                                    foreach (var actualValue in actualValues)
                                    {
                                        grid.AutoFilterHelper.ApplyFilters(CurrentGrid, CurrentColumn, actualValue);
                                    }

                                    var distictictValues = grid.AutoFilterHelper.CurrentDistictValues;
                                    distictictValues[0].IsChecked = false;
                                    grid.AutoFilterHelper.CurrentDistictValues = distictictValues;
                                    grid.AutoFilterHelper.CurrentListBox.Items.Refresh();
                                    popup.Tag = distictictValues.Count(c => c.IsChecked) == 0 ? "False" : "True";
                                    CurrentGrid.Items.Refresh();
                                    CurrentGrid.UpdateLayout();
                                }
                                else
                                {

                                    grid.AutoFilterHelper.CurrentDistictValues[0].IsChecked = countOfFiltersSelected == distictValues.Count - 1;
                                    grid.AutoFilterHelper.CurrentListBox.Items.Refresh();
                                    grid.AutoFilterHelper.CurrentListBox.UpdateLayout();
                                    popup.Tag = grid.AutoFilterHelper.CurrentDistictValues.Count(c => c.IsChecked) == 0 ? "False" : "True";
                                    CurrentGrid.Items.Refresh();
                                    CurrentGrid.UpdateLayout();


                                }
                            }
                            else if (CollectionViewSource.GetDefaultView(grid.ItemsSource) != null)
                            {
                                rowFilter = grid.AutoFilterHelper.FilterExpression;
                                if (string.IsNullOrEmpty(rowFilter))
                                {
                                    ICollectionView view = CollectionViewSource.GetDefaultView(grid.ItemsSource);
                                    var actualValues = new HashSet<string>();
                                    foreach (var rowData in grid.ItemsSource)
                                    {
                                        var propertyValue = rowData.GetType().GetProperty(CurrentColumn);
                                        if (propertyValue != null)
                                        {
                                            var data = Convert.ToString(propertyValue.GetValue(rowData, null));
                                            if (!actualValues.Contains(data) && data != Convert.ToString(value))
                                            {
                                                actualValues.Add(data);
                                            }
                                        }
                                    }
                                    foreach (var actualValue in actualValues)
                                    {
                                        grid.AutoFilterHelper.ApplyFilters(CurrentGrid, CurrentColumn, actualValue);
                                    }

                                    var distictictValues = grid.AutoFilterHelper.CurrentDistictValues;
                                    distictictValues[0].IsChecked = false;
                                    grid.AutoFilterHelper.CurrentDistictValues = distictictValues;
                                    grid.AutoFilterHelper.CurrentListBox.Items.Refresh();
                                    popup.Tag = distictictValues.Count(c => c.IsChecked) == 0 ? "False" : "True";
                                    grid.Items.Refresh();
                                    grid.UpdateLayout();

                                }
                                else
                                {
                                    grid.AutoFilterHelper.CurrentDistictValues[0].IsChecked = countOfFiltersSelected == distictValues.Count - 1;
                                    grid.AutoFilterHelper.CurrentListBox.Items.Refresh();
                                    grid.AutoFilterHelper.CurrentListBox.UpdateLayout();
                                    popup.Tag = grid.AutoFilterHelper.CurrentDistictValues.Count(c => c.IsChecked) == 0 ? "False" : "True";
                                    grid.Items.Refresh();
                                    grid.UpdateLayout();
                                }
                            }


                           
                        }
                        else
                        {
                            grid.AutoFilterHelper.CurrentListBox = FindControls.FindChild<ListBox>(popup.Child, "autoFilterList");
                            grid.AutoFilterHelper.CurrentListBox.Items.Refresh();
                            distictValues = grid.AutoFilterHelper.CurrentListBox.ItemsSource as ObservableCollection<CheckedListItem>;
                            if (distictValues != null)
                            {
                                var checkCount = distictValues.Count(c => c.IsChecked && Convert.ToString(c.Name) != "(Select All)" && c.IsSelectAll != "(Select All)");
                                if (checkCount == 0)
                                {
                                    grid.AutoFilterHelper.RemoveAllFilter(CurrentGrid, CurrentColumn);
                                    grid.AutoFilterHelper.CurrentListBox.Items.Refresh();
                                    popup.Tag = countOfFiltersSelected == 0 ? "False" : "True";
                                }
                                else
                                {
                                    grid.AutoFilterHelper.RemoveFilters(CurrentGrid, CurrentColumn, value);
                                    var distictictValues = grid.AutoFilterHelper.CurrentDistictValues;
                                    popup.Tag = distictictValues.Count(c => c.IsChecked) == 0 ? "False" : "True";
                                }
                            }
                            var sp1 = FindControls.FindParent<StackPanel>(grid.AutoFilterHelper.CurrentListBox);
                            var popup1 = sp1.Parent as Popup;
                            if (popup1 != null)
                            {
                                var clearButton = FindControls.FindChild<Button>(popup1.Child, "btnClear");
                                if (clearButton != null)
                                {
                                    clearButton.IsEnabled = false;

                                }

                            }
                        }
                    }
                }

                else
                {
                    _isLoading = true;
                    var distictictValues = grid.AutoFilterHelper.CurrentDistictValues;
                    distictictValues[0].IsChecked = false;
                    foreach (var distictictValue in distictictValues)
                    {
                        if (Convert.ToString(distictictValue.Name) != "(Select All)" && distictictValue.IsSelectAll != "(Select All)")
                            distictictValue.IsChecked = false;
                    }
                    grid.AutoFilterHelper.CurrentDistictValues = distictictValues;
                    grid.AutoFilterHelper.RemoveAllFilter(CurrentGrid, CurrentColumn);
                    grid.AutoFilterHelper.CurrentListBox.Items.Refresh();
                    var countOfFiltersSelected = distictictValues.Count(c => c.IsChecked && Convert.ToString(c.Name) != "(Select All)");
                    popup.Tag = countOfFiltersSelected == 0 ? "False" : "True";
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (grid != null)
                {
                    grid.Items.Refresh();
                    ComputeAllColumnSummaries(grid);
                    grid.FireNotifyForRowSummaries();
                }
                _isLoading = false;
            }
        }

        internal string CurrentColumn { get;  set; }
        private DataGrid CurrentGrid { get; set; }

        public bool IsDragging
        {
            get { return _isDragging; }
            set
            {
                _isDragging = value;
                if(_dummyGridSplitter!=null)
                {
                    _dummyGridSplitter.Visibility = _isDragging ? Visibility.Visible : Visibility.Collapsed;
                }

            }
        }

        

        private void ClearClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                if (button != null)
                {
                    var popup2 = (Popup)((StackPanel)(button.Parent)).Parent;
                    var mainGrid = FindControls.FindParent<ExtendedDataGrid>(popup2);
                    //var mainGrid = AutoFilterHelper.CurrentGrid;
                    if(mainGrid==null)return;
                    _isLoading = true;
                    var distictictValues = mainGrid.AutoFilterHelper.CurrentDistictValues;
                    foreach (var distictictValue in distictictValues)
                    {
                        if (distictictValue.IsChecked)
                            distictictValue.IsChecked = false;
                    }
                    mainGrid.AutoFilterHelper.CurrentDistictValues = distictictValues;
                    mainGrid.AutoFilterHelper.RemoveAllFilter(CurrentGrid, CurrentColumn);
                    mainGrid.AutoFilterHelper.CurrentListBox.Items.Refresh();
                    mainGrid.AutoFilterHelper.RemoveAllFilter(mainGrid, mainGrid.AutoFilterHelper.CurrentColumName);
                    var sp = FindControls.FindParent<StackPanel>(mainGrid.AutoFilterHelper.CurrentListBox);
                    var popup = sp.Parent as Popup;
                    if (popup != null) popup.Tag = "False";
                }
            }
            finally
            {
                _isLoading = false;
            }
        }

        private void AutoFilterGlphLoaded(object sender, RoutedEventArgs e)
        {

            var column = FindControls.FindParent<DataGridColumnHeader>((ContentControl)sender);
            if(column==null)
                return;
            var extendedColumn = column.Column as IExtendedColumn;
              
            if(extendedColumn != null && !extendedColumn.AllowAutoFilter)
            {
                ((ContentControl)(sender)).Visibility = Visibility.Collapsed;
            }
        }

        private void GridSplitterLoaded(object sender, RoutedEventArgs e)
        {
            var gridSplitter = (GridSplitter) sender;
            var grid = FindControls.FindParent<ExtendedDataGrid>((GridSplitter) sender);
            if(grid!=null)
            {
                gridSplitter.Visibility = grid.ShowColumnSplitter ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void GridSplitterMouseUp(object sender, MouseButtonEventArgs e)
        {
            IsDragging = false;
            var gridSplitter = (GridSplitter)sender;
            var grid = FindControls.FindParent<ExtendedDataGrid>(gridSplitter);
            if (grid != null)
            {
                var scrollviewer = FindControls.FindChild<ScrollViewer>(grid, "DG_ScrollViewer");
               var columnPositions=new List<double>();
               double tillNowWidth = 0;
                foreach (var column in grid.Columns)
                {
                    if(column.Visibility==Visibility.Visible)
                    {
                        tillNowWidth = tillNowWidth + column.ActualWidth-0.5;
                        columnPositions.Add(tillNowWidth);
                    }
                }
                var position = e.GetPosition(_gridSplitterGrid);
                var splitterPosition = position.X;
                double valueToBeComapred;
                if(grid.FrozenColumnCount>1)
                {
                    var currentClosstColumnToSplitter = FindClosest(columnPositions, splitterPosition);
                    if (currentClosstColumnToSplitter != null)
                    {
                        var index = columnPositions.IndexOf((double) currentClosstColumnToSplitter);
                        if(index<grid.FrozenColumnCount-1)
                        {
                            valueToBeComapred = splitterPosition ;
                            if (valueToBeComapred > -1)
                            {
                                var closestValue = FindClosest(columnPositions, valueToBeComapred);
                                if (closestValue != null)
                                {

                                    if (columnPositions.IndexOf((double)closestValue) != columnPositions.Count - 1)
                                    {
                                        grid.FrozenColumnCount = columnPositions.IndexOf((double)closestValue) + 1;
                                        _gridSplitterGrid.ColumnDefinitions[0].Width = new GridLength((Double)closestValue+grid.RowHeaderWidth);

                                    }

                                    else
                                    {

                                        double previousColumnPosition = 0;
                                        if (columnPositions.IndexOf((double)closestValue) - 1 >= 0)
                                        {
                                            previousColumnPosition =
                                                columnPositions[columnPositions.IndexOf((double)closestValue) - 1];

                                        }

                                        grid.FrozenColumnCount = columnPositions.IndexOf((double)closestValue);
                                        _gridSplitterGrid.ColumnDefinitions[0].Width = new GridLength(previousColumnPosition +GetGridHeaderActualWidth(grid));

                                    }

                                }
                            }
                        }
                        else
                        {
                            valueToBeComapred = splitterPosition + scrollviewer.HorizontalOffset;
                            if (valueToBeComapred > -1)
                            {
                                var closestValue = FindClosest(columnPositions, valueToBeComapred);
                                if (closestValue != null)
                                {

                                    if (columnPositions.IndexOf((double)closestValue) != columnPositions.Count - 1)
                                    {
                                        grid.FrozenColumnCount = columnPositions.IndexOf((double)closestValue) + 1;
                                        _gridSplitterGrid.ColumnDefinitions[0].Width = new GridLength((Double)closestValue +GetGridHeaderActualWidth(grid));

                                    }

                                    else
                                    {

                                        double previousColumnPosition = 0;
                                        if (columnPositions.IndexOf((double)closestValue) - 1 >= 0)
                                        {
                                            previousColumnPosition =
                                                columnPositions[columnPositions.IndexOf((double)closestValue) - 1];

                                        }

                                        grid.FrozenColumnCount = columnPositions.IndexOf((double)closestValue);
                                        _gridSplitterGrid.ColumnDefinitions[0].Width = new GridLength(previousColumnPosition +GetGridHeaderActualWidth(grid));

                                    }

                                }
                            }
                        }
                       
                    }
                  
                
                }
                else
                {
                    valueToBeComapred = splitterPosition + scrollviewer.HorizontalOffset;
                    if (valueToBeComapred > -1)
                    {
                        var closestValue = FindClosest(columnPositions, valueToBeComapred);
                        if (closestValue != null)
                        {

                            if (columnPositions.IndexOf((double)closestValue) != columnPositions.Count - 1)
                            {
                                grid.FrozenColumnCount = columnPositions.IndexOf((double)closestValue) +1;
                                _gridSplitterGrid.ColumnDefinitions[0].Width = new GridLength((Double)closestValue +GetGridHeaderActualWidth(grid));

                            }

                            else
                            {

                                double previousColumnPosition = 0;
                                if (columnPositions.IndexOf((double)closestValue) - 1 >= 0)
                                {
                                    previousColumnPosition =
                                        columnPositions[columnPositions.IndexOf((double)closestValue) - 1];

                                }

                                grid.FrozenColumnCount = columnPositions.IndexOf((double)closestValue);
                                _gridSplitterGrid.ColumnDefinitions[0].Width = new GridLength(previousColumnPosition +GetGridHeaderActualWidth(grid));

                            }

                        }
                    }
                }
              
               

            }
        }

        private double GetGridHeaderActualWidth(DataGrid grid)
        {
            if (grid.HeadersVisibility == DataGridHeadersVisibility.None || grid.HeadersVisibility == DataGridHeadersVisibility.Column)
                return 0;
            return grid.RowHeaderWidth;
        }

        private double? FindClosest(IEnumerable<double> numbers, double x)
        {
            return
                (from number in numbers
                 let difference = Math.Abs(number - x)
                 orderby difference, Math.Abs(number), number descending
                 select (double?)number)
                .FirstOrDefault();
        }

        private Grid _gridSplitterGrid;
        private void GridSplitterGridLoaded(object sender, RoutedEventArgs e)
        {
            _gridSplitterGrid = (Grid) sender;
            
            var grid = FindControls.FindParent<ExtendedDataGrid>(_gridSplitterGrid);
            if(grid==null||!grid.ShowColumnSplitter||grid.FrozenColumnCount==0)return;
            grid.GridSplitterGrid = _gridSplitterGrid;
            double tillNowWidth = 0;
            int index = 0;
            foreach (var column in grid.Columns)
            {
                if (index == grid.FrozenColumnCount ) break;
                if (column.Visibility == Visibility.Visible)
                {
                    tillNowWidth = tillNowWidth + column.ActualWidth - 0.5;
                    
                }
                index++;
            }
            var scrollviewer = FindControls.FindChild<ScrollViewer>(grid, "DG_ScrollViewer");
            _gridSplitterGrid.ColumnDefinitions[0].Width = new GridLength(tillNowWidth - 0.5 * grid.FrozenColumnCount - scrollviewer.HorizontalOffset +GetGridHeaderActualWidth(grid));
        }

        private void ColumnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            
            var grid = FindControls.FindParent<ExtendedDataGrid>((FrameworkElement)sender);
            if (grid == null) return;
            foreach (var column in grid.Columns)
            {
                //Adjust width of summary row headers
                var summarieRowGridColumn = grid.GetRowSummariesGridColumnForSortMemberPath(column.SortMemberPath);
                if (summarieRowGridColumn != null)
                {
                    summarieRowGridColumn.Visibility = column.Visibility;
                    summarieRowGridColumn.Width = column.ActualWidth;
                }
            }
           

            if (!grid.ShowColumnSplitter || grid.FrozenColumnCount == 0)
                return;
            var scrollviewer = FindControls.FindChild<ScrollViewer>(grid, "DG_ScrollViewer");
            var columnPositions = new List<double>();
            double tillNowWidth = 0;
            foreach (var column in grid.Columns)
            {
                //Adjust width of summary row headers
                var summarieRowGridColumn = grid.GetRowSummariesGridColumnForSortMemberPath(column.SortMemberPath);
                if(summarieRowGridColumn!=null)
                {
                    summarieRowGridColumn.Visibility = column.Visibility;
                    summarieRowGridColumn.Width = column.ActualWidth;
                }

                if (column.Visibility == Visibility.Visible)
                {
                    tillNowWidth = tillNowWidth + column.ActualWidth-.5;
                    columnPositions.Add(tillNowWidth);
                }
            }
            if (_gridSplitterGrid == null)
                return;
            double splitterPositionToBe = 0;
            var listOfColumn = grid.Columns.ToList().OrderBy(c => c.DisplayIndex);

            foreach (var column in listOfColumn)
            {
                if (column.Visibility == Visibility.Visible && column.DisplayIndex < grid.FrozenColumnCount)
                {
                    splitterPositionToBe =splitterPositionToBe+ column.ActualWidth - 0.5;
                }
            }
            var splitterPosition = splitterPositionToBe;
            
            double valueToBeComapred;
            if (grid.FrozenColumnCount > 1)
            {
                var currentClosstColumnToSplitter = FindClosest(columnPositions, splitterPosition);
                if (currentClosstColumnToSplitter != null)
                {
                    var index = columnPositions.IndexOf((double)currentClosstColumnToSplitter);
                    if (index < grid.FrozenColumnCount - 1)
                    {
                        valueToBeComapred = splitterPosition;
                        if (valueToBeComapred > -1)
                        {
                            var closestValue = FindClosest(columnPositions, valueToBeComapred);
                            if (closestValue != null)
                            {

                                if (columnPositions.IndexOf((double)closestValue) != columnPositions.Count - 1)
                                {

                                    _gridSplitterGrid.ColumnDefinitions[0].Width = new GridLength((Double)closestValue +GetGridHeaderActualWidth(grid));

                                }

                                else
                                {

                                    double previousColumnPosition = 0;
                                    if (columnPositions.IndexOf((double)closestValue) - 1 >= 0)
                                    {
                                        previousColumnPosition =
                                            columnPositions[columnPositions.IndexOf((double)closestValue) - 1];
                                       
                                    }


                                    _gridSplitterGrid.ColumnDefinitions[0].Width = new GridLength(previousColumnPosition +GetGridHeaderActualWidth(grid));

                                }

                            }
                        }
                    }
                    else
                    {
                        valueToBeComapred = splitterPosition + scrollviewer.HorizontalOffset;
                        if (valueToBeComapred > -1)
                        {
                            var closestValue = FindClosest(columnPositions, valueToBeComapred);
                            if (closestValue != null)
                            {

                                if (columnPositions.IndexOf((double)closestValue) != columnPositions.Count - 1)
                                {

                                    _gridSplitterGrid.ColumnDefinitions[0].Width = new GridLength((double)closestValue +GetGridHeaderActualWidth(grid));

                                }

                                else
                                {

                                    double previousColumnPosition = 0;
                                    if (columnPositions.IndexOf((double)closestValue) - 1 >= 0)
                                    {
                                        previousColumnPosition =
                                            columnPositions[columnPositions.IndexOf((double)closestValue) - 1];

                                    }


                                    _gridSplitterGrid.ColumnDefinitions[0].Width = new GridLength(previousColumnPosition +GetGridHeaderActualWidth(grid));

                                }

                            }
                        }
                    }

                }


            }
            else
            {
                valueToBeComapred = splitterPosition + scrollviewer.HorizontalOffset;
                if (valueToBeComapred > -1)
                {
                    var closestValue = FindClosest(columnPositions, valueToBeComapred);
                    if (closestValue != null)
                    {

                        if (columnPositions.IndexOf((double)closestValue) != columnPositions.Count - 1)
                        {

                            _gridSplitterGrid.ColumnDefinitions[0].Width = new GridLength((Double)closestValue +GetGridHeaderActualWidth(grid));

                        }

                        else
                        {

                            double previousColumnPosition = 0;
                            if (columnPositions.IndexOf((double)closestValue) - 1 >= 0)
                            {
                                previousColumnPosition =
                                    columnPositions[columnPositions.IndexOf((double)closestValue) - 1];

                            }


                            _gridSplitterGrid.ColumnDefinitions[0].Width = new GridLength(previousColumnPosition +GetGridHeaderActualWidth(grid));

                        }

                    }
                }
            }
        }

        private void DummyGridSplitterLoaded(object sender, RoutedEventArgs e)
        {
            _dummyGridSplitter = (Rectangle) sender;
        }

        private Rectangle _dummyGridSplitter;
        private bool _isDragging;
        private void GridSplitterMouseDown(object sender, MouseButtonEventArgs e)
        {
            IsDragging = true;
            if(_gridSplitterGrid!=null)
            {
                _dummyGridSplitter.Margin = new Thickness(_gridSplitterGrid.ColumnDefinitions[0].ActualWidth,0,0,0);
            }
        }


        #region "Drag And Drop"

   

        private bool? _canUserResesizeRows;
        private DataGridSelectionMode? _dataGridSelectionMode;

        private void PreviewDataCellMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                _canUserResesizeRows = null;
                _dataGridSelectionMode = null;
             
                var rowHeader = sender as DataGridRowHeader;
                var row = FindControls.FindParent<DataGridRow>(rowHeader);

                var grid = FindControls.FindParent<ExtendedDataGrid>(rowHeader);
                if(grid==null) return;

                if(!grid.CanUserReorderRows)
                    return;

                var popupDrag = FindControls.FindChild<Popup>(grid, "popupDrag");
                if(popupDrag==null)return;

                if (row != null)
                {
                    if (row.IsEditing)
                        return;
               
                   

                

                   // popupDrag.Width = grid.ActualWidth;
                    grid.CanUserResizeRows = false;

                    IsDragging = true;
                    _canUserResesizeRows = grid.CanUserResizeRows;
                    _dataGridSelectionMode = grid.SelectionMode;
                     grid.SelectionMode=DataGridSelectionMode.Single;
                    grid.CanUserResizeRows = false;
                    grid.DraggedItem = ((DataRowView)row.DataContext).Row;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void GridMouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                var grid = sender as ExtendedDataGrid;
                if (grid == null) return;
                var popupDrag = FindControls.FindChild<Popup>(grid, "popupDrag");
                if (popupDrag == null) return;
                if ((!IsDragging && e.LeftButton != MouseButtonState.Pressed) ||
                    grid.DraggedItem == null)
                    return;
               

                //display the popup if it hasn't been opened yet
                if (!popupDrag.IsOpen)
                {
                    //switch to read-only mode
                    grid.IsReadOnly = true;
                    grid.Cursor = Cursors.ScrollNS;
                    //make sure the popup is visible

                    popupDrag.IsOpen = true;
                }
                //Change the position of popup with the mouse
                var popupSize = new Size(popupDrag.ActualWidth, popupDrag.ActualHeight);
                var position = e.GetPosition(popupDrag);
               
                position.X = position.X + 10;
                position.Y = position.Y - 11;
                popupDrag.PlacementRectangle = new Rect(position, popupSize);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void CellMouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                if (IsDragging)
                {
                    if(sender is DataGridCell)
                    {
                        var cell = sender as DataGridCell;
                        var grid = FindControls.FindParent<ExtendedDataGrid>(cell);
                        if (grid == null) return;
                        grid.SelectedItem = cell.DataContext;
                        if (grid.SelectedItem != null)
                        {
                            grid.ScrollIntoView(grid.SelectedItem);
                        }
                    }
                    else if (sender is DataGridRowHeader)
                    {
                        var rowHeader = sender as DataGridRowHeader;
                        var grid = FindControls.FindParent<ExtendedDataGrid>(rowHeader);
                        if (grid == null) return;
                        var row = FindControls.FindParent<DataGridRow>(rowHeader);
                        if(row==null)return;
                        grid.SelectedItem = row.DataContext;
                        if (grid.SelectedItem != null)
                        {
                            grid.ScrollIntoView(grid.SelectedItem);
                        }
                    }
                   
                }
                e.Handled = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void GridPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var grid = sender as ExtendedDataGrid;
            try
            {
                if (grid==null)return;

                if (!IsDragging || grid.DraggedItem==null)
                    return;
              
                //get the target item
                if (grid.SelectedItem != null)
                {
                    var targetItem = ((DataRowView)grid.SelectedItem).Row;

                    if (targetItem != null && !ReferenceEquals(grid.DraggedItem, targetItem))
                    {
                        DataTable columnChooserDataTable=null;
                        var dataView = grid.ItemsSource as DataView;
                        if (dataView != null)
                            columnChooserDataTable = dataView.Table;

                        if (columnChooserDataTable != null)
                        {
                            var row = columnChooserDataTable.NewRow();
                            for(int i=0;i<columnChooserDataTable.Columns.Count;i++)
                            {
                                row[i] = grid.DraggedItem[i];
                            }
                            int targetIndex = columnChooserDataTable.Rows.IndexOf(targetItem);
                            if (targetIndex == 0)
                                targetIndex = 1;
                            columnChooserDataTable.Rows.Remove(grid.DraggedItem);
                            columnChooserDataTable.Rows.InsertAt(row, targetIndex);
                            
                            grid.SelectedItem = grid.DraggedItem;
                        }
                        
                    }
                    ResetDragDrop(grid);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (_canUserResesizeRows!=null)
                {
                    if (grid != null) grid.CanUserResizeRows = (bool) _canUserResesizeRows;
                    _canUserResesizeRows = null;

                }
                if (grid != null)
                {
                    grid.Cursor = Cursors.Arrow;

                    if(_dataGridSelectionMode!=null)
                    {
                        grid.SelectionMode = _dataGridSelectionMode.Value;
                        _dataGridSelectionMode = null;
                    }
                }
            }

        }
        public void ResetDragDrop(ExtendedDataGrid grid)
        {
            if (!grid.CanUserReorderRows)
                return;
            var popupDrag = FindControls.FindChild<Popup>(grid, "popupDrag");
            IsDragging = false;
            if(popupDrag!=null)
            popupDrag.IsOpen = false; 
            grid.IsReadOnly = false;
            grid.DraggedItem = null;

            if (_canUserResesizeRows != null)
            {
                grid.CanUserResizeRows = (bool)_canUserResesizeRows;
                _canUserResesizeRows = null;
            }

            if (_dataGridSelectionMode != null)
            {
                grid.SelectionMode = _dataGridSelectionMode.Value;
                _dataGridSelectionMode = null;
            }
        }


        #endregion

        private void GridMouseLeave(object sender, MouseEventArgs e)
        {
           ResetDragDrop((ExtendedDataGrid)sender);
        }

     
        private static System.Drawing.Bitmap GetBitmap(Uri uri)
        {
            // Use the helper methods on WPF's application
            // class to create an image.
            var streamResourceInfo = Application.GetResourceStream(uri);
            if (streamResourceInfo != null)
                using (var resourceStream = streamResourceInfo.Stream)
                {
                    return new System.Drawing.Bitmap(resourceStream);
                }
            return null;
        }

        private void PopSigmaLostFocus(object sender, RoutedEventArgs e)
        {
            var stackPanel = sender as StackPanel == null ? FindControls.FindParent<StackPanel>((FrameworkElement)sender) : (StackPanel)sender;
            if (stackPanel == null) return;
            var popup = (Popup)stackPanel.Parent;
            if (popup == null) return;
            if (popup.IsMouseOver) return;
            var currentFocueedElement = FocusManager.GetFocusedElement(popup);
            if (currentFocueedElement == null)
                popup.IsOpen = false;
        }

        private void SigmaMouseDown(object sender, MouseButtonEventArgs e)
        {
            
            e.Handled = true;

            if (e.ChangedButton == MouseButton.Right)
                return;
            var column = FindControls.FindParent<DataGridColumnHeader>((ContentControl)sender);


            var popup = FindControls.FindChild<Popup>(column, "sigmaDrag");
           
            if (popup == null) return;
            popup.IsOpen = true;
            //Change the position of popup with the mouse
            var popupSize = new Size(popup.ActualWidth, popup.ActualHeight);
            var position = new Point { X = column.ActualWidth - 19, Y = column.ActualHeight };
            popup.PlacementRectangle = new Rect(position, popupSize);
            var listbox = FindControls.FindChild<ListBox>(popup.Child, "sigmaList");
            listbox.Focus();
            listbox.LostFocus += PopSigmaLostFocus;
            var clearButton = FindControls.FindChild<Button>(popup.Child, "btnSigmaClear");
            //Get the data from
            var mainGrid = FindControls.FindParent<ExtendedDataGrid>(popup);
            if (mainGrid != null)
            {
                mainGrid.CommitEdit();
                mainGrid.CommitEdit();
                mainGrid.AutoFilterHelper.CurrentSigmaListBox = listbox;
                CurrentSigmaColumn = column.Column.SortMemberPath;
                CurrentGrid = mainGrid;

                List<CheckedListItem> currentValues;

                var itemSource = (DataView)mainGrid.ItemsSource;
                var table = itemSource.Table;
                CurrentColumn = column.Column.SortMemberPath;
                if (IsSummable(table.Columns[column.Column.SortMemberPath].DataType))
                currentValues = new List<CheckedListItem>()
                                        {
                                            new CheckedListItem(){Name = "Sum",IsChecked = IsSummariesChecked(CurrentColumn,ExtendedDataGrid.Sum)},
                                            new CheckedListItem(){Name = "Average",IsChecked = IsSummariesChecked(CurrentColumn,ExtendedDataGrid.Average)},
                                            new CheckedListItem(){Name = "Count",IsChecked = IsSummariesChecked(CurrentColumn,ExtendedDataGrid.Count)},
                                            new CheckedListItem(){Name = "Min",IsChecked = IsSummariesChecked(CurrentColumn,ExtendedDataGrid.Min)},
                                            new CheckedListItem(){Name = "Max",IsChecked = IsSummariesChecked(CurrentColumn,ExtendedDataGrid.Max)}
                                        };
                else
                    currentValues = new List<CheckedListItem>()
                                        {
                                            new CheckedListItem(){Name = "Count",IsChecked = IsSummariesChecked(CurrentColumn,ExtendedDataGrid.Count)},
                                            new CheckedListItem(){Name = "Smallest",IsChecked = IsSummariesChecked(CurrentColumn,ExtendedDataGrid.Smallest)},
                                            new CheckedListItem(){Name = "Largest",IsChecked = IsSummariesChecked(CurrentColumn,ExtendedDataGrid.Largest)}
                                        };


              
                     
                if (clearButton != null)
                {
                    clearButton.IsEnabled = currentValues.Count(c => c.IsChecked) > 0;
                    clearButton.UpdateLayout();
                }

                listbox.ItemsSource = currentValues;
                listbox.UpdateLayout();
                listbox.Items.Refresh();
            }
        }

        private bool IsSummariesChecked(string columnName,int computation)
        {
           return !string.IsNullOrEmpty( Convert.ToString(((ExtendedDataGrid) CurrentGrid).RowSummariesTable.Rows[computation][columnName]));
        }
        public bool IsSummable(Type type)
        {

            try
            {

                ParameterExpression paramA = System.Linq.Expressions.Expression.Parameter(type, "a");
                ParameterExpression paramB = System.Linq.Expressions.Expression.Parameter(type, "b");
                BinaryExpression addExpression = System.Linq.Expressions.Expression.Add(paramA, paramB);
                var add = System.Linq.Expressions.Expression.Lambda(addExpression, paramA, paramB).Compile();
                var v = Activator.CreateInstance(type);
                add.DynamicInvoke(v, v);
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected string CurrentSigmaColumn { get; set; }
       

        private void SigmaRightMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void SigmaChecked(object sender, RoutedEventArgs e)
        {
            var currentColumnName = CurrentColumn;
            RowSummariesHelper.CurrentColumn = CurrentColumn;
            var extendedDataGrrid = (ExtendedDataGrid) CurrentGrid;
            var currentComputation = Convert.ToString(((CheckBox) sender).Content);
            var itemSourceDataTable = ((DataView) CurrentGrid.ItemsSource).ToTable();
          
            switch (currentComputation)
            
            {
                case "Count":
                    extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Count][currentColumnName] =
                        itemSourceDataTable.Rows.Count;
                    break;
                case "Sum":
                    extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Sum][currentColumnName] =
                        Convert.ToDouble(itemSourceDataTable.Compute("Sum(" + currentColumnName + ")", ""));
                    break;
                case "Average":
                    extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Average][currentColumnName] =
                        itemSourceDataTable.AsEnumerable().Average((row) => Convert.ToDouble(row[currentColumnName]));
                    break;
                case "Min":
                    extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Min][currentColumnName] =
                        Convert.ToDouble(itemSourceDataTable.Compute("Min(" + currentColumnName + ")", ""));
                    break;
                case "Max":
                    extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Max][currentColumnName] =
                        Convert.ToDouble(itemSourceDataTable.Compute("Max(" + currentColumnName + ")", ""));
                    break;
                case "Smallest":
                  
                    var lengthOfCells = (from DataRow row in itemSourceDataTable.Rows select Convert.ToString(row[currentColumnName]).Length).ToList();
                    var minValue = "";
                    foreach (var row in itemSourceDataTable.Rows.Cast<DataRow>().Where(row => Convert.ToString(row[currentColumnName]).Length == lengthOfCells.Min()))
                    {
                        minValue = Convert.ToString(row[currentColumnName]);
                        break;
                    }

                    if (lengthOfCells.Count > 0)
                    {
                       
                        extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Smallest][currentColumnName] =minValue;
                    }
                    
                    break;
                case "Largest":

                    var lengthOfCells1 = (from DataRow row in itemSourceDataTable.Rows select Convert.ToString(row[currentColumnName]).Length).ToList();
                    var maxValue = "";
                    foreach (var row in itemSourceDataTable.Rows.Cast<DataRow>().Where(row => Convert.ToString(row[currentColumnName]).Length == lengthOfCells1.Max()))
                    {
                        maxValue = Convert.ToString(row[currentColumnName]);
                        break;
                    }

                    if (lengthOfCells1.Count > 0)
                    {

                        extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Largest][currentColumnName] = maxValue;
                    }

                    break;
            }
            ((ExtendedDataGrid)CurrentGrid).FireNotifyForRowSummaries();
           
        }

        private void SigmaUnChecked(object sender, RoutedEventArgs e)
        {
            var currentColumnName = CurrentColumn;
            RowSummariesHelper.CurrentColumn = CurrentColumn;
            var extendedDataGrrid = (ExtendedDataGrid)CurrentGrid;
            var currentComputation = Convert.ToString(((CheckBox)sender).Content);
            switch (currentComputation)
            {
                case "Count":
                    extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Count][currentColumnName] =
                        "";
                    break;
                case "Sum":
                    extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Sum][currentColumnName] =
                       "";
                    break;
                case "Average":
                    extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Average][currentColumnName] =
                      "";
                    break;
                case "Min":
                    extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Min][currentColumnName] =
                     "";
                    break;
                case "Max":
                    extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Max][currentColumnName] =
                      "";
                    break;
                case "Smallest":
                        extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Smallest][currentColumnName] = "";
                    break;
                case "Largest":
                    extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Largest][currentColumnName] = "";
                    break;
            }
            ((ExtendedDataGrid)CurrentGrid).FireNotifyForRowSummaries();
        }
        private void ComputeAllColumnSummaries(ExtendedDataGrid extendedDataGrrid)
        {
            var dataView = extendedDataGrrid.ItemsSource as DataView;
            if (dataView != null)
            {
                DataTable itemSourceDataTable = dataView.ToTable();
                for (int i = 0; i < itemSourceDataTable.Columns.Count; i++)
                {
                    string currentColumnName = itemSourceDataTable.Columns[i].ColumnName;
                    if (
                        !string.IsNullOrEmpty(
                            Convert.ToString(
                                extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Count][currentColumnName])))
                        extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Count][currentColumnName] =
                            itemSourceDataTable.Rows.Count;
                    if (
                        !string.IsNullOrEmpty(
                            Convert.ToString(
                                extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Sum][currentColumnName])))
                        extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Sum][currentColumnName] =
                            Convert.ToDouble(itemSourceDataTable.Compute("Sum(" + currentColumnName + ")", ""));
                    if (
                        !string.IsNullOrEmpty(
                            Convert.ToString(
                                extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Average][currentColumnName])))
                        extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Average][currentColumnName] =
                            itemSourceDataTable.AsEnumerable().Average((row) => Convert.ToDouble(row[currentColumnName]));
                    if (
                        !string.IsNullOrEmpty(
                            Convert.ToString(
                                extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Min][currentColumnName])))
                        extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Min][currentColumnName] =
                            Convert.ToDouble(itemSourceDataTable.Compute("Min(" + currentColumnName + ")", ""));
                    if (
                        !string.IsNullOrEmpty(
                            Convert.ToString(
                                extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Max][currentColumnName])))
                        extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Max][currentColumnName] =
                            Convert.ToDouble(itemSourceDataTable.Compute("Max(" + currentColumnName + ")", ""));
                    if (
                        !string.IsNullOrEmpty(
                            Convert.ToString(
                                extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Smallest][currentColumnName])))
                    {
                        var lengthOfCells =
                            (from DataRow row in itemSourceDataTable.Rows
                             select Convert.ToString(row[currentColumnName]).Length)
                                .ToList();
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
                            extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Smallest][currentColumnName] =
                                minValue;
                        }
                    }
                    if (
                        !string.IsNullOrEmpty(
                            Convert.ToString(
                                extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Largest][currentColumnName])))
                    {
                        var lengthOfCells1 =
                            (from DataRow row in itemSourceDataTable.Rows
                             select Convert.ToString(row[currentColumnName]).Length)
                                .ToList();
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
                            extendedDataGrrid.RowSummariesTable.Rows[ExtendedDataGrid.Largest][currentColumnName] =
                                maxValue;
                        }
                    }
                }
            }
        }
        private void RowSummariesGridLoaded(object sender, RoutedEventArgs e)
        {
            var datagrid = (DataGrid) sender;
            var parentGrid = FindControls.FindParent<ExtendedDataGrid>(datagrid);
           
               
            if (parentGrid!=null)
            {
                if (parentGrid.RowSummariesGrid != null) return;
                var styleHeader = (Style)parentGrid.FindResource("RowSummariesHeader");
                datagrid.ColumnHeaderStyle = styleHeader;
                
                parentGrid.RowSummariesGrid = datagrid;
                parentGrid.RowSummariesTable.DefaultView.ListChanged += parentGrid.DefaultViewListChanged;
                var sortedColumn = parentGrid.Columns.ToList();
                DataTable dt=new DataTable();
                foreach (var column in sortedColumn.OrderBy(c=>c.DisplayIndex))
                {
                    if (!dt.Columns.Contains(column.SortMemberPath))
                      dt.Columns.Add(column.SortMemberPath);
                   datagrid.Columns.Add(new DataGridTextColumn { SortMemberPath = column.SortMemberPath, DisplayIndex = column.DisplayIndex, Visibility = column.Visibility, Width = column.Width });
                }
                var row = dt.NewRow();
                dt.Rows.Add(row);
                datagrid.ItemsSource = dt.DefaultView;
                var summaryRow = (StackPanel)(datagrid.Parent);
                if (summaryRow != null)
                    summaryRow.Visibility = parentGrid.ShowRowSummaries ? Visibility.Visible : Visibility.Collapsed;

                parentGrid.LoadRowSummaries();
            }

            datagrid.AutoGenerateColumns = true;
          
        }


        private void RowSplitterLoaded(object sender, RoutedEventArgs e)
        {
            var grid = FindControls.FindParent<ExtendedDataGrid>(sender as Rectangle);
            if(grid!=null)
            {
                grid.RowSplitter = sender as Rectangle;
                if (grid.FrozenRowCount <= 0)
                {
                    if (grid.RowSplitter != null) grid.RowSplitter.Visibility = Visibility.Collapsed;
                    return;
                }
                if (grid.RowSplitter != null) grid.RowSplitter.Visibility = Visibility.Visible;
                ;
                var converter = new FrozenRowSplitterMarginConverter();
                var values = new object[] { grid.NonFrozenRowsViewportVerticalOffset, grid };
                if (grid.RowSplitter != null)
                    grid.RowSplitter.Margin=(Thickness) converter.Convert(values, null, null, null);
            }
        }

        private void ClearSummaries(object sender, RoutedEventArgs e)
        {
           
            var clearButton = (Button)sender;
            var popup = (Popup)((System.Windows.Controls.StackPanel)(clearButton.Parent)).Parent;
            var mainGrid = FindControls.FindParent<ExtendedDataGrid>(popup);
            foreach (DataRow row in ((ExtendedDataGrid)CurrentGrid).RowSummariesTable.Rows)
            {
                row[CurrentColumn] = "";
            }
            clearButton.IsEnabled = false;
            if (mainGrid.AutoFilterHelper.CurrentSigmaListBox != null)
            {
                var itemSource = mainGrid.AutoFilterHelper.CurrentSigmaListBox.ItemsSource as ObservableCollection<CheckedListItem>;
                if (itemSource != null)
                {
                    foreach (var checkedListItem in itemSource)
                    {
                        checkedListItem.IsChecked = false;
                    }
                }
                mainGrid.AutoFilterHelper.CurrentSigmaListBox.ItemsSource = itemSource;
                mainGrid.AutoFilterHelper.CurrentSigmaListBox.Items.Refresh();
            }
        }

        private void GroupByHeaderPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;

            var column= sender as DataGridColumnHeader;
            if(column!=null)
            {
                var sp = column.Parent as StackPanel;
                if(sp!=null)
                {
                    var textBlock = FindControls.FindChild<TextBlock>(sp, "groupName");

                    if(textBlock!=null)
                    {
                        var columnName = Convert.ToString(textBlock.Tag);
                        var grid = FindControls.FindParent<ExtendedDataGrid>(column);
                        var sortArrow = FindControls.FindChild<Path>(sp, "SortArrow");
                        if(grid!=null && sortArrow!=null)
                        {
                            var count = grid.GroupByCollection.Count(gc => gc.SortMemberPath == columnName);
                            if(count>0)
                            {
                                var item = grid.GroupByCollection.First(gc => gc.SortMemberPath == columnName);
                                var realColumn = grid.Columns.First(c => c.SortMemberPath == columnName);
                                switch (item.SortDirection)
                                {
                                    case "Ascending":
                                        column.Tag=item.SortDirection = "Descending";
                                        sortArrow.Visibility = Visibility.Visible;

                                        realColumn.SortDirection = ListSortDirection.Descending;
                                        
                                        break;
                                    case "":
                                        column.Tag = item.SortDirection = "Ascending";
                                        sortArrow.Visibility = Visibility.Visible;
                                        realColumn.SortDirection = ListSortDirection.Ascending;
                                        break;
                                    case "Descending":
                                        column.Tag = item.SortDirection = "";
                                        sortArrow.Visibility = Visibility.Collapsed;
                                        realColumn.SortDirection = null;
                                        break;
                                }
                            }
                        }
                    }

                }
            }
        }

        private void RemoveGroupByMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.OriginalSource is Path)
                {
                    var parent = ((Path)e.OriginalSource).Parent;
                    if (parent is Canvas)
                    {
                        var parentGrid = FindControls.FindParent<ExtendedDataGrid>(parent);
                        if (parentGrid != null)
                        {
                            if (parentGrid.IsGroupByColumnRemoved)
                            {
                                var stackPanel = ((Button)((Canvas)parent).Parent).Parent;
                                var textBlock = FindControls.FindChild<TextBlock>(stackPanel, "");
                                parentGrid.RaiseGroupByColumnRemoved(parentGrid.GetRowSummariesGridColumnForSortMemberPath(Convert.ToString(textBlock.Tag)));
                            }
                        }
                    }

                }
                if (e.OriginalSource is Decorator)
                {
                    var parent = ((System.Windows.Controls.Panel)((((System.Windows.Controls.ContentPresenter)((((System.Windows.Controls.Decorator)e.OriginalSource)).Child))).Content));
                    if (parent is Canvas)
                    {
                        var parentGrid = FindControls.FindParent<ExtendedDataGrid>(parent);
                        if (parentGrid != null)
                        {
                            if (parentGrid.IsGroupByColumnRemoved)
                            {
                                var stackPanel = ((Button)((Canvas)parent).Parent).Parent;
                                var textBlock = FindControls.FindChild<TextBlock>(stackPanel, "");
                                parentGrid.RaiseGroupByColumnRemoved(parentGrid.GetRowSummariesGridColumnForSortMemberPath(Convert.ToString(textBlock.Tag)));
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
             
            }
          
        }

        private void ExpanderExpanded(object sender, RoutedEventArgs e)
        {
            var grid = FindControls.FindParent<ExtendedDataGrid>((Expander) sender);
            if(grid!=null)
            {
                grid.UpdateLayout();
                grid.InvalidateArrange();
                grid.Focus();
                if (grid.Items.Count > 0)
                {
                    var scrollviewer = FindControls.FindChild<ScrollViewer>(grid, "DG_ScrollViewer");
                    if (scrollviewer != null)
                    {

                        scrollviewer.ScrollToLeftEnd();
                    }
                }
            }
        }

        private void TxtDragLoaded(object sender, RoutedEventArgs e)
        {
            var textDrag = (TextBlock) sender;
            var mainGrid = FindControls.FindParent<ExtendedDataGrid>(textDrag);
            if (mainGrid == null) return;
            if (mainGrid.ColumnsInGroupBy.Count > 0)
            {
                textDrag.Visibility=Visibility.Collapsed;
                mainGrid.ArrangeGroupBy();
            }
        }

        private void GridLoaded(object sender, RoutedEventArgs e)
        {
            CurrentGrid = (DataGrid) sender;
        }

        private void ClearGroupClick(object sender, RoutedEventArgs e)
        {
            var btnClear =  sender as FrameworkElement;
            var grid = FindControls.FindParent<ExtendedDataGrid>(btnClear);
            if(grid!=null)
            {
                var itemSource = grid.ItemsSource;
                if(itemSource!=null)
                {
                    var cvs = CollectionViewSource.GetDefaultView(itemSource);
                    if(cvs!=null)
                    {
                        cvs.GroupDescriptions.Clear();
                        grid.GroupByCollection.Clear();
                        grid.ColumnsInGroupBy.Clear();
                        cvs.Refresh();
                    }
                   
                }
            }

        }

        private void OnScroll(object sender, ScrollEventArgs e)
        {
            //Get the main grid from the source
            var mainGrid = FindControls.FindParent<ExtendedDataGrid>(sender as ScrollBar);
            if(mainGrid!=null)
            {
                //Find the row summaries Grid
                var summariesGrid = mainGrid.RowSummariesGrid;
                if(summariesGrid!=null)
                {
                    summariesGrid.UpdateLayout();
                    var scrollViewer = FindControls.FindChild<ScrollBar>(summariesGrid, "PART_HorizontalScrollBar");

                    ;
                    if (scrollViewer != null)
                    {
                        var border = VisualTreeHelper.GetChild(summariesGrid, 0) as Decorator;
                        if (border != null)
                        {
                            var scroll = border.Child as ScrollViewer;
                            if (scroll != null)
                            {
                                scroll.CanContentScroll = false;
                                scroll.ScrollToHorizontalOffset(e.NewValue);
                            }
                                
                        }
                    }
                }
            }
        }
        private void AutoFilterSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = ((TextBox) sender);
            var mainGrid = textBox.Tag as ExtendedDataGrid;
            if(mainGrid !=null)
            {
                foreach (var items in mainGrid.AutoFilterHelper.CurrentDistictValues)
                {
                    if (items.IsSelectAll == "(Select All)")
                        continue;
                    items.Hide = !Convert.ToString(items.Name).ToLower().StartsWith(textBox.Text.ToLower());
                }
            }
        }

        private void BtnGroupByClick(object sender, RoutedEventArgs e)
        {
            var mainGrid = FindControls.FindParent<ExtendedDataGrid>(sender as Button);
            var dataGridColumnHeader = FindControls.FindParent<DataGridColumnHeader>(sender as Button);
            if (mainGrid != null && dataGridColumnHeader != null)
            {
                mainGrid.ColumnsInGroupBy.Add(dataGridColumnHeader.Column);
                mainGrid.RaiseGroupByColumnAdded(dataGridColumnHeader.Column);
            }
            
        }
    }

    public class CheckedListItem : INotifyPropertyChanged
    {
        public object Name { get; set; }
        public bool IsChecked { get; set; }
        public string IsSelectAll { get; set; }
        private bool _hide;
        public bool Hide
        {
            get { return _hide; }
            set
            {
                if (_hide == value)
                    return;
                _hide = value;
                if (PropertyChanged != null)
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("Hide"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
