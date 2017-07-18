
#region Apache Notice
/*****************************************************************************
 * $Revision: 387044 $
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

using Apache.Ibatis.Common.Contracts.Exceptions;

namespace Apache.Ibatis.Common.Contracts
{
    /// <summary>
    /// Helper class for post conditions checks
    /// Will throw exception of type <typeparamref name="PostConditionException"/>
    /// with the specified message if the condition is false
    /// </summary>
    /// <example>
    /// Sample usage:
    /// <code>
    /// <![CDATA[
    /// Contract.Ensure.That(connectionString, Is.Not.Null & Is.Not.Empty).When("retrieving argument connectionString in DataSource constructor");
    /// 
    /// Contract.Ensure.That<ValidationException>(name, Is.Not.Null & Is.Not.Empty).When("validate order");
    /// ]]>
    /// </code>
    /// </example>
    public sealed class Ensure : Contract
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ensure"/> class.
        /// </summary>
        public Ensure()
        {
            exceptionType = typeof(PostConditionException);
        }
    }
}
