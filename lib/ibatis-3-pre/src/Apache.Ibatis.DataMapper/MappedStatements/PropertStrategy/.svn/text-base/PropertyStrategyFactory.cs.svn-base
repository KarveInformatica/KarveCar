#region Apache Notice
/*****************************************************************************
 * $Revision: 374175 $
 * $LastChangedDate: 2008-09-21 13:25:16 -0600 (Sun, 21 Sep 2008) $
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

using System.Collections;
using System.Collections.Generic;
using Apache.Ibatis.DataMapper.Model.ResultMapping;
using Apache.Ibatis.DataMapper.MappedStatements.PropertStrategy;

namespace Apache.Ibatis.DataMapper.MappedStatements.PropertyStrategy
{
	/// <summary>
	/// Factory to get <see cref="IPropertyStrategy"/> implementation.
	/// </summary>
	public sealed class PropertyStrategyFactory
	{
		private static readonly IPropertyStrategy defaultStrategy = null;
        private static readonly IPropertyStrategy resultMapStrategy = null;
        private static readonly IPropertyStrategy groupByStrategy = null;

        private static readonly IPropertyStrategy selectArrayStrategy = null;
        private static readonly IPropertyStrategy selectGenericListStrategy = null;
        private static readonly IPropertyStrategy selectListStrategy = null;
        private static readonly IPropertyStrategy selectObjectStrategy = null;
        private static readonly IPropertyStrategy circularStrategy = null;

		/// <summary>
		/// Initializes the <see cref="PropertyStrategyFactory"/> class.
		/// </summary>
		static PropertyStrategyFactory()
		{
			defaultStrategy = new DefaultStrategy();
            resultMapStrategy = new ResultMapStrategy();

            selectArrayStrategy = new SelectArrayStrategy();
            selectListStrategy = new SelectListStrategy();
            selectObjectStrategy = new SelectObjectStrategy();
            selectGenericListStrategy = new SelectGenericListStrategy();
            circularStrategy = new CircularStrategy(resultMapStrategy);
            groupByStrategy = new GroupByStrategy(resultMapStrategy, circularStrategy);
		}

		/// <summary>
		/// Finds the <see cref="IPropertyStrategy"/>.
		/// </summary>
		/// <param name="mapping">The <see cref="ResultProperty"/>.</param>
		/// <returns>The <see cref="IPropertyStrategy"/></returns>
		public static IPropertyStrategy Get(ResultProperty mapping)
		{
		    // no 'select' or 'resultMap' attributes
			if (mapping.Select.Length == 0 && mapping.NestedResultMap == null)
			{
				// We have a 'normal' ResultMap
				return defaultStrategy;
			}
		    if (mapping.NestedResultMap != null) // 'resultMap' attribute
		    {
		        if (mapping.NestedResultMap.GroupByPropertyNames.Count>0)
		        {
		            return groupByStrategy; 
		        }
		        if (mapping.MemberType.IsGenericType &&
		            typeof(IList<>).IsAssignableFrom(mapping.MemberType.GetGenericTypeDefinition()))
		        {
		            return groupByStrategy; 
		        }
		        if (typeof(IList).IsAssignableFrom(mapping.MemberType))
		        {
		            return groupByStrategy; 
		        }
		        if (mapping.NestedResultMap.KeyPropertyNames.Count > 0)
		        {
		            return circularStrategy;
		        }
		        return resultMapStrategy;
		    }

            //'select' ResultProperty 
		    return new SelectStrategy(mapping,
		                              selectArrayStrategy,
		                              selectGenericListStrategy,
		                              selectListStrategy,
		                              selectObjectStrategy);
		}
	}
}
