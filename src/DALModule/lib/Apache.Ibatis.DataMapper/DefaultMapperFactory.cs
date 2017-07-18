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

using System;

namespace Apache.Ibatis.DataMapper
{
    /// <summary>
    /// The default implementation of the <see cref="IMapperFactory"/>  
    /// Responsible to build mapper interface instance
    /// </summary>
    public class DefaultMapperFactory : IMapperFactory, IDataMapperAccessor
    {
        private readonly IDataMapper dataMapper = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultMapperFactory"/> class.
        /// </summary>
        /// <param name="dataMapper">The data mapper.</param>
        public DefaultMapperFactory(IDataMapper dataMapper)
        {
            this.dataMapper = dataMapper;
        }

        #region IMapperFactory Members

        /// <summary>
        /// Gets the mapper.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <returns>
        /// An implementation of the interface that delegates database call to the DataMapper
        /// </returns>
        public TInterface GetMapper<TInterface>()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IDataMapperAccessor Members

        /// <summary>
        /// Gets the <see cref="IDataMapper"/>
        /// </summary>
        /// <value>The data mapper.</value>
        public IDataMapper DataMapper
        {
            get { return dataMapper; }
        }

        #endregion
    }
}
