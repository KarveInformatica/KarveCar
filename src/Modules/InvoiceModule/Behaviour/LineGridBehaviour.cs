using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using InvoiceModule.Behaviour;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.ScrollAxis;

namespace InvoiceModule
{
    /// <summary>
    ///     This blend behaviour change the behavior of the grid.
    /// </summary>
    public class LineGridBehaviour : Behavior<SfDataGrid>
    {
        /// <summary>
        ///     This is the list of the allowed columns. If a column is not in this list.
        /// </summary>
        public static readonly DependencyProperty gridColumns = DependencyProperty.Register("GridColumns",
            typeof(List<string>), typeof(LineGridBehaviour));


        /// <summary>
        ///     This is a property for the cell presentation.
        /// </summary>
        public static readonly DependencyProperty cellPresenterItemsProperty =
            DependencyProperty.Register("CellPresenterItems", typeof(List<CellPresenterItem>),
                typeof(LineGridBehaviour), new UIPropertyMetadata(new List<CellPresenterItem>()));


        /// <summary>
        ///     DependencyProperty. ItemChangedCommand.
        /// </summary>
        public static readonly DependencyProperty ItemChangedCommandProperty =
            DependencyProperty.Register("ItemChangedCommand", typeof(ICommand), typeof(LineGridBehaviour));

        private object _editCellValue;

        private string _editedMappedName;

        /// <summary>
        ///     GridColumns Property.
        /// </summary>

        public List<string> GridColumns
        {
            set => SetValue(gridColumns, value);
            get => (List<string>) GetValue(gridColumns);
        }

        /// <summary>
        ///     CellPresenterItems Property.
        /// </summary>
        public List<CellPresenterItem> CellPresenterItems
        {
            set => SetValue(cellPresenterItemsProperty, value);
            get => (List<CellPresenterItem>) GetValue(cellPresenterItemsProperty);
        }

        /// <summary>
        ///     ItemChangedCommand Property.
        /// </summary>
        public ICommand ItemChangedCommand
        {
            set => SetValue(ItemChangedCommandProperty, value);
            get => (ICommand) GetValue(ItemChangedCommandProperty);
        }

        public RowColumnIndex _editedIndex { get; private set; }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.GridCopyOption = GridCopyOption.CopyData | GridCopyOption.CutData;
            var karve = new KarveGridCopyPaste(AssociatedObject);
            AssociatedObject.GridCopyPaste = karve;
            AssociatedObject.AutoGeneratingColumn += AssociatedObject_AutogenerateCols;
            AssociatedObject.RowValidating += OnRowValidating;
            AssociatedObject.RowValidated += RowValidated;
            AssociatedObject.CurrentCellValueChanged += dataGrid_CurrentCellValueChanged;
            AssociatedObject.CurrentCellBeginEdit += dataGrid_CurrentCellBeginEdit;
        }

        protected override void OnDetaching()
        {
            base.OnAttached();
            AssociatedObject.AutoGeneratingColumn -= AssociatedObject_AutogenerateCols;
            AssociatedObject.CurrentCellValueChanged -= dataGrid_CurrentCellValueChanged;
            AssociatedObject.CurrentCellBeginEdit -= dataGrid_CurrentCellBeginEdit;
            AssociatedObject.RowValidating -= OnRowValidating;
        }

