#region Apache Notice
/*****************************************************************************
 * $Revision: 408099 $
 * $LastChangedDate: 2009-06-13 20:01:00 -0600 (Sat, 13 Jun 2009) $
 * $LastChangedBy: rgrabowski $
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
using Apache.Ibatis.DataMapper.DataExchange;
using Apache.Ibatis.DataMapper.Model.Sql.Dynamic;
using Apache.Ibatis.DataMapper.Model.Statements;

namespace Apache.Ibatis.DataMapper.Model.ParameterMapping
{
    /// <summary>
    /// Inline Paremeter MapBuilder
    /// </summary>
    public class InlineParemeterMapBuilder
    {
        private const string MARK_TOKEN = "?";
        private const string COMMA_TOKEN = ",";

        private readonly InlineParameterMapParser paramParser = new InlineParameterMapParser();
        private readonly IModelStore modelStore = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineParemeterMapBuilder"/> class.
        /// </summary>
        public InlineParemeterMapBuilder(IModelStore modelStore)
        {
            this.modelStore = modelStore;
        }


        /// <summary>
        /// Build inline paremeterMap
        /// </summary>
        /// <param name="statement">The statement.</param>
        /// <param name="sqlCommandText">The SQL command text.</param>
        /// <param name="newSqlCommandText">The newsql command text.</param>
        /// <returns></returns>
        public ParameterMap BuildInlineParemeterMap(IStatement statement, string sqlCommandText, out string newSqlCommandText)
        {
            newSqlCommandText = sqlCommandText;
            ParameterMap map = null;
     
            // Check the inline parameter
            if (statement.ParameterMap == null)
            {
                // Build a Parametermap with the inline parameters.
                // if they exist. Then delete inline infos from sqltext.

                SqlText sqlText = InlineParameterMapParser.ParseInlineParameterMap(modelStore.DataExchangeFactory, statement.Id, statement, newSqlCommandText);

                if (sqlText.Parameters.Length > 0)
                {
                    string id = statement.Id + "-InLineParameterMap";
                    string className = string.Empty;
                    Type classType = null;
                    IDataExchange dataExchange = null;

                    if (statement.ParameterClass != null)
                    {
                        className = statement.ParameterClass.Name;
                        classType = statement.ParameterClass;
                        //dataExchange = modelStore.DataExchangeFactory.GetDataExchangeForClass(classType);
                    }

                    if (statement.ParameterClass == null &&
                        sqlText.Parameters.Length == 1 && sqlText.Parameters[0].PropertyName == "value")//#value# parameter with no parameterClass attribut
                    {
                        dataExchange = modelStore.DataExchangeFactory.GetDataExchangeForClass(typeof(int));//Get the primitiveDataExchange
                    }
                    else
                    {
                        dataExchange = modelStore.DataExchangeFactory.GetDataExchangeForClass(statement.ParameterClass);
                    }

                    map = new ParameterMap(
                        id,
                        className,
                        string.Empty,
                        classType,
                        dataExchange,
                        modelStore.SessionFactory.DataSource.DbProvider.UsePositionalParameters
                        )
                        ;
                    int lenght = sqlText.Parameters.Length;
                    for (int index = 0; index < lenght; index++)
                    {
                        map.AddParameterProperty(sqlText.Parameters[index]);
                    }
                }
                newSqlCommandText = sqlText.Text;
            }

            if (statement is Procedure)
            {
                newSqlCommandText = newSqlCommandText.Replace(MARK_TOKEN, string.Empty).Replace(COMMA_TOKEN, string.Empty);
            }
            // newSqlCommandText = newSqlCommandText.Trim();

            return map;
        }
    }
}
