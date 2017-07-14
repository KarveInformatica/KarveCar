
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 383115 $
 * $Date: 2008-06-28 09:26:16 -0600 (Sat, 28 Jun 2008) $
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
    /// Weak Cache implementation.
	/// </summary>
	public sealed class WeakCache: BaseCache	
	{
        private readonly IDictionary<object, WeakReference> cache = new Dictionary<object, WeakReference>();

		/// <summary>
		/// Constructor
		/// </summary>
        public WeakCache() 
		{
            cache = new Dictionary<object, WeakReference>();
		}

		#region ICache Members

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>The size.</value>
        public override int Size
        {
            get { return cache.Count; }
        }

		/// <summary>
		/// Remove an object from a cache model
		/// </summary>
		/// <param name="key">the key to the object</param>
		/// <returns>the removed object</returns>
		public override object Remove(object key)
		{
            object value = null;
            WeakReference reference = null;
            if (cache.TryGetValue(key, out reference))
            {
                cache.Remove(key);
                value = reference.Target;
            }
            return value;
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
                WeakReference reference = null;

                if (cache.TryGetValue(key, out reference))
                {
                    if (reference.IsAlive)
                    {
                        value = reference.Target;
                    }
                    else
                    {
                        Remove(key);
                    }
                }
                return value;
            }
            set
            {
                WeakReference reference = new WeakReference(value, false);
                cache[key] = reference;
            }
		}


		/// <summary>
		/// Clears all elements from the cache.
		/// </summary>
        public override void Clear()
        {
            cache.Clear();
		}


        /// <summary>
        /// Determines whether the cache contains the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        /// 	<c>true</c> if the specified key contains key; otherwise, <c>false</c>.
        /// </returns>
        public override bool ContainsKey(object key)
        {
            return cache.ContainsKey(key);
        }

		#endregion

	}
}

