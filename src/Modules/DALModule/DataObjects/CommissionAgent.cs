using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;
using Dapper;
using KarveCommon.Generic;
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Markup;
using KarveDataServices;
using Prism.Mvvm;

namespace DataAccessLayer.DataObjects
{
    /// <summary>
    ///  This class returns the commission agent for a file.
    /// </summary>
    public class CommissionAgent: BindableBase, ICommissionAgent
    {
        private IEnumerable<COMISIO> _commissionAgents;
        private IEnumerable<PAIS> _nacioPer;
        private IEnumerable<TIPOCOMI> _tipoComis;
        private IEnumerable<PROVINCIA> _provinces;
        private ISqlQueryExecutor _queryExecutor;
        private COMISIO _currentComisio;
        private  string _queryTipoComi = "SELECT {0} FROM TIPOCOMI WHERE NUM_TICOMI='{1}'";
        private  string _queryProvincia = "SELECT {0} FROM PROVINCIA WHERE SIGLAS='{0}'";
        private  string _queryPais = "SELECT {0} FROM PROVINCIA WHERE PAIS='{1}'";
        /*
          cSELECT & Cols & vbNewLine & _
                    ", ISNULL(NOM_CARGO, CG.NOMBRE) AS NOM_CARGO, cldDelegacion DELEGACC_NOM" & vbNewLine & _
            cFROM & "CONTACTOS_COMI CC" & vbNewLine & _
            cOUTER & "PERCARGOS CG ON CC.CARGO = CG.CODIGO" & vbNewLine & _
            cOUTER & "COMI_DELEGA DL ON (CC.DELEGA_CC = DL.CLDIDDELEGA AND CC.COMISIO = DL.CLDIDCOMI)" & vbNewLine & _
            cWHERE & "COMISIO = '" & Text1.Text & "'" & vbNewLine & _
            cORDER & "CC.CONTACTO"
             */
        
        private string _queryContactos = "SELECT {0} ISNULL(NOM_CARGO,CG.NOMBRE) as NOM_CARGO, " +
                                         "cldDelegacion DELEGACC_NOM FROM CONTACTOS_COMI CC"+
                                         "FULL OUTER JOIN";
      
        private bool isChanged = false;
        /// <summary>
        ///  Commission agent for a file.
        /// </summary>
        public CommissionAgent(ISqlQueryExecutor executor)
        {
            _queryExecutor = executor;
        }

        /// <summary>
        /// This load the single value.
        /// <returns>This returns a bool value</returns>
        /// </summary>
        public COMISIO Comission
        {
            set {
                _currentComisio = value;
                RaisePropertyChanged();
            }
            get { return _currentComisio; }
        }
        public async Task<bool> LoadSingleValue(IDictionary<string, string> commissionDictionary, string commissionId)
        {
            string commisionQuery = commissionDictionary["COMISIO"];
            string provinceFields = commissionDictionary["PROVINCIA"];
            string countryFields = commissionDictionary["PAIS"];
            string tipoComiFields = commissionDictionary["TIPOCOMI"];
            string contactosFields = commissionDictionary["CONTACTOS"];

            bool isOpen = _queryExecutor.Open();
            // now between the two
            if (isOpen)
            {
                IDbConnection connection = _queryExecutor.Connection;
                _commissionAgents = await connection.QueryAsync<COMISIO>(commisionQuery);
                _currentComisio = _commissionAgents.First();
                string provinceQuery = string.Format(_queryProvincia, provinceFields, _currentComisio.PROVINCIA);
                _provinces = await connection.QueryAsync<PROVINCIA>(provinceQuery).ConfigureAwait(false);
                string queryTipoComi = string.Format(_queryTipoComi,tipoComiFields,_currentComisio.TIPOCOMI);
                _tipoComis = await connection.QueryAsync<TIPOCOMI>(queryTipoComi).ConfigureAwait(false);
                string queryContactos = string.Format(_queryContactos,contactosFields,_currentComisio.C);
                _nacioPer = await connection.QueryAsync<PAIS>(queryPais);
                _queryExecutor.Close();
            }
            return true;
        }

        public async void FillSingleValue()
        {
            IDbConnection connection = _queryExecutor.Connection;
            if (_queryExecutor.Connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            string queryProvincia = string.Format(_queryProvincia, provinceFields, _currentComisio.PROVINCIA);
            _provinces = await connection.QueryAsync<PROVINCIA>(queryProvincia).ConfigureAwait(false);
            string queryTipoComi = string.Format(_queryTipoComi, _currentComisio.TIPOCOMI);
            _tipoComis = await connection.QueryAsync<TIPOCOMI>(queryTipoComi).ConfigureAwait(false);
            string queryPais = string.Format(_queryContactos, _currentComisio.NACIOPER);
            _nacioPer = await connection.QueryAsync<PAIS>(queryPais);
            _queryExecutor.Close();
        }

    }
}
