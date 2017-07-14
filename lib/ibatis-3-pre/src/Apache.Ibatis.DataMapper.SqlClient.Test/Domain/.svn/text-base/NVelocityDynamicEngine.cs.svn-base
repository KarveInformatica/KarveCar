using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Apache.Ibatis.Common.Contracts;
using Apache.Ibatis.Common.Logging;
using Apache.Ibatis.DataMapper.Exceptions;
using Apache.Ibatis.DataMapper.MappedStatements;
using Apache.Ibatis.DataMapper.Model.Sql.External;
using NVelocity;
using NVelocity.App;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Domain
{
    /// <summary>
    /// NVelocity implemantation of <see cref="ISqlSource"/>
    /// which parse sql string using Velocity language
    /// </summary>
    /// <remarks>
    /// See http://www.castleproject.org/others/nvelocity/index.html
    /// </remarks>
    public class NVelocityDynamicEngine : ISqlSource
    {
        private readonly VelocityEngine velocityEngine = null;
        private const string VELOCITY_DIRECTIVE = "$";
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Initializes a new instance of the <see cref="NVelocityDynamicEngine"/> class.
        /// </summary>
        public NVelocityDynamicEngine()
        {
            velocityEngine = new VelocityEngine();
            velocityEngine.Init();
        }

        #region ISqlSource Members

        /// <summary>
        /// Gets the SQL.
        /// </summary>
        /// <param name="mappedStatement">The mapped statement.</param>
        /// <param name="parameterObject">The parameter object.</param>
        /// <returns></returns>
        /// <remarks>
        /// Paremeters should be typeof IDictionary<string, object>
        /// </remarks>
        public string GetSql(IMappedStatement mappedStatement, object parameterObject)
        {
            Contract.Assert.That(parameterObject, Is.TypeOf<IDictionary<string, object>>()).When("Processing NVelocity source for statement :" + mappedStatement.Id);

            StringWriter sw = new StringWriter();
            ExternalSql externalSql = (ExternalSql)mappedStatement.Statement.Sql;
            
            string commandText = externalSql.CommandText;

            if (commandText.Contains(VELOCITY_DIRECTIVE))
            {
                VelocityContext velocityContext = new VelocityContext();

                IDictionary<string, object> dico = (IDictionary<string, object>)parameterObject;

                foreach(string key in dico.Keys)
                {
                    velocityContext.Put(key, dico[key]);
                }

                try
                {
                    velocityEngine.Evaluate(velocityContext, sw, "error", commandText);
                }
                catch (Exception ex)
                {
                    if (logger.IsDebugEnabled)
                    {
                        logger.Debug("Could not parse velocity string '" + commandText + "' for " + mappedStatement.Id);
                    }

                    throw new DataMapperException("Could not parse velocity string '" + commandText + "' for " + mappedStatement.Id);
                }
                commandText = sw.GetStringBuilder().ToString();
            }

            if (logger.IsDebugEnabled)
            {
                logger.Debug("SQL command text parse by velocity: " + commandText);
            }

            return commandText;
        }

        #endregion
    }
}
