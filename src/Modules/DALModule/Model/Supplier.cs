using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Transactions;
using Dapper;
using DataAccessLayer.DataObjects;
using DesignByContract;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using KarveDapper;
using KarveDataAccessLayer.DataObjects;
using KarveDataServices;
using Model;
using AutoMapper;
using DataAccessLayer.DataObjects.Wrapper;
using DataAccessLayer.Logic;
using KarveCommon.Generic;
using KarveDapper.Extensions;
using NLog;

namespace DataAccessLayer.Model
{


    /// <summary>
    ///  This is the class factory for each vehicle.
    /// </summary>
    public class SupplierFactory
    {
        private readonly ISqlExecutor _sqlExecutor;

        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        ///  This is the queryExecutro factory.
        /// </summary>
        /// <param name="executor"></param>
        private SupplierFactory(ISqlExecutor executor)
        {
            _sqlExecutor = executor;
        }
        /// <summary>
        ///  This is the factory for the commission agent. 
        /// </summary>
        /// <param name="executor">Query executor of the things</param>
        /// <returns></returns>
        public static SupplierFactory GetFactory(ISqlExecutor executor)
        {
            return new SupplierFactory(executor);
        }
        /// <summary>
        /// This returns a new Supplier
        /// </summary>
        /// <returns></returns>
        public ISupplierData NewSupplier(string id)
        {
            logger.Debug("Creating a new supplier with id" + id);
            ISupplierData data = new Supplier(_sqlExecutor, id);
            //SupplierDto dto = new SupplierDto();
            // dto.NUM_PROVEE = id;
            data.Valid = true;
            //data.Value = dto;
            return data;
        }

        

