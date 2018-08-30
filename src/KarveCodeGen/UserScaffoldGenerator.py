#!/usr/bin/env python
import os
import dalgenerator.dal
from dalgenerator.modeldata import *
from util.meta import *

class UserScaffoldGenerator(object):

    def __init__(self):
        self.__auxQuery = [{'type': 'QueryType.QueryOffice', 'param': 'dto.OFI_COD'}]
        self.__auxQueryResult = [ResultObject("UserOfficeDto", "OFICINA", "OfficeViewObject", "Value.OFI_COD")]

    def generateInfoviewmodel(self, output='Generated'):
        dtometa = [MetaAssist("OFFICE_ASSIST", "UserOfficeDto", "officeDto")]
        dto_values = [MetaDto("Office", "clientDto"), MetaDto("CityDto", "cityDto")]
        infomodelviewdata = dalgenerator.dal.InfoViewModelData()
        infomodelviewdata.name = "User"
        infomodelviewdata.dto_values = dto_values
        infomodelviewdata.assist_list = dtometa
        infomodelviewdata.baseuri = "user"
        infomodelviewdata.subsystem = "Users"
        infomodelviewdata.modulename = "Users"
        generator = dalgenerator.dal.InfoViewGenerator()
        generator.data = infomodelviewdata
        generator.loadFile("dalgenerator/templates/infoviewmodel.tpl")
        generator.render()

    def generateSummary(self, output='Generated'):
        summaryData= SummaryData()
        summaryData.name = "Users"
        summaryData.modulename = "Users"
        summaryData.summarytitle = "Usuarios"
        summaryData.namelower = "incident"
        summaryData.subsystem = "UserSubsystem"
        summaryData.baseuri = "user"
        summaryData.infoviewmodel = "UserViewModelInfo"
        generator =  dalgenerator.dal.SummaryViewGenerator()
        generator.data = summaryData
        generator.loadFile("dalgenerator/templates/summaryviewmodel.tpl")
        generator.render()

    def generateSummaryView(self, output='Generated'):
        summaryData= SummaryData()
        summaryData.name = "User"
        summaryData.modulename = "User"
        summaryData.summarytitle = "Usuarios"
        summaryData.namelower = "usuarios"
        summaryData.subsystem = "Users"
        summaryData.baseuri = "b"
        summaryData.infoviewmodel = "UserViewModelInfo"
        generator =  dalgenerator.dal.SummaryViewGenerator()
        generator.data = summaryData
        generator.loadFile("dalgenerator/templates/summaryviewmodel.tpl")
        generator.render()

    def generateSummaryDto(self, output='Generated'):
        dtofields= [
        MetaSummaryDto("Code","string", "Codigo Oficina", "Codigo", "code"),
        MetaSummaryDto("Oficina","string", "Codigo Oficina", "Oficina", "booking"),
        MetaSummaryDto("Name","string", "Nombre Incidencia", "Nombre", "name"),
        MetaSummaryDto("Password","string", "Password", "Password", "password")
        ]
        generator = dalgenerator.dal.SummaryDtoGenerator()
        summaryDto = DataSummaryDto()
        summaryDto.name = "User"
        summaryDto.dtofields = dtofields
        generator.data = summaryDto
        generator.loadFile("dalgenerator/templates/dtosummary.tpl")
        generator.render()

    def generateDal(self, output='Generated'):
        dalGenerator =  dalgenerator.dal.DalGenerator("Users","USURE","UserSummaryPaged",self.__auxQuery, self.__auxQueryResult)
        dalGenerator.loadFile("dalgenerator/templates/dalaccess.tpl")
        dalGenerator.render(output)

if __name__ == "__main__":
    g = UserScaffoldGenerator()
    g.generateDal()
    g.generateSummary()
    g.generateSummaryDto()
    g.generateSummaryView()
    g.generateInfoviewmodel()
