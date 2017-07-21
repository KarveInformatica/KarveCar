using System;
using Apache.Ibatis.DataMapper;
using Apache.Ibatis.DataMapper.Configuration;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config.Xml;
using Apache.Ibatis.DataMapper.Session;
using KarveCommon.Generic;

namespace DataAccessLayer
{
    public abstract class BaseDataMapper : IDalObject
    {
        protected IDataMapper DataMapper;
        protected ISessionFactory SessionFactory;
        protected IMapperFactory MapperFactory;
        protected IConfigurationEngine ConfigurationEngine;
        public abstract GenericObservableCollection GetItems();
        public abstract void SetItems(GenericObservableCollection collection);
        public abstract void SetUniqueItems(GenericObservableCollection collection);
        public abstract string Id {get;}
        public abstract Type DalType { set; get; }
        /* add exception handling and pop up the exception */
        protected BaseDataMapper(string uri)
        {
            string directoryName = System.Environment.CurrentDirectory;
            string resource = "SqlMap.config";
            // Before have 4 properties
            ConfigurationEngine = new DefaultConfigurationEngine(); 
            ConfigurationEngine.RegisterInterpreter(new XmlConfigurationInterpreter(resource));
            MapperFactory = ConfigurationEngine.BuildMapperFactory();
            SessionFactory = ConfigurationEngine.ModelStore.SessionFactory;
            DataMapper = ((IDataMapperAccessor)MapperFactory).DataMapper;
            
        }
    }
}
