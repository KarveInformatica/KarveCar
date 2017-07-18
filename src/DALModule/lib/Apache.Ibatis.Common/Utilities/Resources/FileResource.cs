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
using System.Globalization;
using System.IO;
using System.Security.Permissions;
using Apache.Ibatis.Common.Exceptions;

namespace Apache.Ibatis.Common.Resources
{
    /// <summary>
    /// A <see cref="System.IO.File"/> backed resource.
    /// </summary>
    public class FileResource : AbstractResource
    {
        private Uri _uri = null;
        private Stream _stream = null;
        private FileInfo _fileInfo = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="UrlResource"/> class.
        /// </summary>
        /// <param name="resource">The URI.</param>
        public FileResource(Uri resource)
        {
            if (!resource.IsFile)
            {
                throw new FileNotFoundException(string.Format(" This pecified resource {0} is not a file.", resource));
            }
            _uri = resource;

            string filePath = GetResourceNameWithoutProtocol(Uri);

            if (filePath[0] == '/')
            {
                filePath = filePath.Substring(1);
            }
            if (filePath[filePath.Length - 1] == '/')
            {
                filePath = filePath.Substring(0, filePath.Length - 1);
            }

            CreateFileInfoStream(filePath);
        }

        private void CreateFileInfoStream(String filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException("filePath");
            }

            if (!Path.IsPathRooted(filePath) || !FileExists(filePath))
            {
                // For a relative path, we use the ApplicationBase to
                // resolve the full path

                filePath = Path.Combine(Resources.ApplicationBase, filePath);
            }

            Console.WriteLine(filePath);

            _fileInfo = new FileInfo(filePath);
            //Uri.LocalPath
            _stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        }

        /// <summary>
        /// Determines whether the specified file exists.
        /// </summary>
        /// <param name="filePath">The file to check.</param>
        /// <returns>
        /// true if the caller has the required permissions and path contains the name of an existing file
        /// false if the caller has the required permissions or path doesn't contain the name of an existing file
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

        #region IResource Members

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
            get { throw new Exception("The method or operation is not implemented."); }
        }

        /// <summary>
        /// Returns the <see cref="System.Uri"/> handle for this resource.
        /// </summary>
        /// <value></value>
        public override Uri Uri
        {
            get { return _uri; }
        }

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
        public override Stream Stream
        {
            get { return _stream; }
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
        /// <summary>
        /// Returns a description for this resource.
        /// </summary>
        /// <value>
        /// A description for this resource.
        /// </value>
        public override string Description
        {
            get
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "file [{0}]", _fileInfo.FullName);
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
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public override void Dispose()
        {
            throw new Exception("The method or operation is not implemented.");
        }


        #endregion

    }
}
