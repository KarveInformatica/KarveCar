
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
using System.Globalization;
using System.Text;

namespace Apache.Ibatis.Common.Logging.Impl
{
	/// <summary>
	/// Logger that sends output to the <see cref="System.Diagnostics.Trace" /> sub-system.
	/// </summary>
	public class TraceLogger: AbstractLogger
	{
		private readonly bool showDateTime = false;
        private readonly bool showLogName = false;
        private readonly string logName = string.Empty;
        private readonly LogLevel currentLogLevel = LogLevel.All;
        private readonly string dateTimeFormat = string.Empty;
        private readonly bool hasDateTimeFormat = false;

		/// <summary>
		/// Creates a new instance of the TraceLogger.
		/// </summary>
		/// <param name="logName">The name for this instance (usually the fully qualified class name).</param>
		/// <param name="logLevel">
		///	The logging threshold. Log messages created with a <see cref="LogLevel" />
		/// beneath this threshold will not be logged.
		/// </param>
		/// <param name="showDateTime">Include the current time in the log message </param>
		/// <param name="showLogName">Include the instance name in the log message</param>
		/// <param name="dateTimeFormat">The date and time format to use in the log message </param>
		public TraceLogger( string logName, LogLevel logLevel
		                    , bool showDateTime, bool showLogName, string dateTimeFormat)
		{
			this.logName = logName;
			currentLogLevel = logLevel;
			this.showDateTime = showDateTime;
			this.showLogName = showLogName;
			this.dateTimeFormat = dateTimeFormat;

			if (this.dateTimeFormat != null && this.dateTimeFormat.Length > 0)
			{
				hasDateTimeFormat = true;
			}
		}

		/// <summary>
		/// Responsible for assembling and writing the log message to the tracing sub-system.
		/// </summary>
		/// <param name="level"></param>
		/// <param name="message"></param>
		/// <param name="e"></param>
		protected override void Write( LogLevel level, object message, Exception e )
		{
			// Use a StringBuilder for better performance
			StringBuilder sb = new StringBuilder();

			// Append date-time if so configured
			if ( showDateTime )
			{
				if ( hasDateTimeFormat )
				{
					sb.Append( DateTime.Now.ToString( dateTimeFormat, CultureInfo.InvariantCulture ));
				}
				else
				{
					sb.Append( DateTime.Now );
				}
				
				sb.Append( " " );
			}
	
			// Append a readable representation of the log level
			sb.Append( string.Format( "[{0}]", level.ToString().ToUpper() ).PadRight( 8 ) );

			// Append the name of the log instance if so configured
			if ( showLogName )
			{
				sb.Append( logName ).Append( " - " );
			}

			// Append the message
			sb.Append( message.ToString() );

			// Append stack trace if not null
			if ( e != null )
			{
				sb.Append(Environment.NewLine).Append(e.ToString());
			}

			// Print to the appropriate destination
            System.Diagnostics.Trace.WriteLine(sb.ToString());			
		}

		/// <summary>
		/// Is the given log level currently enabled ?
		/// </summary>
		/// <param name="level"></param>
		/// <returns></returns>
		protected override bool IsLevelEnabled( LogLevel level )
		{
			int iLevel = (int)level;
			int iCurrentLogLevel = (int)currentLogLevel;

			return ( iLevel >= iCurrentLogLevel );
		}
	}
}

