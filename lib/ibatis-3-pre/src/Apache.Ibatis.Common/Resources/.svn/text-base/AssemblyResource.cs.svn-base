#region Apache Notice
/*****************************************************************************
 * $Revision: 408099 $
 * $LastChangedDate: 2008-10-16 12:14:45 -0600 (Thu, 16 Oct 2008) $
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
using System.IO;
using System.Reflection;
using System.Globalization;

using Apache.Ibatis.Common.Exceptions;
using Apache.Ibatis.Common.Contracts;

namespace Apache.Ibatis.Common.Resources
{
    /// <summary>
    /// An <see cref="Apache.Ibatis.Common.Resources.IResource"/> implementation for
    /// resources stored within assemblies.
    /// </summary>
    public class AssemblyResource : AbstractResource
    {
        private readonly Uri uri = null;
        private readonly string resourceName = string.Empty;
        private readonly string fullResourceName = string.Empty;
        private readonly string resourceAssemblyName = string.Empty;
        private readonly Assembly assembly = null;

        /// <summary>
        /// Is the type name being resolved assembly qualified ?
        /// </summary>
        public bool IsAssemblyQualified
        {
            get
            {
                if (resourceAssemblyName == null || resourceAssemblyName.Trim().Length == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyResource"/> class.
        /// </summary>
        /// <param name="uri">The URI.</param>
        public AssemblyResource(Uri uri)
        {
            Contract.Require.That(uri, Is.Not.Null).When("retrieving uri argument in AssemblyResource constructor");

            this.uri = uri;
            string[] info = GetResourceNameWithoutProtocol(uri).Split('/');

            if (info.Length != 3)
            {
                throw new ResourceException(
                    "Invalid resource for '" + uri.OriginalString + "'. It has to be in " +
                        "'assembly:<assemblyName>/<namespace>/<resourceName>' format. The uri is case sensitive.");
            }

            resourceAssemblyName = info[0];

            assembly = Assembly.Load(resourceAssemblyName);
            
            if (assembly == null)
            {
                throw new ResourceException("Unable to load assembly [" + resourceAssemblyName + "]");
            }

            fullResourceName = String.Format("{0}.{1}.{2}", info[0], info[1], info[2]);
            resourceName = String.Format("{0}.{1}", info[1], info[2]);
        }

        /// <summary>
        /// Returns the <see cref="System.Uri"/> handle for this resource.
        /// </summary>
        /// <value></value>
        public override Uri Uri
        {
            get { return uri; }
        }

        /// <summary>
        /// Returns a <see cref="System.IO.FileInfo"/> handle for this resource.
        /// </summary>
        /// <value>The <see cref="System.IO.FileInfo"/> handle for this resource.</value>
        /// <remarks>
        /// 	<p>
        /// For safety, always check the value of the
        /// <see cref="System.Uri.IsFile "/> property prior to
        /// accessing this property; resources that cannot be exposed as
        /// a <see cref="System.IO.FileInfo"/> will typically return
        /// <see langword="false"/> from a call to this property.
        /// </p>
        /// </remarks>
        /// <exception cref="System.IO.IOException">
        /// If the resource is not available on a filesystem, or cannot be
        /// exposed as a <see cref="System.IO.FileInfo"/> handle.
        /// </exception>
        public override FileInfo FileInfo
        {
            get { throw new NotImplementedException("The method or operation is not implemented."); }
        }

        /// <summary>
        /// Return an <see cref="System.IO.Stream"/> for this resource.
        /// </summary>
        /// <value>An <see cref="System.IO.Stream"/>.</value>
        /// <remarks>
        /// <note type="caution">
        /// Clients of this interface must be aware that every access of this
        /// property will create a <i>fresh</i>
        /// 		<see cref="System.IO.Stream"/>;
        /// it is the responsibility of the calling code to close any such
        /// <see cref="System.IO.Stream"/>.
        /// </note>
        /// </remarks>
        /// <exception cref="System.IO.IOException">
        /// If the stream could not be opened.
        /// </exception>
        public override Stream Stream
        {
            get 
            {
                if (IsAssemblyQualified)
                {
                    stream = assembly.GetManifestResourceStream(fullResourceName);

                    // JIRA - IBATISNET-103 
                    if (stream == null)
                    {
                        stream = assembly.GetManifestResourceStream(resourceName);
                    }
                }
                else
                {
                    // bare type name... loop thru all loaded assemblies
                    Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
                    for (int i = 0; i < assemblies.Length; i++)
                    {
                        Assembly ass = assemblies[i];
                        stream = ass.GetManifestResourceStream(fullResourceName);
                        if (stream == null)
                        {
                            stream = ass.GetManifestResourceStream(resourceName);
                        }

                        if (stream != null)
                        {
                            break;
                        }
                    }
                }
                
                Contract.Assert.That<ResourceException>(stream, Is.Not.Null).When(
                    "getting stream from assembly resource with name = [" + resourceName +
                        "] from assembly [" + assembly + "]. Uri specified is " + uri.OriginalString
                        +" iBATIS.Net Uri syntax is 'assembly://assemblyName/namespace/resourceName'.");

                return stream;
            }
        }

        /// <summary>
        /// Returns a description for this resource.
        /// </summary>
        /// <value>A description for this resource.</value>
        /// <remarks>
        /// 	<p>
        /// The description is typically used for diagnostics and other such
        /// logging when working with the resource.
        /// </p>
        /// 	<p>
        /// Implementations are also encouraged to return this value from their
        /// <see cref="System.Object.ToString()"/> method.
        /// </p>
        /// </remarks>
        public override string Description
        {
            get
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "assembly [{0}], resource [{1}]", assembly.FullName, resourceName);
            }
        }

        /// <summary>
        /// Creates a resource relative to this resource.
        /// </summary>
        /// <param name="relativePath">The path (always resolved as relative to this resource).</param>
        /// <returns>The relative resource.</returns>
        /// <exception cref="System.IO.IOException">
        /// If the relative resource could not be created from the supplied
        /// path.
        /// </exception>
        /// <exception cref="System.NotSupportedException">
        /// If the resource does not support the notion of a relative path.
        /// </exception>
        public override IResource CreateRelative(string relativePath)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        /// <summary>
        /// Strips any protocol name from the supplied
        /// <paramref name="uriParam"/>.
        /// </summary>
        /// <param name="uriParam">An Uri resource.</param>
        /// <returns>
        /// The name of the resource without the protocol name.
        /// </returns>
        /// <remarks>
        /// 	<p>
        /// If the supplied <paramref name="uriParam"/> does not
        /// have any protocol associated with it, then the supplied
        /// <paramref name="uriParam"/> will be returned as-is.
        /// </p>
        /// </remarks>
        /// <example>
        /// 	<code language="C#">
        /// GetResourceNameWithoutProtocol("http://www.mycompany.com/resource.txt");
        /// // returns www.mycompany.com/resource.txt
        /// </code>
        /// </example>
        protected override string GetResourceNameWithoutProtocol(Uri uriParam)
        {
            int index = uriParam.Scheme.Length + Uri.SchemeDelimiter.Length;

            if (index == -1)
            {
                return uriParam.AbsoluteUri;
            }
            else
            {
                return uriParam.OriginalString.Substring(index); 
            }
        }
    }
}
