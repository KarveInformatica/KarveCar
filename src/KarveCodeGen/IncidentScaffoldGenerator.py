#!/usr/bin/env python
import os
import dalgenerator.dal
from dalgenerator.modeldata import *
from util.meta import *

class IncidentScaffoldGenerator(object):
    def __init__(self):
        self.__auxQuery = [{'type': 'QueryType.QueryOffice', 'param': 'dto.OFICINA'},
                    {'type': 'QueryType.QuerySupplierSummary', 'param': 'dto.PROVEE'},
                    {'type': 'QueryType.QueryVehicleSummary', 'param': 'dto.VEHI'},
                    {'type': 'QueryType.ClientSummaryExtended', 'param': 'dto.CLIENTE'},
                    {'type': 'QueryType.IncidentType', 'param': 'dto.COINRE'}]

        self.__auxQueryResult = [ResultObject("IncidentOfficeDto", "OFICINA", "OfficeDto", "Value.OFICINA"),
                                 ResultObject("IncidentSupplierDto", "PROVEE1","SupplierSummaryDto","Value.PROVEE"),
                                 ResultObject("IncidentVehicleDto","VehicleSummaryDto", "VehicleSummaryDto","Value.VEHI"),
                                 ResultObject("IncidentClientDto","ClientSummaryExtended", "ClientSummaryExtended", "Value.CLIENTE"),
                                 ResultObject("IncidentTypeDto","COINRE", "IncidentTypeDto", "Value.TIPO")
                                 ]

    def generateInfoviewmodel(self, output='Generated'):
        dtometa = [MetaAssist("CLIENT_ASSIST_TYPE", "IncidentClientDto", "clientDto"),
                   MetaAssist("SUPPLIER_ASSIST_TYPE", "IncidentSupplierDto", "supplierDto"),
                   MetaAssist("OFFICE_ASSIST", "IncidentOfficeDto", "officeDto"),
                   MetaAssist("VEHICLE_ASSIST", "IncidentVehicleDto","vehicleDto"),
                   MetaAssist("BOOKING_INCIDENT_TYPE", "BookingIncidentTypeDto", "bookingIncidentType")]
        dto_values = [MetaDto("ClientDto", "clientDto"), MetaDto("CityDto", "cityDto")]
        infomodelviewdata = dalgenerator.dal.InfoViewModelData()
        infomodelviewdata.name = "BookingIncident"
        infomodelviewdata.dto_values = dto_values
        infomodelviewdata.assist_list = dtometa
        infomodelviewdata.baseuri = "booking/incident"
        infomodelviewdata.subsystem = "Booking"
        infomodelviewdata.modulename = "Booking"
        generator = dalgenerator.dal.InfoViewGenerator()
        generator.data = infomodelviewdata
        generator.loadFile("dalgenerator/templates/infoviewmodel.tpl")
        generator.render()

    def generateSummary(self, output='Generated'):
        summaryData= SummaryData()
        summaryData.name = "BookingIncident"
        summaryData.modulename = "Booking"
        summaryData.summarytitle = "Incidencias"
        summaryData.namelower = "incident"
        summaryData.subsystem = "BookingSubsystem"
        summaryData.baseuri = "booking/incident"
        summaryData.infoviewmodel = "BookingIncidentViewModelInfo"
        generator =  dalgenerator.dal.SummaryViewGenerator()
        generator.data = summaryData
        generator.loadFile("dalgenerator/templates/summaryviewmodel.tpl")
        generator.render()
    def generateSummaryView(self, output='Generated'):
        summaryData= SummaryData()
        summaryData.name = "IncidentBooking"
        summaryData.modulename = "Booking"
        summaryData.summarytitle = "Incidencias Reserva"
        summaryData.namelower = "incidencias"
        summaryData.subsystem = "Booking"
        summaryData.baseuri = "booking/incidents"
        summaryData.infoviewmodel = "BookingIncidentViewModelInfo"
        generator =  dalgenerator.dal.SummaryViewGenerator()
        generator.data = summaryData
        generator.loadFile("dalgenerator/templates/summaryviewmodel.tpl")
        generator.render()

    def generateSummaryDto(self, output='Generated'):
        dtofields= [ MetaSummaryDto("Code","string", "Codigo Incidencia Reserva", "Codigo", "code"),
        MetaSummaryDto("Booking","string", "Numero Reserva", "Reserva", "booking"),
        MetaSummaryDto("Name","string", "Nombre Incidencia", "Nombre", "name")]
        generator = dalgenerator.dal.SummaryDtoGenerator()
        summaryDto = DataSummaryDto()
        summaryDto.name = "BookingIncident"
        summaryDto.dtofields = dtofields
        generator.data = summaryDto
        generator.loadFile("dalgenerator/templates/dtosummary.tpl")
        generator.render()

    def generateDal(self, output='Generated'):
        dalGenerator =  dalgenerator.dal.DalGenerator("BookingIncident","INCIRE","BookingIncidentSummaryPaged",self.__auxQuery, self.__auxQueryResult)
        dalGenerator.loadFile("dalgenerator/templates/dalaccess.tpl")
        dalGenerator.render(output)

if __name__ == "__main__":
    g = IncidentScaffoldGenerator()
    g.generateDal()
    g.generateSummary()
    g.generateSummaryDto()
    g.generateSummaryView()
    g.generateInfoviewmodel()
