#!/usr/bin/env python
import os
import dalgenerator.dal
from dalgenerator.modeldata import *
from util.meta import *

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
                    {'type': 'QueryType.QueryCounty', 'param': 'dto.PAISCOND_RES2'},
                    {'type': 'QueryType.QueryProvince', 'param': 'dto.PROVCOND_RES2'}]

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
                                       ResultObject("ProvinceDto3", "PROVINCIA","ProvinciaDto","Value.PROVCOND_RES2")]
    def generate(self, output='dalbooking'):
        dalGenerator =  dalgenerator.dal.DalGenerator("Booking","RESERVAS1","BookingSummaryPaged",self.__auxQuery, self.__auxQueryResult)
        dalGenerator.loadFile("dalgenerator/templates/dalaccess.tpl")
        dalGenerator.render(output)

if __name__ == "__main__":
    g = BookingDalGenerator()
    g.generate()
