
#region Apache Notice
/*****************************************************************************
 * $Revision: 408099 $
 * $LastChangedDate: 2008-06-28 09:50:38 -0600 (Sat, 28 Jun 2008) $
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
using System.IO;
using System.Reflection;
using System.Security.Permissions;
using System.Xml;
using Apache.Ibatis.Common.Contracts;
using Apache.Ibatis.Common.Exceptions;
using Apache.Ibatis.Common.Logging;

#endregion

namespace Apache.Ibatis.Common.Resources
{
	/// <summary>
	/// A class to simplify access to resources.
	/// 
	/// The file can be loaded from the application root directory 
	/// (use the resource attribute) 
	/// or from any valid URL (use the url attribute). 
	/// For example,to load a fixed path file, use:
	/// &lt;properties url=”file:///c:/config/my.properties” /&gt;
	/// </summary>
	public class Resources
	{

		#region Fields

        public static readonly string ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

        public static readonly string DefaultBasePath = AppDomain.CurrentDomain.BaseDirectory;

		private static readonly ILog _logger = LogManager.GetLogger( MethodBase.GetCurrentMethod().DeclaringType );

		#endregion

		#region Methods

        /// <summary>
        /// Determines whether the specified file exists.
        /// </summary>
        /// <param name="filePath">The file to check.</param>
        /// <returns>
        /// true if the caller has the required permissions and path contains the name of an existing file
        /// false if the caller has the required permissions and path doesn't contain the name of an existing file
        /// else exception
        /// </returns>
        public static bool FileExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                // true if the caller has the required permissions and path contains the name of an existing file; 
                return true;
            }
            else
            {
                // This method also returns false if the caller does not have sufficient permissions 
                // to read the specified file, 
                // no exception is thrown and the method returns false regardless of the existence of path.
                // So we check permissiion and throw an exception if no permission
                FileIOPermission filePermission = null;
                try
                {
                    // filePath must be the absolute path of the file. 
                    filePermission = new FileIOPermission(FileIOPermissionAccess.Read, filePath);
                }
                catch
                {
                    return false;
                }
                try
                {
                    filePermission.Demand();
                }
                catch (Exception e)
                {
                    throw new ResourceException(
                        string.Format("iBATIS doesn't have the right to read the config file \"{0}\". Cause : {1}",
                        filePath,
                        e.Message), e);
                }

                return false;
            }
        }


        /// <summary>
        /// Gets as XML document from the specified uri.
        /// </summary>
        /// <param name="uri">The URI.</param>
        ///// <param name="configStore">The config store.</param>, IConfigurationStore configStore
        /// <returns>Return the Xml document load.</returns>
        public static XmlDocument GetUriAsXmlDocument(string uri)
        {
            Contract.Require.That(uri, Is.Not.Null & Is.Not.Empty).When("retrieving uri in GetUriAsXmlDocument method");

            IResource resource = ResourceLoaderRegistry.GetResource(uri);

            XmlDocument xmlDocument = GetStreamAsXmlDocument(resource.Stream);

            return xmlDocument;
        }

		/// <summary>
		/// Get XmlDocument from a stream resource
		/// </summary>
		/// <param name="resource"></param>
		/// <returns></returns>
		public static XmlDocument GetStreamAsXmlDocument(Stream resource)
		{
			XmlDocument config = new XmlDocument();

			try 
			{
				config.Load(resource);
			}
			catch(Exception e)
			{
				throw new ConfigurationException(
					string.Format("Unable to load XmlDocument via stream. Cause : {0}", 
					e.Message ) ,e); 
			}

			return config;
		}

        /// <summary>
        /// Gets the URI as XML reader.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns></returns>
        public static XmlTextReader GetUriAsXmlReader(string uri)
        {
            Contract.Require.That(uri, Is.Not.Null & Is.Not.Empty).When("retrieving uri in GetUriAsXmlReader method");

            IResource resource = ResourceLoaderRegistry.GetResource(uri);

            return GetStreamAsXmlReader(resource.Stream);
        }

        /// <summary>
        /// Gets the stream as XML reader.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns></returns>
        public static XmlTextReader GetStreamAsXmlReader(Stream resource)
        {
            Contract.Require.That(resource, Is.Not.Null).When("Getting stream As XmlReader");

            XmlTextReader reader = null;

            try
            {
                reader = new XmlTextReader(resource);
            }
            catch (Exception e)
            {
                throw new ConfigurationException(
                    string.Format("Unable to load XmlReader via stream. Cause : {0}",
                    e.Message), e);
            }

            return reader;
        }

		#endregion

	}
}
