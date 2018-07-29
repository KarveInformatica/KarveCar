using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using AutoMapper;
using DataAccessLayer.DataObjects;
using KarveDataServices.DataTransferObject;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using KarveDataServices.DataObjects;
using DataAccessLayer.Model;
using Model;

namespace DataAccessLayer.Logic
{
    /// <summary>
    /// POCO to Dto converter for the provice domain object
    /// </summary>
    public class ProvinciaConverter : ITypeConverter<PROVINCIA, ProvinciaDto>
    {
        public ProvinciaDto Convert(PROVINCIA source, ProvinciaDto destination, ResolutionContext context)
        {
            ProvinciaDto prov = new ProvinciaDto();
            prov.Code = source.SIGLAS;
            prov.CodeId = source.SIGLAS;

            prov.Name = source.PROV;
            prov.Capital = source.CAPITAL;
            prov.Prefix = source.PREFIJO;
            prov.Country = source.PAIS;
            prov.CountryValue = new CountryDto();
            // TODO: avoid this replication
            prov.CountryValue.CountryCode = source.PAIS;
            prov.CountryValue.Code = source.PAIS;
            return prov;
        }
    }

    /// <summary>
    /// Drto converter for the provice domain object
    /// </summary>
    public class ProvinciaConverterToPOCO : ITypeConverter<ProvinciaDto, PROVINCIA>
    {
        /// <summary>
        ///  Provincia converter
        /// </summary>
        /// <param name="source">Convert the provincia</param>
        /// <param name="destination"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public PROVINCIA Convert(ProvinciaDto source, PROVINCIA destination, ResolutionContext context)
        {
            PROVINCIA prov = new PROVINCIA();
            prov.SIGLAS = source.Code;
            prov.PROV = source.Name;
            prov.CAPITAL = source.Capital;
            prov.PREFIJO = source.Prefix;
            prov.PAIS = source.CountryValue.Code;
            return prov;
        }
    }

