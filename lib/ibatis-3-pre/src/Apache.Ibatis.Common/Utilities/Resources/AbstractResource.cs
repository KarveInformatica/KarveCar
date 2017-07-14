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
using System.IO;

namespace Apache.Ibatis.Common.Resources
{
    /// <summary>
    /// Convenience base class for <see cref="Apache.Ibatis.Common.Utilities.Resources.IResource"/>
    /// implementations, pre-implementing typical behavior.
    /// </summary>
    public abstract class AbstractResource : IResource
    {
        /// <summary>
        /// The default special character that denotes the base (home, or root)
        /// path.
        /// </summary>
        protected const string DefaultBasePathPlaceHolder = "~";

        #region IResource Members

        /// <summary>
        /// Returns the <see cref="System.Uri"/> handle for this resource.
        /// </summary>
        /// <value></value>
        public abstract Uri Uri { get; }

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
        public abstract FileInfo FileInfo { get; }

        /// <summary>
        /// Return an <see cref="System.IO.Stream"/> for this resource.
        /// </summary>
        /// <value>An <see cref="System.IO.Stream"/>.</value>
        /// <remarks>
        /// 	<note type="caution">
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
        public abstract Stream Stream { get; }

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
        public abstract string Description { get; }


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
        public abstract IResource CreateRelative(String relativePath);

        #endregion

        /// <summary>
        /// Strips any protocol name from the supplied
        /// <paramref name="resourceName"/>.
        /// </summary>
        /// <remarks>
        /// <p>
        /// If the supplied <paramref name="resourceName"/> does not
        /// have any protocol associated with it, then the supplied
        /// <paramref name="resourceName"/> will be returned as-is.
        /// </p>
        /// </remarks>
        /// <example>
        /// <code language="C#">
        /// GetResourceNameWithoutProtocol("http://www.mycompany.com/resource.txt");
        ///		// returns www.mycompany.com/resource.txt
        /// </code>
        /// </example>
        /// <param name="resource">
        /// An Uri resource.
        /// </param>
        /// <returns>
        /// The name of the resource without the protocol name.
        /// </returns>
        protected static string GetResourceNameWithoutProtocol(Uri resource)
        {
            int index = resource.Scheme.Length + Uri.SchemeDelimiter.Length;

            if (index == -1)
            {
                return resource.AbsoluteUri;
            }
            else
            {
                return resource.AbsoluteUri.Substring(index); ;
            }
        }

        /// <summary>
        /// This implementation returns the
        /// <see cref="Description"/> of this resource.
        /// </summary>
        /// <seealso cref="Apache.Ibatis.Common.Utilities.Resources.IResource.Description"/>
        public override string ToString()
        {
            return Description;
        }

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public abstract void Dispose();

        #endregion

    }
}
