using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows;
using AutoMapper;
using DataAccessLayer.DataObjects;
using KarveDataServices.DataTransferObject;

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
            prov.Name = source.PROV;
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
            dto.CountryName = source.PAIS;
            return dto;
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
            contactsDto.ContactsKeyId = source.COMISIO;
            contactsDto.ContactId = source.CONTACTO.ToString();
            contactsDto.ContactName = source.NOM_CONTACTO;
            contactsDto.Nif = source.NIF;
            contactsDto.Responsability = source.percargos.NOMBRE;
            contactsDto.Telefono = source.TELEFONO;
            contactsDto.Movil = source.MOVIL;
            contactsDto.Fax = source.FAX;
            contactsDto.Email = source.EMAIL;
            contactsDto.User = source.USUARIO;
            contactsDto.LastMod = source.ULTMODI;
            contactsDto.CurrentDelegation = source.comiDelega.cldDelegacion;
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
            branchesDto.Branch = source.cldDelegacion;
            branchesDto.Province.Code = source.PROV.SIGLAS;
            branchesDto.Province.Name = source.PROV.PROV;
            branchesDto.Province.Country = source.PROV.PAIS;
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
            contacts.ccoCargo = source.Responsability;
            contacts.ccoIdCliente = source.ContactsKeyId;
            
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
           /*
            branchesDto.BranchId = source.cldIdDelega.ToString();
            branchesDto.Branch = source.cldDelegacion;
            branchesDto.Province.Code = source.PROV.SIGLAS;
            branchesDto.Province.Name = source.PROV.PROV;
            branchesDto.Province.Country = source.PROV.PAIS;
            branchesDto.Address = source.cldDireccion1;
            branchesDto.Address2 = source.cldDireccion2;
            branchesDto.Phone = source.cldTelefono1;
            branchesDto.Phone2 = source.cldTelefono2;
            branchesDto.Email = source.cldEMail;
            branchesDto.City = source.cldPoblacion;
           */
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
            destinationDto.Name = source.CODIGO;
            destinationDto.Code = source.NOMBRE;
            return destinationDto;
        }
    }
    /// <summary>
    /// POCO to Dto converter for the client domain object
    /// </summary>
    public class ClientesConverter : ITypeConverter<CLIENTES1, ClientesDto>
    {
        public ClientesDto Convert(CLIENTES1 source, ClientesDto destination, ResolutionContext context)
        {
            ClientesDto clientesDto = new ClientesDto();
            clientesDto.Numero = source.NUMERO_CLI;
            clientesDto.Nombre = source.NOMBRE;
            clientesDto.Movil = source.MOVIL;
            return clientesDto;
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
            businessDto.Code= source.CODIGO;
            businessDto.Name = source.NOMBRE;
            return businessDto;
        }
    }
    /// <summary>
    /// POCO to Dto converter for the reseller domain object
    /// </summary>
    public class VendedorConverter : ITypeConverter<VENDEDOR, VendedorDto>
    {
        public VendedorDto Convert(VENDEDOR source, VendedorDto destination, ResolutionContext context)
        {
            VendedorDto vendedorDto = new VendedorDto();
            vendedorDto.Numero = source.NUM_VENDE;
            vendedorDto.Nombre = source.NOMBRE;
            vendedorDto.Movil = source.MOVIL;
            return vendedorDto;
        }
    }
    /// <summary>
    /// ContactsCOMI and mapper field.
    /// </summary>
    public class ContactsComi : ITypeConverter<ContactsDto, CONTACTOS_COMI>
    {
        public CONTACTOS_COMI Convert(ContactsDto source, CONTACTOS_COMI destination, ResolutionContext context)
        {
            string idComi = "0";
            CONTACTOS_COMI comiContact = new CONTACTOS_COMI();
            IEnumerable<ContactsComiPoco> comiPoco = null;
            if (context.Items.ContainsKey("RefId"))
            {
                idComi = context.Items["RefId"] as string;
            }
            if (context.Items.ContainsKey("POCO"))
            {
                comiPoco =  context.Items["POCO"] as IEnumerable<ContactsComiPoco>;
            }
            int contactIdentifier = Int32.Parse(source.ContactId);
            ContactsComiPoco contacts = comiPoco.FirstOrDefault(c => c.CONTACTO == contactIdentifier);
            comiContact.COMISIO = idComi;
            comiContact.NOM_CONTACTO = source.ContactName;
            comiContact.EMAIL = source.Email;
            comiContact.NOM_CONTACTO = source.ContactName;
            comiContact.DELEGA_CC = contacts?.DELEGA_CC; 
            comiContact.FAX = source.Fax;
            comiContact.CARGO = contacts?.CARGO;
            comiContact.USUARIO = source.User;
            comiContact.ULTMODI = DateTime.Now.ToString();
            comiContact.NIF = source.Nif; 
            comiContact.MOVIL = source.Movil;
            comiContact.FAX = source.Fax;
            comiContact.EMAIL = source.Email;
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
            languageDto.Codigo= source.CODIGO.ToString();
            languageDto.Nombre = source.NOMBRE;
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

            dest.cldEMail = source.Email;
            if (string.IsNullOrEmpty(idComi))
            {
                dest.cldIdCOMI = source.BranchKeyId;
            }
            else
            {
                dest.cldIdCOMI = idComi;
            }
            if (source.Province != null)
            {
                dest.cldIdProvincia = source.Province.Code;
            }
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
            visitsDto.ClientId = source.visIdCliente;
            visitsDto.ContactId = source.visIdContacto;
            visitsDto.ContactName = source.ContactsComi.NOM_CONTACTO;
            visitsDto.Date = source.visFecha;
            visitsDto.SellerId = source.VendedorComi.NOMBRE;
            visitsDto.VisitId = source.visIdVisita;
            visitsDto.VisitType = source.TipoVisitas.NOMBRE_VIS;
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
            comi.COMISIO = source.COMISIO;
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

    public static class MapperField
    {
        private static IMapper Instance = null;
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TIPOCOMI, CommissionTypeDto>().ConvertUsing(new TipoCommisionConverter());
                cfg.CreateMap<PROVINCIA, ProvinciaDto>().ConvertUsing(new ProvinciaConverter());
                cfg.CreateMap<Country, CountryDto>().ConvertUsing(new CountryConverter());
                cfg.CreateMap<OFICINAS, OfficeDtos>().ConvertUsing(new OfficeConverter());
                cfg.CreateMap<ZONAOFI, ZonaOfiDto>().ConvertUsing( new ZonaOfiConverter());
                cfg.CreateMap<PRODUCTS, ProductsDto>().ConvertUsing(new ProductsConverter());
                cfg.CreateMap<MERCADO, MercadoDto>().ConvertUsing(new MercadoConverter());
                cfg.CreateMap<CLIENTES1, ClientesDto>().ConvertUsing(new ClientesConverter());
              //  cfg.CreateMap<CANAL, ChannelDto>().ConvertUsing(new CanalConverter());
                cfg.CreateMap<NEGOCIO, BusinessDto>().ConvertUsing(new NegocioConverter());
                cfg.CreateMap<VENDEDOR, VendedorDto>().ConvertUsing(new VendedorConverter());
                cfg.CreateMap<ORIGEN, OrigenDto>().ConvertUsing(new OrigenConverter());
                cfg.CreateMap<CLAVEPTO, ClavePtoDto>().ConvertUsing(new ClavePtoConverter());
                cfg.CreateMap<IDIOMAS, LanguageDto>().ConvertUsing(new LanguageConverter());
                cfg.CreateMap<ContactsDto, ProContactos>().ConvertUsing(new ContactToProContactosConverter());
                cfg.CreateMap<VisitasComiPoco, VisitsDto>().ConvertUsing(new VisitaCommissionConverter() );
                cfg.CreateMap<ComiDelegaPoco, BranchesDto>().ConvertUsing(new BranchesConverter());
                cfg.CreateMap<BranchesDto, COMI_DELEGA>().ConvertUsing(new BranchesToComiDelega());
                cfg.CreateMap<ContactsComiPoco, ContactsDto>().ConvertUsing(new ContactsConverter());
                cfg.CreateMap<ContactsDto, CONTACTOS_COMI>().ConvertUsing(new ContactsComi());
                cfg.CreateMap<ACTIVI, ActividadDto>().ConvertUsing(new ActivityConverter());
                cfg.CreateMap<OrigenDto, ORIGEN>().ConvertUsing(src =>
                {
                    var model = new ORIGEN();
                    model.NUM_ORIGEN = src.Code;
                    model.NOMBRE = src.Name;
                    return model;
                });
                cfg.CreateMap<BANCO,BanksDto>().ConvertUsing(src =>
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
                    model.Name= src.NOMBRE;
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
                    var model = new  InvoiceBlockDto();
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
                cfg.CreateMap<SUBLICEN, CompanyDto>().ConvertUsing(src =>
                {
                    var model = new CompanyDto();
                    model.Code = src.CODIGO;
                    model.Name = src.NOMBRE;
                    model.CommercialName = src.NOMCOMER;
                    model.Poblacion = src.POBLACION;
                    model.Nif = src.NIF;
                    return model;
                });
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
                    if (src.Province != null)
                    {
                        model.cldIdProvincia = src.Province.Code;
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
                    model.Codigo = src.CODIGO;
                    model.Nombre = src.NOMBRE;
                    model.Cuenta = src.CUENTA;
                    return model;
                });
                cfg.CreateMap<POBLACIONES, CityDto>().ConvertUsing(src =>
                {
                    var model = new CityDto();
                    model.Code = src.CP;
                    model.Poblacion = src.POBLA;
                    model.Pais = src.PAIS;
                    model.Country = new CountryDto();
                    model.Country.Code = src.PAIS;
                    return model;
                });
                cfg.CreateMap<SUBLICEN, CompanyDto>().ConvertUsing(src =>
                {
                    var model = new CompanyDto();
                    model.Code = src.CODIGO;
                    model.Name = src.NOMBRE;
                    model.Nif = src.NIF;
                    model.Poblacion = src.POBLACION;
                    model.CommercialName = src.NOMCOMER;
                    return model;
                });
                cfg.CreateMap<CU1, AccountDto>().ConvertUsing(src =>
                {
                    var model = new AccountDto();
                    model.Codigo = src.CODIGO;
                    model.Description = src.DESCRIP;
                    model.Cuenta = src.CC;
                    return model;
                });
                cfg.CreateMap<BusinessDto, NEGOCIO>().ConvertUsing(src =>
                {
                    var model = new NEGOCIO();
                    model.CODIGO = src.Name;
                    model.NOMBRE = src.Name;
                    model.ULTMODI = src.LastModification;
                    model.USUARIO = src.User;
                    return model;
                });

            });
            if (Instance == null)
            {
                Instance = config.CreateMapper();
            }
            return Instance;
        }
    }


    public class OfficeConverter : ITypeConverter<OFICINAS, OfficeDtos>
    {
        public OfficeDtos Convert(OFICINAS source, OfficeDtos destination, ResolutionContext context)
        {
            OfficeDtos office = new OfficeDtos();
            office.Codigo = source.CODIGO;
            office.Nombre = source.NOMBRE;
            return office;
        }
    }
}

    