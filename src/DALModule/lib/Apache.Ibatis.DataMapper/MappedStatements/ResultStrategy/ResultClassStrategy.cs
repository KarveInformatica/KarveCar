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
using System.Data;
using Apache.Ibatis.DataMapper.Scope;

namespace Apache.Ibatis.DataMapper.MappedStatements.ResultStrategy
{
	/// <summary>
	/// <see cref="IResultStrategy"/> implementation when 
	/// a 'resultClass' attribute is specified.
	/// </summary>
    public sealed class ResultClassStrategy : IResultStrategy
	{
		private static IResultStrategy simpleTypeStrategy = null;
		private static IResultStrategy dictionaryStrategy = null;
		private static IResultStrategy listStrategy = null;
		private static IResultStrategy autoMapStrategy = null;
        private static IResultStrategy dataTableStrategy = null;

		/// <summary>
		/// Initializes a new instance of the <see cref="ResultClassStrategy"/> class.
		/// </summary>
		public ResultClassStrategy()
		{
			simpleTypeStrategy = new SimpleTypeStrategy();
			dictionaryStrategy = new DictionaryStrategy();
			listStrategy = new ListStrategy();
			autoMapStrategy = new AutoMapStrategy();
            dataTableStrategy = new DataRowStrategy();
		}

        #region IResultStrategy Members

		/// <summary>
		/// Processes the specified <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="request">The request.</param>
		/// <param name="reader">The reader.</param>
		/// <param name="resultObject">The result object.</param>
        public object Process(RequestScope request, ref IDataReader reader, object resultObject)
		{
		    // Check if the ResultClass is a 'primitive' Type
            if (request.DataExchangeFactory.TypeHandlerFactory.IsSimpleType(request.CurrentResultMap.Class))
			{
                return simpleTypeStrategy.Process(request, ref reader, resultObject);
			}
		    if (typeof(IDictionary).IsAssignableFrom(request.CurrentResultMap.Class)) 
		    {
		        return dictionaryStrategy.Process(request, ref reader, resultObject);
		    }
		    if (typeof(IList).IsAssignableFrom(request.CurrentResultMap.Class)) 
		    {
		        return listStrategy.Process(request, ref reader, resultObject);
		    }
		    if (typeof(DataRow).IsAssignableFrom(request.CurrentResultMap.Class))
		    {
		        return dataTableStrategy.Process(request, ref reader, resultObject);
		    }
		    return autoMapStrategy.Process(request, ref reader, resultObject);
		}

	    #endregion
	}
}