        /// <summary>
        /// This retrieve a commission agent.
        /// </summary>
        /// <param name="fields">Fields to be selected in the db</param>
        /// <param name="commissionId">Commission Id</param>
        /// <returns>A commmission agent data transfer object</returns>
        public async Task<ISupplierData> GetSupplier(IDictionary<string, string> fields, string supplierId)
        {
            Dbc.Requires(fields.Count > 0, "Fields not valid");
            Dbc.Requires(!string.IsNullOrEmpty(supplierId), "SupplierId valid");
            ISupplierData agent = new Supplier(_sqlExecutor);
            bool loaded = await agent.LoadValue(fields, supplierId).ConfigureAwait(false);
            agent.Valid = loaded;
            logger.Debug("Loading a new supplier with id " + supplierId + " Valid " + loaded.ToString());

            return agent;
        }


    }
    public class Supplier : DomainObject, ISupplierData
    {
        // TODO: Craft a query container, query builder.
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private const string TipoProveSelect = "SELECT NUM_TIPROVE as Number, NOMBRE as Name, " +
                                               "USER as Account, " +
                                               "ULTMODI as LastModification FROM TIPOPROVE WHERE NUM_TIPROVE='{0}'";
        private const string ProvinciaSelectAll = "SELECT SIGLAS, PROV, PAIS  FROM PROVINCIA";
        private const string CompanySelect = "SELECT CODIGO, NOMBRE FROM SUBLICEN WHERE CODIGO='{0}'";
        private string _queryCity = "SELECT * FROM POBLACIONES";
        // select * from ProContactos
        private const string LanguageSelect = "SELECT CODIGO,NOMBRE FROM IDIOMAS";
        private const string OfficeSelect =
            " select CODIGO, NOMBRE, SUBLICEN, DIRECCION, POBLACION from oficinas WHERE CODIGO='{0}' AND SUBLICEN='{1}'";
        private const string PaisSelectAll = "SELECT SIGLAS, PAIS FROM PAIS";
        private const string DeleteDelegaciones = "DELETE FROM ProDelega where cldIdCliente='{0}'";
        private const string DeleteContactos = "DELETE FROM ProContactos where ccoIdCliente='{0}'";
        private const string BankSelect = "SELECT CODBAN, NOMBRE FROM BANCO WHERE CODBAN='{0}'";
        private const string AccountSelect = "SELECT CODIGO, DESCRIP FROM CU1";
        private const string PaymentFormSelect = "SELECT CODIGO, NOMBRE FROM FORMAS";
        private const string MonthsSelect = "SELECT NUMERO_MES, MES FROM MESES";
        private const string ViaSelect = "SELECT NUM_VIA, NOMBRE FROM VIAS WHERE NUM_VIA='{0}'";
        private const string CurrencySelect = "SELECT CODIGO, NOMBRE FROM DIVISAS";
        private const string SupplierQuery = "SELECT PROVEE1.NUM_PROVEE as NUM_PROVEE,NIF,TIPO,NOMBRE,DIRECCION,DIREC2,CP," +
                                             "PROVEE2.COMERCIAL,PROVEE2.PREFIJO,PROVEE2.CONTABLE,PROVEE2.FORPA,PROVEE2.PLAZO,PROVEE2.PLAZO2,PROVEE2.PLAZO3," +
                                             "PROVEE2.DIA,PROVEE2.PALBARAN, PROVEE2.INTRACO, PROVEE2.DIA2,PROVEE2.DIA3,PROVEE2.DTO,PROVEE2.PP,PROVEE2.DIVISA,PROVEE2.PALBARAN,PROVEE2.INTRACO," +
                                             "POBLACION,PROV,NACIOPER,TELEFONO,FAX,MOVIL,INTERNET,EMAIL,PERSONA," +
                                             "SUBLICEN,GESTION_IVA_IMPORTA,OFICINA,FBAJA,FALTA,NOTAS,OBSERVA,CTAPAGO,TIPOIVA,MESVACA," +
                                             "MESVACA2,CC,IBAN,BANCO,SWIFT,IDIOMA_PR1,GESTION_IVA_IMPORTA,NOAUTOMARGEN," +
                                             "PROALB_COSTE_TRANSP,EXENCIONES_INT,CTALP,CONTABLE,CUGASTO,RETENCION,CTAPAGO,AUTOFAC_MANTE,CTACP,CTALP,DIR_PAGO,DIR2_PAGO," +
                                             "CP_PAGO,POB_PAGO, PROV_PAGO,PAIS_PAGO,TELF_PAGO,FAX_PAGO, PERSONA_PAGO,MAIL_PAGO,DIR_DEVO," +
                                             "DIR2_DEVO,POB_DEVO,CP_DEVO,PROV_DEVO,PAIS_DEVO,TELF_DEVO,FAX_DEVO,PERSONA_DEVO,MAIL_DEVO, DIR_RECLAMA,DIR2_RECLAMA," +
                                             "CP_RECLAMA,POB_RECLAMA,PROV_RECLAMA,PAIS_RECLAMA,TELF_RECLAMA,FAX_RECLAMA,PERSONA_RECLAMA,MAIL_RECLAMA,VIA,FORMA_ENVIO,CONDICION_VENTA,DIRENVIO6," +
                                             "CTAINTRACOP,ctaintracoPRep FROM PROVEE1 INNER JOIN PROVEE2 ON PROVEE1.NUM_PROVEE = PROVEE2.NUM_PROVEE WHERE NUM_PROVEE='{0}'";

        private ISqlExecutor _sqlExecutor;
        private SupplierPoco _supplierValue;
        private IMapper _supplierMapper;
        private IEnumerable<ISupplierTypeData> _type = new ObservableCollection<ISupplierTypeData>();
        private IEnumerable<AccountDto> _accounts = new ObservableCollection<AccountDto>();
        private IEnumerable<ProvinciaDto> _provinciaDto = new ObservableCollection<ProvinciaDto>();
        private IEnumerable<BanksDto> _banksDtos = new ObservableCollection<BanksDto>();
        private IEnumerable<CountryDto> _countryDtos = new ObservableCollection<CountryDto>();
        private IEnumerable<ViaDto> _viaDtos = new ObservableCollection<ViaDto>();
        private IEnumerable<BranchesDto> _branchesDtos = new ObservableCollection<BranchesDto>();
        private IEnumerable<ContactsDto> _contactsDtos = new ObservableCollection<ContactsDto>();
        private IEnumerable<MonthsDto> _monthsDtos = new ObservableCollection<MonthsDto>();
        private IEnumerable<PaymentFormDto> _paymentFormDtos = new ObservableCollection<PaymentFormDto>();
        private IEnumerable<VisitsDto> _visitsDtos = new ObservableCollection<VisitsDto>();
        private SupplierDto _supplierDto = new SupplierDto();
        private IEnumerable<LanguageDto> _languagesDto = new ObservableCollection<LanguageDto>();
        private IEnumerable<CurrencyDto> _currencyDto = new ObservableCollection<CurrencyDto>();
        private IEnumerable<CompanyDto> _companyDtos = new ObservableCollection<CompanyDto>();
        private IEnumerable<OfficeDtos> _officeDtos = new ObservableCollection<OfficeDtos>();
        private IEnumerable<CityDto> _cityDtos = new ObservableCollection<CityDto>();
        private IEnumerable<DeliveringFormDto> _deliveringFormDto;

