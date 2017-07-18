#region Apache Notice
/*****************************************************************************
 * $Revision: 408164 $
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
using Apache.Ibatis.Common.Contracts;
using Apache.Ibatis.Common.Exceptions;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config;
using Apache.Ibatis.DataMapper.Model;

namespace Apache.Ibatis.DataMapper.Configuration.Serializers
{
	/// <summary>
	/// Summary description for DeSerializerFactory.
	/// </summary>
	public class DeSerializerFactory
	{
        private readonly IDictionary<string, IDeSerializer> serializerMap = new Dictionary<string, IDeSerializer>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DeSerializerFactory"/> class.
        /// </summary>
        /// <param name="modelStore">The model store.</param>
        public DeSerializerFactory(IModelStore modelStore)
		{
            serializerMap.Add(ConfigConstants.ELEMENT_DYNAMIC, new DynamicDeSerializer(modelStore.DataExchangeFactory.AccessorFactory));
            serializerMap.Add(ConfigConstants.ELEMENT_ISEQUAL, new IsEqualDeSerializer(modelStore.DataExchangeFactory.AccessorFactory));
            serializerMap.Add(ConfigConstants.ELEMENT_ISNOTEQUAL, new IsNotEqualDeSerializer(modelStore.DataExchangeFactory.AccessorFactory));
            serializerMap.Add(ConfigConstants.ELEMENT_ISGREATEREQUAL, new IsGreaterEqualDeSerializer(modelStore.DataExchangeFactory.AccessorFactory));
            serializerMap.Add(ConfigConstants.ELEMENT_ISGREATERTHAN, new IsGreaterThanDeSerializer(modelStore.DataExchangeFactory.AccessorFactory));
            serializerMap.Add(ConfigConstants.ELEMENT_ISLESSEQUAL, new IsLessEqualDeSerializer(modelStore.DataExchangeFactory.AccessorFactory));
            serializerMap.Add(ConfigConstants.ELEMENT_ISLESSTHAN, new IsLessThanDeSerializer(modelStore.DataExchangeFactory.AccessorFactory));
            serializerMap.Add(ConfigConstants.ELEMENT_ISNOTEMPTY, new IsNotEmptyDeSerializer(modelStore.DataExchangeFactory.AccessorFactory));
            serializerMap.Add(ConfigConstants.ELEMENT_ISEMPTY, new IsEmptyDeSerializer(modelStore.DataExchangeFactory.AccessorFactory));
            serializerMap.Add(ConfigConstants.ELEMENT_ISNOTNULL, new IsNotNullDeSerializer(modelStore.DataExchangeFactory.AccessorFactory));
            serializerMap.Add(ConfigConstants.ELEMENT_ISNOTPARAMETERPRESENT, new IsNotParameterPresentDeSerializer(modelStore.DataExchangeFactory.AccessorFactory));
            serializerMap.Add(ConfigConstants.ELEMENT_ISNOTPROPERTYAVAILABLE, new IsNotPropertyAvailableDeSerializer(modelStore.DataExchangeFactory.AccessorFactory));
            serializerMap.Add(ConfigConstants.ELEMENT_ISNULL, new IsNullDeSerializer(modelStore.DataExchangeFactory.AccessorFactory));
            serializerMap.Add(ConfigConstants.ELEMENT_ISPARAMETERPRESENT, new IsParameterPresentDeSerializer(modelStore.DataExchangeFactory.AccessorFactory));
            serializerMap.Add(ConfigConstants.ELEMENT_ISPROPERTYAVAILABLE, new IsPropertyAvailableDeSerializer(modelStore.DataExchangeFactory.AccessorFactory));
            serializerMap.Add(ConfigConstants.ELEMENT_ITERATE, new IterateSerializer(modelStore.DataExchangeFactory.AccessorFactory));		
		}


        /// <summary>
        /// Gets the deserializer.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
		public IDeSerializer GetDeSerializer(string id) 
		{
           Contract.Require.That(id, Is.Not.Null & Is.Not.Empty).When("retrieving argument id");

           if (serializerMap.ContainsKey(id))
           {
               return serializerMap[id];
           }
           else
           {
               throw new ConfigurationException("There's no dynamic tag DeSerializer with id '" + id + "', cause: there's no valid dynamic tag named '" + id);
           }
		}

	}
}
