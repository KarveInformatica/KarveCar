using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;


namespace ExtendedGrid.Classes
{
    public static class SortHelpers
    {
        public static string GetSortMemberPath(DataGridColumn column)
        {
            // find the sortmemberpath
            string sortPropertyName = column.SortMemberPath;
            if (string.IsNullOrEmpty(sortPropertyName))
            {
                var boundColumn = column as DataGridBoundColumn;
                if (boundColumn != null)
                {
                    var binding = boundColumn.Binding as Binding;
                    if (binding != null)
                    {
                        if (!string.IsNullOrEmpty(binding.XPath))
                        {
                            sortPropertyName = binding.XPath;
                        }
                        else if (binding.Path != null)
                        {
                            sortPropertyName = binding.Path.Path;
                        }
                    }
                }
            }

            return sortPropertyName;
        }

        public static int FindSortDescription(SortDescriptionCollection sortDescriptions, string sortPropertyName)
        {
            int index = -1;
            int i = 0;
            foreach (SortDescription sortDesc in sortDescriptions)
            {
                if (System.String.CompareOrdinal(sortDesc.PropertyName, sortPropertyName) == 0)
                {
                    index = i;
                    break;
                }
                i++;
            }

            return index;
        }
    }
}
