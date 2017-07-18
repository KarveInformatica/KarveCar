using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Apache.Ibatis.Common.Resources;
using Apache.Ibatis.DataMapper;
using Apache.Ibatis.DataMapper.Configuration;
using Apache.Ibatis.DataMapper.Configuration.Interpreters.Config.Xml;
using Apache.Ibatis.Common.Data;
using Apache.Ibatis.Common.Logging;
using Apache.Ibatis.Common.Logging.Impl;
using Apache.Ibatis.Common.Utilities;
using Apache.Ibatis.DataMapper.Session;
using KarveCar.Common;

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
