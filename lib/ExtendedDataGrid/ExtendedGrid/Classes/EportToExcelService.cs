using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;


namespace ExtendedGrid.Classes
{
    internal class ExportToExcelService
    {
        //[DllImport("Oleacc.dll")]
        //public static extern int AccessibleObjectFromWindow(int hwnd, uint dwObjectId, byte[] riid, ref System.Windows.Window ptr);

        public delegate bool EnumChildCallback(int hwnd, ref int lParam);

        [DllImport("User32.dll")]
        public static extern bool EnumChildWindows(int hWndParent, EnumChildCallback lpEnumFunc, ref int lParam);

        [DllImport("User32.dll")]
        public static extern int GetClassName(int hWnd, StringBuilder lpClassName, int nMaxCount);

        public static bool EnumChildProc(int hwndChild, ref int lParam)
        {
            var buf = new StringBuilder(128);
            GetClassName(hwndChild, buf, 128);
            if (buf.ToString() == "EXCEL7")
            {
                lParam = hwndChild;
                return false;
            }
            return true;
        }

        internal static void CreateExcelFromClipboard(string worksheetName, string fullFilePath, bool toOpen)
        {
            //Excel Application class 
            var app = new Application();
            //Get process id
            int excelProcessId = GetApplicationProcessId(app);

            try
            {
                //Add workbook
                Workbook theWorkbook = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                //Add worksheet
                var theWorksheet =
                    (Worksheet)theWorkbook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                string sheetName = worksheetName;
                if (worksheetName.Length > 31)
                    sheetName = worksheetName.Substring(0, 31);
                theWorksheet.Name = sheetName;
                app.SheetsInNewWorkbook = 1;
                app.DisplayAlerts = false;
                theWorksheet.Activate();

                //Paste to the worksheet from clpboard
                theWorksheet.Paste(Type.Missing, Type.Missing);
                //Apply Borders
                ApplyBorder(theWorksheet.UsedRange);

                //Auto Fit All columns
                Range xlRange = theWorksheet.UsedRange;
                // put all hardcodes in  a constant class 
                xlRange.Font.Name = "Arial";
                xlRange.Font.Size = 9;
                var firstRowRange = (Range)xlRange.Rows[1, Missing.Value];
                firstRowRange.EntireRow.Font.Bold = true;
                firstRowRange.EntireRow.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                //Set Wrap Test to false
                xlRange.WrapText = false;
                xlRange.Columns.AutoFit();
                theWorksheet.Activate();

                //Save the file
                theWorkbook.SaveAs(fullFilePath, XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing,
                                   Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange,
                                   Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                if (!toOpen)
                {
                    //Clean up 
                    app.Quit();
                    Marshal.ReleaseComObject(app);
                }
            }
            catch
            {
                ForceExcelClose(excelProcessId);
                throw;
            }
            finally
            {
                app.Visible = toOpen;
            }
        }

        internal static void CreatePdfFromClipboard(string worksheetName, string fullFilePath, bool toOpen)
        {
            //Excel Application class 
            var app = new Application();
            //Get process id
            int excelProcessId = GetApplicationProcessId(app);
            app.Visible = false;
            try
            {
                //Add workbook
                Workbook theWorkbook = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                //Add worksheet
                var theWorksheet =
                    (Worksheet)theWorkbook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                string sheetName = worksheetName;
                if (worksheetName.Length > 31)
                    sheetName = worksheetName.Substring(0, 31);
                theWorksheet.Name = sheetName;
                app.SheetsInNewWorkbook = 1;
                theWorksheet.Activate();
                app.DisplayAlerts = false;
                //Paste to the worksheet from clpboard
                theWorksheet.Paste(Type.Missing, Type.Missing);
                //Apply Borders
                ApplyBorder(theWorksheet.UsedRange);

                //Auto Fit All columns
                Range xlRange = theWorksheet.UsedRange;
                // put all hardcodes in  a constant class 
                xlRange.Font.Name = "Arial";
                xlRange.Font.Size = 9;
                var firstRowRange = (Range)xlRange.Rows[1, Missing.Value];
                firstRowRange.EntireRow.Font.Bold = true;
                firstRowRange.EntireRow.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                //Set Wrap Test to false
                xlRange.WrapText = false;
                xlRange.Columns.AutoFit();
                theWorksheet.Activate();

                //Save the file
                string xcelFile = Path.Combine(Path.GetTempPath(),
                                               Path.GetFileNameWithoutExtension(fullFilePath) + ".xlsx");
                theWorkbook.SaveAs(xcelFile, XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing,
                                   Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange,
                                   Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                theWorksheet.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, fullFilePath,
                                                 XlFixedFormatQuality.xlQualityStandard, true, false, Missing.Value,
                                                 Missing.Value, toOpen, Missing.Value);


                //Clean up 
                app.Quit();
                Marshal.ReleaseComObject(app);
                File.Delete(xcelFile);
            }
            catch
            {
                MessageBox.Show(
                  "Please add 2007 Microsoft Office Add-in: Microsoft Save as PDF or XPS , dowload it from this location http://www.microsoft.com/download/en/details.aspx?id=7",
                  "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                ForceExcelClose(excelProcessId);
                throw;
            }
        }

        internal static void CreateCsvFromClipboard(string workSheetName, string fullFilePath, bool toOpen)
        {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(fullFilePath);
                string clipboardText = Clipboard.GetText();
                if (clipboardText.Contains(","))
                {
                    string[] splitted = clipboardText.Split(',');
                    for (int i = 0; i < splitted.Length; i++)
                    {
                        if (i == 0)
                        {
                            var current = splitted[i];
                            var lastIndex = current.LastIndexOf("\t", StringComparison.Ordinal);
                            if (lastIndex != -1)
                            {
                                current = current.Insert(lastIndex + 1, "\"");
                                splitted[i] = current;
                            }
                        }
                        else
                        {
                            var current = splitted[i];
                            int firstIndex = current.IndexOf("\t", StringComparison.Ordinal);
                            if (firstIndex != -1)
                            {
                                current = current.Insert(firstIndex, "\"");
                                splitted[i] = current;
                            }
                            int lastIndex = current.LastIndexOf("\t", StringComparison.Ordinal);
                            if (lastIndex != -1)
                            {
                                current = current.Insert(lastIndex + 1, "\"");
                                splitted[i] = current;
                            }
                        }
                    }
                    if (splitted.Length > 1)
                    {
                        string modifiedText = "";
                        int index = 0;
                        foreach (string s in splitted)
                        {
                            if (index == 0)
                            {
                                modifiedText = modifiedText + s;
                            }
                            else
                            {
                                modifiedText = modifiedText + "," + s;
                            }

                            index++;
                        }
                        clipboardText = modifiedText;
                    }
                }
                clipboardText = clipboardText.Replace("	", ",");
                sw.Write(clipboardText);

            }
            finally
            {
                if (sw != null) sw.Close();
                Process.Start(fullFilePath);
            }
        }

        private static int GetApplicationProcessId(_Application excelApp)
        {
            int excelPid = -1;
            //
            // Get the Excel instance's process ID...used later
            // to prevent orphaned Excel processes.
            //
            Process[] aProcesses = Process.GetProcesses();
            for (int i = 0; i <= aProcesses.GetUpperBound(0); i++)
            {
                if (aProcesses[i].MainWindowHandle.ToString() == excelApp.Hwnd.ToString(CultureInfo.InvariantCulture))
                {
                    excelPid = aProcesses[i].Id;
                    break;
                }
            }


            return excelPid;
        }

        private static void ForceExcelClose(int excelPid)
        {
            Process[] aProcesses = Process.GetProcesses();
            Process aProcess = null;

            //
            // Look for an Excel process matching the one we started.
            //
            for (int i = 0; i <= aProcesses.GetUpperBound(0); i++)
            {
                if (aProcesses[i].Id == excelPid)
                {
                    aProcess = aProcesses[i];
                    break;
                }
            }

            //
            // If we found a matching Excel proceess with no main window
            // associated main window, kill it.
            //
            if (aProcess != null)
            {
                if (aProcess.ProcessName.ToUpper() == "EXCEL")
                {
                    if (!aProcess.HasExited)
                    {
                        aProcess.Kill();
                    }
                }
            }
        }

        internal static string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            while (dividend > 0)
            {
                int modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo) + columnName;
                dividend = (dividend - modulo) / 26;
            }
            return columnName;
        }

