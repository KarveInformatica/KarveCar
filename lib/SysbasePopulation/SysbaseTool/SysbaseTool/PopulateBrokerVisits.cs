using System;
using System.Collections.Generic;
using SqlLayer.DataAccessLayer;
using System.Data;
using KarveDapper.Extensions;
using DataAccessLayer.DataObjects;
using iAnywhere.Data.SQLAnywhere;

namespace SysbaseTool
{
    /// <summary>
    ///  PopulateFactory.
    /// </summary>
    public class PopulateFactory
    {
        /// <summary>
        ///  Get an instance of a populate factory.
        /// </summary>
        /// <returns></returns>
        public static PopulateFactory GetInstance()
        {
            return new PopulateFactory();
        }
        /// <summary>
        /// BuildBroker.
        /// </summary>
        /// <returns></returns>
        public IPopulator BuildBrokerVisits()
        {
            var populate = new PopulateBrokerVisits();
            return populate;
        }
    }
    /// <summary>
    ///  PopulateBrokerVisits.
    /// </summary>
    public class PopulateBrokerVisits: IPopulator
    {
        private IDbConnection _connection;
        private string _connectionString = "EngineName=DBRENT_NET16;DataBaseName=DBRENT_NET16;Uid=cv;Pwd=1929;Host=172.26.0.45";
        
        public PopulateBrokerVisits()
        {
            _connection = new SAConnection(_connectionString);
        }  
        // this will populate the visit
        public void Populate()
        {
            _connection.Open();
            IList<VISITAS_COMI> visitList = new List<VISITAS_COMI>()
            {
                new VISITAS_COMI()
                {
                    visIdVisita = "1292",
                    visIdCliente = "8139253",
                    visIdContacto = "91",
                    visFecha = DateTime.Now
                },
                new VISITAS_COMI()
                {
                    visIdVisita = "1292",
                    visIdCliente = "8139253",
                    visIdContacto = "91",
                    visFecha = DateTime.Now
                },
                new VISITAS_COMI()
                {
                    visIdVisita = "1252",
                    visIdCliente = "8139253",
                    visIdContacto = "1252",
                    visAlta = DateTime.Now.AddDays(10),
                    visFecha = DateTime.Now,
                    visTexto = "Connessione"
                },
                new VISITAS_COMI()
                {
                    visIdVisita = "1291",
                    visIdCliente = "8139253",
                    visIdContacto = "114570",
                    visAlta = DateTime.Now.AddDays(10),
                    visFecha = DateTime.Now,
                    visTexto = "Connessione"
                }
               
            };
            var visitas = new VISITAS_COMI();
            var inserted = _connection.Insert<IEnumerable<VISITAS_COMI>>(visitList);
            _connection.Close();
        }
    }
}
