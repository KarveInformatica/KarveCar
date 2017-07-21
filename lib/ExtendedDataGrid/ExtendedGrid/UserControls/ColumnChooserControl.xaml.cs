using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using ExtendedGrid.ExtendedGridControl;

namespace ExtendedGrid.UserControls
{
    /// <summary>
    /// Interaction logic for ColumnChooserControl.xaml
    /// </summary>
    public partial class ColumnChooserControl : INotifyPropertyChanged
    {
        #region Members

        private int _checkedCount;
        private DataTable _columnChooserDataTable;
        private DataRow _draggedItem;

        #endregion

        #region Properties


        private bool CellisBeingEdited { get; set; }
        private bool IsDragging { get; set; }
        private bool Loading { get; set; }
        private ExtendedDataGrid MainGrid { get; set; }

        public DataTable ColumnChooserDataTable
        {
            get { return _columnChooserDataTable; }
            set
            {
                _columnChooserDataTable = value;
                NotifyPropertyChanged("ColumnChooserDataTable");
            }
        }

        public DataRow DraggedItem
        {
            get { return _draggedItem; }
            set
            {
                _draggedItem = value;
                NotifyPropertyChanged("DraggedItem");
            }
        }

        #endregion

        #region Constructor

        public ColumnChooserControl()
        {
            DataContext = this;
            InitializeComponent();
        }


        #endregion

        #region Methods

        public void ResetDragDrop()
        {
            IsDragging = false;
            popupDrag.IsOpen = false;
            grid.IsReadOnly = false;
            DraggedItem = null;
        }


        public T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            //get parent item
            var parentObject = VisualTreeHelper.GetParent(child);

            //we've reached the end of the tree
            if (parentObject == null) return null;

            //check if the parent matches the type we're looking for
            var parent = parentObject as T;
            return parent ?? FindParent<T>(parentObject);
        }

        private static bool ConvertVisibiltyToBool(Visibility visibility)
        {
            return visibility == Visibility.Visible;
        }

        public static int CompareColumnPosition(DataGridColumn x, DataGridColumn y)
        {
            if (x == y)
                return 0;
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                // If x is null and y is not null, y
                // is greater. 
                return -1;
            }
            // If x is not null...
            //
            if (y == null)
                // ...and y is null, x is greater.
            {
                return 1;
            }
            // ...and y is not null, compare the 
            // lengths of the two strings.
            //
            int retval = x.DisplayIndex.CompareTo(y.DisplayIndex);

