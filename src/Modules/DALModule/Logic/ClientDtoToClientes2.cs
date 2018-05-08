using AutoMapper;
using DataAccessLayer.DataObjects;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.Logic
{
    ///
    /// Dto to POCO converter.
    /// 
    public class ClientDtoToClientes2 : ITypeConverter<ClientDto, CLIENTES2>
    {
        public CLIENTES2 Convert(ClientDto source, CLIENTES2 destination, ResolutionContext context)
        {
            var entityConverter = new GenericBackConverter<ClientDto, CLIENTES2>();
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