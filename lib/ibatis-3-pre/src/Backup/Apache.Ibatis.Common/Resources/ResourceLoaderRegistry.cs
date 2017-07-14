#region Apache Notice
/*****************************************************************************
 * $Revision: 408099 $
 * $LastChangedDate: 2008-06-28 11:17:59 -0600 (Sat, 28 Jun 2008) $
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
using System.Collections.Generic;
using Apache.Ibatis.Common.Contracts;

namespace Apache.Ibatis.Common.Resources
{
    /// <summary>
    /// Registry class that allows to register and retrieve resource loader.
    /// </summary>
    public class ResourceLoaderRegistry
    {
        private static readonly IDictionary<string, IResourceLoader> resourceLoaders = new Dictionary<string, IResourceLoader>();
        private static readonly object syncLock = new object();

        /// <summary>
        /// Event launch on processing file resource
        /// </summary>
        public static event EventHandler<FileResourceLoadEventArgs> LoadFileResource = delegate { };

        /// <summary>
        /// Registers standard and user-configured resource handlers.
        /// </summary>
        static ResourceLoaderRegistry()
        {
            lock (syncLock)
            {
                resourceLoaders[FileResourceLoader.Scheme] = new FileResourceLoader();
                resourceLoaders[UrlResourceLoader.SchemeHttp] = new UrlResourceLoader();
                resourceLoaders[UrlResourceLoader.SchemeHttps] = new UrlResourceLoader();
                resourceLoaders[UrlResourceLoader.SchemeFtp] = new UrlResourceLoader();
                resourceLoaders[AssemblyResourceLoader.Scheme] = new AssemblyResourceLoader();

                // register custom resource handlers
                //ConfigurationUtils.GetSection(ResourcesSectionName);
            }
        }

        /// <summary>
        /// Return an <see cref="Apache.Ibatis.Common.Resources.IResource"/> for the
        /// specified string address.
        /// </summary>
        /// <param name="resource">The string adress.</param>
        /// <returns>
        /// An appropriate <see cref="Apache.Ibatis.Common.Resources.IResource"/>.
        /// </returns>
        public static IResource GetResource(string resource)
        {
            Contract.Require.That(resource, Is.Not.Null & Is.Not.Empty).When("retrieving resource argument in GetResource method");

            CustomUriBuilder builder = new CustomUriBuilder(resource, Resources.DefaultBasePath);

            IResourceLoader loader = resourceLoaders[builder.Uri.Scheme];
            IResource res = loader.Create(builder.Uri);

            if (loader is FileResourceLoader)
            {
                FileResourceLoadEventArgs evnt = new FileResourceLoadEventArgs();
                evnt.FileInfo = res.FileInfo;

                LoadFileResource(loader, evnt);
            }
            return res;
        }

        /// <summary>
        /// Resets the event handler.
        /// </summary>
        public static void ResetEventHandler()
        {
            LoadFileResource = delegate { };
        }

    }
}