            return retval != 0 ? retval : 9;
        }

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public static T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            // Confirm parent and childName are valid.  
            if (parent == null) return null;
            T foundChild = null;
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);

                // If the child is not of the request child type child  
                var childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree  
                    foundChild = FindChild<T>(child, childName);
                    // If the child is found, break so we do not overwrite the found child.    
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child's name is set for search    
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name  
                        foundChild = (T) child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T) child;
                    break;
                }
            }
            return foundChild;
        }

        private static int GetColumnIndex(IEnumerable<DataGridColumn> columns, string filedName)
        {
            var index = 0;
            foreach (var col in columns)
            {
                if (col.SortMemberPath == filedName)
                {
                    return index;
                }
                index++;
            }

            return index;
        }

        #endregion

        #region Events

        private void DataGridLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Loading = true;

                if (grid != null)
                {
                    
                    var contextMenu = FindParent<ContextMenu>(grid) ?? (ContextMenu)
                                                                       ((MenuItem) (((ColumnChooserControl) (((DockPanel) (grid.Parent)).Parent)).Parent)).Parent;
                   // contextMenu.Visibility = Visibility.Collapsed;
                    ExtendedDataGrid mainGrid = null;
                    if(contextMenu.PlacementTarget!=null)
                    {
                        mainGrid =
                        FindParent<ExtendedDataGrid>(contextMenu.PlacementTarget);
                    }
                    else
                    {
                        mainGrid = contextMenu.Tag as ExtendedDataGrid;
                    }
                    if (mainGrid != null)
                    {
                        MainGrid = mainGrid;
                        if(mainGrid.HideColumnChooser)
                        {
                            contextMenu.Visibility = Visibility.Collapsed;
                            Visibility = Visibility.Collapsed;
                            return;
                        }
                        else
                        {
                            contextMenu.Visibility = Visibility.Visible;
                            Visibility = Visibility.Visible;
                        }
                        var dt = new DataTable();
                        dt.Columns.Add("chkBox", typeof (bool));
                        dt.Columns.Add("columnHeader");
                        dt.Columns.Add("columnField");
                        var row1 = dt.NewRow();
                        row1["columnField"] = row1["columnHeader"] = "(Select All)";
                        row1["chkBox"] = false;
                        _checkedCount = 0;
                        var actualCount = 0;
                        dt.Rows.Add(row1);
                        var columnCollection = mainGrid.Columns;
                        var columns = columnCollection.ToList();
                        columns.Sort(CompareColumnPosition);
                        foreach (var column in columns)
                        {
                            if (column != null)
                            {
                                var row = dt.NewRow();
                                row["chkBox"] = ConvertVisibiltyToBool(column.Visibility);
                                row["columnHeader"] = column.Header;
                                row["columnField"] = column.SortMemberPath;
                                dt.Rows.Add(row);
                                actualCount++;
                                if (column.Visibility == Visibility.Visible)
                                {
                                    _checkedCount++;
                                }
                            }
                        }
                        if (_checkedCount == actualCount)
                            dt.AsEnumerable().First(r => Convert.ToString(r["columnHeader"]) == "(Select All)")["chkBox"
                                ] = true;
                        else
                        {
                            var row = dt.AsEnumerable().First(r => Convert.ToString(r["columnHeader"]) == "(Select All)");
                            row["chkBox"
                                ] = false;
                        }
                        ColumnChooserDataTable = dt;
                        NotifyPropertyChanged("ColumnChooserDataTable");
                      
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                Loading = false;
            }
        }

     

        public event PropertyChangedEventHandler PropertyChanged;

        private void GridSizeChanged(object sender, SizeChangedEventArgs e)
        {
            try
            {
                if (grid == null) return;
                var contextMenu = FindParent<ContextMenu>(grid);
                contextMenu.Width = grid.ActualWidth + 18;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void CheckBoxChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Loading)
                    return;
                var chkBox = sender as CheckBox;

                if (chkBox != null)
                {
                    if (!chkBox.IsFocused)
                    {
                        return;
                    }

                    var cell = FindParent<DataGridCell>(chkBox);

                    var rowOwner = FindParent<DataGridRow>(cell);
                    var filedName = Convert.ToString(((DataRowView) (rowOwner.Item)).Row.ItemArray[2]);
                    if (string.IsNullOrEmpty(filedName))
                        return;
                    var contextMenu =
                        FindParent<ContextMenu>(
                            grid);

                    var mainGrid = MainGrid;


                    if (
                        !contextMenu
                             .IsOpen)
                        return;

                    if (filedName == "(Select All)")
                    {
                        foreach (var col in mainGrid.Columns)
                        {
                            col.Visibility = chkBox.IsChecked != null && chkBox.IsChecked.Value ? Visibility.Visible : Visibility.Collapsed;
                        }
                        Loading = true;
                        foreach (DataRow dataRow in ColumnChooserDataTable.Rows)
                        {
                            if (Convert.ToString(dataRow["columnField"]) != "(Select All)")
                                dataRow["chkBox"] = chkBox.IsChecked != null && chkBox.IsChecked.Value;
                        }
                        if (chkBox.IsChecked != null && chkBox.IsChecked.Value)
                        {
                            var count = mainGrid.Columns.Count(c => ConvertVisibiltyToBool(c.Visibility));
                            _checkedCount = count;
                        }
                        else
                        {
                            _checkedCount = 0;
                        }
                        Loading = false;
                    }
                    else
                    {
                        var parentCell = FindParent<DataGridCell>(chkBox);
                        var rowparentOwner = FindParent<DataGridRow>(parentCell);
                        ColumnChooserDataTable.AsEnumerable().First(
                            r =>
                            Convert.ToString(r["columnField"]) ==
                            Convert.ToString(((DataRowView) (rowparentOwner.Item)).Row.ItemArray[2]))["chkBox"] =
                            chkBox.IsChecked != null && chkBox.IsChecked.Value;
                        if (chkBox.IsChecked != null && chkBox.IsChecked.Value)
                        {
                            _checkedCount++;
                        }
                        else
                        {
                            _checkedCount--;
                        }


                        mainGrid.Columns[GetColumnIndex(mainGrid.Columns, filedName)].Visibility =
                            chkBox.IsChecked != null && chkBox.IsChecked.Value ? Visibility.Visible : Visibility.Collapsed;
                        Loading = true;
                        var count = mainGrid.Columns.Count;

                        if (_checkedCount > count)
                            _checkedCount = count;


                        ColumnChooserDataTable.AsEnumerable().First(r => r["columnField"].ToString() == "(Select All)")[
                            "chkBox"] = _checkedCount == count;
                        Loading = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PreviewDataCellMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var cell = sender as DataGridCell;
                if (cell != null)
                {
                    if (cell.IsEditing)
                        return;
                    var rowparentOwner = FindParent<DataGridRow>(cell);
                    if (Convert.ToString(((DataRowView) (rowparentOwner.Item)).Row.ItemArray[2]) == "(Select All)")
                        return;
                   
                    if (CellisBeingEdited)
                        return;

                    popupDrag.Width = grid.ActualWidth;
                    IsDragging = true;

                    DraggedItem = ((DataRowView) cell.DataContext).Row;
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
                if ((!IsDragging && e.LeftButton != MouseButtonState.Pressed) ||
                    DraggedItem == null)
                    return;
                if (CellisBeingEdited)
                    return;

                //display the popup if it hasn't been opened yet
                if (!popupDrag.IsOpen)
                {
                    //switch to read-only mode
                    if (grid != null) grid.IsReadOnly = true;

                    //make sure the popup is visible

                    popupDrag.IsOpen = true;
                }
                //Change the position of popup with the mouse
                var popupSize = new Size(popupDrag.ActualWidth, popupDrag.ActualHeight);
                var position = e.GetPosition(popupDrag);
                position.X = position.X - 10;
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
                    var cell = sender as DataGridCell;

                    if (cell != null)
                    {
                        grid.SelectedItem = cell.DataContext;
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
            try
            {
                if (!IsDragging)
                    return;

                //get the target item
                if (grid.SelectedItem != null)
                {
                    var targetItem = ((DataRowView) grid.SelectedItem).Row;

                    if (targetItem != null && !ReferenceEquals(DraggedItem, targetItem))
                    {
                        Loading = true;
                        var row = ColumnChooserDataTable.NewRow();
                        row[0] = DraggedItem[0];
                        row[1] = DraggedItem[1];
                        row[2] = DraggedItem[2];
                        var rowToBemoved =
                            ColumnChooserDataTable.AsEnumerable().First(
                                r => Convert.ToString(r["columnField"]) == Convert.ToString(DraggedItem["columnField"]));
                        ColumnChooserDataTable.Rows.Remove(rowToBemoved);
                        var currentTargetRow = ColumnChooserDataTable.AsEnumerable().First(
                            r => Convert.ToString(r["columnField"]) == Convert.ToString(targetItem["columnField"]));
                        int targetIndex = ColumnChooserDataTable.Rows.IndexOf(currentTargetRow);
                        if (targetIndex == 0)
                            targetIndex++;

                        ColumnChooserDataTable.Rows.InsertAt(row, targetIndex);
                        var previousColumnFieldName =
                            Convert.ToString(ColumnChooserDataTable.Rows[targetIndex - 1]["columnField"]);


                        var columnCollection = MainGrid.Columns;
                        var columns = columnCollection.ToList();
                        columns.Sort(CompareColumnPosition);
                        var pos = 0;
                        columns.ForEach(c =>
                                            {
                                                c.DisplayIndex = pos;
                                                pos++;
                                            });
                        var previousVisiblePosition = previousColumnFieldName == "(Select All)"
                                                          ? 0
                                                          : MainGrid.Columns[
                                                              GetColumnIndex(MainGrid.Columns, previousColumnFieldName)
                                                                ].DisplayIndex;
                        var currentFiledName = Convert.ToString(ColumnChooserDataTable.Rows[targetIndex]["columnField"]);

                        MainGrid.Columns[GetColumnIndex(MainGrid.Columns, currentFiledName)].DisplayIndex =
                            previousVisiblePosition + 1;

                        columns.Clear();
                        columns.AddRange(columnCollection);
                        if (previousColumnFieldName == "(Select All)")
                        {
                            columns.ForEach(c =>
                                                {
                                                    if (c.SortMemberPath != currentFiledName)
                                                    {
                                                        if (c.DisplayIndex + 1 < columns.Count)
                                                            c.DisplayIndex = c.DisplayIndex + 1;
                                                        else
                                                        {
                                                            c.DisplayIndex = columns.Count - 1;
                                                        }
                                                    }
                                                });
                        }
                        else
                        {
                            columns.ForEach(c =>
                                                {
                                                    if (c.SortMemberPath != currentFiledName &&
                                                        c.SortMemberPath != previousColumnFieldName)
                                                    {
                                                        if (c.DisplayIndex + 1 < columns.Count)
                                                            c.DisplayIndex = c.DisplayIndex + 1;
                                                        else
                                                        {
                                                            c.DisplayIndex = columns.Count - 1;
                                                        }
                                                    }
                                                });
                        }

                        grid.SelectedItem = DraggedItem;
                        //Reorder row summaries after reordering column using column chosser.
                        foreach (var mainGridColumn in MainGrid.Columns)
                        {
                            var rowSummariesColumn = MainGrid.RowSummariesGrid.Columns.FirstOrDefault(column => column.SortMemberPath == mainGridColumn.SortMemberPath);
                            if(rowSummariesColumn!=null)
                            {
                                rowSummariesColumn.DisplayIndex = mainGridColumn.DisplayIndex;
                            }
                        }

                        Loading = false;
                    }
                    ResetDragDrop();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var cell = sender as DataGridCell;
                if (cell != null)
                {
                    if (Convert.ToString(cell.Content) == "(Select All)")
                    {
                        e.Handled = true;
                        return;
                    }

                    if (cell.Content is ContentPresenter)
                    {
                        if ((string) ((DataRowView) (((ContentPresenter) (cell.Content)).Content)).Row.ItemArray[1] ==
                            "(Select All)")
                        {
                            return;
                        }
                    }

                    if (cell.Column != null)
                        if (cell.Column.SortMemberPath == "chkBox")
                            return;

                    if (Convert.ToString(cell.Tag) == "editing")
                        return;
                    CellisBeingEdited = true;
                    cell.Tag = "editing";
                    var templateColumn = grid.Columns[1] as DataGridTemplateColumn;
                    if (templateColumn != null)
                        templateColumn.CellEditingTemplate = (DataTemplate) FindResource("editingTextBoxTemplate");
                    cell.IsEditing = true;
                    IsDragging = false;
                    ResetDragDrop();
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void TextBoxMouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                var tb = sender as TextBox;
                var cell = FindParent<DataGridCell>(tb);
                if (cell != null)
                {
                    CellisBeingEdited = false;
                    cell.Tag = "";
                    var templateColumn = grid.Columns[1] as DataGridTemplateColumn;
                    if (templateColumn != null)
                        templateColumn.CellEditingTemplate = null;
                    cell.IsEditing = false;
                    grid.UpdateLayout();
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void TextBoxMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void TextBoxMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void TextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var tb = sender as TextBox;
                if (tb != null)
                {
                    if (!tb.IsFocused)
                        return;
                    var cell = FindParent<DataGridCell>(tb);

                    var rowparentOwner = FindParent<DataGridRow>(cell);


                    MainGrid.Columns[
                        GetColumnIndex(MainGrid.Columns,
                                       Convert.ToString(((DataRowView) (rowparentOwner.Item)).Row.ItemArray[2]))].Header
                        = tb.Text;
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void UserControlSizeChanged(object sender, SizeChangedEventArgs e)
        {
            try
            {
                var contextMenu = FindParent<ContextMenu>(grid);
                if (ColumnChooserDataTable == null)
                    return;
                grid.UpdateLayout();
                contextMenu.Visibility = Visibility.Visible;
                contextMenu.Height = grid.ActualHeight + 18;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        #endregion

        private void TextBoxLoaded(object sender, RoutedEventArgs e)
        {
            var tb = sender as TextBox;
            if (tb != null) tb.Focus();
        }
    }
}

