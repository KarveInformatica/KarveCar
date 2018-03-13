using Syncfusion.Data;
using Syncfusion.Data.Extensions;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace InvoiceModule.Behaviour
{
    /// <summary>
    ///  This is copy paste behaviour for the grids.
    /// </summary>
    public class KarveGridCopyPaste : GridCutCopyPaste
    {

        public KarveGridCopyPaste(SfDataGrid sfgrid)
            : base(sfgrid)
        {
        }
        protected override void PasteTextToRow()
        {
            System.Windows.IDataObject dataObject = null;
            dataObject = Clipboard.GetDataObject();
            var clipBoardContent = dataObject.GetData(DataFormats.UnicodeText) as string;
            string[] records = Regex.Split(clipBoardContent.ToString(), @"\r\n");
            if (dataGrid.SelectionUnit == GridSelectionUnit.Row)
            {
                dataGrid.Focus();
                bool isAddNewRow = this.dataGrid.IsAddNewIndex(this.dataGrid.SelectionController.CurrentCellManager.CurrentRowColumnIndex.RowIndex);

                //Checking for row is AddNewRow.
                if (isAddNewRow)
                {
                    if (!this.dataGrid.View.IsAddingNew)
                        return;

                    string[] record = Regex.Split(records[0], @"\t");
                    var provider = this.dataGrid.View.GetPropertyAccessProvider();
                    var rowData = (this.dataGrid.View as CollectionViewAdv).CurrentAddItem;

                    //Paste the copied row in each cell.
                    foreach (var column in this.dataGrid.Columns)
                    {
                        var cellText = provider.GetValue(rowData, column.MappingName);
                        if (cellText == null)
                        {
                            PropertyDescriptorCollection typeInfos = this.dataGrid.View.GetItemProperties();
                            var typeInfo = typeInfos.GetPropertyDescriptor(column.MappingName);
                        }
                        CommitValue(rowData, column, provider, record[this.dataGrid.Columns.IndexOf(column)]);
                    }
                }
            }
            else
                base.PasteTextToRow();
        }
    
        protected override void PasteToRows(object clipboardrows)
        {
            var copiedRecord = (string[])clipboardrows;
            int copiedrecordscount = copiedRecord.Count();
            //Based on the clipboard count added the new record to be pasted.
            if (copiedrecordscount > 0)
            {
                for (int i = 0; i < copiedrecordscount; i++)
                {
                    // Creates new record.
                    this.dataGrid.View.AddNew();
                    for (int j = 0; j < this.dataGrid.Columns.Count; j++)
                    {
                        var record = copiedRecord[i];
                        string[] splitRecord = Regex.Split(record, @"\t");
                        //Adds the new record by using the PasteToCell method, by passing the
                        //created data, particular column, and clipboard value.
                        this.PasteToCell(this.dataGrid.View.CurrentAddItem, this.dataGrid.Columns[j], splitRecord[j]);
                    }
                    // Commits the pasted record.
                    this.dataGrid.View.CommitNew();
                }
            }
        }
    }
    
}
