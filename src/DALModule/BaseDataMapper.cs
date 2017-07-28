using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        // Set the provided items
        public abstract void SetItems(GenericObservableCollection collection);
        public abstract bool RemoveCollection<T>(ObservableCollection<T> collection);

        

        public abstract bool StoreCollection<T>(ObservableCollection<T> collection);

        public string Id { get; protected set; }
        public Type DalType { set; get; }
        // this is enforce the name of the field of the duplicates
        public const string DuplicateFieldCheck = "Codigo";

        /* add exception handling and pop up the exception */
        protected BaseDataMapper()
        {
            string resource = "SqlMap.config";
            // Before have 4 properties
            ConfigurationEngine = new DefaultConfigurationEngine();
            ConfigurationEngine.RegisterInterpreter(new XmlConfigurationInterpreter(resource));
            MapperFactory = ConfigurationEngine.BuildMapperFactory();
            SessionFactory = ConfigurationEngine.ModelStore.SessionFactory;
            DataMapper = ((IDataMapperAccessor)MapperFactory).DataMapper;

        }
        protected bool StoreCollection<T>(string mapperMethod, IList<T> current)
        {
            int ret = DataMapper.Update(mapperMethod, current);
            return true;
        }
        protected bool RemoveCollection<T>(string mapperMethod, IList<T> current)
        {
            int ret = DataMapper.Delete(mapperMethod, current);
            return true;
        }

    }
}
