
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 383115 $
 * $Date: 2008-06-07 10:14:33 +0200 (sam., 07 juin 2008) $
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

using System.Collections.Generic;


namespace Apache.Ibatis.DataMapper.Model.Cache.Implementation
{
	/// <summary>
	/// A read-only cache implementation where cache object are shared among all users and therefore offer greater performance benefit. 
    /// However, objects read from a read-only cache should not be modified. 	
    /// </summary>
	/// <remarks>
    /// eq to SHARED_READ_ONLY
	/// </remarks>
	public sealed class PerpetualCache : BaseCache	
	{
	    private readonly IDictionary<object, object> cache = new Dictionary<object, object>();

		/// <summary>
		/// Constructor
		/// </summary>
		public PerpetualCache() 
		{
            cache = new Dictionary<object, object>();
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
            cache.TryGetValue(key, out value);
            cache.Remove(key);
            return value;
		}

		/// <summary>
		/// Adds an item with the specified key and value into cached data.
		/// Gets a cached object with the specified key.
		/// </summary>
		/// <value>The cached object or <c>null</c></value>
		public override object this [object key] 
		{
			get
            {
                object value = null;
                cache.TryGetValue(key, out value);
                return value;
            }
            set
            {

                cache[key] = value;
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
