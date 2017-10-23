using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCommon.Generic
{
    public static class LinqToTreeExtensions
    {
        #region primary Linq methods

        /// <summary>
        /// Returns a collection of descendant elements.
        /// </summary>
        public static IEnumerable<ILinqToTree<T>> Descendants<T>(this ILinqToTree<T> adapter)
        {
            foreach (var child in adapter.Children())
            {
                yield return child;

                foreach (var grandChild in child.Descendants())
                {
                    yield return grandChild;
                }
            }
        }

        /// <summary>
        /// Returns a collection of ancestor elements.
        /// </summary>
        public static IEnumerable<ILinqToTree<T>> Ancestors<T>(this ILinqToTree<T> adapter)
        {
            var parent = adapter.Parent;
            while (parent != null)
            {
                yield return parent;
                parent = parent.Parent;
            }
        }

        /// <summary>
        /// Returns a collection of child elements.
        /// </summary>
        public static IEnumerable<ILinqToTree<T>> Elements<T>(this ILinqToTree<T> adapter)
        {
            foreach (var child in adapter.Children())
            {
                yield return child;
            }
        }

        #endregion

        #region 'AndSelf' implementations

        /// <summary>
        /// Returns a collection containing this element and all child elements.
        /// </summary>
        public static IEnumerable<ILinqToTree<T>> ElementsAndSelf<T>(this ILinqToTree<T> adapter)
        {
            yield return adapter;

            foreach (var child in adapter.Elements())
            {
                yield return child;
            }
        }

        /// <summary>
        /// Returns a collection of ancestor elements.
        /// </summary>
        public static IEnumerable<ILinqToTree<T>> AncestorsAndSelf<T>(this ILinqToTree<T> adapter)
        {

            yield return adapter;

            foreach (var child in adapter.Ancestors())
            {
                yield return child;
            }
        }

        /// <summary>
        /// Returns a collection containing this element and all descendant elements.
        /// </summary>
        public static IEnumerable<ILinqToTree<T>> DescendantsAndSelf<T>(this ILinqToTree<T> adapter)
        {
            yield return adapter;

            foreach (var child in adapter.Descendants())
            {
                yield return child;
            }
        }

        #endregion

        #region Method which take type parameters

        /// <summary>
        /// Returns a collection of descendant elements.
        /// </summary>
        public static IEnumerable<ILinqToTree<T>> Descendants<T, K>(this ILinqToTree<T> adapter)
        {
            return adapter.Descendants().Where(i => i.Item is K);
        }


        #endregion
    }
}
