using System.Collections.Generic;
using System.Linq;
using Syncfusion.UI.Xaml.Grid;
using System.Windows.Input;
using System.Windows;
using Syncfusion.UI.Xaml.ScrollAxis;
using System;
using KarveControls.Behaviour.Grid;
using System.Collections.ObjectModel;
using System.Windows.Media;
using KarveDataServices.DataTransferObject;
using System.Collections.Specialized;
using KarveDataServices;

namespace KarveControls.Behaviour
{
    /// <summary>
    ///  This blend behaviour change the behavior of the grid.
    ///  
    /// </summary>
    public class LineGridBehaviour : KarveBehaviorBase<SfDataGrid>
    {
        
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
            set => SetValue(gridColumns, value);
            get => (ICollection<string>)GetValue(gridColumns);
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
            set => SetValue(cellPresenterItemsProperty, value);
            get => (ObservableCollection<CellPresenterItem>)GetValue(cellPresenterItemsProperty);
        }

        public static readonly DependencyProperty relatedItemsProperty = DependencyProperty.Register("IResolver", typeof(IResolver), typeof(LineGridBehaviour));

        public IResolver Resolver
        {
            set => SetValue(relatedItemsProperty, value);
            get => (IResolver)GetValue(relatedItemsProperty);

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
            set => SetValue(ItemChangedCommandProperty, value);
            get => (ICommand)GetValue(ItemChangedCommandProperty);
        }


     
        public static readonly DependencyProperty DataObjectProperty = DependencyProperty.Register("DataObject", typeof(object), typeof(LineGridBehaviour));

        /// <summary>
        ///  ItemChangedCommand Property.
        /// </summary>
        public object DataObject
        {
            set => SetValue(DataObjectProperty, value);
            get => GetValue(DataObjectProperty);
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
            // AssociatedObject.CurrentCellValueChanged += dataGrid_CurrentCellValueChanged;
            AssociatedObject.CurrentCellBeginEdit += dataGrid_CurrentCellBeginEdit;
            
            this.AssociatedObject.CurrentCellEndEdit += dataGridCellEndEdit;
            this.AssociatedObject.RecordDeleting += dataGrid_RecordDeleting;
            this.AssociatedObject.RecordDeleted += AssociatedObject_RecordDeleted;
        
            
        }

 
        private void AssociatedObject_RecordDeleted(object sender, RecordDeletedEventArgs e)
        {
            var v = this.AssociatedObject.ItemsSource;
            var command = ItemChangedCommand as ICommand;
            if ((command != null))
            {
                IDictionary<string, object> objectName = new Dictionary<string, object>();
                objectName["ChangedValue"] = v;
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
           // var resolver = Resolver;

//            resolver.ResolveReference(editCellValue, );


        }

        protected override void OnCleanup()
        {
            base.OnAttached();
          
            this.AssociatedObject.AutoGeneratingColumn -= AssociatedObject_AutogenerateCols;
          
            this.AssociatedObject.CurrentCellBeginEdit -= dataGrid_CurrentCellBeginEdit;
            this.AssociatedObject.RowValidating -= OnRowValidating;
            this.AssociatedObject.RecordDeleting -= dataGrid_RecordDeleting;
            
        }
        void OnRowValidating(object sender, RowValidatingEventArgs args)
        {
            if (args.RowData is BookingItemsDto dto)
            {
                var item = dto;
                
            }
            var command = ItemChangedCommand as ICommand;
            if ((command != null))
            {
                IDictionary<string, object> objectName = new Dictionary<string, object>();
                objectName["ChangedValue"] = this.AssociatedObject.ItemsSource;
                command.Execute(objectName);
            }
           
/*
            if (args.RowData != null && string.IsNullOrEmpty((args.RowData as OrderInfo).CustomerID))
            {
                args.ErrorMessages.Add("CustomerID", "Customer ID field should not be null or empty");
                args.IsValid = false;
            }*/

        }
        void RowValidated(object sender, RowValidatedEventArgs e)
        {
            
            SfDataGrid dataGrid = sender as SfDataGrid;
            BaseDto dto = e.RowData as BaseDto;
            if (dataGrid.IsAddNewIndex(e.RowIndex))
            {
               dataGrid.Dispatcher.BeginInvoke(new Action(() =>
                {
                    dataGrid.SelectedItem = e.RowData;
                    dataGrid.ScrollInView(dataGrid.SelectionController.CurrentCellManager.CurrentRowColumnIndex);
                }));
                if (dto != null)
                {
                    dto.IsDirty = true;
                    dto.IsNew = true;
                }
            }
          
          
        }
        private void dataGrid_CurrentCellBeginEdit(object sender, CurrentCellBeginEditEventArgs e)
        {
            _editedIndex = e.RowColumnIndex;
            var recordIndex = this.AssociatedObject.ResolveToRecordIndex(e.RowColumnIndex.RowIndex);
            var columnIndex = this.AssociatedObject.ResolveToGridVisibleColumnIndex(e.RowColumnIndex.ColumnIndex);
           _editedMappedName = this.AssociatedObject.Columns[columnIndex].MappingName;
            var record = this.AssociatedObject.View.Records.GetItemAt(recordIndex);
          var  _editCellValue = this.AssociatedObject.View.GetPropertyAccessProvider().GetValue(record, _editedMappedName);


          

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
                                   
                                    if (e.Column is GridCheckBoxColumn)
                                    {
                                        return;
                                    }
                                    e.Column.CellTemplate = resource;   
                                    // here in data template i shall find the button.
                                 

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
