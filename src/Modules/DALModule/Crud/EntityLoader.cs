using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DataAccessLayer.DataObjects;
using DataAccessLayer.SQL;
using KarveDataServices.ViewObjects;

namespace DataAccessLayer.Crud
{ 
    /// <summary>
    ///  This class has the single responsabilty to load an entity.
    /// </summary>
    public class EntityLoader<EntityType>
    {
        private QueryStoreFactory _queryStoreFactory = new QueryStoreFactory();
        /// <summary>
        /// Load an entity from clients and maps the entity to a data transfer object.
        /// </summary>
        /// <param name="conn">Connection to be used</param>
        /// <param name="code">Code of the entity</param>
        /// <returns>A data transfer object to be loaded.</returns>
        public async Task<EntityType> LoadEntity<Entity1,Entity2>(IDbConnection conn, string code)
        {
            var clientPocoQueryStore = _queryStoreFactory.GetQueryStore();
            clientPocoQueryStore.AddParam(QueryType.QueryClient1, code);
            clientPocoQueryStore.AddParam(QueryType.QueryClient2, code);
            var query = clientPocoQueryStore.BuildQuery();
            var pocoReader = await conn.QueryMultipleAsync(query);
            var firstEntity1 = pocoReader.Read<Entity1>().FirstOrDefault();
            var firstEntity2 = pocoReader.Read<Entity2>().FirstOrDefault();
            var entityValue = Activator.CreateInstance<EntityType>();
            var outType = entityValue.GetType();
            if (firstEntity1 != null)
            {
                foreach (var propertyInfo in firstEntity1.GetType().GetProperties())
                {
                    var name = propertyInfo.Name;
                    var prop = outType.GetProperty(name);
                    if (prop == null)
                    {
                        continue;
                    }
                    // ok we have set the property
                    var v = propertyInfo.GetValue(firstEntity1);
                    if (v != null)
                    {
                        prop.SetValue(entityValue, v);
                    }
                }
            }
            if (firstEntity2!= null)
            {
                foreach (var propertyInfo in firstEntity2.GetType().GetProperties())
                {
                    var name = propertyInfo.Name;
                    var prop = outType.GetProperty(name);
                    if (prop == null)
                    {
                        continue;
                    }
                    // ok we have set the property
                    var v = propertyInfo.GetValue(firstEntity2);
                    if (v != null)
                    {
                        prop.SetValue(entityValue, v);
                    }
                }
            }
            return entityValue;
        }
    }
}
