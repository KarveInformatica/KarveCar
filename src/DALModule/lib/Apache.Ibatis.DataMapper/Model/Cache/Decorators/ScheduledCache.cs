
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

namespace Apache.Ibatis.DataMapper.Model.Cache.Decorators
{
    /// <summary>
    /// Cache decorator which clears the delegate cache on interval
    /// </summary>
    public sealed class ScheduledCache : BaseCache 
    {
        private readonly long flushInterval = 0;
        private long lastClear = 0;
        private readonly ICache delegateCache = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduledCache"/> class.
        /// </summary>
        /// <param name="delegateCache">The delegate cache.</param>
        /// <param name="flushIntervalInMinute">The flush interval in minute.</param>
        public ScheduledCache(ICache delegateCache, long flushIntervalInMinute)
        {
            this.delegateCache = delegateCache;
            flushInterval = flushIntervalInMinute * TimeSpan.TicksPerMinute;
            lastClear = DateTime.Now.Ticks;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        /// <value>The id.</value>
        public override string Id
        {
            get { return delegateCache.Id; }
        }


        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>The size.</value>
        public override int Size
        {
            get
            {
                ClearWhenStale();
                return delegateCache.Size;
            }
            set { delegateCache.Size = value; }
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
                if (ClearWhenStale()) 
                {
                    return null;
                } 
                else 
                {
                    return delegateCache[key];
                }           
            }
            set
            {
                ClearWhenStale();
                delegateCache[key] = value;
            }
        }

        /// <summary>
        /// Remove an object from a cache model
        /// </summary>
        /// <param name="key">the key to the object</param>
        /// <returns>the removed object(?)</returns>
        public override object Remove(object key)
        {
            ClearWhenStale();
            return delegateCache.Remove(key);
        }

        /// <summary>
        /// Clears all elements from the cache.
        /// </summary>
        public override void Clear()
        {
            lastClear = DateTime.Now.Ticks;
            delegateCache.Clear();
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
            if (ClearWhenStale())
            {
                return false;
            }
            else
            {
                return delegateCache.ContainsKey(key);
            }
        }


        private bool ClearWhenStale()
        {
            if ((DateTime.Now.Ticks - lastClear) > flushInterval)
            {
                Clear();
                return true;
            }
            return false;
        }

    }
}
