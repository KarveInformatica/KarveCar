using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Dapper;
using NLog;
using KarveDataServices;

namespace DataAccessLayer.SQL
{
    // This class has the responsability to memorize all the queries and format properly
    [Serializable]
    [XmlRoot("QueryStore")]
    public class QueryStore: IQueryStore
    {
        protected Logger Logger = LogManager.GetCurrentClassLogger();
        
        private Dictionary<QueryType, string> _dictionary = new Dictionary<QueryType, string>()
        {
            {
                QueryType.QueryBroker, @"SELECT NUM_COMI as Code, NOMBRE as Name, PERSONA as Person, NIF as Nif, DIRECCION as Direction, POBLACION as City, " +
            "PROVINCIA.PROV as Province, PAIS.PAIS as Country, IATA as IATA,  FROM COMISIO " +
            " LEFT JOIN PROVINCIA ON COMISIO.PROVINCIA = PROVINCIA.SIGLAS " +
                " LEFT JOIN PAIS on COMISIO.NACIOPER = PAIS.SIGLAS;"},
            { QueryType.QueryBrokerSummary, @"SELECT NUM_COMI as Numero, NOMBRE as Nombre, PERSONA as Persona, NIF as Nif, DIRECCION as Direccion, POBLACION as Poblacion, " +
            "PROVINCIA.PROV as Provincia, PAIS.PAIS as Pais FROM COMISIO " +
            " LEFT JOIN PROVINCIA ON COMISIO.PROVINCIA = PROVINCIA.SIGLAS " +
            " LEFT JOIN PAIS on COMISIO.NACIOPER = PAIS.SIGLAS;"},
            { QueryType.QueryPagedClient, @"SELECT TOP {0} START AT {1} CLIENTES1.NUMERO_CLI, * FROM CLIENTES1 INNER JOIN CLIENTES2 ON CLIENTES1.NUMERO_CLI = CLIENTES2.NUMERO_CLI ORDER BY CLIENTES1.NUMERO_CLI" },
            {QueryType.QueryClient1, @"SELECT * FROM CLIENTES1 WHERE NUMERO_CLI='{0}'"},
            {QueryType.QueryClient2, @"SELECT * FROM CLIENTES2 WHERE NUMERO_CLI='{0}'"},
            {QueryType.QueryCity, @"SELECT * FROM POBLACIONES WHERE CP = '{0}'" },
            {QueryType.QueryClientType, @"SELECT * FROM TIPOCLI WHERE NUM_TICLI = '{0}'" },
            {QueryType.QueryCreditCard, @"SELECT * FROM TARCREDI WHERE CODIGO='{0}'"},
            {QueryType.QueryCompany, @"SELECT * FROM SUBLICEN WHERE CODIGO='{0}'"},
            {QueryType.QueryMarket, @"SELECT * FROM MERCADO WHERE CODIGO = '{0}'"},
            {QueryType.QueryLanguage, @"SELECT * FROM IDIOMAS WHERE CODIGO='{0}'"},
            {QueryType.QueryZone, @"SELECT * FROM ZONAS WHERE  NUM_ZONA='{0}'"},
            {QueryType.QuerySeller, @"SELECT * FROM VENDEDOR WHERE NUM_VENDE='{0}'"},
            {QueryType.QueryOffice, @"SELECT * OFICINAS WHERE CODIGO='{0}'" },
            {QueryType.QueryCompanyOffices, @"SELECT * FROM OFICINAS WHERE SUBLICEN='{0}'" },
            {QueryType.QueryOfficeZone, @"SELECT * FROM ZONAOFI WHERE COD_ZONAOFI='{0}'" },
            {QueryType.QueryActivity, @"SELECT * FROM ACTIVI WHERE NUM_ACTIVI='{0}'" },
            {QueryType.QueryProvince, @"SELECT * FROM PROVINCIA WHERE SIGLAS='{0}'" },
            {QueryType.QueryCountry, @"SELECT * FROM PAIS WHERE SIGLAS='{0}'" },
            {QueryType.QueryPaymentForm, @"SELECT * FROM FORMAS WHERE CODIGO='{0}'" },
            {QueryType.QueryOffices, @"SELECT * FROM OFICINAS WHERE CODIGO = '{0}'"},
            {QueryType.HolidaysByOffice, @"SELECT * FROM FESTIVOS_OFICINA WHERE OFICINA = '{0}'"},
            {QueryType.HolidaysDate, @"SELECT * FROM FESTIVOS_OFICINA WHERE FESTIVO = CONVERT(DATETIME,'{0}',101) AND OFICINA='{1}' AND  PARTE_DIA='{2}' AND HORA_DESDE='{3}' AND HORA_HASTA='{4}'"},
            {QueryType.QueryChannel, @"SELECT * FROM CANAL WHERE CODIGO='{0}'" },
            {QueryType.QueryCompanySummary, @"select CODIGO as Code, NOMBRE as Name, TELEFONO as Phone, Direccion as Direction, SUBLICEN.CP as Zip, Poblacion as City, PROVINCIA.PROV as Province, PAIS.PAIS as Country from SUBLICEN LEFT OUTER JOIN PAIS ON SUBLICEN.NACIO = PAIS.PAIS LEFT OUTER JOIN PROVINCIA ON SUBLICEN.PROVINCIA = PROVINCIA.PROV" },
            {QueryType.QueryCurrency, @"select * from currencies;" },
            
            {QueryType.QueryClientSummary, @"SELECT CLIENTES1.NUMERO_CLI as Code, 
                                                    NOMBRE as Name, 
                                                    NIF as Nif,
                                                    DIRECCION as Direction,
                                                    POBLACION as City, 
                                                    TARNUM as NumberCreditCard, 
                                                    TARTI as CreditCardType, 
                                                    CLIENTES1.CP as Zip, 
                                                    CLIENTES2.SECTOR as Sector, 
                                                    PROVINCIA.PROV as Province, 
                                                    PAIS.PAIS as Country, 
                                                    TELEFONO as Phone, 
                                                    OFICINA as Oficina, 
                                                    CLIENTES2.VENDEDOR as Vendidor, 
                                                    ALTA as Falta, 
                                                    MOVIL as Movil 
                                                    from CLIENTES1 
                                                    INNER JOIN CLIENTES2 
                                                    ON CLIENTES2.NUMERO_CLI = CLIENTES1.NUMERO_CLI 
                                                    LEFT OUTER JOIN PROVINCIA 
                                                    ON PROVINCIA.SIGLAS = CLIENTES1.PROVINCIA 
                                                    LEFT OUTER JOIN PAIS 
                                                    ON PAIS.SIGLAS = CLIENTES1.NACIOPER WHERE CLIENTES1.NUMERO_CLI='{0}'"
                                                    },
            {QueryType.QueryOfficeSummary,
                "select OFICINAS.CODIGO as Code, OFICINAS.NOMBRE AS Name, OFICINAS.DIRECCION as Direction,  OFICINAS.TELEFONO as Phone ,OFICINAS.POBLACION as City, OFICINAS.CP as Zip, PROVINCIA.PROV as Province,  SUBLICEN.NOMBRE as CompanyName, ZONAOFI.NOM_ZONA as OfficeZone FROM OFICINAS LEFT OUTER JOIN PROVINCIA   ON OFICINAS.PROVINCIA=PROVINCIA.SIGLAS LEFT OUTER JOIN ZONAOFI ON OFICINAS.ZONAOFI=ZONAOFI.COD_ZONAOFI   LEFT OUTER JOIN SUBLICEN ON OFICINAS.SUBLICEN=SUBLICEN.CODIGO;"},
              {QueryType.QueryOfficeSummaryByCompany, "select OFICINAS.CODIGO as Code, OFICINAS.NOMBRE AS Name, OFICINAS.DIRECCION as Direction, OFICINAS.POBLACION as City, PROVINCIA.PROV as Province, SUBLICEN.NOMBRE as CompanyName, ZONAOFI.NOM_ZONA as OfficeZone FROM OFICINAS LEFT OUTER JOIN PROVINCIA " +
                "ON OFICINAS.PROVINCIA=PROVINCIA.SIGLAS LEFT OUTER JOIN ZONAOFI ON OFICINAS.ZONAOFI=ZONAOFI.COD_ZONAOFI " +
                "LEFT OUTER JOIN SUBLICEN ON OFICINAS.SUBLICEN=SUBLICEN.CODIGO WHERE SUBLICEN='{0}';" },
            {QueryType.QueryClientSummaryExt, "SELECT CLIENTES1.NUMERO_CLI as Code, NOMBRE as Name,NIF as Nif,TELEFONO as Phone,MOVIL as Movil,EMAIL as Email, DIRECCION as Direction,CLIENTES1.CP as Zip,POBLACION as City,PROVINCIA.PROV as Province,PAIS.PAIS as Country,TARTI as CreditCardType, TARNUM as NumberCreditCard,FPAGO as PaymentForm,CONTABLE as AccountableAccount,CLIENTES2.SECTOR as Sector,ZONA as Zone,ORIGEN as Origin, CLIENTES2.VENDEDOR as Reseller,OFICINA as Office,COMERCIAL as Commercial,ALTA as Falta,FENAC as BirthDate from CLIENTES1 INNER JOIN CLIENTES2 ON CLIENTES2.NUMERO_CLI = CLIENTES1.NUMERO_CLI LEFT OUTER JOIN PROVINCIA ON PROVINCIA.SIGLAS = CLIENTES1.PROVINCIA LEFT OUTER JOIN PAIS ON PAIS.SIGLAS = CLIENTES1.NACIOPER"},
            { QueryType.QueryClientPagedSummary, @"SELECT TOP {0} START AT {1} CLIENTES1.NUMERO_CLI as Code, 
                                                    NOMBRE as Name, 
                                                    NIF as Nif,
                                                    TELEFONO as Phone,  
                                                    MOVIL as Movil,
                                                    EMAIL as Email,
                                                    DIRECCION as Direction,
                                                    CLIENTES1.CP as Zip, 
                                                    POBLACION as City, 
                                                    PROVINCIA.PROV as Province, 
                                                    PAIS.PAIS as Country, 
                                                    TARTI as CreditCardType, 
                                                    TARNUM as NumberCreditCard, 
                                                    FPAGO as PaymentForm,
                                                    CONTABLE as AccountableAccount,
                                                    CLIENTES2.SECTOR as Sector,
                                                    ZONA as Zone,
                                                    ORIGEN as Origin,
                                                    CLIENTES2.VENDEDOR as Reseller,
                                                    OFICINA as Office, 
                                                    COMERCIAL as Commercial
                                                    ALTA as Falta, 
                                                    FENAC as BirthDate
                                                    from CLIENTES1 
                                                    INNER JOIN CLIENTES2 
                                                    ON CLIENTES2.NUMERO_CLI = CLIENTES1.NUMERO_CLI 
                                                    LEFT OUTER JOIN PROVINCIA 
                                                    ON PROVINCIA.SIGLAS = CLIENTES1.PROVINCIA 
                                                    LEFT OUTER JOIN PAIS 
                                                    ON PAIS.SIGLAS = CLIENTES1.NACIOPER WHERE CLIENTES1.NUMERO_CLI='{0}'"
                                                    },
            {QueryType.QueryClientContacts, @"SELECT ccoIdContacto, ccoContacto,DL.cldIdDelega as idDelegacion, DL.cldDelegacion as nombreDelegacion,NIF, ccoCargo,ccoTelefono, ccoMovil, ccoFax, ccoMail,CC.ULTMODI as ULTMODI,CC.USUARIO as USUARIO FROM CliContactos AS CC LEFT OUTER JOIN PERCARGOS AS PG ON CC.ccoCargo = PG.CODIGO LEFT OUTER JOIN CliDelega AS DL ON CC.ccoIdDelega = DL.CLDIDDELEGA AND CC.ccoIdCliente = DL.cldIdCliente  WHERE cldIdCliente='{0}' ORDER BY CC.ccoContacto"},
            { QueryType.QuerySupplierSummary, @"SELECT " },
            { QueryType.QueryVehicleSummary, @"SELECT vehiculo1.codiint As Code, matricula as Matricula, 
                MARCAS.NOMBRE as Marca, modelo as Model, grupo as Group, oficina as Office, NUMPLAZAS as Places, ACTIVIDAD as Activity, Color as Color, METROS_CUB as CubeMeters, PROPIE as Owner, CIASEGU as AssuranceCompany, CIALES as LeasingCompany, FSEGB as LeavingDate, FSEGA as StartingDate, CLIENTE1.NUMERO_CLI as ClientNumber, CLIENTE1.NOMBRE as Client, TIPOREV as Policy,    
                 VEHICULO2.KM as Kilometers, COMPRAFRA as PurchaseInvoice, BASTIDOR as Frame,  NUM_MOTOR as MotorNumber, ANOMODELO as ModelYear, REF as Referencia, KeyCode as LLAVE, LLAVE2 as StorageKey  FROM VEHICULO1 " +
            " LEFT OUTER JOIN CLIENTES1 ON VEHICULO1.CLIENTE = CLIENTES1.NUMERO_CLI "+
            " LEFT OUTER JOIN MARCAS ON VEHICULO1.MARCA = MARCA.NOMBRE " +
             " INNER JOIN VEHICULO2 ON VEHICULO1.CODIINT = VEHICULO2.CODIINT"},
             { QueryType.QueryVehicleSummaryPaged, @"SELECT TOP {0} START AT {1} vehiculo1.codiint As Code, matricula as Matricula, MARCAS.NOMBRE as Marca, modelo as Model, grupo as Group, oficina as Office, NUMPLAZAS as Places, ACTIVIDAD as Activity, Color as Color, METROS_CUB as CubeMeters, PROPIE as Owner, CIASEGU as AssuranceCompany, CIALES as LeasingCompany, FSEGB as LeavingDate, FSEGA as StartingDate, CLIENTE1.NUMERO_CLI as ClientNumber, CLIENTE1.NOMBRE as Client, TIPOREV as Policy,    
                 VEHICULO2.KM as Kilometers, COMPRAFRA as PurchaseInvoice, BASTIDOR as Frame,  NUM_MOTOR as MotorNumber, ANOMODELO as ModelYear, REF as Referencia, KeyCode as LLAVE, LLAVE2 as StorageKey  FROM VEHICULO1 LEFT OUTER JOIN CLIENTES1 ON VEHICULO1.CLIENTE = CLIENTES1.NUMERO_CLI "+
                 " LEFT OUTER JOIN MARCAS ON VEHICULO1.MARCA = MARCA.NOMBRE " +
                " INNER JOIN VEHICULO2 ON VEHICULO1.CODIINT = VEHICULO2.CODIINT"},
            {QueryType.QueryInvoiceSummaryExtended, "select distinct numero_fac as InvoiceName, serie_fac as InvoiceSerie, referen_fac as InvoiceRef, cliente_fac as InvoiceCode, CONTRATO_FAC as InvoiceContract,c.nombre as ClientName, fecha_fac as InvoiceDate, cuota_fac as InvoiceFee, base_fac as InvoiceBase, todo_fac as TotalInvoice, f.FRATIPIMPR as InvoiceType, c2.contable as Account, sublicen_fac as CompanyCode, s.NOMBRE as CompanyName, oficina_fac as OfficeCode, asiento_fac as Seat, fserv_a as InvoiceTo, fserv_de as InvoiceFrom, observaciones_fac as Notes, usuario_fac as InvoiceUser, ultmodi_fac as LastModification, vienede_fac as ComeFrom from facturas as f " +
                "left outer join sublicen as s on f.sublicen_fac = s.CODIGO " +
                "inner join clientes1 as c on f.cliente_fac = c.numero_cli " +
                "inner join clientes2 as c2 on c.numero_cli = c2.numero_cli;" },
            {QueryType.QuerySellerSummary, "select NUM_VENDE, NOMBRE, DIRECCION, POBLACION, VENDEDOR.CP, PR.PROV as PROVINCIA, TELEFONO,MOVIL FROM VENDEDOR left outer join provincia as pr on pr.SIGLAS = VENDEDOR.PROVINCIA" },
            {QueryType.QueryCommissionAgentSummary, "SELECT NUM_COMI as Code, NOMBRE as Name, PERSONA as Person, NIF as Nif, DIRECCION as Direction, PROVINCIA.CP as Zip, POBLACION as City, PROVINCIA.PROV as Province, PAIS.PAIS as Country,IATA, SUBLICEN as Company,  ZONAOFI as OfficeZone, COMISIO.ULTMODI as LastModification, COMISIO.USUARIO as CurrentUser  FROM COMISIO LEFT OUTER JOIN PROVINCIA ON COMISIO.PROVINCIA = PROVINCIA.SIGLAS LEFT OUTER JOIN PAIS on COMISIO.NACIOPER = PAIS.SIGLAS;"},
            { QueryType.QueryBrokerContacts, "SELECT CONTACTO,COMISIO,NOM_CONTACTO, NIF, PG.CODIGO as CARGO, PG.NOMBRE AS NOM_CARGO, TELEFONO, MOVIL, FAX, EMAIL, CC.USUARIO, CC.ULTMODI, DL.CLDIDDELEGA as DelegaId, cldDelegacion DELEGACC_NOM FROM CONTACTOS_COMI AS CC LEFT OUTER JOIN PERCARGOS AS PG ON CC.CARGO = PG.CODIGO LEFT OUTER JOIN COMI_DELEGA AS DL ON CC.DELEGA_CC = DL.CLDIDDELEGA AND CC.COMISIO = DL.CLDIDCOMI WHERE COMISIO = '{0}' ORDER BY CC.CONTACTO;" },
            { QueryType.QueryResellerByClient, "SELECT visIdVisita as VisitId,visIdCliente as ClientId,visIdContacto as VisitClientId,visFecha as VisitDate,visIdVendedor as VisitResellerId,visIdVisitaTipo as VisitTypeId,PEDIDO as VisitOrder, PV.CONTACTO as ContactId,TV.CODIGO_VIS as VisitCode, TV.NOMBRE_VIS as VisitTypeName, TV.ULTMODI as VisitTypeLastModification, TV.USUARIO as VisitTypeUser , NUM_VENDE as ResellerId, PV.nom_contacto AS ContactName, VE.NOMBRE as ResellerName, VE.MOVIL as ResellerCellPhone FROM VISITAS_COMI CC LEFT OUTER JOIN CONTACTOS_COMI PV ON PV.COMISIO = CC.VISIDCLIENTE AND PV.CONTACTO = CC.VISIDCONTACTO LEFT OUTER JOIN TIPOVISITAS TV ON TV.CODIGO_VIS = CC.VISIDVISITATIPO LEFT OUTER JOIN VENDEDOR VE ON VE.NUM_VENDE = CC.visIdVendedor WHERE VISIDCLIENTE='{0}' ORDER BY CC.visFECHA;"},
            { QueryType.QuerySupplierById, "SELECT PROVEE1.NUM_PROVEE as NUM_PROVEE,NIF,TIPO,NOMBRE,DIRECCION,DIREC2,CP,PROVEE2.COMERCIAL,PROVEE2.PREFIJO,PROVEE2.CONTABLE,PROVEE2.FORPA,PROVEE2.PLAZO,PROVEE2.PLAZO2,PROVEE2.PLAZO3,PROVEE2.DIA,PROVEE2.PALBARAN, PROVEE2.INTRACO,PROVEE2.DIA2,PROVEE2.DIA3,PROVEE2.DTO,PROVEE2.PP,PROVEE2.DIVISA,PROVEE2.PALBARAN,PROVEE2.INTRACO,POBLACION,PROV,NACIOPER,TELEFONO,FAX,MOVIL,INTERNET,EMAIL,PERSONA,          SUBLICEN,GESTION_IVA_IMPORTA,OFICINA,FBAJA,FALTA,NOTAS,OBSERVA,CTAPAGO,TIPOIVA,MESVACA,MESVACA2,CC,IBAN,BANCO,SWIFT,IDIOMA_PR1,GESTION_IVA_IMPORTA,NOAUTOMARGEN,PROALB_COSTE_TRANSP,EXENCIONES_INT,CTALP,CONTABLE,CUGASTO,RETENCION,CTAPAGO,AUTOFAC_MANTE,CTACP,CTALP,DIR_PAGO,DIR2_PAGO,CP_PAGO,POB_PAGO, PROV_PAGO,PAIS_PAGO,TELF_PAGO,FAX_PAGO, PERSONA_PAGO,MAIL_PAGO,DIR_DEVO,     DIR2_DEVO,POB_DEVO,CP_DEVO,PROV_DEVO,PAIS_DEVO,TELF_DEVO,FAX_DEVO,PERSONA_DEVO,MAIL_DEVO, DIR_RECLAMA,DIR2_RECLAMA,                                         CP_RECLAMA,POB_RECLAMA,PROV_RECLAMA,PAIS_RECLAMA,TELF_RECLAMA,FAX_RECLAMA,PERSONA_RECLAMA,MAIL_RECLAMA,VIA,FORMA_ENVIO,CONDICION_VENTA,DIRENVIO6,CTAINTRACOP,ctaintracoPRep FROM PROVEE1 INNER JOIN PROVEE2 ON PROVEE1.NUM_PROVEE = PROVEE2.NUM_PROVEE WHERE NUM_PROVEE='{0}'"},
            {QueryType.QuerySuppliersBranches, "SELECT cldIdDelega, cldDelegacion,cldDireccion1,cldDireccion2, cldIdProvincia, cldPoblacion, cldTelefono1, cldTelefono2, cldEmail,cldFax,CP as CP, PROV as NOM_PROV FROM ProDelega LEFT OUTER JOIN PROVINCIA ON cldIdProvincia = PROVINCIA.SIGLAS WHERE cldIdCliente={0} ORDER BY cldIdCliente;" }
        };
        
