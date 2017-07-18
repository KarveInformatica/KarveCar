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
using System.Collections.Generic;

namespace Apache.Ibatis.Common.Configuration
{
    /// <summary>
    /// A collection of <see cref="IConfiguration"/> objects.
    /// </summary>
    [Serializable]
    public class ConfigurationCollection : List<IConfiguration>
    {

        /// <summary>
        /// Gets the <see cref="IConfiguration"/> with the specified id.
        /// </summary>
        /// <value></value>
        public IConfiguration this[string id]
        {
            get
            {
                for(int i=0;i<Count;i++)
                {
                    if (id.Equals(this[i].Id))
                    {
                        return this[i];
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// Finds the IConfiguration element that are from the specified element type.
        /// </summary>
        /// <param name="elementType">Type of the element.</param>
        /// <returns>A list of IConfiguration</returns>
        public ConfigurationCollection Find(string elementType) 
        {
            ConfigurationCollection liste = new ConfigurationCollection();

            for (int i = 0; i < Count; i++)
            {
                if (elementType.Equals(this[i].Type))
                {
                    liste.Add(this[i]);
                }
            }

            return liste;
        }


        /// <summary>
        /// Recursive find of the IConfiguration element that are from the specified element type.
        /// </summary>
        /// <param name="elementType">Type of the element.</param>
        /// <returns>A list of IConfiguration</returns>
        public ConfigurationCollection RecursiveFind(string elementType)
        {
            ConfigurationCollection list = new ConfigurationCollection();

            for (int i = 0; i < Count; i++)
            {
                if (elementType.Equals(this[i].Type))
                {
                    list.Add(this[i]);
                }
                list.AddRange(this[i].Children.RecursiveFind(elementType));
            }

            return list;
        }


        /// <summary>
        /// Builds a new collection where element of the specified type
        /// are removed.
        /// </summary>
        /// <param name="elementType">Type of the element.</param>
        /// <returns></returns>
        public ConfigurationCollection Remove(string elementType)
        {
            ConfigurationCollection newCollection = new ConfigurationCollection();
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Type != elementType)
                {
                    newCollection.Add(this[i]);
                }
            }
            return newCollection;
        }
    }
}
