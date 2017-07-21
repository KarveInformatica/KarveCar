using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;

namespace ExtendedGrid.Classes
{
    public static class ClipboardHelper
    {
        public delegate string[] ParseFormat(string value);

        public static List<string[]> ParseClipboardData()
        {
            List<string[]> clipboardData = null;
            object clipboardRawData = null;
            ParseFormat parseFormat = null;

            // get the data and set the parsing method based on the format
            // currently works with CSV and Text DataFormats            
            IDataObject dataObj = Clipboard.GetDataObject();
            if (dataObj != null && (clipboardRawData = dataObj.GetData(DataFormats.CommaSeparatedValue)) != null)
            {
                parseFormat = ParseCsvFormat;
            }
            else if (dataObj != null && (clipboardRawData = dataObj.GetData(DataFormats.Text)) != null)
            {
                parseFormat = ParseTextFormat;
            }

            if (parseFormat != null)
            {
                var rawDataStr = clipboardRawData as string;

                if (rawDataStr == null && clipboardRawData is MemoryStream)
                {
                    // cannot convert to a string so try a MemoryStream
                    var ms = clipboardRawData as MemoryStream;
                    var sr = new StreamReader(ms);
                    rawDataStr = sr.ReadToEnd();
                }
                Debug.Assert(rawDataStr != null,
                             string.Format(
                                 "clipboardRawData: {0}, could not be converted to a string or memorystream.",
                                 clipboardRawData));

                string[] rows = rawDataStr.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
                if (rows.Length > 0)
                {
                    clipboardData = rows.Select(row => parseFormat(row)).ToList();
                }
                else
                {
                    Debug.WriteLine("unable to parse row data.  possibly null or contains zero rows.");
                }
            }

            return clipboardData;
        }

        public static string[] ParseCsvFormat(string value)
        {
            return ParseCsvOrTextFormat(value, true);
        }

        public static string[] ParseTextFormat(string value)
        {
            return ParseCsvOrTextFormat(value, false);
        }

        private static string[] ParseCsvOrTextFormat(string value, bool isCsv)
        {
            var outputList = new List<string>();

            char separator = isCsv ? ',' : '\t';
            int startIndex = 0;
            int endIndex = 0;

            for (int i = 0; i < value.Length; i++)
            {
                char ch = value[i];
                if (ch == separator)
                {
                    outputList.Add(value.Substring(startIndex, endIndex - startIndex));

                    startIndex = endIndex + 1;
                    endIndex = startIndex;
                }
                else if (ch == '\"' && isCsv)
                {
                    // skip until the ending quotes
                    i++;
                    if (i >= value.Length)
                    {
                        throw new FormatException(string.Format("value: {0} had a format exception", value));
                    }
                    char tempCh = value[i];
                    while (tempCh != '\"' && i < value.Length)
                        i++;

                    endIndex = i;
                }
                else if (i + 1 == value.Length)
                {
                    // add the last value
                    outputList.Add(value.Substring(startIndex));
                    break;
                }
                else
                {
                    endIndex++;
                }
            }

            return outputList.ToArray();
        }
    }
}
