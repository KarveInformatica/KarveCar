using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using Syncfusion.Data;
using Syncfusion.Data.Extensions;
using Syncfusion.UI.Xaml.Grid;

namespace InvoiceModule.Behaviour
{
    /// <summary>
    ///     This is copy paste behaviour for the grids.
    /// </summary>
    public class KarveGridCopyPaste : GridCutCopyPaste
    {
        public KarveGridCopyPaste(SfDataGrid sfgrid)
            : base(sfgrid)
        {
        }

        protected override void PasteTextToRow()
        {
            IDataObject dataObject = null;
            dataObject = Clipboard.GetDataObject();
            var clipBoardContent = dataObject.GetData(DataFormats.UnicodeText) as string;
            var records = Regex.Split(clipBoardContent, @"\r\n");
            if (dataGrid.SelectionUnit == GridSelectionUnit.Row)
            {
                dataGrid.Focus();
                var isAddNewRow =
                    dataGrid.IsAddNewIndex(dataGrid.SelectionController.CurrentCellManager.CurrentRowColumnIndex
                        .RowIndex);

                //Checking for row is AddNewRow.
                if (isAddNewRow)
                {
                    if (!dataGrid.View.IsAddingNew)
                        return;

                    var record = Regex.Split(records[0], @"\t");
                    var provider = dataGrid.View.GetPropertyAccessProvider();
                    var rowData = (dataGrid.View as CollectionViewAdv).CurrentAddItem;

                    //Paste the copied row in each cell.
                    foreach (var column in dataGrid.Columns)
                    {
                        var cellText = provider.GetValue(rowData, column.MappingName);
                        if (cellText == null)
                        {
                            var typeInfos = dataGrid.View.GetItemProperties();
                            var typeInfo = typeInfos.GetPropertyDescriptor(column.MappingName);
                        }

                        CommitValue(rowData, column, provider, record[dataGrid.Columns.IndexOf(column)]);
                    }
                }
            }
            else
            {
                base.PasteTextToRow();
            }
        }

        protected override void PasteToRows(object clipboardrows)
        {
            var copiedRecord = (string[]) clipboardrows;
            var copiedrecordscount = copiedRecord.Count();
            //Based on the clipboard count added the new record to be pasted.
            if (copiedrecordscount > 0)
                for (var i = 0; i < copiedrecordscount; i++)
                {
                    // Creates new record.
                    dataGrid.View.AddNew();
                    for (var j = 0; j < dataGrid.Columns.Count; j++)
                    {
                        var record = copiedRecord[i];
                        var splitRecord = Regex.Split(record, @"\t");
                        //Adds the new record by using the PasteToCell method, by passing the
                        //created data, particular column, and clipboard value.
                        PasteToCell(dataGrid.View.CurrentAddItem, dataGrid.Columns[j], splitRecord[j]);
                    }

                    // Commits the pasted record.
                    dataGrid.View.CommitNew();
                }
        }
    }
}