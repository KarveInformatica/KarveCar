using System.Collections.Generic;
using Dapper;
using DataAccessLayer.DataObjects;

namespace DataAccessLayer.Crud
{
    /// <summary>
    ///  EntityMapper. This maps the entities to a l
    /// </summary>
    public class EntityMapper
    {
        /// <summary>
        ///  This deserialize the mapper to the entity.
        /// </summary>
        /// <param name="reader">SqlReader</param>
        /// <param name="deserializer">Deserializer</param>
        /// <returns></returns>
        public List<EntityDecorator> Map(SqlMapper.GridReader reader, EntityDeserializer deserializer)
        {
            List<EntityDecorator> decorators = new List<EntityDecorator>();
            while (!reader.IsConsumed)
            {
                var row = reader.Read();
                foreach (var singleValue in row)
                {
                    var deserialized = deserializer.Deserialize(singleValue);
                    if (deserialized != null)
                    {
                        decorators.Add(deserialized);
                    }
                }
            }
            return decorators;
        }
    }
}
