#region Apache Notice
/*****************************************************************************
 * $Revision: 408099 $
 * $LastChangedDate: 2008-10-11 10:07:44 -0600 (Sat, 11 Oct 2008) $
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

#region Remarks
// Inpspired from Spring.NET
#endregion


using System;
using System.Collections.Generic;

namespace Apache.Ibatis.Common.Utilities.TypesResolver
{
    /// <summary>
    /// Resolves (instantiates) a <see cref="System.Type"/> by it's (possibly
    /// assembly qualified) name, and caches the <see cref="System.Type"/>
    /// instance against the type name.
    /// </summary>
	public class CachedTypeResolver : ITypeResolver
    {
        #region Fields
        /// <summary>
        /// The cache, mapping type names (<see cref="System.String"/> instances) against
        /// <see cref="System.Type"/> instances.
        /// </summary>
        private readonly IDictionary<string, Type> _typeCache = new Dictionary<string, Type>();

        private readonly ITypeResolver _typeResolver = null;
        #endregion

        #region Constructor (s) / Destructor
        /// <summary>
        /// Creates a new instance of the <see cref="Apache.Ibatis.Common.Utilities.TypesResolver.CachedTypeResolver"/> class.
        /// </summary>
        /// <param name="typeResolver">
        /// The <see cref="Apache.Ibatis.Common.Utilities.TypesResolver.ITypeResolver"/> that this instance will delegate
        /// actual <see cref="System.Type"/> resolution to if a <see cref="System.Type"/>
        /// cannot be found in this instance's <see cref="System.Type"/> cache.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// If the supplied <paramref name="typeResolver"/> is <see langword="null"/>.
        /// </exception>
        public CachedTypeResolver(ITypeResolver typeResolver)
        {
            _typeResolver = typeResolver;
        }
        #endregion

        #region ITypeResolver Members

        /// <summary>
        /// Resolves the supplied <paramref name="typeName"/> to a
        /// <see cref="System.Type"/>
        /// instance.
        /// </summary>
        /// <param name="typeName">
        /// The (possibly partially assembly qualified) name of a
        /// <see cref="System.Type"/>.
        /// </param>
        /// <returns>
        /// A resolved <see cref="System.Type"/> instance.
        /// </returns>
        /// <exception cref="System.TypeLoadException">
        /// If the supplied <paramref name="typeName"/> could not be resolved
        /// to a <see cref="System.Type"/>.
        /// </exception>
        public Type Resolve(string typeName)
        {
            if (typeName == null || typeName.Trim().Length == 0)
            {
                throw new TypeLoadException("Could not load type from string value '" + typeName + "'.");
            }
            Type type = null;
            try
            {
                if (!_typeCache.TryGetValue(typeName, out type))
                {
                    type = _typeResolver.Resolve(typeName);
                    _typeCache[typeName] = type;
                }
            }
            catch (Exception ex)
            {
                if (ex is TypeLoadException)
                {
                    throw;
                }
                throw new TypeLoadException("Could not load type from string value '" + typeName + "'.", ex);
            }
            return type;
        }


        #endregion
    }
}
