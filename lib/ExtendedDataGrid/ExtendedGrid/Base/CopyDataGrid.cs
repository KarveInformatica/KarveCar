using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;

namespace ExtendedGrid.Base
{
    public class CopyDg : CustomDg
    {
        static CopyDg()
        {
            CommandManager.RegisterClassCommandBinding(
                typeof (CopyDg),
                new CommandBinding(ApplicationCommands.Paste,
                                   OnExecutedPaste,
                                   OnCanExecutePaste));
        }

        #region Clipboard Paste

        private static void OnCanExecutePaste(object target, CanExecuteRoutedEventArgs args)
        {
            ((CopyDg) target).OnCanExecutePaste(args);
        }

        /// <summary>
        /// This virtual method is called when ApplicationCommands.Paste command query its state.
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnCanExecutePaste(CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
            args.Handled = true;
        }

        private static void OnExecutedPaste(object target, ExecutedRoutedEventArgs args)
        {
            ((CopyDg) target).OnExecutedPaste(args);
        }

        /// <summary>
        /// This virtual method is called when ApplicationCommands.Paste command is executed.
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnExecutedPaste(ExecutedRoutedEventArgs args)
        {
            Debug.WriteLine("OnExecutedPaste begin");

            // parse the clipboard data            
            List<string[]> rowData = Classes.ClipboardHelper.ParseClipboardData();

            // call OnPastingCellClipboardContent for each cell
            int minRowIndex = Items.IndexOf(CurrentItem);
            int maxRowIndex = Items.Count - 1;
            int minColumnDisplayIndex = (SelectionUnit != DataGridSelectionUnit.FullRow)
                                            ? Columns.IndexOf(CurrentColumn)
                                            : 0;
            int maxColumnDisplayIndex = Columns.Count - 1;
            int rowDataIndex = 0;
            for (int i = minRowIndex; i <= maxRowIndex && rowDataIndex < rowData.Count; i++, rowDataIndex++)
            {
                int columnDataIndex = 0;
                for (int j = minColumnDisplayIndex;
                     j <= maxColumnDisplayIndex && columnDataIndex < rowData[rowDataIndex].Length;
                     j++, columnDataIndex++)
                {
                    DataGridColumn column = ColumnFromDisplayIndex(j);
                    column.OnPastingCellClipboardContent(Items[i], rowData[rowDataIndex][columnDataIndex]);
                }
            }
        }
        #endregion Clipboard Paste
    }
}
