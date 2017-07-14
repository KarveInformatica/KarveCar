
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

using System;
using System.Reflection;
using Apache.Ibatis.Common.Logging;

namespace Apache.Ibatis.DataMapper.Model.Cache.Decorators
{
    /// <summary>
    /// A cache decorator that logs all cache access
    /// </summary>
    public sealed class LoggingCache : BaseCache
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ICache delegateCache = null;
        private int requests = 0;
        private int hits = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingCache"/> class.
        /// </summary>
        /// <param name="delegateCache">The delegate cache.</param>
        public LoggingCache(ICache delegateCache)
        {
            this.delegateCache = delegateCache;

            requests = 0;
            hits = 0;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        /// <value>The id.</value>
        public override string Id
        {
            get { return delegateCache.Id; }
            set { delegateCache.Id = value;}
        }


        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>The size.</value>
        public override int Size
        {
            get { return delegateCache.Size; }
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
                requests++;
                if (ContainsKey(key))
                {
                    hits++;
                }
                object value =  delegateCache[key];

                if (logger.IsDebugEnabled)
                {
                    if (value != null)
                    {
                        logger.Debug(String.Format("Retrieved cached object '{0}' using key '{1}' ", value, key));
                    }
                    else
                    {
                        logger.Debug(String.Format("Cache miss using key '{0}' ", key));
                    }
                    logger.Debug("Cache Hit Ratio [" + Id + "]: " + HitRatio);
                }
                return value;
            }
            set
            {
                if (logger.IsDebugEnabled)
                {
                    logger.Debug(String.Format("Cache object '{0}' using key '{1}' ", value, key));
                }

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
            return delegateCache.Remove(key);
        }

        /// <summary>
        /// Clears all elements from the cache.
        /// </summary>
        public override void Clear()
        {
            if (logger.IsDebugEnabled)
            {
                logger.Debug("Clears cache :" + Id);
            }

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
            return delegateCache.ContainsKey(key);
        }

        /// <summary>
        /// Gets the hit ratio.
        /// </summary>
        /// <value>The hit ratio.</value>
        public double HitRatio
        {
            get
            {
                if (requests != 0)
                {
                    return (double)hits / (double)requests;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
