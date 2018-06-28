#!/usr/bin/env python
import os
import dalgenerator.dal
from dalgenerator.modeldata import *
from util.meta import *
"""
    Generate data layer
"""
def should_generate_dal_test():
    auxQuery = [{'type': 'QueryType.QueryVehicle', 'param': '_domainObject.VEHICLE'}, {'type': 'QueryType.QueryFares', 'param': '_domainObject.FARES'}]
    auxQueryResult = [ResultObject("VehicleDto", "CODIINT", "VehicleDto", "Value.CODIINT"),ResultObject("FareDto", "NTARI", "FareDto", "Value.FARES")]
    dalGenerator =  dalgenerator.dal.DalGenerator("User","USUARIO","UserSummaryPaged",auxQuery, auxQueryResult)
    correctTemplate = ""
    dalGenerator.loadFile("dalgenerator/templates/dalaccess.tpl")
    dalGenerator.render()
    #assert correctTemplate == render
"""
    Generate view model grid de consulta
"""
def should_generate_summaryviewmodel_test():
    summaryData= SummaryData()
    summaryData.name = "User"
    summaryData.modulename = "Users"
    summaryData.summarytitle = "Usuarios"
    summaryData.namelower = "user"
    summaryData.subsystem = "Account"
    summaryData.baseuri = "accounting/users"
    summaryData.infoviewmodel = "UserViewModelInfo"
    generator =  dalgenerator.dal.SummaryViewGenerator()
    generator.data = summaryData
    generator.loadFile("dalgenerator/templates/summaryviewmodel.tpl")
    generator.render()

"""
    Generate data object por grid de consulta
"""
def should_generate_summarydto_test():
    dtofields= [ MetaSummaryDto("Name","string", "Nombre Usuario", "Nombre", "name"), MetaSummaryDto("Office","string", "Oficina", "Oficina", "oficina")]
    generator = dalgenerator.dal.SummaryDtoGenerator()
    summaryDto = DataSummaryDto()
    summaryDto.name = "User"
    summaryDto.dtofields = dtofields
    generator.data = summaryDto
    generator.loadFile("dalgenerator/templates/dtosummary.tpl")
    generator.render()
"""
    Generate view model for ficha de modifica
"""
def should_generate_infoviewmodel_test():
    dtometa = [MetaAssist("CLIENT_ASSIST_TYPE", "Client", "clientDto"),MetaAssist("CITY_ASSIST", "CityDto", "cityDto")]
    dto_values = [MetaDto("ClientDto", "clientDto"), MetaDto("CityDto", "cityDto")]
    infomodelviewdata = dalgenerator.dal.InfoViewModelData()
    infomodelviewdata.name = "User"
    infomodelviewdata.dto_values = dto_values
    infomodelviewdata.assist_list = dtometa
    infomodelviewdata.baseuri = "accounting/users"
    infomodelviewdata.subsystem = "Account"
    infomodelviewdata.modulename = "Users"
    generator = dalgenerator.dal.InfoViewGenerator()
    generator.data = infomodelviewdata
    generator.loadFile("dalgenerator/templates/infoviewmodel.tpl")
    generator.render()
"""
Generate view model for ficha de consulta.
"""
def should_generate_summaryview_test():
    summaryviewdata = SummaryControlViewModel()
    summaryviewdata.modulename = "Users"
    summaryviewdata.localizedname = "lusuarios"
    summaryviewdata.name = "User"
    summaryviewdata.coldesc = [MetaCol("Nombre","lnombre", "Nombre", "Name"), MetaCol("Oficina","loficina", "Oficina","Office")]
    generator = dalgenerator.dal.ControlViewGenerator()
    generator.data = summaryviewdata
    generator.loadFile("dalgenerator/templates/summaryview.xml")
    generator.render()


    

   

    












