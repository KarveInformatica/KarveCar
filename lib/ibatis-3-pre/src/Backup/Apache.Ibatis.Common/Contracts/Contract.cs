
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
    public delegate void ThrowException(string message);
    public delegate bool IsSatisfied();
    public delegate string GetErrorMessage();
    public delegate void AppendErrorMessage(string message);

    /// <summary>
    /// Design By Contract Checks.
    /// </summary>
    public class Contract
    {
        /// <summary>
        /// Checks post conditions
        /// </summary>
        public static readonly Ensure Ensure = new Ensure();
        /// <summary>
        /// Checks pre conditions
        /// </summary>
        public static readonly Require Require = new Require();
        /// <summary>
        /// Assert conditions
        /// </summary>
        public static readonly Assert Assert = new Assert();

        protected string errorMessage = string.Empty;
        protected string messagePrefix = string.Empty;
        protected ThrowException throwException = null;
        protected object objectToCheck = null;
        protected AppendErrorMessage appendErrorMessage = null;
        protected GetErrorMessage getErrorMessage = null;
        protected Type exceptionType = null;

        /// <summary>
        /// Initializes the <see cref="Contract"/> class.
        /// </summary>
        public Contract()
        {
            appendErrorMessage = AppendMessageError;
            getErrorMessage = GetMessageError;
            throwException = ThrowAnException;
        }

        /// <summary>
        /// Thats the specified condition is true
        /// else throw exception
        /// </summary>
        /// <param name="condition">if set to <c>true</c> [condition].</param>
        /// <returns></returns>
        public ContractMessage That(bool condition)
        {
            return That(condition, Is.True);
        }

        /// <summary>
        /// Thats the specified condition.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="condition">if set to <c>true</c> [condition].</param>
        /// <returns></returns>
        public ContractMessage That<TException>(bool condition) where TException : Exception
        {
            return That<TException>(condition, Is.True);
        }

        /// <summary>
        /// Thats the specified actual verify the constraint
        /// else throw exception  of type <typeparamref name="TException"/>
        /// </summary>
        /// <param name="actual">The actual.</param>
        /// <param name="constraint">The constraint.</param>
        /// <returns></returns>
        public ContractMessage That<TException>(object actual, BaseConstraint constraint) where TException : Exception
        {
            exceptionType = typeof(TException);

            return That(actual, constraint);
        }

        /// <summary>
        /// Thats the specified verify the constraint.
        /// </summary>
        /// <param name="actual">The actual.</param>
        /// <param name="constraint">The constraint.</param>
        /// <returns></returns>
        public ContractMessage That(object actual, BaseConstraint constraint)
        {
            objectToCheck = actual;

            if (objectToCheck != null)
            {
                messagePrefix = objectToCheck.GetType().Name + " object should";
            }
            else
            {
                messagePrefix = "Object reference should";
            }

            IsSatisfied isSatisfied = delegate { return constraint.IsSatisfiedBy(actual, appendErrorMessage); };

            return new ContractMessage(messagePrefix, throwException, isSatisfied, getErrorMessage);
        }

        /// <summary>
        /// Appends the error message.
        /// </summary>
        /// <param name="message">The message.</param>
        private void AppendMessageError(string message)
        {
            errorMessage = " " + message;
        }

        /// <summary>
        /// Gets the message error.
        /// </summary>
        /// <returns></returns>
        private string GetMessageError()
        {
            return errorMessage;
        }

        private void ThrowAnException(string message)
        {
            throw (Exception)Activator.CreateInstance(exceptionType, message);
        }
    }
}
