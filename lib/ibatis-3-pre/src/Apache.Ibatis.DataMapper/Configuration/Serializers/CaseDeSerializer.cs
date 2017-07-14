#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 576082 $
 * $Date: 2008-09-20 12:15:29 -0600 (Sat, 20 Sep 2008) $
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


using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.DataMapper.Model.ResultMapping;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config;

namespace Apache.Ibatis.DataMapper.Configuration.Serializers
{
	/// <summary>
	/// Summary description for CaseDeSerializer.
	/// </summary>
	public sealed class CaseDeSerializer
	{
        /// <summary>
        /// Build a Case object
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns>a Case object</returns>
        public static Case Deserialize(IConfiguration configuration)
        {
            string discriminatorValue = ConfigurationUtils.GetStringAttribute(configuration.Attributes, ConfigConstants.ATTRIBUTE_VALUE);
            string resultMapName = ConfigurationUtils.GetStringAttribute(configuration.Attributes, ConfigConstants.ATTRIBUTE_RESULTMAP);

            return new Case(discriminatorValue, resultMapName);
        }

	}
}
