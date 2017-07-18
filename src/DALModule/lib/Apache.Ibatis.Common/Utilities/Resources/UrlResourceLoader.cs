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
using Apache.Ibatis.Common.Exceptions;

namespace Apache.Ibatis.Common.Resources
{
    /// <summary>
    /// Url resource loader implementation of the
    /// <see cref="Apache.Ibatis.Common.Utilities.Resources.IResourceLoader"/> interface.
    /// </summary>
    /// <remarks>
    /// <p>
    /// This <see cref="Apache.Ibatis.Common.Utilities.Resources.IResourceLoader"/> implementation
    /// allows the creation of embeded assembly resource.
    /// </p>
    /// <remarks>
    /// <p>
    /// Obviously supports resolution as a <see cref="System.Uri"/>, and also
    /// as a <see cref="System.IO.FileInfo"/> in the case of the <c>"file:"</c>
    /// protocol.
    /// </p>
    /// </remarks>
    /// <example>
    /// <p>
    /// Some examples of the strings that can be used to initialize a new
    /// instance of the <see cref="Apache.Ibatis.Common.Utilities.Resources.UrlResource"/> class
    /// include...
    /// <list type="bullet">
    /// <item>
    /// <description>ftp://Config/SqlMap.config</description>
    /// </item>
    /// <item>
    /// <description>http://www.mycompany.com/SqlMap.config</description>
    /// </item>
    /// </list>
    /// </p>
    /// </example>
    /// </remarks>
    public class UrlResourceLoader : IResourceLoader
    {

        /// <summary>
        /// The resource is accessed through FTP. 
        /// </summary>
        public const string SchemeFtp = "ftp";
        /// <summary>
        /// The resource is accessed through HTTP. 
        /// </summary>
        public const string SchemeHttp = "http";
        /// <summary>
        /// The resource is accessed through SSL-encrypted HTTP. 
        /// </summary>
        public const string SchemeHttps = "https";

        #region IResourceLoader Members

        /// <summary>
        /// Check if this loader accepts the specified URI.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns>True or false</returns>
        public bool Accept(Uri uri)
        {
            return (SchemeFtp.Equals(uri.Scheme) ||
                SchemeHttp.Equals(uri.Scheme) ||
                SchemeHttps.Equals(uri.Scheme));
        }

        /// <summary>
        /// Return an <see cref="Apache.Ibatis.Common.Utilities.Resources.IResource"/> handle for the
        /// specified URI.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>
        /// An appropriate <see cref="Apache.Ibatis.Common.Utilities.Resources.IResource"/> handle.
        /// </returns>
        public IResource Create(Uri resource)
        {
            if (Accept(resource))
           {
               return new UrlResource(resource);
           }
           else
           {
               throw new ResourceException(string.Format( 
                    "{0} cannot be resolved - " +
                    "resource does not use '{1}:', '{2}:', '{3}:'  protocols.", resource, SchemeFtp, SchemeHttp, SchemeHttps));
           }
        }


        #endregion
    }
}
