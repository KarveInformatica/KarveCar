
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 471478 $
 * $Date: 2008-06-28 09:26:16 -0600 (Sat, 28 Jun 2008) $
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

namespace Apache.Ibatis.Common.Logging.Impl
{
	/// <summary>
	/// Silently ignores all log messages.
	/// </summary>
	public sealed class NoOpLogger: ILog
	{
		#region Members of ILog

		/// <summary>
		/// Ignores message.
		/// </summary>
		/// <param name="message"></param>
		public void Debug(object message)
		{
			// NOP - no operation
		}

		/// <summary>
		/// Ignores message.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="e"></param>
		public void Debug(object message, Exception e)
		{
			// NOP - no operation
		}

		/// <summary>
		/// Ignores message.
		/// </summary>
		/// <param name="message"></param>
		public void Error(object message)
		{
			// NOP - no operation
		}

		/// <summary>
		/// Ignores message.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="e"></param>
		public void Error(object message, Exception e)
		{
			// NOP - no operation
		}

		/// <summary>
		/// Ignores message.
		/// </summary>
		/// <param name="message"></param>
		public void Fatal(object message)
		{
			// NOP - no operation
		}

		/// <summary>
		/// Ignores message.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="e"></param>
		public void Fatal(object message, Exception e)
		{
			// NOP - no operation
		}

		/// <summary>
		/// Ignores message.
		/// </summary>
		/// <param name="message"></param>
		public void Info(object message)
		{
			// NOP - no operation
		}

		/// <summary>
		/// Ignores message.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="e"></param>
		public void Info(object message, Exception e)
		{
			// NOP - no operation
		}

		/// <summary>
		/// Ignores message.
		/// </summary>
		/// <param name="message"></param>
		public void Warn(object message)
		{
			// NOP - no operation
		}


		/// <summary>
		/// Ignores message.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="e"></param>
		public void Warn(object message, Exception e)
		{
			// NOP - no operation
		}

        /// <summary>
        /// Log a message object with the <see cref="LogLevel.Trace"/> level.
        /// </summary>
        /// <param name="message">The message object to log.</param>
        public void Trace(object message)
        {
            // NOP - no operation
        }

        /// <summary>
        /// Log a message object with the <see cref="LogLevel.Trace"/> level including
        /// the stack trace of the <see cref="Exception"/> passed
        /// as a parameter.
        /// </summary>
        /// <param name="message">The message object to log.</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        public void Trace(object message, Exception exception)
        {
            // NOP - no operation
        }

		/// <summary>
		/// Always returns <see langword="false" />.
		/// </summary>
		public bool IsDebugEnabled
		{
			get { return false; }
		}

		/// <summary>
		/// Always returns <see langword="false" />.
		/// </summary>
		public bool IsErrorEnabled
		{
			get { return false; }

		}

		/// <summary>
		/// Always returns <see langword="false" />.
		/// </summary>
		public bool IsFatalEnabled
		{
			get { return false; }
		}

		/// <summary>
		/// Always returns <see langword="false" />.
		/// </summary>
		public bool IsInfoEnabled
		{
			get { return false; }
		}

		/// <summary>
		/// Always returns <see langword="false" />.
		/// </summary>
		public bool IsWarnEnabled
		{
			get { return false; }
		}

        /// <summary>
        /// Checks if this logger is enabled for the <see cref="LogLevel.Trace"/> level.
        /// </summary>
        /// <value></value>
        public bool IsTraceEnabled
        {
            get { return false; }
        }

        #endregion
    }
}