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
    /// Base implementation for <see cref="IResultMapEvents"/>
    /// </summary>
    [Serializable]
    public abstract class ResultMapEventSupport : IResultMapEvents
    {
        protected static readonly object PreCreateEvent = new object();
        protected static readonly object PostCreateEvent = new object();

        private readonly EventHandlerList events = new EventHandlerList();

        #region IResultMapEvents Members

        /// <summary>
        /// Handles event <see cref="PreCreateEventArgs"/> generated before creating an instance of the <see cref="IResultMap"/> object.
        /// </summary>
        public event EventHandler<PreCreateEventArgs> PreCreate
        {
            add { events.AddHandler(PreCreateEvent, value); }
            remove { events.RemoveHandler(PreCreateEvent, value); }
        }

        /// <summary>
        /// Handles event <see cref="PostCreateEventArgs"/> generated after creating an instance of the <see cref="IResultMap"/> object.
        /// </summary>
        public event EventHandler<PostCreateEventArgs> PostCreate
        {
            add { events.AddHandler(PostCreateEvent, value); }
            remove { events.RemoveHandler(PostCreateEvent, value); }
        }
        #endregion

        /// <summary>
        /// Raises the <see cref="PreCreateEventArgs"/>.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// Returns is used as the parameters used to create the object
        /// </returns>
        protected object[] RaisePreCreateEvent(object[] parameters)
        {
            EventHandler<PreCreateEventArgs> handlers = (EventHandler<PreCreateEventArgs>)events[PreCreateEvent];

            if (handlers != null)
            {
                PreCreateEventArgs eventArgs = new PreCreateEventArgs();
                eventArgs.Parameters = parameters;

                handlers(this, eventArgs);
                
                return eventArgs.Parameters;
            }
            return parameters;
        }

        /// <summary>
        /// Raises the <see cref="PostCreateEventArgs"/>.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns>
        /// Returns is used as the parameters used to create the object
        /// </returns>
        protected object RaisePostCreateEvent(object instance)
        {
            EventHandler<PostCreateEventArgs> handlers = (EventHandler<PostCreateEventArgs>)events[PostCreateEvent];

            if (handlers != null)
            {
                PostCreateEventArgs eventArgs = new PostCreateEventArgs();
                eventArgs.Instance = instance;
                
                handlers(this, eventArgs);

                return eventArgs.Instance;
            }
            return instance;
        }
    }
}
