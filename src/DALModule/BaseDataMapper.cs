using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Apache.Ibatis.DataMapper;
using Apache.Ibatis.DataMapper.Configuration;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config.Xml;
using Apache.Ibatis.DataMapper.Session;
using KarveCommon.Generic;
using KarveDataServices;

namespace DataAccessLayer
{
    /// <summary>
    ///  Abstract calls that provide the base configuration for all data acess layer classes.
    /// </summary>
    public class BaseDataMapper: IKarveDataMapper
    {
        // Data mapper 
        private IDataMapper _mapper;
        // Data session 
        private ISessionFactory _sessionFactory;
        // mapper factory
        private IMapperFactory _mapperFactory;
        // mapper configuration engine.
        private IConfigurationEngine _configurationEngine;
        // Type of the data object
        private string _resource;
    
        public string ConfigFile { get { return _resource; } set { _resource = value; } }
        public IDataMapper DataMapper { get { return _mapper; } }
        public ISessionFactory SessionFactory { get { return _sessionFactory; }  }

        // Field of the data object that shall be not duplicated.
        public const string DuplicateFieldCheck = "Codigo";
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseDataMapper()
        {
            _resource = "SqlMap.config";
            InitMapper(_resource);
        }
       
        private void InitMapper(string resource)
        {
            try
            {
                 _configurationEngine = new DefaultConfigurationEngine();
                _configurationEngine.RegisterInterpreter(new XmlConfigurationInterpreter(resource));
                _mapperFactory = _configurationEngine.BuildMapperFactory();
                _sessionFactory = _configurationEngine.ModelStore.SessionFactory;
                _mapper = ((IDataMapperAccessor)_mapperFactory).DataMapper;
            }
            catch (Exception e)
            {
                string reason = e.StackTrace + " BaseDataMapper failed initialization";
                DataLayerExecutionException ex = new DataLayerExecutionException(reason);
                throw ex;
            }
        }
    }
}
