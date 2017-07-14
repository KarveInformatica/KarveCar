
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 383115 $
 * $Date: 2008-05-18 10:02:28 +0200 (dim., 18 mai 2008) $
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

using System;
using System.Collections.Generic;

namespace Apache.Ibatis.DataMapper.Model.Cache.Implementation
{
	/// <summary>
    /// Cache following a LRU (least recently used) algorithm
	/// </summary>
	public sealed class LruCache : BaseCache	
	{
        private readonly IDictionary<object, object> cache = new Dictionary<object, object>();
        private readonly LinkedList<object> keyList = new LinkedList<object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="LruCache"/> class.
        /// </summary>
		public LruCache() 
		{
			Size = 256;
            cache = new Dictionary<object, object>();
            keyList = new LinkedList<object>();
		}

        ///// <summary>
        ///// Gets the size.
        ///// </summary>
        ///// <value>The size.</value>
        //public override int Size
        //{
        //    set { size =value; }
        //}

		/// <summary>
		/// Remove an object from a cache model
		/// </summary>
		/// <param name="key">the key to the object</param>
		/// <returns>the removed object(?)</returns>
		public override object Remove(object key)
		{
            object value = null;
            if (cache.TryGetValue(key, out value))
            {
                keyList.Remove(key);
                cache.Remove(key);
            }
            return value;
		}

		/// <summary>
		/// Clears all elements from the cache.
		/// </summary>
        public override void Clear()
		{
            cache.Clear();
            keyList.Clear();
		}


		/// <summary>
		/// Adds an item with the specified key and value into cached data.
		/// Gets a cached object with the specified key.
		/// </summary>
		/// <value>The cached object or <c>null</c></value>
		public override object this[object key] 
		{
			get
            {
                object value = null;
                if (cache.TryGetValue(key, out value))
                {
                    keyList.Remove(key);
                    keyList.AddLast(key);
                }
                return value;
            }
			set
			{
                cache[key] = value;
                keyList.AddLast(key);
                if (keyList.Count > Size)
                {
                    LinkedListNode<object> oldestKey = keyList.First;
                    keyList.RemoveFirst();
                    cache.Remove(oldestKey.Value);
                }
			}
		}

        /// <summary>
        /// Determines whether the cache contains the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        /// 	<c>true</c> if the specified key contains key; otherwise, <c>false</c>.
        /// </returns>
        public override bool  ContainsKey(object key)
        {
            return keyList.Contains(key);
        }

	}
}
