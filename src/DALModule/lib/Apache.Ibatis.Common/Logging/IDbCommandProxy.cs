
#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 383115 $
 * $Date: 2008-03-16 02:10:31 -0600 (Sun, 16 Mar 2008) $
 * 
 * iBATIS.NET Data Mapper
 * Copyright (C) 2004 - Gilles Bayon
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

using System.Data;
using Castle.DynamicProxy;

namespace Apache.Ibatis.Common.Logging
{
	/// <summary>
	/// 
	/// </summary>
	public class IDbCommandProxy : IInterceptor
	{
		private IDbCommand _command = null;
		private static readonly ILog _dataReaderLogger = LogManager.GetLogger("System.Data.IDataReader");

		internal IDbCommandProxy(IDbCommand command)
		{
			_command = command;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
		public static IDbCommand NewInstance(IDbCommand command)
		{
			IInterceptor handler = new IDbCommandProxy(command);

			object proxyCommand = new ProxyGenerator().CreateProxy(typeof(IDbCommand), handler, command);

			return (IDbCommand) proxyCommand;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="invocation"></param>
		/// <param name="arguments"></param>
		/// <returns></returns>
		public object Intercept(IInvocation invocation, params object[] arguments)
		{
			object returnValue = invocation.Method.Invoke(_command, arguments);

			if (invocation.Method.Name == "ExecuteReader")
			{
				if (_dataReaderLogger.IsDebugEnabled)
				{
					returnValue = IDataReaderProxy.NewInstance((IDataReader)returnValue);
				}
			}

			return returnValue;
		}
	}
}