    /// <summary>
    /// POCO to Dto converter for the country domain object
    /// </summary>
    public class CountryConverter : ITypeConverter<Country, CountryDto>
    {
        public CountryDto Convert(Country source, CountryDto destination, ResolutionContext context)
        {
            CountryDto dto = new CountryDto();
            dto.Code = source.SIGLAS;
            dto.CodeId = source.SIGLAS;

            dto.CountryName = source.PAIS;
            dto.Language = source.IDIOMA_PAIS;
            if (source.INTRACO.HasValue)
            {
                var value = source.INTRACO.Value;
                dto.IsIntraco = value == 1;
            }
            return dto;
        }
    }
    /// <summary>
    /// Dto to POCO  converter for the country domain object
    /// </summary>
    public class Country2PocoConverter : ITypeConverter<CountryDto, Country>
    {
        public Country Convert(CountryDto source, Country destination, ResolutionContext context)
        {
            Country dto = new Country();
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

    public class PercargosConverter : ITypeConverter<PERCARGOS, PersonalPositionDto>
    {
        /// <summary>
        ///  Convert a PERCARGO to a Data Transfer Object.
        /// </summary>
        /// <param name="source">Entity source</param>
        /// <param name="destination">Destination data transfer object</param>
        /// <param name="context">Resolution context</param>
        /// <returns></returns>
        public PersonalPositionDto Convert(PERCARGOS source, PersonalPositionDto destination, ResolutionContext context)
        {
            PersonalPositionDto position = new PersonalPositionDto();
            position.Code = source.CODIGO.ToString();
            position.CodeId = source.CODIGO.ToString();
            position.Name = source.NOMBRE;
            position.LastModification = source.ULTMODI;
            position.User = source.USUARIO;
            return position;
        }
    }

    public class PersonalPositioDtoConverter : ITypeConverter<PersonalPositionDto, PERCARGOS>
    {
        public PERCARGOS Convert(PersonalPositionDto source, PERCARGOS destination, ResolutionContext context)
        {
            PERCARGOS percargos = new PERCARGOS();
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
    public class ContactsConverter : ITypeConverter<ContactsComiPoco, ContactsDto>
    {
        public ContactsDto Convert(ContactsComiPoco source, ContactsDto destination, ResolutionContext context)
        {
            ContactsDto contactsDto = new ContactsDto();
            contactsDto.CodeId = source.CONTACTO.ToString();

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
            contactsDto.ResponsabilitySource = new PersonalPositionDto();
            contactsDto.ResponsabilitySource.Code = source.CARGO?.ToString();
            contactsDto.ResponsabilitySource.Name = source.NOM_CARGO;
            return contactsDto;

        }
    }
    /// <summary>
    /// POCO to Dto converter for the commission branches
    /// </summary>
    public class BranchesConverter : ITypeConverter<ComiDelegaPoco, BranchesDto>
    {
        public BranchesDto Convert(ComiDelegaPoco source, BranchesDto destination, ResolutionContext context)
        {
            BranchesDto branchesDto = new BranchesDto();
            branchesDto.BranchId = source.cldIdDelega.ToString();
            branchesDto.CodeId = branchesDto.BranchId;
            branchesDto.Branch = source.cldDelegacion;
            if (source.PROV != null)
            {
                branchesDto.Province = new ProvinciaDto();
                branchesDto.Province.Code = source.PROV.SIGLAS;
                branchesDto.Province.Name = source.NOM_PROV;
                branchesDto.Province.Country = source.PAIS;
                branchesDto.ProvinceName = source.NOM_PROV;

                branchesDto.Zip = source.PROV.CP;
                // redundundant.
                branchesDto.ProvinceSource = branchesDto.Province;


            }
            branchesDto.Zip = source.cldCP;
            branchesDto.ProvinceId = source.cldIdProvincia;
            branchesDto.Address = source.cldDireccion1;
            branchesDto.Address2 = source.cldDireccion2;
            branchesDto.Phone = source.cldTelefono1;
            branchesDto.Phone2 = source.cldTelefono2;
            branchesDto.Email = source.cldEMail;
            branchesDto.City = source.cldPoblacion;
            branchesDto.Fax = source.cldFax;
            branchesDto.User = source.USUARIO;
            branchesDto.LastModification = source.ULTMODI;
            return branchesDto;
        }
    }

    /// <summary>
    ///  POCO to Dto converter.
    /// </summary>
    /// <summary>
    /// POCO to Dto converter for the commission branches
    /// </summary>
    public class ClientBranchesConverter : ITypeConverter<CliDelegaPoco, BranchesDto>
    {
        public BranchesDto Convert(CliDelegaPoco source, BranchesDto destination, ResolutionContext context)
        {
            var branchesDto = new BranchesDto
            {
                Branch = source.cldDelegacion,
                BranchId = source.cldIdDelega,
                Province = new ProvinciaDto(),
                ProvinceSource =  new ProvinciaDto()
            };

            if (source.PROV != null)
            {

                branchesDto.Province.Code = source.PROV.SIGLAS;
                branchesDto.Province.Name = source.PROV.PROV;
                branchesDto.Province.Country = source.PROV.PAIS;
                branchesDto.ProvinceSource = branchesDto.Province;
            }
            branchesDto.Address = source.cldDireccion1;
            branchesDto.Address2 = source.cldDireccion2;
            branchesDto.Phone = source.cldTelefono1;
            branchesDto.Phone2 = source.cldTelefono2;
            branchesDto.Email = source.cldEMail;
            branchesDto.City = source.cldPoblacion;
            return branchesDto;
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
    public class ContactToProContactosConverter : ITypeConverter<ContactsDto, ProContactos>
    {
        public ProContactos Convert(ContactsDto source, ProContactos destination, ResolutionContext context)
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
    public class ProContactsConverter : ITypeConverter<ProContactos, ContactsDto>
    {
        public ContactsDto Convert(ProContactos source, ContactsDto destination, ResolutionContext context)
        {
            ContactsDto contacts = new ContactsDto();
            contacts.ContactId = source.ccoIdContacto;
            contacts.ContactName = source.ccoContacto;
            contacts.ContactsKeyId = source.ccoIdCliente;
            contacts.Telefono = source.ccoTelefono;
            contacts.LastModification = source.ULTMODI;
            contacts.User = source.USUARIO;
            contacts.Email = source.ccoMail;
            contacts.CurrentDelegation = source.ccoIdDelega;
            contacts.ResponsabilitySource = new PersonalPositionDto();
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
    public class ZonaOfiConverter : ITypeConverter<ZONAOFI, ZonaOfiDto>
    {
        public ZonaOfiDto Convert(ZONAOFI source, ZonaOfiDto destination, ResolutionContext context)
        {
            ZonaOfiDto ofiDto = new ZonaOfiDto();
            ofiDto.Codigo = source.COD_ZONAOFI;
            ofiDto.Nombre = source.NOM_ZONA;
            ofiDto.Plaza = source.PLAZA;
            ofiDto.CodeId = source.COD_ZONAOFI;

            return ofiDto;
        }
    }
    /// <summary>
    /// POCO to Dto converter for the products domain object
    /// </summary>
    public class ProductsConverter : ITypeConverter<PRODUCTS, ProductsDto>
    {

        public ProductsDto Convert(PRODUCTS source, ProductsDto destination, ResolutionContext context)
        {
            ProductsDto destinationDto = new ProductsDto();
            destinationDto.Codigo = source.CODIGO_PRD;
            destinationDto.Nombre = source.NOMBRE_PRD;
            destinationDto.Observacion = source.OBS_PRD;
            destinationDto.CodeId = source.CODIGO_PRD.ToString();

            return destinationDto;
        }
    }
    /// <summary>
    /// POCO to Dto converter for the market domain object
    /// </summary>
    public class MercadoConverter : ITypeConverter<MERCADO, MercadoDto>
    {

        public MercadoDto Convert(MERCADO source, MercadoDto destination, ResolutionContext context)
        {
            MercadoDto destinationDto = new MercadoDto();
            destinationDto.Code = source.CODIGO;
            destinationDto.Name = source.NOMBRE;
            destinationDto.CodeId = source.CODIGO;

            return destinationDto;
        }
    }
    /// <summary>
    /// POCO to Dto converter for the market domain object
    /// </summary>
    public class Poco2MercadoConverter : ITypeConverter<MercadoDto, MERCADO>
    {

        public MERCADO Convert(MercadoDto source, MERCADO destination, ResolutionContext context)
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
    public class CompanyConverterBack : ITypeConverter<CompanyDto, SUBLICEN>
    {
        public SUBLICEN Convert(CompanyDto source, SUBLICEN destination, ResolutionContext context)
        {
            var entityConverter = new GenericBackConverter<CompanyDto, SUBLICEN>();
            var entity = entityConverter.Convert(source, destination, context);
            // assure that is al ok.
            entity.CODIGO = source.Code;

            return entity;
        }
    }

    /// <summary>
    ///  CompanyToDto converter
    /// </summary>
    public class CompanyConverter : ITypeConverter<SUBLICEN, CompanyDto>
    {
        public CompanyDto Convert(SUBLICEN source, CompanyDto destination, ResolutionContext context)
        {
            var entityConverter = new GenericConverter<SUBLICEN, CompanyDto>();
            var model = entityConverter.Convert(source, destination, context);
            if (model != null)
            {
                model.Code = source.CODIGO;
                model.Name = source.NOMBRE;
                model.CommercialName = source.NOMCOMER;
                model.Poblacion = source.POBLACION;
                model.Nif = source.NIF;
                model.CodeId = source.CODIGO;

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
    public class ClientToClientes1 : ITypeConverter<CLIENTES1, ClientDto>
    {
        public ClientDto Convert(CLIENTES1 source, ClientDto destination, ResolutionContext context)
        {
            GenericConverter<CLIENTES1, ClientDto> gc = new GenericConverter<CLIENTES1, ClientDto>();
            var v = gc.Convert(source, destination, context);
            return v;
        }
    }
    /// POCO to Dto converter for the client domain object to merge both.
    public class ClientToClientes2 : ITypeConverter<CLIENTES2, ClientDto>
    {
        public ClientDto Convert(CLIENTES2 source, ClientDto destination, ResolutionContext context)
        {
            GenericConverter<CLIENTES2, ClientDto> gc = new GenericConverter<CLIENTES2, ClientDto>();
            var v = gc.Convert(source, destination, context);
            return v;
        }
    }

    /// <summary>
    /// POCO to Dto converter for the client domain object
    /// </summary>
    public class ClientesConverter : ITypeConverter<CLIENTES1, ClientDto>
    {
        public ClientDto Convert(CLIENTES1 source, ClientDto destination, ResolutionContext context)
        {
            ClientDto clientDto = new ClientDto();
            clientDto.Numero = source.NUMERO_CLI;
            clientDto.Nombre = source.NOMBRE;
            clientDto.Movil = source.MOVIL;
            clientDto.Numero= source.NUMERO_CLI;
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
    public class CanalConverter : ITypeConverter<CANAL, ChannelDto>
    {
        public ChannelDto Convert(CANAL source, ChannelDto destination, ResolutionContext context)
        {
            ChannelDto dto = new ChannelDto();
            dto.Code = source.CODIGO;
            dto.Name = source.NOMBRE;
            dto.CodeId = source.CODIGO;

            return dto;
        }
    }
    /// <summary>
    /// POCO to Dto converter for the business shop domain object
    /// </summary>
    public class NegocioConverter : ITypeConverter<NEGOCIO, BusinessDto>
    {
        public BusinessDto Convert(NEGOCIO source, BusinessDto destination, ResolutionContext context)
        {
            BusinessDto businessDto = new BusinessDto();
            businessDto.Code = source.CODIGO;
            businessDto.Name = source.NOMBRE;
            businessDto.CodeId = source.CODIGO;
            return businessDto;
        }
    }
    /// <summary>
    /// POCO to Dto converter for the reseller domain object
    /// </summary>
    public class VendedorConverter : ITypeConverter<VENDEDOR, ResellerDto>
    {
        public ResellerDto Convert(VENDEDOR source, ResellerDto destination, ResolutionContext context)
        {
            ResellerDto resellerDto = new ResellerDto();
            resellerDto.Code = source.NUM_VENDE;
            resellerDto.Name = source.NOMBRE;
            resellerDto.Nif = source.NIF;
            resellerDto.City = new CityDto();
            resellerDto.City.Poblacion = source.POBLACION;
            resellerDto.City.Code = source.CP;
            resellerDto.Country = new CountryDto();
            resellerDto.Country.Code = source.NACIOPER;
            resellerDto.Direction = source.DIRECCION;
            resellerDto.Province = new ProvinciaDto();
            resellerDto.Province.Code = source.PROVINCIA;
            resellerDto.Fax = source.FAX;
            resellerDto.Email = source.EMAIL;
            resellerDto.CellPhone = source.MOVIL;
            resellerDto.StartDate = source.FECHALTA;
            resellerDto.LeaveDate = source.FECHABAJA;
            resellerDto.Web = source.WEB;
            return resellerDto;
        }
    }


    /// <summary>
    /// ContactsCOMI and mapper field.
    /// </summary>
    public class ContactsComi : ITypeConverter<ContactsDto, CONTACTOS_COMI>
    {
        public CONTACTOS_COMI Convert(ContactsDto source, CONTACTOS_COMI destination, ResolutionContext context)
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
            comiContact.ULTMODI  = DateTime.Now.ToString("yyyyMMddHHmmss");
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
    public class OrigenConverter : ITypeConverter<ORIGEN, OrigenDto>
    {
        public OrigenDto Convert(ORIGEN source, OrigenDto destination, ResolutionContext context)
        {
            OrigenDto origenDto = new OrigenDto();
            origenDto.Code = source.NUM_ORIGEN;
            origenDto.Name = source.NOMBRE;
            return origenDto;
        }
    }
    /// <summary>
    /// POCO to Dto converter for the language domain object
    /// </summary>
    public class LanguageConverter : ITypeConverter<IDIOMAS, LanguageDto>
    {
        public LanguageDto Convert(IDIOMAS source, LanguageDto destination, ResolutionContext context)
        {
            LanguageDto languageDto = new LanguageDto();
            languageDto.Codigo = source.CODIGO.ToString();
            languageDto.Nombre = source.NOMBRE;
            languageDto.CodeId = source.CODIGO.ToString();
            return languageDto;
        }
    }
    /// <summary>
    /// POCO to Dto converter for the key ppto object
    /// </summary>
    public class ClavePtoConverter : ITypeConverter<CLAVEPTO, ClavePtoDto>
    {
        public ClavePtoDto Convert(CLAVEPTO source, ClavePtoDto destination, ResolutionContext context)
        {
            ClavePtoDto clavePto = new ClavePtoDto();
            clavePto.Numero = source.COD_CLAVE;
            clavePto.Nombre = source.NOMBRE;
            return clavePto;
        }
    }
    /// <summary>
    /// POCO to Dto converter for the commission type object
    /// </summary>
    public class TipoCommisionConverter : ITypeConverter<TIPOCOMI, CommissionTypeDto>
    {
        public CommissionTypeDto Convert(TIPOCOMI source, CommissionTypeDto destination, ResolutionContext context)
        {
            CommissionTypeDto commisiDto = new CommissionTypeDto();
            commisiDto.Codigo = source.NUM_TICOMI;
            commisiDto.Nombre = source.NOMBRE;
            return commisiDto;
        }
    }

    /// <summary>
    /// POCO to Dto converter for the commission type object
    /// </summary>
    public class TipoCommisionBackConverter : ITypeConverter<CommissionTypeDto, TIPOCOMI>
    {
        /// <summary>
        /// Conversion from source to destination
        /// </summary>
        /// <param name="source">Commission agent source.</param>
        /// <param name="destination">Commission agent destination.</param>
        /// <param name="context">Resolution context.</param>
        /// <returns></returns>
        public TIPOCOMI Convert(CommissionTypeDto source, TIPOCOMI destination, ResolutionContext context)
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
    public class BranchesToComiDelega : ITypeConverter<BranchesDto, COMI_DELEGA>
    {
        public COMI_DELEGA Convert(BranchesDto source, COMI_DELEGA destination, ResolutionContext context)
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
    public class VisitaCommissionConverter : ITypeConverter<VisitasComiPoco, VisitsDto>
    {
        public VisitsDto Convert(VisitasComiPoco source, VisitsDto destination, ResolutionContext context)
        {
            VisitsDto visitsDto = new VisitsDto();
            visitsDto.ClientId = source.VisitClientId;
            visitsDto.ContactId = source.ContactId;
            visitsDto.ContactName = source.ContactName;
            visitsDto.Date = source.VisitDate;
            visitsDto.SellerId = source.ResellerId;
            visitsDto.VisitId = source.VisitId;
            visitsDto.VisitType = new VisitTypeDto();
            visitsDto.VisitType.Code = source.VisitTypeId;
            visitsDto.VisitType.Name = source.VisitTypeName;
            visitsDto.VisitType.LastModification = source.VisitTypeLastModification;
            visitsDto.VisitType.User = source.VisitTypeUser;
            visitsDto.SellerSource = new ResellerDto();
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

    public class ActivityConverter : ITypeConverter<ACTIVI, ActividadDto>
    {
        public ActividadDto Convert(ACTIVI source, ActividadDto destination, ResolutionContext context)
        {
            ActividadDto actividad = new ActividadDto();
            actividad.Codigo = source.NUM_ACTIVI;
            actividad.Nombre = source.NOMBRE;
            return actividad;

        }
    }
    public class VisitComiToVisit: ITypeConverter<VisitasComiPoco, VISITAS_COMI>
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
            return comiVisita;
        }
    }
    public class BrandVehicle2Poco : ITypeConverter<BrandVehicleDto, MARCAS>
    {
        public MARCAS Convert(BrandVehicleDto source, MARCAS destination, ResolutionContext context)
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
    public class Poco2BrandVehicle : ITypeConverter<MARCAS, BrandVehicleDto>
    {
        public BrandVehicleDto Convert(MARCAS source, BrandVehicleDto destination, ResolutionContext context)
        {
            BrandVehicleDto brandVehicleDto = new BrandVehicleDto();
            brandVehicleDto.CodeId = source.CODIGO;
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
        private static IMapper BuildMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
            cfg.CreateMap<PROPIE, OwnerDto>().ConvertUsing(new PropieToOwnerDtoConverter());
            cfg.CreateMap<TIPOCOMI, CommissionTypeDto>().ConvertUsing(new TipoCommisionConverter());
            cfg.CreateMap<CommissionTypeDto, TIPOCOMI>().ConvertUsing(new TipoCommisionBackConverter());
            cfg.CreateMap<PROVINCIA, ProvinciaDto>().ConvertUsing(new ProvinciaConverter());
            cfg.CreateMap<ProvinciaDto, PROVINCIA>().ConvertUsing(new ProvinciaConverterToPOCO());
            cfg.CreateMap<Country, CountryDto>().ConvertUsing(new CountryConverter());
            cfg.CreateMap<CountryDto, Country>().ConvertUsing(new Country2PocoConverter());
            cfg.CreateMap<OFICINAS, OfficeDtos>().ConvertUsing(new OfficeConverter());
            cfg.CreateMap<ZONAOFI, ZonaOfiDto>().ConvertUsing(new ZonaOfiConverter());
            cfg.CreateMap<OfficeDtos, OFICINAS>().ConvertUsing(new OfficeConverterBack());
            cfg.CreateMap<ComisioDto, COMISIO>();
            cfg.CreateMap<COMISIO, ComisioDto>();
            cfg.CreateMap<PETICION, ReservationRequestDto>();
            cfg.CreateMap<ReservationRequestDto, PETICION>();
            cfg.CreateMap<RequestReasonDto, MOPETI>().ConvertUsing(src =>
            {
                var newmo = new MOPETI();
                newmo.CODIGO = src.Code;
                newmo.NOMBRE = src.Name;
                newmo.ULTMODI = src.LastModification;
                newmo.USUARIO = src.CurrentUser;
                return newmo;
            });
                cfg.CreateMap<MOPETI, RequestReasonDto>().ConvertUsing(src =>
                {
                    var newmo = new RequestReasonDto();
                    newmo.Code = src.CODIGO;
                    newmo.Name= src.NOMBRE;
                    newmo.CodeId = src.CODIGO;
                    newmo.LastModification = src.ULTMODI;
                    newmo.CurrentUser = src.USUARIO;
                    return newmo;
                });
                cfg.CreateMap<VisitasComiPoco, VISITAS_COMI>().ConvertUsing(new VisitComiToVisit());
            cfg.CreateMap<PRODUCTS, ProductsDto>().ConvertUsing(new ProductsConverter());
            cfg.CreateMap<MERCADO, MercadoDto>().ConvertUsing(new MercadoConverter());
            cfg.CreateMap<MercadoDto, MERCADO>().ConvertUsing(new Poco2MercadoConverter());
            cfg.CreateMap<NEGOCIO, BusinessDto>().ConvertUsing(new NegocioConverter());
            cfg.CreateMap<VENDEDOR, ResellerDto>().ConvertUsing(new VendedorConverter());
            cfg.CreateMap<ORIGEN, OrigenDto>().ConvertUsing(new OrigenConverter());
            cfg.CreateMap<CLAVEPTO, ClavePtoDto>().ConvertUsing(new ClavePtoConverter());
            cfg.CreateMap<IDIOMAS, LanguageDto>().ConvertUsing(new LanguageConverter());
            cfg.CreateMap<ContactsDto, ProContactos>().ConvertUsing(new ContactToProContactosConverter());
            cfg.CreateMap<VisitasComiPoco, VisitsDto>().ConvertUsing(new VisitaCommissionConverter());
            cfg.CreateMap<ComiDelegaPoco, BranchesDto>().ConvertUsing(new BranchesConverter());
            cfg.CreateMap<BranchesDto, COMI_DELEGA>().ConvertUsing(new BranchesToComiDelega());
            cfg.CreateMap<BranchesDto, cliDelega>().ConvertUsing(new BranchesToCliDelega());
            cfg.CreateMap<CliDelegaPoco, BranchesDto>().ConvertUsing(new ClientBranchesConverter());
            cfg.CreateMap<ContactsComiPoco, ContactsDto>().ConvertUsing(new ContactsConverter());
            cfg.CreateMap<ContactsDto, CONTACTOS_COMI>().ConvertUsing(new ContactsComi());
            cfg.CreateMap<CONTACTOS_COMI, ContactsDto>().ConvertUsing(new ContactsComiToDto());
            cfg.CreateMap<MARCAS, BrandVehicleDto>().ConvertUsing(new Poco2BrandVehicle());
            cfg.CreateMap<CLIENTES1, ClientDto>().ConvertUsing(new ClientToClientes1());
            cfg.CreateMap<CLIENTES2, ClientDto>().ConvertUsing(new ClientToClientes2());
            cfg.CreateMap<ClientDto, CLIENTES1>().ConvertUsing(new ClientDtoToClientes1());
            cfg.CreateMap<ClientDto, CLIENTES2>().ConvertUsing(new ClientDtoToClientes2());
            cfg.CreateMap<ACTIVI, ActividadDto>().ConvertUsing(new ActivityConverter());
            cfg.CreateMap<BrandVehicleDto, MARCAS>().ConvertUsing(new BrandVehicle2Poco());
            cfg.CreateMap<ACTIVEHI, ActividadDto>().ConvertUsing(src =>
            {
                var actividad = new ActividadDto
                {
                    Codigo = src.NUM_ACTIVEHI,
                    Nombre = src.NOMBRE
                };
                return actividad;
            });
                cfg.CreateMap<FareDto, NTARI>().ConvertUsing(src =>
                {
                    var fare = new NTARI();
                    fare.CODIGO = src.Code;
                    fare.NOMBRE = src.Name;
                    fare.COD_PROMO = src.PromotionCode;
                    fare.ULTMODI = src.LastModification;
                    fare.USUARIO = src.CurrentUser;
                    return fare;

                });
                cfg.CreateMap<NTARI, FareDto>().ConvertUsing(src =>
                {
                    var fare = new FareDto();
                    fare.Code = src.CODIGO;
                    fare.Name = src.NOMBRE;
                    fare.PromotionCode = src.COD_PROMO;
                    fare.LastModification = src.ULTMODI;
                    fare.CurrentUser = src.USUARIO;
                    return fare;
                });

                cfg.CreateMap<InvoiceDto, FACTURAS>().ConvertUsing(src =>
            {
                var value = new FACTURAS();
                var genericConverter = new GenericConverter<InvoiceDto, FACTURAS>();

                value = genericConverter.Convert(src, null, null);

                return value;
            });
            cfg.CreateMap<FACTURAS, InvoiceDto>().ConvertUsing(src =>
            {
                var genericConverter = new GenericConverter<FACTURAS, InvoiceDto>();
                var value = genericConverter.Convert(src, null, null);

                return value;
            });

            cfg.CreateMap<DELEGA, DelegaContableDto>().ConvertUsing(src =>
            {
                var generic = new DelegaContableDto
                {
                    Code = src.NUM_DELEGA,
                    Name = src.NOMBRE
                };
                return generic;
            });
            cfg.CreateMap<DelegaContableDto, DELEGA>().ConvertUsing(src =>
            {
                var generic = new DELEGA
                {
                    NUM_DELEGA = src.Code,
                    NOMBRE = src.Name
                };
                return generic;
            });
                cfg.CreateMap<BookingPoco, BookingDto>();

                cfg.CreateMap<CONTRATOS1, ContractDto>().ConvertUsing(src =>
                {
                    var generic = new ContractDto()
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
                cfg.CreateMap<ContractDto, CONTRATOS1>().ConvertUsing(src =>
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
                cfg.CreateMap<LIRESER, BookingItemsDto>().ConvertUsing(src=>
                {
                    var reservaItem = new BookingItemsDto()
                    {
                        Number = src.NUMERO,
                        BookingKey = src.CLAVE_LR,
                        Bill = src.FACTURAR,
                        Concept =  src.CONCEPTO,
                        Cost = src.COSTE,
                        CurrentUser = src.USUARIO,
                        Days = src.DIAS,
                        Desccon = src.DESCCON,
                        Discount = src.DTO

                    };
                    reservaItem.LastModification = src.ULTMODI;
                    return reservaItem;

                });
                cfg.CreateMap<BookingItemsDto, LIRESER>().ConvertUsing(src=>
                {
                    var lineaReservation = new LIRESER
                    {
                        NUMERO = src.Number,
                        CLAVE_LR = src.BookingKey,
                        FACTURAR = src.Bill,
                        CONCEPTO = src.Concept,
                        COSTE = src.Cost,
                        USUARIO = src.CurrentUser,
                        DIAS = src.Days,
                        DESCCON = src.Desccon,
                        DTO = src.Discount,
                        ULTMODI = src.LastModification

                };
                    return lineaReservation;
                });
                cfg.CreateMap<LIFAC, InvoiceSummaryDto>().ConvertUsing(src =>
                {
                    var opciones = 0;
                    if (src.CONCEPTO_LIF.HasValue)
                    {
                        opciones = src.CONCEPTO_LIF.Value;

                    }
                    var invoiceItem = new InvoiceSummaryDto
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
                cfg.CreateMap<InvoiceSummaryDto, LIFAC>().ConvertUsing(src =>
                {
                    var opciones = src.Opciones;
                    var invoiceItem = new LIFAC
                    {
                        SUBTOTAL_LIF = src.Subtotal,
                        EXPEDIENTE_LIF = src.FileNumber,
                        DTO_LIF =  src.Discount,
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
                        if ((parsed) && (clavelf!=0))
                        {
                            invoiceItem.CLAVE_LF = clavelf;
                        }

                    }

                    return invoiceItem;
                });
                cfg.CreateMap<LIFAC, InvoiceItem>();
                cfg.CreateMap<InvoiceItem, LIFAC>();
                cfg.CreateMap<CurrenciesDto, CURRENCIES>().ConvertUsing(
                    src =>
                    {
                        var currencies = new CURRENCIES
                        {
                            CODIGO_CUR = src.Code,
                            NOMBRE_CUR = src.Name
                        };
                        return currencies;
                    });
                cfg.CreateMap<CURRENCIES, CurrenciesDto>().ConvertUsing(
                    src =>
                    {
                        var currencies = new CurrenciesDto
                        {
                            Code = src.CODIGO_CUR,
                            Name = src.NOMBRE_CUR
                        };
                        return currencies;
                    });

                cfg.CreateMap<CurrencyDto, DIVISAS>().ConvertUsing(
                   src =>
                   {
                       var currencies = new DIVISAS
                       {
                           CODIGO = src.Codigo,
                           NOMBRE = src.Nombre
                       };
                       return currencies;
                   });
                cfg.CreateMap<DIVISAS, CurrencyDto>().ConvertUsing(
                    src =>
                    {
                        var currencies = new CurrencyDto
                        {
                            Codigo = src.CODIGO,
                            Nombre = src.NOMBRE
                        };
                        return currencies;
                    });

                cfg.CreateMap<BrandVehicleDto, MARCAS>().ConvertUsing(src =>
                {
                    var marcas = new MARCAS();
                    marcas.CODIGO = src.Code;
                    marcas.NOMBRE = src.Name;
                    return marcas;
                });
                cfg.CreateMap<MARCAS, BrandVehicleDto>().ConvertUsing(src =>
                {
                    var marcas = new BrandVehicleDto();
                    marcas.Code = src.CODIGO;
                    marcas.Name = src.NOMBRE;
                    return marcas;
                });
                cfg.CreateMap<PICTURES, PictureDto>();
                cfg.CreateMap<ColorDto, COLORFL>().ConvertUsing(src =>
                {
                    var color = new COLORFL();
                    color.CODIGO = src.Code;
                    color.NOMBRE = src.Name;
                    return color;
                }
                );
                cfg.CreateMap<MODELO, ModelVehicleDto>().ConvertUsing(src =>
                {
                    var model = new ModelVehicleDto();
                    model.Codigo = src.CODIGO;
                    model.Nombre = src.NOMBRE;
                    model.Marca = src.MARCA;
                    model.Categoria = src.CATEGORIA;
                    model.Variante = src.VARIANTE;
                    model.NomeMarca = src.NOMMARCA;
                    return model;
                }
                );
                cfg.CreateMap<ModelVehicleDto, MODELO>().ConvertUsing(src =>
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

                cfg.CreateMap<ACTIVEHI, ActividadDto>().ConvertUsing(src =>
                {
                    var color = new ActividadDto();
                    color.Codigo = src.NUM_ACTIVEHI;
                    color.Nombre = src.NOMBRE;
                    return color;
                }
                );
                cfg.CreateMap<ActividadDto, ACTIVEHI>().ConvertUsing(src =>
                {
                    var color = new ACTIVEHI();
                    color.NUM_ACTIVEHI = src.Codigo;
                    color.NOMBRE = src.Nombre;
                    return color;
                }
                );

                cfg.CreateMap<ClientPoco, ClientSummaryDto>().ConvertUsing(new ClientSummaryConverter());

                cfg.CreateMap<TIPOCOMI, CommissionTypeDto>().ConvertUsing(src =>
                {
                    var tipoComi = new CommissionTypeDto
                    {
                        Codigo = src.NUM_TICOMI,
                        Nombre = src.NOMBRE,
                        LastModification = src.ULTMODI,
                        User = src.USUARIO
                    };
                    return tipoComi;
                });
                cfg.CreateMap<COMISIO, ComisioDto>();
                cfg.CreateMap<cliDelega, BranchesDto>().ConvertUsing(src =>
                {
                    var delegation = new BranchesDto
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

                cfg.CreateMap<Visitas, VisitsDto>().ConvertUsing(src =>
                {
                    var visits = new VisitsDto();
                /*
                tipoComi.Codigo = src.NUM_TICOMI;
                tipoComi.Nombre = src.NOMBRE;
                tipoComi.LastModification = src.ULTMODI;
                tipoComi.User = src.USUARIO;
                */
                    return visits;
                });
                cfg.CreateMap<VisitsDto, VISITAS_COMI>().ConstructUsing(src =>
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
                cfg.CreateMap<MARCAS, BrandVehicleDto>().ConvertUsing(src =>
                {
                    var marcas = new BrandVehicleDto
                    {
                        Code = src.CODIGO,
                        Name = src.NOMBRE,
                        LastModification = src.ULTMODI,
                        User = src.USUARIO
                    };
                    return marcas;
                });

                cfg.CreateMap<SITUACION, CurrentSituationDto>().ConvertUsing(src =>
                {
                    var marcas = new CurrentSituationDto()
                    {
                        Code = src.NUMERO,
                        Name = src.NOMBRE,
                        LastModification = src.ULTMODI,
                        User = src.USUARIO
                    };
                    return marcas;
                });
                cfg.CreateMap<CurrentSituationDto, SITUACION>().ConvertUsing(src =>
                {
                    var marcas = new SITUACION()
                    {
                        NUMERO = src.Code,
                        NOMBRE = src.Name,
                        ULTMODI = src.LastModification,
                        USUARIO = src.User
                    };
                    return marcas;
                });

                cfg.CreateMap<MODELO, ModelVehicleDto>().ConvertUsing(src =>
                {
                    var vehicle = new ModelVehicleDto
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
                cfg.CreateMap<GRUPOS, VehicleGroupDto>().ConvertUsing(
                    src =>
                    {
                        var grupos = new VehicleGroupDto()
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

                cfg.CreateMap<CU1, AccountDto>().ConvertUsing(src =>
                {
                    var accountDto = new AccountDto
                    {
                        Codigo = src.CODIGO,
                        Description = src.DESCRIP,
                        Cuenta = src.CC
                    };
                    return accountDto;
                }

                    );
                cfg.CreateMap<AccountDto, CU1>().ConvertUsing(src =>
                {
                    var accountDto = new CU1
                    {
                        CODIGO = src.Codigo,
                        DESCRIP = src.Description
                    };
                    return accountDto;
                }

                );



                cfg.CreateMap<DIVISAS, CurrencyDto>();
                cfg.CreateMap<MESES, MonthsDto>();

                cfg.CreateMap<FORMAS, PaymentFormDto>();
                cfg.CreateMap<SupplierPoco, PROVEE1>().ConvertUsing<PocoToProvee1>();
                cfg.CreateMap<SupplierPoco, PROVEE2>().ConvertUsing<PocoToProvee2>();
                cfg.CreateMap<ProvinciaDto, PROVINCIA>().ConvertUsing(src =>
                {
                    var provincia = new PROVINCIA
                    {
                        SIGLAS = src.Code,
                        PROV = src.Name
                    };
                    return provincia;
                });
                cfg.CreateMap<IDIOMAS, LanguageDto>().ConvertUsing(src =>
                {
                    var language = new LanguageDto
                    {
                        Nombre = src.NOMBRE,
                        Codigo = Convert.ToString(src.CODIGO)
                    };
                    return language;
                });
                cfg.CreateMap<BANCO, BanksDto>().ConvertUsing(
                    src =>
                    {
                        var banks = new BanksDto
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

                cfg.CreateMap<ProDelega, BranchesDto>().ConvertUsing(src =>
                {
                    var branchesDto = new BranchesDto
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
                    branchesDto.Province = new ProvinciaDto
                    {
                        Code = src.cldIdProvincia
                    };
                    return branchesDto;
                });

                cfg.CreateMap<ProContactos, ContactsDto>().ConvertUsing(src =>
                {
                    var contactDto = new ContactsDto
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





                cfg.CreateMap<TIPOPROVE, SupplierTypeDto>().ConvertUsing(src =>
                {
                    var tipoComi = new SupplierTypeDto();
                    tipoComi.Codigo = src.NUM_TIPROVE;
                    tipoComi.Nombre = src.NOMBRE;
                    return tipoComi;
                });
                cfg.CreateMap<TIPOPROVE, SupplierTypeDto>().ConvertUsing(src =>
                {
                    var model = new SupplierTypeDto
                    {
                        Codigo = src.NUM_TIPROVE,
                        Nombre = src.NOMBRE,
                        UltimaModifica = src.ULTMODI,
                        Usuario = src.USUARIO
                    };
                    return model;
                });
                cfg.CreateMap<SupplierTypeDto, TIPOPROVE>().ConvertUsing(src =>
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
                        var base64EncodedBytes = System.Convert.FromBase64String(src.SERILIZED_DATA);
                        model.XmlBase64 = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);


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
                        model.SERILIZED_DATA = System.Convert.ToBase64String(plainTextBytes);

                    }
                    return model;
                });

                cfg.CreateMap<VEHI_ACC, VehicleToolDto>().ConvertUsing(src =>
                {
                    var model = new VehicleToolDto();

                    if (src == null) return model;
                    model = new VehicleToolDto
                    {
                        Name = src.NOM_ACC,
                        Code = src.COD_ACC.ToString()
                    };
                    return model;
                });
                cfg.CreateMap<VehicleToolDto, VEHI_ACC>().ConvertUsing(src =>
                {
                    var model = new VEHI_ACC();
                    model.COD_ACC = Convert.ToInt32(src.Code);
                    model.NOM_ACC = src.Name;
                    return model;
                });
                cfg.CreateMap<ACTIVEHI, VehicleActivitiesDto>().ConvertUsing(src =>
                {
                    var model = new VehicleActivitiesDto();
                    model.Code = src.NUM_ACTIVEHI;
                    model.Activity = src.NOMBRE;
                    model.LastModification = src.ULTMODI;
                    model.User = src.USUARIO;
                    model.ActivitySigle = src.SIGLAS_ACT;
                    var c = Convert.ToInt16(src.CALCULO);
                    model.Compute = (c == 0);
                    model.ActityAlquiler = src.ACTIVI_ALQ;
                    model.Assurance = src.SEGURO_ANUAL;

                    return model;
                });

                cfg.CreateMap<ProDelegaPoco, BranchesDto>().ConvertUsing(src =>
                {
                    BranchesDto bdto = new BranchesDto();
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
                    var prov = new ProvinciaDto();
                    bdto.Province = prov;
                    prov.Code = src.CP;
                    prov.Name = src.NOM_PROV;
                    bdto.ProvinceSource = prov;
                    return bdto;
                });
                cfg.CreateMap<BranchesDto, ProDelega>().ConvertUsing(src =>
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
                        ProvinciaDto dto = src.ProvinceSource as ProvinciaDto;
                        pdelega.cldCP = dto.Code;
                        pdelega.cldIdProvincia = dto.Code;
                    }
                    pdelega.cldPoblacion = src.City;
                    pdelega.cldMovil = src.CellPhone;
                    pdelega.cldIdProvincia = src.ProvinceId;
                    pdelega.cldObservaciones = src.Notes;
                    return pdelega;
                });
                cfg.CreateMap<ClientPoco, ClientDto>();

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
                cfg.CreateMap<VehicleActivitiesDto, ACTIVEHI>().ConvertUsing(src =>
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
                cfg.CreateMap<VehicleToolDto, VEHI_ACC>().ConvertUsing(src =>
                {
                    var model = new VEHI_ACC();
                    model.COD_ACC = Convert.ToInt32(src.Code);
                    model.NOM_ACC = src.Name;
                    return model;
                });

                cfg.CreateMap<COLORFL, ColorDto>().ConvertUsing(src =>
                {
                    var model = new ColorDto();
                    model.Code = src.CODIGO;
                    model.Name = src.NOMBRE;
                    var colorType = src.TIPOCOLOR;
                    model.NoCoating = colorType == "S";
                    model.PowderCoating = colorType == "M";
                    model.TwoTone = colorType == "B";
                    return model;
                });
                cfg.CreateMap<ColorDto, COLORFL>().ConvertUsing(src =>
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
                cfg.CreateMap<EXTRASVEHI, VehicleExtraDto>().ConvertUsing(src =>
                {
                    var model = new VehicleExtraDto();
                    model.Name = src.NOMBRE;
                    model.Code = src.CODIGO.ToString();
                    model.LastModification = src.ULTMODI;
                    model.User = src.USUARIO;
                    model.Reference = src.REFERENCIA;
                    model.Notes = src.OBS;
                    model.VehicleType = new VehicleTypeDto();
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
                cfg.CreateMap<CliContactsPoco, ContactsDto>().ConvertUsing(src =>
                {
                    var c = new ContactsDto();
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

                cfg.CreateMap<VehicleExtraDto, EXTRASVEHI>().ConvertUsing(src =>
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

                cfg.CreateMap<USO_ALQUILER, RentingUseDto>().ConvertUsing(src =>
                {
                    var model = new RentingUseDto();
                    model.Name = src.NOMBRE;
                    model.Code = src.CODIGO.ToString();
                    model.LastModification = src.ULTMODI;
                    model.User = src.USUARIO;
                    return model;
                });
                cfg.CreateMap<RentingUseDto, USO_ALQUILER>().ConvertUsing(src =>
                {
                    var model = new USO_ALQUILER();
                    model.CODIGO = Convert.ToByte(src.Code);
                    model.NOMBRE = src.Name;
                    model.ULTMODI = src.LastModification;
                    model.USUARIO = src.User;
                    return model;
                });
                cfg.CreateMap<ResellerDto, VENDEDOR>().ConvertUsing(src =>
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
                cfg.CreateMap<OrigenDto, ORIGEN>().ConvertUsing(src =>
                {
                    var model = new ORIGEN();
                    model.NUM_ORIGEN = src.Code;
                    model.NOMBRE = src.Name;
                    model.ULTMODI = src.LastModification;
                    model.USUARIO = src.User;
                    return model;
                });
                cfg.CreateMap<CreditCardDto, TARCREDI>().ConvertUsing(src =>
                {
                    var model = new TARCREDI();
                    model.CODIGO = src.Code;
                    model.NOMBRE = src.Name;
                    model.ULTMODI = src.LastModification;
                    model.USUARIO = src.User;
                    return model;
                });
                cfg.CreateMap<ClientTypeDto, TIPOCLI>().ConvertUsing(src =>
                {
                    var model = new TIPOCLI();
                    model.NUM_TICLI = src.Code;
                    model.NOMBRE = src.Name;
                    model.ULTMODI = src.LastModification;
                    model.USUARIO = src.User;
                    return model;
                });
                cfg.CreateMap<TIPOCLI, ClientTypeDto>().ConvertUsing(src =>
                {
                    var model = new ClientTypeDto();
                    model.Code = src.NUM_TICLI;
                    model.Name = src.NOMBRE;
                    model.User = src.USUARIO;
                    model.LastModification = src.ULTMODI;
                    return model;
                });
                cfg.CreateMap<ClientZoneDto, ZONAS>().ConvertUsing(src =>
                {
                    var model = new ZONAS();
                    model.NUM_ZONA = src.Code;
                    model.NOMBRE = src.Name;
                    model.ULTMODI = src.LastModification;
                    model.USUARIO = src.User;
                    return model;
                });
                cfg.CreateMap<ZONAS, ClientZoneDto>().ConvertUsing(src =>
                {
                    var model = new ClientZoneDto();
                    model.Code = src.NUM_ZONA;
                    model.Name = src.NOMBRE;
                    model.LastModification = src.ULTMODI;
                    model.User = src.USUARIO;
                    return model;
                });
                cfg.CreateMap<VisitTypeDto, TIPOVISITAS>().ConvertUsing(src =>
                {
                    var model = new TIPOVISITAS();
                    model.NOMBRE_VIS = src.Name;
                    model.CODIGO_VIS = src.Code;
                    model.ULTMODI = src.LastModification;
                    model.USUARIO = src.User;
                    return model;
                });
                cfg.CreateMap<TIPOVISITAS, VisitTypeDto>().ConvertUsing(src =>
                {
                    var model = new VisitTypeDto();
                    model.Code = src.CODIGO_VIS;
                    model.Name = src.NOMBRE_VIS;
                    model.User = src.USUARIO;
                    model.LastModification = src.ULTMODI;
                    return model;
                });
                cfg.CreateMap<ContactTypeDto, TIPOCONTACTO_CLI>().ConvertUsing(src =>
                {
                    var model = new TIPOCONTACTO_CLI();
                    model.CODIGO = src.Code;
                    model.NOMBRE = src.Name;
                    model.ULTMODI = src.LastModification;
                    model.USUARIO = src.User;
                    return model;
                });
                cfg.CreateMap<TIPOCONTACTO_CLI, ContactTypeDto>().ConvertUsing(src =>
                {
                    var model = new ContactTypeDto();
                    model.Code = src.CODIGO;
                    model.Name = src.NOMBRE;
                    model.User = src.USUARIO;
                    model.LastModification = src.ULTMODI;
                    return model;
                });
                cfg.CreateMap<TARCREDI, CreditCardDto>().ConvertUsing(src =>
                {
                    var model = new CreditCardDto();
                    model.Code = src.CODIGO;
                    model.Name = src.NOMBRE;
                    model.LastModification = src.ULTMODI;
                    model.User = src.USUARIO;
                    return model;
                });

                cfg.CreateMap<TARJETA_EMP, CompanyCardDto>().ConvertUsing(src =>
                {
                    var model = new CompanyCardDto();
                    model.Code = src.COD_TARJETA;
                    model.Name = src.NOMBRE;
                    model.Conditions = src.CONDICIONES;
                    model.Prefix = src.PREFIJO;
                    model.Price = src.PRECIO;
                    return model;
                });

                cfg.CreateMap<CompanyCardDto, TARJETA_EMP>().ConvertUsing(src =>
                {
                    var model = new TARJETA_EMP();
                    model.COD_TARJETA = src.Code;
                    model.CONDICIONES = src.Conditions;
                    model.PRECIO = src.Price;
                    model.PREFIJO = src.Prefix;
                    model.NOMBRE = src.Name;
                    return model;
                });
                cfg.CreateMap<BANCO, BanksDto>().ConvertUsing(src =>
                 {
                     var model = new BanksDto();
                     model.Code = src.CODBAN;
                     model.Name = src.NOMBRE;
                     model.Swift = src.SWIFT;
                     model.LastModification = src.ULTMODI;
                     return model;
                 });
                cfg.CreateMap<CLAVEPTO, BudgetKeyDto>().ConvertUsing(src =>
                {
                    var model = new BudgetKeyDto();
                    model.Code = src.COD_CLAVE;
                    model.Name = src.NOMBRE;
                    model.LastModification = src.ULTMODI;
                    model.User = src.USUARIO;
                    return model;
                });
                cfg.CreateMap<BudgetKeyDto, CLAVEPTO>().ConvertUsing(src =>
                {
                    var model = new CLAVEPTO();
                    model.COD_CLAVE = src.Code;
                    model.NOMBRE = src.Name;
                    model.ULTMODI = src.LastModification;
                    model.USUARIO = src.User;
                    return model;
                });

                cfg.CreateMap<ChannelDto, CANAL>().ConvertUsing(src =>
                {
                    var model = new CANAL();
                    model.CODIGO = src.Code;
                    model.NOMBRE = src.Name;
                    model.ULTMODI = src.LastModification;
                    model.USUARIO = src.User;
                    return model;
                });
                cfg.CreateMap<CANAL, ChannelDto>().ConvertUsing(src =>
                {
                    var model = new ChannelDto();
                    model.Code = src.CODIGO;
                    model.Name = src.NOMBRE;
                    model.LastModification = src.ULTMODI;
                    model.User = src.USUARIO;
                    return model;
                });
                cfg.CreateMap<TIPO_CARGO, PeoplePositionDto>().ConvertUsing(src =>
                {
                    var model = new PeoplePositionDto();
                    model.Code = src.CODIGO;
                    model.Name = src.NOMBRE;
                    return model;
                });
                cfg.CreateMap<PeoplePositionDto, TIPO_CARGO>().ConvertUsing(src =>
                {
                    var model = new TIPO_CARGO();
                    model.CODIGO = Convert.ToByte(src.Code);
                    model.NOMBRE = src.Name;
                    return model;
                });

                cfg.CreateMap<BLOQUEFAC, InvoiceBlockDto>().ConvertUsing(src =>
                {
                    var model = new InvoiceBlockDto();
                    model.Code = src.CODIGO;
                    model.Name = src.NOMBRE;
                    model.LastModification = src.ULTMODI;
                    model.User = src.USUARIO;
                    return model;
                });
                cfg.CreateMap<InvoiceBlockDto, BLOQUEFAC>().ConvertUsing(src =>
                {
                    var model = new BLOQUEFAC();
                    model.CODIGO = src.Code;
                    model.NOMBRE = src.Name;
                    model.ULTMODI = src.LastModification;
                    model.USUARIO = src.User;
                    return model;
                });
                cfg.CreateMap<BanksDto, BANCO>().ConvertUsing(src =>
                {
                    var model = new BANCO();
                    model.CODBAN = src.Code;
                    model.NOMBRE = src.Name;
                    model.ULTMODI = src.LastModification;
                    model.SWIFT = src.Swift;
                    return model;
                });

                cfg.CreateMap<VIASPEDIPRO, DeliveringWayDto>().ConvertUsing(src =>
                {
                    var model = new DeliveringWayDto();
                    model.Codigo = src.CODIGO.ToString();
                    model.Nombre = src.NOMBRE;
                    model.LastModification = src.ULTMODI;
                    model.User = src.USUARIO;
                    return model;
                });
                cfg.CreateMap<DeliveringWayDto, VIASPEDIPRO>().ConvertUsing(src =>
                {
                    var model = new VIASPEDIPRO();
                    model.CODIGO = byte.Parse(src.Codigo);
                    model.NOMBRE = src.Nombre;
                    model.ULTMODI = src.LastModification ;
                    model.USUARIO = src.User;
                    return model;
                });
                cfg.CreateMap<FORMAS_PEDENT, DeliveringFormDto>().ConvertUsing(src =>
                    {
                        var model = new DeliveringFormDto();
                        model.Codigo = src.CODIGO;
                        model.Nombre = src.NOMBRE;
                        return model;
                    });

                cfg.CreateMap<VehicleProvisionReasonDto, MOT_REPOSTAJE>().ConvertUsing(src =>
                {
                    var model = new MOT_REPOSTAJE();
                    model.COD_MOT = src.Code;
                    model.NOM_MOT = src.Name;
                    return model;
                });


                cfg.CreateMap<CATEGO, VehicleTypeDto>().ConvertUsing(src =>
                {
                    var model = new VehicleTypeDto();
                    model.Code = src.CODIGO;
                    model.Name = src.NOMBRE;
                    model.WebName = src.NOMWEB;
                    model.OfferMargin = src.DIAS_MARGEN;
                    model.LastModification = src.ULTMODI;
                    // model.TerminationDate = src.
                    return model;
                });
                cfg.CreateMap<VehicleTypeDto, CATEGO>().ConvertUsing(src =>
                {
                    var model = new CATEGO();
                    model.CODIGO = src.Code;
                    model.NOMBRE = src.Name;
                    model.NOMWEB = src.WebName;
                    model.DIAS_MARGEN = src.OfferMargin;
                    model.ULTMODI = src.LastModification;
                    return model;
                });

                cfg.CreateMap<DeliveringFormDto, FORMAS_PEDENT>().ConvertUsing(src =>
                {
                    var model = new FORMAS_PEDENT();
                    model.CODIGO = src.Codigo;
                    model.NOMBRE = src.Nombre;
                    return model;
                });
                cfg.CreateMap<PriceConditionDto, TL_CONDICION_PRECIO>().ConvertUsing(src =>
                {
                    var model = new TL_CONDICION_PRECIO();
                    model.CODIGO = src.Codigo;
                    model.NOMBRE = src.Nombre;
                    model.DESCRIPCION = src.Description;
                    return model;
                });
                cfg.CreateMap<SUBLICEN, CompanyDto>().ConvertUsing(new CompanyConverter());
                cfg.CreateMap<CompanyDto, SUBLICEN>().ConvertUsing(new CompanyConverterBack());
                cfg.CreateMap<DIVISAS, CurrencyDto>().ConvertUsing(src =>
                {
                    var model = new CurrencyDto();
                    model.Codigo = src.CODIGO;
                    model.Nombre = src.NOMBRE;
                    return model;
                });
                cfg.CreateMap<BranchesDto, ProDelega>().ConvertUsing(src =>
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
                    if (src.ProvinceSource!=null)
                    {
                        var prov = src.ProvinceSource as ProvinciaDto;
                        if (prov != null)
                        {
                            model.cldIdProvincia = src.ProvinceId;
                        }
                    }
                    return model;
                });
                cfg.CreateMap<ProDelega, BranchesDto>().ConvertUsing(src =>
                {
                    var model = new BranchesDto();
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
                    model.Province = new ProvinciaDto();
                    model.Province.Code = src.cldIdProvincia;
                    var proDto = new ProvinciaDto();
                    proDto.Code = src.cldIdProvincia;
                    model.ProvinceSource = proDto;
                    return model;
                });
                cfg.CreateMap<MESES, MonthsDto>().ConstructUsing(src =>
                {
                    var model = new MonthsDto();
                    model.MES = src.MES;
                    model.NUMERO_MES = src.NUMERO_MES;
                    return model;
                });

                cfg.CreateMap<FORMAS, PaymentFormDto>().ConvertUsing(src =>
                {
                    var model = new PaymentFormDto();
                    model.CodeId = src.CODIGO.ToString();
                    model.Codigo = src.CODIGO;
                    model.Nombre = src.NOMBRE;
                    model.Cuenta = src.CUENTA;
                    model.LastModification = src.ULTMODI;
                    model.User = src.USUARIO;
                    return model;
                });
                cfg.CreateMap<PaymentFormDto, FORMAS>().ConvertUsing(src =>
                {
                    var model = new FORMAS();
                    model.CODIGO = src.Codigo;
                    model.NOMBRE = src.Nombre;
                    model.CUENTA = src.Cuenta;

                    return model;
                });
                //  opt => opt.Condition((src, dest, sourceMember) => sourceMember != null)
                cfg.CreateMap<VehiclePoco, VehicleDto>().ForAllMembers(opt => opt.Condition((src, dest, sourceMember) => sourceMember != null));
                // .ForAllMembers(opt => opt.Condition(srs => !srs.IsSourceValueNull));
                cfg.CreateMap<VehicleDto, VehiclePoco>();
                cfg.CreateMap<PICTURES, PictureDto>();
                cfg.CreateMap<VehiclePoco, VEHICULO1>().ConvertUsing<PocoToVehiculo1>();
                cfg.CreateMap<VehiclePoco, VEHICULO2>().ConvertUsing<PocoToVehiculo2>();
                cfg.CreateMap<BrandVehicleDto, MARCAS>().ConvertUsing(src =>
                {
                    var marcas = new MARCAS();
                    marcas.CODIGO = src.Code;
                    marcas.NOMBRE = src.Name;
                    return marcas;
                });
                // _vehicleMapper.Map<IEnumerable<PICTURES>, IEnumerable<PictureDto>>(pictureResult);
                cfg.CreateMap<MARCAS, BrandVehicleDto>().ConvertUsing(src =>
                {
                    var marcas = new BrandVehicleDto();
                    marcas.Code = src.CODIGO;
                    marcas.Name = src.NOMBRE;
                    return marcas;
                });
                cfg.CreateMap<PICTURES, PictureDto>();
                cfg.CreateMap<ColorDto, COLORFL>().ConvertUsing(src =>
                {
                    var color = new COLORFL();
                    color.CODIGO = src.Code;
                    color.NOMBRE = src.Name;
                    return color;
                }
                );
                cfg.CreateMap<COLORFL, ColorDto>().ConvertUsing(src =>
                {
                    var color = new ColorDto();
                    color.Code = src.CODIGO;
                    color.Name = src.NOMBRE;
                    return color;
                }
                );

                cfg.CreateMap<MODELO, ModelVehicleDto>().ConvertUsing(src =>
                {
                    var model = new ModelVehicleDto();
                    model.Codigo = src.CODIGO;
                    model.Nombre = src.NOMBRE;
                    model.Marca = src.MARCA;
                    model.Categoria = src.CATEGORIA;
                    model.Variante = src.VARIANTE;
                    model.NomeMarca = src.NOMMARCA;
                    return model;
                }
                );
                cfg.CreateMap<ModelVehicleDto, MODELO>().ConvertUsing(src =>
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

                cfg.CreateMap<ACTIVEHI, ActividadDto>().ConvertUsing(src =>
                {
                    var color = new ActividadDto();
                    color.Codigo = src.NUM_ACTIVEHI;
                    color.Nombre = src.NOMBRE;
                    return color;
                }
                );
                cfg.CreateMap<ActividadDto, ACTIVEHI>().ConvertUsing(src =>
                {
                    var color = new ACTIVEHI();
                    color.NUM_ACTIVEHI = src.Codigo;
                    color.NOMBRE = src.Nombre;
                    return color;
                }
                );


                cfg.CreateMap<InvoiceBlockDto, BLOQUEFAC>().ConvertUsing(src =>
                {
                    var model = new BLOQUEFAC();
                    model.CODIGO = src.Code;
                    model.NOMBRE = src.Name;
                    return model;
                });


                cfg.CreateMap<POBLACIONES, CityDto>().ConvertUsing(src =>
                {
                    var model = new CityDto();
                    model.CodeId = src.CP;
                    model.Code = src.CP;
                    model.Poblacion = src.POBLA;
                    model.Pais = src.PAIS;
                    model.Country = new CountryDto();
                    model.Country.Code = src.PAIS;
                    return model;
                });
                cfg.CreateMap<SUBLICEN, CompanyDto>().ConvertUsing(
                  new CompanyConverter());
                cfg.CreateMap<CompanyDto, SUBLICEN>().ConvertUsing(
                  new CompanyConverterBack());
                cfg.CreateMap<CU1, AccountDto>().ConvertUsing(src =>
                {
                    var model = new AccountDto();
                    model.CodeId = src.CODIGO.ToString();
                    model.Codigo = src.CODIGO;
                    model.Description = src.DESCRIP;
                    model.Cuenta = src.CC;
                    return model;
                });
                cfg.CreateMap<BusinessDto, NEGOCIO>().ConvertUsing(src =>
                {
                    var model = new NEGOCIO();
                    model.CODIGO = src.Code;
                    model.NOMBRE = src.Name;
                    model.ULTMODI = src.LastModification;
                    model.USUARIO = src.User;
                    return model;
                });
                cfg.CreateMap<PERCARGOS, PersonalPositionDto>().ConvertUsing(new PercargosConverter());
                cfg.CreateMap<PersonalPositionDto, PERCARGOS>().ConvertUsing(new PersonalPositioDtoConverter());
                cfg.CreateMap<{DtoTypeName1}Dto, {TableName}>();
            });
            var mappingConfig = config.CreateMapper();

            return mappingConfig;
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
    internal class PropieToOwnerDtoConverter : ITypeConverter<PROPIE, OwnerDto>
    {
        public OwnerDto Convert(PROPIE source, OwnerDto destination, ResolutionContext context)
        {
            OwnerDto model = new OwnerDto();
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

    internal class BranchesToCliDelega : ITypeConverter<BranchesDto, cliDelega>
    {


        public cliDelega Convert(BranchesDto src, cliDelega destination, ResolutionContext context)
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

    class ClientSummaryConverter : ITypeConverter<ClientPoco, ClientSummaryDto>
    {
        public ClientSummaryConverter()
        {
        }
        public ClientSummaryDto Convert(ClientPoco source, ClientSummaryDto destination, ResolutionContext context)
        {
            var clients = new ClientSummaryDto();
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


    public class HolidayConverter : ITypeConverter<FESTIVOS_OFICINA, HolidayDto>
    {
        public HolidayDto Convert(FESTIVOS_OFICINA source, HolidayDto destination, ResolutionContext context)
        {
            var holiday = new HolidayDto
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

    public class HolidayConverterBack : ITypeConverter<HolidayDto, FESTIVOS_OFICINA>
    {
        public FESTIVOS_OFICINA Convert(HolidayDto source, FESTIVOS_OFICINA destination, ResolutionContext context)
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
    /// Office converter from OFINAS to OfficeDtos.
    /// </summary>
    public class OfficeConverter : ITypeConverter<OFICINAS, OfficeDtos>
    {
        /// <summary>
        ///  Fill the time table.
        /// </summary>
        /// <param name="i">Index</param>
        /// <param name="ofi">Office data trasnfer object</param>
        /// <param name="oficinas">Oficinas</param>
        private void FillTimeTable(int i, ref OfficeDtos ofi, OFICINAS oficinas)
        {
            ofi.TimeTable = new List<DailyTime>();
            Dictionary<int, Func<OfficeDtos, OFICINAS, OfficeDtos>> dictionary = new Dictionary<int, Func<OfficeDtos, OFICINAS, OfficeDtos>>() {
                    { 0, (officeDto, office) =>
                          {
                              var daily = new DailyTime();
                              daily.Morning = new OfficeOpenClose();
                              daily.Afternoon = new OfficeOpenClose();
                              daily.Morning.Open = office.ABRE_MA_LUNES;
                              daily.Afternoon.Open = office.ABRE_TA_LUNES;
                              daily.Afternoon.Close = office.CIERRA_TA_LUNES;
                              daily.Morning.Close = office.CIERRA_MA_LUNES;
                              officeDto.TimeTable.Add(daily);
                              return officeDto;
                          }
                    },
                    { 1, (officeDto, office) =>
                          {
                              var daily = new DailyTime();
                              daily.Morning = new OfficeOpenClose();
                              daily.Afternoon = new OfficeOpenClose();
                              daily.Morning.Open = office.ABRE_MA_MARTES;
                              daily.Afternoon.Open = office.ABRE_TA_MARTES;
                              daily.Afternoon.Close = office.CIERRA_TA_MARTES;
                              daily.Morning.Close = office.CIERRA_MA_MARTES;
                              officeDto.TimeTable.Add(daily);
                              return officeDto;


                          }
                    },
                    { 2, (officeDto, office) =>
                          {

                              var daily = new DailyTime();
                              daily.Morning = new OfficeOpenClose();
                              daily.Afternoon = new OfficeOpenClose();
                              daily.Morning.Open = office.ABRE_MA_MIERCOLES;
                              daily.Afternoon.Open = office.ABRE_TA_MIERCOLES;
                              daily.Afternoon.Close = office.CIERRA_TA_MIERCOLES;
                              daily.Morning.Close = office.CIERRA_MA_MIERCOLES;
                              officeDto.TimeTable.Add(daily);
                              return officeDto;

                                                        }
                    },
                    { 3, (officeDto, office) =>
                          {

                              var daily = new DailyTime();
                              daily.Morning = new OfficeOpenClose();
                              daily.Afternoon = new OfficeOpenClose();
                              daily.Morning.Open = office.ABRE_MA_JUEVES;
                              daily.Afternoon.Open = office.ABRE_TA_JUEVES;
                              daily.Afternoon.Close = office.CIERRA_TA_JUEVES;
                              daily.Morning.Close = office.CIERRA_MA_JUEVES;
                              officeDto.TimeTable.Add(daily);
                              return officeDto;

                          }
                    },
                    { 4, (officeDto, office) =>
                          {


                              var daily = new DailyTime();
                              daily.Morning = new OfficeOpenClose();
                              daily.Afternoon = new OfficeOpenClose();
                              daily.Morning.Open = office.ABRE_MA_VIERNES;
                              daily.Afternoon.Open = office.ABRE_TA_VIERNES;
                              daily.Afternoon.Close = office.CIERRA_TA_VIERNES;
                              daily.Morning.Close = office.CIERRA_MA_VIERNES;
                              officeDto.TimeTable.Add(daily);
                              return officeDto;


                          }
                    },
                    { 5, (officeDto, office) =>
                          {

                              var daily = new DailyTime();
                              daily.Morning = new OfficeOpenClose();
                              daily.Afternoon = new OfficeOpenClose();
                              daily.Morning.Open = office.ABRE_MA_SABADO;
                              daily.Afternoon.Open = office.ABRE_TA_SABADO;
                              daily.Afternoon.Close = office.CIERRA_TA_SABADO;
                              daily.Morning.Close = office.CIERRA_MA_SABADO;
                              officeDto.TimeTable.Add(daily);
                              return officeDto;

                          }
                    },
                    { 6, (officeDto, office) =>
                          {
                              var daily = new DailyTime();
                              daily.Morning = new OfficeOpenClose();
                              daily.Afternoon = new OfficeOpenClose();
                              daily.Morning.Open = office.ABRE_MA_DOMINGO;
                              daily.Afternoon.Open = office.ABRE_TA_DOMINGO;
                              daily.Afternoon.Close = office.CIERRA_TA_DOMINGO;
                              daily.Morning.Close = office.CIERRA_MA_DOMINGO;
                              officeDto.TimeTable.Add(daily);
                              return officeDto;

                          }
                    }
                };
            Func<OfficeDtos, OFICINAS, OfficeDtos> f;
            var hasFunc = dictionary.TryGetValue(i, out f);

            if (hasFunc)
            {
                ofi = f.Invoke(ofi, oficinas);
            }
        }
        public OfficeDtos Convert(OFICINAS source, OfficeDtos destination, ResolutionContext context)
        {
            var office = new OfficeDtos();
            var gc = new GenericConverter<OFICINAS, OfficeDtos>();
            office = gc.Convert(source, office, context);
            for (var i = 0; i < 7; ++i)
            {
                FillTimeTable(i, ref office, source);
            }
            office.Codigo = source.CODIGO;
            office.Nombre = source.NOMBRE;
            office.LastModification = source.ULTMODI;
            office.User = source.USUARIO;
            office.POBLACION = source.POBLACION;
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
    public class OfficeConverterBack : ITypeConverter<OfficeDtos, OFICINAS>
    {
        /// <summary>
        ///  Convert an office to a destination office.
        /// </summary>
        /// <param name="source">Office to use.</param>
        /// <param name="destination">Destination office to use.</param>
        /// <param name="context">Context to be used.</param>
        /// <returns>Return the current office.</returns>
        public OFICINAS Convert(OfficeDtos source, OFICINAS destination, ResolutionContext context)
        {
            OFICINAS office = new OFICINAS();
            GenericBackConverter<OfficeDtos, OFICINAS> gc = new GenericBackConverter<OfficeDtos, OFICINAS>();
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
            return supplier;
        }
    }
}
