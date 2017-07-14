#region Apache Notice
/*****************************************************************************
 * $Revision: 408099 $
 * $LastChangedDate: 2010-03-10 22:08:07 -0700 (Wed, 10 Mar 2010) $
 * $LastChangedBy: mmccurrey $
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
using System.IO;
using System.Text;
using Apache.Ibatis.Common.Exceptions;
using Apache.Ibatis.Common.Contracts;

namespace Apache.Ibatis.Common.Resources
{
    /// <summary>
    /// Provides a custom constructor for uniform resource identifiers (URIs)
    /// </summary>
    public class CustomUriBuilder
    {
        private Uri _uri = null;

        /// <summary>
        /// The default special character that denotes the base (home, or root)
        /// path.
        /// </summary>
        private const string DefaultBasePathPlaceHolder = "~";

        /// <summary>
        /// Returns the <see cref="System.Uri"/> handle for this resource.
        /// </summary>
        /// <value>
        /// The <see cref="System.Uri"/> handle for this resource.
        /// </value>
        /// <exception cref="System.IO.IOException">
        /// If the resource is not available or cannot be exposed as a
        /// <see cref="System.Uri"/>.
        /// </exception>
        public Uri Uri
        {
            get { return _uri; }
        }

        /// <summary>
        /// Initializes a new instance of the UriBuilder class with the specified 
        /// path or fragment identifier. 
        /// </summary>
        /// <param name="resourceUri">The specified path or fragment identifier</param>
        /// <param name="basePath">The base directory</param>
        /// <exception cref="ResourceException">Thrown when the resource doesn't exist for the supplied URI</exception>
        public CustomUriBuilder(string resourceUri, string basePath)
        {
            string originalResourceName = resourceUri;

            Contract.Require.That(resourceUri, Is.Not.Null & Is.Not.Empty).When("retrieving resourceUri argument in CustomUriBuilder constructor");
            Contract.Require.That(basePath, Is.Not.Null).When("retrieving basePath argument in CustomUriBuilder constructor");

            // Remove file:// to better analyse later
            if (resourceUri.StartsWith(FileResourceLoader.Scheme + Uri.SchemeDelimiter))
            {
                int index = FileResourceLoader.Scheme.Length + Uri.SchemeDelimiter.Length;
                resourceUri = resourceUri.Substring(index);

                // Remove extra slashes used to indicate that resource is local (handle the case "/C:/path1/...")
                if (resourceUri[0] == '/' && resourceUri[2] == ':')
                {
                    resourceUri = resourceUri.Substring(1);
                }
            }

            resourceUri = ResolveBasePathPlaceHolder(resourceUri);

            try
            {
                _uri = new Uri(resourceUri);
            }
            catch
            {
                try
                {

                    if (!Path.IsPathRooted(resourceUri) || !Resources.FileExists(resourceUri))
                    {
                        resourceUri = Path.Combine(basePath, resourceUri);
                    }
                    _uri = new Uri(resourceUri);
                }
                catch(Exception ex)
                {
                    throw new ResourceException("The resource string " + originalResourceName + " cannot be reconize as a valid Uri.", ex);
                }
            }
        }

        /// <summary>
        /// Resolves the presence of the
        /// ~ value in the supplied <paramref name="resourceName"/> into a path.
        /// </summary>
        /// <param name="resourceName">
        /// The name of the resource.
        /// </param>
        private string ResolveBasePathPlaceHolder(string resourceName)
        {
            if (resourceName.Contains(DefaultBasePathPlaceHolder))
            {
                return resourceName.Replace(DefaultBasePathPlaceHolder, AppDomain.CurrentDomain.BaseDirectory).TrimStart();
            }
            return resourceName;
        }
    }
}
