using System;
using System.Xml;
using System.Collections.Specialized;

#region Apache Notice
/*****************************************************************************
 * $Revision: 387044 $
 * $LastChangedDate: 2008-10-11 10:07:44 -0600 (Sat, 11 Oct 2008) $
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

namespace Apache.Ibatis.Common.Xml
{
	/// <summary>
	/// Summary description for NodeUtils.
	/// </summary>
	public sealed class NodeUtils
	{

		/// <summary>
		/// Searches for the attribute with the specified name in this attributes list.
		/// </summary>
		/// <param name="attributes"></param>
		/// <param name="name">The key</param>
		/// <returns></returns>
		public static string GetStringAttribute(NameValueCollection attributes, string name) 
		{
			string value = attributes[name];
			if (value == null) 
			{
				return string.Empty;
			}
		    return value;
		}

		/// <summary>
		/// Searches for the attribute with the specified name in this attributes list.
		/// </summary>
		/// <param name="attributes"></param>
		/// <param name="name">The key</param>
		/// <param name="def">The default value to be returned if the attribute is not found.</param>
		/// <returns></returns>
		public static string GetStringAttribute(NameValueCollection attributes, string name, string def) 
		{
			string value = attributes[name];
			if (value == null) 
			{
				return def;
			}
		    return value;
		}
		/// <summary>
		/// Searches for the attribute with the specified name in this attributes list.
		/// </summary>
		/// <param name="attributes"></param>
		/// <param name="name">The key</param>
		/// <param name="def">The default value to be returned if the attribute is not found.</param>
		/// <returns></returns>
		public static byte GetByteAttribute(NameValueCollection attributes, string name, byte def) 
		{
			string value = attributes[name];
			if (value == null) 
			{
				return def;
			}
		    return XmlConvert.ToByte(value);
		}

		/// <summary>
		/// Searches for the attribute with the specified name in this attributes list.
		/// </summary>
		/// <param name="attributes"></param>
		/// <param name="name">The key</param>
		/// <param name="def">The default value to be returned if the attribute is not found.</param>
		/// <returns></returns>
		public static int GetIntAttribute(NameValueCollection attributes, string name, int def) 
		{
			string value = attributes[name];
			if (value == null) 
			{
				return def;
			}
		    return XmlConvert.ToInt32(value);
		}

		/// <summary>
		/// Searches for the attribute with the specified name in this attributes list.
		/// </summary>
		/// <param name="attributes"></param>
		/// <param name="name">The key</param>
		/// <param name="def">The default value to be returned if the attribute is not found.</param>
		/// <returns></returns>
		public static bool GetBooleanAttribute(NameValueCollection attributes, string name, bool def) 
		{
			string value = attributes[name];
			if (value == null) 
			{
				return def;
			}
		    return XmlConvert.ToBoolean(value);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		public static NameValueCollection ParseAttributes(XmlNode node) 
		{
			return ParseAttributes(node, null);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="node"></param>
		/// <param name="variables"></param>
		/// <returns></returns>
		public static NameValueCollection ParseAttributes(XmlNode node, NameValueCollection variables) 
		{
			NameValueCollection attributes = new NameValueCollection();
			int count = node.Attributes.Count;
			for (int i = 0; i < count; i++) 
			{
				XmlAttribute attribute = node.Attributes[i];
				String value = ParsePropertyTokens(attribute.Value, variables);
				attributes.Add(attribute.Name, value);
			}
			return attributes;
		}


		/// <summary>
		/// Replace properties by their values in the given string
		/// </summary>
		/// <param name="str"></param>
		/// <param name="properties"></param>
		/// <returns></returns>
		public static string ParsePropertyTokens(string str, NameValueCollection  properties) 
		{
			const string OPEN = "${";
			const string CLOSE = "}";

			string newString = str;
			if (newString != null && properties != null) 
			{
				int start = newString.IndexOf(OPEN);
				int end = newString.IndexOf(CLOSE);

				while (start > -1 && end > start) 
				{
					string prepend = newString.Substring(0, start);
					string append = newString.Substring(end + CLOSE.Length);

					int index = start + OPEN.Length;
					string propName = newString.Substring(index, end-index);
					string propValue = properties.Get(propName);
					if (propValue == null) 
					{
						newString = prepend + propName + append;
					} 
					else 
					{
						newString = prepend + propValue + append;
					}
					start = newString.IndexOf(OPEN);
					end = newString.IndexOf(CLOSE);
				}
			}
			return newString;
		}

	}
}
