
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 383115 $
 * $Date: 2008-10-19 05:25:12 -0600 (Sun, 19 Oct 2008) $
 * 
 * iBATIS.NET Data Mapper
 * Copyright (C) 2008/2005 - The Apache Software Foundation
 *  
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *      http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * 
 ********************************************************************************/
#endregion

using Apache.Ibatis.DataMapper.Exceptions;

namespace Apache.Ibatis.DataMapper.Model.Cache
{
    /// <summary>
    /// Base Cache class implements a template method pattern for subclasses.
    /// </summary>
    public abstract class BaseCache : ICache
    {
        #region ICache Members

        /// <summary>
        /// Gets the id.
        /// </summary>
        /// <value>The id.</value>
        public virtual string Id { get; set; }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>The size.</value>
        public virtual int Size { get; set; }

        /// <summary>
        /// Adds an item with the specified key and value into cached data.
        /// Gets a cached object with the specified key.
        /// </summary>
        /// <value>The cached object or <c>null</c></value>
        public abstract object this[object key] { get;set;}


        /// <summary>
        /// Remove an object from a cache model
        /// </summary>
        /// <param name="key">the key to the object</param>
        /// <returns>the removed object(?)</returns>
        public abstract object Remove(object key);


        /// <summary>
        /// Clears all elements from the cache.
        /// </summary>
        public abstract void Clear();

        /// <summary>
        /// Determines whether the cache contains the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        /// 	<c>true</c> if the specified key contains key; otherwise, <c>false</c>.
        /// </returns>
        public abstract bool ContainsKey(object key);


        #endregion


        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">The <paramref name="obj"/> parameter is null.</exception>
		public override bool Equals(object obj) 
		{
            if (string.IsNullOrEmpty(Id)) 
            {
                throw new DataMapperException("Cache instances require an ID.");
            }
			if (this == obj)
			{
			    return true;
			}
            if (!(obj is BaseCache))
            {
                return false;
            }

            BaseCache baseCache = (BaseCache)obj;

            if ( !Id.Equals(baseCache.Id) )
            {
                return false;
            }

            return true;
		}

        /// <summary>
        /// Get the HashCode for this CacheKey
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            if (string.IsNullOrEmpty(Id)) 
            {
                throw new DataMapperException("Cache instances require an ID.");
            }
            return Id.GetHashCode();
        }
    }
}
