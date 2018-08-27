using AutoMapper;
using DataAccessLayer.DataObjects;
using KarveDataServices.ViewObjects;

namespace DataAccessLayer.Logic
{
    ///
    /// Dto to POCO converter.
    /// 
    public class ClientDtoToClientes2 : ITypeConverter<ClientViewObject, CLIENTES2>
    {
        public CLIENTES2 Convert(ClientViewObject source, CLIENTES2 destination, ResolutionContext context)
        {
            var entityConverter = new GenericBackConverter<ClientViewObject, CLIENTES2>();
            var entity = entityConverter.Convert(source, destination, context);
            if (entity != null && entity?.EMAIL != null)
            {
                var email = entity.EMAIL.Replace("@", "#");
                entity.EMAIL = email;
            }

            return entity;
        }
    }
}