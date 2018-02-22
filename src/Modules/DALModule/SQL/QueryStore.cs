using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Dapper;
using NLog;

namespace DataAccessLayer.SQL
{
    // This class has the responsability to memorize all the queries and format properly
    [Serializable]
    [XmlRoot("QueryStore")]
    public class QueryStore
    {
        protected Logger Logger = LogManager.GetCurrentClassLogger();
        public enum QueryType
        {
            QueryCity,
            QueryMarket,
            QueryCompany,
            QueryLanguage,
            QueryCreditCard,
            QueryZone,
            QueryOfficeZone,
            QuerySeller,
            QueryOffice,
            QueryActivity,
            QueryProvince,
            QueryPaymentForm,
            QueryChannel,
            QueryClientType,
            QueryRentingUse,
            QueryClientSummary,
            QueryClientContacts,
            QueryClient1,
            QueryClient2,
            DeleteClientContacts,
            DeleteClientBranches,
            DeleteClientVisits,
            QueryPagedClient,
            QueryClientPagedSummary,
            QueryPagedCompany,
            QueryCompanySummary,
            QueryCountry,
            QueryOffices,
            QueryOfficeSummary,
            QueryOfficeSummaryByCompany,
            HolidaysByOffice,
            HolidaysDate,
        }

        private Dictionary<QueryType, string> _dictionary = new Dictionary<QueryType, string>()
        {
            
            { QueryType.QueryPagedClient, @"SELECT TOP {0} START AT {1} CLIENTES1.NUMERO_CLI, * FROM CLIENTES1 INNER JOIN CLIENTES2 ON CLIENTES1.NUMERO_CLI = CLIENTES2.NUMERO_CLI ORDER BY CLIENTES1.NUMERO_CLI" },
            {QueryType.QueryClient1, @"SELECT * FROM CLIENTES1 WHERE NUMERO_CLI='{0}'"},
            {QueryType.QueryClient2, @"SELECT * FROM CLIENTES2 WHERE NUMERO_CLI='{0}'"},
            {QueryType.QueryCity, @"SELECT CP,POBLA FROM POBLACIONES WHERE CP = '{0}'" },
            {QueryType.QueryClientType, @"SELECT NUM_TICLI,NOMBRE FROM TIPOCLI WHERE NUM_TICLI = '{0}'" },
            {QueryType.QueryCreditCard, @"SELECT CODIGO, NOMBRE FROM TARCREDI WHERE CODIGO='{0}'"},
            {QueryType.QueryCompany, @"SELECT CODIGO, NOMBRE FROM SUBLICEN WHERE CODIGO='{0}'"},
            {QueryType.QueryMarket, @"SELECT CODIGO, NOMBRE FROM MERCADO WHERE CODIGO = '{0}'"},
            {QueryType.QueryLanguage, @"SELECT CODIGO, NOMBRE FROM IDIOMAS WHERE CODIGO='{0}'"},
            {QueryType.QueryZone, @"SELECT NUM_ZONA,NOMBRE FROM ZONAS WHERE  NUM_ZONA='{0}'"},
            {QueryType.QuerySeller, @"SELECT NUM_VENDE, NOMBRE FROM VENDEDOR WHERE NUM_VENDE='{0}'"},
            {QueryType.QueryOffice, @"SELECT CODIGO, NOMBRE FROM OFICINAS WHERE CODIGO='{0}'" },
            {QueryType.QueryOfficeZone, @"SELECT COD_ZONAOFI, NOM_ZONA FROM ZONAOFI WHERE COD_ZONAOFI='{0}'" },
            {QueryType.QueryActivity, @"SELECT NUM_ACTIVI,NOMBRE FROM ACTIVI WHERE NUM_ACTIVI='{0}'" },
            {QueryType.QueryProvince, @"SELECT SIGLAS,PROV FROM PROVINCIA WHERE SIGLAS='{0}'" },
            {QueryType.QueryCountry, @"SELECT SIGLAS,PAIS FROM PAIS WHERE SIGLAS='{0}'" },
            {QueryType.QueryPaymentForm, @"SELECT CODIGO,NOMBRE FROM FORMAS WHERE CODIGO='{0}'" },
            {QueryType.QueryOffices, @"SELECT * FROM OFICINAS WHERE SUBLICEN = '{0}'"},
            {QueryType.HolidaysByOffice, @"SELECT * FROM FESTIVOS_OFICINAS WHERE OFICINA = '{0}'"},
            {QueryType.HolidaysDate, @"SELECT * FROM FESTIVOS_OFICINA WHERE FESTIVO = CONVERT(DATETIME,'{0}',101) AND OFICINA='{1}' AND  PARTE_DIA='{2}' AND HORA_DESDE='{3}' AND HORA_HASTA='{4}'"},
            {QueryType.QueryChannel, @"SELECT CODIGO,NOMBRE FROM CANAL WHERE CODIGO='{0}'" },
            {QueryType.QueryCompanySummary, @"select CODIGO as Code, NOMBRE as Name, TELEFONO as Phone, Direccion as Direction, SUBLICEN.CP as Zip, Poblacion as City, PROVINCIA.PROV as Province, PAIS.PAIS as Country from SUBLICEN LEFT OUTER JOIN PAIS ON SUBLICEN.NACIO = PAIS.PAIS LEFT OUTER JOIN PROVINCIA ON SUBLICEN.PROVINCIA = PROVINCIA.PROV" },

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
            {QueryType.QueryOfficeSummary, "select OFICINAS.CODIGO as Code, OFICINAS.NOMBRE AS Name, OFICINAS.DIRECCION as Direction, OFICINAS.POBLACION as City, PROVINCIA.PROV as Province, SUBLICEN.NOMBRE as CompanyName, ZONAOFI.NOM_ZONA as OfficeZone FROM OFICINAS LEFT OUTER JOIN PROVINCIA " +
                "ON OFICINAS.PROVINCIA=PROVINCIA.SIGLAS LEFT OUTER JOIN ZONAOFI ON OFICINAS.ZONAOFI=ZONAOFI.COD_ZONAOFI " +
                "LEFT OUTER JOIN SUBLICEN ON OFICINAS.SUBLICEN=SUBLICEN.CODIGO;" },
              {QueryType.QueryOfficeSummaryByCompany, "select OFICINAS.CODIGO as Code, OFICINAS.NOMBRE AS Name, OFICINAS.DIRECCION as Direction, OFICINAS.POBLACION as City, PROVINCIA.PROV as Province, SUBLICEN.NOMBRE as CompanyName, ZONAOFI.NOM_ZONA as OfficeZone FROM OFICINAS LEFT OUTER JOIN PROVINCIA " +
                "ON OFICINAS.PROVINCIA=PROVINCIA.SIGLAS LEFT OUTER JOIN ZONAOFI ON OFICINAS.ZONAOFI=ZONAOFI.COD_ZONAOFI " +
                "LEFT OUTER JOIN SUBLICEN ON OFICINAS.SUBLICEN=SUBLICEN.CODIGO WHERE SUBLICEN='{0}';" },

            { QueryType.QueryClientPagedSummary, @"SELECT TOP {0} START AT {1} CLIENTES1.NUMERO_CLI as Code, 
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
            {QueryType.QueryClientContacts, @"SELECT ccoIdContacto, ccoContacto,DL.cldIdDelega as idDelegacion, DL.cldDelegacion as nombreDelegacion,NIF, ccoCargo,ccoTelefono, ccoMovil, ccoFax, ccoMail,CC.ULTMODI as ULTMODI,CC.USUARIO as USUARIO FROM CliContactos AS CC LEFT OUTER JOIN PERCARGOS AS PG ON CC.ccoCargo = PG.CODIGO LEFT OUTER JOIN CliDelega AS DL ON CC.ccoIdDelega = DL.CLDIDDELEGA AND CC.ccoIdCliente = DL.cldIdCliente  WHERE cldIdCliente='{0}' ORDER BY CC.ccoContacto"}
        };
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
        /// Build a query set.
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
                        value = string.Format(valueofQuery, codeList[i++]);
                    }
                    
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


        public void AddParam(QueryType query)
        {
            _memoryStore.Add(query, string.Empty);
        }
    }
}
