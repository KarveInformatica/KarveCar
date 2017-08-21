using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Apache.Ibatis.DataMapper;
using Apache.Ibatis.DataMapper.Configuration;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config.Xml;
using Apache.Ibatis.DataMapper.Session;
using KarveCommon.Generic;

namespace DataAccessLayer
{
    /// <summary>
    ///  Abstract calls that provide the base configuration for all data acess layer classes.
    /// </summary>
    public abstract class BaseDataMapper
    {
        // Data mapper 
        protected IDataMapper DataMapper;
        // Data session 
        protected ISessionFactory SessionFactory;
        // mapper factory
        protected IMapperFactory MapperFactory;
        // mapper configuration engine.
        protected IConfigurationEngine ConfigurationEngine;
        // Object identifieer of the data object
        public string Id { get; protected set; }
        // Type of the data object
        public Type DalType { set; get; }
        // Field of the data object that shall be not duplicated.
        public const string DuplicateFieldCheck = "Codigo";
        
        /// <summary>
        /// Default constructor
        /// </summary>
        protected BaseDataMapper()
        {
            string resource = "SqlMap.config";
            InitMapper(resource);
        }
        protected BaseDataMapper(string resource)
        {
            InitMapper(resource);
        }
        private void InitMapper(string resource)
        {
            try
            {
                ConfigurationEngine = new DefaultConfigurationEngine();
                ConfigurationEngine.RegisterInterpreter(new XmlConfigurationInterpreter(resource));
                MapperFactory = ConfigurationEngine.BuildMapperFactory();
                SessionFactory = ConfigurationEngine.ModelStore.SessionFactory;
                DataMapper = ((IDataMapperAccessor)MapperFactory).DataMapper;
            }
            catch (Exception e)
            {
                string reason = e.Message + " BaseDataMapper failed initialization";
                DataLayerExecutionException ex = new DataLayerExecutionException(reason);
                throw ex;
            }
        }
    }
}
