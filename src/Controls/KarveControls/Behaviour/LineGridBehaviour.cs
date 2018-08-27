namespace KarveControls.Behaviour
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;

    using KarveControls.Behaviour.Grid;

    using KarveDataServices;
    using KarveDataServices.ViewObjects;

    using Syncfusion.UI.Xaml.Grid;
    using Syncfusion.UI.Xaml.Grid.Helpers;
    using Syncfusion.UI.Xaml.ScrollAxis;

    /// <summary>
    ///  This blend behaviour change the behavior of the grid.
    /// </summary>
    
    public class LineGridBehaviour : KarveBehaviorBase<SfDataGrid>
    {
        /// <summary>
        ///  Grid Check Box Column.
        /// </summary>
        private GridCheckBoxColumn _checkBox = null;
        
        /// <summary>
        ///  Grid Combo Box Column.
        /// </summary>
        private GridComboBoxColumn _comboBox= null;

        /// <summary>
        ///  This is the list of the allowed columns. If a column is not in this list.
        /// </summary>
        public static readonly DependencyProperty gridColumns = DependencyProperty.Register("GridColumns",
            typeof(ICollection<string>), typeof(LineGridBehaviour));

       /// <summary>
       ///  GridColumns.
       /// </summary>
        public ICollection<string> GridColumns
       {
           get => (ICollection<string>)GetValue(gridColumns);
           set => this.SetValue(gridColumns, value);
        }

        /// <summary>
        ///  This is a property for the cell presentation.
        /// </summary>
        /// 
        public static readonly DependencyProperty cellPresenterItemsProperty = DependencyProperty.Register("CellPresenterItems", typeof(ICollection<CellPresenterItem>), typeof(LineGridBehaviour), 
            new UIPropertyMetadata(new ObservableCollection<CellPresenterItem>()));

        /// <summary>
        ///  CellPresenterItems Property.
        /// </summary>
        public ICollection<CellPresenterItem> CellPresenterItems
        {
            get => (ObservableCollection<CellPresenterItem>)GetValue(cellPresenterItemsProperty);
            set => this.SetValue(cellPresenterItemsProperty, value);
        }

        public static readonly DependencyProperty relatedItemsProperty = DependencyProperty.Register("IResolver", typeof(IResolver), typeof(LineGridBehaviour));

        public IResolver Resolver
        {
            get => (IResolver)GetValue(relatedItemsProperty);
            set => this.SetValue(relatedItemsProperty, value);
        }

        /// <summary>
        ///  DependencyProperty. ItemChangedCommand.
        /// </summary>
        public static readonly DependencyProperty ItemChangedCommandProperty = DependencyProperty.Register("ItemChangedCommand", typeof(ICommand), typeof(LineGridBehaviour));

        /// <summary>
        ///  ItemChangedCommand Property.
        /// </summary>
        public ICommand ItemChangedCommand
        {
            get => (ICommand)GetValue(ItemChangedCommandProperty);
            set => this.SetValue(ItemChangedCommandProperty, value);
        }

        public static readonly DependencyProperty DataObjectProperty = DependencyProperty.Register("DataObject", typeof(object), typeof(LineGridBehaviour));

        /// <summary>
        ///  ItemChangedCommand Property.
        /// </summary>
        public object DataObject
        {
            get => GetValue(DataObjectProperty);
            set => this.SetValue(DataObjectProperty, value);
        }

        protected override void OnSetup()
        {

            base.OnAttached();
            AssociatedObject.GridCopyOption = GridCopyOption.CopyData | GridCopyOption.CutData;
            var karve = new KarveGridCopyPaste(AssociatedObject);
            AssociatedObject.GridCopyPaste = karve;
            AssociatedObject.AutoGeneratingColumn += AssociatedObject_AutogenerateCols;
            AssociatedObject.RowValidating += OnRowValidating;
            AssociatedObject.RowValidated += RowValidated;     
            AssociatedObject.AddNewRowInitiating += AssociatedObject_AddNewRowInitiating;
            AssociatedObject.CurrentCellBeginEdit += dataGrid_CurrentCellBeginEdit;
            this.AssociatedObject.RecordDeleting += dataGrid_RecordDeleting;
            this.AssociatedObject.RecordDeleted += AssociatedObject_RecordDeleted;
            this.AssociatedObject.CurrentCellValueChanged += this.AssociatedObject_CurrentCellValueChanged;
        }

        

        protected override void OnCleanup()
        {
            base.OnAttached();
            this.AssociatedObject.AutoGeneratingColumn -= AssociatedObject_AutogenerateCols;
            this.AssociatedObject.CurrentCellBeginEdit -= dataGrid_CurrentCellBeginEdit;
            this.AssociatedObject.RowValidating -= OnRowValidating;
            AssociatedObject.RowValidated -= RowValidated;
            this.AssociatedObject.RecordDeleting -= dataGrid_RecordDeleting;
            this.AssociatedObject.CurrentCellValueChanged -= this.AssociatedObject_CurrentCellValueChanged;


        }

        private static readonly DependencyProperty GridStateProperty =
DependencyProperty.Register("GridState", typeof(ControlExt.GridOp),
typeof(ControlExt));

        private void AssociatedObject_AddNewRowInitiating(object sender, AddNewRowInitiatingEventArgs e)
        {

          //  MessageBox.Show("Ciao baby");
          //        SetValue(GridStateProperty, ControlExt.GridOp.Insert);
             
        }

        private void AddNewRow(object sender, RoutedEventArgs e)
        {

            // Which avoid the process of committing normal rows. It only processed for AddNewRow.
            var rowIndex = this.AssociatedObject.SelectionController.CurrentCellManager.CurrentCell != null ? this.AssociatedObject.SelectionController.CurrentCellManager.CurrentCell.RowIndex : 0;
            if (this.AssociatedObject.IsAddNewIndex(rowIndex))
            {
                // Which end edit the current cell. by passing false, it commit the entered value.
                if (this.AssociatedObject.SelectionController.CurrentCellManager.CurrentCell.IsEditing)
                    this.AssociatedObject.SelectionController.CurrentCellManager.EndEdit(true);

                //Initialize row and column index after committing new row 
                var rowColumnIndex = this.AssociatedObject.SelectionController.CurrentCellManager.CurrentRowColumnIndex;
                var addNewRowController = this.AssociatedObject.GetAddNewRowController();
                addNewRowController.CommitAddNew();
                rowColumnIndex.RowIndex = addNewRowController.GetAddNewRowIndex();
                this.AssociatedObject.SelectedItems.Clear();
                //If the AddNewRowPosition is Top need to move the current cell to next row 
                if (this.AssociatedObject.AddNewRowPosition == AddNewRowPosition.Top)
                    rowColumnIndex.RowIndex = rowColumnIndex.RowIndex + 1;

                var recordIndex = this.AssociatedObject.ResolveToRecordIndex(rowColumnIndex.RowIndex);
                var record = this.AssociatedObject.View.Records.GetItemAt(recordIndex);
                BaseViewObject dto = record as BaseViewObject;
                if (dto != null)
                {
                    dto.IsNew = true;
                }

                // Which retains the current cell border in the row after canceling addnewrow as you press esc key operation.
                this.AssociatedObject.MoveCurrentCell(rowColumnIndex);
            }
        }

        private void AssociatedObject_RecordDeleted(object sender, RecordDeletedEventArgs e)
        {
            var v = this.AssociatedObject.ItemsSource;
            var command = ItemChangedCommand as ICommand;
            if ((command != null))
            {
                IDictionary<string, object> objectName = new Dictionary<string, object>();
                objectName["ChangedValue"] = v;
                objectName["Operation"] = GetValue(GridStateProperty);
                command.Execute(objectName);
            }
            
        }

 
        private void dataGridCellEndEdit(object sender, CurrentCellEndEditEventArgs e)
        {
            var recordIndex = this.AssociatedObject.ResolveToRecordIndex(e.RowColumnIndex.RowIndex);
            var columnIndex = this.AssociatedObject.ResolveToGridVisibleColumnIndex(e.RowColumnIndex.ColumnIndex);
            var editedMappedName = this.AssociatedObject.Columns[columnIndex].MappingName;
            var record = this.AssociatedObject.View.Records.GetItemAt(recordIndex);
            var editCellValue = this.AssociatedObject.View.GetPropertyAccessProvider().GetValue(record, editedMappedName);
         

        }

       

        private void AssociatedObject_CurrentCellActivated(object sender, CurrentCellActivatedEventArgs args)
        {
            var datagrid = sender as SfDataGrid;
            if (datagrid.IsAddNewIndex(args.PreviousRowColumnIndex.RowIndex))
            {
                var recordIndex = this.AssociatedObject.ResolveToRecordIndex(args.CurrentRowColumnIndex.RowIndex);
                var record = this.AssociatedObject.View.Records.GetItemAt(recordIndex);
                BaseViewObject dto = record as BaseViewObject;
                if (dto != null)
                {
                    dto.IsNew = true;
                }
            }
        }

        void OnRowValidating(object sender, RowValidatingEventArgs args)
        {
            if (args.RowData is BookingItemsViewObject dto)
            {
                dto.IsDirty = true;
            }

            var command = ItemChangedCommand as ICommand;
            if ((command != null))
            {
                var op = ControlExt.GridOp.Update;
                var rowIndex = this.AssociatedObject.ResolveToRecordIndex(args.RowIndex);

                if (rowIndex >= 0)
                {
                    if (this.AssociatedObject.IsAddNewIndex(rowIndex))
                    {
                        op = ControlExt.GridOp.Insert;
                    }

                    var record = this.AssociatedObject.View.Records[rowIndex].Data;
                    IDictionary<string, object> objectName = new Dictionary<string, object>();
                    objectName["ChangedValue"] = record;
                    objectName["Operation"] = op;
                    command.Execute(objectName);
                }
            }
           
        }

        void RowValidated(object sender, RowValidatedEventArgs e)
        {

            SfDataGrid dataGrid = sender as SfDataGrid;
            BaseViewObject dto = e.RowData as BaseViewObject;
           
            if (dataGrid.IsAddNewIndex(e.RowIndex))
            {
                dataGrid.Dispatcher.BeginInvoke(new Action(() =>
                 {
                     dataGrid.SelectedItem = e.RowData;
                     dataGrid.ScrollInView(this.AssociatedObject.SelectionController.CurrentCellManager.CurrentRowColumnIndex);
                 }));
                if (dto != null)
                {
                    dto.IsNew = true;
                }
            }

            if (dto != null)
            {
                dto.IsDirty = true;
            }
            
        }

        private void AssociatedObject_CurrentCellValueChanged(object sender, CurrentCellValueChangedEventArgs args)
        {
           
            int columnindex = this.AssociatedObject.ResolveToGridVisibleColumnIndex(args.RowColumnIndex.ColumnIndex);
            var column = this.AssociatedObject.Columns[columnindex];
            var rowIndex = this.AssociatedObject.ResolveToRecordIndex(args.RowColumnIndex.RowIndex);

            if (rowIndex >= 0)
            {
                
                var grid = sender as SfDataGrid;
                if (grid != null)
                {
                    var record = grid.View.Records[rowIndex].Data;
                    if (!(this.ItemChangedCommand is ICommand command))
                    {
                        return;
                    }

                    var op = ControlExt.GridOp.Update;
                    if (grid.IsAddNewIndex(rowIndex))
                    {
                        op = ControlExt.GridOp.Insert;
                    }

                    if (record is BaseViewObject dto)
                    {
                        dto.IsDirty = true;
                    }

                    IDictionary<string, object> objectName = new Dictionary<string, object>();
                    objectName["Operation"] = op;
                    objectName["ChangedValue"] = record;
                    command.Execute(objectName);
                }
            }
        }

        private void dataGrid_CurrentCellBeginEdit(object sender, CurrentCellBeginEditEventArgs e)
        {
            /*
             *  In case of a readonly value.
             */
            var navigationAwareItem = CellPresenterItems.FirstOrDefault<CellPresenterItem>(x => x.MappingName == e.Column.MappingName);

            if (navigationAwareItem != null)
            {
                if (navigationAwareItem.IsReadOnly)
                {
                    e.Cancel = true;
                }
            }
        }

        void dataGrid_RecordDeleting(object sender, RecordDeletingEventArgs args)
        {

            MessageBoxResult result = MessageBox.Show("Quieres borrar la linea?",
                      "Confirma",
                      MessageBoxButton.YesNo,
                      MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes)
            {
                args.Cancel = true;
            }
                
            
        }

        private void AssociatedObject_AutogenerateCols(object sender, AutoGeneratingColumnArgs e)
        {

            if (GridColumns != null)
            {
              
                var column = GridColumns.FirstOrDefault<string>(x => x == e.Column.MappingName);
                if (column == null)
                {
                    e.Cancel = true;
                }
                else
                {
                    // now shall find if we have a valid data template for the column.
                    CellPresenterItem navigationAwareItem = CellPresenterItems.FirstOrDefault<CellPresenterItem>(x => x.MappingName == e.Column.MappingName);
                    if (navigationAwareItem != null)
                    {
                        // in this case we dont want bound the cell with a template
                        // we want just to keep the mapping in the cell presenter list.
                        // It is true in case of readonly cells.
         
                        if (navigationAwareItem.NoTemplate)
                        {
                           
                            return;
                        }

                        try
                        {
                            e.Column.SetCellBoundValue = true;
                           // e.Column.IsReadOnly = true;

                            /*
                             *  if the data template is not null. we shall apply the template.
                             */

                            if (!string.IsNullOrEmpty(navigationAwareItem.DataTemplateName))
                            {
                                if (this.AssociatedObject.FindResource(navigationAwareItem.DataTemplateName) is DataTemplate resource)
                                {
                                   
                                    if (e.Column is GridCheckBoxColumn checkBoxColumn)
                                    {
                                      
                                        return;
                                    }

                                    e.Column.CellTemplate = resource;   

                                }
                            }

                        }
                        catch (System.Exception ex)
                        {
                            throw new LineGridUIException("Autogenerate Columns", ex);
                        }
                    }
                }


            }              
        }

       

        private ChildControl FindVisualChild<ChildControl>(DependencyObject DependencyObj)
            where ChildControl : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(DependencyObj); i++)
            {
                DependencyObject Child = VisualTreeHelper.GetChild(DependencyObj, i);

                if (Child != null && Child is ChildControl)
                {
                    return (ChildControl)Child;
                }
                else
                {
                    ChildControl ChildOfChild = FindVisualChild<ChildControl>(Child);

                    if (ChildOfChild != null)
                    {
                        return ChildOfChild;
                    }
                }
            }

            return null;
        }

        private string _editedMappedName;
        private object _editCellValue;
        public RowColumnIndex _editedIndex { get; private set; }
        public bool SelectionCellDone { get; private set; }
    }
}
