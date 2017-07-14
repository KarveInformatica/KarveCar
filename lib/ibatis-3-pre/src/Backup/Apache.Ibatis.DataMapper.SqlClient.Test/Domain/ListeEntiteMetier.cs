using System;
using System.Collections.Generic;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Domain
{
    [Serializable]
    public class ListeEntiteMetier<T> : List<T>
    {
        /// <summary>
        /// Obtient le nombre d'éléments réellement contenus dans la liste
        /// </summary>
        public new virtual int Count
        {
            get { return base.Count; }
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.Item"/>.
        /// </summary>
        /// <value></value>
        public new virtual T this[int index]
        {
            get { return base[index]; }
            set { base[index] = value; }
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List`1.Add"/>.
        /// </summary>
        /// <param name="item">The object to be added to the end of the <see cref="T:System.Collections.Generic.List`1"/>. The value can be null for reference types.</param>
        public new virtual void Add(T item)
        {
            base.Add(item);
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.AddRange"/>.
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the <see cref="T:System.Collections.Generic.List`1"/>. The collection itself cannot be null, but it can contain elements that are null, if type <paramref name="T"/> is a reference type.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="collection"/> is null.</exception>
        public new virtual void AddRange(IEnumerable<T> collection)
        {
            this.InsertRange(base.Count, collection);
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.Clear"/>.
        /// </summary>
        public new virtual void Clear()
        {
            base.Clear();
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.Insert"/>.
        /// </summary>
        public new virtual void Insert(int index, T item)
        {
            base.Insert(index, item);
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.InsertRange"/>.
        /// </summary>
        public new virtual void InsertRange(int index, IEnumerable<T> collection)
        {
            base.InsertRange(index, collection);
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.Remove"/>.
        /// </summary>
        public new virtual bool Remove(T item)
        {
            bool result = base.Remove(item);
            return result;
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.RemoveAll"/>.
        /// </summary>
        public new virtual int RemoveAll(Predicate<T> match)
        {
            int count = base.RemoveAll(match);
            return count;
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.RemoveAt"/>.
        /// </summary>
        public new virtual void RemoveAt(int index)
        {
            base.RemoveAt(index);
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.RemoveRange"/>.
        /// </summary>
        public new virtual void RemoveRange(int index, int count)
        {
            int listCount = base.Count;
            base.RemoveRange(index, count);
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.Find"/>.
        /// </summary>
        /// <param name="match">Délégué qui définit les conditions de l'élément à rechercher</param>
        /// <returns></returns>
        public new virtual T Find(Predicate<T> match)
        {
            return base.Find(match);
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.FindAll"/>.
        /// </summary>
        /// <param name="match">Délégué qui définit les conditions de l'élément à rechercher</param>
        /// <returns></returns>
        public new virtual ListeEntiteMetier<T> FindAll(Predicate<T> match)
        {
            return (ListeEntiteMetier<T>)base.FindAll(match);
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.FindIndex"/>.
        /// </summary>
        /// <param name="match">Délégué qui définit les conditions de l'élément à rechercher</param>
        /// <returns></returns>
        public new virtual int FindIndex(Predicate<T> match)
        {
            return base.FindIndex(match);
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.FindIndex"/>.
        /// </summary>
        /// <param name="startIndex">Index de début de base zéro de la recherche</param>
        /// <param name="match">Délégué qui définit les conditions de l'élément à rechercher</param>
        /// <returns></returns>
        public new virtual int FindIndex(int startIndex, Predicate<T> match)
        {
            return base.FindIndex(startIndex, match);
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.FindIndex"/>.
        /// </summary>
        /// <param name="startIndex">Index de début de base zéro de la recherche</param>
        /// <param name="count">Nombre d'élément contenus dans la section où la recherche doit être effectuée</param>
        /// <param name="match">Délégué qui définit les conditions de l'élément à rechercher</param>
        /// <returns></returns>
        public new virtual int FindIndex(int startIndex, int count, Predicate<T> match)
        {
            return base.FindIndex(startIndex, count, match);
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.FindLast"/>.
        /// </summary>
        /// <param name="match">Délégué qui définit les conditions de l'élément à rechercher</param>
        /// <returns></returns>
        public new virtual T FindLast(Predicate<T> match)
        {
            return base.FindLast(match);
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.FindLastIndex"/>.
        /// </summary>
        /// <param name="match">Délégué qui définit les conditions de l'élément à rechercher</param>
        /// <returns></returns>
        public new virtual int FindLastIndex(Predicate<T> match)
        {
            return base.FindLastIndex(match);
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.FindLastIndex"/>.
        /// </summary>
        /// <param name="startIndex">Index de début de base zéro de la recherche</param>
        /// <param name="match">Délégué qui définit les conditions de l'élément à rechercher</param>
        /// <returns></returns>
        public new virtual int FindLastIndex(int startIndex, Predicate<T> match)
        {
            return base.FindLastIndex(startIndex, match);
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.FindLastIndex"/>.
        /// </summary>
        /// <param name="startIndex">Index de début de base zéro de la recherche</param>
        /// <param name="count">Nombre d'élément contenus dans la section où la recherche doit être effectuée</param>
        /// <param name="match">Délégué qui définit les conditions de l'élément à rechercher</param>
        /// <returns></returns>
        public new virtual int FindLastIndex(int startIndex, int count, Predicate<T> match)
        {
            return base.FindLastIndex(startIndex, count, match);
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.ForEach"/>.
        /// </summary>
        /// <param name="action">Délégué à éxécuter sur chaque élément de la liste</param>
        /// <returns></returns>
        public new virtual void ForEach(Action<T> action)
        {
            base.ForEach(action);
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.GetEnumerator"/>.
        /// </summary>
        /// <param name="action">Délégué à éxécuter sur chaque élément de la liste</param>
        /// <returns></returns>
        public new virtual Enumerator GetEnumerator()
        {
            return base.GetEnumerator();
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.GetRange"/>.
        /// </summary>
        /// <param name="index">Index de base zéro auquel la plage commence</param>
        /// <param name="count">Nombre d'élément dans la plage</param>
        /// <returns></returns>
        public new virtual ListeEntiteMetier<T> GetRange(int index, int count)
        {
            return (ListeEntiteMetier<T>)base.GetRange(index, count);
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.IndexOf"/>.
        /// </summary>
        /// <param name="item">Objet à trouver</param>
        /// <returns></returns>
        public new virtual int IndexOf(T item)
        {
            return base.IndexOf(item);
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.IndexOf"/>.
        /// </summary>
        /// <param name="item">Objet à trouver</param>
        /// <param name="index">Index de début de base zéro de la recherche</param>
        /// <returns></returns>
        public new virtual int IndexOf(T item, int index)
        {
            return base.IndexOf(item, index);
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.IndexOf"/>.
        /// </summary>
        /// <param name="item">Objet à trouver</param>
        /// <param name="index">Index de début de base zéro de la recherche</param>
        /// <param name="count">Nombre d'éléments contenus dans la section où la recherche doit être effectuée</param>
        /// <returns></returns>
        public new virtual int IndexOf(T item, int index, int count)
        {
            return base.IndexOf(item, index, count);
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.LastIndexOf"/>.
        /// </summary>
        /// <param name="item">Objet à trouver</param>
        /// <returns></returns>
        public new virtual int LastIndexOf(T item)
        {
            return base.LastIndexOf(item);
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.LastIndexOf"/>.
        /// </summary>
        /// <param name="item">Objet à trouver</param>
        /// <param name="index">Index de début de base zéro de la recherche</param>
        public new virtual int LastIndexOf(T item, int index)
        {
            return base.LastIndexOf(item, index);
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.LastIndexOf"/>.
        /// </summary>
        /// <param name="item">Objet à trouver</param>
        /// <param name="index">Index de début de base zéro de la recherche</param>
        /// <param name="count">Nombre d'éléments contenus dans la section où la recherche doit être effectuée</param>
        public new virtual int LastIndexOf(T item, int index, int count)
        {
            return base.LastIndexOf(item, index);
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.Reverse"/>.
        /// </summary>
        public new virtual void Reverse()
        {
            base.Reverse();
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.Reverse"/>.
        /// </summary>
        /// <param name="index">Index de début de base zéro de la recherche</param>
        /// <param name="count">Nombre d'éléments contenus dans la section où la recherche doit être effectuée</param>
        public new virtual void Reverse(int index, int count)
        {
            base.Reverse(index, count);
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.Sort"/>.
        /// </summary>
        /// <returns></returns>
        public new virtual void Sort()
        {
            base.Sort();
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.Sort"/>.
        /// </summary>
        /// <param name="comparison">System.Comparison à utiliser lors de la comparaison d'éléments</param>
        public new virtual void Sort(Comparison<T> comparison)
        {
            base.Sort(comparison);
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.Sort"/>.
        /// </summary>
        /// <param name="comparer">Implémentation de IComparer à utiliser lors de la comparaison d'éléments</param>
        public new virtual void Sort(IComparer<T> comparer)
        {
            base.Sort(comparer);
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.Sort"/>.
        /// </summary>
        /// <param name="index">Index de début de base zéro de la plage à trier</param>
        /// <param name="count">Longueur de la plage à trier</param>
        /// <param name="comparer">Implémentation de IComparer à utiliser lors de la comparaison d'éléments</param>
        public new virtual void Sort(int index, int count, IComparer<T> comparer)
        {
            base.Sort(index, count, comparer);

            base.ToArray();
        }

        /// <summary>
        /// Overloads <see cref="System.Collections.Generic.List.ToArray"/>.
        /// </summary>
        /// <returns></returns>
        public new virtual T[] ToArray()
        {
            return base.ToArray();
        }
    }
}
