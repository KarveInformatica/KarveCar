#region Apache Notice
/*****************************************************************************
 * $Revision: 408099 $
 * $LastChangedDate: 2008-06-28 09:26:16 -0600 (Sat, 28 Jun 2008) $
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

using System.Collections.Generic;
using System.Xml;
using Apache.Ibatis.Common.Exceptions;

namespace Apache.Ibatis.Common.Configuration
{
    /// <summary>
    ///  Various utility methods relating to attribute configuration reading.
    /// </summary>
    public sealed class ConfigurationUtils
    {
        /// <summary>
        /// Gets the string value of the attribute with the specified name.
        /// </summary>
        /// <param name="config">The config.</param>
        /// <param name="name">The key</param>
        /// <returns>
        /// If the attribute exists, its value otherwise string.Empty
        /// </returns>
        public static string GetMandatoryStringAttribute(IConfiguration config, string name)
        {
            string value = null;
            config.Attributes.TryGetValue(name, out value);
            if (value == null)
            {
                throw new ConfigurationException(
                    string.Format("The '{0}' attribute is mandatory on the {1} '{2}'", name, config.Type, config.Id));
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Gets the string value of the attribute with the specified name.
        /// </summary>
        /// <param name="attributes">The list of attributes</param>
        /// <param name="name">The key</param>
        /// <returns>If the attribute exists, its value otherwise string.Empty</returns>
        public static string GetStringAttribute(IDictionary<string, string> attributes, string name)
        {
            string value = null;
            attributes.TryGetValue(name, out value);
            if (value == null)
            {
                return string.Empty;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Gets the string value of the attribute with the specified name.
        /// </summary>
        /// <param name="attributes">The list of attributes</param>
        /// <param name="name">The key</param>
        /// <param name="def">The default value to be returned if the attribute is not found.</param>
        /// <returns>If the attribute exists its value otherwise the default value</returns>
        public static string GetStringAttribute(IDictionary<string, string> attributes, string name, string def)
        {
            string value = null;
            attributes.TryGetValue(name, out value);
            if (value == null)
            {
                return def;
            }
            else
            {
                return value;
            }
        }
        /// <summary>
        /// Gets the Byte value of the attribute with the specified name.
        /// </summary>
        /// <param name="attributes">The list of attributes</param>
        /// <param name="name">The key</param>
        /// <param name="def">The default value to be returned if the attribute is not found.</param>
        /// <returns>If the attribute exists its value otherwise the default value</returns>
        public static byte GetByteAttribute(IDictionary<string, string> attributes, string name, byte def)
        {
            string value = null;
            attributes.TryGetValue(name, out value);
            if (value == null)
            {
                return def;
            }
            else
            {
                return XmlConvert.ToByte(value);
            }
        }

        /// <summary>
        /// Gets the int value of the attribute with the specified name.
        /// </summary>
        /// <param name="attributes">The list of attributes</param>
        /// <param name="name">The key</param>
        /// <param name="def">The default value to be returned if the attribute is not found.</param>
        /// <returns>If the attribute exists its value otherwise the default value</returns>
        public static int GetIntAttribute(IDictionary<string, string> attributes, string name, int def)
        {
            string value = null;
            attributes.TryGetValue(name, out value);
            if (value == null)
            {
                return def;
            }
            else
            {
                return XmlConvert.ToInt32(value);
            }
        }

        /// <summary>
        /// Gets the long value of the attribute with the specified name.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <param name="name">The name.</param>
        /// <param name="def">The default value to be returned if the attribute is not found.</param>
        /// <returns>If the attribute exists its value otherwise the default value</returns>
        public static long GetLongAttribute(IDictionary<string, string> attributes, string name, long def)
        {
            string value = null;
            attributes.TryGetValue(name, out value);
            if (value == null)
            {
                return def;
            }
            else
            {
                return XmlConvert.ToInt64(value);
            }
        }

        /// <summary>
        /// Gets the bool value of the attribute with the specified name.
        /// </summary>
        /// <param name="attributes">The list of attributes</param>
        /// <param name="name">The key</param>
        /// <param name="def">The default value to be returned if the attribute is not found.</param>
        /// <returns>If the attribute exists its value otherwise the default value</returns>
        public static bool GetBooleanAttribute(IDictionary<string, string> attributes, string name, bool def)
        {
            string value = null;
            attributes.TryGetValue(name, out value);
            if (value == null)
            {
                return def;
            }
            else
            {
                return XmlConvert.ToBoolean(value);
            }
        }
    }
}
