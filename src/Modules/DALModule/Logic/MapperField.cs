// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Vehicle.cs" company="Karve Informatica S.L">
//   
// </copyright>
// <summary>
//   Mapper class. This class maps all database objects to view objects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using KarveDataServices.ViewObjects;
using AutoMapper;
using DataAccessLayer.DataObjects;
using DataAccessLayer.DtoWrapper;
using Model;
using System.IO;
using System.IO.Compression;
using KarveDataServices.DataObjects;

namespace DataAccessLayer.Logic
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// This is the converter from the line reservation to the booking items.
    /// </summary>
    public class LineReservation2BookingItems : ITypeConverter<LIRESER, BookingItemsViewObject>
    {
        /// <inheritdoc />
        /// <summary>
        /// Convert the database entity to the view entity for table lireser
        /// </summary>
        /// <param name="src">
        ///  The source entity.
        /// </param>
        /// <param name="destination">
        /// View entity to b mapped.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="T:KarveDataServices.ViewObjects.BookingItemsViewObject" />.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1101:PrefixLocalCallsWithThis", Justification = "Reviewed. Suppression is OK here.")]
        public BookingItemsViewObject Convert(LIRESER src, BookingItemsViewObject destination, ResolutionContext context)
        {
            BookingItemsViewObject viewObject = new BookingItemsViewObject();
            var bookingItem = new BookingItemsViewObject()
                                  {
                                      Number = src.NUMERO,
                                      BookingKey = src.CLAVE_LR,
                                      Bill = System.Convert.ToInt32(src.FACTURAR),
                                      Concept = src.CONCEPTO,
                                      Cost = src.COSTE,
                                      CurrentUser = src.USUARIO,
                                      Days = src.DIAS,
                                      Desccon = src.DESCCON,
                                      Discount = src.DTO,
                                      Iva = src.IVA,
                                      Type = src.TIPO,
                                      Fare = src.TARIFA,
                                      Quantity = src.CANTIDAD,
                                      Group = src.GRUPO,
                                      Price = src.PRECIO,
                                      Subtotal = src.SUBTOTAL,
                                      Unity = UnityConvert(src.UNIDAD)
                                  };
            if (src.INCLUIDO.HasValue)
            {
                if (src.INCLUIDO == -1)
                {
                    bookingItem.Included = true;
                }
                else
                {
                    bookingItem.Included = false;
                }
            }
            bookingItem.LastModification = src.ULTMODI;
            return bookingItem;
        }

        /// <summary>
        /// Convert lires unity to the real value.
        /// </summary>
        /// <param name="selectedIndex">
        /// String value to convert
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// Integer to be converted.
        /// </returns>
        public int UnityConvert(string selectedIndex)
        {
            var selectionIndex = 0;
            selectedIndex = selectedIndex.ToUpper();
            switch (selectedIndex)
            {
                case "DIA":
                    {
                        selectionIndex = 1;
                        break;
                    }
                case "SEMANA":
                    {
                        selectionIndex = 2;
                        break;
                    }
                case "MES":
                    {
                        selectionIndex = 3;
                        break;
                    }
                case "QUINCENA":
                    {
                        selectionIndex = 4;
                        break;
                    }
                case "UNICO":
                    {
                        selectionIndex = 5;
                        break;
                    }
                case "FIN DE SEMANA":
                    {
                        selectionIndex = 6;
                        break;
                    }
            }

            return selectionIndex;
        }
    }

    /// <summary>
    /// Convert the country view object to the database table Country (PAIS).
    /// </summary>
    public class Country2PocoConverter : ITypeConverter<CountryViewObject, Country>
    {
        public Country Convert(CountryViewObject source, Country destination, ResolutionContext context)
        {
            var dto = new Country();
            dto.SIGLAS = source.Code;
            dto.PAIS = source.CountryName;
            dto.IDIOMA_PAIS = source.Language;
            if (source.IsIntraco)
            {
                dto.INTRACO = 1;
            }
            return dto;
        }
    }

    public class PercargosConverter : ITypeConverter<PERCARGOS, PersonalPositionViewObject>
    {
        /// <summary>
        ///  Convert a PERCARGO to a Data Transfer Object.
        /// </summary>
        /// <param name="source">Entity source</param>
        /// <param name="destination">Destination data transfer object</param>
        /// <param name="context">Resolution context</param>
        /// <returns></returns>
        public PersonalPositionViewObject Convert(PERCARGOS source, PersonalPositionViewObject destination, ResolutionContext context)
        {
            PersonalPositionViewObject position = new PersonalPositionViewObject();
            position.Code = source.CODIGO.ToString();
            position.Name = source.NOMBRE;
            position.LastModification = source.ULTMODI;
            position.User = source.USUARIO;
            return position;
        }
    }

    public class PersonalPositionDtoConverter : ITypeConverter<PersonalPositionViewObject, PERCARGOS>
    {
        public PERCARGOS Convert(PersonalPositionViewObject source, PERCARGOS destination, ResolutionContext context)
        {
            var percargos = new PERCARGOS();
            percargos.CODIGO = int.Parse(source.Code);
            percargos.NOMBRE = source.Name;
            percargos.ULTMODI = source.LastModification;
            percargos.USUARIO = source.User;
            return percargos;
        }
    }


    /// <summary>
    /// POCO to Dto converter for the commission contact domain object
    /// </summary>
    public class ContactsConverter : ITypeConverter<ContactsComiPoco, ContactsViewObject>
    {
        public ContactsViewObject Convert(ContactsComiPoco source, ContactsViewObject destination, ResolutionContext context)
        {
            ContactsViewObject contactsDto = new ContactsViewObject();
            contactsDto.Code = source.CONTACTO.ToString();
            contactsDto.ContactsKeyId = source.COMISIO;
            contactsDto.ContactId = source.CONTACTO.ToString();
            contactsDto.ContactName = source.NOM_CONTACTO;
            contactsDto.Nif = source.NIF;
            contactsDto.Responsability = source.percargos?.NOMBRE;
            contactsDto.Telefono = source.TELEFONO;
            contactsDto.Movil = source.MOVIL;
            contactsDto.Fax = source.FAX;
            contactsDto.Email = source.EMAIL;
            contactsDto.User = source.USUARIO;
            contactsDto.LastModification = source.ULTMODI;
            contactsDto.CurrentDelegation = source.comiDelega?.cldDelegacion;
            contactsDto.ResponsabilitySource = new PersonalPositionViewObject();
            contactsDto.ResponsabilitySource.Code = source.CARGO?.ToString();
            contactsDto.ResponsabilitySource.Name = source.NOM_CARGO;
            return contactsDto;

        }
    }

    public class ExtendedProContactsConvert : ITypeConverter<ProContact, ProContactos>
    {
        public ProContactos Convert(ProContact source, ProContactos destination, ResolutionContext context)
        {
            ProContactos proContactos = new ProContactos();
            proContactos.ccoCargo = source.Cargo;
            proContactos.ccoDepto = source.Dipartimento;
            proContactos.ccoFax = source.Fax;
            proContactos.ULTMODI = source.UltimaModifica;
            proContactos.ccoIdCliente = source.ccoIdCliente;
            proContactos.ccoMail = source.Email;
            proContactos.ccoMovil = source.Movil;
            proContactos.ccoFax = source.Fax;
            proContactos.ccoTelefono = source.Telefono;
            return proContactos;
        }
    }
    public class ContactToProContactosConverter : ITypeConverter<ContactsViewObject, ProContactos>
    {
        public ProContactos Convert(ContactsViewObject source, ProContactos destination, ResolutionContext context)
        {
            ProContactos contacts = new ProContactos();
            contacts.ccoFax = source.Fax;
            if (source.ContactName == null)
            {
                source.ContactName = String.Empty;
            }
            contacts.ccoContacto = source.ContactName;
            contacts.ccoIdContacto = source.ContactId;
            contacts.ccoIdDelega = source.CurrentDelegation;
            contacts.ccoTelefono = source.Telefono;
            contacts.ccoMail = source.Email;
            contacts.ccoMovil = source.Movil;
            contacts.ccoIdCliente = source.ContactsKeyId;
            if (source.ResponsabilitySource != null)
            {
                var code = int.Parse(source.ResponsabilitySource.Code);
                contacts.ccoIdCargo = code;
                contacts.ccoCargo = source.ResponsabilitySource.Name;
            }
            return contacts;

        }
    }
    public class ProContactsConverter : ITypeConverter<ProContactos, ContactsViewObject>
    {
        public ContactsViewObject Convert(ProContactos source, ContactsViewObject destination, ResolutionContext context)
        {
            ContactsViewObject contacts = new ContactsViewObject();
            contacts.ContactId = source.ccoIdContacto;
            contacts.ContactName = source.ccoContacto;
            contacts.ContactsKeyId = source.ccoIdCliente;
            contacts.Telefono = source.ccoTelefono;
            contacts.LastModification = source.ULTMODI;
            contacts.User = source.USUARIO;
            contacts.Email = source.ccoMail;
            contacts.CurrentDelegation = source.ccoIdDelega;
            contacts.ResponsabilitySource = new PersonalPositionViewObject();
            if (source.ccoIdCargo.HasValue)
            {
                var ccoIdCargoValue = source.ccoIdCargo.Value;
                contacts.ResponsabilitySource.Code = ccoIdCargoValue.ToString();
                contacts.ResponsabilitySource.Name = source.ccoCargo;
            }
            return contacts;
        }
    }
    /// <summary>
    /// POCO to Dto converter for the office zones domain object
    /// </summary>
    public class ZonaOfiConverter : ITypeConverter<ZONAOFI, ZonaOfiViewObject>
    {
        public ZonaOfiViewObject Convert(ZONAOFI source, ZonaOfiViewObject destination, ResolutionContext context)
        {
            ZonaOfiViewObject ofiDto = new ZonaOfiViewObject();
            ofiDto.Codigo = source.COD_ZONAOFI;
            ofiDto.Nombre = source.NOM_ZONA;
            ofiDto.Plaza = source.PLAZA;
            ofiDto.Code = source.COD_ZONAOFI;

            return ofiDto;
        }
    }
    /// <summary>
    /// POCO to Dto converter for the products domain object
    /// </summary>
    public class ProductsConverter : ITypeConverter<PRODUCTS, ProductsViewObject>
    {

        public ProductsViewObject Convert(PRODUCTS source, ProductsViewObject destination, ResolutionContext context)
        {
            ProductsViewObject destinationDto = new ProductsViewObject();
            destinationDto.Codigo = source.CODIGO_PRD;
            destinationDto.Nombre = source.NOMBRE_PRD;
            destinationDto.Observacion = source.OBS_PRD;
            destinationDto.Code = source.CODIGO_PRD.ToString();

            return destinationDto;
        }
    }
    /// <summary>
    /// POCO to Dto converter for the market domain object
    /// </summary>
    public class MercadoConverter : ITypeConverter<MERCADO, MarketViewObject>
    {

        public MarketViewObject Convert(MERCADO source, MarketViewObject destination, ResolutionContext context)
        {
            MarketViewObject destinationDto = new MarketViewObject();
            destinationDto.Code = source.CODIGO;
            destinationDto.Name = source.NOMBRE;
            destinationDto.Code = source.CODIGO;

            return destinationDto;
        }
    }
    /// <summary>
    /// POCO to Dto converter for the market domain object
    /// </summary>
    public class Poco2MercadoConverter : ITypeConverter<MarketViewObject, MERCADO>
    {

        public MERCADO Convert(MarketViewObject source, MERCADO destination, ResolutionContext context)
        {
            MERCADO destinationDto = new MERCADO();
            destinationDto.CODIGO = source.Code;
            destinationDto.NOMBRE = source.Name;
            return destinationDto;
        }
    }

    /// <summary>
    /// Merge two entities.
    /// </summary>
    public class MergePOCO<Entity> where Entity : class, new()
    {
        public static string EntityName = "POCOToMerge";

        public Entity Convert(Entity source, IDictionary<string, Entity> context)
        {
            Entity entity = new Entity();
            PropertyInfo[] currentProperties = source.GetType().GetProperties();
            foreach (PropertyInfo property in currentProperties)
            {
                var currentSource = source.GetType();
                var propertyInfo = currentSource.GetProperty(property.Name);
                if (propertyInfo != null)
                {
                    var tmpValue = propertyInfo.GetValue(source);
                    if (tmpValue != null)
                    {
                        var currentType = entity.GetType();

                        if (currentType != null)
                        {
                            var propValue = currentType.GetProperty(property.Name);
                            if (propValue != null)
                            {
                                propValue.SetValue(entity, tmpValue);
                            }
                        }

                    }

                }

            }
            // add the second pococ
            var secondPoco = context[EntityName];
            if (secondPoco == null)
            {
                return entity;
            }
            PropertyInfo[] currentProperties2 = secondPoco.GetType().GetProperties();

            foreach (PropertyInfo property in currentProperties2)
            {
                var currentSource = secondPoco.GetType();
                var propertyInfo = currentSource.GetProperty(property.Name);

                if (propertyInfo != null)
                {
                    var tmpValue = propertyInfo.GetValue(secondPoco);
                    if (tmpValue != null)
                    {
                        entity.GetType().GetProperty(property.Name).SetValue(entity, tmpValue);
                    }

                }

            }
            return entity;
        }
    }

    /// <summary>
    ///  Converter for the the new vehiculo2.
    /// </summary>
    public class GenericBackConverter<Dto, Entity> : ITypeConverter<Dto, Entity> where Entity : class, new()
    {
        public Entity Convert(Dto source, Entity destination, ResolutionContext context)
        {
            Entity e = new Entity();
            PropertyInfo[] currentProperties = e.GetType().GetProperties();
            foreach (PropertyInfo property in currentProperties)
            {
                var currentSource = source.GetType();
                if (currentSource != null)
                {
                    if (property != null)
                    {
                        var propertyInfo = currentSource.GetProperty(property.Name);
                        if (propertyInfo != null)
                        {

                            var tmpValue = propertyInfo.GetValue(source);
                            e.GetType().GetProperty(property.Name).SetValue(e, tmpValue);
                        }
                    }
                }

            }
            return e;
        }
    }
    /// <summary>
    ///  CompanyToDto converter
    /// </summary>
    public class CompanyConverterBack : ITypeConverter<CompanyViewObject, SUBLICEN>
    {
        public SUBLICEN Convert(CompanyViewObject source, SUBLICEN destination, ResolutionContext context)
        {
            var entityConverter = new GenericBackConverter<CompanyViewObject, SUBLICEN>();
            var entity = entityConverter.Convert(source, destination, context);
            // assure that is al ok.
            entity.CODIGO = source.Code;

            return entity;
        }
    }

    /// <summary>
    ///  CompanyToDto converter
    /// </summary>
    public class CompanyConverter : ITypeConverter<SUBLICEN, CompanyViewObject>
    {
        public CompanyViewObject Convert(SUBLICEN source, CompanyViewObject destination, ResolutionContext context)
        {
            var entityConverter = new GenericConverter<SUBLICEN, CompanyViewObject>();
            var model = entityConverter.Convert(source, destination, context);
            if (model != null)
            {
                model.Code = source.CODIGO;
                model.Name = source.NOMBRE;
                model.CommercialName = source.NOMCOMER;
                model.Poblacion = source.POBLACION;
                model.Nif = source.NIF;
                model.Code = source.CODIGO;

            }
            return model;
        }
    }
    /// <summary>
    /// Convert the generic conversion.
    /// </summary>
    public class GenericConverter<Dto, Entity> : ITypeConverter<Dto, Entity> where Entity : class, new()
    {

        public Entity Convert(Dto source, Entity destination, ResolutionContext context)
        {
            Entity e = new Entity();

            if (source != null)
            {
                Type dtoSourceType = source.GetType();
                PropertyInfo[] currentProperties = e.GetType().GetProperties();
                for (int i = 0; i < currentProperties.Length; ++i)
                {
                    // destination property
                    var prop = currentProperties[i];
                    // source Value
                    var sourceValueProperty = dtoSourceType.GetProperty(prop.Name);
                    if (sourceValueProperty != null)
                    {
                        var destinationProperty = e.GetType().GetProperty(prop.Name);
                        var tmpValue = sourceValueProperty.GetValue(source);
                        if (tmpValue != null)
                        {
                            destinationProperty?.SetValue(e, tmpValue);
                        }
                    }
                }
            }
            return e;
        }
    }
    /// POCO to Dto converter for the client domain object to merge both.
    public class BookingToReserva1 : ITypeConverter<RESERVAS1, BookingViewObject>
    {
        public BookingViewObject Convert(RESERVAS1 source, BookingViewObject destination, ResolutionContext context)
        {
            GenericConverter<RESERVAS1, BookingViewObject> gc = new GenericConverter<RESERVAS1, BookingViewObject>();
            var v = gc.Convert(source, destination, context);
            return v;
        }
    }
    /// POCO to Dto converter for the client domain object to merge both.
    public class BookingToReserva2 : ITypeConverter<RESERVAS2, BookingViewObject>
    {
        public BookingViewObject Convert(RESERVAS2 source, BookingViewObject destination, ResolutionContext context)
        {
            GenericConverter<RESERVAS2, BookingViewObject> gc = new GenericConverter<RESERVAS2, BookingViewObject>();
            var v = gc.Convert(source, destination, context);
            return v;
        }
    }



    /// POCO to Dto converter for the client domain object to merge both.
    public class ClientToClientes1 : ITypeConverter<CLIENTES1, ClientViewObject>
    {
        public ClientViewObject Convert(CLIENTES1 source, ClientViewObject destination, ResolutionContext context)
        {
            GenericConverter<CLIENTES1, ClientViewObject> gc = new GenericConverter<CLIENTES1, ClientViewObject>();
            var v = gc.Convert(source, destination, context);
            return v;
        }
    }
    /// POCO to Dto converter for the client domain object to merge both.
    public class ClientToClientes2 : ITypeConverter<CLIENTES2, ClientViewObject>
    {
        public ClientViewObject Convert(CLIENTES2 source, ClientViewObject destination, ResolutionContext context)
        {
            GenericConverter<CLIENTES2, ClientViewObject> gc = new GenericConverter<CLIENTES2, ClientViewObject>();
            var v = gc.Convert(source, destination, context);
            return v;
        }
    }

    /// <summary>
    /// POCO to Dto converter for the client domain object
    /// </summary>
    public class ClientesConverter : ITypeConverter<CLIENTES1, ClientViewObject>
    {
        public ClientViewObject Convert(CLIENTES1 source, ClientViewObject destination, ResolutionContext context)
        {
            ClientViewObject clientDto = new ClientViewObject();
            clientDto.Numero = source.NUMERO_CLI;
            clientDto.Nombre = source.NOMBRE;
            clientDto.Movil = source.MOVIL;
            clientDto.Numero = source.NUMERO_CLI;
            if (!string.IsNullOrEmpty(source.TARCADU))
            {
                var value = source.TARCADU.Split('/');
                clientDto.CreditCardExpiryMonth = value[0].Trim();
                clientDto.CreditCardExpiryYear = value[1].Trim();
            }

            var sourceEmailMainMant = source.EMAIL_MANT;
            clientDto.EMAIL_MANT = sourceEmailMainMant.Replace("#", "@");
            return clientDto;
        }
    }
    /// <summary>
    /// POCO to Dto converter for the canal domain object
    /// </summary>
    public class CanalConverter : ITypeConverter<CANAL, ChannelViewObject>
    {
        public ChannelViewObject Convert(CANAL source, ChannelViewObject destination, ResolutionContext context)
        {
            ChannelViewObject dto = new ChannelViewObject();
            dto.Code = source.CODIGO;
            dto.Name = source.NOMBRE;


            return dto;
        }
    }
    /// <summary>
    /// POCO to Dto converter for the business shop domain object
    /// </summary>
    public class BusinessConverter : ITypeConverter<NEGOCIO, BusinessViewObject>
    {
        public BusinessViewObject Convert(NEGOCIO source, BusinessViewObject destination, ResolutionContext context)
        {
            BusinessViewObject businessDto = new BusinessViewObject();
            businessDto.Code = source.CODIGO;
            businessDto.Name = source.NOMBRE;
            return businessDto;
        }
    }
    /// <summary>
    /// POCO to Dto converter for the reseller domain object
    /// </summary>
    public class VendedorConverter : ITypeConverter<VENDEDOR, ResellerViewObject>
    {
        public ResellerViewObject Convert(VENDEDOR source, ResellerViewObject destination, ResolutionContext context)
        {
            ResellerViewObject resellerDto = new ResellerViewObject();
            resellerDto.Code = source.NUM_VENDE;
            resellerDto.Name = source.NOMBRE;
            resellerDto.Nif = source.NIF;
            resellerDto.City = new CityViewObject();
            resellerDto.City.Poblacion = source.POBLACION;
            resellerDto.City.Code = source.CP;
            resellerDto.Country = new CountryViewObject();
            resellerDto.Country.Code = source.NACIOPER;
            resellerDto.Direction = source.DIRECCION;
            resellerDto.Province = new ProvinceViewObject();
            resellerDto.Province.Code = source.PROVINCIA;
            resellerDto.Fax = source.FAX;
            resellerDto.Email = source.EMAIL;
            resellerDto.CellPhone = source.MOVIL;
            resellerDto.StartDate = source.FECHALTA;
            resellerDto.LeaveDate = source.FECHABAJA;
            resellerDto.Web = source.WEB;
            resellerDto.Notes = source.NOTAS;
            resellerDto.Phone = source.TELEFONO;
            resellerDto.Salary = source.SUELDO;
            return resellerDto;
        }
    }


    /// <summary>
    /// ContactsCOMI and mapper field.
    /// </summary>
    public class ContactsComi : ITypeConverter<ContactsViewObject, CONTACTOS_COMI>
    {
        public CONTACTOS_COMI Convert(ContactsViewObject source, CONTACTOS_COMI destination, ResolutionContext context)
        {
            string idComi = source.ContactsKeyId;
            CONTACTOS_COMI comiContact = new CONTACTOS_COMI();
            IEnumerable<ContactsComiPoco> comiPoco = null;
            if (context.Items.ContainsKey("RefId"))
            {
                idComi = context.Items["RefId"] as string;
            }
            if (context.Items.ContainsKey("POCO"))
            {
                comiPoco = context.Items["POCO"] as IEnumerable<ContactsComiPoco>;
            }

            int contactIdentifier = Int32.Parse(source.ContactId);
            comiContact.COMISIO = idComi;
            comiContact.NOM_CONTACTO = source.ContactName;
            comiContact.EMAIL = source.Email;
            comiContact.NOM_CONTACTO = source.ContactName;
            comiContact.CONTACTO = Int32.Parse(source.ContactId);
            comiContact.FAX = source.Fax;
            comiContact.USUARIO = source.User;
            comiContact.ULTMODI = DateTime.Now.ToString("yyyyMMddHHmmss");
            comiContact.NIF = source.Nif;
            comiContact.MOVIL = source.Movil;
            comiContact.FAX = source.Fax;
            comiContact.EMAIL = source.Email;
            comiContact.TELEFONO = source.Telefono;
            if (source.CurrentDelegation != null)
            {
                comiContact.DELEGA_CC = int.Parse(source.CurrentDelegation);
            }
            if (source.ResponsabilitySource != null)
            {
                if (!string.IsNullOrEmpty(source.ResponsabilitySource.Code))
                {
                    comiContact.CARGO = byte.Parse(source.ResponsabilitySource.Code);
                }
                comiContact.NOM_CARGO = source.ResponsabilitySource.Name;
                if (comiPoco != null)
                {
                    ContactsComiPoco contacts = comiPoco.FirstOrDefault(c => c.CONTACTO == contactIdentifier);
                    comiContact.DELEGA_CC = contacts?.DELEGA_CC;
                    comiContact.CARGO = contacts?.CARGO;
                }
            }
            return comiContact;
        }
    }
    /// <summary>
    /// POCO to Dto converter for the origen object
    /// </summary>
    public class OrigenConverter : ITypeConverter<ORIGEN, OrigenViewObject>
    {
        public OrigenViewObject Convert(ORIGEN source, OrigenViewObject destination, ResolutionContext context)
        {
            OrigenViewObject origenDto = new OrigenViewObject();
            origenDto.Code = source.NUM_ORIGEN.ToString();
            origenDto.Name = source.NOMBRE;
            return origenDto;
        }
    }
    /// <summary>
    /// POCO to Dto converter for the language domain object
    /// </summary>
    public class LanguageConverter : ITypeConverter<IDIOMAS, LanguageViewObject>
    {
        public LanguageViewObject Convert(IDIOMAS source, LanguageViewObject destination, ResolutionContext context)
        {
            LanguageViewObject languageDto = new LanguageViewObject();
            languageDto.Codigo = source.CODIGO.ToString();
            languageDto.Nombre = source.NOMBRE;

            return languageDto;
        }
    }
    /// <summary>
    /// POCO to Dto converter for the key ppto object
    /// </summary>
    public class ClavePtoConverter : ITypeConverter<CLAVEPTO, ClavePtoViewObject>
    {
        public ClavePtoViewObject Convert(CLAVEPTO source, ClavePtoViewObject destination, ResolutionContext context)
        {
            ClavePtoViewObject clavePto = new ClavePtoViewObject();
            clavePto.Numero = source.COD_CLAVE;
            clavePto.Nombre = source.NOMBRE;
            return clavePto;
        }
    }
    /// <summary>
    /// POCO to Dto converter for the commission type object
    /// </summary>
    public class TipoCommisionConverter : ITypeConverter<TIPOCOMI, CommissionTypeViewObject>
    {
        public CommissionTypeViewObject Convert(TIPOCOMI source, CommissionTypeViewObject destination, ResolutionContext context)
        {
            CommissionTypeViewObject commisiDto = new CommissionTypeViewObject();
            commisiDto.Codigo = source.NUM_TICOMI;
            commisiDto.Nombre = source.NOMBRE;
            return commisiDto;
        }
    }

    /// <summary>
    /// POCO to Dto converter for the commission type object
    /// </summary>
    public class TipoCommisionBackConverter : ITypeConverter<CommissionTypeViewObject, TIPOCOMI>
    {
        /// <summary>
        /// Conversion from source to destination
        /// </summary>
        /// <param name="source">Commission agent source.</param>
        /// <param name="destination">Commission agent destination.</param>
        /// <param name="context">Resolution context.</param>
        /// <returns></returns>
        public TIPOCOMI Convert(CommissionTypeViewObject source, TIPOCOMI destination, ResolutionContext context)
        {
            TIPOCOMI commisioDto = new TIPOCOMI();
            commisioDto.NUM_TICOMI = source.Codigo;
            commisioDto.NOMBRE = source.Nombre;
            return commisioDto;
        }
    }
    /// <summary>
    ///  Dto to poco converter
    /// </summary>
    public class BranchesToComiDelega : ITypeConverter<BranchesViewObject, COMI_DELEGA>
    {
        public COMI_DELEGA Convert(BranchesViewObject source, COMI_DELEGA destination, ResolutionContext context)
        {
            string idComi = "";
            if (context.Items.ContainsKey("RefId"))
            {
                idComi = context.Items["RefId"] as string;
            }

            COMI_DELEGA dest = new COMI_DELEGA();
            dest.cldDelegacion = source.Branch;
            dest.cldDireccion1 = source.Address;
            dest.cldDireccion2 = source.Address2;
            dest.cldIdProvincia = source.ProvinceId;
            dest.cldCP = source.Zip;
            dest.cldEMail = source.Email;
            if (string.IsNullOrEmpty(idComi))
            {
                dest.cldIdCOMI = source.BranchKeyId;
            }
            else
            {
                dest.cldIdCOMI = idComi;
            }
            dest.cldPoblacion = source.City;
            dest.cldTelefono1 = source.Phone;
            dest.cldTelefono2 = source.Phone2;
            dest.cldFax = source.Fax;
            dest.cldPoblacion = source.City;
            dest.cldIdDelega = int.Parse(source.BranchId);
            return dest;
        }
    }
    /// <summary>
    /// POCO to Dto converter for the visits object
    /// </summary>
    public class VisitaCommissionConverter : ITypeConverter<VisitasComiPoco, VisitsViewObject>
    {
        public VisitsViewObject Convert(VisitasComiPoco source, VisitsViewObject destination, ResolutionContext context)
        {
            VisitsViewObject visitsDto = new VisitsViewObject();
            visitsDto.ClientId = source.VisitClientId;
            visitsDto.ContactId = source.ContactId;
            visitsDto.ContactName = source.ContactName;
            visitsDto.ContactsSource = new ContactsViewObject();
            visitsDto.ContactsSource.ContactId = source.ContactId;
            visitsDto.ContactsSource.ContactName = source.ContactName;
            visitsDto.Date = source.VisitDate;
            visitsDto.SellerId = source.ResellerId;
            visitsDto.VisitId = source.VisitId;
            visitsDto.Text = source.VisitText;
            visitsDto.Email = source.Email;
            visitsDto.IsOrder = (source.VisitOrder == 0);

            visitsDto.VisitType = new VisitTypeViewObject();
            visitsDto.VisitType.Code = source.VisitTypeId;
            visitsDto.VisitType.Name = source.VisitTypeName;
            visitsDto.VisitType.LastModification = source.VisitTypeLastModification;
            visitsDto.VisitType.User = source.VisitTypeUser;
            visitsDto.SellerSource = new ResellerViewObject();
            visitsDto.SellerId = source.ResellerId;
            visitsDto.SellerSource.Code = source.ResellerId;
            visitsDto.SellerSource.Name = source.ResellerName;
            visitsDto.SellerSource.CellPhone = source.ResellerCellPhone;
            visitsDto.User = source.User;
            visitsDto.LastModification = source.LastModification;
            return visitsDto;
        }
    }


    /// <summary>
    ///  ContactosComiConverter
    /// </summary>
    public class ContactosComiConverter : ITypeConverter<ContactsComiPoco, CONTACTOS_COMI>
    {
        public CONTACTOS_COMI Convert(ContactsComiPoco source, CONTACTOS_COMI destination, ResolutionContext context)
        {
            CONTACTOS_COMI comi = new CONTACTOS_COMI();
            comi.CARGO = source.CARGO;
            comi.COMISIO = source.COMISIO;
            comi.CONTACTO = source.CONTACTO;
            comi.DELEGA_CC = source.DELEGA_CC;
            comi.EMAIL = source.EMAIL;
            comi.ESVENDE = source.ESVENDE;
            comi.FAX = source.FAX;
            comi.MOVIL = source.MOVIL;
            comi.NIF = source.NIF;
            comi.NOM_CARGO = source.NOM_CARGO;
            comi.NOM_CONTACTO = source.NOM_CONTACTO;
            comi.OBSERVA = source.OBSERVA;
            comi.TELEFONO = source.TELEFONO;
            comi.ULTMODI = source.ULTMODI;
            comi.USUARIO = source.USUARIO;
            return comi;
        }
    }

    public class ActivityConverter : ITypeConverter<ACTIVI, ActividadViewObject>
    {
        public ActividadViewObject Convert(ACTIVI source, ActividadViewObject destination, ResolutionContext context)
        {
            ActividadViewObject actividad = new ActividadViewObject();
            actividad.Codigo = source.NUM_ACTIVI;
            actividad.Nombre = source.NOMBRE;
            return actividad;

        }
    }
    public class VisitComiToVisit : ITypeConverter<VisitasComiPoco, VISITAS_COMI>
    {
        public VISITAS_COMI Convert(VisitasComiPoco source, VISITAS_COMI destination, ResolutionContext resolutionContext)
        {
            VISITAS_COMI comiVisita = new VISITAS_COMI();
            comiVisita.visIdCliente = source.VisitClientId;
            comiVisita.visIdContacto = source.ContactId;
            comiVisita.visAlta = source.VisitMembershipDate;
            comiVisita.visFecha = source.VisitDate;
            comiVisita.visIdVendedor = source.ResellerId;
            comiVisita.visIdVisita = source.VisitId;
            comiVisita.visTexto = source.VisitText;
            comiVisita.visIdVisitaTipo = source.VisitTypeId;
            comiVisita.EMAIL = source.Email;
            comiVisita.PEDIDO = source.VisitOrder;
            comiVisita.ULTMODI = source.LastModification;
            comiVisita.USUARIO = source.User;
            return comiVisita;
        }
    }
    public class BrandVehicle2Poco : ITypeConverter<BrandVehicleViewObject, MARCAS>
    {
        public MARCAS Convert(BrandVehicleViewObject source, MARCAS destination, ResolutionContext context)
        {
            MARCAS marcas = new MARCAS();
            marcas.CODIGO = source.Code;
            marcas.NOMBRE = source.Name;
            marcas.CONDICIONES = source.Terms;
            marcas.FBAJA = source.LeaveDate;
            marcas.FECHA = source.CurrentDate;
            marcas.OBS = source.Observation;
            marcas.ULTMODI = source.LastModification;
            marcas.USUARIO = source.User;
            marcas.PROVEE = source.Supplier.NUM_PROVEE;
            return marcas;
        }
    }
    public class Poco2BrandVehicle : ITypeConverter<MARCAS, BrandVehicleViewObject>
    {
        public BrandVehicleViewObject Convert(MARCAS source, BrandVehicleViewObject destination, ResolutionContext context)
        {
            BrandVehicleViewObject brandVehicleDto = new BrandVehicleViewObject();
            brandVehicleDto.Code = source.CODIGO;
            brandVehicleDto.CurrentDate = source.FECHA;
            brandVehicleDto.Name = source.NOMBRE;
            brandVehicleDto.Observation = source.OBS;
            brandVehicleDto.LastModification = source.ULTMODI;
            brandVehicleDto.User = source.USUARIO;
            return brandVehicleDto;
        }
    }
    /// <summary>
    ///  Singleton class for the conversion from transfer object to dto.
    /// </summary>
    public static class MapperField
    {
        private static IMapper _instance = null;

        /// <summary>
        ///  Get the map if instantiated otherwise build one.
        /// </summary>
        /// <returns>Map to be built.</returns>
        public static IMapper GetMapper()
        {
            return _instance ?? (_instance = BuildMapping());
        }
        private static char IsBoolChar(bool value)
        {
            if (value)
            {
                return '1';
            }
            return '0';
        }
        private static int IsBoolInt(bool value)
        {
            if (value)
            {
                return 1;
            }
            return 0;
        }


        public static byte[] Compress(byte[] raw)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                using (GZipStream gzip = new GZipStream(memory,
                    CompressionMode.Compress, true))
                {
                    gzip.Write(raw, 0, raw.Length);
                }
                return memory.ToArray();
            }
        }
        public static byte[] Uncompress(byte[] raw)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                using (GZipStream gzip = new GZipStream(memory,
                    CompressionMode.Decompress, true))
                {

                    gzip.Write(raw, 0, raw.Length);
                }
                return memory.ToArray();
            }
        }
        private static string CheckLastMod(string lastModification)
        {
            if (string.IsNullOrEmpty(lastModification))
            {
              return  DateTime.Now.ToString("yyyyMMddHHmmss");
            }
            return lastModification;
        }
        private static IMapper BuildMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<PROPIE, OwnerViewObject>().ConvertUsing(new PropieToOwnerDtoConverter());
                cfg.CreateMap<TIPOCOMI, CommissionTypeViewObject>().ConvertUsing(new TipoCommisionConverter());
                cfg.CreateMap<CommissionTypeViewObject, TIPOCOMI>().ConvertUsing(new TipoCommisionBackConverter());
                cfg.CreateMap<PROVINCIA, ProvinceViewObject>().ConvertUsing(new ProvinceConverter());
                cfg.CreateMap<ProvinceViewObject, PROVINCIA>().ConvertUsing(new ProvinceConverterToPOCO());
                cfg.CreateMap<Country, CountryViewObject>().ConvertUsing(new CountryConverter());
                cfg.CreateMap<CountryViewObject, Country>().ConvertUsing(new Country2PocoConverter());
                cfg.CreateMap<OFICINAS, OfficeViewObject>().ConvertUsing(new OfficeConverter());
                cfg.CreateMap<ZONAOFI, ZonaOfiViewObject>().ConvertUsing(new ZonaOfiConverter());
                cfg.CreateMap<OfficeViewObject, OFICINAS>().ConvertUsing(new OfficeConverterBack());
                cfg.CreateMap<HolidayViewObject, FESTIVOS_OFICINA>().ConvertUsing(new HolidayConverterBack());
                cfg.CreateMap<FESTIVOS_OFICINA, HolidayViewObject>().ConvertUsing(new HolidayConverter());
                cfg.CreateMap<SupplierPoco, SupplierViewObject>().ConvertUsing(new SupplierPocoConverter());

                cfg.CreateMap<COTIZA_RES, BookingItemsViewObject>().ConvertUsing(
                    src =>
                        {
                            var question = new BookingItemsViewObject();
                            question.Group = src.GRUPO;
                            question.Fare = src.TARIFA;
                            question.Concept = src.codConcep;
                            question.Desccon = src.nomConcep;
                            question.Bill = src.Ind_Facturar;
                            question.Included = (src.Incluido == -1);
                            question.Subtotal = src.Importe;
                            question.Price = src.Precio;
                            question.Quantity = src.Cant;
                            question.Discount = src.Dto;
                            question.Extra = src.Extras;
                            question.Min = src.Minimo;
                            question.Max = src.Maximo;
                            return question;

                        });

                cfg.CreateMap<BookingRefusedViewObject, MOTANU>().ConvertUsing(src=>
                {
                    var bookingRefused = new MOTANU();
                    bookingRefused.CODIGO = src.Code;
                    bookingRefused.NOMBRE = src.Name;
                    bookingRefused.ULTMODI = src.LastModification;
                    bookingRefused.USUARIO = src.CurrentUser;
                    return bookingRefused;
                });
                cfg.CreateMap<MOTANU, BookingRefusedViewObject>().ConvertUsing(src=>
                {
                    var bookingRefused = new BookingRefusedViewObject();
                    bookingRefused.Code = src.CODIGO;
                    bookingRefused.Name = src.NOMBRE;
                    bookingRefused.LastModification = src.ULTMODI;
                    bookingRefused.CurrentUser = src.USUARIO;
                    return bookingRefused;
                });
                cfg.CreateMap<COINRE, IncidentTypeViewObject>().ConvertUsing(src =>
                {
                    var incidentType = new IncidentTypeViewObject();
                    incidentType.Code = src.CODIGO;
                    incidentType.Name = src.NOMBRE;
                    incidentType.LastModification = src.ULTMODI;
                    incidentType.User = src.USUARIO;
                    return incidentType;
                });
                cfg.CreateMap<IncidentTypeViewObject, COINRE>().ConvertUsing(src =>
                {
                    var incidentType = new COINRE();
                    incidentType.CODIGO = src.Code;
                    incidentType.NOMBRE = src.Name;
                    incidentType.ULTMODI = src.LastModification;
                    incidentType.USUARIO = src.User;
                    return incidentType;
                });
                cfg.CreateMap<CONTRATIPIMPR, PrintingTypeViewObject>().ConstructUsing(src=> 
                {
                    var printingContracto = new PrintingTypeViewObject();
                    printingContracto.Code = src.CODIGO.ToString();
                    printingContracto.Name = src.NOMBRE;
                    printingContracto.LastModification = src.ULTMODI;
                    printingContracto.CurrentUser = src.USUARIO;
                    return printingContracto;
                });
                cfg.CreateMap<PrintingTypeViewObject, CONTRATIPIMPR>().ConstructUsing(src =>
                {
                    var printingContracto = new CONTRATIPIMPR();
                    printingContracto.CODIGO = byte.Parse(src.Code);
                    printingContracto.NOMBRE = src.Name;
                    printingContracto.ULTMODI = CheckLastMod(src.LastModification);
                    printingContracto.USUARIO = src.User;
                    return printingContracto;
                });


                cfg.CreateMap<MEDIO_RES, BookingMediaViewObject>().ConstructUsing(src =>
                {
                    var bookingMediaDto = new BookingMediaViewObject();
                    bookingMediaDto.Code = src.CODIGO;
                    bookingMediaDto.Name = src.NOMBRE;
                    bookingMediaDto.CurrentUser = src.USUARIO;
                    bookingMediaDto.LastModification = CheckLastMod(src.ULTMODI);
                    return bookingMediaDto;
                });
                cfg.CreateMap<RESERCONFIRM, BookingConfirmMessageViewObject>().ConstructUsing(src =>
                {
                    var bookingConfirmDto = new BookingConfirmMessageViewObject();
                    bookingConfirmDto.Code = src.CODIGO;
                    bookingConfirmDto.Language = src.IDIOMA;
                    bookingConfirmDto.LastModification = src.ULTMODI;
                    bookingConfirmDto.Text = src.TEXTO;
                    bookingConfirmDto.Title = src.TITULO;

                    return bookingConfirmDto;
                });
                cfg.CreateMap<BookingMediaViewObject, MEDIO_RES>().ConstructUsing(src=>
                {
                    var bookingMedia = new MEDIO_RES();
                    bookingMedia.CODIGO = src.Code;
                    bookingMedia.NOMBRE = src.Name;
                    bookingMedia.ULTMODI = src.LastModification;
                    bookingMedia.USUARIO = src.CurrentUser;
                    return bookingMedia;
                });
                cfg.CreateMap<ComisioViewObject, COMISIO>();
                cfg.CreateMap<COMISIO, ComisioViewObject>();
                cfg.CreateMap<CONCEP_FACTUR, FareConceptViewObject>();
                cfg.CreateMap<FareConceptViewObject, CONCEP_FACTUR>();
                cfg.CreateMap<BookingTypeViewObject, TIPOS_RESERVAS>().ConvertUsing(src=>{
                    var booking = new TIPOS_RESERVAS();
                    booking.CODIGO = src.Code;
                    booking.NOMBRE = src.Name;
                    return booking;
                });
                cfg.CreateMap<TIPOS_RESERVAS, BookingTypeViewObject>().ConvertUsing(src=>
                {

                    var bookingType = new BookingTypeViewObject();
                    bookingType.Code = src.CODIGO;
                    bookingType.Name = src.NOMBRE;
                    return bookingType;
                });
                cfg.CreateMap<EAGE, AgencyEmployeeViewObject>().ConstructUsing(src =>
                {
                    var genericConverter = new GenericConverter<EAGE, AgencyEmployeeViewObject>();
                    var agencyEmployee = genericConverter.Convert(src, null, null);
                    agencyEmployee.Code = src.NUM_EAGE;
                    agencyEmployee.Name = src.NOMBRE;
                    agencyEmployee.LastModification = src.ULTMODI;
                    agencyEmployee.CurrentUser = src.USUARIO;
                    return agencyEmployee;
                });
                cfg.CreateMap<AgencyEmployeeViewObject,EAGE>().ConstructUsing(src =>
                {
                    var genericConverter = new GenericConverter<AgencyEmployeeViewObject, EAGE>();
                    var agencyEmployee = genericConverter.Convert(src, null, null);
                    agencyEmployee.ULTMODI = src.LastModification;
                    agencyEmployee.USUARIO = src.User;
                    return agencyEmployee;
                });
                cfg.CreateMap<ClientViewObject, ClientSummaryExtended>().ConvertUsing(src =>
                {
                    var ce = new ClientSummaryExtended();
                    ce.Code = src.NUMERO_CLI;
                    ce.Name = src.NOMBRE;
                    ce.LastModification = src.LastModification;
                    ce.CurrentUser = src.CurrentUser;
                    return ce;
                });
                cfg.CreateMap<ClientSummaryExtended, ClientViewObject>().ConvertUsing(src =>
                {
                    var ce = new ClientViewObject();
                    ce.NUMERO_CLI = src.Code;
                    ce.Numero = src.Code;
                    ce.NOMBRE = src.Name;
                    ce.Nombre = src.Name;
                    return ce;
                });
                cfg.CreateMap<PETICION, ReservationRequestViewObject>();
                cfg.CreateMap<ReservationRequestViewObject, PETICION>();
                cfg.CreateMap<CountryRegionViewObject, CCAA>().ConvertUsing(src =>
                {
                    var newca = new CCAA();
                    newca.CODIGO_CCAA = src.Code;
                    newca.NOMBRE_CCAA = src.Name;
                    return newca;
                });
                cfg.CreateMap<CCAA, CountryRegionViewObject>().ConvertUsing(src =>
                {
                    var newca = new CountryRegionViewObject();
                    newca.Code = src.CODIGO_CCAA;
                    newca.Name = src.NOMBRE_CCAA;
                    return newca;
                });
                cfg.CreateMap<CODIGOS_PROMOCIONALES, PromotionCodesViewObject>().ConvertUsing(src=>
                {
                    var promotion = new PromotionCodesViewObject();
                    promotion.Code = src.CODIGO_PROMO;
                    promotion.Name = src.NOMBRE_PROMO;
                    promotion.LastModification = src.ULTMODI_PROMO;
                    promotion.CurrentUser = src.USUARIO_PROMO;
                    promotion.ConceptPromo = src.CONCEPTO_PROMO;
                    promotion.Discount = src.DTO_PROMO;
                    promotion.EndDatePromo = src.FBAJA_PROMO;
                    promotion.StartDatePromo = src.FALTA_PROMO;
                    promotion.NotesPromo = src.OBS_PROMO;
                    promotion.IsRentingPromo = src.ES_ALQUILER_PROMO;
                    promotion.IsAssurancePromo = src.ES_SEGURO_PROMO;
                    return promotion;

                });
                cfg.CreateMap<PromotionCodesViewObject, CODIGOS_PROMOCIONALES>().ConvertUsing(src =>
                {
                    var promotion = new CODIGOS_PROMOCIONALES();
                    promotion.CODIGO_PROMO = src.Code;
                    promotion.NOMBRE_PROMO = src.Name;
                    promotion.ULTMODI_PROMO = src.LastModification;
                    promotion.USUARIO_PROMO = src.CurrentUser;
                    promotion.CONCEPTO_PROMO= src.ConceptPromo;
                    promotion.DTO_PROMO = src.Discount;
                    promotion.FBAJA_PROMO = src.EndDatePromo;
                    promotion.FALTA_PROMO = src.StartDatePromo;
                    promotion.OBS_PROMO = src.NotesPromo;
                    promotion.ES_ALQUILER_PROMO = src.IsRentingPromo;
                    promotion.ES_SEGURO_PROMO = src.IsAssurancePromo;
                    return promotion;
                });

                cfg.CreateMap<RequestReasonViewObject, MOPETI>().ConvertUsing(src =>
                {
                var newmo = new MOPETI();
                newmo.CODIGO = src.Code;
                newmo.NOMBRE = src.Name;
                newmo.ULTMODI = src.LastModification;
                newmo.USUARIO = src.CurrentUser;
                return newmo;
                });
                cfg.CreateMap<MOPETI, RequestReasonViewObject>().ConvertUsing(src =>
                {
                    var newmo = new RequestReasonViewObject();
                    newmo.Code = src.CODIGO;
                    newmo.Name = src.NOMBRE;
                    newmo.LastModification = src.ULTMODI;
                    newmo.CurrentUser = src.USUARIO;
                    return newmo;
                });
                cfg.CreateMap<VisitasComiPoco, VISITAS_COMI>().ConvertUsing(new VisitComiToVisit());
                cfg.CreateMap<PRODUCTS, ProductsViewObject>().ConvertUsing(new ProductsConverter());
                cfg.CreateMap<MERCADO, MarketViewObject>().ConvertUsing(new MercadoConverter());
                cfg.CreateMap<MarketViewObject, MERCADO>().ConvertUsing(new Poco2MercadoConverter());
                cfg.CreateMap<NEGOCIO, BusinessViewObject>().ConvertUsing(new BusinessConverter());
                cfg.CreateMap<VENDEDOR, ResellerViewObject>().ConvertUsing(new VendedorConverter());
                cfg.CreateMap<ORIGEN, OrigenViewObject>().ConvertUsing(new OrigenConverter());
                cfg.CreateMap<CLAVEPTO, ClavePtoViewObject>().ConvertUsing(new ClavePtoConverter());
                cfg.CreateMap<IDIOMAS, LanguageViewObject>().ConvertUsing(new LanguageConverter());
                cfg.CreateMap<ContactsViewObject, ProContactos>().ConvertUsing(new ContactToProContactosConverter());
                cfg.CreateMap<VisitasComiPoco, VisitsViewObject>().ConvertUsing(new VisitaCommissionConverter());
                cfg.CreateMap<VisitsViewObject, VISITAS_COMI>().ConvertUsing(new VisitaCommissionBackConverter());
                cfg.CreateMap<ComiDelegaPoco, BranchesViewObject>().ConvertUsing(new BranchesConverter());
                cfg.CreateMap<BranchesViewObject, COMI_DELEGA>().ConvertUsing(new BranchesToComiDelega());
                cfg.CreateMap<BranchesViewObject, cliDelega>().ConvertUsing(new BranchesToCliDelega());
                cfg.CreateMap<CliDelegaPoco, BranchesViewObject>().ConvertUsing(new ClientBranchesConverter());
                cfg.CreateMap<ContactsComiPoco, ContactsViewObject>().ConvertUsing(new ContactsConverter());
                cfg.CreateMap<ContactsViewObject, CONTACTOS_COMI>().ConvertUsing(new ContactsComi());
                cfg.CreateMap<CONTACTOS_COMI, ContactsViewObject>().ConvertUsing(new ContactsComiToDto());
                cfg.CreateMap<MARCAS, BrandVehicleViewObject>().ConvertUsing(new Poco2BrandVehicle());
                cfg.CreateMap<CLIENTES1, ClientViewObject>().ConvertUsing(new ClientToClientes1());
                cfg.CreateMap<CLIENTES2, ClientViewObject>().ConvertUsing(new ClientToClientes2());
                cfg.CreateMap<ClientViewObject, CLIENTES1>().ConvertUsing(new ClientDtoToClientes1());
                cfg.CreateMap<ClientViewObject, CLIENTES2>().ConvertUsing(new ClientDtoToClientes2());
                cfg.CreateMap<ACTIVI, ActividadViewObject>().ConvertUsing(new ActivityConverter());
                cfg.CreateMap<BrandVehicleViewObject, MARCAS>().ConvertUsing(new BrandVehicle2Poco());
               // cfg.CreateMap<BookingViewObject, RESERVAS1>().ConvertUsing(new )
                cfg.CreateMap<DeliveringPlaceViewObject, ENTREGAS>().ConvertUsing(src=>
                {
                    var genericConverter = new GenericConverter<DeliveringPlaceViewObject, ENTREGAS>();
                    var value = genericConverter.Convert(src, null, null);
                    return value;

                });
                cfg.CreateMap<ENTREGAS, DeliveringPlaceViewObject>().ConvertUsing(src =>
                {
                    var genericConverter = new GenericConverter<ENTREGAS, DeliveringPlaceViewObject>();
                    var value = genericConverter.Convert(src, null, null);
                    return value;
                });
                cfg.CreateMap<ACTIVEHI, VehicleActivitiesViewObject>().ConvertUsing(src =>
                {
                    var model = new VehicleActivitiesViewObject();
                    model.Code = src.NUM_ACTIVEHI;
                    model.Activity = src.NOMBRE;
                    model.Name = src.NOMBRE;
                    model.LastModification = src.ULTMODI;
                    model.User = src.USUARIO;
                    /*
                    model.ActivitySigle = src.SIGLAS_ACT;
                    var c = Convert.ToInt16(src.CALCULO);
                    model.Compute = (c == 0);
                    model.ActityAlquiler = src.ACTIVI_ALQ;
                    model.Assurance = src.SEGURO_ANUAL;
                    */
                    return model;
                });
                /*
                cfg.CreateMap<ACTIVEHI, ActividadDto>().ConvertUsing(src =>
                {
                    var actividad = new ActividadDto
                    {
                        Codigo = src.NUM_ACTIVEHI,
                        Nombre = src.NOMBRE
                    };
                    return actividad;
                });*/
                cfg.CreateMap<FareViewObject, NTARI>().ConvertUsing(src =>
                {
                    var fare = new NTARI();
                    fare.CODIGO = src.Code;
                    fare.NOMBRE = src.Name;
                    fare.COD_PROMO = src.PromotionCode;
                    fare.ULTMODI = src.LastModification;
                    fare.USUARIO = src.CurrentUser;
                    return fare;

                });
                cfg.CreateMap<NTARI, FareViewObject>().ConvertUsing(src =>
                {
                    var fare = new FareViewObject();
                    fare.Code = src.CODIGO;
                    fare.Name = src.NOMBRE;
                    fare.PromotionCode = src.COD_PROMO;
                    fare.LastModification = src.ULTMODI;
                    fare.CurrentUser = src.USUARIO;
                    return fare;
                });

                cfg.CreateMap<InvoiceViewObject, FACTURAS>().ConvertUsing(src =>
            {
                var value = new FACTURAS();
                var genericConverter = new GenericConverter<InvoiceViewObject, FACTURAS>();

                value = genericConverter.Convert(src, null, null);

                return value;
            });
                cfg.CreateMap<FACTURAS, InvoiceViewObject>().ConvertUsing(src =>
                {
                    var genericConverter = new GenericConverter<FACTURAS, InvoiceViewObject>();
                    var value = genericConverter.Convert(src, null, null);

                    return value;
                });

                cfg.CreateMap<DELEGA, DelegaContableViewObject>().ConvertUsing(src =>
                {
                    var generic = new DelegaContableViewObject
                    {
                        Code = src.NUM_DELEGA,
                        Name = src.NOMBRE
                    };
                    return generic;
                });
                cfg.CreateMap<DelegaContableViewObject, DELEGA>().ConvertUsing(src =>
                {
                    var generic = new DELEGA
                    {
                        NUM_DELEGA = src.Code,
                        NOMBRE = src.Name
                    };
                    return generic;
                });
                cfg.CreateMap<BookingPoco, BookingViewObject>();
                cfg.CreateMap<BookingIncidentViewObject, INCIRE>();
                cfg.CreateMap<INCIRE, BookingIncidentViewObject>();
                cfg.CreateMap<CONTRATOS1, ContractViewObject>().ConvertUsing(src =>
                {
                    var generic = new ContractViewObject()
                    {
                        Code = src.NUMERO,
                        Name = src.NOMBRE_CON1,
                        StartingFrom = src.FECHA_CON1,
                        ReleaseDate = src.FSALIDA_CON1,
                        ReturnDate = src.FRETOR_CON1,
                        DeliveringPlace = src.LUENTRE_CON1,
                        Days = src.DIAS_CON1,
                        ClientCode = src.CLIENTE_CON1,
                        DriverCode = src.CONDUCTOR_CON1,
                        VehicleCode = src.VCACT_CON1
                    };
                    return generic;
                });
                cfg.CreateMap<ContractViewObject, CONTRATOS1>().ConvertUsing(src =>
                {
                    var generic = new CONTRATOS1()
                    {
                        NUMERO = src.Code,
                        NOMBRE_CON1 = src.Name,
                        FECHA_CON1 = src.StartingFrom,
                        FSALIDA_CON1 = src.ReleaseDate,
                        FRETOR_CON1 = src.ReturnDate,
                        LUENTRE_CON1 = src.DeliveringPlace,
                        DIAS_CON1 = src.Days,
                        CLIENTE_CON1 = src.ClientCode,
                        CONDUCTOR_CON1 = src.DriverCode,
                        VCACT_CON1 = src.VehicleCode
                    };
                    return generic;
                });
                cfg.CreateMap<BookingItemsViewObject, LIRESER>().ConvertUsing(new BookingItems2LineReservation());
                cfg.CreateMap<LIRESER, BookingItemsViewObject>().ConvertUsing(new LineReservation2BookingItems());
                cfg.CreateMap<LIFAC, InvoiceSummaryViewObject>().ConvertUsing(src =>
                {
                    var opciones = 0;
                    if (src.CONCEPTO_LIF.HasValue)
                    {
                        opciones = src.CONCEPTO_LIF.Value;

                    }
                    var invoiceItem = new InvoiceSummaryViewObject
                    {
                        Opciones = opciones,
                        AgreementCode = src.CONTRATO_LIF,
                        Number = src.NUMERO_LIF,
                        Subtotal = src.SUBTOTAL_LIF,
                        FileNumber = src.EXPEDIENTE_LIF,
                        Discount = src.DTO_LIF,
                        Description = src.DESCRIP_LIF,
                        Iva = src.IVA,
                        VehicleCode = src.VEHICULO_LIF,
                        User = src.USUARIO_LIF,
                        Unity = src.UNIDAD_LIF,
                        Quantity = src.CANTIDAD_LIF,
                        KeyId = src.CLAVE_LF.ToString(),
                        LastModification = src.ULTMODI_LIF

                    };
                    if (src.PRE_LIF.HasValue)
                    {
                        invoiceItem.Price = src.PRE_LIF.Value;
                    }

                    return invoiceItem;
                });
                cfg.CreateMap<InvoiceSummaryViewObject, LIFAC>().ConvertUsing(src =>
                {
                    var opciones = src.Opciones;
                    var invoiceItem = new LIFAC
                    {
                        SUBTOTAL_LIF = src.Subtotal,
                        EXPEDIENTE_LIF = src.FileNumber,
                        DTO_LIF = src.Discount,
                        DESCRIP_LIF = src.Description,
                        IVA = src.Iva,
                        PRE_LIF = src.Price,
                        VEHICULO_LIF = src.VehicleCode,
                        USUARIO_LIF = src.User,
                        UNIDAD_LIF = src.Unity,
                        NUMERO_LIF = src.Number,
                        CANTIDAD_LIF = src.Quantity,
                        CONTRATO_LIF = src.AgreementCode,
                        CONCEPTO_LIF = opciones,
                        ULTMODI_LIF = src.LastModification
                    };
                    if (src.KeyId != null)
                    {
                        var parsed = int.TryParse(src.KeyId, out var clavelf);
                        if ((parsed) && (clavelf != 0))
                        {
                            invoiceItem.CLAVE_LF = clavelf;
                        }

                    }

                    return invoiceItem;
                });
                cfg.CreateMap<LIFAC, InvoiceItem>();
                cfg.CreateMap<InvoiceItem, LIFAC>();
                cfg.CreateMap<CurrenciesViewObject, CURRENCIES>().ConvertUsing(
                    src =>
                    {
                        var currencies = new CURRENCIES
                        {
                            CODIGO_CUR = src.Code,
                            NOMBRE_CUR = src.Name
                        };
                        return currencies;
                    });
                cfg.CreateMap<CURRENCIES, CurrenciesViewObject>().ConvertUsing(
                    src =>
                    {
                        var currencies = new CurrenciesViewObject
                        {
                            Code = src.CODIGO_CUR,
                            Name = src.NOMBRE_CUR
                        };
                        return currencies;
                    });

                cfg.CreateMap<CurrencyViewObject, DIVISAS>().ConvertUsing(
                   src =>
                   {
                       var currencies = new DIVISAS
                       {
                           CODIGO = src.Codigo,
                           NOMBRE = src.Nombre
                       };
                       return currencies;
                   });
                cfg.CreateMap<DIVISAS, CurrencyViewObject>().ConvertUsing(
                    src =>
                    {
                        var currencies = new CurrencyViewObject
                        {
                            Codigo = src.CODIGO,
                            Nombre = src.NOMBRE
                        };
                        return currencies;
                    });

                cfg.CreateMap<BrandVehicleViewObject, MARCAS>().ConvertUsing(src =>
                {
                    var marcas = new MARCAS();
                    marcas.CODIGO = src.Code;
                    marcas.NOMBRE = src.Name;
                    return marcas;
                });
                cfg.CreateMap<MARCAS, BrandVehicleViewObject>().ConvertUsing(src =>
                {
                    var marcas = new BrandVehicleViewObject();
                    marcas.Code = src.CODIGO;
                    marcas.Name = src.NOMBRE;
                    return marcas;
                });
                cfg.CreateMap<PICTURES, PictureDto>();
                cfg.CreateMap<ColorViewObject, COLORFL>().ConvertUsing(src =>
                {
                    var color = new COLORFL();
                    color.CODIGO = src.Code;
                    color.NOMBRE = src.Name;
                    return color;
                }
                );
                cfg.CreateMap<MODELO, ModelVehicleViewObject>().ConvertUsing(src =>
                {
                    var model = new ModelVehicleViewObject();
                    model.Codigo = src.CODIGO;
                    model.Nombre = src.NOMBRE;
                    model.Marca = src.MARCA;
                    model.Categoria = src.CATEGORIA;
                    model.Variante = src.VARIANTE;
                    model.NomeMarca = src.NOMMARCA;
                    return model;
                }
                );
                cfg.CreateMap<ModelVehicleViewObject, MODELO>().ConvertUsing(src =>
                {
                    var model = new MODELO();
                    model.MARCA = src.Marca;
                    model.CODIGO = src.Codigo;
                    model.NOMBRE = src.Nombre;
                    model.CATEGORIA = src.Categoria;
                    model.VARIANTE = src.Variante;
                    model.NOMMARCA = src.NomeMarca;
                    return model;
                }
                );
                
                cfg.CreateMap<ACTIVEHI, VehicleActivitiesViewObject>().ConvertUsing(src =>
                {
                    var color = new VehicleActivitiesViewObject();
                    color.Code = src.NUM_ACTIVEHI;
                    color.Activity = src.NOMBRE;
                    return color;
                }
                );

                /*
                cfg.CreateMap<ActividadDto, ACTIVEHI>().ConvertUsing(src =>
                {
                    var color = new ACTIVEHI();
                    color.NUM_ACTIVEHI = src.Codigo;
                    color.NOMBRE = src.Nombre;
                    return color;
                }
                );
                */

                cfg.CreateMap<ClientPoco, ClientSummaryViewObject>().ConvertUsing(new ClientSummaryConverter());

                cfg.CreateMap<TIPOCOMI, CommissionTypeViewObject>().ConvertUsing(src =>
                {
                    var tipoComi = new CommissionTypeViewObject
                    {
                        Codigo = src.NUM_TICOMI,
                        Nombre = src.NOMBRE,
                        LastModification = src.ULTMODI,
                        User = src.USUARIO
                    };
                    return tipoComi;
                });
                cfg.CreateMap<COMISIO, ComisioViewObject>();
                cfg.CreateMap<cliDelega, BranchesViewObject>().ConvertUsing(src =>
                {
                    var delegation = new BranchesViewObject
                    {
                        BranchId = src.cldIdDelega,
                        Address = src.cldDireccion1,
                        Address2 = src.cldDireccion2,
                        City = src.cldPoblacion,
                        Branch = src.cldDelegacion,
                        Email = src.cldEMail,
                        Notes = src.cldObservaciones,
                        Phone = src.cldTelefono1,
                        Phone2 = src.cldTelefono2,
                        LastModification = src.ULTMODI,
                        User = src.USUARIO
                    };
                    return delegation;
                });

                cfg.CreateMap<Visitas, VisitsViewObject>().ConvertUsing(src =>
                {
                    var visits = new VisitsViewObject();
                    /*
                    tipoComi.Codigo = src.NUM_TICOMI;
                    tipoComi.Nombre = src.NOMBRE;
                    tipoComi.LastModification = src.ULTMODI;
                    tipoComi.User = src.USUARIO;
                    */
                    return visits;
                });
                cfg.CreateMap<VisitsViewObject, VISITAS_COMI>().ConstructUsing(src =>
                {
                    var visit = new VISITAS_COMI
                    {
                        visIdCliente = src.ClientId,
                        visIdContacto = src.ContactId,
                        visIdObra = src.WorkId
                    };
                    if (src.SellerSource != null)
                    {
                        visit.visIdVendedor = src.SellerSource.Code;
                    }
                    visit.visIdVisita = src.VisitId;
                    if (src.VisitType != null)
                    {
                        visit.visIdVisitaTipo = src.VisitType.Code;
                    }
                    visit.visTexto = src.Text;
                    visit.visAlta = src.StartingDate;
                    visit.visFecha = src.Date;
                    visit.visMinutos = src.Minutes;
                    visit.EMAIL = src.Email;
                    visit.PREAVISO = src.IsOrder ? 0 : 1;

                    return visit;
                });
                cfg.CreateMap<MARCAS, BrandVehicleViewObject>().ConvertUsing(src =>
                {
                    var marcas = new BrandVehicleViewObject
                    {
                        Code = src.CODIGO,
                        Name = src.NOMBRE,
                        LastModification = src.ULTMODI,
                        User = src.USUARIO
                    };
                    return marcas;
                });

                cfg.CreateMap<SITUACION, CurrentSituationViewObject>().ConvertUsing(src =>
                {
                    var marcas = new CurrentSituationViewObject()
                    {
                        Code = src.NUMERO.ToString(),
                        Name = src.NOMBRE,
                        LastModification = src.ULTMODI,
                        User = src.USUARIO
                    };
                    return marcas;
                });
                cfg.CreateMap<CurrentSituationViewObject, SITUACION>().ConvertUsing(src =>
                {
                    var marcas = new SITUACION()
                    {
                        NUMERO = Convert.ToByte(src.Code),
                        NOMBRE = src.Name,
                        ULTMODI = src.LastModification,
                        USUARIO = src.User
                    };
                    return marcas;
                });

                cfg.CreateMap<MODELO, ModelVehicleViewObject>().ConvertUsing(src =>
                {
                    var vehicle = new ModelVehicleViewObject
                    {
                        Codigo = src.CODIGO,
                        Variante = src.VARIANTE,
                        Nombre = src.NOMBRE,
                        Marca = src.MARCA,
                        NomeMarca = src.NOMMARCA,
                        Categoria = src.CATEGORIA,
                        Referencia = src.REFERENCIA_MO,
                        Chassis = src.CHASIS
                    };
                    return vehicle;
                });
                cfg.CreateMap<GRUPOS, VehicleGroupViewObject>().ConvertUsing(
                    src =>
                    {
                        var grupos = new VehicleGroupViewObject()
                        {
                            Codigo = src.CODIGO,
                            Nombre = src.NOMBRE
                        };
                        return grupos;
                    });

                /*
                 
                  ForMember(x => x.PALBARAN, opt => opt.MapFrom(
                       src => ((!string.IsNullOrEmpty(src.PALBARAN)) &&  (src.PALBARAN != "0")))).
                 
                cfg.CreateMap<SupplierPoco, SupplierDto>().
                    ForMember(x => x.NOAUTOMARGEN, opt => opt.MapFrom(
                       src => (src.NOAUTOMARGEN.HasValue) && (src.NOAUTOMARGEN.Value == 1))).
                      
                       ForMember(x => x.GESTION_IVA_IMPORTA, opt => opt.MapFrom(
                       src => (src.GESTION_IVA_IMPORTA.HasValue) && (src.GESTION_IVA_IMPORTA.Value == 1))).

                cfg.CreateMap<SupplierDto, SupplierPoco>().
                ForMember(x => x.NOAUTOMARGEN, opt => opt.MapFrom(
                   src => (IsBoolInt(src.NOAUTOMARGEN)))).ForMember(x => x.GESTION_IVA_IMPORTA, opt => opt.MapFrom(src => (IsBoolInt(src.NOAUTOMARGEN)))).ForMember(x => x.INTRACO, opt => opt.MapFrom(src => IsBoolInt(src.INTRACO)));

                */

                cfg.CreateMap<CU1, AccountViewObject>().ConvertUsing(src =>
                {
                    var accountDto = new AccountViewObject
                    {
                        Codigo = src.CODIGO,
                        Description = src.DESCRIP,
                        Cuenta = src.CC
                    };
                    return accountDto;
                }

                    );
                cfg.CreateMap<AccountViewObject, CU1>().ConvertUsing(src =>
                {
                    var accountDto = new CU1
                    {
                        CODIGO = src.Codigo,
                        DESCRIP = src.Description
                    };
                    return accountDto;
                }

                );



                cfg.CreateMap<DIVISAS, CurrencyViewObject>();
                cfg.CreateMap<MESES, MonthsViewObject>();

                cfg.CreateMap<FORMAS, PaymentFormViewObject>();
                cfg.CreateMap<SupplierPoco, PROVEE1>().ConvertUsing<PocoToProvee1>();
                cfg.CreateMap<SupplierPoco, PROVEE2>().ConvertUsing<PocoToProvee2>();
                cfg.CreateMap<ProvinceViewObject, PROVINCIA>().ConvertUsing(src =>
                {
                    var provincia = new PROVINCIA
                    {
                        SIGLAS = src.Code,
                        PROV = src.Name
                    };
                    return provincia;
                });
                cfg.CreateMap<IDIOMAS, LanguageViewObject>().ConvertUsing(src =>
                {
                    var language = new LanguageViewObject
                    {
                        Nombre = src.NOMBRE,
                        Codigo = Convert.ToString(src.CODIGO)
                    };
                    return language;
                });
                cfg.CreateMap<BANCO, BanksViewObject>().ConvertUsing(
                    src =>
                    {
                        var banks = new BanksViewObject
                        {
                            Code = src.CODBAN,
                            Name = src.NOMBRE,
                            Swift = src.SWIFT,
                            LastModification = src.ULTMODI,
                            Usuario = src.USUARIO
                        };
                        return banks;
                    }
                );

                cfg.CreateMap<ProDelega, BranchesViewObject>().ConvertUsing(src =>
                {
                    var branchesDto = new BranchesViewObject
                    {
                        BranchId = src.cldIdDelega,
                        Address = src.cldDireccion1,
                        Address2 = src.cldDireccion2,
                        Branch = src.cldDelegacion,
                        City = src.cldPoblacion,
                        Email = src.cldEMail,
                        Phone = src.cldTelefono1,
                        Phone2 = src.cldTelefono2,
                        BranchKeyId = src.cldIdCliente
                    };
                    branchesDto.Branch = src.cldDelegacion;
                    branchesDto.Fax = src.cldFax;
                    branchesDto.Province = new ProvinceViewObject
                    {
                        Code = src.cldIdProvincia
                    };
                    return branchesDto;
                });

                cfg.CreateMap<ProContactos, ContactsViewObject>().ConvertUsing(src =>
                {
                    var contactDto = new ContactsViewObject
                    {
                        Email = src.ccoMail,
                        LastModification = src.ULTMODI,
                        ContactId = src.ccoIdContacto,
                        ContactName = src.ccoContacto,
                        Fax = src.ccoFax,
                        Movil = src.ccoMovil,
                        CurrentDelegation = src.ccoIdDelega,
                        Telefono = src.ccoTelefono,
                        Responsability = src.ccoCargo,
                        ContactsKeyId = src.ccoIdCliente
                    };
                    if (src.ccoIdCargo.HasValue)
                    {
                        contactDto.ResponsabilitySource.Code = src.ccoIdCargo.Value.ToString();
                    }
                    contactDto.ResponsabilitySource.Name = src.ccoCargo;
                    return contactDto;
                });





                cfg.CreateMap<TIPOPROVE, SupplierTypeViewObject>().ConvertUsing(src =>
                {
                    var tipoComi = new SupplierTypeViewObject();
                    tipoComi.Codigo = src.NUM_TIPROVE;
                    tipoComi.Nombre = src.NOMBRE;
                    return tipoComi;
                });
                cfg.CreateMap<TIPOPROVE, SupplierTypeViewObject>().ConvertUsing(src =>
                {
                    var model = new SupplierTypeViewObject
                    {
                        Codigo = src.NUM_TIPROVE,
                        Nombre = src.NOMBRE,
                        UltimaModifica = src.ULTMODI,
                        Usuario = src.USUARIO
                    };
                    return model;
                });
                cfg.CreateMap<SupplierTypeViewObject, TIPOPROVE>().ConvertUsing(src =>
                {
                    var model = new TIPOPROVE
                    {
                        NOMBRE = src.Nombre,
                        NUM_TIPROVE = src.Codigo,
                        USUARIO = src.Usuario,
                        ULTMODI = src.UltimaModifica
                    };
                    return model;
                });
                cfg.CreateMap<GRID_SERIALIZATION, GridSettingsDto>().ConvertUsing(src =>
                {
                    var model = new GridSettingsDto();

                    if (src == null)
                    {
                        return model;
                    }
                    model.GridIdentifier = src.GRID_ID;
                    model.GridName = src.GRID_NAME;
                    if (src.SERILIZED_DATA != null)
                    {
                        var base64String = src.SERILIZED_DATA;
                        var decodedData = Convert.FromBase64String(base64String);
                        model.XmlBase64 = System.Text.Encoding.UTF8.GetString(decodedData);
                    }
                    return model;
                });
                cfg.CreateMap<GridSettingsDto, GRID_SERIALIZATION>().ConvertUsing(src =>
                {
                    var model = new GRID_SERIALIZATION();
                    if (src != null)
                    {
                        model.GRID_ID = src.GridIdentifier;
                        model.GRID_NAME = src.GridName;
                        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(src.XmlBase64);
                        model.SERILIZED_DATA = Convert.ToBase64String(plainTextBytes);

                    }
                    return model;
                });

                cfg.CreateMap<VEHI_ACC, VehicleToolViewObject>().ConvertUsing(src =>
                {
                    var model = new VehicleToolViewObject();

                    if (src == null) return model;
                    model = new VehicleToolViewObject
                    {
                        Name = src.NOM_ACC,
                        Code = src.COD_ACC.ToString()
                    };
                    return model;
                });
                cfg.CreateMap<VehicleToolViewObject, VEHI_ACC>().ConvertUsing(src =>
                {
                    var model = new VEHI_ACC();
                    model.COD_ACC = Convert.ToInt32(src.Code);
                    model.NOM_ACC = src.Name;
                    return model;
                });
                cfg.CreateMap<ACTIVEHI, VehicleActivitiesViewObject>().ConvertUsing(src =>
                {
                    var model = new VehicleActivitiesViewObject();
                    model.Code = src.NUM_ACTIVEHI;
                    model.Activity = src.NOMBRE;
                    model.LastModification = src.ULTMODI;
                    model.User = src.USUARIO;
                    model.ActivitySigle = src.SIGLAS_ACT;
                   // var c = Convert.ToInt16(src.CALCULO);
                   // model.Compute = (c == 0);
                    model.ActityAlquiler = src.ACTIVI_ALQ;
                    model.Assurance = src.SEGURO_ANUAL;

                    return model;
                });

                cfg.CreateMap<ProDelegaPoco, BranchesViewObject>().ConvertUsing(src =>
                {
                    BranchesViewObject bdto = new BranchesViewObject();
                    bdto.BranchId = src.cldIdDelega;
                    bdto.BranchKeyId = src.cldIdCliente;
                    bdto.City = src.cldPoblacion;
                    bdto.Address = src.cldDireccion1;
                    bdto.Address2 = src.cldDireccion2;
                    bdto.Email = src.cldEMail;
                    bdto.Phone = src.cldTelefono1;
                    bdto.Phone2 = src.cldTelefono2;
                    bdto.Branch = src.cldDelegacion;
                    bdto.CellPhone = src.cldMovil;
                    bdto.Fax = src.cldFax;
                    bdto.Zip = src.CP;
                    bdto.Notes = src.cldObservaciones;
                    var prov = new ProvinceViewObject();
                    bdto.Province = prov;
                    prov.Code = src.CP;
                    prov.Name = src.NOM_PROV;
                    bdto.ProvinceSource = prov;
                    return bdto;
                });
                cfg.CreateMap<BranchesViewObject, ProDelega>().ConvertUsing(src =>
                {
                    ProDelega pdelega = new ProDelega();
                    pdelega.cldIdDelega = src.BranchId;
                    pdelega.cldIdCliente = src.BranchKeyId;
                    pdelega.cldDireccion1 = src.Address;
                    pdelega.cldDireccion2 = src.Address2;
                    pdelega.cldEMail = src.Email;
                    pdelega.cldMovil = src.CellPhone;
                    pdelega.cldFax = src.Fax;
                    if (src.ProvinceSource != null)
                    {
                        ProvinceViewObject dto = src.ProvinceSource as ProvinceViewObject;
                        pdelega.cldCP = dto.Code;
                        pdelega.cldIdProvincia = dto.Code;
                    }
                    pdelega.cldPoblacion = src.City;
                    pdelega.cldMovil = src.CellPhone;
                    pdelega.cldIdProvincia = src.ProvinceId;
                    pdelega.cldObservaciones = src.Notes;
                    return pdelega;
                });
                cfg.CreateMap<ClientPoco, ClientViewObject>();

                cfg.CreateMap<CLIENTES1, ClientPoco>().ConvertUsing(src =>
                {
                    var clientPoco = new GenericConverter<CLIENTES1, ClientPoco>();
                    return clientPoco.Convert(src, null, null);
                });
                cfg.CreateMap<CLIENTES2, ClientPoco>().ConvertUsing(src =>
                {
                    var clientPoco = new GenericConverter<CLIENTES2, ClientPoco>();
                    return clientPoco.Convert(src, null, null);
                });
                cfg.CreateMap<VehicleActivitiesViewObject, ACTIVEHI>().ConvertUsing(src =>
                {
                    var model = new ACTIVEHI();
                    model.NOMBRE = src.Activity;
                    model.CALCULO = src.Compute.ToString();
                    model.ACTIVI_ALQ = src.ActityAlquiler;
                    model.ULTMODI = src.LastModification;
                    model.USUARIO = src.User;
                    model.SEGURO_ANUAL = src.Assurance;
                    model.SIGLAS_ACT = src.ActivitySigle;

                    return model;
                });
                cfg.CreateMap<VehicleToolViewObject, VEHI_ACC>().ConvertUsing(src =>
                {
                    var model = new VEHI_ACC();
                    model.COD_ACC = Convert.ToInt32(src.Code);
                    model.NOM_ACC = src.Name;
                    return model;
                });

                cfg.CreateMap<COLORFL, ColorViewObject>().ConvertUsing(src =>
                {
                    var model = new ColorViewObject();
                    model.Code = src.CODIGO;
                    model.Name = src.NOMBRE;
                    var colorType = src.TIPOCOLOR;
                    model.NoCoating = colorType == "S";
                    model.PowderCoating = colorType == "M";
                    model.TwoTone = colorType == "B";
                    return model;
                });
                cfg.CreateMap<ColorViewObject, COLORFL>().ConvertUsing(src =>
                {
                    var model = new COLORFL();
                    model.CODIGO = src.Code;
                    model.NOMBRE = src.Name;
                    string type = "";
                    if (src.NoCoating)
                    {
                        type = "S";
                    }
                    if (src.PowderCoating)
                    {
                        type = "M";
                    }
                    if (src.TwoTone)
                    {
                        type = "B";
                    }
                    model.TIPOCOLOR = type;
                    return model;
                });
                cfg.CreateMap<EXTRASVEHI, VehicleExtraViewObject>().ConvertUsing(src =>
                {
                    var model = new VehicleExtraViewObject();
                    model.Name = src.NOMBRE;
                    model.Code = src.CODIGO.ToString();
                    model.LastModification = src.ULTMODI;
                    model.User = src.USUARIO;
                    model.Reference = src.REFERENCIA;
                    model.Notes = src.OBS;
                    model.VehicleType = new VehicleTypeViewObject();
                    model.VehicleType.Code = src.CODIGO.ToString();
                    return model;
                });


                cfg.CreateMap<OFICINAS, IList<DailyTime>>().ConvertUsing(src =>
                {
                    var dayOfTheWeek = new List<DailyTime>
                    {
                        new DailyTime()
                        {
                            Morning = new OfficeOpenClose() { Open = src.ABRE_MA_LUNES , Close = src.CIERRA_MA_LUNES },
                            Afternoon = new OfficeOpenClose() { Open = src.ABRE_TA_LUNES, Close = src.CIERRA_TA_LUNES }
                        },
                        new DailyTime()
                        {
                           Morning = new OfficeOpenClose() { Open = src.ABRE_MA_MARTES, Close = src.CIERRA_MA_MARTES },
                           Afternoon = new OfficeOpenClose() { Open = src.ABRE_TA_MARTES, Close = src.CIERRA_TA_MARTES }
                        },
                        new DailyTime()
                        {
                              Morning = new OfficeOpenClose() { Open = src.ABRE_MA_MIERCOLES, Close = src.CIERRA_MA_MIERCOLES },
                              Afternoon = new OfficeOpenClose() { Open = src.ABRE_TA_MIERCOLES, Close = src.CIERRA_TA_MIERCOLES }
                        },
                        new DailyTime()
                        {
                            Morning = new OfficeOpenClose() { Open = src.ABRE_MA_MIERCOLES, Close = src.CIERRA_MA_MIERCOLES },
                            Afternoon =  new OfficeOpenClose() { Open = src.ABRE_TA_MIERCOLES, Close = src.CIERRA_TA_MIERCOLES }
                        },
                        new DailyTime()
                        {
                            Morning = new OfficeOpenClose() { Open = src.ABRE_MA_JUEVES, Close = src.CIERRA_MA_JUEVES },
                            Afternoon =  new OfficeOpenClose() { Open = src.ABRE_TA_JUEVES, Close = src.CIERRA_TA_JUEVES }
                        },
                        new DailyTime()
                        {
                            Morning= new OfficeOpenClose() { Open = src.ABRE_MA_VIERNES, Close = src.CIERRA_MA_VIERNES },
                            Afternoon =  new OfficeOpenClose() { Open = src.ABRE_TA_VIERNES, Close = src.CIERRA_TA_VIERNES }
                        },
                        new DailyTime()
                        {
                            Morning = new OfficeOpenClose() { Open = src.ABRE_MA_SABADO, Close = src.CIERRA_MA_SABADO },
                            Afternoon= new OfficeOpenClose() { Open = src.ABRE_TA_SABADO, Close = src.CIERRA_TA_SABADO }
                        },
                        new DailyTime()
                        {
                            Morning = new OfficeOpenClose() { Open = src.ABRE_MA_DOMINGO, Close = src.CIERRA_MA_DOMINGO },
                            Afternoon = new OfficeOpenClose() { Open = src.ABRE_TA_DOMINGO, Close = src.CIERRA_TA_DOMINGO }
                        }
                    };
                    return dayOfTheWeek;
                });
                cfg.CreateMap<CliContactsPoco, ContactsViewObject>().ConvertUsing(src =>
                {
                    var c = new ContactsViewObject();
                    c.ContactId = src.ccoIdContacto;
                    c.ContactName = src.ccoContacto;
                    c.Nif = src.NIF;
                    c.Email = src.ccoMail;
                    c.Fax = src.ccoFax;
                    c.LastModification = src.ULTMODI;
                    c.User = src.USUARIO;
                    c.CurrentDelegation = src.nombreDelegacion;
                    c.Responsability = src.ccoCargo;
                    c.Movil = src.ccoMovil;
                    c.Telefono = src.ccoTelefono;
                    return c;
                });

                cfg.CreateMap<VehicleExtraViewObject, EXTRASVEHI>().ConvertUsing(src =>
                {
                    var model = new EXTRASVEHI();
                    model.CODIGO = Convert.ToInt32(src.Code);
                    model.NOMBRE = src.Name;
                    model.ULTMODI = src.LastModification;
                    model.USUARIO = src.User;
                    model.REFERENCIA = src.Reference;
                    model.OBS = src.Notes;
                    model.TIPO_VEHI = src.VehicleType.Code;
                    return model;
                });

                cfg.CreateMap<USO_ALQUILER, RentingUseViewObject>().ConvertUsing(src =>
                {
                    var model = new RentingUseViewObject();
                    model.Name = src.NOMBRE;
                    model.Code = src.CODIGO.ToString();
                    model.LastModification = src.ULTMODI;
                    model.User = src.USUARIO;
                    return model;
                });
                cfg.CreateMap<RentingUseViewObject, USO_ALQUILER>().ConvertUsing(src =>
                {
                    var model = new USO_ALQUILER();
                    model.CODIGO = Convert.ToByte(src.Code);
                    model.NOMBRE = src.Name;
                    model.ULTMODI = src.LastModification;
                    model.USUARIO = src.User;
                    return model;
                });
                cfg.CreateMap<ResellerViewObject, VENDEDOR>().ConvertUsing(src =>
                {

                    var model = new VENDEDOR();
                    model.NUM_VENDE = src.Code;
                    model.NOMBRE = src.Name;
                    model.ULTMODI = src.LastModification;
                    model.USUARIO = src.User;
                    model.FECHALTA = src.StartDate;
                    model.FECHABAJA = src.LeaveDate;
                    model.CP = src.City.Code;
                    model.POBLACION = src.City.Poblacion;
                    model.PROVINCIA = src.Province.Code;
                    model.EMAIL = src.Email;
                    model.MOVIL = src.CellPhone;
                    model.DIRECCION = src.Direction;
                    model.NIF = src.Nif;
                    model.OBS1 = src.Observation;
                    model.NOTAS = src.Notes;
                    model.FAX = src.Fax;
                    model.WEB = src.Web;

                    return model;
                });
                cfg.CreateMap<OrigenViewObject, ORIGEN>().ConvertUsing(src =>
                {
                    var model = new ORIGEN();
                    int value = -1;
                    if (int.TryParse(src.Code, out value))
                    {
                        model.NUM_ORIGEN = value; 
                    }
                    model.NOMBRE = src.Name;
                    model.ULTMODI = src.LastModification;
                    model.USUARIO = src.User;
                    return model;
                });
                cfg.CreateMap<CreditCardViewObject, TARCREDI>().ConvertUsing(src =>
                {
                    var model = new TARCREDI();
                    model.CODIGO = src.Code;
                    model.NOMBRE = src.Name;
                    model.ULTMODI = src.LastModification;
                    model.USUARIO = src.User;
                    return model;
                });
                cfg.CreateMap<ClientTypeViewObject, TIPOCLI>().ConvertUsing(src =>
                {
                    var model = new TIPOCLI();
                    model.NUM_TICLI = src.Code;
                    model.NOMBRE = src.Name;
                    model.ULTMODI = src.LastModification;
                    model.USUARIO = src.User;
                    return model;
                });
                cfg.CreateMap<TIPOCLI, ClientTypeViewObject>().ConvertUsing(src =>
                {
                    var model = new ClientTypeViewObject();
                    model.Code = src.NUM_TICLI;
                    model.Name = src.NOMBRE;
                    model.User = src.USUARIO;
                    model.LastModification = src.ULTMODI;
                    return model;
                });
                cfg.CreateMap<ClientZoneViewObject, ZONAS>().ConvertUsing(src =>
                {
                    var model = new ZONAS();
                    model.NUM_ZONA = src.Code;
                    model.NOMBRE = src.Name;
                    model.ULTMODI = src.LastModification;
                    model.USUARIO = src.User;
                    return model;
                });
                cfg.CreateMap<ZONAS, ClientZoneViewObject>().ConvertUsing(src =>
                {
                    var model = new ClientZoneViewObject();
                    model.Code = src.NUM_ZONA;
                    model.Name = src.NOMBRE;
                    model.LastModification = src.ULTMODI;
                    model.User = src.USUARIO;
                    return model;
                });
                cfg.CreateMap<VisitTypeViewObject, TIPOVISITAS>().ConvertUsing(src =>
                {
                    var model = new TIPOVISITAS();
                    model.NOMBRE_VIS = src.Name;
                    model.CODIGO_VIS = src.Code;
                    model.ULTMODI = src.LastModification;
                    model.USUARIO = src.User;
                    return model;
                });
                cfg.CreateMap<TIPOVISITAS, VisitTypeViewObject>().ConvertUsing(src =>
                {
                    var model = new VisitTypeViewObject();
                    model.Code = src.CODIGO_VIS;
                    model.Name = src.NOMBRE_VIS;
                    model.User = src.USUARIO;
                    model.LastModification = src.ULTMODI;
                    return model;
                });
                cfg.CreateMap<ContactTypeViewObject, TIPOCONTACTO_CLI>().ConvertUsing(src =>
                {
                    var model = new TIPOCONTACTO_CLI();
                    model.CODIGO = src.Code;
                    model.NOMBRE = src.Name;
                    model.ULTMODI = src.LastModification;
                    model.USUARIO = src.User;
                    return model;
                });
                cfg.CreateMap<TIPOCONTACTO_CLI, ContactTypeViewObject>().ConvertUsing(src =>
                {
                    var model = new ContactTypeViewObject();
                    model.Code = src.CODIGO;
                    model.Name = src.NOMBRE;
                    model.User = src.USUARIO;
                    model.LastModification = src.ULTMODI;
                    return model;
                });
                cfg.CreateMap<TARCREDI, CreditCardViewObject>().ConvertUsing(src =>
                {
                    var model = new CreditCardViewObject();
                    model.Code = src.CODIGO;
                    model.Name = src.NOMBRE;
                    model.LastModification = src.ULTMODI;
                    model.User = src.USUARIO;
                    return model;
                });

                cfg.CreateMap<TARJETA_EMP, CompanyCardViewObject>().ConvertUsing(src =>
                {
                    var model = new CompanyCardViewObject();
                    model.Code = src.COD_TARJETA;
                    model.Name = src.NOMBRE;
                    model.Conditions = src.CONDICIONES;
                    model.Prefix = src.PREFIJO;
                    model.Price = src.PRECIO;
                    return model;
                });

                cfg.CreateMap<CompanyCardViewObject, TARJETA_EMP>().ConvertUsing(src =>
                {
                    var model = new TARJETA_EMP();
                    model.COD_TARJETA = src.Code;
                    model.CONDICIONES = src.Conditions;
                    model.PRECIO = src.Price;
                    model.PREFIJO = src.Prefix;
                    model.NOMBRE = src.Name;
                    return model;
                });
                cfg.CreateMap<BANCO, BanksViewObject>().ConvertUsing(src =>
                 {
                     var model = new BanksViewObject();
                     model.Code = src.CODBAN;
                     model.Name = src.NOMBRE;
                     model.Swift = src.SWIFT;
                     model.LastModification = src.ULTMODI;
                     return model;
                 });
                cfg.CreateMap<CLAVEPTO, BudgetKeyViewObject>().ConvertUsing(src =>
                {
                    var model = new BudgetKeyViewObject();
                    model.Code = src.COD_CLAVE;
                    model.Name = src.NOMBRE;
                    model.LastModification = src.ULTMODI;
                    model.User = src.USUARIO;
                    return model;
                });
                cfg.CreateMap<BudgetKeyViewObject, CLAVEPTO>().ConvertUsing(src =>
                {
                    var model = new CLAVEPTO();
                    model.COD_CLAVE = src.Code;
                    model.NOMBRE = src.Name;
                    model.ULTMODI = src.LastModification;
                    model.USUARIO = src.User;
                    return model;
                });

                cfg.CreateMap<ChannelViewObject, CANAL>().ConvertUsing(src =>
                {
                    var model = new CANAL();
                    model.CODIGO = src.Code;
                    model.NOMBRE = src.Name;
                    model.ULTMODI = src.LastModification;
                    model.USUARIO = src.User;
                    return model;
                });
                cfg.CreateMap<CANAL, ChannelViewObject>().ConvertUsing(src =>
                {
                    var model = new ChannelViewObject();
                    model.Code = src.CODIGO;
                    model.Name = src.NOMBRE;
                    model.LastModification = src.ULTMODI;
                    model.User = src.USUARIO;
                    return model;
                });
                cfg.CreateMap<TIPO_CARGO, PeoplePositionViewObject>().ConvertUsing(src =>
                {
                    var model = new PeoplePositionViewObject();
                    model.Code = src.CODIGO.ToString();
                    model.Name = src.NOMBRE;
                    return model;
                });
                cfg.CreateMap<PeoplePositionViewObject, TIPO_CARGO>().ConvertUsing(src =>
                {
                    var model = new TIPO_CARGO();
                    model.CODIGO = Convert.ToByte(src.Code);
                    model.NOMBRE = src.Name;
                    return model;
                });

                cfg.CreateMap<BLOQUEFAC, InvoiceBlockViewObject>().ConvertUsing(src =>
                {
                    var model = new InvoiceBlockViewObject();
                    model.Code = src.CODIGO;
                    model.Name = src.NOMBRE;
                    //  model.LastModification = src.ULTMODI;
                    //  model.User = src.USUARIO;
                    return model;
                });
                cfg.CreateMap<InvoiceBlockViewObject, BLOQUEFAC>().ConvertUsing(src =>
                {
                    var model = new BLOQUEFAC();
                    model.CODIGO = src.Code;
                    model.NOMBRE = src.Name;
                    // model.ULTMODI = src.LastModification;
                    // model.USUARIO = src.User;
                    return model;
                });
                cfg.CreateMap<BanksViewObject, BANCO>().ConvertUsing(src =>
                {
                    var model = new BANCO();
                    model.CODBAN = src.Code;
                    model.NOMBRE = src.Name;
                    model.ULTMODI = src.LastModification;
                    model.SWIFT = src.Swift;
                    return model;
                });

                cfg.CreateMap<VIASPEDIPRO, DeliveringWayViewObject>().ConvertUsing(src =>
                {
                    var model = new DeliveringWayViewObject();
                    model.Codigo = src.CODIGO.ToString();
                    model.Nombre = src.NOMBRE;
                    model.LastModification = src.ULTMODI;
                    model.User = src.USUARIO;
                    return model;
                });
                cfg.CreateMap<DeliveringWayViewObject, VIASPEDIPRO>().ConvertUsing(src =>
                {
                    var model = new VIASPEDIPRO();
                    model.CODIGO = byte.Parse(src.Codigo);
                    model.NOMBRE = src.Nombre;
                    model.ULTMODI = src.LastModification;
                    model.USUARIO = src.User;
                    return model;
                });
                cfg.CreateMap<FORMAS_PEDENT, DeliveringFormViewObject>().ConvertUsing(src =>
                    {
                        var model = new DeliveringFormViewObject();
                        model.Codigo = src.CODIGO;
                        model.Nombre = src.NOMBRE;
                        return model;
                    });

                cfg.CreateMap<VehicleProvisionReasonViewObject, MOT_REPOSTAJE>().ConvertUsing(src =>
                {
                    var model = new MOT_REPOSTAJE();
                    model.COD_MOT = src.Code;
                    model.NOM_MOT = src.Name;
                    return model;
                });


                cfg.CreateMap<CATEGO, VehicleTypeViewObject>().ConvertUsing(src =>
                {
                    var model = new VehicleTypeViewObject();
                    model.Code = src.CODIGO;
                    model.Name = src.NOMBRE;
                    model.WebName = src.NOMWEB;
                    model.OfferMargin = src.DIAS_MARGEN;
                    model.LastModification = src.ULTMODI;

                    return model;
                });
                cfg.CreateMap<VehicleTypeViewObject, CATEGO>().ConvertUsing(src =>
                {
                    var model = new CATEGO();
                    model.CODIGO = src.Code;
                    model.NOMBRE = src.Name;
                    model.NOMWEB = src.WebName;
                    model.DIAS_MARGEN = src.OfferMargin;
                    model.ULTMODI = src.LastModification;
                    return model;
                });

                cfg.CreateMap<DeliveringFormViewObject, FORMAS_PEDENT>().ConvertUsing(src =>
                {
                    var model = new FORMAS_PEDENT();
                    model.CODIGO = src.Codigo;
                    model.NOMBRE = src.Nombre;
                    return model;
                });
                cfg.CreateMap<PriceConditionViewObject, TL_CONDICION_PRECIO>().ConvertUsing(src =>
                {
                    var model = new TL_CONDICION_PRECIO();
                    model.CODIGO = src.Codigo;
                    model.NOMBRE = src.Nombre;
                    model.DESCRIPCION = src.Description;
                    return model;
                });
                cfg.CreateMap<SUBLICEN, CompanyViewObject>().ConvertUsing(new CompanyConverter());
                cfg.CreateMap<CompanyViewObject, SUBLICEN>().ConvertUsing(new CompanyConverterBack());
                cfg.CreateMap<DIVISAS, CurrencyViewObject>().ConvertUsing(src =>
                {
                    var model = new CurrencyViewObject();
                    model.Codigo = src.CODIGO;
                    model.Nombre = src.NOMBRE;
                    return model;
                });
                cfg.CreateMap<BranchesViewObject, ProDelega>().ConvertUsing(src =>
                {
                    var model = new ProDelega();
                    model.cldIdCliente = src.BranchKeyId;
                    model.cldDireccion1 = src.Address;
                    model.cldDireccion2 = src.Address2;
                    model.cldEMail = src.Email;
                    model.cldIdDelega = src.BranchId.ToString();
                    model.cldDelegacion = src.Branch;
                    model.cldObservaciones = src.Notes;
                    model.cldPoblacion = src.City;
                    model.cldTelefono1 = src.Phone;
                    model.cldTelefono2 = src.Phone2;
                    model.cldFax = src.Fax;
                    if (src.Province != null)
                    {
                        model.cldIdProvincia = src.Province.Code;
                    }
                    if (src.ProvinceSource != null)
                    {
                        var prov = src.ProvinceSource as ProvinceViewObject;
                        if (prov != null)
                        {
                            model.cldIdProvincia = src.ProvinceId;
                        }
                    }
                    return model;
                });
                cfg.CreateMap<ProDelega, BranchesViewObject>().ConvertUsing(src =>
                {
                    var model = new BranchesViewObject();
                    model.Branch = src.cldDelegacion;
                    model.BranchId = src.cldIdDelega;
                    model.Address = src.cldDireccion1;
                    model.Address2 = src.cldDireccion2;
                    model.Email = src.cldEMail;
                    model.City = src.cldPoblacion;
                    model.Phone = src.cldTelefono1;
                    model.Phone2 = src.cldTelefono2;
                    model.Notes = src.cldObservaciones;
                    model.BranchKeyId = src.cldIdDelega;
                    model.Province = new ProvinceViewObject();
                    model.Province.Code = src.cldIdProvincia;
                    var proDto = new ProvinceViewObject();
                    proDto.Code = src.cldIdProvincia;
                    model.ProvinceSource = proDto;
                    return model;
                });
                cfg.CreateMap<MESES, MonthsViewObject>().ConstructUsing(src =>
                {
                    var model = new MonthsViewObject();
                    model.MES = src.MES;
                    model.NUMERO_MES = src.NUMERO_MES;
                    return model;
                });

                cfg.CreateMap<FORMAS, PaymentFormViewObject>().ConvertUsing(src =>
                {
                    var model = new PaymentFormViewObject();
                    model.Code = src.CODIGO.ToString();
                    model.Codigo = src.CODIGO;
                    model.Nombre = src.NOMBRE;
                    model.Cuenta = src.CUENTA;
                    model.LastModification = src.ULTMODI;
                    model.User = src.USUARIO;
                    return model;
                });
                cfg.CreateMap<PaymentFormViewObject, FORMAS>().ConvertUsing(src =>
                {
                    var model = new FORMAS();
                    model.CODIGO = src.Codigo;
                    model.NOMBRE = src.Nombre;
                    model.CUENTA = src.Cuenta;

                    return model;
                });
                //  opt => opt.Condition((src, dest, sourceMember) => sourceMember != null)
                cfg.CreateMap<VehiclePoco, VehicleViewObject>().ForAllMembers(opt => opt.Condition((src, dest, sourceMember) => sourceMember != null));
                // .ForAllMembers(opt => opt.Condition(srs => !srs.IsSourceValueNull));
                cfg.CreateMap<VehicleViewObject, VehiclePoco>();
                cfg.CreateMap<PICTURES, PictureDto>();
                cfg.CreateMap<VehiclePoco, VEHICULO1>().ConvertUsing<PocoToVehiculo1>();
                cfg.CreateMap<VehiclePoco, VEHICULO2>().ConvertUsing<PocoToVehiculo2>();
                cfg.CreateMap<BrandVehicleViewObject, MARCAS>().ConvertUsing(src =>
                {
                    var marcas = new MARCAS();
                    marcas.CODIGO = src.Code;
                    marcas.NOMBRE = src.Name;
                    return marcas;
                });
                // _vehicleMapper.Map<IEnumerable<PICTURES>, IEnumerable<PictureDto>>(pictureResult);
                cfg.CreateMap<MARCAS, BrandVehicleViewObject>().ConvertUsing(src =>
                {
                    var marcas = new BrandVehicleViewObject();
                    marcas.Code = src.CODIGO;
                    marcas.Name = src.NOMBRE;
                    return marcas;
                });
                cfg.CreateMap<PICTURES, PictureDto>();
                cfg.CreateMap<ColorViewObject, COLORFL>().ConvertUsing(src =>
                {
                    var color = new COLORFL();
                    color.CODIGO = src.Code;
                    color.NOMBRE = src.Name;
                    return color;
                }
                );
                cfg.CreateMap<COLORFL, ColorViewObject>().ConvertUsing(src =>
                {
                    var color = new ColorViewObject();
                    color.Code = src.CODIGO;
                    color.Name = src.NOMBRE;
                    return color;
                }
                );

                cfg.CreateMap<MODELO, ModelVehicleViewObject>().ConvertUsing(src =>
                {
                    var model = new ModelVehicleViewObject();
                    model.Codigo = src.CODIGO;
                    model.Nombre = src.NOMBRE;
                    model.Marca = src.MARCA;
                    model.Categoria = src.CATEGORIA;
                    model.Variante = src.VARIANTE;
                    model.NomeMarca = src.NOMMARCA;
                    return model;
                }
                );
                cfg.CreateMap<ModelVehicleViewObject, MODELO>().ConvertUsing(src =>
                {
                    var model = new MODELO();
                    model.MARCA = src.Marca;
                    model.CODIGO = src.Codigo;
                    model.NOMBRE = src.Nombre;
                    model.CATEGORIA = src.Categoria;
                    model.VARIANTE = src.Variante;
                    model.NOMMARCA = src.NomeMarca;
                    return model;
                }
                );

                cfg.CreateMap<ACTIVEHI, ActividadViewObject>().ConvertUsing(src =>
                {
                    var color = new ActividadViewObject();
                    color.Codigo = src.NUM_ACTIVEHI;
                    color.Nombre = src.NOMBRE;
                    return color;
                }
                );
                cfg.CreateMap<ActividadViewObject, ACTIVEHI>().ConvertUsing(src =>
                {
                    var color = new ACTIVEHI();
                    color.NUM_ACTIVEHI = src.Codigo;
                    color.NOMBRE = src.Nombre;
                    return color;
                }
                );


                cfg.CreateMap<InvoiceBlockViewObject, BLOQUEFAC>().ConvertUsing(src =>
                {
                    var model = new BLOQUEFAC();
                    model.CODIGO = src.Code;
                    model.NOMBRE = src.Name;
                    return model;
                });


                cfg.CreateMap<POBLACIONES, CityViewObject>().ConvertUsing(src =>
                {
                    var model = new CityViewObject();

                    model.Code = src.CP;
                    model.Poblacion = src.POBLA;
                    model.Pais = src.PAIS;
                    model.Country = new CountryViewObject();
                    model.Country.Code = src.PAIS;
                    return model;
                });
                cfg.CreateMap<SUBLICEN, CompanyViewObject>().ConvertUsing(
                  new CompanyConverter());
                cfg.CreateMap<CompanyViewObject, SUBLICEN>().ConvertUsing(
                  new CompanyConverterBack());
                cfg.CreateMap<CU1, AccountViewObject>().ConvertUsing(src =>
                {
                    var model = new AccountViewObject();
                    model.Code = src.CODIGO.ToString();
                    model.Codigo = src.CODIGO;
                    model.Description = src.DESCRIP;
                    model.Cuenta = src.CC;
                    return model;
                });
                cfg.CreateMap<BusinessViewObject, NEGOCIO>().ConvertUsing(src =>
                {
                    var model = new NEGOCIO();
                    model.CODIGO = src.Code;
                    model.NOMBRE = src.Name;
                    model.ULTMODI = src.LastModification;
                    model.USUARIO = src.User;
                    return model;
                });
                cfg.CreateMap<PERCARGOS, PersonalPositionViewObject>().ConvertUsing(new PercargosConverter());
                cfg.CreateMap<PersonalPositionViewObject, PERCARGOS>().ConvertUsing(new PersonalPositionDtoConverter());

            });
            var mappingConfig = config.CreateMapper();

            return mappingConfig;
        }
    }

    class VisitaCommissionBackConverter: ITypeConverter<VisitsViewObject, VISITAS_COMI>
    {
        public VisitaCommissionBackConverter()
        {
        }

        public VISITAS_COMI Convert(VisitsViewObject source, VISITAS_COMI destination, ResolutionContext context)
        {
            var outValue = new VISITAS_COMI();
            outValue.PEDIDO = System.Convert.ToByte(source.IsOrder);
            outValue.EMAIL = source.Email;
            outValue.ULTMODI = source.LastModification;
            outValue.USUARIO = source.User;
            outValue.visIdVisitaTipo = source.VisitType.Code;
            outValue.visIdContacto = source.ContactsSource.Code;
            outValue.visIdCliente = source.ClientSource.Code;
            outValue.visIdVendedor = source.SellerSource.Code;
            outValue.visTexto = source.Text;
            return outValue;
        }
    }

    /// <summary>
    ///  Converter for the the new vehiculo2.
    /// </summary>
    class PocoToVehiculo2 : ITypeConverter<VehiclePoco, VEHICULO2>
    {
        public VEHICULO2 Convert(VehiclePoco source, VEHICULO2 destination, ResolutionContext context)
        {
            VEHICULO2 vehiculo2 = new VEHICULO2();
            vehiculo2.CODIINT = source.CODIINT;

            PropertyInfo[] currentProperties = vehiculo2.GetType().GetProperties();
            foreach (PropertyInfo property in currentProperties)
            {
                var value = source.GetType().GetProperty(property.Name).GetValue(source);
                vehiculo2.GetType().GetProperty(property.Name).SetValue(vehiculo2, value);
            }
            return vehiculo2;
        }
    }
    /// <summary>
    /// Convert to the new vehiculo1. TODO: remove an use the generic version.
    /// </summary>
    class PocoToVehiculo1 : ITypeConverter<VehiclePoco, VEHICULO1>
    {
        public VEHICULO1 Convert(VehiclePoco source, VEHICULO1 destination, ResolutionContext context)
        {
            VEHICULO1 vehiculo = new VEHICULO1();
            vehiculo.CODIINT = source.CODIINT;
            Type vehiculoSourceType = source.GetType();
            PropertyInfo[] currentProperties = vehiculo.GetType().GetProperties();
            for (int i = 0; i < currentProperties.Length; ++i)
            {
                // destination property
                var prop = currentProperties[i];
                // source Value
                var sourceValueProperty = vehiculoSourceType.GetProperty(prop.Name);
                if (sourceValueProperty != null)
                {
                    var destinationProperty = vehiculo.GetType().GetProperty(prop.Name);
                    destinationProperty?.SetValue(vehiculo, sourceValueProperty.GetValue(source));
                }
            }
            return vehiculo;
        }
    }
    internal class PropieToOwnerDtoConverter : ITypeConverter<PROPIE, OwnerViewObject>
    {
        public OwnerViewObject Convert(PROPIE source, OwnerViewObject destination, ResolutionContext context)
        {
            OwnerViewObject model = new OwnerViewObject();
            model.Codigo = source.NUM_PROPIE;
            model.CP = source.CP;
            model.Direccion = source.DIRECCION;
            model.EMail = source.EMAIL;
            model.Fax = source.FAX;
            model.NIF = source.NIF;
            model.Nombre = source.NOMBRE;
            model.Provincia = source.PROVINCIA;
            model.Telefono = source.TELEFONO;
            return model;
        }
    }

    internal class BranchesToCliDelega : ITypeConverter<BranchesViewObject, cliDelega>
    {


        public cliDelega Convert(BranchesViewObject src, cliDelega destination, ResolutionContext context)
        {
            cliDelega model = new cliDelega();

            model.cldIdCliente = src.BranchKeyId;
            model.cldDireccion1 = src.Address;
            model.cldDireccion2 = src.Address2;
            model.cldEMail = src.Email;
            model.cldIdDelega = src.BranchId.ToString();
            model.cldDelegacion = src.Branch;
            model.cldObservaciones = src.Notes;
            model.cldPoblacion = src.City;
            model.cldTelefono1 = src.Phone;
            model.cldTelefono2 = src.Phone2;
            if (src.Province != null)
            {
                model.cldIdProvincia = src.Province.Code;
            }
            return model;

        }
    }

    class ClientSummaryConverter : ITypeConverter<ClientPoco, ClientSummaryViewObject>
    {
        public ClientSummaryConverter()
        {
        }
        public ClientSummaryViewObject Convert(ClientPoco source, ClientSummaryViewObject destination, ResolutionContext context)
        {
            var clients = new ClientSummaryViewObject();
            clients.Code = source.NUMERO_CLI;
            clients.AccountableAccount = source.CONTABLE;
            clients.City = source.POBLACION;
            clients.Direction = source.DIRECCION;
            clients.CreditCardType = source.TARTI;
            clients.NumberCreditCard = source.TARNUM;
            clients.Email = source.EMAIL;
            clients.Falta = source.ALTA;
            clients.Movil = source.MOVIL;
            clients.Name = source.NOMBRE;
            clients.Telefono = source.TELEFONO;
            clients.Sector = source.SECTOR;
            clients.Reseller = source.VENDEDOR;
            return clients;
        }


    }


    public class HolidayConverter : ITypeConverter<FESTIVOS_OFICINA, HolidayViewObject>
    {
        public HolidayViewObject Convert(FESTIVOS_OFICINA source, HolidayViewObject destination, ResolutionContext context)
        {
            var holiday = new HolidayViewObject
            {
                FESTIVO = source.FESTIVO,
                HORA_DESDE = source.HORA_DESDE,
                HORA_HASTA = source.HORA_HASTA,
                OFICINA = source.OFICINA,
                PARTE_DIA = source.PARTE_DIA

            };
            return holiday;
        }
    }

    /// <summary>
    ///  HolidayConverterBack from holiday to festivos oficina.
    /// </summary>

    public class HolidayConverterBack : ITypeConverter<HolidayViewObject, FESTIVOS_OFICINA>
    {
        public FESTIVOS_OFICINA Convert(HolidayViewObject source, FESTIVOS_OFICINA destination, ResolutionContext context)
        {
            FESTIVOS_OFICINA holiday = new FESTIVOS_OFICINA();
            holiday.FESTIVO = source.FESTIVO;
            holiday.HORA_DESDE = source.HORA_DESDE;
            holiday.HORA_HASTA = source.HORA_HASTA;
            holiday.OFICINA = source.OFICINA;
            holiday.PARTE_DIA = source.PARTE_DIA;
           
            /* if (holiday.ULTMODI == null)
             {
                 holiday.ULTMODI = DateTime.Now.ToString("yyyyMMddhhmmss");
             }
             if (holiday.USUARIO == null)
             {
                 holiday.USUARIO = "GUEST";
             }*/
            return holiday;
        }
    }
    /// <summary>
    /// Office converter from OFINAS to OfficeViewObject.
    /// </summary>
    public class OfficeConverter : ITypeConverter<OFICINAS, OfficeViewObject>
    {
        /// <summary>
        ///  Fill the time table.
        /// </summary>
        /// <param name="i">Index</param>
        /// <param name="ofi">Office data trasnfer object</param>
        /// <param name="oficinas">Oficinas</param>
        private void FillTimeTable(ref OfficeViewObject officeDto, OFICINAS office)
        {
            officeDto.TimeTable = new List<DailyTime>();
            var daily = new DailyTime();
            daily.DayName = "Lunes";
            daily.Morning = new OfficeOpenClose();
            daily.Afternoon = new OfficeOpenClose();
            daily.Morning.Open = office.ABRE_MA_LUNES ?? new TimeSpan();
            daily.Afternoon.Open = office.ABRE_TA_LUNES ?? new TimeSpan();
            daily.Afternoon.Close = office.CIERRA_TA_LUNES ?? new TimeSpan();
            daily.Morning.Close = office.CIERRA_MA_LUNES ?? new TimeSpan();
            officeDto.TimeTable.Add(daily);
            var daily1 = new DailyTime();
            daily1.DayName = "Martes";
            daily1.Morning = new OfficeOpenClose();
            daily1.Afternoon = new OfficeOpenClose();
            daily1.Morning.Open = office.ABRE_MA_MARTES ?? new TimeSpan();
            daily1.Afternoon.Open = office.ABRE_TA_MARTES ?? new TimeSpan();
            daily1.Afternoon.Close = office.CIERRA_TA_MARTES ?? new TimeSpan();
            daily1.Morning.Close = office.CIERRA_MA_MARTES ?? new TimeSpan();
            officeDto.TimeTable.Add(daily1);


            var daily2 = new DailyTime();
            daily2.DayName = "Miercoles";

            daily2.Morning = new OfficeOpenClose();
            daily2.Afternoon = new OfficeOpenClose();
            daily2.Morning.Open = office.ABRE_MA_MIERCOLES ?? new TimeSpan();
            daily2.Afternoon.Open = office.ABRE_TA_MIERCOLES ?? new TimeSpan();
            daily2.Afternoon.Close = office.CIERRA_TA_MIERCOLES ?? new TimeSpan();
            daily2.Morning.Close = office.CIERRA_MA_MIERCOLES ?? new TimeSpan();
            officeDto.TimeTable.Add(daily2);
            var daily3 = new DailyTime();
            daily3.DayName = "Jueves";
            daily3.Morning = new OfficeOpenClose();
            daily3.Afternoon = new OfficeOpenClose();
            daily3.Morning.Open = office.ABRE_MA_JUEVES ?? new TimeSpan();
            daily3.Afternoon.Open = office.ABRE_TA_JUEVES ?? new TimeSpan();
            daily3.Afternoon.Close = office.CIERRA_TA_JUEVES ?? new TimeSpan();
            daily3.Morning.Close = office.CIERRA_MA_JUEVES ?? new TimeSpan();
            officeDto.TimeTable.Add(daily3);
            var daily4 = new DailyTime();
            daily4.DayName = "Viernes";
            daily4.Morning = new OfficeOpenClose();
            daily4.Afternoon = new OfficeOpenClose();
            daily4.Morning.Open = office.ABRE_MA_VIERNES ?? new TimeSpan();
            daily4.Afternoon.Open = office.ABRE_TA_VIERNES ?? new TimeSpan();
            daily4.Afternoon.Close = office.CIERRA_TA_VIERNES ?? new TimeSpan();
            daily4.Morning.Close = office.CIERRA_MA_VIERNES ?? new TimeSpan();
            officeDto.TimeTable.Add(daily4);


            var daily5 = new DailyTime();
            daily5.DayName = "Sabado";
            daily5.Morning = new OfficeOpenClose();
            daily5.Afternoon = new OfficeOpenClose();
            daily5.Morning.Open = office.ABRE_MA_SABADO ?? new TimeSpan();
            daily5.Afternoon.Open = office.ABRE_TA_SABADO ?? new TimeSpan();
            daily5.Afternoon.Close = office.CIERRA_TA_SABADO ?? new TimeSpan();
            daily5.Morning.Close = office.CIERRA_MA_SABADO ?? new TimeSpan();
            officeDto.TimeTable.Add(daily5);
            var daily6 = new DailyTime();
            daily6.DayName = "Domingo";
            daily6.Morning = new OfficeOpenClose();
            daily6.Afternoon = new OfficeOpenClose();
            daily6.Morning.Open = office.ABRE_MA_DOMINGO ?? new TimeSpan();
            daily6.Afternoon.Open = office.ABRE_TA_DOMINGO ?? new TimeSpan();
            daily6.Afternoon.Close = office.CIERRA_TA_DOMINGO ?? new TimeSpan();
            daily6.Morning.Close = office.CIERRA_MA_DOMINGO ?? new TimeSpan();
            officeDto.TimeTable.Add(daily6);

        }
        public OfficeViewObject Convert(OFICINAS source, OfficeViewObject destination, ResolutionContext context)
        {
            var office = new OfficeViewObject();
            var gc = new GenericConverter<OFICINAS, OfficeViewObject>();
            office = gc.Convert(source, office, context);
            office.Codigo = source.CODIGO;
            office.Nombre = source.NOMBRE;
            office.LastModification = source.ULTMODI;
            office.User = source.USUARIO;
            office.POBLACION = source.POBLACION;
            FillTimeTable(ref office, source);
            if (office.TIPO1 == null)
            {
                office.TIPO1 = "0";
            }
            if (office.TIPO2 == null)
            {
                office.TIPO2 = "0";
            }
            if (office.TIPO3 == null)
            {
                office.TIPO3 = "0";
            }
            return office;
        }
    }

    /// <summary>
    ///  Office conversion from an office dto to oficinas.
    /// </summary>
    public class OfficeConverterBack : ITypeConverter<OfficeViewObject, OFICINAS>
    {
        /// <summary>
        ///  Convert an office to a destination office.
        /// </summary>
        /// <param name="source">Office to use.</param>
        /// <param name="destination">Destination office to use.</param>
        /// <param name="context">Context to be used.</param>
        /// <returns>Return the current office.</returns>
        public OFICINAS Convert(OfficeViewObject source, OFICINAS destination, ResolutionContext context)
        {
            OFICINAS office = new OFICINAS();
            GenericBackConverter<OfficeViewObject, OFICINAS> gc = new GenericBackConverter<OfficeViewObject, OFICINAS>();
            office = gc.Convert(source, office, context);
            if (source.Codigo != null)
            {
                office.CODIGO = source.Codigo.Length <= 2 ? source.Codigo : source.Codigo.Substring(0, 2);

                office.ULTMODI = source.LastModification;
                office.USUARIO = source.User;
                office.NOMBRE = source.Nombre;
                if (office.ULTMODI == null)
                {
                    // yyyy MM dd hh
                    var officeDateTime = DateTime.Now.ToString("yyyyMMddhhmm");
                    var timestamp = officeDateTime.Substring(0, 10) + ":" + officeDateTime.Substring(10);
                    office.ULTMODI = timestamp;
                }

                if (office.USUARIO == null)
                {
                    office.USUARIO = "GT";
                }

                if (string.IsNullOrEmpty(office.NOMBRE))
                {
                    office.NOMBRE = "Unknown";
                }

                var timeTable = source.TimeTable;
                if (timeTable != null)
                {
                    for (int i = 0; i < timeTable.Count(); ++i)
                    {
                        FillDate(i, timeTable[i], ref office);
                    }
                }
            }
            return office;
        }


        /// <summary>
        /// Fill date.
        /// </summary>
        /// <param name="office">Office to use</param>
        /// <returns></returns>
        private void FillDate(int i, DailyTime dailyTime, ref OFICINAS oficinas)
        {
            Dictionary<int, Func<DailyTime, OFICINAS, OFICINAS>> dictionary = new Dictionary<int, Func<DailyTime, OFICINAS, OFICINAS>>() {
                    { 0, (daily, office) =>
                          {
                              office.ABRE_MA_LUNES = daily.Morning.Open;
                              office.ABRE_TA_LUNES = daily.Afternoon.Open;
                              office.CIERRA_MA_LUNES = daily.Morning.Close;
                              office.CIERRA_TA_LUNES = daily.Afternoon.Close;
                              return office;
                          }
                    },
                    { 1, (daily, office) =>
                          {
                              office.ABRE_MA_MARTES = daily.Morning.Open;
                              office.ABRE_TA_MARTES = daily.Afternoon.Open;
                              office.CIERRA_MA_MARTES = daily.Morning.Close;
                              office.CIERRA_TA_MARTES = daily.Afternoon.Close;

                              return office;
                          }
                    },
                    { 2, (daily,office) =>
                          {
                              office.ABRE_MA_MIERCOLES = daily.Morning.Open;
                              office.ABRE_TA_MIERCOLES = daily.Afternoon.Open;
                              office.CIERRA_MA_MIERCOLES = daily.Morning.Close;
                              office.CIERRA_TA_MIERCOLES = daily.Afternoon.Close;
                              return office;
                          }
                    },
                    { 3, (daily, office) =>
                          {
                              office.ABRE_MA_JUEVES = daily.Morning.Open;
                              office.ABRE_TA_JUEVES= daily.Afternoon.Open;
                              office.CIERRA_MA_JUEVES = daily.Morning.Close;
                              office.CIERRA_TA_JUEVES = daily.Afternoon.Close;
                              return office;
                          }
                    },
                    { 4, (daily, office) =>
                          {
                              office.ABRE_MA_VIERNES = daily.Morning.Open;
                              office.ABRE_TA_VIERNES= daily.Afternoon.Open;
                              office.CIERRA_MA_VIERNES = daily.Morning.Close;
                              office.CIERRA_TA_VIERNES = daily.Afternoon.Close;
                              return office;
                          }
                    },
                    { 5, (daily, office) =>
                          {
                              office.ABRE_MA_SABADO = daily.Morning.Open;
                              office.ABRE_TA_SABADO= daily.Afternoon.Open;
                              office.CIERRA_MA_SABADO = daily.Morning.Close;
                              office.CIERRA_TA_SABADO = daily.Afternoon.Close;
                              return office;
                          }
                    },
                    { 6, (daily, office) =>
                          {
                              office.ABRE_MA_DOMINGO = daily.Morning.Open;
                              office.ABRE_TA_DOMINGO= daily.Afternoon.Open;
                              office.CIERRA_MA_DOMINGO = daily.Morning.Close;
                              office.CIERRA_TA_DOMINGO = daily.Afternoon.Close;
                              return office;
                          }
                    }
                };
            Func<DailyTime, OFICINAS, OFICINAS> f;
            var hasFunc = dictionary.TryGetValue(i, out f);

            if (hasFunc)
            {
                oficinas = f.Invoke(dailyTime, oficinas);
            }
        }


    }
    internal class PocoToProvee2 : ITypeConverter<SupplierPoco, PROVEE2>
    {
        public PROVEE2 Convert(SupplierPoco source, PROVEE2 destination, ResolutionContext context)
        {
            PROVEE2 supplier = new PROVEE2();
            supplier.NUM_PROVEE = source.NUM_PROVEE;
            if (supplier.PALBARAN.HasValue)
            {
                supplier.PALBARAN = (source.PALBARAN == 0) ? '0' : '1';
            }
            Supplier.SetProperties(source, supplier);
            return supplier;
        }
    }

    internal class PocoToProvee1 : ITypeConverter<SupplierPoco, PROVEE1>
    {
        public PROVEE1 Convert(SupplierPoco source, PROVEE1 destination, ResolutionContext context)
        {
            PROVEE1 supplier = new PROVEE1();
            supplier.NUM_PROVEE = source.NUM_PROVEE;
            Supplier.SetProperties(source, supplier);
            if (supplier.MAIL_DEVO!=null)
            {
                supplier.MAIL_DEVO.Replace("@", "#");

            }
            if (supplier.MAIL_PAGO != null)
            {
                supplier.MAIL_PAGO.Replace("@", "#");

            }
            if (supplier.MAIL_PEDI != null)
            {
                supplier.MAIL_PEDI.Replace("@", "#");

            }
            if (supplier.MAIL_DEVO != null)
            {
                supplier.MAIL_DEVO.Replace("@", "#");

            }
            if (supplier.EMAIL!= null)
            {
                supplier.EMAIL.Replace("@", "#");

            }
            return supplier;
        }
    }
}

