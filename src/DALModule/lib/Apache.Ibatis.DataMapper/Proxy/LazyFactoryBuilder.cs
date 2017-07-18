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

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using Apache.Ibatis.DataMapper.Exceptions;

namespace Apache.Ibatis.DataMapper.Proxy
{
    /// <summary>
    /// Gets <see cref="ILazyFactory"/> instance.
    /// </summary>
    public class LazyFactoryBuilder
    {
        private readonly IDictionary factory = new HybridDictionary();

        /// <summary>
        /// Initializes a new instance of the <see cref="LazyFactoryBuilder"/> class.
        /// </summary>
        public LazyFactoryBuilder()
        {
            factory[typeof(IList)] = new LazyListFactory();
            factory[typeof(IList<>)] = new LazyListGenericFactory();
        }

        
        /// <summary>
        /// Register (add) a lazy load Proxy for a type and member type
        /// </summary>
        /// <param name="type">The target type which contains the member proxyfied</param>
        /// <param name="memberName">The member name the proxy must emulate</param>
        /// <param name="factory">The <see cref="ILazyFactory"/>.</param>
        public void Register(Type type, string memberName, ILazyFactory factory)
        {
            // for further used, support for custom proxy
        }

        /// <summary>
        /// Get a ILazyLoadProxy for a type, member name
        /// </summary>
        /// <param name="type">The target type which contains the member proxyfied</param>
        /// <returns>Return the ILazyLoadProxy instance</returns>
        public ILazyFactory GetLazyFactory(Type type)
        {
            if (type.IsInterface)
            {
                if (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(IList<>)) )
                {
                    return factory[ type.GetGenericTypeDefinition() ] as ILazyFactory;
                }
                else if (type == typeof(IList))
                {
                    return factory[type] as ILazyFactory;
                }
                else
                {
                    throw new DataMapperException("Cannot proxy others interfaces than IList or IList<>.");
                }
            }
            else
            {
                // if you want to proxy concrete classes, there are also two requirements: 
                // the class can not be sealed and only virtual methods can be intercepted. 
                // The reason is that DynamicProxy will create a subclass of your class overriding all methods 
                // so it can dispatch the invocations to the interceptor.
                return new LazyLoadProxyFactory();
            }
        }
    }
}
