#!/usr/bin/env python
import os
from util import meta
from dalgenerator.modeldata import *
from jinja2 import Template
"""This module provide standard generators for creating a new window in KarveCar"""


class BaseGenerator(object):
    """
    Base generator class that allows us to load/write a file.
    """
    def __init__(self):
        self.contentValue = None
    @property
    def contentValue(self):
        return self.__contentValue
    @contentValue.setter
    def contentValue(self, x ):
        self.__contentValue = x

    def loadFile(self, fileName):
        with open(fileName) as f:
            self.contentValue = f.read()
    def writeFile(self, dir, domainName, name, output):
        fileName = ''.join([dir,"/", domainName, name])
        with open(fileName, "w+") as outFile:
            outFile.write(output)
    def render(self):
        pass


class DalGenerator(BaseGenerator):
    """
     Data access layer generator that allows us to write the code for a given entity to be loaded
      and its helpers tables that are needed for working correctly.
    """
    def __init__(self, domainName, tablename, summaryQueryName, auxQueries, auxResultQueries):
        """Constructors.
         Args:
        domainName: Name of the domain to be used.
        tableName: Name of the entity table to be used.
        summaryQueryName: Tag of the QueryStore class used for asking the summary table
        auxQueries: Tag of the QueryStore class used for aux tables using Dapper QueryMultiple
        auxResultQueries: Couple of item that represent  class used for aux tables results.
        """
        super()
        self.__domainName = domainName
        print("Processing table " + tablename)
        self.__tableName = tablename
        self.__summaryQueryName = summaryQueryName
        self.__auxQueries = auxQueries
        self.__auxResultQueries = auxResultQueries

    def render(self, output='output'):
        """
           Resolve the input variables and create a DataAccessLayer csharp file for doing load/store.
        """
        template = Template(super().contentValue)
        dalgeneration = DalData(self.__domainName, self.__tableName, self.__summaryQueryName, self.__auxQueries, self.__auxResultQueries)
        outstring= template.render(data = dalgeneration)
        currentOutput = os.path.join(os.getcwd(), output)
        if ( not os.path.exists(currentOutput)):
                os.makedirs(os.path.join(os.getcwd(), output))
        # here we are sure that the dir exists
        self.writeFile(currentOutput, self.__domainName, "DataAccessLayer.cs", outstring)


class SummaryViewGenerator(BaseGenerator):
    """
      Generate a SummaryControlViewModel. Each table has a info view model and control view model.
      The control view model just is used for showing the main grid and opening other items.
    """
    def __init__(self):
        super()
    @property
    def data(self):
        """
        Get the data needed for the resolution.
        """
        return self.__dataGenerator
    @data.setter
    def data(self, x):
        """
        Set the data needed for the resolution.
        """
        self.__dataGenerator = x

    def render(self):
        template = Template(super().contentValue)
        outstring= template.render(data = self.data)
        currentOutput = os.path.join(os.getcwd(), 'output')
        if ( not os.path.exists(currentOutput)):
                os.makedirs(os.path.join(os.getcwd(), 'output'))
        self.writeFile(currentOutput, self.data.name, "ControlViewModel.cs", outstring)

class InfoViewGenerator(SummaryViewGenerator):
       """
          Generate a InfoViewModel for a given domain element.
       """
       def render(self):
        template = Template(super().contentValue)
        outstring= template.render(data = self.data)
        currentOutput = os.path.join(os.getcwd(), 'output')
        if ( not os.path.exists(currentOutput)):
                os.makedirs(os.path.join(os.getcwd(), 'output'))
        self.writeFile(currentOutput, self.data.name, "InfoViewModel.cs", outstring)

class SummaryDtoGenerator(BaseGenerator):
    """
    SummaryDtoGenerator. It creates the transfer object for the summary info view model.
    """
    def __init():
        super()
    @property
    def data(self):
        """
         Get the data needed for the resolution.
        """
        return self.__dataGenerator
    @data.setter
    def data(self, x):
        """
         Set the data needed for the resolution.
        """
        self.__dataGenerator = x
    def render(self):
        """
           Resolve the input variables and create a DataAccessLayer csharp file for doing load/store.
        """
        template = Template(super().contentValue)
        outstring= template.render(data = self.__dataGenerator)
        currentOutput = os.path.join(os.getcwd(), 'output')
        if ( not os.path.exists(currentOutput)):
                os.makedirs(os.path.join(os.getcwd(), 'output'))
        # here we are sure that the dir exists

        self.writeFile(currentOutput, self.data.name, "SummaryDto.cs", outstring)

class ControlViewGenerator(BaseGenerator):
    """
    ControlViewGenerator. It creates the control view.
    """
    def __init():
        super()
    @property
    def data(self):
        """
         Get the data needed for the resolution.
        """
        return self.__dataGenerator
    @data.setter
    def data(self, x):
        """
         Set the data needed for the resolution.
        """
        self.__dataGenerator = x
    def render(self):
        """
           Resolve the input variables and create a DataAccessLayer csharp file for doing load/store.
        """
        template = Template(super().contentValue)
        outstring= template.render(data = self.__dataGenerator)
        currentOutput = os.path.join(os.getcwd(), 'output')
        if ( not os.path.exists(currentOutput)):
                os.makedirs(os.path.join(os.getcwd(), 'output'))
        # here we are sure that the dir exists
        self.writeFile(currentOutput, self.data.name, "ControlView.xml", outstring)
