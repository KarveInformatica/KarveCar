using AutoMapper;
using KarveDapper.Extensions;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataObjects
{
    public class EntityDeserializer
    {
        private static readonly ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>> KeyProperties = new ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>>();
        private static readonly ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>> TypeProperties = new ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>>();
        private static readonly ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>> ComputedProperties = new ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>>();

        private readonly IList<Type> types = new List<Type>();
        private IList<object> _entities;
        private IList<object> _dtos;
        /// <summary>
        ///  This is an entity deserializer.
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="type"></param>
        public EntityDeserializer(IList<object> entities, IList<object> dtos)
        {
            _entities = entities;
            _dtos = dtos;
            foreach (var e in entities)
            {
                types.Add(e.GetType());
                KeyPropertiesCache(e.GetType());
            }
        }
        /// <summary>
        ///  Select a dto from a list of values.
        /// </summary>
        /// <typeparam name="T">Type of the value</typeparam>
        /// <param name="decorator">Decorator to be used.</param>
        /// <returns>A list of values</returns>
        public IEnumerable<T1> SelectDto<T, T1>(IMapper mapper, List<EntityDecorator> decorator) where T : class
        {
            IList<T1> selectedValues = new List<T1>();
            var values = decorator.Where(x => x.DtoType == typeof(T1));
            foreach (var v in values)
            {
                var currentEntity = v.Value as T;
                var item = mapper.Map<T, T1>(currentEntity);
                selectedValues.Add(item);
            }
            return selectedValues;
        }
        private List<PropertyInfo> KeyPropertiesCache(Type type)
        {
            if (KeyProperties.TryGetValue(type.TypeHandle, out IEnumerable<PropertyInfo> pi))
            {
                return pi.ToList();
            }

            var allProperties = TypePropertiesCache(type);
            var keyProperties = allProperties.Where(p => p.GetCustomAttributes(true).Any(a => a is KeyAttribute)).ToList();

            if (keyProperties.Count == 0)
            {
                var idProp = allProperties.Find(p => string.Equals(p.Name, "id", StringComparison.CurrentCultureIgnoreCase));
                if (idProp != null && !idProp.GetCustomAttributes(true).Any(a => a is ExplicitKeyAttribute))
                {
                    keyProperties.Add(idProp);
                }
            }

            KeyProperties[type.TypeHandle] = keyProperties;
            return keyProperties;
        }

        private List<PropertyInfo> TypePropertiesCache(Type type)
        {
            if (TypeProperties.TryGetValue(type.TypeHandle, out IEnumerable<PropertyInfo> pis))
            {
                return pis.ToList();
            }

            var properties = type.GetProperties().Where(IsWriteable).ToArray();
            TypeProperties[type.TypeHandle] = properties;
            return properties.ToList();
        }

        private bool IsWriteable(PropertyInfo pi)
        {
            var attributes = pi.GetCustomAttributes(typeof(WriteAttribute), false).ToList();
            if (attributes.Count != 1) return true;
            var writeAttribute = (WriteAttribute)attributes[0];
            return writeAttribute.Write;
        }
        private bool IsSameEntity(PropertyInfo[] properties, ICollection<string> keys)
        {
            if (keys.Count() == properties.Count())
            {
                var currentProp = from v in properties select v.Name;
                var keyCount = keys.Count();
                var count = currentProp.Intersect(keys).Count();
                return keyCount == count;
            }
            return false;
        }
        
        public EntityDecorator Deserialize(dynamic row)
        {
            int i = 0;
            foreach (var e in _entities)
            {              
                IDictionary<string, object> valueRow = row as IDictionary<string, object>;
                if (row == null)
                    return null;
               bool sameEntity = IsSameEntity(e.GetType().GetProperties(), valueRow.Keys);
               if (sameEntity)
               {
                    var entityValue = Activator.CreateInstance(e.GetType());
                    foreach (var property in e.GetType().GetProperties())
                    {
                        var sinkProperty = entityValue.GetType().GetProperty(property.Name);
                        if (sinkProperty != null)
                        {
                            sinkProperty.SetValue(entityValue, valueRow[property.Name]);
                        }
                    }
                    EntityDecorator decorator = new EntityDecorator();
                    decorator.Value = entityValue;
                    decorator.Type = e.GetType();
                    if (i < _dtos.Count())
                    {
                        decorator.DtoType = _dtos[i].GetType();                   
                    }
                    return decorator;
               }
             ++i;
            }
            return null;
        }

        
    }
}
