using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;


namespace ExtendedGrid.Classes
{
    internal sealed class FindControls
    {
        public static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            //get parent item
            var parentObject = VisualTreeHelper.GetParent(child);

            //we've reached the end of the tree
            if (parentObject == null) return null;

            //check if the parent matches the type we're looking for
            var parent = parentObject as T;
            return parent ?? FindParent<T>(parentObject);
        }

        public static T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            // Confirm parent and childName are valid.  
            if (parent == null) return null;
            T foundChild = null;
            var childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (var i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                // If the child is not of the request child type child  
                var childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree  
                    foundChild = FindChild<T>(child, childName);
                    // If the child is found, break so we do not overwrite the found child.    
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child's name is set for search    
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name  
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T)child;
                    break;
                }
            }
            return foundChild;
        }

       
        public static DataGridColumnHeader GetColumnHeaderFromColumn(DataGridColumn column,DataGrid grid)
        {
            // dataGrid is the name of your DataGrid. In this case Name="dataGrid"
            var columnHeaders = GetVisualChildCollection<DataGridColumnHeader>(grid);
            return columnHeaders.FirstOrDefault(columnHeader => columnHeader.Column == column);
        }

        public static List<T> GetVisualChildCollection<T>(object parent) where T : Visual
        {
            var visualCollection = new List<T>();
            GetVisualChildCollection(parent as DependencyObject, visualCollection);
            return visualCollection;
        }

        private static void GetVisualChildCollection<T>(DependencyObject parent, List<T> visualCollection) where T : Visual
        {
            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is T)
                {
                    visualCollection.Add(child as T);
                }
                else if (child != null)
                {
                    GetVisualChildCollection(child, visualCollection);
                }
            }
        }
    }
}
