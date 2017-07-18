
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

using System;

namespace Apache.Ibatis.Common.Contracts
{
    /// <summary>
    /// Checks that an object is less than another
    /// </summary>
    public class LessThanConstraint : BaseConstraint
    {
        private readonly IComparable expected = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="LessThanConstraint"/> class.
        /// </summary>
        /// <param name="expected">The expected.</param>
        public LessThanConstraint(IComparable expected)
        {
            this.expected = expected;
        }

        /// <summary>
        /// Determines whether [is satisfied by] [the specified actual].
        /// </summary>
        /// <param name="actual">The actual.</param>
        /// <param name="appendErrorMessage">The append error message.</param>
        /// <returns>
        /// 	<c>true</c> if [is satisfied by] [the specified actual]; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsSatisfiedBy(object actual, AppendErrorMessage appendErrorMessage)
        {
            bool test = expected.CompareTo(actual) > 0;

            if (!test)
            {
                ErrorMessage = NegationMessage + "less than '" + expected + "'";
                appendErrorMessage(ErrorMessage);
            }

            return test;
        }
    }
}
