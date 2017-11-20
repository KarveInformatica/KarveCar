using System.Collections.Generic;

namespace KarveCommonInterfaces
{
    /// <summary>
    /// Defines an adapter that must be implemented in order to use the LinqToTree
    /// extension methods
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILinqToTree<T>
    {
        /// <summary>
        /// Obtains all the children of the Item.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ILinqToTree<T>> Children();

        /// <summary>
        /// The parent of the Item.
        /// </summary>
        ILinqToTree<T> Parent { get; }

        /// <summary>
        /// The item being adapted.
        /// </summary>
        T Item { get; }
    }
}
