#!/usr/bin/env python
"""
Dal generation data for the data access layer. It will be useful for creating 
the data access layer for a given table
"""
class DalData(object):
    def __init__(self):
        pass
    def __init__(self, domainName,tableName,summaryQueryName, auxQueries, auxResultQueries):
        self.__tablename = tableName
        self.__name = domainName
        self.__pagedquery = summaryQueryName
        self.__queries = auxQueries
        self.__queryResult = auxResultQueries
    @property
    def name(self):
        return self.__name
    @name.setter
    def name(self, x):
        self.__name = x
    @property
    def tablename(self):
        return self.__tablename
    @tablename.setter
    def tablename(self, x):
        self.__tablename= x
    @property
    def queryresult(self):
        return self.__queryResult
    @queryresult.setter
    def queryresult(self, x):
        self.__queryResult = x
    @property
    def queries(self):
        return self.__queries
    @queries.setter
    def queries(self, x):
        self.__queries = x
    @property
    def pagedquery(self):
        return self.__pagedquery
    @pagedquery.setter
    def pagedquery(self, x):
        self.__pagedquery= x

"""
SummaryData. Data useful for the generation of th e 
"""
class SummaryData(object):
    
    @property
    def name(self):
        return self.__name
    @name.setter
    def name(self, x):
        self.__name = x
    @property
    def baseuri(self):
        return self.__baseuri
    @baseuri.setter
    def baseuri(self, x):
        self.__baseuri = x
    @property
    def subsystem(self):
        return self.__subsystem
    @subsystem.setter
    def subsystem(self, x):
        self.__subsystem = x
    @property
    def infoviewmodel(self):
        return self.__infoviewmodel
    @infoviewmodel.setter
    def infoviewmodel(self, x):
        self.__infoviewmodel = x
    @property
    def module(self):
        return self.__module
    @module.setter
    def module(self, x):
        self.__module = x
    @property
    def namelower(self):
        return self.__namelower
    @namelower.setter
    def namelower(self, x):
        self.__namelower = x
    @property
    def summarytitle(self):
        return self.__summarytitle
    @summarytitle.setter
    def summarytitle(self, x):
        self.__summarytitle = x

"""
InfoViewModelData. Data useful for the generation of th e 
"""
class InfoViewModelData(object):
      @property
      def name(self):
        return self.__name
      @name.setter
      def name(self, x):
        self.__name = x
      @property
      def dto_values(self):
        return self.__dto_values
      @dto_values.setter
      def dto_values(self, x):
        self.__dto_values = x
      @property
      def baseuri(self):
        return self.__baseuri
      @baseuri.setter
      def baseuri(self, x):
        self.__baseuri = x
      @property
      def subsystem(self):
        return self.__subsystem
      @subsystem.setter
      def subsystem(self, x):
        self.__subsystem = x
      @property
      def modulename(self):
        return self.__modulename
      @modulename.setter
      def modulename(self, x):
        self.__modulename = x
      @property
      def assist(self):
        return self.__assist
      @assist.setter
      def assist(self, x):
        self.__assist = x


class SummaryControlViewModel(object):
      @property
      def name(self):
        return self.__name
      @name.setter
      def name(self, x):
        self.__name = x
      @property
      def localizedname(self):
        return self.__localizedname
      @localizedname.setter
      def localizedname(self, x):
        self.__localizedname= x
      @property
      def coldesc(self):
        return self.__coldesc
      @coldesc.setter
      def coldesc(self, x):
        self.__coldesc= x

class SummaryInfoViewModel(object):
      @property
      def name(self):
        return self.__name
      @name.setter
      def name(self, x):
        self.__name = x
      @property
      def localizedname(self):
        return self.__localizedname
      @localizedname.setter
      def localizedname(self, x):
        self.__localizedname= x
      @property
      def coldesc(self):
        return self.__coldesc
      @coldesc.setter
      def coldesc(self, x):
        self.__coldesc= x
      
class DataServiceData(object):
      @property
      def name(self):
        return self.__name
      @name.setter
      def name(self, x):
        self.__name = x
  
"""
InfoViewModelData. Data useful for the generation of th e 
"""
class DataSummaryDto(object):
      @property
      def name(self):
        return self.__name
      @name.setter
      def name(self, x):
        self.__name = x
      @property
      def dto_fields(self):
        return dto_fields
      @dto_fields.setter
      def dto_fields(self, x):
          dto_fields = x

