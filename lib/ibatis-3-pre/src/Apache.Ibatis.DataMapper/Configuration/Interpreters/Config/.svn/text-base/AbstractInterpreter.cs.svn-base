#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 591621 $
 * $Date: 2008-06-28 11:17:59 -0600 (Sat, 28 Jun 2008) $
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
using Apache.Ibatis.Common.Resources;
using Apache.Ibatis.Common.Contracts;

namespace Apache.Ibatis.DataMapper.Configuration.Interpreters.Config
{
    /// <summary>
    /// Provides common methods for those who wants 
    /// to implement <see cref="IConfigurationInterpreter"/>
    /// </summary>
    public abstract class AbstractInterpreter : IConfigurationInterpreter
    {
        private readonly IResource resource = null;

        /// <summary>
        /// Exposes the reference to <see cref="IResource"/>
        /// which the interpreter is likely to hold
        /// </summary>
        public IResource Resource
        {
            get { return resource; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractInterpreter"/> class
        /// from an The <see cref="IResource"/>.
        /// </summary>
        /// <param name="source">The <see cref="IResource"/>.</param>
        public AbstractInterpreter(IResource source)
        {
            Contract.Require.That(source, Is.Not.Null).When("retrieving argument IResource in AbstractInterpreter constructor");

            resource = source;

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractInterpreter"/> class
        /// from a file path.
        /// </summary>
        /// <param name="fileName">The filename.</param>
        public AbstractInterpreter(string fileName)
            : this(ResourceLoaderRegistry.GetResource(fileName))
        {
        }

        /// <summary>
        /// Should obtain the contents from the resource,
        /// interpret it and populate the <see cref="IConfigurationStore"/>
        /// accordingly.
        /// </summary>
        /// <param name="store">The store.</param>
        public abstract void ProcessResource(IConfigurationStore store);
    }
}
