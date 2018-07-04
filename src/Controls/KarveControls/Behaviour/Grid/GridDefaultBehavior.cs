using System;
using System.Windows.Input;
using Syncfusion.UI.Xaml.Grid;
using System.Windows;
using Syncfusion.UI.Xaml.Grid.Helpers;

namespace KarveControls.Behaviour.Grid
{
    public class GridDefaultBehavior: KarveBehaviorBase<SfDataGrid>
    {

        /// <summary>
        ///  this is needed for adapting the sfgrid directly to the tabitem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridDefaultBehavior_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
              SfDataGrid grid = sender as SfDataGrid;
              grid.ColumnSizer = GridLengthUnitType.Star;
              grid.GridColumnSizer.Refresh();
        }
        protected override void OnSetup()
        {
            this.AssociatedObject.RecordDeleting += dataGrid_RecordDeleting;
            this.AssociatedObject.SizeChanged += GridDefaultBehavior_SizeChanged;
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
            this.AssociatedObject.ColumnSizer = GridLengthUnitType.Star;
            this.AssociatedObject.CurrentCellValueChanged += AssosciatedObject_CurrentCellValueChanged;
        }
        void AssosciatedObject_CurrentCellValueChanged(object sender, Syncfusion.UI.Xaml.Grid.CurrentCellValueChangedEventArgs args)
        {
            int columnIndex = this.AssociatedObject.ResolveToGridVisibleColumnIndex(args.RowColumnIndex.ColumnIndex);

                this.AssociatedObject.GetValidationHelper().SetCurrentRowValidated(false);
            
        }
        private void AssociatedObject_PreviewKeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.ColumnSizer = GridLengthUnitType.Star;
           
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
        

        protected override void OnCleanup()
        {
            this.AssociatedObject.RecordDeleting -= dataGrid_RecordDeleting;
            this.AssociatedObject.SizeChanged -= GridDefaultBehavior_SizeChanged;
            this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
        }

    }
}
