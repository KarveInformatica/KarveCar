#region Apache Notice
/*****************************************************************************
 * $Revision: 476843 $
 * $LastChangedDate: 2008-05-31 15:52:05 +0200 (sam., 31 mai 2008) $
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
using Apache.Ibatis.DataMapper.MappedStatements;

namespace Apache.Ibatis.DataMapper
{
    /// <summary>
    /// Give access to the sql command text
    /// </summary>
    public interface ISqlSource
    {
        /// <summary>
        /// Gets the SQL text.
        /// </summary>
        /// <param name="mappedStatement">The mapped statement.</param>
        /// <param name="parameterObject">The parameter object.</param>
        /// <returns></returns>
        string GetSql(IMappedStatement mappedStatement, Object parameterObject);

    }
}
