#region Apache Notice
/*****************************************************************************
 * $Revision: 408099 $
 * $LastChangedDate: 2009-06-28 10:11:37 -0600 (Sun, 28 Jun 2009) $
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
using System.Text;
using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.Common.Contracts;
using Apache.Ibatis.Common.Exceptions;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config;
using Apache.Ibatis.DataMapper.Configuration.Serializers;
using Apache.Ibatis.DataMapper.MappedStatements;
using Apache.Ibatis.DataMapper.Model.ParameterMapping;
using Apache.Ibatis.DataMapper.Model.Sql.Dynamic;
using Apache.Ibatis.DataMapper.Model.Sql.Dynamic.Elements;
using Apache.Ibatis.DataMapper.Model.Sql.External;
using Apache.Ibatis.DataMapper.Model.Sql.SimpleDynamic;
using Apache.Ibatis.DataMapper.Model.Sql.Static;
using Apache.Ibatis.DataMapper.Model.Statements;
using Apache.Ibatis.DataMapper.Session;

namespace Apache.Ibatis.DataMapper.Configuration
{
    /// <summary>
    /// This implementation of <see cref="IConfigurationStore"/>, builds all statement.
    /// </summary>
    public partial class DefaultModelBuilder
    {
        private readonly InlineParameterMapParser paramParser = new InlineParameterMapParser();

        /// <summary>
        /// Builds the mapped statements.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <param name="configurationSetting"></param>
        private void BuildMappedStatements(IConfigurationStore store, ConfigurationSetting configurationSetting)
        {
            for (int i = 0; i < store.Statements.Length; i++)
            {
                IConfiguration statementConfig = store.Statements[i];
                IMappedStatement mappedStatement = null;

                switch (statementConfig.Type)
                {
                    case ConfigConstants.ELEMENT_STATEMENT:
                        mappedStatement = BuildStatement(statementConfig, configurationSetting);
                        break;
                    case ConfigConstants.ELEMENT_SELECT:
                        mappedStatement = BuildSelect(statementConfig, configurationSetting);
                        break;
                    case ConfigConstants.ELEMENT_INSERT:
                        mappedStatement = BuildInsert(statementConfig, configurationSetting);
                        break;
                    case ConfigConstants.ELEMENT_UPDATE:
                        mappedStatement = BuildUpdate(statementConfig, configurationSetting);
                        break;
                    case ConfigConstants.ELEMENT_DELETE:
                        mappedStatement = BuildDelete(statementConfig, configurationSetting);
                        break;
                    case ConfigConstants.ELEMENT_PROCEDURE:
                        mappedStatement = BuildProcedure(statementConfig, configurationSetting);
                        break;
                    case ConfigConstants.ELEMENT_SQL:
                        break;
                    default:
                        throw new ConfigurationException("Cannot build the statement, cause invalid statement type '" + statementConfig.Type + "'.");

                }
                if (mappedStatement!=null)
                {
                    modelStore.AddMappedStatement(mappedStatement);
                }
            }
        }

        /// <summary>
        /// Builds a Mapped Statement for a statement.
        /// </summary>
        /// <param name="statement">The statement.</param>
        /// <param name="mappedStatement">The mapped statement.</param>
        /// <returns></returns>
        private IMappedStatement BuildCachingStatement(IStatement statement, MappedStatement mappedStatement)
        {
            IMappedStatement mapStatement = mappedStatement;
            if (statement.CacheModel != null && isCacheModelsEnabled)
            {
                mapStatement = new CachingStatement(mappedStatement);
            }
            return mapStatement;
        }

        /// <summary>
        /// Builds a <see cref="Statement"/> for a statement configuration.
        /// </summary>
        /// <param name="statementConfig">The statement config.</param>
        /// <param name="configurationSetting"></param>
        private IMappedStatement BuildStatement(IConfiguration statementConfig, ConfigurationSetting configurationSetting)
        {
            BaseStatementDeSerializer statementDeSerializer = new StatementDeSerializer();
            IStatement statement = statementDeSerializer.Deserialize(modelStore, statementConfig, configurationSetting);
            ProcessSqlStatement(statementConfig, statement);
            MappedStatement mappedStatement = new MappedStatement(modelStore, statement);

            return BuildCachingStatement(statement, mappedStatement);
        }

        /// <summary>
        /// Builds an <see cref="Insert"/> for a insert configuration.
        /// </summary>
        /// <param name="statementConfig">The statement config.</param>
        /// <param name="configurationSetting"></param>
        private IMappedStatement BuildInsert(IConfiguration statementConfig, ConfigurationSetting configurationSetting)
        {
            BaseStatementDeSerializer insertDeSerializer = new InsertDeSerializer();
            IStatement statement = insertDeSerializer.Deserialize(modelStore, statementConfig, configurationSetting);
            ProcessSqlStatement(statementConfig, statement);
            MappedStatement mappedStatement = new InsertMappedStatement(modelStore, statement);
            Insert insert = (Insert)statement;
            if (insert.SelectKey != null)
            {
                ConfigurationCollection selectKeys = statementConfig.Children.Find(ConfigConstants.ELEMENT_SELECTKEY);
                IConfiguration selectKeyConfig = selectKeys[0];

                ProcessSqlStatement(selectKeyConfig, insert.SelectKey);
                MappedStatement mapStatement = new MappedStatement(modelStore, insert.SelectKey);
                modelStore.AddMappedStatement(mapStatement);
            }

            return BuildCachingStatement(statement, mappedStatement);
        }

        /// <summary>
        /// Builds an <see cref="Statement"/> for a statement configuration.
        /// </summary>
        /// <param name="statementConfig">The statement config.</param>
        /// <param name="configurationSetting"></param>
        private IMappedStatement BuildUpdate(IConfiguration statementConfig, ConfigurationSetting configurationSetting)
        {
            BaseStatementDeSerializer updateDeSerializer = new UpdateDeSerializer();
            IStatement statement = updateDeSerializer.Deserialize(modelStore, statementConfig, configurationSetting);
            ProcessSqlStatement(statementConfig, statement);
            MappedStatement mappedStatement = new UpdateMappedStatement(modelStore, statement);

            return BuildCachingStatement(statement, mappedStatement);

        }

        /// <summary>
        /// Builds an <see cref="Delete"/> for a delete configuration.
        /// </summary>
        /// <param name="statementConfig">The statement config.</param>
        /// <param name="configurationSetting"></param>
        private IMappedStatement BuildDelete(IConfiguration statementConfig, ConfigurationSetting configurationSetting)
        {
            BaseStatementDeSerializer deleteDeSerializer = new DeleteDeSerializer();
            IStatement statement = deleteDeSerializer.Deserialize(modelStore, statementConfig, configurationSetting);
            ProcessSqlStatement(statementConfig, statement);
            MappedStatement mappedStatement = new DeleteMappedStatement(modelStore, statement);

            return BuildCachingStatement(statement, mappedStatement);

        }

        /// <summary>
        /// Builds an <see cref="Select"/> for a select configuration.
        /// </summary>
        /// <param name="statementConfig">The statement config.</param>
        /// <param name="configurationSetting"></param>
        private IMappedStatement BuildSelect(IConfiguration statementConfig, ConfigurationSetting configurationSetting)
        {
            BaseStatementDeSerializer selectDeSerializer = new SelectDeSerializer();
            IStatement statement = selectDeSerializer.Deserialize(modelStore, statementConfig, configurationSetting);
            ProcessSqlStatement(statementConfig, statement);
            MappedStatement mappedStatement = new SelectMappedStatement(modelStore, statement);

            return BuildCachingStatement(statement, mappedStatement);

        }

        /// <summary>
        /// Builds an <see cref="Procedure"/> for a procedure configuration.
        /// </summary>
        /// <param name="statementConfig">The statement config.</param>
        /// <param name="configurationSetting"></param>
        private IMappedStatement BuildProcedure(IConfiguration statementConfig, ConfigurationSetting configurationSetting)
        {
            BaseStatementDeSerializer procedureDeSerializer = new ProcedureDeSerializer();
            IStatement statement = procedureDeSerializer.Deserialize(modelStore, statementConfig, configurationSetting);
            ProcessSqlStatement(statementConfig, statement);
            MappedStatement mappedStatement = new MappedStatement(modelStore, statement);

            return BuildCachingStatement(statement, mappedStatement);
        }

        /// <summary>
        /// Process the Sql cpmmand text statement (Build ISql)
        /// </summary>
        /// <param name="statementConfiguration">The statement configuration.</param>
        /// <param name="statement">The statement.</param>
        private void ProcessSqlStatement(IConfiguration statementConfiguration, IStatement statement)
        {
            if(dynamicSqlEngine!=null)
            {
                statement.SqlSource = dynamicSqlEngine;
            }

            if (statement.SqlSource!=null)
            {
                #region sqlSource - external processor
                string commandText = string.Empty;

                if (statementConfiguration.Children.Count > 0)
                {
                    IConfiguration child = statementConfiguration.Children[0];
                    if (child.Type == ConfigConstants.ELEMENT_TEXT || child.Type == ConfigConstants.ELEMENT_CDATA)
                    {
                        // pass the unformated sql to the external processor
                        commandText = child.Value;
                    }
                }

                ExternalSql externalSql = new ExternalSql(modelStore, statement, commandText);
                statement.Sql = externalSql; 
                #endregion
            }
            else
            {
                #region default - internal processor
                bool isDynamic = false;

                DynamicSql dynamic = new DynamicSql(
                    modelStore.SessionFactory.DataSource.DbProvider.UsePositionalParameters,
                    modelStore.DBHelperParameterCache,
                    modelStore.DataExchangeFactory,
                    statement);
                StringBuilder sqlBuffer = new StringBuilder();

                isDynamic = ParseDynamicTags(statementConfiguration, dynamic, sqlBuffer, isDynamic, false, statement);

                if (isDynamic)
                {
                    statement.Sql = dynamic;
                }
                else
                {
                    string sqlText = sqlBuffer.ToString();
                    string newSqlCommandText = string.Empty;

                    ParameterMap map = inlineParemeterMapBuilder.BuildInlineParemeterMap(statement, sqlText, out newSqlCommandText);
                    if (map != null)
                    {
                        statement.ParameterMap = map;
                    }

                    if (SimpleDynamicSql.IsSimpleDynamicSql(newSqlCommandText))
                    {
                        statement.Sql = new SimpleDynamicSql(
                            modelStore.DataExchangeFactory,
                            modelStore.DBHelperParameterCache,
                            newSqlCommandText,
                            statement);
                    }
                    else
                    {
                        if (statement is Procedure)
                        {
                            statement.Sql = new ProcedureSql(
                                modelStore.DataExchangeFactory,
                                modelStore.DBHelperParameterCache,
                                newSqlCommandText,
                                statement);
                            // Could not call BuildPreparedStatement for procedure because when NUnit Test
                            // the database is not here (but in theory procedure must be prepared like statement)
                            // It's even better as we can then switch DataSource.
                        }
                        else if (statement is Statement)
                        {
                            statement.Sql = new StaticSql(
                                modelStore.DataExchangeFactory,
                                modelStore.DBHelperParameterCache,
                                statement);

                            // this does not open a connection to the database
                            ISession session = modelStore.SessionFactory.OpenSession();

                            ((StaticSql)statement.Sql).BuildPreparedStatement(session, newSqlCommandText);

                            session.Close();
                        }
                    } 
                }                
                #endregion
            }                

            Contract.Ensure.That(statement.Sql, Is.Not.Null).When("process Sql statement.");
        }


        /// <summary>
        /// Parse dynamic tags
        /// </summary>
        /// <param name="statementConfig">The statement config.</param>
        /// <param name="dynamic">The dynamic.</param>
        /// <param name="sqlBuffer">The SQL buffer.</param>
        /// <param name="isDynamic">if set to <c>true</c> [is dynamic].</param>
        /// <param name="postParseRequired">if set to <c>true</c> [post parse required].</param>
        /// <param name="statement">The statement.</param>
        /// <returns></returns>
        private bool ParseDynamicTags(
            IConfiguration statementConfig, 
            IDynamicParent dynamic,
            StringBuilder sqlBuffer, 
            bool isDynamic, 
            bool postParseRequired, 
            IStatement statement)
        {
            ConfigurationCollection children = statementConfig.Children;
            int count = children.Count;
            for (int i = 0; i < count; i++)
            {
                IConfiguration child = children[i];
                if (child.Type == ConfigConstants.ELEMENT_TEXT || child.Type == ConfigConstants.ELEMENT_CDATA)
                {
                    string childValueString = child.Value;
                    if (statement.PreserveWhitespace)
                    {
                        childValueString = childValueString
                            .Replace('\n', ' ')
                            .Replace('\r', ' ')
                            .Replace('\t', ' ')
                            .Trim(); 
                    }

                    SqlText sqlText = null;
                    if (postParseRequired)
                    {
                        sqlText = new SqlText();
                        sqlText.Text = childValueString;
                    }
                    else
                    {
                        sqlText = InlineParameterMapParser.ParseInlineParameterMap(modelStore.DataExchangeFactory, statementConfig.Id, null, childValueString);
                    }

                    dynamic.AddChild(sqlText);
                    sqlBuffer.Append(" " + childValueString);
                }
                else if (child.Type == ConfigConstants.ELEMENT_SELECTKEY || child.Type == ConfigConstants.ELEMENT_INCLUDE)
                { }
                else
                {
                    IDeSerializer serializer = deSerializerFactory.GetDeSerializer(child.Type);

                    if (serializer != null)
                    {
                        isDynamic = true;
                        SqlTag tag;

                        tag = serializer.Deserialize(child);

                        dynamic.AddChild(tag);

                        if (child.Children.Count > 0)
                        {
                            isDynamic = ParseDynamicTags(child, tag, sqlBuffer, isDynamic, tag.Handler.IsPostParseRequired, statement);
                        }
                    }
                }
            }

            return isDynamic;
        }




    }
}
