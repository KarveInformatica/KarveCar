using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Dapper;
using DataAccessLayer.DataObjects;
using DataAccessLayer.DataObjects.Wrapper;
using DesignByContract;
using KarveDapper.Extensions;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using Model;

namespace DataAccessLayer.Model
{

    /// <summary>
    ///  This is the class factory for each vehicle.
    /// </summary>
    public class VehicleFactory
    {
        private const string VehicleIds = " SELECT {0} FROM VEHICULO1 INNER JOIN VEHICULO2 ON VEHICULO1.CODIINT=VEHICULO2.CODIINT";
        private const string VehicleLimitIds = " SELECT TOP {0} START AT {1} {2} FROM VEHICULO1 INNER JOIN VEHICULO2 ON VEHICULO1.CODIINT=VEHICULO2.CODIINT";
        private readonly ISqlExecutor _sqlExecutor;
        /// <summary>
        ///  This is the queryExecutro factory.
        /// </summary>
        /// <param name="executor"></param>
        private VehicleFactory(ISqlExecutor executor)
        {
            _sqlExecutor = executor;
        }
        /// <summary>
        ///  This is the factory for the commission agent. 
        /// </summary>
        /// <param name="executor">Query executor of the things</param>
        /// <returns></returns>
        public static VehicleFactory GetFactory(ISqlExecutor executor)
        {
            return new VehicleFactory(executor);
        }
        /// <summary>
        /// This returns a new vehicle.
        /// </summary>
        /// <returns></returns>
        public IVehicleData NewVehicle(string id)
        {
            IVehicleData data = new Vehicle(_sqlExecutor);
            VehicleDto dto = new VehicleDto();
            dto.CODIINT = id;
            data.Valid = true;
            data.Value = dto;
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
            IDbConnection connection = _sqlExecutor.Connection;
            string currentQueryAgent = "";
            IList<IVehicleData> list = new List<IVehicleData>();
            string vehiclesFields = fields["VEHICULO1"] + "," + fields["VEHICULO2"];
            int i = 0;
            if (maxLimit == 0)
            {
                currentQueryAgent = string.Format(VehicleIds, vehiclesFields);
            }
            else
            {
                currentQueryAgent = string.Format(VehicleLimitIds, maxLimit, offset, vehiclesFields);
            }
            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                IEnumerable<VehiclePoco> vehicleAgents = await connection.QueryAsync<VehiclePoco>(currentQueryAgent);
                foreach (VehiclePoco c in vehicleAgents)
                {

                    Vehicle agent = new Vehicle(_sqlExecutor);
                    bool loaded = await agent.LoadValue(fields, c.CODIINT);
                    if (loaded)
                    {
                        list.Add(agent);
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// This retrieve a commission agent.
        /// </summary>
        /// <param name="fields">Fields to be selected in the db</param>
        /// <param name="commissionId">Commission Id</param>
        /// <returns>A commmission agent data transfer object</returns>
        public async Task<IVehicleData> GetVehicle(IDictionary<string, string> fields, string vehicleId)
        {
            Dbc.Requires(fields.Count > 0, "Fields not valid");
            Dbc.Requires(!string.IsNullOrEmpty(vehicleId), "VehicleId valid");
            Vehicle agent = new Vehicle(_sqlExecutor);
            bool loaded = await agent.LoadValue(fields, vehicleId).ConfigureAwait(false);
            agent.Valid = loaded;
            return agent;
        }


    }

    /// <summary>
    /// This is a domain object that wraps all the pocos for representing the vehicle. It is a model wrapper.
    /// </summary>
    public class Vehicle : DomainObject, IVehicleData
    {
        #region constants
        public const string Brand = "MARCA";
        public const string Vehiculo1 = "VEHICULO1";
        public const string Vehiculo2 = "VEHICULO2";
        public const string Clientes1 = "CLIENTES1";
        public const string Contractos1 = "CONTRATOS1";
        public const string Reservas1 = "RESERVAS1";
        public const string Vendedor = "VENDEDOR1";
        public const string Branches = "BRANCHES";
        public const string Visitas = "VISITAS";
        private const string VehicleQueryFormat = "SELECT VEHICULO1.CODIINT, {0} FROM VEHICULO1 " +
                                                  "INNER JOIN VEHICULO2 ON VEHICULO1.CODIINT=VEHICULO2.CODIINT " +
                                                  "WHERE VEHICULO1.CODIINT='{1}'";

        private const string BrandByVehicle =
            "SELECT CODIGO, NOMBRE FROM MARCAS INNER JOIN VEHICULO1 ON VEHICULO1.MAR=MARCAS.CODIGO " +
            "WHERE VEHICULO1.CODIINT='{0}'";

        private const string ColorByName = "SELECT CODIGO, NOMBRE FROM COLORFL " +
                                           "INNER JOIN VEHICULO1 ON VEHICULO1.COLOR=COLORFL.CODIGO " +
                                           "WHERE VEHICULO1.CODIINT='{0}'";
        private const string PhotoByValue = "select picture,empresa,filename from vehiculo1 inner join pictures on codiint = cod_asociado and empresa = -2 " +
                                            "and filename = rutafoto " +
                                            "where (cod_asociado  is not null) and (codiint='{0}')";

        #endregion

        private bool _isValid = false;
        /// <summary>
        ///  automapper for the fields.
        /// </summary>
        private IMapper _vehicleMapper;
        private readonly ISqlExecutor _sqlExecutor;
        // a vehicle has a marca  
        private VehiclePoco _vehicleValue = new VehiclePoco();
        // data transfer object.

        #region  Data Transfer Object
        private IEnumerable<BrandVehicleDto> _brandDtos;
        private IEnumerable<ModelVehicleDto> _modelDtos;
        private IEnumerable<ColorDto> _colorDtos;
        private IEnumerable<PictureDto> _pictureDtos;
        #endregion

        #region Fields to related data.
        private IEnumerable<PICTURES> _pictures;
        private IEnumerable<MARCAS> _marcas;
        private IEnumerable<MODELO> _modelos;
        private IEnumerable<COLORFL> _colorfl;

        #endregion



        /// <summary>
        /// Vehicle data. 
        /// </summary>
        /// <param name="sqlExecutor">Sql Query Executor</param>

        public Vehicle(ISqlExecutor sqlExecutor)
        {
            _sqlExecutor = sqlExecutor;
            InitializeMapping();
        }
        /// <summary>
        ///  This is the initialize mapping for the vehiculos.
        /// </summary>
        public void InitializeMapping()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VehiclePoco, VehicleDto>();
                cfg.CreateMap<VehicleDto, VehiclePoco>();
                cfg.CreateMap<PICTURES, PictureDto> ();
                cfg.CreateMap<VehiclePoco, VEHICULO1>().ConvertUsing<PocoToVehiculo1>();
                cfg.CreateMap<VehiclePoco, VEHICULO2>().ConvertUsing<PocoToVehiculo2>();
                cfg.CreateMap<BrandVehicleDto, MARCAS>().ConvertUsing(src =>
                {
                    var marcas = new MARCAS();
                    marcas.CODIGO = src.Codigo;
                    marcas.NOMBRE = src.Nombre;
                    return marcas;
                });
                cfg.CreateMap<ColorDto, COLORFL>().ConvertUsing(src =>
                    {
                        var color = new COLORFL();
                        color.CODIGO= src.Codigo;
                        color.NOMBRE = src.Nombre;
                        return color;
                    }
                );
                cfg.CreateMap<ModelVehicleDto, MODELO>().ConvertUsing(src =>
                    {
                        var model = new MODELO();
                        model.CODIGO = src.Codigo;
                        model.NOMBRE = src.Nombre;
                        model.VARIANTE = src.Variante;
                        return model;
                    }
                );

            });
            _vehicleMapper = mapperConfiguration.CreateMapper();

        }
        /// <summary>
        ///  Changed value agent
        /// </summary>
        public bool Changed { set; get; }