        internal static void ClearBorder(Range range)
        {
            if (range == null)
                return;

            range.Borders[XlBordersIndex.xlDiagonalDown].LineStyle = Constants.xlNone;
            range.Borders[XlBordersIndex.xlDiagonalUp].LineStyle = Constants.xlNone;
            Array xlBorderArray = Enum.GetValues(typeof(XlBordersIndex));
            foreach (object xlBorder in xlBorderArray)
            {
                switch ((XlBordersIndex)xlBorder)
                {
                    case XlBordersIndex.xlInsideHorizontal:
                    case XlBordersIndex.xlInsideVertical:
                    case XlBordersIndex.xlEdgeRight:
                    case XlBordersIndex.xlEdgeBottom:
                    case XlBordersIndex.xlEdgeTop:
                    case XlBordersIndex.xlEdgeLeft:
                        range.Borders[(XlBordersIndex)xlBorder].LineStyle =
                            Constants.xlNone;
                        break;
                }
            }
        }

        internal static void ApplyBorder(Range usedRange)
        {
            if (usedRange == null)
                return;

            usedRange.Borders[XlBordersIndex.xlDiagonalDown].LineStyle = Constants.xlNone;
            usedRange.Borders[XlBordersIndex.xlDiagonalUp].LineStyle = Constants.xlNone;
            Array xlBorderArray = Enum.GetValues(typeof(XlBordersIndex));
            foreach (object xlBorder in xlBorderArray)
            {
                switch ((XlBordersIndex)xlBorder)
                {
                    case XlBordersIndex.xlInsideHorizontal:
                    case XlBordersIndex.xlInsideVertical:
                    case XlBordersIndex.xlEdgeRight:
                    case XlBordersIndex.xlEdgeBottom:
                    case XlBordersIndex.xlEdgeTop:
                    case XlBordersIndex.xlEdgeLeft:
                        usedRange.Borders[(XlBordersIndex)xlBorder].LineStyle = XlLineStyle.xlContinuous;
                        usedRange.Borders[(XlBordersIndex)xlBorder].ColorIndex =
                            Constants.xlAutomatic;
                        usedRange.Borders[(XlBordersIndex)xlBorder].TintAndShade = 0;
                        usedRange.Borders[(XlBordersIndex)xlBorder].Weight = XlBorderWeight.xlThin;
                        break;
                }
            }
        }

