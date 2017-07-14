#region Apache Notice
/*****************************************************************************
 * $Header: $
 * $Revision: 408099 $
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

#region Using

using System;
using System.Collections;
using System.Text;
using Apache.Ibatis.Common.Exceptions;
using Apache.Ibatis.Common.Utilities;
using Apache.Ibatis.Common.Utilities.Objects;
using Apache.Ibatis.DataMapper.Configuration.Sql.Dynamic;
using Apache.Ibatis.DataMapper.Model.Statements;
using Apache.Ibatis.DataMapper.Exceptions;
using Apache.Ibatis.DataMapper.Scope;
using Apache.Ibatis.DataMapper.TypeHandlers;

#endregion 

namespace Apache.Ibatis.DataMapper.Model.ParameterMapping
{
	/// <summary>
	/// Summary description for InlineParameterMapParser.
	/// </summary>
	internal class InlineParameterMapParser
	{

		#region Fields

		private const string PARAMETER_TOKEN = "#";
		private const string PARAM_DELIM = ":";

		#endregion 

		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		public InlineParameterMapParser()
		{
		}
		#endregion 

		/// <summary>
		/// Parse Inline ParameterMap
		/// </summary>
		/// <param name="statement"></param>
		/// <param name="sqlStatement"></param>
		/// <returns>A new sql command text.</returns>
		/// <param name="scope"></param>
		public SqlText ParseInlineParameterMap(IScope scope, IStatement statement, string sqlStatement)
		{
			string newSql = sqlStatement;
			ArrayList mappingList = new ArrayList();
			Type parameterClassType = null;

			if (statement != null)
			{
				parameterClassType = statement.ParameterClass;
			}

			StringTokenizer parser = new StringTokenizer(sqlStatement, PARAMETER_TOKEN, true);
			StringBuilder newSqlBuffer = new StringBuilder();

			string token = null;
			string lastToken = null;

			IEnumerator enumerator = parser.GetEnumerator();

			while (enumerator.MoveNext()) 
			{
				token = (string)enumerator.Current;

				if (PARAMETER_TOKEN.Equals(lastToken)) 
				{
					if (PARAMETER_TOKEN.Equals(token)) 
					{
						newSqlBuffer.Append(PARAMETER_TOKEN);
						token = null;
					} 
					else 
					{
						ParameterProperty mapping = null; 
						if (token.IndexOf(PARAM_DELIM) > -1) 
						{
							mapping =  OldParseMapping(token, parameterClassType, scope);
						} 
						else 
						{
							mapping = NewParseMapping(token, parameterClassType, scope);
						}															 

						mappingList.Add(mapping);
						newSqlBuffer.Append("? ");

						enumerator.MoveNext();
						token = (string)enumerator.Current;
						if (!PARAMETER_TOKEN.Equals(token)) 
						{
							throw new DataMapperException("Unterminated inline parameter in mapped statement (" + statement.Id + ").");
						}
						token = null;
					}
				} 
				else 
				{
					if (!PARAMETER_TOKEN.Equals(token)) 
					{
						newSqlBuffer.Append(token);
					}
				}

				lastToken = token;
			}

			newSql = newSqlBuffer.ToString();

			ParameterProperty[] mappingArray = (ParameterProperty[]) mappingList.ToArray(typeof(ParameterProperty));

			SqlText sqlText = new SqlText();
			sqlText.Text = newSql;
			sqlText.Parameters = mappingArray;

			return sqlText;
		}


		/// <summary>
		/// Parse inline parameter with syntax as
		/// #propertyName,type=string,dbype=Varchar,direction=Input,nullValue=N/A,handler=string#
		/// </summary>
		/// <param name="token"></param>
		/// <param name="parameterClassType"></param>
		/// <param name="scope"></param>
		/// <returns></returns>
		private ParameterProperty NewParseMapping(string token, Type parameterClassType, IScope scope) 
		{
			ParameterProperty mapping = null;

            string propertyName = string.Empty;
            string type = string.Empty;
            string dbType = string.Empty;
            string direction = string.Empty;
            string callBack = string.Empty;
            string nullValue = string.Empty;

			StringTokenizer paramParser = new StringTokenizer(token, "=,", false);
			IEnumerator enumeratorParam = paramParser.GetEnumerator();
			enumeratorParam.MoveNext();

            propertyName = ((string)enumeratorParam.Current).Trim();

			while (enumeratorParam.MoveNext()) 
			{
				string field = (string)enumeratorParam.Current;
				if (enumeratorParam.MoveNext()) 
				{
					string value = (string)enumeratorParam.Current;
					if ("type".Equals(field)) 
					{
                        type = value;
					} 
					else if ("dbType".Equals(field)) 
					{
                        dbType = value;
					} 
					else if ("direction".Equals(field)) 
					{
                        direction = value;
					} 
					else if ("nullValue".Equals(field)) 
					{
                        nullValue = value;
					} 
					else if ("handler".Equals(field)) 
					{
                        callBack = value;
					} 
					else 
					{
						throw new DataMapperException("Unrecognized parameter mapping field: '" + field + "' in " + token);
					}
				} 
				else 
				{
					throw new DataMapperException("Incorrect inline parameter map format (missmatched name=value pairs): " + token);
				}
			}

            //if (mapping.CallBackName.Length >0)
            //{
            //    mapping.Initialize( scope, parameterClassType );
            //}
            //else
            //{
            //    ITypeHandler handler = null;
            //    if (parameterClassType == null) 
            //    {
            //        handler = scope.DataExchangeFactory.TypeHandlerFactory.GetUnkownTypeHandler();
            //    } 
            //    else 
            //    {
            //        handler = ResolveTypeHandler( scope.DataExchangeFactory.TypeHandlerFactory, 
            //            parameterClassType, mapping.PropertyName,  
            //            mapping.CLRType, mapping.DbType );
            //    }
            //    mapping.TypeHandler = handler;
            //    mapping.Initialize(  scope, parameterClassType );				
            //}

            return new ParameterProperty(
                propertyName,
                string.Empty,
                callBack,
                type,
                dbType,
                direction,
                nullValue,
                0,
                0,
                -1,
                parameterClassType,
                scope.DataExchangeFactory);
		}


		/// <summary>
		/// Parse inline parameter with syntax as
		/// #propertyName:dbType:nullValue#
		/// </summary>
		/// <param name="token"></param>
		/// <param name="parameterClassType"></param>
		/// <param name="scope"></param>
		/// <returns></returns>
		private ParameterProperty OldParseMapping(string token, Type parameterClassType, IScope scope) 
		{
			ParameterProperty mapping = null;
            string propertyName = string.Empty;
            string dbType = string.Empty;
            string nullValue = string.Empty;

			if (token.IndexOf(PARAM_DELIM) > -1) 
			{
				StringTokenizer paramParser = new StringTokenizer(token, PARAM_DELIM, true);
				IEnumerator enumeratorParam = paramParser.GetEnumerator();

				int n1 = paramParser.TokenNumber;
				if (n1 == 3) 
				{
					enumeratorParam.MoveNext();
					propertyName = ((string)enumeratorParam.Current).Trim();

					enumeratorParam.MoveNext();
					enumeratorParam.MoveNext(); //ignore ":"
                    dbType = ((string)enumeratorParam.Current).Trim();

                    //ITypeHandler handler = null;
                    //if (parameterClassType == null) 
                    //{
                    //    handler = scope.DataExchangeFactory.TypeHandlerFactory.GetUnkownTypeHandler();
                    //} 
                    //else 
                    //{
                    //    handler = ResolveTypeHandler(scope.DataExchangeFactory.TypeHandlerFactory, parameterClassType, propertyName, null, dBType);
                    //}
                    //mapping.TypeHandler = handler;
                    //mapping.Initialize( scope, parameterClassType );
				} 
				else if (n1 >= 5) 
				{
					enumeratorParam.MoveNext();
					propertyName = ((string)enumeratorParam.Current).Trim();

					enumeratorParam.MoveNext();
					enumeratorParam.MoveNext(); //ignore ":"
                    dbType = ((string)enumeratorParam.Current).Trim();

					enumeratorParam.MoveNext();
					enumeratorParam.MoveNext(); //ignore ":"
					nullValue = ((string)enumeratorParam.Current).Trim();

					while (enumeratorParam.MoveNext()) 
					{
						nullValue = nullValue + ((string)enumeratorParam.Current).Trim();
					}

                    //ITypeHandler handler = null;
                    //if (parameterClassType == null) 
                    //{
                    //    handler = scope.DataExchangeFactory.TypeHandlerFactory.GetUnkownTypeHandler();
                    //} 
                    //else 
                    //{
                    //    handler = ResolveTypeHandler(scope.DataExchangeFactory.TypeHandlerFactory, parameterClassType, propertyName, null, dBType);
                    //}
                    //mapping.TypeHandler = handler;
                    //mapping.Initialize( scope, parameterClassType );
				} 
				else 
				{
					throw new ConfigurationException("Incorrect inline parameter map format: " + token);
				}
			} 
			else 
			{
				propertyName = token;
                //ITypeHandler handler = null;
                //if (parameterClassType == null) 
                //{
                //    handler = scope.DataExchangeFactory.TypeHandlerFactory.GetUnkownTypeHandler();
                //} 
                //else 
                //{
                //    handler = ResolveTypeHandler(scope.DataExchangeFactory.TypeHandlerFactory, parameterClassType, token, null, null);
                //}
                //mapping.TypeHandler = handler;
                //mapping.Initialize( scope, parameterClassType );


			}

            return new ParameterProperty(
                propertyName,
                string.Empty,
                string.Empty,
                string.Empty,
                dbType,
                string.Empty,
                nullValue,
                0,
                0,
                -1,
                parameterClassType,
                scope.DataExchangeFactory);
		}


        ///// <summary>
        ///// Resolve TypeHandler
        ///// </summary>
        ///// <param name="parameterClassType"></param>
        ///// <param name="propertyName"></param>
        ///// <param name="propertyType"></param>
        ///// <param name="dbType"></param>
        ///// <param name="typeHandlerFactory"></param>
        ///// <returns></returns>
        //private ITypeHandler ResolveTypeHandler(
        //    TypeHandlerFactory typeHandlerFactory, 
        //    Type classType, 
        //    string memberName, 
        //    string memberType, 
        //    string dbType) 
        //{
        //    ITypeHandler handler = null;

        //    if (classType == null) 
        //    {
        //        handler = typeHandlerFactory.GetUnkownTypeHandler();
        //    } 
        //    else if (typeof(IDictionary).IsAssignableFrom(classType))
        //    {
        //        if (memberType == null || memberType.Length==0) 
        //        {
        //            handler = typeHandlerFactory.GetUnkownTypeHandler();
        //        } 
        //        else 
        //        {
        //            try 
        //            {
        //                Type typeClass = TypeUtils.ResolveType(memberType);
        //                handler = typeHandlerFactory.GetTypeHandler(typeClass, dbType);
        //            } 
        //            catch (Exception e) 
        //            {
        //                throw new ConfigurationException("Error. Could not set TypeHandler.  Cause: " + e.Message, e);
        //            }
        //        }
        //    } 
        //    else if (typeHandlerFactory.GetTypeHandler(classType, dbType) != null) 
        //    {
        //        handler = typeHandlerFactory.GetTypeHandler(classType, dbType);
        //    } 
        //    else 
        //    {
        //        Type typeClass = ObjectProbe.GetMemberTypeForGetter(classType, memberName);
        //        handler = typeHandlerFactory.GetTypeHandler(typeClass, dbType);
        //    }

        //    return handler;
        //}

	}
}
