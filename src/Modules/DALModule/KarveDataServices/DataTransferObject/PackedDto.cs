using System;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    /// This class packs the dto from the conversion
    /// </summary>
    /// <typeparam name="Entity">Entity to be used for packing.</typeparam>
    /// <typeparam name="RelatedEntity">Related helper entity.</typeparam>
    public class PackedEntity<Entity, RelatedEntity>
    {
        public PackedEntity()
        {
        }

        /// <summary>
        /// Construct the wrapper for automapper conversion
        /// </summary>
        /// <param name="pEntity">Dto to be used for the conversion</param>
        /// <param name="rEntity">Helper dto to be incapsulated</param>
        public PackedEntity(Entity pDto, RelatedEntity rDto)
        {
            PackItem = pDto;
            HelperItem = rDto;
        }
        /// <summary>
        ///  Entity to be used.
        /// </summary>
        public Entity PackItem { set; get;}
        /// <summary>
        ///  Related entity.
        /// </summary>
        public RelatedEntity HelperItem { set; get;} 
    }
}