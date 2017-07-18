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
using Apache.Ibatis.DataMapper.Model.Statements;

namespace Apache.Ibatis.DataMapper.MappedStatements.ResultStrategy
{
    /// <summary>
    /// Factory to get <see cref="IResultStrategy"/> implementation.
    /// </summary>
    public sealed class ResultStrategyFactory
    {
        private static readonly IResultStrategy _resultClassStrategy = null;
        private static readonly IResultStrategy _mapStrategy = null;
        private static readonly IResultStrategy _objectStrategy = null;

        /// <summary>
        /// Initializes the <see cref="ResultStrategyFactory"/> class.
        /// </summary>
        static ResultStrategyFactory()
        {
            _mapStrategy = new MapStrategy();
            _resultClassStrategy = new ResultClassStrategy();
            _objectStrategy = new ObjectStrategy();
        }

        /// <summary>
        /// Finds the <see cref="IResultStrategy"/>.
        /// </summary>
        /// <param name="statement">The statement.</param>
        /// <returns>The <see cref="IResultStrategy"/></returns>
        public static IResultStrategy Get(IStatement statement)
        {
            // If there's an IResultMap, use it
            if (statement.ResultsMap.Count > 0)
            {
                if (statement.ResultsMap[0] is ResultMap)
                {
                    return _mapStrategy; 
                }
                return _resultClassStrategy;
            }
            return _objectStrategy;
        }
    }
}
