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
    public abstract class BaseDataMapper : IDalObject
    {
        protected IDataMapper DataMapper;
        protected ISessionFactory SessionFactory;
        protected IMapperFactory MapperFactory;
        protected IConfigurationEngine ConfigurationEngine;
        public abstract GenericObservableCollection GetItems();
        public abstract void SetItems(GenericObservableCollection collection);
        public abstract void SetUniqueItems(GenericObservableCollection collection);
        public abstract bool StoreCollection<T>(ObservableCollection<T> collection);
        public abstract bool RemoveCollection<T>(ObservableCollection<T> collection);
        public abstract string Id { get; }
        public abstract Type DalType { set; get; }
        public const string DuplicateFieldCheck = "CODE";

        /* add exception handling and pop up the exception */
        protected BaseDataMapper(string uri)
        {
            string resource = "SqlMap.config";
            // Before have 4 properties
            ConfigurationEngine = new DefaultConfigurationEngine();
            ConfigurationEngine.RegisterInterpreter(new XmlConfigurationInterpreter(resource));
            MapperFactory = ConfigurationEngine.BuildMapperFactory();
            SessionFactory = ConfigurationEngine.ModelStore.SessionFactory;
            DataMapper = ((IDataMapperAccessor)MapperFactory).DataMapper;

        }

        /// <summary>
        /// This method filter duplicates from an input observable collection. It prevents showing duplicates in the Grid. 
        /// The UI protects itself against duplicates in the database. 
        /// </summary>
        /// <typeparam name="T">Generic type of the observable collection</typeparam>
        /// <param name="dataCollection">Observable collection to be filtered</param>
        /// <returns>A filtered collection withot any</returns>
        protected ObservableCollection<object> FilterCollectionDuplicates<T>(ObservableCollection<T> dataCollection)
        {
            ObservableCollection<object> abstractCollection = new ObservableCollection<object>();
            foreach (var item in dataCollection)
            {
                //Se recorre la GenericObservableCollection, y cada object se convierte en un string
                //como el ejemplo: [key1, value1];[ke2, value2]...
                string stringItem = GenericObjectHelper.PropertyConvertToDictionary(item);
                //Se hace un split del string con los object de la GenericObservableCollection, y se
                //guardan los valores de una misma propiedad en una IList
                IList<string> tempString = stringItem.Split(';').ToList();
                ISet<string> collectionTemp = new SortedSet<string>();
                bool result = false;
                //Se recorren los valores para cada IList que corresponde a cada propiedad del object,
                //y se comprueba que no haya valores repetidos
                foreach (string itemTempString in tempString)
                {
                    //Si el valor no existe, se añade a la SortedSet temporal(collectionAux), y se 
                    //comprueba que el siguiente valor no esté en esta SortedSet temporal

                    if (itemTempString.Contains(DuplicateFieldCheck))
                    {
                        if (!collectionTemp.Contains(itemTempString))
                        {
                            collectionTemp.Add(itemTempString);
                        }
                        else
                        {
                            result = true;
                            break;
                        }
                    }
                }
                if (!result)
                {
                    abstractCollection.Add((object)item);

                }
            }
            return abstractCollection;
        }
    }
}
