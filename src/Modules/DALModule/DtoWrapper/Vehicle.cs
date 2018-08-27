﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Vehicle.cs" company="Karve Informatica S.L">
//   
// </copyright>
// <summary>
//   Object that wraps all data for the vehicle.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataAccessLayer.DtoWrapper
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using System.Transactions;

    using AutoMapper;

    using Dapper;

    using DataAccessLayer.DataObjects;
    using DataAccessLayer.DataObjects.Wrapper;
    using DataAccessLayer.Logic;
    using DataAccessLayer.SQL;

    using KarveDapper.Extensions;

    using KarveDataServices;
    using KarveDataServices.DataObjects;
    using KarveDataServices.ViewObjects;

    using Model;

    using NLog;

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

        private const string QueryModels =
            "SELECT MARCA, CODIGO, VARIANTE, NOMBRE, NOMMARCA, CATEGORIA FROM MODELO WHERE CODIGO='{0}'";

        private const string QueryModel = "SELECT * FROM MODELO";
        private const string BrandByVehicle =
            "SELECT CODIGO, NOMBRE FROM MARCAS INNER JOIN VEHICULO1 ON VEHICULO1.MAR=MARCAS.CODIGO " +
            "WHERE VEHICULO1.CODIINT='{0}'";

        private const string ColorByName = "SELECT CODIGO, NOMBRE FROM COLORFL " +
                                           "INNER JOIN VEHICULO1 ON VEHICULO1.COLOR=COLORFL.CODIGO " +
                                           "WHERE VEHICULO1.CODIINT='{0}'";

        private const string PhotoByValue =
            "select picture,empresa,filename from vehiculo1 inner join pictures on codiint = cod_asociado and empresa = -2 " +
            "and filename = rutafoto " +
            "where (cod_asociado  is not null) and (codiint='{0}')";

        private const string ActividadByVehicle = "select NUM_ACTIVEHI, nombre from ACTIVEHI where NUM_ACTIVEHI='{0}'";

        private const string OwnersByVehicle = "select NUM_PROPIE as Code, " +
                                               "NOMBRE as Nombre, DIRECCION as Direccion, POBLACION as Poblacion, " +
                                               "PROPIE.CP as CP, PROVINCIA.PROV as Provincia, " +
                                               "NIF, TELEFONO as Telefono, FAX as Fax, EMAIL as Email from PROPIE " +
                                               "INNER JOIN PROVINCIA ON PROPIE.PROVINCIA = PROVINCIA.SIGLAS WHERE NUM_PROPIE='{0}'"
            ;

        private const string AgentByVehicule = "select NUM_AG as Code, " +
                                               "NOMBRE as Nombre, DIRECCION as Direccion, POBLACION as Poblacion, " +
                                               "AGENTES.CP as CP, PROVINCIA.PROV as Provincia, " +
                                               "NIF, TELEFONO as Telefono, FAX as Fax, EMAIL as Email from AGENTES " +
                                               "INNER JOIN PROVINCIA ON AGENTES.PROVINCIA = PROVINCIA.SIGLAS WHERE NUM_AG='{0}'"
            ;

        private const string MaintenanceQuery = "select CODIGO_MAN as MaintananceCode," +
                                                " NOMBRE_MAN as MaintananceName, " +
                                                "ULT_FEC_MV as LastMaintenenceDate, " +
                                                "ULT_KM_MV as  LastMaintananceKMs, " +
                                                "PROX_FEC_MV as NextMaintenenceDate, " +
                                                "PROX_KM_MV as  NextMaintananceKMs, " +
                                                "OBSERVACIONES_MAN as Observation " +
                                                "from MANTENIMIENTO_VEHICULO " +
                                                "LEFT OUTER JOIN MANTENIMIENTO m ON CODIGO_MAN = CODIGO_MANT_MV " +
                                                "WHERE CODIGO_VEHI_MV='{0}' AND FBAJA_MV iS NULL OR FBAJA_MV >=GETDATE(*)"
            ;

      
        #endregion

        /// <summary>
        ///  automapper for the fields.
        /// </summary>
        private IMapper _vehicleMapper;

        private readonly ISqlExecutor _sqlExecutor;

        // a vehicle has a marca  
        private VehiclePoco _vehicleValue = new VehiclePoco();
        // data transfer object.

        #region  Data Transfer Object

        private IEnumerable<BrandVehicleViewObject> _brandDtos = new ObservableCollection<BrandVehicleViewObject>();
        private IEnumerable<ModelVehicleViewObject> _modelDtos = new ObservableCollection<ModelVehicleViewObject>();
        private IEnumerable<ColorViewObject> _colorDtos = new ObservableCollection<ColorViewObject>();
        private IEnumerable<PictureDto> _pictureDtos = new ObservableCollection<PictureDto>();

        #endregion

        #region Fields to related data.

        private IEnumerable<PICTURES> _pictures = new ObservableCollection<PICTURES>();
        private IEnumerable<MARCAS> _marcas = new ObservableCollection<MARCAS>();
        private IEnumerable<MODELO> _modelos = new ObservableCollection<MODELO>();
        private IEnumerable<COLORFL> _colorfl = new ObservableCollection<COLORFL>();
        private IEnumerable<VehicleGroupViewObject> _vehicleGroupDtos = new ObservableCollection<VehicleGroupViewObject>();
        private IEnumerable<ActividadViewObject> _actividadDtos = new ObservableCollection<ActividadViewObject>();
        private IEnumerable<OwnerViewObject> _ownerDtos = new ObservableCollection<OwnerViewObject>();
        private IEnumerable<AgentViewObject> _agentDtos = new ObservableCollection<AgentViewObject>();

        private string _assistQueryOwner;
        private string _agentQuery;
        private IEnumerable<MaintainanceViewObject> _maintenanceDto = new ObservableCollection<MaintainanceViewObject>();
        private PictureDto _pictureDto = new PictureDto();
        private IEnumerable<PICTURES> _pictureResult;
        private Logger _logger = LogManager.GetCurrentClassLogger();
        private static QueryStoreFactory _queryStoreFactory = new QueryStoreFactory();
        private VehicleViewObject _vehicleDto;
        


        #endregion

        /// <summary>
        /// Vehicle data. 
        /// </summary>
        /// <param name="sqlExecutor">Sql Query Executor</param>

        public Vehicle()
        {
            _vehicleMapper = MapperField.GetMapper();
        }
        
        public string VehicleModelQuery {
            get
            {
                return QueryModel;
            }
        }
        
        /// <summary>
        ///  Return the vehicle data transfer object 
        /// </summary>
        public VehicleViewObject Value
        {
            get { return _vehicleDto; }
            set
            {
                _vehicleDto = value;
                //_vehicleValue = _vehicleMapper.Map<VehicleDto, VehiclePoco>(value);
                RaisePropertyChanged();
            }
        }
       
        // This data transfer object to be used in the grid when using the lookup.
        public IEnumerable<BrandVehicleViewObject> BrandDtos { get { return _brandDtos; }  set { _brandDtos = value;  RaisePropertyChanged();} }
        /// <summary>
        ///  Model Dto
        /// </summary>
        public IEnumerable<ModelVehicleViewObject> ModelDtos { get { return _modelDtos;  } set { _modelDtos = value; RaisePropertyChanged();} }
        // each vehicle has a model.
        public IEnumerable<ColorViewObject> ColorDtos { get { return _colorDtos; } set { _colorDtos = value; RaisePropertyChanged(); } }
        public IEnumerable<PictureDto> PictureDtos { get { return _pictureDtos; } set { _pictureDtos = value; RaisePropertyChanged(); } }
        public IEnumerable<ActividadViewObject> ActividadDtos {  get { return _actividadDtos; } set { _actividadDtos = value; RaisePropertyChanged(); } }
        public IEnumerable<OwnerViewObject> OwnerDtos { get { return _ownerDtos; } set { _ownerDtos = value; RaisePropertyChanged(); } }
        public IEnumerable<AgentViewObject> AgentDtos { get { return _agentDtos; } set { _agentDtos = value; RaisePropertyChanged(); } }
        // List of the mantainance.  This is a property of the domain model.
        public IEnumerable<MaintainanceViewObject> MaintenanceDtos {  get { return _maintenanceDto; }
                                                               set { _maintenanceDto= value;  RaisePropertyChanged(); }
        }
        /// <summary>
        ///  Dto for the vehiclegroup.
        /// </summary>
        public IEnumerable<VehicleGroupViewObject> VehicleGroupDtos
        {
            get { return _vehicleGroupDtos; }
            set { _vehicleGroupDtos = value;
                RaisePropertyChanged();}
        }

        public IEnumerable<MaintainanceViewObject> MaintenanceHistory { get; set; }


        /// <summary>
        ///  Delete asynchronous data. For now it doesnt do nothing.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DeleteAsyncData()
        {
            bool retValue = true;
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                using (TransactionScope transactionScope =
                    new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        // delete all pictures.
                        PICTURES pic = _pictureResult.FirstOrDefault();
                        if (pic != null)
                        {
                            retValue = await connection.DeleteAsync<PICTURES>(pic);
                        }
                        VEHICULO1 vehiculo1 = _vehicleMapper.Map<VehiclePoco, VEHICULO1>(_vehicleValue);
                        VEHICULO2 vehiculo2 = _vehicleMapper.Map<VehiclePoco, VEHICULO2>(_vehicleValue);
                        retValue = await connection.DeleteAsync<VEHICULO1>(vehiculo1);
                        if (retValue)
                        {
                            retValue = await connection.DeleteAsync<VEHICULO2>(vehiculo2);
                        }
                        transactionScope.Complete();
                    }
                    catch (System.Exception e)
                    {
                        _logger.Log(LogLevel.Error, "Delete error in the Vehicle module" + e.Message);
                        return false;
                    }
                }
            }
            return retValue;
        }
        /// <summary>
        ///  This returns an assist query.
        /// </summary>
        public string AssistQueryOwner
        {
            get { return _assistQueryOwner; }
            private set { _assistQueryOwner = value; }
        }

        /// <summary>
        ///  Save asynchronous data
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Save()
        {
            var vehicleDto = Value;
            _vehicleValue = _vehicleMapper.Map<VehicleViewObject, VehiclePoco>(vehicleDto);
            VEHICULO1 vehiculo1 = _vehicleMapper.Map<VehiclePoco, VEHICULO1>(_vehicleValue);
            VEHICULO2 vehiculo2 = _vehicleMapper.Map<VehiclePoco, VEHICULO2>(_vehicleValue);
            vehiculo2.CODIINT = vehiculo1.CODIINT;
            Contract.Requires(vehiculo1.CODIINT != null, "Null PrimaryKey before Saving");
            Contract.Requires(vehiculo2.CODIINT != null, "Null PrimaryKey before Saving");
            bool retValue = false;
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {

                using (TransactionScope transactionScope =
                new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                
                    try
                    {
                        int ret = await connection.InsertAsync(vehiculo1);
                        retValue = ret > 0 ;
                        ret = await connection.InsertAsync(vehiculo2);
                        transactionScope.Complete();
                        retValue = retValue && (ret > 0);
                    }
                    catch (TransactionException ex)
                    {
                        // this is  an antipattern for exception handling.
                        string message = "Transaction Scope Exception in Vehicle Insertion. Reason: " + ex.Message;
                        _logger.Log(LogLevel.Error,message);
                       DataLayerExecutionException dataLayer = new DataLayerExecutionException(message);
                        throw dataLayer;
                    }
                    catch (System.Exception other)
                    {
                        string message = "Error in a Vehicle Insertion. Reason: " + other.Message;
                        _logger.Log(LogLevel.Error, message);
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
                            string message = "Save Exception in Vehicle Update. Reason: " + other.Message;
                            DataLayerExecutionException dataLayer = new DataLayerExecutionException(message, other);
                            throw dataLayer;
                        }
                    }
                }
            }
            catch (System.Exception other2)
            {
                string message = "Connection Exception in Vehicle Update. Reason: " + other2.Message;
                DataLayerExecutionException dataLayer = new DataLayerExecutionException(message, other2);
                throw dataLayer;
            }
            return retValue;
        }
        /// <summary>
        ///  Picture of the vehicle.
        /// </summary>
        public PictureDto Picture
        {
            get { return _pictureDto; }
            set { _pictureDto = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// This load asynchronously a vehicle.
        /// </summary>
        /// <param name="fields">Fields to be loaded.</param>
        /// <param name="codeVehicle">Vehicle code to be loaded.</param>
        /// <returns></returns>
        public async Task<bool> LoadValue(IDictionary<string, string> fields, string codeVehicle)
        {
            Stopwatch stopwatch= new Stopwatch();
            stopwatch.Start();
            
            Contract.Requires(!string.IsNullOrEmpty(fields["VEHICULO1"]));
            Contract.Requires(!string.IsNullOrEmpty(fields["VEHICULO2"]));
            Contract.Requires(_vehicleMapper != null);
            QueryStoreFactory storeFactory= new QueryStoreFactory();
            IQueryStore store = storeFactory.GetQueryStore();
            store.AddParam(QueryType.QueryVehicle, codeVehicle);
            string vehicleQuery = store.BuildQuery();
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

                    /*
                     *  See if for the lookup tables. we shall try to use multiple query,
                     */
                   
                    var query = string.Format(BrandByVehicle, _vehicleValue.CODIINT);
                    var brand = await connection.QueryAsync<MARCAS>(query);
                    BrandDtos = _vehicleMapper.Map <IEnumerable<MARCAS>, IEnumerable<BrandVehicleViewObject>>(brand);
                    var queryPicture = string.Format(PhotoByValue, _vehicleValue.CODIINT);
                     _pictureResult = await connection.QueryAsync<PICTURES>(queryPicture);
                    PictureDtos = _vehicleMapper.Map<IEnumerable<PICTURES>, IEnumerable<PictureDto>>(_pictureResult);
                    var queryActivi = string.Format(ActividadByVehicle, _vehicleValue.ACTIVIDAD);
                    var actividad = await connection.QueryAsync<ACTIVEHI>(queryActivi);
                    ActividadDtos = _vehicleMapper.Map<IEnumerable<ACTIVEHI>, IEnumerable<ActividadViewObject>>(actividad);
                    // this is the owner. Just in this case i sue the dto.
                    string queryOwner = string.Format(OwnersByVehicle, _vehicleValue.PROPIE);
                    AssistQueryOwner = queryOwner;
                    OwnerDtos = await connection.QueryAsync<OwnerViewObject>(queryOwner);
                    VehicleAgentQuery = string.Format(AgentByVehicule, _vehicleValue.AGENTE);
                    AgentDtos = await connection.QueryAsync<AgentViewObject>(VehicleAgentQuery);
                    var maintananceQuery = string.Format(MaintenanceQuery, _vehicleValue.CODIINT);
                    MaintenanceDtos = await connection.QueryAsync<MaintainanceViewObject>(maintananceQuery);
                    var queryVehicle = CraftModelQuery(_vehicleValue);
                    var colors = CraftColorQuery(_vehicleValue.COLOR);
                    var cl = await connection.QueryAsync<COLORFL>(colors);
                    ColorDtos = _vehicleMapper.Map<IEnumerable<COLORFL>, IEnumerable<ColorViewObject>>(cl);
                    var models = await connection.QueryAsync<MODELO>(queryVehicle);
                    var q = CraftVehicleGroup(_vehicleValue);
                    var grupos = await connection.QueryAsync<GRUPOS>(q);
                    VehicleGroupDtos=_vehicleMapper.Map<IEnumerable<GRUPOS>, IEnumerable<VehicleGroupViewObject>>(grupos);
                    ModelDtos = _vehicleMapper.Map<IEnumerable<MODELO>, IEnumerable<ModelVehicleViewObject>>(models);
                    Valid =true;
                }
                catch (System.Exception e)
                {
                    string message = "Vehicle Loading error: " +e.Message;
                    throw new DataLayerExecutionException(message);
                }
            }
            stopwatch.Stop();
            // around 100 ms/ 90 ms just to load the vehicle.
            long value = stopwatch.ElapsedMilliseconds;
            return true;
        }

        
        /// <summary>
        ///  TODO: move to the query store.
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        private static string CraftModelQuery(VehiclePoco poco)
        {
            var query =
                $"SELECT * FROM MODELO WHERE MARCA='{poco.MAR}' AND CODIGO='{poco.MO1}' AND VARIANTE='{poco.MO2}'";
            return query;
        }

        private static string CraftVehicleGroup(VehiclePoco poco)
        {
            var query = $"SELECT * from GRUPOS WHERE CODIGO='{poco.GRUPO}'";
            return query;
        }

        private static string CraftColorQuery(string id)
        {
            var store = new QueryStoreFactory();
            var newStore = store.GetQueryStore();
            newStore.AddParam(QueryType.QueryVehicleColor, id);
            return newStore.BuildQuery();
        }
        public string VehicleAgentQuery {
            get { return _agentQuery; }
            set { _agentQuery = value;  RaisePropertyChanged();}
        }

        public string AssistModelQuery
        {
            get { return QueryModel; }
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
        /// Convert to the new vehiculo1. TODO: remove an use the generic version.
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

        public IEnumerable<AgentViewObject> AgentsDto { get; set; }
        public IEnumerable<VehicleActivitiesViewObject> ActivityDtos { get; set; }
        public IEnumerable<PictureDto> PicturesDtos { get; set; }
        public IEnumerable<SupplierSummaryViewObject> Supplier2 { get; set; }
        public IEnumerable<PaymentFormViewObject> PaymentForm { get; set; }
        public IEnumerable<SupplierSummaryViewObject> Supplier1 { get; set; }
        public IEnumerable<ClientSummaryExtended> ClientDto { get; set; }
        public IEnumerable<ResellerViewObject> ResellerDto { get; set; }
        public IEnumerable<CityViewObject> RoadTaxesCityDto { get; set; }
        public IEnumerable<ZonaOfiViewObject> RoadOfficeZoneDto { get; set; }
        public IEnumerable<SupplierSummaryViewObject> AssistencePolicyDto { get ; set ; }
        public IEnumerable<SupplierSummaryViewObject> AssistenceAssuranceDto { get ; set; }
        public IEnumerable<SupplierSummaryViewObject> AdditionalAssuranceDto { get ; set ; }
        public IEnumerable<SupplierSummaryViewObject> AssuranceDto { get ; set ; }
        public IEnumerable<AgentViewObject> AssuranceAgentDto { get; set; }
    }

}