        private void OnRowValidating(object sender, RowValidatingEventArgs args)
        {
            /*
            if (args.RowData != null && string.IsNullOrEmpty((args.RowData as OrderInfo).CustomerID))
            {
                args.ErrorMessages.Add("CustomerID", "Customer ID field should not be null or empty");
                args.IsValid = false;
            }*/
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RowValidated(object sender, RowValidatedEventArgs e)
        {
            var dataGrid = sender as SfDataGrid;
            if (dataGrid.IsAddNewIndex(e.RowIndex))
                dataGrid.Dispatcher.BeginInvoke(new Action(() =>
                {
                    dataGrid.SelectedItem = e.RowData;
                    dataGrid.ScrollInView(dataGrid.SelectionController.CurrentCellManager.CurrentRowColumnIndex);
                }));
            var command = dataGrid?.GetValue(ItemChangedCommandProperty) as ICommand;
            if (command != null && dataGrid != null)
            {
                IDictionary<string, object> objectName = new Dictionary<string, object>();
                objectName["ChangedValue"] = e.RowData;
                // objectName["PreviousValue"] = lastChangedRow;
                //objectName["Operation"] = GridOp.Update;
                objectName["DeletedItems"] = false;
                // objectName["LastRowId"] = dataGrid.;
                // lastChangedRow = dataGrid.Get;
                command.Execute(objectName);
            }
        }

        private void dataGrid_CurrentCellBeginEdit(object sender, CurrentCellBeginEditEventArgs e)
        {
            _editedIndex = e.RowColumnIndex;
            var recordIndex = AssociatedObject.ResolveToRecordIndex(e.RowColumnIndex.RowIndex);
            var columnIndex = AssociatedObject.ResolveToGridVisibleColumnIndex(e.RowColumnIndex.ColumnIndex);
            _editedMappedName = AssociatedObject.Columns[columnIndex].MappingName;
            var record = AssociatedObject.View.Records.GetItemAt(recordIndex);
            _editCellValue = AssociatedObject.View.GetPropertyAccessProvider().GetValue(record, _editedMappedName);
        }

        private void dataGrid_CurrentCellValueChanged(object sender, CurrentCellValueChangedEventArgs args)
        {
            var colIndex = args.RowColumnIndex;
            var recordIndex = AssociatedObject.ResolveToRecordIndex(args.RowColumnIndex.RowIndex);
            var columnIndex = AssociatedObject.ResolveToGridVisibleColumnIndex(args.RowColumnIndex.ColumnIndex);
            var mappingName = AssociatedObject.Columns[columnIndex].MappingName;
            var record = AssociatedObject.View.Records.GetItemAt(recordIndex);
            var cellValue = AssociatedObject.View.GetPropertyAccessProvider().GetValue(record, mappingName);
            var gridChangedVector = new GridChangedVector
            {
                ChangedValue = cellValue,
                PreviousValue = _editCellValue,
                SourceView = AssociatedObject.ItemsSource,
                RowVector = columnIndex,
                EditMappedName = AssociatedObject.Columns[columnIndex].MappingName
            };
            var dataGrid = sender as SfDataGrid;
            if (dataGrid?.GetValue(ItemChangedCommandProperty) is ICommand command)
            {
                IDictionary<string, object> objectName = new Dictionary<string, object>();
                objectName["ChangedValue"] = gridChangedVector;
                objectName["DeletedItems"] = false;
                command.Execute(objectName);
            }
        }

        private void AssociatedObject_AutogenerateCols(object sender, AutoGeneratingColumnArgs e)
        {
            var value = e.Column.MappingName;
            if (CellPresenterItems == null)
                return;

            var navigationAwareItem = CellPresenterItems.FirstOrDefault(x => x.MappingName == e.Column.MappingName);
            if (navigationAwareItem != null)
            {
                try
                {
                    /*
                     *  if the data template is not null. we shall apply the template.
                     */
                    if (!string.IsNullOrEmpty(navigationAwareItem.DataTemplateName))
                    {
                        var resource =
                            AssociatedObject.FindResource(navigationAwareItem.DataTemplateName) as DataTemplate;
                        if (resource != null) e.Column.CellTemplate = resource;
                    }

#pragma warning disable 0168
                }
                catch (ResourceReferenceKeyNotFoundException ex)
                {
                    // we skip the value to find.
                }
#pragma warning restore 0168
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        ///     CellPresenterItem. This is a class for presenting a cell.
        /// </summary>
        public class CellPresenterItem
        {
            // Set or get the name of the mapping 
            public string MappingName { set; get; }

            /// <summary>
            ///     Name of the cell in display mode.
            /// </summary>
            public string DataTemplateName { set; get; }

            /// <summary>
            ///     Set or Get if the field is readonly
            /// </summary>
            public bool IsReadOnly { set; get; }

            /// <summary>
            ///     Name of the cell in edit mode.
            /// </summary>
            public string EditTemplateName { get; set; }

            public ICommand ChangedItem { set; get; }
        }

        /// <summary>
        ///     NavigationAwareItem. It is a class for generating the line and associate navigation
        /// </summary>
        public class NavigationAwareItem : CellPresenterItem
        {
            /// <summary>
            ///     Set or Get the action to execute.
            /// </summary>
            public ICommand Action { set; get; }

            /// <summary>
            ///     Set or get the region name to navigate to
            /// </summary>
            public string RegionName { set; get; }
        }

        /// <summary>
        ///     This a dictionary of paramteres to be changed
        /// </summary>
        public class GridChangedVector
        {
            /// <summary>
            ///     SourceView view of the source
            /// </summary>
            public object SourceView { set; get; }

            /// <summary>
            ///     Value changed
            /// </summary>
            public object ChangedValue { set; get; }

            /// <summary>
            ///     Row changed
            /// </summary>
            public long RowVector { set; get; }

            /// <summary>
            ///     PreviousValue
            /// </summary>
            public object PreviousValue { get; set; }

            public string EditMappedName { get; internal set; }
        }
    }
}