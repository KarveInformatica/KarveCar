using Dapper;
using DataAccessLayer.SQL;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;
using DataAccessLayer.DataObjects;
using AutoMapper;
using DataAccessLayer.Logic;
using DataAccessLayer.Model;

namespace DataAccessLayer.Crud.Vehicle
{


    public class VehicleDataLoader : IDataLoader<IVehicleData>
    {
        private ISqlExecutor _executor;
        private QueryStoreFactory queryStoreFactory = new QueryStoreFactory();
        private IMapper _mapper;

        public VehicleDataLoader(ISqlExecutor executor)
        {
            _executor = executor;
            _mapper = MapperField.GetMapper();
        }
        public Task<IEnumerable<VehicleDto>> LoadAsyncAll()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        ///  Return a vehicle dto.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<IVehicleData> LoadValueAsync(string code)
        {

            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException("Vehicle code cannot be null");
            }
            var vehicle = new Model.Vehicle();
            var queryStore = queryStoreFactory.GetQueryStore();
            using (var connection = _executor.OpenNewDbConnection())
            {
                if (connection != null)
                {
                    var store = queryStore.AddParam(QueryType.QueryVehicleById, code);
                    var resultQuery = await connection.QueryFirstOrDefaultAsync<VehicleDto>(store.BuildQuery()).ConfigureAwait(false);
                    if (resultQuery == null)
                    {
                        throw new DataLayerException("Vehicle to be triggered!");
                    }
                    /// here in value i pass directly the dto for performance reasons. 3 conversions are too much.
                    vehicle.Value = resultQuery;
                   // vehicle.Value = _mapper.Map<VehiclePoco, VehicleDto>(resultQuery);
                    // ok here we have a valid way to do the query now. I need a new query store.

                    var auxQueryStore = queryStoreFactory.GetQueryStore();
                    auxQueryStore.AddParam(QueryType.QueryVehicleModelWithCount, resultQuery.MAR, resultQuery.MO1, resultQuery.MO2);
                    auxQueryStore.AddParamCount(QueryType.QueryBrandByVehicle, resultQuery.MAR, resultQuery.CODIINT);
                    auxQueryStore.AddParam(QueryType.QueryVehiclePhoto, resultQuery.CODIINT);
                    auxQueryStore.AddParamCount(QueryType.QueryVehicleActivity, resultQuery.ACTIVIDAD);
                    auxQueryStore.AddParamCount(QueryType.QueryVehicleOwner, resultQuery.PROPIE);
                    auxQueryStore.AddParamCount(QueryType.QueryAgentByVehicle, resultQuery.AGENTE_VEHI);
                    auxQueryStore.AddParam(QueryType.QueryVehicleMaintenance, resultQuery.CODIINT);
                    auxQueryStore.AddParamCount(QueryType.QueryVehicleColor, resultQuery.COLOR);
                    auxQueryStore.AddParamCount(QueryType.QueryVehicleGroup, resultQuery.GRUPO);
                    auxQueryStore.AddParamCount(QueryType.QueryPaymentForm, SelectionHelpers.ValueString(resultQuery.FORPAGOCO));
                    auxQueryStore.AddParamCount(QueryType.QuerySupplierSummaryById, resultQuery.PROVEEDOR);
                    auxQueryStore.AddParamCount(QueryType.QueryClientSummaryExtById, resultQuery.COMPRADOR);
                    auxQueryStore.AddParamCount(QueryType.QueryReseller, resultQuery.VENDEDOR_VTA);
                    auxQueryStore.AddParamCount(QueryType.QueryCity, resultQuery.POBLA_IMP);
                    auxQueryStore.AddParamCount(QueryType.QueryOfficeZone, resultQuery.ZONA_IMP);
                    try
                    {
                        var query = auxQueryStore.BuildQuery();
                        if (string.IsNullOrEmpty(query))
                        {
                            vehicle.Valid = false;
                            return vehicle;
                        }
                       
                    var multipleResult = await connection.QueryMultipleAsync(query).ConfigureAwait(false);
                        // FIXME: this is due to the fact the querystore doesnt support well yet duplicated keys.
                        var auxDuplicate = queryStoreFactory.GetQueryStore();
                        auxDuplicate.AddParamCount(QueryType.QuerySupplierSummaryById, resultQuery.CIALEAS);
                        auxDuplicate.AddParamCount(QueryType.QuerySupplierSummaryById, resultQuery.CIAADA3);
                        auxDuplicate.AddParamCount(QueryType.QuerySupplierSummaryById, resultQuery.CIAADA);
                        auxDuplicate.AddParamCount(QueryType.QuerySupplierSummaryById, resultQuery.CIAADA2);
                        auxDuplicate.AddParamCount(QueryType.QuerySupplierSummaryById, resultQuery.CIASEGU);
                   //     auxDuplicate.AddParamCount(QueryType.Query, resultQuery.AGENTE);
                        var secondQuery = auxDuplicate.BuildQuery();
                     SqlMapper.GridReader secondResult = null;
                     if (!string.IsNullOrEmpty(secondQuery))
                      {
                       secondResult = await connection.QueryMultipleAsync(secondQuery).ConfigureAwait(false);
                      }
                        // assuarance
                      

                        vehicle.Valid = ParseResult(vehicle, multipleResult, secondResult);
                        
                    }
                    catch (System.Exception ex)
                    {
                        vehicle.Valid = false;
                    }
                       
                }
            }
            return vehicle;
        }

       

