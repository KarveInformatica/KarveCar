#region Apache Notice
/*****************************************************************************
 * $Revision: 408099 $
 * $LastChangedDate: 2008-03-16 02:10:31 -0600 (Sun, 16 Mar 2008) $
 * $LastChangedBy: gbayon $
 * 
 * iBATIS.NET Data Mapper
 * Copyright (C) 2006/2005 - The Apache Software Foundation
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

namespace Apache.Ibatis.Common.Resources
{
    /// <summary>
    /// Assembly resource loader implementation of the
    /// <see cref="Apache.Ibatis.Common.Utilities.Resources.IResourceLoader"/> interface.
    /// </summary>
    /// <remarks>
    /// <p>
    /// This <see cref="Apache.Ibatis.Common.Utilities.Resources.IResourceLoader"/> implementation
    /// allows the creation of embeded assembly resource.
    /// </p>
    /// <p>
    /// URI must be format as assembly://'AssemblyName'/'NameSpace'/'ResourceName'.
    /// </p>
    /// </remarks>
    /// <example>
    /// iBATIS V1 
    /// "Apache.Ibatis.Common.Test.properties.xml, Apache.Ibatis.Common.Test"
    /// 
    /// iBATIS V2
    /// assembly://Apache.Ibatis.Common.Test/Apache.Ibatis.Common.Test/properties.xml
    /// 
    /// "CompanyName.ProductName.Maps.ISCard.xml, OctopusService"
    /// assembly://OctopusService/CompanyName.ProductName.Maps/ISCard.xml
    /// </example>
    public class AssemblyResourceLoader : IResourceLoader
    {
        /// <summary>
        /// The resource is accessed as embedded resource. 
        /// </summary>
        public const string Scheme = "assembly";

        #region IResourceLoader Members

        /// <summary>
        /// Return an <see cref="Apache.Ibatis.Common.Utilities.Resources.IResource"/> handle for the
        /// specified URI.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns>
        /// An appropriate <see cref="Apache.Ibatis.Common.Utilities.Resources.IResource"/> handle.
        /// </returns>
        public IResource Create(Uri uri)
        {
            throw new Exception("The method or operation is not implemented.");
        }


        /// <summary>
        /// Check if this loader accepts the specified URI.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns>True or false</returns>
        public bool Accept(Uri uri)
        {
            return Scheme.Equals(uri.Scheme);
        }

        #endregion
    }
}
