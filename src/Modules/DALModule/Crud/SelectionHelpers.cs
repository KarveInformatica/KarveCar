using AutoMapper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Crud
{
    internal static class SelectionHelpers
    {
        public static IEnumerable<DtoType> SelectDto<EntityType, DtoType>(IMapper mapper, SqlMapper.GridReader gridReader) where DtoType : class
        {

            var hasValue = gridReader.ReadSingle<int>() > 0;
            if (hasValue)
            {
                var entityCollection = gridReader.Read<EntityType>();
                if (entityCollection != null)
                {
                    if (typeof(EntityType) != typeof(DtoType))
                    {
                        return mapper.Map<IEnumerable<EntityType>, IEnumerable<DtoType>>(entityCollection);
                    }
                    else
                    {
                        return entityCollection as IEnumerable<DtoType>;
                    }
                }
            }
            else
            {
                var badValue = gridReader.Read();
            }
            var list = new List<DtoType>();
            return list;
        }

        public static IEnumerable<DtoType> WrappedSelectedDto<EntityType, DtoType>(object value, IMapper mapper, SqlMapper.GridReader reader) where DtoType : class
        {
            IEnumerable<DtoType> current = new List<DtoType>();
            if ((value == null) || (reader == null))
            {
                return current;
            }
            
            current = SelectDto<EntityType, DtoType>(mapper, reader);
            return current;
            
        }
        public static string ValueString(byte? b)
        {
            if (b.HasValue)
            {
                return Convert.ToString(b);
            }
            else
            {
                return "0";
            }
        }
    }
}