        public Supplier(ISqlExecutor executor)
        {
            _sqlExecutor = executor;
            _supplierValue = new SupplierPoco();
            _supplierDto = new SupplierDto();
            InitializeMapping();
        }

        public Supplier(ISqlExecutor executor, string id)
        {
            _sqlExecutor = executor;
            _supplierValue = new SupplierPoco();
            _supplierDto = new SupplierDto();
            _supplierValue.NUM_PROVEE = id;
            _supplierDto.NUM_PROVEE = id;
            InitializeMapping();
        }
        /// <summary>
        ///  Move the mapping to a single mapper.DRY Principle. Dont repeat yourself.
        /// </summary>
        public void InitializeMapping()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SupplierPoco, SupplierDto>();
                cfg.CreateMap<SupplierDto, SupplierPoco>();
                cfg.CreateMap<CU1, AccountDto>().ConvertUsing(src =>
                    {
                        var accountDto = new AccountDto();
                        accountDto.Codigo = src.CODIGO;
                        accountDto.Description = src.DESCRIP;
                        accountDto.Cuenta = src.CC;
                        return accountDto;
                    }

                    );
                cfg.CreateMap<AccountDto, CU1>().ConvertUsing(src =>
                     {
                         var accountDto = new CU1();
                         accountDto.CODIGO = src.Codigo;
                         accountDto.DESCRIP = src.Description;
                         return accountDto;
                     }

                );

                cfg.CreateMap<BanksDto, BANCO>().ConstructUsing(src=>
                        {
                    var bankDto = new BANCO();
                            bankDto.CODBAN = src.Code;
                            bankDto.NOMBRE = src.Name;
                            bankDto.SWIFT = src.Swift;
                            bankDto.USUARIO = src.Usuario;
                            bankDto.ULTMODI = src.LastModification;
                            return bankDto;
                        }
                        );
                cfg.CreateMap<DIVISAS, CurrencyDto>();
                cfg.CreateMap<MESES, MonthsDto>();

                cfg.CreateMap<FORMAS, PaymentFormDto>();
                cfg.CreateMap<SupplierPoco, PROVEE1>().ConvertUsing<PocoToProvee1>();
                cfg.CreateMap<SupplierPoco, PROVEE2>().ConvertUsing<PocoToProvee2>();
                cfg.CreateMap<ProvinciaDto, PROVINCIA>().ConvertUsing(src =>
                {
                    var provincia = new PROVINCIA();
                    provincia.SIGLAS = src.Code;
                    provincia.PROV = src.Name;
                    return provincia;
                });
                cfg.CreateMap<IDIOMAS, LanguageDto>().ConvertUsing(src =>
                {
                    var language = new LanguageDto();
                    language.Nombre = src.NOMBRE;
                    language.Codigo = Convert.ToString(src.CODIGO);
                    return language;
                });
                cfg.CreateMap<BANCO, BanksDto>().ConvertUsing(
                    src =>
                    {
                        var banks = new BanksDto();
                        banks.Code = src.CODBAN;
                        banks.Name = src.NOMBRE;
                        banks.Swift = src.SWIFT;
                        banks.LastModification = src.ULTMODI;
                        banks.Usuario = src.USUARIO;
                        return banks;
                    }
                );
                
                cfg.CreateMap<ProDelega, BranchesDto>().ConvertUsing(src =>
                {
                    var branchesDto = new BranchesDto();
                    branchesDto.BranchId = src.cldIdDelega;
                    branchesDto.Address = src.cldDireccion1;
                    branchesDto.Address2 = src.cldDireccion2;
                    branchesDto.Branch = src.cldDelegacion;
                    branchesDto.City = src.cldPoblacion;
                    branchesDto.Email = src.cldEMail;
                    branchesDto.Phone = src.cldTelefono1;
                    branchesDto.Phone2 = src.cldTelefono2;
                    branchesDto.BranchKeyId = src.cldIdCliente;
                    branchesDto.Province = new ProvinciaDto();
                    branchesDto.Province.Code = src.cldIdProvincia;
                    return branchesDto;
                });

