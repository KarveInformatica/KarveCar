using System;
using System.Windows;

namespace KarveControls.VisualTreeDumper
{
  
    static class LogicalTreeDumper
    {

        public static void Dump(DependencyObject originalElement)
        {
            DependencyObject closestLogicalAncestor = FindClosestLogicalAncestor(originalElement);
            DependencyObject logicalRoot = FindLogicalTreeRoot(closestLogicalAncestor);

            Console.WriteLine("DUMPING LOGICAL TREE:");
            Console.WriteLine("Original Element: " + originalElement.GetType().Name);

            string closestParentText = closestLogicalAncestor == originalElement ? "(self)" : closestLogicalAncestor.GetType().Name;
            Console.WriteLine("Closest Logical Ancestor to Original Element: " + closestParentText);

            DependencyObject templatedParent = Utils.GetTemplatedParent(closestLogicalAncestor);
            string templatedParentType = templatedParent == null ? "(null)" : templatedParent.GetType().Name;
            Console.WriteLine("TemplatedParent of Closest Logical Ancestor: " + templatedParentType);

            Console.WriteLine();

            // Write out the logical tree to the console.
            DoDump(logicalRoot, closestLogicalAncestor, 0);

            Console.WriteLine("************************************************************\n");
        }
       
        /// <summary>
        /// This method is necessary in case the user clicks on an element
        /// which is not part of a logical tree.  It finds the closest ancestor
        /// element which is in a logical tree.
        /// </summary>
        /// <param name="initial">The element on which the user clicked.</param>
        static DependencyObject FindClosestLogicalAncestor(DependencyObject initial)
        {
            DependencyObject current = initial;
            DependencyObject result = initial;

            while (current != null)
            {
                DependencyObject logicalParent = LogicalTreeHelper.GetParent(current);
                if (logicalParent != null)
                {
                    result = current;
                    break;
                }
                current = System.Windows.Media.VisualTreeHelper.GetParent(current);
            }

            return result;
        }

        /// <summary>
        /// Walks up the logical tree starting at 'initial' and returns
        /// the topmost element in that tree.
        /// </summary>
        /// <param name="initial">It is assumed that this element is in a logical tree.</param>
        static DependencyObject FindLogicalTreeRoot(DependencyObject initial)
        {
            DependencyObject current = initial;
            DependencyObject result = initial;

            while (current != null)
            {
                result = current;
                current = LogicalTreeHelper.GetParent(current);
            }

            return result;
        }

        static void DoDump(object current, object initial, int indentLevel)
        {
            Utils.DumpElement(current, current == initial, indentLevel);

            // The logical tree can contain any type of object, not just 
            // instances of DependencyObject subclasses.  LogicalTreeHelper
            // only works with DependencyObject subclasses, so we must be
            // sure that we do not pass it an object of the wrong type.
            DependencyObject depObj = current as DependencyObject;

            if (depObj != null)
                foreach (object logicalChild in LogicalTreeHelper.GetChildren(depObj))
                    DoDump(logicalChild, initial, indentLevel + 1);
        }
    }
}