        /// <summary>
        ///  Return the vehicle data transfer object 
        /// </summary>
        public VehicleDto Value
        {
            get { return _vehicleMapper.Map<VehiclePoco, VehicleDto>(_vehicleValue); }
            set
            {
                _vehicleValue = _vehicleMapper.Map<VehicleDto, VehiclePoco>(value);
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Return if the vehicle has been loaded in a correct way
        /// </summary>
        public bool Valid
        {
            get { return _isValid; }
            set { _isValid = value; }
        }
        // This data transfer object to be used in the grid when using the lookup.
        public IEnumerable<BrandVehicleDto> BrandDtos { get { return _brandDtos; }  set { _brandDtos = value;  RaisePropertyChanged();} }
        public IEnumerable<ModelVehicleDto> ModelDtos { get { return _modelDtos;  } set { _modelDtos = value; RaisePropertyChanged();} }
        public IEnumerable<ColorDto> ColorDtos { get { return _colorDtos; } set { _colorDtos = value; RaisePropertyChanged(); } }
        public IEnumerable<PictureDto> PictureDtos { get { return _pictureDtos; } set { _pictureDtos = value; RaisePropertyChanged(); } }

       
        /// <summary>
        ///  Delete asynchronous data. For now it doesnt do nothing.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DeleteAsyncData()
        {
            await Task.Delay(1);
            return true;
        }

        /// <summary>
        ///  Save asynchronous data
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Save()
        {
            VEHICULO1 vehiculo1 = _vehicleMapper.Map<VehiclePoco, VEHICULO1>(_vehicleValue);
            VEHICULO2 vehiculo2 = _vehicleMapper.Map<VehiclePoco, VEHICULO2>(_vehicleValue);
            vehiculo2.CODIINT = vehiculo1.CODIINT;
            Dbc.Requires(vehiculo1.CODIINT != null, "Null PrimaryKey before Saving");
            Dbc.Requires(vehiculo2.CODIINT != null, "Null PrimaryKey before Saving");


            bool retValue = false;
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {

                using (TransactionScope transactionScope =
                new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                
                    try
                    {
                        int ret = await connection.InsertAsync(vehiculo1);
                        retValue = ret == 0 ;
                        ret = await connection.InsertAsync(vehiculo2);
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

        /// <summary>
        ///  This method save the vehicle. Throws a DataLayerExecution exception in case the tr
        /// </summary>
        /// <returns>Returns true if we have saved the changes.</returns>
        public async Task<bool> SaveChanges()
        {
            VEHICULO1 vehiculo1 = _vehicleMapper.Map<VehiclePoco, VEHICULO1>(_vehicleValue);
            VEHICULO2 vehiculo2 = _vehicleMapper.Map<VehiclePoco, VEHICULO2>(_vehicleValue);
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
                            retValue = await connection.UpdateAsync(vehiculo1);
                            retValue = retValue && await connection.UpdateAsync(vehiculo2);
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
            catch (System.Exception other2)
            {
                return false;
            }
            return retValue;
        }

        /// <summary>
        /// This load asynchronously a vehicle.
        /// </summary>
        /// <param name="fields">Fields to be loaded.</param>
        /// <param name="codeVehicle">Vehicle code to be loaded.</param>
        /// <returns></returns>
        public async Task<bool> LoadValue(IDictionary<string, string> fields, string codeVehicle)
        {
            Dbc.Requires(!string.IsNullOrEmpty(fields["VEHICULO1"]));
            Dbc.Requires(!string.IsNullOrEmpty(fields["VEHICULO2"]));

            string fieldsValue = fields["VEHICULO1"] + "," + fields["VEHICULO2"];
            string vehicleQuery = string.Format(VehicleQueryFormat, fieldsValue, codeVehicle);
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                try
                {
                    var queryResult = await connection.QueryAsync<VehiclePoco>(vehicleQuery);
                    _vehicleValue = queryResult.FirstOrDefault(c => c.CODIINT == codeVehicle);
                    if (_vehicleValue == null)
                    {
                        return false;
                    }
                    // now we look for aux tables.
                    var query = string.Format(BrandByVehicle, _vehicleValue.CODIINT);
                    var brand = await connection.QueryAsync<MARCAS>(query);
                    BrandDtos = Mapper.Map <IEnumerable<MARCAS>, IEnumerable<BrandVehicleDto>>(brand);
                    var queryPicture = string.Format(PhotoByValue, _vehicleValue.CODIINT);
                    var pictureResult = await connection.QueryAsync<PICTURES>(queryPicture);
                    PictureDtos = Mapper.Map<IEnumerable<PICTURES>, IEnumerable<PictureDto>>(pictureResult);
                    Valid =true;
                }
                catch (System.Exception e)
                {
                    string message = "Vehicle Loading error: " +e.Message;
                    throw new DataLayerExecutionException(message);
                }
            }
            return true;
        }
        /// <summary>
        ///  Converter for the the new vehiculo2.
        /// </summary>
        private class PocoToVehiculo2 : ITypeConverter<VehiclePoco, VEHICULO2>
        {
            public VEHICULO2 Convert(VehiclePoco source, VEHICULO2 destination, ResolutionContext context)
            {
                VEHICULO2 vehiculo2 = new VEHICULO2();
                vehiculo2.CODIINT = source.CODIINT;
                
                PropertyInfo[] currentProperties = vehiculo2.GetType().GetProperties();
                foreach (PropertyInfo property in currentProperties)
                {
                    var value = source.GetType().GetProperty(property.Name).GetValue(source);
                    vehiculo2.GetType().GetProperty(property.Name).SetValue(vehiculo2, value);
                }
                return vehiculo2;
            }
        }
        /// <summary>
        /// Convert to the new vehiculo1.
        /// </summary>
        private class PocoToVehiculo1 : ITypeConverter<VehiclePoco, VEHICULO1>
        {
            public VEHICULO1 Convert(VehiclePoco source, VEHICULO1 destination, ResolutionContext context)
            {
                VEHICULO1 vehiculo = new VEHICULO1();
                vehiculo.CODIINT = source.CODIINT;
                Type vehiculoSourceType = source.GetType();
                PropertyInfo[] currentProperties = vehiculo.GetType().GetProperties();
                for (int i = 0; i < currentProperties.Length; ++i)
                {
                    // destination property
                    var prop = currentProperties[i];
                    // source Value
                    var sourceValueProperty = vehiculoSourceType.GetProperty(prop.Name);
                    if (sourceValueProperty!=null)
                    {
                        var destinationProperty = vehiculo.GetType().GetProperty(prop.Name);
                        destinationProperty?.SetValue(vehiculo,sourceValueProperty.GetValue(source));
                    }    
                }
                return vehiculo;
            }
        }
    }


}
