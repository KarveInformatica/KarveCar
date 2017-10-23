using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using Dapper;
using DataAccessLayer.Exception;
using DesignByContract;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDapper.Extensions;
using Prism.Mvvm;

namespace DataAccessLayer.DataObjects.Wrapper
{

    public class CommissionAgentFactory
    {
        // SELECT TOP 5 START AT 50 * FROM ProDelega;
        private const string CommissionAgentIds = "SELECT {0} NUM_COMI FROM COMISIO";
        private const string CommissionAgentLimitsId = " SELECT TOP {0} START AT {1} {2} FROM COMISIO";
        private readonly ISqlQueryExecutor _sqlQueryExecutor;
        /// <summary>
        ///  This is the factory for the commission agent. 
        /// </summary>
        /// <param name="queryExecutor">Query executor of the things</param>
        /// <returns></returns>
        public static CommissionAgentFactory GetFactory(ISqlQueryExecutor queryExecutor)
        {
            return new CommissionAgentFactory(queryExecutor);
        }
        /// <summary>
        ///  This is the queryExecutro factory.
        /// </summary>
        /// <param name="queryExecutor"></param>
        private CommissionAgentFactory(ISqlQueryExecutor queryExecutor)
        {
            _sqlQueryExecutor = queryExecutor;
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
            DesignByContract.Dbc.Requires(_sqlQueryExecutor.Connection != null, "Null Connection");
            IDbConnection connection = _sqlQueryExecutor.Connection;
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
            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                IEnumerable<COMISIO> commissionAgents = await connection.QueryAsync<COMISIO>(currentQueryAgent);
                foreach (COMISIO c in commissionAgents)
                {
                    
                    CommissionAgent agent = new CommissionAgent(_sqlQueryExecutor);
                    bool loaded = await agent.LoadValue(fields, c.NUM_COMI);
                    if (loaded)
                    {
                        list.Add(agent);
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// Commission agent.
        /// </summary>
        /// <returns>A commission agent</returns>
        public ICommissionAgent NewCommissionAgent()
        {
            CommissionAgent agent = new CommissionAgent(_sqlQueryExecutor);
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
            DesignByContract.Dbc.Requires(fields.Count > 0, "Fields not valid");
            DesignByContract.Dbc.Requires(!string.IsNullOrEmpty(commissionId), "Null Connection");
            CommissionAgent agent = new CommissionAgent(_sqlQueryExecutor);
            bool loaded = await agent.LoadValue(fields, commissionId).ConfigureAwait(false);
            agent.Valid = loaded; 
            return agent;
        }
        
    }

    /// <summary>
    ///  This class returns the commission agent for a file.
    /// </summary>
    public class CommissionAgent : BindableBase, ICommissionAgent
    {
        public const string Comisio = "COMISIO";
        public const string Tipocomi = "TIPOCOMI";
        public const string Contactos = "CONTACTOS";
        public const string Branches = "BRANCHES";
        public const string Visitas = "VISITAS";
        private const string DefaultTicomiFields = "NUM_TICOMI,NOMBRE";

        private const string DefaultContactosFields =
            "NUM_CONTACTO, NIF, CARGO, TELEFONO, MOVIL, FAX, EMAIL, USUARIO, ULTIMODI";

        private const string DefaultVisitasField =
            "visIdVisita,visIdCliente,visIdContacto,visIdFecha,visIdVendedor, visIdVisitaTipo";

        private const string DefaultDelegation =
                "cldIdCOMI, cldDelegacion, cldDireccion1, cldDireccion2, cldCP, cldPoblacion, cldIdProvincia,cldTelefono1, cldTelefono2, cldFax, cldEMail, cldMovil"
            ;

        private IEnumerable<COMISIO> _commissionAgents;
        private IEnumerable<Country> _nacioPer;
        private IEnumerable<TIPOCOMI> _tipoComis;
        private IEnumerable<PROVINCIA> _provinces;
        private IEnumerable<CONTACTOS_COMI> _contactos;
        private IEnumerable<COMI_DELEGA> _delegations;
        private IEnumerable<VISITAS_COMI> _visitasComis;


        private readonly ISqlQueryExecutor _queryExecutor;
        private COMISIO _currentComisio;
        private string _queryTipoComi = "SELECT {0} FROM TIPOCOMI WHERE NUM_TICOMI='{1}'";
        private string _queryProvincia = "SELECT SIGLAS,PROV FROM PROVINCIA WHERE SIGLAS='{0}'";
        private string _queryPais = "SELECT SIGLAS,PAIS FROM PROVINCIA WHERE SIGLAS='{0}'";
        private string _queryComi = "SELECT {0} FROM COMISIO WHERE NUM_COMI='{1}'";

        private string _queryContactos = "SELECT COMISIO,NOM_CONTACTO, NIF, CARGO, TELEFONO, MOVIL, " +
                                         "FAX, EMAIL, CC.USUARIO, CC.ULTMODI, cldDelegacion DELEGACC_NOM " +
                                         "FROM CONTACTOS_COMI AS CC " +
                                         "LEFT OUTER JOIN PERCARGOS AS PG ON CC.CARGO = PG.CODIGO " +
                                         "LEFT OUTER JOIN COMI_DELEGA AS DL ON CC.DELEGA_CC = DL.CLDIDDELEGA " +
                                         "AND CC.COMISIO = DL.CLDIDCOMI WHERE COMISIO = '{0}' ORDER BY CC.CONTACTO";

        private string _queryComiDelega = "SELECT {0},PV.PROV AS NOM_PROV FROM COMI_DELEGA CC " +
                                          "LEFT OUTER JOIN PROVINCIA PV ON PV.SIGLAS = CC.cldIdProvincia" +
                                          " WHERE cldIdCOMI='{1}' ORDER BY CC.cldIdDelega";

        
        private string _queryVisitas = "SELECT visIdVisita,visIdCliente,visIdContacto,visFecha,visIdVendedor, " +
                                       "visIdVisitaTipo, PV.nom_contacto AS NOMCONTACTO, VE.NOMBRE FROM VISITAS_COMI CC " +
                                       "LEFT OUTER JOIN CONTACTOS_COMI PV ON PV.COMISIO = CC.VISIDCLIENTE AND PV.CONTACTO = CC.VISIDCONTACTO " +
                                       "LEFT OUTER JOIN VENDEDOR VE ON VE.NUM_VENDE = CC.visIdVendedor WHERE VISIDCLIENTE= '{0}' ORDER BY CC.visFECHA";

        private bool isChanged = false;
        private bool _valid = false;
        private CommissionAgentTypeData _commissionAgentType;
        private IDbConnection _dbConnection = null;


        /// <summary>
        ///  Commission agent ctr.
        /// </summary>
        public CommissionAgent(ISqlQueryExecutor executor)
        {
            _queryExecutor = executor;
            _currentComisio = new COMISIO();
            _commissionAgents = new List<COMISIO>();
            _nacioPer = new List<Country>();
            _tipoComis = new List<TIPOCOMI>();
            _provinces = new List<PROVINCIA>();
            _contactos = new List<CONTACTOS_COMI>();
            _delegations = new List<COMI_DELEGA>();
            _visitasComis = new List<VISITAS_COMI>();
            _commissionAgentType = new CommissionAgentTypeData();
        }

        
        /// <summary>
        ///  Changed value agent
        /// </summary>
        public bool Changed
        {
            set { isChanged = value; }
            get { return isChanged; }
        }
       
        /// <summary>
        /// This load the single value.
        /// <returns>This returns a bool value</returns>
        /// </summary>
        public object Commission
        {
            set
            {
                _currentComisio = (COMISIO) value;
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

            string commisionQueryFields = commissionDictionary[Comisio];
            string tipoComiFields = GetFields(Tipocomi,commissionDictionary, DefaultTicomiFields);
            string branchesField = GetFields(Branches, commissionDictionary, DefaultDelegation);

            bool isOpen = false;
            if (_dbConnection == null)
            {
                isOpen = _queryExecutor.Open();
            }
           

            // now between the two

            if (isOpen)
            {
                try
                {
                    _dbConnection = _queryExecutor.Connection;
                    string commisionQuery = string.Format(_queryComi, commisionQueryFields, commissionId);
                    if (_dbConnection.State != ConnectionState.Open)
                    {
                       _dbConnection.Open();
                    }
                    _commissionAgents = await _dbConnection.QueryAsync<COMISIO>(commisionQuery);
                    _currentComisio = _commissionAgents.First();
                    if (string.IsNullOrEmpty(_currentComisio.PROVINCIA))
                    {
                        string provinceQuery = string.Format(_queryProvincia, _currentComisio.PROVINCIA);
                        _provinces = await _dbConnection.QueryAsync<PROVINCIA>(provinceQuery).ConfigureAwait(false);
                    }
                    string queryTipoComi = string.Format(_queryTipoComi, tipoComiFields, _currentComisio.TIPOCOMI);
                    _tipoComis = await _dbConnection.QueryAsync<TIPOCOMI>(queryTipoComi).ConfigureAwait(false);
                    string queryContactos = string.Format(_queryContactos, _currentComisio.NUM_COMI);
                    _contactos = await _dbConnection.QueryAsync<CONTACTOS_COMI>(queryContactos);
                    if (!string.IsNullOrEmpty(_currentComisio.NACIOPER))
                    {
                        string queryPais = string.Format(_queryPais, _currentComisio.NACIOPER);
                        _nacioPer = await _dbConnection.QueryAsync<Country>(queryPais);

                    }
                    string delega = string.Format(_queryComiDelega, branchesField, _currentComisio.NUM_COMI);
                    _delegations = await _dbConnection.QueryAsync<COMI_DELEGA>(delega);
                    string visitas = string.Format(_queryVisitas,_currentComisio.NUM_COMI);
                    _visitasComis = await _dbConnection.QueryAsync<VISITAS_COMI>(visitas);
                }
                catch (System.Exception e)
                {
                    string message = e.Message;
                    return false;
                }
                finally
                {
                    _queryExecutor.Close();
                }
            }
            else
            {
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
            if (_dbConnection == null)
            {
                _queryExecutor.Open();
                _dbConnection = _queryExecutor.Connection;
            }


            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    // now we have to add the new connection.
                    await _dbConnection.InsertAsync<COMISIO>(_currentComisio).ConfigureAwait(false);
                    await _dbConnection.InsertAsync(_contactos);
                    await _dbConnection.InsertAsync(_delegations);
                    await _dbConnection.InsertAsync(_visitasComis);
                    transactionScope.Complete();
                    retValue = true;

                }
                catch (TransactionException ex)
                {
                    retValue = false;
                }
                catch (System.Exception ex)
                {
                    retValue = false;
                    throw new CommissionAgentException(ex.Message);
                }
                finally
                {
                    if (_dbConnection != null)
                    {
                       _dbConnection.Close();
                    }
                    transactionScope.Dispose();
                }
                
            }
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
            if ((_dbConnection == null)  || (_dbConnection.State != ConnectionState.Open))
            {

                _queryExecutor.Open();
                _dbConnection = _queryExecutor.Connection;

            }
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                   
                    // now we have to add the new connection.
                    retValue = await _dbConnection.UpdateAsync(_currentComisio);
                    if (_contactos.Count() != 0)
                    {
                        retValue = retValue && await _dbConnection.UpdateAsync(_contactos);
                    }
                    if (_delegations.Count() != 0)
                    {
                        retValue = retValue && await _dbConnection.UpdateAsync(_delegations);
                    }
                    if (_visitasComis.Count() != 0)
                    {
                        retValue = retValue && await _dbConnection.UpdateAsync(_visitasComis);
                    }
                    
                    transactionScope.Complete();
                    transactionScope.Dispose();
                }
                catch (TransactionException ex)
                {
                    transactionScope.Dispose();
                    MessageBox.Show("Transaction Exception Occured");
                   
                    return retValue;
                }
                catch (System.Exception ex1)
                {
                    transactionScope.Dispose();
                    MessageBox.Show(ex1.Message);
                    return retValue;
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
            bool retValue =true;
            IDbConnection connection = _queryExecutor.Connection;
            if (connection.State != ConnectionState.Open)
            {
                _queryExecutor.Open();
                connection = _queryExecutor.Connection;

            }

            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                // here i have to delete the current commission data.
                try
                {
                    // now we have to add the new connection.
                    // delete the cross references.
                    var contactRef = from contacto in _contactos
                        where contacto.COMISIO == _currentComisio.NUM_COMI
                        select contacto;
                    if (contactRef.Count() != 0)
                    {

                        retValue = await connection.DeleteAsync(contactRef);
                    }
                    var delegationRef = from delegation in _delegations
                        where delegation.cldIdCOMI == _currentComisio.NUM_COMI
                        select delegation;
                    var visitasRef = from visita in _visitasComis
                        where visita.visIdCliente == _currentComisio.NUM_COMI
                        select visita;
                    // This is very common.
                    if (delegationRef.Count() != 0)
                    {
                        retValue = retValue && await connection.DeleteAsync(delegationRef);
                    }
                    if (visitasRef.Count() != 0)
                    {
                        retValue = retValue && await connection.DeleteAsync(visitasRef);
                    }
                    retValue = retValue && await connection.DeleteAsync(_currentComisio);
                    transactionScope.Complete();
                }
                catch (TransactionException ex)
                {
                    transactionScope.Dispose();
                    return retValue;
                }
                catch (System.Exception ex)
                {
                    transactionScope.Dispose();
                    return retValue;
                }
                finally
                {
                    transactionScope.Dispose();
                }
            }
            return retValue;
        }

        /// <summary>
        ///  This method fill a single value.
        /// </summary>
        public async void FillSingleValue()
        {
            IDbConnection connection = _queryExecutor.Connection;
            if (_queryExecutor.Connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            string queryProvincia = string.Format(_queryProvincia, _currentComisio.PROVINCIA);
            _provinces = await connection.QueryAsync<PROVINCIA>(queryProvincia).ConfigureAwait(false);
            string queryTipoComi = string.Format(_queryTipoComi, _currentComisio.TIPOCOMI);
            _tipoComis = await connection.QueryAsync<TIPOCOMI>(queryTipoComi).ConfigureAwait(false);
            string queryPais = string.Format(_queryContactos, _currentComisio.NACIOPER);
            _nacioPer = await connection.QueryAsync<Country>(queryPais).ConfigureAwait(false);
            _queryExecutor.Close();
        }

        
        /// <summary>
        ///  Valid data
        /// </summary>
        public bool Valid { get; set; }


        private ICountryData GetCountryData(COMISIO data, IEnumerable<Country> country)
        {
            ICountryData dataCountry = new CountryData();
            dataCountry.Code = data.NACIOPER;
            var name = from countryvalue in country
                       where countryvalue.SIGLAS == dataCountry.Code
                       select  countryvalue.PAIS ;
            dataCountry.CountryName = name.Distinct().First();
            return dataCountry;
        }

        private void SetCountryData(ICountryData data)
        {
            _currentComisio.NACIOPER = data.Code;
        }


        private ICommissionAgentTypeData GetCommissionAgentType(COMISIO data, IEnumerable<TIPOCOMI> tipocomis)
        {
            ICommissionAgentTypeData dataCommission= new CommissionAgentTypeData();
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

        private void SetProviceData(IProvinceData data)
        {
            _currentComisio.PROVINCIA = data.Code;
        }

        private IProvinceData GetProvinceData(COMISIO data, IEnumerable<PROVINCIA> provinces)
        {
            IProvinceData provinceData = new ProvinceData();
            provinceData.Code = data.PROVINCIA;
            var name = from provincevalue in provinces
                where provincevalue.SIGLAS == data.PROVINCIA
                select provincevalue.PROV;
            provinceData.Name = name.Distinct().First();
            var countryCode = from provincevalue in provinces
                where provincevalue.SIGLAS == data.PROVINCIA
                select provincevalue.PAIS;
            provinceData.CountryCode = countryCode.Distinct().First();
            return provinceData;
        }

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

        /// <summary>
        ///  Set o Get Country Data
        /// </summary>
        public ICountryData Country
        {
            get { return GetCountryData(_currentComisio, _nacioPer); }
            set { SetCountryData(value);}
        }
        /// <summary>
        ///  Get o Set Province Data
        /// </summary>
        public IProvinceData ProvinceData
        {
            
            get { return GetProvinceData(_currentComisio, _provinces); }
            set
            {
                SetProviceData(value);
            }
        }
        /// <summary>
        ///  This convert an enumerable array to another one.
        /// </summary>
        /// <typeparam name="InType"></typeparam>
        /// <typeparam name="OutType"></typeparam>
        /// <param name="inDataArray"></param>
        /// <param name="outTypes"></param>
        public void ConvertToDataArrayDelega(IEnumerable<COMI_DELEGA> inDataArray, out List<IBranchesData> outTypes)
        {
            outTypes = new List<IBranchesData>();
            foreach (COMI_DELEGA value in inDataArray)
            {
                IBranchesData branch = new BranchData();
                branch.Code = value.cldIdDelega;
                branch.Name = value.cldDelegacion;
                branch.Address = value.cldDireccion1;
                branch.Address2 = value.cldDireccion2;
                branch.CodeProvince = value.cldIdProvincia;
                branch.City = value.cldPoblacion;
                branch.Email = value.cldEMail;
                branch.CodeAgent = value.cldIdCOMI;
                branch.LastModified = value.ULTMODI;
                branch.User = value.USUARIO;
                branch.ObjectValue = value;
                outTypes.Add(branch);
            }
        }
        public void ConvertToDataArrayVisit(IEnumerable<VISITAS_COMI> inDataArray, out List<IVisitData> outTypes)
        {
            outTypes = new List<IVisitData>();
          
        }
        /// <summary>
        ///  Get or set the delegation associated with this commission agent.
        /// </summary>
        public IEnumerable<IBranchesData> Delegation
        {
            get
            {
                List<IBranchesData> data;
                ConvertToDataArrayDelega(_delegations, out data);
                return data;
            }
            set => ConvertFromDataDelega(value, out _delegations);
        }

        private void ConvertFromDataDelega(IEnumerable<IBranchesData> value, out IEnumerable<COMI_DELEGA> delegations)
        {
            delegations = new List<COMI_DELEGA>();
            foreach (var comi in value)
            {
                ((List<COMI_DELEGA>) delegations).Add((COMI_DELEGA)comi.ObjectValue);
            }
        }

        public IEnumerable<IContactsData> Contacts
        {
            get
            {
                List<IContactsData> data;
                ConvertToDataArrayContacts(_contactos, out data);
                return data;
            }
            set
            {
                ConvertFromDataContact(value, out _contactos);
            }
        }

        private void ConvertFromDataContact(IEnumerable<IContactsData> value, out IEnumerable<CONTACTOS_COMI> contactos)
        {
           contactos = new List<CONTACTOS_COMI>();
            foreach (var comi in value)
            {
                ((List<CONTACTOS_COMI>)contactos).Add((CONTACTOS_COMI)comi.ObjectValue);
            }
        }

        private void ConvertToDataArrayContacts(IEnumerable<CONTACTOS_COMI> contactos, out List<IContactsData> data)
        {
            data = new List<IContactsData>();
            foreach (CONTACTOS_COMI value in contactos)
            {
                IContactsData contact = new ContactsData();
                contact.Code = value.CONTACTO;
                contact.Name = value.NOM_CONTACTO;
                contact.Nif = value.NIF;
                contact.Branch = value.DELEGA_CC;
                contact.Position = value.CARGO;
                contact.Email = value.EMAIL;
                contact.Phone = value.MOVIL;
                contact.Fax = value.FAX;
                contact.User = value.USUARIO;
                contact.ObjectValue = value;
                data.Add(contact);
            }
            
        }
    }
}
