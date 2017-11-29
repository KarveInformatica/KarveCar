using System;
using System.Collections.Generic;
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
using KarveCommon.Generic;
using KarveDapper.Extensions;


namespace DataAccessLayer.Model
{


    /// <summary>
    ///  This is the class factory for each vehicle.
    /// </summary>
    public class SupplierFactory
    {
        private readonly ISqlExecutor _sqlExecutor;

        
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
            ISupplierData data = new Supplier(_sqlExecutor);
            SupplierDto dto = new SupplierDto();;
            dto.NUM_PROVEE = id;
            data.Valid = true;
            data.Value = dto;
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
            return agent;
        }


    }
    public class Supplier: DomainObject,ISupplierData
    {
        // TODO: Craft a query container, query builder.

        private const string TipoProveSelect = "SELECT NUM_TIPROVE as Number, NOMBRE as Name, " +
                                               "USER as Account, " +
                                               "ULTMODI as LastModification FROM TIPOPROVE WHERE NUM_TIPROVE='{0}'";
        private const string ProvinciaSelect = "SELECT SIGLAS, PROV, PAIS  FROM PROVINCIA WHERE SIGLAS='{0}'";
        private const string OficinasSelect = " SELECT CODIGO, NOMBRE FROM SUBLICEN WHERE CODIGO='{0}'";
        private const string PaisSelect = "SELECT SIGLAS, PAIS FROM PAIS WHERE SIGLAS='{0}'";
        private const string BankSelect = "SELECT CODBAN, NOMBRE FROM BANCO WHERE CODBAN='{0}'";
        private const string AccountSelect = "SELECT CODIGO, DESCRIP FROM CU1";
        private const string PaymentFormSelect = "SELECT CODIGO, NOMBRE FROM FORMAS";
        private const string MonthsSelect = "SELECT NUMERO_MES, MES FROM MESES";
        private const string ViaSelect = "SELECT NUM_VIA, NOMBRE FROM VIAS WHERE NUM_VIA='{0}'";
        private const string CurrencySelect = "SELECT CODIGO, NOMBRE FROM DIVISAS";
        private const string SupplierQuery = "SELECT PROVEE1.NUM_PROVEE as NUM_PROVEE,NIF,TIPO,NOMBRE,DIRECCION,CP," +
                                             "PROVEE2.COMERCIAL,PROVEE2.PREFIJO,PROVEE2.CONTABLE,PROVEE2.FORPA,PROVEE2.PLAZO,PROVEE2.PLAZO2,PROVEE2.PLAZO3," +
                                             "PROVEE2.DIA,PROVEE2.DIA2,PROVEE2.DIA3,PROVEE2.DTO,PROVEE2.PP,PROVEE2.DIVISA,PROVEE2.PALBARAN,PROVEE2.INTRACO," +
                                             "POBLACION,PROV,NACIOPER,TELEFONO,FAX,MOVIL,INTERNET,EMAIL,PERSONA," +
                                             "SUBLICEN,OFICINA,FBAJA,FALTA,NOTAS,OBSERVA,CTAPAGO,TIPOIVA,MESVACA," +
                                             "MESVACA2,CC,IBAN,BANCO,SWIFT,IDIOMA_PR1,GESTION_IVA_IMPORTA,NOAUTOMARGEN," +
                                             "PROALB_COSTE_TRANSP,EXENCIONES_INT,AUTOFAC_MANTE,CTACP,CTALP,DIR_PAGO,DIR2_PAGO," +
                                             "CP_PAGO,PROV_PAGO,PAIS_PAGO,TELF_PAGO,FAX_PAGO, PERSONA_PAGO,MAIL_PAGO,DIR_DEVO," +
                                             "DIR2_DEVO,CP_DEVO,PROV_DEVO,PAIS_DEVO,TELF_DEVO,FAX_DEVO,PERSONA_DEVO,MAIL_DEVO, DIR_RECLAMA,DIR2_RECLAMA," +
                                             "CP_RECLAMA,PROV_RECLAMA,PAIS_RECLAMA,TELF_RECLAMA,FAX_RECLAMA,PERSONA_RECLAMA,MAIL_RECLAMA,VIA,FORMA_ENVIO,CONDICION_VENTA,DIRENVIO6," +
                                             "CTAINTRACOP,CTAINTRACOPREP FROM PROVEE1 INNER JOIN PROVEE2 ON PROVEE1.NUM_PROVEE = PROVEE2.NUM_PROVEE WHERE NUM_PROVEE='{0}'";

        private ISqlExecutor _sqlExecutor;
        private SupplierPoco _supplierValue;
        private IMapper _supplierMapper;
        private IEnumerable<ISupplierTypeData> _type;
        private IEnumerable<AccountDto> _accounts;
        private IEnumerable<ProvinciaDto> _provinciaDto;
        private IEnumerable<BanksDto> _banksDtos;
        private IEnumerable<CountryDto> _countryDtos;
        private IEnumerable<ViaDto> _viaDtos;
        private IEnumerable<BranchesDto> _branchesDtos;
        private IEnumerable<ContactsDto> _contactsDtos;
        private IEnumerable<MonthsDto> _monthsDtos;
        private IEnumerable<PaymentFormDto> _paymentFormDtos;
        private IEnumerable<VisitsDto> _visitsDtos;
        private SupplierDto _supplierDto;
        private IEnumerable<LanguageDto> _languagesDto;
        private IEnumerable<CurrencyDto> _currencyDto;
        private IEnumerable<CompanyDto> _companyDtos;
        private IEnumerable<OfficeDtos> _officeDtos;

        public Supplier(ISqlExecutor executor)
        {
            _sqlExecutor = executor;
            InitializeMapping();
        }
        public void InitializeMapping()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SupplierPoco, SupplierDto>();
                cfg.CreateMap<SupplierDto, SupplierPoco>();
                cfg.CreateMap<CU1, AccountDto>();
                cfg.CreateMap<AccountDto,CU1>();
                cfg.CreateMap<BANCO, BanksDto>();
                cfg.CreateMap<DIVISAS, CurrencyDto>();
                cfg.CreateMap<BanksDto, BANCO>();
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
                cfg.CreateMap<ProDelega, BranchesDto>().ConvertUsing(src =>
                {
                    var branchesDto = new BranchesDto();
                    branchesDto.BranchId = Convert.ToInt32(src.cldIdDelega);
                    branchesDto.Address = src.cldDireccion1;
                    branchesDto.Address2 = src.cldDireccion2;
                    branchesDto.Branch = src.cldDelegacion;
                    branchesDto.City = src.cldPoblacion;
                    branchesDto.Email = src.cldEMail;
                    return branchesDto;
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


        public Task<bool> DeleteAsyncData()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Save()
        {
            PROVEE1 provee1 = _supplierMapper.Map<SupplierPoco, PROVEE1>(_supplierValue);
            PROVEE2 provee2 = _supplierMapper.Map<SupplierPoco,PROVEE2>(_supplierValue);
            provee1.NUM_PROVEE = provee2.NUM_PROVEE;
        
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
                        transactionScope.Complete();
                        retValue = retValue && (ret == 0);
                    }
                    catch (TransactionException ex)
                    {
                        string message = "Transaction Scope Exception in Vehicle Insertion. Reason: " + ex.Message;
                        DataLayerExecutionException dataLayer = new DataLayerExecutionException(message);
                        throw dataLayer;
                    }
                    catch (System.Exception other)
                    {
                        string message = "Error in a Vehicle Insertion. Reason: " + other.Message;
                        DataLayerExecutionException dataLayer = new DataLayerExecutionException(message);
                        throw dataLayer;
                    }

                }
            }
            return retValue;
        }
    

        public async Task<bool> SaveChanges()
        {
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


                        // here we shall already have the correct change in the VehiclePoco. It shall already validated.
                        // now we have to add the new connection.
                        try
                        {
                            retValue = await connection.UpdateAsync(provee1);
                            retValue = retValue && await connection.UpdateAsync(provee2);
                            transactionScope.Complete();
                        }
                        catch (TransactionException ex)
                        {
                            string message = "Transaction Scope Exception in Vehicle Update. Reason: " + ex.Message;
                            DataLayerExecutionException dataLayer = new DataLayerExecutionException(message);
                            throw dataLayer;
                        }
                        catch (System.Exception other)
                        {
                            return retValue;
                        }
                    }
                }
            }

            catch (System.Exception e)
            {

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
                    var provincia =
                        await BuildAndExecute<PROVINCIA>(connection, ProvinciaSelect, _supplierValue.PROV);
                    ProvinciaDtos = _supplierMapper.Map<IEnumerable<PROVINCIA>, IEnumerable<ProvinciaDto>>(provincia);

                    var pais =
                        await BuildAndExecute<Country>(connection, PaisSelect, _supplierValue.NACIOPER);
                    CountryDtos = _supplierMapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(pais);

                    var banks = await BuildAndExecute<BANCO>(connection, BankSelect, _supplierValue.BANCO);
                    BanksDtos = _supplierMapper.Map<IEnumerable<BANCO>, IEnumerable<BanksDto>>(banks);
                    if (_supplierValue.VIA.HasValue)
                    {
                        var vias = await BuildAndExecute<VIAS, byte>(connection, ViaSelect, _supplierValue.VIA.Value);
                        ViasDtos = _supplierMapper.Map <IEnumerable<VIAS>, IEnumerable<ViaDto>>(vias);
                    }
                    var branches = await BuildAndExecute<ProDelega>(connection, GenericSql.DelegationQuery,
                        _supplierValue.NUM_PROVEE);
                    BranchesDtos = _supplierMapper.Map<IEnumerable<ProDelega>, IEnumerable<BranchesDto>>(branches);
                    var contacts =
                        await BuildAndExecute<ProContactos>(connection, GenericSql.ContactsQuery,
                            _supplierValue.NUM_PROVEE);
                    ContactsDtos = _supplierMapper.Map<IEnumerable<ProContactos>, IEnumerable<ContactsDto>>(contacts);
                    var months = await connection.QueryAsync<MESES>(MonthsSelect);
                    MonthsDtos = _supplierMapper.Map<IEnumerable<MESES>, IEnumerable<MonthsDto>>(months);
                    var paymentForms = await connection.QueryAsync<FORMAS>(PaymentFormSelect);
                    PaymentDtos = _supplierMapper.Map<IEnumerable<FORMAS>, IEnumerable<PaymentFormDto>>(paymentForms);
                    var currency = await connection.QueryAsync<DIVISAS>(CurrencySelect);
                    CurrencyDtos = _supplierMapper.Map<IEnumerable<DIVISAS>, IEnumerable<CurrencyDto>>(currency);
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

        private async Task<IEnumerable<T>> BuildAndExecute<T>(IDbConnection connection, string query, string
            code)
        {
            IEnumerable<T> type = null;
  

            if (!string.IsNullOrEmpty(code))
            {
                string queryToExec = string.Format(query, code);
                 type =
                    await connection.QueryAsync<T>(queryToExec);
            }
            return type;
        }
     
        private async Task<IEnumerable<T1>> BuildAndExecute<T1, T2>(IDbConnection connection, string query,T2 code)
        {
           
            string queryToExec = string.Format(query, code);
            IEnumerable<T1> type =
                await connection.QueryAsync<T1>(queryToExec);
           
            return type;
        }

        public SupplierDto Value
        {
            get { return _supplierMapper.Map<SupplierPoco, SupplierDto>(_supplierValue);  }
            set
            {
                _supplierValue = _supplierMapper.Map<SupplierDto, SupplierPoco>(value);
                RaisePropertyChanged();

            }
        }

        public bool Valid { get; set; }
        /// <summary>
        ///  Supplier Type
        /// </summary>
        public IEnumerable<ISupplierTypeData> Type {
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
            set { _accounts = value; RaisePropertyChanged();}
        }
   
        public IEnumerable<ProvinciaDto> ProvinciaDtos {
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
            set { _branchesDtos = value; RaisePropertyChanged();}
        }
        public IEnumerable<ContactsDto> 
            ContactsDtos {
            get { return _contactsDtos; }
            set { _contactsDtos = value; RaisePropertyChanged();} }
        public IEnumerable<MonthsDto> MonthsDtos
        {
            get { return _monthsDtos; }
            set { _monthsDtos = value; RaisePropertyChanged();}
        }
        public IEnumerable<PaymentFormDto> PaymentDtos {
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
      }
}
