using KarveDataServices.DataTransferObject;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace KarveControls.Behaviour
{
    /// <summary>
    ///  GridInsertionBehaviour. This is a behaviour for the grid.
    /// </summary>
    public class MagnifierGridBehavior: KarveBehaviorBase<SfDataGrid>
    {
        public static readonly DependencyProperty showCommandProperty = DependencyProperty.Register("ShowCommand", typeof(ICommand), typeof(MagnifierGridBehavior));

        public ICommand ShowCommand
        {
            get
            {
                return (ICommand) GetValue(showCommandProperty);
            }
            set
            {
                SetValue(showCommandProperty, value);
            }
        }

        protected override void OnSetup() {
            this.AssociatedObject.CurrentCellBeginEdit += AssociatedObject_CurrentCellBeginEdit;

        }

        /// <summary>
        /// Cleanup the behavior.
        /// </summary>
        protected override void OnCleanup() {
            this.AssociatedObject.CurrentCellBeginEdit -= AssociatedObject_CurrentCellBeginEdit;
        }

        private void AssociatedObject_CurrentCellBeginEdit(object sender, CurrentCellBeginEditEventArgs e)

        {
            SfDataGrid grid = sender as SfDataGrid;
            if (grid != null)
            {
                var editedIndex = e.RowColumnIndex;
                var recordIndex = grid.ResolveToRecordIndex(e.RowColumnIndex.RowIndex);
                var columnIndex = grid.ResolveToGridVisibleColumnIndex(e.RowColumnIndex.ColumnIndex);
                var editedMappedName = grid.Columns[columnIndex].MappingName;
                var record = grid.View.Records.GetItemAt(recordIndex);
                var editCellValue = grid.View.GetPropertyAccessProvider().GetValue(record, editedMappedName);
                var baseDto = editCellValue as BaseDto;
                if (baseDto != null)
                {
                    baseDto.ShowCommand = ShowCommand;
                }
            }
        }
        
    }
}
