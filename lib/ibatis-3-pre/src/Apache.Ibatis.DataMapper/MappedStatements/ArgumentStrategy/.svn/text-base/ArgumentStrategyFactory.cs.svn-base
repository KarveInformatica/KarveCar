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

using Apache.Ibatis.DataMapper.Model.ResultMapping;

namespace Apache.Ibatis.DataMapper.MappedStatements.ArgumentStrategy
{
	/// <summary>
	/// Factory to get <see cref="IArgumentStrategy"/> implementation.
	/// </summary>
	public sealed class ArgumentStrategyFactory
	{
		private static readonly IArgumentStrategy _defaultStrategy = null;
		private static readonly IArgumentStrategy _resultMapStrategy = null;
        private static readonly IArgumentStrategy _selectArrayStrategy = null;
        private static readonly IArgumentStrategy _selectGenericListStrategy = null;
        private static readonly IArgumentStrategy _selectListStrategy = null;
        private static readonly IArgumentStrategy _selectObjectStrategy = null;

		/// <summary>
		/// Initializes the <see cref="ArgumentStrategyFactory"/> class.
		/// </summary>
		static ArgumentStrategyFactory()
		{
			_defaultStrategy = new DefaultStrategy();
			_resultMapStrategy = new ResultMapStrategy();

            _selectArrayStrategy = new SelectArrayStrategy();
            _selectListStrategy = new SelectListStrategy();
            _selectObjectStrategy = new SelectObjectStrategy();
            _selectGenericListStrategy = new SelectGenericListStrategy();
		}

		/// <summary>
		/// Finds the <see cref="IArgumentStrategy"/>.
		/// </summary>
		/// <param name="mapping">The <see cref="ArgumentProperty"/>.</param>
		/// <returns>The <see cref="IArgumentStrategy"/></returns>
		public static IArgumentStrategy Get(ArgumentProperty mapping)
		{
		    // no 'select' or 'resultMap' attributes
            if (mapping.Select.Length == 0 && mapping.NestedResultMapName.Length == 0)
			{
				// We have a 'normal' ResultMap
				return _defaultStrategy;
			}
		    if (mapping.NestedResultMapName.Length != 0) // 'resultMap' attribut
		    {
		        return _resultMapStrategy;
		    }
            //'select' ResultProperty 
		    return new SelectStrategy(mapping,
		                              _selectArrayStrategy,
		                              _selectGenericListStrategy,
		                              _selectListStrategy,
		                              _selectObjectStrategy);
		}
	}
}
