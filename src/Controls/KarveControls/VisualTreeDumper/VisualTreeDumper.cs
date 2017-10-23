using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Media3D;


namespace KarveControls.VisualTreeDumper
{
    ///
    public static class VisualTreeDumper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="originalElement"></param>
        /// <param name="itemDictionary"></param>
        /// <param name="assistDictionary"></param>
        static public void CollectData(DependencyObject originalElement, ref IDictionary<string, List<string>> itemDictionary, ref IDictionary<string, List<string>> assistDictionary)
        {
            DependencyObject closestVisualAncestor = FindClosestVisualAncestor(originalElement);
            DependencyObject visualRoot = FindVisualTreeRoot(originalElement);
            DependencyObject templatedParent = Utils.GetTemplatedParent(closestVisualAncestor);
            DoDumpCallback(visualRoot, closestVisualAncestor, 0, ref itemDictionary, ref assistDictionary);
        }

        static bool GoDownLogical(DependencyObject dependencyObject)
        {
            if ((dependencyObject is TabControl) || (dependencyObject is TabItem))
            {
                return true;
            }
            return false;
        }

        static bool GoDown(DependencyObject dependencyObject)
        {
            
            if (dependencyObject.GetType() == typeof(DockPanel) || dependencyObject.GetType() == typeof(StackPanel) ||
                dependencyObject.GetType() == typeof(WrapPanel) ||
                dependencyObject.GetType() == typeof(Grid) || dependencyObject.GetType() == typeof(Canvas) ||
                dependencyObject.GetType() == typeof(GroupBox) ||
                dependencyObject.GetType() == typeof(ScrollViewer) || dependencyObject.GetType() == typeof(Border) ||
                dependencyObject.GetType() == typeof(UniformGrid) ||
                dependencyObject.GetType() == typeof(Table) || dependencyObject.GetType() == typeof(TabPanel) ||
                dependencyObject.GetType() == typeof(ToolBarOverflowPanel) ||
                dependencyObject.GetType() == typeof(VirtualizingPanel) || 
                dependencyObject.GetType() == typeof(TabControl) ||
                dependencyObject.GetType() == typeof(VirtualizingStackPanel))
            {
                return true;
            }

            return false;
        }
        static private void DoDumpCallback(DependencyObject current, DependencyObject initial, int indentLevel,
            ref IDictionary<string, List<string>> itemDictionary,
            ref IDictionary<string, List<string>> assistDictionary)

