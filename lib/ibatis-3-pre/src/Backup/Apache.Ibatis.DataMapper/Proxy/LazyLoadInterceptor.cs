
#region Apache Notice
/*****************************************************************************
 * $Revision: 374175 $
 * $LastChangedDate: 2008-06-28 09:26:16 -0600 (Sat, 28 Jun 2008) $
 * $LastChangedBy: gbayon $
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
using System.Collections;
using System.Reflection;
using Apache.Ibatis.Common.Logging;
using Apache.Ibatis.Common.Utilities.Objects.Members;
using Apache.Ibatis.DataMapper.MappedStatements;
using Castle.Core.Interceptor;

#endregion

namespace Apache.Ibatis.DataMapper.Proxy
{
	/// <summary>
	/// Default implementation of the interceptor reponsible of load the lazy element
	/// Could load collections and single objects
	/// </summary>
	[Serializable]
    public class LazyLoadInterceptor : IInterceptor
	{
		#region Fields
		private readonly object param = null;
        private readonly object target = null;
        private readonly ISetAccessor setAccessor = null;
        private readonly IDataMapper dataMapper = null;
        private readonly string statementName = string.Empty;
		private bool loaded = false;
		private object lazyLoadedItem = null;
        private readonly object syncLock = new object();
        private readonly static ArrayList passthroughMethods = new ArrayList();

		private static readonly ILog _logger = LogManager.GetLogger( MethodBase.GetCurrentMethod().DeclaringType );
		#endregion

		#region  Constructor (s) / Destructor

		/// <summary>
		/// Static Constructor for a lazy list loader
		/// </summary>
		static LazyLoadInterceptor()
		{
			passthroughMethods.Add("GetType");
		}

        /// <summary>
        /// Constructor for a lazy list loader
        /// </summary>
        /// <param name="dataMapper">The data mapper.</param>
        /// <param name="mappedSatement">The mapped statement used to build the list</param>
        /// <param name="param">The parameter object used to build the list</param>
        /// <param name="target">The target object which contains the property proxydied.</param>
        /// <param name="setAccessor">The proxified member accessor.</param>
        public LazyLoadInterceptor(
            IDataMapper dataMapper,
            IMappedStatement mappedSatement, object param,
			object target, ISetAccessor setAccessor)
		{
			this.param = param;
			statementName = mappedSatement.Id;
            this.dataMapper = dataMapper;
			this.target = target;
			this.setAccessor = setAccessor;
		}		
		#endregion

		#region IInterceptor member

		/// <summary>
		/// Intercepts the specified invocation., params object[] arguments
		/// </summary>
		/// <param name="invocation">The invocation.</param>
		/// <returns></returns>
        public virtual void Intercept(IInvocation invocation)
		{
			if (_logger.IsDebugEnabled) 
			{
				_logger.Debug("Proxyfying call to " + invocation.Method.Name);
			}

			lock(syncLock)
			{
				if ((loaded == false) && (!passthroughMethods.Contains(invocation.Method.Name)))
				{
					if (_logger.IsDebugEnabled) 
					{
						_logger.Debug("Proxyfying call, query statement " + statementName);
					}
		
					//Perform load
                    if (typeof(IList).IsAssignableFrom(setAccessor.MemberType))
					{
						lazyLoadedItem = dataMapper.QueryForList(statementName, param);
					}
					else
					{
						lazyLoadedItem = dataMapper.QueryForObject(statementName, param);
					}

					loaded = true;
					setAccessor.Set(target, lazyLoadedItem);
				}
			}

            try
            {
                invocation.ReturnValue = invocation.Method.Invoke(lazyLoadedItem, invocation.Arguments);
            }
            catch (TargetInvocationException exception)
            {
                PreserveStackTrace(exception);
                throw;
            }

		    if (_logger.IsDebugEnabled) 
			{
				_logger.Debug("End of proxyfied call to " + invocation.Method.Name);
			}
		}

		#endregion

        private void PreserveStackTrace(Exception exception)
        {
            MethodInfo preserveStackTrace = typeof(Exception).GetMethod("InternalPreserveStackTrace",
              BindingFlags.Instance | BindingFlags.NonPublic);
            preserveStackTrace.Invoke(exception, null);
        }
	}
}