        /// <summary>
        ///  Working memory to assign and build a query.
        /// </summary>
        private Dictionary<QueryType, string> _memoryStore = new Dictionary<QueryType, string>();

        /// <summary>
        ///  Get the list of the available queries in the system.
        /// </summary>
        [XmlElement("Queries")]
        public Dictionary<QueryType, string> Queries
        {
            get { return _dictionary; }
        }

       
         
        /// <summary>
        /// Build a query set for using with the dapper multiple query command.
        /// </summary>
        /// <param name="queryList">List of queries</param>
        /// <param name="codeList">List of codes</param>
        /// <returns></returns>
        private IList<string> BuildQuerySet(List<QueryType> queryList, List<string> codeList)
        {
            List<string> currentList = new List<string>();
            if (queryList.Count != codeList.Count)
            {
                return new List<string>();
            }
            int i = 0;
            foreach (var typeOfQuery in queryList)
            {
                var valueofQuery = "";
                _dictionary.TryGetValue(typeOfQuery, out valueofQuery);
                if (!string.IsNullOrEmpty(valueofQuery))
                {
                    var value = string.Empty;
                    if (string.IsNullOrEmpty(codeList[i]))
                    {
                        value = valueofQuery;
                    }
                    else
                    {
                        value = string.Format(valueofQuery, codeList[i]);
                    }
                    i++;
                    currentList.Add(value);
                }
                
            }
            return currentList;
        }
        /// <summary>
        /// Assign to each query a code in the where clause.
        /// </summary>
        /// <param name="queryList">List of query type</param>
        /// <param name="codeList">List of codes</param>
        /// <returns>A string containing the queries with the clauses.</returns>
        private string BuildMultipleQuery(List<QueryType> queryList, List<string> codeList)
        {
            IList<string> currentValue = BuildQuerySet(queryList, codeList);
            StringBuilder builder =  new StringBuilder();
            foreach (var v in currentValue)
            {
                builder.Append(v);
                builder.Append(";");
            }
            return builder.ToString();
        }

