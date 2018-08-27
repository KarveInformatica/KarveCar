using AutoMapper;
using DataAccessLayer.DataObjects;
using KarveDataServices.ViewObjects;

namespace DataAccessLayer.Logic
{
    ///
    /// Dto to POCO converter.
    /// 
    public class ClientDtoToClientes1 : ITypeConverter<ClientViewObject, CLIENTES1>
    {
        public CLIENTES1 Convert(ClientViewObject source, CLIENTES1 destination, ResolutionContext context)
        {
            var entityConverter = new GenericBackConverter<ClientViewObject, CLIENTES1>();
            var entity = entityConverter.Convert(source, destination, context);
            if (entity?.EMAIL_DEV != null)
            {
                var replace = entity.EMAIL_DEV?.Replace("@", "#");
                entity.EMAIL_DEV = replace;
            }

            if (entity != null && entity.EMAIL_MANT == null)
            {
                return entity;
            }

            if (entity == null)
                return null;

            var emailMaintenaince = entity.EMAIL_MANT.Replace("@", "#");
            entity.EMAIL_MANT = emailMaintenaince;

            var month = source.CreditCardExpiryMonth;
            var year = source.CreditCardExpiryYear;
            entity.TARCADU = month + "/" + year;

            return entity;
        }
    }
}