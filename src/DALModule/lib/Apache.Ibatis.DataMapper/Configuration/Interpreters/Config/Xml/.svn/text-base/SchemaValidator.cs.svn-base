#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 591621 $
 * $Date: 2008-06-28 09:26:16 -0600 (Sat, 28 Jun 2008) $
 * 
 * iBATIS.NET Data Mapper
 * Copyright (C) 2008/2005-2008 - The Apache Software Foundation
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
using System.Xml;
using System.Xml.Schema;
using Apache.Ibatis.Common.Contracts;
using Apache.Ibatis.Common.Exceptions;
using CommonExceptions = Apache.Ibatis.Common.Exceptions;

namespace Apache.Ibatis.DataMapper.Configuration.Interpreters.Config.Xml
{

    /// <summary>
    /// Validates XmlNode againts a schema
    /// </summary>
    public static class SchemaValidator
    {

        /// <summary>
        /// Validates an XmlNode against a schema file.
        /// </summary>
        /// <param name="section">The doc to validate.</param>
        /// <param name="schemaFileName">Schema file name.</param>
        public static void Validate(XmlNode section, string schemaFileName)
        {
            XmlReader validatingReader = null;
            Stream schemaXSD = null;
            ValidationResult result = new ValidationResult();

            try
            {
                //Validate the document using a schema               
                schemaXSD = Assembly.GetExecutingAssembly().GetManifestResourceStream("Apache.Ibatis.DataMapper." + schemaFileName); ;

                Contract.Assert.That(schemaXSD, Is.Not.Null).When("loading embedded resource [Apache.Ibatis.DataMapper." + schemaFileName + "]. If you are building from source, verfiy the file is marked as an embedded resource.");

                XmlSchema schema = XmlSchema.Read(schemaXSD, delegate(object sender, ValidationEventArgs args)
                                                       {
                                                           result.IsValid = false;
                                                           result.ErrorMessage += args.Message + Environment.NewLine;
                                                       });

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;

                // Create the XmlSchemaSet class.
                XmlSchemaSet schemas = new XmlSchemaSet();
                schemas.Add(schema);

                settings.Schemas = schemas;
                validatingReader = XmlReader.Create(new XmlNodeReader(section), settings);

                // Wire up the call back.  The ValidationEvent is fired when the
                // XmlValidatingReader hits an issue validating a section of the xml
                settings.ValidationEventHandler += delegate(object sender, ValidationEventArgs args)
                                                       {
                                                           result.IsValid = false;
                                                           result.ErrorMessage += args.Message + Environment.NewLine;
                                                       };

                // Validate the document
                while (validatingReader.Read()) { }

                if (!result.IsValid)
                {
                    throw new ConfigurationException("Invalid config document. cause :" + result.ErrorMessage);
                }
            }
            finally
            {
                if (validatingReader != null) validatingReader.Close();
                if (schemaXSD != null) schemaXSD.Close();
            }
        }

        /// <summary>
        /// The schema validation result
        /// </summary>
        private class ValidationResult
        {
            private bool isValid = true;
            private string errorMsg = string.Empty;

            /// <summary>
            /// Gets or sets a value indicating whether this instance is valid.
            /// </summary>
            /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
            public bool IsValid
            {
                get { return isValid; }
                set { isValid = value; }
            }

            /// <summary>
            /// Gets or sets the error message.
            /// </summary>
            /// <value>The error message.</value>
            public string ErrorMessage
            {
                get { return errorMsg; }
                set { errorMsg = value; }
            }
        }

    }
}
