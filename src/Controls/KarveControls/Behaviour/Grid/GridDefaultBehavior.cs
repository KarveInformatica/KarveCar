using Syncfusion.UI.Xaml.Grid;

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
            this.AssociatedObject.SizeChanged += GridDefaultBehavior_SizeChanged;
        }
        protected override void OnCleanup()
        {
            this.AssociatedObject.SizeChanged -= GridDefaultBehavior_SizeChanged;
        }

    }
}
