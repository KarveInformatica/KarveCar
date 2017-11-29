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
            contactsDto.CommissionId = source.COMISIO;
            contactsDto.ContactId = source.CONTACTO;
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
            branchesDto.BranchId = source.cldIdDelega;
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
            destinationDto.Codigo = source.CODIGO;
            destinationDto.Nombre = source.NOMBRE;
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
    public class CanalConverter : ITypeConverter<CANAL, CanalDto>
    {
        public CanalDto Convert(CANAL source, CanalDto destination, ResolutionContext context)
        {
            CanalDto dto = new CanalDto();
            dto.Canal = source.CODIGO;
            dto.Nombre = source.NOMBRE;
            return dto;
        }
    }
    /// <summary>
    /// POCO to Dto converter for the business shop domain object
    /// </summary>
    public class NegocioConverter : ITypeConverter<NEGOCIO, NegocioDto>
    {
        public NegocioDto Convert(NEGOCIO source, NegocioDto destination, ResolutionContext context)
        {
            NegocioDto negocioDto = new NegocioDto();
            negocioDto.Codigo = source.CODIGO;
            negocioDto.Negocio = source.NOMBRE;
            return negocioDto;
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
            ContactsComiPoco contacts = comiPoco.FirstOrDefault(c => c.CONTACTO == source.ContactId);
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
            origenDto.Numero = source.NUM_ORIGEN;
            origenDto.Nombre = source.NOMBRE;
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
            languageDto.Numero = source.CODIGO;
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
    public class TipoCommisionConverter : ITypeConverter<TIPOCOMISION, CommissionTypeDto>
    {
        public CommissionTypeDto Convert(TIPOCOMISION source, CommissionTypeDto destination, ResolutionContext context)
        {
            CommissionTypeDto commisiDto = new CommissionTypeDto();
            commisiDto.Codigo = source.NUM_SOBREQ;
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
            string idComi = "0";
            if (context.Items.ContainsKey("RefId"))
            {
                idComi = context.Items["RefId"] as string;
            }
            
            COMI_DELEGA dest = new COMI_DELEGA();
            dest.cldDelegacion = source.Branch;
            dest.ULTMODI = DateTime.Now.ToString();
            dest.cldDireccion1 = source.Address;
            dest.cldDireccion2 = source.Address2;
            dest.cldEMail = source.Email;
            dest.cldIdCOMI = idComi;
            dest.cldIdProvincia = source.Province.Code;
            dest.cldPoblacion = source.City;
            dest.cldIdDelega = source.BranchId;
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
                cfg.CreateMap<TIPOCOMISION, CommissionTypeDto>().ConvertUsing(new TipoCommisionConverter());
                cfg.CreateMap<PROVINCIA, ProvinciaDto>().ConvertUsing(new ProvinciaConverter());
                cfg.CreateMap<Country, CountryDto>().ConvertUsing(new CountryConverter());
                cfg.CreateMap<ZONAOFI, ZonaOfiDto>().ConvertUsing( new ZonaOfiConverter());
                cfg.CreateMap<PRODUCTS, ProductsDto>().ConvertUsing(new ProductsConverter());
                cfg.CreateMap<MERCADO, MercadoDto>().ConvertUsing(new MercadoConverter());
                cfg.CreateMap<CLIENTES1, ClientesDto>().ConvertUsing(new ClientesConverter());
                cfg.CreateMap<CANAL, CanalDto>().ConvertUsing(new CanalConverter());
                cfg.CreateMap<NEGOCIO, NegocioDto>().ConvertUsing(new NegocioConverter());
                cfg.CreateMap<VENDEDOR, VendedorDto>().ConvertUsing(new VendedorConverter());
                cfg.CreateMap<ORIGEN, OrigenDto>().ConvertUsing(new OrigenConverter());
                cfg.CreateMap<CLAVEPTO, ClavePtoDto>().ConvertUsing(new ClavePtoConverter());
                cfg.CreateMap<IDIOMAS, LanguageDto>().ConvertUsing(new LanguageConverter());
                cfg.CreateMap<VisitasComiPoco, VisitsDto>().ConvertUsing(new VisitaCommissionConverter() );
                cfg.CreateMap<ComiDelegaPoco, BranchesDto>().ConvertUsing(new BranchesConverter());
                cfg.CreateMap<BranchesDto, COMI_DELEGA>().ConvertUsing(new BranchesToComiDelega());
                cfg.CreateMap<ContactsComiPoco, ContactsDto>().ConvertUsing(new ContactsConverter());
                cfg.CreateMap<ContactsDto, CONTACTOS_COMI>().ConvertUsing(new ContactsComi());
                cfg.CreateMap<ACTIVI, ActividadDto>().ConvertUsing(new ActivityConverter());

                cfg.CreateMap<FORMAS, PaymentFormDto>().ConvertUsing(src =>
                {
                    var model = new PaymentFormDto();
                    model.Codigo = src.CODIGO;
                    model.Nombre = src.NOMBRE;
                    model.Cuenta = src.CUENTA;
                    return model;
                });
                ///  cfg.CreateMap<PROPIE, OwnerDto>().ConvertUsing(new OwnerConverter());

                //  cfg.CreateMap<AGENTES, AgentDto>().ConvertUsing(new AgentConverter());

            });
            if (Instance == null)
            {
                Instance = config.CreateMapper();
            }
            return Instance;
        }
    }

    
}

    