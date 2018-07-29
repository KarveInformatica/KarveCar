#!/usr/bin/env python
import os
import dalgenerator.dal
from dalgenerator.modeldata import *
from util.meta import *
"""
  var builder = new GeneralInfoCollectionBuilder(AssistCommand, CreateCommand, ItemChangedCommand);
            builder.Add(KarveLocale.Properties.Resources.StringConstants_Origen,"ORIGEN_RES", "BOOKING_ORIGIN_ASSIST", "BOOKING_ORIGIN_CREATE");
            builder[0].SourceView = BookingOrigen;
            
            builder.Add(KarveLocale.Properties.Resources.lbookingmedia, "MEDIO_RES", "BOOKING_MEDIO_ASSIST", "BOOKING_MEDIO_CREATE");
            builder[1].SourceView = BookingMedia;
            builder.Add(KarveLocale.Properties.Resources.lbookingtype, "TIPORES_RES1", "BOOKING_TYPE_ASSIST", "BOOKING_TYPE_CREATE");
            builder[2].SourceView = BookingType;
            builder.Add(KarveLocale.Properties.Resources.lagencyemployee,"EMPLEAGE_RES2", "EMPLEAGE_ASSIST", "EMPLEAGE_CREATE");
            builder[3].SourceView = BookingAgencyEmployee;
            builder.Add(KarveLocale.Properties.Resources.lcontacto,"CONTACTO_RES2", "BOOKING_CONTACTO_ASSIST", "BOOKING_CONTACTO_CREATE");
            builder[4].SourceView = BookingContacts;
            builder.Add(KarveLocale.Properties.Resources.lformadecobro,"FCOBRO_RES1", "BOOKING_FCOBRO_ASSIST", "BOOKING_FCOBRO_CREATE");
            builder[5].SourceView = BookingPaymentFormDto;
            builder.Add(KarveLocale.Properties.Resources.lprintingtype,"CONTRATIPIMPR_RES", "BOOKING_CONTRATIPIMPR_ASSIST", "BOOKING_CONTRATIPIMPR_CREATE");
            builder[6].SourceView = PrintingTypeDto;
            builder.Add(KarveLocale.Properties.Resources.lrbtnActividadesVehiculos, "ACTIVEHI_RES1", "BOOKING_ACTIVEHI_RES1_ASSIST", "BOOKING_ACTIVEHI_RES1_CREATE");
            builder[7].SourceView = BookingVehicleActivity;
            return builder.AsObservable();
"""
class BookingDalGenerator(object):
    def __init__(self):
        self.__auxQuery = [{'type': 'QueryType.QueryOffice', 'param': 'dto.OFICINA_RES1'},
                    {'type': 'QueryType.QueryOffice', 'param': 'dto.OFISALIDA_RES1'},
                    {'type': 'QueryType.QueryOffice', 'param': 'dto.OFIRETORNO_RES1'},
                    {'type': 'QueryType.QueryBudget', 'param': 'dto.PRESUPUESTO_RES1'},
                    {'type': 'QueryType.QueryFares', 'param': 'dto.TARIFA_RES1'},
                    {'type': 'QueryType.QueryGroup', 'param': 'dto.GRUPO_RES1'},
                    {'type': 'QueryType.QueryBroker', 'param': 'dto.COMISIO_RES2'},
                    {'type': 'QueryType.QueryVehicleSummary', 'param': 'dto.VCACT_RES1'},
                    {'type': 'QueryType.ClientSummaryExtended', 'param': 'dto.OTROCOND_RES2'},
                    {'type': 'QueryType.ClientSummaryExtended', 'param': 'dto.OTRO2COND_RES2'},
                    {'type': 'QueryType.ClientSummaryExtended', 'param': 'dto.OTRO3COND_RES2'},
                    {'type': 'QueryType.ClientSummaryExtended', 'param': 'dto.CONDUCTOR_CON1'},
                    {'type': 'QueryType.QueryCity', 'param': 'dto.POCOND_RES2'},
                    {'type': 'QueryType.QueryCountry', 'param': 'dto.PAISNIFCOND_RES2'},
                    {'type': 'QueryType.QueryCountry', 'param': 'dto.PAISCOND_RES2'},
                    {'type': 'QueryType.QueryProvince', 'param': 'dto.PROVCOND_RES2'},
                    {'type': 'QueryType.QueryOrigin', 'param': 'dto.ORIGEN_RES1'},
                    {'type': 'QueryType.QueryBookingMedia', 'param': 'dto.MEDIO_RES1'},
                    {'type': 'QueryType.QueryBookingType', 'param': 'dto.TIPORES_RES1'},
                    {'type': 'QueryType.QueryAgencyEmployee', 'param': 'dto.EMPLEAGE_RES2'},
                    {'type': 'QueryType.QueryClientContacts', 'param':'dto.CONTACTO_RES2'},
                    {'type': 'QueryType.QueryPaymentForm', 'param':'dto.FCOBRO_RES1'},
                    {'type': 'QueryType.QueryPrintingType', 'param':'dto.CONTRATIPIMPR_RES'},
                    {'type': 'QueryType.QueryVehicleActivity', 'param':'dto.ACTIVEHI_RES1'}
                    ]

        self.__auxQueryResult = [ResultObject("OfficeDto", "OFICINA", "OfficeDto", "Value.OFICINA_RES1"),
                                 ResultObject("ReservationOfficeDeparture", "OFICINA","OfficeDto","Value.OFISALIDA_RES1"),
                                 ResultObject("ReservationOfficeArrival", "OFICINA", "OfficeDto", "Value.OFIRETORNO_RES1"),
                                 ResultObject("BudgetDto", "PRESUP1","BudgetDto", "Value.PRESUPUESTO_RES1"),
                                 ResultObject("FareDto", "NTARI", "FareDto","Value.TARIFA_RES1"),
                                 ResultObject("VehicleGroupDto", "GRUPOS", "VehicleGroupDto", "Value.GRUPO_RES1"),
                                 ResultObject("BrokerDto", "COMISIO","CommissionAgentSummaryDto","Value.COMISIO_RES2"),
                                 ResultObject("VehicleDto","VEHICULOS1", "VehicleSummaryDto","Value.VCACT_RES1"),
                                 ResultObject("DriverDto3","CLIENTES1", "ClientSummaryExtended", "Value.OTROCOND_RES2"),
                                 ResultObject("DriverDto4","CLIENTES1", "ClientSummaryExtended", "Value.OTRO2COND_RES2"),
                                 ResultObject("DriverDto5","CLIENTES1","ClientSummaryExtended", "Value.OTRO3COND_RES2"),
                                 ResultObject("DriverDto2","CLIENTES1","ClientSummaryExtended", "Value.CONDUCTOR_CON1"),
                                 ResultObject("CityDto3", "POBLACIONES","CityDto","Value.POCOND_RES2"),
                                 ResultObject("Country2Dto", "PAIS", "CountryDto","Value.PAISNIFCOND_RES2"),
                                 ResultObject("CountryDto3", "PAIS","CountryDto","Value.PAISCOND_RES2"),
                                 ResultObject("ProvinceDto3", "PROVINCIA","ProvinciaDto","Value.PROVCOND_RES2"),
                                 ResultObject("OriginDto", "ORIGEN","OriginDto","Value.ORIGEN_RES1"),
                                 ResultObject("BookingMediaDto", "MEDIO_RES","BookingMediaDto","Value.MEDIO_RES1"),
                                 ResultObject("BookingTypeDto", "TIPORES","BookingTypeDto","Value.TIPORES_res1"),
                                 ResultObject("AgencyEmployeeDto", "EAGE","AgencyEmployeeDto","Value.EMPLEAGE_RES2"),
                                 ResultObject("ContactsDto1", "CliContactos","ContactsDto","Value.CONTACTO_RES2"),
                                 ResultObject("PaymentFormDto", "FORMAS","PaymentFormDto","Value.FCOBRO_RES1"),
                                 ResultObject("PrintingTypeDto", "CONTRATIPIMPR","PrintingTypeDto","Value.CONTRATIPIMPR_RES"),
                                 ResultObject("VehicleActivitiesDto", "ACTIVEHI","VehicleActivitiesDto","Value.ACTIVEHI_RES1"),
                                       ]
    def generate(self, output='Generated'):
        dalGenerator =  dalgenerator.dal.DalGenerator("Booking","RESERVAS1","BookingSummaryPaged",self.__auxQuery, self.__auxQueryResult)
        dalGenerator.loadFile("dalgenerator/templates/dalaccess.tpl")
        dalGenerator.render(output)

if __name__ == "__main__":
    g = BookingDalGenerator()
    g.generate()