        public Task<IEnumerable<IVehicleData>> LoadValueAtMostAsync(int n, int back = 0)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<IVehicleData>> IDataLoader<IVehicleData>.LoadAsyncAll()
        {
            throw new NotImplementedException();
        }

        private bool ParseResult(IVehicleData vehicle, SqlMapper.GridReader reader, SqlMapper.GridReader secondResult)
        {
            try
            {
                vehicle.ModelDtos = SelectionHelpers.WrappedSelectedDto<MODELO, ModelVehicleDto>(vehicle.Value.MODELO, _mapper, reader);
                vehicle.BrandDtos = SelectionHelpers.WrappedSelectedDto<MARCAS, BrandVehicleDto>(vehicle.Value.MAR, _mapper, reader);
                vehicle.PicturesDtos = SelectionHelpers.WrappedSelectedDto<PICTURES, PictureDto>(vehicle, _mapper, reader);
                vehicle.ActivityDtos = SelectionHelpers.WrappedSelectedDto<ACTIVEHI, ActividadDto>(vehicle.Value.ACTIVIDAD, _mapper, reader);
                vehicle.OwnerDtos = SelectionHelpers.WrappedSelectedDto<OwnerDto, OwnerDto>(vehicle.Value.PROPIE, _mapper, reader);
                vehicle.AgentsDto = SelectionHelpers.WrappedSelectedDto<AGENTES, AgentDto>(vehicle.Value.AGENTE_VEHI, _mapper, reader);
                vehicle.MaintenanceHistory = SelectionHelpers.WrappedSelectedDto<MaintainanceDto, MaintainanceDto>(vehicle.Value, _mapper, reader);
                vehicle.ColorDtos = SelectionHelpers.WrappedSelectedDto<COLORFL, ColorDto>(vehicle.Value.COLOR, _mapper, reader);
                vehicle.VehicleGroupDtos = SelectionHelpers.WrappedSelectedDto<GRUPOS, VehicleGroupDto>(vehicle.Value.GRUPO, _mapper, reader);
                vehicle.PaymentForm = SelectionHelpers.WrappedSelectedDto<FORMAS, PaymentFormDto>(vehicle.Value.FORPAGOCO, _mapper, reader);
                vehicle.Supplier1 = SelectionHelpers.WrappedSelectedDto<SupplierSummaryDto,SupplierSummaryDto>(vehicle.Value.PROVEEDOR, _mapper, reader);
                vehicle.ClientDto = SelectionHelpers.WrappedSelectedDto<ClientSummaryExtended, ClientSummaryExtended>(vehicle.Value.COMPRADOR, _mapper, reader);
                vehicle.ResellerDto = SelectionHelpers.WrappedSelectedDto<VENDEDOR, ResellerDto>(vehicle.Value.VENDEDOR_VTA, _mapper, reader);
                vehicle.RoadTaxesCityDto = SelectionHelpers.WrappedSelectedDto<POBLACIONES, CityDto>(vehicle.Value.POBLA_IMP, _mapper, reader);
                vehicle.RoadOfficeZoneDto = SelectionHelpers.WrappedSelectedDto<ZONAOFI, ZonaOfiDto>(vehicle.Value.ZONA_IMP, _mapper, reader);
                vehicle.AssuranceDto = SelectionHelpers.WrappedSelectedDto<SupplierSummaryDto, SupplierSummaryDto>(vehicle.Value.CIASEGU, _mapper, secondResult);
                vehicle.AssistencePolicyDto = SelectionHelpers.WrappedSelectedDto<SupplierSummaryDto, SupplierSummaryDto>(vehicle.Value.CIAADA2, _mapper, secondResult);
                vehicle.AssistenceAssuranceDto = SelectionHelpers.WrappedSelectedDto<SupplierSummaryDto, SupplierSummaryDto>(vehicle.Value.CIAADA, _mapper, secondResult);
                vehicle.AdditionalAssuranceDto = SelectionHelpers.WrappedSelectedDto<SupplierSummaryDto, SupplierSummaryDto>(vehicle.Value.CIAADA3, _mapper, secondResult);
                vehicle.Supplier2 = SelectionHelpers.WrappedSelectedDto<SupplierSummaryDto, SupplierSummaryDto>(vehicle.Value.CIALEAS, _mapper, secondResult);
              //  vehicle.AssuranceAgentDto = SelectionHelpers.WrappedSelectedDto<AGENTES, AgentDto>(vehicle.Value.AGENTE, _mapper, reader);
            }
            catch (System.Exception ex)
            {
                return false;
            }
            return true;
        }
           
        }

           
}
