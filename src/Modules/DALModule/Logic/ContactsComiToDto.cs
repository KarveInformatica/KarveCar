using AutoMapper;
using DataAccessLayer.DataObjects;
using KarveDataServices.ViewObjects;

namespace DataAccessLayer.Logic
{
    /// <summary>
    /// ContactsCOMI and mapper field.
    /// </summary>
    public class ContactsComiToDto : ITypeConverter<CONTACTOS_COMI, ContactsViewObject>
    {
        public ContactsViewObject Convert(CONTACTOS_COMI source, ContactsViewObject destination, ResolutionContext context)
        {
            ContactsViewObject contactsViewObject = new ContactsViewObject();
            var contacto = source.CONTACTO;
            contactsViewObject.ContactId = contacto.ToString();
            contactsViewObject.ResponsabilitySource = new PersonalPositionViewObject();
            var cargo = source.CARGO;
            if (cargo != null)
            {
                contactsViewObject.ResponsabilitySource.Code = cargo.ToString();
            }
            contactsViewObject.ResponsabilitySource.Name = source.NOM_CARGO;
            contactsViewObject.ContactName = source.NOM_CONTACTO;
            contactsViewObject.ContactsKeyId = source.COMISIO;
            var currentDelega = source.DELEGA_CC;
            if (currentDelega.HasValue)
            {
                contactsViewObject.CurrentDelegation = currentDelega.Value.ToString();
            }
            contactsViewObject.CurrentUser = source.USUARIO;
            contactsViewObject.Email = source.EMAIL;
            contactsViewObject.Fax = source.FAX;
            contactsViewObject.Telefono = source.TELEFONO;
            contactsViewObject.Nif = source.NIF;
            contactsViewObject.Movil = source.MOVIL;
            contactsViewObject.LastModification = source.ULTMODI;
            contactsViewObject.User = source.USUARIO;
            return contactsViewObject;
        }
    }
}