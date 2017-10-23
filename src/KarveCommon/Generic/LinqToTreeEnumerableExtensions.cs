using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCommon.Generic
{
    public static class LinqToTreeEnumerableExtensions
    {
        /// <summary>
        /// Applies the given function to each of the items in the supplied
        /// IEnumerable.
        /// </summary>
        private static IEnumerable<ILinqToTree<T>> DrillDown<T>(this IEnumerable<ILinqToTree<T>> items,
            Func<ILinqToTree<T>, IEnumerable<ILinqToTree<T>>> function)
        {
            foreach (var item in items)
            {
                foreach (ILinqToTree<T> itemChild in function(item))
                {
                    yield return itemChild;
                }
            }
        }

        /// <summary>
        /// Returns a collection of descendant elements.
        /// </summary>
        public static IEnumerable<ILinqToTree<T>> Descendants<T>(this IEnumerable<ILinqToTree<T>> items)
        {

            return items.DrillDown(i => i.Descendants());
        }

        /// <summary>
        /// Returns a collection containing this element and all descendant elements.
        /// </summary>
        public static IEnumerable<ILinqToTree<T>> DescendantsAndSelf<T>(this IEnumerable<ILinqToTree<T>> items)
        {
            return items.DrillDown(i => i.DescendantsAndSelf());
        }

        /// <summary>
        /// Returns a collection of ancestor elements.
        /// </summary>
        public static IEnumerable<ILinqToTree<T>> Ancestors<T>(this IEnumerable<ILinqToTree<T>> items)
        {
            return items.DrillDown(i => i.Ancestors());
        }

        /// <summary>
        /// Returns a collection containing this element and all ancestor elements.
        /// </summary>
        public static IEnumerable<ILinqToTree<T>> AncestorsAndSelf<T>(this IEnumerable<ILinqToTree<T>> items)
        {
            return items.DrillDown(i => i.AncestorsAndSelf());
        }

        /// <summary>
        /// Returns a collection of child elements.
        /// </summary>
        public static IEnumerable<ILinqToTree<T>> Elements<T>(this IEnumerable<ILinqToTree<T>> items)
        {
            return items.DrillDown(i => i.Elements());
        }

        /// <summary>
        /// Returns a collection containing this element and all child elements.
        /// </summary>
        public static IEnumerable<ILinqToTree<T>> ElementsAndSelf<T>(this IEnumerable<ILinqToTree<T>> items)
        {
            return items.DrillDown(i => i.ElementsAndSelf());
        }

    }
    
}
