using Dapper;
using DataAccessLayer.Crud;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Exception;
using DataAccessLayer.SQL;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using System;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /*
     *  Code has been generared by the script BookingStructureGenerator.py in CodeGenerator project.
     *  The generator shall keep present that duplicated query type shall be separated generating 
     *  a temp variable.
     */

    internal partial class BookingDataAccessLayer
    {
        private async Task<IBookingData> BuildAux(IBookingData result)
        {
            var auxQueryStore = QueryStoreFactory.GetQueryStore();
            var dto = result.Value;
            #region KarveCode Generator for query multiple single values
            // Code Generated that concatains multiple queries to be executed by QueryMultipleAsync.

            auxQueryStore.AddParamCount(QueryType.QueryAgencyEmployee, dto.EMPLEAGE_RES2);
            auxQueryStore.AddParamCount(QueryType.QueryBookingMedia, dto.MEDIO_RES1);
            auxQueryStore.AddParamCount(QueryType.QueryBookingType, dto.TIPORES_res1);
            auxQueryStore.AddParamCount(QueryType.QueryBudgetSummaryById, dto.PRESUPUESTO_RES1);
            auxQueryStore.AddParamCount(QueryType.QueryCityByName, dto.POCOND_RES2);
            auxQueryStore.AddParamCount(QueryType.QueryClientContacts, dto.CONTACTO_RES2);
            auxQueryStore.AddParamCount(QueryType.QueryCompany, dto.SUBLICEN_RES1);
            auxQueryStore.AddParamCount(QueryType.QueryCommissionAgentSummaryById, dto.COMISIO_RES2);
            auxQueryStore.AddParamCount(QueryType.QueryFares, dto.TARIFA_RES1);
            auxQueryStore.AddParamCount(QueryType.QueryPaymentForm, dto.FCOBRO_RES1);
            auxQueryStore.AddParamCount(QueryType.QueryProvince, dto.PROVCOND_RES2);
            auxQueryStore.AddParamCount(QueryType.QueryPrintingType, dto.CONTRATIPIMPR_RES);
            auxQueryStore.AddParamCount(QueryType.QueryOrigin, dto.ORIGEN_RES2);
            auxQueryStore.AddParamCount(QueryType.QueryVehicleActivity, dto.ACTIVEHI_RES1);
            auxQueryStore.AddParamCount(QueryType.QueryVehicleGroup, dto.GRUPO_RES1);
            auxQueryStore.AddParamCount(QueryType.QueryVehicleSummaryById, dto.VCACT_RES1);
          //  auxQueryStore.AddParamCount(QueryType.QueryLanguage, dto.L)
            #endregion


            #region OfficeQuery

            var officeStore = _queryStoreFactory.GetQueryStore();
            officeStore.AddParamCount(QueryType.QueryOffice, dto.OFICINA_RES1);

            officeStore.AddParamCount(QueryType.QueryOffice, dto.OFISALIDA_RES1);

            officeStore.AddParamCount(QueryType.QueryOffice, dto.OFIRETORNO_RES1);
            #endregion
            #region  ClientQuery
            var clientStore = _queryStoreFactory.GetQueryStore();
            clientStore.AddParamCount(QueryType.QueryClientSummaryExtById, dto.CLIENTE_RES1);
            clientStore.AddParamCount(QueryType.QueryClientSummaryExtById, dto.CONDUCTOR_RES1);
            clientStore.AddParamCount(QueryType.QueryClientSummaryExtById, dto.OTROCOND_RES2);
            clientStore.AddParamCount(QueryType.QueryClientSummaryExtById, dto.OTRO2COND_RES2);
            clientStore.AddParamCount(QueryType.QueryClientSummaryExtById, dto.OTRO3COND_RES2);
            #endregion
            #region CountryQuery
            var countryStore = _queryStoreFactory.GetQueryStore();
            countryStore.AddParamCount(QueryType.QueryCountry, dto.PAISNIFCOND_RES2);
            countryStore.AddParamCount(QueryType.QueryCountry, dto.PAISCOND_RES2);
            #endregion
            #region DeliveryPlaces
            //var deliveryPlaceStore = _queryStoreFactory.GetQueryStore();
           // deliveryPlaceStore.AddParamCount(QueryType.QueryDeliveringBy, dto.LUDEVO_RES1);
           // deliveryPlaceStore.AddParamCount(QueryType.QueryDeliveringBy, dto.LUENTRE_RES1);

            #endregion
            var basicQuery = auxQueryStore.BuildQuery();
            var countryQuery = countryStore.BuildQuery();
            var clientQuery = clientStore.BuildQuery();
            var officeQuery = officeStore.BuildQuery();
            //var deliveryQuery = deliveryPlaceStore.BuildQuery();

            // query comtains everything we need now.
            var query = basicQuery + countryQuery;
            try
            {
                using (var connection = SqlExecutor.OpenNewDbConnection())
                {
                    if (connection != null)
                    {
                        var multipleResult = await connection.QueryMultipleAsync(query).ConfigureAwait(false);
                        result.Valid = ParseResult(result, multipleResult);
                        result.Valid = result.Valid && ParseCountryResult(result, multipleResult);
                        var officeResult = await connection.QueryMultipleAsync(officeQuery).ConfigureAwait(false);
                        result.Valid = result.Valid && ParseOfficeResult(result, officeResult);
                        var clientResult = await connection.QueryMultipleAsync(clientQuery).ConfigureAwait(false);
                        result.Valid = result.Valid && ParseClientResult(result, clientResult);
                       // var countries = await connection.QueryMultipleAsync(countryQuery).ConfigureAwait(false);
                      //  result.Valid = result.Valid && ParseCountryResult(result, clientResult);


                    }
                }
            } catch (System.Exception ex)
            {
                var msg = "Error building aux for booking type " + dto.NUMERO_RES;
                throw new DataAccessLayerException(msg, ex);
            }
            return result;
        }

        private bool ParseCountryResult(IBookingData request, SqlMapper.GridReader reader)
        {
            // null checking as usual.
            if ((request == null) || (reader == null))
            {
                return false;
            }
            if (request.Value == null)
            {
                return false;
            }
            try
            {
                // client queries. Multiple Query are stacked when created so we need to fetch in the reverse order.
                request.CountryDto3 = SelectionHelpers.WrappedSelectedDto<Country, CountryDto>(request.Value.PAISCOND_RES2, _mapper, reader);
                request.DriverCountryList = SelectionHelpers.WrappedSelectedDto<Country, CountryDto>(request.Value.PAISNIFCOND_RES2, _mapper, reader);
            }
            catch (System.Exception ex)
            {
                throw new DataAccessLayerException("Parsing multiple query result error", ex);
            }
            return true;
        }


        private bool ParseClientResult(IBookingData request, SqlMapper.GridReader reader)
        {
            if ((request == null) || (reader == null))
            {
                return false;
            }
            if (request.Value == null)
            {
                return false;
            }
            try
            {
                // client queries. Multiple Query are stacked when created so we need to fetch in the reverse order.
                request.DriverDto5 = SelectionHelpers.WrappedSelectedDto<ClientSummaryExtended, ClientSummaryExtended>(request.Value.OTRO3COND_RES2, _mapper, reader);

                request.DriverDto4 = SelectionHelpers.WrappedSelectedDto<ClientSummaryExtended, ClientSummaryExtended>(request.Value.OTRO2COND_RES2, _mapper, reader);

                request.DriverDto3 = SelectionHelpers.WrappedSelectedDto<ClientSummaryExtended, ClientSummaryExtended>(request.Value.OTROCOND_RES2, _mapper, reader);
              
                request.DriverDto2 = SelectionHelpers.WrappedSelectedDto<ClientSummaryExtended, ClientSummaryExtended>(request.Value.CONDUCTOR_RES1, _mapper, reader);

                request.Clients = SelectionHelpers.WrappedSelectedDto<ClientSummaryExtended, ClientSummaryExtended>(request.Value.CLIENTE_RES1, _mapper, reader);

              


            } catch (System.Exception ex)
            {
                throw new DataAccessLayerException("Parsing multiple query result error", ex);
            }
            return true;
        }
        private bool ParseOfficeResult(IBookingData request, SqlMapper.GridReader reader)
        {
            if ((request == null) || (reader == null))
            {
                return false;
            }
            if (request.Value == null)
            {
                return false;
            }
            try
            {
                // office queries
                request.OfficeDto = SelectionHelpers.WrappedSelectedDto<OFICINAS, OfficeDtos>(request.Value.OFICINA_RES1, _mapper, reader);
                request.ReservationOfficeDeparture = SelectionHelpers.WrappedSelectedDto<OFICINAS, OfficeDtos>(request.Value.OFISALIDA_RES1, _mapper, reader);

                request.ReservationOfficeArrival = SelectionHelpers.WrappedSelectedDto<OFICINAS, OfficeDtos>(request.Value.OFIRETORNO_RES1, _mapper, reader);
            }
            catch (System.Exception ex)
            {
                throw new DataAccessLayerException("Parsing multiple query result error", ex);
            }
            return true;
        }

        private bool ParseResult(IBookingData request, SqlMapper.GridReader reader)
        {

            if ((request == null) || (reader == null))
            {
                return false;
            }
            if (request.Value == null)
            {
                return false;
            }
            try
            {
                request.AgencyEmployeeDto = SelectionHelpers.WrappedSelectedDto<EAGE, AgencyEmployeeDto>(request.Value.EMPLEAGE_RES2, _mapper, reader);

                request.BookingMediaDto = SelectionHelpers.WrappedSelectedDto<MEDIO_RES, BookingMediaDto>(request.Value.MEDIO_RES1, _mapper, reader);

                request.BookingTypeDto = SelectionHelpers.WrappedSelectedDto<TIPOS_RESERVAS, BookingTypeDto>(request.Value.TIPORES_res1, _mapper, reader);


                
                request.BookingBudget = SelectionHelpers.WrappedSelectedDto<BudgetSummaryDto, BudgetSummaryDto>(request.Value.PRESUPUESTO_RES1, _mapper, reader);

                request.BrokerDto = SelectionHelpers.WrappedSelectedDto<CommissionAgentSummaryDto, CommissionAgentSummaryDto>(request.Value.COMISIO_RES2, _mapper, reader);


                request.CityDto3 = SelectionHelpers.WrappedSelectedDto<POBLACIONES, CityDto>(request.Value.POCOND_RES2, _mapper, reader);

                request.ContactsDto1 = SelectionHelpers.WrappedSelectedDto<CliContactos, ContactsDto>(request.Value.CONTACTO_RES2, _mapper, reader);

                request.CompanyDto = SelectionHelpers.WrappedSelectedDto<SUBLICEN, CompanyDto>(request.Value.SUBLICEN_RES1, _mapper, reader);

                

                request.FareDto = SelectionHelpers.WrappedSelectedDto<NTARI, FareDto>(request.Value.TARIFA_RES1, _mapper, reader);

                request.PaymentFormDto = SelectionHelpers.WrappedSelectedDto<FORMAS, PaymentFormDto>(request.Value.FCOBRO_RES1, _mapper, reader);

                request.ProvinceDto3 = SelectionHelpers.WrappedSelectedDto<PROVINCIA, ProvinciaDto>(request.Value.PROVCOND_RES2, _mapper, reader);

                request.PrintingTypeDto = SelectionHelpers.WrappedSelectedDto<CONTRATIPIMPR, PrintingTypeDto>(request.Value.CONTRATIPIMPR_RES, _mapper, reader);

                request.OriginDto = SelectionHelpers.WrappedSelectedDto<ORIGEN, OrigenDto>(request.Value.ORIGEN_RES2,_mapper,reader);

                request.VehicleActivitiesDto = SelectionHelpers.WrappedSelectedDto<ACTIVEHI, VehicleActivitiesDto>(request.Value.ACTIVEHI_RES1, _mapper, reader);

                request.VehicleGroupDto = SelectionHelpers.WrappedSelectedDto<GRUPOS, VehicleGroupDto>(request.Value.GRUPO_RES1, _mapper, reader);

                request.VehicleDto = SelectionHelpers.WrappedSelectedDto<VehicleSummaryDto, VehicleSummaryDto>(request.Value.VCACT_RES1, _mapper, reader);

              
#pragma warning disable CS0168 // Variable is declared but never used
            }
            catch (System.Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                throw new DataAccessLayerException("Parsing multiple query result error", ex);
            }
            return true;
        }

    }
}
