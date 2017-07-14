#region Apache Notice
/*****************************************************************************
 * $Revision: 476843 $
 * $LastChangedDate: 2008-10-19 05:25:12 -0600 (Sun, 19 Oct 2008) $
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
using System.ComponentModel;
using Apache.Ibatis.DataMapper.Model.Events;

namespace Apache.Ibatis.DataMapper.Model.ResultMapping
{
    /// <summary>
    /// Base implementation for <see cref="IResultPropertySupportEvents"/>
    /// </summary>
    [Serializable]
    public abstract class ResultPropertyEventSupport : IResultPropertySupportEvents
    {
        protected static readonly object PrePropertyEvent = new object();
        protected static readonly object PostPropertyEvent = new object();

        private readonly EventHandlerList events = new EventHandlerList();

        #region IResultPropertySupportEvents Members

        /// <summary>
        /// Handles event <see cref="PrePropertyEventArgs"/> generated before setting the property value in an instance of a <see cref="IResultMap"/> object.
        /// </summary>
        public event EventHandler<PrePropertyEventArgs> PreProperty
        {
            add { events.AddHandler(PrePropertyEvent, value); }
            remove { events.RemoveHandler(PrePropertyEvent, value); }
        }

        /// <summary>
        /// Handles event <see cref="PostCreateEventArgs"/> generated after setting the property value in an instance of a <see cref="IResultMap"/> object.
        /// </summary>
        public event EventHandler<PostPropertyEventArgs> PostProperty
        {
            add { events.AddHandler(PostPropertyEvent, value); }
            remove { events.RemoveHandler(PostPropertyEvent, value); }
        }

        #endregion

        /// <summary>
        /// Raises the <see cref="PreCreateEventArgs"/>.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="value">The value.</param>
        /// <returns>Returns is used as databse value, to be set on the property</returns>
        protected object RaisePrePropertyEvent(object target, object value)
        {
            EventHandler<PrePropertyEventArgs> handlers = (EventHandler<PrePropertyEventArgs>)events[PrePropertyEvent];

            if (handlers != null)
            {
                PrePropertyEventArgs evnt = new PrePropertyEventArgs();
                evnt.DataBaseValue = value;
                evnt.Target = target;
                handlers(this, evnt);

                return evnt.DataBaseValue;
            }
            return value;
        }

        /// <summary>
        /// Raises the <see cref="PostPropertyEventArgs"/>.
        /// </summary>
        /// <param name="target">The target.</param>
        protected void RaisePostPropertyEvent(object target)
        {
            EventHandler<PostPropertyEventArgs> handlers = (EventHandler<PostPropertyEventArgs>)events[PostPropertyEvent];

            if (handlers != null)
            {
                PostPropertyEventArgs evnt = new PostPropertyEventArgs();
                evnt.Target = target;
                handlers(this, evnt);
            }
        }
    }
}
