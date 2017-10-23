using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using System.Data;
using System.Runtime.CompilerServices;
using Dapper;
using KarveDapper.Extensions;


namespace DataAccessLayer.DataObjects.Wrapper
{
    /// <summary>
    ///  This is the class factory for each vehicle.
    /// </summary>
    public class VehicleFactory
    {
        private const string VehicleIds = "SELECT {0} NUM_COMI FROM VEHICULO1";
        private const string VehicleLimitIds = " SELECT TOP {0} START AT {1} {2} FROM VEHICULO1";
        private readonly ISqlQueryExecutor _sqlQueryExecutor;
        /// <summary>
        ///  This is the queryExecutro factory.
        /// </summary>
        /// <param name="queryExecutor"></param>
        private VehicleFactory(ISqlQueryExecutor queryExecutor)
        {
            _sqlQueryExecutor = queryExecutor;
        }
        /// <summary>
        ///  This is the factory for the commission agent. 
        /// </summary>
        /// <param name="queryExecutor">Query executor of the things</param>
        /// <returns></returns>
        public static VehicleFactory GetFactory(ISqlQueryExecutor queryExecutor)
        {
            return new VehicleFactory(queryExecutor);
        }
        /// <summary>
        /// This returns a new vehicle.
        /// </summary>
        /// <returns></returns>
        public IVehicleData NewVehicle()
        {
            IVehicleData data = new Vehicle(_sqlQueryExecutor);
            return data;
        }

        /// <summary>
        /// Create a list of vehicles
        /// </summary>
        /// <param name="fields">Fields to be fetched</param>
        /// <param name="maxLimit">Limit maximum of the agents to be fetched. Zero all fields</param>
        /// <param name="offset">Starting offset from which we can fetch</param>
        /// <returns></returns>
        public async Task<IList<IVehicleData>> CreateVehicleList(
            IDictionary<string, string> fields, int maxLimit = 0, int offset = 0)
        {
            IDbConnection connection = _sqlQueryExecutor.Connection;
            string currentQueryAgent = "";
            IList<IVehicleData> list = new List<IVehicleData>();
            int i = 0;
            if (maxLimit == 0)
            {
                currentQueryAgent = string.Format(VehicleIds, fields["VEHICLE"]);
            }
            else
            {
                currentQueryAgent = string.Format(VehicleLimitIds, maxLimit, offset, fields["VEHICLE"]);
            }
            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                IEnumerable<VEHICULO1> vehicleAgents = await connection.QueryAsync<VEHICULO1>(currentQueryAgent);
                foreach (VEHICULO1 c in vehicleAgents)
                {

                    Vehicle agent = new Vehicle(_sqlQueryExecutor);
                    bool loaded = await agent.LoadValue(fields, c.CODIINT);
                    if (loaded)
                    {
                        list.Add(agent);
                    }
                }
            }
            return list;
        }

    }
    /// <summary>
    /// 
    /// </summary>
    public class Vehicle: IVehicleData
    {
        private ISqlQueryExecutor _sqlQueryExecutor;
        private IEnumerable<VEHICULO1> _vehiculo1;
        private IEnumerable<VEHICULO2> _vehiculo2;
        private MARCAS _vehiculosMarcas;
        private CLIENTES1 _clientes1;
        private CONTRATOS1 _contratos1;
        private RESERVAS1 _reservas1;
        private VENDEDOR _vendedor;
        private AGENTES _agentes;
        private COLORFL _colorfl;
        private MODELO _modelo;
        /// <summary>
        /// Vehicles1
        /// </summary>
        private VEHICULO1 _currentVehiculo1;
        /// <summary>
        /// Vehicles2
        /// </summary>
        private VEHICULO2 _currentVehiculo2;

        public const string Brand = "MARCA";
        public const string Vehiculo1 = "VEHICULO1";
        public const string Vehiculo2 = "VEHICULO2";
        public const string Clientes1 = "CLIENTES1";
        public const string Contractos1 = "CONTRATOS1";
        public const string Reservas1 = "RESERVAS1";
        public const string Vendedor = "VENDEDOR1";
        public const string Branches = "BRANCHES";
        public const string Visitas = "VISITAS";
        private const string _queryMarcas = "SELECT * FROM MARCAS WHERE CODIGO='{1}'";
        private const string _queryClientes = "SELECT {0} FROM CLIENTES1 NUMERO_CLI='{1}";
        private const string _queryVehiculo1 = "SELECT {0} FROM VEHICULO1 NUMERO_CLI='{1}";
        private bool isChanged;
        private object v;


        /// <summary>
        /// Vehicle data. 
        /// </summary>
        /// <param name="sqlQueryExecutor">Sql Query Executor</param>

        public Vehicle(ISqlQueryExecutor sqlQueryExecutor)
        {
            _sqlQueryExecutor = sqlQueryExecutor;
            _vehiculo1 = new List<VEHICULO1>();
            _vehiculo2 = new List<VEHICULO2>();
            _vehiculosMarcas = new MARCAS();
            _clientes1 = new CLIENTES1();
            _contratos1 = new CONTRATOS1();
            _reservas1 = new RESERVAS1();
            _vendedor = new VENDEDOR();
            _agentes = new AGENTES();
            _colorfl = new COLORFL();
            _modelo = new MODELO();
        }
        /// <summary>
        ///  Changed value agent
        /// </summary>
        public bool Changed
        {
            set { isChanged = value; }
            get { return isChanged; }
        }

/*
        /// <summary>
        /// This load the single value.
        /// <returns>This returns a bool value</returns>
        /// </summary>
        public object Vehicle
        {
            
            set
            {
                object v = value;
               
            
            }
            get { return v; }
        }
        /// <summary>
        /// Delete an asynchronous data.
        /// </summary>
        /// <returns></returns>
        public Task<bool> DeleteAsyncData()
        {
            
        }
        /// <summary>
        /// Save the task.
        /// </summary>
        /// <returns></returns>
        public Task<bool> Save()
        {
            return true;
        }
        /// <summary>
        /// Save Cha
        /// </summary>
        /// <returns></returns>
        public Task<bool> SaveChanges()
        {
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="cCodiint"></param>
        /// <returns></returns>
        public async Task<bool> LoadValue(IDictionary<string, string> fields, string cCodiint)
        {

            bool isOpen = _sqlQueryExecutor.Open();
            string vehicleData1 = fields[Vehiculo1];
            string vehicleData2 = fields[Vehiculo2];
            string brandData = fields[Brand];
            

            if (isOpen)
            {
                try
                {
                    IDbConnection connection = _sqlQueryExecutor.Connection;
                    _vehiculo1 = await connection.QueryAsync<VEHICULO1>(vehicleData1);
                    _vehiculo2 = await connection.QueryAsync<VEHICULO2>(vehicleData2);
                    IEnumerable<MARCAS> marcas = await connection.QueryAsync<MARCAS>(brandData);
                }
                catch (System.Exception e)
                {

                }
            }
        }
        */
        public Task<bool> DeleteAsyncData()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<bool> LoadValue(IDictionary<string, string> fields, string cCodiint)
        {
            throw new NotImplementedException();
        }
    }
}
