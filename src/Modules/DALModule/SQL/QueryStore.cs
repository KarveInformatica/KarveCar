using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using NLog;
using KarveCommonInterfaces;
using System.ComponentModel;
using System.Linq;
using ExtendedXmlSerialization;
using System.Xml;

namespace DataAccessLayer.SQL
{
    /*
     * This class has the responsability to memorize all the queries and format properly.
     *  This class will use a Working Memory for manipulate the queries, concatenate queries in an unique query to
     *  be executed from the Dapper.
     */
    [Serializable]
    [XmlRoot("QueryStore")]
    public class QueryStore : IQueryStore
    {
        [XmlIgnore]
        protected Logger Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// This dictionary is needed from the query store to create select count(*) from table 
        /// The table needs the table name and its primary key. 
        /// There is a mechanism in the query store for multiple query. We always preceed a select count(*) 
        /// and a query in dapper query multiple mechanism. This allows us to know whether
        /// or not we have to parse result later.
        /// </summary>
        [XmlElement("PrimaryKeys")]
        protected Dictionary<QueryType, Tuple<string, string>> _paramDictionary = new Dictionary<QueryType, Tuple<string, string>>

        {
             {  QueryType.QueryAccount, new Tuple<string,string>("CU1", "CODIGO") },
             {  QueryType.QueryAgentByVehicle, new Tuple<string,string>("AGENTES", "NUM_AG") },
             {  QueryType.QueryAgencyEmployee, new Tuple<string, string>("EAGE","NUM_EAGE") },
             {  QueryType.QueryBookingMedia, new Tuple<string, string>("MEDIO_RES", "CODIGO") },
             {  QueryType.QueryBookingType, new Tuple<string, string>("TIPOS_RESERVAS", "CODIGO") },
             {  QueryType.QueryBookingIncident, new Tuple<string, string>("INCRE","COD_INCI") },
             {  QueryType.QueryBookingIncidentSummary, new Tuple<string, string>("INCRE", "COD_INCI") },
             {  QueryType.QueryBookingIncidentType, new Tuple<string, string>("COINRE", "CODIGO") },
             {  QueryType.QueryBrandByVehicle, new Tuple<string,string>("MARCAS", "CODIGO") }, 
             {  QueryType.QueryBudgetSummary, new Tuple<string, string>("PRESUP1", "NUMERO_PRE") },
             {  QueryType.QueryBudgetSummaryById, new Tuple<string, string>("PRESUP1", "NUMERO_PRE") },
             {  QueryType.QueryBudgetSummaryPaged, new Tuple<string, string>("PRESUP1","NUMERO_PRE") },
             {  QueryType.QueryCity, new Tuple<string,string>("POBLACIONES", "CP") },
             {  QueryType.QueryCityByName, new Tuple<string,string>("POBLACIONES", "POBLA") },
             {  QueryType.QueryClientSummaryExtById, new Tuple<string,string>("CLIENTES1", "NUMERO_CLI") },
             {  QueryType.QueryClientContacts, new Tuple<string, string>("CliContactos","cldIdCliente") },
             {  QueryType.QueryCompany, new Tuple<string,string>("SUBLICEN", "CODIGO") },
             {  QueryType.QueryCompanyOffices, new Tuple<string,string>("OFICINAS", "CODIGO") },
             {  QueryType.QueryContractsByClient, new Tuple<string, string>("CONTRATOS1", "NUMERO")},
             {  QueryType.QueryCountry, new Tuple<string,string>("PAIS", "SIGLAS") },
             {  QueryType.QueryCommissionAgentSummaryById, new Tuple<string, string>("COMISIO", "NUM_COMI") },
             {  QueryType.QueryCurrency, new Tuple<string,string>("DIVISAS", "CODIGO") },
             {  QueryType.QueryCurrencyValue, new Tuple<string,string>("CURRENCIES", "CODIGO_CUR") },
             {  QueryType.QueryDeptContable, new Tuple<string, string>("DELEGA", "NUM_DELEGA") },
             {  QueryType.QueryDelivering, new Tuple<string, string>("ENTREGAS","CODIGO") },
             {  QueryType.QueryDeliveringBy, new Tuple<string, string>("ENTREGAS","CODIGO") },
             {  QueryType.QueryDeliveringFrom, new Tuple<string, string>("FORMA_PEDENT", "CODIGO")  },
             {  QueryType.QueryReseller, new Tuple<string,string>("VENDEDOR", "NUM_VENDE") },
             {  QueryType.QuerySupplierSummaryById, new Tuple<string,string>("PROVEE1", "NUM_PROVEE") },
             {  QueryType.QueryProvince, new Tuple<string,string>("PROVINCIA", "CP") },
             {  QueryType.QueryFares, new Tuple<string,string>("NTARI", "CODIGO") },
             {  QueryType.QueryOrigin, new Tuple<string,string>("ORIGEN", "NUM_ORIGEN") },
             {  QueryType.QueryOffice, new Tuple<string,string>("OFICINAS", "CODIGO") },
             {  QueryType.QueryOfficePaged, new Tuple<string,string>("OFICINAS", "CODIGO") },
             {  QueryType.QueryOfficeZone, new Tuple<string,string>("ZONAOFI", "COD_ZONAOFI") },
             {  QueryType.QueryPaymentForm, new Tuple<string,string>("FORMAS", "CODIGO") },
             {  QueryType.QueryRefusedBooking, new Tuple<string,string>("MOTANU", "CODIGO") },
             {  QueryType.QueryReservationRequestReason, new Tuple<string,string>("MOPETI", "CODIGO") },
             {  QueryType.QueryVehicle, new Tuple<string,string>("VEHICULO1", "CODIINT") },
             {  QueryType.QueryVehicleColor, new Tuple<string,string>("COLORFL", "CODIGO") },
             {  QueryType.QueryVehicleGroup, new Tuple<string,string>("GRUPOS", "CODIGO") },
             {  QueryType.QueryVehicleSummaryById, new Tuple<string,string>("VEHICULO1", "CODIINT") },
             {  QueryType.QueryVehicleActivity, new Tuple<string,string>("ACTIVEHI", "NUM_ACTIVEHI") },
             {  QueryType.QueryVehicleOwner, new Tuple<string,string>("PROPIE", "NUM_PROPIE") },
             {  QueryType.HolidaysByOffice, new Tuple<string,string>("FESTIVOS_OFICINA", "OFICINA") },
             {  QueryType.QueryPrintingType, new Tuple<string, string>("CONTRATIPIMPR","CODIGO") }
        };
        [XmlElement("StaticQueries")]
        protected Dictionary<QueryType, string> _dictionary = new Dictionary<QueryType, string>()
        {
             {  QueryType.QueryAgencyEmployee, @"SELECT * FROM EAGE"},
             {
                QueryType.QueryBroker, @"SELECT NUM_COMI as Code, NOMBRE as Name, PERSONA as Person, NIF as Nif, DIRECCION as Direction, POBLACION as City, " +
            "PROVINCIA.PROV as Province, PAIS.PAIS as Country, IATA as IATA,  FROM COMISIO " +
            " LEFT JOIN PROVINCIA ON COMISIO.PROVINCIA = PROVINCIA.SIGLAS " +
                " LEFT JOIN PAIS on COMISIO.NACIOPER = PAIS.SIGLAS;"},
            { QueryType.QueryBrokerSummary, @"SELECT NUM_COMI as Numero, NOMBRE as Nombre, PERSONA as Persona, NIF as Nif, DIRECCION as Direccion, POBLACION as Poblacion, " +
            "PROVINCIA.PROV as Provincia, PAIS.PAIS as Pais FROM COMISIO " +
            " LEFT JOIN PROVINCIA ON COMISIO.PROVINCIA = PROVINCIA.SIGLAS " +
            " LEFT JOIN PAIS on COMISIO.NACIOPER = PAIS.SIGLAS;"},
            { QueryType.QueryBookingIncidentType, @"SELECT * FROM COINRE WHERE CODIGO='{0}';" },
            { QueryType.QueryBookingIncident, @"SELECT * FROM INCIRE WHERE CODIGO='{0}';" },
            { QueryType.QueryBookingIncidentSummary, @"SELECT COD_INCI as Code, ID_INCIDEN as Name, RESERVA as Booking, CORTO as Notes FROM INCIRE;" },
            { QueryType.QueryBookingIncidentSummaryPaged, "SELECT TOP {0} START AT {1}  COD_INCI as Code, ID_INCIDEN as Name, RESERVA as Booking, CORTO as Notes FROM INCIRE;" },

            {
                 QueryType.QueryBookedPaged, "SELECT TOP {0} START AT {1} * FROM RESERVAS1 INNER JOIN RESERVAS2 ON RESERVAS1.NUMERO_RES = RESERVAS2.NUMERO_RES"
            },

            { QueryType.QueryBookingSummaryExt, "select * from reservas1;" },
                       { QueryType.QueryBookingAllFields,"SELECT RESERVAS1.NUMERO_RES as BookingNumber, RESERVAS1.NOMBRE_RES1 as BookingName, RESERVAS1.FECHA_RES1 as BookingDate, RESERVAS1.LOCALIZA_RES1 as Locator, OFFICE.CODIGO AS OfficeCode, OFFICE.ZONAOFI AS OfficeZone, OFFICE.NOMBRE as OfficeName, RESERVAS1.GRUPO_RES1 as BookingGroup, RESERVAS1.RENTAL1_RES1 AS BookerUserCode, RESERVAS1.FSALIDA_RES1 as DepartureDate, RESERVAS1.HSALIDA_RES1 as DepartureHour, US1.NOMBRE as BookerUserName, DRIVER.NOMBRE as DriverName, DRIVER.NUMERO_CLI as DriverCode, RESERVAS1.USUARIO_RES1 AS CurrentUser, RESERVAS2.OBS1_RES2 as Notes, RESERVAS2.ORIGEN_RES2 as BookingOrigin, RESERVAS2.MULDIR_RES2 as MultipleDirection, RESERVAS1.ULTMODI_RES1 as LastModification, RESERVAS2.COMISIO_RES2 as BookingBroker, RESERVAS2.TOLON_RES2 as DepositTotal, RESERVAS1.contrato_res1 as Contract, RESERVAS1.FIANZA_DEPOSITO_RES1 as Deposit, RESERVAS1.TARIFA_RES1 as Fare, RESERVAS1.LUENTRE_RES1 as DeliveryPlace, RESERVAS1.LUDEVO_RES1 as ReturnPlace, RESERVAS1.RECHAZAFECHA as RejectionDate, RESERVAS1.FPREV_RES1 as ReturnDate, RESERVAS1.HPREV_RES1 as ReturnTime, V1.MATRICULA as RegistrationNumber, V1.MODELO as VehicleModel, V1.SITUACION as VehicleSituation, RESERVAS2.BONONUM_RES2 as Bonus, CLIENT1.NUMERO_CLI as ClientCode,CLIENT1.NOMBRE as ClientName, RESERVAS2.CONFIRMADA_RES2 as Confirmed, RESERVAS2.OTROCOND_RES2 as OtherDriver, RESERVAS2.OTRO2COND_RES2 as OtherDriver2, RESERVAS2.OTRO3COND_RES2 as OtherDriver3, (select sum(importe) from cobros where reserva = RESERVAS1.NUMERO_RES) as BookingBill, (select NOMBRE from ORIGEN where NUM_ORIGEN=BookingOrigin) as BookingOriginName FROM RESERVAS1 LEFT OUTER JOIN GRUPOS G ON RESERVAS1.GRUPO_RES1=G.CODIGO LEFT OUTER JOIN OFICINAS AS OFFICE ON RESERVAS1.OFISALIDA_RES1 = OFFICE.CODIGO LEFT OUTER JOIN CLIENTES1 AS CLIENT1 ON RESERVAS1.CLIENTE_RES1 = CLIENT1.NUMERO_CLI LEFT OUTER JOIN CLIENTES1 AS DRIVER ON RESERVAS1.CONDUCTOR_RES1 = DRIVER.NUMERO_CLI LEFT OUTER JOIN SUBLICEN AS COMPANY ON RESERVAS1.SUBLICEN_RES1 = COMPANY.CODIGO LEFT OUTER JOIN VEHICULO1 V1 ON RESERVAS1.VCACT_RES1=V1.CODIINT LEFT OUTER JOIN USURE US1 ON US1.CODIGO=RESERVAS1.RENTAL1_RES1 LEFT OUTER JOIN VEHICULO2 V2 ON V2.CODIINT=V1.CODIINT INNER JOIN RESERVAS2 ON RESERVAS1.NUMERO_RES = RESERVAS2.NUMERO_RES ORDER BY BookingNumber, BookingDate;"},

            { QueryType.QueryBookingPaged,"SELECT TOP {0} START AT {1} RESERVAS1.NUMERO_RES as BookingNumber, RESERVAS1.NOMBRE_RES1 as BookingName, RESERVAS1.FECHA_RES1 as BookingDate, RESERVAS1.LOCALIZA_RES1 as Locator, OFFICE.CODIGO AS OfficeCode, OFFICE.ZONAOFI AS OfficeZone, OFFICE.NOMBRE as OfficeName, RESERVAS1.GRUPO_RES1 as BookingGroup, RESERVAS1.RENTAL1_RES1 AS BookerUserCode, RESERVAS1.FSALIDA_RES1 as DepartureDate, RESERVAS1.HSALIDA_RES1 as DepartureHour, US1.NOMBRE as BookerUserName, DRIVER.NOMBRE as DriverName, DRIVER.NUMERO_CLI as DriverCode, RESERVAS1.USUARIO_RES1 AS CurrentUser, RESERVAS2.OBS1_RES2 as Notes, RESERVAS2.ORIGEN_RES2 as BookingOrigin, RESERVAS2.MULDIR_RES2 as MultipleDirection, RESERVAS1.ULTMODI_RES1 as LastModification, RESERVAS2.COMISIO_RES2 as BookingBroker, RESERVAS2.TOLON_RES2 as DepositTotal, RESERVAS1.contrato_res1 as Contract, RESERVAS1.FIANZA_DEPOSITO_RES1 as Deposit, RESERVAS1.TARIFA_RES1 as Fare, RESERVAS1.LUENTRE_RES1 as DeliveryPlace, RESERVAS1.LUDEVO_RES1 as ReturnPlace, RESERVAS1.RECHAZAFECHA as RejectionDate, RESERVAS1.FPREV_RES1 as ReturnDate, RESERVAS1.HPREV_RES1 as ReturnTime, V1.MATRICULA as RegistrationNumber, V1.MODELO as VehicleModel, V1.SITUACION as VehicleSituation, RESERVAS2.BONONUM_RES2 as Bonus, CLIENT1.NUMERO_CLI as ClientCode,CLIENT1.NOMBRE as ClientName, RESERVAS2.CONFIRMADA_RES2 as Confirmed, RESERVAS2.OTROCOND_RES2 as OtherDriver, RESERVAS2.OTRO2COND_RES2 as OtherDriver2, RESERVAS2.OTRO3COND_RES2 as OtherDriver3, (select sum(importe) from cobros where reserva = RESERVAS1.NUMERO_RES) as BookingBill, (select NOMBRE from ORIGEN where NUM_ORIGEN=BookingOrigin) as BookingOriginName FROM RESERVAS1 LEFT OUTER JOIN GRUPOS G ON RESERVAS1.GRUPO_RES1=G.CODIGO LEFT OUTER JOIN OFICINAS AS OFFICE ON RESERVAS1.OFISALIDA_RES1 = OFFICE.CODIGO LEFT OUTER JOIN CLIENTES1 AS CLIENT1 ON RESERVAS1.CLIENTE_RES1 = CLIENT1.NUMERO_CLI LEFT OUTER JOIN CLIENTES1 AS DRIVER ON RESERVAS1.CONDUCTOR_RES1 = DRIVER.NUMERO_CLI LEFT OUTER JOIN SUBLICEN AS COMPANY ON RESERVAS1.SUBLICEN_RES1 = COMPANY.CODIGO LEFT OUTER JOIN VEHICULO1 V1 ON RESERVAS1.VCACT_RES1=V1.CODIINT LEFT OUTER JOIN USURE US1 ON US1.CODIGO=RESERVAS1.RENTAL1_RES1 LEFT OUTER JOIN VEHICULO2 V2 ON V2.CODIINT=V1.CODIINT INNER JOIN RESERVAS2 ON RESERVAS1.NUMERO_RES = RESERVAS2.NUMERO_RES ORDER BY BookingNumber, BookingDate;"},
            { QueryType.QueryBusiness,@"SELECT * FROM NEGOCIO WHERE CODIGO='{0}';"},
            { QueryType.QueryBudget,@"SELECT * FROM PRESUP1 INNER JOIN PRESUP2 ON PRESUP1.NUMERO_PRE = PRESUP2.NUMERO_PRE WHERE NUMERO_PRE='{0}'" },
             {QueryType.QueryBudgetSummaryPaged, @"SELECT TOP {0} START AT {1} PRESUP1.NUMERO_PRE as BudgetNumber,
                                                   OFICINA_PRE1 as BudgetOffice,
                                                   CLIENTES1.NOMBRE as ClientName,
                                                   FECHA_PRE1 as BudgetCreationDate,
                                                   FSALIDA_PRE1 as DepartureDate,
                                                   GRUPO_PRE1 as GroupCode,
                                                   RESERVA_PRE1 as BookingNumber,
                                                   COMISIO.NOMBRE as BrokerName,
                                                   PRESUP2.BONONUM_PRE2 as BonusNumber,
                                                   ORIGEN.NOMBRE as Origin,
                                                   NOTAS_PRE1 as Notes
                                                   FROM PRESUP1
                                                   INNER JOIN PRESUP2 ON PRESUP1.NUMERO_PRE =       PRESUP2.NUMERO_PRE
                                                   LEFT OUTER JOIN CLIENTES1 ON NUMERO_CLI = CLIENTE_PRE1
                                                   LEFT OUTER JOIN ORIGEN ON NUM_ORIGEN = PRESUP2.ORIGEN_PRE2
                                                   LEFT OUTER JOIN COMISIO ON NUM_COMI = PRESUP2.COMISIO_PRE2;"},
                          {QueryType.QueryBudgetSummary, @"SELECT PRESUP1.NUMERO_PRE as BudgetNumber,
                                                   OFICINA_PRE1 as BudgetOffice,
                                                   CLIENTES1.NOMBRE as ClientName,
                                                   FECHA_PRE1 as BudgetCreationDate,
                                                   FSALIDA_PRE1 as DepartureDate,
                                                   GRUPO_PRE1 as GroupCode,
                                                   RESERVA_PRE1 as BookingNumber,
                                                   COMISIO.NOMBRE as BrokerName,
                                                   PRESUP2.BONONUM_PRE2 as BonusNumber,
                                                   ORIGEN.NOMBRE as Origin,
                                                   NOTAS_PRE1 as Notes
                                                   FROM PRESUP1
                                                   INNER JOIN PRESUP2 ON PRESUP1.NUMERO_PRE = PRESUP2.NUMERO_PRE
                                                   LEFT OUTER JOIN CLIENTES1 ON NUMERO_CLI = CLIENTE_PRE1
                                                   LEFT OUTER JOIN ORIGEN ON NUM_ORIGEN = PRESUP2.ORIGEN_PRE2
                                                   LEFT OUTER JOIN COMISIO ON NUM_COMI = PRESUP2.COMISIO_PRE2;"},
                            {QueryType.QueryBudgetSummaryById, @"SELECT PRESUP1.NUMERO_PRE as BudgetNumber,
                                                   OFICINA_PRE1 as BudgetOffice,
                                                   CLIENTES1.NOMBRE as ClientName,
                                                   FECHA_PRE1 as BudgetCreationDate,
                                                   FSALIDA_PRE1 as DepartureDate,
                                                   GRUPO_PRE1 as GroupCode,
                                                   RESERVA_PRE1 as BookingNumber,
                                                   COMISIO.NOMBRE as BrokerName,
                                                   PRESUP2.BONONUM_PRE2 as BonusNumber,
                                                   ORIGEN.NOMBRE as Origin,
                                                   NOTAS_PRE1 as Notes
                                                   FROM PRESUP1
                                                   INNER JOIN PRESUP2 ON PRESUP1.NUMERO_PRE = PRESUP2.NUMERO_PRE
                                                   LEFT OUTER JOIN CLIENTES1 ON NUMERO_CLI = CLIENTE_PRE1
                                                   LEFT OUTER JOIN ORIGEN ON NUM_ORIGEN = PRESUP2.ORIGEN_PRE2
                                                   LEFT OUTER JOIN COMISIO ON NUM_COMI = PRESUP2.COMISIO_PRE2 
                                                   WHERE PRESUP1.NUMERO_PRE='{0}';"},

            { QueryType.QueryPagedClient, @"SELECT TOP {0} START AT {1} CLIENTES1.NUMERO_CLI, * FROM CLIENTES1 INNER JOIN CLIENTES2 ON CLIENTES1.NUMERO_CLI = CLIENTES2.NUMERO_CLI ORDER BY CLIENTES1.NUMERO_CLI" },
            {QueryType.QueryClient1, @"SELECT * FROM CLIENTES1 WHERE NUMERO_CLI='{0}'"},
            {QueryType.QueryClient2, @"SELECT * FROM CLIENTES2 WHERE NUMERO_CLI='{0}'"},
            {QueryType.QueryCity, @"SELECT * FROM POBLACIONES WHERE CP = '{0}'" },
            {QueryType.QueryCityByName, @"SELECT * FROM POBLACIONES WHERE POBLA = '{0}'" },
            {QueryType.QueryClientType, @"SELECT * FROM TIPOCLI WHERE NUM_TICLI = '{0}'" },
            {QueryType.QueryCompany, @"SELECT * FROM SUBLICEN WHERE CODIGO='{0}'"},
            {QueryType.QueryCreditCard, @"SELECT * FROM TARCREDI WHERE CODIGO='{0}'"},

            { QueryType.QueryMarket, @"SELECT * FROM MERCADO WHERE CODIGO = '{0}'"},
            {QueryType.QueryLanguage, @"SELECT * FROM IDIOMAS WHERE CODIGO='{0}'"},
            {QueryType.QueryOrigin, @"SELECT * FROM ORIGEN WHERE NUM_ORIGEN='{0}'"},

            {QueryType.QueryZone, @"SELECT * FROM ZONAS WHERE  NUM_ZONA='{0}'"},
            {QueryType.QuerySeller, @"SELECT * FROM VENDEDOR WHERE NUM_VENDE='{0}'"},
            {QueryType.QueryInvoiceBlocks, @"SELECT * FROM BLOQUEFAC WHERE CODIGO='{0}'"},
            {QueryType.QueryOffice, @"SELECT * FROM OFICINAS WHERE CODIGO='{0}'" },
             {QueryType.QueryOfficePaged, @"SELECT TOP {0} START AT {1} * FROM OFICINAS" },
            {QueryType.QueryCompanyOffices, @"SELECT * FROM OFICINAS WHERE SUBLICEN='{0}'" },
            {QueryType.QueryOfficeZone, @"SELECT * FROM ZONAOFI WHERE COD_ZONAOFI='{0}'" },
            {QueryType.QueryActivity, @"SELECT * FROM ACTIVI WHERE NUM_ACTIVI='{0}'" },
            {QueryType.QueryProvince, @"SELECT * FROM PROVINCIA WHERE SIGLAS='{0}'" },
            {QueryType.QueryCountry, @"SELECT * FROM PAIS WHERE SIGLAS='{0}'" },
            {QueryType.QueryPaymentForm, @"SELECT * FROM FORMAS WHERE CODIGO='{0}'" },
            {QueryType.QueryRefusedBooking,  @"SELECT * FROM MOTANU WHERE CODIGO='{0}'"},
            {QueryType.QueryVehicle,@"SELECT VEHICULO1.CODIINT,MARCA,MATRICULA,MODELO,MO1,MO2,GRUPO,MAR,COLOR,PROVEEDOR,TIPOSEGU,BASTIDOR,DANOS,LEXTRAS,ACCESORIOS_VH,AVISO,REF,ACTIVIDAD,PROPIE,KMRESTA,
                                FCAMBIO_KM,VEHICULO2.GASTOS,VEHICULO2.KM,VEHICULO2.SALDO,VEHICULO2.PROXIMANTE
                                      FROM VEHICULO1 INNER JOIN VEHICULO2 ON VEHICULO2.CODIINT=VEHICULO1.CODIINT WHERE VEHICULO1.CODIINT='{0}'"},
            {QueryType.QueryOffices, @"SELECT * FROM OFICINAS WHERE CODIGO = '{0}'"},
            {QueryType.HolidaysByOffice, @"SELECT * FROM FESTIVOS_OFICINA WHERE OFICINA = '{0}'"},
            {QueryType.HolidaysOfficeDelete, @"DELETE FROM FESTIVOS_OFICINA WHERE OFICINA = '{0}'"},
            {QueryType.HolidaysDate, @"SELECT * FROM FESTIVOS_OFICINA WHERE FESTIVO = CONVERT(DATETIME,'{0}',101) AND OFICINA='{1}' AND  PARTE_DIA='{2}' AND HORA_DESDE='{3}' AND HORA_HASTA='{4}'"},
            {QueryType.QueryChannel, @"SELECT * FROM CANAL WHERE CODIGO='{0}'" },
            {QueryType.QueryCompanySummary, @"select CODIGO as Code, NOMBRE as Name, NIF as Nif, TELEFONO as Phone, Direccion as Direction, SUBLICEN.CP as Zip, Poblacion as City, PROVINCIA.PROV as Province, PAIS.PAIS as Country from SUBLICEN LEFT OUTER JOIN PAIS ON SUBLICEN.NACIO = PAIS.PAIS LEFT OUTER JOIN PROVINCIA ON SUBLICEN.PROVINCIA = PROVINCIA.PROV" },
            {
                QueryType.QueryCompanyPaged,  @"select TOP {0} START AT {1} CODIGO as Code, NOMBRE as Name, NIF as Nif, TELEFONO as Phone, Direccion as Direction, SUBLICEN.CP as Zip, Poblacion as City, PROVINCIA.PROV as Province, PAIS.PAIS as Country from SUBLICEN LEFT OUTER JOIN PAIS ON SUBLICEN.NACIO = PAIS.PAIS LEFT OUTER JOIN PROVINCIA ON SUBLICEN.PROVINCIA = PROVINCIA.PROV"
            },
           {QueryType.QueryDivisa, @"select * from divisas;" },
            {QueryType.QueryDeliveringFrom, @"select * from forma_pedent;" },

            {QueryType.QueryCurrency, @"select * from currencies;" },

           {QueryType.QueryCurrencyValue, @"select * from currencies where codigo_cur='{0}'" },

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
            { QueryType.QueryOfficeSummaryPaged, "select TOP {0} START AT {1} OFICINAS.CODIGO as Code, OFICINAS.NOMBRE AS Name, OFICINAS.DIRECCION as Direction,  OFICINAS.TELEFONO as Phone,OFICINAS.POBLACION as City, OFICINAS.CP as Zip, PROVINCIA.PROV as Province,  SUBLICEN.NOMBRE as CompanyName, ZONAOFI.NOM_ZONA as OfficeZone FROM OFICINAS LEFT OUTER JOIN PROVINCIA   ON OFICINAS.PROVINCIA=PROVINCIA.SIGLAS LEFT OUTER JOIN ZONAOFI ON OFICINAS.ZONAOFI=ZONAOFI.COD_ZONAOFI   LEFT OUTER JOIN SUBLICEN ON OFICINAS.SUBLICEN=SUBLICEN.CODIGO LEFT OUTER JOIN POBLACIONES ON OFICINAS.POBLACION=POBLACIONES.CP;" },
            { QueryType.QueryOfficeSummary,
                "select OFICINAS.CODIGO as Code, OFICINAS.NOMBRE AS Name, OFICINAS.DIRECCION as Direction,  OFICINAS.TELEFONO as Phone,POBLACIONES.POBLA as City, OFICINAS.CP as Zip, PROVINCIA.PROV as Province,  SUBLICEN.NOMBRE as CompanyName, ZONAOFI.NOM_ZONA as OfficeZone FROM OFICINAS LEFT OUTER JOIN PROVINCIA   ON OFICINAS.PROVINCIA=PROVINCIA.SIGLAS LEFT OUTER JOIN ZONAOFI ON OFICINAS.ZONAOFI=ZONAOFI.COD_ZONAOFI   LEFT OUTER JOIN SUBLICEN ON OFICINAS.SUBLICEN=SUBLICEN.CODIGO LEFT OUTER JOIN POBLACIONES ON OFICINAS.POBLACION=POBLACIONES.CP;"},
              {QueryType.QueryOfficeSummaryByCompany, "select OFICINAS.CODIGO as Code, OFICINAS.NOMBRE AS Name, OFICINAS.DIRECCION as Direction, OFICINAS.POBLACION as City, PROVINCIA.PROV as Province, SUBLICEN.NOMBRE as CompanyName, ZONAOFI.NOM_ZONA as OfficeZone FROM OFICINAS LEFT OUTER JOIN PROVINCIA " +
                "ON OFICINAS.PROVINCIA=PROVINCIA.SIGLAS LEFT OUTER JOIN ZONAOFI ON OFICINAS.ZONAOFI=ZONAOFI.COD_ZONAOFI " +
                "LEFT OUTER JOIN SUBLICEN ON OFICINAS.SUBLICEN=SUBLICEN.CODIGO WHERE SUBLICEN='{0}';" },
            {QueryType.QueryClientSummaryExt, "SELECT CLIENTES1.NUMERO_CLI as Code, NOMBRE as Name,NIF as Nif,TELEFONO as Phone,MOVIL as Movil,EMAIL as Email, DIRECCION as Direction,CLIENTES1.CP as Zip,POBLACION as City,PROVINCIA.PROV as Province,PAIS.PAIS as Country,TARTI as CreditCardType, TARNUM as NumberCreditCard,FPAGO as PaymentForm,CONTABLE as AccountableAccount,CLIENTES2.SECTOR as Sector,ZONA as Zone,ORIGEN as Origin, CLIENTES2.VENDEDOR as Reseller,OFICINA as Office,COMERCIAL as Commercial,ALTA as Falta,FENAC as BirthDate from CLIENTES1 INNER JOIN CLIENTES2 ON CLIENTES2.NUMERO_CLI = CLIENTES1.NUMERO_CLI LEFT OUTER JOIN PROVINCIA ON PROVINCIA.SIGLAS = CLIENTES1.PROVINCIA LEFT OUTER JOIN PAIS ON PAIS.SIGLAS = CLIENTES1.NACIOPER"},
            {QueryType.QueryClientSummaryExtById, "SELECT CLIENTES1.NUMERO_CLI as Code, NOMBRE as Name FROM CLIENTES1 WHERE CLIENTES1.NUMERO_CLI='{0}'"},
            {
                QueryType.QueryContractSummaryBasic, @"SELECT NUMERO as Code, NOMBRE_CON1 as Name, FSALIDA_CON1 as ReleaseDate,  FECHA_CON1 as StartingFrom, FRETOR_CON1 as ReturnDate, LUENTRE_CON1 as DeliveringPlace, DIAS_CON1 as Days, CLIENTE_CON1 as ClientCode, CONDUCTOR_CON1 as DriverCode, VCACT_CON1 as VehicleCode, CLIENTES1.NOMBRE as ClientName, Conductor.NOMBRE as DriverName, VEHICULO1.MATRICULA as RegistrationNumber, VEHICULO1.MARCA as VehicleBrand, VEHICULO1.MODELO as VehicleModel FROM CONTRATOS1 
                  LEFT OUTER JOIN CLIENTES1 ON CONTRATOS1.CLIENTE_CON1=CLIENTES1.NUMERO_CLI 
                  LEFT OUTER JOIN CLIENTES1 as Conductor ON  CONTRATOS1.CONDUCTOR_CON1=Conductor.NUMERO_CLI 
                  LEFT OUTER JOIN VEHICULO1 ON VEHICULO1.CODIINT=CONTRATOS1.VCACT_CON1;"
            },
             {
                QueryType.QueryClientSummaryById, @"SELECT NUMERO as Code, NOMBRE_CON1 as Name, FSALIDA_CON1 as ReleaseDate,  FECHA_CON1 as StartingFrom, FRETOR_CON1 as ReturnDate, LUENTRE_CON1 as DeliveringPlace, DIAS_CON1 as Days, CLIENTE_CON1 as ClientCode, CONDUCTOR_CON1 as DriverCode, VCACT_CON1 as VehicleCode, CLIENTES1.NOMBRE as ClientName, Conductor.NOMBRE as DriverName, VEHICULO1.MATRICULA as RegistrationNumber, VEHICULO1.MARCA as VehicleBrand, VEHICULO1.MODELO as VehicleModel FROM CONTRATOS1 
                  LEFT OUTER JOIN CLIENTES1 ON CONTRATOS1.CLIENTE_CON1=CLIENTES1.NUMERO_CLI 
                  LEFT OUTER JOIN CLIENTES1 as Conductor ON  CONTRATOS1.CONDUCTOR_CON1=Conductor.NUMERO_CLI 
                  LEFT OUTER JOIN VEHICULO1 ON VEHICULO1.CODIINT=CONTRATOS1.VCACT_CON1 WHERE CLIENTES1.NUMERO_CLI='{0}';"
            },
             {
                QueryType.QueryContractSummaryPaged, @"SELECT TOP {0} START AT {1} NUMERO as Code, NOMBRE_CON1 as Name, FSALIDA_CON1 as ReleaseDate,  FECHA_CON1 as StartingFrom, FRETOR_CON1 as ReturnDate, LUENTRE_CON1 as DeliveringPlace, DIAS_CON1 as Days, CLIENTE_CON1 as ClientCode, CONDUCTOR_CON1 as DriverCode, VCACT_CON1 as VehicleCode, CLIENTES1.NOMBRE as ClientName, Conductor.NOMBRE as DriverName, VEHICULO1.MATRICULA as RegistrationNumber, VEHICULO1.MARCA as VehicleBrand, VEHICULO1.MODELO as VehicleModel FROM CONTRATOS1 
                  LEFT OUTER JOIN CLIENTES1 ON CONTRATOS1.CLIENTE_CON1=CLIENTES1.NUMERO_CLI 
                  LEFT OUTER JOIN CLIENTES1 as Conductor ON  CONTRATOS1.CONDUCTOR_CON1=Conductor.NUMERO_CLI 
                  LEFT OUTER JOIN VEHICULO1 ON VEHICULO1.CODIINT=CONTRATOS1.VCACT_CON1;"
            },
            { QueryType.QueryDeliveringBy, "SELECT * FROM ENTREGAS WHERE CODIGO='{0}';" },
            { QueryType.QueryClientPagedSummary, @"SELECT TOP {0} START AT {1} CLIENTES1.NUMERO_CLI as Code,NOMBRE as Name, NIF as Nif,TELEFONO as Phone,MOVIL as Movil,EMAIL as Email,DIRECCION as Direction,CLIENTES1.CP as Zip,POBLACION as City,PROVINCIA.PROV as Province, 
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
                                                    COMERCIAL as Commercial,
                                                    ALTA as Falta, 
                                                    FENAC as BirthDate
                                                    from CLIENTES1 
                                                    INNER JOIN CLIENTES2 
                                                    ON CLIENTES2.NUMERO_CLI = CLIENTES1.NUMERO_CLI 
                                                    LEFT OUTER JOIN PROVINCIA 
                                                    ON PROVINCIA.SIGLAS = CLIENTES1.PROVINCIA 
                                                    LEFT OUTER JOIN PAIS 
                                                    ON PAIS.SIGLAS = CLIENTES1.NACIOPER "
                                                    },
            {QueryType.QueryClientContacts, @"SELECT ccoIdContacto, ccoContacto,DL.cldIdDelega as idDelegacion, DL.cldDelegacion as nombreDelegacion,NIF, ccoCargo,ccoTelefono, ccoMovil, ccoFax, ccoMail,CC.ULTMODI as ULTMODI,CC.USUARIO as USUARIO FROM CliContactos AS CC LEFT OUTER JOIN PERCARGOS AS PG ON CC.ccoCargo = PG.CODIGO LEFT OUTER JOIN CliDelega AS DL ON CC.ccoIdDelega = DL.CLDIDDELEGA AND CC.ccoIdCliente = DL.cldIdCliente  WHERE cldIdCliente='{0}' ORDER BY CC.ccoContacto"},
            { QueryType.QueryClientDelegations, "SELECT cldIdDelega,cldIdCliente, cldDelegacion, cldDireccion1, cldDireccion2, cldCP, cldPoblacion, cldIdProvincia,cldTelefono1, cldTelefono2, cldFax, cldEMail, cldMovil,PV.PROV AS NOM_PROV, PV.SIGLAS FROM cliDelega CC LEFT OUTER JOIN PROVINCIA PV ON PV.SIGLAS = CC.cldIdProvincia WHERE cldIdCliente='{0}' ORDER BY CC.cldIdDelega;"},
            { QueryType.QuerySupplierSummary, @"SELECT PROVEE1.NUM_PROVEE AS Codigo, PROVEE1.NOMBRE AS Nombre, NIF as Nif, TIPOPROVE.NOMBRE as Proveedor, COMERCIAL as Comercial,TELEFONO as Telefono, DIRECCION as Direccion, PROVEE1.CP as CP, POBLACION as Poblacion,PROVINCIA.PROV as Provincia, F_AEAT as AEAT, PROVEE2.CONTABLE as Contable,  CUGASTO as CuentaGasto, PROVEE1.ULTMODI as LastModification, PROVEE1.USUARIO as CurrentUser FROM PROVEE1 LEFT OUTER JOIN TIPOPROVE ON TIPOPROVE.NUM_TIPROVE=PROVEE1.TIPO LEFT OUTER JOIN PROVINCIA ON PROVINCIA.SIGLAS = PROVEE1.PROV INNER JOIN PROVEE2 ON PROVEE2.NUM_PROVEE = PROVEE1.NUM_PROVEE" },
             { QueryType.QuerySupplierSummaryById, @"SELECT PROVEE1.NUM_PROVEE AS Codigo, PROVEE1.NOMBRE AS Nombre, NIF as Nif, TIPOPROVE.NOMBRE as Proveedor, COMERCIAL as Comercial,TELEFONO as Telefono, DIRECCION as Direccion, PROVEE1.CP as CP, POBLACION as Poblacion,PROVINCIA.PROV as Provincia, F_AEAT as AEAT, PROVEE2.CONTABLE as Contable,  CUGASTO as CuentaGasto, PROVEE1.ULTMODI as LastModification, PROVEE1.USUARIO as CurrentUser FROM PROVEE1 LEFT OUTER JOIN TIPOPROVE ON TIPOPROVE.NUM_TIPROVE=PROVEE1.TIPO LEFT OUTER JOIN PROVINCIA ON PROVINCIA.SIGLAS = PROVEE1.PROV INNER JOIN PROVEE2 ON PROVEE2.NUM_PROVEE = PROVEE1.NUM_PROVEE WHERE PROVEE2.NUM_PROVEE='{0}'" },
            { QueryType.QuerySupplierSummaryPaged, "SELECT TOP {0} START AT {1} PROVEE1.NUM_PROVEE AS Codigo, PROVEE1.NOMBRE AS Nombre, NIF as Nif, TIPOPROVE.NOMBRE as Proveedor, COMERCIAL as Comercial,TELEFONO as Telefono, DIRECCION as Direccion, PROVEE1.CP as CP, POBLACION as Poblacion,PROVINCIA.PROV as Provincia, F_AEAT as AEAT, PROVEE2.CONTABLE as Contable,  CUGASTO as CuentaGasto, PROVEE1.ULTMODI as LastModification, PROVEE1.USUARIO as CurrentUser FROM PROVEE1 LEFT OUTER JOIN TIPOPROVE ON TIPOPROVE.NUM_TIPROVE=PROVEE1.TIPO LEFT OUTER JOIN PROVINCIA ON PROVINCIA.SIGLAS = PROVEE1.PROV INNER JOIN PROVEE2 ON PROVEE2.NUM_PROVEE = PROVEE1.NUM_PROVEE" },
            { QueryType.QueryFareConcept,"SELECT * FROM CONCEP_FACTUR WHERE CODIGO='{0}'"},
            { QueryType.QueryOfficeByCompany, @"SELECT * FROM OFICINAS WHERE CODIGO='{0}' AND SUBLICEN='{1}'"},
            { QueryType.QueryVehicleSummary, @"SELECT vehiculo1.codiint As Code, matricula as Matricula, 
                MARCAS.NOMBRE as Marca, modelo as Model, grupo as Group, oficina as Office, NUMPLAZAS as Places, ACTIVIDAD as Activity, Color as Color, METROS_CUB as CubeMeters, PROPIE as Owner, CIASEGU as AssuranceCompany, CIALES as LeasingCompany, FSEGB as LeavingDate, FSEGA as StartingDate, CLIENTE1.NUMERO_CLI as ClientNumber, CLIENTE1.NOMBRE as Client, TIPOREV as Policy, VEHICULO2.KM as Kilometers, COMPRAFRA as PurchaseInvoice, BASTIDOR as Frame,  NUM_MOTOR as MotorNumber, ANOMODELO as ModelYear, REF as Referencia, KeyCode as LLAVE, LLAVE2 as StorageKey  FROM VEHICULO1 LEFT OUTER JOIN CLIENTES1 ON VEHICULO1.CLIENTE = CLIENTES1.NUMERO_CLI LEFT OUTER JOIN MARCAS ON VEHICULO1.MARCA = MARCA.NOMBRE INNER JOIN VEHICULO2 ON VEHICULO1.CODIINT = VEHICULO2.CODIINT"},
                 { QueryType.QueryVehicleSummaryById, @"SELECT vehiculo1.codiint As Code, matricula as Matricula, MARCAS.NOMBRE as Brand, modelo as Model, grupo as VehicleGroup, oficina as Office, NUMPLAZAS as Places, ACTIVIDAD as Activity, Color as Color, METROS_CUB as CubeMeters, PROPIE as Owner, CIASEGU as AssuranceCompany, CIALEAS as LeasingCompany, FSEGUB as LeavingDate, FSEGUBA as StartingDate, CLIENTES1.NUMERO_CLI as ClientNumber, CLIENTES1.NOMBRE as Client, TIPOREV as Policy,SITUACION as Situation,VEHICULO2.KM as Kilometers, COMPRAFRA as PurchaseInvoice, BASTIDOR as Frame,  NUM_MOTOR as MotorNumber, ANOMODELO as ModelYear, REF as Referencia, PROPIE.NOMBRE as OwnerName ,LLAVE as KeyCode, LLAVE2 as StorageKey FROM VEHICULO1 LEFT OUTER JOIN CLIENTES1 ON VEHICULO1.CLIENTE = CLIENTES1.NUMERO_CLI LEFT OUTER JOIN PROPIE ON PROPIE.NUM_PROPIE = VEHICULO1.PROPIE LEFT OUTER JOIN MARCAS ON VEHICULO1.MARCA = MARCAS.NOMBRE INNER JOIN VEHICULO2 ON VEHICULO1.CODIINT = VEHICULO2.CODIINT where vehiculo1.codiint='{0}'"},
             { QueryType.QueryVehicleSummaryPaged, @"SELECT TOP {0} START AT {1} vehiculo1.codiint As Code, matricula as Matricula, MARCAS.NOMBRE as Brand, modelo as Model, grupo as VehicleGroup, oficina as Office, NUMPLAZAS as Places, ACTIVIDAD as Activity, Color as Color, METROS_CUB as CubeMeters, PROPIE as Owner, CIASEGU as AssuranceCompany, CIALEAS as LeasingCompany, FSEGUB as LeavingDate, FSEGUBA as StartingDate, CLIENTES1.NUMERO_CLI as ClientNumber, CLIENTES1.NOMBRE as Client, TIPOREV as Policy,SITUACION as Situation,VEHICULO2.KM as Kilometers, COMPRAFRA as PurchaseInvoice, BASTIDOR as Frame,  NUM_MOTOR as MotorNumber, ANOMODELO as ModelYear, REF as Referencia, PROPIE.NOMBRE as OwnerName ,LLAVE as KeyCode, LLAVE2 as StorageKey FROM VEHICULO1 LEFT OUTER JOIN CLIENTES1 ON VEHICULO1.CLIENTE = CLIENTES1.NUMERO_CLI LEFT OUTER JOIN PROPIE ON PROPIE.NUM_PROPIE = VEHICULO1.PROPIE LEFT OUTER JOIN MARCAS ON VEHICULO1.MARCA = MARCAS.NOMBRE INNER JOIN VEHICULO2 ON VEHICULO1.CODIINT = VEHICULO2.CODIINT;"},

            {QueryType.QueryInvoiceSummaryExtended, "select distinct numero_fac as InvoiceName, serie_fac as InvoiceSerie, referen_fac as InvoiceRef, cliente_fac as InvoiceCode, CONTRATO_FAC as InvoiceContract,c.nombre as ClientName, fecha_fac as InvoiceDate, cuota_fac as InvoiceFee, base_fac as InvoiceBase, todo_fac as TotalInvoice, f.FRATIPIMPR as InvoiceType, c2.contable as Account, sublicen_fac as CompanyCode, s.NOMBRE as CompanyName, oficina_fac as OfficeCode, asiento_fac as Seat, fserv_a as InvoiceTo, fserv_de as InvoiceFrom, observaciones_fac as Notes, usuario_fac as InvoiceUser, ultmodi_fac as LastModification, vienede_fac as ComeFrom from facturas as f " +
                "left outer join sublicen as s on f.sublicen_fac = s.CODIGO " +
                "inner join clientes1 as c on f.cliente_fac = c.numero_cli " +
                "inner join clientes2 as c2 on c.numero_cli = c2.numero_cli;" },
            {QueryType.QueryInvoiceSummaryPaged, "select distinct TOP {0} START AT {1} numero_fac as InvoiceName, serie_fac as InvoiceSerie, referen_fac as InvoiceRef, cliente_fac as InvoiceCode, CONTRATO_FAC as InvoiceContract,c.nombre as ClientName, fecha_fac as InvoiceDate, cuota_fac as InvoiceFee, base_fac as InvoiceBase, todo_fac as TotalInvoice, f.FRATIPIMPR as InvoiceType, c2.contable as Account, sublicen_fac as CompanyCode, s.NOMBRE as CompanyName, oficina_fac as OfficeCode, asiento_fac as Seat, fserv_a as InvoiceTo, fserv_de as InvoiceFrom, observaciones_fac as Notes, usuario_fac as InvoiceUser, ultmodi_fac as LastModification, vienede_fac as ComeFrom from facturas as f " +
                                                    "left outer join sublicen as s on f.sublicen_fac = s.CODIGO " +
                                                    "inner join clientes1 as c on f.cliente_fac = c.numero_cli " +
                                                    "inner join clientes2 as c2 on c.numero_cli = c2.numero_cli;" },

            {QueryType.QueryInvoiceSingle, "SELECT * from FACTURAS where NUMERO_FAC='{0}'"},
            {QueryType.QueryInvoiceItem,"SELECT * FROM LIFAC WHERE NUMERO_LIF='{0}';"},
            {QueryType.QueryInvoiceSingleByDate,"select * from FACTURAS where NUMERO_FAC='{0}' and fecha_fac='{1}'"},
            {QueryType.QuerySellerSummary, "select NUM_VENDE, NOMBRE, DIRECCION, POBLACION, VENDEDOR.CP, PR.PROV as PROVINCIA, TELEFONO,MOVIL FROM VENDEDOR left outer join provincia as pr on pr.SIGLAS = VENDEDOR.PROVINCIA" },
            {QueryType.QueryCommissionAgentSummary, "SELECT NUM_COMI as Code, NOMBRE as Name, PERSONA as Person, NIF as Nif, DIRECCION as Direction, POBLACIONES.CP as Zip, POBLACIONES.POBLA as City, PROVINCIA.PROV as Province, PAIS.PAIS as Country,IATA, SUBLICEN as Company,  ZONAOFI as OfficeZone, COMISIO.ULTMODI as LastModification, COMISIO.USUARIO as CurrentUser  FROM COMISIO LEFT OUTER JOIN PROVINCIA ON COMISIO.PROVINCIA = PROVINCIA.SIGLAS LEFT OUTER JOIN PAIS on COMISIO.NACIOPER = PAIS.SIGLAS LEFT OUTER JOIN POBLACIONES on COMISIO.CP = POBLACIONES.CP;"},
                        {QueryType.QueryCommissionAgentSummaryById, "SELECT NUM_COMI as Code, NOMBRE as Name, PERSONA as Person, NIF as Nif, DIRECCION as Direction, POBLACIONES.CP as Zip, POBLACIONES.POBLA as City, PROVINCIA.PROV as Province, PAIS.PAIS as Country,IATA, SUBLICEN as Company,  ZONAOFI as OfficeZone, COMISIO.ULTMODI as LastModification, COMISIO.USUARIO as CurrentUser  FROM COMISIO LEFT OUTER JOIN PROVINCIA ON COMISIO.PROVINCIA = PROVINCIA.SIGLAS LEFT OUTER JOIN PAIS on COMISIO.NACIOPER = PAIS.SIGLAS LEFT OUTER JOIN POBLACIONES on COMISIO.CP = POBLACIONES.CP WHERE NUM_COMI='{0}';"},

            { QueryType.QueryCommissionAgentPaged, "SELECT TOP {0} START AT {1} NUM_COMI as Code, NOMBRE as Name, PERSONA as Person, NIF as Nif, DIRECCION as Direction, POBLACIONES.CP as Zip, POBLACIONES.POBLA as City, PROVINCIA.PROV as Province, PAIS.PAIS as Country,IATA, SUBLICEN as Company,  ZONAOFI as OfficeZone, COMISIO.ULTMODI as LastModification, COMISIO.USUARIO as CurrentUser  FROM COMISIO LEFT OUTER JOIN PROVINCIA ON COMISIO.PROVINCIA = PROVINCIA.SIGLAS LEFT OUTER JOIN PAIS on COMISIO.NACIOPER = PAIS.SIGLAS LEFT OUTER JOIN POBLACIONES on COMISIO.CP = POBLACIONES.CP;" },
            { QueryType.QueryBrokerContacts, "SELECT CONTACTO,COMISIO,NOM_CONTACTO, NIF, PG.CODIGO as CARGO, PG.NOMBRE AS NOM_CARGO, TELEFONO, MOVIL, FAX, EMAIL, CC.USUARIO, CC.ULTMODI, DL.CLDIDDELEGA as DelegaId, cldDelegacion DELEGACC_NOM FROM CONTACTOS_COMI AS CC LEFT OUTER JOIN PERCARGOS AS PG ON CC.CARGO = PG.CODIGO LEFT OUTER JOIN COMI_DELEGA AS DL ON CC.DELEGA_CC = DL.CLDIDDELEGA AND CC.COMISIO = DL.CLDIDCOMI WHERE COMISIO = '{0}' ORDER BY CC.CONTACTO;" },
             { QueryType.QueryBrokerContactsPaged, "SELECT CONTACTO,COMISIO,NOM_CONTACTO, NIF, PG.CODIGO as CARGO, PG.NOMBRE AS NOM_CARGO, TELEFONO, MOVIL, FAX, EMAIL, CC.USUARIO, CC.ULTMODI, DL.CLDIDDELEGA as DelegaId, cldDelegacion DELEGACC_NOM FROM CONTACTOS_COMI AS CC LEFT OUTER JOIN PERCARGOS AS PG ON CC.CARGO = PG.CODIGO LEFT OUTER JOIN COMI_DELEGA AS DL ON CC.DELEGA_CC = DL.CLDIDDELEGA AND CC.COMISIO = DL.CLDIDCOMI  ORDER BY CC.CONTACTO;" },
            { QueryType.QueryClientVisits, "SELECT visIdVisita as VisitId,visIdCliente as ClientId,visIdContacto as VisitClientId,visFecha as VisitDate,visIdVendedor as VisitResellerId,visIdVisitaTipo as VisitTypeId,PEDIDO as VisitOrder, PV.CONTACTO as ContactId,TV.CODIGO_VIS as VisitCode, TV.NOMBRE_VIS as VisitTypeName, TV.ULTMODI as VisitTypeLastModification, TV.USUARIO as VisitTypeUser , NUM_VENDE as ResellerId, PV.nom_contacto AS ContactName, VE.NOMBRE as ResellerName, VE.MOVIL as ResellerCellPhone FROM VISITAS_COMI CC LEFT OUTER JOIN CONTACTOS_COMI PV ON PV.COMISIO = CC.VISIDCLIENTE AND PV.CONTACTO = CC.VISIDCONTACTO LEFT OUTER JOIN TIPOVISITAS TV ON TV.CODIGO_VIS = CC.VISIDVISITATIPO LEFT OUTER JOIN VENDEDOR VE ON VE.NUM_VENDE = CC.visIdVendedor WHERE VISIDCLIENTE='{0}' ORDER BY CC.visFECHA;"},
            { QueryType.QuerySupplierById, "SELECT PROVEE1.NUM_PROVEE as NUM_PROVEE,NIF,TIPO,NOMBRE,DIRECCION,DIREC2,PROVEE1.CP,PROVEE2.COMERCIAL,PROVEE2.PREFIJO,PROVEE2.CONTABLE,PROVEE2.FORPA,PROVEE2.PLAZO,PROVEE2.PLAZO2,PROVEE2.PLAZO3,PROVEE2.DIA,PROVEE2.PALBARAN, PROVEE2.INTRACO,PROVEE2.DIA2,PROVEE2.DIA3,PROVEE2.DTO,PROVEE2.PP,PROVEE2.DIVISA,PROVEE2.PALBARAN,PROVEE2.INTRACO,PROVEE1.POBLACION,PROVEE1.PROV,NACIOPER,TELEFONO,FAX,MOVIL,INTERNET,EMAIL,PERSONA,SUBLICEN,GESTION_IVA_IMPORTA,OFICINA,FBAJA,FALTA,NOTAS,OBSERVA,CTAPAGO,TIPOIVA,MESVACA,MESVACA2,CC,IBAN,BANCO,SWIFT,IDIOMA_PR1,GESTION_IVA_IMPORTA,NOAUTOMARGEN,PROALB_COSTE_TRANSP,EXENCIONES_INT,CTALP,CONTABLE,CUGASTO,RETENCION,CTAPAGO,AUTOFAC_MANTE,CTACP,CTALP,DIR_PAGO,DIR2_PAGO,CP_PAGO,POB_PAGO, PROV_PAGO,PAIS_PAGO,TELF_PAGO,FAX_PAGO, PERSONA_PAGO,MAIL_PAGO,DIR_DEVO,DIR2_DEVO,POB_DEVO,CP_DEVO,PROV_DEVO,PAIS_DEVO,TELF_DEVO,FAX_DEVO,PERSONA_DEVO,MAIL_DEVO,DIR_RECLAMA,DIR2_RECLAMA,CP_RECLAMA,POB_RECLAMA,PROV_RECLAMA,PAIS_RECLAMA,TELF_RECLAMA,FAX_RECLAMA,PERSONA_RECLAMA,MAIL_RECLAMA,VIA,FORMA_ENVIO,CONDICION_VENTA,DIRENVIO6,CTAINTRACOP,ctaintracoPRep FROM PROVEE1 LEFT OUTER JOIN POBLACIONES POBLA ON PROVEE1.POBLACION = POBLA.POBLA LEFT OUTER JOIN PROVINCIA as P  ON PROVEE1.PROV=P.SIGLAS INNER JOIN PROVEE2 ON PROVEE1.NUM_PROVEE = PROVEE2.NUM_PROVEE WHERE PROVEE2.NUM_PROVEE='{0}'"},
            {QueryType.QuerySuppliersBranches, "SELECT cldIdDelega, cldDelegacion,cldDireccion1,cldDireccion2, cldIdProvincia, cldPoblacion, cldTelefono1, cldTelefono2, cldEmail,cldFax,CP as CP, PROV as NOM_PROV FROM ProDelega LEFT OUTER JOIN PROVINCIA ON cldIdProvincia = PROVINCIA.SIGLAS WHERE cldIdCliente={0} ORDER BY cldIdCliente;" },
            {
                QueryType.QueryVehicleModel, "SELECT * FROM MODELO WHERE MAR='{0}' AND MO1='{1}' AND MO2='{2}'"

            },
            {
                QueryType.QueryVehicleModelWithCount, "SELECT COUNT(*) FROM MODELO WHERE MARCA='{0}' AND CODIGO='{1}' AND VARIANTE='{2}';SELECT * FROM MODELO WHERE MARCA='{0}' AND CODIGO='{1}' AND VARIANTE='{2}'"

            },
            {
                QueryType.QueryVehiclePhoto, "select count(*) from vehiculo1 inner join pictures on CODIINT = cod_asociado and empresa = -2 and filename = rutafoto where (cod_asociado  is not null) and (codiint='{0}');select PICTURE,EMPRESA,FILENAME from vehiculo1 inner join pictures on CODIINT = cod_asociado and empresa = -2 and filename = rutafoto where (cod_asociado  is not null) and (codiint='{0}')"
            },
            {
                QueryType.QueryDeptContable, "SELECT NUM_DELEGA,D.NOMBRE, CLIENTE_DEP, C1.NOMBRE AS NOMCLI FROM DELEGA D LEFT OUTER JOIN CLIENTES1 C1 ON CLIENTE_DEP = NUMERO_CLI WHERE NUM_DELEGA='{0}'"
            },
            {
                QueryType.QueryVehicleColor, "SELECT * FROM COLORFL WHERE CODIGO='{0}'"
            },
            {
                QueryType.QueryVehicleActivity,  "select * from ACTIVEHI where NUM_ACTIVEHI='{0}'"
            },
            {
                QueryType.QueryVehicleGroup, "SELECT * from GRUPOS WHERE CODIGO='{0}'"
            },
            {

                QueryType.QueryVehicleOwner, "select NUM_PROPIE as Codigo, " +
                                             "NOMBRE as Nombre, DIRECCION as Direccion, POBLACION as Poblacion, " +
                                             "PROPIE.CP as CP, PROVINCIA.PROV as Provincia, " +
                                             "NIF, TELEFONO as Telefono, FAX as Fax, EMAIL as Email from PROPIE " +
                                             "LEFT OUTER JOIN PROVINCIA ON PROPIE.PROVINCIA = PROVINCIA.SIGLAS WHERE NUM_PROPIE='{0}'"
            },
            {
                QueryType.QueryAgentByVehicle, "select NUM_AG as Code, " +
                                               "NOMBRE as Nombre, DIRECCION as Direccion, POBLACION as Poblacion, " +
                                               "AGENTES.CP as CP, PROVINCIA.PROV as Provincia, " +
                                               "NIF, TELEFONO as Telefono, FAX as Fax, EMAIL as Email from AGENTES " +
                                               "INNER JOIN PROVINCIA ON AGENTES.PROVINCIA = PROVINCIA.SIGLAS WHERE NUM_AG='{0}'"
            },
            {
                QueryType.QueryBrandByVehicle, "SELECT CODIGO,NOMBRE,PACTADAS,FECHA,LOCUTOR,PROVEE,CONDICIONES,MARCAS.ULTMODI,MARCAS.USUARIO,FBAJA,OBS,CTA_MARCA FROM MARCAS INNER JOIN VEHICULO1 ON VEHICULO1.MAR=MARCAS.CODIGO WHERE VEHICULO1.CODIINT='{0}'"
            },
            {
                QueryType.QueryVehicleMaintenance, "select count(*)  from MANTENIMIENTO_VEHICULO LEFT OUTER JOIN MANTENIMIENTO m ON CODIGO_MAN = CODIGO_MANT_MV WHERE CODIGO_VEHI_MV='{0}' AND FBAJA_MV iS NULL OR FBAJA_MV >=GETDATE(*);select CODIGO_MAN as MaintananceCode, NOMBRE_MAN as MaintananceName, ULT_FEC_MV as LastMaintenenceDate, ULT_KM_MV as  LastMaintananceKMs, PROX_FEC_MV as NextMaintenenceDate, PROX_KM_MV as  NextMaintananceKMs, OBSERVACIONES_MAN as Observation from MANTENIMIENTO_VEHICULO LEFT OUTER JOIN MANTENIMIENTO m ON CODIGO_MAN = CODIGO_MANT_MV WHERE CODIGO_VEHI_MV='{0}' AND FBAJA_MV iS NULL OR FBAJA_MV >=GETDATE(*)"
            },
            {
                QueryType.QueryVehicleById, "select * from vehiculo1 inner join vehiculo2 on VEHICULO1.codiint = vehiculo2.codiint where vehiculo1.codiint='{0}';"
            },
            {
                QueryType.QueryBookingSummary, "select * from reservas1 inner join reservas2 on reservas1.NUMERO_RESERVA = reservas2.NUMERO_RESERVA"
            },
            {
                 QueryType.QueryBooking, "SELECT * FROM RESERVAS1 INNER JOIN RESERVAS2 ON RESERVAS1.NUMERO_RES = RESERVAS2.NUMERO_RES WHERE RESERVAS2.NUMERO_RES='{0}';SELECT * FROM LIRESER WHERE NUMERO='{0}'"
            },
            {
                 QueryType.QueryBookingMedia, "SELECT * FROM MEDIO_RES WHERE CODIGO='{0}'"
            },
         
            { QueryType.QueryDelivering, "SELECT * FROM ENTREGAS;" },
            { QueryType.QueryBookingItem, @"select * from LIRESER WHERE CLAVE_LR='{0}';" },
            { QueryType.QueryBookingItems, @"SELECT * FROM LIRESER WHERE NUMERO='{0}'" },
            { QueryType.QueryActiveFare,@"SELECT TOP {0} START AT {1} DISTINCT(XX.TARIFA) AS Fare, XX.NOMBRE as Name, XX.ACTIVA as IsActive from ( SELECT TC.TARIFA, T.NOMBRE, T.ACTIVA FROM TARICLI TC INNER JOIN NTARI T ON TC.TARIFA=T.CODIGO WHERE TC.CLIENTE='{2}' UNION ALL SELECT CODIGO,NOMBRE, ACTIVA FROM Ntari WHERE PUBLICA='1')XX WHERE XX.ACTIVA=1;" },

            { QueryType.QueryContractsByClient, @"SELECT NUMERO as Contract, CLIENTE_CON1 as ClientCode, D.NOMBRE as Driver, DIAS_CON1 as Days, FPREV_CON1 as ForeCastDeparture, FECHA_CON1 as DepartureDate, FRETOR_CON1 as ReturnData, V.MATRICULA as Matricula, V.MARCA as Brand, V.MODELO as Model, TARIFA_CON1 as Fare,F.NUMERO_FAC as InvoiceNumber, F.BRUTO_FAC as GrossInvoice from CONTRATOS1 LEFT OUTER JOIN VEHICULO1 V ON V.CODIINT=VCACT_CON1 LEFT OUTER JOIN CLIENTES1 D ON D.NUMERO_CLI=CONDUCTOR_CON1 LEFT OUTER JOIN FACTURAS F ON F.CLIENTE_FAC=CLIENTE_CON1 WHERE CLIENTE_CON1='{0}';" },
            { QueryType.QueryCountActiveFare,@"SELECT COUNT(DISTINCT(XX.TARIFA)) from ( SELECT TC.TARIFA, T.NOMBRE, T.ACTIVA FROM TARICLI TC INNER JOIN NTARI T ON TC.TARIFA=T.CODIGO WHERE TC.CLIENTE='{2}' UNION ALL SELECT CODIGO,NOMBRE, ACTIVA FROM Ntari WHERE PUBLICA='1')XX WHERE XX.ACTIVA=1;" },
            { QueryType.QueryBudgetKey, "select * from CLAVEPTO WHERE COD_CLAVE='{0}'"},
            { QueryType.QueryVehicleBrand, "select * from marcas where codigo='{0}'"},
            { QueryType.QueryReseller, "select NUM_VENDE, NOMBRE, DIRECCION, POBLACION, VENDEDOR.CP as CP, PR.PROV as PROVINCIA, TELEFONO,MOVIL from vendedor left outer join provincia as pr on pr.SIGLAS = VENDEDOR.PROVINCIA WHERE NUM_VENDE='{0}'" },
            { QueryType.QueryReservationRequest, "SELECT * FROM PETICION WHERE NUMERO='{0}'" },
            { QueryType.QueryReservationRequestSummaryPaged, "SELECT TOP {0} START AT {1} NUMERO AS Code, PETICION.SUBLICEN AS CompanyCode, SUBLICEN.NOMBRE as CompanyName, Fecha as CurrentDate, DIAS as Days, CATEGO as VehicleGroup,PETICION.CLIENTE as ClientCode, CLIENTES1.NOMBRE as ClientName, MOPETI as Reason, PETICION.OBS1 as Notes FROM PETICION LEFT OUTER JOIN SUBLICEN ON SUBLICEN.CODIGO=PETICION.SUBLICEN LEFT OUTER JOIN CLIENTES1 ON CLIENTES1.NUMERO_CLI=PETICION.CLIENTE;" },
            { QueryType.QueryReservationRequestSummary, "SELECT NUMERO AS Code, PETICION.SUBLICEN AS CompanyCode, SUBLICEN.NOMBRE as CompanyName, Fecha as Date, DIAS as Days, CATEGO as Group,PETICION.CLIENTE as ClientCode, CLIENTES1.NOMBRE as ClientName, MOPETI as Reason, OBS1 as Notes, USER as CurrentUser, ULTMODI as LastModification FROM PETICION LEFT OUTER JOIN SUBLICEN COMPANY ON COMPANY.CODIGO=PETICION.SUBLICEN LEFT OUTER JOIN CLIENTES1 ON CLIENTES1.NUMERO_CLI=PETICION.CLIENTE;" },
            {QueryType.QueryReservationRequestReason, "SELECT * FROM MOPETI WHERE CODIGO='{0}'" },
            {QueryType.QueryFares, "SELECT * FROM NTARI WHERE CODIGO='{0}'" },
            {QueryType.QueryBrokerVisit, "SELECT visIdVisita as VisitId,visIdCliente as VisitClientId,visIdContacto as ContactId,visFecha as VisitDate,visIdVendedor as ResellerId, visIdVisitaTipo as VisitTypeId, TV.NOMBRE_VIS as VisitTypeName, PV.nom_contacto AS ContactName, PEDIDO as VisitOrder, VE.NOMBRE as ResellerName FROM VISITAS_COMI CC LEFT OUTER JOIN CONTACTOS_COMI PV ON  PV.CONTACTO = CC.VISIDCONTACTO LEFT OUTER JOIN TIPOVISITAS TV ON TV.CODIGO_VIS = CC.VISIDVISITATIPO LEFT OUTER JOIN VENDEDOR VE ON VE.NUM_VENDE = CC.visIdVendedor WHERE VISIDCLIENTE= '{0}' ORDER BY CC.visFECHA" },
            { QueryType.QueryPrintingType, "SELECT * FROM CONTRATIPIMPR WHERE CODIGO='{0}'" },
            { QueryType.QueryDriverWithContract, "select DISTINCT CONDUCTOR_CON1 as Code, clientes1.NOMBRE as Name from clientes1 inner join contratos1 on clientes1.NUMERO_CLI = contratos1.CONDUCTOR_CON1 WHERE NUMERO_CLI = '{0}';" },
            { QueryType.QueryMulti, ""}
            /*
            { QueryType.QueryVehicleMaintenance,  "select CODIGO_MAN as MaintananceCode, NOMBRE_MAN as MaintananceName, ULT_FEC_MV as LastMaintenenceDate, ULT_KM_MV as  LastMaintananceKMs, PROX_FEC_MV as NextMaintenenceDate, PROX_KM_MV as  NextMaintananceKMs, OBSERVACIONES_MAN as Observation from MANTENIMIENTO_VEHICULO LEFT OUTER JOIN MANTENIMIENTO m ON CODIGO_MAN = CODIGO_MANT_MV WHERE CODIGO_VEHI_MV='{0}' AND FBAJA_MV iS NULL OR FBAJA_MV >=GETDATE(*)" }*/

        };

        public QueryStore()
        {

        }
        /// <summary>
        ///  Working memory to assign and build a query.
        /// </summary>
        [XmlIgnore]
        private MultiDictionary<QueryType, string> _memoryStore = new MultiDictionary<QueryType, string>();
        [XmlIgnore]
        private StringBuilder _multiQuery = new StringBuilder();
       
        /// <summary>
        ///  Get the list of the available queries in the system.
        /// </summary>
        [XmlElement("Queries")]
        public Dictionary<QueryType, string> Queries
        {
            get { return _dictionary; }
        }

        public static QueryType BookingIncidentSummaryPaged { get; internal set; }



        /// <summary>
        /// Build a query set for using with the dapper multiple query command.
        /// </summary>
        /// <param name="queryList">List of queries</param>
        /// <param name="codeList">List of codes</param>
        /// <returns></returns>
        private IList<string> BuildQuerySet(List<QueryType> queryList, List<string> codeList)
        {
            var currentList = new List<string>();
            if (queryList.Count != codeList.Count)
            {
                return new List<string>();
            }
            var i = 0;
            foreach (var typeOfQuery in queryList)
            {
                _dictionary.TryGetValue(typeOfQuery, out var valueofQuery);

                if (!string.IsNullOrEmpty(valueofQuery))
                {
                    var value = string.Empty;

                    try
                    {
                        value = string.IsNullOrEmpty(codeList[i]) ? valueofQuery : string.Format(valueofQuery, codeList[i]);
                    } catch (System.Exception ex)
                    {
                        var v = ex;
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
            var currentValue = BuildQuerySet(queryList, codeList);
            var builder = new StringBuilder();
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
        public IQueryStore AddParamRange(QueryType query, long start, long stop)
        {
            _dictionary.TryGetValue(query, out var tmpQuery);
            if (string.IsNullOrEmpty(tmpQuery))
            {
                throw new ArgumentNullException("Resolved query is null");
            }
            tmpQuery = string.Format(tmpQuery, start, stop);
            _memoryStore.Add(query, tmpQuery);
            return this;
        }
        /// <summary>
        ///  Parameter list.
        /// </summary>
        /// <param name="query">Type of the query</param>
        /// <param name="parameter">List of parameters</param>
        public IQueryStore AddParam(QueryType query, IList<string> parameter)
        {
            var args = new object[parameter.Count];
            int k = 0;
            foreach (var p in parameter)
            {
                args[k] = p;
                k++;
            }

            _dictionary.TryGetValue(query, out var tmpQuery);
            tmpQuery = string.Format(tmpQuery ?? throw new InvalidOperationException(), args);
            _dictionary.Remove(query);
            _dictionary.Add(query, tmpQuery);
            _memoryStore.Add(query, string.Empty);
            return this;
        }
        /// <summary>
        /// Add a parameter to build in the memory store.
        /// </summary>
        /// <param name="queryCity">Kind of query type</param>
        /// <param name="code">Code of the query</param>
        public IQueryStore AddParam(QueryType queryCity, string code)
        {
            if (string.IsNullOrEmpty(code)) return this;
            Logger.Debug(queryCity.ToString());
            if (!_memoryStore.ContainsKey(queryCity))
            {
                _memoryStore.Add(queryCity, code);
            }
            return this;
        }
        private void MergeDuplicate(QueryType type)
        {
            if (_memoryStore.ContainsKey(type))
            {
                var current = _dictionary[type].Split(';')[1];
                var buildQuery = BuildQuery();

                _dictionary.Remove(type);
                _dictionary.Add(type, current + ";" + buildQuery);

            }
        }
        public IQueryStore AppendFirstParam(QueryType query, string param)
        {
            if (string.IsNullOrEmpty(param)) return this;



            string outString = string.Empty;
            var simpleQuery = _dictionary.TryGetValue(query, out outString);

            var newQuery = new StringBuilder();
            newQuery.Append(param);
            newQuery.Append(";");
            newQuery.Append(outString);
            _dictionary.Remove(query);
            _dictionary.Add(query, newQuery.ToString());
            return this;
        }

        public IQueryStore AddParamCount(QueryType type, string table, string primaryKey, string code, string refCode = "")
        {
            if (string.IsNullOrEmpty(code))
                return this;


            var count = GetCountItems(table, primaryKey, code);


            AppendFirstParam(type, count);
            var queryCode = code;
            if (!string.IsNullOrEmpty(refCode))
                queryCode = refCode;
            AddParam(type, queryCode);
            return this;
        }

        /// <inheritdoc />
        /// <summary>
        /// Build the query and returns the values.
        /// </summary>
        /// <returns>This returns the query.</returns>
        public virtual string BuildQuery()
        {
            var collectionKeys = new List<QueryType>();
            var collectionValues = new List<string>();
            foreach (var key in _memoryStore.Keys)
            {
                var list = _memoryStore[key];
                foreach (var v in list)
                {
                    collectionKeys.Add(key);
                    collectionValues.Add(v);
                }
            }
            var value = BuildMultipleQuery(collectionKeys, collectionValues);
            _memoryStore.Clear();
            return value;
        }
        /// <inheritdoc />
        /// <summary>
        ///  Clear the query store.
        /// </summary>
        public virtual IQueryStore Clear()
        {
            _memoryStore.Clear();
            return this;
        }
        /// <summary>
        ///  Add a parameter for the query type.
        /// </summary>
        /// <param name="query">Query type</param>
        public IQueryStore AddParam(QueryType query)
        {
            _memoryStore.Add(query, string.Empty);
            return this;
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
      

        /// <summary>
        /// Add parameters to the query set in the working memory
        /// </summary>
        /// <typeparam name="T1">First parameter type</typeparam>
        /// <typeparam name="T2">Second parameter type</typeparam>
        /// <param name="queryType">Type of the query</param>
        /// <param name="firstCode">Fist code type</param>
        /// <param name="secondCode">Second code type</param>
        public IQueryStore AddParam<T1, T2>(QueryType queryType, T1 firstCode, T2 secondCode)
        {
            var code = firstCode.ToString();
            var code2 = secondCode.ToString();
            IList<string> par = new List<string>
            {
                code,
                code2
            };
            this.AddParam(queryType, par);
            return this;
        }
        /// <summary>
        /// Add parameters to the query set in the working memory
        /// </summary>
        /// <typeparam name="T1">First parameter type</typeparam>
        /// <typeparam name="T2">Second parameter type</typeparam>
        /// <typeparam name="T3">Third parameter type</typeparam>
        /// <param name="queryType">Type of the query</param>
        /// <param name="firstCode">First code type</param>
        /// <param name="secondCode">Second code type</param>
        /// <param name="thirdCode">Third code type</param>
        public IQueryStore AddParam<T1, T2, T3>(QueryType queryType, T1 firstCode, T2 secondCode, T3 thirdCode)
        {
            var code = firstCode.ToString();
            var code2 = secondCode.ToString();
            var code3 = thirdCode.ToString();
            IList<string> par = new List<string>();
            par.Add(code);
            par.Add(code2);
            par.Add(code3);
            this.AddParam(queryType, par);
            return this;
        }
        /// <summary>
        /// Build a query without passing through the working memory.
        /// </summary>
        /// <param name="queryType">Type of the query. The type of the query shall have the same size of the working memory.</param>
        /// <param name="param">List of parameters.</param>
        /// <returns></returns>
        public string BuildQuery(QueryType query, IList<string> param)
        {

            var args = new object[param.Count];
            var k = 0;
            string tmpQuery = string.Empty;
            foreach (var p in param)
            {
                args[k] = p;
                k++;
            }
            if (!_memoryStore.TryGetValue(query, out string tmpQuery1))
            {
                if (_dictionary.TryGetValue(query, out var tmpQuery2))
                {
                    tmpQuery = tmpQuery2;
                }
            }
            else
            {
                tmpQuery = tmpQuery1;
            }
            tmpQuery = string.Format(tmpQuery ?? throw new InvalidOperationException("QueryType is null"), args);
            return tmpQuery;
        }

        public string GetCountQuery(QueryTable client)
        {

            return "";
        }

        public string GetCountItems(string table, string key, string number)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT COUNT(*) ");
            builder.Append("FROM ");
            builder.Append(table);
            builder.Append(" WHERE ");
            builder.Append(key);
            builder.Append("=");
            builder.Append("'");
            builder.Append(number);
            builder.Append("'");
            return builder.ToString();

        }
        /// <summary>
        ///  Add a param filter: NAME REGEXP value.
        /// </summary>
        /// <param name="pagedQuery">Type of the paged query</param>
        /// <param name="queryFilter">Filter chain to be used.</param>

        public IQueryStore AddParamFilter(QueryType pagedQuery, IQueryFilter queryFilter)
        {
            string filter = " WHERE " + queryFilter.Resolve();
            _memoryStore.Add(pagedQuery, filter);
            return this;
        }
        /// <summary>
        ///  Add parameters for sorting.
        /// </summary>
        /// <param name="queryTemplate">Type of the paged array</param>
        /// <param name="sortChain">Index of sorting</param>
        /// <returns>The current query store.</returns>
        public IQueryStore AddParamFilterSort(QueryType queryTemplate, Dictionary<string, ListSortDirection> sortChain)
        {
            var orderByBuilder = new StringBuilder();
            _dictionary.TryGetValue(queryTemplate, out var tmpQuery);
            orderByBuilder.Append(tmpQuery);
            orderByBuilder.Append(" ORDER BY ");
            foreach (var pair in sortChain)
            {
                orderByBuilder.Append(pair.Key);
                var key = sortChain[pair.Key];
                if (key == ListSortDirection.Ascending)
                {
                    orderByBuilder.Append(" ASC, ");
                }
                else
                {
                    orderByBuilder.Append(" DESC, ");
                }
            }
            var orderQuery = orderByBuilder.ToString().Trim();
            if (orderQuery[orderQuery.Count()-1] == ',')
            {
               orderQuery = orderQuery.Substring(0, orderQuery.Count() - 1);
            }
            _memoryStore.Add(queryTemplate, orderQuery);
            return this;
        }

        public IQueryStore AddParamCount(QueryType type, string code, string refCode)
        {
            if (!_paramDictionary.ContainsKey(type))
            {
                throw new ArgumentException("Not valid key in the param dictionary");
            }
            var tuple = _paramDictionary[type];
            return AddParamCount(type, tuple.Item1, tuple.Item2, code, refCode);

        }

        public IQueryStore AddParamCount(QueryType query, string code)
        {
            if (code == null)
            {
                return this;
            }
            MergeDuplicate(query);
            return AddParamCount(query, code, string.Empty);
        }

        public IQueryStore AddParamCount(QueryType type, byte? code)
        {
            if (code.HasValue)
            {
                var value = code.ToString();
                AddParamCount(type,value);
            }
            return this;
        }

        public void Save(string path)
        {
            ExtendedXmlSerializer serializer = new ExtendedXmlSerializer();
            var xml = serializer.Serialize(this);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            using (XmlTextWriter writer = new XmlTextWriter(path, null))
            {
                writer.Formatting = Formatting.Indented;
                doc.Save(writer);
            }
        }

        public virtual IComposableStore Compose(QueryType queryBooking)
        {
            return new ComposableStore(this);
        }
    }
}