        internal static void CreateExcelFromClipboard(string workSheetName, string fullFilePath,
                                                      ExcelTableStyle excelTableStyle, bool toOpen)
        {
            //Excel Application class 
            var app = new Application();

            //Get process id
            int excelProcessId = GetApplicationProcessId(app);

            app.DisplayAlerts = false;
            try
            {
                //Add workbook
                Workbook theWorkbook = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                //Add worksheet
                var theWorksheet =
                    (Worksheet)theWorkbook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                string sheetName = workSheetName;
                if (workSheetName.Length > 31)
                    sheetName = workSheetName.Substring(0, 31);
                theWorksheet.Name = sheetName;
                app.SheetsInNewWorkbook = 1;
                theWorksheet.Activate();
                //Paste to the worksheet from clpboard
                theWorksheet.Paste(Type.Missing, Type.Missing);
                //Apply Borders
                ApplyBorder(theWorksheet.UsedRange);
                //Auto Fit All columns
                Range xlRange = theWorksheet.UsedRange;
                // put all hardcodes in  a constant class 
                xlRange.Font.Name = "Arial";
                xlRange.Font.Size = 9;
                var firstRowRange = (Range)xlRange.Rows[1, Missing.Value];
                firstRowRange.EntireRow.Font.Bold = true;
                firstRowRange.EntireRow.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                //Set Wrap Test to false
                xlRange.WrapText = false;
                object misValue = Missing.Value;
                theWorksheet.ListObjects.Add(XlListObjectSourceType.xlSrcRange,
                                             xlRange, misValue, XlYesNoGuess.xlYes, misValue).Name = "myTableList";
                string tableStyleName = "TableStyle" + excelTableStyle;
                theWorksheet.ListObjects["myTableList"].TableStyle = tableStyleName;
                xlRange.Columns.AutoFit();
                theWorksheet.Activate();
                //Save the file
                theWorkbook.SaveAs(fullFilePath, XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing,
                                   Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange,
                                   Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                if (!toOpen)
                {
                    //Clean up 
                    app.Quit();
                    Marshal.ReleaseComObject(app);
                }
            }
            catch
            {
                ForceExcelClose(excelProcessId);
                throw;
            }
            finally
            {
                app.Visible = toOpen;
            }
        }

        internal static void CreatePdfFromClipboard(string workSheetName, string fullFilePath,
                                                    ExcelTableStyle tableStyle, bool toOpen)
        {
            //Excel Application class 
            var app = new Application();
            //Get process id
            int excelProcessId = GetApplicationProcessId(app);
            app.DisplayAlerts = false;
            app.Visible = false;
            try
            {
                //Add workbook
                Workbook theWorkbook = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                //Add worksheet
                var theWorksheet =
                    (Worksheet)theWorkbook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                string sheetName = workSheetName;
                if (workSheetName.Length > 31)
                    sheetName = workSheetName.Substring(0, 31);
                theWorksheet.Name = sheetName;
                app.SheetsInNewWorkbook = 1;
                theWorksheet.Activate();

                //Paste to the worksheet from clpboard
                theWorksheet.Paste(Type.Missing, Type.Missing);
                //Apply Borders
                ApplyBorder(theWorksheet.UsedRange);

                //Auto Fit All columns
                Range xlRange = theWorksheet.UsedRange;
                // put all hardcodes in  a constant class 
                xlRange.Font.Name = "Arial";
                xlRange.Font.Size = 9;
                var firstRowRange = (Range)xlRange.Rows[1, Missing.Value];
                firstRowRange.EntireRow.Font.Bold = true;
                firstRowRange.EntireRow.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                //Set Wrap Test to false
                xlRange.WrapText = false;
                object misValue = Missing.Value;
                theWorksheet.ListObjects.Add(XlListObjectSourceType.xlSrcRange,
                                             xlRange, misValue, XlYesNoGuess.xlYes, misValue).Name = "myTableList";
                string tableStyleName = "TableStyle" + tableStyle;
                theWorksheet.ListObjects["myTableList"].TableStyle = tableStyleName;
                xlRange.Columns.AutoFit();
                theWorksheet.Activate();

                //Save the file
                string xcelFile = Path.Combine(Path.GetTempPath(),
                                               Path.GetFileNameWithoutExtension(fullFilePath) + ".xlsx");
                theWorkbook.SaveAs(xcelFile, XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing,
                                   Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange,
                                   Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                theWorksheet.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, fullFilePath,
                                                 XlFixedFormatQuality.xlQualityStandard, true, false, Missing.Value,
                                                 Missing.Value, toOpen, Missing.Value);


                //Clean up 
                app.Quit();
                Marshal.ReleaseComObject(app);
                File.Delete(xcelFile);
            }
            catch
            {
                MessageBox.Show(
                    "Please add 2007 Microsoft Office Add-in: Microsoft Save as PDF or XPS , dowload it from this location http://www.microsoft.com/download/en/details.aspx?id=7",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                ForceExcelClose(excelProcessId);
                throw;
            }
        }
    }

    public enum ExcelTableStyle
    {
        Light1,
        Light2,
        Light3,
        Light4,
        Light5,
        Light6,
        Light7,
        Light8,
        Light9,
        Light10,
        Light11,
        Light12,
        Light13,
        Light14,
        Light15,
        Light16,
        Light17,
        Light18,
        Light19,
        Light20,
        Light21,
        Medium1,
        Medium2,
        Medium3,
        Medium4,
        Medium5,
        Medium6,
        Medium7,
        Medium8,
        Medium9,
        Medium10,
        Medium11,
        Medium12,
        Medium13,
        Medium14,
        Medium15,
        Medium16,
        Medium17,
        Medium18,
        Medium19,
        Medium20,
        Medium21,
        Medium22,
        Medium23,
        Medium24,
        Medium25,
        Medium26,
        Medium27,
        Medium28,
        Dark1,
        Dark2,
        Dark3,
        Dark4,
        Dark5,
        Dark6,
        Dark7,
        Dark8,
        Dark9,
        Dark10,
        Dark11,
    }
}
