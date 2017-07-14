#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 591621 $
 * $Date: 2008-06-28 09:26:16 -0600 (Sat, 28 Jun 2008) $
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
using System.Xml;

namespace Apache.Ibatis.DataMapper.Configuration.Interpreters.Config.Xml.Processor
{
    /// <summary>
    /// Base class for XmlProcessor
    /// </summary>
    public abstract class BaseXmlProcessor : IDisposable
    {
        protected Stack<Tag> elementStack = new Stack<Tag>();
        protected Dictionary<string, XmlTagHandler> handlers = new Dictionary<string, XmlTagHandler>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseXmlProcessor"/> class.
        /// </summary>
        public BaseXmlProcessor()
        {
            RegisterElementHandler(ConfigConstants.ELEMENT_TEXT, ProcessTextElement);
            RegisterElementHandlers();
        }

        /// <summary>
        /// Registers the element handler.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        /// <param name="handler">The handler.</param>
        public virtual void RegisterElementHandler(string elementName, XmlTagHandler handler)
        {
            handlers.Add(elementName, handler);
        }

        /// <summary>
        /// Registers the element handlers.
        /// </summary>
        protected abstract void RegisterElementHandlers();

        /// <summary>
        /// Processes the specified reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="configurationStore">The configuration store.</param>
        public virtual void Process(XmlTextReader reader, IConfigurationStore configurationStore)
        {
            bool lastElementEmpty = false;

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element || reader.NodeType == XmlNodeType.EndElement)
                {
                    if (!reader.IsStartElement())
                    {
                        //pop off because we reached a closing tag
                        elementStack.Pop();
                        continue;
                    }
                    else if (lastElementEmpty)
                    {
                        //pop off because this is not a sub-element of last
                        elementStack.Pop();
                    }
                    Tag parent = elementStack.Count == 0 ? null : elementStack.Peek();

                    Tag tag = new Tag(reader, parent, configurationStore);
                    elementStack.Push(tag);

                    XmlTagHandler handler = null;
                    if (handlers.TryGetValue(tag.Name, out handler))
                    {
                        handler(tag, configurationStore);
                    }

                    lastElementEmpty = reader.IsEmptyElement;
                }
                else if (reader.NodeType == XmlNodeType.Text || reader.NodeType == XmlNodeType.CDATA)
                {
                    Tag parent = elementStack.Count == 0 ? null : elementStack.Peek();

                    if (parent.Name==ConfigConstants.ELEMENT_INCLUDE)
                    {
                        parent = parent.Parent;
                    }
                    Tag tag = new Tag(reader, parent, configurationStore);

                    XmlTagHandler handler = null;
                    if (handlers.TryGetValue(ConfigConstants.ELEMENT_TEXT, out handler))
                    {
                        handler(tag, configurationStore);
                    }
                }
            }
        }

        /// <summary>
        /// Processes the text element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="configurationStore">The configuration store.</param>
        protected virtual void ProcessTextElement(Tag element, IConfigurationStore configurationStore)
        {}

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            elementStack.Clear();
        }

        #endregion
    }
}
