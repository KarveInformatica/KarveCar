using AutoMapper;
using DataAccessLayer.DataObjects;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.Logic
{
    /// <summary>
    /// ContactsCOMI and mapper field.
    /// </summary>
    public class ContactsComiToDto : ITypeConverter<CONTACTOS_COMI, ContactsDto>
    {
        public ContactsDto Convert(CONTACTOS_COMI source, ContactsDto destination, ResolutionContext context)
        {
            ContactsDto contactsDto = new ContactsDto();
            var contacto = source.CONTACTO;
            contactsDto.ContactId = contacto.ToString();
            contactsDto.ResponsabilitySource = new PersonalPositionDto();
            var cargo = source.CARGO;
            if (cargo != null)
            {
                contactsDto.ResponsabilitySource.Code = cargo.ToString();
            }
            contactsDto.ResponsabilitySource.Name = source.NOM_CARGO;
            contactsDto.ContactName = source.NOM_CONTACTO;
            contactsDto.ContactsKeyId = source.COMISIO;
            var currentDelega = source.DELEGA_CC;
            if (currentDelega.HasValue)
            {
                contactsDto.CurrentDelegation = currentDelega.Value.ToString();
            }
            contactsDto.CurrentUser = source.USUARIO;
            contactsDto.Email = source.EMAIL;
            contactsDto.Fax = source.FAX;
            contactsDto.Telefono = source.TELEFONO;
            contactsDto.Nif = source.NIF;
            contactsDto.Movil = source.MOVIL;
            contactsDto.LastModification = source.ULTMODI;
            contactsDto.User = source.USUARIO;
            return contactsDto;
        }
    }
}