        /// <summary>
        ///  Add the query range
        /// </summary>
        /// <param name="query">Type of the query</param>
        /// <param name="start">start position</param>
        /// <param name="stop">End position.</param>
        public void AddParamRange(QueryType query, long start, long stop)
        {
            var tmpQuery = "";
            _dictionary.TryGetValue(query, out tmpQuery);
            tmpQuery = string.Format(tmpQuery, start, stop);
            _memoryStore.Add(query, tmpQuery);
        }
        /// <summary>
        ///  Parameter list.
        /// </summary>
        /// <param name="query">Type of the query</param>
        /// <param name="parameter">List of parameters</param>
        public void AddParam(QueryType query, IList<string> parameter)
        {
            object[] args = new object[parameter.Count];
            int k = 0;
            foreach (var p in parameter)
            {
                args[k] = p;
                k++;
            }
            var tmpQuery = "";
            _dictionary.TryGetValue(query, out tmpQuery);
            tmpQuery = string.Format(tmpQuery, args);
            _memoryStore.Add(query, tmpQuery);
        }
    /// <summary>
    /// Add a parameter to build in the memory store.
    /// </summary>
    /// <param name="queryCity">Kind of query type</param>
    /// <param name="code">Code of the query</param>
    public void AddParam(QueryType queryCity, string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                Logger.Debug(queryCity.ToString());
                if (!_memoryStore.ContainsKey(queryCity))
                {
                    _memoryStore.Add(queryCity, code);
                }
            }
            
        }
        /// <summary>
        /// Build the query and returns the values.
        /// </summary>
        /// <returns>This returns the query.</returns>
        public string BuildQuery()
        {
            List<QueryType> keys = _memoryStore.Keys.AsList();
            List<string> values = _memoryStore.Values.AsList();
            var value = BuildMultipleQuery(keys, values);
            _memoryStore.Clear();
            return value;
        }
        /// <summary>
        ///  Clear the query store.
        /// </summary>
        public void Clear()
        {
            _memoryStore.Clear();
        }
        /// <summary>
        ///  Add a parameter for the query type.
        /// </summary>
        /// <param name="query">Query type</param>
        public void AddParam(QueryType query)
        {
            _memoryStore.Add(query, string.Empty);
        }
        /// <summary>
        ///  Get an instanct of the query store
        /// </summary>
        /// <returns>An instance of the query store</returns>
        public static QueryStore GetInstance()
        {
            var qs = new QueryStore();
            return qs;
        }
    }
}
