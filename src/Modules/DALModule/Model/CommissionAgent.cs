using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using AutoMapper;
using Dapper;
using DataAccessLayer.DataObjects;
using DataAccessLayer.DataObjects.Wrapper;
using DataAccessLayer.Exception;
using DataAccessLayer.Logic;
using DesignByContract;
using KarveDapper.Extensions;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using Prism.Mvvm;
using NLog;
namespace DataAccessLayer.Model
{

    public class CommissionAgentFactory
    {
        // SELECT TOP 5 START AT 50 * FROM ProDelega;
        private const string CommissionAgentIds = "SELECT {0} NUM_COMI FROM COMISIO";
        private const string CommissionAgentLimitsId = " SELECT TOP {0} START AT {1} {2} FROM COMISIO";
        private readonly ISqlExecutor _sqlExecutor;
        private static Logger logger = LogManager.GetCurrentClassLogger();


        /// <summary>
        ///  This is the factory for the commission agent. 
        /// </summary>
        /// <param name="executor">Query executor of the things</param>
        /// <returns></returns>
        public static CommissionAgentFactory GetFactory(ISqlExecutor executor)
        {
            return new CommissionAgentFactory(executor);
        }
        /// <summary>
        ///  This is the queryExecutro factory.
        /// </summary>
        /// <param name="executor"></param>
        private CommissionAgentFactory(ISqlExecutor executor)
        {
            _sqlExecutor = executor;
        }
        /// <summary>
        /// Create a list of commission agents
        /// </summary>
        /// <param name="fields">Fields to be fetched</param>
        /// <param name="maxLimit">Limit maximum of the agents to be fetched. Zero all fields</param>
        /// <param name="offset">Starting offset from which we can fetch</param>
        /// <returns>A list of commission agent objects.</returns>
        public async Task<IList<ICommissionAgent>> CreateCommissionAgentList(
            IDictionary<string, string> fields, int maxLimit = 0, int offset = 0)
        {
            DesignByContract.Dbc.Requires(fields.Count > 0, "Fields not valid");
            DesignByContract.Dbc.Requires(_sqlExecutor.Connection != null, "Null Connection");
            logger.Debug("Creating Commission List.");
            IDbConnection connection = _sqlExecutor.Connection;
            string currentQueryAgent = "";
            IList<ICommissionAgent> list = new List<ICommissionAgent>();
            if (maxLimit == 0)
            {
                currentQueryAgent = string.Format(CommissionAgentIds, fields["COMISIO"]);
            }
            else
            {
                currentQueryAgent = string.Format(CommissionAgentLimitsId, maxLimit, offset, fields["COMISIO"]);
            }
            logger.Debug("Current Agent Query :" + currentQueryAgent);
            using (connection)
            {
                logger.Debug("Create Loading CommissionAgent");
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                IEnumerable<COMISIO> commissionAgents = await connection.QueryAsync<COMISIO>(currentQueryAgent);
                foreach (COMISIO c in commissionAgents)
                {

                    CommissionAgent agent = new CommissionAgent(_sqlExecutor);
                    bool loaded = await agent.LoadValue(fields, c.NUM_COMI);
                    
                    if (loaded)
                    {
                        logger.Debug("Agent Loaded.");
                        list.Add(agent);
                    }
                    else
                    {
                        logger.Info("Failed to laod the commission agent list.");
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// New commission agent id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ICommissionAgent NewCommissionAgent(string id)
        {
            Dbc.Requires(id.Length > 0, "Id length shall be ok.");
            CommissionAgent agent = new CommissionAgent(_sqlExecutor, id);
            return agent;
        }



        /// <summary>
        /// This retrieve a commission agent.
        /// </summary>
        /// <param name="fields">Fields to be selected in the db</param>
        /// <param name="commissionId">Commission Id</param>
        /// <returns>A commmission agent data transfer object</returns>
        public async Task<ICommissionAgent> GetCommissionAgent(IDictionary<string, string> fields, string commissionId)
        {
            Dbc.Requires(fields.Count > 0, "Fields not valid");
            Dbc.Requires(!string.IsNullOrEmpty(commissionId), "Null Connection");
            CommissionAgent agent = new CommissionAgent(_sqlExecutor);
            logger.Debug("Loading CommissionAgent Value for id: " + commissionId);

            bool loaded = await agent.LoadValue(fields, commissionId).ConfigureAwait(false);
            agent.Valid = loaded;
            if (!agent.Valid)
            {
                logger.Info("Cannot Load Agent for ID" + commissionId + ".");
            }
            
            return agent;
        }

    }

    /// <summary>
    ///  This class returns the commission agent for a file.
    /// </summary>
    public class CommissionAgent : BindableBase, ICommissionAgent, INotifyDataErrorInfo, IRevertibleChangeTracking
    {
        public const string Comisio = "COMISIO";
        public const string Tipocomi = "TIPOCOMI";
        public const string Contactos = "CONTACTOS";
        public const string Branches = "BRANCHES";
        public const string Visitas = "VISITAS";
        private const string TipoComision = "TIPOCOMISION";
        private const string Negocio = "NEGOCIO";
        private const string Canal = "CANAL";
        private const string ClavePpto = "CLAVEPTO";
        private const string Origen = "ORIGEN";
        private const string Idiomas = "IDIOMAS";
        private const string ZonaOfi = "ZONAOFI";
        private const string Products = "PRODUCTS";
        private const string Vendedor = "VENDEDOR";
        private const string Mercado = "MERCADO";
        private const string Client1 = "CLIENTES1";
        private const string DefaultTicomiFields = "NUM_TICOMI,NOMBRE";
        private const string DefaultProductsFields = "CODIGO_PRD, NOMBRE_PRD";
        private const string DefaultVendedorFields = "NUM_VENDE, NOMBRE";
        private const string DefaultMercadoFields = "CODIGO,NOMBRE";
        private const string DefaultClientes1Fields = "NUMERO_CLI, NOMBRE";
        private const string DefaultNegocioFields = "CODIGO,NOMBRE";
        private const string DefaultCanalFields = "CODIGO,NOMBRE";
        private const string DefaultTipoComision = "NUM_SOBREQ,NOMBRE";
        private const string DefaultOriginField = "NUM_ORIGEN, NOMBRE";
        private const string DefaultZonaOfi = "COD_ZONAOFI,NOM_ZONA";
        private const string DefaultClavePpto = "COD_CLAVE,NOMBRE";
        private const string DefaultIdiomas = "CODIGO,NOMBRE";
        private const string DefaultDelegation =
                "cldIdCOMI, cldDelegacion, cldDireccion1, cldDireccion2, cldCP, cldPoblacion, cldIdProvincia,cldTelefono1, cldTelefono2, cldFax, cldEMail, cldMovil";

        private IEnumerable<COMISIO> _commissionAgents = new ObservableCollection<COMISIO>();
        private IEnumerable<Country> _nacioPer;
        private IEnumerable<TIPOCOMI> _tipoComis = new ObservableCollection<TIPOCOMI>();
        private IEnumerable<PROVINCIA> _provinces;
        private IEnumerable<ContactsComiPoco> _contactos = new List<ContactsComiPoco>();
        private IEnumerable<ComiDelegaPoco> _delegations = new List<ComiDelegaPoco>();
        private IEnumerable<VisitasComiPoco> _visitasComis = new List<VisitasComiPoco>();
        private IEnumerable<TIPOCOMI> _tipocomisions = new List<TIPOCOMI>();
        private IEnumerable<PRODUCTS> _products = new List<PRODUCTS>();
        private IEnumerable<VENDEDOR> _vendedors = new List<VENDEDOR>();
        private IEnumerable<MERCADO> _mercados = new List<MERCADO>();
        private IEnumerable<CLIENTES1> _clientes = new List<CLIENTES1>();
        private IEnumerable<NEGOCIO> _negocios = new List<NEGOCIO>();
        private IEnumerable<CANAL> _canals = new List<CANAL>();
        private IEnumerable<ORIGEN> _origens = new List<ORIGEN>();
        private IEnumerable<ZONAOFI> _zonaofis = new List<ZONAOFI>();
        private IEnumerable<ClavePtoDto> _clavePto = new List<ClavePtoDto>();
        private IEnumerable<IDIOMAS> _idiomas = new List<IDIOMAS>();
        private IEnumerable<CityDto> _cities = new List<CityDto>();
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();





        private readonly ISqlExecutor _executor;
        private COMISIO _currentComisio;
        
        private string _queryTipoComi = "SELECT NUM_TICOMI, NOMBRE FROM TIPOCOMI WHERE NUM_TICOMI='{0}'";
        private string _queryProvincia = "SELECT SIGLAS,PROV FROM PROVINCIA WHERE SIGLAS='{0}'";
        private string _queryPais = "SELECT SIGLAS,PAIS FROM PAIS WHERE SIGLAS='{0}'";
        private string _queryComi = "SELECT {0} FROM COMISIO WHERE NUM_COMI='{1}'";
        private string _queryComiDapper = "SELECT {1} FROM {0} WHERE {2}='{3}';";

        private string _queryCity = "SELECT * FROM POBLACIONES WHERE CP='{0}'";

        private string _queryContactos = "SELECT CONTACTO as ContactoId,COMISIO,NOM_CONTACTO, NIF, PG.CODIGO as CargoId, " +
                                         "PG.NOMBRE AS CARGO, TELEFONO, MOVIL, " +
                                         "FAX, EMAIL, CC.USUARIO, CC.ULTMODI, DL.CLDIDDELEGA as DelegaId, cldDelegacion " +
                                         "DELEGACC_NOM " +
                                         "FROM CONTACTOS_COMI AS CC " +
                                         "LEFT OUTER JOIN PERCARGOS AS PG ON CC.CARGO = PG.CODIGO " +
                                         "LEFT OUTER JOIN COMI_DELEGA AS DL ON CC.DELEGA_CC = DL.CLDIDDELEGA " +
                                         "AND CC.COMISIO = DL.CLDIDCOMI WHERE COMISIO = '{0}' ORDER BY CC.CONTACTO";

        private string _queryComiDelega = "SELECT cldIdDelega,{0},PV.PROV AS NOM_PROV, PV.SIGLAS FROM COMI_DELEGA CC " +
                                          "LEFT OUTER JOIN PROVINCIA PV ON PV.SIGLAS = CC.cldIdProvincia" +
                                          " WHERE cldIdCOMI='{1}' ORDER BY CC.cldIdDelega";


        private string _queryVisitas = "SELECT visIdVisita,visIdCliente,visIdContacto,visFecha,visIdVendedor, " +
                                       "visIdVisitaTipo, PV.CONTACTO as IdContacto,TV.CODIGO_VIS as IdTipoVisita,NUM_VENDE as IdVendedor, PV.nom_contacto AS NOMCONTACTO, VE.NOMBRE FROM VISITAS_COMI CC " +
                                       "LEFT OUTER JOIN CONTACTOS_COMI PV ON PV.COMISIO = CC.VISIDCLIENTE AND PV.CONTACTO = CC.VISIDCONTACTO " +
                                       "LEFT OUTER JOIN TIPOVISITAS TV ON TV.CODIGO_VIS = CC.VISIDVISITATIPO " +
                                       "LEFT OUTER JOIN VENDEDOR VE ON VE.NUM_VENDE = CC.visIdVendedor WHERE VISIDCLIENTE= '{0}' ORDER BY CC.visFECHA";

        private bool isChanged = false;
        private bool _valid = false;
        private CommissionAgentTypeData _commissionAgentType;
        private IDbConnection _dbConnection = null;
        private readonly IMapper _mapper;
        private IEnumerable<ProvinciaDto> _provinciaDtos;
        private IEnumerable<CountryDto> _countryDtos;
        private IEnumerable<CLAVEPTO> _clavePpto;
        private IEnumerable<ORIGEN> _origen;
        private IEnumerable<ContactsDto> _contactosDto = new List<ContactsDto>();
        private IEnumerable<BranchesDto> _delegationDto = new List<BranchesDto>();
        private IEnumerable<VisitsDto> _visitDto = new List<VisitsDto>();
        private IEnumerable<POBLACIONES> _poblaciones;

        #region Properties
        /// <summary>
        ///  Province Dto.
        /// </summary>
        public IEnumerable<ProvinciaDto> ProvinceDto
        {
            get { return _provinciaDtos; }
            set { _provinciaDtos = value; RaisePropertyChanged(); }
        }
        /// <summary>
        ///  Contacts Dto.
        /// </summary>
        public IEnumerable<ContactsDto> ContactsDto
        {
            get { return _contactosDto; }
            set { _contactosDto = value; RaisePropertyChanged(); }
        }

        /// <summary>
        ///  DelegationDto.
        /// </summary>
        public IEnumerable<BranchesDto> DelegationDto
        {
            get { return _delegationDto; }
            set
            {
                _delegationDto = value;
                RaisePropertyChanged();
            }
        }


        /// <summary>
        /// CountryDto.
        /// </summary>
        public IEnumerable<CountryDto> CountryDto
        {
            get { return _countryDtos; }
            set { _countryDtos = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// ProductsDto
        /// </summary>
        public IEnumerable<ProductsDto> ProductsDto { get; set; }
        /// <summary>
        /// Commisi
        /// </summary>
        public IEnumerable<CommissionTypeDto> CommisionTypeDto { get; set; }
        /// <summary>
        ///  Language Dto
        /// </summary>
        public IEnumerable<LanguageDto> LanguageDto { get; set; }
        /// <summary>
        ///  Clients Dto
        /// </summary>
        public IEnumerable<ClientesDto> ClientsDto { get; set; }

        public IEnumerable<VisitsDto> VisitsDto { get; set; }

        /// <summary>
        ///  Vendedor Dto
        /// </summary>
        public IEnumerable<ResellerDto> VendedorDto { get; set; }
        /// <summary>
        ///  MercadoDto
        /// </summary>
        public IEnumerable<MercadoDto> MercadoDto { get; set; }
        /// <summary>
        ///  Negocio Dto
        /// </summary>
        public IEnumerable<BusinessDto> NegocioDto { get; set; }
        /// <summary>
        ///  Canal Dto
        /// </summary>
        public IEnumerable<ChannelDto> CanalDto { get; set; }
        /// <summary>
        ///  Clave Ppto Dto
        /// </summary>
        public IEnumerable<ClavePtoDto> ClavePptoDto { get; set; }
        /// <summary>
        ///  Origen Dto
        /// </summary>
        public IEnumerable<OrigenDto> OrigenDto { get; set; }
        /// <summary>
        ///  ZonaOfi Dto
        /// </summary>
        public IEnumerable<ZonaOfiDto> ZonaOfiDto { get; set; }

        /// <summary>
        ///  Visits dto.
        /// </summary>
        public IEnumerable<VisitsDto> VisitDto
        {
            get { return _visitDto; }
            set
            {
                _visitDto = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Cities DTO.
        /// </summary>
        public IEnumerable<CityDto> CityDtos
        {
            get { return _cities; }
            set { _cities = value; RaisePropertyChanged(); }
        }

        /// <summary>
        ///  Changed value agent
        /// </summary>
        public bool Changed
        {
            set { isChanged = value; }
            get { return isChanged; }
        }

        #endregion


        /// <summary>
        ///  Commission agent ctr.
        /// </summary>
        public CommissionAgent(ISqlExecutor executor)
        {
            _executor = executor;
            _currentComisio = new COMISIO();
            _commissionAgents = new List<COMISIO>();
            _nacioPer = new List<Country>();
            _tipoComis = new List<TIPOCOMI>();
            _provinces = new List<PROVINCIA>();
            _commissionAgentType = new CommissionAgentTypeData();
            _mapper = MapperField.GetMapper();
        }

        public CommissionAgent(ISqlExecutor executor, string commissionId)
        {
            _executor = executor;
            _currentComisio = new COMISIO();
            _currentComisio.NUM_COMI = commissionId;
            _commissionAgents = new List<COMISIO>();
            _nacioPer = new List<Country>();
            _tipoComis = new List<TIPOCOMI>();
            _provinces = new List<PROVINCIA>();
            _commissionAgentType = new CommissionAgentTypeData();
            _mapper = MapperField.GetMapper();
        }




        /// <summary>
        /// This load the single value.
        /// <returns>This returns a bool value</returns>
        /// </summary>
        public object Value
        {
            set
            {
                /* Evaluating if it is needed convert the mapper to ComisioDto*
                 * ComisioDto dto = Mapper.Configuration
                 */
                _currentComisio = (COMISIO)value;
                isChanged = true;
                RaisePropertyChanged();
            }
            get { return _currentComisio; }
        }



        /// <summary>
        /// Get the fields of one string
        /// </summary>
        /// <param name="key">Kind of the key</param>
        /// <param name="comiDictionary">Dictionary to be fetched</param>
        /// <returns></returns>
        private string GetFields(string key, IDictionary<string, string> comiDictionary, string defaultFields)
        {
            if (comiDictionary.ContainsKey(key))
            {
                return comiDictionary[key];
            }
            return defaultFields;
        }
        /// This function is too big. it shall be extracted to an object.
        /// <summary>
        /// Execute multiple queries.
        /// </summary>
        /// <param name="comisio">Comisio.</param>
        /// <param name="connection">DbConnection.</param>
        /// <returns></returns>
        private async Task BuildAuxQueryMultiple(COMISIO comisio, IDbConnection connection)
        {
            string tmpQuery = "";

            if (!string.IsNullOrEmpty(comisio.TIPOCOMI))
            {
                tmpQuery = string.Format(_queryTipoComi, comisio.TIPOCOMI);
                _tipocomisions = await _dbConnection.QueryAsync<TIPOCOMI>(tmpQuery);
                CommisionTypeDto = _mapper.Map<IEnumerable<TIPOCOMI>, IEnumerable<CommissionTypeDto>>(_tipocomisions);

            }
            if (!string.IsNullOrEmpty(comisio.CP))
            {
                tmpQuery = string.Format(_queryCity, comisio.CP);
                _poblaciones = await _dbConnection.QueryAsync<POBLACIONES>(tmpQuery);
                CityDtos = _mapper.Map<IEnumerable<POBLACIONES>, IEnumerable<CityDto>>(_poblaciones);
            }
            if (comisio.PRODUCT_COMI != null)
            {
                tmpQuery = string.Format(_queryComiDapper, Products, DefaultProductsFields, "CODIGO_PRD", comisio.PRODUCT_COMI);
                _products = await _dbConnection.QueryAsync<PRODUCTS>(tmpQuery);
                ProductsDto = _mapper.Map<IEnumerable<PRODUCTS>, IEnumerable<ProductsDto>>(_products);
            }
            if ((!string.IsNullOrEmpty(comisio.VENDE_COMI)))
            {

                tmpQuery = string.Format(_queryComiDapper, Vendedor, DefaultVendedorFields, "NUM_VENDE", comisio.VENDE_COMI);
                _vendedors = await _dbConnection.QueryAsync<VENDEDOR>(tmpQuery);
                VendedorDto = _mapper.Map<IEnumerable<VENDEDOR>, IEnumerable<ResellerDto>>(_vendedors);
            }
            if (!string.IsNullOrEmpty(comisio.MERCADO))
            {
                tmpQuery = string.Format(_queryComiDapper, Mercado, DefaultMercadoFields, "CODIGO", comisio.MERCADO);
                _mercados = await _dbConnection.QueryAsync<MERCADO>(tmpQuery);
                MercadoDto = _mapper.Map<IEnumerable<MERCADO>, IEnumerable<MercadoDto>>(_mercados);
            }
            if ((!string.IsNullOrEmpty(comisio.CLIENTE)))
            {
                tmpQuery = string.Format(_queryComiDapper, Client1, DefaultClientes1Fields, "NUMERO_CLI", comisio.CLIENTE);
                // FIXME: this shall be a client poco.
                _clientes = await _dbConnection.QueryAsync<CLIENTES1>(tmpQuery);
                ClientsDto = _mapper.Map<IEnumerable<CLIENTES1>, IEnumerable<ClientesDto>>(_clientes);

            }
            if ((!string.IsNullOrEmpty(comisio.NEGOCIO)))
            {
                tmpQuery = string.Format(_queryComiDapper, Negocio, DefaultNegocioFields, "CODIGO", comisio.NEGOCIO);
                _negocios = await _dbConnection.QueryAsync<NEGOCIO>(tmpQuery);
                NegocioDto = _mapper.Map<IEnumerable<NEGOCIO>, IEnumerable<BusinessDto>>(_negocios);

            }
            if (!string.IsNullOrEmpty(comisio.CANAL))
            {
                tmpQuery = string.Format(_queryComiDapper, Canal, DefaultCanalFields, "CODIGO", comisio.CANAL);
                _canals = await _dbConnection.QueryAsync<CANAL>(tmpQuery);
                CanalDto = _mapper.Map<IEnumerable<CANAL>, IEnumerable<ChannelDto>>(_canals);

            }
            if ((!string.IsNullOrEmpty(comisio.CLAVEPPTO)))
            {
                tmpQuery = string.Format(_queryComiDapper, ClavePpto, DefaultClavePpto, "COD_CLAVE", comisio.CLAVEPPTO);
                _clavePpto = await _dbConnection.QueryAsync<CLAVEPTO>(tmpQuery);
                ClavePptoDto = _mapper.Map<IEnumerable<CLAVEPTO>, IEnumerable<ClavePtoDto>>(_clavePpto);

            }
            if (comisio.ORIGEN_COMI != null)
            {
                tmpQuery = string.Format(_queryComiDapper, Origen, DefaultOriginField, "NUM_ORIGEN", comisio.ORIGEN_COMI);
                _origen = await _dbConnection.QueryAsync<ORIGEN>(tmpQuery);
                OrigenDto = _mapper.Map<IEnumerable<ORIGEN>, IEnumerable<OrigenDto>>(_origen);

            }
            if (!string.IsNullOrEmpty(comisio.ZONAOFI))
            {
                tmpQuery = string.Format(_queryComiDapper, ZonaOfi, DefaultZonaOfi, "COD_ZONAOFI", comisio.ZONAOFI);
                _zonaofis = await _dbConnection.QueryAsync<ZONAOFI>(tmpQuery);
                ZonaOfiDto = _mapper.Map<IEnumerable<ZONAOFI>, IEnumerable<ZonaOfiDto>>(_zonaofis);
            }
            if (comisio.IDIOMA != null)
            {
                tmpQuery = string.Format(_queryComiDapper, Idiomas, DefaultIdiomas, "CODIGO", comisio.IDIOMA);
                _idiomas = await _dbConnection.QueryAsync<IDIOMAS>(tmpQuery);
                LanguageDto = _mapper.Map<IEnumerable<IDIOMAS>, IEnumerable<LanguageDto>>(_idiomas);
            }
        }


        /// <summary>
        ///  Load single value. It loads a commission agent.
        /// </summary>
        /// <param name="commissionDictionary">Dictionary of the selected fields</param>
        /// <param name="commissionId"></param>
        /// <returns></returns>
        public async Task<bool> LoadValue(IDictionary<string, string> commissionDictionary, string commissionId)
        {
            // in the commission query already i have a commission id.
            bool preCondition = commissionDictionary.ContainsKey(Comisio);
            Dbc.Requires(preCondition, "The dictionary used is not correct");
            Dbc.Requires(!string.IsNullOrEmpty(commissionId), "The commission is is not ok");
            logger.Info("Load Agent for ID" + commissionId);
            
            string commisionQueryFields = commissionDictionary[Comisio];
            string tipoComiFields = GetFields(Tipocomi, commissionDictionary, DefaultTicomiFields);
            string branchesField = GetFields(Branches, commissionDictionary, DefaultDelegation);
            // this collect all kind of objects as result of the query.
            bool isOpen = false;
            if (_dbConnection == null)
            {
                logger.Debug("Opening Connection to DB");
                isOpen = _executor.Open();
            }
            // now between the two

            if (isOpen)
            {
                try
                {
                    _dbConnection = _executor.Connection;
                    string commisionQuery = string.Format(_queryComi, commisionQueryFields, commissionId);
                    logger.Debug("Executing query " + commisionQuery);

                    _commissionAgents = await _dbConnection.QueryAsync<COMISIO>(commisionQuery);
                    _currentComisio = _commissionAgents.FirstOrDefault();

                    if (_currentComisio != null)
                    {
                        if (!string.IsNullOrEmpty(_currentComisio.PROVINCIA))
                        {
                            string provinceQuery = string.Format(_queryProvincia, _currentComisio.PROVINCIA);
                            _provinces = await _dbConnection.QueryAsync<PROVINCIA>(provinceQuery).ConfigureAwait(false);
                            ProvinceDto = _mapper.Map<IEnumerable<PROVINCIA>, IEnumerable<ProvinciaDto>>(_provinces);
                        }
                        string queryContactos = string.Format(_queryContactos, _currentComisio.NUM_COMI);
                        _contactos = await _dbConnection
                            .QueryAsync<ContactsComiPoco, PERCARGOS, COMI_DELEGA, ContactsComiPoco>(queryContactos,
                                (contacts, precargo, cc) =>
                                {
                                    contacts.percargos = precargo;
                                    contacts.comiDelega = cc;
                                    return contacts;
                                }, splitOn: "ContactoId,CargoId,DelegaId");

                        ContactsDto = _mapper.Map<IEnumerable<ContactsComiPoco>, IEnumerable<ContactsDto>>(_contactos);

                        string queryTipoComi = string.Format(_queryTipoComi, tipoComiFields, _currentComisio.TIPOCOMI);
                        logger.Debug("Query commission agent kind: "+ queryTipoComi);

                        _tipoComis = await _dbConnection.QueryAsync<TIPOCOMI>(queryTipoComi).ConfigureAwait(false);
                        if (!string.IsNullOrEmpty(_currentComisio.NACIOPER))
                        {
                            string queryPais = string.Format(_queryPais, _currentComisio.NACIOPER);
                            logger.Debug("Query commission agent kind: " + queryPais);
                            _nacioPer = await _dbConnection.QueryAsync<Country>(queryPais);
                            CountryDto = _mapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(_nacioPer);
                        }

                        string delega = string.Format(_queryComiDelega, branchesField, _currentComisio.NUM_COMI);
                        _delegations = await _dbConnection.QueryAsync<ComiDelegaPoco, PROVINCIA, ComiDelegaPoco>(delega,
                            (branch, prov) =>
                            {
                                branch.PROV = prov;
                                return branch;
                            }, splitOn: "SIGLAS");
                        // DelegationDto = _mapper.Map<IEnumerable<ComiDelegaPoco>, IEnumerable<BranchesDto>>(_delegations);
                        string visitas = string.Format(_queryVisitas, _currentComisio.NUM_COMI);
                        _visitasComis = await _dbConnection.QueryAsync<VisitasComiPoco, CONTACTOS_COMI, TIPOVISITAS, VENDEDOR, VisitasComiPoco>(visitas,
                            (visita, contactos, tipoVisitas, vendedor) =>
                            {
                                visita.ContactsComi = contactos;
                                visita.VendedorComi = vendedor;
                                visita.TipoVisitas = tipoVisitas;
                                return visita;
                            }, splitOn: "visIdVisita,IdContacto,IdTipoVisita,IdVendedor");
                        VisitDto = _mapper.Map<IEnumerable<VisitasComiPoco>, IEnumerable<VisitsDto>>(_visitasComis);
                        logger.Debug("Executing AuxQueries.");
                        await BuildAuxQueryMultiple(_currentComisio, _dbConnection);
                    }

                }
                catch (System.Exception e)
                {
                    logger.Info("Cannot open value" + e.Message);

                    return false;
                }
                finally
                {
                    _executor.Close();
                    logger.Debug("Connection close with success.");
                }
            }
            else
            {
                logger.Debug("Current commisionist is null.");
                return false;
            }
            _valid = true;
            return true;
        }




        /// <summary>
        ///  This save a new generated item
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<bool> Save()
        {
            Dbc.Requires(_currentComisio != null, "Current CommissionAgent is null");

            bool retValue = false;
            var delegations = _mapper.Map<IEnumerable<BranchesDto>, IEnumerable<COMI_DELEGA>>(DelegationDto, res => res.Items.Add("RefId", _currentComisio.NUM_COMI));
            logger.Debug("Opening connection for saving.");

            // the open shall be reverted.
            using (IDbConnection connection = _executor.OpenNewDbConnection())
            {

                using (TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    try
                    {
                        logger.Debug("Inserting data");

                        // now we have to add the new connection.
                        await connection.InsertAsync<COMISIO>(_currentComisio).ConfigureAwait(false);
                        await connection.InsertAsync(_contactos).ConfigureAwait(false);
                        await connection.InsertAsync(delegations).ConfigureAwait(false);
                        await connection.InsertAsync(_visitasComis).ConfigureAwait(false);
                        transactionScope.Complete();
                        retValue = true;

                    }
                    catch (TransactionException ex)
                    {
                        logger.Info("Transaction ScopeException while saving " + ex.Message);
                        retValue = false;
                    }
                    catch (System.Exception ex)
                    {
                        retValue = false;
                        logger.Info("Cannot open database connection while saving " + ex.Message);
                        throw new CommissionAgentException(ex.Message);
                    }
                    finally
                    {

                        //transactionScope.Dispose();
                        if (_dbConnection != null)
                        {
                            logger.Debug("Closing connection.");

                            _dbConnection.Close();
                        }
                    }
                }

            }
            return retValue;
        }
        
        private async Task<bool> SaveBranches(IDbConnection conn, IEnumerable<BranchesDto> dto, 
            string currentComi, IEnumerable<ComiDelegaPoco> delegations)
        {
            Dbc.Requires(_mapper != null, "Conversion Map shall be allocated");
            logger.Debug("Saving branches..");
            bool retValue = false;
            var branchesDtos = dto as BranchesDto[] ?? dto.ToArray();
            if (branchesDtos.ToList().Count == 0)
            {
                return true;
            }
            // we shall convert back before saving.
            IEnumerable<COMI_DELEGA> branches = _mapper.Map<IEnumerable<BranchesDto>, IEnumerable<COMI_DELEGA>>(branchesDtos,
                res => res.Items.Add("RefId", currentComi));
            var entityToUpdate = branches as IList<COMI_DELEGA> ?? branches.ToList();
            if (entityToUpdate.Count() != 0)
            {
                retValue = await conn.UpdateAsync(entityToUpdate);
            }
            return retValue;
        }

        private async Task<bool> SaveContacts(IDbConnection conn, IEnumerable<ContactsDto> dto, string currentComi, 
            IEnumerable<ContactsComiPoco> contactos)
        {
            Dbc.Requires(_mapper != null, "Conversion Map shall be allocated");
            Dbc.Requires(!string.IsNullOrEmpty(currentComi), "Conversion Map shall be allocated");
            Dbc.Requires(conn != null, "The connection shall be not null");
            logger.Debug("Saving Contacts..");
            var contactsDtos = dto as ContactsDto[] ?? dto.ToArray();
            if (contactsDtos.Length == 0)
            {
                return true;
            }
            if (contactsDtos.All(contact => contact.ContactsKeyId == null))
            {
                logger.Error("Error during saving contacts.");
                return false;
            }
            
            IEnumerable<CONTACTOS_COMI> contacts = _mapper?.Map<IEnumerable<ContactsDto>,
                IEnumerable<CONTACTOS_COMI>>(contactsDtos, res =>
            {
                res.Items.Add("RefId", currentComi);
                res.Items.Add("POCO", _contactos);
            });
            bool retValue = await conn.UpdateAsync(contacts?.ToList());
            return retValue;
        }
        /// <summary>
        ///  This saves all changes. It is reflected to the update method.
        /// </summary>
        /// <returns></returns>
        /// 
        public async Task<bool> SaveChanges()
        {
            bool retValue = true;
            // TODO: shall be reverted and the DTC enabled.   
            using (IDbConnection connection = _executor.OpenNewDbConnection())
            {
                using (TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    try
                    {

                        // now we have to add the new connection.
                        retValue = await connection.UpdateAsync(_currentComisio);
                        retValue = retValue && await SaveContacts(connection, ContactsDto, _currentComisio.NUM_COMI, _contactos);
                        retValue = retValue && await SaveBranches(connection, DelegationDto, _currentComisio.NUM_COMI, _delegations);
                        if (_visitasComis.Count() != 0)
                        {
                            retValue = retValue && await connection.UpdateAsync(_visitasComis);
                        }
                        retValue = true;
                        transactionScope.Complete();

                    }
                    catch (TransactionException ex)
                    {
                        transactionScope.Dispose();
                        MessageBox.Show("Transaction error: " + ex.Message);

                    }
                    catch (System.Exception ex1)
                    {
                        transactionScope.Dispose();
                        string msg = "Error during updating the commission agent: " + ex1.Message;
                        throw new DataLayerExecutionException(msg);
                    }
                }
            }
            return retValue;
        }

        /// <summary>
        /// This delete all data in asynchronous thing.
        /// </summary>
        /// <returns>Returns the data to deleted.</returns>
        public async Task<bool> DeleteAsyncData()
        {
            bool retValue = true;

            // we shall revert this.

            using (IDbConnection connection = _executor.OpenNewDbConnection())
            {

                using (TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    // here i have to delete the current commission data.
                    try
                    {
                        retValue = await connection.DeleteAsync(_currentComisio);
                        // now we have to add the new connection.
                        // delete the cross references.
                        var contactRef = _contactos.FirstOrDefault(c => (c.COMISIO == _currentComisio.NUM_COMI));
                        if (contactRef != null)
                        {

                            retValue = await connection.DeleteAsync(contactRef);
                        }
                        var delegationRef = _delegations.FirstOrDefault(c => (c.cldIdCOMI == _currentComisio.NUM_COMI));
                        var visitasRef =
                            _visitasComis.FirstOrDefault(c => (c.visIdCliente == _currentComisio.NUM_COMI));

                        // This is very common.
                        if (delegationRef != null)
                        {
                            retValue = retValue && await connection.DeleteAsync(delegationRef);
                        }
                        if (visitasRef != null)
                        {
                            retValue = retValue && await connection.DeleteAsync(visitasRef);
                        }
                        //retValue = retValue && await connection.DeleteAsync(_currentComisio);
                        transactionScope.Complete();
                    }
                    catch (TransactionException ex)
                    {
                        logger.Error("Transaction scope error during deleting data.");
                        transactionScope.Dispose();
                        return retValue;
                    }
                    catch (System.Exception ex)
                    {
                        logger.Error("Error during deleting data: " + ex.Message);
                        transactionScope.Dispose();
                        return retValue;
                    }
                    finally
                    {
                        transactionScope.Dispose();
                    }
                }
            }
            return retValue;
        }

        /// <summary>
        ///  This method fill a single value.
        /// </summary>
        public async void FillSingleValue()
        {
            IDbConnection connection = _executor.Connection;
            if (_executor.Connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            string queryProvincia = string.Format(_queryProvincia, _currentComisio.PROVINCIA);
            _provinces = await connection.QueryAsync<PROVINCIA>(queryProvincia).ConfigureAwait(false);
            string queryTipoComi = string.Format(_queryTipoComi, _currentComisio.TIPOCOMI);
            _tipoComis = await connection.QueryAsync<TIPOCOMI>(queryTipoComi).ConfigureAwait(false);
            string queryPais = string.Format(_queryContactos, _currentComisio.NACIOPER);
            _nacioPer = await connection.QueryAsync<Country>(queryPais).ConfigureAwait(false);
            _executor.Close();
        }


        /// <summary>
        ///  Valid data
        /// </summary>
        public bool Valid
        {
            get { return _valid; }
            set { _valid = true; }
        }


        private ICommissionAgentTypeData GetCommissionAgentType(COMISIO data, IEnumerable<TIPOCOMI> tipocomis)
        {
            ICommissionAgentTypeData dataCommission = new CommissionAgentTypeData();
            dataCommission.Code = data.TIPOCOMI;
            // there is a na errro we return a null AgentTypeData
            if (!tipocomis.Any())

            {
                return new NullCommissionAgentTypeData();
            }
            var name = from countryvalue in tipocomis
                       where countryvalue.NUM_TICOMI == data.TIPOCOMI
                       select countryvalue.NOMBRE;
            dataCommission.Name = name.Distinct().First();
            return dataCommission;
        }

        private void SetCommissionAgentTypeData(ICommissionAgentTypeData data)
        {
            _currentComisio.TIPOCOMI = data.Code;
        }
        /// <summary>
        ///  This gives out the time.
        /// </summary>
        public ICommissionAgentTypeData Type
        {
            get
            {
                return GetCommissionAgentType(_currentComisio, _tipoComis);
            }

            set
            {
                SetCommissionAgentTypeData(value);
            }
        }


        public IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }

        public bool HasErrors { get; }
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public void AcceptChanges()
        {
            throw new NotImplementedException();
        }

        public bool IsChanged { get; }
        public void RejectChanges()
        {
            throw new NotImplementedException();
        }
    }
}
