using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
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
    public abstract class BaseDataMapper : IDalObject
    {
        // Data mapper 
        protected IDataMapper DataMapper;
        // Data session 
        protected ISessionFactory SessionFactory;
        // mapper factory
        protected IMapperFactory MapperFactory;
        // mapper configuration engine.
        protected IConfigurationEngine ConfigurationEngine;
        // Get the lower level of Items.
        public abstract GenericObservableCollection GetItems();
        // Deprecate store a GenericObservableCollection to the database
        public abstract void SetItems(GenericObservableCollection collection);
        // Store an observable collection from the database.
        public abstract void StoreCollection<T>(ObservableCollection<T> collection);
        // Remove a collection from the the database.
        public abstract void RemoveCollection<T>(ObservableCollection<T> collection);
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
        
        protected void StoreCollection<T>(string mapperMethod, IList<T> current)
        {
            DataMapper.Update(mapperMethod, current);
        }
        protected void RemoveCollection<T>(string mapperMethod, IList<T> current)
        {
            DataMapper.Delete(mapperMethod, current);
            
        }
    }
}
