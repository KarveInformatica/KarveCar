using System;
using System.Data;

namespace MasterModule.Common
{
    /// <summary>
    /// This is a dataset helper.
    /// </summary>
    internal class DataSetUtilities
    {
        /// <summary>
        /// This is a merge table
        /// </summary>
        /// <param name="table">The table to be merged</param>
        /// <param name="currentDataSet">The current dataset</param>
        internal static void MergeTableChanged(DataTable table, ref DataSet currentDataSet)
        {

            string tableName = table.TableName;
            bool foundTable = false;
            if (currentDataSet != null)
            {
                foreach (DataTable currentTable in currentDataSet.Tables)
                {
                    if (currentTable.TableName == tableName)
                    {
                        foundTable = true;
                        break;
                    }
                }
                if (foundTable)
                {
                    currentDataSet.Tables[tableName].Merge(table);
                }
            }
        }

        
    }
}
