
#region Apache Notice
/*****************************************************************************
 * $Revision: 387044 $
 * $LastChangedDate: 2008-10-11 10:07:44 -0600 (Sat, 11 Oct 2008) $
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

namespace Apache.Ibatis.Common.Contracts
{
    /// <summary>
    /// Checks that an object equals another
    /// </summary>
    public class EqualConstraint : BaseConstraint
    {
        private readonly object expected = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="EqualConstraint"/> class.
        /// </summary>
        /// <param name="expected">The expected.</param>
        public EqualConstraint(object expected)
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
            bool test = CheckEquality(expected, actual);
            if (expected == null)
            {
                ErrorMessage = NegationMessage+"be equal to null";
            }
            else
            {
                ErrorMessage = NegationMessage + "be equal to '" + expected +"'";
            }

            if (!test)
            {
                appendErrorMessage(ErrorMessage);
            }

            return test;
        }

        private static bool CheckEquality(object expected, object actual)
        {
            if ((expected == null) && (actual == null))
            {
                return true;
            }
            if ((expected == null) || (actual == null))
            {
                return false;
            }
            //Type type = expected.GetType();
            //Type type2 = actual.GetType();
            //if (!((!type.IsArray || !type2.IsArray) || base.compareAsCollection))
            //{
            //    return this.ArraysEqual((Array)expected, (Array)actual);
            //}
            //if ((expected is ICollection) && (actual is ICollection))
            //{
            //    return this.CollectionsEqual((ICollection)expected, (ICollection)actual);
            //}
            //if ((expected is Stream) && (actual is Stream))
            //{
            //    return this.StreamsEqual((Stream)expected, (Stream)actual);
            //}
            //if (base.compareWith != null)
            //{
            //    return (base.compareWith.Compare(expected, actual) == 0);
            //}
            //if (Numerics.IsNumericType(expected) && Numerics.IsNumericType(actual))
            //{
            //    return Numerics.AreEqual(expected, actual, ref this.tolerance);
            //}
            //if ((expected is string) && (actual is string))
            //{
            //    return (string.Compare((string)expected, (string)actual, base.caseInsensitive) == 0);
            //}
            //if (((expected is DateTime) && (actual is DateTime)) && (base.tolerance is TimeSpan))
            //{
            //    TimeSpan span = (TimeSpan)(((DateTime)expected) - ((DateTime)actual));
            //    return (span.Duration() <= ((TimeSpan)base.tolerance));
            //}
            return expected.Equals(actual);
        }
    }
}