        {
            
            if (current.GetType().BaseType == typeof(Window) || current.GetType().BaseType == typeof(UserControl) || GoDownLogical(current) ||
                current.GetType().BaseType == typeof(Page))
            {
                IEnumerable children = LogicalTreeHelper.GetChildren(current);
                foreach (object child in children)
                {
                    if (child is DependencyObject)
                    {
                        DoDumpCallback((DependencyObject)child, null, 0, ref itemDictionary, ref assistDictionary);

                    }
                    else
                    {
                        var named = child;
                    }
                  
                }
            }
            else
            {
                DependencyObject child = null;
                if (GoDown(current))
                {
                    int count = VisualTreeHelper.GetChildrenCount(current);
                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(current); i++)
                    {
                        object value = VisualTreeHelper.GetChild(current, i);
                        if (value is DependencyObject)
                        {
                            child = (DependencyObject) value;
                        }
                        DoDumpCallback(child, null, 0, ref itemDictionary, ref assistDictionary);
                    }
                }
                else
                {
                    if (current is TabControl)
                    {
                        object named = current;
                    }
                    object value = current;
                }
                /*


                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(current); i++)
                {
                    FrameworkElement child = (FrameworkElement) VisualTreeHelper.GetChild(current, i);

                    if (child.GetType() == typeof(DockPanel) || child.GetType() == typeof(StackPanel) ||
                        child.GetType() == typeof(WrapPanel) ||
                        child.GetType() == typeof(Grid) || child.GetType() == typeof(Canvas) ||
                        child.GetType() == typeof(GroupBox) ||
                        child.GetType() == typeof(ScrollViewer) || child.GetType() == typeof(Border) ||
                        child.GetType() == typeof(UniformGrid) ||
                        child.GetType() == typeof(Table) || child.GetType() == typeof(TabPanel) ||
                        child.GetType() == typeof(ToolBarOverflowPanel) ||
                        child.GetType() == typeof(VirtualizingPanel) ||
                        child.GetType() == typeof(VirtualizingStackPanel))
                    {
                        DoDumpCallback(child, null, 0, ref itemDictionary, ref assistDictionary);
                    }
                    else
                    {
                        if (current is DataField)
                        {
                            var obj = current;
                        }
                    }
                }*/

            }
            /*
            int visualChildrenCount = System.Windows.Media.VisualTreeHelper.GetChildrenCount(current);
            IEnumerable children = LogicalTreeHelper.GetChildren(current);
            foreach ()
                
            IEnumerable enumerable = LogicalTreeHelper.GetChildren(current);
            // Collect
            CollectItem(current, ref itemDictionary, ref assistDictionary);
            for (int i = 0; i < visualChildrenCount; ++i)
            {
                DependencyObject visualChild = System.Windows.Media.VisualTreeHelper.GetChild(current, i);
                DoDumpCallback(visualChild, initial, indentLevel + 1, ref itemDictionary, ref assistDictionary);
            }*/
        }

        /// <summary>
        ///  This add or create a name.
        /// </summary>
        /// <param name="tableName">Table name</param>
        /// <param name="fieldName">Table field</param>
        /// <param name="dictionary">Table dictionary that contains the fields for table</param>
        private static void AddOrCreate(string tableName, string fieldName,
            ref IDictionary<string, List<string>> dictionary)
        {
            if (!dictionary.ContainsKey(tableName))
            {
                List<string> str = new List<string>();
                str.Add(fieldName);
                dictionary.Add(tableName, str);
            }
            else
            {
                List<string> name = dictionary[tableName];
                name.Add(fieldName);
                dictionary[tableName] = name;
            }
        }
        /// <summary>
        /// Item collection 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="itemDictionary"></param>
        /// <param name="assistDictionary"></param>
        static private void CollectItem(DependencyObject current, ref IDictionary<string, List<string>> itemDictionary, ref IDictionary<string, List<string>> assistDictionary)
        {
            object v = current;
            if (v is DataField)
            {
                DataField field = (DataField) current;
                AddOrCreate(field.TableName, field.DBField, ref itemDictionary);
            }
        }
        public static void Dump(DependencyObject originalElement)
        {
        
            Console.WriteLine("DUMPING VISUAL TREE:");
            Console.WriteLine("Original Element: " + originalElement.GetType().Name);
            DependencyObject closestVisualAncestor = FindClosestVisualAncestor(originalElement);
            DependencyObject visualRoot = FindVisualTreeRoot(originalElement);
            DependencyObject templatedParent = Utils.GetTemplatedParent(closestVisualAncestor);            
            string closestParentText = closestVisualAncestor == originalElement ? "(self)" : closestVisualAncestor.GetType().Name;
            Console.WriteLine("Closest Visual Ancestor to Original Element: " + closestParentText);

            string templatedParentType = templatedParent == null ? "(null)" : templatedParent.GetType().Name;
            Console.WriteLine("TemplatedParent of Closest Visual Ancestor: " + templatedParentType);

            Console.WriteLine();

            // Write out the visual tree to the console.
            DoDump(visualRoot, closestVisualAncestor, 0);

            Console.WriteLine("************************************************************\n");
        }

        /// <summary>
        /// This method is necessary in case the user clicks on a ContentElement,
        /// which is not part of the visual tree.  It will walk up the logical
        /// tree, if necessary, to find the first ancestor in the visual tree.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        static DependencyObject FindClosestVisualAncestor(DependencyObject initial)
        {
            if (initial is Visual || initial is Visual3D)
                return initial;

            DependencyObject current = initial;
            DependencyObject result = initial;

            while (current != null)
            {
                result = current;
                if (current is Visual || current is Visual3D)
                {
                    result = current;
                    break;
                }
                else
                {
                    // If we're in Logical Land then we must walk up the logical tree
                    // until we find a Visual/Visual3D to get us back to Visual Land.
                    current = LogicalTreeHelper.GetParent(current);
                }
            }

            return result;
        }

        static DependencyObject FindVisualTreeRoot(DependencyObject initial)
        {
            DependencyObject current = initial;
            DependencyObject result = initial;

            while (current != null)
            {
                result = current;
                if (current is Visual || current is Visual3D)
                {
                    current = System.Windows.Media.VisualTreeHelper.GetParent(current);
                }
                else
                {
                    // If we're in Logical Land then we must walk up the logical tree
                    // until we find a Visual/Visual3D to get us back to Visual Land.
                    current = LogicalTreeHelper.GetParent(current);
                }
            }

            return result;
        }

        static void DoDump(DependencyObject current, DependencyObject initial, int indentLevel)
        {
            Utils.DumpElement(current, current == initial, indentLevel);

            int visualChildrenCount = System.Windows.Media.VisualTreeHelper.GetChildrenCount(current);

            for (int i = 0; i < visualChildrenCount; ++i)
            {
                DependencyObject visualChild = System.Windows.Media.VisualTreeHelper.GetChild(current, i);
                DoDump(visualChild, initial, indentLevel + 1);
            }
        }
    }
}