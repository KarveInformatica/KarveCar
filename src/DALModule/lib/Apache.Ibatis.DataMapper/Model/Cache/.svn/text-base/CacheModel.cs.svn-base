
#region Apache Notice
/*****************************************************************************
 * $Revision: 575913 $
 * $LastChangedDate: 2009-06-28 01:03:34 -0600 (Sun, 28 Jun 2009) $
 * $LastChangedBy: rgrabowski $
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

#region Using

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Apache.Ibatis.Common.Contracts;
using Apache.Ibatis.Common.Exceptions;
using Apache.Ibatis.Common.Logging;
using Apache.Ibatis.Common.Logging.Impl;
using Apache.Ibatis.Common.Utilities;
using Apache.Ibatis.DataMapper.MappedStatements;
using Apache.Ibatis.DataMapper.Model.Cache.Decorators;

#endregion

namespace Apache.Ibatis.DataMapper.Model.Cache
{

    /// <summary>
    /// Summary description for CacheModel.
    /// </summary>
	[Serializable]
    [DebuggerDisplay("CacheModel: {Id}-{Cache}")]
	public class CacheModel
	{
		private ICache cache = null;
        private readonly IList<string> statementFlushNames = new List<string>();

        /// <summary>
        /// This is used to represent null objects that are returned from the cache so 
        /// that they can be cached, too.
        /// </summary>
        public readonly static object NULL_OBJECT = new Object(); 

		/// <summary>
		/// Identifier used to identify the CacheModel amongst the others.
		/// </summary>
		public string Id
		{
            get { return cache.Id; }
		}


        /// <summary>
        /// Gets the statement flush on execute names.
        /// </summary>
        /// <value>The statement flush names.</value>
        public IList<string> StatementFlushNames
        {
            get { return statementFlushNames; }
        }

		/// <summary>
		/// Set the cache implementation
		/// </summary>
		public ICache Cache
		{
            get { return cache; }
            set { cache = value; }
		}

        /// <summary>
		/// Adds an item with the specified key and value into cached data.
		/// Gets a cached object with the specified key.
		/// </summary>
		/// <value>The cached object or <c>null</c></value>
        public object this[CacheKey key]
        {
            get { return cache[key]; }
            set { cache[key] = value;}
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheModel"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="implementation">The cache implementation.</param>
        /// <param name="flushInterval">The flush interval.</param>
        /// <param name="size">The size.</param>
        /// <param name="isShare">if set to <c>true</c> [is share].</param>
        public CacheModel(
            string id,
            string implementation,
            long flushInterval,
            int size,
            bool isShare) 
		{
            Contract.Require.That(id, Is.Not.Null & Is.Not.Empty).When("retrieving argument id in CacheModel constructor");
            Contract.Require.That(implementation, Is.Not.Null & Is.Not.Empty).When("retrieving argument implementation in CacheModel constructor");

			try 
			{
				// Build the Cache
                Type type = TypeUtils.ResolveType(implementation);
                object[] arguments = new object[0];

                cache = (ICache)Activator.CreateInstance(type, arguments);
			    cache.Id = id;
			    cache = new NullValueDecorator(cache);

                if (size != int.MinValue)
                {
                    cache.Size = size;
                }
                if (flushInterval != long.MinValue)
                {
                    cache = cache = new ScheduledCache(cache, flushInterval);
                }
                if (isShare)
                {
                    cache = cache = new SharedCache(cache);
                }
                if (!(LogManager.Adapter is NoOpLoggerFA))
                {
                    cache = new LoggingCache(cache);
                }
			    cache = new SynchronizedCache(cache);
			} 
			catch (Exception e) 
			{
				throw new ConfigurationException("Error instantiating cache implementation for cache '"+id+". Cause: " + e.Message, e);
			}
		}


		/// <summary>
		/// Event listener
		/// </summary>
		/// <param name="mappedStatement">A MappedStatement on which we listen ExecuteEventArgs event.</param>
		public void RegisterTriggerStatement(IMappedStatement mappedStatement)
		{
			mappedStatement.Executed +=FlushHandler;
		}
		
		
		/// <summary>
		/// FlushHandler which clear the cache 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FlushHandler(object sender, ExecuteEventArgs e)
		{
			cache.Clear();
		}
	}
}
