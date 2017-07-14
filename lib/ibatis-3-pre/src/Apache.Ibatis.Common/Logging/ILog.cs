
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 474141 $
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

namespace Apache.Ibatis.Common.Logging
{

	/// <summary>
	/// A simple logging interface abstracting logging APIs. Inspired by log4net.
	/// </summary>
	public interface ILog
	{
		/// <summary>
		/// Log a message object with the <see cref="LogLevel.Debug"/> level.
		/// </summary>
		/// <param name="message">The message object to log.</param>
		void Debug( object message );

		/// <summary>
		/// Log a message object with the <see cref="LogLevel.Debug"/> level including
		/// the stack trace of the <see cref="Exception"/> passed
		/// as a parameter.
		/// </summary>
		/// <param name="message">The message object to log.</param>
		/// <param name="exception">The exception to log, including its stack trace.</param>
		void Debug( object message, Exception exception );


		/// <summary>
		/// Log a message object with the <see cref="LogLevel.Error"/> level.
		/// </summary>
		/// <param name="message">The message object to log.</param>
		void Error( object message );

		/// <summary>
		/// Log a message object with the <see cref="LogLevel.Error"/> level including
		/// the stack trace of the <see cref="Exception"/> passed
		/// as a parameter.
		/// </summary>
		/// <param name="message">The message object to log.</param>
		/// <param name="exception">The exception to log, including its stack trace.</param>
		void Error( object message, Exception exception );


		/// <summary>
		/// Log a message object with the <see cref="LogLevel.Fatal"/> level.
		/// </summary>
		/// <param name="message">The message object to log.</param>
		void Fatal( object message );

		/// <summary>
		/// Log a message object with the <see cref="LogLevel.Fatal"/> level including
		/// the stack trace of the <see cref="Exception"/> passed
		/// as a parameter.
		/// </summary>
		/// <param name="message">The message object to log.</param>
		/// <param name="exception">The exception to log, including its stack trace.</param>
		void Fatal( object message, Exception exception );


		/// <summary>
		/// Log a message object with the <see cref="LogLevel.Info"/> level.
		/// </summary>
		/// <param name="message">The message object to log.</param>
		void Info( object message );

		/// <summary>
		/// Log a message object with the <see cref="LogLevel.Info"/> level including
		/// the stack trace of the <see cref="Exception"/> passed
		/// as a parameter.
		/// </summary>
		/// <param name="message">The message object to log.</param>
		/// <param name="exception">The exception to log, including its stack trace.</param>
		void Info( object message, Exception exception );

        /// <summary>
        /// Log a message object with the <see cref="LogLevel.Trace"/> level.
        /// </summary>
        /// <param name="message">The message object to log.</param>
        void Trace(object message);

        /// <summary>
        /// Log a message object with the <see cref="LogLevel.Trace"/> level including
        /// the stack trace of the <see cref="Exception"/> passed
        /// as a parameter.
        /// </summary>
        /// <param name="message">The message object to log.</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        void Trace(object message, Exception exception);

		/// <summary>
		/// Log a message object with the <see cref="LogLevel.Warn"/> level.
		/// </summary>
		/// <param name="message">The message object to log.</param>
		void Warn( object message );

		/// <summary>
		/// Log a message object with the <see cref="LogLevel.Warn"/> level including
		/// the stack trace of the <see cref="Exception"/> passed
		/// as a parameter.
		/// </summary>
		/// <param name="message">The message object to log.</param>
		/// <param name="exception">The exception to log, including its stack trace.</param>
		void Warn( object message, Exception exception );


		/// <summary>
		/// Checks if this logger is enabled for the <see cref="LogLevel.Debug"/> level.
		/// </summary>
		bool IsDebugEnabled
		{
			get;
		}

		/// <summary>
		/// Checks if this logger is enabled for the <see cref="LogLevel.Error"/> level.
		/// </summary>
		bool IsErrorEnabled
		{
			get;
		}

		/// <summary>
		/// Checks if this logger is enabled for the <see cref="LogLevel.Fatal"/> level.
		/// </summary>
		bool IsFatalEnabled
		{
			get;
		}

		/// <summary>
		/// Checks if this logger is enabled for the <see cref="LogLevel.Info"/> level.
		/// </summary>
		bool IsInfoEnabled
		{
			get;
		}

        /// <summary>
        /// Checks if this logger is enabled for the <see cref="LogLevel.Trace"/> level.
        /// </summary>
        bool IsTraceEnabled
        {
            get;
        }

		/// <summary>
		/// Checks if this logger is enabled for the <see cref="LogLevel.Warn"/> level.
		/// </summary>
		bool IsWarnEnabled
		{
			get;
		}
	}
}
