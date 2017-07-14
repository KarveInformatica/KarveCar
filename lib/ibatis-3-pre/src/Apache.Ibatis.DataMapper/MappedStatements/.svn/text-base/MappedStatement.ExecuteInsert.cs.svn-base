#region Apache Notice
/*****************************************************************************
 * $Revision: 374175 $
 * $LastChangedDate: 2008-10-11 12:07:44 -0400 (Sat, 11 Oct 2008) $
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

using System.Data;
using Apache.Ibatis.Common.Utilities.Objects;
using Apache.Ibatis.DataMapper.Model.Statements;
using Apache.Ibatis.DataMapper.Session;
using Apache.Ibatis.DataMapper.TypeHandlers;

namespace Apache.Ibatis.DataMapper.MappedStatements
{
    public partial class MappedStatement
    {
        /// <summary>
        /// Execute an insert statement. Fill the parameter object with 
        /// the ouput parameters if any, also could return the insert generated key
        /// </summary>
        /// <param name="session">The session</param>
        /// <param name="parameterObject">The parameter object used to fill the statement.</param>
        /// <returns>Can return the insert generated key.</returns>
        public virtual object ExecuteInsert(ISession session, object parameterObject)
        {
            return Execute(PreInsertEventKey,PostInsertEventKey,session,parameterObject,
               (r, p) =>
               {
                   #region RunInsert

                   object generatedKey = null;
                   SelectKey selectKeyStatement = null;

                   if (statement is Insert)
                   {
                       selectKeyStatement = ((Insert)statement).SelectKey;
                   }

                   if (selectKeyStatement != null && !selectKeyStatement.isAfter)
                   {
                       IMappedStatement mappedStatement = modelStore.GetMappedStatement(selectKeyStatement.Id);
                       generatedKey = mappedStatement.ExecuteQueryForObject(session, p, null);

                       ObjectProbe.SetMemberValue(p, selectKeyStatement.PropertyName, generatedKey,
                           r.DataExchangeFactory.ObjectFactory,
                           r.DataExchangeFactory.AccessorFactory);
                   }

                   preparedCommand.Create(r, session, Statement, p);

                   using (IDbCommand command = r.IDbCommand)
                   {
                       if (statement is Insert)
                       {
                           command.ExecuteNonQuery();
                       }
                       // Retrieve output parameter if the result class is specified
                       else if (statement is Procedure && (statement.ResultClass != null) &&
                               modelStore.DataExchangeFactory.TypeHandlerFactory.IsSimpleType(statement.ResultClass))
                       {
                           IDataParameter returnValueParameter = command.CreateParameter();
                           returnValueParameter.Direction = ParameterDirection.ReturnValue;
                           command.Parameters.Add(returnValueParameter);

                           command.ExecuteNonQuery();
                           generatedKey = returnValueParameter.Value;

                           ITypeHandler typeHandler = modelStore.DataExchangeFactory.TypeHandlerFactory.GetTypeHandler(statement.ResultClass);
                           generatedKey = typeHandler.GetDataBaseValue(generatedKey, statement.ResultClass);
                       }
                       else
                       {
                           generatedKey = command.ExecuteScalar();
                           if ((statement.ResultClass != null) &&
                               modelStore.DataExchangeFactory.TypeHandlerFactory.IsSimpleType(statement.ResultClass))
                           {
                               ITypeHandler typeHandler = modelStore.DataExchangeFactory.TypeHandlerFactory.GetTypeHandler(statement.ResultClass);
                               generatedKey = typeHandler.GetDataBaseValue(generatedKey, statement.ResultClass);
                           }
                       }

                       if (selectKeyStatement != null && selectKeyStatement.isAfter)
                       {
                           IMappedStatement mappedStatement = modelStore.GetMappedStatement(selectKeyStatement.Id);
                           generatedKey = mappedStatement.ExecuteQueryForObject(session, p, null);

                           ObjectProbe.SetMemberValue(p, selectKeyStatement.PropertyName, generatedKey,
                               r.DataExchangeFactory.ObjectFactory,
                               r.DataExchangeFactory.AccessorFactory);
                       }

                       RetrieveOutputParameters(r, session, command, p);
                   }

                   // ???
                   return generatedKey;

                   #endregion
               });
        }
    }
}