                cfg.CreateMap<ProContactos, ContactsDto>().ConvertUsing(src =>
                {
                    var contactDto = new ContactsDto();
                    contactDto.Email = src.ccoMail;
                    contactDto.LastMod = src.ULTMODI;
                    contactDto.ContactId = src.ccoIdContacto;
                    contactDto.ContactName = src.ccoContacto;
                    contactDto.Fax = src.ccoFax;
                    contactDto.Movil = src.ccoMovil;
                    contactDto.CurrentDelegation = src.ccoIdDelega;
                    contactDto.Telefono = src.ccoTelefono;
                    contactDto.Responsability = src.ccoCargo;
                    contactDto.ContactsKeyId = src.ccoIdCliente;

                    return contactDto;
                });

                cfg.CreateMap<Country, CountryDto>().ConvertUsing(src =>
                {
                    var country = new CountryDto();
                    country.Code = src.SIGLAS;
                    country.CountryName = src.PAIS;
                    return country;
                });

                // _vehicleMapper.Map<IEnumerable<PICTURES>, IEnumerable<PictureDto>>(pictureResult);
                cfg.CreateMap<PROVINCIA, ProvinciaDto>().ConvertUsing(src =>
                {
                    var provinciaDto = new ProvinciaDto();
                    provinciaDto.Code = src.SIGLAS;
                    provinciaDto.Name = src.PROV;
                    return provinciaDto;
                });


            });
            _supplierMapper = mapperConfiguration.CreateMapper();

        }
        // TODO: this is a rpelication.
        /**
         *  This code copy all properties in commmon to a soruce to a destination
         */
        public static void SetProperties(object source, object destination)
        {
            PropertyInfo[] currentProperties = destination.GetType().GetProperties();
            for (int i = 0; i < currentProperties.Length; ++i)
            {
                // destination property
                var prop = currentProperties[i];
                // source Value
                var sourceValueProperty = source.GetType().GetProperty(prop.Name);
                if (sourceValueProperty != null)
                {
                    var destinationProperty = destination.GetType().GetProperty(prop.Name);
                    destinationProperty?.SetValue(destination, sourceValueProperty.GetValue(source));
                }
            }
        }
        internal class PocoToProvee2 : ITypeConverter<SupplierPoco, PROVEE2>
        {
            public PROVEE2 Convert(SupplierPoco source, PROVEE2 destination, ResolutionContext context)
            {
                PROVEE2 supplier = new PROVEE2();
                supplier.NUM_PROVEE = source.NUM_PROVEE;
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


        public async Task<bool> DeleteAsyncData()
        {
            bool value = false;
            PROVEE1 proveedor1 = _supplierMapper.Map<SupplierPoco, PROVEE1>(_supplierValue);
            PROVEE2 proveedor2 = _supplierMapper.Map<SupplierPoco, PROVEE2>(_supplierValue);
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                using (TransactionScope transactionScope =
                    new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        value = await connection.DeleteAsync(proveedor1);
                        value = value && await connection.DeleteAsync(proveedor2);
                        // delete branches 
                        var queryString = string.Format(DeleteDelegaciones, proveedor1.NUM_PROVEE);
                        var tmpValue = await connection.ExecuteAsync(queryString) > 0;
                        value = value && tmpValue;
                        queryString = string.Format(DeleteContactos, proveedor1.NUM_PROVEE);
                        value = await connection.ExecuteAsync(queryString) > 0;
                        // delete 
                        transactionScope.Complete();
                    }
                    catch (System.Exception e)
                    {
                        transactionScope.Dispose();
                    }
                }
            }
            return value;
        }

        public async Task<bool> Save()
        {

            // set reference to city dto.
            FillCities(ref _supplierValue);
            
            PROVEE1 provee1 = _supplierMapper.Map<SupplierPoco, PROVEE1>(_supplierValue);
            PROVEE2 provee2 = _supplierMapper.Map<SupplierPoco, PROVEE2>(_supplierValue);
            provee1.NUM_PROVEE = provee2.NUM_PROVEE;
            logger.Debug("Saving supplier " + provee2.NUM_PROVEE);

            bool retValue = false;
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {

                using (TransactionScope transactionScope =
                    new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    try
                    {
                        int ret = await connection.InsertAsync(provee1);
                        retValue = ret == 0;
                        ret = await connection.InsertAsync(provee2);
                        retValue = retValue && await SaveContacts(connection);
                        transactionScope.Complete();
                        retValue = retValue && (ret == 0);
                    }
                    catch (TransactionException ex)
                    {
                        string message = "Transaction Scope Exception in Supplier Insertion. Reason: " + ex.Message;
                        DataLayerExecutionException dataLayer = new DataLayerExecutionException(message);
                        logger.Error(ex, "Exception while saving a supplier. Transaction Scope saving.");
                        throw dataLayer;
                    }
                    catch (System.Exception other)
                    {
                        string message = "Error in a Vehicle Supplier. Reason: " + other.Message;
                        logger.Error(other, "Exception while saving a supplier..");
                        DataLayerExecutionException dataLayer = new DataLayerExecutionException(message);
                        throw dataLayer;
                    }

                }
            }
            return retValue;
        }


        public async Task<bool> SaveBranches(IDbConnection connection)
        {
            bool retValue = true;
            string deleteAll = string.Format("DELETE FROM ProDelega WHERE cldIdCliente='{0}'",
                this.Value.NUM_PROVEE);
            await connection.ExecuteAsync(deleteAll);
            IMapper tmpMapper = MapperField.GetMapper();
            foreach (var branch in this.BranchesDtos)
            {
                ProDelega delega = tmpMapper.Map<BranchesDto, ProDelega>(branch);
                delega.cldIdCliente = this.Value.NUM_PROVEE;
                
                try

                {
                    int value = await connection.InsertAsync(delega);
                }
                catch (System.Exception e)
                {
                    retValue = false;
                    string message = "Transaction Scope Exception in Vehicle Insertion. Reason: " + e.Message;
                    logger.Error(message);
                    DataLayerExecutionException dataLayer = new DataLayerExecutionException(message);
                    throw dataLayer;
                }
            }
            return retValue;
        }
        /// <summary>
        ///  Save the contacts.
        /// </summary>
        /// <param name="connection">Connection</param>
        /// <returns></returns>
        public async Task<bool> SaveContacts(IDbConnection connection)
        {
            bool retValue = true;
            string deleteAll = string.Format("DELETE FROM ProContactos WHERE ccoIdCliente='{0}'",
                this.Value.NUM_PROVEE);
            await connection.ExecuteAsync(deleteAll);

            foreach (var c in this.ContactsDtos)
            {
                ProContactos cont = new ProContactos();
                cont.ccoCargo = c.Responsability;
                cont.ULTMODI = c.LastMod;
                cont.ccoIdContacto = c.ContactId.ToString();
                cont.ccoIdCliente = this.Value.NUM_PROVEE;
                cont.ccoContacto = c.ContactName;
                cont.ccoIdDelega = c.CurrentDelegation;
                cont.ccoTelefono = c.Telefono;
                cont.ccoFax = c.Fax;
                cont.ccoMail = c.Email;
                cont.ccoMovil = c.Movil;
                DateTime time = DateTime.Now;
                cont.ULTMODI = time.ToString("yyyMMddHHmmss");
                cont.USUARIO = c.User;

                try

                {
                    await connection.InsertAsync(cont);

                }
                catch (System.Exception e)
                {
                    string message = "Transaction Scope Exception in Vehicle Insertion. Reason: " + e.Message;
                    logger.Error(message);

                    DataLayerExecutionException dataLayer = new DataLayerExecutionException(message);
                    throw dataLayer;
                }

            }
            return retValue;
        }

        private void FillCities(ref SupplierPoco poco)
        {
            var city = from c in _cityDtos
                where c.Code == _supplierValue.CP
                select c;
            var singleCity = city.FirstOrDefault();
            if (singleCity != null)
            {
               poco.POBLACION = singleCity.Poblacion;
            }

        }
        public async Task<bool> SaveChanges()
        {
            
            FillCities(ref _supplierValue);

            PROVEE1 provee1 = _supplierMapper.Map<SupplierPoco, PROVEE1>(_supplierValue);
            PROVEE2 provee2 = _supplierMapper.Map<SupplierPoco, PROVEE2>(_supplierValue);

            bool retValue = false;

            try
            {
                // TODO: Reverse.
                using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
                {

                    using (TransactionScope transactionScope =
                        new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {

                        // private const string TipoProveSelect = "SELECT NUM_TIPROVE as Number, NOMBRE as Name, " +
                        string value = string.Format(TipoProveSelect, provee1.NUM_PROVEE);
                        IEnumerable<TIPOPROVE> prove = await connection.QueryAsync<TIPOPROVE>(value);
                        var tipoProve = prove.FirstOrDefault<TIPOPROVE>();

                        // here we shall already have the correct change in the VehiclePoco. It shall already validated.
                        // now we have to add the new connection.
                        try
                        {

                            retValue = await connection.UpdateAsync(provee1);
                            retValue = retValue && await connection.UpdateAsync(provee2);
                            retValue = retValue && await SaveContacts(connection);
                            retValue = await SaveBranches(connection) && retValue;
                            transactionScope.Complete();
                        }
                        catch (TransactionException ex)
                        {
                            transactionScope.Dispose();
                            string message = "Transaction Scope Exception in Vehicle Update. Reason: " + ex.Message;
                            logger.Error(message);
                            DataLayerExecutionException dataLayer = new DataLayerExecutionException(message);
                            throw dataLayer;
                        }
                        catch (System.Exception other)
                        {
                            logger.Error(other);
                            return retValue;
                        }
                    }
                }
            }

            catch (System.Exception e)
            {
                logger.Error(e);
            }

            return retValue;

        }



        public async Task<bool> LoadValue(IDictionary<string, string> fields, string code)
        {
            var currentQuery = string.Format(SupplierQuery, code);
            Valid = false;
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                try
                {
                    var queryResult = await connection.QueryAsync<SupplierPoco>(currentQuery);
                    _supplierValue = queryResult.FirstOrDefault(c => c.NUM_PROVEE == code);
                    if (_supplierValue == null)
                    {
                        return false;
                    }
                    Value = _supplierMapper.Map<SupplierPoco, SupplierDto>(_supplierValue);

                    // now we look for aux tables.
                    if (_supplierValue.TIPO.HasValue)
                    {
                        short value = _supplierValue.TIPO.Value;
                        Type =
                            await BuildAndExecute<SupplierTypeDataObject, short>(connection, TipoProveSelect,
                                value);
                    }
                    IEnumerable<CU1> accounts = await connection.QueryAsync<CU1>(AccountSelect);
                    AccountDtos = _supplierMapper.Map<IEnumerable<CU1>, IEnumerable<AccountDto>>(accounts);
                    var provincia = await connection.QueryAsync<PROVINCIA>(ProvinciaSelectAll);
                    //   await BuildAndExecute<PROVINCIA>(connection, ProvinciaSelect, _supplierValue.PROV);
                    if (provincia != null)
                    {
                        ProvinciaDtos =
                            _supplierMapper.Map<IEnumerable<PROVINCIA>, IEnumerable<ProvinciaDto>>(provincia);
                    }
                    var pais = await connection.QueryAsync<Country>(PaisSelectAll);
                    if (pais != null)
                    {
                        CountryDtos = _supplierMapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(pais);
                    }
                    var banks = await BuildAndExecute<BANCO>(connection, BankSelect, _supplierValue.BANCO);
                    if (banks != null)
                    {
                        BanksDtos = _supplierMapper.Map<IEnumerable<BANCO>, IEnumerable<BanksDto>>(banks);
                        if (_supplierValue.VIA.HasValue)
                        {
                            var vias = await BuildAndExecute<VIAS, byte>(connection, ViaSelect,
                                _supplierValue.VIA.Value);
                            ViasDtos = _supplierMapper.Map<IEnumerable<VIAS>, IEnumerable<ViaDto>>(vias);
                        }
                    }


                    var branches = await BuildAndExecute<ProDelega>(connection, GenericSql.DelegationQuery,
                        _supplierValue.NUM_PROVEE);
                    
                    var tmp = _supplierMapper.Map<IEnumerable<ProDelega>, IEnumerable<BranchesDto>>(branches);
                    AdjustBranchWithProvince(ref tmp, ProvinciaDtos);
                    BranchesDtos = tmp;
                    var contacts =
                        await BuildAndExecute<ProContactos>(connection, GenericSql.ContactsQuery,
                            _supplierValue.NUM_PROVEE);
                    
                    ContactsDtos = _supplierMapper.Map<IEnumerable<ProContactos>, IEnumerable<ContactsDto>>(contacts);
                    var months = await connection.QueryAsync<MESES>(MonthsSelect);
                    MonthsDtos = _supplierMapper.Map<IEnumerable<MESES>, IEnumerable<MonthsDto>>(months);
                    var languages = await connection.QueryAsync<IDIOMAS>(LanguageSelect);
                    LanguageDtos = _supplierMapper.Map<IEnumerable<IDIOMAS>, IEnumerable<LanguageDto>>(languages);
                    var paymentForms = await connection.QueryAsync<FORMAS>(PaymentFormSelect);
                    PaymentDtos = _supplierMapper.Map<IEnumerable<FORMAS>, IEnumerable<PaymentFormDto>>(paymentForms);
                    var currency = await connection.QueryAsync<DIVISAS>(CurrencySelect);
                    CurrencyDtos = _supplierMapper.Map<IEnumerable<DIVISAS>, IEnumerable<CurrencyDto>>(currency);
                    // poblacion mapping
                    var globalMapper = MapperField.GetMapper();
                    if (_supplierValue.FORMA_ENVIO.HasValue)
                    {
                        var deliveringForm = await BuildAndExecute<FORMAS_PEDENT>(connection,
                            GenericSql.DeliveringFromQuery,
                            _supplierValue?.FORMA_ENVIO.ToString());
                        var mapper = MapperField.GetMapper();
                        DeliveringFormDto = globalMapper.Map<IEnumerable<FORMAS_PEDENT>, IEnumerable<DeliveringFormDto>>(deliveringForm);
                    }
                    if (_supplierValue.VIA.HasValue)
                    {
                    //    var viaForm = await BuildAndExecute<VIAS>(connection, GenericSql.Via, _supplierValue?.VIA.Value)
                    }
                 
                    var cityMapper = globalMapper;
                    var cityQuery = string.Format(_queryCity);
                    var cities = await connection.QueryAsync<POBLACIONES>(cityQuery);
                    var mappedCityDtos = cityMapper.Map<IEnumerable<POBLACIONES>, IEnumerable<CityDto>>(cities);
                    CityDtos = new ObservableCollection<CityDto>(mappedCityDtos);
                    // office mapping
                    string query = string.Format(OfficeSelect, _supplierValue.OFICINA, _supplierValue.SUBLICEN);
                    var office = await connection.QueryAsync<OFICINAS>(query);
                    var mappedOffices = MapperField.GetMapper().Map<IEnumerable<OFICINAS>, IEnumerable<OfficeDtos>>(office);
                    OfficeDtos = new ObservableCollection<OfficeDtos>(mappedOffices); 
                    query = string.Format(CompanySelect, _supplierValue.SUBLICEN);

                    var company = await connection.QueryAsync<SUBLICEN>(query);
                    CompanyDtos = MapperField.GetMapper().Map<IEnumerable<SUBLICEN>, IEnumerable<CompanyDto>>(company);
                    Value = _supplierMapper.Map<SupplierPoco, SupplierDto>(_supplierValue);
                    Valid = true;
                }
                catch (System.Exception e)
                {
                    throw new DataLayerExecutionException("Cannot load supplier " + e.Message);
                }
            }
            return Valid;
        }


        /// <summary>
        ///  Adjust branch witj province.
        /// </summary>
        /// <param name="branchesDtos">Branches in London.</param>
        /// <param name="provinciaDtos">Provincia in London.</param>
        private void AdjustBranchWithProvince(ref IEnumerable<BranchesDto> branchesDtos, IEnumerable<ProvinciaDto> provinciaDtos)
        {
            IList<BranchesDto> listOfBranches = branchesDtos.ToList();
            for (int i = 0; i < listOfBranches.Count();++i)
            {
                var tmp = listOfBranches[i].Province.Code;
                IEnumerable<ProvinciaDto> tmpProvince = provinciaDtos.Where(x => (tmp == x.Code));
                ProvinciaDto dto = tmpProvince.FirstOrDefault();
                if (dto != null)
                {
                    listOfBranches[i].Province.Name = dto.Name;
                    listOfBranches[i].Province.Country = dto.Country;
                }
            }
            branchesDtos = listOfBranches;
        }
        private async Task<IEnumerable<T>> BuildAndExecute<T>(IDbConnection connection, string query, string
            code)
        {
            IEnumerable<T> type = new ObservableCollection<T>();


            if (!string.IsNullOrEmpty(code))
            {
                string queryToExec = string.Format(query, code);
                type =
                   await connection.QueryAsync<T>(queryToExec);
            }
            return type;
        }

        private async Task<IEnumerable<T1>> BuildAndExecute<T1, T2>(IDbConnection connection, string query, T2 code)
        {

            string queryToExec = string.Format(query, code);
            IEnumerable<T1> type =
                await connection.QueryAsync<T1>(queryToExec);

            return type;
        }

        public SupplierDto Value
        {
            get { return _supplierMapper.Map<SupplierPoco, SupplierDto>(_supplierValue); }
            set
            {
                _supplierDto = (SupplierDto)value;
                _supplierValue = _supplierMapper.Map<SupplierDto, SupplierPoco>(value);
                RaisePropertyChanged();

            }
        }

        public bool Valid { get; set; }
        /// <summary>
        ///  Supplier Type
        /// </summary>
        public IEnumerable<ISupplierTypeData> Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value; RaisePropertyChanged();

            }
        }
        /// <summary>
        ///  AccountDto.
        /// </summary>
        public IEnumerable<AccountDto> AccountDtos
        {
            get { return _accounts; }
            set { _accounts = value; RaisePropertyChanged(); }
        }

        public IEnumerable<ProvinciaDto> ProvinciaDtos
        {
            get { return _provinciaDto; }
            set { _provinciaDto = value; RaisePropertyChanged(); }
        }

        public IEnumerable<BanksDto> BanksDtos
        {
            get { return _banksDtos; }
            set
            {
                _banksDtos = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<CountryDto> CountryDtos
        {
            get { return _countryDtos; }
            set { _countryDtos = value; RaisePropertyChanged(); }
        }

        public IEnumerable<ViaDto> ViasDtos
        {
            get { return _viaDtos; }
            set { _viaDtos = value; RaisePropertyChanged(); }
        }

        public IEnumerable<CompanyDto> CompanyDtos
        {
            get { return _companyDtos; }
            set { _companyDtos = value; RaisePropertyChanged(); }
        }
        public IEnumerable<OfficeDtos> OfficeDtos
        {
            get { return _officeDtos; }
            set { _officeDtos = value; RaisePropertyChanged(); }
        }
        public IEnumerable<BranchesDto> BranchesDtos
        {
            get { return _branchesDtos; }
            set { _branchesDtos = value; RaisePropertyChanged(); }
        }
        public IEnumerable<ContactsDto>
            ContactsDtos
        {
            get { return _contactsDtos; }
            set { _contactsDtos = value; RaisePropertyChanged(); }
        }
        public IEnumerable<MonthsDto> MonthsDtos
        {
            get { return _monthsDtos; }
            set { _monthsDtos = value; RaisePropertyChanged(); }
        }
        public IEnumerable<PaymentFormDto> PaymentDtos
        {
            get { return _paymentFormDtos; }
            set { _paymentFormDtos = value; RaisePropertyChanged(); }
        }

        public IEnumerable<VisitsDto> VisitsDtos { get; set; }

        public IEnumerable<LanguageDto> LanguageDtos
        {
            get { return _languagesDto; }
            set
            {
                _languagesDto = value;
                RaisePropertyChanged();
            }
        }


        public IEnumerable<CurrencyDto> CurrencyDtos
        {
            get { return _currencyDto; }
            set { _currencyDto = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<CityDto> CityDtos
        {

            get => new ObservableCollection<CityDto>(_cityDtos); set => _cityDtos = value;
        }
        public IEnumerable<DeliveringFormDto> DeliveringFormDto {
            get { return _deliveringFormDto; }
            set { _deliveringFormDto = value; RaisePropertyChanged(); }
        }
    }
}
